using DevExpress.XtraEditors;
using Microsoft.EntityFrameworkCore;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale
{
    public class EfMethods
    {
        //private subContext db;
        public EfMethods()
        {
            //this.db = new subContext();
        }


        public List<TrInvoiceLine> SelectInvoiceLines(Guid invoiceHeaderId)
        {
            using (subContext db = new subContext())
            {
                List<TrInvoiceLine> InvoiceLines = db.TrInvoiceLines.Include(x => x.DcProduct)
                                        .Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                                        .OrderBy(x => x.CreatedDate)
                                        .ToList();

                InvoiceLines.ForEach(x =>
                {
                    x.ReturnQty = db.TrInvoiceLines.Where(y => y.RelatedLineId == x.InvoiceLineId).Sum(s => s.Qty);
                    x.RemainingQty = db.TrInvoiceLines.Where(y => y.RelatedLineId == x.InvoiceLineId).Sum(s => s.Qty) + x.Qty;
                });

                #region Comment
                //List<TrInvoiceLine> linqInvoiceLine = (from i in db.TrInvoiceLines
                //                   join p in db.DcProducts on i.ProductCode equals p.ProductCode
                //                   where i.InvoiceHeaderId == invoiceHeaderId
                //                   orderby i.CreatedDate
                //                   select new TrInvoiceLine
                //                   {                                       
                //                       ReturnQty = db.TrInvoiceLines.Where(x => x.RelatedLineId == i.InvoiceLineId).Sum(x => x.Qty),
                //                       RemainingQty = i.Qty + db.TrInvoiceLines.Where(x => x.RelatedLineId == i.InvoiceLineId).Sum(x => x.Qty),
                //                   }).ToList(); 
                #endregion


                return InvoiceLines;
            }
        }

        public decimal SelectInvoiceNetAmount(Guid invoiceHeaderId)
        {
            using (subContext db = new subContext())
            {
                decimal sumNetAmount = db.TrInvoiceLines.Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                                                        .Sum(x => x.NetAmount);
                return sumNetAmount;
            }
        }

        public List<DcProduct> SelectProducts()
        {
            using (subContext db = new subContext())
            {
                return db.DcProducts.ToList();
            }
        }

        public List<TrInvoiceHeader> SelectInvoiceHeaders()
        {
            using (subContext db = new subContext())
            {
                return db.TrInvoiceHeaders.Where(x => x.IsCompleted == true)
                                          .OrderBy(x => x.CreatedDate)
                                          .ToList();
            }
        }

        public TrInvoiceLine SelectInvoiceLine(Guid invoiceLineId)
        {
            using (subContext db = new subContext())
            {
                return db.TrInvoiceLines.FirstOrDefault(x => x.InvoiceLineId == invoiceLineId);
            }
        }

        public List<TrInvoiceLine> SelectInvoiceLineForReport(Guid invoiceHeaderId)
        {
            using (subContext db = new subContext())
            {
                return db.TrInvoiceLines.Include(x => x.TrInvoiceHeader)
                                            .ThenInclude(x => x.DcCurrAcc)
                                        .Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                                        .ToList();
            }
        }

        public int InsertInvoiceLine(DcProduct dcProduct, Guid invoiceHeaderId)
        {
            using (subContext db = new subContext())
            {
                IQueryable<DcProduct> dcProducts = db.DcProducts.AsQueryable();

                if (!string.IsNullOrEmpty(dcProduct.ProductCode))
                    dcProducts = dcProducts.Where(x => x.ProductCode == dcProduct.ProductCode);
                else if (!string.IsNullOrEmpty(dcProduct.Barcode))
                    dcProducts = dcProducts.Where(x => x.Barcode == dcProduct.Barcode);

                DcProduct product = dcProducts.FirstOrDefault();

                if (product != null)
                {
                    TrInvoiceLine trInvoiceLine = new TrInvoiceLine()
                    {
                        InvoiceLineId = Guid.NewGuid(),
                        InvoiceHeaderId = invoiceHeaderId,
                        ProductCode = product.ProductCode,
                        Price = product.RetailPrice,
                        Amount = Convert.ToDecimal(product.RetailPrice),
                        PosDiscount = Convert.ToDecimal(product.PosDiscount),
                        NetAmount = Convert.ToDecimal(product.RetailPrice - product.PosDiscount)
                    };

                    db.TrInvoiceLines.Add(trInvoiceLine);
                    return db.SaveChanges();
                }
                else
                    return -1;
            }
        }

        public int InsertInvoiceLine(TrInvoiceLine TrInvoiceLine)
        {
            using (subContext db = new subContext())
            {
                db.TrInvoiceLines.Add(TrInvoiceLine);
                return db.SaveChanges();
            }
        }

        public bool InvoiceLineExist(Guid invoicecHeaderId, Guid relatedLineId)
        {
            using (subContext db = new subContext())
            {
                return db.TrInvoiceLines.Where(x => x.InvoiceHeaderId == invoicecHeaderId)
                                        .Any(x => x.RelatedLineId == relatedLineId);
            }
        }

        public bool InvoiceHeaderExist(Guid invoiceHeaderId)
        {
            using (subContext db = new subContext())
            {
                return db.TrInvoiceHeaders.Any(x => x.InvoiceHeaderId == invoiceHeaderId);
            }
        }

        public void InsertInvoiceHeader(TrInvoiceHeader TrInvoiceHeader)
        {
            using (subContext db = new subContext())
            {
                db.TrInvoiceHeaders.Add(TrInvoiceHeader);
                db.SaveChanges();
            }
        }

        public int DeleteInvoice(Guid invoiceHeaderId)
        {
            using (subContext db = new subContext())
            {
                TrInvoiceHeader trInvoiceHeader = new TrInvoiceHeader() { InvoiceHeaderId = invoiceHeaderId };
                db.TrInvoiceHeaders.Remove(trInvoiceHeader);

                IQueryable<TrInvoiceLine> trInvoiceLine = db.TrInvoiceLines.Where(x => x.InvoiceHeaderId == invoiceHeaderId);
                if (trInvoiceLine.Any())
                    db.TrInvoiceLines.Remove(trInvoiceLine.First());

                return db.SaveChanges();
            }
        }

        public int DeleteInvoiceLine(object invoiceLineId)
        {
            using (subContext db = new subContext())
            {
                TrInvoiceLine trInvoiceLine = new TrInvoiceLine() { InvoiceLineId = Guid.Parse(invoiceLineId.ToString()) };
                db.TrInvoiceLines.Remove(trInvoiceLine);
                return db.SaveChanges();
            }
        }

        public int UpdateInvoiceIsCompleted(Guid invoiceHeaderId)
        {
            using (subContext db = new subContext())
            {
                TrInvoiceHeader trInvoiceHeader = new TrInvoiceHeader() { InvoiceHeaderId = invoiceHeaderId, IsCompleted = true };
                db.Entry(trInvoiceHeader).Property(x => x.IsCompleted).IsModified = true;
                return db.SaveChanges();
            }
        }

        public int UpdateInvoiceLineQty(object invoiceLineId, int qty)
        {
            Guid variable = Guid.Parse(invoiceLineId.ToString());

            using (subContext db = new subContext())
            {
                TrInvoiceLine trInvoiceLine = db.TrInvoiceLines.FirstOrDefault(x => x.InvoiceLineId == variable);

                trInvoiceLine.PosDiscount = qty * (trInvoiceLine.PosDiscount / trInvoiceLine.Qty); // qty is new quantity trInvoiceLine.Qty is old quantity
                trInvoiceLine.Amount = qty * Convert.ToDecimal(trInvoiceLine.Price);
                trInvoiceLine.NetAmount = trInvoiceLine.Amount - trInvoiceLine.PosDiscount;
                trInvoiceLine.Qty = qty;

                db.TrInvoiceLines.Update(trInvoiceLine);
                return db.SaveChanges();
            }
        }

        public int UpdateInvoiceLineQty(object invoiceHeaderId, object relatedLineId, int qty)
        {
            Guid HeaderId = Guid.Parse(invoiceHeaderId.ToString());
            Guid relatedId = Guid.Parse(relatedLineId.ToString());

            using (subContext db = new subContext())
            {
                TrInvoiceLine trInvoiceLine = db.TrInvoiceLines.Where(x => x.RelatedLineId == relatedId)
                                                   .FirstOrDefault(x => x.InvoiceHeaderId == HeaderId);

                trInvoiceLine.PosDiscount = qty * (trInvoiceLine.PosDiscount / trInvoiceLine.Qty); // qty is new quantity trInvoiceLine.Qty is old quantity
                trInvoiceLine.Amount = qty * Convert.ToDecimal(trInvoiceLine.Price);
                trInvoiceLine.NetAmount = trInvoiceLine.Amount - trInvoiceLine.PosDiscount;
                trInvoiceLine.Qty = qty;

                db.TrInvoiceLines.Update(trInvoiceLine);
                return db.SaveChanges();
            }
        }

        public int UpdateInvoicePosDiscount(TrInvoiceLine trInvoiceLine)
        {
            using (subContext db = new subContext())
            {
                //db.TrInvoiceLine.Attach(TrInvoiceLine);
                db.Entry(trInvoiceLine).Property(x => x.PosDiscount).IsModified = true;
                db.Entry(trInvoiceLine).Property(x => x.NetAmount).IsModified = true;
                return db.SaveChanges();
            }
        }

        public int UpdateInvoiceCurrAccCode(Guid invoiceHeaderId, string currAccCode)
        {
            using (subContext db = new subContext())
            {
                TrInvoiceHeader trInvoiceHeader = new TrInvoiceHeader() { InvoiceHeaderId = invoiceHeaderId, CurrAccCode = currAccCode };
                db.Entry(trInvoiceHeader).Property(x => x.CurrAccCode).IsModified = true;
                return db.SaveChanges();
            }
        }

        public int UpdateInvoiceSalesPerson(Guid invoiceLineId, string currAccCode)
        {
            using (subContext db = new subContext())
            {
                TrInvoiceLine trInvoiceLine = new TrInvoiceLine() { InvoiceLineId = invoiceLineId, SalesPersonCode = currAccCode };
                db.Entry(trInvoiceLine).Property(x => x.SalesPersonCode).IsModified = true;
                return db.SaveChanges();
            }
        }

        public int InsertCustomer(DcCurrAcc dcCurrAcc)
        {
            using (subContext db = new subContext())
            {
                db.DcCurrAccs.Add(dcCurrAcc);
                return db.SaveChanges();
            }
        }

        public bool CustomerExist(string CurrAccCode)
        {
            using (subContext db = new subContext())
            {
                return db.DcCurrAccs.Any(x => x.CurrAccCode == CurrAccCode);
            }
        }

        public int UpdateCustomer(DcCurrAcc dcCurrAcc)
        {
            using (subContext db = new subContext())
            {
                db.DcCurrAccs.Update(dcCurrAcc);
                return db.SaveChanges();
            }
        }

        public int InsertPaymentHeader(TrPaymentHeader trPaymentHeader)
        {
            using (subContext db = new subContext())
            {
                db.TrPaymentHeaders.Add(trPaymentHeader);
                return db.SaveChanges();
            }
        }

        public int InsertPaymentLine(TrPaymentLine trPaymentLine)
        {
            using (subContext db = new subContext())
            {
                db.TrPaymentLines.Add(trPaymentLine);
                return db.SaveChanges();
            }
        }

        public bool PaymentHeaderExist(Guid invoiceHeaderId)
        {
            using (subContext db = new subContext())
            {
                return db.TrPaymentHeaders.Any(x => x.InvoiceHeaderId == invoiceHeaderId);
            }
        }

        public List<TrPaymentLine> SelectPaymentLines(Guid invoiceHeaderId)
        {
            using (subContext db = new subContext())
            {
                return db.TrPaymentLines.Include(x => x.TrPaymentHeader)
                                            .ThenInclude(x => x.TrInvoiceHeader)
                                        .Include(x => x.DcPaymentType)
                                        .Where(x => x.TrPaymentHeader.InvoiceHeaderId == invoiceHeaderId)
                                        .ToList();
            }
        }

        public List<DcCurrAcc> SelectCurrAccs()
        {
            using (subContext db = new subContext())
            {
                return db.DcCurrAccs.Where(x => x.IsDisabled == false)
                                    .OrderBy(x => x.CreatedDate)
                                    .ToList(); // burdaki kolonlari dizaynda da elave et
            }
        }

        public DcCurrAcc SelectCurrAcc(string currAccCode)
        {
            using (subContext db = new subContext())
            {
                return db.DcCurrAccs.Where(x => x.IsDisabled == false)
                                    .FirstOrDefault(x => x.CurrAccCode == currAccCode);
            }
        }

        public List<DcOffice> SelectOffices()
        {
            using (subContext db = new subContext())
            {
                return db.DcOffices.Where(x => x.IsDisabled == false)
                                   .OrderBy(x => x.CreatedDate)
                                   .ToList(); // burdaki kolonlari dizaynda da elave et
            }
        }

        public List<DcStore> SelectStores()
        {
            using (subContext db = new subContext())
            {
                return db.DcStores.Where(x => x.IsDisabled == false)
                                  .OrderBy(x => x.CreatedDate)
                                  .ToList(); // burdaki kolonlari dizaynda da elave et
            }
        }

        public List<DcWarehouse> SelectWarehouses()
        {
            using (subContext db = new subContext())
            {
                return db.DcWarehouses.Where(x => x.IsDisabled == false)
                                      .OrderBy(x => x.CreatedDate)
                                      .ToList(); // burdaki kolonlari dizaynda da elave et
            }
        }

        public bool CurrAccExist(string CurrAccCode, string Password)
        {
            if (string.IsNullOrEmpty(Password.Trim()))
                return false;
            else
            {
                using (subContext db = new subContext())
                {
                    return db.DcCurrAccs.Where(x => x.IsDisabled == false)
                                        .Where(x => x.CurrAccCode == CurrAccCode)
                                        .Any(x => x.Password == Password);
                }
            }
        }

        public List<DcRole> SelectRoles(string CurrAccCode)
        {
            using (subContext db = new subContext())
            {
                return db.DcRoles.Include(x => x.TrCurrAccRoles)
                    .ThenInclude(x => x.DcCurrAcc)
                    .Where(o => o.TrCurrAccRoles.Any(x => x.CurrAccCode == CurrAccCode))
                                 .ToList();
            }
        }
    }
}
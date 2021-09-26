using Microsoft.EntityFrameworkCore;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace PointOfSale
{
    public class SqlMethods
    {
        private string subConnString = Properties.Settings.Default.subConnString;
        private SqlParameter[] paramArray = new SqlParameter[] { };
        //private subContext db;

        public SqlMethods()
        {
            //this.db = new subContext();
        }

        public int SqlExec(string query, SqlParameter[] sqlParameters)
        {
            using (SqlConnection con = new SqlConnection(subConnString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddRange(sqlParameters);
                    con.Open();

                    int result = cmd.ExecuteNonQuery();

                    if (result < 0)
                        MessageBox.Show("Data Əlavə edilməsində xəta baş verdi!");
                    return result;
                }
            }
        }

        public DataTable SqlGetDt(string query, SqlParameter[] sqlParameters)
        {
            using (SqlConnection con = new SqlConnection(subConnString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {
                    da.SelectCommand.Parameters.AddRange(sqlParameters);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public string GetNextDocNum(string processCode, string columnName, string tableName)
        {
            string qry = "dbo.GetNextDocNum @ProcessCode = @ProcessCode, @ColumnName = @ColumnName, @TableName = @TableName";
            paramArray = new SqlParameter[]
             {
                new SqlParameter("@ProcessCode", processCode),
                new SqlParameter("@ColumnName", columnName),
                new SqlParameter("@TableName", tableName)
             };
            DataTable dt = SqlGetDt(qry, paramArray);
            return dt.Rows[0][0].ToString();
        }

        public List<DcProduct> SelectProducts()
        {
            using (subContext db = new subContext())
            {
                return db.DcProducts.ToList();
            }
        }

        public List<TrInvoiceHeader> SelectInvoiceHeader()
        {
            using (subContext db = new subContext())
            {
                return db.TrInvoiceHeaders.OrderBy(x => x.CreatedDate).ToList();
            }
        }

        public DataTable SelectInvoiceLine(Guid invoiceHeaderId)
        {
            string qry = "select TrInvoiceLines.*, ProductDescription, Barcode" +
                ", ReturnQty = ISNULL((select sum(Qty) from TrInvoiceLines returnLine where returnLine.RelatedLineId = TrInvoiceLines.InvoiceLineId),0) " +
                ", RemainingQty = Qty + ISNULL((select sum(Qty) from TrInvoiceLines returnLine where returnLine.RelatedLineId = TrInvoiceLines.InvoiceLineId),0) " +
                "from TrInvoiceLines " +
                "left join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode " +
                "where InvoiceHeaderId = @InvoiceHeaderId " +
                "order by CreatedDate"; // burdaki kolonlari dizaynda da elave et

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceHeaderId", invoiceHeaderId)
            };
            return SqlGetDt(qry, paramArray);
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

        public bool InvoiceLineExist(Guid invoicecHeaderId, object relatedLineId)
        {
            using (subContext db = new subContext())
            {
                return db.TrInvoiceLines.Where(x => x.InvoiceLineId == invoicecHeaderId)
                                        .Any(x => x.RelatedLineId == invoicecHeaderId);
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

                db.TrInvoiceLines.Remove(db.TrInvoiceLines.Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                                                          .FirstOrDefault());

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

        public int InsertCustomer(DcCurrAcc dcCurrAcc)
        {
            using (subContext db = new subContext())
            {
                db.DcCurrAccs.Add(dcCurrAcc);
                return db.SaveChanges();
            }
        }

        public int UpdateCurrAccCode(string currAccCode, Guid invoiceHeaderId)
        {
            using (subContext db = new subContext())
            {
                TrInvoiceHeader trInvoiceHeader = new TrInvoiceHeader() { InvoiceHeaderId = invoiceHeaderId, CurrAccCode = currAccCode };
                db.Entry(trInvoiceHeader).Property(x => x.CurrAccCode).IsModified = true;
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

        public List<TrPaymentLine> SelectPaymentLine(Guid invoiceHeaderId)
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

        public List<DcCurrAcc> SelectCurrAcc()
        {
            using (subContext db = new subContext())
            {
                return db.DcCurrAccs.Where(x => x.IsDisabled == false)
                                    .OrderBy(x => x.CreatedDate)
                                    .ToList(); // burdaki kolonlari dizaynda da elave et
            }
        }

        public List<DcOffice> SelectOffice()
        {
            using (subContext db = new subContext())
            {
                return db.DcOffices.Where(x => x.IsDisabled == false)
                                   .OrderBy(x => x.CreatedDate)
                                   .ToList(); // burdaki kolonlari dizaynda da elave et
            }
        }

        public List<DcStore> SelectStore()
        {
            using (subContext db = new subContext())
            {
                return db.DcStores.Where(x => x.IsDisabled == false)
                                  .OrderBy(x => x.CreatedDate)
                                  .ToList(); // burdaki kolonlari dizaynda da elave et
            }
        }

        public List<DcWarehouse> SelectWarehouse()
        {
            using (subContext db = new subContext())
            {
                return db.DcWarehouses.Where(x => x.IsDisabled == false)
                                      .OrderBy(x => x.CreatedDate)
                                      .ToList(); // burdaki kolonlari dizaynda da elave et
            }
        }
    }
}

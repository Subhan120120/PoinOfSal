using DevExpress.Utils.VisualEffects;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using PointOfSale.Models;
using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale
{
    public partial class FormInvoice : RibbonForm
    {
        Badge badge1;
        Badge badge2;
        AdornerUIManager adornerUIManager1;

        public Guid invoiceHeaderId;

        EfMethods efMethods = new EfMethods();
        subContext dbContext;

        public FormInvoice()
        {
            InitializeComponent();
            lookUpEdit_OfficeCode.Properties.DataSource = efMethods.SelectOffices();
            lookUpEdit_StoreCode.Properties.DataSource = efMethods.SelectStores();
            lookUpEdit_WarehouseCode.Properties.DataSource = efMethods.SelectWarehouses();

            adornerUIManager1 = new AdornerUIManager(components);
            badge1 = new Badge();
            badge2 = new Badge();
            adornerUIManager1.Elements.Add(badge1);
            adornerUIManager1.Elements.Add(badge2);
            badge1.TargetElement = bBI_Save;
            badge2.TargetElement = RibbonPage_Invoice;
        }

        public AdornerElement[] Badges { get { return new AdornerElement[] { badge1, badge2 }; } }

        private void FormInvoice_Load(object sender, EventArgs e)
        {
            invoiceHeaderId = Guid.NewGuid();

            dbContext = new subContext();
            dbContext.TrInvoiceLines.Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                                    .LoadAsync()
                                    .ContinueWith(loadTask => trInvoiceLinesBindingSource.DataSource = dbContext.TrInvoiceLines.Local.ToBindingList(), TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void btnEdit_DocNum_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            using (FormInvoiceHeaderList form = new FormInvoiceHeaderList())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    btnEdit_DocNum.EditValue = form.TrInvoiceHeader.DocumentNumber;
                    checkEdit_IsReturn.EditValue = form.TrInvoiceHeader.IsReturn;
                    txtEdit_InvoiceCustomNum.EditValue = form.TrInvoiceHeader.CustomsDocumentNumber;
                    dateEdit_DocDate.EditValue = form.TrInvoiceHeader.DocumentDate;
                    dateEdit_DocTime.EditValue = form.TrInvoiceHeader.DocumentTime;
                    btnEdit_CurrAccCode.EditValue = form.TrInvoiceHeader.CurrAccCode;
                    lookUpEdit_OfficeCode.EditValue = form.TrInvoiceHeader.OfficeCode;
                    lookUpEdit_StoreCode.EditValue = form.TrInvoiceHeader.StoreCode;
                    lookUpEdit_WarehouseCode.EditValue = form.TrInvoiceHeader.WarehouseCode;
                    memoEdit_InvoiceDesc.EditValue = form.TrInvoiceHeader.Description;

                    dbContext = new subContext();
                    dbContext.TrInvoiceLines.Where(x => x.InvoiceHeaderId == form.TrInvoiceHeader.InvoiceHeaderId)
                                            .LoadAsync()
                                            .ContinueWith(loadTask => trInvoiceLinesBindingSource.DataSource = dbContext.TrInvoiceLines.Local.ToBindingList(), TaskScheduler.FromCurrentSynchronizationContext());
                }
            }
        }

        private void btnEdit_CurrAccCode_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            using (FormCurrAccList form = new FormCurrAccList())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    btnEdit_CurrAccCode.EditValue = form.dcCurrAcc.CurrAccCode;
            }
        }

        private void gV_InvoiceLine_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            if (!efMethods.InvoiceHeaderExist(invoiceHeaderId)) //if invoiceHeader doesnt exist
            {
                string NewDocNum = efMethods.GetNextDocNum("RP", "DocumentNumber", "TrInvoiceHeaders");

                TrInvoiceHeader TrInvoiceHeader = new TrInvoiceHeader();

                TrInvoiceHeader.InvoiceHeaderId = invoiceHeaderId;
                TrInvoiceHeader.ProcessCode = "RP";
                TrInvoiceHeader.DocumentNumber = NewDocNum;
                TrInvoiceHeader.IsReturn = Convert.ToBoolean(checkEdit_IsReturn.EditValue);
                TrInvoiceHeader.CustomsDocumentNumber = txtEdit_InvoiceCustomNum.Text;
                TrInvoiceHeader.DocumentDate = Convert.ToDateTime(dateEdit_DocDate.EditValue);
                TrInvoiceHeader.DocumentTime = (TimeSpan)dateEdit_DocTime.EditValue;
                TrInvoiceHeader.CurrAccCode = btnEdit_CurrAccCode.EditValue.ToString();
                TrInvoiceHeader.OfficeCode = lookUpEdit_OfficeCode.EditValue.ToString();
                TrInvoiceHeader.StoreCode = lookUpEdit_StoreCode.EditValue.ToString();
                TrInvoiceHeader.WarehouseCode = lookUpEdit_WarehouseCode.EditValue.ToString();
                TrInvoiceHeader.Description = memoEdit_InvoiceDesc.Text;

                efMethods.InsertInvoiceHeader(TrInvoiceHeader);
            }

            gV_InvoiceLine.SetRowCellValue(e.RowHandle, "InvoiceHeaderId", invoiceHeaderId);
            gV_InvoiceLine.SetRowCellValue(e.RowHandle, "InvoiceLineId", Guid.NewGuid());

            efMethods.UpdateInvoiceIsCompleted(invoiceHeaderId);
        }

        private void gV_InvoiceLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Sətir Silinsin?", "Təsdiqlə", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
                GridView gV = sender as GridView;
                MessageBox.Show(gV.FocusedRowHandle.ToString());

                gV.DeleteRow(gV.FocusedRowHandle);
            }
        }

        private void gV_InvoiceLine_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            object objPrice = gV_InvoiceLine.GetRowCellValue(e.RowHandle, "Price");
            object objQty = gV_InvoiceLine.GetRowCellValue(e.RowHandle, "Qty");
            object objPosDiscount = gV_InvoiceLine.GetRowCellValue(e.RowHandle, "PosDiscount");

            if (e.Column.FieldName == "Price")
                objPrice = e.Value;
            if (e.Column.FieldName == "Qty")
                objQty = e.Value;
            if (e.Column.FieldName == "PosDiscount")
                objPosDiscount = e.Value;

            decimal Price = objPrice.IsNumeric() ? Convert.ToDecimal(objPrice) : 0;
            decimal Qty = objQty.IsNumeric() ? Convert.ToDecimal(objQty) : 0;
            decimal PosDiscount = objPosDiscount.IsNumeric() ? Convert.ToDecimal(objPosDiscount) : 0;

            gV_InvoiceLine.SetRowCellValue(e.RowHandle, "Amount", Qty * Price);
            gV_InvoiceLine.SetRowCellValue(e.RowHandle, "NetAmount", Qty * Price - PosDiscount);
        }

        private void gV_InvoiceLine_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            #region Comment
            //GridView view = sender as GridView;
            //decimal val = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, colQty));
            //if (val < 10)
            //{
            //    //e.ErrorText = "Error absh verdi";
            //    e.Valid = false;
            //    view.SetColumnError(colQty, "Deyer 10dan az ola bilmez");
            //} 
            #endregion
        }

        private void repoBtnEdit_ProductCode_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            int buttonIndex = editor.Properties.Buttons.IndexOf(e.Button);
            if (buttonIndex == 0)
            {
                using (FormProductList form = new FormProductList())
                {
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        editor.EditValue = form.DcProduct.ProductCode;
                    }
                }
            }
        }

        private void gV_InvoiceLine_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            //e.ExceptionMode = ExceptionMode.DisplayError;
            //e.ErrorText = "Deyer 10dan az ola bilmez";
        }

        private void gV_InvoiceLine_RowUpdated(object sender, RowObjectEventArgs e)
        {
            dbContext.SaveChanges();
        }

        private void gV_InvoiceLine_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            dbContext.SaveChanges();
        }

        private void FormInvoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            dbContext.Dispose();
        }
    }
}
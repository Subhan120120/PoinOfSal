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

        public TrInvoiceHeader trInvoiceHeader;

        EfMethods efMethods = new EfMethods();
        subContext dbContext;

        public FormInvoice()
        {
            InitializeComponent();
            lUE_OfficeCode.Properties.DataSource = efMethods.SelectOffices();
            lUE_StoreCode.Properties.DataSource = efMethods.SelectStores();
            lUE_WarehouseCode.Properties.DataSource = efMethods.SelectWarehouses();

            adornerUIManager1 = new AdornerUIManager(components);
            badge1 = new Badge();
            badge2 = new Badge();
            adornerUIManager1.Elements.Add(badge1);
            adornerUIManager1.Elements.Add(badge2);
            badge1.TargetElement = bBI_Save;
            badge2.TargetElement = RibbonPage_Invoice;


            //        dbContext.TrInvoiceHeaders.LoadAsync().ContinueWith(loadTask =>
            //        {
            //// Bind data to control when loading complete
            //trInvoiceHeadersBindingSource.DataSource = dbContext.TrInvoiceHeaders.Local.ToBindingList();
            //        }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());


        }

        public AdornerElement[] Badges { get { return new AdornerElement[] { badge1, badge2 }; } }

        private void FormInvoice_Load(object sender, EventArgs e)
        {
            ClearControlsAddNew();
        }

        private void ClearControlsAddNew()
        {
            dbContext = new subContext();

            trInvoiceHeader = trInvoiceHeadersBindingSource.AddNew() as TrInvoiceHeader;

            string NewDocNum = efMethods.GetNextDocNum("RP", "DocumentNumber", "TrInvoiceHeaders");
            trInvoiceHeader.InvoiceHeaderId = Guid.NewGuid();
            trInvoiceHeader.DocumentNumber = NewDocNum;
            trInvoiceHeader.DocumentDate = DateTime.Now;
            trInvoiceHeader.DocumentTime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
            trInvoiceHeader.ProcessCode = "RP";

            dbContext.TrInvoiceLines.Where(x => x.InvoiceHeaderId == trInvoiceHeader.InvoiceHeaderId)
                                    .LoadAsync()
                                    .ContinueWith(loadTask => trInvoiceLinesBindingSource.DataSource = dbContext.TrInvoiceLines.Local.ToBindingList(), TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void btnEdit_DocNum_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            using (FormInvoiceHeaderList form = new FormInvoiceHeaderList("RP"))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    //trInvoiceHeadersBindingSource.DataSource = form.trInvoiceHeader;

                    trInvoiceHeader.InvoiceHeaderId = form.trInvoiceHeader.InvoiceHeaderId;

                    dbContext = new subContext();
                    dbContext.TrInvoiceHeaders.Where(x => x.InvoiceHeaderId == form.trInvoiceHeader.InvoiceHeaderId).Load();
                    trInvoiceHeadersBindingSource.DataSource = dbContext.TrInvoiceHeaders.Local.ToBindingList();


                    dbContext.TrInvoiceLines.Where(x => x.InvoiceHeaderId == form.trInvoiceHeader.InvoiceHeaderId)
                                            .LoadAsync()
                                            .ContinueWith(loadTask => trInvoiceLinesBindingSource.DataSource = dbContext.TrInvoiceLines.Local.ToBindingList(), TaskScheduler.FromCurrentSynchronizationContext());
                }
            }
        }

        private void btnEdit_CurrAccCode_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            using (FormCurrAccList form = new FormCurrAccList(2))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    btnEdit_CurrAccCode.EditValue = form.dcCurrAcc.CurrAccCode;
            }
        }

        private void gV_InvoiceLine_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            gV_InvoiceLine.SetRowCellValue(e.RowHandle, "InvoiceHeaderId", trInvoiceHeader.InvoiceHeaderId);
            gV_InvoiceLine.SetRowCellValue(e.RowHandle, "InvoiceLineId", Guid.NewGuid());

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
                using (FormProductList form = new FormProductList(1))
                {
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        editor.EditValue = form.dcProduct.ProductCode;
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
            //dbContext.SaveChanges();
        }

        private void gV_InvoiceLine_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            //dbContext.SaveChanges();
        }

        private void FormInvoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            dbContext.Dispose();
        }

        private void btn_Save(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if (!efMethods.InvoiceHeaderExist(trInvoiceHeader.InvoiceHeaderId))//if invoiceHeader doesnt exist
            {
                efMethods.InsertInvoiceHeader(trInvoiceHeader);

            }

            dbContext.SaveChanges();

            efMethods.UpdateInvoiceIsCompleted(trInvoiceHeader.InvoiceHeaderId);

            ClearControlsAddNew();

        }
    }
}
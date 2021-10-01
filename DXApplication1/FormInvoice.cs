using DevExpress.Utils.VisualEffects;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using PointOfSale.Models;
using System;
using System.Windows.Forms;

namespace PointOfSale
{
    public partial class FormInvoice : RibbonForm
    {
        Badge badge1;
        Badge badge2;
        AdornerUIManager adornerUIManager1;

        public Guid invoiceHeaderId;

        SqlMethods sqlMethods = new SqlMethods();

        public FormInvoice()
        {
            InitializeComponent();

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
            TrInvoiceLineTableAdapter.Fill(subDataSet.TrInvoiceLine, invoiceHeaderId);

            lookUpEdit_OfficeCode.Properties.DataSource = sqlMethods.SelectOffices();
            lookUpEdit_StoreCode.Properties.DataSource = sqlMethods.SelectStores();
            lookUpEdit_WarehouseCode.Properties.DataSource = sqlMethods.SelectWarehouses();
        }

        private void buttonEditDocNum_ButtonPressed(object sender, ButtonPressedEventArgs e)
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

                    TrInvoiceLineTableAdapter.Fill(subDataSet.TrInvoiceLine, form.TrInvoiceHeader.InvoiceHeaderId);
                }
            }
        }

        private void buttonEditCurrAccCode_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            using (FormCurrAccList form = new FormCurrAccList())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    btnEdit_CurrAccCode.EditValue = form.DcCurrAcc.CurrAccCode;
                }
            }
        }

        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            if (!sqlMethods.InvoiceHeaderExist(invoiceHeaderId)) //if invoiceHeader doesnt exist
            {
                string NewDocNum = sqlMethods.GetNextDocNum("RP", "DocumentNumber", "TrInvoiceHeaders");
                TrInvoiceHeader TrInvoiceHeader = new TrInvoiceHeader()
                {
                    InvoiceHeaderId = invoiceHeaderId,
                    ProcessCode = "RP",
                    DocumentNumber = NewDocNum,
                    IsReturn = Convert.ToBoolean(checkEdit_IsReturn.EditValue),
                    CustomsDocumentNumber = txtEdit_InvoiceCustomNum.EditValue.ToString(),
                    DocumentDate = Convert.ToDateTime(dateEdit_DocDate.EditValue),
                    DocumentTime = (TimeSpan)dateEdit_DocTime.EditValue,
                    CurrAccCode = btnEdit_CurrAccCode.EditValue.ToString(),
                    OfficeCode = lookUpEdit_OfficeCode.EditValue.ToString(),
                    StoreCode = lookUpEdit_StoreCode.EditValue.ToString(),
                    WarehouseCode = lookUpEdit_WarehouseCode.EditValue.ToString(),
                    Description = memoEdit_InvoiceDesc.EditValue.ToString(),
                };
                sqlMethods.InsertInvoiceHeader(TrInvoiceHeader);
            }

            gV_InvoiceLine.SetRowCellValue(e.RowHandle, "InvoiceHeaderId", invoiceHeaderId);
            gV_InvoiceLine.SetRowCellValue(e.RowHandle, "InvoiceLineId", Guid.NewGuid());
        }

        private void gridView1_CellValueChanging(object sender, CellValueChangedEventArgs e)
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

        private void gridView1_ValidateRow(object sender, ValidateRowEventArgs e)
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

        private void repoItemButtonEditProductCode_ButtonPressed(object sender, ButtonPressedEventArgs e)
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

        private void gridView1_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            //e.ExceptionMode = ExceptionMode.DisplayError;
            //e.ErrorText = "Deyer 10dan az ola bilmez";
        }

        private void gridView1_RowUpdated(object sender, RowObjectEventArgs e)
        {
            TrInvoiceLineTableAdapter.Adapter.Update(subDataSet);
        }
    }
}
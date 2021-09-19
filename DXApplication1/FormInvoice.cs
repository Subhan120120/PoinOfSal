using DevExpress.Utils.VisualEffects;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using PointOfSale.Model;
using System;
using System.Windows.Forms;

namespace PointOfSale
{
    public partial class FormInvoice : RibbonForm
    {
        Badge badge1;
        Badge badge2;
        AdornerUIManager adornerUIManager1;

        public string invoiceHeaderId;

        SqlMethods sqlMethods = new SqlMethods();

        public FormInvoice()
        {
            InitializeComponent();

            adornerUIManager1 = new AdornerUIManager(components);
            badge1 = new Badge();
            badge2 = new Badge();
            adornerUIManager1.Elements.Add(badge1);
            adornerUIManager1.Elements.Add(badge2);
            badge1.TargetElement = bbiSave;
            badge2.TargetElement = mainRibbonPage;
        }

        public AdornerElement[] Badges { get { return new AdornerElement[] { badge1, badge2 }; } }

        private void FormInvoice_Load(object sender, EventArgs e)
        {
            invoiceHeaderId = Guid.NewGuid().ToString();
            trInvoiceLineTableAdapter.FillBy(subDataSet.trInvoiceLine, Guid.Parse(invoiceHeaderId));

            textEditOfficeCode.Properties.DataSource = sqlMethods.SelectOffice();
            textEditStoreCode.Properties.DataSource = sqlMethods.SelectStore();
            textEditWarehouseCode.Properties.DataSource = sqlMethods.SelectWarehouse();
        }

        private void buttonEditDocNum_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            using (FormInvoiceHeaderList form = new FormInvoiceHeaderList())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    buttonEditDocNum.EditValue = form.trInvoiceHeader.DocumentNumber;
                    checkEditIsReturn.EditValue = form.trInvoiceHeader.IsReturn;
                    textEditInvoiceCustomNum.EditValue = form.trInvoiceHeader.CustomsDocumentNumber;
                    dateEditDocumentDate.EditValue = form.trInvoiceHeader.DocumentDate;
                    dateEditDocumentTime.EditValue = form.trInvoiceHeader.DocumentTime;
                    buttonEditCurrAccCode.EditValue = form.trInvoiceHeader.CurrAccCode;
                    textEditOfficeCode.EditValue = form.trInvoiceHeader.OfficeCode;
                    textEditStoreCode.EditValue = form.trInvoiceHeader.StoreCode;
                    textEditWarehouseCode.EditValue = form.trInvoiceHeader.WarehouseCode;
                    textEditInvoiceDesc.EditValue = form.trInvoiceHeader.Description;

                    trInvoiceLineTableAdapter.FillBy(subDataSet.trInvoiceLine, Guid.Parse(form.trInvoiceHeader.InvoiceHeaderId));
                }
            }
        }

        private void buttonEditCurrAccCode_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            using (FormCurrAccList form = new FormCurrAccList())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    buttonEditCurrAccCode.EditValue = form.dcCurrAcc.CurrAccCode;
                }
            }
        }

        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            if (!sqlMethods.InvoiceHeaderExist(invoiceHeaderId)) //if invoiceHeader doesnt exist
            {
                string NewDocNum = sqlMethods.GetNextDocNum("RP", "DocumentNumber", "trInvoiceHeader");
                trInvoiceHeader trInvoiceHeader = new trInvoiceHeader()
                {
                    InvoiceHeaderId = invoiceHeaderId,
                    ProcessCode = "RP",
                    DocumentNumber = NewDocNum,
                    IsReturn = Convert.ToBoolean(checkEditIsReturn.EditValue),
                    CustomsDocumentNumber = textEditInvoiceCustomNum.EditValue.ToString(),
                    DocumentDate = Convert.ToDateTime(dateEditDocumentDate.EditValue),
                    DocumentTime = (TimeSpan)dateEditDocumentTime.EditValue,
                    CurrAccCode = buttonEditCurrAccCode.EditValue.ToString(),
                    OfficeCode = textEditOfficeCode.EditValue.ToString(),
                    StoreCode = textEditStoreCode.EditValue.ToString(),
                    WarehouseCode = textEditWarehouseCode.EditValue.ToString(),
                    Description = textEditInvoiceDesc.EditValue.ToString(),
                };
                sqlMethods.InsertInvoiceHeader(trInvoiceHeader);
            }

            gridView1.SetRowCellValue(e.RowHandle, "InvoiceHeaderId", invoiceHeaderId);
            gridView1.SetRowCellValue(e.RowHandle, "InvoiceLineId", Guid.NewGuid());
        }

        private void gridView1_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            object objPrice = gridView1.GetRowCellValue(e.RowHandle, "Price");
            object objQty = gridView1.GetRowCellValue(e.RowHandle, "Qty");
            object objPosDiscount = gridView1.GetRowCellValue(e.RowHandle, "PosDiscount");

            if (e.Column.FieldName == "Price")
                objPrice = e.Value; 
            if (e.Column.FieldName == "Qty")
                objQty = e.Value;
            if (e.Column.FieldName == "PosDiscount")
                objPosDiscount = e.Value;

            decimal Price = objPrice.IsNumeric() ? Convert.ToDecimal(objPrice) : 0;
            decimal Qty = objQty.IsNumeric() ? Convert.ToDecimal(objQty) : 0;
            decimal PosDiscount = objPosDiscount.IsNumeric() ? Convert.ToDecimal(objPosDiscount) : 0;

            gridView1.SetRowCellValue(e.RowHandle, "Amount", Qty * Price);
            gridView1.SetRowCellValue(e.RowHandle, "NetAmount", Qty * Price - PosDiscount);
        }

        private void gridView1_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            decimal val = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, colQty));
            if (val < 10)
            {
                //e.ErrorText = "Error absh verdi";
                e.Valid = false;
                view.SetColumnError(colQty, "Deyer 10dan az ola bilmez");
            }
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
                        editor.EditValue = form.dcProduct.ProductCode;
                    }
                }
            }
        }

        private void gridView1_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
            e.ErrorText = "Deyer 10dan az ola bilmez";
        }

        private void gridView1_RowUpdated(object sender, RowObjectEventArgs e)
        {
            trInvoiceLineTableAdapter.Adapter.Update(subDataSet);
        }        
    }
}
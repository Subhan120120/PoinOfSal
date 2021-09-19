using DevExpress.Utils.VisualEffects;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Windows.Forms;
using DXApplication1.Model;
using DevExpress.XtraEditors;

namespace DXApplication1
{
    public partial class FormInvoice : RibbonForm
    {
        Badge badge1;
        Badge badge2;
        AdornerUIManager adornerUIManager1;

        public string invoiceHeaderId = Guid.NewGuid().ToString();

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
            invoiceHeaderId = "da40f3b8-3b70-41b4-a2ee-71f81af11383";
            trInvoiceLineTableAdapter.FillBy(subDataSet.trInvoiceLine, Guid.Parse(invoiceHeaderId));

            textEditOfficeCode.Properties.DataSource = sqlMethods.SelectOffice();
            textEditStoreCode.Properties.DataSource = sqlMethods.SelectStore();
            textEditWarehouseCode.Properties.DataSource = sqlMethods.SelectWarehouse();
        }

        private void buttonEditDocNum_ButtonClick(object sender, ButtonPressedEventArgs e)
        {

        }

        private void bbiSave_ItemClick(object sender, ItemClickEventArgs e)
        {

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

        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            trInvoiceLineTableAdapter.Adapter.Update(subDataSet);
        }

        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            //if (!sqlMethods.InvoiceHeaderExist(invoiceHeaderId)) //if invoiceHeader doesnt exist
            //{
            //    string NewDocNum = sqlMethods.GetNextDocNum("RS", "DocumentNumber", "trInvoiceHeader");
            //    trInvoiceHeader trInvoiceHeader = new trInvoiceHeader()
            //    {
            //        InvoiceHeaderId = invoiceHeaderId,
            //        DocumentNumber = NewDocNum,
            //    };
            //    sqlMethods.InsertInvoiceHeader(trInvoiceHeader);
            //}

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
            //GridView view = sender as GridView;
            //decimal val = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, colQty));
            //if (val < 10)
            //{
            //    e.ErrorText = "Error absh verdi";
            //    e.Valid = false;
            //    view.SetColumnError(colQty, "The value must be greater than Units On Order");
            //}
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
            //e.ExceptionMode = ExceptionMode.DisplayError;
            //e.ErrorText = "Error occured";
        }
    }
}
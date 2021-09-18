using DevExpress.Utils.VisualEffects;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Windows.Forms;
using DXApplication1.Model;

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
            if (e.Column.FieldName == "Qty")
            {
                object objPrice = gridView1.GetRowCellValue(e.RowHandle, "Price");
                object objPosDiscount = gridView1.GetRowCellValue(e.RowHandle, "PosDiscount");
                decimal Price = objPrice == DBNull.Value ? 0 : Convert.ToDecimal(objPrice);
                decimal PosDiscount = objPosDiscount == DBNull.Value ? 0 : Convert.ToDecimal(objPosDiscount);
                gridView1.SetRowCellValue(e.RowHandle, "Amount", Convert.ToDecimal(e.Value) * Price);
                gridView1.SetRowCellValue(e.RowHandle, "NetAmount", Convert.ToDecimal(e.Value) * Price - PosDiscount);
            }

            if (e.Column.FieldName == "Price")
            {
                object objQty = gridView1.GetRowCellValue(e.RowHandle, "Qty");
                object objPosDiscount = gridView1.GetRowCellValue(e.RowHandle, "PosDiscount");
                decimal Qty = objQty == DBNull.Value ? 0 : Convert.ToDecimal(objQty);
                decimal PosDiscount = objPosDiscount == DBNull.Value ? 0 : Convert.ToDecimal(objPosDiscount);
                gridView1.SetRowCellValue(e.RowHandle, "Amount", Convert.ToDecimal(e.Value) * Qty);
                gridView1.SetRowCellValue(e.RowHandle, "NetAmount", Qty * Convert.ToDecimal(e.Value) - PosDiscount);
            }

            if (e.Column.FieldName == "PosDiscount")
            {
                object objQty = gridView1.GetRowCellValue(e.RowHandle, "Qty");
                object objPrice = gridView1.GetRowCellValue(e.RowHandle, "Price");
                decimal Qty = objQty == DBNull.Value ? 0 : Convert.ToDecimal(objQty);
                decimal Price = objPrice == DBNull.Value ? 0 : Convert.ToDecimal(objPrice);
                gridView1.SetRowCellValue(e.RowHandle, "NetAmount", Qty * Price - Convert.ToDecimal(e.Value));
            }

        }
    }
}
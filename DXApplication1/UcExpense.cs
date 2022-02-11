﻿using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.EntityFrameworkCore;
using PointOfSale.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale
{
    public partial class UcExpense : DevExpress.XtraEditors.XtraUserControl
    {
        subContext dbContext;

        EfMethods efMethods = new EfMethods();
        TrInvoiceHeader trInvoiceHeader;

        public UcExpense()
        {
            InitializeComponent();
        }

        private void UcExpense_Load(object sender, EventArgs e)
        {
            ClearControlsAddNew();
        }

        private void ClearControlsAddNew()
        {
            dbContext = new subContext();

            trInvoiceHeader = trInvoiceHeadersBindingSource.AddNew() as TrInvoiceHeader;
            string NewDocNum = efMethods.GetNextDocNum("EX", "DocumentNumber", "TrInvoiceHeaders");
            trInvoiceHeader.InvoiceHeaderId = Guid.NewGuid();
            trInvoiceHeader.DocumentNumber = NewDocNum;
            trInvoiceHeader.ProcessCode = "EX";

            dbContext.TrInvoiceLines.Where(x => x.InvoiceHeaderId == trInvoiceHeader.InvoiceHeaderId)
                        .LoadAsync()
                        .ContinueWith(loadTask => trInvoiceLinesBindingSource.DataSource = dbContext.TrInvoiceLines.Local.ToBindingList(), TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void gV_InvoiceLine_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            gV_InvoiceLine.SetRowCellValue(e.RowHandle, "InvoiceHeaderId", trInvoiceHeader.InvoiceHeaderId);
            gV_InvoiceLine.SetRowCellValue(e.RowHandle, "InvoiceLineId", Guid.NewGuid());
        }

        private void btnEdit_DocNum_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            using (FormInvoiceHeaderList form = new FormInvoiceHeaderList())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    //btnEdit_DocNum.EditValue = form.TrInvoiceHeader.DocumentNumber;
                    //dateEdit_DocDate.EditValue = form.TrInvoiceHeader.DocumentDate;
                    //dateEdit_DocTime.EditValue = form.TrInvoiceHeader.DocumentTime;
                    //btnEdit_CurrAccCode.EditValue = form.TrInvoiceHeader.CurrAccCode;
                    //memoEdit_InvoiceDesc.EditValue = form.TrInvoiceHeader.Description;

                    dbContext = new subContext();
                    dbContext.TrInvoiceLines.Where(x => x.InvoiceHeaderId == form.TrInvoiceHeader.InvoiceHeaderId)
                                            .LoadAsync()
                                            .ContinueWith(loadTask => trInvoiceLinesBindingSource.DataSource = dbContext.TrInvoiceLines.Local.ToBindingList(), TaskScheduler.FromCurrentSynchronizationContext());


                    dbContext.TrInvoiceHeaders.Where(x => x.InvoiceHeaderId == form.TrInvoiceHeader.InvoiceHeaderId)
                                              .LoadAsync()
                                              .ContinueWith(loadTask => trInvoiceHeadersBindingSource.DataSource = dbContext.TrInvoiceHeaders.Local.ToBindingList(), TaskScheduler.FromCurrentSynchronizationContext());
                    
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
                        editor.EditValue = form.dcProduct.ProductCode;
                    }
                }
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            //TrInvoiceHeader trInvoiceHeader = trInvoiceHeadersBindingSource.Current as TrInvoiceHeader;
            if (!efMethods.InvoiceHeaderExist(trInvoiceHeader.InvoiceHeaderId))
                dbContext.TrInvoiceHeaders.Add(trInvoiceHeader);
            dbContext.SaveChanges();
            efMethods.UpdateInvoiceIsCompleted(trInvoiceHeader.InvoiceHeaderId);

            ClearControlsAddNew();
        }

    }
}

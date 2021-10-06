using DevExpress.XtraEditors;
using System;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using PointOfSale.Models;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;

namespace PointOfSale
{
    public partial class UcSale : XtraUserControl
    {
        public Guid invoiceHeaderId = Guid.NewGuid();
        SqlMethods sqlMethods = new SqlMethods();

        public UcSale()
        {
            InitializeComponent();
            btn_CustomerAdd.BorderStyle = BorderStyles.UltraFlat;
            btn_CustomerSearch.BorderStyle = BorderStyles.UltraFlat;
            btn_CustomerEdit.BorderStyle = BorderStyles.UltraFlat;

            //AcceptButton = simpleButtonEnter;
            ActiveControl = txtEdit_Barcode;
        }

        private void UcSale_Load(object sender, EventArgs e)
        {
            this.ParentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing); // set Parent Form Closing event
        }
        void ParentForm_FormClosing(object sender, FormClosingEventArgs e) // Parent Form Closing event
        {
            if (sqlMethods.InvoiceHeaderExist(invoiceHeaderId))
                sqlMethods.DeleteInvoice(invoiceHeaderId);                // delete incomplete invoice
        }

        private void gV_InvoiceLine_CalcPreviewText(object sender, CalcPreviewTextEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;

            string Barcode = view.GetRowCellDisplayText(e.RowHandle, view.Columns["Barcode"]);
            decimal PosDiscount = Convert.ToDecimal(view.GetRowCellDisplayText(e.RowHandle, view.Columns["PosDiscount"]));
            decimal Amount = Convert.ToDecimal(view.GetRowCellDisplayText(e.RowHandle, view.Columns["Amount"]));
            decimal NetAmount = Convert.ToDecimal(view.GetRowCellDisplayText(e.RowHandle, view.Columns["NetAmount"]));
            string asdasd = view.GetRowCellDisplayText(e.RowHandle, view.Columns["VatRate"]);
            float VatRate = float.Parse(asdasd);

            e.PreviewText = Methods.GetPreviewText(PosDiscount, Amount, NetAmount, VatRate, Barcode);
        }

        private void btn_ProductSearch_Click(object sender, EventArgs e)
        {
            using (FormProductList formProductList = new FormProductList())
            {
                if (formProductList.ShowDialog(this) == DialogResult.OK)
                {
                    if (!sqlMethods.InvoiceHeaderExist(invoiceHeaderId)) //if invoiceHeader doesnt exist
                    {
                        string NewDocNum = sqlMethods.GetNextDocNum("RS", "DocumentNumber", "TrInvoiceHeaders");

                        TrInvoiceHeader TrInvoiceHeader = new TrInvoiceHeader()
                        {
                            InvoiceHeaderId = invoiceHeaderId,
                            ProcessCode = "RS",
                            DocumentNumber = NewDocNum
                        };
                        sqlMethods.InsertInvoiceHeader(TrInvoiceHeader);
                    }

                    DcProduct DcProduct = formProductList.DcProduct;
                    int result = sqlMethods.InsertInvoiceLine(DcProduct, invoiceHeaderId);

                    if (result > 0)
                    {
                        gC_Sale.DataSource = sqlMethods.SelectInvoiceLines(invoiceHeaderId);
                        gV_InvoiceLine.MoveLast();
                    }
                    else
                        XtraMessageBox.Show("Məhsul əlavə edilə bilmədi");
                }
            }
        }

        private void btn_CancelInvoice_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = XtraMessageBox.Show("Silmək istədiyinizə əminmisiniz?", "Diqqət", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int result = sqlMethods.DeleteInvoice(invoiceHeaderId);

                if (result >= 0)
                {
                    gC_Sale.DataSource = sqlMethods.SelectInvoiceLines(invoiceHeaderId);
                    invoiceHeaderId = Guid.NewGuid();
                }
            }
        }


        private void btn_DeleteLine_Click(object sender, EventArgs e)
        {
            if (gV_InvoiceLine.RowCount > 1)
            {
                DialogResult dialogResult = XtraMessageBox.Show("Silmək istədiyinizə əminmisiniz?", "Diqqət", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    object invoiceLineId = gV_InvoiceLine.GetRowCellValue(gV_InvoiceLine.FocusedRowHandle, "InvoiceLineId");
                    int result = sqlMethods.DeleteInvoiceLine(invoiceLineId);

                    if (result >= 0)
                    {
                        gC_Sale.DataSource = sqlMethods.SelectInvoiceLines(invoiceHeaderId);
                        gV_InvoiceLine.MoveLast();
                    }
                }
            }
            else if (gV_InvoiceLine.RowCount == 1)
                XtraMessageBox.Show("Son Sətri Silmək Olmur.\nSilmək üçün çeki ləğv etməlisiniz!", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btn_Discount_Click(object sender, EventArgs e)
        {
            bool authorized = false;
            Session.DcRoles.ForEach(x => authorized = x.RoleCode.Contains("Admin"));     //check user role

            if (authorized)                                                              
            {
                if (gV_InvoiceLine.FocusedRowHandle >= 0)                           //if product selected
                {
                    decimal PosDiscount = Convert.ToDecimal(gV_InvoiceLine.GetRowCellValue(gV_InvoiceLine.FocusedRowHandle, "PosDiscount"));
                    decimal Amount = Convert.ToDecimal(gV_InvoiceLine.GetRowCellValue(gV_InvoiceLine.FocusedRowHandle, "Amount"));

                    using (FormPosDiscount formPosDiscount = new FormPosDiscount(PosDiscount, Amount))
                    {
                        if (formPosDiscount.ShowDialog(this) == DialogResult.OK)
                        {
                            object invoiceLineId = gV_InvoiceLine.GetRowCellValue(gV_InvoiceLine.FocusedRowHandle, "InvoiceLineId");

                            TrInvoiceLine TrInvoiceLine = new TrInvoiceLine()
                            {
                                InvoiceLineId = (Guid)invoiceLineId,
                                NetAmount = Amount - formPosDiscount.PosDiscount,
                                PosDiscount = formPosDiscount.PosDiscount
                            };
                            int result = sqlMethods.UpdateInvoicePosDiscount(TrInvoiceLine);

                            if (result >= 0)
                            {
                                gC_Sale.DataSource = sqlMethods.SelectInvoiceLines(invoiceHeaderId);
                                gV_InvoiceLine.MoveLast();
                            }
                        }
                    }
                }
                else
                    XtraMessageBox.Show("Məhsul seçin", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                XtraMessageBox.Show("Yetkiniz Yoxdur", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btn_Num_Click(object sender, EventArgs e)
        {
            SimpleButton simpleButton = sender as SimpleButton;
            string key = simpleButton.Text;

            switch (key)
            {
                case "←":
                    SendKeys.Send("{BACKSPACE}");
                    break;
                case "C":
                    SendKeys.Send("^A");
                    SendKeys.Send("{BACKSPACE}");
                    break;
                default:
                    SendKeys.Send(key);
                    break;
            }
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            if (txtEdit_Barcode.EditValue != null)
            {
                DcProduct DcProduct = new DcProduct { Barcode = txtEdit_Barcode.EditValue.ToString() };

                if (!sqlMethods.InvoiceHeaderExist(invoiceHeaderId)) //if invoiceHeader doesnt exist
                {
                    string NewDocNum = sqlMethods.GetNextDocNum("RS", "DocumentNumber", "TrInvoiceHeaders");
                    TrInvoiceHeader TrInvoiceHeader = new TrInvoiceHeader()
                    {
                        InvoiceHeaderId = invoiceHeaderId,
                        ProcessCode = "RS",
                        DocumentNumber = NewDocNum,
                    };
                    sqlMethods.InsertInvoiceHeader(TrInvoiceHeader);
                }
                int result = sqlMethods.InsertInvoiceLine(DcProduct, invoiceHeaderId);

                if (result > 0)
                {
                    gC_Sale.DataSource = sqlMethods.SelectInvoiceLines(invoiceHeaderId);
                    gV_InvoiceLine.MoveLast();
                    txtEdit_Barcode.EditValue = string.Empty;
                }
                else
                    XtraMessageBox.Show("Barkod Tapılmadı", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ActiveControl = txtEdit_Barcode;
        }

        private void gC_Sale_MouseUp(object sender, MouseEventArgs e)
        {
            txtEdit_Barcode.Focus();
        }

        private void btn_Payment_Click(object sender, EventArgs e)
        {
            decimal summaryNetAmount = Convert.ToDecimal(gV_InvoiceLine.Columns["NetAmount"].SummaryItem.SummaryValue);

            if (summaryNetAmount > 0)
            {
                int paymentType = 0;

                SimpleButton simpleButton = sender as SimpleButton;
                switch (simpleButton.Name)
                {
                    case "btn_Cash":
                        paymentType = 1;
                        break;
                    case "btn_Cashless":
                        paymentType = 2;
                        break;
                    case "btn_CustomerBonus":
                        paymentType = 3;
                        break;
                    default:
                        break;
                }

                using (FormPayment formPayment = new FormPayment(paymentType, summaryNetAmount, invoiceHeaderId))
                {
                    if (formPayment.ShowDialog(this) == DialogResult.OK)
                    {
                        sqlMethods.UpdateInvoiceIsCompleted(invoiceHeaderId);

                        invoiceHeaderId = Guid.NewGuid();

                        gC_Sale.DataSource = sqlMethods.SelectInvoiceLines(invoiceHeaderId);
                    }
                }
            }
            else XtraMessageBox.Show("Ödəmə 0a bərabərdir");
        }

        private void btn_Customer_Click(object sender, EventArgs e)
        {
            SimpleButton simpleButton = (SimpleButton)sender;
            DcCurrAcc DcCurrAcc = new DcCurrAcc();


            if (simpleButton.Name == "btn_CustomerEdit")
            {
                if (!string.IsNullOrEmpty(txtEdit_CustomerCode.Text))
                {
                    string currAccCode = txtEdit_CustomerCode.Text;
                    DcCurrAcc = sqlMethods.SelectCurrAcc(currAccCode);
                }
                else
                {
                    XtraMessageBox.Show("Fakturaya aid olan Musteri yoxdur");
                    return; // return btn_Customer_Click
                }
            }

            using (FormCustomer formCustomer = new FormCustomer(DcCurrAcc))
            {
                if (formCustomer.ShowDialog(this) == DialogResult.OK)
                {
                    if (!sqlMethods.InvoiceHeaderExist(invoiceHeaderId)) //if invoiceHeader doesnt exist
                    {
                        string NewDocNum = sqlMethods.GetNextDocNum("RS", "DocumentNumber", "TrInvoiceHeaders");
                        TrInvoiceHeader TrInvoiceHeader = new TrInvoiceHeader()
                        {
                            InvoiceHeaderId = invoiceHeaderId,
                            ProcessCode = "RS",
                            DocumentNumber = NewDocNum,
                        };
                        sqlMethods.InsertInvoiceHeader(TrInvoiceHeader);
                    }

                    int result = sqlMethods.UpdateInvoiceCurrAccCode(formCustomer.DcCurrAcc.CurrAccCode, invoiceHeaderId);

                    if (result >= 0)
                    {
                        txtEdit_CustomerCode.EditValue = formCustomer.DcCurrAcc.CurrAccCode;
                        txtEdit_BonCardNum.EditValue = formCustomer.DcCurrAcc.BonusCardNum;
                        txtEdit_CustomerName.EditValue = formCustomer.DcCurrAcc.FirstName + " " + formCustomer.DcCurrAcc.LastName;
                        txtEdit_CustomerAddress.EditValue = formCustomer.DcCurrAcc.Address;
                        txtEdit_CustomerPhoneNum.EditValue = formCustomer.DcCurrAcc.PhoneNum;
                    }
                }
            }
        }

        private void gC_Sale_DoubleClick(object sender, EventArgs e)
        {
            object invoiceLineId = gV_InvoiceLine.GetRowCellValue(gV_InvoiceLine.FocusedRowHandle, "InvoiceLineId");
            if (gV_InvoiceLine.FocusedColumn == col_Qty)
            {
                using (FormQty formQty = new FormQty())
                {
                    if (formQty.ShowDialog(this) == DialogResult.OK)
                    {
                        sqlMethods.UpdateInvoiceLineQty(invoiceLineId, formQty.qty);
                        gC_Sale.DataSource = sqlMethods.SelectInvoiceLines(invoiceHeaderId);
                        gV_InvoiceLine.MoveLast();
                    }
                }
            }
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            ReportClass reportClass = new ReportClass();
            ReportPrintTool printTool = new ReportPrintTool(reportClass.CreateReport(sqlMethods.SelectInvoiceLineForReport(invoiceHeaderId), string.Empty));
            printTool.ShowPreview();
        }

        private void btn_PrintDesign_Click(object sender, EventArgs e)
        {
            ReportClass reportClass = new ReportClass();
            ReportDesignTool designTool = new ReportDesignTool(reportClass.CreateReport(sqlMethods.SelectInvoiceLineForReport(invoiceHeaderId), string.Empty));
            designTool.ShowRibbonDesignerDialog();
        }
    }
}

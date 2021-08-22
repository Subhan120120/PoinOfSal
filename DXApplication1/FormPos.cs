﻿using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DXApplication1.Model;
using System;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class FormPos : XtraForm
    {
        public string invoiceHeaderID = Guid.NewGuid().ToString();
        SqlMethods sqlMethods = new SqlMethods();

        public FormPos()
        {
            InitializeComponent();
            simpleButtonCustomerAdd.BorderStyle = BorderStyles.UltraFlat;
            simpleButton3.BorderStyle = BorderStyles.UltraFlat;
            simpleButton4.BorderStyle = BorderStyles.UltraFlat;
            simpleButton5.BorderStyle = BorderStyles.UltraFlat;
            //simpleButton6.BorderStyle = BorderStyles.UltraFlat;
            //simpleButton7.BorderStyle = BorderStyles.UltraFlat;
            //simpleButton8.BorderStyle = BorderStyles.UltraFlat; 
            //simpleButton9.BorderStyle = BorderStyles.UltraFlat; 
            //simpleButton10.BorderStyle = BorderStyles.UltraFlat; 
            //simpleButtonSalesPerson.BorderStyle = BorderStyles.UltraFlat; 
            //simpleButtonDiscount.BorderStyle = BorderStyles.UltraFlat; 
            //simpleButtonDeleteLine.BorderStyle = BorderStyles.UltraFlat; 
            //simpleButtonCancelInvoice.BorderStyle = BorderStyles.UltraFlat; 
            //simpleButtonProductSearch.BorderStyle = BorderStyles.UltraFlat; 
            //AcceptButton = simpleButtonEnter;

            ActiveControl = textEditBarcode;
        }

        private void FormPos_Load(object sender, EventArgs e)
        {

        }

        private void gridView1_CalcPreviewText(object sender, CalcPreviewTextEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            string Barcode = view.GetRowCellDisplayText(e.RowHandle, view.Columns["Barcode"]);
            string PosDiscount = view.GetRowCellDisplayText(e.RowHandle, view.Columns["PosDiscount"]);
            string Amount = view.GetRowCellDisplayText(e.RowHandle, view.Columns["Amount"]);
            string NetAmount = view.GetRowCellDisplayText(e.RowHandle, view.Columns["NetAmount"]);
            string VatRate = view.GetRowCellDisplayText(e.RowHandle, view.Columns["VatRate"]);

            e.PreviewText = GetPreviewText(Barcode, PosDiscount, Amount, NetAmount, VatRate);
        }

        private static string GetPreviewText(string Barcode, string PosDiscount, string Amount, string NetAmount, string VatRate)
        {
            decimal PosDiscountRate = 0;
            if (Amount != string.Empty && NetAmount != string.Empty)
                PosDiscountRate = Math.Round(Convert.ToDecimal(PosDiscount) / Convert.ToDecimal(Amount) * 100, 2);

            string previewText = "ƏDV: " + VatRate + "%\n";

            if (Barcode != string.Empty)
                previewText += "Barkod: " + Barcode + "\n";

            if (PosDiscountRate > 0)
                previewText += "Pos Endirimi: [" + PosDiscountRate + "%] = " + PosDiscount + "\n";
            return previewText;
        }

        private void simpleButtonProductSearch_Click(object sender, EventArgs e)
        {
            using (FormProductList formProductList = new FormProductList())
            {
                if (formProductList.ShowDialog(this) == DialogResult.OK)
                {
                    if (!sqlMethods.HeaderExist(invoiceHeaderID)) //if invoiceHeader doesnt exist
                    {
                        string NewDocNum = sqlMethods.GetNextNumber("DocumentNumber", "trInvoiceHeader");
                        sqlMethods.InsertHeader(invoiceHeaderID, NewDocNum);
                    }

                    dcProduct dcProduct = formProductList.dcProduct;
                    int result = sqlMethods.InsertLine(dcProduct, invoiceHeaderID);

                    if (result > 0)
                    {
                        gridControl1.DataSource = sqlMethods.BindToData(invoiceHeaderID);
                        gridControl1.DataMember = "customQuery1";
                        gridView1.MoveLast();
                    }
                    else
                        MessageBox.Show("Məhsul əlavə edilə bilmədi");
                }
            }
        }

        private void simpleButtonCancelInvoice_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Silmək istədiyinizə əminmisiniz?", "Diqqət", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int result = sqlMethods.DeleteInvoice(invoiceHeaderID);

                if (result >= 0)
                {
                    gridControl1.DataSource = sqlMethods.BindToData(invoiceHeaderID);
                    invoiceHeaderID = Guid.NewGuid().ToString();
                }
            }
        }


        private void simpleButtonDeleteLine_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 1)
            {
                DialogResult dialogResult = MessageBox.Show("Silmək istədiyinizə əminmisiniz?", "Diqqət", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    object invoiceLineId = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "InvoiceLineId");
                    int result = sqlMethods.DeleteLine(invoiceLineId);

                    if (result >= 0)
                    {
                        gridControl1.DataSource = sqlMethods.BindToData(invoiceHeaderID);
                        gridView1.MoveLast();
                    }
                }
            }
            else if (gridView1.RowCount == 1)
                MessageBox.Show("Son Sətri Silmək Olmur.\nSilmək üçün çeki ləğv etməlisiniz!", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void simpleButtonDiscount_Click(object sender, EventArgs e)
        {

            if (gridView1.FocusedRowHandle >= 0) //if product selected
            {
                decimal PosDiscount = Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PosDiscount"));
                decimal Amount = Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Amount"));
                using (FormPosDiscount formPosDiscount = new FormPosDiscount(PosDiscount, Amount))
                {
                    if (formPosDiscount.ShowDialog(this) == DialogResult.OK)
                    {
                        object invoiceLineId = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "InvoiceLineId");

                        trInvoiceLine trInvoiceLine = new trInvoiceLine()
                        {
                            InvoiceLineId = invoiceLineId.ToString(),
                            NetAmount = formPosDiscount.NetAmount,
                            PosDiscount = formPosDiscount.PosDiscount
                        };
                        int result = sqlMethods.UpdatePosDiscount(trInvoiceLine);

                        if (result >= 0)
                        {
                            gridControl1.DataSource = sqlMethods.BindToData(invoiceHeaderID);
                            gridView1.MoveLast();
                        }
                    }
                }
            }
            else
                MessageBox.Show("Məhsul seçin", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void simpleButtonNum_Click(object sender, EventArgs e)
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

        private void simpleButtonEnter_Click(object sender, EventArgs e)
        {
            if (textEditBarcode.EditValue != null)
            {
                dcProduct dcProduct = new dcProduct { Barcode = textEditBarcode.EditValue.ToString() };

                if (!sqlMethods.HeaderExist(invoiceHeaderID)) //if invoiceHeader doesnt exist
                {
                    string NewDocNum = sqlMethods.GetNextNumber("DocumentNumber", "trInvoiceHeader");
                    sqlMethods.InsertHeader(invoiceHeaderID, NewDocNum);
                }
                int result = sqlMethods.InsertLine(dcProduct, invoiceHeaderID);

                if (result > 0)
                {
                    gridControl1.DataSource = sqlMethods.BindToData(invoiceHeaderID);
                    gridControl1.DataMember = "customQuery1";
                    gridView1.MoveLast();
                    textEditBarcode.EditValue = string.Empty;
                }
                else
                    MessageBox.Show("Barkod Tapılmadı", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void simpleButtonCustomerAdd_Click(object sender, EventArgs e)
        {
            using (FormCustomer formCustomer = new FormCustomer(new dcCurrAcc()))
            {
                if (formCustomer.ShowDialog(this) == DialogResult.OK)
                {
                    if (!sqlMethods.HeaderExist(invoiceHeaderID)) //if invoiceHeader doesnt exist
                    {
                        string NewDocNum = sqlMethods.GetNextNumber("DocumentNumber", "trInvoiceHeader");
                        sqlMethods.InsertHeader(invoiceHeaderID, NewDocNum);
                    }
                    int result = sqlMethods.UpdateCurrAccCode(formCustomer.dcCurrAcc.CurrAccCode, invoiceHeaderID);

                    if (result >= 0)
                    {
                        textEditBonCardNum.EditValue = formCustomer.dcCurrAcc.BonusCardNum;
                        textEditCustomerName.EditValue = formCustomer.dcCurrAcc.FirstName + " " + formCustomer.dcCurrAcc.LastName;
                        textEditCustomerAddress.EditValue = formCustomer.dcCurrAcc.Address;
                        textEditCustomerPhoneNum.EditValue = formCustomer.dcCurrAcc.PhoneNum;
                    }
                }
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            Object summaryValue = gridView1.Columns["NetAmount"].SummaryItem.SummaryValue;
            MessageBox.Show(summaryValue.ToString());
        }

        private void gridControl1_MouseUp(object sender, MouseEventArgs e)
        {
            textEditBarcode.Focus();
        }

        private void simpleButtonPayment_Click(object sender, EventArgs e)
        {

            int paymentType = 0;

            SimpleButton simpleButton = sender as SimpleButton;
            switch (simpleButton.Name)
            {
                case "simpleButtonCash":
                    paymentType = 1;
                    break;
                case "simpleButtonCashless":
                    paymentType = 2;
                    break;
                case "simpleButtonCustomerBonus":
                    paymentType = 3;
                    break;

                default:
                    break;
            }

            decimal summaryNetAmount = Convert.ToDecimal(gridView1.Columns["NetAmount"].SummaryItem.SummaryValue);
            using (FormPayment formPayment = new FormPayment(paymentType, summaryNetAmount, invoiceHeaderID))
            {
                if (formPayment.ShowDialog(this) == DialogResult.OK)
                {

                }
            }
        }
    }
}

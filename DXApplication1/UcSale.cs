using DevExpress.XtraEditors;
using System;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DXApplication1.Model;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class UcSale : XtraUserControl
    {
        public string invoiceHeaderId = Guid.NewGuid().ToString();
        SqlMethods sqlMethods = new SqlMethods();

        public UcSale()
        {
            InitializeComponent();
            simpleButtonCustomerAdd.BorderStyle = BorderStyles.UltraFlat;
            simpleButton3.BorderStyle = BorderStyles.UltraFlat;
            simpleButtonCustomerEdit.BorderStyle = BorderStyles.UltraFlat;

            //AcceptButton = simpleButtonEnter;
            ActiveControl = textEditBarcode;
        }

        private void gridView11_CalcPreviewText(object sender, CalcPreviewTextEventArgs e)
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
                    if (!sqlMethods.InvoiceHeaderExist(invoiceHeaderId)) //if invoiceHeader doesnt exist
                    {
                        string NewDocNum = sqlMethods.GetNextDocNum("RS", "DocumentNumber", "trInvoiceHeader");

                        trInvoiceHeader trInvoiceHeader = new trInvoiceHeader()
                        {
                            InvoiceHeaderId = invoiceHeaderId,
                            ProcessCode = "RS",
                            DocumentNumber = NewDocNum
                        };
                        sqlMethods.InsertInvoiceHeader(trInvoiceHeader);
                    }

                    dcProduct dcProduct = formProductList.dcProduct;
                    int result = sqlMethods.InsertInvoiceLine(dcProduct, invoiceHeaderId);

                    if (result > 0)
                    {
                        gridControlSale.DataSource = sqlMethods.SelectInvoiceLine(invoiceHeaderId);
                        gridView11.MoveLast();
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
                int result = sqlMethods.DeleteInvoice(invoiceHeaderId);

                if (result >= 0)
                {
                    gridControlSale.DataSource = sqlMethods.SelectInvoiceLine(invoiceHeaderId);
                    invoiceHeaderId = Guid.NewGuid().ToString();
                }
            }
        }


        private void simpleButtonDeleteLine_Click(object sender, EventArgs e)
        {
            if (gridView11.RowCount > 1)
            {
                DialogResult dialogResult = MessageBox.Show("Silmək istədiyinizə əminmisiniz?", "Diqqət", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    object invoiceLineId = gridView11.GetRowCellValue(gridView11.FocusedRowHandle, "InvoiceLineId");
                    int result = sqlMethods.DeleteInvoiceLine(invoiceLineId);

                    if (result >= 0)
                    {
                        gridControlSale.DataSource = sqlMethods.SelectInvoiceLine(invoiceHeaderId);
                        gridView11.MoveLast();
                    }
                }
            }
            else if (gridView11.RowCount == 1)
                MessageBox.Show("Son Sətri Silmək Olmur.\nSilmək üçün çeki ləğv etməlisiniz!", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void simpleButtonDiscount_Click(object sender, EventArgs e)
        {

            if (gridView11.FocusedRowHandle >= 0) //if product selected
            {
                decimal PosDiscount = Convert.ToDecimal(gridView11.GetRowCellValue(gridView11.FocusedRowHandle, "PosDiscount"));
                decimal Amount = Convert.ToDecimal(gridView11.GetRowCellValue(gridView11.FocusedRowHandle, "Amount"));
                using (FormPosDiscount formPosDiscount = new FormPosDiscount(PosDiscount, Amount))
                {
                    if (formPosDiscount.ShowDialog(this) == DialogResult.OK)
                    {
                        object invoiceLineId = gridView11.GetRowCellValue(gridView11.FocusedRowHandle, "InvoiceLineId");

                        trInvoiceLine trInvoiceLine = new trInvoiceLine()
                        {
                            InvoiceLineId = invoiceLineId.ToString(),
                            NetAmount = Amount - formPosDiscount.PosDiscount,
                            PosDiscount = formPosDiscount.PosDiscount
                        };
                        int result = sqlMethods.UpdateInvoicePosDiscount(trInvoiceLine);

                        if (result >= 0)
                        {
                            gridControlSale.DataSource = sqlMethods.SelectInvoiceLine(invoiceHeaderId);
                            gridView11.MoveLast();
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

                if (!sqlMethods.InvoiceHeaderExist(invoiceHeaderId)) //if invoiceHeader doesnt exist
                {
                    string NewDocNum = sqlMethods.GetNextDocNum("RS", "DocumentNumber", "trInvoiceHeader");
                    trInvoiceHeader trInvoiceHeader = new trInvoiceHeader()
                    {
                        InvoiceHeaderId = invoiceHeaderId,
                        ProcessCode = "RS",
                        DocumentNumber = NewDocNum,
                    };
                    sqlMethods.InsertInvoiceHeader(trInvoiceHeader);
                }
                int result = sqlMethods.InsertInvoiceLine(dcProduct, invoiceHeaderId);

                if (result > 0)
                {
                    gridControlSale.DataSource = sqlMethods.SelectInvoiceLine(invoiceHeaderId);
                    //gridControl11.DataMember = "customQuery1";
                    gridView11.MoveLast();
                    textEditBarcode.EditValue = string.Empty;
                }
                else
                    MessageBox.Show("Barkod Tapılmadı", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ActiveControl = textEditBarcode;
        }

        private void gridControl11_MouseUp(object sender, MouseEventArgs e)
        {
            textEditBarcode.Focus();
        }

        private void simpleButtonPayment_Click(object sender, EventArgs e)
        {
            decimal summaryNetAmount = Convert.ToDecimal(gridView11.Columns["NetAmount"].SummaryItem.SummaryValue);

            if (summaryNetAmount > 0)
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

                using (FormPayment formPayment = new FormPayment(paymentType, summaryNetAmount, invoiceHeaderId))
                {
                    if (formPayment.ShowDialog(this) == DialogResult.OK)
                    {
                        sqlMethods.UpdateInvoiceIsCompleted(invoiceHeaderId);

                        invoiceHeaderId = Guid.NewGuid().ToString();

                        gridControlSale.DataSource = sqlMethods.SelectInvoiceLine(invoiceHeaderId);
                        //gridControl11.DataMember = "customQuery1";
                    }
                }
            }
            else MessageBox.Show("Ödəmə 0a bərabərdir");
        }

        private void simpleButtonCustomer_Click(object sender, EventArgs e)
        {
            SimpleButton simpleButton = sender as SimpleButton;
            dcCurrAcc dcCurrAcc = new dcCurrAcc()
            {
                CurrAccCode = textEditCustomerCode.Text,
                //BirthDate = textEditCustomerBirthdate.Text,
                Address = textEditBonCardNum.Text,
                BonusCardNum = textEditBonCardNum.Text,
                PhoneNum = textEditCustomerPhoneNum.Text
            };

            using (FormCustomer formCustomer = new FormCustomer(dcCurrAcc))
            {
                if (formCustomer.ShowDialog(this) == DialogResult.OK)
                {
                    if (simpleButton.Name == "simpleButtonCustomerAdd")
                    {
                        if (!sqlMethods.InvoiceHeaderExist(invoiceHeaderId)) //if invoiceHeader doesnt exist
                        {
                            string NewDocNum = sqlMethods.GetNextDocNum("RS", "DocumentNumber", "trInvoiceHeader");
                            trInvoiceHeader trInvoiceHeader = new trInvoiceHeader()
                            {
                                InvoiceHeaderId = invoiceHeaderId,
                                ProcessCode = "RS",
                                DocumentNumber = NewDocNum,
                            };
                            sqlMethods.InsertInvoiceHeader(trInvoiceHeader);
                        }
                        int result = sqlMethods.UpdateCurrAccCode(formCustomer.dcCurrAcc.CurrAccCode, invoiceHeaderId);

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
        }

        private void gridControl11_DoubleClick(object sender, EventArgs e)
        {
            object invoiceLineId = gridView11.GetRowCellValue(gridView11.FocusedRowHandle, "InvoiceLineId");
            if (gridView11.FocusedColumn == columnQty)
            {
                using (FormQty formQty = new FormQty())
                {
                    if (formQty.ShowDialog(this) == DialogResult.OK)
                    {
                        sqlMethods.UpdateInvoiceLineQty(invoiceLineId, formQty.qty);
                        gridControlSale.DataSource = sqlMethods.SelectInvoiceLine(invoiceHeaderId);
                        gridView11.MoveLast();
                    }
                }
            }
        }
    }
}

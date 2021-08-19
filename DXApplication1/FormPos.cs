using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DXApplication1.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class FormPos : XtraForm
    {
        public string subConnString = Properties.Settings.Default.subConnString;
        public string invoiceHeaderID = "";
        SqlMethods sqlMethods = new SqlMethods();

        public FormPos()
        {
            InitializeComponent();
            //AcceptButton = simpleButtonEnter;
            simpleButtonCustomerAdd.BorderStyle = BorderStyles.UltraFlat;
            simpleButton3.BorderStyle = BorderStyles.UltraFlat;
            simpleButton4.BorderStyle = BorderStyles.UltraFlat;
            simpleButton5.BorderStyle = BorderStyles.UltraFlat;
        }

        private void FormPos_Load(object sender, EventArgs e)
        {
            invoiceHeaderID = Guid.NewGuid().ToString();
            textEditBarcode.Focus();
        }

        private void gridView1_CalcPreviewText(object sender, CalcPreviewTextEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            string Barcode = view.GetRowCellDisplayText(e.RowHandle, view.Columns["Barcode"]);
            string PosDiscountRate = view.GetRowCellDisplayText(e.RowHandle, view.Columns["PosDiscountRate"]);
            string Amount = view.GetRowCellDisplayText(e.RowHandle, view.Columns["Amount"]);
            string NetAmount = view.GetRowCellDisplayText(e.RowHandle, view.Columns["NetAmount"]);
            string VatRate = view.GetRowCellDisplayText(e.RowHandle, view.Columns["VatRate"]);


            float DiscountAmount = 0;
            if (Amount != string.Empty && NetAmount != string.Empty)
                DiscountAmount = float.Parse(Amount) - float.Parse(NetAmount);

            string previewText = "ƏDV: " + VatRate + "%\n";

            if (Barcode != string.Empty)
                previewText += "Barkod: " + Barcode + "\n";

            if (PosDiscountRate != "0")
                previewText += "Pos Endirimi: [" + PosDiscountRate + "%] = " + DiscountAmount.ToString() + "\n";

            e.PreviewText = previewText;
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
                        gridControl1.DataSource = BindToData();
                        gridControl1.DataMember = "customQuery1";
                        gridView1.MoveLast();
                    }
                    else
                        MessageBox.Show("Məhsul əlavə edilə bilmədi");
                }
            }
        }

        public SqlDataSource BindToData()
        {
            CustomStringConnectionParameters connectionParameters = new CustomStringConnectionParameters(subConnString);

            SqlDataSource ds = new SqlDataSource(connectionParameters);
            CustomSqlQuery query = new CustomSqlQuery();
            query.Name = "customQuery1";
            query.Sql = "select trInvoiceLine.*, ProductDescription, Barcode from trInvoiceLine " +
                "left join dcProduct on trInvoiceLine.ProductCode = dcProduct.ProductCode " +
                "where InvoiceHeaderID = '" + invoiceHeaderID + "' order by CreatedDate"; // burdaki kolonlari dizaynda da elave et

            ds.Queries.Add(query);
            ds.Fill();

            return ds;
        }

        private void simpleButtonCancelInvoice_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Silmək istədiyinizə əminmisiniz?", "Diqqət", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int result = sqlMethods.DeleteInvoice(invoiceHeaderID);

                if (result >= 0)
                {
                    gridControl1.DataSource = BindToData();
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
                        gridControl1.DataSource = BindToData();
                        gridView1.MoveLast();
                    }
                }
            }
            else if (gridView1.RowCount == 1)
                MessageBox.Show("Son Sətri Silmək Olmur.\nSilmək üçün çeki ləğv etməlisiniz!", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void simpleButtonDiscount_Click(object sender, EventArgs e)
        {

            if (gridView1.FocusedRowHandle >= 0)
            {
                float PosDiscountRate = float.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PosDiscountRate").ToString());
                float Amount = float.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Amount").ToString());
                using (FormPosDiscount formPosDiscount = new FormPosDiscount(PosDiscountRate, Amount))
                {
                    if (formPosDiscount.ShowDialog(this) == DialogResult.OK)
                    {
                        object invoiceLineId = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "InvoiceLineId");
                        int result = sqlMethods.UpdatePosDiscount(formPosDiscount, invoiceLineId);

                        if (result >= 0)
                        {
                            gridControl1.DataSource = BindToData();
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
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case ",":
                case "*":
                    SendKeys.Send(key);
                    break;
                case "C":
                    textEditBarcode.EditValue = "";
                    break;
                case "←":
                    SendKeys.Send("{BACKSPACE}");
                    break;
                default:
                    // code block
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
                    gridControl1.DataSource = BindToData();
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
            //simpleButtonEnter.PerformClick();
        }
    }
}

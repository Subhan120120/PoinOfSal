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
            simpleButtonCustomerAdd.BorderStyle = BorderStyles.UltraFlat;
            simpleButton3.BorderStyle = BorderStyles.UltraFlat;
            simpleButton4.BorderStyle = BorderStyles.UltraFlat;
            simpleButton5.BorderStyle = BorderStyles.UltraFlat;
        }

        private void FormPos_Load(object sender, EventArgs e)
        {
            invoiceHeaderID = Guid.NewGuid().ToString();
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
                        string NewDocNum = sqlMethods.GetDocumentNumber("DocumentNumber", "trInvoiceHeader");
                        sqlMethods.InsertHeader(invoiceHeaderID, NewDocNum);
                    }

                    dcProduct dcProduct = formProductList.dcProduct;

                    int result = sqlMethods.InsertLine(dcProduct, invoiceHeaderID);

                    if (result >= 0)
                    {
                        gridControl1.DataSource = BindToData();
                        gridControl1.DataMember = "customQuery1";
                        gridView1.MoveLast();
                    }
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
            switch (simpleButton.Text)
            {
                case "0":
                    textEditBarcode.EditValue += "0";
                    break;
                case "1":
                    textEditBarcode.EditValue += "1";
                    break;
                case "2":
                    textEditBarcode.EditValue += "2";
                    break;
                case "3":
                    textEditBarcode.EditValue += "3";
                    break;
                case "4":
                    textEditBarcode.EditValue += "4";
                    break;
                case "5":
                    textEditBarcode.EditValue += "5";
                    break;
                case "6":
                    textEditBarcode.EditValue += "6";
                    break;
                case "7":
                    textEditBarcode.EditValue += "7";
                    break;
                case "8":
                    textEditBarcode.EditValue += "8";
                    break;
                case "9":
                    textEditBarcode.EditValue += "9";
                    break;
                case ",":
                    textEditBarcode.EditValue += ",";
                    break;
                case "*":
                    textEditBarcode.EditValue += "*";
                    break;
                case "C":
                    textEditBarcode.EditValue = "";
                    break;
                case "←":
                    if (textEditBarcode.Text.Length != 0)
                        textEditBarcode.EditValue = textEditBarcode.Text.Substring(0, textEditBarcode.Text.Length - 1);
                    break;
                default:
                    // code block
                    break;
            }
        }

        private void simpleButtonEnter_Click(object sender, EventArgs e)
        {
            string barcode = textEditBarcode.EditValue.ToString();
            dcProduct dcProduct = new dcProduct { Barcode = barcode };

            if (!sqlMethods.HeaderExist(invoiceHeaderID)) //if invoiceHeader doesnt exist
            {
                string NewDocNum = sqlMethods.GetDocumentNumber("DocumentNumber", "trInvoiceHeader");
                sqlMethods.InsertHeader(invoiceHeaderID, NewDocNum);
            }
            int result = sqlMethods.InsertLine(dcProduct, invoiceHeaderID);

            if (result >= 0)
            {
                gridControl1.DataSource = BindToData();
                gridControl1.DataMember = "customQuery1";
                gridView1.MoveLast();
                textEditBarcode.EditValue = "";
            }
        }

        private void simpleButtonCustomerAdd_Click(object sender, EventArgs e)
        {
            using (FormCustomer formCustomer = new FormCustomer())
            {
                if (formCustomer.ShowDialog(this) == DialogResult.OK)
                {

                }
            }
        }
    }
}

using DXApplication1.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication1
{
    public class SqlMethods
    {
        public string subConnString = Properties.Settings.Default.subConnString;
        private SqlParameter[] paramArray = new SqlParameter[] { };

        public int SqlExec(string query, SqlParameter[] sqlParameters)
        {
            using (SqlConnection con = new SqlConnection(subConnString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddRange(sqlParameters);
                    con.Open();

                    int result = cmd.ExecuteNonQuery();

                    if (result < 0)
                        MessageBox.Show("Data Əlavə edilməsində xəta baş verdi!");
                    return result;
                }
            }
        }

        public DataTable SqlGetDt(string query, SqlParameter[] sqlParameters)
        {
            using (SqlConnection con = new SqlConnection(subConnString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {
                    da.SelectCommand.Parameters.AddRange(sqlParameters);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public int InsertLine(dcProduct dcProduct, string invoiceHeaderID)
        {

            string qryInsertProduct = "insert into trInvoiceLine([InvoiceLineId],[InvoiceHeaderID],[ProductCode],[Price]) " +
                "select @InvoiceLineId, @InvoiceHeaderID,[ProductCode],[RetailPrice] from dcProduct ";


            SqlParameter[] paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceLineId", Guid.NewGuid()),
                new SqlParameter("@InvoiceHeaderID", invoiceHeaderID),
                new SqlParameter("@Barcode", dcProduct.Barcode)
            };

            if (!string.IsNullOrEmpty(dcProduct.Barcode))
                qryInsertProduct += "where [Barcode] = @Barcode";
            else
            {
                qryInsertProduct += "where [ProductCode] = @ProductCode";
                paramArray[2] = new SqlParameter("@ProductCode", dcProduct.ProductCode);
            }

            int result = SqlExec(qryInsertProduct, paramArray);
            return result;
        }

        public bool HeaderExist(string invoiceHeaderID)
        {
            string qrySelectHeader = "SELECT TOP 1 InvoiceHeaderID FROM [trInvoiceHeader] WHERE ([InvoiceHeaderID] = @InvoiceHeaderID)";
            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceHeaderID", invoiceHeaderID)
            };
            DataTable dt = SqlGetDt(qrySelectHeader, paramArray);

            int HeaderCount = dt.Select("InvoiceHeaderID = '" + invoiceHeaderID + "'").Length;
            if (HeaderCount > 0) return true;
            else return false;
        }

        public string GetNextNumber(string columnName, string tableName)
        {
            string qryProcGetDocNum = "dbo.GetNextNum @ColumnName = @ColumnName, @TableName = @TableName";
            paramArray = new SqlParameter[]
             {
                new SqlParameter("@ColumnName", columnName),
                new SqlParameter("@TableName", tableName)
             };

            DataTable dt = SqlGetDt(qryProcGetDocNum, paramArray);

            string newDocNum = dt.Rows[0][0].ToString();

            return newDocNum;
        }
        public void InsertHeader(string invoiceHeaderID, string newDocNum)
        {
            string qryInsertHeader = "INSERT INTO [dbo].[trInvoiceHeader] ([InvoiceHeaderID],[ProcessCode],[DocumentNumber]) " +
                                        "VALUES (@InvoiceHeaderID,@ProcessCode,@DocumentNumber)";

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceHeaderID", invoiceHeaderID),
                new SqlParameter("@ProcessCode", "R"),
                new SqlParameter("@DocumentNumber", "R-1-" + newDocNum)
            };

            SqlExec(qryInsertHeader, paramArray);
        }

        public int DeleteInvoice(string invoiceHeaderID)
        {
            string qryDeleteInvoice = "DELETE FROM [dbo].[trInvoiceLine] where InvoiceHeaderID = @InvoiceHeaderID; " +
                                        "DELETE FROM [dbo].[trInvoiceHeader] where InvoiceHeaderID = @InvoiceHeaderID";

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceHeaderID", invoiceHeaderID)
            };
            int result = SqlExec(qryDeleteInvoice, paramArray);
            return result;
        }

        public int DeleteLine(object invoiceLineId)
        {
            string qryDeleteLine = "DELETE FROM [dbo].[trInvoiceLine] where InvoiceLineId = @InvoiceLineId";

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceLineId", invoiceLineId)
            };
            int result = SqlExec(qryDeleteLine, paramArray);
            return result;
        }

        public int UpdatePosDiscount(FormPosDiscount formDiscount, object invoiceLineId)
        {
            string qryUpdateDiscount = "UPDATE [dbo].[trInvoiceLine] set PosDiscountRate = @PosDiscountRate where InvoiceLineId = @InvoiceLineId";

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceLineId", invoiceLineId),
                new SqlParameter("@PosDiscountRate",formDiscount.PosDiscountRate)
            };
            int result = SqlExec(qryUpdateDiscount, paramArray);
            return result;
        }

        public int InsertCustomer(dcCurrAcc dcCurrAcc)
        {
            string qryInsertCustomer = "INSERT INTO [dbo].[dcCurrAcc]([CurrAccTypeCode],[CurrAccCode],[FirstName],[LastName],[BonusCardNum],[Address],[PhoneNum]) " +
                "VALUES(@CurrAccTypeCode,@CurrAccCode,@FirstName,@LastName,@BonusCardNum,@Address,@PhoneNum)";

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@CurrAccTypeCode", 2),
                new SqlParameter("@CurrAccCode", dcCurrAcc.CurrAccCode),
                new SqlParameter("@FirstName", dcCurrAcc.FirstName),
                new SqlParameter("@LastName", dcCurrAcc.LastName),
                new SqlParameter("@BonusCardNum", dcCurrAcc.BonusCardNum ),
                new SqlParameter("@Address", dcCurrAcc.Address),
                new SqlParameter("@PhoneNum", dcCurrAcc.PhoneNum)
            };

            int result = SqlExec(qryInsertCustomer, paramArray);
            return result;
        }

        public int UpdateCurrAccCode(string currAccCode, object invoiceHeaderId)
        {
            string qryUpdateCurrAccCode = "UPDATE [dbo].[trInvoiceHeader] set CurrAccCode = @CurrAccCode where InvoiceHeaderId = @InvoiceHeaderId";

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceHeaderId", invoiceHeaderId),
                new SqlParameter("@CurrAccCode", currAccCode)
            };
            int result = SqlExec(qryUpdateCurrAccCode, paramArray);
            return result;
        }
    }
}

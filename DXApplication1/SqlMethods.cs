using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DXApplication1.Model;
using System;
using System.Data;
using System.Data.SqlClient;
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

        public SqlDataSource BindToData(string invoiceHeaderID)
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

        public int InsertLine(dcProduct dcProduct, string invoiceHeaderID)
        {
            string qry = "Insert into trInvoiceLine([InvoiceLineId],[InvoiceHeaderID],[ProductCode],[Price],[Amount],[PosDiscount],[NetAmount]) " +
                "select @InvoiceLineId,@InvoiceHeaderID,[ProductCode],[RetailPrice],[RetailPrice],[PosDiscount],[RetailPrice]-[PosDiscount] from dcProduct ";

            SqlParameter[] paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceLineId", Guid.NewGuid()),
                new SqlParameter("@InvoiceHeaderID", invoiceHeaderID),
                new SqlParameter("@Barcode", dcProduct.Barcode)
            };

            if (!string.IsNullOrEmpty(dcProduct.Barcode))
                qry += "where [Barcode] = @Barcode";
            else
            {
                qry += "where [ProductCode] = @ProductCode";
                paramArray[2] = new SqlParameter("@ProductCode", dcProduct.ProductCode);
            }

            return SqlExec(qry, paramArray);
        }

        public bool HeaderExist(string invoiceHeaderID)
        {
            string qry = "SELECT TOP 1 InvoiceHeaderID FROM [trInvoiceHeader] WHERE ([InvoiceHeaderID] = @InvoiceHeaderID)";
            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceHeaderID", invoiceHeaderID)
            };
            DataTable dt = SqlGetDt(qry, paramArray);

            //int HeaderCount = dt.Select("InvoiceHeaderID = '" + invoiceHeaderID + "'").Length;
            int HeaderCount = dt.Rows.Count;
            if (HeaderCount > 0) return true;
            else return false;
        }

        public string GetNextNumber(string columnName, string tableName)
        {
            string qry = "dbo.GetNextNum @ColumnName = @ColumnName, @TableName = @TableName";
            paramArray = new SqlParameter[]
             {
                new SqlParameter("@ColumnName", columnName),
                new SqlParameter("@TableName", tableName)
             };

            DataTable dt = SqlGetDt(qry, paramArray);

            return dt.Rows[0][0].ToString(); ;
        }
        public void InsertHeader(string invoiceHeaderID, string newDocNum)
        {
            string qry = "INSERT INTO [dbo].[trInvoiceHeader] ([InvoiceHeaderID],[ProcessCode],[DocumentNumber]) " +
                                        "VALUES (@InvoiceHeaderID,@ProcessCode,@DocumentNumber)";

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceHeaderID", invoiceHeaderID),
                new SqlParameter("@ProcessCode", "R"),
                new SqlParameter("@DocumentNumber", "R-1-" + newDocNum)
            };

            SqlExec(qry, paramArray);
        }

        public int DeleteInvoice(string invoiceHeaderID)
        {
            string qry = "DELETE FROM [dbo].[trInvoiceLine] where InvoiceHeaderID = @InvoiceHeaderID; " +
                                        "DELETE FROM [dbo].[trInvoiceHeader] where InvoiceHeaderID = @InvoiceHeaderID";

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceHeaderID", invoiceHeaderID)
            };

            return SqlExec(qry, paramArray);
        }

        public int DeleteLine(object invoiceLineId)
        {
            string qry = "DELETE FROM [dbo].[trInvoiceLine] where InvoiceLineId = @InvoiceLineId";

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceLineId", invoiceLineId)
            };

            return SqlExec(qry, paramArray);
        }

        public int UpdatePosDiscount(trInvoiceLine trInvoiceLine)
        {
            string qry = "UPDATE [dbo].[trInvoiceLine] set [PosDiscount] = @PosDiscount, [NetAmount] = @NetAmount where InvoiceLineId = @InvoiceLineId";

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceLineId", trInvoiceLine.InvoiceLineId),
                new SqlParameter("@NetAmount", trInvoiceLine.NetAmount),
                new SqlParameter("@PosDiscount",trInvoiceLine.PosDiscount)
            };

            return SqlExec(qry, paramArray);
        }

        public int InsertCustomer(dcCurrAcc dcCurrAcc)
        {
            string qry = "INSERT INTO [dbo].[dcCurrAcc]([CurrAccTypeCode],[CurrAccCode],[FirstName],[LastName],[BonusCardNum],[Address],[PhoneNum],[BirthDate]) " +
                "VALUES(@CurrAccTypeCode,@CurrAccCode,@FirstName,@LastName,@BonusCardNum,@Address,@PhoneNum, @BirthDate)";

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@CurrAccTypeCode", 2),
                new SqlParameter("@CurrAccCode", dcCurrAcc.CurrAccCode),
                new SqlParameter("@FirstName", dcCurrAcc.FirstName),
                new SqlParameter("@LastName", dcCurrAcc.LastName),
                new SqlParameter("@BonusCardNum", dcCurrAcc.BonusCardNum ),
                new SqlParameter("@Address", dcCurrAcc.Address),
                new SqlParameter("@BirthDate", dcCurrAcc.BirthDate),
                new SqlParameter("@PhoneNum", dcCurrAcc.PhoneNum)
            };

            return SqlExec(qry, paramArray);
        }

        public int UpdateCurrAccCode(string currAccCode, string invoiceHeaderId)
        {
            string qry = "UPDATE [dbo].[trInvoiceHeader] set CurrAccCode = @CurrAccCode where InvoiceHeaderId = @InvoiceHeaderId";

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceHeaderId", invoiceHeaderId),
                new SqlParameter("@CurrAccCode", currAccCode)
            };

            return SqlExec(qry, paramArray);
        }

        public int InsertPaymentHeader(trPaymentHeader trPayment)
        {
            string qry = "INSERT INTO [dbo].[trPaymentHeader] " +
                "([PaymentHeaderID],[InvoiceHeaderID],[DocumentNumber],[CurrAccCode]) " +
                "VALUES(@PaymentHeaderID,@InvoiceHeaderID,@DocumentNumber,@CurrAccCode)";

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@PaymentHeaderID", trPayment.PaymentHeaderID),
                new SqlParameter("@InvoiceHeaderID", trPayment.InvoiceHeaderID),
                new SqlParameter("@DocumentNumber", "P-1-" + trPayment.DocumentNumber),
                new SqlParameter("@CurrAccCode", "C-0-0")
            };

            return SqlExec(qry, paramArray);
        }

        public int InsertPaymentLine(trPaymentLine trPaymentLine)
        {
            string qry = "INSERT INTO [dbo].[trPaymentLine] ([PaymentLineID],[PaymentHeaderID],[Payment],[PaymentTypeCode]) " +
                "VALUES (@PaymentLineID,@PaymentHeaderID,@Payment,@PaymentTypeCode)";

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@PaymentLineID", trPaymentLine.PaymentLineID),
                new SqlParameter("@PaymentHeaderID", trPaymentLine.PaymentHeaderID),
                new SqlParameter("@Payment", trPaymentLine.Payment),
                new SqlParameter("@PaymentTypeCode", trPaymentLine.PaymentTypeCode)
            };

            return SqlExec(qry, paramArray);
        }
        public bool PaymentHeaderExist(string invoiceHeaderID)
        {
            string qry = "SELECT TOP 1 PaymentHeaderID FROM [trPaymentHeader] WHERE ([InvoiceHeaderID] = @InvoiceHeaderID)";
            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceHeaderID", invoiceHeaderID)
            };
            DataTable dt = SqlGetDt(qry, paramArray);
            //int HeaderCount = dt.Select("InvoiceHeaderID = '" + invoiceHeaderID + "'").Length;
            int HeaderCount = dt.Rows.Count;
            if (HeaderCount > 0) return true;
            else return false;
        }

        public bool PaymentLineExist(string invoiceHeaderID, int paymentTypeCode)
        {
            string qry = "select TOP 1 PaymentLineID from [trPaymentLine] " +
                "left join[trPaymentHeader] on[trPaymentHeader].[PaymentHeaderID] = [trPaymentLine].[PaymentHeaderID] " +
                "WHERE [InvoiceHeaderID] = @InvoiceHeaderID AND [PaymentTypeCode] = @PaymentTypeCode ";

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceHeaderID", invoiceHeaderID),
                new SqlParameter("@PaymentTypeCode", paymentTypeCode)
            };

            DataTable dt = SqlGetDt(qry, paramArray);
            //int HeaderCount = dt.Select("InvoiceHeaderID = '" + invoiceHeaderID + "'").Length;
            int HeaderCount = dt.Rows.Count;
            if (HeaderCount > 0) return true;
            else return false;
        }

        public int UpdateIsCompleted(string invoiceHeaderId)
        {
            string qry = "UPDATE trInvoiceHeader SET IsCompleted = 1 WHERE InvoiceHeaderID = @InvoiceHeaderID";

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceHeaderId", invoiceHeaderId)
            };

            return SqlExec(qry, paramArray);
        }

    }
}

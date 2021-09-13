using DXApplication1.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DXApplication1
{
    public class SqlMethods
    {
        private string subConnString = Properties.Settings.Default.subConnString;
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

        public string GetNextDocNum(string processCode, string columnName, string tableName)
        {
            string qry = "dbo.GetNextDocNum @ProcessCode = @ProcessCode, @ColumnName = @ColumnName, @TableName = @TableName";
            paramArray = new SqlParameter[]
             {
                new SqlParameter("@ProcessCode", processCode),
                new SqlParameter("@ColumnName", columnName),
                new SqlParameter("@TableName", tableName)
             };

            DataTable dt = SqlGetDt(qry, paramArray);

            return dt.Rows[0][0].ToString(); ;
        }

        public DataTable SelectInvoiceHeader()
        {
            SqlParameter[] paramArray2 = new SqlParameter[] { };
            string qry = "select * from trInvoiceHeader where IsCompleted = 1 order by CreatedDate "; // burdaki kolonlari dizaynda da elave et
            return SqlGetDt(qry, paramArray2);
        }

        public DataTable SelectInvoiceLine(string invoiceHeaderID)
        {
            string qry = "select trInvoiceLine.*, ProductDescription, Barcode" +
                ", ReturnQty = ISNULL((select sum(Qty) from trInvoiceLine returnLine where returnLine.RelatedLineId = trInvoiceLine.InvoiceLineId),0) " +
                ", RemainingQty = Qty + ISNULL((select sum(Qty) from trInvoiceLine returnLine where returnLine.RelatedLineId = trInvoiceLine.InvoiceLineId),0) " +
                "from trInvoiceLine " +
                "left join dcProduct on trInvoiceLine.ProductCode = dcProduct.ProductCode " +
                "where InvoiceHeaderID = @InvoiceHeaderID order by CreatedDate"; // burdaki kolonlari dizaynda da elave et

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceHeaderID", invoiceHeaderID)
            };
            return SqlGetDt(qry, paramArray);
        }

        public int InsertInvoiceLine(dcProduct dcProduct, string invoiceHeaderID)
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

        public int InsertInvoiceLine(trInvoiceLine trInvoiceLine)
        {
            string qry = "Insert into trInvoiceLine(InvoiceLineId,InvoiceHeaderID,RelatedLineId,ProductCode,Qty,Price,Amount,PosDiscount,NetAmount) " +
                "select @InvoiceLineId, @InvoiceHeaderID, InvoiceLineId, ProductCode, @Qty, Price, @Qty*Amount/Qty, @Qty*PosDiscount/Qty, @Qty*NetAmount/Qty from trInvoiceLine where InvoiceLineId = @RelatedLineId ";

            SqlParameter[] paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceLineId", trInvoiceLine.InvoiceLineId),
                new SqlParameter("@InvoiceHeaderID", trInvoiceLine.InvoiceHeaderID),
                new SqlParameter("@RelatedLineId", trInvoiceLine.RelatedLineId),
                new SqlParameter("@Qty", trInvoiceLine.Qty),
            };

            return SqlExec(qry, paramArray);
        }

        public bool InvoiceLineExist(string invoicecHeaderId, object relatedLineId)
        {
            string qry = "SELECT TOP 1 1 FROM trInvoiceLine WHERE RelatedLineId = @RelatedLineId AND InvoiceHeaderID = @InvoicecHeaderId";
            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoicecHeaderId", invoicecHeaderId),
                new SqlParameter("@RelatedLineId", relatedLineId),
            };
            DataTable dt = SqlGetDt(qry, paramArray);
            int HeaderCount = dt.Rows.Count;
            if (HeaderCount > 0) return true;
            else return false;
        }

        public bool InvoiceHeaderExist(string invoiceHeaderID)
        {
            string qry = "SELECT TOP 1 InvoiceHeaderID FROM [trInvoiceHeader] WHERE ([InvoiceHeaderID] = @InvoiceHeaderID)";
            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceHeaderID", invoiceHeaderID)
            };
            DataTable dt = SqlGetDt(qry, paramArray);

            int HeaderCount = dt.Rows.Count;
            if (HeaderCount > 0) return true;
            else return false;
        }



        public void InsertInvoiceHeader(trInvoiceHeader trInvoiceHeader)
        {
            string qry = "INSERT INTO trInvoiceHeader (InvoiceHeaderID, ProcessCode, DocumentNumber, IsReturn) " +
                "VALUES (@InvoiceHeaderID,@ProcessCode,@DocumentNumber, @IsReturn)";

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceHeaderID", trInvoiceHeader.InvoiceHeaderID),
                new SqlParameter("@ProcessCode", "RS"),
                new SqlParameter("@DocumentNumber", trInvoiceHeader.DocumentNumber),
                new SqlParameter("@IsReturn", trInvoiceHeader.IsReturn)
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

        public int DeleteInvoiceLine(object invoiceLineId)
        {
            string qry = "DELETE FROM [dbo].[trInvoiceLine] where InvoiceLineId = @InvoiceLineId";

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceLineId", invoiceLineId)
            };

            return SqlExec(qry, paramArray);
        }

        public int UpdateInvoiceIsCompleted(string invoiceHeaderId)
        {
            string qry = "UPDATE trInvoiceHeader SET IsCompleted = 1 WHERE InvoiceHeaderID = @InvoiceHeaderID";

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceHeaderId", invoiceHeaderId)
            };

            return SqlExec(qry, paramArray);
        }

        public int UpdateInvoiceLineQty(object invoiceLineId, int qty)
        {
            string qry = "UPDATE trInvoiceLine set Qty = @Qty, Amount = @Qty*Price,  NetAmount = (@Qty*Price)-(@Qty*PosDiscount/Qty), PosDiscount = @Qty*PosDiscount/Qty  where InvoiceLineId = @InvoiceLineId";

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceLineId", invoiceLineId),
                new SqlParameter("@Qty", qty)
            };

            return SqlExec(qry, paramArray);
        }

        public int UpdateInvoiceLineQty(object invoiceHeaderId, object relatedLineId, int qty)
        {
            string qry = "UPDATE trInvoiceLine set Qty = @Qty, Amount = @Qty*Price,  NetAmount = (@Qty*Price)-(@Qty*PosDiscount/Qty), PosDiscount = @Qty*PosDiscount/Qty  " +
                "WHERE InvoiceHeaderId = @InvoiceHeaderId AND RelatedLineId = @RelatedLineId";

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceHeaderId", invoiceHeaderId),
                new SqlParameter("@RelatedLineId", relatedLineId),
                new SqlParameter("@Qty", qty)
            };

            return SqlExec(qry, paramArray);
        }

        public int UpdateInvoicePosDiscount(trInvoiceLine trInvoiceLine)
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
                new SqlParameter("@DocumentNumber", trPayment.DocumentNumber),
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
            int HeaderCount = dt.Rows.Count;
            if (HeaderCount > 0) return true;
            else return false;
        }

        public DataTable SelectPaymentLine(string invoiceHeaderID)
        {
            string qry = "select paymentTypeDescription, Payment from trPaymentLine " +
                "join trPaymentHeader on trPaymentHeader.PaymentHeaderID = trPaymentLine.PaymentHeaderID " +
                "join dcPaymentType on trPaymentLine.PaymentTypeCode = dcPaymentType.PaymentTypeCode " +
                "where InvoiceHeaderID = @InvoiceHeaderID"; // burdaki kolonlari dizaynda da elave et

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceHeaderID", invoiceHeaderID)
            };
            return SqlGetDt(qry, paramArray);
        }
    }
}

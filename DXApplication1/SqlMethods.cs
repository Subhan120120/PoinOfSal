using PointOfSale.Models;
using System;
using System.Data;
//using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PointOfSale
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

        public DataTable SelectProducts()
        {
            SqlParameter[] paramArray = new SqlParameter[] { };
            string qry = "select * from dcProduct"; // burdaki kolonlari dizaynda da elave et
            return SqlGetDt(qry, paramArray);
        }

        public DataTable SelectInvoiceHeader()
        {
            SqlParameter[] paramArray2 = new SqlParameter[] { };
            string qry = "select * from TrInvoiceHeader order by CreatedDate "; // burdaki kolonlari dizaynda da elave et
            return SqlGetDt(qry, paramArray2);
        }

        public DataTable SelectInvoiceLine(Guid invoiceHeaderId)
        {
            string qry = "select TrInvoiceLine.*, ProductDescription, Barcode" +
                ", ReturnQty = ISNULL((select sum(Qty) from TrInvoiceLine returnLine where returnLine.RelatedLineId = TrInvoiceLine.InvoiceLineId),0) " +
                ", RemainingQty = Qty + ISNULL((select sum(Qty) from TrInvoiceLine returnLine where returnLine.RelatedLineId = TrInvoiceLine.InvoiceLineId),0) " +
                "from TrInvoiceLine " +
                "left join DcProduct on TrInvoiceLine.ProductCode = DcProduct.ProductCode " +
                "where InvoiceHeaderId = @InvoiceHeaderId order by CreatedDate"; // burdaki kolonlari dizaynda da elave et

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceHeaderId", invoiceHeaderId)
            };
            return SqlGetDt(qry, paramArray);
        }

        public int InsertInvoiceLine(DcProduct DcProduct, Guid invoiceHeaderId)
        {
            string qry = "Insert into TrInvoiceLine([InvoiceLineId],[InvoiceHeaderId],[ProductCode],[Price],[Amount],[PosDiscount],[NetAmount]) " +
                "select @InvoiceLineId,@InvoiceHeaderId,[ProductCode],[RetailPrice],[RetailPrice],[PosDiscount],[RetailPrice]-[PosDiscount] from DcProduct ";

            SqlParameter[] paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceLineId", Guid.NewGuid()),
                new SqlParameter("@InvoiceHeaderId", invoiceHeaderId),
                new SqlParameter("@Barcode", DcProduct.Barcode)
            };

            if (!string.IsNullOrEmpty(DcProduct.Barcode))
                qry += "where [Barcode] = @Barcode";
            else
            {
                qry += "where [ProductCode] = @ProductCode";
                paramArray[2] = new SqlParameter("@ProductCode", DcProduct.ProductCode);
            }

            return SqlExec(qry, paramArray);
        }

        public int InsertInvoiceLine(TrInvoiceLine TrInvoiceLine)
        {
            string qry = "Insert into TrInvoiceLine(InvoiceLineId,InvoiceHeaderId,RelatedLineId,ProductCode,Qty,Price,Amount,PosDiscount,NetAmount) " +
                "select @InvoiceLineId, @InvoiceHeaderId, InvoiceLineId, ProductCode, @Qty, Price, @Qty*Amount/Qty, @Qty*PosDiscount/Qty, @Qty*NetAmount/Qty from TrInvoiceLine where InvoiceLineId = @RelatedLineId ";

            SqlParameter[] paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceLineId", TrInvoiceLine.InvoiceLineId),
                new SqlParameter("@InvoiceHeaderId", TrInvoiceLine.InvoiceHeaderId),
                new SqlParameter("@RelatedLineId", TrInvoiceLine.RelatedLineId),
                new SqlParameter("@Qty", TrInvoiceLine.Qty),
            };

            return SqlExec(qry, paramArray);
        }

        public bool InvoiceLineExist(Guid invoicecHeaderId, object relatedLineId)
        {
            string qry = "SELECT TOP 1 1 FROM TrInvoiceLine WHERE RelatedLineId = @RelatedLineId AND InvoiceHeaderId = @InvoicecHeaderId";
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

        public bool InvoiceHeaderExist(Guid invoiceHeaderId)
        {
            string qry = "SELECT TOP 1 InvoiceHeaderId FROM [TrInvoiceHeader] WHERE ([InvoiceHeaderId] = @InvoiceHeaderId)";
            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceHeaderId", invoiceHeaderId)
            };
            DataTable dt = SqlGetDt(qry, paramArray);

            int HeaderCount = dt.Rows.Count;
            if (HeaderCount > 0) return true;
            else return false;
        }



        public void InsertInvoiceHeader(TrInvoiceHeader TrInvoiceHeader)
        {
            subContext db = new subContext();
            //string qry = "INSERT INTO TrInvoiceHeader (InvoiceHeaderId, ProcessCode, DocumentNumber, IsReturn, CustomsDocumentNumber, DocumentDate, DocumentTime, CurrAccCode, OfficeCode, StoreCode, WarehouseCode, Description) " +
            //    "VALUES (@InvoiceHeaderId, @ProcessCode, @DocumentNumber, @IsReturn, @CustomsDocumentNumber, @DocumentDate, @DocumentTime, @CurrAccCode, @OfficeCode, @StoreCode, @WarehouseCode, @Description)";

            //paramArray = new SqlParameter[]
            //{
            //    new SqlParameter("@InvoiceHeaderId", TrInvoiceHeader.InvoiceHeaderId.ValueOrNull()),
            //    new SqlParameter("@ProcessCode", TrInvoiceHeader.ProcessCode.ValueOrNull()),
            //    new SqlParameter("@DocumentNumber", TrInvoiceHeader.DocumentNumber.ValueOrNull()),
            //    new SqlParameter("@IsReturn", TrInvoiceHeader.IsReturn),
            //    new SqlParameter("@CustomsDocumentNumber", TrInvoiceHeader.CustomsDocumentNumber.ValueOrNull()),
            //    new SqlParameter("@DocumentDate", TrInvoiceHeader.DocumentDate.ValueOrNull()),
            //    new SqlParameter("@DocumentTime", TrInvoiceHeader.DocumentTime.ValueOrNull()),
            //    new SqlParameter("@CurrAccCode", TrInvoiceHeader.CurrAccCode.ValueOrNull()),
            //    new SqlParameter("@OfficeCode", TrInvoiceHeader.OfficeCode.ValueOrNull()),
            //    new SqlParameter("@StoreCode", TrInvoiceHeader.StoreCode.ValueOrNull()),
            //    new SqlParameter("@WarehouseCode", TrInvoiceHeader.WarehouseCode.ValueOrNull()),
            //    new SqlParameter("@Description", TrInvoiceHeader.Description.ValueOrNull())
            //};

            //SqlExec(qry, paramArray);

            db.TrInvoiceHeader.Add(TrInvoiceHeader);

            db.SaveChanges();

        }

        public int DeleteInvoice(Guid invoiceHeaderId)
        {
            string qry = "DELETE FROM [dbo].[TrInvoiceLine] where InvoiceHeaderId = @InvoiceHeaderId; " +
                "DELETE FROM [dbo].[TrInvoiceHeader] where InvoiceHeaderId = @InvoiceHeaderId";

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceHeaderId", invoiceHeaderId)
            };

            return SqlExec(qry, paramArray);
        }

        public int DeleteInvoiceLine(object invoiceLineId)
        {
            string qry = "DELETE FROM [dbo].[TrInvoiceLine] where InvoiceLineId = @InvoiceLineId";

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceLineId", invoiceLineId)
            };

            return SqlExec(qry, paramArray);
        }

        public int UpdateInvoiceIsCompleted(Guid invoiceHeaderId)
        {
            string qry = "UPDATE TrInvoiceHeader SET IsCompleted = 1 WHERE InvoiceHeaderId = @InvoiceHeaderId";

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceHeaderId", invoiceHeaderId)
            };

            return SqlExec(qry, paramArray);
        }

        public int UpdateInvoiceLineQty(object invoiceLineId, int qty)
        {
            string qry = "UPDATE TrInvoiceLine set Qty = @Qty, Amount = @Qty*Price,  NetAmount = (@Qty*Price)-(@Qty*PosDiscount/Qty), PosDiscount = @Qty*PosDiscount/Qty  where InvoiceLineId = @InvoiceLineId";

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceLineId", invoiceLineId),
                new SqlParameter("@Qty", qty)
            };

            return SqlExec(qry, paramArray);
        }

        public int UpdateInvoiceLineQty(object invoiceHeaderId, object relatedLineId, int qty)
        {
            string qry = "UPDATE TrInvoiceLine set Qty = @Qty, Amount = @Qty*Price,  NetAmount = (@Qty*Price)-(@Qty*PosDiscount/Qty), PosDiscount = @Qty*PosDiscount/Qty  " +
                "WHERE InvoiceHeaderId = @InvoiceHeaderId AND RelatedLineId = @RelatedLineId";

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceHeaderId", invoiceHeaderId),
                new SqlParameter("@RelatedLineId", relatedLineId),
                new SqlParameter("@Qty", qty)
            };

            return SqlExec(qry, paramArray);
        }

        public int UpdateInvoicePosDiscount(TrInvoiceLine TrInvoiceLine)
        {
            string qry = "UPDATE [dbo].[TrInvoiceLine] set [PosDiscount] = @PosDiscount, [NetAmount] = @NetAmount where InvoiceLineId = @InvoiceLineId";

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceLineId", TrInvoiceLine.InvoiceLineId),
                new SqlParameter("@NetAmount", TrInvoiceLine.NetAmount),
                new SqlParameter("@PosDiscount",TrInvoiceLine.PosDiscount)
            };

            return SqlExec(qry, paramArray);
        }

        public int InsertCustomer(DcCurrAcc DcCurrAcc)
        {
            string qry = "INSERT INTO [dbo].[DcCurrAcc]([CurrAccTypeCode],[CurrAccCode],[FirstName],[LastName],[BonusCardNum],[Address],[PhoneNum],[BirthDate]) " +
                "VALUES(@CurrAccTypeCode,@CurrAccCode,@FirstName,@LastName,@BonusCardNum,@Address,@PhoneNum, @BirthDate)";

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@CurrAccTypeCode", 2),
                new SqlParameter("@CurrAccCode", DcCurrAcc.CurrAccCode),
                new SqlParameter("@FirstName", DcCurrAcc.FirstName),
                new SqlParameter("@LastName", DcCurrAcc.LastName),
                new SqlParameter("@BonusCardNum", DcCurrAcc.BonusCardNum ),
                new SqlParameter("@Address", DcCurrAcc.Address),
                new SqlParameter("@BirthDate", DcCurrAcc.BirthDate),
                new SqlParameter("@PhoneNum", DcCurrAcc.PhoneNum)
            };

            return SqlExec(qry, paramArray);
        }

        public int UpdateCurrAccCode(string currAccCode, Guid invoiceHeaderId)
        {
            string qry = "UPDATE [dbo].[TrInvoiceHeader] set CurrAccCode = @CurrAccCode where InvoiceHeaderId = @InvoiceHeaderId";

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceHeaderId", invoiceHeaderId),
                new SqlParameter("@CurrAccCode", currAccCode)
            };

            return SqlExec(qry, paramArray);
        }

        public int InsertPaymentHeader(TrPaymentHeader trPayment)
        {
            string qry = "INSERT INTO [dbo].[TrPaymentHeader] " +
                "([PaymentHeaderId],[InvoiceHeaderId],[DocumentNumber],[CurrAccCode]) " +
                "VALUES(@PaymentHeaderId,@InvoiceHeaderId,@DocumentNumber,@CurrAccCode)";

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@PaymentHeaderId", trPayment.PaymentHeaderId),
                new SqlParameter("@InvoiceHeaderId", trPayment.InvoiceHeaderId),
                new SqlParameter("@DocumentNumber", trPayment.DocumentNumber),
                new SqlParameter("@CurrAccCode", "C-0-0")
            };

            return SqlExec(qry, paramArray);
        }

        public int InsertPaymentLine(TrPaymentLine TrPaymentLine)
        {
            string qry = "INSERT INTO [dbo].[TrPaymentLine] ([PaymentLineId],[PaymentHeaderId],[Payment],[PaymentTypeCode]) " +
                "VALUES (@PaymentLineId,@PaymentHeaderId,@Payment,@PaymentTypeCode)";

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@PaymentLineId", TrPaymentLine.PaymentLineId),
                new SqlParameter("@PaymentHeaderId", TrPaymentLine.PaymentHeaderId),
                new SqlParameter("@Payment", TrPaymentLine.Payment),
                new SqlParameter("@PaymentTypeCode", TrPaymentLine.PaymentTypeCode)
            };

            return SqlExec(qry, paramArray);
        }

        public bool PaymentHeaderExist(Guid invoiceHeaderId)
        {
            string qry = "SELECT TOP 1 PaymentHeaderId FROM [TrPaymentHeader] WHERE ([InvoiceHeaderId] = @InvoiceHeaderId)";
            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceHeaderId", invoiceHeaderId)
            };
            DataTable dt = SqlGetDt(qry, paramArray);
            int HeaderCount = dt.Rows.Count;
            if (HeaderCount > 0) return true;
            else return false;
        }

        public DataTable SelectPaymentLine(Guid invoiceHeaderId)
        {
            string qry = "select paymentTypeDescription, Payment from TrPaymentLine " +
                "join TrPaymentHeader on TrPaymentHeader.PaymentHeaderId = TrPaymentLine.PaymentHeaderId " +
                "join DcPaymentType on TrPaymentLine.PaymentTypeCode = DcPaymentType.PaymentTypeCode " +
                "where InvoiceHeaderId = @InvoiceHeaderId"; // burdaki kolonlari dizaynda da elave et

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceHeaderId", invoiceHeaderId)
            };
            return SqlGetDt(qry, paramArray);
        }

        public DataTable SelectCurrAcc()
        {
            string qry = "select * from DcCurrAcc where DcCurrAcc.IsDisabled = 0 order by CreatedDate"; // burdaki kolonlari dizaynda da elave et
            return SqlGetDt(qry, paramArray);
        }

        public DataTable SelectOffice()
        {
            string qry = "select * from dcOffice where dcOffice.IsDisabled = 0 order by CreatedDate"; // burdaki kolonlari dizaynda da elave et
            return SqlGetDt(qry, paramArray);
        }

        public DataTable SelectStore()
        {
            string qry = "select * from dcStore where dcStore.IsDisabled = 0 order by CreatedDate"; // burdaki kolonlari dizaynda da elave et
            return SqlGetDt(qry, paramArray);
        }

        public DataTable SelectWarehouse()
        {
            string qry = "select * from dcWarehouse where dcWarehouse.IsDisabled = 0 order by CreatedDate"; // burdaki kolonlari dizaynda da elave et
            return SqlGetDt(qry, paramArray);
        }
    }
}

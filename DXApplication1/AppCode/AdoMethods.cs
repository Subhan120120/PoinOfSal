using DevExpress.XtraEditors;
using Microsoft.EntityFrameworkCore;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace PointOfSale
{
    public class AdoMethods
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
                        XtraMessageBox.Show("Data Əlavə edilməsində xəta baş verdi!");
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
            return dt.Rows[0][0].ToString();
        }

        public DataTable SelectInvoiceLines(Guid invoiceHeaderId)
        {
            string qry = "select * from TrInvoiceLines " +
                "where InvoiceHeaderId = @InvoiceHeaderId " +
                "order by CreatedDate"; // burdaki kolonlari dizaynda da elave et

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceHeaderId", invoiceHeaderId)
            };
            return SqlGetDt(qry, paramArray);
        }

        public DataTable SelectInvoiceHeaders(Guid invoiceHeaderId)
        {
            string qry = "select * from TrInvoiceHeaders " +
                "where InvoiceHeaderId = @InvoiceHeaderId " + // burdaki kolonlari dizaynda da elave et
                "order by CreatedDate"; // burdaki kolonlari dizaynda da elave et

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@InvoiceHeaderId", invoiceHeaderId)
            };
            return SqlGetDt(qry, paramArray);
        }

    }
}
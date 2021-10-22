using DevExpress.DataAccess.Sql;
using System;
using System.IO;
using System.Reflection;

namespace PointOfSale
{
    public class DsMethods
    {
        public CustomSqlQuery SelectInvoiceLines(DateTime StartDate, DateTime EndDate)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string str = "PointOfSale.AppCode.Qry_Sales.sql";
            string qry = "";
            using (Stream stream = assembly.GetManifestResourceStream(str))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    qry = reader.ReadToEnd();
                }
            }

            CustomSqlQuery sqlQuerySale = new CustomSqlQuery();
            sqlQuerySale.Name = "trInvoiceLines";
            QueryParameter queryParameter1 = new QueryParameter();
            QueryParameter queryParameter2 = new QueryParameter();
            queryParameter1.Name = "StartDate";
            queryParameter1.Type = typeof(System.DateTime);
            queryParameter1.ValueInfo = StartDate.ToString("yyyy-MM-dd");
            queryParameter2.Name = "EndDate";
            queryParameter2.Type = typeof(System.DateTime);
            queryParameter2.ValueInfo = EndDate.ToString("yyyy-MM-dd");
            sqlQuerySale.Parameters.Add(queryParameter1);
            sqlQuerySale.Parameters.Add(queryParameter2);
            sqlQuerySale.Sql = qry;

            return sqlQuerySale;
        }

        public CustomSqlQuery SelectPaymentLines(DateTime StartDate, DateTime EndDate)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string str = "PointOfSale.AppCode.Qry_Payments.sql";
            string qry = "";
            using (Stream stream = assembly.GetManifestResourceStream(str))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    qry = reader.ReadToEnd();
                }
            }


            CustomSqlQuery sqlQueryPayment = new CustomSqlQuery();
            sqlQueryPayment.Name = "trPaymentLines";
            QueryParameter queryParameter1 = new QueryParameter();
            QueryParameter queryParameter2 = new QueryParameter();

            queryParameter1.Name = "StartDate";
            queryParameter1.Type = typeof(DateTime);
            queryParameter1.ValueInfo = StartDate.ToString("yyyy-MM-dd");
            queryParameter2.Name = "EndDate";
            queryParameter2.Type = typeof(DateTime);
            queryParameter2.ValueInfo = EndDate.ToString("yyyy-MM-dd");
            sqlQueryPayment.Parameters.Add(queryParameter1);
            sqlQueryPayment.Parameters.Add(queryParameter2);
            sqlQueryPayment.Sql = qry;

            return sqlQueryPayment;
        }
    }
}

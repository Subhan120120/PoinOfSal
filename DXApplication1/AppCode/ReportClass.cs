using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale
{
    class ReportClass
    {
        SqlMethods sqlMethods = new SqlMethods();
        public string SelectDesign()
        {
            string fileExt = string.Empty;
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                fileExt = Path.GetExtension(file.FileName);
                if (fileExt.CompareTo(".repx") == 0)
                {
                    return file.FileName;
                }
                else
                {
                    XtraMessageBox.Show("Yalnız .repx fayl seçə bilərsiniz", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
            }
            else
                return "";
        }

        public XtraReport CreateReport(object Datasource, string reportDesignPath)
        {
            if (reportDesignPath == "")
                reportDesignPath = SelectDesign();

            // A path to a report's definition file.
            string reportFilePath = reportDesignPath;

            // A path to a report style sheet.
            string styleSheetFilePath = @"C:\Temp\ReportStyleSheet1.repss";

            // Create a new report instance.
            XtraReport report = new XtraReport();

            // Load a report's layout from XML.
            if (File.Exists(reportFilePath))
                report.LoadLayoutFromXml(reportFilePath);
            else
                XtraMessageBox.Show("Dizayn faylı tapılmadı.");

            // Load a report's style sheet from XML.
            //if (File.Exists(styleSheetFilePath))
            //    report.StyleSheet.LoadFromXml(styleSheetFilePath);
            //else
            //    XtraMessageBox.Show("The source file does not exist.");


            // Assign the data source to the report.
            report.DataSource = Datasource;
            //report.DataMember = "customQuery";

            // Add a detail band to the report.
            //DetailBand detailBand = new DetailBand();
            //detailBand.Height = 50;
            //report.Bands.Add(detailBand);

            // Create a new label.
            //XRLabel label = new XRLabel { WidthF = 300 };
            // Bind the label to data.
            //label.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[ProductName]"));
            // Add a label to the detail band. 
            //detailBand.Controls.Add(label);

            return report;
        }
    }
}

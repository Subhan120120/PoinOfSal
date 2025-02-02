﻿using DevExpress.DataAccess.ConnectionParameters;
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
        EfMethods efMethods = new EfMethods();
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

        public XtraReport CreateReport(object Datasource, string reportFilePath)
        {
            XtraReport report = new XtraReport();

            if (File.Exists(reportFilePath))
                report.LoadLayoutFromXml(reportFilePath);
            else
                XtraMessageBox.Show("Dizayn faylı tapılmadı.");

            //string styleSheetFilePath = @"C:\Temp\ReportStyleSheet1.repss";
            //if (File.Exists(styleSheetFilePath))
            //    report.StyleSheet.LoadFromXml(styleSheetFilePath);
            //else
            //    XtraMessageBox.Show("The source file does not exist.");

            report.DataSource = Datasource;

            return report;
        }
    }
}

﻿using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale
{
    public partial class DefaultControls : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        EfMethods efMethods = new EfMethods();
        public DefaultControls()
        {
            InitializeComponent();
        }

        private void btn_saveLayout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Stream str = new MemoryStream();
            gridView1.SaveLayoutToStream(str);
            str.Seek(0, SeekOrigin.Begin);
            StreamReader reader = new StreamReader(str);
            string layourTxt = reader.ReadToEnd();
            efMethods.UpdateAppSettingGridViewLayout(layourTxt);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
        }
    }
}
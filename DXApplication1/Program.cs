﻿using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PointOfSale
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            EfMethods efMethods = new EfMethods();
            AppSetting appSetting = efMethods.SelectAppSetting();
            Properties.Settings.Default.AppSetting = appSetting;
            Properties.Settings.Default.Save();

            Application.Run(new FormLogin());
        }
    }
}

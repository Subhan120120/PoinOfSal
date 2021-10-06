using DevExpress.XtraGrid.Views.Grid;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace PointOfSale
{
    public static class Session
    {
        public static string CurrAccCode { get; set; }
        //public string Password { get; set; }
        public static List<DcRole> DcRoles { get; set; }


    }
}

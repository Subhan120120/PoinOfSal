using DevExpress.XtraGrid.Views.Grid;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace PointOfSale
{
    public static class Authorization
    {
        public static string CurrAccCode { get; set; }

        public static List<DcRole> DcRoles { get; set; }

        public static bool Authorized(string role)
        {
            bool authorized = false;
            DcRoles.ForEach(x => authorized = x.RoleCode.Contains(role));     //check user role

            return authorized;
        }
    }
}

using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale
{
    public static class Extensions
    {
        public static bool Between(this decimal num, decimal lower, decimal upper, bool inclusive = false)
        {
            if (lower > upper) // boyuk ve kicik reqemlerin yerlerinin deyisdirilmesi ucun
            {
                decimal upper2 = upper;
                upper = lower;
                lower = upper2;
            }
            return inclusive
                ? lower <= num && num <= upper
                : lower < num && num < upper;
        }

        public static void InvisibleColumns(this LookUpEdit lookUpEdit, int[] array)
        {
            lookUpEdit.Properties.PopulateColumns();

            foreach (int item in array)
            {
                lookUpEdit.Properties.Columns[item].Visible = false;
            }
        }

        public static bool IsNumeric(this object expression)
        {
            if (expression == null)
                return false;

            double number;
            return Double.TryParse(Convert.ToString(expression
                                                    , CultureInfo.InvariantCulture)
                                  , NumberStyles.Any
                                  , NumberFormatInfo.InvariantInfo
                                  , out number);
        }
    }
}

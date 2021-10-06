using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Globalization;

namespace PointOfSale
{
    public static class Extensions
    {
        public static bool Between(this decimal num, decimal lower, decimal upper, bool inclusive = false)
        {
            if (lower > upper) // Swapping Values parametr lower and upper
            {
                decimal upper2 = upper;
                upper = lower;
                lower = upper2;
            }
            return inclusive
                ? lower <= num && num <= upper
                : lower < num && num < upper;
        }

        public static bool IsNumeric(this object value)
        {
            if (value == null)
                return false;

            double number;
            return Double.TryParse(Convert.ToString(value, CultureInfo.InvariantCulture)
                                  , NumberStyles.Any
                                  , NumberFormatInfo.InvariantInfo
                                  , out number);
        }


    }
}

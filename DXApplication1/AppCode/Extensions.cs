using System;
using System.Globalization;

namespace PointOfSale
{
    public static class Extensions
    {
        public static object ValueOrNull(this object value)
        {
            if (value != null)
            {
                if (value.GetType() == DateTime.Now.GetType())
                {
                    if (Convert.ToDateTime(value) == DateTime.MinValue)
                    {
                        return DBNull.Value;
                    }
                }
                else
                {
                    string str = value.ToString();
                    str = str.Trim();
                    if (String.IsNullOrEmpty(str) || str.Length == 0)
                        return DBNull.Value;
                }
            }
            else
                return DBNull.Value;
            return value;
        }

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

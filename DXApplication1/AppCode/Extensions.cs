using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication1
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
    }
}

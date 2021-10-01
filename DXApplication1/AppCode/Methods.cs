using DevExpress.Xpo;
using DevExpress.XtraGrid.Views.Grid;
using System;

namespace PointOfSale
{
    public static class Methods
    {
        public static string GetPreviewText(decimal PosDiscount, decimal Amount, decimal NetAmount, float VatRate, string Barcode)
        {
            decimal PosDiscountRate = 0;
            if (Amount != 0 && NetAmount != 0)
                PosDiscountRate = Math.Round(PosDiscount / Amount * 100, 2);

            string previewText = "ƏDV: " + VatRate + "%\n";

            if (Barcode != string.Empty)
                previewText += "Barkod: " + Barcode + "\n";

            if (PosDiscountRate > 0)
                previewText += "Pos Endirimi: [" + PosDiscountRate + "%] = " + PosDiscount + "\n";
            return previewText;
        }

        public static void DefaultLayout(GridView gridView)
        {
            gridView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 12F);
            gridView.Appearance.FooterPanel.Options.UseFont = true;
            gridView.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            gridView.Appearance.Row.Options.UseFont = true;
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.OptionsView.ShowIndicator = false;
            gridView.OptionsBehavior.Editable = false;
        }

    }

}
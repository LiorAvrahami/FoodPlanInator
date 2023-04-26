using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPlanInator {
    public class ListBoxUtil {
        public static void DrawListBoxItem(int realSelecttedIndex, object sender, DrawItemEventArgs e) {
            if (e.Index == -1) { return; }

            ListBox listBoxSender = (ListBox)sender;
            // Select Brush For Background
            Brush brush;
            if (e.Index == realSelecttedIndex) {
                brush = Brushes.LightGray;
            } else if (e.Index % 2 == 0) {
                brush = Brushes.White;
            } else {
                brush = Brushes.Lavender;
            }

            // Draw the background of the ListBox control for each item.
            e.Graphics.FillRectangle(brush, e.Bounds);
            // Draw the current item text based on the current Font 
            // and the custom brush settings.
            e.Graphics.DrawString(listBoxSender.Items[e.Index].ToString(),
                e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
        }
    }
}

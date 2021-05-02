using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MouseClicker
{
    class GlobalUtil
    {
        public static void SetTextBoxPos(TextBox txtBox_x, TextBox txtBox_y, Point pos)
        {
            txtBox_x.Text = pos.X.ToString();
            txtBox_y.Text = pos.Y.ToString();
        }

        public static void SetNumericRGB(
            NumericUpDown numericR
            , NumericUpDown numericG
            , NumericUpDown numericB
            , int r
            , int g
            , int b)
        {
            numericR.Value = r;
            numericG.Value = g;
            numericB.Value = b;
        }

        public static Point GetPos(TextBox txtBox_x, TextBox txtBox_y)
        {
            int x, y;
            int.TryParse(txtBox_x.Text, out x);
            int.TryParse(txtBox_y.Text, out y);
            return new Point(x, y);
        }

        public static void CopyColor(Color[,] source, int width, int height, ref Color[,] dest)
        {
            dest = new Color[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    dest[i, j] = source[i, j];
                }
            }
        }
    }
}

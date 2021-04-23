using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseClicker
{
    public partial class ConditionSelectionForm : Form
    {
        public ConditionSelectionForm(Func<Point, Color> colorGetter)
        {
            InitializeComponent();
            this.colorGetter = colorGetter;
        }

        Func<Point, Color> colorGetter;

        public ActionConditionFlag Flags
        {
            get
            {
                ActionConditionFlag flags = ActionConditionFlag.None;

                if (this.checkBox_colorEqualityCheck.Checked)
                {
                    flags |= ActionConditionFlag.ColorEquality;
                }

                return flags;
            }
        }

        public Form1.ConditionChecker.ConditionCheckParam Param
        {
            get
            {
                int r, g, b;
                int x, y;

                int.TryParse(textBox_colorCheck_posX.Text, out x);
                int.TryParse(textBox_colorCheck_posY.Text, out y);

                int.TryParse(textBox_colorCheck_rgbR.Text, out r);
                int.TryParse(textBox_colorCheck_rgbG.Text, out g);
                int.TryParse(textBox_colorCheck_rgbB.Text, out b);

                Point colorEquality_cursorPos = new Point(x, y);

                Color colorEquality_color = Color.FromArgb(255, r, g, b);

                Form1.ConditionChecker.ConditionCheckParam param = new Form1.ConditionChecker.ConditionCheckParam(
                    colorEquality_cursorPos
                    , colorEquality_color);

                return param;
            }
        }

        int Clamp(int value, int min, int max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }

        async public void Update()
        {
            if (colorGetter == null)
            {
                MessageBox.Show("colorGetter is null");
                Close();
                return;
            }

            while (true)
            {
                txtCursorColor_conditionForm.Text = colorGetter(Cursor.Position).ToString();
                txtCursorPos_conditionForm.Text = Cursor.Position.ToString();

                await Task.Delay(100);
            }
        }

        private void txtCursorColor_conditionForm_Click(object sender, EventArgs e)
        {

        }

        private void textBox_colorCheck_rgbR_TextChanged(object sender, EventArgs e)
        {
            int r = 0;
            if (int.TryParse(textBox_colorCheck_rgbR.Text, out r))
            {
                r = Clamp(r, 0, 255);
                textBox_colorCheck_rgbR.Text = r.ToString();
            }
        }

        private void textBox_colorCheck_rgbG_TextChanged(object sender, EventArgs e)
        {
            int g = 0;
            if (int.TryParse(textBox_colorCheck_rgbG.Text, out g))
            {
                g = Clamp(g, 0, 255);
                textBox_colorCheck_rgbG.Text = g.ToString();
            }
        }

        private void textBox_colorCheck_rgbB_TextChanged(object sender, EventArgs e)
        {
            int b = 0;
            if (int.TryParse(textBox_colorCheck_rgbB.Text, out b))
            {
                b = Clamp(b, 0, 255);
                textBox_colorCheck_rgbB.Text = b.ToString();
            }
        }
    }
}

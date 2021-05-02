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
    public partial class ConditionCheck_PixelTargetColor : Form
    {
        public ConditionCheck_PixelTargetColor(Func<Point, Color> colorGetter, Point firstClickPos, Point checkTargetPos, Color checkColor)
        {
            InitializeComponent();
            this.firstClickPosCaptured = firstClickPos;
            this.colorGetter = colorGetter;

            /// 초기값들 세팅 
            textBox_colorCheck_rgbR.Text = checkColor.R.ToString();
            textBox_colorCheck_rgbG.Text = checkColor.G.ToString();
            textBox_colorCheck_rgbB.Text = checkColor.B.ToString();

            textBox_colorCheck_posX.Text = checkTargetPos.X.ToString();
            textBox_colorCheck_posY.Text = checkTargetPos.Y.ToString();

            Update();
        }

        Point firstClickPosCaptured;
        Func<Point, Color> colorGetter;

        public void SetResult(Form1.ConditionChecker.ConditionEvaluateParam advEvaluateParam)
        {
            #region 색상 매칭 값 세팅
            int r, g, b;
            int x, y;

            int.TryParse(textBox_colorCheck_posX.Text, out x);
            int.TryParse(textBox_colorCheck_posY.Text, out y);

            int.TryParse(textBox_colorCheck_rgbR.Text, out r);
            int.TryParse(textBox_colorCheck_rgbG.Text, out g);
            int.TryParse(textBox_colorCheck_rgbB.Text, out b);

            Point colorEquality_cursorPos = new Point(x, y);
            Color colorEquality_color = Color.FromArgb(255, r, g, b);
            #endregion

            #region 랜덤 값 세팅 
            //    int possibility = 0;
            //     int.TryParse(textBox_possibilityCheck.Text, out possibility);
            #endregion

            advEvaluateParam.pixelCheckTargetCursorPos = colorEquality_cursorPos;
            advEvaluateParam.pixelCheckTargetColor = colorEquality_color;
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

        //private void textBox_possibilityCheck_TextChanged(object sender, EventArgs e)
        //{
        //    int v = 0;
        //    if (int.TryParse(textBox_possibilityCheck.Text, out v))
        //    {
        //        v = Clamp(v, 0, 100);
        //        textBox_possibilityCheck.Text = v.ToString();
        //    }
        //}

        private void btnApply_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnSetFirstPos_Click(object sender, EventArgs e)
        {
            textBox_colorCheck_posX.Text = firstClickPosCaptured.X.ToString();
            textBox_colorCheck_posY.Text = firstClickPosCaptured.Y.ToString();
        }

        private void textBox_colorCheck_posX_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_colorCheck_posY_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

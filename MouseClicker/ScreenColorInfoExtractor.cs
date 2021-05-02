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
    public partial class ScreenColorInfoExtractor : Form
    {
        public ScreenColorInfoExtractor(DataContainer.ColorData sourceData)
        {
            InitializeComponent();

            if (sourceData != null)
            {
                sourceData.CopyTo(OutputData);

                GlobalUtil.SetNumericRGB(targetColor_Rgb_r, targetColor_Rgb_g, targetColor_Rgb_b, OutputData.colorKey.R, OutputData.colorKey.G, OutputData.colorKey.B);
                GlobalUtil.SetNumericRGB(discardColor_Rgb_r, discardColor_Rgb_b, discardColor_Rgb_b, OutputData.discardKey.R, OutputData.discardKey.G, OutputData.discardKey.B);
                txtTargetText.Text = OutputData.key;
                numeric_acceptArrange.Value = OutputData.acceptRange;

                /// source 데이터존재할땐 바로 클릭 가능 상태로.
                IsCaptureDone = true;
                IsTargetTextSet = true;
            }
        }

        public DataContainer.ColorData OutputData = new DataContainer.ColorData();

        bool IsCaptureDone;
        bool IsTargetTextSet;

        private void ScreenColorInfoExtractor_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }

        int Clamp(int v, int min, int max)
        {
            if (v < min)
                v = min;
            else if (v > max)
                v = max;
            return v;
        }

        int RefreshMatchingPixelCount()
        {
            int acceptRange = (int)numeric_acceptArrange.Value;
            int resultCnt = ScreenColorHelper.Instance.GetMatchingColorInfo(OutputData.colorInfo, OutputData.width, OutputData.height, OutputData.colorKey, acceptRange, out OutputData.matchingColorNormalizedPos);
            OutputData.colorKeyMatchingCount = resultCnt;
            OutputData.acceptRange = acceptRange;
            return resultCnt;
        }

        private void OnCaptureClicked(object sender, EventArgs e)
        {
            using (var form = new SelectArea(SelectArea.Type.SelectArea))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    OutputData.colorInfo = form.Output_ColorInfo;
                    OutputData.width = form.Output_Width;
                    OutputData.height = form.Output_Height;

                    IsCaptureDone = true;
                    UpdateUI();
                }
            }
        }

        private void btnSetTargetColorKey_Click(object sender, EventArgs e)
        {
            using (var form = new SelectArea(SelectArea.Type.PickPixel))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    var color = form.Output_ColorInfo[0, 0];
                    targetColor_Rgb_r.Value = color.R;
                    targetColor_Rgb_g.Value = color.G;
                    targetColor_Rgb_b.Value = color.B;
                    OutputData.colorKey = form.Output_ColorInfo[0, 0];
                    UpdateUI();
                }
            }
        }

        private void btnSetBackgroundColorKey_Click(object sender, EventArgs e)
        {
            using (var form = new SelectArea(SelectArea.Type.PickPixel))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    var color = form.Output_ColorInfo[0, 0];
                    discardColor_Rgb_r.Value = color.R;
                    discardColor_Rgb_g.Value = color.G;
                    discardColor_Rgb_b.Value = color.B;
                    OutputData.discardKey = color;
                    UpdateUI();
                }
            }
        }

        void UpdateUI()
        {
            btnComplete.Enabled = IsAllSet();
            btnCheckMatchingCount.Enabled = IsAllSet();
        }

        bool IsAllSet()
        {
            return this.IsCaptureDone && this.IsTargetTextSet;
        }

        private void OnClickComplete(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            RefreshMatchingPixelCount();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtTargetText_TextChanged(object sender, EventArgs e)
        {
            IsTargetTextSet = string.IsNullOrEmpty(txtTargetText.Text) == false;
            OutputData.key = txtTargetText.Text;
            UpdateUI();
        }

        private void targetColor_Rgb_r_ValueChanged(object sender, EventArgs e)
        {
            OutputData.colorKey = Color.FromArgb((int)targetColor_Rgb_r.Value, OutputData.colorKey.G, OutputData.colorKey.B);
        }

        private void targetColor_Rgb_g_ValueChanged(object sender, EventArgs e)
        {
            OutputData.colorKey = Color.FromArgb(OutputData.colorKey.R, (int)targetColor_Rgb_g.Value, OutputData.colorKey.B);
        }

        private void targetColor_Rgb_b_ValueChanged(object sender, EventArgs e)
        {
            OutputData.colorKey = Color.FromArgb(OutputData.colorKey.R, OutputData.colorKey.G, (int)targetColor_Rgb_b.Value);
        }

        private void discardColor_Rgb_r_ValueChanged(object sender, EventArgs e)
        {
            OutputData.discardKey = Color.FromArgb((int)discardColor_Rgb_r.Value, OutputData.discardKey.G, OutputData.discardKey.B);
        }

        private void discardColor_Rgb_g_ValueChanged(object sender, EventArgs e)
        {
            OutputData.discardKey = Color.FromArgb(OutputData.discardKey.R, (int)discardColor_Rgb_g.Value, OutputData.discardKey.B);
        }

        private void discardColor_Rgb_b_ValueChanged(object sender, EventArgs e)
        {
            OutputData.discardKey = Color.FromArgb(OutputData.discardKey.R, OutputData.discardKey.G, (int)discardColor_Rgb_b.Value);
        }

        private void btnCheckMatchingCount_Click(object sender, EventArgs e)
        {
            int cnt = RefreshMatchingPixelCount();
            MessageBox.Show($"해당 컬러 매칭 개수는 {cnt} 개 입니다.");
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
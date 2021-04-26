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
        public ScreenColorInfoExtractor()
        {
            InitializeComponent();
        }

        public DataContainer.ColorData OutputData;

        bool IsCaptureDone;
        bool IsTargetColorSet;
        bool IsDiscardColorSet;
        bool IsTargetTextSet;

        private void ScreenColorInfoExtractor_Load(object sender, EventArgs e)
        {
            OutputData = new DataContainer.ColorData();

            UpdateUI();
        }

        private void OnCaptureClicked(object sender, EventArgs e)
        {
            using (var form = new SelectArea(SelectArea.Type.SelectArea))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    OutputData.colorInfo = form.Output;
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
                    txtColorKey.Text = form.Output[0, 0].ToString();
                    OutputData.colorKey = form.Output[0, 0];
                    IsTargetColorSet = true;
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
                    txtBackgroundKey.Text = form.Output[0, 0].ToString();
                    OutputData.discardKey = form.Output[0, 0];
                    IsDiscardColorSet = true;
                    UpdateUI();
                }
            }
        }

        void UpdateUI()
        {
            btnComplete.Enabled = IsAllSet();
        }

        bool IsAllSet()
        {
            return this.IsCaptureDone && this.IsDiscardColorSet && this.IsTargetColorSet && this.IsTargetTextSet;
        }

        private void OnClickComplete(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            IsTargetTextSet = string.IsNullOrEmpty(txtTargetText.Text) == false;
            UpdateUI();
        }
    }
}
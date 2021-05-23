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
    public partial class GlobalSettingForm : Form
    {
        public GlobalSettingForm()
        {
            InitializeComponent();
        }

        private void GlobalSettingForm_Load(object sender, EventArgs e)
        {
            txtBox_speedMultiplier.Text = GlobalSettingManager.SpeedMultiplier.ToString();
            txtBox_randomDelayMin.Text = GlobalSettingManager.RandomDelayBetweenActionMin.ToString();
            txtBox_randomDelayMax.Text = GlobalSettingManager.RandomDelayBetweenActionMax.ToString();
            btnApply.Enabled = false;
        }

        private void txtBox_speedMultiplier_TextChanged(object sender, EventArgs e)
        {
            UpdateApplyBtn();
        }

        private void txtBox_randomDelayMin_TextChanged(object sender, EventArgs e)
        {
            UpdateApplyBtn();
        }

        private void txtBox_randomDelayMax_TextChanged(object sender, EventArgs e)
        {
            UpdateApplyBtn();
        }

        void UpdateRandomDelayMinMax()
        {
            double min;
            double max;

            if (double.TryParse(txtBox_randomDelayMin.Text, out min) == false)
            {
                min = GlobalSettingManager.RandomDelayBetweenActionMin;
            }

            if (double.TryParse(txtBox_randomDelayMax.Text, out max) == false)
            {
                max = GlobalSettingManager.RandomDelayBetweenActionMax;
            }

            if (min > max)
            {
                txtBox_randomDelayMin.ForeColor = Color.Red;
                txtBox_randomDelayMax.ForeColor = Color.Red;
            }
            else
            {
                txtBox_randomDelayMin.ForeColor = Color.Black;
                txtBox_randomDelayMax.ForeColor = Color.Black;
            }

            GlobalSettingManager.SetRandomDelayMinMax(min, max);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            double.TryParse(txtBox_speedMultiplier.Text, out var speed);
            double.TryParse(txtBox_randomDelayMin.Text, out var min);
            double.TryParse(txtBox_randomDelayMax.Text, out var max);

            GlobalSettingManager.SpeedMultiplier = speed;
            GlobalSettingManager.RandomDelayBetweenActionMin = min;
            GlobalSettingManager.RandomDelayBetweenActionMax = max;

            DialogResult = DialogResult.OK;
            Close();
        }

        void UpdateApplyBtn()
        {
            bool canApply = false;
            double speed = 0; 
            double min = 0;
            double max = 0;

            canApply = double.TryParse(txtBox_speedMultiplier.Text, out speed)
            && double.TryParse(txtBox_randomDelayMin.Text, out min)
            && double.TryParse(txtBox_randomDelayMax.Text, out max);

            if (canApply)
            {
                canApply = min <= max;
            }

            if(canApply)
            {
                canApply = speed > 0;
            }

            btnApply.Enabled = canApply;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtBox_speedMultiplier_TextChanged_1(object sender, EventArgs e)
        {
            UpdateApplyBtn();
        }
    }
}
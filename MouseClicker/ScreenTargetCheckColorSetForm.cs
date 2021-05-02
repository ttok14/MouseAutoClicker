using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MouseClicker.DataContainer;

namespace MouseClicker
{
    public partial class ScreenTargetCheckColorSetForm : Form
    {
        public ScreenTargetCheckColorSetForm(ScreenTargetColorCheckData firstData)
        {
            InitializeComponent();

            if (firstData != null)
            {
                txtAreaCount.Text = firstData.areaList.Count.ToString();
                firstData.CopyTo(Output);
            }

            UpdateUI();
        }

        public ScreenTargetColorCheckData Output = new ScreenTargetColorCheckData();

        private void ScreenTargetCheckColorSetForm_Load(object sender, EventArgs e)
        {

        }

        void UpdateUI()
        {
            txtTargetText.Text = Output.key;
            txtAreaCount.Text = Output.areaList.Count.ToString();
            btnComplete.Enabled = string.IsNullOrEmpty(Output.key) == false;
        }

        private void txtTargetText_TextChanged(object sender, EventArgs e)
        {
            Output.key = txtTargetText.Text;
            UpdateUI();
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void btnSetArea_Click(object sender, EventArgs e)
        {
            using (var form = new SelectArea(SelectArea.Type.SelectArea))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    var area = new ScreenTargetColorCheckData.Area();

                    area.colors = form.Output_ColorInfo;
                    area.width = form.Output_Width;
                    area.height = form.Output_Height;

                    Output.areaList.Add(area);

                    UpdateUI();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Output.areaList.Clear();
            UpdateUI();
        }
    }
}

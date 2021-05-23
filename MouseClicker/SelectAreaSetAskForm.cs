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
    public partial class SelectAreaSetAskForm : Form
    {
        public SelectAreaSetAskForm()
        {
            InitializeComponent();
            TopMost = true;
        }

        public int Output_AdditionalRightX
        {
            get
            {
                return (int)numeric_X.Value;
            }
        }

        public int Output_AdditionalDownY
        {
            get
            {
                return (int)numeric_Y.Value;
            }
        }

        public int Output_AdditionalLeftX
        {
            get
            {
                return (int)numeric_left_X.Value;
            }
        }

        public int Output_AdditionalUpY
        {
            get
            {
                return (int)numeric_up_Y.Value;
            }
        }

        private void SelectAreaSetAskForm_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void numeric_X_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numeric_left_X_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

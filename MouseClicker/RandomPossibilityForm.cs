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
    public partial class RandomPossibilityForm : Form
    {
        public RandomPossibilityForm(int percentage)
        {
            InitializeComponent();

            this.numberic_possibility.Value = percentage;
        }

        public void SetResult(Form1.ConditionChecker.ConditionEvaluateParam advEvaluateParam)
        {
            advEvaluateParam.percentage = (int)numberic_possibility.Value;
        }

        // apply
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

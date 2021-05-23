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
    public partial class TextWriter : Form
    {
        string Title, Content;
        Predicate<string> confirmPredicate;

        public TextWriter(string title, string content, Predicate<string> confirmPredicate = null)
        {
            InitializeComponent();

            Title = title;
            Content = content;
            this.confirmPredicate = confirmPredicate;
            TopMost = true;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            txtTitle.Text = Title;
            txtContent.Text = Content;
            UpdateUI();
        }

        void UpdateUI()
        {
            btnConfirm.Enabled = string.IsNullOrEmpty(textBox1.Text) == false;
        }

        public string ResultText => textBox1.Text;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.confirmPredicate != null)
            {
                if (this.confirmPredicate.Invoke(ResultText) == false)
                {
                    MessageBox.Show("다른 값을 입력해주세요.");
                    return;
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

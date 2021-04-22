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
    /// <summary>
    /// 인풋 박스 Form
    /// </summary>
    public partial class Form_InputBox : Form
    {
        public string typedTxt;

        /// <summary>
        /// key : order
        /// value : 타이핑 문자열 
        /// </summary>
        Dictionary<int, string> txts = new Dictionary<int, string>();
        public List<string> Txts
        {
            get
            {
                var result = new List<string>();
                foreach (var txt in txts)
                {
                    if (string.IsNullOrEmpty(txt.Value) == false)
                    {
                        result.Add(txt.Value);
                    }
                }
                return result;
            }
        }

        public Form_InputBox()
        {
            InitializeComponent();
        }

        void SetText(int key, string str)
        {
            if (txts.ContainsKey(key) == false)
            {
                txts.Add(key, string.Empty);
            }

            txts[key] = str;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SetText(1, textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SetText(2, textBox2.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            SetText(3, textBox3.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            SetText(4, textBox4.Text);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            SetText(5, textBox5.Text);
        }
    }
}

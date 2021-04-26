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
    public partial class NumberColorSetForm : Form
    {
        public NumberColorSetForm()
        {
            InitializeComponent();

            comboBox_Number.SelectedIndex = 0;

            UpdateUI();
        }

        Dictionary<uint, DataContainer.ColorData> colorDataBuffer = new Dictionary<uint, DataContainer.ColorData>();

        private void NumberColorSetForm_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void SetData(uint num, DataContainer.ColorData colorData)
        {
            if (colorDataBuffer.ContainsKey(num) == false)
            {
                colorDataBuffer.Add(num, default(DataContainer.ColorData));
            }

            colorDataBuffer[num] = colorData;
        }

        void UpdateUI()
        {
            txtStateList.Text = "";

            for (int i = 0; i < 10; i++)
            {
                if (string.IsNullOrEmpty(txtStateList.Text) == false)
                {
                    txtStateList.Text += "\n\n";
                }

                bool isSet = this.colorDataBuffer.ContainsKey((uint)i);
                string stateMark = isSet ? "O" : "X";
                txtStateList.Text += $"숫자 {i} 설정 상태 : {stateMark}";
            }
        }

        private void txtSetInfo_Click(object sender, EventArgs e)
        {
            using (var selectArea = new SelectArea())
            {
                var result = selectArea.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var data = selectArea.Output;
                    uint curNumber = uint.Parse(comboBox_Number.Text);

                    //SetData(curNumber, new DataContainer.ColorData(curNumber.ToString(), data));
                    UpdateUI();
                }
            }
        }

        /// <summary>
        /// 파일로 저장 
        /// </summary>
        private void btnSaveAsFile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("not imeple");
        }

        /// <summary>
        /// 로컬 데이터에만 캐싱 
        /// </summary>
        private void txtSaveLocal_Click(object sender, EventArgs e)
        {
            if (colorDataBuffer.Count == 0)
            {
                MessageBox.Show("저장된 데이터가 없습니다.");
                Close();
                return;
            }

            foreach (var data in colorDataBuffer)
            {
                DataContainer.Instance.SetData_ColorCompare(data.Key.ToString(), data.Value);
            }

            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}

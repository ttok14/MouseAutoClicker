using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseClicker
{
    public partial class ActionEditor : Form
    {
        List<Form1.SingleAction> curActionData;

        public DataContainer.ActionGroup ResultActionGroup => DataContainer.Instance.GetActionGroupDataBufferByIndex(this.listBox_data.SelectedIndex);

        public ActionEditor(List<Form1.SingleAction> actionList)
        {
            InitializeComponent();
            curActionData = actionList;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            RefreshListBoxData();
            UpdateBtnState();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        void RefreshListBoxData()
        {
            listBox_data.Items.Clear();

            foreach (var data in DataContainer.ActionGroupDataBuffer)
            {
                listBox_data.Items.Add(data.Key);
            }
        }

        void UpdateBtnState()
        {
            btnChangeKey.Enabled = listBox_data.SelectedIndex != -1;
            btnRemove.Enabled = listBox_data.SelectedIndex != -1;
            btnSelect.Enabled = listBox_data.SelectedIndex != -1;

            btnClear.Enabled = DataContainer.ActionGroupDataBuffer.Count > 0;
            btnSave.Enabled = DataContainer.IsActionGroupDataBufferDirty;
            btnAdd.Enabled = curActionData != null && curActionData.Count > 0;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void listBox_data_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateBtnState();
        }

        private void btnRemove_Click_1(object sender, EventArgs e)
        {
            if (listBox_data.SelectedIndex == -1)
            {
                MessageBox.Show("에러. (cannot be clicked when the index is -1 which means non click state");
                return;
            }

            DataContainer.Instance.RemoveActionGroupDataByIndex(listBox_data.SelectedIndex);
            RefreshListBoxData();
            UpdateBtnState();
        }

        private void btnOpenCacheFolder_Click_1(object sender, EventArgs e)
        {
            Process.Start(DataContainer.Instance.CachePath);
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            DataContainer.Instance.ClearActionGroupDataBuffer();
            RefreshListBoxData();
            UpdateBtnState();
        }


        private void listBox_data_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            UpdateBtnState();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            DataContainer.Instance.SaveActionGroupData();
            UpdateBtnState();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        ///  key 변경 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeKey_Click(object sender, EventArgs e)
        {
            using (var form = new TextWriter("Key 변경", "새로운 Key 를 입력해주세요."
                , (tryConfirmText) =>
                {
                    return DataContainer.Instance.IsTargetActionGroupExist(tryConfirmText) == false;
                }))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    /// from => to 
                    DataContainer.Instance.ChangeActionGroupKey(
                        DataContainer.Instance.GetActionGroupDataBufferByIndex(this.listBox_data.SelectedIndex).key
                        , form.ResultText);

                    RefreshListBoxData();
                    UpdateBtnState();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (curActionData == null || curActionData.Count == 0)
            {
                MessageBox.Show("데이터 없음");
                UpdateBtnState();
                return;
            }

            using (var form = new TextWriter("Key 입력", "등록할 Key 를 입력해주세요"))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    if (DataContainer.Instance.IsTargetActionGroupExist(form.ResultText))
                    {
                        MessageBox.Show($"해당 키 : {form.ResultText} 가 이미 존재합니다.");
                    }
                    else
                    {
                        DataContainer.Instance.SetData_ActionGroup(form.ResultText, this.curActionData);

                        curActionData = null;

                        RefreshListBoxData();
                        UpdateBtnState();
                    }
                }
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "1";
            DataContainer.Instance.SetData_ActionGroup(this.textBox1.Text, new List<Form1.SingleAction>() { new Form1.SingleAction(ActionType.SingleMouseClick, new Point(0, 1), 10) });

            curActionData = null;

            RefreshListBoxData();
            UpdateBtnState();
        }
    }
}

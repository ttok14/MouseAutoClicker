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
using static MouseClicker.DataContainer;

namespace MouseClicker
{
    public partial class SelectAreaSetForm : Form
    {
        public List<Rectangle> areas = new List<Rectangle>();

        public SelectAreaSetForm(string sourceColorDataKey, List<Rectangle> firstAreas, float similarity)
        {
            InitializeComponent();

            foreach (var data in DataContainer.ScreenColorMatchingDataBuffer)
            {
                listBox_sourceColorData.Items.Add(data.Key);
            }

            int index = -1;

            if (string.IsNullOrEmpty(sourceColorDataKey) == false)
                index = DataContainer.Instance.GetScreenColorDataIndexByKey(sourceColorDataKey);

            if (index != -1)
            {
                listBox_sourceColorData.SetSelected(index, true);
            }

            if (firstAreas != null)
                areas.AddRange(firstAreas);

            txtBox_similarityPassThreshold.Text = similarity.ToString();

            UpdateUI();
        }

        private void SelectTargetScreenColorForm_Load(object sender, EventArgs e)
        {
        }

        public void SetResult(Form1.ConditionChecker.ConditionEvaluateParam advEvaluateParam)
        {
            var selectedData = DataContainer.Instance.GetScreenColorDataBufferByIndex(listBox_sourceColorData.SelectedIndex); ;
            advEvaluateParam.screenColorMatchingStringKey = selectedData.key;

            advEvaluateParam.screenColorMatchingAreas.Clear();
            advEvaluateParam.screenColorMatchingAreas.AddRange(areas);
            /// 여기서 실패나면 float 숫자값아닐때 드러온건데
            /// SetResult 는 확실시 될떄만 호출대야함.
            advEvaluateParam.screenColorMatchingSimilarityThreshold = float.Parse(txtBox_similarityPassThreshold.Text);
        }

        void UpdateUI()
        {
            bool similaritySet = float.TryParse(txtBox_similarityPassThreshold.Text, out var dummy);

            btnComplete.Enabled =
                listBox_sourceColorData.SelectedIndex != -1
                && this.areas.Count > 0
                && similaritySet;
            txtAreaCount.Text = areas.Count.ToString();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        /// <summary>
        /// 완료 
        /// </summary>
        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            using (var prompt = new PromptForm())
            {
                prompt.Set($"선택한 영역 초기화 ?");
                prompt.StartPosition = FormStartPosition.CenterScreen;

                var prompt_result = prompt.ShowDialog();
                if (prompt_result == DialogResult.OK)
                {
                    areas.Clear();
                    UpdateUI();
                }
            }
        }

        private void btnRemove_Click_1(object sender, EventArgs e)
        {
        }

        private void btnModify_Click_1(object sender, EventArgs e)
        {
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            float curSimiliarty = 0;

            float.TryParse(txtBox_similarityPassThreshold.Text, out curSimiliarty);

            if (curSimiliarty == 0f)
            {
                MessageBox.Show("현재 Similarity 가 0 입니다. 즉 무조건 결과가 실패로 나올것이기에 세팅을 먼저 하시오.");
                return;
            }

            using (var form = new SelectArea())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    float similiarty;
                    string resultStr = ScreenColorHelper.Instance.IsTarget(
                        DataContainer.Instance.GetScreenColorDataBufferByIndex(listBox_sourceColorData.SelectedIndex)
                        , form.Output_ColorInfo
                        , form.Output_Width
                        , form.Output_Height
                        , 10
                        , curSimiliarty
                        , out similiarty) ? "매칭" : "비매칭";

                    MessageBox.Show($"{resultStr} , similarity : {(double)similiarty}");

                    using (var form_prompt = new SelectAreaSetAskForm())
                    {
                        form_prompt.StartPosition = FormStartPosition.CenterScreen;

                        var result_prompt = form_prompt.ShowDialog();
                        if (result_prompt == DialogResult.OK)
                        {
                            /// 기본적으로 선택한 선택영역 ++ 
                            this.areas.Add(form.Output_Rectangle);

                            /// 추가 영역 존재하면 순회하며 ++
                            int additionalRightX = form_prompt.Output_AdditionalRightX;
                            int additioanlDownY = form_prompt.Output_AdditionalDownY;
                            int additionalLeftX = form_prompt.Output_AdditionalLeftX;
                            int additioanlUpY = form_prompt.Output_AdditionalUpY;

                            for (int i = 0; i < additionalRightX; i++)
                            {
                                this.areas.Add(new Rectangle(
                                    form.Output_Rectangle.X + 1 + i
                                    , form.Output_Rectangle.Y
                                    , form.Output_Rectangle.Width
                                    , form.Output_Rectangle.Height));
                            }

                            for (int i = 0; i < additioanlDownY; i++)
                            {
                                this.areas.Add(new Rectangle(
                                    form.Output_Rectangle.X
                                    , form.Output_Rectangle.Y + 1 + i
                                    , form.Output_Rectangle.Width
                                    , form.Output_Rectangle.Height));
                            }
                            
                            for (int i = 0; i < additionalLeftX; i++)
                            {
                                this.areas.Add(new Rectangle(
                                    form.Output_Rectangle.X - 1 + (i * -1)
                                    , form.Output_Rectangle.Y
                                    , form.Output_Rectangle.Width
                                    , form.Output_Rectangle.Height));
                            }

                            for (int i = 0; i < additioanlUpY; i++)
                            {
                                this.areas.Add(new Rectangle(
                                    form.Output_Rectangle.X
                                    , form.Output_Rectangle.Y - 1 + (i * -1)
                                    , form.Output_Rectangle.Width
                                    , form.Output_Rectangle.Height));
                            }

                            UpdateUI();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 저장하기 
        /// </summary>
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            DataContainer.Instance.SaveScreenTargetCheckColorData();
            UpdateUI();
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
        }

        private void listBox_sourceColorData_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtBox_similarityPassThreshold_TextChanged(object sender, EventArgs e)
        {
            float.TryParse(txtBox_similarityPassThreshold.Text, out float result);

            if (result < 0f)
            {
                result = 0;
                txtBox_similarityPassThreshold.Text = result.ToString();
            }
            else if (result > 1f)
            {
                result = 1f;
                txtBox_similarityPassThreshold.Text = result.ToString();
            }

            UpdateUI();
        }
    }
}

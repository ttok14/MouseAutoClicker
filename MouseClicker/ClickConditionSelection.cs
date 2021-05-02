using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MouseClicker.Form1.ConditionChecker;

namespace MouseClicker
{
    /// <summary>
    /// 조건따라 클릭하게 해주는 Form 클래스 .
    /// </summary>
    public partial class ClickConditionSelection : Form
    {
        public ClickConditionSelection(Func<Point, Color> getColorAt)
        {
            InitializeComponent();
            colorGetter = getColorAt;
            curPosCaptured = Cursor.Position;

            txtBox_fallBackX.Text = curPosCaptured.X.ToString();
            txtBox_fallBackY.Text = curPosCaptured.Y.ToString();

            GlobalUtil.SetTextBoxPos(txtBox_colorEqualityPos_X, txtBox_colorEqualityPos_Y, curPosCaptured);
            GlobalUtil.SetTextBoxPos(txtBox_randomPos_X, txtBox_randomPos_Y, curPosCaptured);
            GlobalUtil.SetTextBoxPos(txtBox_screenColorMatching_X, txtBox_screenColorMatching_Y, curPosCaptured);

            this.advEvaluateParam.SetAllPos(curPosCaptured);

            UpdateApplyBtn();
            Update();
        }

        Func<Point, Color> colorGetter;

        Point curPosCaptured;

        //    public ActionConditionFlag advActionConditionFlag = ActionConditionFlag.None;
        public ActionConditionFlag OutputFlags
        {
            get
            {
                ActionConditionFlag result = ActionConditionFlag.None;

                /// 타겟 색상 체크 
                if (checkBox_useColorEquality.Checked)
                {
                    result |= ActionConditionFlag.ColorEquality;
                }

                if (checkBox_useRandomPossibility.Checked)
                {
                    result |= ActionConditionFlag.Possibility;
                }

                if (checkBox_useScreenColorMatching.Checked)
                {
                    result |= ActionConditionFlag.ScreenColorMatching;
                }

                /// fall back 활성화면 ++ 
                if (checkBox_useFallBack.Checked)
                {
                    result |= ActionConditionFlag.FallBackClick;
                }

                return result;
            }
        }

        ConditionEvaluateParam advEvaluateParam = new ConditionEvaluateParam();
        public ConditionEvaluateParam OutputEvaluateParam
        {
            get
            {
                var result = advEvaluateParam;

                /// 색상 매칭용 위치 세팅 
                if (checkBox_useColorEquality.Checked)
                {
                    result.colorMatchingClickPos = GlobalUtil.GetPos(txtBox_colorEqualityPos_X, txtBox_colorEqualityPos_Y);
                }

                if (checkBox_useRandomPossibility.Checked)
                {
                    result.randomPossibilityClickPos = GlobalUtil.GetPos(txtBox_randomPos_X, txtBox_randomPos_Y);
                }

                /// 스크린 영역 색상 매칭 .
                if (checkBox_useScreenColorMatching.Checked)
                {
                    result.screenColorMatchingClickPos = GlobalUtil.GetPos(txtBox_screenColorMatching_X, txtBox_screenColorMatching_Y);
                }

                /// fall back 체크 
                if (checkBox_useFallBack.Checked)
                {
                    result.fallBackClickPos = GlobalUtil.GetPos(txtBox_fallBackX, txtBox_fallBackY);
                }

                return result;
            }
        }

        async public void Update()
        {
            while (true)
            {
                txtCurPos.Text = Cursor.Position.ToString();

                await Task.Delay(100);
            }
        }

        void UpdateApplyBtn()
        {
            btnApply.Enabled =
                checkBox_useColorEquality.Checked
                || checkBox_useFallBack.Checked
                || checkBox_useRandomPossibility.Checked
                || checkBox_useScreenColorMatching.Checked;
        }

        /// <summary>
        /// 특정 픽셀 컬러 체크 
        /// </summary>
        private void btnTargetColor_Click(object sender, EventArgs e)
        {
            using (var form = new ConditionCheck_PixelTargetColor(this.colorGetter, curPosCaptured, advEvaluateParam.pixelCheckTargetCursorPos, advEvaluateParam.pixelCheckTargetColor))
            {
                form.TopMost = true;

                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    form.SetResult(advEvaluateParam);
                }
            }
        }

        private void btnRandomPossibility_Click(object sender, EventArgs e)
        {
            using (var form = new RandomPossibilityForm(this.advEvaluateParam.percentage))
            {
                form.TopMost = true;

                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    form.SetResult(advEvaluateParam);
                }
            }
        }

        private void btnScreenColorMatching_Click(object sender, EventArgs e)
        {
            if (DataContainer.ScreenColorMatchingDataBuffer.Count == 0)
            {
                MessageBox.Show("최소한 하나의 색상 매칭 데이터가 필요함.");
                return;
            }

            string sourceDataKey = string.IsNullOrEmpty(this.advEvaluateParam.screenColorMatchingStringKey) ?
                DataContainer.Instance.GetScreenColorDataBufferByIndex(0).key
                : this.advEvaluateParam.screenColorMatchingStringKey;

            using (var form = new SelectAreaSetForm(sourceDataKey, this.advEvaluateParam.screenColorMatchingAreas, this.advEvaluateParam.screenColorMatchingSimilarityThreshold))
            {
                form.TopMost = true;

                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    form.SetResult(advEvaluateParam);
                }
            }
        }

        //void RemoveFlag(ActionConditionFlag flag)
        //{
        //    advActionConditionFlag ^= flag;
        //}


        private void button3_Click(object sender, EventArgs e)
        {
            txtBox_fallBackX.Text = this.curPosCaptured.X.ToString();
            txtBox_fallBackY.Text = this.curPosCaptured.Y.ToString();
        }

        private void btnSetFirstPos_colorEquality_Click(object sender, EventArgs e)
        {
            GlobalUtil.SetTextBoxPos(txtBox_colorEqualityPos_X, txtBox_colorEqualityPos_Y, curPosCaptured);
        }

        private void btnSetFirstPos_random_Click(object sender, EventArgs e)
        {
            GlobalUtil.SetTextBoxPos(txtBox_randomPos_X, txtBox_randomPos_X, curPosCaptured);
        }

        private void btnSetFirstPos_screenColorMatching_Click(object sender, EventArgs e)
        {
            GlobalUtil.SetTextBoxPos(txtBox_screenColorMatching_X, txtBox_screenColorMatching_Y, curPosCaptured);
        }

        private void txtBox_randomPos_X_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBox_randomPos_Y_TextChanged(object sender, EventArgs e)
        {

        }

        private void ClickConditionSelection_Load(object sender, EventArgs e)
        {

        }

        private void checkBox_useColorEquality_CheckedChanged(object sender, EventArgs e)
        {
            UpdateApplyBtn();
        }

        private void checkBoxUseFallBack_click(object sender, EventArgs e)
        {
            UpdateApplyBtn();
        }

        private void checkBox_useRandomPossibility_CheckedChanged(object sender, EventArgs e)
        {
            UpdateApplyBtn();
        }

        private void checkBox_useScreenColorMatching_CheckedChanged(object sender, EventArgs e)
        {
            UpdateApplyBtn();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            DialogResult = btnApply.Enabled ? DialogResult.OK : DialogResult.Cancel;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtCurPos_Click(object sender, EventArgs e)
        {

        }
    }
}

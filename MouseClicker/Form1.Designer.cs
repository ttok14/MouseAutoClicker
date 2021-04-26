using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MouseClicker
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnMainKeyFunction = new System.Windows.Forms.Button();
            this.remainedTimeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.remainedTimeInfoTxt = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnPause = new System.Windows.Forms.Button();
            this.autoDisableTimerCheckBox = new System.Windows.Forms.CheckBox();
            this.autoDisableRemainedCntCheckBox = new System.Windows.Forms.CheckBox();
            this.remainedCntTextBox = new System.Windows.Forms.TextBox();
            this.remainedCntInfoText = new System.Windows.Forms.Label();
            this.resetCursorPosCheckBox = new System.Windows.Forms.CheckBox();
            this.speedMultiplier = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSpeedApply = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.shortCutKeySelections = new System.Windows.Forms.ListBox();
            this.txtShortCutKeyStatus = new System.Windows.Forms.Label();
            this.btnShortCutFunction = new System.Windows.Forms.Button();
            this.currentPosAutoClickShortCutCheck = new System.Windows.Forms.CheckBox();
            this.txtCurrentSpeed = new System.Windows.Forms.Label();
            this.txtCursorColor = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnShowInstruction = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_cursorPos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.speedMultiplier)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMainKeyFunction
            // 
            resources.ApplyResources(this.btnMainKeyFunction, "btnMainKeyFunction");
            this.btnMainKeyFunction.Name = "btnMainKeyFunction";
            this.btnMainKeyFunction.UseVisualStyleBackColor = true;
            this.btnMainKeyFunction.Click += new System.EventHandler(this.OnClickMainKeyFunctionButton);
            // 
            // remainedTimeTextBox
            // 
            resources.ApplyResources(this.remainedTimeTextBox, "remainedTimeTextBox");
            this.remainedTimeTextBox.Name = "remainedTimeTextBox";
            this.remainedTimeTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // remainedTimeInfoTxt
            // 
            resources.ApplyResources(this.remainedTimeInfoTxt, "remainedTimeInfoTxt");
            this.remainedTimeInfoTxt.Name = "remainedTimeInfoTxt";
            this.remainedTimeInfoTxt.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label4.Name = "label4";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // btnPause
            // 
            resources.ApplyResources(this.btnPause, "btnPause");
            this.btnPause.Name = "btnPause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // autoDisableTimerCheckBox
            // 
            resources.ApplyResources(this.autoDisableTimerCheckBox, "autoDisableTimerCheckBox");
            this.autoDisableTimerCheckBox.Name = "autoDisableTimerCheckBox";
            this.autoDisableTimerCheckBox.UseVisualStyleBackColor = true;
            // 
            // autoDisableRemainedCntCheckBox
            // 
            resources.ApplyResources(this.autoDisableRemainedCntCheckBox, "autoDisableRemainedCntCheckBox");
            this.autoDisableRemainedCntCheckBox.Name = "autoDisableRemainedCntCheckBox";
            this.autoDisableRemainedCntCheckBox.UseVisualStyleBackColor = true;
            // 
            // remainedCntTextBox
            // 
            resources.ApplyResources(this.remainedCntTextBox, "remainedCntTextBox");
            this.remainedCntTextBox.Name = "remainedCntTextBox";
            // 
            // remainedCntInfoText
            // 
            resources.ApplyResources(this.remainedCntInfoText, "remainedCntInfoText");
            this.remainedCntInfoText.Name = "remainedCntInfoText";
            // 
            // resetCursorPosCheckBox
            // 
            resources.ApplyResources(this.resetCursorPosCheckBox, "resetCursorPosCheckBox");
            this.resetCursorPosCheckBox.Name = "resetCursorPosCheckBox";
            this.resetCursorPosCheckBox.UseVisualStyleBackColor = true;
            // 
            // speedMultiplier
            // 
            resources.ApplyResources(this.speedMultiplier, "speedMultiplier");
            this.speedMultiplier.DecimalPlaces = 2;
            this.speedMultiplier.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.speedMultiplier.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.speedMultiplier.Name = "speedMultiplier";
            this.speedMultiplier.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.speedMultiplier.ValueChanged += new System.EventHandler(this.speedMultiplier_ValueChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btnSpeedApply
            // 
            resources.ApplyResources(this.btnSpeedApply, "btnSpeedApply");
            this.btnSpeedApply.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.btnSpeedApply.Name = "btnSpeedApply";
            this.btnSpeedApply.UseVisualStyleBackColor = true;
            this.btnSpeedApply.Click += new System.EventHandler(this.btnSpeedApply_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // shortCutKeySelections
            // 
            this.shortCutKeySelections.FormattingEnabled = true;
            resources.ApplyResources(this.shortCutKeySelections, "shortCutKeySelections");
            this.shortCutKeySelections.Items.AddRange(new object[] {
            resources.GetString("shortCutKeySelections.Items"),
            resources.GetString("shortCutKeySelections.Items1"),
            resources.GetString("shortCutKeySelections.Items2")});
            this.shortCutKeySelections.Name = "shortCutKeySelections";
            this.shortCutKeySelections.SelectedIndexChanged += new System.EventHandler(this.shortCutKeySelections_SelectedIndexChanged);
            // 
            // txtShortCutKeyStatus
            // 
            resources.ApplyResources(this.txtShortCutKeyStatus, "txtShortCutKeyStatus");
            this.txtShortCutKeyStatus.Name = "txtShortCutKeyStatus";
            // 
            // btnShortCutFunction
            // 
            resources.ApplyResources(this.btnShortCutFunction, "btnShortCutFunction");
            this.btnShortCutFunction.Name = "btnShortCutFunction";
            this.btnShortCutFunction.UseVisualStyleBackColor = true;
            this.btnShortCutFunction.Click += new System.EventHandler(this.btnShortCutFunction_Click);
            // 
            // currentPosAutoClickShortCutCheck
            // 
            resources.ApplyResources(this.currentPosAutoClickShortCutCheck, "currentPosAutoClickShortCutCheck");
            this.currentPosAutoClickShortCutCheck.Name = "currentPosAutoClickShortCutCheck";
            this.currentPosAutoClickShortCutCheck.UseVisualStyleBackColor = true;
            // 
            // txtCurrentSpeed
            // 
            resources.ApplyResources(this.txtCurrentSpeed, "txtCurrentSpeed");
            this.txtCurrentSpeed.Name = "txtCurrentSpeed";
            // 
            // txtCursorColor
            // 
            resources.ApplyResources(this.txtCursorColor, "txtCursorColor");
            this.txtCursorColor.Name = "txtCursorColor";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // btnShowInstruction
            // 
            resources.ApplyResources(this.btnShowInstruction, "btnShowInstruction");
            this.btnShowInstruction.Name = "btnShowInstruction";
            this.btnShowInstruction.UseVisualStyleBackColor = true;
            this.btnShowInstruction.Click += new System.EventHandler(this.btnShowInstruction_Click);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // txt_cursorPos
            // 
            resources.ApplyResources(this.txt_cursorPos, "txt_cursorPos");
            this.txt_cursorPos.Name = "txt_cursorPos";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txt_cursorPos);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnShowInstruction);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCursorColor);
            this.Controls.Add(this.txtCurrentSpeed);
            this.Controls.Add(this.currentPosAutoClickShortCutCheck);
            this.Controls.Add(this.btnShortCutFunction);
            this.Controls.Add(this.txtShortCutKeyStatus);
            this.Controls.Add(this.shortCutKeySelections);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSpeedApply);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.speedMultiplier);
            this.Controls.Add(this.resetCursorPosCheckBox);
            this.Controls.Add(this.remainedCntInfoText);
            this.Controls.Add(this.remainedCntTextBox);
            this.Controls.Add(this.autoDisableRemainedCntCheckBox);
            this.Controls.Add(this.autoDisableTimerCheckBox);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.remainedTimeInfoTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.remainedTimeTextBox);
            this.Controls.Add(this.btnMainKeyFunction);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.speedMultiplier)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        #endregion
        private Button btnMainKeyFunction;
        private TextBox remainedTimeTextBox;
        private Label label2;
        private Label remainedTimeInfoTxt;
        private Label label4;
        private ToolTip toolTip1;
        private Label label11;
        private Label label12;
        private Button btnPause;
        private CheckBox autoDisableTimerCheckBox;
        private CheckBox autoDisableRemainedCntCheckBox;
        private TextBox remainedCntTextBox;
        private Label remainedCntInfoText;
        private CheckBox resetCursorPosCheckBox;
        private NumericUpDown speedMultiplier;
        private Label label1;
        private Button btnSpeedApply;
        private Label label3;
        private Label label5;
        private ListBox shortCutKeySelections;
        private Label txtShortCutKeyStatus;
        private Button btnShortCutFunction;
        private CheckBox currentPosAutoClickShortCutCheck;
        private Label txtCurrentSpeed;
        private Label txtCursorColor;
        private Label label9;
        private Button btnShowInstruction;
        private Label label6;
        private Label txt_cursorPos;
    }
}


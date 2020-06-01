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
            this.btnFunction = new System.Windows.Forms.Button();
            this.remainedTimeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.remainedTimeInfoTxt = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnPause = new System.Windows.Forms.Button();
            this.autoDisableTimerCheckBox = new System.Windows.Forms.CheckBox();
            this.autoDisableRemainedCntCheckBox = new System.Windows.Forms.CheckBox();
            this.remainedCntTextBox = new System.Windows.Forms.TextBox();
            this.remainedCntInfoText = new System.Windows.Forms.Label();
            this.resetCursorPosCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnFunction
            // 
            this.btnFunction.Location = new System.Drawing.Point(12, 225);
            this.btnFunction.Name = "btnFunction";
            this.btnFunction.Size = new System.Drawing.Size(105, 53);
            this.btnFunction.TabIndex = 2;
            this.btnFunction.Text = "Record";
            this.btnFunction.UseVisualStyleBackColor = true;
            this.btnFunction.Click += new System.EventHandler(this.OnClickFunctionButton);
            // 
            // remainedTimeTextBox
            // 
            this.remainedTimeTextBox.Location = new System.Drawing.Point(30, 114);
            this.remainedTimeTextBox.Name = "remainedTimeTextBox";
            this.remainedTimeTextBox.Size = new System.Drawing.Size(114, 21);
            this.remainedTimeTextBox.TabIndex = 4;
            this.remainedTimeTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "자동 종료 옵션";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // remainedTimeInfoTxt
            // 
            this.remainedTimeInfoTxt.AutoSize = true;
            this.remainedTimeInfoTxt.Location = new System.Drawing.Point(150, 117);
            this.remainedTimeInfoTxt.Name = "remainedTimeInfoTxt";
            this.remainedTimeInfoTxt.Size = new System.Drawing.Size(57, 12);
            this.remainedTimeInfoTxt.TabIndex = 6;
            this.remainedTimeInfoTxt.Text = "남은 시간";
            this.remainedTimeInfoTxt.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label4.Font = new System.Drawing.Font("Cambria", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 43);
            this.label4.TabIndex = 7;
            this.label4.Text = "State";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 290);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "-사용법-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 315);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(181, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "Record 클릭하면 녹화 모드 진입";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 337);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(321, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "단순 클릭은 마우스 왼쪽 버튼 클릭, 채팅 보내기는 휠 클릭";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 359);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(217, 12);
            this.label9.TabIndex = 12;
            this.label9.Text = "녹화 후 마우스 오른쪽 클릭하면 시작됨";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 383);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(221, 12);
            this.label10.TabIndex = 13;
            this.label10.Text = "마우스 오른쪽 한번 더 누르면 기능 종료";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(292, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 14;
            this.label11.Text = "Author";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(292, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 12);
            this.label12.TabIndex = 15;
            this.label12.Text = "Mr.LEE";
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(130, 231);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(89, 41);
            this.btnPause.TabIndex = 16;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // autoDisableTimerCheckBox
            // 
            this.autoDisableTimerCheckBox.AutoSize = true;
            this.autoDisableTimerCheckBox.Location = new System.Drawing.Point(30, 92);
            this.autoDisableTimerCheckBox.Name = "autoDisableTimerCheckBox";
            this.autoDisableTimerCheckBox.Size = new System.Drawing.Size(124, 16);
            this.autoDisableTimerCheckBox.TabIndex = 17;
            this.autoDisableTimerCheckBox.Text = "타이머 (Seconds)";
            this.autoDisableTimerCheckBox.UseVisualStyleBackColor = true;
            // 
            // autoDisableRemainedCntCheckBox
            // 
            this.autoDisableRemainedCntCheckBox.AutoSize = true;
            this.autoDisableRemainedCntCheckBox.Location = new System.Drawing.Point(30, 141);
            this.autoDisableRemainedCntCheckBox.Name = "autoDisableRemainedCntCheckBox";
            this.autoDisableRemainedCntCheckBox.Size = new System.Drawing.Size(126, 16);
            this.autoDisableRemainedCntCheckBox.TabIndex = 18;
            this.autoDisableRemainedCntCheckBox.Text = "횟수 (사이클 단위)";
            this.autoDisableRemainedCntCheckBox.UseVisualStyleBackColor = true;
            // 
            // remainedCntTextBox
            // 
            this.remainedCntTextBox.Location = new System.Drawing.Point(30, 163);
            this.remainedCntTextBox.Name = "remainedCntTextBox";
            this.remainedCntTextBox.Size = new System.Drawing.Size(114, 21);
            this.remainedCntTextBox.TabIndex = 19;
            // 
            // remainedCntInfoText
            // 
            this.remainedCntInfoText.AutoSize = true;
            this.remainedCntInfoText.Location = new System.Drawing.Point(150, 166);
            this.remainedCntInfoText.Name = "remainedCntInfoText";
            this.remainedCntInfoText.Size = new System.Drawing.Size(57, 12);
            this.remainedCntInfoText.TabIndex = 20;
            this.remainedCntInfoText.Text = "남은 횟수";
            // 
            // resetCursorPosCheckBox
            // 
            this.resetCursorPosCheckBox.AutoSize = true;
            this.resetCursorPosCheckBox.Location = new System.Drawing.Point(12, 203);
            this.resetCursorPosCheckBox.Name = "resetCursorPosCheckBox";
            this.resetCursorPosCheckBox.Size = new System.Drawing.Size(140, 16);
            this.resetCursorPosCheckBox.TabIndex = 21;
            this.resetCursorPosCheckBox.Text = "마우스 위치 원상복귀";
            this.resetCursorPosCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 403);
            this.Controls.Add(this.resetCursorPosCheckBox);
            this.Controls.Add(this.remainedCntInfoText);
            this.Controls.Add(this.remainedCntTextBox);
            this.Controls.Add(this.autoDisableRemainedCntCheckBox);
            this.Controls.Add(this.autoDisableTimerCheckBox);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.remainedTimeInfoTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.remainedTimeTextBox);
            this.Controls.Add(this.btnFunction);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        #endregion
        private Button btnFunction;
        private TextBox remainedTimeTextBox;
        private Label label2;
        private Label remainedTimeInfoTxt;
        private Label label4;
        private ToolTip toolTip1;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Button btnPause;
        private CheckBox autoDisableTimerCheckBox;
        private CheckBox autoDisableRemainedCntCheckBox;
        private TextBox remainedCntTextBox;
        private Label remainedCntInfoText;
        private CheckBox resetCursorPosCheckBox;
    }
}


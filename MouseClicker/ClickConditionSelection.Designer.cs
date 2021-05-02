namespace MouseClicker
{
    partial class ClickConditionSelection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTargetColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_useFallBack = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBox_fallBackX = new System.Windows.Forms.TextBox();
            this.txtBox_fallBackY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBox_colorEqualityPos_Y = new System.Windows.Forms.TextBox();
            this.txtBox_colorEqualityPos_X = new System.Windows.Forms.TextBox();
            this.btnSetFirstPos_colorEquality = new System.Windows.Forms.Button();
            this.checkBox_useColorEquality = new System.Windows.Forms.CheckBox();
            this.txtCurPos = new System.Windows.Forms.Label();
            this.checkBox_useRandomPossibility = new System.Windows.Forms.CheckBox();
            this.btnSetFirstPos_random = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBox_randomPos_Y = new System.Windows.Forms.TextBox();
            this.txtBox_randomPos_X = new System.Windows.Forms.TextBox();
            this.btnRandomPossibility = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBox_useScreenColorMatching = new System.Windows.Forms.CheckBox();
            this.btnSetFirstPos_screenColorMatching = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBox_screenColorMatching_Y = new System.Windows.Forms.TextBox();
            this.txtBox_screenColorMatching_X = new System.Windows.Forms.TextBox();
            this.btnScreenColorMatching = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTargetColor
            // 
            this.btnTargetColor.Font = new System.Drawing.Font("굴림", 15F);
            this.btnTargetColor.Location = new System.Drawing.Point(289, 115);
            this.btnTargetColor.Name = "btnTargetColor";
            this.btnTargetColor.Size = new System.Drawing.Size(81, 30);
            this.btnTargetColor.TabIndex = 0;
            this.btnTargetColor.Text = "편집";
            this.btnTargetColor.UseVisualStyleBackColor = true;
            this.btnTargetColor.Click += new System.EventHandler(this.btnTargetColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 20F);
            this.label1.Location = new System.Drawing.Point(23, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(480, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "원하는 조건부 클릭 액션을 선택하시오";
            // 
            // checkBox_useFallBack
            // 
            this.checkBox_useFallBack.AutoSize = true;
            this.checkBox_useFallBack.Location = new System.Drawing.Point(337, 340);
            this.checkBox_useFallBack.Name = "checkBox_useFallBack";
            this.checkBox_useFallBack.Size = new System.Drawing.Size(60, 16);
            this.checkBox_useFallBack.TabIndex = 3;
            this.checkBox_useFallBack.Text = "활성화";
            this.checkBox_useFallBack.UseVisualStyleBackColor = true;
            this.checkBox_useFallBack.CheckedChanged += new System.EventHandler(this.checkBoxUseFallBack_click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 13F);
            this.label2.Location = new System.Drawing.Point(115, 306);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(487, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "FallBack 클릭 (모든 조건이 성립되지 않을때 고정으로 클릭)";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(488, 396);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "처음 위치";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 13F);
            this.label4.Location = new System.Drawing.Point(286, 369);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "FallBack 위치 (x,y)";
            // 
            // txtBox_fallBackX
            // 
            this.txtBox_fallBackX.Location = new System.Drawing.Point(240, 396);
            this.txtBox_fallBackX.Name = "txtBox_fallBackX";
            this.txtBox_fallBackX.Size = new System.Drawing.Size(100, 21);
            this.txtBox_fallBackX.TabIndex = 8;
            // 
            // txtBox_fallBackY
            // 
            this.txtBox_fallBackY.Location = new System.Drawing.Point(370, 396);
            this.txtBox_fallBackY.Name = "txtBox_fallBackY";
            this.txtBox_fallBackY.Size = new System.Drawing.Size(100, 21);
            this.txtBox_fallBackY.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 13F);
            this.label3.Location = new System.Drawing.Point(216, 396);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "x";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 13F);
            this.label5.Location = new System.Drawing.Point(346, 399);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 18);
            this.label5.TabIndex = 11;
            this.label5.Text = "y";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(393, 452);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 12;
            this.btnApply.Text = "적용";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(288, 452);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 13F);
            this.label7.Location = new System.Drawing.Point(510, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 18);
            this.label7.TabIndex = 18;
            this.label7.Text = "y";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 13F);
            this.label8.Location = new System.Drawing.Point(380, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 18);
            this.label8.TabIndex = 17;
            this.label8.Text = "x";
            // 
            // txtBox_colorEqualityPos_Y
            // 
            this.txtBox_colorEqualityPos_Y.Location = new System.Drawing.Point(534, 122);
            this.txtBox_colorEqualityPos_Y.Name = "txtBox_colorEqualityPos_Y";
            this.txtBox_colorEqualityPos_Y.Size = new System.Drawing.Size(100, 21);
            this.txtBox_colorEqualityPos_Y.TabIndex = 16;
            // 
            // txtBox_colorEqualityPos_X
            // 
            this.txtBox_colorEqualityPos_X.Location = new System.Drawing.Point(404, 122);
            this.txtBox_colorEqualityPos_X.Name = "txtBox_colorEqualityPos_X";
            this.txtBox_colorEqualityPos_X.Size = new System.Drawing.Size(100, 21);
            this.txtBox_colorEqualityPos_X.TabIndex = 15;
            // 
            // btnSetFirstPos_colorEquality
            // 
            this.btnSetFirstPos_colorEquality.Location = new System.Drawing.Point(648, 119);
            this.btnSetFirstPos_colorEquality.Name = "btnSetFirstPos_colorEquality";
            this.btnSetFirstPos_colorEquality.Size = new System.Drawing.Size(75, 23);
            this.btnSetFirstPos_colorEquality.TabIndex = 19;
            this.btnSetFirstPos_colorEquality.Text = "처음 위치";
            this.btnSetFirstPos_colorEquality.UseVisualStyleBackColor = true;
            this.btnSetFirstPos_colorEquality.Click += new System.EventHandler(this.btnSetFirstPos_colorEquality_Click);
            // 
            // checkBox_useColorEquality
            // 
            this.checkBox_useColorEquality.AutoSize = true;
            this.checkBox_useColorEquality.Font = new System.Drawing.Font("굴림", 14F);
            this.checkBox_useColorEquality.Location = new System.Drawing.Point(13, 119);
            this.checkBox_useColorEquality.Name = "checkBox_useColorEquality";
            this.checkBox_useColorEquality.Size = new System.Drawing.Size(261, 23);
            this.checkBox_useColorEquality.TabIndex = 20;
            this.checkBox_useColorEquality.Text = "특정 픽셀의 특정 색상 체크";
            this.checkBox_useColorEquality.UseVisualStyleBackColor = true;
            this.checkBox_useColorEquality.CheckedChanged += new System.EventHandler(this.checkBox_useColorEquality_CheckedChanged);
            // 
            // txtCurPos
            // 
            this.txtCurPos.AutoSize = true;
            this.txtCurPos.Location = new System.Drawing.Point(26, 63);
            this.txtCurPos.Name = "txtCurPos";
            this.txtCurPos.Size = new System.Drawing.Size(45, 12);
            this.txtCurPos.TabIndex = 21;
            this.txtCurPos.Text = "현 위치";
            this.txtCurPos.Click += new System.EventHandler(this.txtCurPos_Click);
            // 
            // checkBox_useRandomPossibility
            // 
            this.checkBox_useRandomPossibility.AutoSize = true;
            this.checkBox_useRandomPossibility.Font = new System.Drawing.Font("굴림", 14F);
            this.checkBox_useRandomPossibility.Location = new System.Drawing.Point(14, 155);
            this.checkBox_useRandomPossibility.Name = "checkBox_useRandomPossibility";
            this.checkBox_useRandomPossibility.Size = new System.Drawing.Size(110, 23);
            this.checkBox_useRandomPossibility.TabIndex = 28;
            this.checkBox_useRandomPossibility.Text = "랜덤 확률";
            this.checkBox_useRandomPossibility.UseVisualStyleBackColor = true;
            this.checkBox_useRandomPossibility.CheckedChanged += new System.EventHandler(this.checkBox_useRandomPossibility_CheckedChanged);
            // 
            // btnSetFirstPos_random
            // 
            this.btnSetFirstPos_random.Location = new System.Drawing.Point(649, 155);
            this.btnSetFirstPos_random.Name = "btnSetFirstPos_random";
            this.btnSetFirstPos_random.Size = new System.Drawing.Size(75, 23);
            this.btnSetFirstPos_random.TabIndex = 27;
            this.btnSetFirstPos_random.Text = "처음 위치";
            this.btnSetFirstPos_random.UseVisualStyleBackColor = true;
            this.btnSetFirstPos_random.Click += new System.EventHandler(this.btnSetFirstPos_random_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 13F);
            this.label6.Location = new System.Drawing.Point(511, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 18);
            this.label6.TabIndex = 26;
            this.label6.Text = "y";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("굴림", 13F);
            this.label9.Location = new System.Drawing.Point(381, 158);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 18);
            this.label9.TabIndex = 25;
            this.label9.Text = "x";
            // 
            // txtBox_randomPos_Y
            // 
            this.txtBox_randomPos_Y.Location = new System.Drawing.Point(535, 158);
            this.txtBox_randomPos_Y.Name = "txtBox_randomPos_Y";
            this.txtBox_randomPos_Y.Size = new System.Drawing.Size(100, 21);
            this.txtBox_randomPos_Y.TabIndex = 24;
            this.txtBox_randomPos_Y.TextChanged += new System.EventHandler(this.txtBox_randomPos_Y_TextChanged);
            // 
            // txtBox_randomPos_X
            // 
            this.txtBox_randomPos_X.Location = new System.Drawing.Point(405, 158);
            this.txtBox_randomPos_X.Name = "txtBox_randomPos_X";
            this.txtBox_randomPos_X.Size = new System.Drawing.Size(100, 21);
            this.txtBox_randomPos_X.TabIndex = 23;
            this.txtBox_randomPos_X.TextChanged += new System.EventHandler(this.txtBox_randomPos_X_TextChanged);
            // 
            // btnRandomPossibility
            // 
            this.btnRandomPossibility.Font = new System.Drawing.Font("굴림", 15F);
            this.btnRandomPossibility.Location = new System.Drawing.Point(290, 151);
            this.btnRandomPossibility.Name = "btnRandomPossibility";
            this.btnRandomPossibility.Size = new System.Drawing.Size(81, 30);
            this.btnRandomPossibility.TabIndex = 22;
            this.btnRandomPossibility.Text = "편집";
            this.btnRandomPossibility.UseVisualStyleBackColor = true;
            this.btnRandomPossibility.Click += new System.EventHandler(this.btnRandomPossibility_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("굴림", 13F);
            this.label10.Location = new System.Drawing.Point(427, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(248, 18);
            this.label10.TabIndex = 29;
            this.label10.Text = "해당 조건 충족시 클릭할 위치";
            // 
            // checkBox_useScreenColorMatching
            // 
            this.checkBox_useScreenColorMatching.AutoSize = true;
            this.checkBox_useScreenColorMatching.Font = new System.Drawing.Font("굴림", 14F);
            this.checkBox_useScreenColorMatching.Location = new System.Drawing.Point(14, 191);
            this.checkBox_useScreenColorMatching.Name = "checkBox_useScreenColorMatching";
            this.checkBox_useScreenColorMatching.Size = new System.Drawing.Size(217, 23);
            this.checkBox_useScreenColorMatching.TabIndex = 36;
            this.checkBox_useScreenColorMatching.Text = "스크린 영역 색상 매칭";
            this.checkBox_useScreenColorMatching.UseVisualStyleBackColor = true;
            this.checkBox_useScreenColorMatching.CheckedChanged += new System.EventHandler(this.checkBox_useScreenColorMatching_CheckedChanged);
            // 
            // btnSetFirstPos_screenColorMatching
            // 
            this.btnSetFirstPos_screenColorMatching.Location = new System.Drawing.Point(649, 191);
            this.btnSetFirstPos_screenColorMatching.Name = "btnSetFirstPos_screenColorMatching";
            this.btnSetFirstPos_screenColorMatching.Size = new System.Drawing.Size(75, 23);
            this.btnSetFirstPos_screenColorMatching.TabIndex = 35;
            this.btnSetFirstPos_screenColorMatching.Text = "처음 위치";
            this.btnSetFirstPos_screenColorMatching.UseVisualStyleBackColor = true;
            this.btnSetFirstPos_screenColorMatching.Click += new System.EventHandler(this.btnSetFirstPos_screenColorMatching_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("굴림", 13F);
            this.label11.Location = new System.Drawing.Point(511, 197);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 18);
            this.label11.TabIndex = 34;
            this.label11.Text = "y";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("굴림", 13F);
            this.label12.Location = new System.Drawing.Point(381, 194);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 18);
            this.label12.TabIndex = 33;
            this.label12.Text = "x";
            // 
            // txtBox_screenColorMatching_Y
            // 
            this.txtBox_screenColorMatching_Y.Location = new System.Drawing.Point(535, 194);
            this.txtBox_screenColorMatching_Y.Name = "txtBox_screenColorMatching_Y";
            this.txtBox_screenColorMatching_Y.Size = new System.Drawing.Size(100, 21);
            this.txtBox_screenColorMatching_Y.TabIndex = 32;
            // 
            // txtBox_screenColorMatching_X
            // 
            this.txtBox_screenColorMatching_X.Location = new System.Drawing.Point(405, 194);
            this.txtBox_screenColorMatching_X.Name = "txtBox_screenColorMatching_X";
            this.txtBox_screenColorMatching_X.Size = new System.Drawing.Size(100, 21);
            this.txtBox_screenColorMatching_X.TabIndex = 31;
            // 
            // btnScreenColorMatching
            // 
            this.btnScreenColorMatching.Font = new System.Drawing.Font("굴림", 15F);
            this.btnScreenColorMatching.Location = new System.Drawing.Point(290, 187);
            this.btnScreenColorMatching.Name = "btnScreenColorMatching";
            this.btnScreenColorMatching.Size = new System.Drawing.Size(81, 30);
            this.btnScreenColorMatching.TabIndex = 30;
            this.btnScreenColorMatching.Text = "편집";
            this.btnScreenColorMatching.UseVisualStyleBackColor = true;
            this.btnScreenColorMatching.Click += new System.EventHandler(this.btnScreenColorMatching_Click);
            // 
            // ClickConditionSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 497);
            this.Controls.Add(this.checkBox_useScreenColorMatching);
            this.Controls.Add(this.btnSetFirstPos_screenColorMatching);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtBox_screenColorMatching_Y);
            this.Controls.Add(this.txtBox_screenColorMatching_X);
            this.Controls.Add(this.btnScreenColorMatching);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.checkBox_useRandomPossibility);
            this.Controls.Add(this.btnSetFirstPos_random);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtBox_randomPos_Y);
            this.Controls.Add(this.txtBox_randomPos_X);
            this.Controls.Add(this.btnRandomPossibility);
            this.Controls.Add(this.txtCurPos);
            this.Controls.Add(this.checkBox_useColorEquality);
            this.Controls.Add(this.btnSetFirstPos_colorEquality);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtBox_colorEqualityPos_Y);
            this.Controls.Add(this.txtBox_colorEqualityPos_X);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBox_fallBackY);
            this.Controls.Add(this.txtBox_fallBackX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBox_useFallBack);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTargetColor);
            this.Name = "ClickConditionSelection";
            this.Text = "ClickConditionSelection";
            this.Load += new System.EventHandler(this.ClickConditionSelection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTargetColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_useFallBack;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBox_fallBackX;
        private System.Windows.Forms.TextBox txtBox_fallBackY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBox_colorEqualityPos_Y;
        private System.Windows.Forms.TextBox txtBox_colorEqualityPos_X;
        private System.Windows.Forms.Button btnSetFirstPos_colorEquality;
        private System.Windows.Forms.CheckBox checkBox_useColorEquality;
        private System.Windows.Forms.Label txtCurPos;
        private System.Windows.Forms.CheckBox checkBox_useRandomPossibility;
        private System.Windows.Forms.Button btnSetFirstPos_random;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBox_randomPos_Y;
        private System.Windows.Forms.TextBox txtBox_randomPos_X;
        private System.Windows.Forms.Button btnRandomPossibility;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBox_useScreenColorMatching;
        private System.Windows.Forms.Button btnSetFirstPos_screenColorMatching;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBox_screenColorMatching_Y;
        private System.Windows.Forms.TextBox txtBox_screenColorMatching_X;
        private System.Windows.Forms.Button btnScreenColorMatching;
    }
}
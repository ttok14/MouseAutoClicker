namespace MouseClicker
{
    partial class ScreenColorInfoExtractor
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelectArea = new System.Windows.Forms.Button();
            this.btnSetTargetColorKey = new System.Windows.Forms.Button();
            this.btnSetBackgroundColorKey = new System.Windows.Forms.Button();
            this.txtTargetText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnComplete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.targetColor_Rgb_r = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.targetColor_Rgb_g = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.targetColor_Rgb_b = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.discardColor_Rgb_b = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.discardColor_Rgb_g = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.discardColor_Rgb_r = new System.Windows.Forms.NumericUpDown();
            this.btnCheckMatchingCount = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.targetColor_Rgb_r)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.targetColor_Rgb_g)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.targetColor_Rgb_b)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.discardColor_Rgb_b)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.discardColor_Rgb_g)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.discardColor_Rgb_r)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 15F);
            this.label1.Location = new System.Drawing.Point(51, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "타겟 색상키 (문자 인식용)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 15F);
            this.label2.Location = new System.Drawing.Point(51, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "여백키 (빈 공간 인식용)";
            // 
            // btnSelectArea
            // 
            this.btnSelectArea.Location = new System.Drawing.Point(105, 21);
            this.btnSelectArea.Name = "btnSelectArea";
            this.btnSelectArea.Size = new System.Drawing.Size(103, 23);
            this.btnSelectArea.TabIndex = 4;
            this.btnSelectArea.Text = "문자영역 캡쳐";
            this.btnSelectArea.UseVisualStyleBackColor = true;
            this.btnSelectArea.Click += new System.EventHandler(this.OnCaptureClicked);
            // 
            // btnSetTargetColorKey
            // 
            this.btnSetTargetColorKey.Location = new System.Drawing.Point(120, 106);
            this.btnSetTargetColorKey.Name = "btnSetTargetColorKey";
            this.btnSetTargetColorKey.Size = new System.Drawing.Size(75, 23);
            this.btnSetTargetColorKey.TabIndex = 5;
            this.btnSetTargetColorKey.Text = "캡쳐";
            this.btnSetTargetColorKey.UseVisualStyleBackColor = true;
            this.btnSetTargetColorKey.Click += new System.EventHandler(this.btnSetTargetColorKey_Click);
            // 
            // btnSetBackgroundColorKey
            // 
            this.btnSetBackgroundColorKey.Location = new System.Drawing.Point(120, 214);
            this.btnSetBackgroundColorKey.Name = "btnSetBackgroundColorKey";
            this.btnSetBackgroundColorKey.Size = new System.Drawing.Size(75, 23);
            this.btnSetBackgroundColorKey.TabIndex = 6;
            this.btnSetBackgroundColorKey.Text = "캡쳐";
            this.btnSetBackgroundColorKey.UseVisualStyleBackColor = true;
            this.btnSetBackgroundColorKey.Click += new System.EventHandler(this.btnSetBackgroundColorKey_Click);
            // 
            // txtTargetText
            // 
            this.txtTargetText.Location = new System.Drawing.Point(13, 312);
            this.txtTargetText.Name = "txtTargetText";
            this.txtTargetText.Size = new System.Drawing.Size(302, 21);
            this.txtTargetText.TabIndex = 7;
            this.txtTargetText.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 15F);
            this.label3.Location = new System.Drawing.Point(127, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "텍스트";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 12F);
            this.label4.Location = new System.Drawing.Point(102, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "설정해주세요.";
            // 
            // btnComplete
            // 
            this.btnComplete.Location = new System.Drawing.Point(178, 447);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(115, 29);
            this.btnComplete.TabIndex = 10;
            this.btnComplete.Text = "완료";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.OnClickComplete);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(25, 447);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 29);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // targetColor_Rgb_r
            // 
            this.targetColor_Rgb_r.Location = new System.Drawing.Point(55, 144);
            this.targetColor_Rgb_r.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.targetColor_Rgb_r.Name = "targetColor_Rgb_r";
            this.targetColor_Rgb_r.Size = new System.Drawing.Size(52, 21);
            this.targetColor_Rgb_r.TabIndex = 12;
            this.targetColor_Rgb_r.ValueChanged += new System.EventHandler(this.targetColor_Rgb_r_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "R";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(125, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "G";
            // 
            // targetColor_Rgb_g
            // 
            this.targetColor_Rgb_g.Location = new System.Drawing.Point(144, 144);
            this.targetColor_Rgb_g.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.targetColor_Rgb_g.Name = "targetColor_Rgb_g";
            this.targetColor_Rgb_g.Size = new System.Drawing.Size(52, 21);
            this.targetColor_Rgb_g.TabIndex = 14;
            this.targetColor_Rgb_g.ValueChanged += new System.EventHandler(this.targetColor_Rgb_g_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(212, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "B";
            // 
            // targetColor_Rgb_b
            // 
            this.targetColor_Rgb_b.Location = new System.Drawing.Point(231, 144);
            this.targetColor_Rgb_b.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.targetColor_Rgb_b.Name = "targetColor_Rgb_b";
            this.targetColor_Rgb_b.Size = new System.Drawing.Size(52, 21);
            this.targetColor_Rgb_b.TabIndex = 16;
            this.targetColor_Rgb_b.ValueChanged += new System.EventHandler(this.targetColor_Rgb_b_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(211, 254);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 12);
            this.label8.TabIndex = 23;
            this.label8.Text = "B";
            // 
            // discardColor_Rgb_b
            // 
            this.discardColor_Rgb_b.Location = new System.Drawing.Point(230, 252);
            this.discardColor_Rgb_b.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.discardColor_Rgb_b.Name = "discardColor_Rgb_b";
            this.discardColor_Rgb_b.Size = new System.Drawing.Size(52, 21);
            this.discardColor_Rgb_b.TabIndex = 22;
            this.discardColor_Rgb_b.ValueChanged += new System.EventHandler(this.discardColor_Rgb_b_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(124, 254);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 12);
            this.label9.TabIndex = 21;
            this.label9.Text = "G";
            // 
            // discardColor_Rgb_g
            // 
            this.discardColor_Rgb_g.Location = new System.Drawing.Point(143, 252);
            this.discardColor_Rgb_g.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.discardColor_Rgb_g.Name = "discardColor_Rgb_g";
            this.discardColor_Rgb_g.Size = new System.Drawing.Size(52, 21);
            this.discardColor_Rgb_g.TabIndex = 20;
            this.discardColor_Rgb_g.ValueChanged += new System.EventHandler(this.discardColor_Rgb_g_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(35, 254);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 12);
            this.label10.TabIndex = 19;
            this.label10.Text = "R";
            // 
            // discardColor_Rgb_r
            // 
            this.discardColor_Rgb_r.Location = new System.Drawing.Point(54, 252);
            this.discardColor_Rgb_r.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.discardColor_Rgb_r.Name = "discardColor_Rgb_r";
            this.discardColor_Rgb_r.Size = new System.Drawing.Size(52, 21);
            this.discardColor_Rgb_r.TabIndex = 18;
            this.discardColor_Rgb_r.ValueChanged += new System.EventHandler(this.discardColor_Rgb_r_ValueChanged);
            // 
            // btnCheckMatchingCount
            // 
            this.btnCheckMatchingCount.Location = new System.Drawing.Point(163, 398);
            this.btnCheckMatchingCount.Name = "btnCheckMatchingCount";
            this.btnCheckMatchingCount.Size = new System.Drawing.Size(152, 23);
            this.btnCheckMatchingCount.TabIndex = 24;
            this.btnCheckMatchingCount.Text = "컬러키 매칭 개수 확인";
            this.btnCheckMatchingCount.UseVisualStyleBackColor = true;
            this.btnCheckMatchingCount.Click += new System.EventHandler(this.btnCheckMatchingCount_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(25, 401);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 21);
            this.numericUpDown1.TabIndex = 25;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("굴림", 15F);
            this.label11.Location = new System.Drawing.Point(63, 351);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(230, 20);
            this.label11.TabIndex = 26;
            this.label11.Text = "컬러키 매칭 개수 카운트";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(47, 383);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 12);
            this.label12.TabIndex = 27;
            this.label12.Text = "오차허용 범위";
            // 
            // ScreenColorInfoExtractor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 497);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.btnCheckMatchingCount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.discardColor_Rgb_b);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.discardColor_Rgb_g);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.discardColor_Rgb_r);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.targetColor_Rgb_b);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.targetColor_Rgb_g);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.targetColor_Rgb_r);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTargetText);
            this.Controls.Add(this.btnSetBackgroundColorKey);
            this.Controls.Add(this.btnSetTargetColorKey);
            this.Controls.Add(this.btnSelectArea);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ScreenColorInfoExtractor";
            this.Text = "영역 색상 설정";
            this.Load += new System.EventHandler(this.ScreenColorInfoExtractor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.targetColor_Rgb_r)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.targetColor_Rgb_g)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.targetColor_Rgb_b)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.discardColor_Rgb_b)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.discardColor_Rgb_g)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.discardColor_Rgb_r)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSelectArea;
        private System.Windows.Forms.Button btnSetTargetColorKey;
        private System.Windows.Forms.Button btnSetBackgroundColorKey;
        private System.Windows.Forms.TextBox txtTargetText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown targetColor_Rgb_r;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown targetColor_Rgb_g;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown targetColor_Rgb_b;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown discardColor_Rgb_b;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown discardColor_Rgb_g;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown discardColor_Rgb_r;
        private System.Windows.Forms.Button btnCheckMatchingCount;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}
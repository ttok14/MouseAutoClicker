namespace MouseClicker
{
    partial class GlobalSettingForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtBox_randomDelayMin = new System.Windows.Forms.TextBox();
            this.txtBox_randomDelayMax = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtBox_speedMultiplier = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(133, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "설정하기";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 12F);
            this.label2.Location = new System.Drawing.Point(47, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "스피드 (곱셈)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 12F);
            this.label3.Location = new System.Drawing.Point(6, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "액션간 추가 딜레이";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(183, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "최소";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(281, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "최대";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(99, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "닫기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBox_randomDelayMin
            // 
            this.txtBox_randomDelayMin.Location = new System.Drawing.Point(158, 111);
            this.txtBox_randomDelayMin.Name = "txtBox_randomDelayMin";
            this.txtBox_randomDelayMin.Size = new System.Drawing.Size(85, 21);
            this.txtBox_randomDelayMin.TabIndex = 12;
            this.txtBox_randomDelayMin.TextChanged += new System.EventHandler(this.txtBox_randomDelayMin_TextChanged);
            // 
            // txtBox_randomDelayMax
            // 
            this.txtBox_randomDelayMax.Location = new System.Drawing.Point(258, 112);
            this.txtBox_randomDelayMax.Name = "txtBox_randomDelayMax";
            this.txtBox_randomDelayMax.Size = new System.Drawing.Size(85, 21);
            this.txtBox_randomDelayMax.TabIndex = 13;
            this.txtBox_randomDelayMax.TextChanged += new System.EventHandler(this.txtBox_randomDelayMax_TextChanged);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(189, 208);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 14;
            this.btnApply.Text = "적용";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtBox_speedMultiplier
            // 
            this.txtBox_speedMultiplier.Location = new System.Drawing.Point(158, 72);
            this.txtBox_speedMultiplier.Name = "txtBox_speedMultiplier";
            this.txtBox_speedMultiplier.Size = new System.Drawing.Size(85, 21);
            this.txtBox_speedMultiplier.TabIndex = 15;
            this.txtBox_speedMultiplier.TextChanged += new System.EventHandler(this.txtBox_speedMultiplier_TextChanged_1);
            // 
            // GlobalSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 243);
            this.Controls.Add(this.txtBox_speedMultiplier);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.txtBox_randomDelayMax);
            this.Controls.Add(this.txtBox_randomDelayMin);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "GlobalSettingForm";
            this.Text = "GlobalSettingForm";
            this.Load += new System.EventHandler(this.GlobalSettingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtBox_randomDelayMin;
        private System.Windows.Forms.TextBox txtBox_randomDelayMax;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox txtBox_speedMultiplier;
    }
}
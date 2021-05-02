namespace MouseClicker
{
    partial class ScreenTargetCheckColorSetForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnComplete = new System.Windows.Forms.Button();
            this.txtTargetText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAreaCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSetArea = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(49, 173);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 29);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnComplete
            // 
            this.btnComplete.Location = new System.Drawing.Point(202, 173);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(115, 29);
            this.btnComplete.TabIndex = 14;
            this.btnComplete.Text = "완료";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // txtTargetText
            // 
            this.txtTargetText.Location = new System.Drawing.Point(37, 46);
            this.txtTargetText.Name = "txtTargetText";
            this.txtTargetText.Size = new System.Drawing.Size(302, 21);
            this.txtTargetText.TabIndex = 12;
            this.txtTargetText.TextChanged += new System.EventHandler(this.txtTargetText_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 15F);
            this.label1.Location = new System.Drawing.Point(108, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "식별 아이디 (Key)";
            // 
            // txtAreaCount
            // 
            this.txtAreaCount.AutoSize = true;
            this.txtAreaCount.Font = new System.Drawing.Font("굴림", 13F);
            this.txtAreaCount.Location = new System.Drawing.Point(191, 132);
            this.txtAreaCount.Name = "txtAreaCount";
            this.txtAreaCount.Size = new System.Drawing.Size(44, 18);
            this.txtAreaCount.TabIndex = 17;
            this.txtAreaCount.Text = "개수";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 13F);
            this.label3.Location = new System.Drawing.Point(130, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 18);
            this.label3.TabIndex = 18;
            this.label3.Text = "개수 :";
            // 
            // btnSetArea
            // 
            this.btnSetArea.Location = new System.Drawing.Point(49, 87);
            this.btnSetArea.Name = "btnSetArea";
            this.btnSetArea.Size = new System.Drawing.Size(115, 29);
            this.btnSetArea.TabIndex = 19;
            this.btnSetArea.Text = "영역 설정";
            this.btnSetArea.UseVisualStyleBackColor = true;
            this.btnSetArea.Click += new System.EventHandler(this.btnSetArea_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(202, 87);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(115, 29);
            this.btnClear.TabIndex = 20;
            this.btnClear.Text = "영역 클리어";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ScreenTargetCheckColorSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 213);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSetArea);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAreaCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.txtTargetText);
            this.Name = "ScreenTargetCheckColorSetForm";
            this.Text = "ScreenTargetCheckColorSetForm";
            this.Load += new System.EventHandler(this.ScreenTargetCheckColorSetForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.TextBox txtTargetText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtAreaCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSetArea;
        private System.Windows.Forms.Button btnClear;
    }
}
namespace MouseClicker
{
    partial class SelectAreaSetAskForm
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
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.numeric_X = new System.Windows.Forms.NumericUpDown();
            this.txtlabel = new System.Windows.Forms.Label();
            this.numeric_Y = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Y)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(221, 188);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "확인";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(103, 188);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // numeric_X
            // 
            this.numeric_X.Location = new System.Drawing.Point(216, 82);
            this.numeric_X.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numeric_X.Name = "numeric_X";
            this.numeric_X.Size = new System.Drawing.Size(120, 21);
            this.numeric_X.TabIndex = 2;
            // 
            // txtlabel
            // 
            this.txtlabel.AutoSize = true;
            this.txtlabel.Font = new System.Drawing.Font("굴림", 12F);
            this.txtlabel.Location = new System.Drawing.Point(52, 82);
            this.txtlabel.Name = "txtlabel";
            this.txtlabel.Size = new System.Drawing.Size(151, 16);
            this.txtlabel.TabIndex = 3;
            this.txtlabel.Text = "우측 추가 체크 개수";
            // 
            // numeric_Y
            // 
            this.numeric_Y.Location = new System.Drawing.Point(216, 126);
            this.numeric_Y.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numeric_Y.Name = "numeric_Y";
            this.numeric_Y.Size = new System.Drawing.Size(120, 21);
            this.numeric_Y.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(99, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "추가하시겠습니까?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F);
            this.label1.Location = new System.Drawing.Point(52, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "하단 추가 체크 개수";
            // 
            // SelectAreaSetAskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 230);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numeric_Y);
            this.Controls.Add(this.txtlabel);
            this.Controls.Add(this.numeric_X);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Name = "SelectAreaSetAskForm";
            this.Text = "SelectAreaSetAskForm";
            this.Load += new System.EventHandler(this.SelectAreaSetAskForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numeric_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Y)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown numeric_X;
        private System.Windows.Forms.Label txtlabel;
        private System.Windows.Forms.NumericUpDown numeric_Y;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
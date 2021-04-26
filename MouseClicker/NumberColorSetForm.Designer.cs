namespace MouseClicker
{
    partial class NumberColorSetForm
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
            this.comboBox_Number = new System.Windows.Forms.ComboBox();
            this.txtSetInfo = new System.Windows.Forms.Button();
            this.txtStateList = new System.Windows.Forms.Label();
            this.btnSaveAsFile = new System.Windows.Forms.Button();
            this.txtSaveLocal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox_Number
            // 
            this.comboBox_Number.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBox_Number.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Number.FormattingEnabled = true;
            this.comboBox_Number.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBox_Number.Location = new System.Drawing.Point(12, 72);
            this.comboBox_Number.Name = "comboBox_Number";
            this.comboBox_Number.Size = new System.Drawing.Size(121, 20);
            this.comboBox_Number.TabIndex = 0;
            this.comboBox_Number.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // txtSetInfo
            // 
            this.txtSetInfo.Location = new System.Drawing.Point(153, 72);
            this.txtSetInfo.Name = "txtSetInfo";
            this.txtSetInfo.Size = new System.Drawing.Size(75, 23);
            this.txtSetInfo.TabIndex = 2;
            this.txtSetInfo.Text = "정보 설정";
            this.txtSetInfo.UseVisualStyleBackColor = true;
            this.txtSetInfo.Click += new System.EventHandler(this.txtSetInfo_Click);
            // 
            // txtStateList
            // 
            this.txtStateList.AutoSize = true;
            this.txtStateList.Font = new System.Drawing.Font("굴림", 13F);
            this.txtStateList.Location = new System.Drawing.Point(12, 112);
            this.txtStateList.Name = "txtStateList";
            this.txtStateList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtStateList.Size = new System.Drawing.Size(48, 18);
            this.txtStateList.TabIndex = 1;
            this.txtStateList.Text = "state";
            // 
            // btnSaveAsFile
            // 
            this.btnSaveAsFile.Location = new System.Drawing.Point(698, 12);
            this.btnSaveAsFile.Name = "btnSaveAsFile";
            this.btnSaveAsFile.Size = new System.Drawing.Size(90, 23);
            this.btnSaveAsFile.TabIndex = 3;
            this.btnSaveAsFile.Text = "파일로 저장";
            this.btnSaveAsFile.UseVisualStyleBackColor = true;
            this.btnSaveAsFile.Click += new System.EventHandler(this.btnSaveAsFile_Click);
            // 
            // txtSaveLocal
            // 
            this.txtSaveLocal.Location = new System.Drawing.Point(698, 41);
            this.txtSaveLocal.Name = "txtSaveLocal";
            this.txtSaveLocal.Size = new System.Drawing.Size(90, 23);
            this.txtSaveLocal.TabIndex = 4;
            this.txtSaveLocal.Text = "로컬 저장";
            this.txtSaveLocal.UseVisualStyleBackColor = true;
            this.txtSaveLocal.Click += new System.EventHandler(this.txtSaveLocal_Click);
            // 
            // NumberColorSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 481);
            this.Controls.Add(this.txtSaveLocal);
            this.Controls.Add(this.btnSaveAsFile);
            this.Controls.Add(this.txtSetInfo);
            this.Controls.Add(this.txtStateList);
            this.Controls.Add(this.comboBox_Number);
            this.Name = "NumberColorSetForm";
            this.Text = "NumberColorSetForm";
            this.Load += new System.EventHandler(this.NumberColorSetForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_Number;
        private System.Windows.Forms.Button txtSetInfo;
        private System.Windows.Forms.Label txtStateList;
        private System.Windows.Forms.Button btnSaveAsFile;
        private System.Windows.Forms.Button txtSaveLocal;
    }
}
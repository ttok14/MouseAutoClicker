namespace MouseClicker
{
    partial class ColorDataEditorForm
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
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtSave = new System.Windows.Forms.Button();
            this.btnOpenCacheFolder = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtLoadedFilePath = new System.Windows.Forms.Label();
            this.btnAddData = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "로드하기";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtSave
            // 
            this.txtSave.Location = new System.Drawing.Point(12, 41);
            this.txtSave.Name = "txtSave";
            this.txtSave.Size = new System.Drawing.Size(75, 23);
            this.txtSave.TabIndex = 1;
            this.txtSave.Text = "저장하기";
            this.txtSave.UseVisualStyleBackColor = true;
            this.txtSave.Click += new System.EventHandler(this.txtSave_Click);
            // 
            // btnOpenCacheFolder
            // 
            this.btnOpenCacheFolder.Location = new System.Drawing.Point(234, 12);
            this.btnOpenCacheFolder.Name = "btnOpenCacheFolder";
            this.btnOpenCacheFolder.Size = new System.Drawing.Size(75, 23);
            this.btnOpenCacheFolder.TabIndex = 2;
            this.btnOpenCacheFolder.Text = "폴더열기";
            this.btnOpenCacheFolder.UseVisualStyleBackColor = true;
            this.btnOpenCacheFolder.Click += new System.EventHandler(this.btnOpenCacheFolder_Click);
            // 
            // button1
            // 
            this.button1.CausesValidation = false;
            this.button1.Location = new System.Drawing.Point(113, 374);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "비교 테스트";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtLoadedFilePath
            // 
            this.txtLoadedFilePath.Location = new System.Drawing.Point(10, 109);
            this.txtLoadedFilePath.Name = "txtLoadedFilePath";
            this.txtLoadedFilePath.Size = new System.Drawing.Size(297, 115);
            this.txtLoadedFilePath.TabIndex = 4;
            this.txtLoadedFilePath.Text = "-";
            // 
            // btnAddData
            // 
            this.btnAddData.Location = new System.Drawing.Point(93, 12);
            this.btnAddData.Name = "btnAddData";
            this.btnAddData.Size = new System.Drawing.Size(75, 23);
            this.btnAddData.TabIndex = 5;
            this.btnAddData.Text = "추가하기";
            this.btnAddData.UseVisualStyleBackColor = true;
            this.btnAddData.Click += new System.EventHandler(this.btnAddData_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(12, 70);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 6;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_click);
            // 
            // ColorDataEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 450);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnAddData);
            this.Controls.Add(this.txtLoadedFilePath);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnOpenCacheFolder);
            this.Controls.Add(this.txtSave);
            this.Controls.Add(this.btnLoad);
            this.Name = "ColorDataEditorForm";
            this.Text = "ColorDataEditorForm";
            this.Load += new System.EventHandler(this.ColorDataEditorForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button txtSave;
        private System.Windows.Forms.Button btnOpenCacheFolder;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label txtLoadedFilePath;
        private System.Windows.Forms.Button btnAddData;
        private System.Windows.Forms.Button btnNew;
    }
}
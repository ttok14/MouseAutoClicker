namespace MouseClicker
{
    partial class ActionEditor
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
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnOpenCacheFolder = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.listBox_data = new System.Windows.Forms.ListBox();
            this.btnChangeKey = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(78, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Action 편집기";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(21, 250);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 17;
            this.btnRemove.Text = "제거하기";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click_1);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(21, 279);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click_1);
            // 
            // btnOpenCacheFolder
            // 
            this.btnOpenCacheFolder.Location = new System.Drawing.Point(243, 76);
            this.btnOpenCacheFolder.Name = "btnOpenCacheFolder";
            this.btnOpenCacheFolder.Size = new System.Drawing.Size(75, 23);
            this.btnOpenCacheFolder.TabIndex = 11;
            this.btnOpenCacheFolder.Text = "폴더열기";
            this.btnOpenCacheFolder.UseVisualStyleBackColor = true;
            this.btnOpenCacheFolder.Click += new System.EventHandler(this.btnOpenCacheFolder_Click_1);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(21, 337);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "저장하기";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(123, 375);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 18;
            this.btnSelect.Text = "선택";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // listBox_data
            // 
            this.listBox_data.FormattingEnabled = true;
            this.listBox_data.ItemHeight = 12;
            this.listBox_data.Location = new System.Drawing.Point(21, 76);
            this.listBox_data.Name = "listBox_data";
            this.listBox_data.Size = new System.Drawing.Size(167, 136);
            this.listBox_data.TabIndex = 15;
            this.listBox_data.SelectedIndexChanged += new System.EventHandler(this.listBox_data_SelectedIndexChanged_2);
            // 
            // btnChangeKey
            // 
            this.btnChangeKey.Location = new System.Drawing.Point(21, 221);
            this.btnChangeKey.Name = "btnChangeKey";
            this.btnChangeKey.Size = new System.Drawing.Size(75, 23);
            this.btnChangeKey.TabIndex = 21;
            this.btnChangeKey.Text = "Key 변경";
            this.btnChangeKey.UseVisualStyleBackColor = true;
            this.btnChangeKey.Click += new System.EventHandler(this.btnChangeKey_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(21, 308);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 22;
            this.btnAdd.Text = "추가하기";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ActionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 410);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnChangeKey);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.listBox_data);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnOpenCacheFolder);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Name = "ActionEditor";
            this.Text = "ActionEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnOpenCacheFolder;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.ListBox listBox_data;
        private System.Windows.Forms.Button btnChangeKey;
        private System.Windows.Forms.Button btnAdd;
    }
}
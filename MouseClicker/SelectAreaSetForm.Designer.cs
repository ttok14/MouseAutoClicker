using System;

namespace MouseClicker
{
    partial class SelectAreaSetForm
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
            this.btnComplete = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtAreaCount = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox_sourceColorData = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBox_similarityPassThreshold = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnComplete
            // 
            this.btnComplete.Location = new System.Drawing.Point(319, 235);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(75, 23);
            this.btnComplete.TabIndex = 0;
            this.btnComplete.Text = "완료";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(190, 235);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "취소";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtAreaCount
            // 
            this.txtAreaCount.AutoSize = true;
            this.txtAreaCount.Font = new System.Drawing.Font("굴림", 11F);
            this.txtAreaCount.Location = new System.Drawing.Point(325, 87);
            this.txtAreaCount.Name = "txtAreaCount";
            this.txtAreaCount.Size = new System.Drawing.Size(37, 15);
            this.txtAreaCount.TabIndex = 6;
            this.txtAreaCount.Text = "개수";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(231, 146);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "클리어";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click_1);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(231, 119);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "추가하기";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 11F);
            this.label1.Location = new System.Drawing.Point(187, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "설정된 영역 개수 :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(172, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "매칭용 타겟 영역 설정";
            // 
            // listBox_sourceColorData
            // 
            this.listBox_sourceColorData.FormattingEnabled = true;
            this.listBox_sourceColorData.ItemHeight = 12;
            this.listBox_sourceColorData.Location = new System.Drawing.Point(24, 119);
            this.listBox_sourceColorData.Name = "listBox_sourceColorData";
            this.listBox_sourceColorData.Size = new System.Drawing.Size(120, 88);
            this.listBox_sourceColorData.TabIndex = 17;
            this.listBox_sourceColorData.SelectedIndexChanged += new System.EventHandler(this.listBox_sourceColorData_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 11F);
            this.label2.Location = new System.Drawing.Point(22, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "기준 색상 데이터";
            // 
            // txtBox_similarityPassThreshold
            // 
            this.txtBox_similarityPassThreshold.Location = new System.Drawing.Point(419, 130);
            this.txtBox_similarityPassThreshold.Name = "txtBox_similarityPassThreshold";
            this.txtBox_similarityPassThreshold.Size = new System.Drawing.Size(100, 21);
            this.txtBox_similarityPassThreshold.TabIndex = 19;
            this.txtBox_similarityPassThreshold.TextChanged += new System.EventHandler(this.txtBox_similarityPassThreshold_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 11F);
            this.label4.Location = new System.Drawing.Point(386, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 30);
            this.label4.TabIndex = 20;
            this.label4.Text = "유사성 평가 통과 기준값\r\n (0~1 소수)";
            // 
            // SelectAreaSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 269);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBox_similarityPassThreshold);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox_sourceColorData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtAreaCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnComplete);
            this.Name = "SelectAreaSetForm";
            this.Text = "SelectAreaSetForm";
            this.Load += new System.EventHandler(this.SelectTargetScreenColorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label txtAreaCount;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox_sourceColorData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBox_similarityPassThreshold;
        private System.Windows.Forms.Label label4;
    }
}
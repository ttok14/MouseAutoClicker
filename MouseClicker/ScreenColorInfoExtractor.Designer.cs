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
            this.txtColorKey = new System.Windows.Forms.Label();
            this.txtBackgroundKey = new System.Windows.Forms.Label();
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
            this.SuspendLayout();
            // 
            // txtColorKey
            // 
            this.txtColorKey.Font = new System.Drawing.Font("굴림", 12F);
            this.txtColorKey.Location = new System.Drawing.Point(1, 145);
            this.txtColorKey.Name = "txtColorKey";
            this.txtColorKey.Size = new System.Drawing.Size(340, 29);
            this.txtColorKey.TabIndex = 0;
            this.txtColorKey.Text = "설정해주세요.";
            this.txtColorKey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBackgroundKey
            // 
            this.txtBackgroundKey.AutoSize = true;
            this.txtBackgroundKey.Font = new System.Drawing.Font("굴림", 12F);
            this.txtBackgroundKey.Location = new System.Drawing.Point(99, 240);
            this.txtBackgroundKey.Name = "txtBackgroundKey";
            this.txtBackgroundKey.Size = new System.Drawing.Size(109, 16);
            this.txtBackgroundKey.TabIndex = 1;
            this.txtBackgroundKey.Text = "설정해주세요.";
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
            this.btnSetTargetColorKey.Text = "설정";
            this.btnSetTargetColorKey.UseVisualStyleBackColor = true;
            this.btnSetTargetColorKey.Click += new System.EventHandler(this.btnSetTargetColorKey_Click);
            // 
            // btnSetBackgroundColorKey
            // 
            this.btnSetBackgroundColorKey.Location = new System.Drawing.Point(120, 214);
            this.btnSetBackgroundColorKey.Name = "btnSetBackgroundColorKey";
            this.btnSetBackgroundColorKey.Size = new System.Drawing.Size(75, 23);
            this.btnSetBackgroundColorKey.TabIndex = 6;
            this.btnSetBackgroundColorKey.Text = "설정";
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
            this.btnComplete.Location = new System.Drawing.Point(178, 374);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(115, 29);
            this.btnComplete.TabIndex = 10;
            this.btnComplete.Text = "완료";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.OnClickComplete);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(25, 374);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 29);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ScreenColorInfoExtractor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 429);
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
            this.Controls.Add(this.txtBackgroundKey);
            this.Controls.Add(this.txtColorKey);
            this.Name = "ScreenColorInfoExtractor";
            this.Text = "영역 색상 설정";
            this.Load += new System.EventHandler(this.ScreenColorInfoExtractor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtColorKey;
        private System.Windows.Forms.Label txtBackgroundKey;
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
    }
}
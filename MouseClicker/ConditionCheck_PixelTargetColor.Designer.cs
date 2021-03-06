﻿namespace MouseClicker
{
    partial class ConditionCheck_PixelTargetColor
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
            this.txtCursorColor_conditionForm = new System.Windows.Forms.Label();
            this.textBox_colorCheck_posX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_colorCheck_posY = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_colorCheck_rgbR = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_colorCheck_rgbG = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_colorCheck_rgbB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCursorPos_conditionForm = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSetFirstPos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(134, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "픽셀 색상 체크";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 13F);
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "현재 커서 색상";
            // 
            // txtCursorColor_conditionForm
            // 
            this.txtCursorColor_conditionForm.AutoSize = true;
            this.txtCursorColor_conditionForm.Font = new System.Drawing.Font("굴림", 12F);
            this.txtCursorColor_conditionForm.Location = new System.Drawing.Point(170, 57);
            this.txtCursorColor_conditionForm.Name = "txtCursorColor_conditionForm";
            this.txtCursorColor_conditionForm.Size = new System.Drawing.Size(63, 16);
            this.txtCursorColor_conditionForm.TabIndex = 2;
            this.txtCursorColor_conditionForm.Text = "R=G=B=";
            this.txtCursorColor_conditionForm.Click += new System.EventHandler(this.txtCursorColor_conditionForm_Click);
            // 
            // textBox_colorCheck_posX
            // 
            this.textBox_colorCheck_posX.Location = new System.Drawing.Point(40, 178);
            this.textBox_colorCheck_posX.Name = "textBox_colorCheck_posX";
            this.textBox_colorCheck_posX.Size = new System.Drawing.Size(100, 21);
            this.textBox_colorCheck_posX.TabIndex = 4;
            this.textBox_colorCheck_posX.TextChanged += new System.EventHandler(this.textBox_colorCheck_posX_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(181, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Y";
            // 
            // textBox_colorCheck_posY
            // 
            this.textBox_colorCheck_posY.Location = new System.Drawing.Point(155, 178);
            this.textBox_colorCheck_posY.Name = "textBox_colorCheck_posY";
            this.textBox_colorCheck_posY.Size = new System.Drawing.Size(100, 21);
            this.textBox_colorCheck_posY.TabIndex = 6;
            this.textBox_colorCheck_posY.TextChanged += new System.EventHandler(this.textBox_colorCheck_posY_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "R";
            // 
            // textBox_colorCheck_rgbR
            // 
            this.textBox_colorCheck_rgbR.Location = new System.Drawing.Point(40, 220);
            this.textBox_colorCheck_rgbR.Name = "textBox_colorCheck_rgbR";
            this.textBox_colorCheck_rgbR.Size = new System.Drawing.Size(100, 21);
            this.textBox_colorCheck_rgbR.TabIndex = 8;
            this.textBox_colorCheck_rgbR.TextChanged += new System.EventHandler(this.textBox_colorCheck_rgbR_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(181, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "G";
            // 
            // textBox_colorCheck_rgbG
            // 
            this.textBox_colorCheck_rgbG.Location = new System.Drawing.Point(155, 220);
            this.textBox_colorCheck_rgbG.Name = "textBox_colorCheck_rgbG";
            this.textBox_colorCheck_rgbG.Size = new System.Drawing.Size(100, 21);
            this.textBox_colorCheck_rgbG.TabIndex = 10;
            this.textBox_colorCheck_rgbG.TextChanged += new System.EventHandler(this.textBox_colorCheck_rgbG_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(287, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "B";
            // 
            // textBox_colorCheck_rgbB
            // 
            this.textBox_colorCheck_rgbB.Location = new System.Drawing.Point(261, 220);
            this.textBox_colorCheck_rgbB.Name = "textBox_colorCheck_rgbB";
            this.textBox_colorCheck_rgbB.Size = new System.Drawing.Size(100, 21);
            this.textBox_colorCheck_rgbB.TabIndex = 12;
            this.textBox_colorCheck_rgbB.TextChanged += new System.EventHandler(this.textBox_colorCheck_rgbB_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 13F);
            this.label8.Location = new System.Drawing.Point(12, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 18);
            this.label8.TabIndex = 14;
            this.label8.Text = "현재 커서 위치";
            // 
            // txtCursorPos_conditionForm
            // 
            this.txtCursorPos_conditionForm.AutoSize = true;
            this.txtCursorPos_conditionForm.Font = new System.Drawing.Font("굴림", 12F);
            this.txtCursorPos_conditionForm.Location = new System.Drawing.Point(170, 87);
            this.txtCursorPos_conditionForm.Name = "txtCursorPos_conditionForm";
            this.txtCursorPos_conditionForm.Size = new System.Drawing.Size(45, 16);
            this.txtCursorPos_conditionForm.TabIndex = 15;
            this.txtCursorPos_conditionForm.Text = "X=Y=";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(216, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 28);
            this.button1.TabIndex = 16;
            this.button1.Text = "적용";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(97, 265);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 28);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSetFirstPos
            // 
            this.btnSetFirstPos.Location = new System.Drawing.Point(40, 123);
            this.btnSetFirstPos.Name = "btnSetFirstPos";
            this.btnSetFirstPos.Size = new System.Drawing.Size(109, 28);
            this.btnSetFirstPos.TabIndex = 18;
            this.btnSetFirstPos.Text = "최초 위치 설정";
            this.btnSetFirstPos.UseVisualStyleBackColor = true;
            this.btnSetFirstPos.Click += new System.EventHandler(this.btnSetFirstPos_Click);
            // 
            // ConditionCheck_PixelTargetColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 311);
            this.Controls.Add(this.btnSetFirstPos);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtCursorPos_conditionForm);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_colorCheck_rgbB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_colorCheck_rgbG);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_colorCheck_rgbR);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_colorCheck_posY);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_colorCheck_posX);
            this.Controls.Add(this.txtCursorColor_conditionForm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ConditionCheck_PixelTargetColor";
            this.Text = "ConditionSelectionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtCursorColor_conditionForm;
        private System.Windows.Forms.TextBox textBox_colorCheck_posX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_colorCheck_posY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_colorCheck_rgbR;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_colorCheck_rgbG;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_colorCheck_rgbB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label txtCursorPos_conditionForm;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSetFirstPos;
    }
}
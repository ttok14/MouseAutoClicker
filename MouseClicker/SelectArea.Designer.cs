﻿namespace MouseClicker
{
    partial class SelectArea
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
            this.txtRect = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtRect
            // 
            this.txtRect.AutoSize = true;
            this.txtRect.Font = new System.Drawing.Font("굴림", 15F);
            this.txtRect.Location = new System.Drawing.Point(367, 171);
            this.txtRect.Name = "txtRect";
            this.txtRect.Size = new System.Drawing.Size(42, 20);
            this.txtRect.TabIndex = 0;
            this.txtRect.Text = "rect";
            // 
            // SelectArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtRect);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Name = "SelectArea";
            this.Text = "SelectArea";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtRect;
    }
}
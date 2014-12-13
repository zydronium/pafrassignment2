namespace PatternBase
{
    partial class FrmEditor
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
            this.lblDevider = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDevider
            // 
            this.lblDevider.AutoSize = true;
            this.lblDevider.Location = new System.Drawing.Point(487, 13);
            this.lblDevider.Name = "lblDevider";
            this.lblDevider.Size = new System.Drawing.Size(35, 13);
            this.lblDevider.TabIndex = 0;
            this.lblDevider.Text = "label1";
            // 
            // FrmEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 761);
            this.Controls.Add(this.lblDevider);
            this.Name = "FrmEditor";
            this.Text = "Editor - PatternBase";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDevider;
    }
}
namespace PatternBase
{
    partial class FrmStart
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
            this.btnNewDatabase = new System.Windows.Forms.Button();
            this.btnSelectDatabase = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to PatternBase.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Please select a database or create a new one.";
            // 
            // btnNewDatabase
            // 
            this.btnNewDatabase.Location = new System.Drawing.Point(19, 101);
            this.btnNewDatabase.Name = "btnNewDatabase";
            this.btnNewDatabase.Size = new System.Drawing.Size(93, 23);
            this.btnNewDatabase.TabIndex = 2;
            this.btnNewDatabase.Text = "New database";
            this.btnNewDatabase.UseVisualStyleBackColor = true;
            this.btnNewDatabase.Click += new System.EventHandler(this.btnNewDatabase_Click);
            // 
            // btnSelectDatabase
            // 
            this.btnSelectDatabase.Location = new System.Drawing.Point(119, 100);
            this.btnSelectDatabase.Name = "btnSelectDatabase";
            this.btnSelectDatabase.Size = new System.Drawing.Size(95, 23);
            this.btnSelectDatabase.TabIndex = 3;
            this.btnSelectDatabase.Text = "Select database";
            this.btnSelectDatabase.UseVisualStyleBackColor = true;
            this.btnSelectDatabase.Click += new System.EventHandler(this.btnSelectDatabase_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 233);
            this.Controls.Add(this.btnSelectDatabase);
            this.Controls.Add(this.btnNewDatabase);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "PatternBase";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNewDatabase;
        private System.Windows.Forms.Button btnSelectDatabase;
    }
}


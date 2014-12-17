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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveToFile = new System.Windows.Forms.Button();
            this.bbtnNewPurpose = new System.Windows.Forms.Button();
            this.btnNewScope = new System.Windows.Forms.Button();
            this.btnNewPattern = new System.Windows.Forms.Button();
            this.labelPurpose = new System.Windows.Forms.Label();
            this.lbPurpose = new System.Windows.Forms.ListBox();
            this.lbScope = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lbProblems = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lbEditPattern = new System.Windows.Forms.ListBox();
            this.Pattern = new System.Windows.Forms.Label();
            this.lbEditScope = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbEditPurpose = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDevider
            // 
            this.lblDevider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDevider.Location = new System.Drawing.Point(487, 13);
            this.lblDevider.Name = "lblDevider";
            this.lblDevider.Size = new System.Drawing.Size(2, 550);
            this.lblDevider.TabIndex = 0;
            this.lblDevider.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(496, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Edit";
            // 
            // btnSaveToFile
            // 
            this.btnSaveToFile.Location = new System.Drawing.Point(13, 543);
            this.btnSaveToFile.Name = "btnSaveToFile";
            this.btnSaveToFile.Size = new System.Drawing.Size(75, 23);
            this.btnSaveToFile.TabIndex = 16;
            this.btnSaveToFile.Text = "Save To File";
            this.btnSaveToFile.UseVisualStyleBackColor = true;
            this.btnSaveToFile.Click += new System.EventHandler(this.btnSaveToFile_Click);
            // 
            // bbtnNewPurpose
            // 
            this.bbtnNewPurpose.Location = new System.Drawing.Point(94, 543);
            this.bbtnNewPurpose.Name = "bbtnNewPurpose";
            this.bbtnNewPurpose.Size = new System.Drawing.Size(85, 23);
            this.bbtnNewPurpose.TabIndex = 17;
            this.bbtnNewPurpose.Text = "New Purpose";
            this.bbtnNewPurpose.UseVisualStyleBackColor = true;
            this.bbtnNewPurpose.Click += new System.EventHandler(this.bbtnNewPurpose_Click);
            // 
            // btnNewScope
            // 
            this.btnNewScope.Location = new System.Drawing.Point(185, 543);
            this.btnNewScope.Name = "btnNewScope";
            this.btnNewScope.Size = new System.Drawing.Size(75, 23);
            this.btnNewScope.TabIndex = 18;
            this.btnNewScope.Text = "New Scope";
            this.btnNewScope.UseVisualStyleBackColor = true;
            this.btnNewScope.Click += new System.EventHandler(this.btnNewScope_Click);
            // 
            // btnNewPattern
            // 
            this.btnNewPattern.Location = new System.Drawing.Point(266, 543);
            this.btnNewPattern.Name = "btnNewPattern";
            this.btnNewPattern.Size = new System.Drawing.Size(75, 23);
            this.btnNewPattern.TabIndex = 19;
            this.btnNewPattern.Text = "New Pattern";
            this.btnNewPattern.UseVisualStyleBackColor = true;
            this.btnNewPattern.Click += new System.EventHandler(this.btnNewPattern_Click);
            // 
            // labelPurpose
            // 
            this.labelPurpose.AutoSize = true;
            this.labelPurpose.Location = new System.Drawing.Point(13, 29);
            this.labelPurpose.Name = "labelPurpose";
            this.labelPurpose.Size = new System.Drawing.Size(46, 13);
            this.labelPurpose.TabIndex = 22;
            this.labelPurpose.Text = "Purpose";
            // 
            // lbPurpose
            // 
            this.lbPurpose.FormattingEnabled = true;
            this.lbPurpose.Location = new System.Drawing.Point(16, 46);
            this.lbPurpose.Name = "lbPurpose";
            this.lbPurpose.Size = new System.Drawing.Size(205, 173);
            this.lbPurpose.TabIndex = 25;
            this.lbPurpose.SelectedIndexChanged += new System.EventHandler(this.lbPurpose_SelectedIndexChanged);
            // 
            // lbScope
            // 
            this.lbScope.FormattingEnabled = true;
            this.lbScope.Location = new System.Drawing.Point(227, 46);
            this.lbScope.Name = "lbScope";
            this.lbScope.Size = new System.Drawing.Size(205, 173);
            this.lbScope.TabIndex = 27;
            this.lbScope.SelectedIndexChanged += new System.EventHandler(this.lbScope_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(224, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Scope";
            // 
            // lbProblems
            // 
            this.lbProblems.FormattingEnabled = true;
            this.lbProblems.Location = new System.Drawing.Point(16, 244);
            this.lbProblems.Name = "lbProblems";
            this.lbProblems.Size = new System.Drawing.Size(414, 199);
            this.lbProblems.TabIndex = 28;
            this.lbProblems.SelectedIndexChanged += new System.EventHandler(this.lbProblems_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 228);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Problem";
            // 
            // lbEditPattern
            // 
            this.lbEditPattern.FormattingEnabled = true;
            this.lbEditPattern.Location = new System.Drawing.Point(782, 46);
            this.lbEditPattern.Name = "lbEditPattern";
            this.lbEditPattern.Size = new System.Drawing.Size(131, 173);
            this.lbEditPattern.TabIndex = 38;
            this.lbEditPattern.SelectedIndexChanged += new System.EventHandler(this.lbEditPattern_SelectedIndexChanged);
            // 
            // Pattern
            // 
            this.Pattern.AutoSize = true;
            this.Pattern.Location = new System.Drawing.Point(779, 29);
            this.Pattern.Name = "Pattern";
            this.Pattern.Size = new System.Drawing.Size(41, 13);
            this.Pattern.TabIndex = 37;
            this.Pattern.Text = "Pattern";
            // 
            // lbEditScope
            // 
            this.lbEditScope.FormattingEnabled = true;
            this.lbEditScope.Location = new System.Drawing.Point(644, 46);
            this.lbEditScope.Name = "lbEditScope";
            this.lbEditScope.Size = new System.Drawing.Size(131, 173);
            this.lbEditScope.TabIndex = 36;
            this.lbEditScope.SelectedIndexChanged += new System.EventHandler(this.lbEditScope_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(641, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Scope";
            // 
            // lbEditPurpose
            // 
            this.lbEditPurpose.FormattingEnabled = true;
            this.lbEditPurpose.Location = new System.Drawing.Point(499, 46);
            this.lbEditPurpose.Name = "lbEditPurpose";
            this.lbEditPurpose.Size = new System.Drawing.Size(139, 173);
            this.lbEditPurpose.TabIndex = 34;
            this.lbEditPurpose.SelectedIndexChanged += new System.EventHandler(this.lbEditPurpose_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(496, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Purpose";
            // 
            // FrmEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 576);
            this.Controls.Add(this.lbEditPattern);
            this.Controls.Add(this.Pattern);
            this.Controls.Add(this.lbEditScope);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbEditPurpose);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbProblems);
            this.Controls.Add(this.lbScope);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbPurpose);
            this.Controls.Add(this.labelPurpose);
            this.Controls.Add(this.btnNewPattern);
            this.Controls.Add(this.btnNewScope);
            this.Controls.Add(this.bbtnNewPurpose);
            this.Controls.Add(this.btnSaveToFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDevider);
            this.Name = "FrmEditor";
            this.Text = "Editor - PatternBase";
            this.Load += new System.EventHandler(this.FrmEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDevider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveToFile;
        private System.Windows.Forms.Button bbtnNewPurpose;
        private System.Windows.Forms.Button btnNewScope;
        private System.Windows.Forms.Button btnNewPattern;
        private System.Windows.Forms.Label labelPurpose;
        private System.Windows.Forms.ListBox lbPurpose;
        private System.Windows.Forms.ListBox lbScope;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox lbProblems;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox lbEditPattern;
        private System.Windows.Forms.Label Pattern;
        private System.Windows.Forms.ListBox lbEditScope;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbEditPurpose;
        private System.Windows.Forms.Label label4;
    }
}
namespace PrimerProForms
{
    partial class FormMinPairs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMinPairs));
            this.labGrf1 = new System.Windows.Forms.Label();
            this.labGrf2 = new System.Windows.Forms.Label();
            this.tbGrf1 = new System.Windows.Forms.TextBox();
            this.tbGrf2 = new System.Windows.Forms.TextBox();
            this.labTitle = new System.Windows.Forms.Label();
            this.btnSO = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkRoots = new System.Windows.Forms.CheckBox();
            this.chkTone = new System.Windows.Forms.CheckBox();
            this.chkHarmony = new System.Windows.Forms.CheckBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labGrf1
            // 
            this.labGrf1.AutoSize = true;
            this.labGrf1.Location = new System.Drawing.Point(24, 67);
            this.labGrf1.Name = "labGrf1";
            this.labGrf1.Size = new System.Drawing.Size(92, 15);
            this.labGrf1.TabIndex = 1;
            this.labGrf1.Text = "First Grapheme";
            // 
            // labGrf2
            // 
            this.labGrf2.AutoSize = true;
            this.labGrf2.Location = new System.Drawing.Point(24, 113);
            this.labGrf2.Name = "labGrf2";
            this.labGrf2.Size = new System.Drawing.Size(111, 15);
            this.labGrf2.TabIndex = 3;
            this.labGrf2.Text = "Second Grapheme";
            // 
            // tbGrf1
            // 
            this.tbGrf1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGrf1.Location = new System.Drawing.Point(169, 67);
            this.tbGrf1.Name = "tbGrf1";
            this.tbGrf1.Size = new System.Drawing.Size(96, 21);
            this.tbGrf1.TabIndex = 2;
            // 
            // tbGrf2
            // 
            this.tbGrf2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGrf2.Location = new System.Drawing.Point(169, 113);
            this.tbGrf2.Name = "tbGrf2";
            this.tbGrf2.Size = new System.Drawing.Size(96, 21);
            this.tbGrf2.TabIndex = 4;
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Location = new System.Drawing.Point(24, 24);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(325, 15);
            this.labTitle.TabIndex = 0;
            this.labTitle.Text = "Enter the two graphemes for which you want minimal pairs";
            // 
            // btnSO
            // 
            this.btnSO.Location = new System.Drawing.Point(27, 221);
            this.btnSO.Name = "btnSO";
            this.btnSO.Size = new System.Drawing.Size(200, 32);
            this.btnSO.TabIndex = 9;
            this.btnSO.Text = "&Search Options";
            this.btnSO.UseVisualStyleBackColor = true;
            this.btnSO.Click += new System.EventHandler(this.btnSO_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(278, 221);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(408, 221);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkRoots
            // 
            this.chkRoots.AutoSize = true;
            this.chkRoots.Location = new System.Drawing.Point(406, 69);
            this.chkRoots.Name = "chkRoots";
            this.chkRoots.Size = new System.Drawing.Size(83, 19);
            this.chkRoots.TabIndex = 5;
            this.chkRoots.Text = "&Roots only";
            this.chkRoots.UseVisualStyleBackColor = true;
            // 
            // chkTone
            // 
            this.chkTone.AutoSize = true;
            this.chkTone.Location = new System.Drawing.Point(404, 115);
            this.chkTone.Name = "chkTone";
            this.chkTone.Size = new System.Drawing.Size(88, 19);
            this.chkTone.TabIndex = 6;
            this.chkTone.Text = "&Ignore tone";
            this.chkTone.UseVisualStyleBackColor = true;
            // 
            // chkHarmony
            // 
            this.chkHarmony.AutoSize = true;
            this.chkHarmony.Location = new System.Drawing.Point(313, 160);
            this.chkHarmony.Name = "chkHarmony";
            this.chkHarmony.Size = new System.Drawing.Size(160, 19);
            this.chkHarmony.TabIndex = 8;
            this.chkHarmony.Text = "&Allow for vowel harmony ";
            this.chkHarmony.UseVisualStyleBackColor = true;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(27, 160);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(168, 19);
            this.chkAll.TabIndex = 7;
            this.chkAll.Text = "All pairs for first grapheme";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.Visible = false;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // FormMinPairs
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(549, 296);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.chkHarmony);
            this.Controls.Add(this.chkTone);
            this.Controls.Add(this.chkRoots);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnSO);
            this.Controls.Add(this.labTitle);
            this.Controls.Add(this.tbGrf2);
            this.Controls.Add(this.tbGrf1);
            this.Controls.Add(this.labGrf2);
            this.Controls.Add(this.labGrf1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMinPairs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Minimal Pairs Search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labGrf1;
        private System.Windows.Forms.Label labGrf2;
        private System.Windows.Forms.TextBox tbGrf1;
        private System.Windows.Forms.TextBox tbGrf2;
        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.Button btnSO;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkRoots;
        private System.Windows.Forms.CheckBox chkTone;
        private System.Windows.Forms.CheckBox chkHarmony;
        private System.Windows.Forms.CheckBox chkAll;
    }
}
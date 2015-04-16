namespace PrimerProForms
{
    partial class FormTonePairs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTonePairs));
            this.labGrf = new System.Windows.Forms.Label();
            this.tbGrf = new System.Windows.Forms.TextBox();
            this.labTitle = new System.Windows.Forms.Label();
            this.btnSO = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkHarmony = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labGrf
            // 
            this.labGrf.AutoSize = true;
            this.labGrf.Location = new System.Drawing.Point(24, 67);
            this.labGrf.Name = "labGrf";
            this.labGrf.Size = new System.Drawing.Size(78, 18);
            this.labGrf.TabIndex = 1;
            this.labGrf.Text = "Grapheme";
            // 
            // tbGrf
            // 
            this.tbGrf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGrf.Location = new System.Drawing.Point(131, 67);
            this.tbGrf.Name = "tbGrf";
            this.tbGrf.Size = new System.Drawing.Size(96, 24);
            this.tbGrf.TabIndex = 2;
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Location = new System.Drawing.Point(24, 24);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(388, 18);
            this.labTitle.TabIndex = 0;
            this.labTitle.Text = "Enter the grapheme for which you want syllograph minimal pairs";
            // 
            // btnSO
            // 
            this.btnSO.Location = new System.Drawing.Point(27, 173);
            this.btnSO.Name = "btnSO";
            this.btnSO.Size = new System.Drawing.Size(200, 32);
            this.btnSO.TabIndex = 4;
            this.btnSO.Text = "&Search Options";
            this.btnSO.UseVisualStyleBackColor = true;
            this.btnSO.Click += new System.EventHandler(this.btnSO_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(312, 120);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(312, 173);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkHarmony
            // 
            this.chkHarmony.AutoSize = true;
            this.chkHarmony.Location = new System.Drawing.Point(32, 120);
            this.chkHarmony.Name = "chkHarmony";
            this.chkHarmony.Size = new System.Drawing.Size(195, 22);
            this.chkHarmony.TabIndex = 3;
            this.chkHarmony.Text = "&Allow for vowel harmony ";
            this.chkHarmony.UseVisualStyleBackColor = true;
            // 
            // FormTonePairs
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(483, 233);
            this.Controls.Add(this.chkHarmony);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnSO);
            this.Controls.Add(this.labTitle);
            this.Controls.Add(this.tbGrf);
            this.Controls.Add(this.labGrf);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTonePairs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tone Minimal Pairs Search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labGrf;
        private System.Windows.Forms.TextBox tbGrf;
        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.Button btnSO;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkHarmony;
    }
}
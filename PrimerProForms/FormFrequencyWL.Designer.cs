namespace PrimerProForms
{
    partial class FormFrequencyWL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFrequencyWL));
            this.chkIgnoreSightWords = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnSO = new System.Windows.Forms.Button();
            this.chkDisplayPct = new System.Windows.Forms.CheckBox();
            this.chkIgnoreTone = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkIgnoreSightWords
            // 
            this.chkIgnoreSightWords.AutoSize = true;
            this.chkIgnoreSightWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIgnoreSightWords.Location = new System.Drawing.Point(24, 24);
            this.chkIgnoreSightWords.Name = "chkIgnoreSightWords";
            this.chkIgnoreSightWords.Size = new System.Drawing.Size(130, 19);
            this.chkIgnoreSightWords.TabIndex = 0;
            this.chkIgnoreSightWords.Text = "&Ignore Sight Words";
            this.chkIgnoreSightWords.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(280, 144);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(280, 96);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnSO
            // 
            this.btnSO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSO.Location = new System.Drawing.Point(24, 144);
            this.btnSO.Name = "btnSO";
            this.btnSO.Size = new System.Drawing.Size(200, 32);
            this.btnSO.TabIndex = 3;
            this.btnSO.Text = "&Search Options";
            this.btnSO.Click += new System.EventHandler(this.btnSO_Click);
            // 
            // chkDisplayPct
            // 
            this.chkDisplayPct.AutoSize = true;
            this.chkDisplayPct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDisplayPct.Location = new System.Drawing.Point(24, 96);
            this.chkDisplayPct.Name = "chkDisplayPct";
            this.chkDisplayPct.Size = new System.Drawing.Size(138, 19);
            this.chkDisplayPct.TabIndex = 2;
            this.chkDisplayPct.Text = "Display Percentages";
            this.chkDisplayPct.UseVisualStyleBackColor = true;
            // 
            // chkIgnoreTone
            // 
            this.chkIgnoreTone.AutoSize = true;
            this.chkIgnoreTone.Location = new System.Drawing.Point(24, 60);
            this.chkIgnoreTone.Name = "chkIgnoreTone";
            this.chkIgnoreTone.Size = new System.Drawing.Size(92, 19);
            this.chkIgnoreTone.TabIndex = 1;
            this.chkIgnoreTone.Text = "Ignore Tone";
            this.chkIgnoreTone.UseVisualStyleBackColor = true;
            // 
            // FormFrequencyWL
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(436, 209);
            this.Controls.Add(this.chkIgnoreTone);
            this.Controls.Add(this.chkDisplayPct);
            this.Controls.Add(this.btnSO);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkIgnoreSightWords);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormFrequencyWL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Frequency Count Search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkIgnoreSightWords;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnSO;
        private System.Windows.Forms.CheckBox chkDisplayPct;
        private System.Windows.Forms.CheckBox chkIgnoreTone;
    }
}
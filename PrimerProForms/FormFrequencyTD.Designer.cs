namespace PrimerProForms
{
    partial class FormFrequencyTD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFrequencyTD));
            this.chkIgnoreSightWords = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkDisplayPercentages = new System.Windows.Forms.CheckBox();
            this.chkIgnoreTone = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkIgnoreSightWords
            // 
            this.chkIgnoreSightWords.AutoSize = true;
            this.chkIgnoreSightWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIgnoreSightWords.Location = new System.Drawing.Point(24, 24);
            this.chkIgnoreSightWords.Margin = new System.Windows.Forms.Padding(2);
            this.chkIgnoreSightWords.Name = "chkIgnoreSightWords";
            this.chkIgnoreSightWords.Size = new System.Drawing.Size(130, 19);
            this.chkIgnoreSightWords.TabIndex = 0;
            this.chkIgnoreSightWords.Text = "&Ignore Sight Words";
            this.chkIgnoreSightWords.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(24, 144);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 26);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(143, 144);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 26);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkDisplayPercentages
            // 
            this.chkDisplayPercentages.AutoSize = true;
            this.chkDisplayPercentages.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDisplayPercentages.Location = new System.Drawing.Point(24, 96);
            this.chkDisplayPercentages.Margin = new System.Windows.Forms.Padding(2);
            this.chkDisplayPercentages.Name = "chkDisplayPercentages";
            this.chkDisplayPercentages.Size = new System.Drawing.Size(138, 19);
            this.chkDisplayPercentages.TabIndex = 2;
            this.chkDisplayPercentages.Text = "&Display Percentages";
            this.chkDisplayPercentages.UseVisualStyleBackColor = true;
            // 
            // chkIgnoreTone
            // 
            this.chkIgnoreTone.AutoSize = true;
            this.chkIgnoreTone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIgnoreTone.Location = new System.Drawing.Point(24, 60);
            this.chkIgnoreTone.Name = "chkIgnoreTone";
            this.chkIgnoreTone.Size = new System.Drawing.Size(92, 19);
            this.chkIgnoreTone.TabIndex = 1;
            this.chkIgnoreTone.Text = "Ignore Tone";
            this.chkIgnoreTone.UseVisualStyleBackColor = true;
            // 
            // FormFrequencyTD
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(318, 188);
            this.Controls.Add(this.chkIgnoreTone);
            this.Controls.Add(this.chkDisplayPercentages);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkIgnoreSightWords);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormFrequencyTD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Frequency Count Search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkIgnoreSightWords;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkDisplayPercentages;
        private System.Windows.Forms.CheckBox chkIgnoreTone;
    }
}
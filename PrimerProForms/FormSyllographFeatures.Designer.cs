namespace PrimerProForms
{
    partial class FormSyllographFeatures
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
            this.cbPrimary = new System.Windows.Forms.ComboBox();
            this.labPrimary = new System.Windows.Forms.Label();
            this.labTertiary = new System.Windows.Forms.Label();
            this.labSecondary = new System.Windows.Forms.Label();
            this.cbSecondary = new System.Windows.Forms.ComboBox();
            this.cbTertiary = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbPrimary
            // 
            this.cbPrimary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPrimary.FormattingEnabled = true;
            this.cbPrimary.Location = new System.Drawing.Point(170, 24);
            this.cbPrimary.Name = "cbPrimary";
            this.cbPrimary.Size = new System.Drawing.Size(121, 23);
            this.cbPrimary.TabIndex = 0;
            // 
            // labPrimary
            // 
            this.labPrimary.AutoSize = true;
            this.labPrimary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labPrimary.Location = new System.Drawing.Point(24, 24);
            this.labPrimary.Name = "labPrimary";
            this.labPrimary.Size = new System.Drawing.Size(100, 15);
            this.labPrimary.TabIndex = 1;
            this.labPrimary.Text = "Primary Category";
            // 
            // labTertiary
            // 
            this.labTertiary.AutoSize = true;
            this.labTertiary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTertiary.Location = new System.Drawing.Point(24, 104);
            this.labTertiary.Name = "labTertiary";
            this.labTertiary.Size = new System.Drawing.Size(98, 15);
            this.labTertiary.TabIndex = 2;
            this.labTertiary.Text = "Tertiary Category";
            // 
            // labSecondary
            // 
            this.labSecondary.AutoSize = true;
            this.labSecondary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labSecondary.Location = new System.Drawing.Point(24, 64);
            this.labSecondary.Name = "labSecondary";
            this.labSecondary.Size = new System.Drawing.Size(116, 15);
            this.labSecondary.TabIndex = 3;
            this.labSecondary.Text = "Secondary Category";
            // 
            // cbSecondary
            // 
            this.cbSecondary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSecondary.FormattingEnabled = true;
            this.cbSecondary.Location = new System.Drawing.Point(170, 64);
            this.cbSecondary.Name = "cbSecondary";
            this.cbSecondary.Size = new System.Drawing.Size(121, 23);
            this.cbSecondary.TabIndex = 4;
            // 
            // cbTertiary
            // 
            this.cbTertiary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTertiary.FormattingEnabled = true;
            this.cbTertiary.Location = new System.Drawing.Point(170, 104);
            this.cbTertiary.Name = "cbTertiary";
            this.cbTertiary.Size = new System.Drawing.Size(121, 23);
            this.cbTertiary.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(77, 162);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(191, 162);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormSyllographFeatures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 232);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbTertiary);
            this.Controls.Add(this.cbSecondary);
            this.Controls.Add(this.labSecondary);
            this.Controls.Add(this.labTertiary);
            this.Controls.Add(this.labPrimary);
            this.Controls.Add(this.cbPrimary);
            this.Name = "FormSyllographFeatures";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set Syllograph Features";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPrimary;
        private System.Windows.Forms.Label labPrimary;
        private System.Windows.Forms.Label labTertiary;
        private System.Windows.Forms.Label labSecondary;
        private System.Windows.Forms.ComboBox cbSecondary;
        private System.Windows.Forms.ComboBox cbTertiary;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}
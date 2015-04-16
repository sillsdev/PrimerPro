namespace PrimerProForms
{
    partial class FormSyllographTD
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
            this.lblFeatures = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnFeatures = new System.Windows.Forms.Button();
            this.tbSyllograph = new System.Windows.Forms.TextBox();
            this.lblSyllograph = new System.Windows.Forms.Label();
            this.chkParaFmt = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblFeatures
            // 
            this.lblFeatures.AutoSize = true;
            this.lblFeatures.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFeatures.Location = new System.Drawing.Point(20, 103);
            this.lblFeatures.Name = "lblFeatures";
            this.lblFeatures.Size = new System.Drawing.Size(35, 15);
            this.lblFeatures.TabIndex = 14;
            this.lblFeatures.Text = "none";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(282, 136);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 32);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(180, 136);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 32);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnFeatures
            // 
            this.btnFeatures.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFeatures.Location = new System.Drawing.Point(20, 60);
            this.btnFeatures.Margin = new System.Windows.Forms.Padding(2);
            this.btnFeatures.Name = "btnFeatures";
            this.btnFeatures.Size = new System.Drawing.Size(120, 32);
            this.btnFeatures.TabIndex = 11;
            this.btnFeatures.Text = "Choose features";
            this.btnFeatures.UseVisualStyleBackColor = true;
            this.btnFeatures.Click += new System.EventHandler(this.btnFeatures_Click);
            // 
            // tbSyllograph
            // 
            this.tbSyllograph.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSyllograph.Location = new System.Drawing.Point(100, 20);
            this.tbSyllograph.Margin = new System.Windows.Forms.Padding(2);
            this.tbSyllograph.Name = "tbSyllograph";
            this.tbSyllograph.Size = new System.Drawing.Size(76, 21);
            this.tbSyllograph.TabIndex = 10;
            // 
            // lblSyllograph
            // 
            this.lblSyllograph.AutoSize = true;
            this.lblSyllograph.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSyllograph.Location = new System.Drawing.Point(20, 20);
            this.lblSyllograph.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSyllograph.Name = "lblSyllograph";
            this.lblSyllograph.Size = new System.Drawing.Size(65, 15);
            this.lblSyllograph.TabIndex = 9;
            this.lblSyllograph.Text = "Syllograph";
            // 
            // chkParaFmt
            // 
            this.chkParaFmt.AutoSize = true;
            this.chkParaFmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkParaFmt.Location = new System.Drawing.Point(180, 60);
            this.chkParaFmt.Name = "chkParaFmt";
            this.chkParaFmt.Size = new System.Drawing.Size(177, 19);
            this.chkParaFmt.TabIndex = 15;
            this.chkParaFmt.Text = "Display in &paragraph format";
            // 
            // FormSyllographTD
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(393, 201);
            this.Controls.Add(this.chkParaFmt);
            this.Controls.Add(this.lblFeatures);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnFeatures);
            this.Controls.Add(this.tbSyllograph);
            this.Controls.Add(this.lblSyllograph);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormSyllographTD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Syllograph Search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFeatures;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnFeatures;
        private System.Windows.Forms.TextBox tbSyllograph;
        private System.Windows.Forms.Label lblSyllograph;
        private System.Windows.Forms.CheckBox chkParaFmt;
    }
}
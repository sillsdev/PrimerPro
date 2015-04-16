namespace PrimerProForms
{
    partial class FormNewSyllabary
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
            this.btnUseTD = new System.Windows.Forms.Button();
            this.btnUseWL = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUseTD
            // 
            this.btnUseTD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUseTD.Location = new System.Drawing.Point(58, 20);
            this.btnUseTD.Name = "btnUseTD";
            this.btnUseTD.Size = new System.Drawing.Size(240, 32);
            this.btnUseTD.TabIndex = 0;
            this.btnUseTD.Text = "Initialize using text data file";
            this.btnUseTD.UseVisualStyleBackColor = true;
            this.btnUseTD.Click += new System.EventHandler(this.btnUseTD_Click);
            // 
            // btnUseWL
            // 
            this.btnUseWL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUseWL.Location = new System.Drawing.Point(58, 69);
            this.btnUseWL.Name = "btnUseWL";
            this.btnUseWL.Size = new System.Drawing.Size(240, 32);
            this.btnUseWL.TabIndex = 1;
            this.btnUseWL.Text = "Initialize using word list file";
            this.btnUseWL.UseVisualStyleBackColor = true;
            this.btnUseWL.Click += new System.EventHandler(this.btnUseWL_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(58, 120);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 32);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(223, 120);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 32);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormNewSyllabary
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(374, 176);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnUseWL);
            this.Controls.Add(this.btnUseTD);
            this.Name = "FormNewSyllabary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Initialize Syllograph Inventory";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUseTD;
        private System.Windows.Forms.Button btnUseWL;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}
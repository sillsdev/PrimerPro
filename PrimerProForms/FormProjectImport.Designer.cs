namespace PrimerProForms
{
    partial class FormProjectImport
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.labInfo = new System.Windows.Forms.Label();
            this.btnFromFolder = new System.Windows.Forms.Button();
            this.tbFromFolder = new System.Windows.Forms.TextBox();
            this.labFromFolder = new System.Windows.Forms.Label();
            this.labToFolder = new System.Windows.Forms.Label();
            this.tbToFolder = new System.Windows.Forms.TextBox();
            this.btnToFolder = new System.Windows.Forms.Button();
            this.btnTemplateFolder = new System.Windows.Forms.Button();
            this.tbTemplateFolder = new System.Windows.Forms.TextBox();
            this.labTemplateFolder = new System.Windows.Forms.Label();
            this.btnDataFolder = new System.Windows.Forms.Button();
            this.tbDataFolder = new System.Windows.Forms.TextBox();
            this.labDataFolder = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(528, 301);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(653, 301);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labInfo
            // 
            this.labInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labInfo.Location = new System.Drawing.Point(12, 20);
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(799, 29);
            this.labInfo.TabIndex = 2;
            this.labInfo.Text = "This copies all the files associated with the PrimerPro project found in the From" +
                " folder to the To folder";
            // 
            // btnFromFolder
            // 
            this.btnFromFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFromFolder.Location = new System.Drawing.Point(736, 70);
            this.btnFromFolder.Name = "btnFromFolder";
            this.btnFromFolder.Size = new System.Drawing.Size(100, 32);
            this.btnFromFolder.TabIndex = 3;
            this.btnFromFolder.Text = "Browse";
            this.btnFromFolder.Click += new System.EventHandler(this.btnFromFolder_Click);
            // 
            // tbFromFolder
            // 
            this.tbFromFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFromFolder.Location = new System.Drawing.Point(137, 70);
            this.tbFromFolder.Multiline = true;
            this.tbFromFolder.Name = "tbFromFolder";
            this.tbFromFolder.Size = new System.Drawing.Size(583, 48);
            this.tbFromFolder.TabIndex = 2;
            this.tbFromFolder.Leave += new System.EventHandler(this.tbFromFolder_Leave);
            // 
            // labFromFolder
            // 
            this.labFromFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labFromFolder.Location = new System.Drawing.Point(12, 70);
            this.labFromFolder.Name = "labFromFolder";
            this.labFromFolder.Size = new System.Drawing.Size(120, 48);
            this.labFromFolder.TabIndex = 1;
            this.labFromFolder.Text = "From folder";
            // 
            // labToFolder
            // 
            this.labToFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labToFolder.Location = new System.Drawing.Point(12, 125);
            this.labToFolder.Name = "labToFolder";
            this.labToFolder.Size = new System.Drawing.Size(120, 48);
            this.labToFolder.TabIndex = 4;
            this.labToFolder.Text = "To folder";
            // 
            // tbToFolder
            // 
            this.tbToFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbToFolder.Location = new System.Drawing.Point(137, 125);
            this.tbToFolder.Multiline = true;
            this.tbToFolder.Name = "tbToFolder";
            this.tbToFolder.Size = new System.Drawing.Size(583, 48);
            this.tbToFolder.TabIndex = 5;
            this.tbToFolder.Leave += new System.EventHandler(this.tbToFolder_Leave);
            // 
            // btnToFolder
            // 
            this.btnToFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToFolder.Location = new System.Drawing.Point(736, 125);
            this.btnToFolder.Name = "btnToFolder";
            this.btnToFolder.Size = new System.Drawing.Size(100, 32);
            this.btnToFolder.TabIndex = 6;
            this.btnToFolder.Text = "Browse";
            this.btnToFolder.Click += new System.EventHandler(this.btnToFolder_Click);
            // 
            // btnTemplateFolder
            // 
            this.btnTemplateFolder.Location = new System.Drawing.Point(736, 235);
            this.btnTemplateFolder.Name = "btnTemplateFolder";
            this.btnTemplateFolder.Size = new System.Drawing.Size(100, 32);
            this.btnTemplateFolder.TabIndex = 12;
            this.btnTemplateFolder.Text = "Browse";
            this.btnTemplateFolder.Click += new System.EventHandler(this.btnTemplateFolder_Click);
            // 
            // tbTemplateFolder
            // 
            this.tbTemplateFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTemplateFolder.Location = new System.Drawing.Point(137, 235);
            this.tbTemplateFolder.Multiline = true;
            this.tbTemplateFolder.Name = "tbTemplateFolder";
            this.tbTemplateFolder.Size = new System.Drawing.Size(583, 48);
            this.tbTemplateFolder.TabIndex = 11;
            this.tbTemplateFolder.Leave += new System.EventHandler(this.tbTemplateFolder_Leave);
            // 
            // labTemplateFolder
            // 
            this.labTemplateFolder.Location = new System.Drawing.Point(12, 235);
            this.labTemplateFolder.Name = "labTemplateFolder";
            this.labTemplateFolder.Size = new System.Drawing.Size(120, 48);
            this.labTemplateFolder.TabIndex = 10;
            this.labTemplateFolder.Text = "Template folder";
            // 
            // btnDataFolder
            // 
            this.btnDataFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDataFolder.Location = new System.Drawing.Point(736, 180);
            this.btnDataFolder.Name = "btnDataFolder";
            this.btnDataFolder.Size = new System.Drawing.Size(100, 32);
            this.btnDataFolder.TabIndex = 9;
            this.btnDataFolder.Text = "Browse";
            this.btnDataFolder.Click += new System.EventHandler(this.btnDataFolder_Click);
            // 
            // tbDataFolder
            // 
            this.tbDataFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDataFolder.Location = new System.Drawing.Point(137, 180);
            this.tbDataFolder.Multiline = true;
            this.tbDataFolder.Name = "tbDataFolder";
            this.tbDataFolder.Size = new System.Drawing.Size(583, 48);
            this.tbDataFolder.TabIndex = 8;
            // 
            // labDataFolder
            // 
            this.labDataFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDataFolder.Location = new System.Drawing.Point(12, 180);
            this.labDataFolder.Name = "labDataFolder";
            this.labDataFolder.Size = new System.Drawing.Size(120, 48);
            this.labDataFolder.TabIndex = 7;
            this.labDataFolder.Text = "Data folder";
            // 
            // FormProjectImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 361);
            this.Controls.Add(this.btnTemplateFolder);
            this.Controls.Add(this.tbTemplateFolder);
            this.Controls.Add(this.labTemplateFolder);
            this.Controls.Add(this.btnDataFolder);
            this.Controls.Add(this.tbDataFolder);
            this.Controls.Add(this.labDataFolder);
            this.Controls.Add(this.btnToFolder);
            this.Controls.Add(this.tbToFolder);
            this.Controls.Add(this.labToFolder);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.labInfo);
            this.Controls.Add(this.btnFromFolder);
            this.Controls.Add(this.tbFromFolder);
            this.Controls.Add(this.labFromFolder);
            this.Name = "FormProjectImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import Project";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label labInfo;
        private System.Windows.Forms.Button btnFromFolder;
        private System.Windows.Forms.TextBox tbFromFolder;
        private System.Windows.Forms.Label labFromFolder;
        private System.Windows.Forms.Label labToFolder;
        private System.Windows.Forms.TextBox tbToFolder;
        private System.Windows.Forms.Button btnToFolder;
        private System.Windows.Forms.Button btnTemplateFolder;
        private System.Windows.Forms.TextBox tbTemplateFolder;
        private System.Windows.Forms.Label labTemplateFolder;
        private System.Windows.Forms.Button btnDataFolder;
        private System.Windows.Forms.TextBox tbDataFolder;
        private System.Windows.Forms.Label labDataFolder;
    }
}
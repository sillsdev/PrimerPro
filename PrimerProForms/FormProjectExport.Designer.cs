namespace PrimerProForms
{
    partial class FormProjectExport
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
            this.btnExportFolder = new System.Windows.Forms.Button();
            this.tbExportFolder = new System.Windows.Forms.TextBox();
            this.labExportFolder = new System.Windows.Forms.Label();
            this.ckDataFolder = new System.Windows.Forms.CheckBox();
            this.ckTemplateFolder = new System.Windows.Forms.CheckBox();
            this.labelInfo = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExportFolder
            // 
            this.btnExportFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportFolder.Location = new System.Drawing.Point(692, 52);
            this.btnExportFolder.Name = "btnExportFolder";
            this.btnExportFolder.Size = new System.Drawing.Size(100, 32);
            this.btnExportFolder.TabIndex = 3;
            this.btnExportFolder.Text = "Browse";
            this.btnExportFolder.Click += new System.EventHandler(this.btnExportFolder_Click);
            // 
            // tbExportFolder
            // 
            this.tbExportFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbExportFolder.Location = new System.Drawing.Point(158, 52);
            this.tbExportFolder.Multiline = true;
            this.tbExportFolder.Name = "tbExportFolder";
            this.tbExportFolder.Size = new System.Drawing.Size(528, 48);
            this.tbExportFolder.TabIndex = 2;
            this.tbExportFolder.Leave += new System.EventHandler(this.tbExportFolder_Leave);
            // 
            // labExportFolder
            // 
            this.labExportFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labExportFolder.Location = new System.Drawing.Point(32, 52);
            this.labExportFolder.Name = "labExportFolder";
            this.labExportFolder.Size = new System.Drawing.Size(120, 48);
            this.labExportFolder.TabIndex = 1;
            this.labExportFolder.Text = "Export folder";
            // 
            // ckDataFolder
            // 
            this.ckDataFolder.AutoSize = true;
            this.ckDataFolder.Location = new System.Drawing.Point(35, 120);
            this.ckDataFolder.Name = "ckDataFolder";
            this.ckDataFolder.Size = new System.Drawing.Size(244, 22);
            this.ckDataFolder.TabIndex = 4;
            this.ckDataFolder.Text = "Include all files in the Data Folder";
            this.ckDataFolder.UseVisualStyleBackColor = true;
            // 
            // ckTemplateFolder
            // 
            this.ckTemplateFolder.AutoSize = true;
            this.ckTemplateFolder.Location = new System.Drawing.Point(35, 161);
            this.ckTemplateFolder.Name = "ckTemplateFolder";
            this.ckTemplateFolder.Size = new System.Drawing.Size(274, 22);
            this.ckTemplateFolder.TabIndex = 5;
            this.ckTemplateFolder.Text = "Include all files in the Template Folder";
            this.ckTemplateFolder.UseVisualStyleBackColor = true;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo.Location = new System.Drawing.Point(32, 22);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(666, 18);
            this.labelInfo.TabIndex = 0;
            this.labelInfo.Text = "This copies all the files associated with the current project to the specified ex" +
                "port folder";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(557, 155);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(692, 155);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormProjectExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 217);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.ckTemplateFolder);
            this.Controls.Add(this.ckDataFolder);
            this.Controls.Add(this.btnExportFolder);
            this.Controls.Add(this.tbExportFolder);
            this.Controls.Add(this.labExportFolder);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormProjectExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export Project";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExportFolder;
        private System.Windows.Forms.TextBox tbExportFolder;
        private System.Windows.Forms.Label labExportFolder;
        private System.Windows.Forms.CheckBox ckDataFolder;
        private System.Windows.Forms.CheckBox ckTemplateFolder;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}
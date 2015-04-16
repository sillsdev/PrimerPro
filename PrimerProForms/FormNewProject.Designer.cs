namespace PrimerProForms
{
    partial class FormNewProject
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
            this.labProjName = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.tbProjName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnInitGI = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labProjName
            // 
            this.labProjName.AutoSize = true;
            this.labProjName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labProjName.Location = new System.Drawing.Point(20, 20);
            this.labProjName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labProjName.Name = "labProjName";
            this.labProjName.Size = new System.Drawing.Size(82, 15);
            this.labProjName.TabIndex = 0;
            this.labProjName.Text = "Project Name";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(20, 120);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tbProjName
            // 
            this.tbProjName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbProjName.Location = new System.Drawing.Point(108, 20);
            this.tbProjName.Margin = new System.Windows.Forms.Padding(2);
            this.tbProjName.Name = "tbProjName";
            this.tbProjName.Size = new System.Drawing.Size(162, 21);
            this.tbProjName.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(170, 120);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnInitGI
            // 
            this.btnInitGI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInitGI.Location = new System.Drawing.Point(20, 70);
            this.btnInitGI.Margin = new System.Windows.Forms.Padding(2);
            this.btnInitGI.Name = "btnInitGI";
            this.btnInitGI.Size = new System.Drawing.Size(250, 32);
            this.btnInitGI.TabIndex = 2;
            this.btnInitGI.Text = "Initialize Grapheme Inventory";
            this.btnInitGI.UseVisualStyleBackColor = true;
            this.btnInitGI.Click += new System.EventHandler(this.btnInitGI_Click);
            // 
            // FormNewProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 182);
            this.Controls.Add(this.btnInitGI);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbProjName);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labProjName);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormNewProject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create New Project";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labProjName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox tbProjName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnInitGI;
    }
}
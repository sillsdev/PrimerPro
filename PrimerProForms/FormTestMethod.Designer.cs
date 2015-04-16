namespace PrimerProForms
{
    partial class FormTestMethod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTestMethod));
            this.labParm1 = new System.Windows.Forms.Label();
            this.tbParm1 = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.labParm2 = new System.Windows.Forms.Label();
            this.labParm3 = new System.Windows.Forms.Label();
            this.tbParm2 = new System.Windows.Forms.TextBox();
            this.tbParm3 = new System.Windows.Forms.TextBox();
            this.tbParm4 = new System.Windows.Forms.TextBox();
            this.labParm4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labParm1
            // 
            this.labParm1.AutoSize = true;
            this.labParm1.Location = new System.Drawing.Point(34, 44);
            this.labParm1.Name = "labParm1";
            this.labParm1.Size = new System.Drawing.Size(89, 18);
            this.labParm1.TabIndex = 0;
            this.labParm1.Text = "Parameter 1";
            // 
            // tbParm1
            // 
            this.tbParm1.Location = new System.Drawing.Point(171, 43);
            this.tbParm1.Name = "tbParm1";
            this.tbParm1.Size = new System.Drawing.Size(198, 24);
            this.tbParm1.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(93, 255);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // labParm2
            // 
            this.labParm2.AutoSize = true;
            this.labParm2.Location = new System.Drawing.Point(34, 95);
            this.labParm2.Name = "labParm2";
            this.labParm2.Size = new System.Drawing.Size(89, 18);
            this.labParm2.TabIndex = 3;
            this.labParm2.Text = "Parameter 2";
            // 
            // labParm3
            // 
            this.labParm3.AutoSize = true;
            this.labParm3.Location = new System.Drawing.Point(34, 139);
            this.labParm3.Name = "labParm3";
            this.labParm3.Size = new System.Drawing.Size(89, 18);
            this.labParm3.TabIndex = 4;
            this.labParm3.Text = "Parameter 3";
            // 
            // tbParm2
            // 
            this.tbParm2.Location = new System.Drawing.Point(171, 95);
            this.tbParm2.Name = "tbParm2";
            this.tbParm2.Size = new System.Drawing.Size(198, 24);
            this.tbParm2.TabIndex = 5;
            // 
            // tbParm3
            // 
            this.tbParm3.CausesValidation = false;
            this.tbParm3.Location = new System.Drawing.Point(171, 139);
            this.tbParm3.Name = "tbParm3";
            this.tbParm3.Size = new System.Drawing.Size(198, 24);
            this.tbParm3.TabIndex = 6;
            // 
            // tbParm4
            // 
            this.tbParm4.Location = new System.Drawing.Point(171, 188);
            this.tbParm4.Name = "tbParm4";
            this.tbParm4.Size = new System.Drawing.Size(198, 24);
            this.tbParm4.TabIndex = 7;
            // 
            // labParm4
            // 
            this.labParm4.AutoSize = true;
            this.labParm4.Location = new System.Drawing.Point(34, 188);
            this.labParm4.Name = "labParm4";
            this.labParm4.Size = new System.Drawing.Size(89, 18);
            this.labParm4.TabIndex = 8;
            this.labParm4.Text = "Parameter 4";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(294, 255);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormTestMethod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 314);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.labParm4);
            this.Controls.Add(this.tbParm4);
            this.Controls.Add(this.tbParm3);
            this.Controls.Add(this.tbParm2);
            this.Controls.Add(this.labParm3);
            this.Controls.Add(this.labParm2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbParm1);
            this.Controls.Add(this.labParm1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTestMethod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Test Method";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labParm1;
        private System.Windows.Forms.TextBox tbParm1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label labParm2;
        private System.Windows.Forms.Label labParm3;
        private System.Windows.Forms.TextBox tbParm2;
        private System.Windows.Forms.TextBox tbParm3;
        private System.Windows.Forms.TextBox tbParm4;
        private System.Windows.Forms.Label labParm4;
        private System.Windows.Forms.Button btnCancel;
    }
}
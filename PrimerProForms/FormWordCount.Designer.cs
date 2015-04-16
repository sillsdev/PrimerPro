namespace PrimerProForms
{
    partial class FormWordCount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWordCount));
            this.gbSort = new System.Windows.Forms.GroupBox();
            this.rbNumer = new System.Windows.Forms.RadioButton();
            this.rbAlpha = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.chkIgnoreTone = new System.Windows.Forms.CheckBox();
            this.gbSort.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSort
            // 
            this.gbSort.Controls.Add(this.rbNumer);
            this.gbSort.Controls.Add(this.rbAlpha);
            this.gbSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSort.Location = new System.Drawing.Point(24, 24);
            this.gbSort.Name = "gbSort";
            this.gbSort.Size = new System.Drawing.Size(235, 96);
            this.gbSort.TabIndex = 0;
            this.gbSort.TabStop = false;
            this.gbSort.Text = "Sort Order";
            // 
            // rbNumer
            // 
            this.rbNumer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNumer.Location = new System.Drawing.Point(36, 54);
            this.rbNumer.Name = "rbNumer";
            this.rbNumer.Size = new System.Drawing.Size(174, 24);
            this.rbNumer.TabIndex = 1;
            this.rbNumer.Text = "&Numerical";
            // 
            // rbAlpha
            // 
            this.rbAlpha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAlpha.Location = new System.Drawing.Point(36, 23);
            this.rbAlpha.Name = "rbAlpha";
            this.rbAlpha.Size = new System.Drawing.Size(174, 24);
            this.rbAlpha.TabIndex = 0;
            this.rbAlpha.Text = "&Alphabetical";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(255, 175);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(110, 175);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // chkIgnoreTone
            // 
            this.chkIgnoreTone.AutoSize = true;
            this.chkIgnoreTone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIgnoreTone.Location = new System.Drawing.Point(24, 135);
            this.chkIgnoreTone.Name = "chkIgnoreTone";
            this.chkIgnoreTone.Size = new System.Drawing.Size(186, 22);
            this.chkIgnoreTone.TabIndex = 1;
            this.chkIgnoreTone.Text = "&Ignore syllograph in Text Data";
            this.chkIgnoreTone.UseVisualStyleBackColor = true;
            // 
            // FormWordCount
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(391, 227);
            this.Controls.Add(this.chkIgnoreTone);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbSort);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormWordCount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Word Count Search";
            this.gbSort.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSort;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox chkIgnoreTone;
        private System.Windows.Forms.RadioButton rbAlpha;
        private System.Windows.Forms.RadioButton rbNumer;
    }
}
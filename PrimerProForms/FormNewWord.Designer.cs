namespace PrimerProForms
{
    partial class FormNewWord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewWord));
            this.chkIgnoreTone = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkParaFmt = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnBaseFile = new System.Windows.Forms.Button();
            this.tbBaseFile = new System.Windows.Forms.TextBox();
            this.labBaseFile = new System.Windows.Forms.Label();
            this.labTitle1 = new System.Windows.Forms.Label();
            this.labTitle2 = new System.Windows.Forms.Label();
            this.labStory = new System.Windows.Forms.Label();
            this.btnStory = new System.Windows.Forms.Button();
            this.tbStory = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // chkIgnoreTone
            // 
            this.chkIgnoreTone.AutoSize = true;
            this.chkIgnoreTone.Location = new System.Drawing.Point(35, 257);
            this.chkIgnoreTone.Name = "chkIgnoreTone";
            this.chkIgnoreTone.Size = new System.Drawing.Size(186, 22);
            this.chkIgnoreTone.TabIndex = 9;
            this.chkIgnoreTone.Text = "&Ignore syllograph in Text Data";
            this.chkIgnoreTone.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(681, 255);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkParaFmt
            // 
            this.chkParaFmt.AutoSize = true;
            this.chkParaFmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkParaFmt.Location = new System.Drawing.Point(35, 203);
            this.chkParaFmt.Name = "chkParaFmt";
            this.chkParaFmt.Size = new System.Drawing.Size(210, 22);
            this.chkParaFmt.TabIndex = 8;
            this.chkParaFmt.Text = "Display in &paragraph format";
            this.chkParaFmt.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(561, 257);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnBaseFile
            // 
            this.btnBaseFile.Location = new System.Drawing.Point(681, 71);
            this.btnBaseFile.Name = "btnBaseFile";
            this.btnBaseFile.Size = new System.Drawing.Size(100, 32);
            this.btnBaseFile.TabIndex = 4;
            this.btnBaseFile.Text = "Bro&wse";
            this.btnBaseFile.Click += new System.EventHandler(this.btnBaseFile_Click);
            // 
            // tbBaseFile
            // 
            this.tbBaseFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBaseFile.Location = new System.Drawing.Point(133, 71);
            this.tbBaseFile.Multiline = true;
            this.tbBaseFile.Name = "tbBaseFile";
            this.tbBaseFile.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbBaseFile.Size = new System.Drawing.Size(528, 44);
            this.tbBaseFile.TabIndex = 3;
            // 
            // labBaseFile
            // 
            this.labBaseFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labBaseFile.Location = new System.Drawing.Point(33, 71);
            this.labBaseFile.Name = "labBaseFile";
            this.labBaseFile.Size = new System.Drawing.Size(94, 40);
            this.labBaseFile.TabIndex = 2;
            this.labBaseFile.Text = "Base file";
            // 
            // labTitle1
            // 
            this.labTitle1.AutoSize = true;
            this.labTitle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTitle1.Location = new System.Drawing.Point(33, 9);
            this.labTitle1.Name = "labTitle1";
            this.labTitle1.Size = new System.Drawing.Size(585, 18);
            this.labTitle1.TabIndex = 0;
            this.labTitle1.Text = "This search will identify any words in the story file that is not in the base fil" +
                "e. ";
            // 
            // labTitle2
            // 
            this.labTitle2.AutoSize = true;
            this.labTitle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTitle2.Location = new System.Drawing.Point(32, 34);
            this.labTitle2.Name = "labTitle2";
            this.labTitle2.Size = new System.Drawing.Size(496, 18);
            this.labTitle2.TabIndex = 1;
            this.labTitle2.Text = "This allows you to identify new  words in the story file (text data).";
            // 
            // labStory
            // 
            this.labStory.AutoSize = true;
            this.labStory.Location = new System.Drawing.Point(35, 135);
            this.labStory.Name = "labStory";
            this.labStory.Size = new System.Drawing.Size(65, 18);
            this.labStory.TabIndex = 5;
            this.labStory.Text = "Story file";
            // 
            // btnStory
            // 
            this.btnStory.Location = new System.Drawing.Point(681, 135);
            this.btnStory.Name = "btnStory";
            this.btnStory.Size = new System.Drawing.Size(100, 32);
            this.btnStory.TabIndex = 7;
            this.btnStory.Text = "Bro&wse";
            this.btnStory.Click += new System.EventHandler(this.btnStory_Click);
            // 
            // tbStory
            // 
            this.tbStory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStory.Location = new System.Drawing.Point(133, 135);
            this.tbStory.Multiline = true;
            this.tbStory.Name = "tbStory";
            this.tbStory.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbStory.Size = new System.Drawing.Size(528, 44);
            this.tbStory.TabIndex = 6;
            // 
            // FormNewWord
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(794, 299);
            this.Controls.Add(this.tbStory);
            this.Controls.Add(this.btnStory);
            this.Controls.Add(this.labStory);
            this.Controls.Add(this.labTitle2);
            this.Controls.Add(this.labTitle1);
            this.Controls.Add(this.btnBaseFile);
            this.Controls.Add(this.tbBaseFile);
            this.Controls.Add(this.labBaseFile);
            this.Controls.Add(this.chkIgnoreTone);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.chkParaFmt);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormNewWord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Word Search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkIgnoreTone;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkParaFmt;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnBaseFile;
        private System.Windows.Forms.TextBox tbBaseFile;
        private System.Windows.Forms.Label labBaseFile;
        private System.Windows.Forms.Label labTitle1;
        private System.Windows.Forms.Label labTitle2;
        private System.Windows.Forms.Label labStory;
        private System.Windows.Forms.Button btnStory;
        private System.Windows.Forms.TextBox tbStory;
    }
}
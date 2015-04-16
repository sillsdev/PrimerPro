namespace PrimerProForms
{
    partial class FormMergeWordList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMergeWordList));
            this.rbKeep = new System.Windows.Forms.RadioButton();
            this.rbReplace = new System.Windows.Forms.RadioButton();
            this.rbBoth = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbDuplicate = new System.Windows.Forms.GroupBox();
            this.rbAsk = new System.Windows.Forms.RadioButton();
            this.btnFile = new System.Windows.Forms.Button();
            this.tbFile = new System.Windows.Forms.TextBox();
            this.labFile = new System.Windows.Forms.Label();
            this.gbDuplicate.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbKeep
            // 
            this.rbKeep.AutoSize = true;
            this.rbKeep.Location = new System.Drawing.Point(31, 27);
            this.rbKeep.Name = "rbKeep";
            this.rbKeep.Size = new System.Drawing.Size(146, 22);
            this.rbKeep.TabIndex = 0;
            this.rbKeep.TabStop = true;
            this.rbKeep.Text = "&Keep the originals";
            this.rbKeep.UseVisualStyleBackColor = true;
            // 
            // rbReplace
            // 
            this.rbReplace.AutoSize = true;
            this.rbReplace.Location = new System.Drawing.Point(31, 55);
            this.rbReplace.Name = "rbReplace";
            this.rbReplace.Size = new System.Drawing.Size(166, 22);
            this.rbReplace.TabIndex = 1;
            this.rbReplace.TabStop = true;
            this.rbReplace.Text = "&Replace the originals";
            this.rbReplace.UseVisualStyleBackColor = true;
            // 
            // rbBoth
            // 
            this.rbBoth.AutoSize = true;
            this.rbBoth.Location = new System.Drawing.Point(296, 27);
            this.rbBoth.Name = "rbBoth";
            this.rbBoth.Size = new System.Drawing.Size(96, 22);
            this.rbBoth.TabIndex = 2;
            this.rbBoth.TabStop = true;
            this.rbBoth.Text = "Keep &both";
            this.rbBoth.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.Control;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(450, 210);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(579, 210);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gbDuplicate
            // 
            this.gbDuplicate.Controls.Add(this.rbAsk);
            this.gbDuplicate.Controls.Add(this.rbKeep);
            this.gbDuplicate.Controls.Add(this.rbBoth);
            this.gbDuplicate.Controls.Add(this.rbReplace);
            this.gbDuplicate.Location = new System.Drawing.Point(31, 80);
            this.gbDuplicate.Name = "gbDuplicate";
            this.gbDuplicate.Size = new System.Drawing.Size(519, 105);
            this.gbDuplicate.TabIndex = 3;
            this.gbDuplicate.TabStop = false;
            this.gbDuplicate.Text = "Duplicate entries processing (same word)";
            // 
            // rbAsk
            // 
            this.rbAsk.AutoSize = true;
            this.rbAsk.Location = new System.Drawing.Point(296, 55);
            this.rbAsk.Name = "rbAsk";
            this.rbAsk.Size = new System.Drawing.Size(147, 22);
            this.rbAsk.TabIndex = 3;
            this.rbAsk.TabStop = true;
            this.rbAsk.Text = "&Ask me each time";
            this.rbAsk.UseVisualStyleBackColor = true;
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(579, 17);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(100, 32);
            this.btnFile.TabIndex = 2;
            this.btnFile.Text = "Browse";
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // tbFile
            // 
            this.tbFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFile.Location = new System.Drawing.Point(156, 10);
            this.tbFile.Multiline = true;
            this.tbFile.Name = "tbFile";
            this.tbFile.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbFile.Size = new System.Drawing.Size(394, 44);
            this.tbFile.TabIndex = 1;
            // 
            // labFile
            // 
            this.labFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labFile.Location = new System.Drawing.Point(28, 19);
            this.labFile.Name = "labFile";
            this.labFile.Size = new System.Drawing.Size(102, 32);
            this.labFile.TabIndex = 0;
            this.labFile.Text = "File to merge";
            // 
            // FormMergeWordList
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(727, 255);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.tbFile);
            this.Controls.Add(this.labFile);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbDuplicate);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMergeWordList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Merge Word List";
            this.gbDuplicate.ResumeLayout(false);
            this.gbDuplicate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbKeep;
        private System.Windows.Forms.RadioButton rbReplace;
        private System.Windows.Forms.RadioButton rbBoth;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbDuplicate;
        private System.Windows.Forms.RadioButton rbAsk;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.TextBox tbFile;
        private System.Windows.Forms.Label labFile;
    }
}
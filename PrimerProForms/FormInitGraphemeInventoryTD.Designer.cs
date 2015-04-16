namespace PrimerProForms
{
    partial class FormInitGraphemeInventoryTD
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
            this.btnTDFile = new System.Windows.Forms.Button();
            this.tbTDFile = new System.Windows.Forms.TextBox();
            this.labWLFile = new System.Windows.Forms.Label();
            this.tbTones = new System.Windows.Forms.TextBox();
            this.tbVowels = new System.Windows.Forms.TextBox();
            this.btnMulti = new System.Windows.Forms.Button();
            this.btnTones = new System.Windows.Forms.Button();
            this.btnVowels = new System.Windows.Forms.Button();
            this.tbConsonants = new System.Windows.Forms.TextBox();
            this.btnConsonants = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTDFile
            // 
            this.btnTDFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTDFile.Location = new System.Drawing.Point(750, 64);
            this.btnTDFile.Name = "btnTDFile";
            this.btnTDFile.Size = new System.Drawing.Size(100, 32);
            this.btnTDFile.TabIndex = 2;
            this.btnTDFile.Text = "Browse";
            this.btnTDFile.Click += new System.EventHandler(this.btnTDFile_Click);
            // 
            // tbTDFile
            // 
            this.tbTDFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTDFile.Location = new System.Drawing.Point(24, 64);
            this.tbTDFile.Multiline = true;
            this.tbTDFile.Name = "tbTDFile";
            this.tbTDFile.ReadOnly = true;
            this.tbTDFile.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbTDFile.Size = new System.Drawing.Size(699, 55);
            this.tbTDFile.TabIndex = 1;
            // 
            // labWLFile
            // 
            this.labWLFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labWLFile.Location = new System.Drawing.Point(24, 24);
            this.labWLFile.Name = "labWLFile";
            this.labWLFile.Size = new System.Drawing.Size(700, 28);
            this.labWLFile.TabIndex = 0;
            this.labWLFile.Text = "Select the word list file to be used to initialize the grapheme inventory\r\n";
            this.labWLFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbTones
            // 
            this.tbTones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTones.Location = new System.Drawing.Point(200, 340);
            this.tbTones.Multiline = true;
            this.tbTones.Name = "tbTones";
            this.tbTones.ReadOnly = true;
            this.tbTones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbTones.Size = new System.Drawing.Size(540, 72);
            this.tbTones.TabIndex = 8;
            // 
            // tbVowels
            // 
            this.tbVowels.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVowels.Location = new System.Drawing.Point(200, 240);
            this.tbVowels.Multiline = true;
            this.tbVowels.Name = "tbVowels";
            this.tbVowels.ReadOnly = true;
            this.tbVowels.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbVowels.Size = new System.Drawing.Size(540, 72);
            this.tbVowels.TabIndex = 6;
            // 
            // btnMulti
            // 
            this.btnMulti.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMulti.Location = new System.Drawing.Point(24, 430);
            this.btnMulti.Name = "btnMulti";
            this.btnMulti.Size = new System.Drawing.Size(240, 32);
            this.btnMulti.TabIndex = 9;
            this.btnMulti.Text = "Select multi-graphs";
            this.btnMulti.UseVisualStyleBackColor = true;
            this.btnMulti.Click += new System.EventHandler(this.btnMulti_Click);
            // 
            // btnTones
            // 
            this.btnTones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTones.Location = new System.Drawing.Point(24, 340);
            this.btnTones.Name = "btnTones";
            this.btnTones.Size = new System.Drawing.Size(144, 32);
            this.btnTones.TabIndex = 7;
            this.btnTones.Text = "Select tones";
            this.btnTones.UseVisualStyleBackColor = true;
            this.btnTones.Click += new System.EventHandler(this.btnTones_Click);
            // 
            // btnVowels
            // 
            this.btnVowels.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVowels.Location = new System.Drawing.Point(24, 240);
            this.btnVowels.Name = "btnVowels";
            this.btnVowels.Size = new System.Drawing.Size(144, 32);
            this.btnVowels.TabIndex = 5;
            this.btnVowels.Text = "Select  vowels";
            this.btnVowels.UseVisualStyleBackColor = true;
            this.btnVowels.Click += new System.EventHandler(this.btnVowels_Click);
            // 
            // tbConsonants
            // 
            this.tbConsonants.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConsonants.Location = new System.Drawing.Point(200, 144);
            this.tbConsonants.Multiline = true;
            this.tbConsonants.Name = "tbConsonants";
            this.tbConsonants.ReadOnly = true;
            this.tbConsonants.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbConsonants.Size = new System.Drawing.Size(540, 72);
            this.tbConsonants.TabIndex = 4;
            // 
            // btnConsonants
            // 
            this.btnConsonants.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsonants.Location = new System.Drawing.Point(24, 144);
            this.btnConsonants.Name = "btnConsonants";
            this.btnConsonants.Size = new System.Drawing.Size(144, 32);
            this.btnConsonants.TabIndex = 3;
            this.btnConsonants.Text = "Select  consonants";
            this.btnConsonants.UseVisualStyleBackColor = true;
            this.btnConsonants.Click += new System.EventHandler(this.btnConsonants_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(750, 430);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(600, 430);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FormInitGraphemeInventoryTD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 486);
            this.Controls.Add(this.tbTones);
            this.Controls.Add(this.tbVowels);
            this.Controls.Add(this.btnMulti);
            this.Controls.Add(this.btnTones);
            this.Controls.Add(this.btnVowels);
            this.Controls.Add(this.tbConsonants);
            this.Controls.Add(this.btnConsonants);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnTDFile);
            this.Controls.Add(this.tbTDFile);
            this.Controls.Add(this.labWLFile);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormInitGraphemeInventoryTD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Initialize Grapheme Inventory from Text Data";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTDFile;
        private System.Windows.Forms.TextBox tbTDFile;
        private System.Windows.Forms.Label labWLFile;
        private System.Windows.Forms.TextBox tbTones;
        private System.Windows.Forms.TextBox tbVowels;
        private System.Windows.Forms.Button btnMulti;
        private System.Windows.Forms.Button btnTones;
        private System.Windows.Forms.Button btnVowels;
        private System.Windows.Forms.TextBox tbConsonants;
        private System.Windows.Forms.Button btnConsonants;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}
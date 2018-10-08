namespace PrimerProForms
{
    partial class FormInitGraphemeInventoryWL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInitGraphemeInventoryWL));
            this.btnWLFile = new System.Windows.Forms.Button();
            this.tbWLFile = new System.Windows.Forms.TextBox();
            this.labWLFile = new System.Windows.Forms.Label();
            this.gbWLType = new System.Windows.Forms.GroupBox();
            this.rbLIft = new System.Windows.Forms.RadioButton();
            this.rbSFM = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnConsonants = new System.Windows.Forms.Button();
            this.tbConsonants = new System.Windows.Forms.TextBox();
            this.btnVowels = new System.Windows.Forms.Button();
            this.btnTones = new System.Windows.Forms.Button();
            this.btnMulti = new System.Windows.Forms.Button();
            this.tbVowels = new System.Windows.Forms.TextBox();
            this.tbTones = new System.Windows.Forms.TextBox();
            this.gbWLType.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnWLFile
            // 
            this.btnWLFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWLFile.Location = new System.Drawing.Point(640, 60);
            this.btnWLFile.Name = "btnWLFile";
            this.btnWLFile.Size = new System.Drawing.Size(100, 32);
            this.btnWLFile.TabIndex = 2;
            this.btnWLFile.Text = "Browse";
            this.btnWLFile.Click += new System.EventHandler(this.btnWLFile_Click);
            // 
            // tbWLFile
            // 
            this.tbWLFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbWLFile.Location = new System.Drawing.Point(24, 60);
            this.tbWLFile.Multiline = true;
            this.tbWLFile.Name = "tbWLFile";
            this.tbWLFile.ReadOnly = true;
            this.tbWLFile.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbWLFile.Size = new System.Drawing.Size(600, 48);
            this.tbWLFile.TabIndex = 1;
            // 
            // labWLFile
            // 
            this.labWLFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labWLFile.Location = new System.Drawing.Point(24, 24);
            this.labWLFile.Name = "labWLFile";
            this.labWLFile.Size = new System.Drawing.Size(600, 24);
            this.labWLFile.TabIndex = 0;
            this.labWLFile.Text = "Select the word list file to be used to initialize the grapheme inventory\r\n";
            this.labWLFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbWLType
            // 
            this.gbWLType.Controls.Add(this.rbLIft);
            this.gbWLType.Controls.Add(this.rbSFM);
            this.gbWLType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbWLType.Location = new System.Drawing.Point(770, 24);
            this.gbWLType.Name = "gbWLType";
            this.gbWLType.Size = new System.Drawing.Size(122, 100);
            this.gbWLType.TabIndex = 3;
            this.gbWLType.TabStop = false;
            this.gbWLType.Text = "File Type";
            // 
            // rbLIft
            // 
            this.rbLIft.AutoSize = true;
            this.rbLIft.Location = new System.Drawing.Point(17, 63);
            this.rbLIft.Name = "rbLIft";
            this.rbLIft.Size = new System.Drawing.Size(41, 19);
            this.rbLIft.TabIndex = 1;
            this.rbLIft.TabStop = true;
            this.rbLIft.Text = "LIft";
            this.rbLIft.UseVisualStyleBackColor = true;
            this.rbLIft.CheckedChanged += new System.EventHandler(this.rbLIft_CheckedChanged);
            // 
            // rbSFM
            // 
            this.rbSFM.AutoSize = true;
            this.rbSFM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSFM.Location = new System.Drawing.Point(17, 22);
            this.rbSFM.Name = "rbSFM";
            this.rbSFM.Size = new System.Drawing.Size(51, 19);
            this.rbSFM.TabIndex = 0;
            this.rbSFM.TabStop = true;
            this.rbSFM.Text = "SFM";
            this.rbSFM.UseVisualStyleBackColor = true;
            this.rbSFM.CheckedChanged += new System.EventHandler(this.rbSFM_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(770, 420);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(640, 420);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnConsonants
            // 
            this.btnConsonants.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsonants.Location = new System.Drawing.Point(24, 120);
            this.btnConsonants.Name = "btnConsonants";
            this.btnConsonants.Size = new System.Drawing.Size(144, 32);
            this.btnConsonants.TabIndex = 4;
            this.btnConsonants.Text = "Select  consonants";
            this.btnConsonants.UseVisualStyleBackColor = true;
            this.btnConsonants.Click += new System.EventHandler(this.btnConsonants_Click);
            // 
            // tbConsonants
            // 
            this.tbConsonants.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConsonants.Location = new System.Drawing.Point(196, 120);
            this.tbConsonants.Multiline = true;
            this.tbConsonants.Name = "tbConsonants";
            this.tbConsonants.ReadOnly = true;
            this.tbConsonants.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbConsonants.Size = new System.Drawing.Size(540, 72);
            this.tbConsonants.TabIndex = 5;
            // 
            // btnVowels
            // 
            this.btnVowels.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVowels.Location = new System.Drawing.Point(24, 220);
            this.btnVowels.Name = "btnVowels";
            this.btnVowels.Size = new System.Drawing.Size(144, 32);
            this.btnVowels.TabIndex = 6;
            this.btnVowels.Text = "Select  vowels";
            this.btnVowels.UseVisualStyleBackColor = true;
            this.btnVowels.Click += new System.EventHandler(this.btnVowels_Click);
            // 
            // btnTones
            // 
            this.btnTones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTones.Location = new System.Drawing.Point(24, 320);
            this.btnTones.Name = "btnTones";
            this.btnTones.Size = new System.Drawing.Size(144, 32);
            this.btnTones.TabIndex = 8;
            this.btnTones.Text = "Select tones";
            this.btnTones.UseVisualStyleBackColor = true;
            this.btnTones.Click += new System.EventHandler(this.btnTones_Click);
            // 
            // btnMulti
            // 
            this.btnMulti.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMulti.Location = new System.Drawing.Point(24, 420);
            this.btnMulti.Name = "btnMulti";
            this.btnMulti.Size = new System.Drawing.Size(240, 32);
            this.btnMulti.TabIndex = 10;
            this.btnMulti.Text = "Select multi-graphs";
            this.btnMulti.UseVisualStyleBackColor = true;
            this.btnMulti.Click += new System.EventHandler(this.btnMulti_Click);
            // 
            // tbVowels
            // 
            this.tbVowels.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVowels.Location = new System.Drawing.Point(196, 220);
            this.tbVowels.Multiline = true;
            this.tbVowels.Name = "tbVowels";
            this.tbVowels.ReadOnly = true;
            this.tbVowels.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbVowels.Size = new System.Drawing.Size(540, 72);
            this.tbVowels.TabIndex = 7;
            // 
            // tbTones
            // 
            this.tbTones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTones.Location = new System.Drawing.Point(196, 311);
            this.tbTones.Multiline = true;
            this.tbTones.Name = "tbTones";
            this.tbTones.ReadOnly = true;
            this.tbTones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbTones.Size = new System.Drawing.Size(540, 72);
            this.tbTones.TabIndex = 9;
            // 
            // FormInitGraphemeInventoryWL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 461);
            this.Controls.Add(this.tbTones);
            this.Controls.Add(this.tbVowels);
            this.Controls.Add(this.btnMulti);
            this.Controls.Add(this.btnTones);
            this.Controls.Add(this.btnVowels);
            this.Controls.Add(this.tbConsonants);
            this.Controls.Add(this.btnConsonants);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbWLType);
            this.Controls.Add(this.btnWLFile);
            this.Controls.Add(this.tbWLFile);
            this.Controls.Add(this.labWLFile);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormInitGraphemeInventoryWL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Initialize Grapheme Inventory from Word List";
            this.gbWLType.ResumeLayout(false);
            this.gbWLType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWLFile;
        private System.Windows.Forms.TextBox tbWLFile;
        private System.Windows.Forms.Label labWLFile;
        private System.Windows.Forms.GroupBox gbWLType;
        private System.Windows.Forms.RadioButton rbLIft;
        private System.Windows.Forms.RadioButton rbSFM;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnConsonants;
        private System.Windows.Forms.TextBox tbConsonants;
        private System.Windows.Forms.Button btnVowels;
        private System.Windows.Forms.Button btnTones;
        private System.Windows.Forms.Button btnMulti;
        private System.Windows.Forms.TextBox tbVowels;
        private System.Windows.Forms.TextBox tbTones;
    }
}
namespace PrimerProForms
{
    partial class FormTeachingOrder
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
            this.ckConsonant = new System.Windows.Forms.CheckBox();
            this.ckVowel = new System.Windows.Forms.CheckBox();
            this.ckTone = new System.Windows.Forms.CheckBox();
            this.ckSyllograph = new System.Windows.Forms.CheckBox();
            this.labTitle = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbSyllograph = new System.Windows.Forms.GroupBox();
            this.rbNone = new System.Windows.Forms.RadioButton();
            this.rbTertiary = new System.Windows.Forms.RadioButton();
            this.rbSecondary = new System.Windows.Forms.RadioButton();
            this.rbPrimary = new System.Windows.Forms.RadioButton();
            this.ckIgnoreTone = new System.Windows.Forms.CheckBox();
            this.gbSyllograph.SuspendLayout();
            this.SuspendLayout();
            // 
            // ckConsonant
            // 
            this.ckConsonant.AutoSize = true;
            this.ckConsonant.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckConsonant.Location = new System.Drawing.Point(40, 52);
            this.ckConsonant.Margin = new System.Windows.Forms.Padding(2);
            this.ckConsonant.Name = "ckConsonant";
            this.ckConsonant.Size = new System.Drawing.Size(85, 19);
            this.ckConsonant.TabIndex = 1;
            this.ckConsonant.Text = "Consonant";
            this.ckConsonant.UseVisualStyleBackColor = true;
            // 
            // ckVowel
            // 
            this.ckVowel.AutoSize = true;
            this.ckVowel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckVowel.Location = new System.Drawing.Point(40, 116);
            this.ckVowel.Margin = new System.Windows.Forms.Padding(2);
            this.ckVowel.Name = "ckVowel";
            this.ckVowel.Size = new System.Drawing.Size(59, 19);
            this.ckVowel.TabIndex = 3;
            this.ckVowel.Text = "Vowel";
            this.ckVowel.UseVisualStyleBackColor = true;
            // 
            // ckTone
            // 
            this.ckTone.AutoSize = true;
            this.ckTone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckTone.Location = new System.Drawing.Point(40, 84);
            this.ckTone.Margin = new System.Windows.Forms.Padding(2);
            this.ckTone.Name = "ckTone";
            this.ckTone.Size = new System.Drawing.Size(54, 19);
            this.ckTone.TabIndex = 2;
            this.ckTone.Text = "Tone";
            this.ckTone.UseVisualStyleBackColor = true;
            // 
            // ckSyllograph
            // 
            this.ckSyllograph.AutoSize = true;
            this.ckSyllograph.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckSyllograph.Location = new System.Drawing.Point(160, 52);
            this.ckSyllograph.Margin = new System.Windows.Forms.Padding(2);
            this.ckSyllograph.Name = "ckSyllograph";
            this.ckSyllograph.Size = new System.Drawing.Size(84, 19);
            this.ckSyllograph.TabIndex = 4;
            this.ckSyllograph.Text = "Syllograph";
            this.ckSyllograph.UseVisualStyleBackColor = true;
            this.ckSyllograph.CheckedChanged += new System.EventHandler(this.ckSyllograph_CheckedChanged);
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTitle.Location = new System.Drawing.Point(20, 20);
            this.labTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(398, 15);
            this.labTitle.TabIndex = 0;
            this.labTitle.Text = "Indicate which grapheme types you want to include in the teaching order";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(223, 160);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 32);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(369, 160);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 32);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gbSyllograph
            // 
            this.gbSyllograph.Controls.Add(this.rbNone);
            this.gbSyllograph.Controls.Add(this.rbTertiary);
            this.gbSyllograph.Controls.Add(this.rbSecondary);
            this.gbSyllograph.Controls.Add(this.rbPrimary);
            this.gbSyllograph.Location = new System.Drawing.Point(160, 84);
            this.gbSyllograph.Name = "gbSyllograph";
            this.gbSyllograph.Size = new System.Drawing.Size(284, 51);
            this.gbSyllograph.TabIndex = 5;
            this.gbSyllograph.TabStop = false;
            this.gbSyllograph.Text = "Syllograph Category Grouping";
            // 
            // rbNone
            // 
            this.rbNone.AutoSize = true;
            this.rbNone.Location = new System.Drawing.Point(6, 19);
            this.rbNone.Name = "rbNone";
            this.rbNone.Size = new System.Drawing.Size(51, 17);
            this.rbNone.TabIndex = 0;
            this.rbNone.TabStop = true;
            this.rbNone.Text = "None";
            this.rbNone.UseVisualStyleBackColor = true;
            // 
            // rbTertiary
            // 
            this.rbTertiary.AutoSize = true;
            this.rbTertiary.Location = new System.Drawing.Point(210, 19);
            this.rbTertiary.Name = "rbTertiary";
            this.rbTertiary.Size = new System.Drawing.Size(60, 17);
            this.rbTertiary.TabIndex = 3;
            this.rbTertiary.TabStop = true;
            this.rbTertiary.Text = "Tertiary";
            this.rbTertiary.UseVisualStyleBackColor = true;
            // 
            // rbSecondary
            // 
            this.rbSecondary.AutoSize = true;
            this.rbSecondary.Location = new System.Drawing.Point(128, 19);
            this.rbSecondary.Name = "rbSecondary";
            this.rbSecondary.Size = new System.Drawing.Size(76, 17);
            this.rbSecondary.TabIndex = 2;
            this.rbSecondary.TabStop = true;
            this.rbSecondary.Text = "Secondary";
            this.rbSecondary.UseVisualStyleBackColor = true;
            // 
            // rbPrimary
            // 
            this.rbPrimary.AutoSize = true;
            this.rbPrimary.Location = new System.Drawing.Point(63, 19);
            this.rbPrimary.Name = "rbPrimary";
            this.rbPrimary.Size = new System.Drawing.Size(59, 17);
            this.rbPrimary.TabIndex = 1;
            this.rbPrimary.TabStop = true;
            this.rbPrimary.Text = "Primary";
            this.rbPrimary.UseVisualStyleBackColor = true;
            // 
            // ckIgnoreTone
            // 
            this.ckIgnoreTone.AutoSize = true;
            this.ckIgnoreTone.Location = new System.Drawing.Point(40, 160);
            this.ckIgnoreTone.Name = "ckIgnoreTone";
            this.ckIgnoreTone.Size = new System.Drawing.Size(84, 17);
            this.ckIgnoreTone.TabIndex = 6;
            this.ckIgnoreTone.Text = "Ignore Tone";
            this.ckIgnoreTone.UseVisualStyleBackColor = true;
            this.ckIgnoreTone.CheckedChanged += new System.EventHandler(this.ckIgnoreTone_CheckedChanged);
            // 
            // FormTeachingOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 219);
            this.Controls.Add(this.ckIgnoreTone);
            this.Controls.Add(this.gbSyllograph);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labTitle);
            this.Controls.Add(this.ckSyllograph);
            this.Controls.Add(this.ckTone);
            this.Controls.Add(this.ckVowel);
            this.Controls.Add(this.ckConsonant);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormTeachingOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Teaching Order Search";
            this.gbSyllograph.ResumeLayout(false);
            this.gbSyllograph.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckConsonant;
        private System.Windows.Forms.CheckBox ckVowel;
        private System.Windows.Forms.CheckBox ckTone;
        private System.Windows.Forms.CheckBox ckSyllograph;
        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbSyllograph;
        private System.Windows.Forms.RadioButton rbTertiary;
        private System.Windows.Forms.RadioButton rbSecondary;
        private System.Windows.Forms.RadioButton rbPrimary;
        private System.Windows.Forms.RadioButton rbNone;
        private System.Windows.Forms.CheckBox ckIgnoreTone;
    }
}
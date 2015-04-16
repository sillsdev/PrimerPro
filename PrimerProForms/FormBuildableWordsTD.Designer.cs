namespace PrimerProForms
{
    partial class FormBuildableWordsTD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBuildableWordsTD));
            this.labTitle = new System.Windows.Forms.Label();
            this.tbHighlights = new System.Windows.Forms.TextBox();
            this.tbGraphemes = new System.Windows.Forms.TextBox();
            this.labGrapheme = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.chkParaFmt = new System.Windows.Forms.CheckBox();
            this.btnGraphemes = new System.Windows.Forms.Button();
            this.btnHighlight = new System.Windows.Forms.Button();
            this.labHighlight = new System.Windows.Forms.Label();
            this.chkNoDup = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labTitle
            // 
            this.labTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTitle.Location = new System.Drawing.Point(90, 13);
            this.labTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(510, 46);
            this.labTitle.TabIndex = 0;
            this.labTitle.Text = "List only graphemes (consonants and vowels) which have been taught.  The grapheme" +
    "s should be separated by a space.  (e.g. p b m mp mb mpw mbw a e i o u aa)";
            // 
            // tbHighlights
            // 
            this.tbHighlights.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHighlights.Location = new System.Drawing.Point(322, 106);
            this.tbHighlights.Margin = new System.Windows.Forms.Padding(2);
            this.tbHighlights.Name = "tbHighlights";
            this.tbHighlights.Size = new System.Drawing.Size(188, 21);
            this.tbHighlights.TabIndex = 5;
            // 
            // tbGraphemes
            // 
            this.tbGraphemes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGraphemes.Location = new System.Drawing.Point(93, 68);
            this.tbGraphemes.Margin = new System.Windows.Forms.Padding(2);
            this.tbGraphemes.Name = "tbGraphemes";
            this.tbGraphemes.Size = new System.Drawing.Size(418, 21);
            this.tbGraphemes.TabIndex = 2;
            // 
            // labGrapheme
            // 
            this.labGrapheme.AutoEllipsis = true;
            this.labGrapheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labGrapheme.Location = new System.Drawing.Point(18, 68);
            this.labGrapheme.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labGrapheme.Name = "labGrapheme";
            this.labGrapheme.Size = new System.Drawing.Size(78, 20);
            this.labGrapheme.TabIndex = 1;
            this.labGrapheme.Text = "Graphemes";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(589, 195);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 26);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(499, 195);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 26);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // chkParaFmt
            // 
            this.chkParaFmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkParaFmt.Location = new System.Drawing.Point(93, 150);
            this.chkParaFmt.Margin = new System.Windows.Forms.Padding(2);
            this.chkParaFmt.Name = "chkParaFmt";
            this.chkParaFmt.Size = new System.Drawing.Size(204, 20);
            this.chkParaFmt.TabIndex = 7;
            this.chkParaFmt.Text = "Display in &paragraph format";
            this.chkParaFmt.CheckedChanged += new System.EventHandler(this.chkParaFmt_CheckedChanged);
            // 
            // btnGraphemes
            // 
            this.btnGraphemes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGraphemes.Location = new System.Drawing.Point(525, 68);
            this.btnGraphemes.Margin = new System.Windows.Forms.Padding(2);
            this.btnGraphemes.Name = "btnGraphemes";
            this.btnGraphemes.Size = new System.Drawing.Size(135, 26);
            this.btnGraphemes.TabIndex = 3;
            this.btnGraphemes.Text = "Item Selection";
            this.btnGraphemes.UseVisualStyleBackColor = true;
            this.btnGraphemes.Click += new System.EventHandler(this.btnGraphemes_Click);
            // 
            // btnHighlight
            // 
            this.btnHighlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHighlight.Location = new System.Drawing.Point(525, 106);
            this.btnHighlight.Margin = new System.Windows.Forms.Padding(2);
            this.btnHighlight.Name = "btnHighlight";
            this.btnHighlight.Size = new System.Drawing.Size(135, 26);
            this.btnHighlight.TabIndex = 6;
            this.btnHighlight.Text = "Item Selection";
            this.btnHighlight.UseVisualStyleBackColor = true;
            this.btnHighlight.Click += new System.EventHandler(this.btnHighlight_Click);
            // 
            // labHighlight
            // 
            this.labHighlight.AutoEllipsis = true;
            this.labHighlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labHighlight.Location = new System.Drawing.Point(18, 105);
            this.labHighlight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labHighlight.Name = "labHighlight";
            this.labHighlight.Size = new System.Drawing.Size(278, 20);
            this.labHighlight.TabIndex = 4;
            this.labHighlight.Text = "Highlight words with these graphemes";
            this.labHighlight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkNoDup
            // 
            this.chkNoDup.AutoSize = true;
            this.chkNoDup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNoDup.Location = new System.Drawing.Point(93, 195);
            this.chkNoDup.Margin = new System.Windows.Forms.Padding(2);
            this.chkNoDup.Name = "chkNoDup";
            this.chkNoDup.Size = new System.Drawing.Size(103, 19);
            this.chkNoDup.TabIndex = 10;
            this.chkNoDup.Text = "No Duplicates";
            this.chkNoDup.UseVisualStyleBackColor = true;
            this.chkNoDup.CheckedChanged += new System.EventHandler(this.chkNoDup_CheckedChanged);
            // 
            // FormBuildableWordsTD
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(676, 230);
            this.Controls.Add(this.chkNoDup);
            this.Controls.Add(this.labHighlight);
            this.Controls.Add(this.btnHighlight);
            this.Controls.Add(this.btnGraphemes);
            this.Controls.Add(this.chkParaFmt);
            this.Controls.Add(this.tbHighlights);
            this.Controls.Add(this.tbGraphemes);
            this.Controls.Add(this.labGrapheme);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormBuildableWordsTD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Buildable Words Search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.TextBox tbHighlights;
        private System.Windows.Forms.TextBox tbGraphemes;
        private System.Windows.Forms.Label labGrapheme;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox chkParaFmt;
        private System.Windows.Forms.Button btnGraphemes;
        private System.Windows.Forms.Button btnHighlight;
        private System.Windows.Forms.Label labHighlight;
        private System.Windows.Forms.CheckBox chkNoDup;
    }
}
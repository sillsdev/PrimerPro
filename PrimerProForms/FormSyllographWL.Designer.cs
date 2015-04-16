namespace PrimerProForms
{
    partial class FormSyllographWL
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
            this.lblSyllograph = new System.Windows.Forms.Label();
            this.tbSyllograph = new System.Windows.Forms.TextBox();
            this.btnFeatures = new System.Windows.Forms.Button();
            this.btnSO = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkGraphemesTaught = new System.Windows.Forms.CheckBox();
            this.chkBrowseView = new System.Windows.Forms.CheckBox();
            this.lblFeatures = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSyllograph
            // 
            this.lblSyllograph.AutoSize = true;
            this.lblSyllograph.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSyllograph.Location = new System.Drawing.Point(20, 20);
            this.lblSyllograph.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSyllograph.Name = "lblSyllograph";
            this.lblSyllograph.Size = new System.Drawing.Size(65, 15);
            this.lblSyllograph.TabIndex = 0;
            this.lblSyllograph.Text = "Syllograph";
            // 
            // tbSyllograph
            // 
            this.tbSyllograph.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSyllograph.Location = new System.Drawing.Point(100, 20);
            this.tbSyllograph.Margin = new System.Windows.Forms.Padding(2);
            this.tbSyllograph.Name = "tbSyllograph";
            this.tbSyllograph.Size = new System.Drawing.Size(76, 21);
            this.tbSyllograph.TabIndex = 1;
            this.tbSyllograph.TextChanged += new System.EventHandler(this.tbSyllograph_TextChanged);
            // 
            // btnFeatures
            // 
            this.btnFeatures.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFeatures.Location = new System.Drawing.Point(20, 60);
            this.btnFeatures.Margin = new System.Windows.Forms.Padding(2);
            this.btnFeatures.Name = "btnFeatures";
            this.btnFeatures.Size = new System.Drawing.Size(120, 32);
            this.btnFeatures.TabIndex = 2;
            this.btnFeatures.Text = "Choose features";
            this.btnFeatures.UseVisualStyleBackColor = true;
            this.btnFeatures.Click += new System.EventHandler(this.btnFeatures_Click);
            // 
            // btnSO
            // 
            this.btnSO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSO.Location = new System.Drawing.Point(20, 140);
            this.btnSO.Margin = new System.Windows.Forms.Padding(2);
            this.btnSO.Name = "btnSO";
            this.btnSO.Size = new System.Drawing.Size(120, 32);
            this.btnSO.TabIndex = 3;
            this.btnSO.Text = "Search options";
            this.btnSO.UseVisualStyleBackColor = true;
            this.btnSO.Click += new System.EventHandler(this.btnSO_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(200, 140);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 32);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(293, 140);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 32);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkGraphemesTaught
            // 
            this.chkGraphemesTaught.AutoSize = true;
            this.chkGraphemesTaught.Location = new System.Drawing.Point(200, 60);
            this.chkGraphemesTaught.Margin = new System.Windows.Forms.Padding(2);
            this.chkGraphemesTaught.Name = "chkGraphemesTaught";
            this.chkGraphemesTaught.Size = new System.Drawing.Size(168, 17);
            this.chkGraphemesTaught.TabIndex = 6;
            this.chkGraphemesTaught.Text = "&Restrict to Graphemes Taught";
            this.chkGraphemesTaught.UseVisualStyleBackColor = true;
            // 
            // chkBrowseView
            // 
            this.chkBrowseView.AutoSize = true;
            this.chkBrowseView.Location = new System.Drawing.Point(200, 100);
            this.chkBrowseView.Margin = new System.Windows.Forms.Padding(2);
            this.chkBrowseView.Name = "chkBrowseView";
            this.chkBrowseView.Size = new System.Drawing.Size(135, 17);
            this.chkBrowseView.TabIndex = 7;
            this.chkBrowseView.Text = "Display in &Browse View";
            this.chkBrowseView.UseVisualStyleBackColor = true;
            // 
            // lblFeatures
            // 
            this.lblFeatures.AutoSize = true;
            this.lblFeatures.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFeatures.Location = new System.Drawing.Point(20, 100);
            this.lblFeatures.Name = "lblFeatures";
            this.lblFeatures.Size = new System.Drawing.Size(35, 15);
            this.lblFeatures.TabIndex = 8;
            this.lblFeatures.Text = "none";
            // 
            // FormSyllographWL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 198);
            this.Controls.Add(this.lblFeatures);
            this.Controls.Add(this.chkBrowseView);
            this.Controls.Add(this.chkGraphemesTaught);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnSO);
            this.Controls.Add(this.btnFeatures);
            this.Controls.Add(this.tbSyllograph);
            this.Controls.Add(this.lblSyllograph);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormSyllographWL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Syllograph Search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSyllograph;
        private System.Windows.Forms.TextBox tbSyllograph;
        private System.Windows.Forms.Button btnFeatures;
        private System.Windows.Forms.Button btnSO;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkGraphemesTaught;
        private System.Windows.Forms.CheckBox chkBrowseView;
        private System.Windows.Forms.Label lblFeatures;
    }
}
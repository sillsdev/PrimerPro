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
            this.gbSort2 = new System.Windows.Forms.GroupBox();
            this.rbAscending = new System.Windows.Forms.RadioButton();
            this.rbDescending = new System.Windows.Forms.RadioButton();
            this.gbSort.SuspendLayout();
            this.gbSort2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSort
            // 
            this.gbSort.Controls.Add(this.rbNumer);
            this.gbSort.Controls.Add(this.rbAlpha);
            this.gbSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSort.Location = new System.Drawing.Point(37, 20);
            this.gbSort.Margin = new System.Windows.Forms.Padding(2);
            this.gbSort.Name = "gbSort";
            this.gbSort.Padding = new System.Windows.Forms.Padding(2);
            this.gbSort.Size = new System.Drawing.Size(176, 78);
            this.gbSort.TabIndex = 0;
            this.gbSort.TabStop = false;
            this.gbSort.Text = "Sort Order";
            // 
            // rbNumer
            // 
            this.rbNumer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNumer.Location = new System.Drawing.Point(27, 44);
            this.rbNumer.Margin = new System.Windows.Forms.Padding(2);
            this.rbNumer.Name = "rbNumer";
            this.rbNumer.Size = new System.Drawing.Size(130, 20);
            this.rbNumer.TabIndex = 1;
            this.rbNumer.Text = "&Numerical";
            // 
            // rbAlpha
            // 
            this.rbAlpha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAlpha.Location = new System.Drawing.Point(27, 19);
            this.rbAlpha.Margin = new System.Windows.Forms.Padding(2);
            this.rbAlpha.Name = "rbAlpha";
            this.rbAlpha.Size = new System.Drawing.Size(130, 20);
            this.rbAlpha.TabIndex = 0;
            this.rbAlpha.Text = "&Alphabetical";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(237, 142);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 26);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(138, 142);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 26);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // chkIgnoreTone
            // 
            this.chkIgnoreTone.AutoSize = true;
            this.chkIgnoreTone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIgnoreTone.Location = new System.Drawing.Point(18, 110);
            this.chkIgnoreTone.Margin = new System.Windows.Forms.Padding(2);
            this.chkIgnoreTone.Name = "chkIgnoreTone";
            this.chkIgnoreTone.Size = new System.Drawing.Size(188, 19);
            this.chkIgnoreTone.TabIndex = 2;
            this.chkIgnoreTone.Text = "&Ignore syllograph in Text Data";
            this.chkIgnoreTone.UseVisualStyleBackColor = true;
            // 
            // gbSort2
            // 
            this.gbSort2.Controls.Add(this.rbAscending);
            this.gbSort2.Controls.Add(this.rbDescending);
            this.gbSort2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSort2.Location = new System.Drawing.Point(237, 20);
            this.gbSort2.Margin = new System.Windows.Forms.Padding(2);
            this.gbSort2.Name = "gbSort2";
            this.gbSort2.Padding = new System.Windows.Forms.Padding(2);
            this.gbSort2.Size = new System.Drawing.Size(176, 78);
            this.gbSort2.TabIndex = 1;
            this.gbSort2.TabStop = false;
            this.gbSort2.Text = "Sort By";
            // 
            // rbAscending
            // 
            this.rbAscending.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAscending.Location = new System.Drawing.Point(27, 19);
            this.rbAscending.Margin = new System.Windows.Forms.Padding(2);
            this.rbAscending.Name = "rbAscending";
            this.rbAscending.Size = new System.Drawing.Size(130, 20);
            this.rbAscending.TabIndex = 1;
            this.rbAscending.Text = "&Ascending";
            // 
            // rbDescending
            // 
            this.rbDescending.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDescending.Location = new System.Drawing.Point(27, 44);
            this.rbDescending.Margin = new System.Windows.Forms.Padding(2);
            this.rbDescending.Name = "rbDescending";
            this.rbDescending.Size = new System.Drawing.Size(130, 20);
            this.rbDescending.TabIndex = 0;
            this.rbDescending.Text = "&Desending";
            // 
            // FormWordCount
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(445, 198);
            this.Controls.Add(this.gbSort2);
            this.Controls.Add(this.chkIgnoreTone);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbSort);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormWordCount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Word Count Search";
            this.gbSort.ResumeLayout(false);
            this.gbSort2.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox gbSort2;
        private System.Windows.Forms.RadioButton rbAscending;
        private System.Windows.Forms.RadioButton rbDescending;
    }
}
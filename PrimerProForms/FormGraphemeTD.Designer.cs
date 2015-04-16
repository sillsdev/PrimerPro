using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace PrimerProForms
{
    /// <summary>
    /// Summary description for FormGraphemeTD
    /// </summary>
    public partial class FormGraphemeTD : System.Windows.Forms.Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

  
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGraphemeTD));
            this.labGraphemes = new System.Windows.Forms.Label();
            this.tbGraphemes = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.chkParaFmt = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkGraphemesTaught = new System.Windows.Forms.CheckBox();
            this.chkNoDup = new System.Windows.Forms.CheckBox();
            this.btnGraphemes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labGraphemes
            // 
            this.labGraphemes.AutoSize = true;
            this.labGraphemes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labGraphemes.Location = new System.Drawing.Point(24, 24);
            this.labGraphemes.Name = "labGraphemes";
            this.labGraphemes.Size = new System.Drawing.Size(108, 15);
            this.labGraphemes.TabIndex = 0;
            this.labGraphemes.Text = "Graphemes to find";
            this.labGraphemes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbGraphemes
            // 
            this.tbGraphemes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGraphemes.Location = new System.Drawing.Point(152, 24);
            this.tbGraphemes.Name = "tbGraphemes";
            this.tbGraphemes.Size = new System.Drawing.Size(171, 21);
            this.tbGraphemes.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(342, 117);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // chkParaFmt
            // 
            this.chkParaFmt.AutoSize = true;
            this.chkParaFmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkParaFmt.Location = new System.Drawing.Point(24, 80);
            this.chkParaFmt.Name = "chkParaFmt";
            this.chkParaFmt.Size = new System.Drawing.Size(177, 19);
            this.chkParaFmt.TabIndex = 2;
            this.chkParaFmt.Text = "Display in &paragraph format";
            this.chkParaFmt.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(342, 172);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkGraphemesTaught
            // 
            this.chkGraphemesTaught.AutoSize = true;
            this.chkGraphemesTaught.Location = new System.Drawing.Point(24, 130);
            this.chkGraphemesTaught.Name = "chkGraphemesTaught";
            this.chkGraphemesTaught.Size = new System.Drawing.Size(189, 19);
            this.chkGraphemesTaught.TabIndex = 4;
            this.chkGraphemesTaught.Text = "&Restrict to Graphemes Taught";
            this.chkGraphemesTaught.UseVisualStyleBackColor = true;
            // 
            // chkNoDup
            // 
            this.chkNoDup.AutoSize = true;
            this.chkNoDup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNoDup.Location = new System.Drawing.Point(24, 180);
            this.chkNoDup.Margin = new System.Windows.Forms.Padding(2);
            this.chkNoDup.Name = "chkNoDup";
            this.chkNoDup.Size = new System.Drawing.Size(103, 19);
            this.chkNoDup.TabIndex = 5;
            this.chkNoDup.Text = "No Duplicates";
            this.chkNoDup.UseVisualStyleBackColor = true;
            this.chkNoDup.CheckedChanged += new System.EventHandler(this.chkNoDup_CheckedChanged);
            // 
            // btnGraphemes
            // 
            this.btnGraphemes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGraphemes.Location = new System.Drawing.Point(342, 24);
            this.btnGraphemes.Name = "btnGraphemes";
            this.btnGraphemes.Size = new System.Drawing.Size(150, 32);
            this.btnGraphemes.TabIndex = 8;
            this.btnGraphemes.Text = "Item Selection";
            this.btnGraphemes.UseVisualStyleBackColor = true;
            this.btnGraphemes.Click += new System.EventHandler(this.btnGraphemes_Click);
            // 
            // FormGraphemeTD
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(520, 241);
            this.Controls.Add(this.btnGraphemes);
            this.Controls.Add(this.chkNoDup);
            this.Controls.Add(this.chkGraphemesTaught);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.chkParaFmt);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbGraphemes);
            this.Controls.Add(this.labGraphemes);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormGraphemeTD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GraphemeSearch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labGraphemes;
        private System.Windows.Forms.TextBox tbGraphemes;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox chkParaFmt;
        private System.Windows.Forms.Button btnCancel;
        private CheckBox chkGraphemesTaught;
        private CheckBox chkNoDup;
        private Button btnGraphemes;
    }
}
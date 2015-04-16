using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using PrimerProObjects;
using PrimerProLocalization;

namespace PrimerProForms
{
	/// <summary>
	/// Summary description for AboutPTEST.
	/// </summary>
	public class FormAbout : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblProgName;
		private System.Windows.Forms.Label labCopyright;
        private Label labDate;
        private LinkLabel lnkLicense;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public FormAbout()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public FormAbout(LocalizationTable table, string lang)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            //this.Text = table.GetForm("FormAboutT", lang);
            //this.labDate.Text = table.GetForm("FormAbout2", lang);
            //this.labCopyright.Text = table.GetForm("FormAbout3", lang);
            //this.btnOK.Text = table.GetForm("FormAbout4", lang);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.Windows.Forms.Label labVersion;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            this.btnOK = new System.Windows.Forms.Button();
            this.lblProgName = new System.Windows.Forms.Label();
            this.labCopyright = new System.Windows.Forms.Label();
            this.labDate = new System.Windows.Forms.Label();
            this.lnkLicense = new System.Windows.Forms.LinkLabel();
            labVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labVersion
            // 
            labVersion.BackColor = System.Drawing.Color.Transparent;
            labVersion.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labVersion.ForeColor = System.Drawing.SystemColors.WindowText;
            labVersion.Location = new System.Drawing.Point(50, 70);
            labVersion.Name = "labVersion";
            labVersion.Size = new System.Drawing.Size(360, 32);
            labVersion.TabIndex = 1;
            labVersion.Text = "PrimerPro Version 2.41";
            labVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.Menu;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(180, 229);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblProgName
            // 
            this.lblProgName.BackColor = System.Drawing.Color.Transparent;
            this.lblProgName.Font = new System.Drawing.Font("Forte", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblProgName.Location = new System.Drawing.Point(50, 30);
            this.lblProgName.Name = "lblProgName";
            this.lblProgName.Size = new System.Drawing.Size(360, 36);
            this.lblProgName.TabIndex = 0;
            this.lblProgName.Text = "PrimerPro";
            this.lblProgName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labCopyright
            // 
            this.labCopyright.BackColor = System.Drawing.Color.Transparent;
            this.labCopyright.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCopyright.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.labCopyright.Location = new System.Drawing.Point(50, 156);
            this.labCopyright.Name = "labCopyright";
            this.labCopyright.Size = new System.Drawing.Size(360, 50);
            this.labCopyright.TabIndex = 3;
            this.labCopyright.Text = "(c) 2007-2015 SIL International.  This software is licensed acording to the terms" +
    " of the MIT license.\r\n\r\n\r\n";
            this.labCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labDate
            // 
            this.labDate.BackColor = System.Drawing.Color.Transparent;
            this.labDate.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.labDate.Location = new System.Drawing.Point(50, 110);
            this.labDate.Name = "labDate";
            this.labDate.Size = new System.Drawing.Size(360, 32);
            this.labDate.TabIndex = 2;
            this.labDate.Text = "March 2015";
            this.labDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lnkLicense
            // 
            this.lnkLicense.AutoSize = true;
            this.lnkLicense.Location = new System.Drawing.Point(193, 206);
            this.lnkLicense.Name = "lnkLicense";
            this.lnkLicense.Size = new System.Drawing.Size(74, 15);
            this.lnkLicense.TabIndex = 4;
            this.lnkLicense.TabStop = true;
            this.lnkLicense.Text = "MIT License";
            this.lnkLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLicense_LinkClicked);
            // 
            // FormAbout
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(465, 284);
            this.Controls.Add(this.lnkLicense);
            this.Controls.Add(this.labDate);
            this.Controls.Add(this.labCopyright);
            this.Controls.Add(labVersion);
            this.Controls.Add(this.lblProgName);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "FormAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.Load += new System.EventHandler(this.FormAbout_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
            
			Form.ActiveForm.Close();
		}

        private void FormAbout_Load(object sender, EventArgs e)
        {

        }

        private void lnkLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                lnkLicense.LinkVisited = true;
                System.Diagnostics.Process.Start("http://sil.mit-license.org/");
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                MessageBox.Show("Unable to open link that was clicked: " + str);
            }
        }

	}
}

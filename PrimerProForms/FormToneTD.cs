using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using PrimerProObjects;
using PrimerProLocalization;

namespace PrimerProForms
{
	/// <summary>
	/// Summary description for FormToneTD.
	/// </summary>
	public class FormToneTD : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label labTones;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private System.Windows.Forms.CheckBox chkParaFmt;
        private Button btnUncheck;
        private Button btnCheck;
        private CheckedListBox clbTones;

        private ArrayList m_SelectedTones;
        private bool m_ParaFormat;

		public FormToneTD(GraphemeInventory gi, Font fnt)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			for (int i = 0; i < gi.ToneCount(); i++)
			{
                this.clbTones.Items.Add(gi.GetTone(i).Symbol);
			}
            this.clbTones.Font = fnt;
		}

        public FormToneTD(GraphemeInventory gi, Font fnt, LocalizationTable table, string lang)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            for (int i = 0; i < gi.ToneCount(); i++)
            {
                this.clbTones.Items.Add(gi.GetTone(i).Symbol);
            }
            this.clbTones.Font = fnt;

            this.Text = table.GetForm("FormToneTDT", lang);
            this.labTones.Text = table.GetForm("FormToneTD0", lang);
            this.chkParaFmt.Text = table.GetForm("FormToneTD2", lang);
            this.btnCheck.Text = table.GetForm("FormToneTD3", lang);
            this.btnUncheck.Text = table.GetForm("FormToneTD4", lang);
            this.btnOK.Text = table.GetForm("FormToneTD5", lang);
            this.btnCancel.Text = table.GetForm("FormToneTD6", lang);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormToneTD));
            this.labTones = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.chkParaFmt = new System.Windows.Forms.CheckBox();
            this.btnUncheck = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.clbTones = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // labTones
            // 
            this.labTones.AutoSize = true;
            this.labTones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTones.Location = new System.Drawing.Point(20, 21);
            this.labTones.Name = "labTones";
            this.labTones.Size = new System.Drawing.Size(110, 15);
            this.labTones.TabIndex = 0;
            this.labTones.Text = "Select tones to find";
            this.labTones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(333, 225);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 28);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(221, 225);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(83, 28);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // chkParaFmt
            // 
            this.chkParaFmt.AutoSize = true;
            this.chkParaFmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkParaFmt.Location = new System.Drawing.Point(207, 47);
            this.chkParaFmt.Name = "chkParaFmt";
            this.chkParaFmt.Size = new System.Drawing.Size(177, 19);
            this.chkParaFmt.TabIndex = 2;
            this.chkParaFmt.Text = "Display in &paragraph format";
            // 
            // btnUncheck
            // 
            this.btnUncheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUncheck.Location = new System.Drawing.Point(333, 113);
            this.btnUncheck.Name = "btnUncheck";
            this.btnUncheck.Size = new System.Drawing.Size(125, 27);
            this.btnUncheck.TabIndex = 4;
            this.btnUncheck.Text = "&Uncheck All";
            this.btnUncheck.UseVisualStyleBackColor = true;
            this.btnUncheck.Click += new System.EventHandler(this.btnUncheck_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.Location = new System.Drawing.Point(193, 113);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(125, 27);
            this.btnCheck.TabIndex = 3;
            this.btnCheck.Text = "&Check All";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // clbTones
            // 
            this.clbTones.CheckOnClick = true;
            this.clbTones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbTones.FormattingEnabled = true;
            this.clbTones.HorizontalScrollbar = true;
            this.clbTones.Location = new System.Drawing.Point(22, 47);
            this.clbTones.Name = "clbTones";
            this.clbTones.Size = new System.Drawing.Size(158, 196);
            this.clbTones.TabIndex = 1;
            this.clbTones.TabStop = false;
            // 
            // FormToneTD
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(569, 311);
            this.Controls.Add(this.clbTones);
            this.Controls.Add(this.btnUncheck);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.chkParaFmt);
            this.Controls.Add(this.labTones);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormToneTD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tone Search";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        public ArrayList SelectedTones
        {
            get {return m_SelectedTones;}
        }
        
        public bool ParaFormat
        {
            get {return m_ParaFormat;}
        }

		private void btnOK_Click(object sender, System.EventArgs e)
		{
            m_SelectedTones = new ArrayList();
            if (this.clbTones.CheckedItems.Count > 0)
            {
                string strTone = "";
                foreach (object obj in clbTones.CheckedItems)
                {
                    strTone = obj.ToString();
                    m_SelectedTones.Add(strTone);
                }
            }
			m_ParaFormat = chkParaFmt.Checked;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
            m_SelectedTones = null;
			m_ParaFormat = false;
			this.Close();
		}

        private void btnCheck_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbTones.Items.Count; i++)
                clbTones.SetItemChecked(i, true);
            clbTones.Show();
        }

        private void btnUncheck_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbTones.Items.Count; i++)
                clbTones.SetItemChecked(i, false);
            clbTones.Show();
        }
    
    }
}

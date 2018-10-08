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
	/// Summary description for FormSightWords.
	/// </summary>
	public class FormSightWords : System.Windows.Forms.Form
	{
        //private Settings m_Settings;
        private SightWords m_SightWords;
        private Font m_Font;

		private System.Windows.Forms.TextBox tbWords;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label labInfo;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormSightWords(Settings s)
		{
			InitializeComponent();
            m_SightWords = s.SightWords;
            m_Font = s.OptionSettings.GetDefaultFont();
			// add sight words to textbox
			ArrayList al = m_SightWords.Words;
			tbWords.Text = "";
			for (int i = 0; i < al.Count; i++)
			{
				tbWords.Text += (string) al[i] + Environment.NewLine;
			}
            tbWords.Font = m_Font;
            tbWords.SelectionStart = tbWords.Text.Length;
            tbWords.SelectionLength = 0;
		}

        public FormSightWords(Settings s, LocalizationTable table)
        {
            InitializeComponent();
            m_SightWords = s.SightWords;
            m_Font = s.OptionSettings.GetDefaultFont();

            // add sight words to textbox
            ArrayList al = m_SightWords.Words;
            tbWords.Text = "";
            for (int i = 0; i < al.Count; i++)
            {
                tbWords.Text += (string)al[i] + Environment.NewLine;
            }
            tbWords.Font = m_Font;
            tbWords.SelectionStart = tbWords.Text.Length;
            tbWords.SelectionLength = 0;

            this.UpdateFormForLocalization(table);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSightWords));
            this.tbWords = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.labInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbWords
            // 
            this.tbWords.AcceptsReturn = true;
            this.tbWords.Location = new System.Drawing.Point(67, 85);
            this.tbWords.Multiline = true;
            this.tbWords.Name = "tbWords";
            this.tbWords.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbWords.Size = new System.Drawing.Size(250, 235);
            this.tbWords.TabIndex = 1;
            this.tbWords.WordWrap = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(217, 345);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(67, 345);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // labInfo
            // 
            this.labInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfo.Location = new System.Drawing.Point(24, 20);
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(330, 62);
            this.labInfo.TabIndex = 0;
            this.labInfo.Text = "Edit the list of sight words (use lower case graphemes only), one word per line";
            // 
            // FormSightWords
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 17);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(385, 393);
            this.Controls.Add(this.labInfo);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbWords);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSightWords";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Sight Words";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public SightWords SightWords
        {
            get {return m_SightWords;}
        }

        private void btnOK_Click(object sender, System.EventArgs e)
		{
			
			string strText = tbWords.Text;
			string strItem = "";
			string nl = Environment.NewLine;
			int nBeg = 0;
			int nEnd = 0;
			ArrayList al = null;

			al = new ArrayList();
			do
			{
				nEnd = strText.IndexOf(nl,nBeg);
				if (nEnd < 0)
					nEnd = strText.Length;
				strItem = strText.Substring(nBeg, nEnd - nBeg);
                strItem = strItem.Trim();
				if (strItem != "")
					al.Add(strItem);
				nBeg = nEnd + nl.Length;
			}
			while (nBeg < strText.Length);
			m_SightWords.Words = al;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
            this.Close();
		}

        private void UpdateFormForLocalization(LocalizationTable table)
        {
            string strText = "";
            strText = table.GetForm("FormSightWordsT");
			if (strText != "")
				this.Text = strText;
            strText = table.GetForm("FormSightWords0");
			if (strText != "")
				this.labInfo.Text = strText;
            strText = table.GetForm("FormSightWords2");
			if (strText != "")
				this.btnOK.Text = strText;
            strText = table.GetForm("FormSightWords3");
			if (strText != "")
				this.btnCancel.Text = strText;
            return;
        }

	}
}

using System;
using System.ComponentModel;
using System.Windows.Forms;
using PrimerProLocalization;

namespace PrimerProForms
{
    public partial class FormSyllableCount : Form
    {
        private bool m_AlphaSortOrder;
        private bool m_NumerSortOrder;
        private bool m_IgnoreTone;
        private bool m_UseGraphemesTaught;

        public FormSyllableCount()
        {
            InitializeComponent();
            this.rbAlpha.Checked = true;
            this.chkIgnoreTone.Checked = false;
            this.chkGraphemesTaught.Checked = false;
        }

        public FormSyllableCount(LocalizationTable table)
        {
            InitializeComponent();
            this.rbAlpha.Checked = true;
            this.chkIgnoreTone.Checked = false;
            this.chkGraphemesTaught.Checked = false;

            this.UpdateFormForLocalization(table);
        }

        public bool AlphaSortOrder
        {
            get { return m_AlphaSortOrder; }
        }

        public bool NumerSortOrder
        {
            get { return m_NumerSortOrder; }
        }

        public bool IgnoreTone
        {
            get { return m_IgnoreTone; }
        }

        public bool UseGraphemesTaught
        {
            get { return m_UseGraphemesTaught; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            m_AlphaSortOrder = this.rbAlpha.Checked;
            m_NumerSortOrder = this.rbNumer.Checked;
            m_IgnoreTone = this.chkIgnoreTone.Checked;
            m_UseGraphemesTaught = this.chkGraphemesTaught.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_AlphaSortOrder = false;
            m_NumerSortOrder = false;
            m_IgnoreTone = false;
            m_UseGraphemesTaught = false;
        }

        private void UpdateFormForLocalization(LocalizationTable table)
        {
            string strText = "";
            strText = table.GetForm("FormSyllableCountT");
			if (strText != "")
				this.Text = strText;
            strText = table.GetForm("FormSyllableCount0");
			if (strText != "")
				this.gbSort.Text = strText;
            strText = table.GetForm("FormSyllableCountS1");
			if (strText != "")
				this.rbAlpha.Text = strText;
            strText = table.GetForm("FormSyllableCountS2");
			if (strText != "")
				this.rbNumer.Text = strText;
            strText = table.GetForm("FormSyllableCount1");
			if (strText != "")
				this.chkIgnoreTone.Text = strText;
            strText = table.GetForm("FormSyllableCount3");
			if (strText != "")
				this.btnOK.Text = strText;
            strText = table.GetForm("FormSyllableCount4");
			if (strText != "")
				this.btnCancel.Text = strText;
            strText = table.GetForm("FormSyllableCount2");
			if (strText != "")
				this.chkGraphemesTaught.Text = strText;
            return;
        }
        
     }
}

using System;
using System.Windows.Forms;
using PrimerProLocalization;

namespace PrimerProForms
{
    public partial class FormFrequencyTD : Form
    {
        //private FrequencyTDSearch m_Search;         //Frequency Count Search calling form
        private bool m_IgnoreSightWords;
        private bool m_IgnoreTone;
        private bool m_DisplayPercentages;

        public FormFrequencyTD()
        {
            InitializeComponent();
        }

        public FormFrequencyTD(LocalizationTable table)
        {
            InitializeComponent();
            this.UpdateFormForLocalization(table);

        }

        public bool IgnoreSightWords
        {
            get { return m_IgnoreSightWords; }
        }

        public bool IgnoreTone
        {
            get { return m_IgnoreTone; }
        }

        public bool DisplayPercentages
        {
            get { return m_DisplayPercentages; }
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            m_IgnoreSightWords = this.chkIgnoreSightWords.Checked;
            m_IgnoreTone = this.chkIgnoreTone.Checked;
            m_DisplayPercentages = this.chkDisplayPercentages.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_IgnoreSightWords = false;
            m_IgnoreTone = false;
            m_DisplayPercentages = false;
            this.Close();
        }

        private void UpdateFormForLocalization(LocalizationTable table)
        {
            string strText = "";
            strText = table.GetForm("FormFrequencyTDT");
			if (strText != "")
				this.Text = strText;
            strText = table.GetForm("FormFrequencyTD0");
			if (strText != "")
				this.chkIgnoreSightWords.Text = strText;
            strText = table.GetForm("FormFrequencyTD1");
			if (strText != "")
				this.chkIgnoreTone.Text = strText;
            strText = table.GetForm("FormFrequencyTD2");
			if (strText != "")
				this.chkDisplayPercentages.Text = strText;
            strText = table.GetForm("FormFrequencyTD8");
			if (strText != "")
				this.btnOK.Text = strText;
            strText = table.GetForm("FormFrequencyTD9");
			if (strText != "")
				this.btnCancel.Text = strText;
            return;
        }

    }
}
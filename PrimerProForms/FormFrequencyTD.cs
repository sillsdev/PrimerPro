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

        public FormFrequencyTD(LocalizationTable table, string lang)
        {
            InitializeComponent();

            this.Text = table.GetForm("FormFrequencyTDT", lang);
            this.chkIgnoreSightWords.Text = table.GetForm("FormFrequencyTD0", lang);
            this.chkIgnoreTone.Text = table.GetForm("FormFrequencyTD1", lang);
            this.chkDisplayPercentages.Text = table.GetForm("FormFrequencyTD2", lang);
            this.btnOK.Text = table.GetForm("FormFrequencyTD8", lang);
            this.btnCancel.Text = table.GetForm("FormFrequencyTD9", lang);
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

    }
}
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

        public FormSyllableCount()
        {
            InitializeComponent();
            this.rbAlpha.Checked = true;
            this.chkIgnoreTone.Checked = false;
        }

        public FormSyllableCount(LocalizationTable table, string lang)
        {
            InitializeComponent();
            this.rbAlpha.Checked = true;
            this.chkIgnoreTone.Checked = false;

            this.Text = table.GetForm("FormSyllableCountT", lang);
            this.gbSort.Text = table.GetForm("FormSyllableCount0", lang);
            this.rbAlpha.Text = table.GetForm("FormSyllableCountS1", lang);
            this.rbNumer.Text = table.GetForm("FormSyllableCountS2", lang);
            this.chkIgnoreTone.Text = table.GetForm("FormSyllableCount1", lang);
            this.btnOK.Text = table.GetForm("FormSyllableCount2", lang);
            this.btnCancel.Text = table.GetForm("FormSyllableCount3", lang);
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            m_AlphaSortOrder = this.rbAlpha.Checked;
            m_NumerSortOrder = this.rbNumer.Checked;
            m_IgnoreTone = this.chkIgnoreTone.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_AlphaSortOrder = false;
            m_NumerSortOrder = false;
            m_IgnoreTone = false;
        }

     }
}

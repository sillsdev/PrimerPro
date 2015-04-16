using System;
using System.ComponentModel;
using System.Windows.Forms;
using PrimerProLocalization;

namespace PrimerProForms
{
    public partial class FormWordCount : Form
    {
        private bool m_AlphaOrder;
        private bool m_NumerOrder;
        private bool m_IgnoreTone;

        public FormWordCount()
        {
            InitializeComponent();
            this.rbAlpha.Checked = true;
            this.chkIgnoreTone.Checked = false;
        }

        public FormWordCount(LocalizationTable table, string lang)
        {
            InitializeComponent();
            this.rbAlpha.Checked = true;
            this.chkIgnoreTone.Checked = false;

            this.Text = table.GetForm("FormWordCountT", lang);
            this.gbSort.Text = table.GetForm("FormWordCount0", lang);
            this.rbAlpha.Text = table.GetForm("FormWordCountS0", lang);
            this.rbNumer.Text = table.GetForm("FormWordCountS1", lang);
            this.chkIgnoreTone.Text = table.GetForm("FormWordCount1", lang);
            this.btnOK.Text = table.GetForm("FormWordCount2", lang);
            this.btnCancel.Text = table.GetForm("FormWordCount3", lang);
        }

        public bool AlphaOrder
        {
            get { return m_AlphaOrder; }
        }

        public bool NumerOrder
        {
            get { return m_NumerOrder; }
        }

        public bool IgnoreTone
        {
            get { return m_IgnoreTone; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            m_AlphaOrder = this.rbAlpha.Checked;
            m_NumerOrder = this.rbNumer.Checked;
            m_IgnoreTone = this.chkIgnoreTone.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_AlphaOrder = false;
            m_NumerOrder = false; ;
            m_IgnoreTone = false;
        }
    }
}
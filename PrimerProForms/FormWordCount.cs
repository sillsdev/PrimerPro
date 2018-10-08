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
        private bool m_AscendingOrder;
        private bool m_DescendingOrder;
        private bool m_IgnoreTone;

        public FormWordCount()
        {
            InitializeComponent();
            this.rbAlpha.Checked = true;
            this.rbNumer.Checked = false;
            this.rbAscending.Checked = true;
            this.rbDescending.Checked = false;
            this.chkIgnoreTone.Checked = false;
        }

        public FormWordCount(LocalizationTable table)
        {
            InitializeComponent();
            this.rbAlpha.Checked = true;
            this.rbNumer.Checked = false;
            this.rbAscending.Checked = true;
            this.rbDescending.Checked = false;
            this.chkIgnoreTone.Checked = false;

            this.UpdateFormForLocalization(table);
        }

        public bool AlphaOrder
        {
            get { return m_AlphaOrder; }
        }

        public bool NumerOrder
        {
            get { return m_NumerOrder; }
        }

        public bool AscendingOrder
        {
            get { return m_AscendingOrder; }
        }

        public bool DescendingOrder
        {
            get { return m_DescendingOrder; }
        }

        public bool IgnoreTone
        {
            get { return m_IgnoreTone; }
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            m_AlphaOrder = this.rbAlpha.Checked;
            m_NumerOrder = this.rbNumer.Checked;
            m_AscendingOrder = this.rbAscending.Checked;
            m_DescendingOrder = this.rbDescending.Checked;
            m_IgnoreTone = this.chkIgnoreTone.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_AlphaOrder = false;
            m_NumerOrder = false;
            m_AscendingOrder = false;
            m_DescendingOrder = false;
            m_IgnoreTone = false;
        }

        private void UpdateFormForLocalization(LocalizationTable table)
        {
            string strText = "";
            strText = table.GetForm("FormWordCountT");
			if (strText != "")
				this.Text = strText;
            strText = table.GetForm("FormWordCount0");
			if (strText != "")
				this.gbSort.Text = strText;
            strText = table.GetForm("FormWordCountS0");
			if (strText != "")
				this.rbAlpha.Text = strText;
            strText = table.GetForm("FormWordCountS1");
			if (strText != "")
				this.rbNumer.Text = strText;
            strText = table.GetForm("FormWordCount1");
			if (strText != "")
				this.gbSort2.Text = strText;
            strText = table.GetForm("FormWordCountB0");
			if (strText != "")
				this.rbAscending.Text = strText;
            strText = table.GetForm("FormWordCountB1");
			if (strText != "")
				this.rbDescending.Text = strText;
            strText = table.GetForm("FormWordCount2");
			if (strText != "")
				this.chkIgnoreTone.Text = strText;
            strText = table.GetForm("FormWordCount3");
			if (strText != "")
				this.btnOK.Text = strText;
            strText = table.GetForm("FormWordCount4");
			if (strText != "")
				this.btnCancel.Text = strText;
        }

    }
}
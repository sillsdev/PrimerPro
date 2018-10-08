using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PrimerProObjects;
using PrimerProLocalization;

namespace PrimerProForms
{
    public partial class FormTeachingOrder : Form
    {
        private bool m_IncludeConsonant;
        private bool m_IncludeVowel;
        private bool m_IncludeTone;
        private bool m_IncludeSyllograph;
        private SyllographFeatures.SyllographType m_SType;
        private bool m_IgnoreTone;
        
        public FormTeachingOrder()
        {
            InitializeComponent();
            this.ckConsonant.Checked = true;
            this.ckVowel.Checked = false;
            this.ckTone.Checked = false;
            this.ckSyllograph.Checked = false;
            this.ckIgnoreTone.Checked = false;
        }

        public FormTeachingOrder(LocalizationTable table)
        {
            InitializeComponent();
            this.ckConsonant.Checked = true;
            this.ckVowel.Checked = false;
            this.ckTone.Checked = false;
            this.ckSyllograph.Checked = false;
            this.ckIgnoreTone.Checked = false;
            this.rbNone.Checked = false;
            this.rbPrimary.Checked = false;
            this.rbSecondary.Checked = false;
            this.rbTertiary.Checked = false;
            
            this.gbSyllograph.Enabled = false;
            this.rbNone.Enabled = false;
            this.rbPrimary.Enabled = false;
            this.rbSecondary.Enabled = false;
            this.rbTertiary.Enabled = false;

            this.UpdateFormForLocalization(table);
        }

        public bool IncludeConsonant
        {
            get { return m_IncludeConsonant; }
        }

        public bool IncludeVowel
        {
            get { return m_IncludeVowel; }
        }

        public bool IncludeTone
        {
            get { return m_IncludeTone; }
        }

        public bool IncludeSyllograph
        {
            get { return m_IncludeSyllograph; }
        }

        public SyllographFeatures.SyllographType SType
        {
            get { return m_SType; }
        }

        public bool IgnoreTone
        {
            get { return m_IgnoreTone; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            m_IncludeConsonant = this.ckConsonant.Checked;
            m_IncludeVowel = this.ckVowel.Checked;
            m_IncludeTone = this.ckTone.Checked;
            m_IncludeSyllograph = this.ckSyllograph.Checked;
            m_IgnoreTone = this.ckIgnoreTone.Checked;
            if (m_IncludeSyllograph)
                m_SType = SetType();
            else m_SType = SyllographFeatures.SyllographType.None;
         }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_IncludeConsonant = false;
            m_IncludeVowel = false;
            m_IncludeTone = false;
            m_IncludeSyllograph = false;
            m_IgnoreTone = false;
            m_SType = SyllographFeatures.SyllographType.None;
        }

        private void ckSyllograph_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckSyllograph.Checked)
            {
                this.gbSyllograph.Enabled = true;
                this.rbNone.Enabled = true;
                this.rbPrimary.Enabled = true;
                this.rbSecondary.Enabled = true;
                this.rbTertiary.Enabled = true;
                this.rbNone.Checked = true;
            }
            else
            {
                this.gbSyllograph.Enabled = false;
                this.rbNone.Enabled = false;
                this.rbPrimary.Enabled = false;
                this.rbSecondary.Enabled = false;
                this.rbTertiary.Enabled = false;
                this.rbNone.Checked = false;
                this.rbPrimary.Checked = false;
                this.rbSecondary.Checked = false;
                this.rbTertiary.Checked = false;
            }
        }

        private SyllographFeatures.SyllographType SetType()
        {
            SyllographFeatures.SyllographType typ = SyllographFeatures.SyllographType.None;
            if (rbPrimary.Checked)
                typ = SyllographFeatures.SyllographType.Pri;
            else if (rbSecondary.Checked)
                typ = SyllographFeatures.SyllographType.Sec;
            else if (rbTertiary.Checked)
                typ = SyllographFeatures.SyllographType.Ter;
            else typ = SyllographFeatures.SyllographType.None;
            return typ;
        }

        private void ckIgnoreTone_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckIgnoreTone.Checked)
            {
                this.ckTone.Enabled = false;
                this.ckTone.Checked = false;
            }
            else
            {
                this.ckTone.Enabled = true;
                this.ckTone.Checked = false;
            }
        }

        private void UpdateFormForLocalization(LocalizationTable table)
        {
            string strText = "";
            strText = table.GetForm("FormTeachingOrderT");
			if (strText != "")
				this.Text = strText;
            strText = table.GetForm("FormTeachingOrder0");
			if (strText != "")
				this.labTitle.Text = strText;
            strText = table.GetForm("FormTeachingOrder1");
			if (strText != "")
				this.ckConsonant.Text = strText;
            strText = table.GetForm("FormTeachingOrder2");
			if (strText != "")
				this.ckVowel.Text = strText;
            strText = table.GetForm("FormTeachingOrder3");
			if (strText != "")
				this.ckTone.Text = strText;
            strText = table.GetForm("FormTeachingOrder4");
			if (strText != "")
				this.ckSyllograph.Text = strText;
            strText = table.GetForm("FormTeachingOrder6");
			if (strText != "")
				this.ckIgnoreTone.Text = strText;
            strText = table.GetForm("FormTeachingOrder7");
			if (strText != "")
				this.btnOK.Text = strText;
            strText = table.GetForm("FormTeachingOrder8");
			if (strText != "")
				this.btnCancel.Text = strText;
            strText = table.GetForm("FormTeachingOrder5");
			if (strText != "")
				this.gbSyllograph.Text = strText;
            strText = table.GetForm("FormTeachingOrder50");
			if (strText != "")
				this.rbNone.Text = strText;
            strText = table.GetForm("FormTeachingOrder51");
			if (strText != "")
				this.rbPrimary.Text = strText;
            strText = table.GetForm("FormTeachingOrder52");
			if (strText != "")
				this.rbSecondary.Text = strText;
            strText = table.GetForm("FormTeachingOrder53");
			if (strText != "")
				this.rbTertiary.Text = strText;
            return;
        }


    }
}

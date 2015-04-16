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

        public FormTeachingOrder(LocalizationTable table, string lang)
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

            this.Text = table.GetForm("FormTeachingOrderT", lang);
            this.labTitle.Text = table.GetForm("FormTeachingOrder0", lang);
            this.ckConsonant.Text = table.GetForm("FormTeachingOrder1", lang);
            this.ckVowel.Text = table.GetForm("FormTeachingOrder2", lang);
            this.ckTone.Text = table.GetForm("FormTeachingOrder3", lang);
            this.ckSyllograph.Text = table.GetForm("FormTeachingOrder4", lang);
            this.ckIgnoreTone.Text = table.GetForm("FormTeachingOrder6", lang);
            this.btnOK.Text = table.GetForm("FormTeachingOrder7", lang);
            this.btnCancel.Text = table.GetForm("FormTeachingOrder8", lang);
            this.gbSyllograph.Text = table.GetForm("FormTeachingOrder5", lang);
            this.rbNone.Text = table.GetForm("FormTeachingOrder50", lang);
            this.rbPrimary.Text = table.GetForm("FormTeachingOrder51", lang);
            this.rbSecondary.Text = table.GetForm("FormTeachingOrder52", lang);
            this.rbTertiary.Text = table.GetForm("FormTeachingOrder53", lang);
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
            
    }
}

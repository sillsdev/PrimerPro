using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PrimerProObjects;
using PrimerProLocalization;

namespace PrimerProForms
{
    public partial class FormNewSyllabary : Form
    {
        private Settings m_Settings;
        private GraphemeInventory m_GI;

        public FormNewSyllabary(Settings s)
        {
            InitializeComponent();
            m_Settings = s;
            m_GI = new GraphemeInventory(m_Settings);

            LocalizationTable table = m_Settings.LocalizationTable;
            string lang = m_Settings.OptionSettings.UILanguage;
            this.Text = table.GetForm("FormNewSyllabaryT", lang);
            this.btnUseTD.Text = table.GetForm("FormNewSyllabary0", lang);
            this.btnUseWL.Text = table.GetForm("FormNewSyllabary1", lang);
            this.btnOK.Text = table.GetForm("FormNewSyllabary2", lang);
            this.btnCancel.Text = table.GetForm("FormNewSyllabary3", lang);
        }

        public GraphemeInventory GI
        {
            get { return m_GI; }
        }

        private void btnUseTD_Click(object sender, EventArgs e)
        {
            TextData td = new TextData(m_Settings);
            string strFolder = m_Settings.OptionSettings.DataFolder;
            td = td.Load(strFolder);
            if (td != null)
                m_GI = td.BuildSyllabaryInventory();
        }

        private void btnUseWL_Click(object sender, EventArgs e)
        {
            WordList wl = new WordList(m_Settings);
            wl = wl.LoadSFM(m_Settings.OptionSettings.DataFolder);
            if (wl != null)
                m_GI = wl.BuildSyllabaryInventory();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_GI = null;
        }

    }
}

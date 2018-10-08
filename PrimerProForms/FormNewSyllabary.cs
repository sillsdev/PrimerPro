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

        public FormNewSyllabary(Settings s, GraphemeInventory gi)
        {
            InitializeComponent();
            m_Settings = s;
            m_GI = gi;

            this.UpdateFormForLocalization(m_Settings.LocalizationTable);
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

        private void UpdateFormForLocalization(LocalizationTable table)
        {
            string strText = "";
            strText = table.GetForm("FormNewSyllabaryT");
			if (strText != "")
				this.Text = strText;
            strText = table.GetForm("FormNewSyllabary0");
			if (strText != "")
				this.btnUseTD.Text = strText;
            strText = table.GetForm("FormNewSyllabary1");
			if (strText != "")
				this.btnUseWL.Text = strText;
            strText = table.GetForm("FormNewSyllabary2");
			if (strText != "")
				this.btnOK.Text = strText;
            strText = table.GetForm("FormNewSyllabary3");
			if (strText != "")
				this.btnCancel.Text = strText;
            return;
        }

    }
}

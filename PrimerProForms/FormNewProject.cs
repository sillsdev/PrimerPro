using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PrimerProObjects;
using PrimerProLocalization;
using GenLib;

namespace PrimerProForms
{
    public partial class FormNewProject : Form
    {
        private string m_ProjectName;
        private GraphemeInventory m_gi;
        private Settings m_Settings;

        private const string kDefaultGIName = "DefaultGraphemeInventory.xml";
        private const string kBackSlash = "\\";

        public FormNewProject(Settings s)
        {
            InitializeComponent();
            m_Settings  = s;
            m_ProjectName = "";
            m_gi = new GraphemeInventory(s);

            LocalizationTable table = m_Settings.LocalizationTable;
            string lang = m_Settings.OptionSettings.UILanguage;
            this.Text = table.GetForm("FormNewProjectT", lang);
            this.labProjName.Text = table.GetForm("FormNewProject0", lang);
            this.btnInitGI.Text = table.GetForm("FormNewProject2", lang);
            this.btnOK.Text = table.GetForm("FormNewProject3", lang);
            this.btnCancel.Text = table.GetForm("FormNewProject4", lang);
        }

        public string ProjectName
        {
            get { return m_ProjectName; }
        }

        public GraphemeInventory InitialGraphemeInventory
        {
            get { return m_gi; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            m_ProjectName = this.tbProjName.Text;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_ProjectName = "";
            m_gi = null;
        }

        private void btnInitGI_Click(object sender, EventArgs e)
        {
            string strFileName = m_Settings.GetAppFolder() + FormNewProject.kBackSlash + 
                FormNewProject.kDefaultGIName;
            GraphemeInventory gi = new GraphemeInventory(m_Settings);
            if (gi.InitializeGraphemeInventoryFromPredefinedGraphemes(strFileName))
            {
                m_gi = gi;
                //MessageBox.Show("Grapheme Inventory has been initialized");
                MessageBox.Show(m_Settings.LocalizationTable.GetMessage("FormNewProject2",
                    m_Settings.OptionSettings.UILanguage));
            }
            else
            {
                //MessageBox.Show("Grapheme Inventory was not initialized");
                MessageBox.Show(m_Settings.LocalizationTable.GetMessage("FormNewProject1",
                    m_Settings.OptionSettings.UILanguage));
                m_gi = new GraphemeInventory(m_Settings);
            }
        }

    }
}

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

            this.UpdateFormForLocalization(m_Settings.LocalizationTable);
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
            string strText = "";
            string strFileName = m_Settings.GetAppFolder() + FormNewProject.kBackSlash + 
                FormNewProject.kDefaultGIName;
            GraphemeInventory gi = new GraphemeInventory(m_Settings);
            if (gi.InitializeGraphemeInventoryFromPredefinedGraphemes(strFileName))
            {
                m_gi = gi;
                //MessageBox.Show("Grapheme Inventory has been initialized");
                strText = m_Settings.LocalizationTable.GetMessage("FormNewProject2");
                if (strText == "")
                    strText = "Grapheme Inventory has been initialized";
                MessageBox.Show(strText);
            }
            else
            {
                //MessageBox.Show("Grapheme Inventory was not initialized")
                strText = m_Settings.LocalizationTable.GetMessage("FormNewProject1");
                if (strText == "")
                    strText = "Grapheme Inventory was not initialized";
                MessageBox.Show(strText);
                m_gi = new GraphemeInventory(m_Settings);
            }
        }

        private void UpdateFormForLocalization(LocalizationTable table)
        {
            string strText = "";
            strText = table.GetForm("FormNewProjectT");
			if (strText != "")
				this.Text = strText;
            strText = table.GetForm("FormNewProject0");
			if (strText != "")
				this.labProjName.Text = strText;
            strText = table.GetForm("FormNewProject2");
			if (strText != "")
				this.btnInitGI.Text = strText;
            strText = table.GetForm("FormNewProject3");
			if (strText != "")
				this.btnOK.Text = strText;
            strText = table.GetForm("FormNewProject4");
			if (strText != "")
				this.btnCancel.Text = strText;
            return;
        }

    }
}

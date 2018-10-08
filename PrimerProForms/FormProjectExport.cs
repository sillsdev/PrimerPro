using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using PrimerProLocalization;

namespace PrimerProForms
{
    public partial class FormProjectExport : Form
    {
        private string m_DataFolder;
        private string m_TemplateFolder;
        
        private string m_ExportFolder;
        private bool m_IncludeDataFolder;
        private bool m_IncludeTemplateFolder;

        private LocalizationTable m_Table;          //Localization table

        public FormProjectExport(string datafolder, string templatefolder)
        {
            InitializeComponent();
            m_DataFolder = datafolder;
            m_TemplateFolder = templatefolder;

            this.tbExportFolder.Text = "";
            this.ckDataFolder.Checked = false;
            this.ckTemplateFolder.Checked = false;
            if (m_DataFolder == m_TemplateFolder)
                this.ckTemplateFolder.Enabled = false;
            m_Table = null;
        }

        public FormProjectExport(string datafolder, string templatefolder, LocalizationTable table)
        {
            InitializeComponent();
            m_DataFolder = datafolder;
            m_TemplateFolder = templatefolder;

            this.tbExportFolder.Text = "";
            this.ckDataFolder.Checked = false;
            this.ckTemplateFolder.Checked = false;
            if (m_DataFolder == m_TemplateFolder)
                this.ckTemplateFolder.Enabled = false;
            m_Table = table;

            this.UpdateFormForLocalization(table);
        }

        public string ExportFolder
        {
            get { return m_ExportFolder; }
        }

        public bool IncludeDataFolder
        {
            get { return m_IncludeDataFolder; }
        }

        public bool IncludeTemplateFolder
        {
            get { return m_IncludeTemplateFolder; }
        }

        private void btnExportFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd1 = new FolderBrowserDialog();
            fbd1.RootFolder = Environment.SpecialFolder.MyComputer;
            if (m_Table == null)
                fbd1.Description = "ExportFolder";
            else
            {
                fbd1.Description = m_Table.GetMessage("FormProjectExport6");
                if (fbd1.Description == "")
                    fbd1.Description = "ExportFolder";
            }
            fbd1.ShowNewFolderButton = true;
            if (fbd1.ShowDialog() == DialogResult.OK)
            {
                tbExportFolder.Text = fbd1.SelectedPath;
                tbExportFolder.Focus();
            }
        }

        private void tbExportFolder_Leave(object sender, EventArgs e)
        {
            string strText = "";
            if (tbExportFolder.Text != "")
            {
                if (Directory.Exists(tbExportFolder.Text))
                {
                    if (this.tbExportFolder.Text == m_DataFolder)
                    {
                        if (m_Table == null)
                            MessageBox.Show("Export folder can not be the same as the data folder");
                        else
                        {
                            strText = m_Table.GetMessage("FormProjectExport1");
                            if (strText == "")
                                strText = "Export folder can not be the same as the data folder";
                            MessageBox.Show(strText);
                        }
                        this.tbExportFolder.Text = "";
                    }
                    else
                    {
                        if (this.tbExportFolder.Text.Length > m_DataFolder.Length)
                        {
                            if (this.tbExportFolder.Text.Substring(0, m_DataFolder.Length) ==
                            m_DataFolder)
                            {
                                if (m_Table == null)
                                    MessageBox.Show("Export folder can not be a subfolder of data folder");
                                else
                                {
                                    strText = m_Table.GetMessage("FormProjectExport2");
                                    if (strText == "")
                                        strText = "Export folder can not be a subfolder of data folder";
                                    MessageBox.Show(strText);
                                }
                                this.tbExportFolder.Text = "";
                            }
                        }
                    }

                    if (this.tbExportFolder.Text == m_TemplateFolder)
                    {
                        if (m_Table == null)
                            MessageBox.Show("Export folder can not be the same as the template folder");
                        else
                        {
                            strText = m_Table.GetMessage("FormProjectExport3");
                            if (strText == "")
                                strText = "Export folder can not be the same as the template folder";
                            MessageBox.Show(strText);
                        }
                        this.tbExportFolder.Text = "";
                    }
                    else
                    {
                        if (this.tbExportFolder.Text.Length > m_TemplateFolder.Length)
                        {
                            if (this.tbExportFolder.Text.Substring(0, m_TemplateFolder.Length) == m_DataFolder)
                            {
                                if (m_Table == null)
                                    MessageBox.Show("Export folder can not be a subfolder of template folder");
                                else
                                {
                                    strText = m_Table.GetMessage("FormProjectExport4");
                                    if (strText == "")
                                        strText = "Export folder can not be a subfolder of template folder";
                                    MessageBox.Show(strText);
                                }
                                this.tbExportFolder.Text = "";
                            }
                        }
                    }
                }
                else 
                {
                    if (m_Table == null)
                        MessageBox.Show("Export Folder does not exists");
                    else
                    {
                        strText = m_Table.GetMessage("FormProjectExport5");
                        if (strText == "")
                            strText = "Export Folder does not exists";
                        MessageBox.Show(strText);
                    }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            m_ExportFolder = this.tbExportFolder.Text;
            m_IncludeDataFolder = this.ckDataFolder.Checked;
            m_IncludeTemplateFolder = this.ckTemplateFolder.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.tbExportFolder.Text = "";
            this.ckDataFolder.Checked = false;
            this.ckTemplateFolder.Checked = false;
        }

        private void UpdateFormForLocalization(LocalizationTable table)
        {
            string strText = "";
            strText = table.GetForm("FormProjectExportT");
			if (strText != "")
				this.Text = strText;
            strText = table.GetForm("FormProjectExport0");
			if (strText != "")
				this.labelInfo.Text = strText;
            strText = table.GetForm("FormProjectExport1");
			if (strText != "")
				this.labExportFolder.Text = strText;
            strText = table.GetForm("FormProjectExport3");
			if (strText != "")
				this.btnExportFolder.Text = strText;
            strText = table.GetForm("FormProjectExport4");
			if (strText != "")
				this.ckDataFolder.Text = strText;
            strText = table.GetForm("FormProjectExport5");
			if (strText != "")
				this.ckTemplateFolder.Text = strText;
            strText = table.GetForm("FormProjectExport6");
			if (strText != "")
				this.btnOK.Text = strText;
            strText = table.GetForm("FormProjectExport7");
			if (strText != "")
				this.btnCancel.Text = strText;
            return;
        }
    }
}

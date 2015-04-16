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
        private string m_Lang;                      //UI language

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
            m_Lang = "";
        }

        public FormProjectExport(string datafolder, string templatefolder, 
            LocalizationTable table, string lang)
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
            m_Lang = lang;

            this.Text = table.GetForm("FormProjectExportT", lang);
            this.labelInfo.Text = table.GetForm("FormProjectExport0", lang);
            this.labExportFolder.Text = table.GetForm("FormProjectExport1", lang);
            this.btnExportFolder.Text = table.GetForm("FormProjectExport3", lang);
            this.ckDataFolder.Text = table.GetForm("FormProjectExport4", lang);
            this.ckTemplateFolder.Text = table.GetForm("FormProjectExport5", lang);
            this.btnOK.Text = table.GetForm("FormProjectExport6", lang);
            this.btnCancel.Text = table.GetForm("FormProjectExport7", lang);
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
            //fbd1.RootFolder = Environment.SpecialFolder.Personal;
            fbd1.RootFolder = Environment.SpecialFolder.MyComputer;
            if (m_Table == null)
                fbd1.Description = "ExportFolder";
            else fbd1.Description = m_Table.GetMessage("FormProjectExport6", m_Lang);
            fbd1.ShowNewFolderButton = true;
            if (fbd1.ShowDialog() == DialogResult.OK)
            {
                tbExportFolder.Text = fbd1.SelectedPath;
                tbExportFolder.Focus();
            }
        }

        private void tbExportFolder_Leave(object sender, EventArgs e)
        {
            if (tbExportFolder.Text != "")
            {
                if (Directory.Exists(tbExportFolder.Text))
                {
                    if (this.tbExportFolder.Text == m_DataFolder)
                    {
                        if (m_Table == null)
                            MessageBox.Show("Export folder can not be the same as the data folder");
                        else MessageBox.Show(m_Table.GetMessage("FormProjectExport1", m_Lang));
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
                                else MessageBox.Show(m_Table.GetMessage("FormProjectExport2", m_Lang));
                                this.tbExportFolder.Text = "";
                            }
                        }
                    }

                    if (this.tbExportFolder.Text == m_TemplateFolder)
                    {
                        if (m_Table == null)
                            MessageBox.Show("Export folder can not be the same as the template folder");
                        else MessageBox.Show(m_Table.GetMessage("FormProjectExport3", m_Lang));
                        this.tbExportFolder.Text = "";
                    }
                    else
                    {
                        if (this.tbExportFolder.Text.Length > m_TemplateFolder.Length)
                        {
                            if (this.tbExportFolder.Text.Substring(0, m_TemplateFolder.Length) ==
                             m_DataFolder)
                            {
                                if (m_Table == null)
                                    MessageBox.Show("Export folder can not be a subfolder of template folder");
                                else MessageBox.Show(m_Table.GetMessage("FormProjectExport4", m_Lang));
                                this.tbExportFolder.Text = "";
                            }
                        }
                    }
                }
                else 
                {
                    if (m_Table == null)
                        MessageBox.Show("Export Folder does not exists");
                    else MessageBox.Show(m_Table.GetMessage("FormProjectExport5", m_Lang));
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

    }
}

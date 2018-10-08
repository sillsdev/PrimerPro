using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
using System.Windows.Forms;
using System.IO;
//using System.Xml;
using PrimerProObjects;
using PrimerProLocalization;

namespace PrimerProForms
{
    public partial class FormProjectImport : Form
    {
        private Settings m_Settings;
        private string m_ToFolder;
        private string m_FromFolder;
        private string m_DataFolder;
        private string m_TemplateFolder;

        private const string kBackSlash = "\\";
        private const string kData = "Data";
        private const string kTemplate = "Template";
        private const string kPLName = "PackageList.xml";

        private LocalizationTable m_Table;          //Localization table

        public FormProjectImport(Settings s)
        {
            InitializeComponent();
            m_Settings = s;
            this.tbFromFolder.Text = "";
            this.tbToFolder.Text = "";
            this.tbDataFolder.Text = "";
            this.tbTemplateFolder.Text = "";

            this.tbToFolder.Enabled = false;
            this.tbDataFolder.Enabled = false;
            this.tbTemplateFolder.Enabled = false;
            this.btnToFolder.Enabled = false;
            this.btnDataFolder.Enabled = false;
            this.btnTemplateFolder.Enabled = false;
            m_Table = null;
        }

        public FormProjectImport(Settings s, LocalizationTable table)
        {
            InitializeComponent();
            m_Settings = s;
            this.tbFromFolder.Text = "";
            this.tbToFolder.Text = "";
            this.tbDataFolder.Text = "";
            this.tbTemplateFolder.Text = "";

            this.tbToFolder.Enabled = false;
            this.tbDataFolder.Enabled = false;
            this.tbTemplateFolder.Enabled = false;
            this.btnToFolder.Enabled = false;
            this.btnDataFolder.Enabled = false;
            this.btnTemplateFolder.Enabled = false;
            m_Table = table;

            this.UpdateFormForLocalization(table);
        }

        public string FromFolder
        {
            get { return m_FromFolder; }
        }

        public string ToFolder
        {
            get { return m_ToFolder; }
        }

        public string DataFolder
        {
            get { return m_DataFolder; }
        }

        public string TemplateFolder
        {
            get { return m_TemplateFolder; }
        }

        private void btnFromFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd1 = new FolderBrowserDialog();
            //fbd1.RootFolder = Environment.SpecialFolder.Personal;
            fbd1.RootFolder = Environment.SpecialFolder.MyComputer;
            if (m_Table == null)
                fbd1.Description = "From Folder";
            else
            {
                fbd1.Description = m_Table.GetMessage("FormProjectImport5");
                if (fbd1.Description == "")
                    fbd1.Description = "From Folder";
            }
            fbd1.ShowNewFolderButton = true;
            if (fbd1.ShowDialog() == DialogResult.OK)
            {
                tbFromFolder.Text = fbd1.SelectedPath;
                tbFromFolder.Focus();

                PackageList pl = new PackageList(m_Settings);
                if (pl.Read(FormProjectImport.kPLName, tbFromFolder.Text))
                {
                    this.tbToFolder.Text = pl.PrimerProFolder + FormProjectImport.kBackSlash +
                        pl.ProjectName;
                    this.tbToFolder.Enabled = true;
                    this.btnToFolder.Enabled = true;

                    if (pl.DataFolder == pl.ProjectName)
                    {
                        this.tbDataFolder.Text = this.tbToFolder.Text;
                        this.tbDataFolder.Enabled = true;
                        this.btnDataFolder.Enabled = true;
                    }
                    else if (pl.DataFolder != "")
                    {
                        this.tbDataFolder.Text = this.tbToFolder.Text + FormProjectImport.kBackSlash +
                            pl.DataFolder;
                        this.tbDataFolder.Enabled = true;
                        this.btnDataFolder.Enabled = true;
                    }

                    if (pl.TemplateFolder == pl.ProjectName)
                    {
                        this.tbTemplateFolder.Text = this.tbToFolder.Text;
                        this.tbTemplateFolder.Enabled = true;
                        this.btnTemplateFolder.Enabled = true;
                    }
                    else if (pl.TemplateFolder != "")
                    {
                        this.tbTemplateFolder.Text = this.tbToFolder.Text + FormProjectImport.kBackSlash +
                            pl.TemplateFolder;
                        this.tbTemplateFolder.Enabled = true;
                        this.btnTemplateFolder.Enabled = true;
                    }
                }
                else tbFromFolder.Text = "";
            }
        }

        private void btnToFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd1 = new FolderBrowserDialog();
            fbd1.RootFolder = Environment.SpecialFolder.Personal;
            if (m_Table == null)
                fbd1.Description = "To Folder";
            else
            {
                fbd1.Description = m_Table.GetMessage("FormProjectImport6");
                if (fbd1.Description == "")
                    fbd1.Description = "To Folder";
            }
            fbd1.ShowNewFolderButton = true;
            if (fbd1.ShowDialog() == DialogResult.OK)
            {
                tbToFolder.Text = fbd1.SelectedPath;
                tbToFolder.Focus();
            }
        }

        private void btnDataFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd1 = new FolderBrowserDialog();
            fbd1.RootFolder = Environment.SpecialFolder.Personal;
            if (m_Table == null)
                fbd1.Description = "Data Folder";
            else
            {
                fbd1.Description = m_Table.GetMessage("FormProjectImport7");
                if (fbd1.Description == "")
                    fbd1.Description = "Data Folder";
            }
            fbd1.ShowNewFolderButton = true;
            if (fbd1.ShowDialog() == DialogResult.OK)
            {
                tbDataFolder.Text = fbd1.SelectedPath;
                tbDataFolder.Focus();
            }
        }

        private void btnTemplateFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd1 = new FolderBrowserDialog();
            fbd1.RootFolder = Environment.SpecialFolder.Personal;
            if (m_Table == null)
                fbd1.Description = "Template Folder";
            else
            {
                fbd1.Description = m_Table.GetMessage("FormProjectImport8");
                if (fbd1.Description == "")
                    fbd1.Description = "Template Folder";
            }
            fbd1.ShowNewFolderButton = true;
            if (fbd1.ShowDialog() == DialogResult.OK)
            {
                tbTemplateFolder.Text = fbd1.SelectedPath;
                tbTemplateFolder.Focus();
            }
        }

        private void tbFromFolder_Leave(object sender, EventArgs e)
        {
            string strText = "";
            tbDataFolder.Enabled = false;
            tbTemplateFolder.Enabled = false;
            btnDataFolder.Enabled = false;
            btnTemplateFolder.Enabled = false;

            if (tbFromFolder.Text != "")
            {
                string strFolder = tbFromFolder.Text;
                if (Directory.Exists(strFolder))
                {
                    if (Directory.Exists(strFolder + FormProjectImport.kBackSlash + FormProjectImport.kData))
                    {
                        tbDataFolder.Enabled = true;
                        btnDataFolder.Enabled = true;
                    }
                    if (Directory.Exists(strFolder + FormProjectImport.kBackSlash + FormProjectImport.kTemplate))
                    {
                        tbTemplateFolder.Enabled = true;
                        btnDataFolder.Enabled = true;
                    }
                }
                else if (m_Table == null)
                    MessageBox.Show("From folder does not exist");
                else
                {
                    strText = m_Table.GetMessage("FormProjectImport1");
                    if (strText == "")
                        strText = "From folder does not exist";
                    MessageBox.Show(strText);
                }
            }
        }

        private void tbToFolder_Leave(object sender, EventArgs e)
        {
            string strText = "";
            if ((tbToFolder.Text != "") && (!Directory.Exists(tbToFolder.Text)))
                if (m_Table == null)
                    MessageBox.Show("To folder does not exist");
                else
                {
                    strText = m_Table.GetMessage("FormProjectImport2");
                    if (strText == "")
                        strText = "To folder does not exist";
                    MessageBox.Show(strText);
                }
        }

        private void tbDataFolder_Leave(object sender, EventArgs e)
        {
            string strText = "";
            if ( (tbDataFolder.Text != "") && (!Directory.Exists(tbDataFolder.Text)) )
                if (m_Table == null)
                    MessageBox.Show("Data folder does not exist");
                else
                {
                    strText = m_Table.GetMessage("FormProjectImport3");
                    if (strText == "")
                        strText = "Data folder does not exist";
                    MessageBox.Show(strText);
                }
        }

        private void tbTemplateFolder_Leave(object sender, EventArgs e)
        {
            string strText = "";
            if ((tbTemplateFolder.Text != "") && (!Directory.Exists(tbTemplateFolder.Text)))
                if (m_Table == null)
                    MessageBox.Show("Template folder does not exist");
                else
                {
                    strText = m_Table.GetMessage("FormProjectImport4");
                    if (strText == "")
                        strText = "Template folder does not exist";
                    MessageBox.Show(strText);
                }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            m_FromFolder = this.tbFromFolder.Text;
            m_ToFolder = this.tbToFolder.Text;
            m_DataFolder = this.tbDataFolder.Text;
            m_TemplateFolder = this.tbTemplateFolder.Text;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_FromFolder = "";
            m_ToFolder = "";
            m_DataFolder = "";
            m_TemplateFolder = "";
        }

        private void UpdateFormForLocalization(LocalizationTable table)
        {
            string strText = "";
            strText = table.GetForm("FormProjectImportT");
			if (strText != "")
				this.Text = strText;
            strText = table.GetForm("FormProjectImport0");
			if (strText != "")
				this.labInfo.Text = strText;
            strText = table.GetForm("FormProjectImport1");
			if (strText != "")
				this.labFromFolder.Text = strText;
            strText = table.GetForm("FormProjectImport3");
			if (strText != "")
				this.btnFromFolder.Text = strText;
            strText = table.GetForm("FormProjectImport4");
			if (strText != "")
				this.labToFolder.Text = strText;
            strText = table.GetForm("FormProjectImport6");
			if (strText != "")
				this.btnToFolder.Text = strText;
            strText = table.GetForm("FormProjectImport7");
			if (strText != "")
				this.labDataFolder.Text = strText;
            strText = table.GetForm("FormProjectImport9");
			if (strText != "")
				this.btnDataFolder.Text = strText;
            strText = table.GetForm("FormProjectImport10");
			if (strText != "")
				this.labTemplateFolder.Text = strText;
            strText = table.GetForm("FormProjectImport12");
			if (strText != "")
				this.btnTemplateFolder.Text = strText;
            strText = table.GetForm("FormProjectImport13");
			if (strText != "")
				this.btnOK.Text = strText;
            strText = table.GetForm("FormProjectImport14");
			if (strText != "")
				this.btnCancel.Text = strText;
            return;
        }
    }
}

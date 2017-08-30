using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PrimerProLocalization;


namespace PrimerProForms
{
	/// <summary>
	/// Summary description for FormNewWord.
	/// </summary>
    public partial class FormNewWord : Form
    {
        private string m_BaseFileName;
        private string m_StoryFileName;
        private bool m_ParaFormat;
        private bool m_IgnoreTone;
        private string m_Folder;
        private LocalizationTable m_Table;      //Localization Table
        private string m_Lang;                  //UI Language


        public FormNewWord(string folder)
        {
            InitializeComponent();
            tbBaseFile.Text = "";
            tbStory.Text = "";
            chkParaFmt.Checked = true;
            chkIgnoreTone.Checked = false;
            m_Folder = folder;
            m_Table = null;
            m_Lang = "";
        }

        public FormNewWord(string folder, LocalizationTable table, string lang)
        {
            InitializeComponent();
            tbBaseFile.Text = "";
            tbStory.Text = "";
            chkParaFmt.Checked = true;
            chkIgnoreTone.Checked = false;
            m_Folder = folder;
            m_Table = table;
            m_Lang = lang;

            this.Text = table.GetForm("FormNewWordT", lang);
            this.labTitle1.Text = table.GetForm("FormNewWord0", lang);
            this.labTitle2.Text = table.GetForm("FormNewWord1", lang);
            this.labBaseFile.Text = table.GetForm("FormNewWord2", lang);
            this.btnBaseFile.Text = table.GetForm("FormNewWord4", lang);
            this.labStory.Text = table.GetForm("FormNewWord5", lang);
            this.btnStory.Text = table.GetForm("FormNewWord7", lang);
            this.chkParaFmt.Text = table.GetForm("FormNewWord8", lang);
            this.chkIgnoreTone.Text = table.GetForm("FormNewWord9", lang);
            this.btnOK.Text = table.GetForm("FormNewWord10", lang);
            this.btnCancel.Text = table.GetForm("FormNewWord11", lang);
        }
        
        public string BaseFileName
        {
            get { return m_BaseFileName; }
        }

        public string StoryFileName
        {
            get { return m_StoryFileName; }
        }

        public bool ParaFormat
        {
            get { return m_ParaFormat; }
        }

        public bool IgnoreTone
        {
            get { return m_IgnoreTone; }
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            if (this.tbBaseFile.Text == "")
                if (m_Table == null)
                    MessageBox.Show("Base File not specified");
                else MessageBox.Show(m_Table.GetMessage("FormNewWord1", m_Lang));
            else m_BaseFileName = this.tbBaseFile.Text;
            if (this.tbStory.Text == "")
                if (m_Table == null)
                    MessageBox.Show("Story File not specified");
                else MessageBox.Show(m_Table.GetMessage("FormNewWord2", m_Lang));
            else m_StoryFileName = this.tbStory.Text;
            m_ParaFormat = this.chkParaFmt.Checked;
            m_IgnoreTone = this.chkIgnoreTone.Checked;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            m_BaseFileName = "";
            m_StoryFileName = "";
            m_ParaFormat = true;
            m_IgnoreTone = false;
        }

        private void btnBaseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files (*.txt)|*.txt|All Files (*.*)|*.*";
            ofd.FileName = "";
            ofd.DefaultExt = "*.txt";
            ofd.InitialDirectory = m_Folder;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.tbBaseFile.Text = ofd.FileName;
            }
        }

        private void btnStory_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files (*.txt)|*.txt|All Files (*.*)|*.*";
            ofd.FileName = "";
            ofd.DefaultExt = "*.txt";
            ofd.InitialDirectory = m_Folder;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.tbStory.Text = ofd.FileName;
            }

        }

    }
}
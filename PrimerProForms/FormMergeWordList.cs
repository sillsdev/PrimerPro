using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PrimerProObjects;
using PrimerProLocalization;

namespace PrimerProForms
{
    public partial class FormMergeWordList : Form
    {
        private char m_DuplicateProcessing;
        private string m_DataFolder;

        public FormMergeWordList(string df)
        {
            InitializeComponent();
            m_DuplicateProcessing = WordList.kKeepBoth;
            m_DataFolder = df;
            this.rbBoth.Checked = true;
            this.tbFile.Text = "";
        }

        public FormMergeWordList(string df, LocalizationTable table, string lang)
        {
            InitializeComponent();
            m_DuplicateProcessing = WordList.kKeepBoth;
            m_DataFolder = df;
            this.rbBoth.Checked = true;
            this.tbFile.Text = "";

            this.Text = table.GetForm("FormMergeWordListT", lang);
            this.labFile.Text = table.GetForm("FormMergeWordList0", lang);
            this.btnFile.Text = table.GetForm("FormMergeWordList2", lang);
            this.gbDuplicate.Text = table.GetForm("FormMergeWordList3", lang);
            this.rbKeep.Text = table.GetForm("FormMergeWordListD0", lang);
            this.rbReplace.Text = table.GetForm("FormMergeWordListD1", lang);
            this.rbBoth.Text = table.GetForm("FormMergeWordListD2", lang);
            this.rbAsk.Text = table.GetForm("FormMergeWordListD3", lang);
            this.btnOK.Text = table.GetForm("FormMergeWordList4", lang);
            this.btnCancel.Text = table.GetForm("FormMergeWordList5", lang);
        }

        public char DuplicateProcesssing
        {
            get { return m_DuplicateProcessing; }
        }

        public string FileToMerge
        {
            get { return this.tbFile.Text; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.rbKeep.Checked)
                m_DuplicateProcessing = WordList.kKeepOriginal;
            else if (this.rbReplace.Checked)
                m_DuplicateProcessing = WordList.kReplaceOriginal;
            else if (this.rbBoth.Checked)
                m_DuplicateProcessing = WordList.kKeepBoth;
            else m_DuplicateProcessing = WordList.kAskMe;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_DuplicateProcessing = WordList.kKeepBoth;
            this.Close();
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files (*.txt)|*.txt|All Files (*.*)|*.*";
            ofd.FileName = "";
            ofd.DefaultExt = "*.txt";
            ofd.InitialDirectory = m_DataFolder;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.tbFile.Text = ofd.FileName;
            }

        }
    }
}
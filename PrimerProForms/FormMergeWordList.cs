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

        public FormMergeWordList(string Folder)
        {
            InitializeComponent();
            m_DuplicateProcessing = WordList.kKeepBoth;
            m_DataFolder = Folder;
            this.rbBoth.Checked = true;
            this.tbFile.Text = "";
        }

        public FormMergeWordList(string df, LocalizationTable table)
        {
            InitializeComponent();
            m_DuplicateProcessing = WordList.kKeepBoth;
            m_DataFolder = df;
            this.rbBoth.Checked = true;
            this.tbFile.Text = "";

            UpdateFormForLocalization(table);
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

        private void UpdateFormForLocalization(LocalizationTable table)
        {
            string strText = "";
            strText = table.GetForm("FormMergeWordListT");
			if (strText != "")
				this.Text = strText;
            strText = table.GetForm("FormMergeWordList0");
			if (strText != "")
				this.labFile.Text = strText;
            strText = table.GetForm("FormMergeWordList2");
			if (strText != "")
				this.btnFile.Text = strText;
            strText = table.GetForm("FormMergeWordList3");
			if (strText != "")
				this.gbDuplicate.Text = strText;
            strText = table.GetForm("FormMergeWordListD0");
			if (strText != "")
				this.rbKeep.Text = strText;
            strText = table.GetForm("FormMergeWordListD1");
			if (strText != "")
				this.rbReplace.Text = strText;
            strText = table.GetForm("FormMergeWordListD2");
			if (strText != "")
				this.rbBoth.Text = strText;
            strText = table.GetForm("FormMergeWordListD3");
			if (strText != "")
				this.rbAsk.Text = strText;
            strText = table.GetForm("FormMergeWordList4");
			if (strText != "")
				this.btnOK.Text = strText;
            strText = table.GetForm("FormMergeWordList5");
			if (strText != "")
				this.btnCancel.Text = strText;
            return;
        }

    }
}
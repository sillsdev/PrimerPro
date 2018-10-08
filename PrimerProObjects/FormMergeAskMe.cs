using System;
using System.Windows.Forms;
using PrimerProLocalization;

namespace PrimerProObjects
{
    public partial class FormMergeAskMe : Form
    {
        private char m_DuplicateProcessing;

        public FormMergeAskMe(Word wrd1, Word wrd2)
        // wrd1 = Word from Original word list
        // wrd2 = Word from word list to be merged
        {
            InitializeComponent();
            m_DuplicateProcessing = WordList.kKeepBoth;
            this.tbOWord.Text = wrd1.DisplayWord;
            this.tbOGloss.Text = wrd1.GetGloss();
            this.tbOPoS.Text = wrd1.PartOfSpeech;
            this.tbORoot.Text = wrd1.Root.DisplayRoot;
            this.tbOPlural.Text = wrd1.Plural;
            this.tbNWord.Text = wrd2.DisplayWord;
            this.tbNGloss.Text = wrd2.GetGloss();
            this.tbNPoS.Text = wrd2.PartOfSpeech;
            this.tbNRoot.Text = wrd2.Root.DisplayRoot;
            this.tbNPlural.Text = wrd2.Plural;
            this.rbBoth.Checked = true;
        }

        public FormMergeAskMe(Word wrd1, Word wrd2, LocalizationTable table)
        // wrd1 = Word from Original word list
        // wrd2 = Word from word list to be merged
        // table = Localization table
        {
            InitializeComponent();
            m_DuplicateProcessing = WordList.kKeepBoth;
            this.tbOWord.Text = wrd1.DisplayWord;
            this.tbOGloss.Text = wrd1.GetGloss();
            this.tbOPoS.Text = wrd1.PartOfSpeech;
            this.tbORoot.Text = wrd1.Root.DisplayRoot;
            this.tbOPlural.Text = wrd1.Plural;
            this.tbNWord.Text = wrd2.DisplayWord;
            this.tbNGloss.Text = wrd2.GetGloss();
            this.tbNPoS.Text = wrd2.PartOfSpeech;
            this.tbNRoot.Text = wrd2.Root.DisplayRoot;
            this.tbNPlural.Text = wrd2.Plural;
            this.rbBoth.Checked = true;

            this.UpdateFormForLocalization(table);

        }

        public char DuplicateProcesssing
        {
            get { return m_DuplicateProcessing; }
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.rbKeep.Checked)
                m_DuplicateProcessing = WordList.kKeepOriginal;
            else if (this.rbReplace.Checked)
                m_DuplicateProcessing = WordList.kReplaceOriginal;
            else if (this.rbBoth.Checked)
                m_DuplicateProcessing = WordList.kKeepBoth;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.m_DuplicateProcessing = ' ';
            this.Close();
        }

        private void UpdateFormForLocalization(LocalizationTable table)
        {
            string strText = "";
            strText = table.GetForm("FormMergeAskMeT");
			if (strText != "")
				this.Text = strText;
            strText = table.GetForm("FormMergeAskMe0");
			if (strText != "")
				this.labInfo.Text = strText;
            strText = table.GetForm("FormMergeAskMe1");
			if (strText != "")
				this.labOrigWord.Text = strText;
            strText = table.GetForm("FormMergeAskMe2");
			if (strText != "")
				this.labNewWord.Text = strText;
            strText = table.GetForm("FormMergeAskMe3");
			if (strText != "")
				this.labWord.Text = strText;
            strText = table.GetForm("FormMergeAskMe6");
			if (strText != "")
				this.labGloss.Text = strText;
            strText = table.GetForm("FormMergeAskMe9");
			if (strText != "")
				this.labPoS.Text = strText;
            strText = table.GetForm("FormMergeAskMe12");
			if (strText != "")
				this.labRoot.Text = strText;
            strText = table.GetForm("FormMergeAskMe15");
			if (strText != "")
				this.labPlural.Text = strText;
            strText = table.GetForm("FormMergeAskMeA1");
			if (strText != "")
				this.rbKeep.Text = strText;
            strText = table.GetForm("FormMergeAskMeA2");
			if (strText != "")
				this.rbReplace.Text = strText;
            strText = table.GetForm("FormMergeAskMeA3");
			if (strText != "")
				this.rbBoth.Text = strText;
            strText = table.GetForm("FormMergeAskMe19");
			if (strText != "")
				this.btnOK.Text = strText;
            strText = table.GetForm("FormMergeAskMe20");
			if (strText != "")
				this.btnCancel.Text = strText;
            return;
        }

    }
}
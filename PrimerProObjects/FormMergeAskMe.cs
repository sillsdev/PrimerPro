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

        public FormMergeAskMe(Word wrd1, Word wrd2, LocalizationTable table, string lang)
        // wrd1 = Word from Original word list
        // wrd2 = Word from word list to be merged
        // table = Localization table
        // lang = UI language
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

            this.Text = table.GetForm("FormMergeAskMeT", lang);
            this.labInfo.Text = table.GetForm("FormMergeAskMe0", lang);
            this.labOrigWord.Text = table.GetForm("FormMergeAskMe1", lang);
            this.labNewWord.Text = table.GetForm("FormMergeAskMe2", lang);
            this.labWord.Text = table.GetForm("FormMergeAskMe3", lang);
            this.labGloss.Text = table.GetForm("FormMergeAskMe6", lang);
            this.labPoS.Text = table.GetForm("FormMergeAskMe9", lang);
            this.labRoot.Text = table.GetForm("FormMergeAskMe12", lang);
            this.labPlural.Text = table.GetForm("FormMergeAskMe15", lang);
            this.rbKeep.Text = table.GetForm("FormMergeAskMeA1", lang);
            this.rbReplace.Text = table.GetForm("FormMergeAskMeA2", lang);
            this.rbBoth.Text = table.GetForm("FormMergeAskMeA3", lang);
            this.btnOK.Text = table.GetForm("FormMergeAskMe19", lang);
            this.btnCancel.Text = table.GetForm("FormMergeAskMe20", lang);
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

    }
}
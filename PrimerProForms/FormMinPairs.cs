using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PrimerProObjects;
using PrimerProLocalization;
using GenLib;

namespace PrimerProForms
{
    public partial class FormMinPairs : Form
    {
        //private MinPairsSearch m_Search;        //Minimal Pair Search calling form
        private string m_Grapheme1;
        private string m_Grapheme2;
        private bool m_AllPairs;    //currently hidden from user
        private bool m_RootsOnly;
        private bool m_IgnoreTone;
        private bool m_AllowVowelHarmony;
        private PSTable m_PSTable;
        private Font m_Font;
        private string m_Lang;
        private LocalizationTable m_Table;
        private SearchOptions m_SearchOptions;

        public FormMinPairs(Settings settings)
        {
            InitializeComponent();
            m_PSTable = settings.PSTable;
            m_Font = settings.OptionSettings.GetDefaultFont();
            m_Table = null;
            m_SearchOptions = null;
            this.tbGrf1.Font = m_Font;
            this.tbGrf2.Font = m_Font;
        }

        public FormMinPairs(Settings settings, LocalizationTable table)
        {
            InitializeComponent();
            m_PSTable = settings.PSTable;
            m_Font = settings.OptionSettings.GetDefaultFont();
            m_Lang = settings.OptionSettings.UILanguage;
            m_Table = table;
            m_SearchOptions = null;
            this.tbGrf1.Font = m_Font;
            this.tbGrf2.Font = m_Font;

            this.UpdateFormForLocalization(table);
        }

        public string Grapheme1
        {
            get {return m_Grapheme1;}
        }

        public string Grapheme2
        {
            get {return m_Grapheme2;}
        }

        public bool AllPairs
        {
            get { return m_AllPairs; }
        }

        public bool RootsOnly
        {
            get {return m_RootsOnly;}
        }

        public bool IgnoreTone
        {
            get {return m_IgnoreTone;}
        }

        public bool AllowVowelHarmony
        {
            get {return m_AllowVowelHarmony;}
        }

        public SearchOptions SearchOptions
        {
            get { return m_SearchOptions; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            m_Grapheme1 = this.tbGrf1.Text;
            m_Grapheme2 = this.tbGrf2.Text;
            m_AllPairs = this.chkAll.Checked;
            m_RootsOnly = this.chkRoots.Checked;
            m_IgnoreTone = this.chkTone.Checked;
            m_AllowVowelHarmony = this.chkHarmony.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_SearchOptions = null;
            m_Grapheme1 = "";
            m_Grapheme2 = "";
            m_AllPairs = false;
            m_RootsOnly = false;
            m_IgnoreTone = false;
            m_AllowVowelHarmony = false;
            this.Close();
        }

        private void btnSO_Click(object sender, EventArgs e)
        {
            SearchOptions so = new SearchOptions(m_PSTable);
            CodeTable ct = (CodeTable)m_PSTable;
            //FormSearchOptions form = new FormSearchOptions(ct, true, false);
            FormSearchOptions form = new FormSearchOptions(ct, true, false, m_Table);
            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                so.PS = form.PSTE;
                so.IsRootOnly = form.IsRootOnly;
                so.IsIdenticalVowelsInRoot = form.IsIdenticalVowelsInRoot;
                so.IsIdenticalVowelsInWord = form.IsIdenticalVowelsInWord;
                so.IsBrowseView = form.IsBrowseView;
                so.WordCVShape = form.WordCVShape;
                so.RootCVShape = form.RootCVShape;
                so.MinSyllables = form.MinSyllables;
                so.MaxSyllables = form.MaxSyllables;
                so.WordPosition = form.WordPosition;
                so.RootPosition = form.RootPosition;
                m_SearchOptions = so;
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAll.Checked)
                this.tbGrf2.Enabled = false;
            else this.tbGrf2.Enabled = true;

        }

        private void UpdateFormForLocalization(LocalizationTable table)
        {
            string strText = "";
            strText = table.GetForm("FormMinPairsT");
			if (strText != "")
				this.Text = strText;
            strText = table.GetForm("FormMinPairs0");
			if (strText != "")
				this.labTitle.Text = strText;
            strText = table.GetForm("FormMinPairs1");
			if (strText != "")
				this.labGrf1.Text = strText;
            strText = table.GetForm("FormMinPairs3");
			if (strText != "")
				this.labGrf2.Text = strText;
            strText = table.GetForm("FormMinPairs5");
			if (strText != "")
				this.chkRoots.Text = strText;
            strText = table.GetForm("FormMinPairs6");
			if (strText != "")
				this.chkTone.Text = strText;
            strText = table.GetForm("FormMinPairs8");
			if (strText != "")
				this.chkHarmony.Text = strText;
            strText = table.GetForm("FormMinPairs9");
			if (strText != "")
				this.btnSO.Text = strText;
            strText = table.GetForm("FormMinPairs10");
			if (strText != "")
				this.btnOK.Text = strText;
            strText = table.GetForm("FormMinPairs11");
			if (strText != "")
				this.btnCancel.Text = strText;
            return;
        }
 
    }
}
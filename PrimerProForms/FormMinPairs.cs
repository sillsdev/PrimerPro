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
        private LocalizationTable m_Table;
        private string m_Lang;
        private SearchOptions m_SearchOptions;

        public FormMinPairs(PSTable pstable, Font fnt)
        {
            InitializeComponent();
            m_PSTable = pstable;
            m_Table = null;
            m_Lang = "";
            m_SearchOptions = null;
            this.tbGrf1.Font = fnt;
            this.tbGrf2.Font = fnt;
        }

        public FormMinPairs(PSTable pstable, Font fnt, LocalizationTable table, string lang)
        {
            InitializeComponent();
            m_PSTable = pstable;
            m_Table = table;
            m_Lang = lang;
            m_SearchOptions = null;
            this.tbGrf1.Font = fnt;
            this.tbGrf2.Font = fnt;

            this.Text = table.GetForm("FormMinPairsT", lang);
            this.labTitle.Text = table.GetForm("FormMinPairs0", lang);
            this.labGrf1.Text = table.GetForm("FormMinPairs1", lang);
            this.labGrf2.Text = table.GetForm("FormMinPairs3", lang);
            this.chkRoots.Text = table.GetForm("FormMinPairs5", lang);
            this.chkTone.Text = table.GetForm("FormMinPairs6", lang);
            this.chkHarmony.Text = table.GetForm("FormMinPairs8", lang);
            this.btnSO.Text = table.GetForm("FormMinPairs9", lang);
            this.btnOK.Text = table.GetForm("FormMinPairs10", lang);
            this.btnCancel.Text = table.GetForm("FormMinPairs11", lang);
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
            FormSearchOptions form = new FormSearchOptions(ct, true, false, m_Table, m_Lang);
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

    }
}
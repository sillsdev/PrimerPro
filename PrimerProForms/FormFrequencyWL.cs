using System;
using System.ComponentModel;
using System.Windows.Forms;
using PrimerProObjects;
using PrimerProLocalization;
using GenLib;

namespace PrimerProForms
{
    public partial class FormFrequencyWL : Form
    {
        private PSTable m_PSTable;
        private SearchOptions m_SearchOptions;
        private bool m_IgnoreSightWords;
        private bool m_IgnoreTone;
        private bool m_DisplayPercentages;
        private LocalizationTable m_Table;      //Localization table
        private string m_Lang;                  //UI language

        public FormFrequencyWL(PSTable pstable)
        {
            InitializeComponent();
            m_PSTable = pstable;
            m_Table = null;
            m_Lang = "";
        }

        public FormFrequencyWL(PSTable pstable, LocalizationTable table, string lang)
        {
            InitializeComponent();
            m_PSTable = pstable;
            m_Table = table;
            m_Lang = lang;

            this.Text = table.GetForm("FormFrequencyWLT", lang);
            this.chkIgnoreSightWords.Text = table.GetForm("FormFrequencyWL0", lang);
            this.chkIgnoreTone.Text = table.GetForm("FormFrequencyWL1", lang);
            this.chkDisplayPct.Text = table.GetForm("FormFrequencyWL2", lang);
            this.btnSO.Text = table.GetForm("FormFrequencyWL3", lang);
            this.btnOK.Text = table.GetForm("FormFrequencyWL4", lang);
            this.btnCancel.Text = table.GetForm("FormFrequencyWL5", lang);
        }

        public bool IgnoreSightWords
        {
            get { return m_IgnoreSightWords; }
        }

        public bool IgnoreTone
        {
            get { return m_IgnoreTone; }
        }

        public bool DisplayPercentages
        {
            get { return m_DisplayPercentages; }
        }

        public SearchOptions SearchOptions
        {
            get { return m_SearchOptions; }
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            m_IgnoreSightWords = this.chkIgnoreSightWords.Checked;
            m_IgnoreTone = this.chkIgnoreTone.Checked;
            m_DisplayPercentages = this.chkDisplayPct.Checked;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            m_IgnoreSightWords = false;
            m_IgnoreTone = false;
            m_DisplayPercentages = false;
            m_SearchOptions = null;
            this.Close();
        }

        private void btnSO_Click(object sender, System.EventArgs e)
        {
            SearchOptions so = new SearchOptions(m_PSTable);
            CodeTable ct = (CodeTable)m_PSTable;
            //FormSearchOptions form = new FormSearchOptions(ct, true, false);
            PrimerProForms.
            FormSearchOptions form = new FormSearchOptions(ct, false, false,
                m_Table, m_Lang);
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

    }
}
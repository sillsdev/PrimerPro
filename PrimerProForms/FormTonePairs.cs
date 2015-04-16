using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PrimerProObjects;
using PrimerProLocalization;
using GenLib;

namespace PrimerProForms
{
    public partial class FormTonePairs : Form
    {
        private string m_Grapheme;
        private bool m_AllowVowelHarmony;
        private PSTable m_PSTable;
        private LocalizationTable m_Table;
        private string m_Lang;
        private SearchOptions m_SearchOptions;

        public FormTonePairs(PSTable pstable, Font fnt)
        {
            InitializeComponent();
            m_PSTable = pstable;
            m_Table = null;
            m_Lang = "";
            m_SearchOptions = null;
            this.tbGrf.Font = fnt;
        }

        public FormTonePairs(PSTable pstable, Font fnt, LocalizationTable table, string lang)
        {
            InitializeComponent();
            m_PSTable = pstable;
            m_Table = table;
            m_Lang = lang;
            m_SearchOptions = null;
            this.tbGrf.Font = fnt;

            this.Text = table.GetForm("FormTonePairsT", lang);
            this.labTitle.Text = table.GetForm("FormTonePairs0", lang);
            this.labGrf.Text = table.GetForm("FormTonePairs1", lang);
            this.chkHarmony.Text = table.GetForm("FormTonePairs3", lang);
            this.btnSO.Text = table.GetForm("FormTonePairs4", lang);
            this.btnOK.Text = table.GetForm("FormTonePairs5", lang);
            this.btnCancel.Text = table.GetForm("FormTonePairs6", lang);
        }

        public string Grapheme
        {
            get {return m_Grapheme;}
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
            m_Grapheme = this.tbGrf.Text;
            m_AllowVowelHarmony = this.chkHarmony.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_SearchOptions = null;
            m_Grapheme = "";
            m_AllowVowelHarmony = false;
            this.Close();
        }

        private void btnSO_Click(object sender, EventArgs e)
        {
            SearchOptions so = new SearchOptions(m_PSTable);
            CodeTable ct = (CodeTable)m_PSTable;
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
                so.WordPosition = form.WordPosition;
                so.RootPosition = form.RootPosition;
            }
        }

    }
}
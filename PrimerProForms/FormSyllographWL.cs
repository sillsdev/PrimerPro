using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using PrimerProObjects;
using PrimerProLocalization;
using GenLib;

namespace PrimerProForms
{
    public partial class FormSyllographWL : Form
    {
        private string m_Grapheme;              //Grapheme (syllograph) selected;
        private SyllographFeatures m_Features;  //Syllograph features
        private bool m_UseGraphemesTaught;      //Restirct to graphemes taught
        private bool m_BrowseView;              //Display in browse view
        private SearchOptions m_SearchOptions;  //Search option selected
        private PSTable m_PSTable;              //Parts of Speech table
        private GraphemeInventory m_GI;         //Grapheme Inventory
        private Font m_Fnt;                                 //Default font
        private LocalizationTable m_Table;      //Localization table
        private string m_Lang;                  //UI language

        
        public FormSyllographWL(PSTable pstable, GraphemeInventory gi,Font fnt)
        {
            InitializeComponent();
            this.lblFeatures.Text = "";
            this.lblFeatures.Font = fnt;        //Font for displaying features
            this.tbSyllograph.Font = fnt;       //Font for displaying syllograph
            m_PSTable = pstable;                //PoS table used by Search Options
            m_GI = gi;                          //Grapheme Inventory used by Features;
            m_Fnt = fnt;
            m_Table = null;
            m_Lang = "";
        }

        public FormSyllographWL(PSTable pstable, GraphemeInventory gi, Font fnt, LocalizationTable table, string lang)
        {
            InitializeComponent();
            this.lblFeatures.Text = "";
            m_PSTable = pstable;                //PoS table used by Search Options
            m_GI = gi;                          //Grapheme Inventory used by Features;
            m_Fnt = fnt;
            m_Table = table;
            m_Lang = lang;

            this.Text = table.GetForm("FormSyllographWLT", lang);
            this.lblSyllograph.Text = table.GetForm("FormSyllographWL1", lang);
            this.btnFeatures.Text = table.GetForm("FormSyllographWL2", lang);
            this.chkGraphemesTaught.Text  = table.GetForm("FormSyllographWL3", lang);
            this.chkBrowseView.Text  = table.GetForm("FormSyllographWL4", lang);
            this.btnSO.Text = table.GetForm("FormSyllographWL5", lang);
            this.btnOK.Text = table.GetForm("FormSyllographWL6", lang);
            this.btnCancel.Text = table.GetForm("FormSyllographWL7", lang);
            this.lblFeatures.Font = fnt;        //Font for displaying features
            this.tbSyllograph.Font = fnt;       //Font for displaying syllograph
        }
        
        public string Grapheme 
        {
            get {return m_Grapheme;}
        }

        public SyllographFeatures Features
        {
            get {return m_Features;}
        }

        public bool UseGraphemesTaught
        {
            get {return m_UseGraphemesTaught;}
        }

        public bool BrowseView
        {
            get {return m_BrowseView;}
        }

        public SearchOptions SearchOptions
        {
            get { return m_SearchOptions; }
        }

        private void btnFeatures_Click(object sender, EventArgs e)
        {
            SyllographFeatures sf = new SyllographFeatures();
            FormSyllographFeatures form = new FormSyllographFeatures(sf, m_GI, m_Fnt, m_Table, m_Lang);
            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.tbSyllograph.Text = "";
                this.lblFeatures.Text = this.SyllographFeatureList(sf);
                if ((sf.CategoryPrimary == "") && (sf.CategorySecondary == "") && (sf.CategoryTertiary == ""))
                    m_Features = null;
                else m_Features = sf;
            }
        }

        private void tbSyllograph_TextChanged(object sender, EventArgs e)
        {
            lblFeatures.Text = "";
            m_Features = null;
        }

        private void btnOK_Click(object sender, System.EventArgs e)
		{

            m_Grapheme = tbSyllograph.Text;
            m_UseGraphemesTaught = chkGraphemesTaught.Checked;
            m_BrowseView = chkBrowseView.Checked;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
            m_Grapheme = "";
            m_UseGraphemesTaught = false;
            m_BrowseView = false;
			this.Close();
		}

        private void btnSO_Click(object sender, System.EventArgs e)
        {
            SearchOptions so = new SearchOptions(m_PSTable);
            CodeTable ct = (CodeTable) m_PSTable;
            FormSearchOptions form = new FormSearchOptions(ct, false, false, m_Table, m_Lang);
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

        private string SyllographFeatureList(SyllographFeatures sf)
        {
            string strList = "";
            if (sf.CategoryPrimary != "")
                strList += SyllographFeatures.SyllographType.Pri.ToString() + Constants.Equal + sf.CategoryPrimary + Constants.Space;
            if (sf.CategorySecondary != "")
                strList += SyllographFeatures.SyllographType.Sec.ToString() + Constants.Equal + sf.CategorySecondary + Constants.Space;
            if (sf.CategoryTertiary != "")
                strList += SyllographFeatures.SyllographType.Ter.ToString() + Constants.Equal + sf.CategoryTertiary + Constants.Space;
            strList = strList.Trim();
            return strList;
        }

    }
}

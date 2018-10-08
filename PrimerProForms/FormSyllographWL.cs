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
        private Font m_Fnt;                     //Default font
        private LocalizationTable m_Table;      //Localization table

        
        public FormSyllographWL(Settings s)
        {
            InitializeComponent();
            m_PSTable = s.PSTable;                       //PoS table used by Search Options
            m_GI = s.GraphemeInventory;                 //Grapheme Inventory used by Features;
            m_Fnt = s.OptionSettings.GetDefaultFont();
            m_Table = null;
            this.lblFeatures.Text = "";
            this.lblFeatures.Font = m_Fnt;             //Font for displaying features
            this.tbSyllograph.Font = m_Fnt;            //Font for displaying syllograph
        }

        public FormSyllographWL(Settings s, LocalizationTable table)
        {
            InitializeComponent();
            m_PSTable = s.PSTable;                      //PoS table used by Search Options
            m_GI = s.GraphemeInventory;                 //Grapheme Inventory used by Features;
            m_Fnt = s.OptionSettings.GetDefaultFont();
            m_Table = table;
            this.lblFeatures.Text = "";
            this.lblFeatures.Font = m_Fnt;              //Font for displaying features
            this.tbSyllograph.Font = m_Fnt;             //Font for displaying syllograph

            this.UpdateFormForLocalization(table);
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
            FormSyllographFeatures form = new FormSyllographFeatures(sf, m_GI, m_Fnt, m_Table);
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
            FormSearchOptions form = new FormSearchOptions(ct, false, false, m_Table);
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

        private void UpdateFormForLocalization(LocalizationTable table)
        {
            string strText = "";
            strText = table.GetForm("FormSyllographWLT");
			if (strText != "")
				this.Text = strText;
            strText = table.GetForm("FormSyllographWL1");
			if (strText != "")
				this.lblSyllograph.Text = strText;
            strText = table.GetForm("FormSyllographWL2");
			if (strText != "")
				this.btnFeatures.Text = strText;
            strText = table.GetForm("FormSyllographWL3");
			if (strText != "")
				this.chkGraphemesTaught.Text = strText;
            strText = table.GetForm("FormSyllographWL4");
			if (strText != "")
				this.chkBrowseView.Text = strText;
            strText = table.GetForm("FormSyllographWL5");
			if (strText != "")
				this.btnSO.Text = strText;
            strText = table.GetForm("FormSyllographWL6");
			if (strText != "")
				this.btnOK.Text = strText;
            strText = table.GetForm("FormSyllographWL7");
			if (strText != "")
				this.btnCancel.Text = strText;
            return;
        }

    }
}

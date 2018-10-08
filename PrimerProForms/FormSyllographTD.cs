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
    public partial class FormSyllographTD : Form
    {
        private string m_Grapheme;              //Grapheme (syllograph) selected;
        private SyllographFeatures m_Features;  //Syllograph features
        private bool m_ParaFormat;              //Paragraph Format
        private GraphemeInventory m_GI;         //Grapheme Inventory
        private Font m_Fnt;                     //Default font
        private LocalizationTable m_Table;      //Localization table
       
        public FormSyllographTD(GraphemeInventory gi, Font fnt)
        {
            InitializeComponent();
            this.lblFeatures.Text = "";
            this.lblFeatures.Font = fnt;        //Font for displaying features
            this.tbSyllograph.Font = fnt;       //Font for displaying syllograph
            m_GI = gi;                          //Grapheme Inventory used by Features;
            m_Fnt = fnt;
            m_Table = null;
        }

        public FormSyllographTD(GraphemeInventory gi, Font fnt, LocalizationTable table)
        {
            InitializeComponent();
            this.lblFeatures.Text = "";
            this.lblFeatures.Font = fnt;         //Font for displaying features
            this.tbSyllograph.Font = fnt;       //Font for displaying syllograph
            m_GI = gi;                                  //Grapheme Inventory used by Features;
            m_Fnt = fnt;
            m_Table = table;
            this.tbSyllograph.Font = fnt;

            this.UpdateFromForLocalization(table);
        }

        public string Grapheme
        {
            get { return m_Grapheme; }
        }

        public SyllographFeatures Features
        {
            get { return m_Features; }
        }

        public bool ParaFormat
        {
            get { return m_ParaFormat; }
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
            m_ParaFormat = chkParaFmt.Checked;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            m_Grapheme = "";
            m_ParaFormat = false;
            this.Close();
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

        private void UpdateFromForLocalization(LocalizationTable table)
        {
            string strText = "";
            strText = table.GetForm("FormSyllographTDT");
			if (strText != "")
				this.Text = strText;
            strText = table.GetForm("FormSyllographTD1");
			if (strText != "")
				this.lblSyllograph.Text = strText;
            strText = table.GetForm("FormSyllographTD2");
			if (strText != "")
				this.btnFeatures.Text = strText;
            strText = table.GetForm("FormSyllographTD3");
			if (strText != "")
				this.chkParaFmt.Text = strText;
            strText = table.GetForm("FormSyllographTD4");
			if (strText != "")
				this.btnOK.Text = strText;
            strText = table.GetForm("FormSyllographTD5");
			if (strText != "")
				this.btnCancel.Text = strText;
            return;
        }

    }
}

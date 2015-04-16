using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using PrimerProObjects;
using PrimerProLocalization;

namespace PrimerProForms
{
    public partial class FormSyllographFeatures : Form
    {
        private SyllographFeatures m_Features;
        private GraphemeInventory m_GI;
        private Font m_Fnt;
        private LocalizationTable m_Table;              //Localization table
        private string m_Lang;                          // UI Language
        
        public FormSyllographFeatures(SyllographFeatures sf, GraphemeInventory gi, Font fnt)
        {
            InitializeComponent();
            m_Features = sf;
            m_GI = gi;
            m_Fnt = fnt;
            m_Table = null;
            m_Lang = "";

            this.cbPrimary.Font = fnt;
            this.cbSecondary.Font = fnt;
            this.cbTertiary.Font = fnt;

            Syllograph m_Syllograph;
            string m_PrimaryCategory = "";
            string m_SecondaryCategory = "";
            string m_TertiaryCategory = "";
            SortedList slPrimary = new SortedList();
            SortedList slSecondary = new SortedList();
            SortedList slTertiary = new SortedList();
            int nCount = this.GI.SyllographCount();
            if (nCount > 0)
            {
                for (int i = 0; i < nCount; i++)
                {
                    m_Syllograph = this.GI.GetSyllograph(i);
                    m_PrimaryCategory = m_Syllograph.CategoryPrimary;
                    if (!slPrimary.ContainsKey(m_PrimaryCategory))
                    {
                        slPrimary.Add(m_PrimaryCategory, m_PrimaryCategory);
                        cbPrimary.Items.Add(m_PrimaryCategory);
                    }
                    m_SecondaryCategory = m_Syllograph.CategorySecondary;
                    if (!slSecondary.ContainsKey(m_SecondaryCategory))
                    {
                        slSecondary.Add(m_SecondaryCategory, m_SecondaryCategory);
                        cbSecondary.Items.Add(m_SecondaryCategory);
                    }
                    m_TertiaryCategory = m_Syllograph.CategoryTertiary;
                    if (!slTertiary.ContainsKey(m_TertiaryCategory))
                    {
                        slTertiary.Add(m_TertiaryCategory, m_TertiaryCategory);
                        cbTertiary.Items.Add(m_TertiaryCategory);
                    }
                }
            }
        }

        public FormSyllographFeatures(SyllographFeatures sf, GraphemeInventory gi,  Font fnt, 
            LocalizationTable table, string lang)
        {
            InitializeComponent();
            m_Features = sf;
            m_GI = gi;
            m_Fnt = fnt;
            m_Table = table;
            m_Lang = lang;
            
            this.Text = table.GetForm("FormSyllographFeaturesT", lang);
            this.labPrimary.Text = table.GetForm("FormSyllographFeatures1", lang);
            this.labSecondary.Text = table.GetForm("FormSyllographFeatures2", lang);
            this.labTertiary.Text = table.GetForm("FormSyllographFeatures3", lang);
            this.btnOK.Text = table.GetForm("FormSyllographFeatures4", lang);
            this.btnCancel.Text = table.GetForm("FormSyllographFeatures5", lang);
            this.cbPrimary.Font = fnt;
            this.cbSecondary.Font = fnt;
            this.cbTertiary.Font = fnt;
            
            Syllograph m_Syllograph;
            string m_Initial = "";
            string m_Medial = "";
            string m_Final = "";
            SortedList slInitial = new SortedList();
            SortedList slMedial = new SortedList();
            SortedList slFinal = new SortedList();
            int nCount = this.GI.SyllographCount();
            if (nCount > 0)
            {
                for (int i = 0; i < nCount; i++)
                {
                    m_Syllograph = this.GI.GetSyllograph(i);
                    m_Initial = m_Syllograph.CategoryPrimary;
                    if (!slInitial.ContainsKey(m_Initial))
                    {
                        slInitial.Add(m_Initial, m_Initial);
                        cbPrimary.Items.Add(m_Initial);
                    }
                    m_Medial = m_Syllograph.CategorySecondary;
                    if (!slMedial.ContainsKey(m_Medial))
                    {
                        slMedial.Add(m_Medial, m_Medial);
                        cbSecondary.Items.Add(m_Medial);
                    }
                    m_Final = m_Syllograph.CategoryTertiary;
                    if (!slFinal.ContainsKey(m_Final))
                    {
                        slFinal.Add(m_Final, m_Final);
                        cbTertiary.Items.Add(m_Final);
                    }
                }
            }
        }

        public SyllographFeatures Features
        {
            get { return m_Features; }
        }

        public GraphemeInventory GI
        {
            get { return m_GI; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            m_Features.CategoryPrimary = cbPrimary.Text.Trim();
            m_Features.CategorySecondary = cbSecondary.Text.Trim();
            m_Features.CategoryTertiary = cbTertiary.Text.Trim();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            m_Features = null;
            this.Close();
        }


    }
}

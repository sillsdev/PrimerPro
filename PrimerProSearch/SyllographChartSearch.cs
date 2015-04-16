using System;
using PrimerProObjects;

namespace PrimerProSearch
{
    /// <summary>
    /// Syllograph Chart Search
    /// </summary>
    public class SyllographChartSearch : Search
    {
        private string m_Title;
        private Settings m_Settings;
        private SyllographChartTable m_Table;

        public SyllographChartSearch(int number, Settings s)
            : base(number, SearchDefinition.kSyllograph)
        {
            m_Settings = s;
            //m_Title = "Syllograph Chart Search";
            m_Title = m_Settings.LocalizationTable.GetMessage("SyllographChartSearchT",
                m_Settings.OptionSettings.UILanguage);
            m_Table = new SyllographChartTable();
        }

        public string Title
        {
            get { return m_Title; }
        }

        public SyllographChartTable Table
        {
            get { return m_Table; }
            set { m_Table = value; }
        }

        public bool SetupSearch()
        {
            SearchDefinition sd = new SearchDefinition(SearchDefinition.kSyllograph);
            this.SearchDefinition = sd;
            return true;
        }

        public bool SetupSearch(SearchDefinition sd)
        {
            this.SearchDefinition = sd;
            return true;
        }

        public string BuildResults()
        {
            string strText = "";
            string strSN = Search.TagSN + this.SearchNumber.ToString().Trim();
            strText += Search.TagOpener + strSN + Search.TagCloser + Environment.NewLine;
            strText += this.Title;
            strText += Environment.NewLine + Environment.NewLine;
            strText += this.SearchResults;
            strText += Search.TagOpener + Search.TagForwardSlash + strSN
                + Search.TagCloser;
            return strText;
        }

        public void ExecuteSyllographChart(GraphemeInventory gi)
        {
            this.SearchResults = "";
            SyllographChartTable tbl = BuildSyllographTable(gi);
            this.SearchResults += tbl.GetColumnHeaders();
            this.SearchResults += tbl.GetRows();
            return;
        }

        private SyllographChartTable BuildSyllographTable(GraphemeInventory gi)
        {
            SyllographChartTable tbl = new SyllographChartTable();
            Syllograph syllograph = null;
            string strSym = "";
            string strPrimaryCategory = "";
            string strSecondaryCategory = "";
            string strTertiaryCategory = "";

            for (int i = 0; i < gi.SyllographCount(); i++)
            {
                syllograph = gi.GetSyllograph(i);
                strSym = syllograph.Symbol;
                strPrimaryCategory = syllograph.CategoryPrimary;
                strSecondaryCategory = syllograph.CategorySecondary;
                strTertiaryCategory = syllograph.CategoryTertiary;
                tbl = tbl.AddRow(strSym, strPrimaryCategory, strSecondaryCategory, strTertiaryCategory);
            }
            return tbl;
        }

    }
}

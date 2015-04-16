using System;
using PrimerProObjects;

namespace PrimerProSearch
{
	/// <summary>
	/// Summary description for ToneChartSearch.
	/// </summary>
	public class ToneChartSearch : Search
	{
		private string m_Title;
        private Settings m_Settings;
		private ToneChartTable m_Table;

        //private const string kTitle = "Tone Chart";

		public ToneChartSearch(int number, Settings s) : base(number, SearchDefinition.kTone)
		{
            m_Settings = s;
			m_Title = m_Settings.LocalizationTable.GetMessage("ToneChartSearchT",
                m_Settings.OptionSettings.UILanguage);
			m_Table = new ToneChartTable();
		}

		public string Title
		{
			get {return m_Title;}
		}

		public ToneChartTable Table
		{
			get {return m_Table;}
			set {m_Table = value;}
		}

		public bool SetupSearch()
		{
			SearchDefinition sd = new SearchDefinition(SearchDefinition.kTone);
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

        public void ExecuteToneChart(GraphemeInventory gi)
        {
            this.SearchResults = "";
            ToneChartTable tbl = BuildToneTable(gi);
            this.SearchResults += tbl.GetColumnHeaders();
            this.SearchResults += tbl.GetRows();
            return;
        }

        private ToneChartTable BuildToneTable(GraphemeInventory gi)
        {
            ToneChartTable tbl = new ToneChartTable();
            Tone tone = null;
            string strSym = "";
            string strLvl = "";
            string strTBU = "";

            for (int i = 0; i < gi.ToneCount(); i++)
            {
                tone = gi.GetTone(i);
                strSym = tone.Symbol;
                strLvl = tone.Level;
                if (tone.ToneBearingUnit != null)
                    strTBU = tone.ToneBearingUnit.Symbol;
                else strTBU = "";
                tbl = tbl.AddRow(strSym, strLvl, strTBU);
            }
            return tbl;
        }

	}
}

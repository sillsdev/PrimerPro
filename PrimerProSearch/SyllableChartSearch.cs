using System;
using System.Windows.Forms;
using System.Data;
using PrimerProForms;
using PrimerProObjects;
using GenLib;

namespace PrimerProSearch
{
	/// <summary>
	/// 
	/// </summary>
	public class SyllableChartSearch : Search
	{
        //Search parameters 
        private FormSyllableChart.StructureType m_Type;
        private string m_Title;
        private Settings m_Settings;
        private SyllableChartTable m_Table;

        //public enum StructureType {Word, Root};
		private const string kWord = "Word";
		private const string kRoot = "Root";

        //private const string kTitle = "Syllable Chart";
        //private const string kSearch = "Processing Syllable Chart Search";
		
		public SyllableChartSearch(int number, Settings s) : base(number, SearchDefinition.kSyllable)
        {
            m_Settings = s;
			m_Type = FormSyllableChart.StructureType.Word;
            m_Title = m_Settings.LocalizationTable.GetMessage("SyllableChartSearchT");
            if (m_Title == "")
                m_Title = "Syllable Chart";
            m_Table = null;
		}

		public FormSyllableChart.StructureType Type
		{
			get	{return m_Type;}
			set {m_Type = value;}
		}

		public string Title
		{
			get {return m_Title;}
		}

        public SyllableChartTable Table
        {
            get { return m_Table; }
            set { m_Table = value; }
        }

		public bool SetupSearch()
		{
			bool flag = false;
            string strText = "";
            FormSyllableChart form = new FormSyllableChart(m_Settings.LocalizationTable);
			DialogResult dr = form.ShowDialog();
			if (dr == DialogResult.OK)
			{
				SearchDefinition sd = new SearchDefinition(SearchDefinition.kSyllable);
				SearchDefinitionParm sdp;
                m_Type = form.Type;
				if (m_Type == FormSyllableChart.StructureType.Root)
				{
					sdp = new SearchDefinitionParm(SyllableChartSearch.kRoot);
					sd.AddSearchParm(sdp);
                    //m_Title = SyllableChartSearch.kRoot + Constants.Space + m_Title;
                    strText = m_Settings.LocalizationTable.GetMessage("SyllableChartSearch3");
                    if (strText == "")
                        strText = "Root";
                    m_Title = strText + Constants.Space + m_Title;
                    flag = true;
				}
                if (m_Type == FormSyllableChart.StructureType.Word)
				{
					sdp = new SearchDefinitionParm(SyllableChartSearch.kWord);
					sd.AddSearchParm(sdp);
                    //m_Title = SyllableChartSearch.kWord + Constants.Space + m_Title;
                    strText = m_Settings.LocalizationTable.GetMessage("SyllableChartSearch2");
                    if (strText == "")
                        strText = "Word";
                    m_Title = strText + Constants.Space + m_Title;
					flag = true;
				}
				this.SearchDefinition = sd;
			}
			return flag;
		}

		public bool SetupSearch(SearchDefinition sd)
		{
			bool flag = true;
            string strTag = "";
            string strText = "";
            for (int i = 0; i < sd.SearchParmsCount(); i++)
            {
                strTag = sd.GetSearchParmAt(i).GetTag();
                switch (strTag)
                {
                    case SyllableChartSearch.kWord:
                        this.Type = FormSyllableChart.StructureType.Word;
                        //m_Title = SyllableChartSearch.kWord + Constants.Space.ToString() + SyllableChartSearch.kTitle;
                        strText = m_Settings.LocalizationTable.GetMessage("SyllableChartSearch2");
                        if (strText == "")
                            strText = "Word";
                        m_Title =strText + Constants.Space + m_Title;
                        break;
                    case SyllableChartSearch.kRoot:
                        this.Type = FormSyllableChart.StructureType.Root;
                        //m_Title = SyllableChartSearch.kRoot + Constants.Space.ToString() + SyllableChartSearch.kTitle;
                        strText = m_Settings.LocalizationTable.GetMessage("SyllableChartSearch3");
                        if (strText == "")
                            strText = "Root";
                        m_Title = strText + Constants.Space + m_Title;
                        break;
                    default:
                        break;
                }
            }
            this.SearchDefinition = sd;
			return flag;
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

        public SyllableChartSearch ExecuteSyllableChart(WordList wl)
        {
            this.SearchResults = "";
            SyllableChartTable tbl = BuildSyllableTable(wl);
            this.Table = tbl;
            this.SearchResults += tbl.GetColumnHeaders();
            this.SearchResults += tbl.GetRows();
            return this;
        }

        private SyllableChartTable BuildSyllableTable(WordList wl)
        {
            Word wrd = null;
            string strText = "";
            string strPatt = "";
            int nRow = 0;
            SyllableChartTable tbl = null;
            strText = m_Settings.LocalizationTable.GetMessage("SyllableChartSearch1");
            if (strText == "")
                strText = "Processing Syllable Chart Search";
            FormProgressBar form = new FormProgressBar(strText);
            form.PB_Init(0, wl.WordCount());

            if (this.Type == FormSyllableChart.StructureType.Root)
            {
                tbl = new SyllableChartTable(FormSyllableChart.StructureType.Root);
                for (int i = 0; i < wl.WordCount(); i++)
                {
                    form.PB_Update(i);
                    wrd = wl.GetWord(i);
                    if (wrd.ContainInWord(Constants.Space.ToString()))
                        continue;        // ignore multi-words
                    for (int k = 0; k < wrd.Root.SyllableCount(); k++)
                    {
                        Syllable syll = wrd.Root.GetSyllable(k);
                        strPatt = syll.CVPattern;
                        if (strPatt != "")
                        {
                            nRow = tbl.GetRowIndex(strPatt);
                            if (k == 0)
                                //tbl.IncrChartCell(nRow, 1);
                                tbl.UpdateChartCell(nRow, 1, wrd);
                            if (k == (wrd.Root.SyllableCount() - 1))
                                //tbl.IncrChartCell(nRow, 3);
                                tbl.UpdateChartCell(nRow, 3, wrd);
                            if ((0 < k) && (k < (wrd.Root.SyllableCount() - 1)))
                                //tbl.IncrChartCell(nRow, 2);
                                tbl.UpdateChartCell(nRow, 2, wrd);
                        }
                    }
                }
            }
            else
            {
                tbl = new SyllableChartTable(FormSyllableChart.StructureType.Word);
                for (int i = 0; i < wl.WordCount(); i++)
                {
                    form.PB_Update(i);
                    wrd = wl.GetWord(i);
                    if (wrd.ContainInWord(Constants.Space.ToString()))
                        continue;        // ignore multi-words
                    for (int k = 0; k < wrd.SyllableCount(); k++)
                    {
                        Syllable syll = wrd.GetSyllable(k);
                        strPatt = syll.CVPattern;
                        if (strPatt != "")
                        {
                            nRow = tbl.GetRowIndex(strPatt);
                            if (k == 0)
                                //tbl.IncrChartCell(nRow, 1);
                                tbl.UpdateChartCell(nRow, 1, wrd);
                            if (k == (wrd.SyllableCount() - 1))
                                //tbl.IncrChartCell(nRow, 3);
                                tbl.UpdateChartCell(nRow, 3, wrd);
                            if ((0 < k) && (k < (wrd.SyllableCount() - 1)))
                                //tbl.IncrChartCell(nRow, 2);
                                tbl.UpdateChartCell(nRow, 2, wrd);
                        }
                    }
                }
            }
            form.Close();
            return tbl;
        }

    }
}

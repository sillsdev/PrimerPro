using System;
using System.Windows.Forms;
using System.Collections;
using PrimerProForms;
using PrimerProObjects;
using GenLib;


namespace PrimerProSearch
{
    public class SyllableCountSearch : Search
    {
        //Search parameters
        private bool m_AlphaSortOrder;
        private bool m_NumerSortOrder;
        private bool m_IgnoreTone;
        private bool m_UseGraphemesTaught;

        private Settings m_Settings;
        private GraphemeTaughtOrder m_GTO;
        private string m_Title;

        //Search definition tags
        private const string kAlpha = "sortalpha";
        private const string kNumer = "sortnumer";
        private const string kIgnoreTone = "ignoretone";
        private const string kUseGraphemesTaught = "usegraphemestaught";

        //private const string kTitle = "Syllable Count Search from Text Data";

		public SyllableCountSearch(int number, Settings s) : base(number, SearchDefinition.kCount)
		{
            m_Settings = s;
            m_GTO = m_Settings.GraphemesTaught;
			m_Title = m_Settings.LocalizationTable.GetMessage("SyllableCountSearchT");
            if (m_Title == "")
                m_Title = "Syllable Count Search from Text Data";
            m_AlphaSortOrder = true;
            m_NumerSortOrder = false;
            m_IgnoreTone = false;
            m_UseGraphemesTaught = false;
        }

        public bool AlphaSortOrder
        {
            get { return m_AlphaSortOrder; }
            set { m_AlphaSortOrder = value; }
        }

        public bool NumerSortOrder
        {
            get { return m_NumerSortOrder; }
            set { m_NumerSortOrder = value; }
        }

        public bool IgnoreTone
        {
            get { return m_IgnoreTone; }
            set { m_IgnoreTone = value; }
        }

        public bool UseGraphemesTaught
        {
            get { return m_UseGraphemesTaught; }
            set { m_UseGraphemesTaught = value; }
        }

        public string Title
        {
            get { return m_Title; }
        }

        public GraphemeTaughtOrder GTO
        {
            get { return m_GTO; }
        }

        public bool SetupSearch()
        {
            bool flag = false;
            FormSyllableCount form = new FormSyllableCount(m_Settings.LocalizationTable);
            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.AlphaSortOrder = form.AlphaSortOrder;
                this.NumerSortOrder = form.NumerSortOrder;
                this.IgnoreTone = form.IgnoreTone;
                this.UseGraphemesTaught = form.UseGraphemesTaught;

                SearchDefinition sd = new SearchDefinition(SearchDefinition.kSyllCount);
                SearchDefinitionParm sdp = null;
                if (this.NumerSortOrder)
                {
                    sdp = new SearchDefinitionParm(SyllableCountSearch.kNumer);
                    sd.AddSearchParm(sdp);
                }
                if (this.AlphaSortOrder)
                {
                    sdp = new SearchDefinitionParm(SyllableCountSearch.kAlpha);
                    sd.AddSearchParm(sdp);
                }
                if (form.IgnoreTone)
                {
                    sdp = new SearchDefinitionParm(SyllableCountSearch.kIgnoreTone);
                    sd.AddSearchParm(sdp);
                }
                if (form.UseGraphemesTaught)
                {
                    sdp = new SearchDefinitionParm(SyllableCountSearch.kUseGraphemesTaught);
                    sd.AddSearchParm(sdp);
                }
                this.SearchDefinition = sd;
                flag = true;
            }
            return flag;
        }

        public bool SetupSearch(SearchDefinition sd)
        {
            bool flag = false;
            string strTag = "";
            for (int i = 0; i < sd.SearchParmsCount(); i++)
            {
                strTag = sd.GetSearchParmAt(i).GetTag();
                if (strTag == SyllableCountSearch.kAlpha)
                {
                    this.AlphaSortOrder = true;
                    this.NumerSortOrder = false;
                    flag = true;
                }
                if (strTag == SyllableCountSearch.kNumer)
                {
                    this.AlphaSortOrder = false;
                    this.NumerSortOrder = true;
                    flag = true;
                }
                if (strTag == SyllableCountSearch.kIgnoreTone)
                {
                    this.IgnoreTone = true;
                    flag = true;
                }
                if (strTag == SyllableCountSearch.kUseGraphemesTaught)
                {
                    this.UseGraphemesTaught = true;
                    flag = true;
                }
            }
            this.SearchDefinition = sd;
            return flag;
        }

        public string BuildResults()
        {
            string strText = "";
            string str = "";
            string strSN = Search.TagSN + this.SearchNumber.ToString().Trim();
            strText += Search.TagOpener + strSN + Search.TagCloser + Environment.NewLine;
            strText += this.Title + Environment.NewLine + Environment.NewLine;
            strText += this.SearchResults;
            strText += Environment.NewLine;
            //strText += this.SearchCount.ToString() + " entries found" + Environment.NewLine;
            str = m_Settings.LocalizationTable.GetMessage("Search2");
            if (str == "")
                str = "entries found";
            strText += this.SearchCount.ToString() + Constants.Space + str + Environment.NewLine;
            strText += Search.TagOpener + Search.TagForwardSlash + strSN + Search.TagCloser;
            return strText;
        }
        
        public SyllableCountSearch ExecuteSyllableCountSearch(TextData td)
        {
            SortedList sl = null;
            char chSortOrder = 'A';
            if (this.NumerSortOrder)
                chSortOrder = 'N';
            ArrayList alGTO = new ArrayList();
            if (this.GTO != null)
                alGTO = this.GTO.Graphemes;

            string strLine = "";
            string strRslt = "";

            sl = td.GetSyllableCounts(chSortOrder, this.IgnoreTone, this.UseGraphemesTaught, alGTO);
            for (int i = 0; i < sl.Count; i++)
            {
                if (chSortOrder == 'N')
                    strLine = sl.GetByIndex(i).ToString() + Constants.Tab
                    + sl.GetKey(i).ToString().Substring(0, 5) + Environment.NewLine;
                else strLine = sl.GetKey(i).ToString() + Constants.Tab
                    + sl.GetByIndex(i).ToString().PadLeft(5) + Environment.NewLine;
                strRslt += strLine;
            }
            this.SearchResults = strRslt;
            this.SearchCount = sl.Count;
            return this;
        }
        
    }
}

using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using PrimerProForms;
using PrimerProObjects;
using GenLib;

namespace PrimerProSearch
{
	/// <summary>
	/// 
	/// </summary>
	public class GeneralWLSearch : Search
	{
        //Search parameters 
        private string m_PoS;               //Part of Speech
		private bool m_IsRootOnly;
		private bool m_IsIdenticalVowelsInWord;
		private bool m_IsIdenticalVowelsInRoot;
        private bool m_BrowseView;
		private string m_WordCVShape;
		private string m_RootCVShape;
        private int m_MinSyllables;
        private int m_MaxSyllables;
		private SearchOptions.Position m_WordPosition;
        private SearchOptions.Position m_RootPosition;

        private string m_Title;             //Search title
        private Settings m_Settings;        //Application Settings
        private PSTable m_PSTable;		    //Parts of Speech entry
        private Font m_DefaultFont;         //Default Font
        private Color m_HighlightColor;     //Highlight Color
        
        //private const string kTitle = "General Search";
        //private const string kBrowseTitle = kTitle + " Browse View";

		public GeneralWLSearch(int number, Settings s)
            : base(number, SearchDefinition.kGeneralWL)
		{
 			m_IsRootOnly = false;
			m_IsIdenticalVowelsInWord = false;
			m_IsIdenticalVowelsInRoot = false;
            m_BrowseView = false;
			m_WordCVShape = "";
			m_RootCVShape = "";
            m_MinSyllables = 0;
            m_MaxSyllables = 0;
			m_WordPosition = SearchOptions.Position.Any;
			m_RootPosition = SearchOptions.Position.Any;

            m_Settings = s;
            //m_Title = "General Search";
            m_Title = m_Settings.LocalizationTable.GetMessage("GeneralSearchT");
            if (m_Title == "")
                m_Title = "General Search";
            m_PSTable = m_Settings.PSTable;
            m_DefaultFont = m_Settings.OptionSettings.GetDefaultFont();
            m_HighlightColor = m_Settings.OptionSettings.HighlightColor;
		}

        public string PoS
        {
            get { return m_PoS; }
            set { m_PoS = value; }
        }

        public bool IsRootOnly
		{
			get {return m_IsRootOnly;}
            set { m_IsRootOnly = value; }
		}

		public bool IsIdenticalVowelsInWord
		{
			get {return m_IsIdenticalVowelsInWord;}
            set { m_IsIdenticalVowelsInWord = value; }
		}
		
		public bool IsIdenticalVowelsInRoot
		{
			get {return m_IsIdenticalVowelsInRoot;}
            set { m_IsIdenticalVowelsInRoot = value; }
		}

        public bool BrowseView
        {
            get { return m_BrowseView; }
            set { m_BrowseView = value; }
        }

        public string WordCVShape
		{
			get {return m_WordCVShape;}
            set { m_WordCVShape = value; }
		}

		public string RootCVShape
		{
			get {return m_RootCVShape;}
            set { m_RootCVShape = value; }
		}

        public int MinSyllables
        {
            get { return m_MinSyllables; }
            set { m_MinSyllables = value; }
        }

        public int MaxSyllables
        {
            get { return m_MaxSyllables; }
            set { m_MaxSyllables = value; }
        }

		public SearchOptions.Position WordPosition
		{
			get	{return m_WordPosition;}
            set { m_WordPosition = value; }
		}

        public SearchOptions.Position RootPosition
		{
			get {return m_RootPosition;}
            set { m_RootPosition = value; }
		}

		public string Title
		{
			get {return m_Title;}
		}

		public PSTable PSTable
		{
			get {return m_PSTable;}
		}

        public Color HighlightColor
        {
            get { return m_HighlightColor; }
        }

        public Font DefaultFont
        {
            get { return m_DefaultFont; }
        }

        public bool SetupSearch()
		{
			bool flag = false;
            FormSearchOptions form = new FormSearchOptions(this.PSTable, true, true, m_Settings.LocalizationTable);
			form.Text = m_Settings.LocalizationTable.GetMessage("GeneralSearchT");
            if (form.Text == "")
                form.Text = "General Search";
            DialogResult dr = form.ShowDialog();
			if ( dr == DialogResult.OK )
			{
                if (form.PSTE != null)
                    this.PoS = form.PSTE.Code;
                this.IsRootOnly = form.IsRootOnly;
                this.IsIdenticalVowelsInWord = form.IsIdenticalVowelsInWord;
                this.IsIdenticalVowelsInRoot = form.IsIdenticalVowelsInRoot;
                this.WordCVShape = form.WordCVShape;
                this.RootCVShape = form.RootCVShape;
                this.MinSyllables = form.MinSyllables;
                this.MaxSyllables = form.MaxSyllables;
                this.WordPosition = form.WordPosition;
                this.BrowseView = form.IsBrowseView;

                SearchDefinition sd = new SearchDefinition(SearchDefinition.kGeneralWL);
                SearchDefinitionParm sdp = null;
                this.SearchDefinition = sd;

                if (this.PoS != "")
                {
                    sdp = new SearchDefinitionParm(SearchOptions.kPS, this.PoS);
                    sd.AddSearchParm(sdp);
                }
                if (this.IsRootOnly)
                {
                    sdp = new SearchDefinitionParm(SearchOptions.kRootsOnly);
                    sd.AddSearchParm(sdp);
                }
                if (this.IsIdenticalVowelsInWord)
                {
                    sdp = new SearchDefinitionParm(SearchOptions.kSameVowelsInWord);
                    sd.AddSearchParm(sdp);
                }
                if (this.IsIdenticalVowelsInRoot)
                {
                    sdp = new SearchDefinitionParm(SearchOptions.kSameVowelsInRoot);
                }
                if (this.WordCVShape != "")
                {
                    sdp = new SearchDefinitionParm(SearchOptions.kWordCVShape,this.WordCVShape);
                    sd.AddSearchParm(sdp);
                }
                if (this.RootCVShape != "")
                {
                    sdp = new SearchDefinitionParm(SearchOptions.kRootCVShape,this.RootCVShape);
                    sd.AddSearchParm(sdp);
                }
                if (this.MinSyllables > 0)
                {
                    sdp = new SearchDefinitionParm(SearchOptions.kMinSyllables, this.MinSyllables.ToString().Trim());
                    sd.AddSearchParm(sdp);
                }
                if (this.m_MaxSyllables > 0)
                {
                    sdp = new SearchDefinitionParm(SearchOptions.kMaxSyllales, this.m_MaxSyllables.ToString().Trim());
                    sd.AddSearchParm(sdp);
                }
                if (this.WordPosition != SearchOptions.Position.Any)
                {
                    sdp = new SearchDefinitionParm(SearchOptions.kWordPosition, this.WordPosition.ToString());
                    sd.AddSearchParm(sdp);
                }
                if (this.RootPosition != SearchOptions.Position.Any)
                {
                    sdp = new SearchDefinitionParm(SearchOptions.kRootPosition, this.RootPosition.ToString());
                    sd.AddSearchParm(sdp);
                }
                if (this.BrowseView)
                {
                    sdp = new SearchDefinitionParm(SearchOptions.kBrowseView);
                    sd.AddSearchParm(sdp);
                }
				this.SearchDefinition = sd;
                flag = true;
			}
			return flag;
		}

		public bool SetupSearch(SearchDefinition sd)
		{
			bool flag = true;
			this.SearchDefinition = sd;
			return flag;
		}

		public string BuildResults()
		{
			string strText = "";
			string strSN = Search.TagSN + this.SearchNumber.ToString().Trim();
            string str = "";
			strText += Search.TagOpener + strSN	+ Search.TagCloser + Environment.NewLine;
			strText += this.Title + Environment.NewLine + Environment.NewLine;
			strText += this.SearchResults;
			strText += Environment.NewLine;
            //strText += this.SearchCount.ToString() + " entries found" + Environment.NewLine;
            str = m_Settings.LocalizationTable.GetMessage("Search2");
            if (str == "")
                str = "entries found";
            strText +=  this.SearchCount.ToString() + Constants.Space + str + Environment.NewLine;
			strText += Search.TagOpener + Search.TagForwardSlash + strSN + Search.TagCloser;
			return strText;
		}

        public GeneralWLSearch ExecuteGeneralSearch(WordList wl)
        {
            int nCount = 0;
            string strResult = wl.GetDisplayHeadings() + Environment.NewLine;
            SearchOptions so = new SearchOptions(this.PSTable);
            so = this.SearchDefinition.MakeSearchOptions(so);

            Word wrd = null;
            int nWord = wl.WordCount();
            for (int i = 0; i < nWord; i++)
            {
                wrd = wl.GetWord(i);
                if (so != null)
                {
                    if (so.MatchesWord(wrd))
                    {
                        nCount++;
                        strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
                    }
                }
            }
            if (nCount > 0)
            {
                this.SearchResults = strResult;
                this.SearchCount = nCount;
            }
            else
            {
                //this.SearchResults = "***No Results***";
                this.SearchResults = m_Settings.LocalizationTable.GetMessage("Search1");
                if (this.SearchResults == "")
                    this.SearchResults = "***No Results***";
                this.SearchCount = 0;
            }
            return this;
        }

        public GeneralWLSearch BrowseGeneralSearch(WordList wl)
        {
            int nCount = 0;
            string str = "";
            ArrayList al = null;
            Color clr = this.HighlightColor;
            Font fnt = this.DefaultFont;
            Word wrd = null; ;
            FormBrowse form = new FormBrowse();
            str = m_Settings.LocalizationTable.GetMessage("SearchB");
            if (str == "")
                str = "Browse View";
            form.Text = this.Title + " - " + str;
            
            al = wl.GetDisplayHeadingsAsArray();
            form.AddColHeaders(al, clr, fnt);

            SearchOptions so = new SearchOptions(m_Settings.PSTable);
            so = this.SearchDefinition.MakeSearchOptions(so);

            for (int i = 0; i < wl.WordCount(); i++)
            {
                wrd = wl.GetWord(i);
                if (so != null)
                {
                    if (so.MatchesWord(wrd))
                    {
                        nCount++;
                        al = wrd.GetWordInfoAsArray();
                        form.AddRow(al);
                    }
                }
            }

            //form.Text += " - " + nCount.ToString() + " entries";
            str = m_Settings.LocalizationTable.GetMessage("Search3");
            if (str == "")
                str = "entries";
            form.Text += " - " + nCount.ToString() + Constants.Space + str;
            form.Show();
            return this;
        }

    }
}

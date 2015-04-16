using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using PrimerProForms;
using PrimerProObjects;
//using PrimerProLocalization;
using GenLib;

namespace PrimerProSearch
{
	/// <summary>
	/// 
	/// </summary>
	public class BuildableWordSearchWL : Search
	{

        //Search parameters 
        private ArrayList m_Graphemes;			//list of graphemes for buildable words
        private ArrayList m_Highlights;         //graphemes to highlight
        private bool m_BrowseView;              //Display in browse view
		private SearchOptions m_SearchOptions;	//search options filter

        private string m_Title;					//search title
        private Settings m_Settings;            //Application Settings
        private PSTable m_PSTable;	        	//Parts of Speech
        private GraphemeInventory m_GI;         //Grapheme Inventory
        private GraphemeTaughtOrder m_GraphemesTaught;  //Grapheme Taught Order
        private Font m_DefaultFont;             //Default Font

		//Search Definition tags
        private const string kGrapheme = "grapheme";
        private const string kHighlight = "highlight";
        private const string kBrowseView = "browseview";

        //private const string kTitle = "Buildable Words Search";
        //private const string kSearch = "Processing Buildable Word Search";

		public BuildableWordSearchWL(int number, Settings s)
            : base(number, SearchDefinition.kBuildable)
		{
            m_Graphemes = null;
            m_Highlights = null;
            m_BrowseView = false;
			m_SearchOptions = null;

            m_Settings = s;
            //m_Title = BuildableWordsSearchWL.kTitle;
            m_Title = m_Settings.LocalizationTable.GetMessage("BuildableWordsSearchWLT",
                m_Settings.OptionSettings.UILanguage);
            m_PSTable = m_Settings.PSTable;
            m_GI = m_Settings.GraphemeInventory;
            m_GraphemesTaught = m_Settings.GraphemesTaught;
            m_DefaultFont = m_Settings.OptionSettings.GetDefaultFont();
		}

        public ArrayList Graphemes
		{
            get { return m_Graphemes; }
            set { m_Graphemes = value; }
		}

        public ArrayList Highlights
        {
            get { return m_Highlights; }
            set { m_Highlights = value; }
        }

        public bool BrowseView
        {
            get { return m_BrowseView; }
            set { m_BrowseView = value; }
        }

        public SearchOptions SearchOptions
		{
			get {return m_SearchOptions;}
			set {m_SearchOptions = value;}
		}

		public string Title
		{
			get {return m_Title;}
		}

		public PSTable PSTable
		{
			get {return m_PSTable;}
		}

        public GraphemeInventory GI
        {
            get { return m_GI; }
        }

        public GraphemeTaughtOrder GraphemesTaught
        {
            get { return m_GraphemesTaught; }
        }

        public Font DefaultFont
        {
            get { return m_DefaultFont; }
        }

        public string GetGrapheme(int n)
		{
            return (string)m_Graphemes[n];
		}

        public int GraphemesCount()
		{
            return m_Graphemes.Count;
		}

        public string GetHighlight(int n)
        {
            return (string) m_Highlights[n];
        }

        public int HighlightsCount()
        {
            return m_Highlights.Count;
        }

		public bool SetupSearch()
		{
			bool flag = false;
            //FormBuildableWords fpb = new FormBuildableWords(m_GI, m_GraphemesTaught,
            //    m_PSTable, m_DefaultFont);
            FormBuildableWordsWL form = new FormBuildableWordsWL(m_GI, m_GraphemesTaught,
                m_PSTable, m_DefaultFont, m_Settings.LocalizationTable,
                m_Settings.OptionSettings.UILanguage);
			DialogResult dr = form.ShowDialog();
			if ( dr == DialogResult.OK )
			{
                this.Graphemes = form.Graphemes;
                this.Highlights = form.Highlights;
                this.BrowseView = form.BrowseView;
                this.SearchOptions = form.SearchOptions;

                if (this.Graphemes != null)
                {
                    SearchDefinition sd = new SearchDefinition(SearchDefinition.kBuildable);
                    SearchDefinitionParm sdp = null;
                    this.SearchDefinition = sd;

                    string strSym = "";
                    string strGrfs = "";
                    for (int i = 0; i < this.Graphemes.Count; i++)
                    {
                        strSym = this.Graphemes[i].ToString();
                        sdp = new SearchDefinitionParm(BuildableWordSearchWL.kGrapheme, strSym);
                        sd.AddSearchParm(sdp);
                        strGrfs += strSym + Constants.Space;
                    }

                    for (int i = 0; i < this.Highlights.Count; i++)
                    {
                        strSym = this.Highlights[i].ToString();
                        sdp = new SearchDefinitionParm(BuildableWordSearchWL.kHighlight, strSym);
                        sd.AddSearchParm(sdp);
                    }

                    if (this.BrowseView)
                    {
                        sdp = new SearchDefinitionParm(BuildableWordSearchWL.kBrowseView);
                        sd.AddSearchParm(sdp);
                    }

                    if (m_SearchOptions != null)
                    {
                        sd.AddSearchOptions(m_SearchOptions);
                    }
                    m_Title = m_Title + " - [" + strGrfs.Trim() + "]";
                    this.SearchDefinition = sd;
                    flag = true;
                }
                //else MessageBox.Show("Must specified at least one grapheme");
                else
                {
                    string strMsg = m_Settings.LocalizationTable.GetMessage("BuildableWordsSearchWL1",
                        m_Settings.OptionSettings.UILanguage);
                    MessageBox.Show(strMsg);
                }
			}
			return flag;
		}

		public bool SetupSearch(SearchDefinition sd)
		{
			bool flag = false;
			SearchOptions so = new SearchOptions(m_PSTable);

            string strTag = "";
			string strContent = "";
			string strGrfs = "";
			ArrayList alG = new ArrayList();
            ArrayList alH = new ArrayList();
			for (int i = 0; i < sd.SearchParmsCount(); i++)
			{
                strTag = sd.GetSearchParmAt(i).GetTag();
                strContent = sd.GetSearchParmAt(i).GetContent();
				if (strTag == BuildableWordSearchWL.kGrapheme)
				{
					alG.Add(strContent);
                    strGrfs += strContent + Constants.Space;
                    flag = true;
				}
                if (strTag == BuildableWordSearchWL.kHighlight)
                {
                    alH.Add(strContent);
                }
                if (strTag == BuildableWordSearchWL.kBrowseView)
                    this.m_BrowseView = true;
			}
			this.Graphemes = alG;
            this.Highlights = alH;
			m_Title = m_Title + " - [" + strGrfs.Trim() + "]";
            this.SearchOptions = sd.MakeSearchOptions(so);
            this.SearchDefinition = sd;
			return flag;
		}

		public string BuildResults()
		{
			string strText = "";
			string strSN = Search.TagSN + this.SearchNumber.ToString().Trim();
			strText += Search.TagOpener + strSN + Search.TagCloser + Environment.NewLine;
			strText += this.Title + Environment.NewLine + Environment.NewLine;
			strText += this.SearchResults;
			strText += Environment.NewLine;
			strText += this.SearchCount.ToString();
            //strText += " entries found" + Environment.NewLine;
            strText += Constants.Space +m_Settings.LocalizationTable.GetMessage("Search2",
                m_Settings.OptionSettings.UILanguage) + Environment.NewLine;
            strText += Search.TagOpener + Search.TagForwardSlash + strSN
				+ Search.TagCloser + Environment.NewLine;
			return strText;
		}

        public BuildableWordSearchWL ExecuteBuildableSearch(WordList wl)
        {
            SearchOptions so = this.SearchOptions;
            int nCount = 0;
            string strResult = wl.GetDisplayHeadings() + Environment.NewLine;

            Word wrd = null;
            int nWord = wl.WordCount();
            for (int i = 0; i < nWord; i++)
            {
                wrd = wl.GetWord(i);
                if (so == null)
                {
                    if (wrd.IsBuildableWord(this.Graphemes))
                    {
                        nCount++;
                        if ((this.Highlights != null) && (this.Highlights.Count > 0))
                            strResult += wl.GetDisplayLineForWord(i, this.Highlights)
                                + Environment.NewLine;
                        else strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
                    }
                }
                else
                {
                    if (so.MatchesWord(wrd))
                    {
                        if (wrd.IsBuildableWord(this.Graphemes))
                        {
                            nCount++;
                            if ((this.Highlights != null) && (this.Highlights.Count > 0))
                                strResult += wl.GetDisplayLineForWord(i, this.Highlights)
                                    + Environment.NewLine;
                            else strResult +=wl.GetDisplayLineForWord(i) + Environment.NewLine;
                        }
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
                this.SearchResults = m_Settings.LocalizationTable.GetMessage("Search1",
                    m_Settings.OptionSettings.UILanguage);
                this.SearchCount = 0;
            }
            return this;
        }

        public BuildableWordSearchWL BrowseBuildableSearch(WordList wl)
        {
            int nCount = 0;
            ArrayList al = null;
            Color clr = m_Settings.OptionSettings.HighlightColor;
            Font fnt = m_Settings.OptionSettings.GetDefaultFont();
            Word wrd = null;
            SearchOptions so = this.SearchOptions;
            FormBrowse form = new FormBrowse();
            //fpb.Text = BuildableWordsSearchWL.kBrowseTitle;
            form.Text = m_Settings.LocalizationTable.GetForm("FormBuildableWordsWLT",
                m_Settings.OptionSettings.UILanguage) + " - " +
                m_Settings.LocalizationTable.GetMessage("SearchB",
                m_Settings.OptionSettings.UILanguage);

            al = wl.GetDisplayHeadingsAsArray();
            form.AddColHeaders(al, clr, fnt);

            for (int i = 0; i < wl.WordCount(); i++)
            {
                wrd = wl.GetWord(i);
                if (so == null)
                {
                    if (wrd.IsBuildableWord(this.Graphemes))
                    {
                        nCount++;
                        al = wrd.GetWordInfoAsArray();
                        form.AddRow(al);
                    }
                }
                else
                {
                    so = this.SearchDefinition.MakeSearchOptions(so);
                    if (so.MatchesWord(wrd))
                    {
                        if (so.IsRootOnly)
                        {
                            if (wrd.IsBuildableWord(this.Graphemes))
                            {
                                nCount++;
                                al = wrd.GetWordInfoAsArray();
                                form.AddRow(al);
                            }
                        }
                        else
                        {
                            if (wrd.IsBuildableWord(this.Graphemes))
                            {
                                nCount++;
                                al = wrd.GetWordInfoAsArray();
                                form.AddRow(al);
                            }
                        }
                    }
                }
            }
            //fpb.Text += " - " + nCount.ToString() + " entries";
            form.Text += " - " + nCount.ToString() + Constants.Space +
                m_Settings.LocalizationTable.GetMessage("Search3", m_Settings.OptionSettings.UILanguage);
            form.Show();
            return this;
        }

    }
}

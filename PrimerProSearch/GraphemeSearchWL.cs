using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using PrimerProForms;
using PrimerProObjects;
using GenLib;

namespace PrimerProSearch
{
	/// <summary>
	/// Grapheme Search in Word List
	/// </summary>
	public class GraphemeSearchWL : Search
	{
        //Search parameters 
        private ArrayList m_Graphemes;		        //grapheme to be searched
        private bool m_UseGraphemesTaught;      //restrict search to grapheme taughts
        private bool m_BrowseView;              //display in Browse view
		private SearchOptions m_SearchOptions;	//search options filter

        private string m_Title;		            //search title
        private Settings m_Settings;            //Application settings
		private PSTable m_PSTable;		        //Parts of Speech Table
        private GraphemeInventory m_GI;         //Grapheme Inventory
        private GraphemeTaughtOrder m_GTO;      //Graphemes Taught
        private Font m_DefaultFont;             //Default Font
        private Color m_HighlightColor;         //Highlight Color

		//Search Definition Tags
        private const string kTarget = "target";
        private const string kGrapheme = "grapheme";
        private const string kUseGraphemesTaught = "UseGraphemesTaught";
        private const string kBrowseView = "BrowseView";

        public GraphemeSearchWL(int number, Settings s)
            : base(number, SearchDefinition.kGrapheme)
		{
			m_Graphemes = null;
            m_UseGraphemesTaught = false;
            m_BrowseView = false;
			m_SearchOptions = null;

            m_Settings = s;
            //m_Title = "Grapheme Search from Word List";
            m_Title = m_Settings.LocalizationTable.GetMessage("GraphemeSearchWLT");
            if (m_Title == "")
                m_Title = "Grapheme Search from Word List";
			m_PSTable = m_Settings.PSTable;
            m_GI = m_Settings.GraphemeInventory;
            m_GTO = m_Settings.GraphemesTaught;
            m_DefaultFont = m_Settings.OptionSettings.GetDefaultFont();
            m_HighlightColor = m_Settings.OptionSettings.HighlightColor;
        }

        public GraphemeSearchWL(string strGrfs, Settings s)
            : base(0, SearchDefinition.kGrapheme)
		{
            m_Graphemes = Funct.ConvertStringToArrayList(strGrfs, Constants.Space.ToString());
            m_UseGraphemesTaught = false;
            m_BrowseView = false;
			m_SearchOptions = null;

            m_Settings = s;
            //m_Title = "Grapheme Search from Word List";
            m_Title = m_Settings.LocalizationTable.GetMessage("GraphemeSearchWLT");
            if (m_Title == "")
                m_Title = "Grapheme Search from Word List";
            m_PSTable = m_Settings.PSTable;
            m_GI = m_Settings.GraphemeInventory;
            m_GTO = m_Settings.GraphemesTaught;
            m_DefaultFont = m_Settings.OptionSettings.GetDefaultFont();
            m_HighlightColor = m_Settings.OptionSettings.HighlightColor;
		}

        public ArrayList Graphemes
		{
            get { return m_Graphemes; }
            set { m_Graphemes= value; }
		}

        public bool UseGraphemesTaught
        {
            get { return m_UseGraphemesTaught; }
            set { m_UseGraphemesTaught = value; }
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
			get {return m_GI;}
		}

		public GraphemeTaughtOrder GTO
		{
			get {return m_GTO;}
		}

        public Font DefaultFont
        {
            get { return m_DefaultFont; }
        }

        public Color HighlightColor
        {
            get { return m_HighlightColor; }
        }

		public bool SetupSearch()
		{
			bool flag = false;
            string strMsg = "";
            //FormGrapheme fpb = new FormGrapheme(this.PSTable, this.DefaultFont, this);
            FormGraphemeWL form = new FormGraphemeWL(m_Settings, m_Settings.LocalizationTable);
			DialogResult dr;
			dr = form.ShowDialog();
			if (dr == DialogResult.OK)
			{
                this.Graphemes = form.Graphemes;
                this.UseGraphemesTaught = form.UseGraphemesTaught;
                this.BrowseView = form.BrowseView;
                this.SearchOptions = form.SearchOptions;

                if (this.Graphemes != null)
                {
                    SearchDefinition sd = new SearchDefinition(SearchDefinition.kGrapheme);
                    SearchDefinitionParm sdp = null;
                    this.SearchDefinition = sd;
                    
                    string strSym = "";
                    string strGrfs = "";
                    m_Title = m_Title + " - [" + Funct.ConvertArrayListToString(this.Graphemes, Constants.Space.ToString()) + "]";
                    for (int i = 0; i < this.Graphemes.Count; i++)
                    {
                        strSym = this.Graphemes[i].ToString();
                        sdp = new SearchDefinitionParm(GraphemeSearchWL.kGrapheme, strSym);
                        sd.AddSearchParm(sdp);
                        strGrfs += strSym + Constants.Space;
                    } 
                    if (this.UseGraphemesTaught)
                    {
                        sdp = new SearchDefinitionParm(GraphemeSearchWL.kUseGraphemesTaught);
                        sd.AddSearchParm(sdp);
                    }
                    if (this.BrowseView)
                    {
                        sdp = new SearchDefinitionParm(GraphemeSearchWL.kBrowseView);
                        sd.AddSearchParm(sdp);
                    }
                    if (m_SearchOptions != null)
                        sd.AddSearchOptions(m_SearchOptions);
                    this.SearchDefinition = sd;
                    flag = true;
                }
                //else MessageBox.Show("Must specified at least one grapheme");
                else
                {
                    strMsg = m_Settings.LocalizationTable.GetMessage("GraphemeSearch2");
                    if (strMsg == "")
                        strMsg = "Must specified at least one grapheme";
                    MessageBox.Show(strMsg);
                }
			}
			return flag;
		}

		public bool SetupSearch(SearchDefinition sd)
		{
			bool flag = false;
            string strTag = "";
            string strContent = "";
            string strGrfs = "";
            ArrayList alG = new ArrayList();
            SearchOptions so = new SearchOptions(m_PSTable);

            for (int i = 0; i < sd.SearchParmsCount(); i++)
            {
                strTag = sd.GetSearchParmAt(i).GetTag();
                strContent = sd.GetSearchParmAt(i).GetContent();
                if (strTag == GraphemeSearchWL.kGrapheme)
                {
                    alG.Add(strContent);
                    strGrfs = strContent + Constants.Space;
                    flag = true;
                }
                if (strTag == GraphemeSearchWL.kUseGraphemesTaught)
                    this.UseGraphemesTaught = true;
                if (strTag == GraphemeSearchWL.kBrowseView)
                    this.BrowseView = true;
            }
            
            this.Graphemes = alG;
            m_Title = m_Title + " - [" + strGrfs.Trim() + "]";
            this.SearchOptions = sd.MakeSearchOptions(so);
            this.SearchDefinition = sd;
            return flag;
        }

		public string BuildResults()
		{
			string strText = "";
			string strSN = "";
            string str = "";
			if (this.SearchNumber > 0)
			{
				strSN = Search.TagSN + this.SearchNumber.ToString().Trim();
				strText += Search.TagOpener + strSN	+ Search.TagCloser + Environment.NewLine;
			}
			strText += this.Title + Environment.NewLine + Environment.NewLine;
			strText += this.SearchResults;
			strText += Environment.NewLine;
            //strText += this.SearchCount.ToString() + " entries found" + Environment.NewLine;
            str = m_Settings.LocalizationTable.GetMessage("Search2");
            if (str == "")
                str = "entries found";
            strText += this.SearchCount.ToString() + Constants.Space + str + Environment.NewLine;
            if (this.SearchNumber > 0)
				strText += Search.TagOpener + Search.TagForwardSlash + strSN
					+ Search.TagCloser;
			return strText;
		}

        public GraphemeSearchWL ExecuteGraphemeSearch(WordList wl)
        {
            ArrayList alGraphemes = this.Graphemes; ;
            bool fUseGraphemesTaught = this.UseGraphemesTaught;
            ArrayList alGTO = new ArrayList();
            if (this.GTO != null)
                alGTO = this.GTO.Graphemes;
            SearchOptions so = this.SearchOptions;
            int nCount = 0;
            string strResult = wl.GetDisplayHeadings() + Environment.NewLine;

            Word wrd = null;
            for (int i = 0; i < wl.WordCount(); i++)
            {
                wrd = wl.GetWord(i);

                if (so == null)
                {
                    if (fUseGraphemesTaught)
                    {
                        if ((wrd.IsBuildableWord(alGTO)) && (wrd.ContainInWord(alGraphemes)))
                        {
                            nCount++;
                            strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
                        }
                    }
                    else
                    {
                        if (wrd.ContainInWord(alGraphemes))
                        {
                            nCount++;
                            strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
                        }
                    }
                }
                else
                {
                    if ((so.MatchesWord(wrd)) && (so.MatchesPosition(wrd, alGraphemes)))
                    {
                        if (so.IsRootOnly)
                        {
                            if (fUseGraphemesTaught)
                            {
                                if ((wrd.IsBuildableWord(alGTO)) && (wrd.Root.IsInRoot(alGraphemes)))
                                {
                                    nCount++;
                                    strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
                               }
                            }
                            else
                            {
                                if (wrd.Root.IsInRoot(alGraphemes))
                                {
                                    nCount++;
                                    strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
                                }
                            }
                        }
                        else
                        {
                            if (fUseGraphemesTaught)
                            {
                                if ((wrd.IsBuildableWord(alGTO)) && (wrd.ContainInWord(alGraphemes)))
                                {
                                    nCount++;
                                    strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
                                }
                            }
                            else
                            {
                                if (wrd.ContainInWord(alGraphemes))
                                {
                                    nCount++;
                                    strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
                                }
                            }
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
            //    this.SearchResults = "***No Results***";
                this.SearchResults = m_Settings.LocalizationTable.GetMessage("Search1");
                if (this.SearchResults == "")
                    this.SearchResults = "***No Results***";
                this.SearchCount = 0;
            }
            return this;
        }

        public void BrowseGraphemeSearch(WordList wl)
        {
            ArrayList alGraphemes = this.Graphemes; ;
            bool fUseGraphemesTaught = this.UseGraphemesTaught;
            int nCount = 0;
            string str = "";
            ArrayList al = null;
            Color clr = m_HighlightColor;
            Font fnt = m_DefaultFont;
            Word wrd = null;

            ArrayList alGTO = new ArrayList();
            if (this.GTO != null)
                alGTO = this.GTO.Graphemes;
            SearchOptions so = this.SearchOptions;
            FormBrowse form = new FormBrowse();
            str = m_Settings.LocalizationTable.GetMessage("SearchB");
            if (str == "")
                str = "Browse View";
            form.Text = m_Title + " - " + str;

            al = wl.GetDisplayHeadingsAsArray();
            form.AddColHeaders(al, clr, fnt);

            for (int i = 0; i < wl.WordCount(); i++)
            {
                wrd = wl.GetWord(i);
                if (so == null)
                {
                    if (fUseGraphemesTaught)
                    {
                        if ((wrd.IsBuildableWord(alGTO)) && (wrd.ContainInWord(alGraphemes)))
                        {
                            nCount++;
                            al = wrd.GetWordInfoAsArray();
                            form.AddRow(al);
                        }
                    }
                    else
                    {
                        if (wrd.ContainInWord(alGraphemes))
                        {
                            nCount++;
                            al = wrd.GetWordInfoAsArray();
                            form.AddRow(al);
                        }
                    }
                }
                else
                {
                    so = this.SearchDefinition.MakeSearchOptions(so);
                    if ((so.MatchesWord(wrd)) && (so.MatchesPosition(wrd, alGraphemes)))
                    {
                        if (so.IsRootOnly)
                        {
                            if (fUseGraphemesTaught)
                            {
                                if ((wrd.IsBuildableWord(alGTO)) && (wrd.Root.IsInRoot(alGraphemes)))
                                {
                                    nCount++;
                                    al = wrd.GetWordInfoAsArray();
                                    form.AddRow(al);
                                }
                            }
                            else
                            {
                                if (wrd.Root.IsInRoot(alGraphemes))
                                {
                                    nCount++;
                                    al = wrd.GetWordInfoAsArray();
                                    form.AddRow(al);
                                }
                            }
                        }
                        else
                        {
                            if (fUseGraphemesTaught)
                            {
                                if ((wrd.IsBuildableWord(alGTO)) && (wrd.ContainInWord(alGraphemes)))
                                {
                                    nCount++;
                                    al = wrd.GetWordInfoAsArray();
                                    form.AddRow(al);
                                }
                            }
                            else
                            {
                                if (wrd.ContainInWord(alGraphemes))
                                {
                                    nCount++;
                                    al = wrd.GetWordInfoAsArray();
                                    form.AddRow(al);
                                }
                            }
                        }
                    }
                }
            }
            //form.Text += " - " + nCount.ToString() + " entries";
            str = m_Settings.LocalizationTable.GetMessage("Search3");
            if (str == "")
                str = "entries";
            form.Text += " - " + nCount.ToString() + Constants.Space + str;
                
            form.Show();
            return;
        }

    }
}

using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using PrimerProForms;
using PrimerProObjects;
using PrimerProLocalization;
using GenLib;

namespace PrimerProSearch
{
    /// <summary>
    /// Syllograph search in Word List
    /// </summary>
    public class SyllographWLSearch : Search
    {
        //Search parameters
        private string m_Syllograph;                            // Selected syllograph
        private SyllographFeatures m_Features;        // Selected syloograph features
        private bool m_UseGraphemesTaught;          //restrict search to grapheme taughts
        private bool m_BrowseView;                           //display in Browse view
        private SearchOptions m_SearchOptions;     //Search options filter

        private string m_Title;             //Search Title
        private Settings m_Settings;        //Application Settings
        private LocalizationTable m_Table;  //Localization table
        private string m_Lang;              //UI language
        private PSTable m_PSTable;          //Parts of Speech
        private GraphemeInventory m_GI;     //Grapheme Inventory
        private GraphemeTaughtOrder m_GTO;  //Graphemes Taught
        private Font m_DefaultFont;         //Default font
        private Color m_HighlightColor;     //HighLight color
        

        //Search Definition tags
        private const string kTarget = "syllograph";
        private const string kCatPrimary = "primary";
        private const string kCatSecondary = "secondary";
        private const string kCatTertiary = "tertiary";
        private const string kUseGraphemesTaught = "UseGraphemesTaught";
        private const string kBrowseView = "BrowseView";

        private const string kTitle = "Syllograph Search";
        private const string kBrowseTitle = kTitle + " Browse View";
        
        public SyllographWLSearch(int number, Settings s)
            : base(number, SearchDefinition.kSyllographWL)
        {
            m_Syllograph = "";
            m_Features = null;
            m_UseGraphemesTaught = false;
            m_BrowseView = false;
            m_SearchOptions = null;

            m_Settings = s;
            m_Table = m_Settings.LocalizationTable;
            m_Lang = m_Settings.OptionSettings.UILanguage;
            m_Title = SyllographWLSearch.kTitle; ;
            m_GI = m_Settings.GraphemeInventory;
            m_GTO = m_Settings.GraphemesTaught;
            m_PSTable = m_Settings.PSTable;
            m_DefaultFont = m_Settings.OptionSettings.GetDefaultFont();
            m_HighlightColor = m_Settings.OptionSettings.HighlightColor;
        }

        public SyllographWLSearch(string strGrf, Settings s) : base(0, SearchDefinition.kSyllographWL)
        {
            m_Syllograph = strGrf;
            m_Features = null;
            m_UseGraphemesTaught = false;
            m_BrowseView = false;
            m_SearchOptions = null;

            m_Settings = s;
            m_Table = m_Settings.LocalizationTable;
            m_Lang = m_Settings.OptionSettings.UILanguage;
            m_Title = SyllographWLSearch.kTitle; ;
            m_GI = m_Settings.GraphemeInventory;
            m_GTO = m_Settings.GraphemesTaught;
            m_PSTable = m_Settings.PSTable;
            m_DefaultFont = m_Settings.OptionSettings.GetDefaultFont();
            m_HighlightColor = m_Settings.OptionSettings.HighlightColor;
        }

        public string Syllograph
        {
            get { return m_Syllograph; }
            set { m_Syllograph = value; }
        }

        public SyllographFeatures Features
        {
            get { return m_Features; }
            set { m_Features = value; }
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
            get { return m_SearchOptions; }
            set { m_SearchOptions = value; }
        }
        
        public string Title
		{
			get {return m_Title;}
		}

        public GraphemeInventory GI
		{
			get {return m_GI;}
		}

        public PSTable PSTable
        {
            get { return m_PSTable; }
        }

        public GraphemeTaughtOrder GTO
        {
            get { return m_GTO;}
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
            Grapheme  grf = null;

            FormSyllographWL form = new FormSyllographWL(this.PSTable, this.GI, this.DefaultFont, m_Table, m_Lang);
            DialogResult dr;
            dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.Syllograph = form.Grapheme;
                this.Features = form.Features;
                this.UseGraphemesTaught = form.UseGraphemesTaught;
                this.BrowseView = form.BrowseView;
                this.SearchOptions = form.SearchOptions;

                SearchDefinition sd = new SearchDefinition(SearchDefinition.kSyllographWL);
                SearchDefinitionParm sdp = null;
                this.SearchDefinition = sd;

                if (this.Syllograph != "")
                {
                    if (this.GI.IsInInventory(this.Syllograph))
                    {
                        grf = this.GI.GetGrapheme(this.Syllograph);
                        if (grf.IsSyllograph)
                        {
                            sdp = new SearchDefinitionParm(SyllographWLSearch.kTarget, this.Syllograph);
                            sd.AddSearchParm(sdp);
                            m_Title = m_Title + " - [" + this.Syllograph + "]";
                            if (this.UseGraphemesTaught)
                            {
                                sdp = new SearchDefinitionParm(SyllographWLSearch.kUseGraphemesTaught);
                                sd.AddSearchParm(sdp);
                            }
                            if (this.BrowseView)
                            {
                                sdp = new SearchDefinitionParm(SyllographWLSearch.kBrowseView);
                                sd.AddSearchParm(sdp);
                            }
                            if (m_SearchOptions != null)
                                sd.AddSearchOptions(m_SearchOptions);
                            this.SearchDefinition = sd;
                            flag = true;
                        }
                    }
                    //else MessageBox.Show("Syllograph is not in grapheme inventory");
                    else
                    {
                        strMsg = m_Settings.LocalizationTable.GetMessage("SyllographSearchWL1",
                            m_Settings.OptionSettings.UILanguage);
                        MessageBox.Show(strMsg);
                    }
                }
                else if (this.Features != null)
                {
                    if (this.Features.CategoryPrimary != "")
                    {
                        sdp = new SearchDefinitionParm(SyllographWLSearch.kCatPrimary, this.Features.CategoryPrimary);
                        sd.AddSearchParm(sdp);
                    }
                    if (this.Features.CategorySecondary != "")
                    {
                        sdp = new SearchDefinitionParm(SyllographWLSearch.kCatSecondary, this.Features.CategorySecondary);
                        sd.AddSearchParm(sdp);
                    }
                    if (this.Features.CategoryTertiary != "")
                    {
                        sdp = new SearchDefinitionParm(SyllographWLSearch.kCatTertiary, this.Features.CategoryTertiary);
                        sd.AddSearchParm(sdp);
                    }
                    if (this.UseGraphemesTaught)
                    {
                        sdp = new SearchDefinitionParm(SyllographWLSearch.kUseGraphemesTaught);
                        sd.AddSearchParm(sdp);
                    }
                    if (this.BrowseView)
                    {
                        sdp = new SearchDefinitionParm(SyllographWLSearch.kBrowseView);
                        sd.AddSearchParm(sdp);
                    }
                    if (m_SearchOptions != null)
                        sd.AddSearchOptions(m_SearchOptions);
                    this.SearchDefinition = sd;
                    flag = true;
                }
                //else MessageBox.Show("Syllograph or Features must be specified");
                else
                {
                    strMsg = m_Settings.LocalizationTable.GetMessage("SyllographSearchWL2",
                        m_Settings.OptionSettings.UILanguage);
                    MessageBox.Show(strMsg);
                }
            }
            return flag;
        }

        public bool SetupSearch(SearchDefinition sd)
        {
            bool fReturn = false;
            string strTag = "";
            SearchOptions so = new SearchOptions(m_PSTable);

            for (int i=0; i < sd.SearchParmsCount(); i++)
            {
                strTag = sd.GetSearchParmAt(i).GetTag();
                if (strTag == SyllographWLSearch.kTarget)
                {
                    this.Syllograph = sd.GetSearchParmContent(strTag);
                    fReturn = true;
                }
                if (strTag == SyllographWLSearch.kCatPrimary)
                {
                    if (this.Features == null)
                        this.Features = new SyllographFeatures();
                    this.Features.CategoryPrimary = sd.GetSearchParmContent(strTag);
                    fReturn = true;
                }
                if (strTag == SyllographWLSearch.kCatSecondary)
                {
                    if (this.Features == null)
                        this.Features = new SyllographFeatures();
                    this.Features.CategorySecondary = sd.GetSearchParmContent(strTag);
                    fReturn = true;
                }
                if (strTag == SyllographWLSearch.kCatTertiary)
                {
                    if (this.Features == null)
                        this.Features = new SyllographFeatures();
                    this.Features.CategoryTertiary = sd.GetSearchParmContent(strTag);
                    fReturn = true;
                }
                if (strTag == SyllographWLSearch.kUseGraphemesTaught)
                    this.UseGraphemesTaught = true;
                if (strTag == SyllographWLSearch.kBrowseView)
                    this.BrowseView = true;
            }
            
            this.SearchOptions = sd.MakeSearchOptions(so);
            this.SearchDefinition = sd;
            return fReturn;
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
            strText += Constants.Space + m_Settings.LocalizationTable.GetMessage("Search2",
                m_Settings.OptionSettings.UILanguage) + Environment.NewLine;
            strText += Search.TagOpener + Search.TagForwardSlash + strSN
                + Search.TagCloser;
            return strText;
		}
        
        public SyllographWLSearch ExecuteSyllographSearch(WordList wl)
        {
            string strGrapheme = this.Syllograph;
            string strMsg = "";
            SyllographFeatures sf = this.Features;
            bool fUseGraphemesTaught = this.UseGraphemesTaught;
            ArrayList alGTO = new ArrayList();
            if (this.GTO != null)
                alGTO = this.GTO.Graphemes;
            SearchOptions so = this.SearchOptions;
            int nCount = 0;
            string strResult = wl.GetDisplayHeadings() + Environment.NewLine;

            Word wrd = null;
            int nWord = wl.WordCount();
            for (int i = 0; i < nWord; i++)
            {
                wrd = wl.GetWord(i);

                if (so == null)     // No search options filter
                {
                    if (strGrapheme != "")  // Search for syllograph
                    {
                        if (fUseGraphemesTaught) //Restrict to GTO
                        {
                            if ((wrd.IsBuildableWord(alGTO)) && (wrd.ContainInWord(strGrapheme)))
                            {
                                nCount++;
                                strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
                            }
                        }
                        else
                        {
                            if (wrd.ContainInWord(strGrapheme))
                            {
                                nCount++;
                                strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
                            }
                        }
                    }
                    else if (sf != null)    //Search for syllograph feature
                    {
                        if (fUseGraphemesTaught)    //Restrict to GTO
                        {
                            if ((wrd.IsBuildableWord(alGTO)) && (this.FeatureMatchesWord(wrd)))
                            {
                                nCount++;
                                strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
                            }
                        }
                        else
                        {
                            if (this.FeatureMatchesWord(wrd))
                            {
                                nCount++;
                                strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
                            }
                        }
                    }
                    //else MessageBox.Show("Must specify a syllograph or feature");
                    else
                    {
                        strMsg = m_Settings.LocalizationTable.GetMessage("SyllographSearchWL2",
                            m_Settings.OptionSettings.UILanguage);
                        MessageBox.Show(strMsg);
                    }
                }
                else      //Search option filter
                {
                    if (strGrapheme != "")  //Search for syllogrpah
                    {
                        if ((so.MatchesWord(wrd)) && so.MatchesPosition(wrd, strGrapheme))      //Filter for search options
                        {
                            if (so.IsRootOnly)      //Process roots
                            {
                                if (fUseGraphemesTaught)    //Restrict to GTO
                                {
                                    if ((wrd.IsBuildableWord(alGTO)) && (wrd.Root.IsInRoot(strGrapheme)))
                                    {
                                        nCount++;
                                        strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
                                    }
                                }
                                else
                                {
                                    if (wrd.Root.IsInRoot(strGrapheme))
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
                                    if ((wrd.IsBuildableWord(alGTO)) && (wrd.ContainInWord(strGrapheme)))
                                    {
                                        nCount++;
                                        strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
                                    }
                                }
                                else
                                {
                                    if (wrd.ContainInWord(strGrapheme))
                                    {
                                        nCount++;
                                        strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
                                    }
                                }
                            }
                        }
                    }
                    else if (sf != null)
                    {
                        //*** strgrapheme is wrong, need to check the feature matches the position
                        if ((so.MatchesWord(wrd)) && so.MatchesPosition(wrd, strGrapheme))      //filter search options
                        {
                            if (so.IsRootOnly)  //process roots
                            {
                                if (fUseGraphemesTaught)    //restict to GTO
                                {
                                    if ((wrd.IsBuildableWord(alGTO)) && (this.FeatureMatchesRoot(wrd.Root)))
                                    {
                                        nCount++;
                                        strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
                                    }
                                }
                                else
                                {
                                    if (this.FeatureMatchesRoot(wrd.Root))
                                    {
                                        nCount++;
                                        strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
                                    }
                                }
                            }
                            else
                            {
                                if (fUseGraphemesTaught)    //restict to GTO
                                {
                                    if ((wrd.IsBuildableWord(alGTO)) && (this.FeatureMatchesWord(wrd)))
                                    {
                                        nCount++;
                                        strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
                                    }
                                }
                                else
                                {
                                    if (this.FeatureMatchesWord(wrd))
                                    {
                                        nCount++;
                                        strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
                                    }
                                }
                            }
                        }
                    }
                    //else MessageBox.Show("Must specify a syllograph or feature");
                    else
                    {
                        strMsg = m_Settings.LocalizationTable.GetMessage("SyllographSearchWL2",
                            m_Settings.OptionSettings.UILanguage);
                        MessageBox.Show(strMsg);
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
                    this.SearchResults = m_Settings.LocalizationTable.GetMessage("Search1",
                        m_Settings.OptionSettings.UILanguage);
                    this.SearchCount = 0;
                }
            }
            return this;
        }
        
        public void BrowseSyllographWLSearch(WordList wl)
        {
            string strGrapheme = this.Syllograph;
            bool fUseGraphemesTaught = this.UseGraphemesTaught;
            SyllographFeatures sf = this.Features;
            ArrayList al = null;
            Color clr = m_HighlightColor;
            Font fnt = m_DefaultFont;
            int nCount = 0;
            string strMsg = "";
            string strResult = wl.GetDisplayHeadings() + Environment.NewLine;

            ArrayList alGTO = new ArrayList();
            if (this.GTO != null)
                alGTO = this.GTO.Graphemes;
            SearchOptions so = this.SearchOptions;
            FormBrowse form = new FormBrowse();
            form.Text = m_Title + " - " + m_Settings.LocalizationTable.GetMessage("SearchB",
                m_Settings.OptionSettings.UILanguage);

            al = wl.GetDisplayHeadingsAsArray();
            form.AddColHeaders(al, clr, fnt);
            

            Word wrd = null;
            for (int i = 0; i < wl.WordCount(); i++)
            {
                wrd = wl.GetWord(i);

                if (so == null)     // No search options filter
                {
                    if (strGrapheme != "")  // Search for syllograph
                    {
                        if (fUseGraphemesTaught) //Restrict to GTO
                        {
                            if ((wrd.IsBuildableWord(alGTO)) && (wrd.ContainInWord(strGrapheme)))
                            {
                                nCount++;
                                al = wrd.GetWordInfoAsArray();
                                form.AddRow(al);
                            }
                        }
                        else
                        {
                            if (wrd.ContainInWord(strGrapheme))
                            {
                                nCount++;
                                al = wrd.GetWordInfoAsArray();
                                form.AddRow(al);
                            }
                        }
                    }
                    else if (sf != null)    //Search for syllograph feature
                    {
                        if (fUseGraphemesTaught)    //Restrict to GTO
                        {
                            if ((wrd.IsBuildableWord(alGTO)) && (this.FeatureMatchesWord(wrd)))
                            {
                                nCount++;
                                strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
                            }
                        }
                        else
                        {
                            if (this.FeatureMatchesWord(wrd))
                            {
                                nCount++;
                                al = wrd.GetWordInfoAsArray();
                                form.AddRow(al);
                            }
                        }
                    }
                    //else MessageBox.Show("Must specify a syllograph or feature");
                    else
                    {
                        strMsg = m_Settings.LocalizationTable.GetMessage("SyllographSearchWL2",
                            m_Settings.OptionSettings.UILanguage);
                        MessageBox.Show(strMsg);
                    }
                }
                else      //Search option filter
                {
                    if (strGrapheme != "")  //Search for syllogrpah
                    {
                        if ((so.MatchesWord(wrd)) && so.MatchesPosition(wrd, strGrapheme))      //Filter for search options
                        {
                            if (so.IsRootOnly)      //Process roots
                            {
                                if (fUseGraphemesTaught)    //Restrict to GTO
                                {
                                    if ((wrd.IsBuildableWord(alGTO)) && (wrd.Root.IsInRoot(strGrapheme)))
                                    {
                                        nCount++;
                                        al = wrd.GetWordInfoAsArray();
                                        form.AddRow(al);
                                    }
                                }
                                else
                                {
                                    if (wrd.Root.IsInRoot(strGrapheme))
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
                                    if ((wrd.IsBuildableWord(alGTO)) && (wrd.ContainInWord(strGrapheme)))
                                    {
                                        nCount++;
                                        al = wrd.GetWordInfoAsArray();
                                        form.AddRow(al);;
                                    }
                                }
                                else
                                {
                                    if (wrd.ContainInWord(strGrapheme))
                                    {
                                        nCount++;
                                        strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
                                    }
                                }
                            }
                        }
                    }
                    else if (sf != null)
                    {
                        //*** strgrapheme is wrong, need to check the feature matches the position
                        if ((so.MatchesWord(wrd)) && so.MatchesPosition(wrd, strGrapheme))      //filter search options
                        {
                            if (so.IsRootOnly)  //process roots
                            {
                                if (fUseGraphemesTaught)    //restict to GTO
                                {
                                    if ((wrd.IsBuildableWord(alGTO)) && (this.FeatureMatchesRoot(wrd.Root)))
                                    {
                                        nCount++;
                                        al = wrd.GetWordInfoAsArray();
                                        form.AddRow(al);
                                    }
                                }
                                else
                                {
                                    if (this.FeatureMatchesRoot(wrd.Root))
                                    {
                                        nCount++;
                                        al = wrd.GetWordInfoAsArray();
                                        form.AddRow(al);
                                    }
                                }
                            }
                            else
                            {
                                if (fUseGraphemesTaught)    //restict to GTO
                                {
                                    if ((wrd.IsBuildableWord(alGTO)) && (this.FeatureMatchesWord(wrd)))
                                    {
                                        nCount++;
                                        al = wrd.GetWordInfoAsArray();
                                        form.AddRow(al);;
                                    }
                                }
                                else
                                {
                                    if (this.FeatureMatchesWord(wrd))
                                    {
                                        nCount++;
                                        al = wrd.GetWordInfoAsArray();
                                        form.AddRow(al);
                                    }
                                }
                            }
                        }
                    }
                    //else MessageBox.Show("Must specify a syllograph or feature");
                    else
                    {
                        strMsg = m_Settings.LocalizationTable.GetMessage("SyllographSearchWL2",
                            m_Settings.OptionSettings.UILanguage);
                        MessageBox.Show(strMsg);
                    }
                }
            }
            form.Text += " - " + nCount.ToString() + Constants.Space +
                m_Settings.LocalizationTable.GetMessage("Search3", m_Settings.OptionSettings.UILanguage);
            form.Show();
            return;
        }

        public bool FeatureMatchesWord(Word wrd)
        {
            bool flag = false;
            Grapheme grf = null;
            Syllograph syllograph = null;
            SyllographFeatures sf = this.Features;

            if (wrd != null)
            {
                for (int i = 0; i < wrd.GraphemeCount(); i++)
                {
                    bool fMatch = false;
                    int ndx = 0;
                    grf = wrd.GetGrapheme(i);
                    if (grf != null)
                    {
                        if (grf.IsSyllograph)
                        {
                            ndx = this.GI.FindSyllographIndex(grf.Symbol);
                            if (ndx >= 0)
                            {
                                syllograph = this.GI.GetSyllograph(ndx);
                                if (syllograph.MatchesFeatures(sf))
                                    fMatch = true;
                            }
                            if (fMatch)
                            {
                                flag = true;
                                break;
                            }
                        }
                    }
                }
            }
            return flag;
        }

        public bool FeatureMatchesRoot(Root root)
        {
            bool flag = false;
            Grapheme grf = null;
            Syllograph syllograph = null;
            SyllographFeatures sf = this.Features;

            if (root != null)
            {
                for (int i = 0; i < root.GraphemeCount(); i++)
                {
                    bool fMatch = false;
                    int ndx = 0;
                    grf = root.GetGrapheme(i);
                    if (grf != null)
                    {
                        if (grf.IsSyllograph)
                        {
                            ndx = this.GI.FindSyllographIndex(grf.Symbol);
                            if (ndx >= 0)
                            {
                                syllograph = this.GI.GetSyllograph(ndx);
                                if (syllograph.MatchesFeatures(sf))
                                    fMatch = true;
                            }
                            if (fMatch)
                                break;
                        }
                    }
                }
            }
            return flag;
       }

    }
}

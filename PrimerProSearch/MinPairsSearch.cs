using System;
using System.Windows.Forms;
using System.Drawing;
using PrimerProForms;
using PrimerProObjects;
using GenLib;

namespace PrimerProSearch
{
    public class MinPairsSearch : Search
    {
        //Search parameters 
        private string m_Grapheme1;	    	    //first grapheme for Minimal Pairs
        private string m_Grapheme2;             //second grapheme for Minimal Pairs
        private bool m_AllPairs;                //All Minimal Pairs for first grapheme
        private bool m_RootsOnly;               //use roots only
        private bool m_IgnoreTone;              //Ignore Tone
        private bool m_AllowVowelHarmony;       //Allow Harmony
        private SearchOptions m_SearchOptions;	//search options filter
        private string m_Title;		            //search title
        private Settings m_Settings;            //Application settings
        private PSTable m_PSTable;		        //Parts of Speech
        private GraphemeInventory m_GI;         //Grapheme Inventory
        private Font m_DefaultFont;             //Default Font
 
        //Search Definition tags
        private const string kTarget1 = "target1";
        private const string kTarget2 = "target2";
        private const string kAll = "AllPairs";
        private const string kRoots = "RootsOnly";
        private const string kTone = "IgnoreTone";
        private const string kHarmony = "AllowForVowelHarmony";

        //private const string kTitle = "Minimal Pairs Search";
        //private const string kSearch = "Processing Minimal Pairs Search";
 		
        public MinPairsSearch(int number, Settings s)
            : base(number, SearchDefinition.kMinPairs)
		{
			m_Grapheme1 = "";
            m_Grapheme2 = "";
            m_AllPairs = false;
            m_RootsOnly = false;
            m_IgnoreTone = false;
			m_SearchOptions = null;
            m_Settings = s;
            m_Title = m_Settings.LocalizationTable.GetMessage("MinPairsSearchT");
            if (m_Title == "")
                m_Title = "Minimal Pairs Search";
            m_PSTable = m_Settings.PSTable;
            m_GI = m_Settings.GraphemeInventory;
            m_DefaultFont = m_Settings.OptionSettings.GetDefaultFont();
		}
 
        public string Grapheme1
		{
            get { return m_Grapheme1; }
            set { m_Grapheme1 = value; }
		}

        public string Grapheme2
		{
            get { return m_Grapheme2; }
            set { m_Grapheme2 = value; }
		}

        public bool AllPairs
        {
            get { return m_AllPairs; }
            set { m_AllPairs = value; }
        }

        public bool RootsOnly
        {
            get { return m_RootsOnly; }
            set { m_RootsOnly = value; }
        }

        public bool IgnoreTone
        {
            get { return m_IgnoreTone; }
            set { m_IgnoreTone = value; }
        }

        public bool AllowVowelHarmony
        {
            get { return m_AllowVowelHarmony; }
            set { m_AllowVowelHarmony = value; }
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

        public Font DefaultFont
        {
            get { return m_DefaultFont; }
        }

        public bool SetupSearch()
        {
            bool flag = false;
            string strMsg = "";
            FormMinPairs form = new FormMinPairs(m_Settings, m_Settings.LocalizationTable);
            DialogResult dr;
            dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.Grapheme1 = form.Grapheme1;
                this.Grapheme2 = form.Grapheme2;
                this.AllPairs = form.AllPairs;
                this.RootsOnly = form.RootsOnly;
                this.IgnoreTone = form.IgnoreTone;
                this.AllowVowelHarmony = form.AllowVowelHarmony;
                this.SearchOptions = form.SearchOptions;

                SearchDefinition sd = new SearchDefinition(SearchDefinition.kMinPairs);
                SearchDefinitionParm sdp = null;
                this.SearchDefinition = sd;

                if (this.AllPairs)
                {
                    if ((this.Grapheme1 != ""))
                    {
                        if (this.GI.IsInInventory(this.Grapheme1))
                        {
                            sdp = new SearchDefinitionParm(MinPairsSearch.kTarget1, this.Grapheme1);
                            sd.AddSearchParm(sdp);
                            sdp = new SearchDefinitionParm(MinPairsSearch.kAll);
                            sd.AddSearchParm(sdp);
                            if (this.RootsOnly)
                            {
                                sdp = new SearchDefinitionParm(MinPairsSearch.kRoots);
                                sd.AddSearchParm(sdp);
                            }
                            if (this.IgnoreTone)
                            {
                                sdp = new SearchDefinitionParm(MinPairsSearch.kTone);
                                sd.AddSearchParm(sdp);
                            }
                            if (this.AllowVowelHarmony)
                            {
                                sdp = new SearchDefinitionParm(MinPairsSearch.kHarmony);
                                sd.AddSearchParm(sdp);
                            }

                            m_Title = m_Title + " - [" + this.Grapheme1 + "]";
                            if (m_SearchOptions != null)
                                sd.AddSearchOptions(m_SearchOptions);
                            this.SearchDefinition = sd;
                            flag = true;
                        }
                        //else MessageBox.Show("First grapheme is not in the grapheme inventory");
                        else
                        {
                            strMsg = m_Settings.LocalizationTable.GetMessage("MinPairsSearch3");
                            if (strMsg == "")
                                strMsg = "First grapheme is not in the grapheme inventory";
                            MessageBox.Show(strMsg);
                        }
                    }
                    //else MessageBox.Show("First Grapheme must be specified");
                    else
                    {
                        strMsg = m_Settings.LocalizationTable.GetMessage("MinPairsSearch4");
                        if (strMsg == "")
                            strMsg = "First Grapheme must be specified";
                        MessageBox.Show(strMsg);
                    }
                }
                else
                {
                    if ((this.Grapheme1 != "") && (this.Grapheme2 != ""))
                    {
                        if (this.GI.IsInInventory(this.Grapheme1))
                        {
                            if (this.GI.IsInInventory(this.Grapheme2))
                            {
                                if (this.Grapheme1 != this.Grapheme2)
                                {
                                    sdp = new SearchDefinitionParm(MinPairsSearch.kTarget1, this.Grapheme1);
                                    sd.AddSearchParm(sdp);
                                    sdp = new SearchDefinitionParm(MinPairsSearch.kTarget2, this.Grapheme2);
                                    sd.AddSearchParm(sdp);
                                    if (this.RootsOnly)
                                    {
                                        sdp = new SearchDefinitionParm(MinPairsSearch.kRoots);
                                        sd.AddSearchParm(sdp);
                                    }
                                    if (this.IgnoreTone)
                                    {
                                        sdp = new SearchDefinitionParm(MinPairsSearch.kTone);
                                        sd.AddSearchParm(sdp);
                                    }
                                    if (this.AllowVowelHarmony)
                                    {
                                        sdp = new SearchDefinitionParm(MinPairsSearch.kHarmony);
                                        sd.AddSearchParm(sdp);
                                    }

                                    m_Title = m_Title + " - [" + this.Grapheme1 + "] ["
                                        + this.Grapheme2 + "]";
                                    if (m_SearchOptions != null)
                                        sd.AddSearchOptions(m_SearchOptions);
                                    this.SearchDefinition = sd;
                                    flag = true;
                                }
                                //else MessageBox.Show("Graphemes can not be the same");
                                else
                                {
                                    strMsg = m_Settings.LocalizationTable.GetMessage("MinPairsSearch1");
                                    if (strMsg == "")
                                        strMsg = "Graphemes can not be the same";
                                    MessageBox.Show(strMsg);
                                }
                            }
                            //else MessageBox.Show("Second grapheme is not in Inventory");
                            else
                            {
                                strMsg = m_Settings.LocalizationTable.GetMessage("MinPairsSearch2");
                                if (strMsg == "")
                                    strMsg = "Second grapheme is not in Inventory";
                                MessageBox.Show(strMsg);
                            }
                        }
                        //else MessageBox.Show("First Grapheme is not in Inventory");
                        else
                        {
                            strMsg = m_Settings.LocalizationTable.GetMessage("MinPairsSearch3");
                            if (strMsg == "")
                                strMsg = "First grapheme is not in Inventory";
                            MessageBox.Show(strMsg);
                        }
                    }
                    //else MessageBox.Show("First and Second Graphemes must be specified");
                    else
                    {
                        strMsg = m_Settings.LocalizationTable.GetMessage("MinPairsSearch4");
                        if (strMsg == "")
                            strMsg = "First and Second Graphemes must be specified";
                        MessageBox.Show(strMsg);
                    }
                }
            }
            return flag;
        }

        public bool SetupSearch(SearchDefinition sd)
        {
            bool flag = false;
            SearchOptions so = new SearchOptions(m_PSTable);
            string strTag = "";
            for (int i = 0; i < sd.SearchParmsCount(); i++)
            {
                strTag = sd.GetSearchParmAt(i).GetTag();
                if (strTag == MinPairsSearch.kTarget1)
                    this.Grapheme1 = sd.GetSearchParmContent(strTag);
                if (strTag == MinPairsSearch.kTarget2)
                    this.Grapheme2 = sd.GetSearchParmContent(strTag);
                if (strTag == MinPairsSearch.kAll)
                    this.AllPairs = true;
                if (strTag == MinPairsSearch.kRoots)
                    this.RootsOnly = true;
                if (strTag == MinPairsSearch.kTone)
                    this.IgnoreTone = true;
                if (strTag == MinPairsSearch.kHarmony)
                    this.AllowVowelHarmony = true;
            }
            if (this.AllPairs)
                m_Title = m_Title + " - [" + this.Grapheme1 + "]";
            else m_Title = m_Title + " - [" + this.Grapheme1 + "] [" + this.Grapheme2 + "]";
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
                strText += Search.TagOpener + strSN + Search.TagCloser + Environment.NewLine;
            }
            strText += this.Title + Environment.NewLine + Environment.NewLine;
            strText += this.SearchResults;
            strText += Environment.NewLine;
            //strText += this.SearchCount.ToString() +  " entries found" + Environment.NewLine;
            str = m_Settings.LocalizationTable.GetMessage("Search2");
            if (str == "")
                str = "entries found";
            strText += this.SearchCount.ToString() + Constants.Space + str + Environment.NewLine;
            if (this.SearchNumber > 0)
                strText += Search.TagOpener + Search.TagForwardSlash + strSN
                    + Search.TagCloser;
            return strText;
        }

        public MinPairsSearch ExecuteMinPairsSearch(WordList wl)
        {
            GraphemeInventory gi = m_Settings.GraphemeInventory;
            this.SearchResults = wl.GetDisplayHeadings() + Environment.NewLine;
            if (this.AllPairs)
            {
                Grapheme grf1 = gi.GetGrapheme(this.Grapheme1);
                //ExecuteMinPairsSearchAll(wl, grf1, gi);
            }
            else
            {
                Grapheme grf1 = gi.GetGrapheme(this.Grapheme1);
                Grapheme grf2 = gi.GetGrapheme(this.Grapheme2);
                ExecuteMinPairsSearch2(wl, grf1, grf2);
            }
            if (this.SearchCount == 0)
            {
                //this.SearchResults = "***No Results***";
                this.SearchResults += m_Settings.LocalizationTable.GetMessage("Search1");
                if (this.SearchResults == "")
                    this.SearchResults = "***No Results***";
            }
            return this;
        }

        private void ExecuteMinPairsSearch2(WordList wl, Grapheme grf1, Grapheme grf2)
        {
            int nCount = 0;
            string strResult = "";
            Word wrd1 = null;
            Word wrd2 = null;
            int nWord = wl.WordCount();
            bool fMinPair = false;
            //SearchOptions so = this.SearchOptions;

            string str = m_Settings.LocalizationTable.GetMessage("MinPairsSearch5");
            if (str == "")
                str = "Processing Minimal Pairs Search";
            FormProgressBar form = new FormProgressBar(str);
            form.PB_Init(1, nWord);

            for (int i = 0; i < nWord; i++)
            {
                wrd1 = wl.GetWord(i);           //Get first word for comparison
                form.PB_Update(i + 1);
                //for (int j = i + 1; j < nWord; j++)
                for (int j = 0; j < nWord; j++)
                {
                    wrd2 = wl.GetWord(j);       //get second word for comparsion
                    fMinPair = IsMinPair(wrd1, wrd2, grf1, grf2);
                    if (fMinPair)
                    {
                        strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
                        strResult += wl.GetDisplayLineForWord(j) + Environment.NewLine;
                        strResult += Environment.NewLine;
                        nCount++;
                    }
                }
            }

            form.Close();
            if (nCount > 0)
            {
                this.SearchResults += strResult;
                this.SearchCount += nCount;
            }
            return;
        }

        //private void ExecuteMinPairsSearchAll(WordList wl, Grapheme grf1, GraphemeInventory gi)
        //{
        //    int nCount = 0;
        //    string strResult = "";
        //    Word wrd1 = null;
        //    Word wrd2 = null;
        //    Grapheme grf2 = null;
        //    int nWord = wl.WordCount();
        //    bool fMinPair = false;

        //    string str = m_Settings.LocalizationTable.GetMessage("MinPairsSearch5");
        //    FormProgressBar form = new FormProgressBar(str);
        //    form.PB_Init(1, nWord);

        //    for (int i = 0; i < nWord; i++)
        //    {
        //        wrd1 = wl.GetWord(i);         //Get first word for comparison
        //        form.PB_Update(i + 1);
        //        for (int j = 0; j < nWord; j++)
        //        {
        //            wrd2 = wl.GetWord(j);     //get second word for comparsion

        //            for (int k = 0; k < gi.ConsonantCount(); k++)
        //            {
        //                grf2 = (Grapheme) gi.GetConsonant(k);
        //                //fMinPair = IsMinPair(wrd1, wrd2, grf1, grf2);
        //                if (fMinPair)
        //                {
        //                    strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
        //                    strResult += wl.GetDisplayLineForWord(j) + Environment.NewLine;
        //                    strResult += Environment.NewLine;
        //                    nCount++;
        //                }
        //            }

        //            for (int k = 0; k < gi.VowelCount(); k++)
        //            {
        //                grf2 = (Grapheme)gi.GetVowel(k);
        //                //fMinPair = IsMinPair(wrd1, wrd2, grf1, grf2);
        //                if (fMinPair)
        //                {
        //                    strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
        //                    strResult += wl.GetDisplayLineForWord(j) + Environment.NewLine;
        //                    strResult += Environment.NewLine;
        //                    nCount++;
        //                }
        //            }

        //            for (int k = 0; k < gi.ToneCount(); k++)
        //            {
        //                grf2 = (Grapheme) gi.GetTone(k);
        //                //fMinPair = IsMinPair(wrd1, wrd2, grf1, grf2);
        //                if (fMinPair)
        //                {
        //                    strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
        //                    strResult += wl.GetDisplayLineForWord(j) + Environment.NewLine;
        //                    strResult += Environment.NewLine;
        //                    nCount++;
        //                }
        //            }
        //        }
        //    }

        //    form.Close();
        //    if (nCount > 0)
        //    {
        //        this.SearchResults += strResult;
        //        this.SearchCount += nCount;
        //    }
        //    return;
        //}

        private bool IsMinPair(Word wrd1, Word wrd2, Grapheme grf1, Grapheme grf2)
        {
            bool fReturn = false;

            if (this.SearchOptions == null)             //no search options
            {
                if (this.RootsOnly)     //doing roots
                {
                    if (!wrd1.Root.IsSame(wrd2.Root))
                    {
                        if (this.AllowVowelHarmony && grf1.IsVowel && grf2.IsVowel)
                            fReturn = wrd1.Root.IsMinimalPairHarmony(wrd2.Root, this.IgnoreTone,
                                grf1, grf2);
                        else fReturn = wrd1.Root.IsMinimalPair(wrd2.Root, this.IgnoreTone,
                            grf1, grf2);
                    }
                }
                else            //doing words
                {
                    if (!wrd1.IsSame(wrd2))
                    {
                        if (this.AllowVowelHarmony && grf1.IsVowel && grf2.IsVowel)
                            fReturn = wrd1.IsMinimalPairHarmony(wrd2, this.IgnoreTone, grf1, grf2);
                        else fReturn = wrd1.IsMinimalPair(wrd2, this.IgnoreTone, grf1, grf2);
                    }
                }
            }
            else        //have search options
            {
                if ((this.SearchOptions.MatchesWord(wrd1)) && (this.SearchOptions.MatchesWord(wrd2)))
                {
                    if (this.RootsOnly)      //doing roots
                    {
                        if (!wrd1.Root.IsSame(wrd2.Root))
                        {
                            if (this.AllowVowelHarmony  && grf1.IsVowel && grf2.IsVowel)
                                fReturn = wrd1.Root.IsMinimalPairHarmony(wrd2.Root, this.IgnoreTone,
                                    grf1, grf2);
                            else fReturn = wrd1.Root.IsMinimalPair(wrd2.Root, this.IgnoreTone,
                                grf1, grf2);
                        }
                    }
                    else       //doing words
                    {
                        if (!wrd1.IsSame(wrd2))
                        {
                            if (this.AllowVowelHarmony  && grf1.IsVowel && grf2.IsVowel)
                                fReturn = wrd1.IsMinimalPairHarmony(wrd2, this.IgnoreTone, grf1, grf2);
                            else fReturn = wrd1.IsMinimalPair(wrd2, this.IgnoreTone, grf1, grf2);
                        }
                    }
                }
            }
            return fReturn;
        }

    }
}

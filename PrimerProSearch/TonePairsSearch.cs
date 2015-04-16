using System;
using System.Windows.Forms;
using System.Drawing;
using PrimerProForms;
using PrimerProObjects;
using GenLib;

namespace PrimerProSearch
{
    public class TonePairsSearch : Search
    {
        //Search parameters 
        private string m_Grapheme;	    	    //first grapheme for Minimal Pairs
        private bool m_AllowVowelHarmony;       //Allow Harmony
        private SearchOptions m_SearchOptions;	//search options filter
        private string m_Title;		            //search title
        private Settings m_Settings;            //Application settings
        private PSTable m_PSTable;		        //Parts of Speech
        private GraphemeInventory m_GI;         //Grapheme Inventory
        private Font m_DefaultFont;             //Default Font
 
        //Search Definition tags
        private const string kTarget1 = "target1";
        private const string kHarmony = "AllowForVowelHarmony";

        //private const string kTitle = "Minimal Pairs Search";
        //private const string kSearch = "Processing Minimal Pairs Search";
 		
        public TonePairsSearch(int number, Settings s)
            : base(number, SearchDefinition.kMinPairs)
		{
			m_Grapheme = "";
            m_AllowVowelHarmony = false;
			m_SearchOptions = null;
            m_Settings = s;
            m_Title = m_Settings.LocalizationTable.GetMessage("MinPairsSearchT",
                m_Settings.OptionSettings.UILanguage);
            m_PSTable = m_Settings.PSTable;
            m_GI = m_Settings.GraphemeInventory;
            m_DefaultFont = m_Settings.OptionSettings.GetDefaultFont();
		}
 
        public string Grapheme
		{
            get { return m_Grapheme; }
            set { m_Grapheme = value; }
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
            FormTonePairs form = new FormTonePairs(m_PSTable, m_DefaultFont,
                m_Settings.LocalizationTable, m_Settings.OptionSettings.UILanguage);
            DialogResult dr;
            dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                int ndx = m_GI.FindToneIndex(form.Grapheme);
                if (ndx >= 0)
                {
                    this.Grapheme = form.Grapheme;
                    this.AllowVowelHarmony = form.AllowVowelHarmony;
                    this.SearchOptions = form.SearchOptions;

                    SearchDefinition sd = new SearchDefinition(SearchDefinition.kTonePairs);
                    SearchDefinitionParm sdp = null;
                    this.SearchDefinition = sd;

                    if (this.m_Grapheme != "")
                    {
                        if (this.GI.IsInInventory(this.Grapheme))
                        {
                            sdp = new SearchDefinitionParm(TonePairsSearch.kTarget1, this.Grapheme);
                            sd.AddSearchParm(sdp);
                            if (this.AllowVowelHarmony)
                            {
                                sdp = new SearchDefinitionParm(TonePairsSearch.kHarmony);
                                sd.AddSearchParm(sdp);
                            }

                            m_Title = m_Title + " - [" + this.Grapheme + "]";
                            if (m_SearchOptions != null)
                                sd.AddSearchOptions(m_SearchOptions);
                            this.SearchDefinition = sd;
                            flag = true;
                        }
                        //else MessageBox.Show("Grapheme " + this.Grapheme1 + " is not in Inventory");
                        else
                        {
                            strMsg = m_Settings.LocalizationTable.GetMessage("TonePairsSearch1",
                                m_Settings.OptionSettings.UILanguage);
                            MessageBox.Show(strMsg);
                        }
                    }
                    //else MessageBox.Show("Grapheme must be specified");
                    else
                    {
                        strMsg = m_Settings.LocalizationTable.GetMessage("TonePairsSearch2",
                            m_Settings.OptionSettings.UILanguage);
                        MessageBox.Show(strMsg);
                    }
                }
                else MessageBox.Show("Grapheme is not tone");
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
                if (strTag == TonePairsSearch.kTarget1)
                    this.Grapheme = sd.GetSearchParmContent(strTag);
                if (strTag == TonePairsSearch.kHarmony)
                    this.AllowVowelHarmony = true;
            }
            m_Title = m_Title + " - [" + this.Grapheme + "]";
            this.SearchOptions = sd.MakeSearchOptions(so);
            this.SearchDefinition = sd;
            return flag;
        }

        public string BuildResults()
        {
            string strText = "";
            string strSN = "";
            if (this.SearchNumber > 0)
            {
                strSN = Search.TagSN + this.SearchNumber.ToString().Trim();
                strText += Search.TagOpener + strSN + Search.TagCloser + Environment.NewLine;
            }
            strText += this.Title + Environment.NewLine + Environment.NewLine;
            strText += this.SearchResults;
            strText += Environment.NewLine;
            strText += this.SearchCount.ToString();
            //strText += " entries found" + Environment.NewLine;
            strText += Constants.Space + m_Settings.LocalizationTable.GetMessage("Search2",
                m_Settings.OptionSettings.UILanguage) + Environment.NewLine;
            if (this.SearchNumber > 0)
                strText += Search.TagOpener + Search.TagForwardSlash + strSN
                    + Search.TagCloser;
            return strText;
        }

        public TonePairsSearch ExecuteTonePairsSearch(WordList wl)
        {
            Tone tone = null;
            Grapheme grf1 = null;
            Grapheme grf2 = null;
            string strGrf = this.Grapheme;
            string strResult = "";
            int nCount = 0;
            SearchOptions so = this.SearchOptions;
            
            grf2 = this.GI.GetGrapheme(strGrf);
            int ndx = this.GI.FindToneIndex(strGrf);
            if (ndx >= 0)
            {
                tone = this.GI.GetTone(ndx);
                grf1 = tone.ToneBearingUnit;
                strResult = wl.GetDisplayHeadings() + Environment.NewLine;
                GraphemeInventory gi = m_Settings.GraphemeInventory;

                //Process each grapheme pair for the given wordlist
                Word wrd1 = null;
                Word wrd2 = null;
                int nWord = wl.WordCount();
                bool fMinPair = false;

                string str = m_Settings.LocalizationTable.GetMessage("TonePairsSearch3",
                    m_Settings.OptionSettings.UILanguage);
                FormProgressBar form = new FormProgressBar(str);
                form.PB_Init(1, nWord);

                for (int i = 0; i < nWord; i++)
                {
                    wrd1 = wl.GetWord(i);         //Get first word for comparison
                    //fpb.PB_Update(i + 1);  temporary comment
                    for (int j = 0; j < nWord; j++)
                    {
                        wrd2 = wl.GetWord(j);       //get second word for comparsion
                        if (so == null)             //no search options
                        {
                            if (!wrd1.IsSame(wrd2))
                            {
                                if (this.AllowVowelHarmony)
                                    fMinPair = wrd1.IsMinimalPairHarmony(wrd2, false, grf1, grf2);
                                else fMinPair = wrd1.IsMinimalPair(wrd2, false, grf1, grf2);
                                if (fMinPair)
                                {
                                    strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
                                    strResult += wl.GetDisplayLineForWord(j) + Environment.NewLine;
                                    strResult += Environment.NewLine;
                                    nCount++;
                                }
                            }
                        }
                        else        //have search options
                        {
                            if ((so.MatchesWord(wrd1)) && (so.MatchesWord(wrd2)))
                            {
                                if (!wrd1.IsSame(wrd2))
                                {
                                    if (this.AllowVowelHarmony)
                                        fMinPair = wrd1.IsMinimalPairHarmony(wrd2, false, grf1, grf2);
                                    else fMinPair = wrd1.IsMinimalPair(wrd2, false, grf1, grf2);
                                    if (fMinPair)
                                    {
                                        strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
                                        strResult += wl.GetDisplayLineForWord(j) + Environment.NewLine;
                                        strResult += Environment.NewLine;
                                        nCount++;
                                    }
                                }
                            }
                        }
                    }
                }

                form.Close();
                if (nCount > 0)
                {
                    this.SearchResults = strResult;
                    this.SearchCount = nCount;
                }
                else
                {
                    //this.SearchResults = "***No Results***";
                    this.SearchResults += m_Settings.LocalizationTable.GetMessage("Search1",
                        m_Settings.OptionSettings.UILanguage);
                    this.SearchCount = 0;
                }
            }
            else
            {
                MessageBox.Show("Grapheme is not a syllograph grapheme");
            }
            return this;
        }

    }
}

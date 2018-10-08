using System;
using System.Windows.Forms;
using PrimerProForms;
using PrimerProObjects;
using GenLib;

namespace PrimerProSearch
{
    /// <summary>
    /// Frequenncy Search in Word List
    /// </summary>
    public class FrequencyWLSearch : Search
    {
        //Search parameters 
        private bool m_IgnoreSightWords;        // Ignore Sight Words
        private bool m_IgnoreTone;             // Ignore Tone Marks
        private bool m_DisplayPercentages;      // Display percentage
        private SearchOptions m_SearchOptions;  // Search options filters

        private string m_Title;                 // Search title
        private Settings m_Settings;            // Application settings
        private PSTable m_PSTable;              // Parts of speech
        private GraphemeInventory m_GraphemeInventory;         // Grapheme Inventory

        // Search Definition tags
        private const string kIgnoreSightWords = "IgnoreSightWords";
        private const string kIgnoreTone = "IgnoreTone";
        private const string kDisplayPercentages = "DisplayPercentages";

        //private const string kTitle = "Frequency Count in Word List";

        public FrequencyWLSearch(int number, Settings s)
            : base(number, SearchDefinition.kFrequencyWL)
        {
            m_IgnoreSightWords = false;
            m_IgnoreSightWords = false;
            m_DisplayPercentages = false;
            m_SearchOptions = null;

            m_Settings = s;
            //m_Title = FrequencyWLSearch.kTitle;
            m_Title = m_Settings.LocalizationTable.GetMessage("FrequencyWLSearchT");
            if (m_Title == "")
                m_Title = "Frequency Count from Word List";
            m_PSTable = m_Settings.PSTable;
            m_GraphemeInventory = m_Settings.GraphemeInventory;
        }

        public bool IgnoreSightWords
        {
            get {return m_IgnoreSightWords;}
            set {m_IgnoreSightWords = value;}
        }

        public bool IgnoreTone
        {
            get { return m_IgnoreTone; }
            set { m_IgnoreTone = value; }
        }

        public bool DisplayPercentages
        {
            get {return m_DisplayPercentages;}
            set { m_DisplayPercentages = value; }
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

        public GraphemeInventory GraphemeInventory
        {
            get {return m_GraphemeInventory;}
        }

 		public bool SetupSearch()
		{
            bool flag = false;
            //FormFrequencyWL fpb = new FormFrequencyWL(this.PSTable);
            FormFrequencyWL form = new FormFrequencyWL(m_PSTable,
                m_Settings.LocalizationTable, m_Settings.OptionSettings.UILanguage);
            DialogResult dr;
            dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.IgnoreSightWords = form.IgnoreSightWords;
                this.IgnoreTone = form.IgnoreTone;
                this.DisplayPercentages = form.DisplayPercentages;
                this.SearchOptions = form.SearchOptions;

                SearchDefinition sd = new SearchDefinition(SearchDefinition.kFrequencyWL);
                SearchDefinitionParm sdp = null;
                this.SearchDefinition = sd;

                if (form.IgnoreSightWords)
                {
                    sdp = new SearchDefinitionParm(FrequencyWLSearch.kIgnoreSightWords);
                    sd.AddSearchParm(sdp);
                }
                if (form.IgnoreTone)
                {
                    sdp = new SearchDefinitionParm(FrequencyWLSearch.kIgnoreTone);
                    sd.AddSearchParm(sdp);
                }
                if (form.DisplayPercentages)
                {
                    sdp = new SearchDefinitionParm(FrequencyWLSearch.kDisplayPercentages);
                    sd.AddSearchParm(sdp);
                }
                if (form.SearchOptions != null)
                    sd.AddSearchOptions(this.SearchOptions);
                this.SearchDefinition = sd;
                flag = true;
            }
            return flag;
		}

 		public bool SetupSearch(SearchDefinition sd)
		{
			bool flag = true;
            string strTag = "";
            SearchOptions so = new SearchOptions(m_PSTable);

            for (int i = 0; i < sd.SearchParmsCount(); i++)
            {
                strTag = sd.GetSearchParmAt(i).GetTag();
                if (strTag == FrequencyWLSearch.kIgnoreSightWords)
                    this.IgnoreSightWords = true;
                if (strTag == FrequencyWLSearch.kIgnoreTone)
                    this.IgnoreTone = true;
                if (strTag == FrequencyWLSearch.kDisplayPercentages)
                    this.DisplayPercentages = true;
            }

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
            str =  m_Settings.LocalizationTable.GetMessage("Search2");
            if (str == "")
                str = "entries found";
            strText += this.SearchCount.ToString() + Constants.Space + str + Environment.NewLine;
			if (this.SearchNumber > 0)
				strText += Search.TagOpener + Search.TagForwardSlash + strSN
					+ Search.TagCloser;
			return strText;
		}

        //public FrequencyWLSearch XExecuteFrequencySearch(WordList wl)
        //{
        //    Word wrd = null;
        //    Consonant cns = null;
        //    Vowel vwl = null;
        //    Tone tone = null;
        //    Syllograph syllograph = null;
        //    string strSymbol = "";
        //    string strText = "";

        //    // Process consonants
        //    for (int i = 0; i < this.GraphemeInventory.ConsonantCount(); i++)
        //    {
        //        cns = this.GraphemeInventory.GetConsonant(i);
        //        strSymbol = cns.Symbol;
        //        cns.InitCountInWordList();
        //        for (int j = 0; j < wl.WordCount(); j++)
        //        {
        //            wrd = wl.GetWord(j);
        //            if (this.SearchOptions != null)
        //            {
        //                if ((this.SearchOptions.MatchesWord(wrd))
        //                    && (this.SearchOptions.MatchesPosition(wrd, strSymbol)))
        //                {
        //                    if (this.SearchOptions.IsRootOnly)
        //                    {
        //                        if (wrd.Root.IsInRoot(strSymbol))
        //                            cns.IncrCountInWordList();
        //                    }
        //                    else
        //                    {
        //                        if (wrd.ContainInWord(strSymbol))
        //                            cns.IncrCountInWordList();
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                if (wrd.ContainInWord(strSymbol))
        //                    cns.IncrCountInWordList();
        //            }
        //        }
        //    }

        //    //Process vowels
        //    for (int i = 0; i < this.GraphemeInventory.VowelCount(); i++)
        //    {
        //        vwl = this.GraphemeInventory.GetVowel(i);
        //        strSymbol = vwl.Symbol;
        //        vwl.InitCountInWordList();
        //        for (int j = 0; j < wl.WordCount(); j++)
        //        {
        //            wrd = wl.GetWord(j);
        //            if (this.SearchOptions != null)
        //            {
        //                if ((this.SearchOptions.MatchesWord(wrd))
        //                    && (this.SearchOptions.MatchesPosition(wrd, strSymbol)))
        //                {
        //                    if (wrd.ContainInWord(strSymbol))
        //                        vwl.IncrCountInWordList();
        //                }
        //            }
        //            else
        //            {
        //                if (wrd.ContainInWord(strSymbol))
        //                    vwl.IncrCountInWordList();
        //            }
        //        }
        //    }

        //    //Process Tones
        //    for (int i = 0; i < this.GraphemeInventory.ToneCount(); i++)
        //    {
        //        tone = this.GraphemeInventory.GetTone(i);
        //        strSymbol = tone.Symbol;
        //        tone.InitCountInWordList();
        //        for (int j = 0; j < wl.WordCount(); j++)
        //        {
        //            wrd = wl.GetWord(j);
        //            if (this.SearchOptions != null)
        //            {
        //                if ((this.SearchOptions.MatchesWord(wrd))
        //                    && (this.SearchOptions.MatchesPosition(wrd, strSymbol)))
        //                {
        //                    if (this.SearchOptions.IsRootOnly)
        //                    {
        //                        if (wrd.Root.IsInRoot(strSymbol))
        //                            tone.IncrCountInWordList();
        //                    }
        //                    else
        //                    {
        //                        if (wrd.ContainInWord(strSymbol))
        //                            tone.IncrCountInWordList();
        //                    }
        //                }
        //            }
        //            else //no search options
        //            {
        //                if (wrd.ContainInWord(strSymbol))
        //                    tone.IncrCountInWordList();
        //            }
        //        }
        //    }

        //    //Process Syllabaries
        //    for (int i = 0; i < this.GraphemeInventory.SyllographCount(); i++)
        //    {
        //        syllograph = this.GraphemeInventory.GetSyllograph(i);
        //        strSymbol = syllograph.Symbol;
        //        syllograph.InitCountInWordList();
        //        for (int j = 0; j < wl.WordCount(); j++)
        //        {
        //            wrd = wl.GetWord(j);
        //            if (this.SearchOptions != null)
        //            {
        //                if ((this.SearchOptions.MatchesWord(wrd))
        //                    && (this.SearchOptions.MatchesPosition(wrd, strSymbol)))
        //                {
        //                    if (this.SearchOptions.IsRootOnly)
        //                    {
        //                        if (wrd.Root.IsInRoot(strSymbol))
        //                            syllograph.IncrCountInWordList();
        //                    }
        //                    else
        //                    {
        //                        if (wrd.ContainInWord(strSymbol))
        //                            syllograph.IncrCountInWordList();
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                if (wrd.ContainInWord(strSymbol))
        //                    syllograph.IncrCountInWordList();
        //            }
        //        }
        //    }

        //    //strText += "Consonants" + Environment.NewLine;
        //    strText += m_Settings.LocalizationTable.GetMessage("FrequencyWLSearch1") + Environment.NewLine;
        //    if (this.DisplayPercentages)
        //        strText += this.GraphemeInventory.SortedConsonantPercentagesInWordList();
        //    else strText += this.GraphemeInventory.SortedConsonantCountsInWordList();
        //    strText += Environment.NewLine;
            
        //    //strText += "Vowels" + Environment.NewLine;
        //    strText += m_Settings.LocalizationTable.GetMessage("FrequencyWLSearch2") + Environment.NewLine;
        //    if (this.DisplayPercentages)
        //        strText += this.GraphemeInventory.SortedVowelPercentagesInWordList();
        //    else strText += this.GraphemeInventory.SortedVowelCountsInWordList();
        //    strText += Environment.NewLine;

        //    //strText += "Tones" + Environment.NewLine;
        //    strText += m_Settings.LocalizationTable.GetMessage("FrequencyWLSearch3") + Environment.NewLine;
        //    if (this.DisplayPercentages)
        //        strText += this.GraphemeInventory.SortedTonePercentsgesInWordList();
        //    else strText += this.GraphemeInventory.SortedToneCountsInWordList();
        //    strText += Environment.NewLine;

        //    //strText += "Syllographs" + Environment.NewLine;
        //    strText += m_Settings.LocalizationTable.GetMessage("FrequencyWLSearch4") + Environment.NewLine;
        //    if (this.DisplayPercentages)
        //        strText += this.GraphemeInventory.SortedSyllographPercentagesInWordList();
        //    else strText += this.GraphemeInventory.SortedSyllographCountsInWordList();

        //    this.SearchResults = strText;
        //    this.SearchCount = wl.WordCount();
        //    return this;
        //}

        public FrequencyWLSearch ExecuteFrequencySearch(WordList wl)
        {
            Word wrd = null;
            int nWord = 0;
            string strText = "";
            string str = "";

            // Reset all words in word list to be initially available
            for (int i = 0; i < wl.WordCount(); i++)
            {
                wrd = wl.GetWord(i);
                wrd.Available = true;
            }

            // Filter out words for the count
            for (int i = 0; i < wl.WordCount(); i++)
            {
                wrd = wl.GetWord(i);
                if (this.SearchOptions != null)
                {
                    if (!this.SearchOptions.MatchesWord(wrd))
                        wrd.Available = false;
                    else nWord++;
                }
                else if ((wrd.IsSightWord()) && (this.IgnoreSightWords))
                    wrd.Available = false;
                else nWord++;
            }

            // Update Grapheme counts 
            m_GraphemeInventory = wl.UpdateGraphemeCounts(this.GraphemeInventory, this.IgnoreSightWords, this.IgnoreTone);

            //strText += "Consonants" + Environment.NewLine;
            str = m_Settings.LocalizationTable.GetMessage("FrequencyWLSearch1");
            if (str == "")
                str = "Consonants";
            strText += str  + Environment.NewLine;
            if (this.DisplayPercentages)
                strText += this.GraphemeInventory.SortedConsonantPercentagesInWordList();
            else strText += this.GraphemeInventory.SortedConsonantCountsInWordList();
            strText += Environment.NewLine;
            
            //strText += "Vowels" + Environment.NewLine;
            str = m_Settings.LocalizationTable.GetMessage("FrequencyWLSearch2");
            if (str == "")
                str = "Vowels";
            strText += str + Environment.NewLine;
            if (this.DisplayPercentages)
                strText += this.GraphemeInventory.SortedVowelPercentagesInWordList();
            else strText += this.GraphemeInventory.SortedVowelCountsInWordList();
            strText += Environment.NewLine;

            //strText += "Tones" + Environment.NewLine;
            if (!this.IgnoreTone)
            {
                str = m_Settings.LocalizationTable.GetMessage("FrequencyWLSearch3");
                if (str == "")
                    str = "Tones";
                strText += str + Environment.NewLine;
                if (this.DisplayPercentages)
                    strText += this.GraphemeInventory.SortedTonePercentsgesInWordList();
                else strText += this.GraphemeInventory.SortedToneCountsInWordList();
                strText += Environment.NewLine;
            }

            //strText += "Syllographs" + Environment.NewLine;
            str = m_Settings.LocalizationTable.GetMessage("FrequencyWLSearch4");
            if (str == "")
                str = "Syllographs";
            strText += str + Environment.NewLine;
            if (this.DisplayPercentages)
                strText += this.GraphemeInventory.SortedSyllographPercentagesInWordList();
            else strText += this.GraphemeInventory.SortedSyllographCountsInWordList();
            
            this.SearchResults = strText;
            this.SearchCount = nWord;
            return this;
        }

    }
}

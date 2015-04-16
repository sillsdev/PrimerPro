using System;
using System.Collections;
using System.Windows.Forms;
using PrimerProForms;
using PrimerProObjects;
using GenLib;

namespace PrimerProSearch
{
    public class TeachingOrderTDSearch : Search
    {
        //Search parameters
        private bool m_IncludeConsonant;
        private bool m_IncludeVowels;
        private bool m_IncludeTone;
        private bool m_IncludeSyllograph;
        private SyllographFeatures.SyllographType m_SType;
        private bool m_IgnoreTone;

        private string m_Title;
        private Settings m_Settings;
        private GraphemeInventory m_GI;

        //Search Definition tags
        private const string kIncludeC = "includeconsonant";
        private const string kIncludeV = "includevowel";
        private const string kIncludeT = "includetone";
        private const string kIncludeS = "includesyllograph";
        private const string kSyllType = "syllographtype";
        private const string kIgnoreTone = "ignoretone";
        
        //private const string kTitle = "Consonant Teaching Order from Text Data";
        //private const string kInitOrder = "Initializing Consonant Teaching Order";
        //private const string kProcessOrder = "Processing Consonant Teaching Order";
        
        public TeachingOrderTDSearch(int number, Settings s)
			: base(number, SearchDefinition.kOrderTD)
		{
            m_Settings = s;
            m_Title = m_Settings.LocalizationTable.GetMessage("TeachingOrderTDSearchT",
                m_Settings.OptionSettings.UILanguage);
            m_GI = m_Settings.GraphemeInventory;
		}

        public bool IncludeConsonant
        {
            get { return m_IncludeConsonant; }
            set { m_IncludeConsonant = value; }
        }

        public bool IncludeVowel
        {
            get { return m_IncludeVowels; }
            set { m_IncludeVowels = value; }
        }

        public bool IncludeTone
        {
            get { return m_IncludeTone; }
            set { m_IncludeTone = value; }
        }

        public bool IncludeSyllograph
        {
            get { return m_IncludeSyllograph; }
            set { m_IncludeSyllograph = value; }
        }

        public SyllographFeatures.SyllographType SType
        {
            get { return m_SType; }
            set { m_SType = value; }
        }

        public bool IgnoreTone
        {
            get { return m_IgnoreTone; }
            set { m_IgnoreTone = value; }
        }

        public string Title
		{
			get {return m_Title;}
		}

		public GraphemeInventory GI
		{
			get {return m_GI;}
		}

		public bool SetupSearch()
		{
            bool flag = false;
            FormTeachingOrder form = new FormTeachingOrder(m_Settings.LocalizationTable,
                m_Settings.OptionSettings.UILanguage);
            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.IncludeConsonant = form.IncludeConsonant;
                this.IncludeVowel = form.IncludeVowel;
                this.IncludeTone = form.IncludeTone;
                this.IncludeSyllograph = form.IncludeSyllograph;
                this.SType = form.SType;
                this.IgnoreTone = form.IgnoreTone;

                SearchDefinition sd = new SearchDefinition(SearchDefinition.kOrderTD);
                SearchDefinitionParm sdp = null;
                if (this.IncludeConsonant)
                {
                    sdp = new SearchDefinitionParm(TeachingOrderTDSearch.kIncludeC);
                    sd.AddSearchParm(sdp);
                }
                if (this.IncludeVowel)
                {
                    sdp = new SearchDefinitionParm(TeachingOrderTDSearch.kIncludeV);
                    sd.AddSearchParm(sdp);
                }
                if (this.IncludeTone)
                {
                    sdp = new SearchDefinitionParm(TeachingOrderTDSearch.kIncludeT);
                    sd.AddSearchParm(sdp);
                }
                if (this.IncludeSyllograph)
                {
                    sdp = new SearchDefinitionParm(TeachingOrderTDSearch.kIncludeS);
                    sd.AddSearchParm(sdp);
                    sdp = new SearchDefinitionParm(TeachingOrderTDSearch.kSyllType, this.SType.ToString());
                    sd.AddSearchParm(sdp);
                }
                if (this.IgnoreTone)
                {
                    sdp = new SearchDefinitionParm(TeachingOrderTDSearch.kIgnoreTone);
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
            string strTag = "";
            for (int i = 0; i < sd.SearchParmsCount(); i++)
            {
                strTag = sd.GetSearchParmAt(i).GetTag();
                if (strTag == TeachingOrderTDSearch.kIncludeC)
                {
                    this.IncludeConsonant = true;
                    flag = true;
                }
                if (strTag == TeachingOrderTDSearch.kIncludeV)
                {
                    this.IncludeVowel = true;
                    flag = true;
                }
                if (strTag == TeachingOrderTDSearch.kIncludeT)
                {
                    this.IncludeTone = true;
                    flag = true;
                }
                if (strTag == TeachingOrderTDSearch.kIncludeS)
                {
                    this.IncludeSyllograph = true;
                    flag = true;
                }
                if (strTag == TeachingOrderTDSearch.kSyllType)
                {
                    switch (sd.GetSearchParmContent(strTag))
                    {
                        case "Pri":
                            this.SType = SyllographFeatures.SyllographType.Pri;
                            break;
                        case "Sec":
                            this.SType = SyllographFeatures.SyllographType.Sec;
                            break;
                        case "Ter":
                            this.SType = SyllographFeatures.SyllographType.Ter;
                            break;
                        default:
                            this.SType = SyllographFeatures.SyllographType.None;
                            break;
                    }
                    flag = true;
                }
                if (strTag == TeachingOrderTDSearch.kIgnoreTone)
                {
                    this.IgnoreTone = true;
                    flag = true;
                }
            }
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
            if (this.SearchNumber > 0)
                strText += Search.TagOpener + Search.TagForwardSlash + strSN
                    + Search.TagCloser;
            return strText;
        }

        public TeachingOrderTDSearch ExecuteOrderSearch(TextData td)
        {
            string strRslt = "";

            if (this.IncludeConsonant)
                strRslt += ProcessConsonants(td);        //Processing teaching order for consonants

            if (this.IncludeVowel)
                strRslt += ProcessVowels(td);            //Processing teaching order for vowels

            if (this.IncludeTone)
                strRslt += ProcessTones(td);

            if (this.IncludeSyllograph)
            {
                if (this.SType == SyllographFeatures.SyllographType.None)
                    strRslt += ProcessSyllographs(td);   //Process teaching order for syllographs
                else strRslt += ProcessSyllographFeatures(td, this.SType);
            }

            //Indicate number of words processed from text data
            //strRslt += Environment.NewLine;
            //strRslt += "Processed " + td.WordCount().ToString() + " words from Text Data";
            strRslt += td.WordCount().ToString() + Constants.Space +
                m_Settings.LocalizationTable.GetMessage("TeachingOrderTDSearch3",
                m_Settings.OptionSettings.UILanguage);
            this.SearchResults = strRslt;
             return this;
        }

        private string ProcessConsonants(TextData td)
        {
           GraphemeInventory giTemp = new GraphemeInventory(m_Settings);    //Temporary Inventory
            string strRslt = "";
            string strText = "";
            string strMsg = "";
            Word wrd = null;
            Consonant cns = null;
            FormProgressBar fpb = null;

            // Get consonants in inventory
            for (int i = 0; i < this.GI.ConsonantCount(); i++)
            {
                cns = this.GI.GetConsonant(i);
                giTemp.AddConsonant(cns);
            }

            // Build a wordlist from the textdata
            WordList wl = td.BuildWordList();

            // Initialize wordlist so all words are available.
            fpb = new FormProgressBar(m_Settings.LocalizationTable.GetMessage("TeachingOrderTDSearch1",
                m_Settings.OptionSettings.UILanguage));
            fpb.PB_Init(0, wl.WordCount());
            for (int i = 0; i < wl.WordCount(); i++)
            {
                fpb.PB_Update(i);
                wrd = wl.GetWord(i);
                wrd.Available = true;
            }
            fpb.Close();

            //Process consonant order
            fpb = new FormProgressBar(m_Settings.LocalizationTable.GetMessage("TeachingOrderTDSearch2",
                m_Settings.OptionSettings.UILanguage));
            fpb.PB_Init(0, giTemp.ConsonantCount());
            int ndx = 0;
            int num = 0;
            while (giTemp.ConsonantCount() > 0)
            {
                fpb.PB_Update(ndx);
                giTemp = wl.UpdateConsonantCounts(giTemp, this.IgnoreTone);     //Update Consonant Counts
                cns = wl.LeastUsedConsonant(giTemp);                 //get least used consonant
                cns.TeachingOrder = giTemp.ConsonantCount();
                num = this.GI.FindConsonantIndex(cns.Symbol);
                this.GI.UpdConsonant(num, cns);
                num = giTemp.FindConsonantIndex(cns.Symbol);

                strText = cns.Symbol + Environment.NewLine + strText;
                strText = cns.TeachingOrder.ToString().PadLeft(3) + " - " + strText;
                giTemp.DelConsonant(num);
                wl.UnAvailWordsWithConsonant(cns);
                ndx++;
            }
           // Consonant  teaching order
            strMsg = m_Settings.LocalizationTable.GetMessage("TeachingOrderTDSearch4",
                m_Settings.OptionSettings.UILanguage);
            strRslt += strMsg + Environment.NewLine + Environment.NewLine + strText;
            strRslt += Environment.NewLine;
            fpb.Close();
            return strRslt;
        }

        private string ProcessVowels(TextData td)
        {
            GraphemeInventory giTemp = new GraphemeInventory(m_Settings);    //Temporary Inventory
            string strRslt = "";
            string strText = "";
            string strMsg = "";
            Word wrd = null;
            Vowel vwl = null;
            FormProgressBar fpb = null;

            //Get vowel in inventory
            for (int i = 0; i < this.GI.VowelCount(); i++)
            {
                vwl = this.GI.GetVowel(i);
                giTemp.AddVowel(vwl);
            }

            // Build a wordlist from the textdata
            WordList wl = td.BuildWordList();
            
            // Initialize wordlist so all words are available.
            fpb = new FormProgressBar(m_Settings.LocalizationTable.GetMessage("TeachingOrderTDSearch1",
                m_Settings.OptionSettings.UILanguage));
            fpb.PB_Init(0, wl.WordCount());
            for (int i = 0; i < wl.WordCount(); i++)
            {
                fpb.PB_Update(i);
                wrd = wl.GetWord(i);
                wrd.Available = true;
            }
            fpb.Close();

            //Process vowel order
            fpb = new FormProgressBar(m_Settings.LocalizationTable.GetMessage("TeachingOrderTDSearch2",
               m_Settings.OptionSettings.UILanguage));
            fpb.PB_Init(0, giTemp.ToneCount());
            int ndx = 0;
            int num = 0;
            while (giTemp.VowelCount() > 0)
            {
                fpb.PB_Update(ndx);
                giTemp = wl.UpdateVowelCounts(giTemp, this.IgnoreTone);           //Update Vowel Counts
                vwl = wl.LeastUsedVowel(giTemp);                //get least used vowel
                vwl.TeachingOrder = giTemp.VowelCount();
                num = this.GI.FindVowelIndex(vwl.Symbol);
                this.GI.UpdVowel(num, vwl);
                num = giTemp.FindVowelIndex(vwl.Symbol);

                strText = vwl.Symbol + Environment.NewLine + strText;
                strText = vwl.TeachingOrder.ToString().PadLeft(3) + " - " + strText;
                giTemp.DelVowel(num);
                wl.UnAvailWordsWithVowel(vwl);
                ndx++;
            }
            // Vowel teaching order
            strMsg = m_Settings.LocalizationTable.GetMessage("TeachingOrderTDSearch5",
                m_Settings.OptionSettings.UILanguage);
            strRslt += strMsg + Environment.NewLine + Environment.NewLine + strText;
            strRslt += Environment.NewLine;
            fpb.Close();
            return strRslt;
        }

        private string ProcessTones(TextData td)
        {
            GraphemeInventory giTemp = new GraphemeInventory(m_Settings);    //Temporary Inventory
            string strRslt = "";
            string strText = "";
            string strMsg = "";
            Word wrd = null;
           Tone tone = null;
            FormProgressBar fpb = null;

            // Get tones in inventory
            for (int i = 0; i < this.GI.ToneCount(); i++)
            {
                tone = this.GI.GetTone(i);
                giTemp.AddTone(tone);
            }
            
            // Build a wordlist from the textdata
            WordList wl = td.BuildWordList();

            // Initialize wordlist so all words are available.
            fpb = new FormProgressBar(m_Settings.LocalizationTable.GetMessage("TeachingOrderTDSearch1",
                m_Settings.OptionSettings.UILanguage));
            fpb.PB_Init(0, wl.WordCount());
            for (int i = 0; i < wl.WordCount(); i++)
            {
                fpb.PB_Update(i);
                wrd = wl.GetWord(i);
                wrd.Available = true;
            }
            fpb.Close();

            //Process tone order
            fpb = new FormProgressBar(m_Settings.LocalizationTable.GetMessage("TeachingOrderTDSearch2",
               m_Settings.OptionSettings.UILanguage));
            fpb.PB_Init(0, giTemp.ToneCount());
            int ndx = 0;
            int num = 0;
            while (giTemp.ToneCount() > 0)
            {
                fpb.PB_Update(ndx);
                giTemp = wl.UpdateToneCounts(giTemp);       //Update Tone Counts
                tone = wl.LeastUsedTone(giTemp);            //get least used tone
                tone.TeachingOrder = giTemp.ToneCount();
                num = this.GI.FindToneIndex(tone.Symbol);
                this.GI.UpdTone(num, tone);
                num = giTemp.FindToneIndex(tone.Symbol);

                strText = tone.Symbol + Environment.NewLine + strText;
                strText = tone.TeachingOrder.ToString().PadLeft(3) + " - " + strText;
                giTemp.DelTone(num);
                wl.UnAvailWordsWithTone(tone);
                ndx++;
            }
            // Tone teaching order
            strMsg = m_Settings.LocalizationTable.GetMessage("TeachingOrderTDSearch6",
                m_Settings.OptionSettings.UILanguage);
            strRslt += strMsg + Environment.NewLine + Environment.NewLine + strText;
            strRslt += Environment.NewLine;
            fpb.Close();
            return strRslt;
        }

        private string ProcessSyllographs(TextData td)
        {
            GraphemeInventory giTemp = new GraphemeInventory(m_Settings);    //Temporary Inventory
            string strRslt = "";
            string strText = "";
            string strMsg = "";
            Word wrd = null;
            Syllograph syllograph = null;
            FormProgressBar fpb = null;

           //Get syllographs in inventory
            for (int i = 0; i < this.GI.SyllographCount(); i++)
            {
                syllograph = this.GI.GetSyllograph(i);
                giTemp.AddSyllograph(syllograph);
            }

            // Build a wordlist from the textdata
            WordList wl = td.BuildWordList();

            // Initialize wordlist so all words are available.
            fpb = new FormProgressBar(m_Settings.LocalizationTable.GetMessage("TeachingOrderTDSearch1",
                m_Settings.OptionSettings.UILanguage));
            fpb.PB_Init(0, wl.WordCount());
            for (int i = 0; i < wl.WordCount(); i++)
            {
                fpb.PB_Update(i);
                wrd = wl.GetWord(i);
                wrd.Available = true;
            }
            fpb.Close();

            //Process syllograph order
            fpb = new FormProgressBar(m_Settings.LocalizationTable.GetMessage("TeachingOrderTDSearch2",
               m_Settings.OptionSettings.UILanguage));
            fpb.PB_Init(0, giTemp.SyllographCount());
            int ndx = 0;
            int num = 0;
            while (giTemp.SyllographCount() > 0)
            {
                fpb.PB_Update(ndx);
                giTemp = wl.UpdateSyllographCounts(giTemp);             //Update Syllograph Counts
                syllograph = wl.LeastUsedSyllograph(giTemp);             //get least used syllograph
                syllograph.TeachingOrder = giTemp.SyllographCount();
                num = this.GI.FindSyllographIndex(syllograph.Symbol);
                this.GI.UpdSyllograph(num, syllograph);
                num = giTemp.FindSyllographIndex(syllograph.Symbol);

                strText = syllograph.Symbol + Environment.NewLine + strText;
                strText = syllograph.TeachingOrder.ToString().PadLeft(3) + " - " + strText;
                giTemp.DelSyllograph(num);
                wl.UnAvailWordsWithSyllograph(syllograph);
                ndx++;
            }
            //Syllogrpah teaching order
            strMsg = m_Settings.LocalizationTable.GetMessage("TeachingOrderTDSearch7",
                m_Settings.OptionSettings.UILanguage);
            strRslt += strMsg + Environment.NewLine + Environment.NewLine + strText;
            strRslt += Environment.NewLine;
            fpb.Close();
            return strRslt;
        }

        private string ProcessSyllographFeatures(TextData td, SyllographFeatures.SyllographType typ)
        {
            SortedList slFeatures = new SortedList();
            SyllographFeatureInfo info = null;
            string strRslt = "";
            string strText = "";
            string strMsg = "";
            Word wrd = null;
            Syllograph syllograph = null;
            FormProgressBar fpb = null;

            // Get syllograph featuress from inventory
            string strFeature = "";
            for (int i = 0; i < this.GI.SyllographCount(); i++)
            {
                syllograph = this.GI.GetSyllograph(i);
                if (typ == SyllographFeatures.SyllographType.Pri)
                {
                    strFeature = syllograph.CategoryPrimary;
                    info = new SyllographFeatureInfo(strFeature, SyllographFeatures.SyllographType.Pri);
                    if (!slFeatures.ContainsKey(strFeature))
                        slFeatures.Add(strFeature, info);
                }
                else if (typ == SyllographFeatures.SyllographType.Sec)
                {
                    strFeature = syllograph.CategorySecondary;
                    info = new SyllographFeatureInfo(strFeature, SyllographFeatures.SyllographType.Sec);
                    if (!slFeatures.ContainsKey(strFeature))
                        slFeatures.Add(strFeature, info);
                }
                else if (typ == SyllographFeatures.SyllographType.Ter)
                {
                    strFeature = syllograph.CategoryTertiary;
                    info = new SyllographFeatureInfo(strFeature, SyllographFeatures.SyllographType.Ter);
                    if (!slFeatures.ContainsKey(strFeature))
                        slFeatures.Add(strFeature,info);
                }
                else
                {
                    strFeature = syllograph.Symbol;
                    info = new SyllographFeatureInfo(strFeature, SyllographFeatures.SyllographType.None);
                    if (!slFeatures.ContainsKey(strFeature))
                        slFeatures.Add(strFeature,info);
                }
            }

            // Build a wordlist from the textdata
            WordList wl = td.BuildWordList();

            // Reset all words in word list to be initially available
            fpb = new FormProgressBar(m_Settings.LocalizationTable.GetMessage("TeachingOrderWLSearch1",
                m_Settings.OptionSettings.UILanguage));
            fpb.PB_Init(0, wl.WordCount());
            for (int i = 0; i < wl.WordCount(); i++)
            {
                fpb.PB_Update(i);
                wrd = wl.GetWord(i);
                wrd.Available = true;
            }
            fpb.Close();

            //Process syllograph feature order
            int ndx = 0;
            int num = 0;
            fpb = new FormProgressBar(m_Settings.LocalizationTable.GetMessage("TeachingOrderWLSearch2",
                m_Settings.OptionSettings.UILanguage));
            fpb.PB_Init(0,slFeatures.Count);
            while (num < slFeatures.Count )
            {
                fpb.PB_Update(ndx);
                slFeatures = wl.UpdateSyllographFeaturesCounts(slFeatures, this.GI);     //update feature counts
                info = wl.LeastUsedSyllographFeature(slFeatures);
                info.OrderNumber = slFeatures.Count - num;
                info.Available = false;
                slFeatures.Remove(info.Feature);
                slFeatures.Add(info.Feature, info);
                strText = info.Feature + Environment.NewLine + strText;
                strText = info.OrderNumber.ToString().PadLeft(3) + " - " + strText;
                wl.UnAvailWordsWithSyllographFeature(info.Type, info.Feature);
                num++;
                ndx++;
            }

            // Syllograph teaching order (features)
            strMsg = m_Settings.LocalizationTable.GetMessage("TeachingOrderWLSearch7",
                m_Settings.OptionSettings.UILanguage);
            strRslt += strMsg + Environment.NewLine + Environment.NewLine + strText;
            strRslt += Environment.NewLine;
            fpb.Close();
            return strRslt;
        }

        //public TeachingOrderTDSearch ExecuteOrderSearch2(TextData td)
        //{
        //    GraphemeInventory giTemp = new GraphemeInventory(m_Settings);    //Temporary Inventory 
        //    Consonant cns = null;
        //    Vowel vwl = null;
        //    Tone tone = null;
        //    Syllograph syllograph = null;
        //    int num = 0;
        //    Word wrd = null;
        //    string strRslt = "";
        //    string strText = "";
        //    string strMsg = "";
        //    FormProgressBar fpb = null;

        //    // Build temporary Inventory
        //    if (this.IncludeConsonant)
        //    {
        //        for (int i = 0; i < this.GI.ConsonantCount(); i++)
        //        {
        //            cns = this.GI.GetConsonant(i);
        //            giTemp.AddConsonant(cns);
        //        }
        //    }
        //    if (this.IncludeVowel)
        //    {
        //        for (int i = 0; i < this.GI.VowelCount(); i++)
        //        {
        //            vwl = this.GI.GetVowel(i);
        //            giTemp.AddVowel(vwl);
        //        }
        //    }
        //    if (this.IncludeTone)
        //    {
        //        for (int i = 0; i < this.GI.ToneCount(); i++)
        //        {
        //            tone = this.GI.GetTone(i);
        //            giTemp.AddTone(tone);
        //        }
        //    }
        //    if (this.IncludeSyllograph)
        //    {
        //        for (int i = 0; i < this.GI.SyllographCount(); i++)
        //        {
        //            syllograph = this.GI.GetSyllograph(i);
        //            giTemp.AddSyllograph(syllograph);
        //        }
        //    }

        //    // Build a wordlist from the textdata
        //    WordList wl = td.BuildWordList();

        //    // Processing teaching order for consonants
        //    strText = "";
        //    if (this.IncludeConsonant)
        //    {
        //        // Initialize wordlist so all words are available.
        //        fpb = new FormProgressBar(m_Settings.LocalizationTable.GetMessage("TeachingOrderTDSearch1",
        //           m_Settings.OptionSettings.UILanguage));
        //        fpb.PB_Init(0, wl.WordCount());
        //        for (int i = 0; i < wl.WordCount(); i++)
        //        {
        //            fpb.PB_Update(i);
        //            wrd = wl.GetWord(i);
        //            wrd.Available = true;
        //        }
        //        fpb.Close();

        //        //Process consonant order
        //        fpb = new FormProgressBar(m_Settings.LocalizationTable.GetMessage("TeachingOrderTDSearch2",
        //           m_Settings.OptionSettings.UILanguage));
        //        fpb.PB_Init(0, giTemp.ConsonantCount());
        //        int ndx = 0;
        //        while (giTemp.ConsonantCount() > 0)
        //        {
        //            fpb.PB_Update(ndx);
        //            giTemp = wl.UpdateConsonantCounts(giTemp);   //Update Consonant Counts
        //            cns = wl.LeastUsedConsonant(giTemp);         //get least used consonant
        //            cns.TeachingOrder = giTemp.ConsonantCount();
        //            num = this.GI.FindConsonantIndex(cns.Symbol);
        //            this.GI.UpdConsonant(num, cns);
        //            num = giTemp.FindConsonantIndex(cns.Symbol);

        //            strText = cns.Symbol + Environment.NewLine + strText;
        //            strText = cns.TeachingOrder.ToString().PadLeft(3) + " - " + strText;
        //            giTemp.DelConsonant(num);
        //            wl.UnAvailWordsWithConsonant(cns);
        //            ndx++;
        //        }
        //        //Consonants
        //        strMsg = m_Settings.LocalizationTable.GetMessage("TeachingOrderTDSearch4",
        //            m_Settings.OptionSettings.UILanguage);
        //        strRslt += strMsg + Environment.NewLine + Environment.NewLine + strText;
        //        strRslt += Environment.NewLine;
        //        fpb.Close();
        //    }

        //    // Processing teaching order for vowels
        //    strText = "";
        //    if (this.IncludeVowel)
        //    {
        //        // Initialize wordlist so all words are available.
        //        fpb = new FormProgressBar(m_Settings.LocalizationTable.GetMessage("TeachingOrderTDSearch1",
        //           m_Settings.OptionSettings.UILanguage));
        //        fpb.PB_Init(0, wl.WordCount());
        //        for (int i = 0; i < wl.WordCount(); i++)
        //        {
        //            fpb.PB_Update(i);
        //            wrd = wl.GetWord(i);
        //            wrd.Available = true;
        //        }
        //        fpb.Close();

        //        //Process vowel order
        //        fpb = new FormProgressBar(m_Settings.LocalizationTable.GetMessage("TeachingOrderTDSearch2",
        //           m_Settings.OptionSettings.UILanguage));
        //        fpb.PB_Init(0, giTemp.ToneCount());
        //        int ndx = 0;
        //        while (giTemp.VowelCount() > 0)
        //        {
        //            fpb.PB_Update(ndx);
        //            giTemp = wl.UpdateVowelCounts(giTemp);          //Update Vowel Counts
        //            vwl = wl.LeastUsedVowel(giTemp);                       //get least used vowel
        //            vwl.TeachingOrder = giTemp.VowelCount();
        //            num = this.GI.FindVowelIndex(vwl.Symbol);
        //            this.GI.UpdVowel(num, vwl);
        //            num = giTemp.FindVowelIndex(vwl.Symbol);

        //            strText = vwl.Symbol + Environment.NewLine + strText;
        //            strText = vwl.TeachingOrder.ToString().PadLeft(3) + " - " + strText;
        //            giTemp.DelVowel(num);
        //            wl.UnAvailWordsWithVowel(vwl);
        //            ndx++;
        //        }
        //        //Vowels
        //        strMsg = m_Settings.LocalizationTable.GetMessage("TeachingOrderTDSearch5",
        //            m_Settings.OptionSettings.UILanguage);
        //        strRslt += strMsg + Environment.NewLine + Environment.NewLine + strText;
        //        strRslt += Environment.NewLine;
        //        fpb.Close();
        //    }

        //    // Processing teaching order for tones
        //    strText = "";
        //    if (this.IncludeTone)
        //    {
        //        // Initialize wordlist so all words are available.
        //        fpb = new FormProgressBar(m_Settings.LocalizationTable.GetMessage("TeachingOrderTDSearch1",
        //           m_Settings.OptionSettings.UILanguage));
        //        fpb.PB_Init(0, wl.WordCount());
        //        for (int i = 0; i < wl.WordCount(); i++)
        //        {
        //            fpb.PB_Update(i);
        //            wrd = wl.GetWord(i);
        //            wrd.Available = true;
        //        }
        //        fpb.Close();

        //        //Process tone order
        //        fpb = new FormProgressBar(m_Settings.LocalizationTable.GetMessage("TeachingOrderTDSearch2",
        //           m_Settings.OptionSettings.UILanguage));
        //        fpb.PB_Init(0, giTemp.ToneCount());
        //        int ndx = 0;
        //        while (giTemp.ToneCount() > 0)
        //        {
        //            fpb.PB_Update(ndx);
        //            giTemp = wl.UpdateToneCounts(giTemp);       //Update Tone Counts
        //            tone = wl.LeastUsedTone(giTemp);            //get least used tone
        //            tone.TeachingOrder = giTemp.ToneCount();
        //            num = this.GI.FindToneIndex(tone.Symbol);
        //            this.GI.UpdTone(num, tone);
        //            num = giTemp.FindToneIndex(tone.Symbol);

        //            strText = tone.Symbol + Environment.NewLine + strText;
        //            strText = tone.TeachingOrder.ToString().PadLeft(3) + " - " + strText;
        //            giTemp.DelTone(num);
        //            wl.UnAvailWordsWithTone(tone);
        //            ndx++;
        //        }
        //        //Tones
        //        strMsg = m_Settings.LocalizationTable.GetMessage("TeachingOrderTDSearch6",
        //            m_Settings.OptionSettings.UILanguage);
        //        strRslt += strMsg + Environment.NewLine + Environment.NewLine + strText;
        //        strRslt += Environment.NewLine;
        //        fpb.Close();
        //    }

        //    // Processing teaching order for syllabaries
        //    strText = "";
        //    if (this.IncludeSyllograph)
        //    {
        //        // Initialize wordlist so all words are available.
        //        fpb = new FormProgressBar(m_Settings.LocalizationTable.GetMessage("TeachingOrderTDSearch1",
        //           m_Settings.OptionSettings.UILanguage));
        //        fpb.PB_Init(0, wl.WordCount());
        //        for (int i = 0; i < wl.WordCount(); i++)
        //        {
        //            fpb.PB_Update(i);
        //            wrd = wl.GetWord(i);
        //            wrd.Available = true;
        //        }
        //        fpb.Close();

        //        //Process syllograph order
        //        fpb = new FormProgressBar(m_Settings.LocalizationTable.GetMessage("TeachingOrderTDSearch2",
        //           m_Settings.OptionSettings.UILanguage));
        //        fpb.PB_Init(0, giTemp.SyllographCount());
        //        int ndx = 0;
        //        while (giTemp.SyllographCount() > 0)
        //        {
        //            fpb.PB_Update(ndx);
        //            giTemp = wl.UpdateSyllographCounts(giTemp);             //Update Syllograph Counts
        //            syllograph = wl.LeastUsedSyllograph(giTemp);             //get least used syllograph
        //            syllograph.TeachingOrder = giTemp.SyllographCount();
        //            num = this.GI.FindSyllographIndex(syllograph.Symbol);
        //            this.GI.UpdSyllograph(num, syllograph);
        //            num = giTemp.FindSyllographIndex(syllograph.Symbol);

        //            strText = syllograph.Symbol + Environment.NewLine + strText;
        //            strText = syllograph.TeachingOrder.ToString().PadLeft(3) + " - " + strText;
        //            giTemp.DelSyllograph(num);
        //            wl.UnAvailWordsWithSyllograph(syllograph);
        //            ndx++;
        //        }
        //        //Syllographs
        //        strMsg = m_Settings.LocalizationTable.GetMessage("TeachingOrderTDSearch7",
        //            m_Settings.OptionSettings.UILanguage);
        //        strRslt += strMsg + Environment.NewLine + Environment.NewLine + strText;
        //        strRslt += Environment.NewLine;
        //        fpb.Close();
        //    }

        //    //strRslt += Environment.NewLine;
        //    //strRslt += "Processed " + wl.WordCount().ToString() + " words from Text Data";
        //    strRslt += wl.WordCount().ToString() + Constants.Space +
        //        m_Settings.LocalizationTable.GetMessage("TeachingOrderTDSearch3",
        //        m_Settings.OptionSettings.UILanguage);
        //    this.SearchResults = strRslt;
        //    return this;
        //}

     }
}

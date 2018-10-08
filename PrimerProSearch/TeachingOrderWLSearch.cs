using System;
using System.Collections;
using System.Windows.Forms;
using PrimerProForms;
using PrimerProObjects;
using GenLib;

namespace PrimerProSearch
{
	/// <summary>
	/// 
	/// </summary>
	public class TeachingOrderWLSearch : Search
	{
        // Search parameters
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
        private const string kIncludeT = "includetonet";
        private const string kIncludeS = "includesyllograph";
        private const string kSyllType = "syllographtype";
        private const string kIgnoreTone = "ignoretone";
                
        //private const string kTitle = "Teaching Order for Word List";
        //private const string kInitOrder = "Initializing Consonant Teaching Order";
        //private const string kSearch = "Processing Consonant Teaching Order";
		
		public TeachingOrderWLSearch(int number, Settings s)
			: base(number, SearchDefinition.kOrderWL)
		{
            m_Settings = s;
            m_Title = m_Settings.LocalizationTable.GetMessage("TeachingOrderWLSearchT");
            if (m_Title == "")
                m_Title = "Teaching Order from Word List";
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
            FormTeachingOrder form = new FormTeachingOrder(m_Settings.LocalizationTable);
            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.IncludeConsonant = form.IncludeConsonant;
                this.IncludeVowel = form.IncludeVowel;
                this.IncludeTone = form.IncludeTone;
                this.IncludeSyllograph = form.IncludeSyllograph;
                this.SType = form.SType;
                this.IgnoreTone = form.IgnoreTone;

                SearchDefinition sd = new SearchDefinition(SearchDefinition.kOrderWL);
                SearchDefinitionParm sdp = null;
                if (this.IncludeConsonant)
                {
                    sdp = new SearchDefinitionParm(TeachingOrderWLSearch.kIncludeC);
                    sd.AddSearchParm(sdp);
                }
                if (this.IncludeVowel)
                {
                    sdp = new SearchDefinitionParm(TeachingOrderWLSearch.kIncludeV);
                    sd.AddSearchParm(sdp);
                }
                if (this.IncludeTone)
                {
                    sdp = new SearchDefinitionParm(TeachingOrderWLSearch.kIncludeT);
                    sd.AddSearchParm(sdp);
                }
                if (this.IncludeSyllograph)
                {
                    sdp = new SearchDefinitionParm(TeachingOrderWLSearch.kIncludeS);
                    sd.AddSearchParm(sdp);
                    sdp = new SearchDefinitionParm(TeachingOrderWLSearch.kSyllType, this.SType.ToString());
                    sd.AddSearchParm(sdp);
                }
                if (this.IgnoreTone)
                {
                    sdp = new SearchDefinitionParm(TeachingOrderWLSearch.kIgnoreTone);
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
                if (strTag == TeachingOrderWLSearch.kIncludeC)
                {
                    this.IncludeConsonant = true;
                    flag = true;
                }
                if (strTag == TeachingOrderWLSearch.kIncludeV)
                {
                    this.IncludeVowel = true;
                    flag = true;
                }
                if (strTag == TeachingOrderWLSearch.kIncludeT)
                {
                    this.IncludeTone = true;
                    flag = true;
                }
                if (strTag == TeachingOrderWLSearch.kIncludeS)
                {
                    this.IncludeSyllograph = true;
                    flag = true;
                }
                if (strTag == TeachingOrderWLSearch.kSyllType)
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
                    if (strTag == TeachingOrderWLSearch.kIgnoreTone)
                    {
                        this.IgnoreTone = true;
                        flag = true;
                    }
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

        public TeachingOrderWLSearch ExecuteOrderSearch(WordList wl)
        {
            GraphemeInventory giTemp = new GraphemeInventory(m_Settings);    //Temporary Inventory
            string strRslt = "";
            
            if (this.IncludeConsonant)
                strRslt += ProcessConsonants(wl);        //Processing teaching order for consonants

            if (this.IncludeVowel)
                strRslt += ProcessVowels(wl);            //Processing teaching order for vowels
                
            if (this.IncludeTone)
                strRslt += ProcessTones(wl);
            
            if (this.IncludeSyllograph)
            {
                if (this.SType == SyllographFeatures.SyllographType.None)
                    strRslt += ProcessSyllographs(wl);   //Process teaching order for syllographs
                else strRslt += ProcessSyllographFeatures(wl, this.SType);
            }

            //Indicate number of words being processed
            string strText = m_Settings.LocalizationTable.GetMessage("TeachingOrderWLSearch3");
            if (strText == "")
                strText = "words processed from text data";
            strRslt += wl.WordCount().ToString() + Constants.Space + strText;
            this.SearchResults = strRslt;
            return this;
        }

        private string ProcessConsonants(WordList wl)
        //Process teaching order for consonants
        {
            GraphemeInventory giTemp = new GraphemeInventory(m_Settings);    //Temporary Inventory 
            string strRslt = "";
            string strText = "";
            string strMsg = "";
            Word wrd = null;
            Consonant cns = null;
            FormProgressBar form = null;                
                
            // Get consoansts in inventory
            for (int i = 0; i < this.GI.ConsonantCount(); i++)
            {
                cns = this.GI.GetConsonant(i);
                giTemp.AddConsonant(cns);
            }

            // Reset all words in word list to be initially available
            strMsg = m_Settings.LocalizationTable.GetMessage("TeachingOrderWLSearch1");
            if (strMsg == "")
                strMsg = "Initializing teaching order";
            form = new FormProgressBar(strMsg);
            form.PB_Init(0, wl.WordCount());
            for (int i = 0; i < wl.WordCount(); i++)
            {
                form.PB_Update(i);
                wrd = wl.GetWord(i);
                wrd.Available = true;
            }
            form.Close();
                
            //Process Consonant order
            int ndx = 0;
            int num = 0;
            strMsg = m_Settings.LocalizationTable.GetMessage("TeachingOrderWLSearch2");
            if (strMsg == "")
                strMsg = "Processing teaching order";
            form = new FormProgressBar(strMsg);
            form.PB_Init(0, giTemp.ConsonantCount());
            while (giTemp.ConsonantCount() > 0)
            {
                form.PB_Update(ndx);
                giTemp = wl.UpdateConsonantCounts(giTemp, this.IgnoreTone);      //Update Consonant Counts
                cns = wl.LeastUsedConsonant(giTemp);            //Get least used consonant
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
            //Consonants teaching order
            strMsg = m_Settings.LocalizationTable.GetMessage("TeachingOrderWLSearch4");
            if (strMsg == "")
                strMsg = "Consonants";
            strRslt += strMsg + Environment.NewLine + Environment.NewLine + strText;
            strRslt += Environment.NewLine;
            form.Close();
            return strRslt;
        }

        private string ProcessVowels(WordList wl)
        //Process tewaching order for vowels
        {
            GraphemeInventory giTemp = new GraphemeInventory(m_Settings);    //Temporary Inventory 
            string strRslt = "";
            string strText = "";
            string strMsg = "";
            Word wrd = null;
            Vowel vwl = null;
            FormProgressBar form = null;

            // Get vowels in inventory
            for (int i = 0; i < this.GI.VowelCount(); i++)
            {
                vwl = this.GI.GetVowel(i);
                giTemp.AddVowel(vwl);
            }

            // Reset all words in word list to be initially available
            strMsg = m_Settings.LocalizationTable.GetMessage("TeachingOrderWLSearch1");
            if (strMsg == "")
                strMsg = "Initializing teaching order";
            form = new FormProgressBar(strMsg);
            form.PB_Init(0, wl.WordCount());
            for (int i = 0; i < wl.WordCount(); i++)
            {
                form.PB_Update(i);
                wrd = wl.GetWord(i);
                wrd.Available = true;
            }
            form.Close();

            //Processing vowel order
            strMsg = m_Settings.LocalizationTable.GetMessage("TeachingOrderWLSearch2");
            if (strMsg == "")
                strMsg = "Processing teaching order";
            form = new FormProgressBar(strMsg);
            form.PB_Init(0, giTemp.VowelCount());
            int ndx = 0;
            int num = 0;
            while (giTemp.VowelCount() > 0)
            {
                form.PB_Update(ndx);
                giTemp = wl.UpdateVowelCounts(giTemp, this.IgnoreTone);      //Update Vowel Counts
                vwl = wl.LeastUsedVowel(giTemp);            //Get least used vowel
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

            // vowels Teaching order
            strMsg = m_Settings.LocalizationTable.GetMessage("TeachingOrderWLSearch5");
            if (strMsg == "")
                strMsg = "Vowels";
            strRslt += strMsg + Environment.NewLine + Environment.NewLine + strText;
            strRslt += Environment.NewLine;
            form.Close();
            return strRslt;
        }

        private string ProcessTones(WordList wl)
        //Process teaching order for tones
        {
            GraphemeInventory giTemp = new GraphemeInventory(m_Settings);    //Temporary Inventory 
            string strRslt = "";
            string strText = "";
            string strMsg = "";
            Word wrd = null;
            Tone tone = null;;
            FormProgressBar form = null;                
            
            //Get tones in inventory
            for (int i = 0; i < this.GI.ToneCount(); i++)
            {
                tone = this.GI.GetTone(i);
                giTemp.AddTone(tone);
            }

            // Reset all words in word list to be initially available
            strMsg = m_Settings.LocalizationTable.GetMessage("TeachingOrderWLSearch1");
            if (strMsg == "")
                strMsg = "Initializing teaching order";
            form = new FormProgressBar(strMsg);
            form.PB_Init(0, wl.WordCount());
            for (int i = 0; i < wl.WordCount(); i++)
            {
                form.PB_Update(i);
                wrd = wl.GetWord(i);
                wrd.Available = true;
            }
            form.Close();

            //Processing tone order
            int ndx = 0;
            int num = 0;
            strMsg = m_Settings.LocalizationTable.GetMessage("TeachingOrderWLSearch2");
            if (strMsg == "")
                strMsg = "Processing teaching order";
            form = new FormProgressBar(strMsg);
            form.PB_Init(0, giTemp.ToneCount());
            while (giTemp.ToneCount() > 0)
            {
                form.PB_Update(ndx);
                giTemp = wl.UpdateToneCounts(giTemp);       //Update Tone Counts
                tone = wl.LeastUsedTone(giTemp);            //Get least used tone
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

            //Tones  teaching order
            strMsg = m_Settings.LocalizationTable.GetMessage("TeachingOrderWLSearch6");
            if (strMsg == "")
                strMsg = "Tones";
            strRslt += strMsg + Environment.NewLine + Environment.NewLine + strText;
            strRslt += Environment.NewLine;
            form.Close();
            return strRslt;
        }
 
        private string ProcessSyllographs(WordList wl)
        //Process teaching order for syllographs
        {
            GraphemeInventory giTemp = new GraphemeInventory(m_Settings);    //Temporary Inventory 
            string strRslt = "";
            string strText = "";
            string strMsg = "";
            Word wrd = null;
            Syllograph syllograph = null;
            FormProgressBar form = null;

            // Get syllographs in inventory
            for (int i = 0; i < this.GI.SyllographCount(); i++)
            {
                syllograph = this.GI.GetSyllograph(i);
                giTemp.AddSyllograph(syllograph);
            }

            // Reset all words in word list to be initially available
            strMsg = m_Settings.LocalizationTable.GetMessage("TeachingOrderWLSearch1");
            if (strMsg == "")
                strMsg = "Initializing teaching order";
            form = new FormProgressBar(strMsg);
            form.PB_Init(0, wl.WordCount());
            for (int i = 0; i < wl.WordCount(); i++)
            {
                form.PB_Update(i);
                wrd = wl.GetWord(i);
                wrd.Available = true;
            }
            form.Close();

            // Process syllograph order
            int ndx = 0;
            int num = 0;
            strMsg = m_Settings.LocalizationTable.GetMessage("TeachingOrderWLSearch2");
            if (strMsg == "")
                strMsg = "Processing teaching order";
            form = new FormProgressBar(strMsg);
            form.PB_Init(0, giTemp.SyllographCount());
            while (giTemp.SyllographCount() > 0)
            {
                form.PB_Update(ndx);
                giTemp = wl.UpdateSyllographCounts(giTemp);         //Update syllabaries counts
                syllograph = wl.LeastUsedSyllograph(giTemp);        //Get least used syllograph
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
            // Syllograph teaching order
            strMsg = m_Settings.LocalizationTable.GetMessage("TeachingOrderWLSearch7");
            if (strMsg == "")
                strMsg = "Syllographs";
            strRslt += strMsg + Environment.NewLine + Environment.NewLine + strText;
            strRslt += Environment.NewLine;
            form.Close();
            return strRslt;
        }

        private string ProcessSyllographFeatures(WordList wl, SyllographFeatures.SyllographType typ)
        //Process teaching order based upon syllograph type
        {
            SortedList slFeatures= new SortedList();
            SyllographFeatureInfo info = null;
            string strRslt = "";
            string strText = "";
            string strMsg = "";
            Word wrd = null;
            Syllograph syllograph = null;
            FormProgressBar form = null;

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

            // Reset all words in word list to be initially available
            strMsg = m_Settings.LocalizationTable.GetMessage("TeachingOrderWLSearch1");
            if (strMsg == "")
                strMsg = "Initializing teaching order";
            form = new FormProgressBar(strMsg);
            form.PB_Init(0, wl.WordCount());
            for (int i = 0; i < wl.WordCount(); i++)
            {
                form.PB_Update(i);
                wrd = wl.GetWord(i);
                wrd.Available = true;
            }
            form.Close();

            //Process syllograph feature order
            int ndx = 0;
            int num = 0;
            strMsg = m_Settings.LocalizationTable.GetMessage("TeachingOrderWLSearch2");
            if (strMsg == "")
                strMsg = "Processing teaching order";
            form = new FormProgressBar(strMsg);
            form.PB_Init(0,slFeatures.Count);
            while (num < slFeatures.Count )
            {
                form.PB_Update(ndx);
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
            // Syllograph  teaching order (features)
            strMsg = m_Settings.LocalizationTable.GetMessage("TeachingOrderWLSearch7");
            if (strMsg == "")
                strMsg = "Syllographs";
            strRslt += strMsg + Environment.NewLine + Environment.NewLine + strText;
            strRslt += Environment.NewLine;
            form.Close();
             return strRslt;
        }
    }
}

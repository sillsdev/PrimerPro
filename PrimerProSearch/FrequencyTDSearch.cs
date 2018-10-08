using System;
using System.Windows.Forms;
using PrimerProForms;
using PrimerProObjects;

namespace PrimerProSearch
{
    /// <summary>
    /// Frequenncy Search in Text Data
    /// </summary>
    public class FrequencyTDSearch : Search
    {
        //Search parameters
        private bool m_IgnoreSightWords;        //Ignore Sight Words;
        private bool m_IgnoreTone;              //Ignore Tone Marks
        private bool m_DisplayPercentages;

        private string m_Title;                 //Search title
        private Settings m_Settings;            //Application Settings
        private GraphemeInventory m_GI;         //Grapheme inventory
 
        //Search Definition tags
        private const string kIgnoreSightWords = "IgnoreSightWords";
        private const string kIgnoreTone = "IgnoreTone";
        private const string kDisplayPercentsges = "DisplayPercentages";

        //private const string kTitle = "Frequency Count in TextData";

        public FrequencyTDSearch(int number, Settings s) : base(number, SearchDefinition.kFrequencyTD)
        {
            m_Settings = s;
            m_IgnoreSightWords = false;
            m_IgnoreTone = false;
            m_DisplayPercentages = false;
            m_Title = m_Settings.LocalizationTable.GetMessage("FrequencyTDSearchT");
            if (m_Title == "")
                m_Title = "Frequency Count from Text Data"; 
            m_GI = m_Settings.GraphemeInventory;
        }
        
        public bool IgnoreSightWords
        {
            get { return m_IgnoreSightWords; }
            set { m_IgnoreSightWords = value; }
        }

        public bool IgnoreTone
        {
            get { return m_IgnoreTone; }
            set { m_IgnoreTone = value; }
        }

        public bool DisplayPercentages
        {
            get { return m_DisplayPercentages; }
            set { m_DisplayPercentages = value;}
        }

        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        public GraphemeInventory GI
        {
            get { return m_GI; }
        }

        public bool SetupSearch()
        {
            bool flag = false;
            //FormFrequencyTD fpb = new FormFrequencyTD();
            FormFrequencyTD form = new FormFrequencyTD(m_Settings.LocalizationTable);
            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.IgnoreSightWords = form.IgnoreSightWords;
                this.IgnoreTone = form.IgnoreTone;
                this.DisplayPercentages = form.DisplayPercentages;
                SearchDefinition sd = new SearchDefinition(SearchDefinition.kFrequencyTD);
                SearchDefinitionParm sdp = null;
                this.SearchDefinition = sd;

                if (this.IgnoreSightWords)
                {
                    sdp = new SearchDefinitionParm(FrequencyTDSearch.kIgnoreSightWords);
                    sd.AddSearchParm(sdp);
                }
                if ( this.IgnoreTone)
                {
                    sdp = new SearchDefinitionParm(FrequencyTDSearch.kIgnoreTone);
                    sd.AddSearchParm(sdp);
                }
                if (this.DisplayPercentages)
                {
                    sdp = new SearchDefinitionParm(FrequencyTDSearch.kDisplayPercentsges);
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
            this.SearchDefinition = sd;

            for (int i = 0; i < sd.SearchParmsCount(); i++)
            {
                strTag = sd.GetSearchParmAt(i).GetTag();
                if (strTag == FrequencyTDSearch.kIgnoreSightWords)
                    this.IgnoreSightWords = true;
                if (strTag == FrequencyTDSearch.kIgnoreTone)
                    this.IgnoreTone = true;
                if (strTag == FrequencyTDSearch.kDisplayPercentsges)
                    this.DisplayPercentages = true;
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

        public FrequencyTDSearch ExecuteFrequencySearch(TextData td)
        {
            string strText = "";
            string str = "";
            // Update Grapheme counts 
            m_GI = td.UpdateGraphemeCounts(this.GI, this.IgnoreSightWords, this.IgnoreTone);

            //strText += "Consonants" + Environment.NewLine;
            str = m_Settings.LocalizationTable.GetMessage("FrequencyTDSearch1");
            if (str == "")
                str = "Consonants";
            strText += str + Environment.NewLine;
            if (this.DisplayPercentages)
                strText += this.GI.SortedConsonantPercentagesInTextData();
            else strText += this.GI.SortedConsonantCountsInTextData();
            strText += Environment.NewLine;
           
            //strText += "Vowels" + Environment.NewLine;
            str = m_Settings.LocalizationTable.GetMessage("FrequencyTDSearch2");
            if (str == "")
                str = "Vowels";
            strText += str + Environment.NewLine;
            if (this.DisplayPercentages)
                strText += this.GI.SortedVowelPercentagesInTextData();
            else strText += this.GI.SortedVowelCountsInTextData();
            strText += Environment.NewLine;

            //strText += "Tones" + Environment.NewLine;
            if (!this.IgnoreTone)
            {
                str = m_Settings.LocalizationTable.GetMessage("FrequencyTDSearch3");
                if (str == "")
                    str = "Tones";
                strText += str + Environment.NewLine;
                if (this.DisplayPercentages)
                    strText += this.GI.SortedTonePercentagesInTextData();
                else strText += this.GI.SortedToneCountsInTextData();
                strText += Environment.NewLine;
            }

            //strText += "Sylographs" + Environment.NewLine;
            str = m_Settings.LocalizationTable.GetMessage("FrequencyTDSearch4");
            if (str == "")
                str = "Sylographs";
            strText += str + Environment.NewLine;
            if (this.DisplayPercentages)
                strText += this.GI.SortedSyllographlPercentagesInTextData();
            else strText += this.GI.SortedSyllographCountsInTextData();

            this.SearchResults = strText;
            return this;
        }

    }
}

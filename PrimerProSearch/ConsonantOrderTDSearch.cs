using System;
using PrimerProObjects;
using GenLib;

namespace PrimerProSearch
{
    public class ConsonantOrderTDSearch : Search
    {
        //Search parameters - None
 
        private string m_Title;
        private Settings m_Settings;
        private GraphemeInventory m_GI;

        //private const string kTitle = "Consonant Teaching Order from Text Data";
        //private const string kInitOrder = "Initializing Consonant Teaching Order";
        //private const string kProcessOrder = "Processing Consonant Teaching Order";
        
        public ConsonantOrderTDSearch(int number, Settings s)
			: base(number, SearchDefinition.kOrderTD)
		{
            m_Settings = s;
            //m_Title = ConsonantOrderTDSearch.kTitle;
            m_Title = m_Settings.LocalizationTable.GetMessage("ConsonantOrderTDSearchT",
                m_Settings.OptionSettings.UILanguage);
            m_GI = m_Settings.GraphemeInventory;
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
            SearchDefinition sd = new SearchDefinition(SearchDefinition.kOrderTD);
            flag = true;
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

        public ConsonantOrderTDSearch ExecuteOrderSearch(TextData td)
        {
            GraphemeInventory giCns = new GraphemeInventory(m_Settings);    //Consonants Inventory (temporary)
            WordList wl = null;
            Consonant cns = null;
            int num = 0;
            Word wrd = null;
            string strRslt = "";

            // Initialize Consonants Inventory
            for (int i = 0; i < this.GI.ConsonantCount(); i++)
            {
                cns = this.GI.GetConsonant(i);
                giCns.AddConsonant(cns);
            }

            // Build a wordlist from the textdata
            wl = td.BuildWordList();

            
            // Initialize wordlist so all words are available.
            FormProgressBar form = null;
            //form = new FormProgressBar(ConsonantOrderTDSearch.kInitOrder);
            form = new FormProgressBar(m_Settings.LocalizationTable.GetMessage("ConsonantOrderTDSearch1",
               m_Settings.OptionSettings.UILanguage));
            form.PB_Init(0, wl.WordCount());
            for (int i = 0; i < wl.WordCount(); i++)
            {
                form.PB_Update(i);
                wrd = wl.GetWord(i);
                wrd.Available = true;
            }
            form.Close();

            //form = new FormProgressBar(ConsonantOrderTDSearch.kProcessOrder);
            form = new FormProgressBar(m_Settings.LocalizationTable.GetMessage("ConsonantOrderTDSearch2",
               m_Settings.OptionSettings.UILanguage));
            form.PB_Init(0, giCns.ConsonantCount());
            int ndx = 0;

            while (giCns.ConsonantCount() > 0)
            {
                form.PB_Update(ndx);
                giCns = wl.UpdateGraphemeCounts(giCns);  //Update Grapheme Counts
                cns = wl.LeastUsedConsonant(giCns);      //get least used consonant
                cns.TeachingOrder = giCns.ConsonantCount();
                num = this.GI.FindConsonantIndex(cns.Symbol);
                this.GI.UpdConsonant(num, cns);
                num = giCns.FindConsonantIndex(cns.Symbol);

                strRslt = cns.Symbol + Environment.NewLine + strRslt;
                strRslt = cns.TeachingOrder.ToString().PadLeft(3) + " - " + strRslt;
                giCns.DelConsonant(num);
                wl.UnAvailWordsWithConsonant(cns);
                ndx++;
            }
            strRslt += Environment.NewLine;
            //strRslt += "Processed " + wl.WordCount().ToString() + " words from Text Data";
            strRslt += wl.WordCount().ToString() + Constants.Space +
                m_Settings.LocalizationTable.GetMessage("ConsonantOrderTDSearch3",
                m_Settings.OptionSettings.UILanguage);
            this.SearchResults = strRslt;
            form.Close();
            return this;
        }

     }
}

using System;
using PrimerProObjects;
using GenLib;

namespace PrimerProSearch
{
	/// <summary>
	/// 
	/// </summary>
	public class ConsonantOrderWLSearch : Search
	{
        // Search parameters - none

		private string m_Title;
        private Settings m_Settings;
		private GraphemeInventory m_GI;

        //private const string kTitle = "Consonant Teaching Order for Word List";
        //private const string kInitOrder = "Initializing Consonant Teaching Order";
        //private const string kSearch = "Processing Consonant Teaching Order";
		
		public ConsonantOrderWLSearch(int number, Settings s)
			: base(number, SearchDefinition.kOrderWL)
		{
            m_Settings = s;
            //m_Title = ConsonantOrderWLSearch.kTitle;
            m_Title = m_Settings.LocalizationTable.GetMessage("ConsonantOrderWLSearchT",
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
            SearchDefinition sd = new SearchDefinition(SearchDefinition.kOrderWL);
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

        public ConsonantOrderWLSearch ExecuteOrderSearch(WordList wl)
        {
            GraphemeInventory giCns = new GraphemeInventory(m_Settings);    //Consonants Inventory (temporary)
            Consonant cns = null;
            int num = 0;
            Word wrd = null;
            string strRslt = "";
            FormProgressBar form = null;

            //Initialize Consonants Inventory
            //form = new FormProgressBar(ConsonantOrderWLSearch.kInitOrder);
            form = new FormProgressBar(m_Settings.LocalizationTable.GetMessage("ConsonantOrderWLSearch1",
               m_Settings.OptionSettings.UILanguage));
            form.PB_Init(0, wl.WordCount());
            for (int i = 0; i < this.GI.ConsonantCount(); i++)
            {
                cns = this.GI.GetConsonant(i);
                giCns.AddConsonant(cns);
            }

            // Reset all words in word list to be initially available
            for (int i = 0; i < wl.WordCount(); i++)
            {
                form.PB_Update(i);
                wrd = wl.GetWord(i);
                wrd.Available = true;
            }
            form.Close();

            //form = new FormProgressBar(ConsonantOrderWLSearch.kSearch);
            form = new FormProgressBar(m_Settings.LocalizationTable.GetMessage("ConsonantOrderWLSearch2",
               m_Settings.OptionSettings.UILanguage));
            int ndx = 0;

            while (giCns.ConsonantCount() > 0)
            {
                form.PB_Update(ndx);
                giCns = wl.UpdateGraphemeCounts(giCns);     //Update Grapheme Counts
                cns = wl.LeastUsedConsonant(giCns);         //get least used consonant
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
            //strRslt += "Processed " + wl.WordCount().ToString() + " words from Word List";
            strRslt += wl.WordCount().ToString() + Constants.Space +
                m_Settings.LocalizationTable.GetMessage("ConsonantOrderWLSearch3",
                m_Settings.OptionSettings.UILanguage);
            this.SearchResults = strRslt;
            form.Close();
            return this;
        }

    }
}

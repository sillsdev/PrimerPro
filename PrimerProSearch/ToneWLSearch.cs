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
	/// Tone search for Word List
	/// </summary>
	public class ToneWLSearch : Search
	{
        //Search parameters 
        private ArrayList m_SelectedTones;      // tones to be searched
		private SearchOptions m_SearchOptions;  // search option filter
		
        private string m_Title;		            //search title;
        private Settings m_Settings;            //Application Settings
        private PSTable m_PSTable;	            //Parts of Speech
        private GraphemeInventory m_GI;	        //Grapheme Inventory
        private Font m_DefaultFont;             //Default Font   

		//Search definition tags
        private const string kTone = "tone";

        //private const string kTitle = "Tone Search";

		public ToneWLSearch(int number, Settings s)
			: base(number, SearchDefinition.kToneWL)
		{
            //m_Tone = "";
            m_SelectedTones = new ArrayList();
			m_SearchOptions = null;

            m_Settings = s;
            m_Title = m_Settings.LocalizationTable.GetMessage("ToneWLSearchT",
                m_Settings.OptionSettings.UILanguage);
            m_PSTable = m_Settings.PSTable;
			m_GI = m_Settings.GraphemeInventory;
            m_DefaultFont = m_Settings.OptionSettings.GetDefaultFont();
		}

        public ArrayList SelectedTones
        {
            get {return m_SelectedTones;}
            set { m_SelectedTones = value; }
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
            //FormToneWL fpb = new FormToneWL(this.GI, this.PSTable, this.DefaultFont);
            FormToneWL form = new FormToneWL(m_GI, m_PSTable, m_DefaultFont,
                m_Settings.LocalizationTable, m_Settings.OptionSettings.UILanguage);
			DialogResult dr = form.ShowDialog();
			if (dr == DialogResult.OK)
			{
                this.SelectedTones = form.SelectedTones;
                this.SearchOptions = form.SearchOptions;

				SearchDefinition sd = new SearchDefinition(SearchDefinition.kToneWL);
                SearchDefinitionParm sdp = null;

                String strTone = "";
                if (form.SelectedTones != null)
                {
                    if (form.SelectedTones.Count > 0)
                    {
                        for (int i = 0; i < form.SelectedTones.Count; i++)
                        {
                            strTone = form.SelectedTones[i].ToString();
                            sdp = new SearchDefinitionParm(ToneWLSearch.kTone, strTone);
                            sd.AddSearchParm(sdp);
                        }
                        if (form.SearchOptions != null)
                            sd.AddSearchOptions(form.SearchOptions);
                        this.SearchDefinition = sd;
                        flag = true;
                    }
                    //else MessageBox.Show("No tone was selected");
                    else
                    {
                        string strMsg = m_Settings.LocalizationTable.GetMessage("ToneWLSearch2",
                            m_Settings.OptionSettings.UILanguage);
                        MessageBox.Show(strMsg);
                    }
                }
                //else MessageBox.Show("No tone was selected");
                else
                {
                    string strMsg = m_Settings.LocalizationTable.GetMessage("ToneWLSearch2",
                        m_Settings.OptionSettings.UILanguage);
                    MessageBox.Show(strMsg);
                }
            }
			return flag;
		}

		public bool SetupSearch(SearchDefinition sd)
		{
			bool flag = false;
			SearchOptions so = new SearchOptions(m_PSTable);
            string strTag = "";
            string strContent = "";

            for (int i = 0; i < sd.SearchParmsCount(); i++)
            {
                strTag = sd.GetSearchParmAt(i).GetTag();
                strContent = sd.GetSearchParmAt(i).GetContent();
                if (strTag == ToneWLSearch.kTone)
                {
                    this.SelectedTones.Add(strContent);
                    flag = true;
                }
            }
            this.SearchOptions = sd.MakeSearchOptions(so);
            this.SearchDefinition = sd;
            return flag;
		}

		public string BuildResults()
		{
			string strText = "";
			string strSN = Search.TagSN + this.SearchNumber.ToString().Trim();
			strText += Search.TagOpener + strSN	+ Search.TagCloser + Environment.NewLine;
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

        public ToneWLSearch ExecuteToneSearch(WordList wl)
        {
            ArrayList alTones = this.SelectedTones;
            int nCount = 0;
            string strResult = wl.GetDisplayHeadings() + Environment.NewLine;

            Word wrd = null;
            int nWord = wl.WordCount();
            Grapheme grf = null;
            for (int i = 0; i < nWord; i++)
            {
                wrd = wl.GetWord(i);

                if (this.SearchOptions == null)
                {
                    bool found = false;
                    if (alTones.Count > 0)
                    {
                        for (int n = 0; n < wrd.GraphemeCount(); n++)
                        {
                            grf = wrd.GetGrapheme(n);
                            int ndx = 0;
                            do
                            {
                                if (grf.Symbol == alTones[ndx].ToString())
                                    found = true;
                                ndx++;
                            }
                            while ( (!found) && (ndx < this.SelectedTones.Count));
                            if (found)
                                break;
                        }
                    }

                    if (found)
                    {
                        nCount++;
                        strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
                    }
                }
                else
                {
                    if (this.SearchOptions.MatchesWord(wrd))
                    {
                        if (this.SearchOptions.IsRootOnly)
                        {
                            bool found = false;
                            string strTone = "";
                            int ndx = 0;
                            do
                            {
                                if (this.SelectedTones.Count > 0)
                                {
                                    strTone = this.SelectedTones[ndx].ToString();
                                    if (wrd.Root.DisplayRoot.IndexOf(strTone) >= 0)
                                    {
                                        if (this.SearchOptions.MatchesPosition(wrd, strTone))
                                            found = true;
                                    }
                                    ndx++;
                                }
                            }
                            while ((!found) && (ndx < this.SelectedTones.Count));

                            if (found)
                            {
                                nCount++;
                                strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
                            }
                        }
                        else
                        {
                            bool found = false;
                            string strTone = "";
                            int ndx = 0;
                            do
                            {
                                if (this.SelectedTones.Count > 0)
                                {
                                    strTone = this.SelectedTones[ndx].ToString();
                                    if (wrd.DisplayWord.IndexOf(strTone) >= 0)
                                    {
                                        if (this.SearchOptions.MatchesPosition(wrd, strTone))
                                            found = true;
                                    }
                                    ndx++;
                                }
                            }
                            while ((!found) && (ndx < this.SelectedTones.Count));

                            if (found)
                            {
                                nCount++;
                                strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
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
                //this.SearchResults = "***No Results***";
                this.SearchResults = m_Settings.LocalizationTable.GetMessage("Search1",
                    m_Settings.OptionSettings.UILanguage);
                this.SearchCount = 0;
            }
            return this;
        }

    }
}

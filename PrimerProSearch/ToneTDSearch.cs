using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using PrimerProForms;
using PrimerProObjects;
using GenLib;

namespace PrimerProSearch
{
	/// <summary>
	/// Tone Search for Text Data
	/// </summary>
	public class ToneTDSearch : Search
	{
        //Search parameters 
        private string m_Tone;		        //syllograph to be searched
        private ArrayList m_SelectedTones;  //tones to be searched
		private bool m_ParaFormat;	        //How to display the results
		
        private string m_Title;		        //search title;
        private Settings m_Settings;        //Application Settings
        private PSTable m_PSTable;	        //Parts of Speech
        private GraphemeInventory m_GI;	    //Grapheme Inventory
        private bool m_ViewParaSentWord;    //Flag for viewing ParaSentWord number
        private Font m_DefaultFont;         //Default Font

        //Search definition tags
        private const string kTone = "tone";
		private const string kParaFormat = "paraformat";

        //private const string kTitle = "Tone Search";
        //private const string kSearch = "Processing Tone Search";
        private const string kSeparator = Constants.Tab;

		public ToneTDSearch(int number, Settings s)
			: base(number, SearchDefinition.kToneTD)
		{
			m_Tone = "";
            m_SelectedTones = new ArrayList();
			m_ParaFormat = false;
			
            m_Settings = s;
            //m_Title = kTitle;
            m_Title = m_Settings.LocalizationTable.GetMessage("ToneTDSearchT");
            if (m_Title == "")
                m_Title = "Tone Search";
            m_PSTable = m_Settings.PSTable;
			m_GI = m_Settings.GraphemeInventory;
            m_ViewParaSentWord = m_Settings.OptionSettings.ViewParaSentWord;
            m_DefaultFont = m_Settings.OptionSettings.GetDefaultFont();
		}

		public string Tone
		{
			get {return m_Tone;}
			set {m_Tone = value;}
		}

        public ArrayList SelectedTones
        {
            get { return m_SelectedTones; }
            set { m_SelectedTones = value; }
        }

		public bool ParaFormat
		{
			get {return m_ParaFormat;}
			set {m_ParaFormat = value;}
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

        public bool ViewParaSentWord
        {
            get { return m_ViewParaSentWord; }
        }

        public Font DefaultFont
        {
            get { return m_DefaultFont; }
        }

        public bool SetupSearch()
		{
			bool flag = false;
            //FormToneTD fpb = new FormToneTD(m_GI, m_DefaultFont);
            FormToneTD form = new FormToneTD(m_Settings, m_Settings.LocalizationTable);
			DialogResult dr = form.ShowDialog();
			if (dr == DialogResult.OK)
			{
                this.SelectedTones = form.SelectedTones;
                this.ParaFormat = form.ParaFormat;
                
				SearchDefinition sd = new SearchDefinition(SearchDefinition.kToneTD);
				SearchDefinitionParm sdp = null;
                this.SearchDefinition = sd;

                String strTone = "";
                if (form.SelectedTones.Count > 0)
                {
                    for (int i = 0; i < form.SelectedTones.Count; i++)
                    {
                        strTone = form.SelectedTones[i].ToString();
                        sdp = new SearchDefinitionParm(ToneTDSearch.kTone, strTone);
                        sd.AddSearchParm(sdp);
                    }
                    if (form.ParaFormat)
                    {
                        sdp = new SearchDefinitionParm(ToneTDSearch.kParaFormat);
                        sd.AddSearchParm(sdp);
                    }
                    this.SearchDefinition = sd;
                    flag = true;
                }
                //else MessageBox.Show("No tone was selected");
                else
                {
                    string strMsg = m_Settings.LocalizationTable.GetMessage("ToneTDSearch2");
                    if (strMsg == "")
                        strMsg = "No tone was selected";
                    MessageBox.Show(strMsg);
                }
            }
			return flag;
		}

		public bool SetupSearch(SearchDefinition sd)
		{
			bool flag = false;
			string strTag = "";
            string strContent = "";
			for (int i = 0; i < sd.SearchParmsCount(); i++)
			{
				strTag = sd.GetSearchParmAt(i).GetTag();
                strContent = sd.GetSearchParmAt(i).GetContent();
                if (strTag == ToneTDSearch.kTone)
                {
                    this.SelectedTones.Add(strContent);
                    flag = true;
                }
				if (strTag == ToneTDSearch.kParaFormat)
				{
					this.ParaFormat = true;
				}
			}
			this.SearchDefinition = sd;
			return flag;
		}

		public string BuildResults()
		{
			string strText = "";
            string str = "";
			string strSN = Search.TagSN + this.SearchNumber.ToString().Trim();
			strText += Search.TagOpener + strSN	+ Search.TagCloser + Environment.NewLine;
			strText += this.Title + Environment.NewLine + Environment.NewLine;
			strText += this.SearchResults;
			strText += Environment.NewLine;
            //strText += this.SearchCount.ToString() + " entries found" + Environment.NewLine;
            str = m_Settings.LocalizationTable.GetMessage("Search2");
            if (str == "")
                str = "entries found";
            strText += this.SearchCount.ToString() + Constants.Space + str + Environment.NewLine;
            strText += Search.TagOpener + Search.TagForwardSlash + strSN
				+ Search.TagCloser;
			return strText;
		}

        public ToneTDSearch ExecuteToneSearch(TextData td)
        {
            if (this.ParaFormat)
                ExecuteToneSearchP(td);
            else ExecuteToneSearchL(td);
            return this;
        }

        private ToneTDSearch ExecuteToneSearchP(TextData td)
        {
            Paragraph para = null;
            Sentence sent = null;
            Word wrd = null;
            string strRslt = "";
            string str = "";
            int nCount = 0;
            int nPara = td.ParagraphCount();
            str = m_Settings.LocalizationTable.GetMessage("ToneTDSearch1");
            if (str == "")
                str = "Processing Tone Search";
            FormProgressBar form = new FormProgressBar(str);
            form.PB_Init(0, nPara);

            for (int i = 0; i < nPara; i++)
            {
                form.PB_Update(i);
                para = td.GetParagraph(i);
                for (int j = 0; j < para.SentenceCount(); j++)
                {
                    sent = para.GetSentence(j);
                    for (int k = 0; k < sent.WordCount(); k++)
                    {
                        wrd = sent.GetWord(k);
                        if (wrd != null)
                        {
                            bool found = false;
                            int ndx = 0;
                            if (this.SelectedTones.Count > 0)
                            {
                                do
                                {
                                    if (wrd.DisplayWord.IndexOf(this.SelectedTones[ndx].ToString()) >= 0)
                                        found = true;
                                    ndx++;
                                }
                                while ((!found) && (ndx < this.SelectedTones.Count));
                            }

                            if (found)
                            {
                                strRslt += Constants.kHCOn + wrd.DisplayWord
                                    + Constants.kHCOff + Constants.Space;
                                nCount++;
                            }
                            else strRslt += wrd.DisplayWord + Constants.Space;
                        }
                    }
                    strRslt = strRslt.Substring(0, strRslt.Length - 1);	//get ride of last space
                    strRslt += sent.EndingPunctuation;
                    strRslt += Constants.Space;
                }
                strRslt += Environment.NewLine + Environment.NewLine;
            }
            this.SearchResults = strRslt;
            this.SearchCount = nCount;
            form.Close();
            return this;
        }

        private ToneTDSearch ExecuteToneSearchL(TextData td)
        {
            Paragraph para = null;
            Sentence sent = null;
            Word wrd = null;
            int nCount = 0;
            int nPara = td.ParagraphCount();
            string strRslt = "";
            string str = "";
            int nTmp = 0;
            str = m_Settings.LocalizationTable.GetMessage("ToneTDSearch1");
            if (str == "")
                str = "Processing Tone Search";
            FormProgressBar form = new FormProgressBar(str);
            form.PB_Init(0, nPara);

            for (int i = 0; i < nPara; i++)
            {
                form.PB_Update(i);
                para = td.GetParagraph(i);
                for (int j = 0; j < para.SentenceCount(); j++)
                {
                    sent = para.GetSentence(j);
                    for (int k = 0; k < sent.WordCount(); k++)
                    {
                        wrd = sent.GetWord(k);
                        if (wrd != null)
                        {
                            bool found = false;
                            int ndx = 0;
                            if (this.SelectedTones.Count > 0)
                            {
                                do
                                {
                                    if (wrd.DisplayWord.IndexOf(this.SelectedTones[ndx].ToString()) >= 0)
                                        found = true;
                                    ndx++;
                                }
                                while ((!found) && (ndx < this.SelectedTones.Count));
                            }

                            if (found)
                            {
                                if (this.ViewParaSentWord)
                                {
                                    nTmp = i + 1;
                                    strRslt += TextData.kPara + Search.Colon + nTmp.ToString().PadLeft(4);
                                    strRslt += ToneTDSearch.kSeparator;
                                    nTmp = j + 1;
                                    strRslt += TextData.kSent + Search.Colon + nTmp.ToString().PadLeft(4);
                                    strRslt += ToneTDSearch.kSeparator;
                                    nTmp = k + 1;
                                    strRslt += TextData.kWord + Search.Colon + nTmp.ToString().PadLeft(4);
                                    strRslt += ToneTDSearch.kSeparator;
                                }
                                strRslt += wrd.DisplayWord;
                                strRslt += Environment.NewLine;
                                nCount++;
                            }
                        }
                    }
                }
            }
            this.SearchResults = strRslt;
            this.SearchCount = nCount;
            form.Close();
            return this;
        }

    }
}

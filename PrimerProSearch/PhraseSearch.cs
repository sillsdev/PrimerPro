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
	/// Phrase Search
	/// </summary>
	public class PhraseSearch : Search
	{
        //Search parameters 
        private ArrayList m_Graphemes;		//list of graphemes for useable phrases
		private bool m_ParaFmt;				//how to display results
        private bool m_UseGraphemesTaught;   //Restrict to graphemes taught
        private string m_Highlight;         //words containing this grapheme are highligted
        private int m_Min;                  //minimal numbers of words in a phrase

        private string m_Title;
        private Settings m_Settings;
        private GraphemeInventory m_GI;
        private GraphemeTaughtOrder m_GraphemesTaught;
        private Font m_DefaultFont;
        private bool m_ViewParaSentWord;
        
        //Search Definition tags
        private const string kGrapheme = "grapheme";
		private const string kParaFormat = "paraformat";
        private const string kUseGraphemeTaught = "UseGraphemeTaught";
        private const string kHighlight = "highlight";
        private const string kMin = "minwords";

        //private const string kTitle = "Usable Phrases Search";
        //private const string kSearch = "Processing Usable Phrases Search";
        private const string kSeparator = Constants.Tab;

		public PhraseSearch(int number, Settings s)
            : base(number, SearchDefinition.kPhrases)
		{
            m_Graphemes = null;
			m_ParaFmt =  false;
            m_UseGraphemesTaught = false;
            m_Highlight = "";
            m_Min = 0;
            m_Settings = s;
            m_Title = m_Settings.LocalizationTable.GetMessage("PhraseSearchT",
                m_Settings.OptionSettings.UILanguage);
            m_GI = m_Settings.GraphemeInventory;
            m_GraphemesTaught = m_Settings.GraphemesTaught;
            m_ViewParaSentWord = m_Settings.OptionSettings.ViewParaSentWord;
            m_DefaultFont = m_Settings.OptionSettings.GetDefaultFont();
 		}

        public ArrayList Graphemes
		{
            get { return m_Graphemes; }
            set { m_Graphemes = value; }
		}

        public bool ParaFormat
        {
            get { return m_ParaFmt; }
            set { m_ParaFmt = value; }
        }

        public bool UseGraphemesTaught
        {
            get { return m_UseGraphemesTaught; }
            set { m_UseGraphemesTaught = value; }
        }

        public string Highlight
        {
            get { return m_Highlight; }
            set { m_Highlight = value; }
        }

        public int Min
        {
            get { return m_Min; }
            set { m_Min = value; }
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

        public GraphemeTaughtOrder GraphemesTaught
        {
            get { return m_GraphemesTaught; }
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
            string strMsg = "";
            //FormPhrase fpb = new FormPhrase(this.GraphemesTaught, this.DefaultFont);
            FormPhrase form = new FormPhrase(m_GraphemesTaught, m_DefaultFont,
                m_Settings.LocalizationTable, m_Settings.OptionSettings.UILanguage);
			DialogResult dr = form.ShowDialog();
			if (dr == DialogResult.OK)
			{
                this.Graphemes = form.Graphemes;
                this.ParaFormat = form.ParaFormat;
                this.UseGraphemesTaught = form.UseGraphemesTaught;
                this.Highlight = form.Highlight;
                this.Min = form.Min;

                if (this.Graphemes != null)
				{
                    if ((this.Highlight == "") || (this.GI.IsInInventory(this.Highlight)))
                    {
                        SearchDefinition sd = new SearchDefinition(SearchDefinition.kPhrases);
                        SearchDefinitionParm sdp = null;
                        this.SearchDefinition = sd;
                        string strSym = "";
                        string strSegs = "";

                        for (int i = 0; i < this.Graphemes.Count; i++)
                        {
                            strSym = this.Graphemes[i].ToString();
                            sdp = new SearchDefinitionParm(PhraseSearch.kGrapheme, strSym);
                            sd.AddSearchParm(sdp);
                            strSegs += strSym + Constants.Space;
                        }
                        if (this.ParaFormat)
                        {
                            sdp = new SearchDefinitionParm(PhraseSearch.kParaFormat);
                            sd.AddSearchParm(sdp);
                        }

                        if (this.UseGraphemesTaught)
                        {
                            sdp = new SearchDefinitionParm(PhraseSearch.kUseGraphemeTaught);
                            sd.AddSearchParm(sdp);
                        }
                        sdp = new SearchDefinitionParm(PhraseSearch.kHighlight, this.Highlight);
                        sd.AddSearchParm(sdp);
                        sdp = new SearchDefinitionParm(PhraseSearch.kMin, this.Min.ToString());
                        sd.AddSearchParm(sdp);

                        m_Title = m_Title + " - [" + strSegs.Trim() + "]";
                        this.SearchDefinition = sd;
                        flag = true;
                    }
                    //else MessageBox.Show("Highlight grapheme " + this.Highlight + " is not in inventory");
                    else
                    {
                        strMsg = m_Settings.LocalizationTable.GetMessage("PhraseSearch1",
                            m_Settings.OptionSettings.UILanguage);
                        MessageBox.Show(strMsg + ": " + this.Highlight);
                    }
                }
                //else MessageBox.Show("Must specified at least one grapheme");
                else
                {
                    strMsg = m_Settings.LocalizationTable.GetMessage("PhraseSearch2",
                        m_Settings.OptionSettings.UILanguage);
                    MessageBox.Show(strMsg);
                }
            }
            return flag;
		}

		public bool SetupSearch(SearchDefinition sd)
		{
			bool flag = false;
			SearchDefinitionParm sdp = null;
			string strTag = "";
			string strContent = "";
			string strGrfs = "";

			this.SearchDefinition = sd;
			ArrayList al = new ArrayList();

			for (int i = 0; i < sd.SearchParmsCount(); i++)
			{
				sdp = sd.GetSearchParmAt(i);
				strTag = sdp.GetTag();
				strContent = sdp.GetContent();
				if (strTag == PhraseSearch.kGrapheme)
				{
					al.Add(strContent);
                    strGrfs += strContent + Constants.Space;
				}
				if (strTag == PhraseSearch.kParaFormat)
					this.ParaFormat = true;
                if (strTag == PhraseSearch.kUseGraphemeTaught)
                    this.UseGraphemesTaught = true;
                if (strTag == PhraseSearch.kHighlight)
                {
                    this.Highlight = strContent;
                }
                if (strTag == PhraseSearch.kMin)
                {
                    this.Min = Convert.ToInt32(strContent);
                }
            }
            this.Graphemes = al;
            flag = true;
			m_Title = m_Title + " - [" + strGrfs.Trim() + "]";
			return flag;
		}

		public string BuildResults()
		{
			string strText = "";
			string strSN = Search.TagSN + this.SearchNumber.ToString().Trim();
			strText += Search.TagOpener + strSN + Search.TagCloser + Environment.NewLine;
			strText += this.Title + Environment.NewLine + Environment.NewLine;
			strText += this.SearchResults;
			strText += Environment.NewLine;
			strText += this.SearchCount.ToString();
            //strText += " entries found" + Environment.NewLine;
            strText += Constants.Space + m_Settings.LocalizationTable.GetMessage("Search2",
                m_Settings.OptionSettings.UILanguage) + Environment.NewLine;
			strText += Search.TagOpener + Search.TagForwardSlash + strSN
				+ Search.TagCloser + Environment.NewLine;
			return strText;
		}

        public PhraseSearch ExecutePhraseSearch(TextData td)
        {
            if (this.ParaFormat)
                ExecutePhraseSearchP(td);
            else ExecutePhraseSearchL(td);
            return this;
        }

        private PhraseSearch ExecutePhraseSearchP(TextData td)
        {
            int nCount = 0;
            string strRslt = "";

            Paragraph para = null;
            Sentence sent = null;
            Word wrd = null;
            int nPara = td.ParagraphCount();

            //FormProgressBar fpb = new FormProgressBar(PhraseSearch.kSearch);
            FormProgressBar form = new FormProgressBar(m_Settings.LocalizationTable.GetMessage("PhraseSearch3",
                m_Settings.OptionSettings.UILanguage));
            form.PB_Init(0, nPara);
            for (int i = 0; i < nPara; i++)
            {
                form.PB_Update(i);
                para = td.GetParagraph(i);
                int nSent = para.SentenceCount();
                for (int j = 0; j < nSent; j++)
                {
                    sent = para.GetSentence(j);
                    int nWord = sent.WordCount();
                    string strMatch = "";
                    int nSize = 0;
                    for (int k = 0; k < nWord; k++)
                    {
                        wrd = sent.GetWord(k);
                        if (wrd == null)
                            break;
                        else
                        {
                            if (wrd.IsBuildableWord(this.Graphemes))
                            {
                                strMatch += wrd.DisplayWord + Constants.Space;
                                nSize++;
                            }
                            else
                            {
                                if (nSize > (this.Min - 1))
                                {
                                    strRslt += Constants.kHCOn + strMatch.Trim()
                                        + Constants.kHCOff + Constants.Space
                                        + wrd.DisplayWord + Constants.Space;
                                    nSize = 0;
                                    strMatch = "";
                                    nCount++;
                                }
                                else
                                {
                                    if (strMatch != "")
                                        strRslt += strMatch.Trim() + Constants.Space
                                        + wrd.DisplayWord + Constants.Space;
                                    else strRslt += wrd.DisplayWord + Constants.Space;
                                    strMatch = "";
                                    nSize = 0;
                                }
                            }
                        }
                    }
                    if (nSize > 0)
                    {
                        if (nSize > (this.Min - 1))
                        {
                            strRslt += Constants.kHCOn + strMatch.Trim()
                                + Constants.kHCOff + Constants.Space;
                            nCount++;
                        }
                        else
                        {
                            strRslt += strMatch.Trim() + Constants.Space;
                        }
                    }
                    strRslt = strRslt.Substring(0, strRslt.Length - 1);	//get ride of last space
                    strRslt += sent.EndingPunctuation;
                    strRslt += Constants.Space;
                }
                strRslt += Environment.NewLine + Environment.NewLine;
            }
            form.Close();
            this.SearchResults = strRslt;
            this.SearchCount = nCount;
            return this;
        }

        private PhraseSearch ExecutePhraseSearchL(TextData td)
        {
            int nCount = 0;
            string strRslt = "";

            Paragraph para = null;
            Sentence sent = null;
            Word wrd = null;
            int nPara = td.ParagraphCount();

            //FormProgressBar fpb = new FormProgressBar(PhraseSearch.kSearch);
            FormProgressBar form = new FormProgressBar(m_Settings.LocalizationTable.GetMessage("PhraseSearch3",
                m_Settings.OptionSettings.UILanguage));
            form.PB_Init(0, nPara);
            for (int i = 0; i < nPara; i++)
            {
                form.PB_Update(i);
                para = td.GetParagraph(i);
                int nSent = para.SentenceCount();
                for (int j = 0; j < nSent; j++)
                {
                    sent = para.GetSentence(j);
                    int nWord = sent.WordCount();
                    string strMatch = "";
                    bool fHighlight = false;
                    int nSize = 0;
                    int nTmp = 0;
                    for (int k = 0; k < nWord; k++)
                    {
                        wrd = sent.GetWord(k);
                        if (wrd.IsBuildableWord(this.Graphemes))
                        {
                            if (this.Highlight.Trim() == "")
                                strMatch += wrd.DisplayWord + Constants.Space;
                            else
                            {
                                if (wrd.ContainInWord(this.Highlight.Trim()))
                                    fHighlight = true;
                                strMatch += wrd.DisplayWord + Constants.Space;
                            }
                            nSize++;
                        }
                        else
                        {
                            if (nSize > (this.Min - 1))
                            {
                                if (this.ViewParaSentWord)
                                {
                                    nTmp = i + 1;
                                    strRslt += TextData.kPara + Search.Colon + nTmp.ToString().PadLeft(4);
                                    strRslt += PhraseSearch.kSeparator;
                                    nTmp = j + 1;
                                    strRslt += TextData.kSent + Search.Colon + nTmp.ToString().PadLeft(4);
                                    strRslt += PhraseSearch.kSeparator;
                                    nTmp = k + 1 - nSize;
                                    strRslt += TextData.kWord + Search.Colon + nTmp.ToString().PadLeft(4);
                                    strRslt += PhraseSearch.kSeparator;
                                }
                                if (fHighlight)
                                    strRslt += Constants.kHCOn + strMatch.Trim() + Constants.kHCOff;
                                else strRslt += strMatch.Trim();
                                strRslt += Environment.NewLine;
                                nSize = 0;
                                fHighlight = false;
                                strMatch = "";
                                nCount++;

                            }
                            else
                            {
                                nSize = 0;
                                strMatch = "";
                                fHighlight = false;
                            }
                        }
                    }
                    if (nSize > 0)
                    {
                        if (nSize > (this.Min - 1))
                        {
                            if (this.ViewParaSentWord)
                            {
                                nTmp = i + 1;
                                strRslt += TextData.kPara + Search.Colon + nTmp.ToString().PadLeft(4);
                                strRslt += PhraseSearch.kSeparator;
                                nTmp = j + 1;
                                strRslt += TextData.kSent + Search.Colon + nTmp.ToString().PadLeft(4);
                                strRslt += PhraseSearch.kSeparator;
                                nTmp = nWord + 1 - nSize;
                                strRslt += TextData.kWord + Search.Colon + nTmp.ToString().PadLeft(4);
                                strRslt += PhraseSearch.kSeparator;
                            }
                            if (fHighlight)
                                strRslt += Constants.kHCOn + strMatch.Trim() + Constants.kHCOff;
                            else strRslt += strMatch.Trim();
                            strRslt += Environment.NewLine;
                            nCount++;
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

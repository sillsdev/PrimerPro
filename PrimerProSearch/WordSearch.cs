using System;
using System.Drawing;
using System.Windows.Forms;
using PrimerProForms;
using PrimerProObjects;
using GenLib;

namespace PrimerProSearch
{
	/// <summary>
	/// Word Search
	/// </summary>
	public class WordSearch : Search
	{
        //Search parameters 
        private string m_Target;	//Word or Root to be searched
		private bool m_Words;		//Search words
		private bool m_Roots;		//Search roots
		private bool m_ParaFormat;	//How to display the results
        private bool m_IgnoreTone;  //Ignore Tone
		
        private string m_Title;             //Title
        private Settings m_Settings;        //Application Settings
        private WordList m_Wordlist;
        private bool m_ViewParaSentWord;    //Flag for viewing ParaSentWord number

		//search definition tags
        private const string kTarget = "target";
		private const string kWords = "searchwords";
		private const string kRoots = "searchroots";
		private const string kParaFormat = "paraformat";
        private const string kIgnoreTone = "ignoretone";
        
        //private const string kTitle = "Word Search";
        //private const string kSearch = "Processing Grapheme Search";
        private const string kSeparator = Constants.Tab;

		public WordSearch(int number, Settings s)
            : base(number, SearchDefinition.kWord)
		{
			m_Target = "";
			m_Words = true;
			m_Roots = false;
			m_ParaFormat = false;
            m_IgnoreTone = false;
            m_Settings = s;
            //m_Title = WordSearch.kTitle;
            m_Title = m_Settings.LocalizationTable.GetMessage("WordSearchT");
            if (m_Title == "")
                m_Title = "Word Search";
            m_Wordlist = m_Settings.WordList;
            m_ViewParaSentWord = m_Settings.OptionSettings.ViewParaSentWord;
		}

		public WordSearch(string wrd, Settings s) : base(0, SearchDefinition.kWord)
		{
			m_Target = wrd;
			m_Words = true;
			m_Roots = false;
			m_ParaFormat = false;
            m_IgnoreTone = false;
			m_Title = "";
            m_Settings = s;
            m_Wordlist = m_Settings.WordList;
            m_ViewParaSentWord = m_Settings.OptionSettings.ViewParaSentWord;
        }

		public string Target
		{
			get {return m_Target;}
			set {m_Target = value;}
		}

		public bool Words
		{
			get {return m_Words;}
			set {m_Words = value;}
		}

		public bool Roots
		{
			get {return m_Roots;}
			set {m_Roots = value;}
		}

		public bool ParaFormat
		{
			get {return m_ParaFormat;}
			set {m_ParaFormat = value;}
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

        public WordList Wordlist
        {
            get { return m_Wordlist; }
        }

        public bool ViewParaSentWord
        {
            get { return m_ViewParaSentWord; }
        }

		public bool SetupSearch()
		{
			bool flag = false;
            //FormWord fpb = new FormWord(m_Settings.OptionSettings.GetDefaultFont());
            FormWord form = new FormWord(m_Settings.OptionSettings.GetDefaultFont(), m_Settings.LocalizationTable);
            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
			{
                this.Target = form.Target;
                this.Words = false;
                this.Roots = false;
                if (form.Type == FormWord.TargetType.Root)
                    this.Roots = true;
                if (form.Type == FormWord.TargetType.Word)
                    this.Words = true;
                this.ParaFormat = form.ParaFormat;
                this.IgnoreTone = form.IgnoreTone;

                SearchDefinition  sd = new SearchDefinition(SearchDefinition.kWord);
				SearchDefinitionParm sdp = null;
                this.SearchDefinition = sd;

                if (form.Target != "")
                {
                    string strText = "";
                    sdp = new SearchDefinitionParm(WordSearch.kTarget, this.Target);
                    sd.AddSearchParm(sdp);
                    m_Title = m_Title + " - [" + this.Target + "]";
                    if (form.Type == FormWord.TargetType.Word)
                    {
                        sdp = new SearchDefinitionParm(WordSearch.kWords);
                        sd.AddSearchParm(sdp);
                    }
                    else if (form.Type == FormWord.TargetType.Root)
                    {
                        sdp = new SearchDefinitionParm(WordSearch.kRoots);
                        sd.AddSearchParm(sdp);
                        strText = m_Settings.LocalizationTable.GetMessage("WordSearch2");
                        if (strText == "")
                            strText = "Word Search for Root";
                        m_Title = strText + " [" + this.Target + "]";
                    }
                    if (form.ParaFormat)
                    {
                        sdp = new SearchDefinitionParm(WordSearch.kParaFormat);
                        sd.AddSearchParm(sdp);
                    }
                    if (form.IgnoreTone)
                    {
                        sdp = new SearchDefinitionParm(WordSearch.kIgnoreTone);
                        sd.AddSearchParm(sdp);
                    }
                    this.SearchDefinition = sd;
                    flag = true;
                }
                else
                {
                    string strMsg = m_Settings.LocalizationTable.GetMessage("WordSearch3");
                    if (strMsg == "")
                        strMsg = "Word or Root must be specified";
                    MessageBox.Show(strMsg);
                }
			}
			return flag;
		}

		public bool SetupSearch(SearchDefinition sd)
		{
			bool flag = false;
			string strTag = "";
            string strText = "";
			for (int i = 0; i < sd.SearchParmsCount(); i++)
			{
				strTag = sd.GetSearchParmAt(i).GetTag();
				if (strTag == WordSearch.kTarget)
				{
					this.Target = sd.GetSearchParmContent(strTag);
					m_Title = m_Title + " - [" + this.Target + "]";
					flag = true;
				}
				if (strTag == WordSearch.kWords)
				{
					this.Words = true;
					this.Roots = false;
					flag = true;
				}
				if (strTag == WordSearch.kRoots)
				{
					this.Roots = true;
					this.Words = false;
                    strText = m_Settings.LocalizationTable.GetMessage("WordSearch2");
                    if (strText == "")
                        strText = "Word Search for Root";
                    m_Title = strText + " [" + this.Target + "]";
                    flag = true;
				}
				if (strTag == WordSearch.kParaFormat)
					this.ParaFormat = true;
                if (strTag == WordSearch.kIgnoreTone)
                    this.IgnoreTone = true;
			}
			this.SearchDefinition = sd;
			return flag;
		}

		public string BuildResults()
		{
			string strText = "";
            string str = "";
			string strSN = Search.TagSN + this.SearchNumber.ToString().Trim();
			strText += Search.TagOpener + strSN + Search.TagCloser + Environment.NewLine;
			strText += this.Title + Environment.NewLine + Environment.NewLine;
			strText += this.SearchResults;
			strText += Environment.NewLine;
			strText += this.SearchCount.ToString();
            //strText += " entries found" + Environment.NewLine;
            str = m_Settings.LocalizationTable.GetMessage("Search2");
            if (str == "")
                str = "entries found";
            strText += Constants.Space + str + Environment.NewLine;
            strText += Search.TagOpener + Search.TagForwardSlash + strSN + Search.TagCloser;
			return strText;
		}

        public WordSearch ExecuteWordSearch(TextData td)
        {
            if (this.ParaFormat)
                ExecuteWordSearchP(td);
            else ExecuteWordSearchL(td);
            return this;
        }

        private WordSearch ExecuteWordSearchP(TextData td)
        {
            string strTarget = this.Target;
            bool fWords = this.Words;
            bool fRoots = this.Roots;
            bool fIgnoreTone = this.IgnoreTone;
            int nCount = 0;
            string strRslt = "";
            string strWord = "";
            string strRoot = "";
            string str = "";

            Paragraph para = null;
            Sentence sent = null;
            Word wrd = null;
            Word wrd2 = null;
            int nPara = td.ParagraphCount();

            //FormProgressBar form = new FormProgressBar("Processing Word Search");
            str = m_Settings.LocalizationTable.GetMessage("WordSearch1");
            if (str == "")
                str = "Processing Word Search";
            FormProgressBar form = new FormProgressBar(str);
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
                    for (int k = 0; k < nWord; k++)
                    {
                        wrd = sent.GetWord(k);
                        if (fWords)
                        {
                            if (fIgnoreTone)
                                strWord = wrd.GetWordWithoutTone();
                            else strWord = wrd.DisplayWord;
                            if (strWord == strTarget)
                            {
                                nCount++;
                                strRslt += Constants.kHCOn + wrd.DisplayWord
                                    + Constants.kHCOff + Constants.Space;
                            }
                            else strRslt += wrd.DisplayWord + Constants.Space;
                        }
                        if (fRoots)
                        {
                            if (fIgnoreTone)
                                strWord = wrd.GetWordWithoutTone();
                            else strWord = wrd.DisplayWord;
                            wrd2 = this.Wordlist.GetWord(strWord);
                            if (wrd2 != null)
                            {
                                if (wrd2.Root != null)
                                {
                                    if (fIgnoreTone)
                                        strRoot = wrd2.Root.GetRootWithoutTone();
                                    else strRoot = wrd2.Root.DisplayRoot;
                                    if (strRoot == strTarget)
                                    {
                                        nCount++;
                                        strRslt += Constants.kHCOn + wrd.DisplayWord
                                            + Constants.kHCOff + Constants.Space;
                                    }
                                    else strRslt += wrd.DisplayWord + Constants.Space;
                                }
                                else strRslt += wrd.DisplayWord + Constants.Space;
                            }
                            else strRslt += wrd.DisplayWord + Constants.Space;
                        }
                    }
                    strRslt = strRslt.Substring(0, strRslt.Length - 1);
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

        private WordSearch ExecuteWordSearchL(TextData td)
        {
            string strTarget = this.Target;
            bool fWords = this.Words;
            bool fRoots = this.Roots;
            bool fIgnoreTone = this.IgnoreTone;
            int nCount = 0;
            string strRslt = "";
            string strWord = "";
            string strRoot = "";
            string str = "";

            Paragraph para = null;
            Sentence sent = null;
            Word wrd = null;
            Word wrd2 = null;
            int nTmp = 0;
            int nPara = td.ParagraphCount();
            //FormProgressBar form = new FormProgressBar("Processing Word Search");
            str = m_Settings.LocalizationTable.GetMessage("WordSearch1");
            if (str == "")
                str = "Processing Word Search";
            FormProgressBar form = new FormProgressBar(str);
            form.PB_Init(0, td.ParagraphCount());

            for (int i = 0; i < nPara; i++)
            {
                form.PB_Update(i);
                para = td.GetParagraph(i);
                int nSent = para.SentenceCount();
                for (int j = 0; j < nSent; j++)
                {
                    sent = para.GetSentence(j);
                    int nWord = sent.WordCount();
                    for (int k = 0; k < nWord; k++)
                    {
                        wrd = sent.GetWord(k);
                        if (fIgnoreTone)
                            strWord = wrd.GetWordWithoutTone();
                        else strWord = wrd.DisplayWord;
                        if (fWords)
                        {
                            if (strWord == strTarget)
                            {
                                nCount++;
                                if (this.ViewParaSentWord)
                                {
                                    nTmp = i + 1;
                                    strRslt += TextData.kPara + Search.Colon + nTmp.ToString().PadLeft(4);
                                    strRslt += WordSearch.kSeparator;
                                    nTmp = j + 1;
                                    strRslt += TextData.kSent + Search.Colon + nTmp.ToString().PadLeft(4);
                                    strRslt += WordSearch.kSeparator;
                                    nTmp = k + 1;
                                    strRslt += TextData.kWord + Search.Colon + nTmp.ToString().PadLeft(4);
                                    strRslt += WordSearch.kSeparator;
                                }
                                strRslt += wrd.DisplayWord;
                                strRslt += Environment.NewLine;
                            }
                        }
                        if (fRoots)
                        {
                            if (fIgnoreTone)
                                strWord = wrd.GetWordWithoutTone();
                            else strWord = wrd.DisplayWord;
                            wrd2 = this.Wordlist.GetWord(strWord);
                            if (wrd2 != null)
                            {
                                if (wrd2.Root != null)
                                {
                                    if (fIgnoreTone)
                                        strRoot = wrd2.Root.GetRootWithoutTone();
                                    else strRoot = wrd2.Root.DisplayRoot;
                                    if (strRoot == strTarget)
                                    {
                                        nCount++;
                                        if (this.ViewParaSentWord)
                                        {
                                            nTmp = i + 1;
                                            strRslt += TextData.kPara + Search.Colon + nTmp.ToString().PadLeft(4);
                                            strRslt += WordSearch.kSeparator;
                                            nTmp = j + 1;
                                            strRslt += TextData.kSent + Search.Colon + nTmp.ToString().PadLeft(4);
                                            strRslt += WordSearch.kSeparator;
                                            nTmp = k + 1;
                                            strRslt += TextData.kWord + Search.Colon + nTmp.ToString().PadLeft(4);
                                            strRslt += WordSearch.kSeparator;
                                        }
                                        strRslt += wrd.DisplayWord;
                                        strRslt += Environment.NewLine;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            form.Close();
            this.SearchResults = strRslt;
            this.SearchCount = nCount;
            return this;
        }

    }
}

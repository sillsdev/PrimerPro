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
	/// 
	/// </summary>
	public class ResidueSearch : Search
	{
        //Search parameters 
        private ArrayList m_Graphemes;		//list of graphemes for untaught residue
        private string m_GraphemeToBeCounted;   //grapheme to be counted in text data file
		private bool m_ParaFmt;				//how to display results
        private bool m_IgnoreSightWords;    //Ignore sight words or not
        private bool m_UseCurrentTextData;  //Use the current text data file for checking
        private bool m_ReadingLevelInfo;    //Display base reading level information
        private string m_TextDataFile;      //Selected text data file for checking

        private Settings m_Settings;
        private string m_Title;
        private string m_DataFolder;        //Data Folder
        private GraphemeTaughtOrder m_GraphemesTaught;  //Graphemes Taught List
        private bool m_ViewParaSentWord;    //Flag for viewing ParaSentWord number.
        private Font m_DefaultFont;         //Default Font

        //Search Definition tags
        private const string kGrapheme = "grapheme";
        private const string kGrapheme2BCnt = "graphemetobecounted";
		private const string kParaFromat = "paraformat";
        private const string kIgnoreSightWords = "ignoresightwords";
        private const string kReadingLevelInfo = "readinglevelinfo";
        private const string kUseCurrentTextData = "usecurrenttextdata";
        private const string kTextDataFile = "textdatafile";
        
        private const string kSeparator = Constants.Tab;

		public ResidueSearch(int number, Settings s)
            : base(number, SearchDefinition.kResidue)
		{
            m_Graphemes = null;
            m_GraphemeToBeCounted = "";
			m_ParaFmt =  false;
            m_IgnoreSightWords = false;
            m_ReadingLevelInfo = false;
            m_UseCurrentTextData = false;
            m_TextDataFile = "";
            m_Settings = s;
            //m_Title = "UnTaught Residue Search"e;
            m_Title = m_Settings.LocalizationTable.GetMessage("ResidueSearchT");
            if (m_Title == "")
                m_Title = "UnTaught Residue Search";
            m_DataFolder = m_Settings.OptionSettings.DataFolder;
            m_GraphemesTaught = m_Settings.GraphemesTaught;
            m_ViewParaSentWord = m_Settings.OptionSettings.ViewParaSentWord;
            m_DefaultFont = m_Settings.OptionSettings.GetDefaultFont();
		}

        public ArrayList Graphemes
		{
            get { return m_Graphemes; }
            set { m_Graphemes = value; }
		}

        public string GraphemeToBeCounted
        {
            get { return m_GraphemeToBeCounted; }
            set { m_GraphemeToBeCounted = value; }
        }

		public bool ParaFormat
		{
			get {return m_ParaFmt;}
			set {m_ParaFmt = value;}
		}

        public bool IgnoreSightWords
        {
            get { return m_IgnoreSightWords; }
            set { m_IgnoreSightWords = value; }
        }

        public bool ReadingLevelInfo
        {
            get { return m_ReadingLevelInfo; }
            set { m_ReadingLevelInfo = value; }
        }
        
        public bool UseCurrentTextData
        {
            get { return m_UseCurrentTextData; }
            set { m_UseCurrentTextData = value; }
        }

        public string TextDataFile
        {
            get { return m_TextDataFile; }
            set { m_TextDataFile = value; }
        }

        public string Title
		{
			get {return m_Title;}
		}

        public string DataFolder
        {
            get { return m_DataFolder; }
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
            //FormResidue fpb = new FormResidue(this.GraphemesTaught,this.DefaultFont, this.DataFolder);
            FormResidue form = new FormResidue(m_GraphemesTaught, m_DefaultFont, m_DataFolder, m_Settings.LocalizationTable);
			DialogResult dr = form.ShowDialog();
			if (dr == DialogResult.OK)
			{
                this.Graphemes = form.Graphemes;
                this.GraphemeToBeCounted = form.GraphemeToBeCounted;
                this.ParaFormat = form.ParaFormat;
                this.IgnoreSightWords = form.IgnoreSightWords;
                this.ReadingLevelInfo = form.ReadingLevelInfo;
                this.UseCurrentTextData = form.UseCurrentTextData;
                this.TextDataFile = form.TextDataFile;

                if (this.Graphemes != null)
				{
					SearchDefinition sd = new SearchDefinition(SearchDefinition.kResidue);
					SearchDefinitionParm sdp = null;
                    this.SearchDefinition = sd;

					string strSym = "";
					string strSegs = "";
                    string strFile = "";
                    for (int i = 0; i < this.Graphemes.Count; i++)
					{
                        strSym = this.Graphemes[i].ToString();
						sdp = new SearchDefinitionParm(ResidueSearch.kGrapheme, strSym);
						sd.AddSearchParm(sdp);
                        strSegs += strSym + Constants.Space;
					}

                    if (this.GraphemeToBeCounted != "")
                    {
                        strSym = this.GraphemeToBeCounted.Trim();
                        sdp = new SearchDefinitionParm(ResidueSearch.kGrapheme2BCnt, strSym);
                        sd.AddSearchParm(sdp);
                    }

					if (this.ParaFormat)
					{
						sdp = new SearchDefinitionParm(ResidueSearch.kParaFromat);
						sd.AddSearchParm(sdp);
					}
                    if (this.IgnoreSightWords)
                    {
                        sdp = new SearchDefinitionParm(ResidueSearch.kIgnoreSightWords);
                        sd.AddSearchParm(sdp);
                    }
                    if (this.ReadingLevelInfo)
                    {
                        sdp = new SearchDefinitionParm(ResidueSearch.kReadingLevelInfo);
                        sd.AddSearchParm(sdp);
                    }
                    if (this.UseCurrentTextData)
                    {
                        sdp = new SearchDefinitionParm(ResidueSearch.kUseCurrentTextData);
                        sd.AddSearchParm(sdp);
                    }
                    else
                    {
                        strFile = this.TextDataFile;
                        sdp = new SearchDefinitionParm(ResidueSearch.kTextDataFile, strFile);
                        sd.AddSearchParm(sdp);
                    }
					m_Title = m_Title + " - [" + strSegs.Trim() + "]";
					flag = true;
                    this.SearchDefinition = sd;
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
			string strSegs = "";

			this.SearchDefinition = sd;
			ArrayList al = new ArrayList();

			for (int i = 0; i < sd.SearchParmsCount(); i++)
			{
				sdp = sd.GetSearchParmAt(i);
				strTag = sdp.GetTag();
				strContent = sdp.GetContent();
				if (strTag == ResidueSearch.kGrapheme)
				{
					al.Add(strContent);
                    strSegs += strContent + Constants.Space;
                    flag = true;
				}
                if (strTag == ResidueSearch.kGrapheme2BCnt)
                    this.GraphemeToBeCounted = strContent;
				if (strTag == ResidueSearch.kParaFromat)
					this.ParaFormat = true;
                if (strTag == ResidueSearch.kIgnoreSightWords)
                    this.IgnoreSightWords = true;
                if (strTag == ResidueSearch.kReadingLevelInfo)
                    this.ReadingLevelInfo = true;
                if (strTag == ResidueSearch.kUseCurrentTextData)
                    this.UseCurrentTextData = true;
                if (strTag == ResidueSearch.kTextDataFile)
                    this.TextDataFile = strContent;
			}
            this.Graphemes = al;
            m_Title = m_Title + " - [" + strSegs.Trim() + "]";
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
            //strText += this.SearchCount.ToString() + " entries found" + Environment.NewLine;
            str = m_Settings.LocalizationTable.GetMessage("Search2");
            if (str == "")
                str = "entries found";
            strText += this.SearchCount.ToString() + Constants.Space + str + Environment.NewLine;
            strText += Environment.NewLine;
            strText += Search.TagOpener + Search.TagForwardSlash + strSN
				+ Search.TagCloser + Environment.NewLine;
			return strText;
		}

        public ResidueSearch ExecuteResidueSearch(TextData td)
        {
            if (this.ParaFormat)
                ExecuteResidueSearchP(td);
            else ExecuteResidueSearchL(td);
            return this;
        }

        private ResidueSearch ExecuteResidueSearchP(TextData td)
        {
            int nCount = 0;
            string strRslt = "";
            int nGrfCount = 0;

            Paragraph para = null;
            Sentence sent = null;
            Word wrd = null;
            int nPara = td.ParagraphCount();
            for (int i = 0; i < nPara; i++)
            {
                para = td.GetParagraph(i);
                int nSent = para.SentenceCount();
                for (int j = 0; j < nSent; j++)
                {
                    sent = para.GetSentence(j);
                    int nWord = sent.WordCount();
                    for (int k = 0; k < nWord; k++)
                    {
                        wrd = sent.GetWord(k);
                        if (wrd.IsBuildableWord(this.Graphemes))
                        {
                            strRslt += wrd.DisplayWord + Constants.Space;
                        }
                        else if ((this.IgnoreSightWords) && (wrd.IsSightWord()))
                        {
                            strRslt += wrd.DisplayWord + Constants.Space;
                        }
                        else
                        {
                            strRslt += wrd.HighlightMissingGraphemes(this.Graphemes);
                            strRslt += Constants.Space;
                            nCount++;
                        }
                        if (wrd.ContainInWord(this.GraphemeToBeCounted))
                            nGrfCount++;
                    }
                    strRslt = strRslt.TrimEnd();            //get ride of last space
                    strRslt += sent.EndingPunctuation;
                    strRslt += Constants.Space;
                }
                strRslt += Environment.NewLine + Environment.NewLine;
            }
            if (this.GraphemeToBeCounted != "")
            {
                // this.this.GraphemeToBeCounted + " (count): " + nGrfCount.ToString()
                string strMsg = m_Settings.LocalizationTable.GetMessage("ResidueSearch1");
                if (strMsg == "")
                   strMsg =  "(count):";
                strRslt +=  this.GraphemeToBeCounted + Constants.Space + strMsg + Constants.Space + nGrfCount.ToString() + Environment.NewLine + Environment.NewLine;
            }

            if (this.ReadingLevelInfo)
            {
                strRslt += this.GetReadingLevelInfo(td);
                strRslt += Environment.NewLine;
            }

            this.SearchResults = strRslt;
            this.SearchCount = nCount;
            
            return this;
        }

        private ResidueSearch ExecuteResidueSearchL(TextData td)
        {
            int nCount = 0;
            string strRslt = "";
            int nGrfCount = 0;

            Paragraph para = null;
            Sentence sent = null;
            Word wrd = null;
            int nTmp = 0;
            int nPara = td.ParagraphCount();
            for (int i = 0; i < nPara; i++)
            {
                para = td.GetParagraph(i);
                int nSent = para.SentenceCount();
                for (int j = 0; j < nSent; j++)
                {
                    sent = para.GetSentence(j);
                    int nWord = sent.WordCount();
                    for (int k = 0; k < nWord; k++)
                    {
                        wrd = sent.GetWord(k);
                        if (!wrd.IsBuildableWord(this.Graphemes))
                        {
                            if ((!this.IgnoreSightWords) || (!wrd.IsSightWord()))
                            {
                                nCount++;
                                if (this.ViewParaSentWord)
                                {
                                    nTmp = i + 1;
                                    strRslt += TextData.kPara + Search.Colon + nTmp.ToString().PadLeft(4);
                                    strRslt += ResidueSearch.kSeparator;
                                    nTmp = j + 1;
                                    strRslt += TextData.kSent + Search.Colon + nTmp.ToString().PadLeft(4);
                                    strRslt += ResidueSearch.kSeparator;
                                    nTmp = k + 1;
                                    strRslt += TextData.kWord + Search.Colon + nTmp.ToString().PadLeft(4);
                                    strRslt += ResidueSearch.kSeparator;
                                }
                                strRslt += wrd.HighlightMissingGraphemes(this.Graphemes) + Environment.NewLine;
                            }
                        }
                        if (wrd.ContainInWord(this.GraphemeToBeCounted))
                            nGrfCount++;
                    }
                }
            }
            strRslt += Environment.NewLine;

            if (this.GraphemeToBeCounted != "")
            {
                string strMsg = " (count): ";
                strRslt += this.GraphemeToBeCounted + strMsg + nGrfCount.ToString() + Environment.NewLine;
                strRslt += Environment.NewLine;
            }

            if (this.ReadingLevelInfo)
            {
                strRslt += this.GetReadingLevelInfo(td);
                strRslt += Environment.NewLine;
            }

            this.SearchResults = strRslt;
            this.SearchCount = nCount;
            return this;
        }

        private string GetReadingLevelInfo(TextData td)
        {
            string strInfo = "";
            string strText = "";
            strText = m_Settings.LocalizationTable.GetMessage("ResidueSearch2");
            if (strText == "")
                strText = "Max number of words in sentences:";
            strInfo += strText + Constants.Space + td.MaxNumberOfWordsInSentences().ToString() + Environment.NewLine;

            strText = m_Settings.LocalizationTable.GetMessage("ResidueSearch3");
            if (strText == "")
                strText = "Max number of syllables in words";
            strInfo += strText + Constants.Space + td.MaxNumberOfSyllablesInWords().ToString() + Environment.NewLine;

            strText = m_Settings.LocalizationTable.GetMessage("ResidueSearch4");
            if (strText == "")
                strText = "Average number of words in sentences is less than:";
            strInfo += strText + Constants.Space + (td.AvgNumberOfWordsInSentences() + 1).ToString() + Environment.NewLine;
            
            strText = m_Settings.LocalizationTable.GetMessage("ResidueSearch5");
            if (strText == "")
                strText = "Average number of syllables in words is less than:";
            strInfo += strText + Constants.Space + (td.AvgNumberOfSyllablesInWords() + 1).ToString() + Environment.NewLine;

            strText = m_Settings.LocalizationTable.GetMessage("ResidueSearch6");
            if (strText == "")
                strText = "Number of unique words in story:";
            strInfo += strText + Constants.Space + td.BuildWordListWithNoDuplicates().WordCount().ToString() + Environment.NewLine;

            strText = m_Settings.LocalizationTable.GetMessage("ResidueSearch7");
            if (strText == "")
                strText = "Number of words in story:";
            strInfo += strText + Constants.Space + td.WordCount().ToString() + Environment.NewLine;

            strText = m_Settings.LocalizationTable.GetMessage("ResidueSearch8");
            if (strText == "")
                strText = "Number of syllables in story:";
            strInfo += strText + Constants.Space + td.SyllableCount().ToString() + Environment.NewLine;

            strText = m_Settings.LocalizationTable.GetMessage("ResidueSearch9");
            if (strText == "")
                strText = "Number of sentences in story:";
            strInfo += strText + Constants.Space + td.SentenceCount().ToString() + Environment.NewLine;
            return strInfo;
        }
    }
}

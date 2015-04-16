using System;
using System.Windows.Forms;
using System.Collections;
using PrimerProForms;
using PrimerProObjects;
using GenLib;

namespace PrimerProSearch
{
	/// <summary>
	/// Sight Search
	/// </summary>
	public class SightSearch : Search
	{
        //Search parameters 
        private string m_StoryFileName;     //Name of Story File
        private ArrayList m_SelectedWords;  //Selected sight words to be searched
		private bool m_ParaFormat;      	//How to display the results

        private string m_Title;		        //Search title
        private Settings m_Settings;        //Application Settings
        private string m_DataFolder;        //Data Folder
		private SightWords m_SightWords;	//Sight words list
        private bool m_ViewParaSentWord;    //Flag for viewing ParaSentWord number.

        //Search Definition tags
        private const string kStoryFileName = "storyfile";
        private const string kWord = "word";
		private const string kParaFormat = "paraformat";

        //private const string kTitle = "Sight Word Search";
        private const string kSeparator = Constants.Tab;
			
		public SightSearch(int number, Settings s)
            : base(number, SearchDefinition.kSight)
		{
            m_StoryFileName = "";
            m_SelectedWords = new ArrayList();
			m_ParaFormat = false;
            m_Settings = s;
            m_Title = m_Settings.LocalizationTable.GetMessage("SightSearchT",
                m_Settings.OptionSettings.UILanguage); ;
            m_DataFolder = m_Settings.OptionSettings.DataFolder;
            m_SightWords = m_Settings.SightWords;
            m_ViewParaSentWord = m_Settings.OptionSettings.ViewParaSentWord;
        }

        public string StoryFileName
        {
            get { return m_StoryFileName; }
            set { m_StoryFileName = value; }
        }

        public ArrayList SelectedWords
        {
            get { return m_SelectedWords; }
            set { m_SelectedWords = value; }
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

        public string DataFolder
        {
            get { return m_DataFolder; }
        }

		public SightWords SightWords
		{
			get{return m_SightWords;}
		}

        public bool ViewParaSentWord
        {
            get { return m_ViewParaSentWord; }
        }

        public bool SetupSearch()
		{
			bool flag = false;
            //FormSight fpb = new FormSight(m_SightWords, m_DataFolder);
			FormSight form = new FormSight(m_SightWords, m_DataFolder, 
                m_Settings.LocalizationTable, m_Settings.OptionSettings.UILanguage);
			DialogResult dr = form.ShowDialog();
			if (dr == DialogResult.OK)
			{
                this.StoryFileName = form.StoryFileName;
                this.SelectedWords = form.SelectedWords;
                this.ParaFormat = form.ParaFormat;
                
				SearchDefinition sd = new SearchDefinition(SearchDefinition.kSight);
				SearchDefinitionParm sdp = null;
                this.SearchDefinition = sd;

                String strWord = "";
				if (this.SelectedWords.Count > 0)
				{
                    if (this.StoryFileName != "")
                    {
                        sdp = new SearchDefinitionParm(SightSearch.kStoryFileName, this.StoryFileName);
                        sd.AddSearchParm(sdp);
                    }
                    for (int i = 0; i < SelectedWords.Count; i++)
                    {
                        strWord = SelectedWords[i].ToString();
                        sdp = new SearchDefinitionParm(SightSearch.kWord, strWord);
                        sd.AddSearchParm(sdp);
                    }
					if (this.ParaFormat)
					{
						sdp = new SearchDefinitionParm(SightSearch.kParaFormat);
						sd.AddSearchParm(sdp);
					}
					this.SearchDefinition = sd;
					flag = true;
				}
                //else MessageBox.Show("No Sight Word was selected");
                else
                {
                    string strMsg = m_Settings.LocalizationTable.GetMessage("SightSearch1",
                        m_Settings.OptionSettings.UILanguage);
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
                if (strTag == SightSearch.kStoryFileName)
                {
                    this.StoryFileName = sd.GetSearchParmContent(strTag);
                    flag = true;
                }
                if (strTag == SightSearch.kWord)
                    this.SelectedWords.Add(strContent);
 				if (strTag == SightSearch.kParaFormat)
					this.ParaFormat = true;
			}
			this.SearchDefinition = sd;
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
            strText += Search.TagOpener + Search.TagForwardSlash + strSN + Search.TagCloser;
			return strText;
		}

        public SightSearch ExecuteSightSearch()
        {
            TextData tdStory = new TextData(m_Settings);
            if (tdStory.LoadFile(this.StoryFileName))
            {
                if (this.ParaFormat)
                    ExecuteSightSearchP(tdStory);
                else ExecuteSightSearchL(tdStory);
            }
            //else MessageBox.Show("Story File does not Exists");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("SightSearch2",
                    m_Settings.OptionSettings.UILanguage);
                MessageBox.Show(strMsg);
            }
            return this;
        }

        private SightSearch ExecuteSightSearchP(TextData tdStory)
        {
            Paragraph para = null;
            Sentence sent = null;
            Word wrd = null;
            string strRslt = "";
            int nCount = 0;
            for (int i = 0; i < tdStory.ParagraphCount(); i++)
            {
                para = tdStory.GetParagraph(i);
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
                            do
                            {
                                if (wrd.DisplayWord == this.SelectedWords[ndx].ToString())
                                    found = true;
                                ndx++;
                            }
                            while ((!found) && (ndx < this.SelectedWords.Count));

                            if (found)
                            {
                                strRslt += Constants.kHCOn + wrd.DisplayWord +
                                          Constants.kHCOff + Constants.Space;
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
            return this;
        }

        private SightSearch ExecuteSightSearchL(TextData tdStory)
        {
            Paragraph para = null;
            Sentence sent = null;
            Word wrd = null;
            int nCount = 0;
            string strRslt = "";
            int nTmp = 0;
            for (int i = 0; i < tdStory.ParagraphCount(); i++)
            {
                para = tdStory.GetParagraph(i);
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
                            do
                            {
                                if (wrd.DisplayWord == this.SelectedWords[ndx].ToString())
                                    found = true;
                                ndx++;
                            }
                            while ((!found) && (ndx < this.SelectedWords.Count));

                            if (found)
                            {
                                if (this.ViewParaSentWord)
                                {
                                    nTmp = i + 1;
                                    strRslt += TextData.kPara + Search.Colon + nTmp.ToString().PadLeft(4);
                                    strRslt += SightSearch.kSeparator;
                                    nTmp = j + 1;
                                    strRslt += TextData.kSent + Search.Colon + nTmp.ToString().PadLeft(4);
                                    strRslt += SightSearch.kSeparator;
                                    nTmp = k + 1;
                                    strRslt += TextData.kWord + Search.Colon + nTmp.ToString().PadLeft(4);
                                    strRslt += SightSearch.kSeparator;
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
            return this;
        }

    }
}

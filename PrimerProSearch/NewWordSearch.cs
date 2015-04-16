using System;
using System.Windows.Forms;
using System.Collections;
using PrimerProForms;
using PrimerProObjects;
using GenLib;

namespace PrimerProSearch
{
    /// <summary>
    /// Word Search
    /// </summary>
    public class NewWordSearch : Search
    {
        //Search parameters 
        private string m_BaseFileName;      //Name of Base Text File
        private string m_StoryFileName;     //Name of Story File
        private bool m_ParaFormat;          //How to display results
        private bool m_IgnoreTone;          //Ignore Tone in Text Data

        private string m_Title;
        private Settings m_Settings;
        private string m_DataFolder;        //Data Folder
        private bool m_ViewParaSentWord;    //Flag for viewing ParaSentWord number.

        //Search Definition tags
        private const string kBaseFileName = "basefile";
        private const string kStoryFileName = "storyfile";
        private const string kParaFormat = "paraformat";
        private const string kIgnoreTone = "ignoreformat";

        private const string kSeparator = Constants.Tab;

        public NewWordSearch(int number, Settings s)
            : base(number, SearchDefinition.kNewWord)
        {
            m_BaseFileName = "";
            m_StoryFileName = "";
            m_ParaFormat = false;
            m_IgnoreTone = false;

            m_Settings = s;
            m_Title = m_Settings.LocalizationTable.GetMessage("NewWordSearchT",
                m_Settings.OptionSettings.UILanguage);
            m_DataFolder = m_Settings.OptionSettings.DataFolder;
            m_ViewParaSentWord = m_Settings.OptionSettings.ViewParaSentWord;
        }

        public string BaseFileName
        {
            get { return m_BaseFileName; }
            set { m_BaseFileName = value; }
        }

        public string StoryFileName
        {
            get { return m_StoryFileName; }
            set { m_StoryFileName = value; }
        }

        public bool ParaFormat
        {
            get { return m_ParaFormat; }
            set { m_ParaFormat = value; }
        }

        public bool IgnoreTone
        {
            get { return m_IgnoreTone; }
            set { m_IgnoreTone = value; }
        }

        public string Title
        {
            get { return m_Title; }
        }

        public string DataFolder
        {
            get { return m_DataFolder; }
        }

        public bool ViewParaSentWord
        {
            get { return m_ViewParaSentWord; }
        }
 
        public bool SetupSearch()
        {
            bool flag = false;
            //FormNewWord fpb = new FormNewWord(m_DataFolder);
            FormNewWord form = new FormNewWord(m_DataFolder, m_Settings.LocalizationTable,
                m_Settings.OptionSettings.UILanguage);
            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.BaseFileName = form.BaseFileName;
                this.StoryFileName = form.StoryFileName;
                this.ParaFormat = form.ParaFormat;
                this.IgnoreTone = form.IgnoreTone;

                SearchDefinition sd = new SearchDefinition(SearchDefinition.kNewWord);
                SearchDefinitionParm sdp = null;
                this.SearchDefinition = sd;

                if (this.BaseFileName != "")
                {
                    sdp = new SearchDefinitionParm(NewWordSearch.kBaseFileName, this.BaseFileName);
                    sd.AddSearchParm(sdp);
                    sdp = new SearchDefinitionParm(NewWordSearch.kStoryFileName, this.StoryFileName);
                    sd.AddSearchParm(sdp);

                    if (this.ParaFormat)
                    {
                        sdp = new SearchDefinitionParm(NewWordSearch.kParaFormat);
                        sd.AddSearchParm(sdp);
                    }
                    if (this.IgnoreTone)
                    {
                        sdp = new SearchDefinitionParm(NewWordSearch.kIgnoreTone);
                        sd.AddSearchParm(sdp);
                    }
                    this.SearchDefinition = sd;
                    flag = true;
                }
            }
            return flag;
        }
        
        public bool SetupSearch(SearchDefinition sd)
        {
            bool flag = false;
            string strTag = "";
            for (int i = 0; i < sd.SearchParmsCount(); i++)
            {
                strTag = sd.GetSearchParmAt(i).GetTag();
                if (strTag == NewWordSearch.kBaseFileName)
                {
                    this.BaseFileName = sd.GetSearchParmContent(strTag);
                    flag = true;
                }
                if (strTag == NewWordSearch.kStoryFileName)
                {
                    this.StoryFileName = sd.GetSearchParmContent(strTag);
                    flag = true;
                }
                if (strTag == NewWordSearch.kParaFormat)
                    this.ParaFormat = true;
                if (strTag == NewWordSearch.kIgnoreTone)
                    this.IgnoreTone = true;
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

        public NewWordSearch ExecuteNewWordSearch()
        {
            string strMsg = "";
            TextData tdBase = new TextData(m_Settings);
            TextData tdStory = new TextData(m_Settings);
            if (tdBase.LoadFile(this.BaseFileName))
            {
                if (tdStory.LoadFile(this.StoryFileName))
                {
                    SortedList slWords = tdBase.BuildSortedListOfWords(this.IgnoreTone);
                    if (slWords.Count > 0)
                    {
                        if (this.ParaFormat)
                            ExecuteNewWordSearchP(slWords, tdStory);
                        else ExecuteNewWordSearchL(slWords, tdStory);
                    }
                }
                //else MessageBox.Show("Story File does not exist");
                else
                {
                    strMsg = m_Settings.LocalizationTable.GetMessage("NewWordSearch1",
                        m_Settings.OptionSettings.UILanguage);
                    MessageBox.Show(strMsg);
                }
            }
            //else MessageBox.Show("Base File does not exists");
            else
            {
                strMsg = m_Settings.LocalizationTable.GetMessage("NewWordSearch2",
                    m_Settings.OptionSettings.UILanguage);
                MessageBox.Show(strMsg);
            }
            return this;
        }

        private NewWordSearch ExecuteNewWordSearchP(SortedList slWords, TextData tdStory)
        {
            Paragraph para = null;
            Sentence sent = null;
            Word wrd = null;
            string strRslt = "";
            string strWord = "";
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
                        if (this.IgnoreTone)
                            strWord = wrd.GetWordWithoutTone();
                        else strWord = wrd.DisplayWord;
                        if (strWord != "")
                        {
                            if (slWords.IndexOfKey(strWord) < 0)
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

        private NewWordSearch ExecuteNewWordSearchL(SortedList slWords, TextData tdStory)
        {
            bool fIgnoreTone = this.IgnoreTone;
            int nCount = 0;
            string strWord = "";
            string strRslt = "";

            Paragraph para = null;
            Sentence sent = null;
            Word wrd = null;
            int nTmp = 0;
            int nPara = tdStory.ParagraphCount();
            FormProgressBar form = new FormProgressBar();
            form.PB_Init(0, tdStory.ParagraphCount());

            for (int i = 0; i < nPara; i++)
            {
                form.PB_Update(i);
                para = tdStory.GetParagraph(i);
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
                        if (slWords.IndexOfKey(strWord) < 0)
                        {
                            nCount++;
                            if (this.ViewParaSentWord)
                            {
                                nTmp = i + 1;
                                strRslt += TextData.kPara + Search.Colon + nTmp.ToString().PadLeft(4);
                                strRslt += NewWordSearch.kSeparator;
                                nTmp = j + 1;
                                strRslt += TextData.kSent + Search.Colon + nTmp.ToString().PadLeft(4);
                                strRslt += NewWordSearch.kSeparator;
                                nTmp = k + 1;
                                strRslt += TextData.kWord + Search.Colon + nTmp.ToString().PadLeft(4);
                                strRslt += NewWordSearch.kSeparator;
                            }
                            strRslt += wrd.DisplayWord;
                            strRslt += Environment.NewLine;
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

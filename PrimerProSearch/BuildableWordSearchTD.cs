using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using PrimerProForms;
using PrimerProObjects;
using GenLib;

namespace PrimerProSearch
{
    public class BuildableWordSearchTD : Search
    {
        //Search parameters 
        private ArrayList m_Graphemes;			//list of graphemes for buildable words
        private ArrayList m_Highlights;         //graphemes to highlight
        private bool m_ParaFormat;              //how to display the results
        private bool m_NoDuplicates;            //Do not display any duplicate words

        private string m_Title;					//search title
        private Settings m_Settings;            //Application Settings
        private GraphemeInventory m_GI;         //Grapheme Inventory
        private GraphemeTaughtOrder m_GraphemesTaught;  //Grapheme Taught Order
        private bool m_ViewParaSentWord;        //Flag for viewing ParaSentWord number
        private Font m_DefaultFont;             //Default font

        //Search Definition tags
        private const string kGrapheme = "grapheme";
        private const string kHighlight = "highlight";
        private const string kParaFormat = "paraformat";
        private const string kNoDuplicates = "noduplicates";
        private const string kSeparator = Constants.Tab;

        public BuildableWordSearchTD(int number, Settings s)
            : base(number, SearchDefinition.kBuilt)
		{
            m_Graphemes = null;
            m_Highlights = null;
            m_ParaFormat = false;
            m_NoDuplicates = false;
            m_Settings = s;
            //m_Title = BuildableWordsSearchTD.kTitle;
            m_Title = m_Settings.LocalizationTable.GetMessage("BuildableWordsSearchTDT");
            if (m_Title == "")
                m_Title = "Buildable Words Search";
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

        public ArrayList Highlights
        {
            get { return m_Highlights; }
            set { m_Highlights = value; }
        }

        public bool ParaFormat
        {
            get { return m_ParaFormat; }
            set { m_ParaFormat = value; }
        }

        public bool NoDuplicates
        {
            get { return m_NoDuplicates; }
            set { m_NoDuplicates = value; }
        }

        public string Title
        {
            get { return m_Title; }
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
            //FormBuilt fpb = new FormBuilt(m_GI, m_GraphemesTaught, m_DefaultFont);
            FormBuildableWordsTD form = new FormBuildableWordsTD(m_GI, m_GraphemesTaught, m_DefaultFont, m_Settings.LocalizationTable,
                m_Settings.OptionSettings.UILanguage);
            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.Graphemes = form.Graphemes;
                this.Highlights = form.Highlights;
                this.ParaFormat = form.ParaFormat;
                this.NoDuplicates = form.NoDuplicates;

                if (this.Graphemes != null)
                {
                    SearchDefinition sd = new SearchDefinition(SearchDefinition.kBuilt);
                    SearchDefinitionParm sdp = null;
                    this.SearchDefinition = sd;

                    string strSym = "";
                    string strGrfs = "";

                    for (int i = 0; i < this.Graphemes.Count; i++)
                    {
                        strSym = this.Graphemes[i].ToString();
                        sdp = new SearchDefinitionParm(BuildableWordSearchTD.kGrapheme, strSym);
                        sd.AddSearchParm(sdp);
                        strGrfs += strSym + Constants.Space;
                    }

                    for (int i = 0; i < this.Highlights.Count; i++)
                    {
                        strSym = this.Highlights[i].ToString();
                        sdp = new SearchDefinitionParm(BuildableWordSearchTD.kHighlight, strSym);
                        sd.AddSearchParm(sdp);
                    }

                    if (this.ParaFormat)
                    {
                        sdp = new SearchDefinitionParm(BuildableWordSearchTD.kParaFormat);
                        sd.AddSearchParm(sdp);
                    }

                    if (this.NoDuplicates)
                    {
                        sdp = new SearchDefinitionParm(BuildableWordSearchTD.kNoDuplicates);
                        sd.AddSearchParm(sdp);
                    }

                    m_Title = m_Title + " - [" + strGrfs.Trim() + "]";
                    flag = true;
                    this.SearchDefinition = sd;
                }
                //else MessageBox.Show("Must specified at least one grapheme");
                else
                {
                    string strMsg = m_Settings.LocalizationTable.GetMessage("BuildableWordsSearchTD2");
                    if (strMsg == "")
                        strMsg = "Must specified at least one grapheme";
                    MessageBox.Show(strMsg);
                }
            }
            return flag;
        }

        public bool SetupSearch(SearchDefinition sd)
        {
            bool flag = true;
            string strTag = "";
            string strContent = "";
            string strGrfs = "";

            this.SearchDefinition = sd;
            ArrayList alG = new ArrayList();
            ArrayList alH = new ArrayList();

            for (int i = 0; i < sd.SearchParmsCount(); i++)
            {
                strTag = sd.GetSearchParmAt(i).GetTag();
                strContent = sd.GetSearchParmAt(i).GetContent();
                if (strTag == BuildableWordSearchTD.kGrapheme)
                {
                    alG.Add(strContent);
                    strGrfs += strContent + Constants.Space;
                }
                if (strTag == BuildableWordSearchTD.kHighlight)
                {
                    alH.Add(strContent);
                }
                if (strTag == BuildableWordSearchTD.kParaFormat)
                    this.ParaFormat = true;
                if (strTag == BuildableWordSearchTD.kNoDuplicates)
                    this.NoDuplicates = true;
            }
            this.Graphemes = alG;
            this.Highlights = alH;
            m_Title = m_Title + " - [" + strGrfs.Trim() + "]";
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
            //strText += his.SearchCount.ToString() + " entries found" + Environment.NewLine;
            str = m_Settings.LocalizationTable.GetMessage("Search2");
            if (str == "")
                str = "entries found";
            strText += this.SearchCount.ToString() + Constants.Space + str + Environment.NewLine;
            strText += Search.TagOpener + Search.TagForwardSlash + strSN
                + Search.TagCloser + Environment.NewLine;
            return strText;
        }

        public BuildableWordSearchTD ExecuteBuildableWordSearch(TextData td)
        {
            if (this.ParaFormat)
                ExecuteBuildableWordSearchP(td);
            else ExecuteBuildableWordSearchL(td);
            return this;
        }

        private BuildableWordSearchTD ExecuteBuildableWordSearchP(TextData td)
        {
            Paragraph para = null;
            Sentence sent = null;
            Word wrd = null;
            string strRslt = "";
            string strMsg = "";
            int nCount = 0;
            //FormProgressBar fpb = new FormProgressBar(BuildableWordsSearchTD.kSearch);
            strMsg = m_Settings.LocalizationTable.GetMessage("BuildableWordsSearchTD1");
            if (strMsg == "")
                strMsg = "Processing Buildable Words Search";
            FormProgressBar form = new FormProgressBar(strMsg);
            form.PB_Init(0, td.ParagraphCount());

            for (int i = 0; i < td.ParagraphCount(); i++)
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
                            if (wrd.IsBuildableWord(this.Graphemes))
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
            form.Close();
            return this;
        }

        private BuildableWordSearchTD ExecuteBuildableWordSearchL(TextData td)
        {
            Paragraph para = null;
            Sentence sent = null;
            Word wrd = null;
            int nCount = 0;
            string strRslt = "";
            string strMsg = "";
            SortedList sl = new SortedList(StringComparer.OrdinalIgnoreCase);
            int nTmp = 0;
            //FormProgressBar fpb = new FormProgressBar(BuildableWordsSearchTD.kSearch);
            strMsg = m_Settings.LocalizationTable.GetMessage("BuildableWordsSearchTD1");
            if (strMsg == "")
                strMsg = "Processing Buildable Words Search";
            FormProgressBar form = new FormProgressBar(strMsg);
            form.PB_Init(0, td.ParagraphCount());

            for (int i = 0; i < td.ParagraphCount(); i++)
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
                            bool fHighlight = false;
                            if (wrd.IsBuildableWord(this.Graphemes))
                            {
                                if (this.NoDuplicates)
                                {
                                    if (!sl.Contains(wrd.DisplayWord))
                                    {
                                        found = true;
                                        sl.Add(wrd.DisplayWord, wrd);
                                        if ((this.Highlights != null) && (this.Highlights.Count > 0))
                                        {
                                            if (wrd.ContainInWord(this.Highlights))
                                                fHighlight = true;
                                        }
                                    }
                                }
                                else
                                {
                                    found = true;
                                    if ((this.Highlights != null) && (this.Highlights.Count > 0))
                                    {
                                        if (wrd.ContainInWord(this.Highlights))
                                            fHighlight = true;
                                    }
                                }
                            }

                            if (found)
                            {
                                if (this.ViewParaSentWord)
                                {
                                    nTmp = i + 1;
                                    strRslt += TextData.kPara + Search.Colon + nTmp.ToString().PadLeft(4);
                                    strRslt += BuildableWordSearchTD.kSeparator;
                                    nTmp = j + 1;
                                    strRslt += TextData.kSent + Search.Colon + nTmp.ToString().PadLeft(4);
                                    strRslt += BuildableWordSearchTD.kSeparator;
                                    nTmp = k + 1;
                                    strRslt += TextData.kWord + Search.Colon + nTmp.ToString().PadLeft(4);
                                    strRslt += BuildableWordSearchTD.kSeparator;
                                }
                                if (fHighlight)
                                    strRslt += Constants.kHCOn + wrd.DisplayWord + Constants.kHCOff;
                                else strRslt += wrd.DisplayWord;
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

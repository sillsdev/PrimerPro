using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using PrimerProForms;
using PrimerProObjects;
using GenLib;

namespace PrimerProSearch
{
    public class SyllographTDSearch : Search
    {
        //Search parameters
        private string m_Syllograph;            // Selected syllograph
        private SyllographFeatures m_Features;      // Selected syloograph features
        private bool m_ParaFormat;	        //How to display the results

        private string m_Title;		        //search title;
        private Settings m_Settings;        //Application Settings
        private PSTable m_PSTable;	        //Parts of Speech
        private GraphemeInventory m_GI;	    //Grapheme Inventory
        private bool m_ViewParaSentWord;    //Flag for viewing ParaSentWord number
        private Font m_DefaultFont;         //Default Font

        //Search Definition tags
        private const string kTarget = "syllograph";
        private const string kCatPrimary = "primary";
        private const string kCatSecondary = "secondary";
        private const string kCatTertiary = "tertiary";
        private const string kParaFormat = "paraformat";
        private const string kTitle = "Syllograph Search";
        private const string kSeparator = Constants.Tab;

        public SyllographTDSearch(int number, Settings s)
            : base(number, SearchDefinition.kSyllographWL)
        {
            m_Syllograph = "";
            m_Features = null;
            m_ParaFormat = false;

            m_Settings = s;
            m_Title = SyllographTDSearch.kTitle; ;
            m_GI = m_Settings.GraphemeInventory;
            m_PSTable = m_Settings.PSTable;
            m_ViewParaSentWord = m_Settings.OptionSettings.ViewParaSentWord;
            m_DefaultFont = m_Settings.OptionSettings.GetDefaultFont();
        }

        public SyllographTDSearch(string strGrf, Settings s) : base(0, SearchDefinition.kSyllographWL)
        {
            m_Syllograph = strGrf;
            m_Features = null;
            m_ParaFormat = false;

            m_Settings = s;
            m_Title = SyllographTDSearch.kTitle; ;
            m_GI = m_Settings.GraphemeInventory;
            m_PSTable = m_Settings.PSTable;
            m_ViewParaSentWord = m_Settings.OptionSettings.ViewParaSentWord;
            m_DefaultFont = m_Settings.OptionSettings.GetDefaultFont();
        }

        public string Syllograph
        {
            get { return m_Syllograph; }
            set { m_Syllograph = value; }
        }

        public SyllographFeatures Features
        {
            get { return m_Features; }
            set { m_Features = value; }
        }

        public bool ParaFormat
        {
            get { return m_ParaFormat; }
            set { m_ParaFormat = value; }
        }

        public string Title
        {
            get { return m_Title; }
        }

        public PSTable PSTable
        {
            get { return m_PSTable; }
        }

        public GraphemeInventory GI
        {
            get { return m_GI; }
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
            Grapheme grf = null;
            string strMsg = "";

            FormSyllographTD form = new FormSyllographTD(m_GI, m_DefaultFont, m_Settings.LocalizationTable);
            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.Syllograph = form.Grapheme;
                this.Features = form.Features;
                this.ParaFormat = form.ParaFormat;

                SearchDefinition sd = new SearchDefinition(SearchDefinition.kSyllographTD);
                SearchDefinitionParm sdp = null;
                this.SearchDefinition = sd;

                if (this.Syllograph != "")
                {
                    if (this.GI.IsInInventory(this.Syllograph))
                    {
                        grf = this.GI.GetGrapheme(this.Syllograph);
                        if (grf.IsSyllograph)
                        {
                            sdp = new SearchDefinitionParm(SyllographTDSearch.kTarget, this.Syllograph);
                            sd.AddSearchParm(sdp);
                            m_Title = m_Title + " - [" + this.Syllograph + "]";
                            if (this.ParaFormat)
                            {
                                sdp = new SearchDefinitionParm(SyllographTDSearch.kParaFormat);
                                sd.AddSearchParm(sdp);
                            }
                            this.SearchDefinition = sd;
                            flag = true;
                        }
                    }
                    //else MessageBox.Show("Syllograph is not in grapheme Inventory");
                    else
                    {
                        strMsg = m_Settings.LocalizationTable.GetMessage("SyllographSearchTD1");
                        if (strMsg == "")
                            strMsg = "Syllograph is not in grapheme Inventory";
                        MessageBox.Show(strMsg);
                    }
                }
                else if (this.Features != null)
                {
                    if (this.Features.CategoryPrimary != "")
                    {
                        sdp = new SearchDefinitionParm(SyllographTDSearch.kCatPrimary, this.Features.CategoryPrimary);
                        sd.AddSearchParm(sdp);
                    }
                    if (this.Features.CategorySecondary != "")
                    {
                        sdp = new SearchDefinitionParm(SyllographTDSearch.kCatSecondary, this.Features.CategorySecondary);
                        sd.AddSearchParm(sdp);
                    }
                    if (this.Features.CategoryTertiary != "")
                    {
                        sdp = new SearchDefinitionParm(SyllographTDSearch.kCatTertiary, this.Features.CategoryTertiary);
                        sd.AddSearchParm(sdp);
                    }
                    if (this.ParaFormat)
                    {
                        sdp = new SearchDefinitionParm(SyllographTDSearch.kParaFormat);
                        sd.AddSearchParm(sdp);
                    }
                    this.SearchDefinition = sd;
                    flag = true;
                }
                //else MessageBox.Show("Syllograph or features must be specified");
                else
                {
                    strMsg = m_Settings.LocalizationTable.GetMessage("SyllographSearchTD2");
                    if (strMsg == "")
                        strMsg = "Syllograph or features must be specified";
                    MessageBox.Show(strMsg);
                }
            }
            return flag;
        }

        public bool SetupSearch(SearchDefinition sd)
        {
            bool fReturn = false;
            string strTag = "";
           
            for (int i = 0; i < sd.SearchParmsCount(); i++)
            {
                strTag = sd.GetSearchParmAt(i).GetTag();
                if (strTag == SyllographTDSearch.kTarget)
                {
                    this.Syllograph = sd.GetSearchParmContent(strTag);
                    fReturn = true;
                }
                if (strTag == SyllographTDSearch.kCatPrimary)
                {
                    if (this.Features == null)
                        this.Features = new SyllographFeatures();
                    this.Features.CategoryPrimary = sd.GetSearchParmContent(strTag);
                    fReturn = true;
                }
                if (strTag == SyllographTDSearch.kCatSecondary)
                {
                    if (this.Features == null)
                        this.Features = new SyllographFeatures();
                    this.Features.CategorySecondary = sd.GetSearchParmContent(strTag);
                    fReturn = true;
                }
                if (strTag == SyllographTDSearch.kCatTertiary)
                {
                    if (this.Features == null)
                        this.Features = new SyllographFeatures(); 
                    this.Features.CategoryTertiary = sd.GetSearchParmContent(strTag);
                    fReturn = true;
                }
                if (strTag == SyllographTDSearch.kParaFormat)
                    this.ParaFormat = true;
            }
            this.SearchDefinition = sd;
            return fReturn;
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
            strText += Search.TagOpener + Search.TagForwardSlash + strSN
                + Search.TagCloser;
            return strText;
        }

        public SyllographTDSearch ExecuteSyllographSearch(TextData td)
        {
            if (this.ParaFormat)
                ExecuteSyllographSearchP(td);
            else ExecuteSyllographSearchL(td);
            return this;
        }

        private SyllographTDSearch ExecuteSyllographSearchP(TextData td)
        {
            Paragraph para = null;
            Sentence sent = null;
            Word wrd = null;
            string strRslt = "";
            string str = "";
            int nCount = 0;
            int nPara = td.ParagraphCount();
            str = m_Settings.LocalizationTable.GetMessage("SyllagraphSearchTD3");
            if (str == "")
                str = "Processing Syllograph Search";
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
                            string strGrapheme = this.Syllograph;
                            if (strGrapheme != "")
                            {
                                if (wrd.ContainInWord(strGrapheme))
                                {
                                    strRslt += Constants.kHCOn + wrd.DisplayWord
                                        + Constants.kHCOff + Constants.Space;
                                    nCount++;
                                }
                                else strRslt += wrd.DisplayWord + Constants.Space;
                            }
                            else if (this.Features != null)
                            {
                                if (this.FeatureMatchesWord(wrd))
                                {
                                    strRslt += Constants.kHCOn + wrd.DisplayWord
                                       + Constants.kHCOff + Constants.Space;
                                    nCount++;
                                }
                                else strRslt += wrd.DisplayWord + Constants.Space;
                            }
                            else strRslt += wrd.DisplayWord + Constants.Space;
                        }
                    }
                    strRslt = strRslt.Substring(0, strRslt.Length - 1); 	//get ride of last space
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

        private SyllographTDSearch ExecuteSyllographSearchL(TextData td)
        {
            Paragraph para = null;
            Sentence sent = null;
            Word wrd = null;
            int nCount = 0;
            int nPara = td.ParagraphCount();
            string strRslt = "";
            string str = "";
            int nTmp = 0;
            str = m_Settings.LocalizationTable.GetMessage("SyllagraphSearchTD3");
            if (str == "")
                str = "Processing Syllograph Search";
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
                            string strGrapheme = this.Syllograph;
                            if (strGrapheme != "")
                            {
                                if (wrd.ContainInWord(strGrapheme))
                                {
                                    if (this.ViewParaSentWord)
                                    {
                                        nTmp = i + 1;
                                        strRslt += TextData.kPara + Search.Colon + nTmp.ToString().PadLeft(4);
                                        strRslt += SyllographTDSearch.kSeparator;
                                        nTmp = j + 1;
                                        strRslt += TextData.kSent + Search.Colon + nTmp.ToString().PadLeft(4);
                                        strRslt += SyllographTDSearch.kSeparator;
                                        nTmp = k + 1;
                                        strRslt += TextData.kWord + Search.Colon + nTmp.ToString().PadLeft(4);
                                        strRslt += SyllographTDSearch.kSeparator;
                                    }
                                    strRslt += wrd.DisplayWord;
                                    strRslt += Environment.NewLine;
                                    nCount++;
                                }
                            }
                            else if (this.Features != null)
                            {
                                if (this.FeatureMatchesWord(wrd))
                                {
                                    if (this.ViewParaSentWord)
                                    {
                                        nTmp = i + 1;
                                        strRslt += TextData.kPara + Search.Colon + nTmp.ToString().PadLeft(4);
                                        strRslt += SyllographTDSearch.kSeparator;
                                        nTmp = j + 1;
                                        strRslt += TextData.kSent + Search.Colon + nTmp.ToString().PadLeft(4);
                                        strRslt += SyllographTDSearch.kSeparator;
                                        nTmp = k + 1;
                                        strRslt += TextData.kWord + Search.Colon + nTmp.ToString().PadLeft(4);
                                        strRslt += SyllographTDSearch.kSeparator;
                                    }
                                    strRslt += wrd.DisplayWord;
                                    strRslt += Environment.NewLine;
                                    nCount++;
                                }
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

        public bool FeatureMatchesWord(Word wrd)
        {
            bool flag = false;
            Grapheme grf = null;
            Syllograph syllograph = null;
            SyllographFeatures sf = this.Features;

            if (wrd != null)
            {
                for (int i = 0; i < wrd.GraphemeCount(); i++)
                {
                    bool fMatch = false;
                    int ndx = 0;
                    grf = wrd.GetGrapheme(i);
                    if (grf != null)
                    {
                        if (grf.IsSyllograph)
                        {
                            ndx = this.GI.FindSyllographIndex(grf.Symbol);
                            if (ndx >= 0)
                            {
                                syllograph = this.GI.GetSyllograph(ndx);
                                if (syllograph.MatchesFeatures(sf))
                                    fMatch = true;
                            }
                            if (fMatch)
                            {
                                flag = true;
                                break;
                            }
                        }
                    }
                }
            }
            return flag;
        }

    }
}

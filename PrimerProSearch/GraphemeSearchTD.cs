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
    /// Grapheme Search in Text Data
    /// </summary>
    public class GraphemeSearchTD : Search
    {
        //Search parameters 
        private ArrayList m_Graphemes;	    //graphemes to be searched
        private bool m_ParaFormat;  	    //how to display the results
        private bool m_UseGraphemesTaught;  //restrict to graphemes taught
        private bool m_NoDuplicates;        // do not display duplicate words

        private string m_Title;			    //Search title
        private Settings m_Settings;        //Application Settings
        private GraphemeInventory m_GI;     //Grapheme inventory
        private GraphemeTaughtOrder m_GTO;  //Graphemes Taught
        private Font m_DefaultFont;         //Default Font
        private Color m_HighlightColor;     //Highlight Color
        private bool m_ViewParaSentWord;    //Flag for viewing ParaSentWord number

        //Search Definition tags
        private const string kTarget = "target";
        private const string kGrapheme = "grapheme";
 		private const string kParaFormat = "paraformat";
        private const string kUseGraphemesTaught = "UseGraphemesTaught";
        private const string kNoDuplicates = "noduplicates";

        //private const string kTitle = "Grapheme Search";
        private const string kSearch = "Processing Grapheme Search";
        private const string kSeparator = Constants.Tab;


        public GraphemeSearchTD(int number, Settings s)
            : base(number, SearchDefinition.kGraphemeTD)
		{
			m_Graphemes = null;
            m_ParaFormat = false;
            m_UseGraphemesTaught = false;
            m_NoDuplicates = false;
            m_Settings = s;
            m_Title = m_Settings.LocalizationTable.GetMessage("GraphemeTDSearchT");
            if (m_Title == "")
                m_Title = "Grapheme Search from Text Data";
            m_GI =  m_Settings.GraphemeInventory;
            m_GTO = m_Settings.GraphemesTaught;
            m_DefaultFont = m_Settings.OptionSettings.GetDefaultFont();
            m_HighlightColor = m_Settings.OptionSettings.HighlightColor;
            m_ViewParaSentWord = m_Settings.OptionSettings.ViewParaSentWord;
		}

		public GraphemeSearchTD(string strGrfs, Settings s) : base(0, SearchDefinition.kGraphemeTD)
		{
            m_Graphemes = Funct.ConvertStringToArrayList(strGrfs, Constants.Space.ToString());
            m_ParaFormat = false;
            m_NoDuplicates = false;
            m_Settings = s;
            m_Title = m_Settings.LocalizationTable.GetMessage("GraphemeTDSearchT");
            if (m_Title == "")
                m_Title = "Grapheme Search from Text Data";
            m_GI = m_Settings.GraphemeInventory;
            m_GTO = m_Settings.GraphemesTaught;
            m_DefaultFont = m_Settings.OptionSettings.GetDefaultFont();
            m_HighlightColor = m_Settings.OptionSettings.HighlightColor;
            m_ViewParaSentWord = m_Settings.OptionSettings.ViewParaSentWord;
        }

        public ArrayList Graphemes
		{
            get { return m_Graphemes; }
            set { m_Graphemes = value; }
		}

        public bool ParaFormat
        {
            get { return m_ParaFormat; }
            set { m_ParaFormat = value; }
        }

        public bool UseGraphemeTaught
        {
            get { return m_UseGraphemesTaught; }
            set { m_UseGraphemesTaught = value; }
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

        public GraphemeTaughtOrder GTO
        {
            get { return m_GTO; }
        }

        public Font DefaultFont
        {
            get { return m_DefaultFont; }
        }

        public Color HightlightColor
        {
            get { return m_HighlightColor; }
        }

        public bool ViewParaSentWord
        {
            get { return m_ViewParaSentWord; }
        }
 
        public bool SetupSearch()
        {
            bool flag = false;
            string strMsg = "";
            //FormGraphemeTD fpb = new FormGraphemeTD(this.DefaultFont);
            FormGraphemeTD form = new FormGraphemeTD(m_DefaultFont, m_GI,
                m_Settings.LocalizationTable, m_Settings.OptionSettings.UILanguage);
            DialogResult dr;
            dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.Graphemes = form.Graphemes;
                this.ParaFormat = form.ParaFormat;
                this.UseGraphemeTaught = form.UseGraphemesTaught;
                this.NoDuplicates = form.NoDuplicates;

                
                if (this.Graphemes != null)
                {
                    SearchDefinition sd = new SearchDefinition(SearchDefinition.kGraphemeTD);
                    SearchDefinitionParm sdp = null;
                    this.SearchDefinition = sd;
                    m_Title = m_Title + " - [" + Funct.ConvertArrayListToString(this.Graphemes, Constants.Space.ToString()) + "]";

                    string strSym =  "";
                    string strGrfs = "";
                    for (int i = 0; i < this.Graphemes.Count; i++)
                    {
                        strSym = this.Graphemes[i].ToString();
                        sdp = new SearchDefinitionParm(GraphemeSearchTD.kGrapheme, strSym);
                        sd.AddSearchParm(sdp);
                        strGrfs += strSym + Constants.Space;
                    }

                    if (this.ParaFormat)
                    {
                        sdp = new SearchDefinitionParm(GraphemeSearchTD.kParaFormat);
                        sd.AddSearchParm(sdp);
                    }
                    if (this.UseGraphemeTaught)
                    {
                        sdp = new SearchDefinitionParm(GraphemeSearchTD.kUseGraphemesTaught);
                        sd.AddSearchParm(sdp);
                    }
                    if (this.NoDuplicates)
                    {
                        sdp = new SearchDefinitionParm(GraphemeSearchTD.kNoDuplicates);
                        sd.AddSearchParm(sdp);
                    }
                    this.SearchDefinition = sd;
                    flag = true;
                }
                //else MessageBox.Show("Grapheme must be specified");
                else
                {
                    strMsg = m_Settings.LocalizationTable.GetMessage("GraphemeTDSearch2");
                    if (strMsg == "")
                        strMsg = "Grapheme must be specified";
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
            string strGrfs = "";
            ArrayList alG = new ArrayList();

            for (int i = 0; i < sd.SearchParmsCount(); i++)
            {
                strTag = sd.GetSearchParmAt(i).GetTag();
                strContent = sd.GetSearchParmAt(i).GetContent();
                if (strTag == GraphemeSearchTD.kGrapheme)
                {
                    alG.Add(strContent);
                    strGrfs = strContent + Constants.Space;
                    flag = true;
                }
                if (strTag == GraphemeSearchTD.kParaFormat)
                    this.ParaFormat = true;
                if (strTag == GraphemeSearchTD.kUseGraphemesTaught)
                    this.UseGraphemeTaught = true;
                if (strTag == GraphemeSearchTD.kNoDuplicates)
                    this.NoDuplicates = true;
            }
            this.Graphemes = alG;
            m_Title = m_Title + " - [" + strGrfs.Trim() + "]";
            this.SearchDefinition = sd;
            return flag;
        }

        public string BuildResults()
        {
            string strText = "";
            string strSN = "";
            string str = "";
            if (this.SearchNumber > 0)
            {
                strSN = Search.TagSN + this.SearchNumber.ToString().Trim();
                strText += Search.TagOpener + strSN + Search.TagCloser + Environment.NewLine;
            }
            strText += this.Title + Environment.NewLine + Environment.NewLine;
            strText += this.SearchResults;
            strText += Environment.NewLine;
            //strText += this.SearchCount.ToString() + " entries found" + Environment.NewLine;
            str = m_Settings.LocalizationTable.GetMessage("Search2");
            if (str == "")
                str = " entries found";
            strText += this.SearchCount.ToString() + Constants.Space + str + Environment.NewLine;
            if (this.SearchNumber > 0)
                strText += Search.TagOpener + Search.TagForwardSlash + strSN
                    + Search.TagCloser;
            return strText;
        }

        public GraphemeSearchTD ExecuteGraphemeSearch(TextData td)
        {
            if (this.ParaFormat)
                ExecuteGraphemeSearchP(td);
            else ExecuteGraphemeSearchL(td);
            return this;
        }

        private GraphemeSearchTD ExecuteGraphemeSearchP(TextData td)
        {
            ArrayList alGraphemes = this.Graphemes;
            bool fUseGraphemesTaught = this.UseGraphemeTaught;
            ArrayList alGTO = new ArrayList();
            if (this.GTO != null)
                alGTO = this.GTO.Graphemes;
            int nCount = 0;
            string strRslt = "";

            Paragraph para = null;
            Sentence sent = null;
            Word wrd = null;
            int nPara = td.ParagraphCount();
            FormProgressBar form = new FormProgressBar(GraphemeSearchTD.kSearch);
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
                        if (fUseGraphemesTaught)
                        {
                            if ((wrd.IsBuildableWord(alGTO)) && (wrd.ContainInWord(alGraphemes)))
                            {
                                nCount++;
                                strRslt += Constants.kHCOn + wrd.DisplayWord
                                    + Constants.kHCOff + Constants.Space;
                            }
                            else strRslt += wrd.DisplayWord + Constants.Space;
                        }
                        else
                        {
                            if (wrd.ContainInWord(alGraphemes))
                            {
                                nCount++;
                                strRslt += Constants.kHCOn + wrd.DisplayWord
                                    + Constants.kHCOff + Constants.Space;
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
            this.SearchResults = strRslt;
            this.SearchCount = nCount;
            form.Close();
            return this;
        }

        private GraphemeSearchTD ExecuteGraphemeSearchL(TextData td)
        {
            ArrayList alGraphemes = this.Graphemes;
            bool fUseGraphemestaught = this.UseGraphemeTaught;
            ArrayList alGTO = new ArrayList();
            if (this.GTO != null)
                alGTO = this.GTO.Graphemes;
            int nCount = 0;
            string strRslt = "";
            SortedList sl = new SortedList(StringComparer.OrdinalIgnoreCase);

            Paragraph para = null;
            Sentence sent = null;
            Word wrd = null;
            int nTmp = 0;
            int nPara = td.ParagraphCount();
            FormProgressBar form = new FormProgressBar(GraphemeSearchTD.kSearch);
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
                            if (fUseGraphemestaught)    //restricted to graphemes taught
                            {
                                if ((wrd.IsBuildableWord(alGTO)) && (wrd.ContainInWord(alGraphemes)))
                                {
                                    if (this.NoDuplicates)
                                    {
                                        if (!sl.Contains(wrd.DisplayWord))
                                        {
                                            found = true;
                                            sl.Add(wrd.DisplayWord, wrd);
                                        }
                                    }
                                    else found = true;
                                }

                                if (found)
                                {
                                    if (this.ViewParaSentWord)
                                    {
                                        nTmp = i + 1;
                                        strRslt += TextData.kPara + Search.Colon + nTmp.ToString().PadLeft(4);
                                        strRslt += GraphemeSearchTD.kSeparator;
                                        nTmp = j + 1;
                                        strRslt += TextData.kSent + Search.Colon + nTmp.ToString().PadLeft(4);
                                        strRslt += GraphemeSearchTD.kSeparator;
                                        nTmp = k + 1;
                                        strRslt += TextData.kWord + Search.Colon + nTmp.ToString().PadLeft(4);
                                        strRslt += GraphemeSearchTD.kSeparator;
                                    }
                                    strRslt += wrd.DisplayWord;
                                    strRslt += Environment.NewLine;
                                    nCount++;
                                }
                            }
                            else  //no restriction to graphemes taught
                            {
                                if (wrd.ContainInWord(alGraphemes))
                                {
                                    if (this.NoDuplicates)
                                    {
                                        if (!sl.Contains(wrd.DisplayWord))
                                        {
                                            found = true;
                                            sl.Add(wrd.DisplayWord, wrd);
                                        }                                   }
                                    else found = true;

                                    if (found)
                                    {
                                        if (this.ViewParaSentWord)
                                        {
                                            nTmp = i + 1;
                                            strRslt += TextData.kPara + Search.Colon + nTmp.ToString().PadLeft(4);
                                            strRslt += GraphemeSearchTD.kSeparator;
                                            nTmp = j + 1;
                                            strRslt += TextData.kSent + Search.Colon + nTmp.ToString().PadLeft(4);
                                            strRslt += GraphemeSearchTD.kSeparator;
                                            nTmp = k + 1;
                                            strRslt += TextData.kWord + Search.Colon + nTmp.ToString().PadLeft(4);
                                            strRslt += GraphemeSearchTD.kSeparator;
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
            }
            this.SearchResults = strRslt;
            this.SearchCount = nCount;
            form.Close();
            return this;
        }

    }
}

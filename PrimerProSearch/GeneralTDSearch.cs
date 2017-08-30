using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using PrimerProForms;
using PrimerProObjects;
using GenLib;

namespace PrimerProSearch
/// <summary>
/// Genwral search in Text Data
/// </summary>
{
    public class GeneralTDSearch : Search
    {
        //Search parameters 
        private bool m_IsIdenticalVowelsInWord;
        private string m_WordCVShape;
        private int m_MinSyllables;
        private int m_MaxSyllables;
        private bool m_ParaFormat;  	    //how to display the results
        private bool m_UseGraphemesTaught;  //restrict to graphemes taught
        private bool m_NoDuplicates;        // do not display duplicate words

        private string m_Title;			    //Search title
        private Settings m_Settings;        //Application Settings
        private GraphemeInventory m_GI;     //Grapheme Inventory
        private GraphemeTaughtOrder m_GTO;  //Graphemes Taught
        private Font m_DefaultFont;         //Default Font
        private Color m_HighlightColor;     //Highlight Color
        private bool m_ViewParaSentWord;    //Flag for viewing ParaSentWord number

        // Search Defintion tags
        private const string kTitle = "General Search";
        private const string kSearch = "Processing General Search";
        private const string kSeparator = Constants.Tab;
        private const string kIdenticalVowels = "IdenticalVowels";
        private const string kCVShape = "CVShape";
        private const string kMinSyllables = "MinSyll";
        private const string kMaxSyllables = "MaxSyll";
        private const string kParaFormat = "ParaFormat";
        private const string kUseGraphemesTaught = "UseGraphemesTaught";
        private const string kNoDuplicates = "NoDup";

        public GeneralTDSearch(int number, Settings s)
            : base(number, SearchDefinition.kGeneralTD)
        {
            m_IsIdenticalVowelsInWord = false;
            m_WordCVShape = "";
            m_MinSyllables = 0;
            m_MaxSyllables = 0;
            m_ParaFormat = false;
            m_UseGraphemesTaught = false;
            m_NoDuplicates = false;

            m_Settings = s;
            m_Title = "General Search";
            m_Title = m_Settings.LocalizationTable.GetMessage("GeneralSearchT",
                m_Settings.OptionSettings.UILanguage);
            m_GI = m_Settings.GraphemeInventory;
            m_GTO = m_Settings.GraphemesTaught;
            m_DefaultFont = m_Settings.OptionSettings.GetDefaultFont();
            m_HighlightColor = m_Settings.OptionSettings.HighlightColor;
            m_ViewParaSentWord = m_Settings.OptionSettings.ViewParaSentWord;
       }

        public bool IsIdenticalVowelsInWord
        {
            get { return m_IsIdenticalVowelsInWord; }
            set { m_IsIdenticalVowelsInWord = value; }
        }

        public string WordCVShape
        {
            get { return m_WordCVShape; }
            set { m_WordCVShape = value; }
        }

        public int MinSyllables
        {
            get { return m_MinSyllables; }
            set { m_MinSyllables = value; }
        }

        public int MaxSyllables
        {
            get { return m_MaxSyllables; }
            set { m_MaxSyllables = value; }
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

        public bool ViewParaSentWord
        {
            get { return m_ViewParaSentWord; }
            set { m_ViewParaSentWord = value; }
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

        public Color HighlightColor
        {
            get { return m_HighlightColor; }
        }

        public Font DefaultFont
        {
            get { return m_DefaultFont; }
        }

        public bool SetupSearch()
        {
            bool flag = false;
            FormGeneralTD form = new FormGeneralTD(m_Settings, m_Settings.LocalizationTable, m_Settings.OptionSettings.UILanguage);
            form.Text = m_Settings.LocalizationTable.GetMessage("GeneralSearchT",
                m_Settings.OptionSettings.UILanguage);
            DialogResult dr;
            dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.IsIdenticalVowelsInWord = form.IsIdenticalVowelsInWord;
                this.WordCVShape = form.WordCVShape;
                this.MinSyllables = form.MinSyllables;
                this.MaxSyllables = form.MaxSyllables;
                this.ParaFormat = form.ParaFormat;
                this.UseGraphemeTaught = form.UseGraphemesTaught;
                this.NoDuplicates = form.NoDuplicates;
 
                SearchDefinition sd = new SearchDefinition(SearchDefinition.kGeneralTD);
                SearchDefinitionParm sdp = null;
                this.SearchDefinition = sd;

                if (this.IsIdenticalVowelsInWord)
                {
                    sdp = new SearchDefinitionParm(GeneralTDSearch.kIdenticalVowels);
                    sd.AddSearchParm(sdp);
                }
                if (this.WordCVShape != "")
                {
                    sdp = new SearchDefinitionParm(GeneralTDSearch.kCVShape, this.WordCVShape);
                    sd.AddSearchParm(sdp);
                }
                if (this.MinSyllables > 0)
                {
                    sdp = new SearchDefinitionParm(GeneralTDSearch.kMinSyllables, this.MinSyllables.ToString().Trim());
                    sd.AddSearchParm(sdp);
                }
                if (this.m_MaxSyllables > 0)
                {
                    sdp = new SearchDefinitionParm(GeneralTDSearch.kMaxSyllables, this.m_MaxSyllables.ToString().Trim());
                    sd.AddSearchParm(sdp);
                }
                if (this.ParaFormat)
                {
                    sdp = new SearchDefinitionParm(GeneralTDSearch.kParaFormat);
                    sd.AddSearchParm(sdp);
                }
                if (this.UseGraphemeTaught)
                {
                    sdp = new SearchDefinitionParm(GeneralTDSearch.kUseGraphemesTaught);
                    sd.AddSearchParm(sdp);
                }
                if (this.NoDuplicates)
                {
                    sdp = new SearchDefinitionParm(GeneralTDSearch.kNoDuplicates);
                    sd.AddSearchParm(sdp);
                }
                this.SearchDefinition = sd;
                flag = true;
            }
            return flag;
        }

        public bool SetupSearch(SearchDefinition sd)
        {
            bool flag = true;
            string strTag = "";
            string strContent = "";

            this.SearchDefinition = sd;
            ArrayList alG = new ArrayList();
            ArrayList alH = new ArrayList();

            for (int i = 0; i < sd.SearchParmsCount(); i++)
            {
                strTag = sd.GetSearchParmAt(i).GetTag();
                strContent = sd.GetSearchParmAt(i).GetContent();
                if (strTag == GeneralTDSearch.kIdenticalVowels)
                    this.IsIdenticalVowelsInWord = true;
                if (strTag == GeneralTDSearch.kCVShape)
                    this.WordCVShape = strContent;
                if (strTag == GeneralTDSearch.kMinSyllables)
                    this.MinSyllables = Convert.ToInt16(strContent);
                if (strTag == GeneralTDSearch.kMaxSyllables)
                    this.MaxSyllables = Convert.ToInt16(strContent);
                if (strTag == GeneralTDSearch.kParaFormat)
                    this.ParaFormat = true;
                if (strTag == GeneralTDSearch.kUseGraphemesTaught)
                    this.UseGraphemeTaught = true;
                if (strTag == GeneralTDSearch.kNoDuplicates)
                    this.NoDuplicates = true;
            }
            this.SearchDefinition = sd;
            return flag;
        }

        public string BuildResults()
        {
            string strText = "";
            string strSN = "";
            if (this.SearchNumber > 0)
            {
                strSN = Search.TagSN + this.SearchNumber.ToString().Trim();
                strText += Search.TagOpener + strSN + Search.TagCloser + Environment.NewLine;
            }
            strText += this.Title + Environment.NewLine + Environment.NewLine;
            strText += this.SearchResults;
            strText += Environment.NewLine;
            strText += this.SearchCount.ToString();
            //strText += " entries found" + Environment.NewLine;
            strText += Constants.Space + m_Settings.LocalizationTable.GetMessage("Search2",
                m_Settings.OptionSettings.UILanguage) + Environment.NewLine;
            if (this.SearchNumber > 0)
                strText += Search.TagOpener + Search.TagForwardSlash + strSN
                    + Search.TagCloser;
            return strText;
        }

        public GeneralTDSearch ExecuteGeneralSearch(TextData td)
        {
            if (this.ParaFormat)
                ExecuteGeneralSearchP(td);
            else ExecuteGeneralSearchL(td);
            return this;
        }

        private GeneralTDSearch ExecuteGeneralSearchP(TextData td)
        {
            bool fIsIdenticalVowelsInWord = this.IsIdenticalVowelsInWord;
            string strWordCVShape = this.WordCVShape;
            int nMinSyllables = this.MinSyllables;
            int nMaxsyllables = this.MaxSyllables;
            bool fParaFormat = this.ParaFormat;
            bool fUseGraphemestaught = this.UseGraphemeTaught;
            bool FNoDuplicates = this.NoDuplicates;

            ArrayList alGTO = new ArrayList();
            if (this.GTO != null)
                alGTO = this.GTO.Graphemes;
            int nCount = 0;
            string strRslt = "";

            Paragraph para = null;
            Sentence sent = null;
            Word wrd = null;
            //int nTmp = 0;
            int nPara = td.ParagraphCount();
            FormProgressBar form = new FormProgressBar(GeneralTDSearch.kSearch);
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
                            if (this.MatchesWord(wrd))
                            {
                                found = true;
                                if (fUseGraphemestaught)
                                {
                                    if (!wrd.IsBuildableWord(alGTO))
                                        found = false; ;
                                }
                            }
                            else found = false;

                            if (found)
                            {
                                nCount++;
                                strRslt += Constants.kHCOn + wrd.DisplayWord + Constants.kHCOff + Constants.Space;
                            }
                            else strRslt += wrd.DisplayWord + Constants.Space;
                        }
                    }
                    strRslt = strRslt.Substring(0, strRslt.Length - 1) + sent.EndingPunctuation +Constants.Space;
                }
                strRslt += Environment.NewLine + Environment.NewLine;
            }
            this.SearchResults = strRslt;
            this.SearchCount = nCount;
            form.Close();
            return this;
        }

        private GeneralTDSearch ExecuteGeneralSearchL(TextData td)
        {
            bool fIsIdenticalVowelsInWord = this.IsIdenticalVowelsInWord;
            string strWordCVShape = this.WordCVShape;
            int nMinSyllables = this.MinSyllables;
            int nMaxsyllables = this.MaxSyllables;
            bool fParaFormat = this.ParaFormat;
            bool fUseGraphemestaught = this.UseGraphemeTaught;
            bool FNoDuplicates = this.NoDuplicates;

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
            FormProgressBar form = new FormProgressBar(GeneralTDSearch.kSearch);
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
                            if (this.MatchesWord(wrd))
                            {
                                found= true;
                                if (fUseGraphemestaught)
                                {
                                    if (!wrd.IsBuildableWord(alGTO))
                                        found = false;;
                                }
                                if (this.NoDuplicates)
                                {
                                    if (sl.Contains(wrd.DisplayWord))
                                        found = false;
                                    else sl.Add(wrd.DisplayWord, wrd);
                                }
                            }
                            else found = false;
                            
                            if (found)
                            {
                                if (this.ViewParaSentWord)
                                {
                                    nTmp = i + 1;
                                    strRslt += TextData.kPara + Search.Colon + nTmp.ToString().PadLeft(4);
                                    strRslt += GeneralTDSearch.kSeparator;
                                    nTmp = j + 1;
                                    strRslt += TextData.kSent + Search.Colon + nTmp.ToString().PadLeft(4);
                                    strRslt += GeneralTDSearch.kSeparator;
                                    nTmp = k + 1;
                                    strRslt += TextData.kWord + Search.Colon + nTmp.ToString().PadLeft(4);
                                    strRslt += GeneralTDSearch.kSeparator;
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

        private bool MatchesWord(Word wrd)
        {
            bool flag = true;
            if (this.IsIdenticalVowelsInWord)
            {
                if (!wrd.IsSameVowel())
                    flag = false;
            }
            if (this.WordCVShape != "")
            {
                if (this.WordCVShape != wrd.GetCVShapeOfWord())
                    flag = false;
            }
            if (this.MinSyllables > 0)
            {
                if (this.MinSyllables > wrd.SyllableCount())
                    flag = false;
            }

            if (this.MaxSyllables > 0)
            {
                if (this.MaxSyllables < wrd.SyllableCount())
                    flag = false;
            }
            return flag;
        }
    }
}

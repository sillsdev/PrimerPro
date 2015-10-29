using System;
using System.Windows.Forms;
using System.Collections;
using System.Data;
using System.Drawing;
using StandardFormatLib;
using System.Xml;
using System.Xml.Xsl;
using GenLib;

namespace PrimerProObjects
{
	/// <summary>
	/// Word List
	/// </summary>
	/// 

	public class WordList 
	{
		private Settings m_Settings;
		private OptionList m_OptionList;
        private SortedList m_WordsSorted;       //SortedList of Words
        private bool m_Merged;
        private string m_FileName;
        private FileType m_Type;
        private StandardFormatFile m_SFFile;

        // Headings for Wordlist
        //public const string kWord = "Word";
        //public const string kGloss = "Gloss";
        //public const string kOrigWord = "Original";
        //public const string kPS = "PS";
        //public const string kRoot = "Root";
        //public const string kPlural = "Plural";
        //public const string kCVPattern = "CV Pattern";
        //public const string kSyllBreaks = "Syllables";
        //public const string kWordNoTone = "Word w/o Tone";
        //public const string kRootNoTone = "Root w/o Tone";
        //public const string kRootCVPattern = "Root CV Patt";
        //public const string kRootSyllBreaks = "Root Syll";

        public enum FileType { None, StandardFormat, Lift };
        public const string kMergeWordList = "<Merged>";
        public const char kKeepOriginal = 'K';
        public const char kReplaceOriginal ='R';
        public const char kKeepBoth = 'B';
        public const char kAskMe = 'A';

        //private const string kLoad = "Loading Word List";
        //private const string kMerge = "Merging Word List";
        //private const string kSort = "Sorting Word List";

		public WordList()
        {
            m_Settings = null;
            m_OptionList = null;
            m_WordsSorted = new SortedList();
            m_Merged = false;
            m_FileName = "";
            m_Type  = FileType.None;
            m_SFFile = new StandardFormatFile();
        }

        public WordList(Settings s)
		{
			m_Settings = s;
			m_OptionList = m_Settings.OptionSettings;
            m_WordsSorted = new SortedList();
            m_Merged = false;
            m_FileName = "";
            m_Type = FileType.None;
            m_SFFile = new StandardFormatFile();
        }

        public SortedList WordsSorted
        {
            get { return m_WordsSorted; }
            set { m_WordsSorted = value; }
        }

        public bool Merged
        {
            get { return m_Merged; }
        }

        public string FileName
        {
            get { return m_FileName; }
            set { m_FileName = value; }
        }

        public FileType Type
        {
            get { return m_Type; }
            set { m_Type = value; }
        }

        public StandardFormatFile SFFile
        {
            get { return m_SFFile; }
            set { m_SFFile = value; }
        }

        public void AddWord(Word wrd)
        {
            string strKey = wrd.Key;
            if (this.WordsSorted == null)
                this.WordsSorted = new SortedList();
            if (this.WordsSorted.ContainsKey(strKey))     //found duplicate
            {
                int n = 0;
                do
                {
                    n++;
                    strKey = strKey + n.ToString().PadLeft(6,'0');
                }
                while (this.WordsSorted.ContainsKey(strKey));
                wrd.Key = strKey;
                this.WordsSorted.Add(strKey, wrd);
            }
            else this.WordsSorted.Add(strKey, wrd);
        }

        public void DelWord(int n)
		{
            this.WordsSorted.RemoveAt(n);
		}

		public Word GetWord(int n)
		{
            return (Word) this.WordsSorted.GetByIndex(n);
  		}

        public string GetWordKey(int n)
        {
            return (string) this.WordsSorted.GetKey(n);
        }

		public Word GetWord(string strKey)
		{
            int n = FindWordIndex(strKey);
            if (n >= 0)
                return GetWord(n);
            else return null;
   		}

        public Word GetWord2(string strKey)
        {
            Word wrd = null;
            for (int i = 0; i < this.WordCount(); i++)
            {
                wrd = GetWord(i);
                if (wrd.DisplayWord == strKey)
                    break;
                else wrd = null;
            }
            return wrd;
        }

        public int FindWordIndex(string strKey)
        {
            return this.WordsSorted.IndexOfKey(strKey);
        }
        
		public int WordCount()
		{
			if (this.WordsSorted == null )
				return 0;
            else return this.WordsSorted.Count;
		}

	    public WordList LoadSFM(string strFolder)
        {
    		WordList wl = null;
            string strMsg = "";
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "txt files (*.txt)|*.txt|All Files (*.*)|*.*";
			ofd.FileName = "";
			ofd.DefaultExt = "*.txt";
			ofd.InitialDirectory = strFolder;
			ofd.CheckFileExists = true;
			ofd.CheckPathExists = true;

			DialogResult dr = ofd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                wl = new WordList(m_Settings);
                wl.SFFile = new StandardFormatFile();
                wl.Type = FileType.StandardFormat;
                wl.FileName = ofd.FileName;
                wl.SFFile.FileName = ofd.FileName;
                if (wl.SFFile.LoadFile(wl.FileName, m_OptionList.FMRecordMarker))
                {
                    if (wl.SFFile.Count() > 0)
                        wl.LoadWordsFromSF();
                }
                else
                {
                    wl = null;
                    //MessageBox.Show("Invalid or unknown Word List SFM file not imported");
                    strMsg = m_Settings.LocalizationTable.GetMessage("WordList1",
                        m_Settings.OptionSettings.UILanguage);
                    MessageBox.Show(strMsg);
                }
            }
            //else MessageBox.Show("Import cancelled");
            else
            {
                strMsg = m_Settings.LocalizationTable.GetMessage("WordList2",
                    m_Settings.OptionSettings.UILanguage);
                MessageBox.Show(strMsg);
            }
            return wl;
		}

        public WordList LoadSFMFromFile(string strFileName)
        {
            string strMsg = "";
            WordList wl = new WordList(m_Settings);;
            
            wl.SFFile = new StandardFormatFile();
            wl.Type = FileType.StandardFormat;
            wl.FileName = strFileName;
            wl.SFFile.FileName = strFileName;
            if (wl.SFFile.LoadFile(wl.FileName, m_OptionList.FMRecordMarker))
            {
                if (wl.SFFile.Count() > 0)
                    wl.LoadWordsFromSF();
            }
            else
            {
                wl = null;
                //MessageBox.Show("Invalid or unknown Word List SFM file not imported");
                strMsg = m_Settings.LocalizationTable.GetMessage("WordList1",
                    m_Settings.OptionSettings.UILanguage);
                MessageBox.Show(strMsg);
            }
            return wl;
        }
        
        public WordList LoadLIFT(string strFolder)
        {
            WordList wl = null;
            string strMsg = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "lift files (*.lift)|*.lift|All Files (*.*)|*.*";
            ofd.FileName = "";
            ofd.DefaultExt = "*.lift";
            ofd.InitialDirectory = strFolder;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;

            DialogResult dr = ofd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                wl = new WordList(m_Settings);
                wl.Type = FileType.Lift;
                wl.FileName = ofd.FileName;
                wl = wl.LoadWordsFromLift();
                if (wl.WordCount() < 1)
                {
                    //MessageBox.Show("No valid words in LIFT file");
                    strMsg = m_Settings.LocalizationTable.GetMessage("WordList3",
                        m_Settings.OptionSettings.UILanguage);
                    MessageBox.Show(strMsg);
                    wl = null;
                }
            }
            else
            {
                //MessageBox.Show("Import cancelled");
                strMsg = m_Settings.LocalizationTable.GetMessage("WordList2",
                    m_Settings.OptionSettings.UILanguage);
                MessageBox.Show(strMsg);
            }
            return wl;
        }

        public WordList LoadLIFTFromFile(string strFileName)
        {
            string strMsg = "";
            WordList wl = new WordList(m_Settings); ;
            wl.Type = FileType.StandardFormat;
            wl.FileName = strFileName;
            wl =  wl.LoadWordsFromLift();
            if (wl.WordCount() < 1)
            {
                //MessageBox.Show("No valid words in LIFT file");
                strMsg = m_Settings.LocalizationTable.GetMessage("WordList3",
                    m_Settings.OptionSettings.UILanguage);
                MessageBox.Show(strMsg);
                wl = null;
            }
            return wl;
        }

        public WordList MergeSF(string strFileName, char chDuplicateProcessing)
        {
            WordList wlSave = this;                     //Save for backup purposes
            WordList wl = new WordList(m_Settings);
            char chAskMeDuplicateProcessing = WordList.kKeepBoth;
            string strDataFolder = m_Settings.OptionSettings.DataFolder;
            string strMsg = "";

            if (strFileName != "")
            {
                wl.SFFile.FileName = strFileName;
                wl.FileName = strFileName;
                if (wl.SFFile.LoadFile(wl.SFFile.FileName, m_OptionList.FMRecordMarker))
                {
                    if (wl.SFFile.Count() > 0)
                        wl.LoadWordsFromSF();
                    this.SFFile.FileName = WordList.kMergeWordList;
                    this.FileName = this.SFFile.FileName;

                    StandardFormatRecord sfr = null;
                    Word wrd = null;
                    Word wrdOrig= null;
                    int ndx = 0;
                    //FormProgressBar formPB = new FormProgressBar(WordList.kMerge);
                    strMsg = m_Settings.LocalizationTable.GetMessage("WordList12", m_Settings.OptionSettings.UILanguage);
                    FormProgressBar formPB = new FormProgressBar(strMsg);
                    formPB.PB_Init(0, wl.WordCount());
                    
                    for (int i = 0; i < wl.WordCount(); i++)
                    {
                        wrd = wl.GetWord(i);
                        sfr = wl.SFFile.GetRecord(wrd.IndexToSFR);
                        wrdOrig = this.GetWord( wrd.Key );
                        formPB.PB_Update(i);
                        switch (chDuplicateProcessing)
                        {
                            case WordList.kKeepOriginal:
                                if (wrdOrig == null)    //if no duplicate
                                {
                                    ndx = this.SFFile.AddRecord(sfr);
                                    wrd.IndexToSFR = ndx;
                                    this.AddWord(wrd);
                                }
                                break;
                            case WordList.kReplaceOriginal:
                                if (wrdOrig != null)    //if duplicate
                                {
                                    this.DelWord(this.FindWordIndex(wrdOrig.Key));
                                    this.SFFile.DelRecord(wrdOrig.IndexToSFR);
                                    this.SFFile.InsertRecord(wrdOrig.IndexToSFR, sfr);
                                    wrd.IndexToSFR = wrdOrig.IndexToSFR;
                                    this.AddWord(wrd);
                                }
                                else                    //no duplicate
                                {
                                    ndx = this.SFFile.AddRecord(sfr);
                                    wrd.IndexToSFR = ndx;
                                    this.AddWord(wrd);
                                }
                                break;
                            case WordList.kKeepBoth:
                                ndx = this.SFFile.AddRecord(sfr);
                                wrd.IndexToSFR = ndx;
                                this.AddWord(wrd);
                                break;
                            case WordList.kAskMe:
                                if (wrdOrig == null)   //if no duplicate
                                {
                                    ndx = this.SFFile.AddRecord(sfr);
                                    wrd.IndexToSFR = ndx;
                                    this.AddWord(wrd);
                                }
                                else                   //yes duplicate
                                {
                                    formPB.Hide();
                                    //FormMergeAskMe form2 = new FormMergeAskMe(wrdOrig, wrd);
                                    FormMergeAskMe form2 = new FormMergeAskMe(wrdOrig, wrd,
                                        m_Settings.LocalizationTable, m_Settings.OptionSettings.UILanguage);
                                    if (form2.ShowDialog() == DialogResult.OK)
                                    {
                                        chAskMeDuplicateProcessing = form2.DuplicateProcesssing;
                                        switch (chAskMeDuplicateProcessing)
                                        {
                                            case WordList.kKeepBoth:
                                                ndx = this.SFFile.AddRecord(sfr);
                                                wrd.IndexToSFR = ndx;
                                                this.AddWord(wrd);
                                                break;
                                            case WordList.kReplaceOriginal:
                                                this.DelWord(this.FindWordIndex(wrdOrig.Key));
                                                this.SFFile.DelRecord(wrdOrig.IndexToSFR);
                                                this.SFFile.InsertRecord(wrdOrig.IndexToSFR, sfr);
                                                wrd.IndexToSFR = wrdOrig.IndexToSFR;
                                                this.AddWord(wrd);
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        m_Merged = false;
                                        formPB.Close();
                                        //MessageBox.Show("Merge terminated by user");
                                        strMsg = m_Settings.LocalizationTable.GetMessage("WordList4",
                                            m_Settings.OptionSettings.UILanguage);
                                        MessageBox.Show(strMsg);
                                        return wlSave;
                                    }
                                    formPB.Show();
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    formPB.Close();
                    m_Merged = true;
                }
                //else MessageBox.Show("Invalid or unknown Word List file");
                else
                {
                    strMsg = m_Settings.LocalizationTable.GetMessage("WordList5",
                      m_Settings.OptionSettings.UILanguage);
                    MessageBox.Show(strMsg);
                }
            }
            return this;
        }

        public bool SaveAs(string strFolder)
		{
			bool fReturn = false;
            string strMsg = "";
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "txt files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (this.FileName == WordList.kMergeWordList)
                sfd.FileName = "";
            else sfd.FileName = this.FileName;
            if (this.Type == FileType.StandardFormat)
            {
                sfd.DefaultExt = "*.txt";
                sfd.InitialDirectory = strFolder;
                sfd.CheckPathExists = true;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    this.SFFile.SaveFile(sfd.FileName);
                    this.SFFile.FileName = sfd.FileName;
                    this.FileName = sfd.FileName;
                    fReturn = true;
                }
            }
            //else MessageBox.Show("Must be standard format word list");
            else
            {
                strMsg = m_Settings.LocalizationTable.GetMessage("WordList6",
                    m_Settings.OptionSettings.UILanguage);
                MessageBox.Show(strMsg);
            }
			return fReturn;
		}

		public WordList LoadWordsFromSF()
		{
            WordList wl = this;
            StandardFormatRecord sfr = null;
			string strWord = "" ;
			string strPS = "";
			string strGE = "";
			string strGN = "";
			string strGR = "";
			string strPL = "";
			string strRoot = "";
			Word wrd = null;
			SortedList sl = new SortedList();
            //FormProgressBar form = new FormProgressBar(kLoad);
            string strMsg = m_Settings.LocalizationTable.GetMessage("WordList11", m_Settings.OptionSettings.UILanguage);
            FormProgressBar form = new FormProgressBar(strMsg);
            form.PB_Init(0, wl.SFFile.Count());

			for (int i = 0; i < wl.SFFile.Count(); i++)
			{
                form.PB_Update(i);
                sfr = wl.SFFile.GetRecord(i);
				strWord  = sfr.GetFieldContents(m_OptionList.FMLexicon);
				strPS = sfr.GetFieldContents(m_OptionList.FMPS);
				strGE = sfr.GetFieldContents(m_OptionList.FMGlossEnglish);
				strGN = sfr.GetFieldContents(m_OptionList.FMGlossNational);
				strGR = sfr.GetFieldContents(m_OptionList.FMGlossRegional);
				strPL = sfr.GetFieldContents(m_OptionList.FMPlural);
				strRoot = sfr.GetFieldContents(m_OptionList.FMRoot);

				wrd = new Word(strWord, strRoot, m_Settings);
				wrd.PartOfSpeech = strPS.ToUpper();
				wrd.GlossEnglish = strGE;
				wrd.GlossNational = strGN;
				wrd.GlossRegional = strGR;
				wrd.Plural = strPL;
                wrd.IndexToSFR = i;     //add index to standard format file
                wl.AddWord(wrd);
  			}
            form.Close();
            return wl;
 		}

        public WordList LoadWordsFromLift()
        {
            //Lift support
            if (m_Settings.OptionSettings.LiftVernacular != "")
            {
                string str = "Be patience. It may take a few minutes to validate and load "
                    + Funct.ShortFileName(this.FileName);
                FormInfo fi = new FormInfo("...Please wait...");
                fi.UpdateMessage(str);
                if (ValidateLIFT(this.FileName))
                {
                    LiftMerger lm = new LiftMerger(this.WordsSorted, m_Settings);
                    LiftIO.Parsing.LiftParser<LiftObject, LiftEntry, LiftSense, LiftExample> parser =
                        new LiftIO.Parsing.LiftParser<LiftObject, LiftEntry, LiftSense, LiftExample>(lm);
                    int cEntries = parser.ReadLiftFile(this.FileName);
                }
                else
                {
                    this.WordsSorted = null;
                    this.m_FileName = "";
                }
                fi.Close();
            }
            //else MessageBox.Show("Vernacular language is not specified for LIFT options");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("WordList7",
                    m_Settings.OptionSettings.UILanguage);
                MessageBox.Show(strMsg);
            }
            return this;
        }

        public ArrayList GetCharactersInWords()
        // returns Arraylist of strings
        {
            ArrayList alChars = new ArrayList();
            Word wrd = null;
            Grapheme grapheme = null;
            string strChar = "";

            for (int i = 0; i < this.WordCount(); i++)
            {
                wrd = this.GetWord(i);
                for (int j = 0; j < wrd.GraphemeCount(); j++)
                {
                    grapheme = wrd.GetGrapheme(j);
                    strChar = grapheme.Symbol;
                    if (!alChars.Contains(strChar))
                    {
                        alChars.Add(strChar);
                    }
                }
            }
            return alChars;
        }

        public GraphemeInventory BuildSyllabaryInventory()
        {
            GraphemeInventory gi = new GraphemeInventory( m_Settings);
            Word wrd = null;
            Grapheme grf = null;
            string strSymbol = "";
            Syllograph syllograph = null;
            for (int i = 0; i < this.WordCount(); i++)
            {
                wrd = this.GetWord(i);
                for (int j = 0; j < wrd.GraphemeCount(); j++)
                {
                    grf = wrd.GetGrapheme(j);
                    strSymbol = grf.Symbol;
                    if (!gi.IsInInventory(strSymbol))
                    {
                        syllograph = new Syllograph(strSymbol);
                        gi.AddSyllograph(syllograph);
                    }
                }
            }
            return gi;
        }

        public SortedList BuildSortedCharacterList()
        // returns SortedList of strings
        {
            SortedList slChars = new SortedList();
            string strWord = "";
            string strChar = "";
            string strKey = "";

            for (int i = 0; i < this.WordCount(); i++)
            {
                strWord = this.GetWord(i).GetWordInLowerCase();
                for (int j = 0; j < strWord.Length; j++)
                {
                    strChar = strWord[j].ToString();
                    //strKey = Convert.ToInt32(strChar).ToString().PadLeft(6, '0');    needs to be char, not string
                    strKey = strChar;
                    if (!slChars.Contains(strChar))
                        slChars.Add(strKey, strChar);
                }
            }
            return slChars;
        }

        public SortedList BuildSortedMultiGraphList(GraphemeInventory gi)
        // This assumes that the grapheme inventory contains only simple graphemes
        // Returns SortedList of Graphemes
        {
            SortedList sl = new SortedList();
            string strWord = "";
            string strChar = "";

            for (int i = 0; i < this.WordCount(); i++)
            {
                string strCurrent = "";
                string strPrevious = "";
                Grapheme grfCurrent = null;
                Grapheme grfPrevious = null;
                Grapheme.GraphemeType gtCurrent = Grapheme.GraphemeType.None;
                Grapheme.GraphemeType gtPrevious = Grapheme.GraphemeType.None;

                strWord = this.GetWord(i).GetWordInLowerCase();
                for (int j = 0; j < strWord.Length; j++)
                {
                    strChar = strWord[j].ToString();
                    if (gi.IsInInventory(strChar))
                    {
                        grfCurrent = gi.GetGrapheme(strChar);
                        strCurrent = grfCurrent.Symbol;
                        if (grfPrevious != null)
                        {
                            gtCurrent = grfCurrent.GetGraphemeType();
                            if (gtCurrent == gtPrevious)
                            {
                                strPrevious = strPrevious + strCurrent;
                                grfPrevious = new Grapheme(strPrevious);
                                grfPrevious.SetGraphemeType(gtPrevious);
                            }
                            else
                            {
                                if (strPrevious.Length > 1)             // only add multigraphs
                                {
                                   if ( !sl.ContainsKey(strPrevious) )
                                       sl.Add(strPrevious, grfPrevious);
                                }
                                strPrevious = strCurrent;
                                grfPrevious = grfCurrent;
                                gtPrevious = grfPrevious.GetGraphemeType();
                            }
                        }
                        else
                        {
                            strPrevious = strCurrent;
                            grfPrevious = grfCurrent;
                            gtPrevious = grfPrevious.GetGraphemeType();
                        }
                    }
                    else
                    {
                        strCurrent = "";
                        grfCurrent = null;
                        gtCurrent = Grapheme.GraphemeType.None;
                        if (strPrevious == "")
                        {
                            grfPrevious = null;
                            gtPrevious = Grapheme.GraphemeType.None;

                        }
                        else
                        {
                            if (strPrevious.Length > 1)
                            {
                                if (!sl.ContainsKey(strPrevious))
                                    sl.Add(strPrevious, grfPrevious);
                            }
                            strPrevious = strCurrent;
                            grfPrevious = grfCurrent;
                            gtPrevious = gtCurrent;
                        }
                    }
                }
                if (strPrevious.Length > 1)             // only add multigraphs
                {
                    if (!sl.ContainsKey(strPrevious))
                        sl.Add(strPrevious, grfPrevious);
                }
            }
            return sl;
        }
        
        public bool ValidateLIFT(string strFilename)
        {
            try
            {
                //LiftIO.Validation.IValidationProgress progress = null; ;
                //LiftIO.Validation.Validator.CheckLiftWithPossibleThrow(strFilename);
                LiftIO.Validation.Validator.CheckLiftWithPossibleThrow(strFilename);
                return true;
            }
            catch (LiftIO.LiftFormatException lfe)
            {
                //MessageBox.Show("NOT A VALID LIFT FILE:  " + lfe.ToString());
                string strMsg = m_Settings.LocalizationTable.GetMessage("WordList8",
                    m_Settings.OptionSettings.UILanguage);
                MessageBox.Show(strMsg + Constants.Space + lfe.ToString());
                return false;
            }
        }

		public bool IsWordInSFR(string strWord)
		{
			bool fReturn = false;
			StandardFormatRecord sfr = null;
			for (int i = 0; i < this.SFFile.Count(); i++)
			{
				sfr = this.SFFile.GetRecord(i);
				if ( sfr.GetFieldContents(m_OptionList.FMLexicon) == strWord )
				{
					fReturn = true;
					break;
				}
			}
			return fReturn;
		}

		public bool IsWordInList(string strWord)
		{
			bool fReturn = false;
			Word  wrd = null;
			for ( int i = 0; i <  this.WordCount(); i++)
			{
				wrd = this.GetWord(i);
				if ( wrd.DisplayWord == strWord )
				{
					fReturn = true;
					break;
				}
			}
			return fReturn;
		}

        public bool IsWordInList(Word wrd1)
        {
            bool fReturn = false;
            Word wrd2 = null;
            for (int i = 0; i < this.WordCount(); i++)
            {
                wrd2 = this.GetWord(i);
                if ( wrd2.IsSame(wrd1) )
                    fReturn = true;
            }
            return fReturn;
        }

		public string GetDisplayLineForWord(int nWord)
		{
			string strLine = "";
            OptionList ol = new OptionList();
            if (m_Settings != null)
    			ol = m_Settings.OptionSettings;
			Word word = this.GetWord(nWord);

			strLine += word.DisplayWord;
			strLine += Constants.Tab;
			strLine += word.GetGloss();
			strLine	+= Constants.Tab;
			if ( ol.ViewOrigWord )
			{
				strLine += word.OrigWord;
                strLine += Constants.Space.ToString();
				strLine += Constants.Tab;
			}
			if ( ol.ViewPS )
			{
				strLine += word.PartOfSpeech;
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
			}
			if ( ol.ViewPlural )
			{
				strLine += word.Plural;
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
			}
			if ( ol.ViewCVPattern )
			{
				strLine += word.CVPattern;
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
			}
			if ( ol.ViewSyllBreaks)
			{
				strLine += word.GetWordWithSyllBreaks();
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
			}
			if (ol.ViewWordWithoutTone)
			{
				strLine += word.GetWordWithoutTone();
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
			}
            if ( ol.ViewRoot  && (word.Root != null) )
            {
                strLine += word.Root.DisplayRoot;
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
            }
            if (ol.ViewRootCVPattern)
            {
                strLine += word.Root.CVPattern;
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
            }
            if (ol.ViewRootSyllBreaks)
            {
                strLine += word.Root.GetRootwithSyllBreaks();
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
            }
            if (ol.ViewRootWithoutTone)
			{
                strLine += Constants.Space.ToString();
                strLine += word.Root.GetRootWithoutTone();
				strLine += Constants.Tab;
			}
			return strLine;
		}

		public string GetDisplayLineForWord(int nWord, string strGrapheme)
		{
			string strLine = "";
            OptionList ol = null;
            if (m_Settings != null)
			    ol = m_Settings.OptionSettings;
			Word word = this.GetWord(nWord);

			strLine += word.GetWordWithHighlightGrapheme(strGrapheme);
			strLine += Constants.Tab;
			strLine += word.GetGloss();
			strLine	+= Constants.Tab;
			if ( ol.ViewOrigWord )
			{
				strLine += word.OrigWord;
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
			}
			if ( ol.ViewPS )
			{
				strLine += word.PartOfSpeech;
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
			}
			if ( ol.ViewPlural )
			{
				strLine += word.Plural;
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
			}
			if ( ol.ViewRoot )
			{
                strLine += word.Root.DisplayRoot;
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
			}
			if ( ol.ViewCVPattern )
			{
				strLine += word.CVPattern;
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
			}
			if ( ol.ViewSyllBreaks)
			{
				strLine += word.GetWordWithSyllBreaks();
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
			}
			if (ol.ViewWordWithoutTone)
			{
				strLine += word.GetWordWithoutTone();
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
			}
            if (ol.ViewRoot)
            {
                strLine += word.Root.DisplayRoot;
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
            }
            if (ol.ViewRootCVPattern)
            {
                strLine += word.Root.CVPattern;
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
            }
            if (ol.ViewRootSyllBreaks)
            {
                strLine += word.Root.GetRootwithSyllBreaks();
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
            }
            if (ol.ViewRootWithoutTone)
			{
				strLine += word.Root.GetRootWithoutTone();
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
			}
			return strLine;
		}
        
        public string GetDisplayLineForWord(int nWord, ArrayList alGraphemes)
        {
            string strLine = "";
            OptionList ol = null;
            if (m_Settings != null)
                ol = m_Settings.OptionSettings;
            Word word = this.GetWord(nWord);

            strLine += word.GetWordWithHighlightGrapheme(alGraphemes);
            strLine += Constants.Tab;
            strLine += word.GetGloss();
            strLine += Constants.Tab;
            if (ol.ViewOrigWord)
            {
                strLine += word.OrigWord;
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
            }
            if (ol.ViewPS)
            {
                strLine += word.PartOfSpeech;
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
            }
            if (ol.ViewPlural)
            {
                strLine += word.Plural;
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
            }
            if (ol.ViewRoot)
            {
                strLine += word.Root.DisplayRoot;
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
            }
            if (ol.ViewCVPattern)
            {
                strLine += word.CVPattern;
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
            }
            if (ol.ViewSyllBreaks)
            {
                strLine += word.GetWordWithSyllBreaks();
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
            }
            if (ol.ViewWordWithoutTone)
            {
                strLine += word.GetWordWithoutTone();
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
            }
            if (ol.ViewRoot)
            {
                strLine += word.Root.DisplayRoot;
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
            }
            if (ol.ViewRootCVPattern)
            {
                strLine += word.Root.CVPattern;
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
            }
            if (ol.ViewRootSyllBreaks)
            {
                strLine += word.Root.GetRootwithSyllBreaks();
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
            }
            if (ol.ViewRootWithoutTone)
            {
                strLine += word.Root.GetRootWithoutTone();
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
            }
            return strLine;
        }
		
        public string GetDisplayHeadings()
		{
            string strLine = "";
            OptionList ol = new OptionList();
            if (m_Settings != null)
                ol = m_Settings.OptionSettings;

			strLine += Constants.kHCOn;
            //strLine += WordList.kWord;
            strLine += m_Settings.LocalizationTable.GetMessage("WordList20", ol.UILanguage);
			strLine += Constants.Tab;
            //strLine += WordList.kGloss;
            strLine += m_Settings.LocalizationTable.GetMessage("WordList21", ol.UILanguage);
            strLine += Constants.Tab;
			if ( ol.ViewOrigWord )
			{
                //strLine += WordList.kOrigWord;
                strLine += m_Settings.LocalizationTable.GetMessage("WordList22", ol.UILanguage);
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
			}
			if ( ol.ViewPS )
			{
                //strLine += WordList.kPS;
                strLine += m_Settings.LocalizationTable.GetMessage("WordList23", ol.UILanguage);
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
			}
			if ( ol.ViewPlural )
			{
                //strLine += WordList.kPlural;
                strLine += m_Settings.LocalizationTable.GetMessage("WordList25", ol.UILanguage);
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
			}
			if ( ol.ViewCVPattern )
			{
                //strLine += WordList.kCVPattern;
                strLine += m_Settings.LocalizationTable.GetMessage("WordList26", ol.UILanguage);
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
			}
			if ( ol.ViewSyllBreaks )
			{
                //strLine += WordList.kSyllBreaks;
                strLine += m_Settings.LocalizationTable.GetMessage("WordList27", ol.UILanguage);
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
			}
			if ( ol.ViewWordWithoutTone )
			{
                //strLine += WordList.kWordNoTone;
                strLine += m_Settings.LocalizationTable.GetMessage("WordList29", ol.UILanguage);
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
			}
            if (ol.ViewRoot)
            {
                //strLine += WordList.kRoot;
                strLine += m_Settings.LocalizationTable.GetMessage("WordList24", ol.UILanguage);
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
            }
            if (ol.ViewRootCVPattern)
            {
                //strLine += WordList.kRootCVPattern;
                strLine += m_Settings.LocalizationTable.GetMessage("WordList30", ol.UILanguage);
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
            }
            if (ol.ViewRootSyllBreaks)
            {
                //strLine += WordList.kRootSyllBreaks;
                strLine += m_Settings.LocalizationTable.GetMessage("WordList31", ol.UILanguage);
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
            }
            if (ol.ViewRootWithoutTone)
			{
                //strLine += WordList.kRootNoTone;
                strLine += m_Settings.LocalizationTable.GetMessage("WordList28", ol.UILanguage);
                strLine += Constants.Space.ToString();
                strLine += Constants.Tab;
			}
			strLine += Constants.kHCOff;
			return strLine;
		}

        public ArrayList GetDisplayHeadingsAsArray()
        // Returns ArayList of strings
        {
            ArrayList al = new ArrayList();
            OptionList ol = null;
            if (m_Settings != null)
                ol = m_Settings.OptionSettings;

            //al.Add(WordList.kWord);
            al.Add(m_Settings.LocalizationTable.GetMessage("WordList20", ol.UILanguage));
            //al.Add(WordList.kGloss);
            al.Add(m_Settings.LocalizationTable.GetMessage("WordList21", ol.UILanguage));
            if (ol.ViewOrigWord)
                //al.Add(WordList.kOrigWord);
                al.Add(m_Settings.LocalizationTable.GetMessage("WordList22", ol.UILanguage));
            if (ol.ViewPS)
                //al.Add(WordList.kPS);
                al.Add(m_Settings.LocalizationTable.GetMessage("WordList23", ol.UILanguage));
            if (ol.ViewPlural)
                //al.Add(WordList.kPlural);
                al.Add(m_Settings.LocalizationTable.GetMessage("WordList25", ol.UILanguage));
            if (ol.ViewCVPattern)
                //al.Add(WordList.kCVPattern);
                al.Add(m_Settings.LocalizationTable.GetMessage("WordList26", ol.UILanguage));
            if (ol.ViewSyllBreaks)
                //al.Add(WordList.kSyllBreaks);
                al.Add(m_Settings.LocalizationTable.GetMessage("WordList27", ol.UILanguage));
            if (ol.ViewWordWithoutTone)
                //al.Add(WordList.kWordNoTone);
                al.Add(m_Settings.LocalizationTable.GetMessage("WordList29", ol.UILanguage));
            if (ol.ViewRoot)
                //al.Add(WordList.kRoot);
                al.Add(m_Settings.LocalizationTable.GetMessage("WordList24", ol.UILanguage));
            if (ol.ViewRootCVPattern)
                //al.Add(WordList.kRootCVPattern);
                al.Add(m_Settings.LocalizationTable.GetMessage("WordList30", ol.UILanguage));
            if (ol.ViewRootSyllBreaks)
                //al.Add(WordList.kRootSyllBreaks);
                al.Add(m_Settings.LocalizationTable.GetMessage("WordList31", ol.UILanguage));
            if (ol.ViewRootWithoutTone)
                //al.Add(WordList.kRootNoTone);
                al.Add(m_Settings.LocalizationTable.GetMessage("WordList28", ol.UILanguage));
            return al;
        }

        public WordList SortWordList()
        {
            WordList wl = this;
            SortedList sl = new SortedList();
            Word wrd = null;
            string strKey = "";
            int nCntr = 0;
            int nCount = wl.WordCount();
            //FormProgressBar form = new FormProgressBar(kSort);
            string strMsg = m_Settings.LocalizationTable.GetMessage("WordList13", m_Settings.OptionSettings.UILanguage);
            FormProgressBar form = new FormProgressBar(strMsg);
            form.PB_Init(0, nCount * 2);

            for (int i = 0; i < wl.WordCount(); i++)    //sort the words
            {
                form.PB_Update(i);
                wrd = wl.GetWord(i);
                strKey = wrd.DisplayWord;
                while (sl.ContainsKey(strKey))          //get unique key
                {
                    nCntr++;
                    strKey = wrd.DisplayWord + Convert.ToString(nCntr);
                }
                sl.Add(strKey, wrd);
            }

            wl.WordsSorted.Clear();
            for (int i = 0; i < sl.Count; i++)          //save sorted words
            {
                form.PB_Update(nCount + i);
                wrd = (Word)sl.GetByIndex(i);
                wl.AddWord(wrd);
            }
            form.Close();
            return wl;
        }

		public ArrayList RetrieveWordListAsArray()
        //Returns ArrayList of strings
		{
			ArrayList alText = new ArrayList();
			string strLine = "";
            string str = "";
			if ( this.FileName != "" )
			{
                //str = "Retrieving Word List";
                str = m_Settings.LocalizationTable.GetMessage("WordList14", m_Settings.OptionSettings.UILanguage);
                FormProgressBar form = new FormProgressBar(str);
                form.PB_Init(0, this.WordCount());
                for (int i = 0; i < this.WordCount(); i++)
				{
                    form.PB_Update(i);
					strLine = GetDisplayLineForWord(i);
					alText.Add(strLine);
				}
                form.Close();
			}
            //else MessageBox.Show("Need to import word list");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("WordList9",
                    m_Settings.OptionSettings.UILanguage);
                MessageBox.Show(strMsg);
            }
			return alText;
		}

        public string RetrieveWordListAsString()
        {
            string strText = "";
            string strLine = "";
            //if (this.FileName != "")
            //{
                for (int i = 0; i < this.WordCount(); i++)
                {
                    strLine = GetDisplayLineForWord(i) + Constants.Space;
                    strText += strLine + Environment.NewLine;
                }
            //}
            //else MessageBox.Show("Need to import word list");
            return strText;
        }

        public string GetWordFromSFR(int nWord)
		{
			string strWord = "";
			StandardFormatRecord sfr;
			sfr = this.SFFile.GetRecord(nWord);
			strWord = sfr.GetFieldContents(m_OptionList.FMLexicon);
			return strWord;
		}

        public string GetMissingGraphemes()
		{
			string strText = "";
			ArrayList alMissingSegs = new ArrayList();
			Word wrd = null;
			string strSymbol = "";

            int nWidth = this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
			char chSpace = Constants.Space;
			WordList wl = m_Settings.WordList;
			int nWords = wl.WordCount();
		
//For each word in word list
			for (int i = 0; i < nWords; i++)
			{
				wrd = wl.GetWord(i);
                for (int j = 0; j < wrd.GraphemeCount(); j++)
				{
                    strSymbol = wrd.GetGrapheme(j).Symbol;
					if ( strSymbol != chSpace.ToString() )
					{
						if ( !m_Settings.GraphemeInventory.IsInInventory(strSymbol) )
						{
							if ( !alMissingSegs.Contains(strSymbol) )
							{
								alMissingSegs.Add(strSymbol);
								strText += strSymbol.PadRight(nWidth, chSpace);
							}
						}
					}
				}
			}
			return strText;
		}

        public GraphemeInventory UpdateGraphemeCounts(GraphemeInventory gi, bool fIgnoreSightWord, bool fIgnoreTone)
        {
            Consonant cns = null;
            Vowel vwl = null;
            Tone tone = null;
            Syllograph syllograph = null;
            //Grapheme grf = null;
            string strSym;

            // Initialize Counts
            for (int k = 0; k < gi.ConsonantCount(); k++)
            {
                cns = gi.GetConsonant(k);
                cns.InitCountInWordList();
                gi.UpdConsonant(k, cns);
            }

            for (int k = 0; k < gi.VowelCount(); k++)
            {
                vwl = gi.GetVowel(k);
                vwl.InitCountInWordList();
                gi.UpdVowel(k, vwl);
            }

            for (int k = 0; k < gi.ToneCount(); k++)
            {
                tone = gi.GetTone(k);
                tone.InitCountInWordList();
                gi.UpdTone(k, tone);
            }

            for (int k = 0; k < gi.SyllographCount(); k++)
            {
                syllograph = gi.GetSyllograph(k);
                syllograph.InitCountInWordList();
                gi.UpdSyllograph(k, syllograph);
            }

            Word wrd = null;
            int ndx = 0;
            for (int i = 0; i < this.WordCount(); i++)
            {
                wrd = this.GetWord(i);
                if (wrd.Available)
                {
                    if (!fIgnoreSightWord || !wrd.IsSightWord())
                    {
                        for (int j = 0; j < wrd.GraphemeCount(); j++)
                        {
                            if (fIgnoreTone)
                                strSym = wrd.GetGraphemeWithoutTone(j).Symbol;
                            else strSym = wrd.GetGrapheme(j).Symbol;

                            if (gi.IsInInventory(strSym))
                            {
                                ndx = gi.FindConsonantIndex(strSym);
                                if (ndx >= 0)
                                {
                                    cns = gi.GetConsonant(ndx);
                                    cns.IncrCountInWordList();
                                    gi.UpdConsonant(ndx, cns);
                                }

                                ndx = gi.FindVowelIndex(strSym);
                                if (ndx >= 0)
                                {
                                    vwl = gi.GetVowel(ndx);
                                    vwl.IncrCountInWordList();
                                    gi.UpdVowel(ndx, vwl);
                                }

                                ndx = gi.FindToneIndex(strSym);
                                if (ndx >= 0)
                                {
                                    tone = gi.GetTone(ndx);
                                    tone.IncrCountInWordList();
                                    gi.UpdTone(ndx, tone);
                                }

                                ndx = gi.FindSyllographIndex(strSym);
                                if (ndx >= 0)
                                {
                                    syllograph = gi.GetSyllograph(ndx);
                                    syllograph.IncrCountInWordList();
                                    gi.UpdSyllograph(ndx, syllograph);
                                }
                            }
                        }
                    }
                }
            }
            return gi;
        }

        public GraphemeInventory UpdateGraphemeCounts(GraphemeInventory gi)
		{
			Consonant cns = null;
			Vowel vwl = null;
            Tone tone = null;
            Syllograph syllograph = null;
			Word wrd = null;
			string strSym;

			for (int k = 0; k < gi.ConsonantCount(); k++)
			{
				cns = gi.GetConsonant(k);
				cns.InitCountInWordList();
				gi.UpdConsonant(k, cns);
			}

			for (int k = 0; k < gi.VowelCount(); k++)
			{
				vwl = gi.GetVowel(k);
				vwl.InitCountInWordList();
				gi.UpdVowel(k, vwl);
			}

            for (int k = 0; k < gi.ToneCount(); k++)
            {
                tone = gi.GetTone(k);
                tone.InitCountInWordList();
                gi.UpdTone(k, tone);
            }

            for (int k = 0; k < gi.SyllographCount(); k++)
            {
                syllograph = gi.GetSyllograph(k);
                syllograph.InitCountInWordList();
                gi.UpdSyllograph(k, syllograph);
            }

			int ndx;
			int nWords = this.WordCount();
			for (int n = 0; n <nWords; n++)
			{
				wrd = this.GetWord(n);
                if (wrd.Available)
                {
                    int nGraphemes = wrd.GraphemeCount();
                    for (int i = 0; i < nGraphemes; i++)
                    {
                        strSym = wrd.GetGrapheme(i).Symbol;
                        if (gi.IsInInventory(strSym))
                        {
                            ndx = gi.FindConsonantIndex(strSym);
                            if (ndx >= 0)
                            {
                                cns = gi.GetConsonant(ndx);
                                cns.IncrCountInWordList();
                                gi.UpdConsonant(ndx, cns);
                            }

                            ndx = gi.FindVowelIndex(strSym);
                            if (ndx >= 0)
                            {
                                vwl = gi.GetVowel(ndx);
                                vwl.IncrCountInWordList();
                                gi.UpdVowel(ndx, vwl);
                            }

                            ndx = gi.FindToneIndex(strSym);
                            if (ndx >= 0)
                            {
                                tone = gi.GetTone(ndx);
                                tone.IncrCountInWordList();
                                gi.UpdTone(ndx, tone);
                            }

                            ndx = gi.FindSyllographIndex(strSym);
                            if (ndx >= 0)
                            {
                                syllograph = gi.GetSyllograph(ndx);
                                syllograph.IncrCountInWordList();
                                gi.UpdSyllograph(ndx, syllograph);
                            }
                        }
                    }
                }
			}
			return gi;
		}

        public GraphemeInventory UpdateConsonantCounts(GraphemeInventory gi, bool fIgnoreTone)
        {
            Consonant cns = null;
            Word wrd = null;
            string strSym;
            // Initialize the count of the consonant
            for (int k = 0; k < gi.ConsonantCount(); k++)
            {
                cns = gi.GetConsonant(k);
                cns.InitCountInWordList();
                gi.UpdConsonant(k, cns);
            }
            //Process each available word in the wordlist
            int ndx;
            int nWords = this.WordCount();
            for (int n = 0; n < nWords; n++)
            {
                wrd = this.GetWord(n);
                if (wrd.Available)
                {
                    int nGraphemes = wrd.GraphemeCount();
                    for (int i = 0; i < nGraphemes; i++)        //for each grapheme in word
                    {
                        if (fIgnoreTone)
                            strSym = wrd.GetGraphemeWithoutTone(i).Symbol;
                        else strSym = wrd.GetGrapheme(i).Symbol;
                        if (gi.IsInInventory(strSym))
                        {
                            ndx = gi.FindConsonantIndex(strSym);
                            if (ndx >= 0)
                            {
                                cns = gi.GetConsonant(ndx);
                                cns.IncrCountInWordList();      //increment the count of the consonant
                                gi.UpdConsonant(ndx, cns);
                            }
                        }
                    }
                }
            }
            return gi;
        }

        public GraphemeInventory UpdateVowelCounts(GraphemeInventory gi, bool fIgnoreTone)
        {
            Vowel vwl = null;
            Word wrd = null;
            string strSym;
            //Initialze the count of the vowels
            for (int k = 0; k < gi.VowelCount(); k++)
            {
                vwl = gi.GetVowel(k);
                vwl.InitCountInWordList();
                gi.UpdVowel(k, vwl);
            }
            //Process each available in the word list
            int ndx;
            int nWords = this.WordCount();
            for (int n = 0; n < nWords; n++)
            {
                wrd = this.GetWord(n);
                if (wrd.Available)
                {
                    int nGraphemes = wrd.GraphemeCount();
                    for (int i = 0; i < nGraphemes; i++)        //for each grapheme in word
                    {
                        if (fIgnoreTone)
                            strSym = wrd.GetGraphemeWithoutTone(i).Symbol;
                        else strSym = wrd.GetGrapheme(i).Symbol;
                        if (gi.IsInInventory(strSym))
                        {
                            ndx = gi.FindVowelIndex(strSym);
                            if (ndx >= 0)
                            {
                                vwl = gi.GetVowel(ndx);
                                vwl.IncrCountInWordList();      //Increment count of the vowel
                                gi.UpdVowel(ndx, vwl);
                            }
                        }
                    }
                }
            }
            return gi;
        }

        public GraphemeInventory UpdateToneCounts(GraphemeInventory gi)
        {
            Tone tone = null;
            Word wrd = null;
            string strSym;
            // Initialize the count of the tones
            for (int k = 0; k < gi.ToneCount(); k++)
            {
                tone = gi.GetTone(k);
                tone.InitCountInWordList();
                gi.UpdTone(k, tone);
            }
            //Process each available word in the word list
            int ndx;
            int nWords = this.WordCount();
            for (int n = 0; n < nWords; n++)
            {
                wrd = this.GetWord(n);
                if (wrd.Available)
                {
                    int nGraphemes = wrd.GraphemeCount();
                    for (int i = 0; i < nGraphemes; i++)        //for each grapheme in word
                    {
                        strSym = wrd.GetGrapheme(i).Symbol;
                        if (gi.IsInInventory(strSym))
                        {
                            ndx = gi.FindToneIndex(strSym);
                            if (ndx >= 0)
                            {
                                tone = gi.GetTone(ndx);
                                tone.IncrCountInWordList();     //Increment count of the tone
                                gi.UpdTone(ndx, tone);
                            }
                        }
                    }
                }
            }
            return gi;
        }

        public GraphemeInventory UpdateSyllographCounts(GraphemeInventory gi)
        {
            Syllograph syllograph = null;
            Word wrd = null;
            string strSym;
            //Initialize count of the Syllabaries
            for (int k = 0; k < gi.SyllographCount(); k++)
            {
                syllograph = gi.GetSyllograph(k);
                syllograph.InitCountInWordList();
                gi.UpdSyllograph(k, syllograph);
            }
            //Process each available word in the word list
            int ndx;
            int nWords = this.WordCount();
            for (int n = 0; n < nWords; n++)
            {
                wrd = this.GetWord(n);
                if (wrd.Available)
                {
                    int nGraphemes = wrd.GraphemeCount();
                    for (int i = 0; i < nGraphemes; i++)        //For each grapheme in word
                    {
                        strSym = wrd.GetGrapheme(i).Symbol;
                        if (gi.IsInInventory(strSym))
                        {
                            ndx = gi.FindSyllographIndex(strSym);
                            if (ndx >= 0)
                            {
                                syllograph = gi.GetSyllograph(ndx);
                                syllograph.IncrCountInWordList();     //Increment count of syllograph
                                gi.UpdSyllograph(ndx, syllograph);
                            }
                        }
                    }
                }
            }
            return gi;
        }

        public SortedList UpdateSyllographFeaturesCounts(SortedList sl, GraphemeInventory gi)
        // Returns SortedList of SyllographFeatureInfos
        {
            SyllographFeatureInfo info = null;
            Syllograph syllograph = null;
            Word wrd = null;
            Grapheme grf = null;
            //Initialize count to zero
            for (int k = 0; k < sl.Count; k++)
            {
                info = (SyllographFeatureInfo) sl.GetByIndex(k);
                info.CountInWordList = 0;
                sl.RemoveAt(k);
                sl.Add(info.Feature, info);
            }
            //Process each available word in wordlist
            int ndx = 0;
            for (int n = 0; n < this.WordCount(); n++)
            {
                wrd = this.GetWord(n);
                if (wrd.Available)
                {
                    for (int i = 0; i < wrd.GraphemeCount(); i++)        //for each grapheme in word
                    {
                        grf = wrd.GetGrapheme(i);
                        if (grf.IsSyllograph)
                        {
                            ndx = gi.FindSyllographIndex(grf.Symbol);
                            if (ndx >=0)
                            {
                                syllograph = gi.GetSyllograph(ndx);
                                for (int j = 0; j < sl.Count; j++)
                                {
                                    info = (SyllographFeatureInfo)sl.GetByIndex(j);
                                    if (info.Available)
                                    {
                                        if (info.Type == SyllographFeatures.SyllographType.Pri)
                                        {
                                            if (info.Feature == syllograph.CategoryPrimary)
                                                info.CountInWordList++;
                                        }
                                        else if (info.Type == SyllographFeatures.SyllographType.Sec)
                                        {
                                            if (info.Feature == syllograph.CategorySecondary)
                                                info.CountInWordList++;
                                        }
                                        else if (info.Type == SyllographFeatures.SyllographType.Ter)
                                        {
                                            if (info.Feature == syllograph.CategoryTertiary)
                                                info.CountInWordList++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return sl;
        }
           
        public Consonant LeastUsedConsonant(GraphemeInventory gi)
        {
            Consonant cns = null;
            Consonant cnsLeastUsed = null;
            for (int k = 0; k < gi.ConsonantCount(); k++)
            {
                cns = gi.GetConsonant(k);
                if (cnsLeastUsed == null)
                    cnsLeastUsed = cns;
                else
                {
                    if (cns.GetCountInWordList() < cnsLeastUsed.GetCountInWordList())
                        cnsLeastUsed = cns;
                }
            }
            return cnsLeastUsed;
        }

        public Vowel LeastUsedVowel(GraphemeInventory gi)
        {
            Vowel vwl = null;
            Vowel vwlLeastUsed = null;
            for (int k = 0; k < gi.VowelCount(); k++)
            {
                vwl = gi.GetVowel(k);
                if (vwlLeastUsed == null)
                    vwlLeastUsed = vwl;
                else
                {
                    if (vwl.GetCountInWordList() < vwlLeastUsed.GetCountInWordList())
                        vwlLeastUsed = vwl;
                }
            }
            return vwlLeastUsed;
        }

        public Tone LeastUsedTone(GraphemeInventory gi)
        {
            Tone tone = null;
            Tone toneLeastUsed = null;
            for (int k = 0; k < gi.ToneCount(); k++)
            {
                tone = gi.GetTone(k);
                if (toneLeastUsed == null)
                    toneLeastUsed = tone;
                else
                {
                    if (tone.GetCountInWordList() < toneLeastUsed.GetCountInWordList())
                        toneLeastUsed = tone;
                }
            }
            return toneLeastUsed;
        }

        public Syllograph LeastUsedSyllograph(GraphemeInventory gi)
        {
            Syllograph syllograph = null;
            Syllograph syllLeastUsed = null;
            for (int k = 0; k < gi.SyllographCount(); k++)
            {
                syllograph = gi.GetSyllograph(k);
                if (syllLeastUsed == null)
                    syllLeastUsed = syllograph;
                else
                {
                    if (syllograph.GetCountInWordList() < syllLeastUsed.GetCountInWordList())
                        syllLeastUsed = syllograph;
                }
            }
            return syllLeastUsed;
        }

        public SyllographFeatureInfo LeastUsedSyllographFeature(SortedList sl)
        {
            SyllographFeatureInfo info = null;
            SyllographFeatureInfo infoLeastUsed = null;
            for (int k = 0; k < sl.Count; k++)
            {
                info = (SyllographFeatureInfo) sl.GetByIndex(k);
                if (info.Available)
                {
                    if (infoLeastUsed == null)
                        infoLeastUsed = info;
                    else if (info.CountInWordList < infoLeastUsed.CountInWordList)
                        infoLeastUsed = info;
                }
            }
            return infoLeastUsed;
        }

        public void UnAvailWordsWithConsonant(Consonant cns)
        {
            Word wrd = null;
            for (int i = 0; i < this.WordCount(); i++)
            {
                wrd = this.GetWord(i);
                if ( wrd.ContainInWord(cns) )
                    wrd.Available = false;
            }
        }

        public void UnAvailWordsWithVowel(Vowel vwl)
        {
            Word wrd = null;
            for (int i = 0; i < this.WordCount(); i++)
            {
                wrd = this.GetWord(i);
                if (wrd.ContainInWord(vwl))
                    wrd.Available = false;
            }
        }

        public void UnAvailWordsWithTone(Tone tone)
        {
            Word wrd = null;
            for (int i = 0; i < this.WordCount(); i++)
            {
                wrd = this.GetWord(i);
                if (wrd.ContainInWord(tone))
                    wrd.Available = false;
            }
        }

        public void UnAvailWordsWithSyllograph(Syllograph syllograph)
        {
            Word wrd = null;
            for (int i = 0; i < this.WordCount(); i++)
            {
                wrd = this.GetWord(i);
                if (wrd.ContainInWord(syllograph))
                    wrd.Available = false;
            }
        }

        public void UnAvailWordsWithSyllographFeature(SyllographFeatures.SyllographType typ, string val)
        {
            Word wrd = null;
            for (int i = 0; i < this.WordCount(); i++)
            {
                wrd = this.GetWord(i);
                if (wrd.HasSyllographFeatures(typ, val))
                    wrd.Available = false;
            }
        }

        private string GetOpenFileName(string strFolder)
        {
            string strFileName = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files (*.txt)|*.txt|All Files (*.*)|*.*";
            ofd.FileName = "";
            ofd.DefaultExt = "*.txt";
            ofd.InitialDirectory = strFolder;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;

            if (ofd.ShowDialog() == DialogResult.OK)
                strFileName = ofd.FileName;
            return strFileName;
        }

    }
 }


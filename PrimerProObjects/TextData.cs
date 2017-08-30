using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.IO;
using PrimerProLocalization;
using GenLib;
using StandardFormatLib;

namespace PrimerProObjects
{
	/// <summary>
	/// 
	/// </summary>
	public class TextData
	{
		private Settings m_Settings;
		private string m_FileName;
		private ArrayList m_Paragraphs;
        
        private const string kSeparator = Constants.Tab;
        //private const string kLoad = "Loading Text Data";
        //private const string kBuild = "Building Text Data";
        //private const string kBuildWL = "Building Word List from Text Data";
        //private const string kBuildSFM = "Building SFM Word List";

        public const string kMergeTextData = "<Merged>";
        public const string kPara = "Para";
        public const string kSent = "Sent";
        public const string kWord = "Word";

		public TextData(Settings s)
		{
			m_Settings = s;
			m_FileName = "";
			m_Paragraphs = null;
		}

        public string FileName
		{
			get {return m_FileName;}
			set {m_FileName = value;}
		}

		public ArrayList Paragraphs
		{
			get {return m_Paragraphs;}
			set {m_Paragraphs = value;}
		}

		public void AddParagraph(Paragraph para)
		{
			m_Paragraphs.Add(para);
		}

		public void DelParagraph(int n)
		{
			m_Paragraphs.RemoveAt(n);
		}

		public Paragraph GetParagraph(int n)
		{
			if ( n < this.ParagraphCount() )
				return (Paragraph) m_Paragraphs[n];
			else return null;
		}
		
		public int ParagraphCount()
		{
			if (m_Paragraphs == null )
				return 0;
			else return m_Paragraphs.Count;
		}

		public int SentenceCount()
		{
			int nCount = 0;
			Paragraph para = null;
			for (int i = 0; i < this.ParagraphCount(); i++)
			{
				para = this.GetParagraph(i);
				nCount = nCount + para.SentenceCount();
			}
			return nCount;
		}

		public int WordCount()
		{
			int nCount = 0;
			Paragraph para = null;
			for (int i = 0; i < this.ParagraphCount(); i++)
			{
				para = this.GetParagraph(i);
				nCount = nCount + para.WordCount();
			}
			return nCount;
		}

        public string BuildTextDataAsString()
        {
            string strData = "";
            string strMsg = "";
            //FormProgressBar form = new FormProgressBar(TextData.kBuild);
            strMsg = m_Settings.LocalizationTable.GetMessage("TextData12", m_Settings.OptionSettings.UILanguage);
            FormProgressBar form = new FormProgressBar(strMsg);
            form.PB_Init(0, this.ParagraphCount());
            if (this.m_FileName != "")
            {
                for (int i = 0; i < this.ParagraphCount(); i++)
                {
                    form.PB_Update(i);
                    strData += GetParagraph(i).AsString() + Environment.NewLine;
                    //strData += Environment.NewLine;
                }
            }
            //else MessageBox.Show("Need to import text data");
            else
            {
                strMsg = m_Settings.LocalizationTable.GetMessage("TextData1", m_Settings.OptionSettings.UILanguage);
                MessageBox.Show(strMsg);
            }
            form.Close();
            return strData;
        }

        public ArrayList BuildTextDataAsArray()
        {
            ArrayList alData = new ArrayList();
            string strPara = "";
            string strMsg = "";
            //FormProgressBar form = new FormProgressBar(TextData.kBuild);
            strMsg = m_Settings.LocalizationTable.GetMessage("TextData12", m_Settings.OptionSettings.UILanguage);
            FormProgressBar form = new FormProgressBar(strMsg);
            form.PB_Init(0, this.ParagraphCount());
            if (this.m_FileName != "")
            {
                for (int i = 0; i < this.ParagraphCount(); i++)
                {
                    form.PB_Update(i);
                    strPara = GetParagraph(i).AsString();
                    alData.Add(strPara);
                }
            }
            //else MessageBox.Show("Need to import text data");
            else
            {
                strMsg = m_Settings.LocalizationTable.GetMessage("TextData1", m_Settings.OptionSettings.UILanguage);
                MessageBox.Show(strMsg);
            }
            form.Close();
            return alData;
        }

        public TextData Load(string strFolder)
		{
			TextData td  = null;
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
				td = new TextData(m_Settings);
                if (td.LoadFile(ofd.FileName))
                    td.FileName = ofd.FileName;
                else td.FileName = "";
			}
			return td;
		}

		public bool LoadFile(string strFileName)
		{
            bool fReturn = false;
			Paragraph para = null;
			this.FileName = strFileName;
            string strMsg = "";

            if (File.Exists(strFileName))
            {
                try
                {
                    string[] strLines = File.ReadAllLines(strFileName);
                    int nCount = strLines.GetLength(0);
                    //FormProgressBar form = new FormProgressBar(TextData.kLoad));
                    strMsg = m_Settings.LocalizationTable.GetMessage("TextData11", m_Settings.OptionSettings.UILanguage);
                    FormProgressBar form = new FormProgressBar(strMsg);
                    form.PB_Init(0, nCount);
                    if (this.Paragraphs == null)
                        this.Paragraphs = new ArrayList();
                    int n = 0;
                    foreach (string strPara in strLines)
                    {
                        n++;
                        form.PB_Update(n);
                        if (strPara != "")
                        {
                            para = new Paragraph(strPara, m_Settings);
                            this.AddParagraph(para);
                        }
                    }
                    form.Close();
                    fReturn = true;
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    fReturn = false;
                }
            }
            //else MessageBox.Show(strFileName + " does not exist");
            else
            {
                strMsg = m_Settings.LocalizationTable.GetMessage("TextData2", m_Settings.OptionSettings.UILanguage);
                MessageBox.Show(strFileName + Constants.Space + strMsg);
            }
            return fReturn;
  		}

		public TextData Merge(string strFolder)
		{
			TextData td = this;
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
                if (td.LoadFile(ofd.FileName))
                    td.FileName = TextData.kMergeTextData;
                else td.FileName = "";
			}
			return td;
		}

		public bool Save(string strFolder)
		{
			bool fReturn = false;
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "txt files (*.txt)|*.txt|All Files (*.*)|*.*";
			if (this.FileName == TextData.kMergeTextData)
				sfd.FileName = "";
			else sfd.FileName = this.FileName;
			sfd.DefaultExt = "*.txt";
			sfd.InitialDirectory = strFolder;
			sfd.CheckPathExists = true;

			if (sfd.ShowDialog()== DialogResult.OK)
			{
				this.SaveFile(sfd.FileName);
				this.FileName = sfd.FileName;
				fReturn = true;
			}
			return fReturn;
		}

		public void SaveFile(string strFileName)
		{
			string strText = this.BuildTextDataAsString();
			StreamWriter sw = File.CreateText(strFileName);
			sw.Write(strText);
			sw.Close();
		}

        public WordList BuildWordList()
        {
            WordList wl = new WordList(m_Settings);
            Paragraph para = null;
            Sentence sent = null;
            Word word = null;
            //string strmsg ="Loading Text Data";
            string strMsg = m_Settings.LocalizationTable.GetMessage("TextData13", m_Settings.OptionSettings.UILanguage);
            FormProgressBar form = new FormProgressBar(strMsg);
            form.PB_Init(0, this.ParagraphCount());
            for (int i = 0; i < this.ParagraphCount(); i++)
            {
                form.PB_Update(i);
                para = this.GetParagraph(i);
                for (int j = 0; j < para.SentenceCount(); j++)
                {
                    sent = para.GetSentence(j);
                    for (int k = 0; k < sent.WordCount(); k++)
                    {
                        word = sent.GetWord(k);
                        if (word != null)
                            wl.AddWord(word);
                    }
                }
            }
            form.Close();
            return wl;
        }

        public WordList BuildWordListWithNoDuplicates()
        {
            WordList wl = new WordList(m_Settings);
            SortedList sl = new SortedList();
            Paragraph para = null;
            Sentence sent = null;
            Word word = null;
            //string strmsg ="Loading Text Data";
            string strMsg = m_Settings.LocalizationTable.GetMessage("TextData13", m_Settings.OptionSettings.UILanguage);
            FormProgressBar form = new FormProgressBar(strMsg);
            form.PB_Init(0, this.ParagraphCount());
            for (int i = 0; i < this.ParagraphCount(); i++)
            {
                form.PB_Update(i);
                para = this.GetParagraph(i);
                for (int j = 0; j < para.SentenceCount(); j++)
                {
                    sent = para.GetSentence(j);
                    for (int k = 0; k < sent.WordCount(); k++)
                    {
                        word = sent.GetWord(k);
                        if (word != null)
                        {
                            if (!sl.ContainsKey(word.DisplayWord))
                            {
                                wl.AddWord(word);
                                sl.Add(word.DisplayWord, word);
                            }
                        }
                    }
                }
            }
            form.Close();
            return wl;
        }
        
        public GraphemeInventory BuildSyllabaryInventory()
        {
            GraphemeInventory gi = new GraphemeInventory(m_Settings);
            Paragraph para = null;
            Sentence sent = null;
            Word word = null;
            Syllograph syllograph = null;
            string strGrapheme = "";
            //string strMsg = "Building syllograph inventory";
            string strMsg = m_Settings.LocalizationTable.GetMessage("TextData10", m_Settings.OptionSettings.UILanguage);
            FormProgressBar form = new FormProgressBar(strMsg);
            form.PB_Init(0, this.ParagraphCount());
            for (int i = 0; i < this.ParagraphCount(); i++)
            {
                form.PB_Update(i);
                para = this.GetParagraph(i);
                for (int j = 0; j < para.SentenceCount(); j++)
                {
                    sent = para.GetSentence(j);
                    for (int k = 0; k < sent.WordCount(); k++)
                    {
                        word = sent.GetWord(k);
                        for (int l = 0; l < word.GraphemeCount(); l++)
                        {
                            strGrapheme = word.GetGrapheme(l).Symbol;
                            if (strGrapheme != "")
                            {
                                if (!gi.IsInInventory(strGrapheme))
                                {
                                    syllograph = new Syllograph(strGrapheme);
                                    syllograph.UpperCase = strGrapheme;
                                    gi.AddSyllograph(syllograph);
                                }
                            }
                        }
                    }
                }
            }
            form.Close();
            return gi;
        }
        
        public SortedList BuildSortedListOfWords(bool fIgnore)
        {
            SortedList sl = new SortedList(StringComparer.OrdinalIgnoreCase);
            Paragraph para = null;
            Sentence sent = null;
            Word word = null;
            string strWord = "";
            for (int i = 0; i < this.ParagraphCount(); i++)
            {
                para = this.GetParagraph(i);
                for (int j = 0; j < para.SentenceCount(); j++)
                {
                    sent = para.GetSentence(j);
                    for (int k = 0; k < sent.WordCount(); k++)
                    {
                        word = sent.GetWord(k);
                        if (fIgnore)
                            strWord = word.GetWordWithoutTone();
                        else strWord = word.DisplayWord;
                        if (strWord != "")
                            if ( sl.IndexOfKey(strWord) < 0 )
                                sl.Add(strWord, strWord);
                    }
                }
            }
            return sl;
        }

        public StandardFormatFile BuildStandardFormatFile()
        {
            OptionList ol = m_Settings.OptionSettings;
            StandardFormatRecord sfr = null;
            StandardFormatField field = null;
            WordList wl = m_Settings.WordList;
            Paragraph para = null;
            Sentence sent = null;
            Word word = null;
            string strDisplayWord = "";
            string strDisplayWordUSV = "";         //Unicode values for display word
            SortedList sl = new SortedList();      //Use to build records in alphabetical order and without duplicates

            //FormProgressBar form = new FormProgressBar(TextData.kBuildSFM);
            string strMsg = m_Settings.LocalizationTable.GetMessage("TextData14", m_Settings.OptionSettings.UILanguage);
            FormProgressBar form = new FormProgressBar(strMsg);
            form.PB_Init(0, this.ParagraphCount() - 1);

            for (int i = 0; i < this.ParagraphCount(); i++)
            {
                para = this.GetParagraph(i);
                for (int j = 0; j < para.SentenceCount(); j++)
                {
                    sent = para.GetSentence(j);
                    for (int k = 0; k < sent.WordCount(); k++)
                    {
                        word = sent.GetWord(k);
                        if (word != null)
                        {
                            strDisplayWord = word.GetWordInLowerCase().Trim();
                            strDisplayWordUSV = Funct.GetUnicodeString(strDisplayWord);

                            if (strDisplayWord != "")               //if real word
                            {
                                if (!sl.ContainsKey(strDisplayWordUSV))  //if not in sff
                                {
                                    sfr = new StandardFormatRecord();
                                    if (wl.IsWordInList(strDisplayWord))
                                    {
                                        word = wl.GetWord2(strDisplayWord);
                                        //Add fields to record
                                        field = new StandardFormatField(ol.FMLexicon, word.DisplayWord);
                                        sfr.AddField(field);

                                        field = new StandardFormatField(ol.FMPS, word.PartOfSpeech);
                                        sfr.AddField(field);

                                        field = new StandardFormatField(ol.FMGlossEnglish, word.GlossEnglish);
                                        sfr.AddField(field);

                                        if (word.GlossNational != "")
                                        {
                                            field = new StandardFormatField(ol.FMGlossNational, word.GlossNational);
                                            sfr.AddField(field);
                                        }

                                        if (word.GlossRegional != "")
                                        {
                                            field = new StandardFormatField(ol.FMGlossRegional, word.GlossRegional);
                                            sfr.AddField(field);
                                        }

                                        if (word.Plural != "")
                                        {
                                            field = new StandardFormatField(ol.FMPlural, word.Plural);
                                            sfr.AddField(field);
                                        }

                                        if (word.Root != null)
                                        {
                                            if (word.Root.DisplayRoot != "")
                                            {
                                                field = new StandardFormatField(ol.
                                                    FMRoot, word.Root.DisplayRoot);
                                                sfr.AddField(field);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //Add fields to record
                                        field = new StandardFormatField(ol.FMLexicon, strDisplayWord);
                                        sfr.AddField(field);

                                        field = new StandardFormatField(ol.FMPS, "");
                                        sfr.AddField(field);

                                        field = new StandardFormatField(ol.FMGlossEnglish, "");
                                        sfr.AddField(field);
                                    }
                                    // Add record (word) to file
                                    sl.Add(strDisplayWordUSV, sfr);
                                }
                                //else
                                //{
                                //    MessageBox.Show("Already in SortedList: " + strDisplayWord);
                                //}
                            }
                        }
                    }
                }
                form.PB_Update(i);
            }
            form.Close();

            StandardFormatFile sff = new StandardFormatFile();
            for (int i =0; i < sl.Count; i++)
            {
                sfr = (StandardFormatRecord) sl.GetByIndex(i);
                sff.AddRecord(sfr);
            }
            return sff;
        }

        public GraphemeInventory UpdateGraphemeCounts(GraphemeInventory gi, bool fIgnoreSightWords, bool fIgnoreTone)
		{
			Consonant cns = null;
			Vowel vwl = null;
            Tone tone = null;
            Syllograph syllograph = null;
			Paragraph  para = null;
			Sentence snt = null;
			Word wrd = null;
            Grapheme grf = null;
			string strSym;

			// Initialize Counts
            for (int k = 0; k < gi.ConsonantCount(); k++)
			{
				cns = gi.GetConsonant(k);
				cns.InitCountInTextData();
				gi.UpdConsonant(k, cns);
			}

			for (int k = 0; k < gi.VowelCount(); k++)
			{
				vwl = gi.GetVowel(k);
				vwl.InitCountInTextData();
				gi.UpdVowel(k, vwl);
			}

            for (int k = 0; k < gi.ToneCount(); k++)
            {
                tone = gi.GetTone(k);
                tone.InitCountInTextData();
                gi.UpdTone(k, tone);
            }

            for (int k = 0; k < gi.SyllographCount(); k++)
            {
                syllograph = gi.GetSyllograph(k);
                syllograph.InitCountInTextData();
                gi.UpdSyllograph(k, syllograph);
            }

			int nPara = this.ParagraphCount();
			for (int i = 0; i < nPara; i++)
			{
				para = this.GetParagraph(i);	//next paragraph
				int nSent = para.SentenceCount();
				for (int j = 0; j < nSent; j++)
				{
					snt = para.GetSentence(j);		//next sentence
					int nWord = snt.WordCount();
					for ( int k = 0; k <nWord; k++)
					{
						wrd = snt.GetWord(k);		//next word 
						int ndx = 0;				//index in inventory for grapheme
                        if ( !fIgnoreSightWords || !wrd.IsSightWord() )
                        {
                            for (int n = 0; n < wrd.GraphemeCount(); n++)
                            {
                                strSym = wrd.GetGrapheme(n).Symbol;
                                if (gi.IsInInventory(strSym))
                                {
                                    ndx = gi.FindConsonantIndex(strSym);
                                    if (ndx >= 0)
                                    {
                                        cns = gi.GetConsonant(ndx);
                                        cns.IncrCountInTextData();
                                        gi.UpdConsonant(ndx, cns);
                                    }

                                    ndx = gi.FindVowelIndex(strSym);
                                    if (ndx >= 0)
                                    {
                                        vwl = gi.GetVowel(ndx);
                                        vwl.IncrCountInTextData();
                                        gi.UpdVowel(ndx, vwl);
                                    }

                                    ndx = gi.FindToneIndex(strSym);
                                    if (ndx >= 0)
                                    {
                                        if (fIgnoreTone)
                                        {
                                            grf = gi.GetTone(ndx).ToneBearingUnit;
                                            if ((grf != null) && (grf.IsVowel))
                                            {
                                                ndx = gi.FindVowelIndex(grf.Symbol);
                                                if (ndx >= 0)
                                                {
                                                    vwl = gi.GetVowel(ndx);
                                                    vwl.IncrCountInTextData();
                                                    gi.UpdVowel(ndx, vwl);
                                                }
                                            }
                                            if ((grf != null) && (grf.IsConsonant))
                                            {
                                                ndx = gi.FindConsonantIndex(grf.Symbol);
                                                if (ndx >= 0)
                                                {
                                                    cns = gi.GetConsonant(ndx);
                                                    cns.IncrCountInTextData();
                                                    gi.UpdConsonant(ndx, cns);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            tone = gi.GetTone(ndx);
                                            tone.IncrCountInTextData();
                                            gi.UpdTone(ndx, tone);
                                        }
                                    }

                                    ndx = gi.FindSyllographIndex(strSym);
                                    if (ndx >= 0)
                                    {
                                        syllograph = gi.GetSyllograph(ndx);
                                        syllograph.IncrCountInTextData();
                                        gi.UpdSyllograph(ndx, syllograph);
                                    }
                                }
                            }
						}
					}
				}
			}
			return gi;
		}

        public string GetMissingGraphemes()
		{
			string strText = "";
			ArrayList alMissingSegs = new ArrayList();
			Paragraph para = null;
			Sentence snt = null;
			Word wrd = null;
			string strSymbol = "";

            int nWidth = this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
			char chSpace = Constants.Space;
			TextData td = m_Settings.TextData;
		
			//For each paragraph in text data
			int nPara = td.ParagraphCount();
			for (int i = 0; i < nPara; i++)
			{
				para = td.GetParagraph(i);
				//For each sentence in paragraph
				int nSent = para.SentenceCount();
				for (int j = 0; j < nSent; j++)
				{
					snt = para.GetSentence(j);
					//For each word in sentence
					int nWord = snt.WordCount();
					for (int k = 0; k < nWord; k++)
					{
						wrd = snt.GetWord(k);
                        for (int n = 0; n < wrd.GraphemeCount(); n++)
						{
                            //For Each grapheme in word
                            strSymbol = wrd.GetGrapheme(n).Symbol;
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
				}
			}
			return strText;
		}

		public string GetMissingWords()
		{
			string strText = "";
			ArrayList alMissingWords = new ArrayList();
			Paragraph para = null;
			Sentence snt = null;
			Word wrd = null;
			string strWord = "";

			TextData td = m_Settings.TextData;
			//For each paragraph in text data
			int nPara = td.ParagraphCount();
			for (int i = 0; i < nPara; i++)
			{
				para = td.GetParagraph(i);
				//For each sentence in paragraph
				int nSent = para.SentenceCount();
				for (int j = 0; j < nSent; j++)
				{
					snt = para.GetSentence(j);
					//For each word in sentence
					int nWord = snt.WordCount();
					for (int k = 0; k < nWord; k++)
					{
						wrd = snt.GetWord(k);
						strWord = wrd.DisplayWord;
						if ( !m_Settings.WordList.IsWordInList(strWord) )
						{
							if ( !alMissingWords.Contains(strWord) )
							{
								alMissingWords.Add(strWord);
								strText += strWord + Environment.NewLine;
							}
						}
					}
				}
			}
			return strText;
		}

		public SortedList GetWordCounts(char SortOrder, bool IgnoreTone)
		{
			SortedList sl = new SortedList(StringComparer.OrdinalIgnoreCase);
			int nCount = 0;
			Paragraph para = null;
			Sentence snt = null;
			Word wrd = null;
			string strWord = "";
			TextData td = m_Settings.TextData;
		
			//For each paragraph in text data
			int nPara = td.ParagraphCount();
			for (int i = 0; i < nPara; i++)
			{
				para = td.GetParagraph(i);
				//For each sentence in paragraph
				int nSent = para.SentenceCount();
				for (int j = 0; j < nSent; j++)
				{
					snt = para.GetSentence(j);
					//For each word in sentence
					int nWord = snt.WordCount();
					for (int k = 0; k < nWord; k++)
					{
						wrd = snt.GetWord(k);
                        if (wrd != null)
                        {
                            if (IgnoreTone)
                                strWord = wrd.GetWordWithoutTone();
                            else strWord = wrd.DisplayWord;
                            if (strWord != "")   //skip empty words
                            {
                                if (sl.ContainsKey(strWord))
                                {
                                    nCount = (int)sl[strWord];
                                    sl[strWord] = nCount + 1;
                                }
                                else
                                {
                                    sl.Add(strWord, 1);
                                }
                            }
                        }
					}
				}
			}

            if (SortOrder == 'N')
            {
                SortedList slNumer = new SortedList(StringComparer.OrdinalIgnoreCase);
                string strVal = "";
                string strKey = "";
                for (int i = 0; i < sl.Count; i++)
                {
                    strVal = sl.GetKey(i).ToString();
                    strKey =  sl.GetByIndex(i).ToString().PadLeft(5, Constants.Space) + strVal;
                    slNumer.Add(strKey, strVal);
                }
                sl = slNumer;
            }
			return sl;
		}

        public SortedList GetSyllableCounts(char SortOrder, bool IgnoreTone, bool UseGraphemesTaught, ArrayList alGTO)
        {
            SortedList sl = new SortedList(StringComparer.OrdinalIgnoreCase);
            int nCount = 0;
            Paragraph para = null;
            Sentence snt = null;
            Word wrd = null;
            Syllable syll = null;
            string strSyll = "";
            TextData td = m_Settings.TextData;

            //For each paragraph in text data
            int nPara = td.ParagraphCount();
            for (int i = 0; i < nPara; i++)
            {
                para = td.GetParagraph(i);
                //For each sentence in paragraph
                int nSent = para.SentenceCount();
                for (int j = 0; j < nSent; j++)
                {
                    snt = para.GetSentence(j);
                    //For each word in sentence
                    int nWord = snt.WordCount();
                    for (int k = 0; k < nWord; k++)
                    {
                        wrd = snt.GetWord(k);
                        if (wrd != null)
                        {
                            int nSyll = wrd.SyllableCount();
                            for (int l = 0; l < nSyll; l++)
                            {
                                syll = wrd.GetSyllable(l);
                                strSyll = "";
                                if (UseGraphemesTaught)
                                    if (syll.IsBuildable(alGTO))
                                    {
                                        if (IgnoreTone)
                                            strSyll = syll.GetSyllableWithoutTone();
                                        else strSyll = syll.GetSyllableInLowerCase();
                                    }
                                    else strSyll = "";
                                else
                                {
                                    if (IgnoreTone)
                                        strSyll = syll.GetSyllableWithoutTone();
                                    else strSyll = syll.GetSyllableInLowerCase();
                                }
                                if (strSyll != "")   //skip empty syllables
                                {
                                    if (sl.ContainsKey(strSyll))
                                    {
                                        nCount = (int)sl[strSyll];
                                        sl[strSyll] = nCount + 1;
                                    }
                                    else
                                    {
                                        sl.Add(strSyll, 1);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (SortOrder == 'N')
            {
                SortedList slNumer = new SortedList(StringComparer.OrdinalIgnoreCase);
                string strVal = "";
                string strKey = "";
                for (int i = 0; i < sl.Count; i++)
                {
                    strVal = sl.GetKey(i).ToString();
                    strKey = sl.GetByIndex(i).ToString().PadLeft(5, Constants.Space) + strVal;
                    slNumer.Add(strKey, strVal);
                }
                sl = slNumer;
            }
            return sl;
        }

        //public SortedList GetSyllableCounts(char SortOrder, bool IgnoreTone)
        //{
        //    SortedList sl = new SortedList(StringComparer.OrdinalIgnoreCase);
        //    int nCount = 0;
        //    Paragraph para = null;
        //    Sentence snt = null;
        //    Word wrd = null;
        //    Syllable syll = null;
        //    string strSyll = "";
        //    TextData td = m_Settings.TextData;

        //    //For each paragraph in text data
        //    int nPara = td.ParagraphCount();
        //    for (int i = 0; i < nPara; i++)
        //    {
        //        para = td.GetParagraph(i);
        //        //For each sentence in paragraph
        //        int nSent = para.SentenceCount();
        //        for (int j = 0; j < nSent; j++)
        //        {
        //            snt = para.GetSentence(j);
        //            //For each word in sentence
        //            int nWord = snt.WordCount();
        //            for (int k = 0; k < nWord; k++)
        //            {
        //                wrd = snt.GetWord(k);
        //                if (wrd != null)
        //                {
        //                    int nSyll = wrd.SyllableCount();
        //                    for (int l = 0; l < nSyll; l++)
        //                    {
        //                        syll = wrd.GetSyllable(l);
        //                        if (IgnoreTone)
        //                            strSyll = syll.GetSyllableWithoutTone();
        //                        else strSyll = syll.GetSyllableInLowerCase();
        //                        if (strSyll != "")   //skip empty words
        //                        {
        //                            if (sl.ContainsKey(strSyll))
        //                            {
        //                                nCount = (int)sl[strSyll];
        //                                sl[strSyll] = nCount + 1;
        //                            }
        //                            else
        //                            {
        //                                sl.Add(strSyll, 1);
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    if (SortOrder == 'N')
        //    {
        //        SortedList slNumer = new SortedList(StringComparer.OrdinalIgnoreCase);
        //        string strVal = "";
        //        string strKey = "";
        //        for (int i = 0; i < sl.Count; i++)
        //        {
        //            strVal = sl.GetKey(i).ToString();
        //            strKey = sl.GetByIndex(i).ToString().PadLeft(5, Constants.Space) + strVal;
        //            slNumer.Add(strKey, strVal);
        //        }
        //        sl = slNumer;
        //    }
        //    return sl;
        //}

        //private string GetUnicodeString(string s)
        //{
        //    string strUnicode = "";
        //    string strVal = "";
        //    foreach (char c in s)
        //    {
        //        strVal = String.Format("{0:x4}", (int)c);
        //        strUnicode = strUnicode + strVal;
        //    }
        //    return strUnicode;
        //}

    }
}

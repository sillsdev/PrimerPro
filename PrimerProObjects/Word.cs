using System;
using System.Collections;
using System.Web.UI;
using GenLib;

namespace PrimerProObjects
{
	/// <summary>
	/// Word Class
	/// </summary>
	public class Word
	{
		private Settings m_Settings;
        private Root m_Root;
        private ArrayList m_Senses;     //List of senses
		private ArrayList m_Graphemes;  //List of graphemes
        private ArrayList m_Syllables;  //List of syllables
 		private string m_OrigWord;          //Original word from input file
		private string m_DisplayWord;       //lower case, no unwanted character
		private string m_PartOfSpeech;
		private string m_GlossEnglish;
		private string m_GlossNational;
		private string m_GlossRegional;
		private string m_Plural;
 		private string m_CVPattern;
        private bool m_Available;           //used by teaching order search
        private string m_Key;               //key to sorted word list
        private int m_IndexToSFR;           //index to Standard Format File

		public const char BeginRootCharacter = '[';
		public const char EndRootCharacter = ']';
		public const char SyllableBreakCharacter = '.';
		public const int MaxNumSyllableBreaks = 20;
        public const string DoubleQuote = @"""";
        public const string Bar = "|";

		public Word(string strWord, string strRoot, Settings s)
		{
			m_Settings = s;
			m_OrigWord = strWord;
            BuildWord();
            this.Key = this.DisplayWord;
            this.Root = new Root(strRoot, s);
		}

		public Word(string strWord, Settings s)
		{
			m_Settings = s;
			m_OrigWord = strWord;
 			BuildWord();
            this.Key = this.DisplayWord;
            this.Root = null;
		}

        public Root Root
        {
            get { return m_Root; }
            set { m_Root = value; }
        }

        public ArrayList Senses
        { 
            get { return m_Senses; }
            set { m_Senses = value;}
        }

        public ArrayList Graphemes
		{
			get {return m_Graphemes;}
			set {m_Graphemes = value;}
		}

        public ArrayList Syllables
        {
            get { return m_Syllables; }
            set { m_Syllables = value; }
        }

        public string OrigWord
		{
			get {return m_OrigWord;}
		}

		public string DisplayWord
		{
			get {return m_DisplayWord;}
		}

		public string PartOfSpeech
		{
			get {return m_PartOfSpeech;}
			set {m_PartOfSpeech = value;}
		}

		public string GlossEnglish
		{
			get {return m_GlossEnglish;}
			set {m_GlossEnglish = value;}
		}

		public string GlossNational
		{
			get {return m_GlossNational;}
			set {m_GlossNational = value;}
		}

		public string GlossRegional
		{
			get {return m_GlossRegional;}
			set {m_GlossRegional = value;}
		}

		public string Plural
		{
			get {return m_Plural;}
			set {m_Plural = value;}
		}

		public string CVPattern
		{
			get {return m_CVPattern;}
		}

        public bool Available
        {
            get { return m_Available; }
            set { m_Available = value; }
        }

        public string Key
        {
            get { return m_Key; }
            set { m_Key = value; }
        }

        public int IndexToSFR
        {
            get { return m_IndexToSFR; }
            set { m_IndexToSFR = value; }
        }
   
        public string GetWordWithoutTone()
		{
			string strWord = "";
			int ndx = 0;
			Grapheme grf = null;
			Tone tone = null;
			GraphemeInventory gi = m_Settings.GraphemeInventory;
			for (int i = 0; i < this.GraphemeCount(); i++)
			{
				grf = this.GetGrapheme(i);
				ndx = gi.FindToneIndex(grf.Symbol);
				if (ndx >=0)
				{
					tone = gi.GetTone(ndx);
                    Grapheme tbu = tone.ToneBearingUnit;
                    if (tbu != null)
					    strWord += tbu.Symbol;
				}
				else strWord += grf.Symbol;
			}
			return strWord;
		}

        public string GetWordInLowerCase()
        {
            string strWord = "";
            Grapheme grf = null;
            GraphemeInventory gi = m_Settings.GraphemeInventory;
            for (int i = 0; i < this.GraphemeCount(); i++)
            {
                grf =  this.GetGrapheme(i);
                strWord += grf.Symbol;
            }
            return strWord;
        }

        public string GetCVShapeOfWord()
        {
            string strCV = "";
            Grapheme grf = null;
            for (int i = 0; i < this.GraphemeCount(); i++)
            {
                grf = this.GetGraphemeWithoutTone(i);
                if (grf.IsConsonant)
                {
                    strCV += GraphemeInventory.kConsonant;
                }
                else if (grf.IsVowel)
                {
                    strCV += GraphemeInventory.kVowel;
                }
                else strCV += GraphemeInventory.kUnknown;
            }
            return strCV;
        }

        public string GetWordWithHighlightGrapheme(string strGrapheme)
        {
            string strWord = "";
            GraphemeInventory gi = m_Settings.GraphemeInventory;
            strWord = this.DisplayWord;
            if (this.ContainInWord(strGrapheme))
                strWord = Constants.kHCOn + strWord + Constants.kHCOff;
            return strWord;
        }

        public string GetWordWithHighlightGrapheme(ArrayList alGraphemes)
        {
            string strWord = "";
            GraphemeInventory gi = m_Settings.GraphemeInventory;
            strWord = this.DisplayWord;
            if (this.ContainInWord(alGraphemes))
                strWord = Constants.kHCOn + strWord + Constants.kHCOff;
            return strWord;
        }

        public string GetWordWithSyllBreaks()
        {
            string strWord = "";
            Syllable syll = null;
            for (int i = 0; i < this.SyllableCount();  i++)
            {
                syll = this.GetSyllable(i);
                strWord += syll.GetSyllableInLowerCase();
                strWord += Word.SyllableBreakCharacter;
            }
            if (strWord.Length > 0 )
                strWord = strWord.Substring(0, strWord.Length - 1);     // get ride of last syllable break chaacter
            return strWord;
        }
        
        public string GetGloss()
		{
			string strGloss = "";
			if ( m_Settings.OptionSettings.ViewGlossEnglish )
				strGloss = this.GlossEnglish;
			if ( m_Settings.OptionSettings.ViewGlossNational )
			{
				if ( strGloss == "" )
					strGloss = this.GlossNational;
				else strGloss += Bar + this.GlossNational;
			}
			if ( m_Settings.OptionSettings.ViewGlossRegional )
			{
				if ( strGloss == "" )
					strGloss = this.GlossRegional;
				else strGloss += Bar + this.GlossRegional;
			}
			return strGloss;
		}

        public Syllable GetSyllable(int n)
		{
            if ( n < this.SyllableCount() )
                return (Syllable) this.Syllables[n];
            else return null;
		}

		public Grapheme GetGrapheme(int n)
		{
			if ( n < this.Graphemes.Count )
				return (Grapheme) this.Graphemes[n];
			else return null;
		}

		public Grapheme GetGraphemeWithoutTone(int n)
		{
			Grapheme grf = null;
			int ndx = 0;
			Tone tone = null;
			GraphemeInventory gi = m_Settings.GraphemeInventory;
			if (n < this.Graphemes.Count)
			{
				grf = GetGrapheme(n);
				ndx = gi.FindToneIndex(grf.Symbol);
				if (ndx >=0)
				{
					tone = gi.GetTone(ndx);
					grf = tone.ToneBearingUnit;
				}
			}
			return grf;
		}
 
        public int GraphemeCount()
		{
			if (this.Graphemes != null)
				return this.Graphemes.Count;
			else return 0;
		}

        public int SyllableCount()
        {
            if (this.Syllables != null)
                return this.Syllables.Count;
            else return 0;
        }

        public bool ContainInWord(Consonant cns)
        {
            bool flag = false;
            Grapheme grf = null;
            GraphemeInventory gi = m_Settings.GraphemeInventory;
            for (int n = 0; n < this.GraphemeCount(); n++)
            {
                grf = this.GetGrapheme(n);
                if (grf.IsConsonant)
                {
                    if (cns.IsSame(grf))
                      flag = true;  
                }
            }
            return flag;
        }

        public bool ContainInWord(Vowel vwl)
        {
            bool flag = false;
            Grapheme grf = null;
            GraphemeInventory gi = m_Settings.GraphemeInventory;
            for (int n = 0; n < this.GraphemeCount(); n++)
            {
                grf = this.GetGrapheme(n);
                if (grf.IsVowel)
                {
                    if (vwl.IsSame(grf))
                        flag = true;
                }
            }
            return flag;
        }

        public bool ContainInWord(Tone tone)
        {
            bool flag = false;
            Grapheme grf = null;
            GraphemeInventory gi = m_Settings.GraphemeInventory;
            for (int n = 0; n < this.GraphemeCount(); n++)
            {
                grf = this.GetGrapheme(n);
                if (grf.IsTone)
                {
                    if (tone.IsSame(grf))
                        flag = true;
                }
            }
            return flag;
        }

        public bool ContainInWord(Syllograph syllograph)
        {
            bool flag = false;
            Grapheme grf = null;
            GraphemeInventory gi = m_Settings.GraphemeInventory;
            for (int n = 0; n < this.GraphemeCount(); n++)
            {
                grf = this.GetGrapheme(n);
                if (grf.IsSyllograph)
                {
                    if (syllograph.IsSame(grf))
                        flag = true;
                }
            }
            return flag;
        }

        public bool ContainInWord(string strGrapheme)
		{
			bool flag = false;
			string strSymbol = "";
            string strUpper = "";
			Grapheme grf = null;
			GraphemeInventory gi = m_Settings.GraphemeInventory;

			for (int n = 0; n < this.GraphemeCount(); n++)
			{
				grf = this.GetGrapheme(n);
                strSymbol = grf.Symbol;
                strUpper = grf.UpperCase;
                if ( (strGrapheme == strSymbol)  || (strGrapheme == strUpper) )
                    flag = true;
			}
			return flag;
		}

        public bool ContainInWord(ArrayList alGraphemes)
        {
            bool flag = false;
            string strSymbol = "";
            string strUpper = "";
            string strGrapheme = "";
            Grapheme grf = null;
            GraphemeInventory gi = m_Settings.GraphemeInventory;

            for (int n = 0; n < this.GraphemeCount(); n++)
            {
                grf = this.GetGrapheme(n);
                strSymbol = grf.Symbol;
                strUpper = grf.UpperCase;
                for (int j = 0; j < alGraphemes.Count; j++)
                {
                    strGrapheme = (string) alGraphemes[j];
                    if ((strGrapheme == strSymbol) || (strGrapheme == strUpper))
                    {
                        flag = true;
                        break;
                    }
                }
            }
            return flag;
        }

        public bool HasSyllographFeatures(SyllographFeatures.SyllographType typ, string val)
        {
            bool flag = false;
            Grapheme grf = null;
            Syllograph syllogrf  = null;
            GraphemeInventory gi = m_Settings.GraphemeInventory;
            int ndx = -1;
            for (int n = 0; n < this.GraphemeCount(); n++)
            {
                grf = this.GetGrapheme(n);
                if (grf.IsSyllograph)
                {
                    ndx = gi.FindSyllographIndex(grf.Symbol);
                    if (ndx >= 0)
                    {
                        syllogrf = gi.GetSyllograph(ndx);
                        if (typ == SyllographFeatures.SyllographType.Pri)
                        {
                            if (syllogrf.CategoryPrimary == val)
                                flag = true;
                        }
                        else if (typ == SyllographFeatures.SyllographType.Sec)
                        {
                            if (syllogrf.CategorySecondary == val)
                                flag = true;
                        }
                        else if (typ == SyllographFeatures.SyllographType.Ter)
                        {
                            if (syllogrf.CategoryTertiary == val)
                                flag = true;
                        }
                    }
                }
            }
            return flag;
        }

        public Word Replace(Grapheme grf1, Grapheme grf2)
        {
            string strWord = "";
            Word wrd = null;
            Grapheme grf = null;
            for (int i = 0; i < this.GraphemeCount(); i++)
            {
                grf = this.GetGrapheme(i);
                if (grf.IsSame(grf1))
                    strWord = strWord + grf2.Symbol;
                else strWord = strWord + grf.Symbol;
            }
            wrd = new Word(strWord, m_Settings);
            return wrd;
        }

        public bool IsToneContainInWord(string strTone)
		{
			bool flag = false;
			string str = "";
			for (int n = 0; n < this.GraphemeCount(); n++)
				str += this.GetGrapheme(n).Symbol;
			if (str.IndexOf(strTone) >= 0)
				flag = true;
			return flag;
		}

		public bool IsOpenSyllable(int n)
		//nth syllable
		{
			bool fReturn = false;
            Syllable syll = this.GetSyllable(n);
            fReturn = syll.IsOpenSyllable();
			return fReturn;
		}

		public bool IsClosedSyllable(int n)
		//nth syllable
		{
			bool fReturn = false;
            Syllable syll = this.GetSyllable(n);
            fReturn = syll.IsClosedSyllable();
            return fReturn;
		}

		public bool IsInSyllable(string strGrf, int n)
		//nth syllable
		{
			bool fReturn = false;
            Syllable syll = this.GetSyllable(n);
            fReturn = syll.IsInSyllable(strGrf);
			return fReturn;
		}

		public bool IsInOpenSyllable(string strGrf)
		{
			bool fReturn = false;
            Syllable syll = null;
			for (int i = 0; i < this.SyllableCount(); i++)
			{
                syll = this.GetSyllable(i);
				if (syll.IsInSyllable(strGrf))
				{
					if (syll.IsOpenSyllable())
					{
						fReturn = true;
						break;
					}
				}
			}
			return fReturn;
		}

        public bool IsSyllableOnset(string strGrapheme)
        {
            bool fReturn = false;
            Syllable syll = null;
            for (int i = 0; i < this.SyllableCount(); i++)
            {
                syll = this.GetSyllable(i);
                if (syll.IsOnset(strGrapheme))
                {
                    fReturn = true;
                    break;
                }
            }
            return fReturn;
        }

        public bool IsSyllableCoda(string strGrapheme)
        {
            bool fReturn = false;
            Syllable syll = null;
            for (int i = 0; i < this.SyllableCount(); i++)
            {
                syll = this.GetSyllable(i);
                if (syll.IsCoda(strGrapheme))
                {
                    fReturn = true;
                    break;
                }
            }
            return fReturn;
        }
        
		public bool IsInClosedSyllable(string strGrf)
		{
			bool fReturn = false;
            Syllable syll = null;
			for (int i = 0; i < this.SyllableCount(); i++)
			{
                syll = this.GetSyllable(i);
				if (syll.IsInSyllable(strGrf))
				{
					if (syll.IsClosedSyllable())
					{
						fReturn = true;
						break;
					}
				}
			}
			return fReturn;
		}

		public bool IsSameVowel()
		{
			bool flag = true;
			string strPrev = "";
			string strSym = "";
			for (int i = 0; i < this.GraphemeCount(); i++)
			{
				if ( this.GetGraphemeWithoutTone(i).IsVowel )
				{
					strSym = this.GetGraphemeWithoutTone(i).Symbol;
					if ( (strPrev != "")  && (strSym != strPrev) )
					{
						flag = false;
						break;
					}
					strPrev = strSym;	
				}
			}
			return flag;
		}
		
		public bool IsWordInitial(string strGrf)
		{
            bool flag = false;
            if (this.GraphemeCount() > 0)
            {
                if ((strGrf == this.GetGrapheme(0).Symbol) || (strGrf == this.GetGrapheme(0).UpperCase))
                    flag = true;
            }
            return flag;
        }

		public bool IsWordMedial(string strGrf)
		{
			bool flag = false;
            if (this.GraphemeCount() > 2)
            {
                for (int i = 1; i < this.GraphemeCount() - 1; i++)
                {
                    if ((strGrf == this.GetGrapheme(i).Symbol) || (strGrf == this.GetGrapheme(i).UpperCase))
                    {
                        flag = true;
                        break;
                    }
                }
            }
			return flag;
		}

		public bool IsWordFinal(string strGrf)
		{
			bool flag = false;
            if (this.GraphemeCount() > 0)
            {
                int n = this.GraphemeCount() - 1;       //Last grapheme in word
                if ((strGrf == this.GetGrapheme(n).Symbol) || (strGrf == this.GetGrapheme(n).UpperCase))
                    flag = true;
            }
			return flag;
		}

        public bool IsSyllableInit(string strGrapheme)
        {
            bool fReturn = false;
            Syllable syll = null;
            for (int i = 0; i < this.SyllableCount(); i++)
            {
                syll = this.GetSyllable(i);
                if (syll.IsSyllableInitial(strGrapheme))
                {
                    fReturn = true;
                    break;
                }
            }
            return fReturn;
        }

        public bool IsSyllableMedial(string strGrapheme)
        {
            bool fReturn = false;
            Syllable syll = null;
            for (int i = 0; i < this.SyllableCount(); i++)
            {
                syll = this.GetSyllable(i);
                if (syll.IsSyllableMedial(strGrapheme))
                {
                    fReturn = true;
                    break;
                }
            }
            return fReturn;
        }

        public bool IsSyllableFinal(string strGrapheme)
        {
            bool fReturn = false;
            Syllable syll = null;
            for (int i = 0; i < this.SyllableCount(); i++)
            {
                syll = this.GetSyllable(i);
                if (syll.IsSyllableFinal(strGrapheme))
                {
                    fReturn = true;
                    break;
                }
            }
            return fReturn;
        }

        public bool IsInitialGrapheme(string strGrf)
		{
			bool flag = false;
			string str = "";
			if (this.GraphemeCount() > 0)
			{
				str = this.GetGraphemeWithoutTone(0).Symbol;
				if ( str == strGrf )
					flag = true;
			}
			return flag;
		}

		public bool IsMedialGrapheme(string strGrf)
		{
			bool flag = false;
			string str = "";
			for (int i = 1; i < this.GraphemeCount() - 1; i++)
			{
				str = this.GetGraphemeWithoutTone(i).Symbol;
				if (str == strGrf)
				{
					flag = true;
					break;
				}
			}
			return flag;
		}

		public bool IsFinalGrapheme(string strGrf)
		{
			bool flag = false;
			string str = "";
			if (this.GraphemeCount() > 0)
			{
				str  = this.GetGraphemeWithoutTone(this.GraphemeCount() - 1).Symbol;
				if (str == strGrf)
					flag = true;
			}
			return flag;
		}

		public bool IsInInitialSyllable(string strGrf)
		{
			bool flag = false;
            Syllable syll = null;
			if (this.SyllableCount() > 0 )
			{
                syll = this.GetSyllable(0);
                if (syll.IsInSyllable(strGrf))
                    flag = true;
			}
			return flag;
		}

		public bool IsInMedialSyllable(string strGrf)
		{
			bool flag = false;
			if (this.SyllableCount() > 2)
			{
				for (int i = 1; i < this.SyllableCount() -1; i++)
				{
					if ( this.GetSyllable(i).IsInSyllable(strGrf) )
					{
						flag = true;
						break;
					}
				}
			}
			return flag;
		}

		public bool IsInFinalSyllable(string strGrf)
		{
			bool flag = false;
            Syllable syll = null;
			if (this.SyllableCount() > 0 )
			{
                syll = this.GetSyllable(this.SyllableCount() -1);
                if (syll.IsInSyllable(strGrf))
                    flag = true;
			}
			return flag;
		}

        public bool IsBuildableWord(ArrayList alGraphemes)
        // alGraphemes  - array list of symbols having string type, not grapheme type
		{
			bool flag = false;
			string strGrf = "";
			string strSym = "";

			for (int i = 0; i < this.GraphemeCount(); i++)
			{
				strGrf = this.GetGrapheme(i).Symbol;
				flag = false;
				for (int j = 0; j < alGraphemes.Count; j++)
				{
                    strSym = alGraphemes[j].ToString();
					if  (strGrf == strSym)
					{
						flag = true;
						break;
					}
				}
				if ( !flag )
					break;
			}
			return flag;
		}

        public bool IsSightWord()
        {
            bool fReturn = false;
            string strWord = this.DisplayWord;
            string strSW = "";
            SightWords sw = this.m_Settings.SightWords;
            for (int i = 0; i < sw.Count(); i++)
            {
                strSW = sw.GetWord(i);
                if (strWord == strSW)
                    fReturn = true;
            }
            return fReturn;
        }

        public bool IsSame(Word wrd)
        {
            bool fReturn = false;
            Grapheme grf = null;
            if (this.GraphemeCount() == wrd.GraphemeCount())
            {
                fReturn = true;
                for (int i = 0; i < this.GraphemeCount(); i++)
                {
                    grf = this.GetGrapheme(i);
                    if (!grf.IsSame(wrd.GetGrapheme(i)))
                    {
                        fReturn = false;
                        break;
                    }
                }
            }
            return fReturn;
        }

        public int IsMinimalPair(Word wrd, bool fIgnoreTone)
        {
            int nPosn = -1;         // Position of Difference
            int nDiff = 0;          // Number of differences
            Grapheme grf1 = null;
            Grapheme grf2 = null;

            if (this.GraphemeCount() == wrd.GraphemeCount())
            {
                for (int i = 0; i < wrd.GraphemeCount(); i++)
                {
                    if (fIgnoreTone)
                        grf1 = this.GetGraphemeWithoutTone(i);
                    else grf1 = this.GetGrapheme(i);
                    if (fIgnoreTone)
                        grf2 = wrd.GetGraphemeWithoutTone(i);
                    else grf2 = wrd.GetGrapheme(i);
                    if (!grf1.IsSame(grf2))
                    {
                        nDiff++;
                        nPosn = i;
                    }
                }
                if (nDiff != 1)
                    nPosn = -1;
            }
            return nPosn;
        }

        public bool IsMinimalPair(Word wrd, bool fIgnoreTone, Grapheme grapheme1, Grapheme grapheme2)
        {
            bool fReturn = false;
            int nDiff = 0;
            Grapheme grf1 = null;
            Grapheme grf2 = null;

            if (this.GraphemeCount() == wrd.GraphemeCount())
            {
                for (int i = 0; i < wrd.GraphemeCount(); i++)
                {
                    if (fIgnoreTone)
                        grf1 = this.GetGraphemeWithoutTone(i);
                    else grf1 = this.GetGrapheme(i);
                    if (fIgnoreTone)
                        grf2 = wrd.GetGraphemeWithoutTone(i);
                    else grf2 = wrd.GetGrapheme(i);
                    if (!grf1.IsSame(grf2))
                    {
                        if (nDiff == 0)
                        {
                            if ((grf1.IsSame(grapheme1)) && (grf2.IsSame(grapheme2)))
                                fReturn = true;
                            nDiff++;
                        }
                        else
                        {
                            fReturn = false;
                            nDiff++;
                        }
                    }
                }
            }
            return fReturn;
        }

        public bool IsMinimalPairHarmony(Word wrd, bool fIgnoreTone, Grapheme grapheme1, Grapheme grapheme2)
        {
            bool fReturn = false;
            Grapheme grf1 = null;
            Grapheme grf2 = null;
            ArrayList alDiff = new ArrayList();
            Pair pair = null;
 
            if (this.GraphemeCount() == wrd.GraphemeCount())
            {
                for (int i = 0; i < wrd.GraphemeCount(); i++ )
                {
                    if (fIgnoreTone)
                        grf1 = this.GetGraphemeWithoutTone(i);
                    else grf1 = this.GetGrapheme(i);
                    if (fIgnoreTone)
                        grf2 = wrd.GetGraphemeWithoutTone(i);
                    else grf2 = wrd.GetGrapheme(i);

                    if (!grf1.IsSame(grf2))         // collect all their differences
                    {
                        pair = new Pair(grf1, grf2);
                        alDiff.Add(pair);
                    }
                }

                if (alDiff.Count < 1)
                    fReturn = false;
                else 
                {
                    int i = 0;
                    fReturn = true;
                    while (i < alDiff.Count)
                    {
                        pair = (Pair) alDiff[i];
                        grf1 = (Grapheme)pair.First;
                        grf2 = (Grapheme)pair.Second;
                        if (grf1.IsSame(grapheme1) && grf2.IsSame(grapheme2))
                            i++;
                        else
                        {
                            fReturn = false;
                            break;
                        }
                    }
                }
            }
            return fReturn;
        }

        public ArrayList GetWordInfoAsArray()
        {
            ArrayList al = new ArrayList();
            OptionList ol = null;
            if (m_Settings != null)
                ol = m_Settings.OptionSettings;

            al.Add(this.DisplayWord);
            al.Add(this.GetGloss());
            if (ol.ViewOrigWord)
                al.Add(this.OrigWord);
            if (ol.ViewPS)
                al.Add(this.PartOfSpeech);
            if (ol.ViewPlural)
                al.Add(this.Plural);
            if (ol.ViewCVPattern)
                al.Add(this.CVPattern);
            if (ol.ViewSyllBreaks)
                al.Add(this.GetWordWithSyllBreaks());
            if (ol.ViewWordWithoutTone)
                al.Add(this.GetWordWithoutTone());
            if (ol.ViewRoot)
            {
                if (this.Root != null)
                    al.Add(this.Root.DisplayRoot);
            }
            if (ol.ViewRootCVPattern)
            {
                if (this.Root != null)
                    al.Add(this.Root.CVPattern);
            }
            if (ol.ViewRootSyllBreaks)
            {
                if (this.Root != null)
                    al.Add(this.Root.GetRootwithSyllBreaks());
            }
            if (ol.ViewRootWithoutTone)
            {
                if (this.Root != null)
                    al.Add(this.Root.GetRootWithoutTone());
            }
            return al;
        }

        public string HighlightMissingGraphemes(ArrayList alGraphemes)
		{
			string strRslt = "";
			string strGrf = "";			//symbol for compare
			Grapheme grf = null;
            //Tone syllograph = null;
			GraphemeInventory gi = m_Settings.GraphemeInventory;
            //int ndx = 0;
			string strSym;

			for (int i = 0; i < this.GraphemeCount(); i++)
			{
				grf = this.GetGrapheme(i);
                strGrf = grf.Symbol;
				bool flag = false;
				for (int j = 0; j < alGraphemes.Count; j++)
				{
					strSym = alGraphemes[j].ToString();
					if  (strGrf == strSym)
					{
						flag = true;
						break;
					}
				}
				if ( flag )
					strRslt += strGrf;
				else strRslt += Constants.kHCOn + strGrf + Constants.kHCOff;
			}
			return strRslt;
		}

        private void BuildWord()
        {
            this.Graphemes = new ArrayList();
            this.Syllables = new ArrayList();
            this.m_DisplayWord = "";
            this.m_CVPattern = "";
            this.Available = true;
            this.Key = "";
            this.IndexToSFR = -1;
            
            GraphemeInventory gi = m_Settings.GraphemeInventory;
            int nMaxSize = this.m_Settings.OptionSettings.MaxSizeGrapheme;
            Grapheme grf = null;
            string strSymbol = "";          //current symbol
            string str = "";                //temp string
            string strWord = "";
            ReplacementList list = null;    //Import replacement list
            
            // get rid of unwanted charactera
            for (int i = 0; i < this.OrigWord.Length; i++)
            {
                strSymbol = this.OrigWord.Substring(i, 1);
                if (!IsRootStart(strSymbol))        //ignore root start character
                {
                    if (!IsRootEnd(strSymbol))      //ignore root end character
                    {
                        // Process import characters to ignore
                        str = m_Settings.OptionSettings.ImportIgnoreChars;
                        if (strSymbol.IndexOfAny(str.ToCharArray()) < 0)
                        {
                            // Ignore General Punctuation
                            str = m_Settings.OptionSettings.GeneralPunct;
                            str = str.Replace(SyllableBreakCharacter, Constants.NullChar);
                            str = str.Replace(Constants.Space, Constants.NullChar);
                            if (strSymbol.IndexOfAny(str.ToCharArray()) < 0)
                            {
                                //Ignore Ending Punctuation
                                str = m_Settings.OptionSettings.EndingPunct;
                                str = str.Replace(SyllableBreakCharacter, Constants.NullChar);
                                if (strSymbol.IndexOfAny(str.ToCharArray()) < 0)
                                {
                                    // Ignore double quote
                                    if (!IsDoubleQuote(strSymbol))
                                    {
                                        str = m_Settings.OptionSettings.ImportIgnoreChars;
                                        if (strSymbol.IndexOfAny(str.ToCharArray()) < 0)
                                            strWord += strSymbol;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // Process import replacement list
            list = m_Settings.OptionSettings.ImportReplacementList;
            if (list != null)
            {
                for (int k = 0; k < list.ListCount(); k++)
                {
                    strWord = strWord.Replace(list.GetReplaceString(k), list.GetWithString(k));
                }
            }

            //Build grapheme list and syllable list (if specified by user)
            string strSyllable = "";
            Syllable syll = null;
            int nLookahead = nMaxSize;
            bool fSyllableBreaks = false;
            for (int i = 0; i < strWord.Length; i++)
            {
                strSymbol = strWord.Substring(i, 1);
                if (IsSyllableBreak(strSymbol))
                {
                    syll = new Syllable(strSyllable, m_Settings);
                    this.Syllables.Add(syll);
                    strSyllable = "";
                    fSyllableBreaks = true;
                }
                else
                {
                    grf = new Grapheme(strSymbol);
                    if ((i + nMaxSize) < strWord.Length)
                        nLookahead = nMaxSize;
                    else nLookahead = strWord.Length - i;
                    for (int j = nLookahead; j > 0; j--)
                    {
                        strSymbol = strWord.Substring(i, j);
                        if ( gi.IsInInventory(strSymbol) )
                        {
                            grf = gi.GetGrapheme(strSymbol);
                            i = i + j - 1;
                            break;
                        }
                    }
                    this.Graphemes.Add(grf);
                    this.m_DisplayWord += grf.Symbol;
                    strSyllable = strSyllable + grf.Symbol;
                }
            }
            if (fSyllableBreaks)        //add last syllable
            {
                syll = new Syllable(strSyllable, m_Settings);
                this.Syllables.Add(syll);
            }

            // Build CV pattern for Word
            this.m_CVPattern = BuildCVPattern();

            if (this.SyllableCount() == 0)		//No syll breaks yet
            {
                if (this.OrigWord != "")
                    BuildWordSyllBreaks();      //Figure out the word breaks.
            }
        }

        private void BuildWordSyllBreaks()
        {
            Grapheme grfPrev = null;
            Grapheme grfCurr = null;
            Grapheme grfNext = null;
            Grapheme grfPrev2 = null;
            Grapheme grfCurr2 = null;
            Grapheme grfNext2 = null;
            GraphemeInventory gi = m_Settings.GraphemeInventory;
            Syllable syll = null;
            ArrayList alSyllables = new ArrayList();
            string strSyllable = "";
            int n = 0;
            bool fCnsBreak = false;     //Indicates a break is needed in a group of Consonants
            
            if (this.GraphemeCount() > 0)
            {
                switch (this.GraphemeCount())
                {
                    case 1:
                        strSyllable = this.GetGrapheme(0).Symbol;
                        syll = new Syllable(strSyllable, m_Settings);
                        n = alSyllables.Add(syll);
                        break;
                    case 2:
                        grfPrev = this.GetGrapheme(0);
                        grfCurr = this.GetGrapheme(1);
                        if (grfCurr != null && grfPrev != null)
                        {
                            if (grfPrev.IsTone)
                                grfPrev2 = this.GetTBU(grfPrev);
                            else grfPrev2 = grfPrev;

                            if (grfCurr.IsTone)
                                grfCurr2 = this.GetTBU(grfCurr);
                            else grfCurr2 = grfCurr;

                            if (grfPrev2.IsSyllograph)      // S?
                            {
                                syll = new Syllable(grfPrev.Symbol, m_Settings);
                                n = alSyllables.Add(syll);
                                syll = new Syllable(grfCurr.Symbol, m_Settings);
                                n = alSyllables.Add(syll);
                            }
                            else if (grfPrev2.IsVowel)
                            {
                                if (grfCurr2.IsSyllograph || grfCurr2.IsVowel)   // VS or VV
                                {
                                    syll = new Syllable(grfPrev.Symbol, m_Settings);
                                    n = alSyllables.Add(syll);
                                    syll = new Syllable(grfCurr.Symbol, m_Settings);
                                    n = alSyllables.Add(syll);
                                }
                                else            // VC or V?
                                {
                                    if ( grfCurr2.IsSyllabicConsonant )
                                    {
                                        syll = new Syllable(grfPrev.Symbol, m_Settings);
                                        n = alSyllables.Add(syll);
                                        syll = new Syllable(grfCurr.Symbol, m_Settings);
                                        n = alSyllables.Add(syll);
                                    }
                                    else
                                    {
                                        strSyllable = grfPrev.Symbol + grfCurr.Symbol;
                                        syll = new Syllable(strSyllable, m_Settings);
                                        n = alSyllables.Add(syll);
                                    }
                                }
                            }
                            else if (grfPrev2.IsConsonant)
                            {
                                if (grfPrev2.IsSyllabicConsonant)
                                {
                                    syll = new Syllable(grfPrev.Symbol, m_Settings);
                                    n = alSyllables.Add(syll);
                                    syll = new Syllable(grfCurr.Symbol, m_Settings);
                                    n = alSyllables.Add(syll);
                                }
                                else
                                {
                                    if (grfCurr2.IsSyllograph)       // CS
                                    {
                                        syll = new Syllable(grfPrev.Symbol, m_Settings);
                                        n = alSyllables.Add(syll);
                                        syll = new Syllable(grfCurr.Symbol, m_Settings);
                                        n = alSyllables.Add(syll);
                                    }
                                    else            // CC or CV or C?
                                    {
                                        if (grfCurr2.IsSyllabicConsonant)
                                        {
                                            syll = new Syllable(grfPrev.Symbol, m_Settings);
                                            n = alSyllables.Add(syll);
                                            syll = new Syllable(grfCurr.Symbol, m_Settings);
                                            n = alSyllables.Add(syll);
                                        }
                                        else
                                        {
                                            strSyllable = grfPrev.Symbol + grfCurr.Symbol;
                                            syll = new Syllable(strSyllable, m_Settings);
                                            n = alSyllables.Add(syll);
                                        }
                                    }
                                }
                            }
                            else                // ??
                            {
                                strSyllable = grfPrev.Symbol + grfCurr.Symbol;
                                syll = new Syllable(strSyllable, m_Settings);
                                n = alSyllables.Add(syll);
                            }
                        }
                        break;
                    default:
                        strSyllable = this.GetGrapheme(0).Symbol;
                        for (int i = 1; (i + 1) < this.GraphemeCount(); i++)
                        {
                            grfPrev = this.GetGrapheme(i - 1);
                            grfCurr = this.GetGrapheme(i);
                            grfNext = this.GetGrapheme(i + 1);
                            if (grfCurr != null)
                            {
                                if (grfCurr.IsTone)
                                    grfCurr2 = this.GetTBU(grfCurr);
                                else grfCurr2 = grfCurr;

                                if (grfPrev.IsTone)
                                    grfPrev2 = this.GetTBU(grfPrev);
                                else grfPrev2 = grfPrev;

                                if (grfNext.IsTone)
                                    grfNext2 = this.GetTBU(grfNext);
                                else grfNext2 = grfNext;

                                if (grfCurr.Symbol == Constants.Space.ToString())     //? ?
                                {
                                    //Syllable break before space
                                    syll = new Syllable(strSyllable, m_Settings);
                                    n = alSyllables.Add(syll);
                                    //strSyllable = grfCurr.Symbol;
                                    strSyllable = "";       // ignore space in syllables
                                }
                                else if (grfCurr2.IsSyllograph)       // ?S?
                                {
                                    //Syllable break before Current
                                    syll = new Syllable(strSyllable, m_Settings);
                                    n = alSyllables.Add(syll);
                                    strSyllable = grfCurr.Symbol;
                                }

                                else if (grfCurr2.IsVowel)
                                {
                                    if (grfPrev2.IsVowel)       // VV?
                                    {
                                        //Syllable break before current
                                        syll = new Syllable(strSyllable, m_Settings);
                                        n = alSyllables.Add(syll);
                                        strSyllable = grfCurr.Symbol;
                                    }
                                    else if (grfPrev2.IsConsonant)  // CV?
                                    {
                                        if (grfPrev2.IsSyllabicConsonant)
                                        {
                                            // Syllable break before current
                                            syll = new Syllable(strSyllable, m_Settings);
                                            n = alSyllables.Add(syll);
                                            strSyllable = grfCurr.Symbol;
                                        }
                                        else
                                        {
                                            //No syllable break
                                            strSyllable = strSyllable + grfCurr.Symbol;
                                        }
                                    }
                                    else if (grfPrev.IsSyllograph)   // SV?
                                    {
                                        //Syllabel break before current
                                        syll = new Syllable(strSyllable, m_Settings);
                                        n = alSyllables.Add(syll);
                                        strSyllable = grfCurr.Symbol;
                                    }
                                    else strSyllable = strSyllable + grfCurr.Symbol;
                                }
                                else if (grfCurr2.IsConsonant)
                                {
                                    if (grfCurr2.IsSyllabicConsonant)
                                    {
                                        //Syllable break before current
                                        syll = new Syllable(strSyllable, m_Settings);
                                        n = alSyllables.Add(syll);
                                        strSyllable = grfCurr.Symbol;
                                    }
                                    else if (grfPrev2.IsVowel)
                                    {
                                        if (grfNext2.IsConsonant)           // VCC 
                                        {
                                            //No syllable break
                                            strSyllable = strSyllable + grfCurr.Symbol;
                                            fCnsBreak = true;
                                        }
                                        else if (grfNext2.IsSyllograph)      // VCS
                                        {
                                            //No syllable break
                                            strSyllable = strSyllable + grfCurr.Symbol;
                                        }
                                        else if (grfNext2.IsVowel)           // VCV
                                        {
                                            //Syllable break before current
                                            syll = new Syllable(strSyllable, m_Settings);
                                            n = alSyllables.Add(syll);
                                            strSyllable = grfCurr.Symbol;
                                        }
                                        else strSyllable = strSyllable + grfCurr.Symbol;
                                    }
                                    else if (grfPrev2.IsConsonant)
                                    {
                                        if (grfPrev2.IsSyllabicConsonant)
                                        {
                                            //Syllable break before current
                                            syll = new Syllable(strSyllable, m_Settings);
                                            n = alSyllables.Add(syll);
                                            strSyllable = grfCurr.Symbol;
                                        }
                                        else if (grfNext2.IsConsonant)   // CCC
                                        {
                                            if (fCnsBreak)
                                            {
                                                //Syllable break before current
                                                syll = new Syllable(strSyllable, m_Settings);
                                                n = alSyllables.Add(syll);
                                                strSyllable = grfCurr.Symbol;
                                                fCnsBreak = false;
                                            }
                                            else
                                            {
                                                //No syllable break
                                                strSyllable = strSyllable + grfCurr.Symbol;
                                            }
                                        }
                                        else if (grfNext2.IsVowel)      // CCV
                                        {
                                            if (fCnsBreak)
                                            {
                                                //Syllable break before current
                                                syll = new Syllable(strSyllable, m_Settings);
                                                n = alSyllables.Add(syll);
                                                strSyllable = grfCurr.Symbol;
                                                fCnsBreak = false;
                                            }
                                            else strSyllable = strSyllable + grfCurr.Symbol;
                                        }
                                        else strSyllable = strSyllable + grfCurr.Symbol;  // CCS or CC?
                                    }
                                    else if (grfPrev2.IsSyllograph)      // SC?
                                    {
                                        //Syllable break before current
                                        syll = new Syllable(strSyllable, m_Settings);
                                        n = alSyllables.Add(syll);
                                        strSyllable = grfCurr.Symbol;
                                    }
                                    else strSyllable = strSyllable + grfCurr.Symbol;
                                }
                                else if (grfCurr.IsTone)   // Is tone without TBU
                                {
                                    //Syllable break before tone
                                    syll = new Syllable(strSyllable, m_Settings);
                                    n = alSyllables.Add(syll);
                                    strSyllable = grfCurr.Symbol;
                                }
                                else
                                {
                                    if (grfPrev2.IsVowel || grfPrev2.IsSyllograph)  //V? or S?
                                    {
                                        //Syllable break before current
                                        syll = new Syllable(strSyllable, m_Settings);
                                        n = alSyllables.Add(syll);
                                        strSyllable = grfCurr.Symbol;
                                    }
                                    else strSyllable = strSyllable + grfCurr.Symbol;
                                }
                            }
                        }       //for statement
                        // the last syllable
                        if (grfNext != null)
                        {
                            if (grfCurr2.IsSyllograph)   // S?
                            {
                                syll = new Syllable(strSyllable, m_Settings);
                                n = alSyllables.Add(syll);
                                strSyllable = grfNext.Symbol;
                            }
                            else if (grfCurr2.IsVowel)
                            {
                                if (grfNext2.IsSyllograph || grfNext2.IsVowel)   // VS or VV
                                {
                                    syll = new Syllable(strSyllable, m_Settings);
                                    n = alSyllables.Add(syll);
                                    strSyllable = grfNext.Symbol;
                                }
                                else if (grfNext2.IsSyllabicConsonant)
                                {
                                    syll = new Syllable(strSyllable, m_Settings);
                                    n = alSyllables.Add(syll);
                                    strSyllable = grfNext.Symbol;
                                }
                                else strSyllable = strSyllable + grfNext.Symbol;
                            }
                            else if (grfCurr2.IsConsonant)
                            {
                                if (grfCurr2.IsSyllabicConsonant)
                                {
                                    syll = new Syllable(strSyllable, m_Settings);
                                    n = alSyllables.Add(syll);
                                    strSyllable = grfNext.Symbol;
                                }
                                else if (grfNext2.IsSyllograph || grfNext2.IsSyllabicConsonant)   // CS
                                {
                                    syll = new Syllable(strSyllable, m_Settings);
                                    n = alSyllables.Add(syll);
                                    strSyllable = grfNext.Symbol;
                                }
                                else strSyllable = strSyllable + grfNext.Symbol;
                            }
                            else strSyllable = strSyllable + grfNext.Symbol;
                        }
                        syll = new Syllable(strSyllable, m_Settings);
                        n = alSyllables.Add(syll);

                        if (alSyllables.Count > 1)      // check last syllable contains all consonants
                        // if so, add to previous syllable
                        {
                            // if last syllable is nothing but non-syllabic consonants, add to previous syllable
                            Syllable syll1 = (Syllable)alSyllables[alSyllables.Count - 2];  //2nd to last syllable
                            Syllable syll2 = (Syllable)alSyllables[alSyllables.Count - 1];  //last syllable
                            bool flag = true;
                            for (int i = 0; i < syll2.GraphemeCount(); i++)
                            {
                                grfCurr = syll2.GetGrapheme(i);
                                if (grfCurr != null)
                                    if (!grfCurr.IsConsonant  || grfCurr.IsSyllabicConsonant)
                                        flag = false;
                            }
                            if (syll1 != null)
                            {
                                grfPrev = syll1.GetGrapheme(syll1.GraphemeCount() - 1); // last grapheme
                                if (grfPrev != null)
                                    if (grfPrev.IsSyllograph || grfPrev.IsSyllabicConsonant)
                                        flag = false;
                            }
                            if (flag)
                            {
                                for (int i = 0; i < syll2.GraphemeCount(); i++)
                                {
                                    grfCurr = syll2.GetGrapheme(i);
                                    syll1.Graphemes.Add(grfCurr);
                                }
                                alSyllables.RemoveAt(alSyllables.Count - 1);
                                alSyllables.RemoveAt(alSyllables.Count - 1);
                                alSyllables.Add(syll1);
                            }
                        } 
                        break;
                }
                this.Syllables = alSyllables;
            }
        }
 
        private Grapheme GetTBU(Grapheme grf)
        {
            Grapheme grfTBU = null;
            int ndx = this.m_Settings.GraphemeInventory.FindToneIndex(grf.Symbol);
            Tone tone = this.m_Settings.GraphemeInventory.GetTone(ndx);
            grfTBU = tone.ToneBearingUnit;
            return grfTBU;
        }

        private string BuildCVPattern()
        {
            Grapheme grf = null;
            string strCVPatt = "";
            for (int i = 0; i < this.GraphemeCount(); i++)
            {
                grf = this.GetGrapheme(i);
                strCVPatt += this.GetCVMarker(grf);
            }
            return strCVPatt;
        }

        private string GetCVMarker(Grapheme grf)
        {
            string strMarker = "";
            if (grf != null)
            {
                GraphemeInventory gi = m_Settings.GraphemeInventory;
                int ndx = 0;
                Consonant cns = null;
                Vowel vwl = null;
                Tone tone = null;
                Syllograph syllograph = null;
                if (grf.Symbol.Trim() == "")	//if space character
                {
                    strMarker = Constants.Space.ToString();
                    return strMarker;
                }

                strMarker = GraphemeInventory.kUnknown;
                if (grf.IsTone)
                {
                    strMarker = m_Settings.OptionSettings.CVTone;
                    ndx = gi.FindToneIndex(grf.Symbol);
                    tone = gi.GetTone(ndx);
                    if (tone.ToneBearingUnit != null)
                    {
                        if (tone.ToneBearingUnit.IsVowel)
                            grf = tone.ToneBearingUnit;
                        else if (tone.ToneBearingUnit.IsConsonant)
                            grf = tone.ToneBearingUnit;
                        else strMarker = m_Settings.OptionSettings.CVTone;
                    }
                }
                if (grf.IsConsonant)
                {
                    strMarker = m_Settings.OptionSettings.CVCns;
                    ndx = gi.FindConsonantIndex(grf.Symbol);
                    cns = gi.GetConsonant(ndx);
                    if (cns.IsSyllabic)
                        strMarker = m_Settings.OptionSettings.CVSyllbc;
                    if (cns.IsAspirated)
                        strMarker = m_Settings.OptionSettings.CVAspir;
                    if (cns.IsVelarized)
                        strMarker = m_Settings.OptionSettings.CVVelrzd;
                    if (cns.IsPalatalized)
                        strMarker = m_Settings.OptionSettings.CVPaltzd;
                    if (cns.IsLabialized)
                        strMarker = m_Settings.OptionSettings.CVLablzd;
                    if (cns.IsPrenasalized)
                        strMarker = m_Settings.OptionSettings.CVPrensl;
                }
                if (grf.IsVowel)
                {
                    strMarker = m_Settings.OptionSettings.CVVwl;
                    ndx = gi.FindVowelIndex(grf.Symbol);
                    vwl = gi.GetVowel(ndx);
                    if (vwl.IsLong)
                        strMarker = m_Settings.OptionSettings.CVVwlLng;
                    if (vwl.IsNasal)
                        strMarker = m_Settings.OptionSettings.CVVwlNsl;
                    if (vwl.IsComplex)
                        strMarker = m_Settings.OptionSettings.CVVwlDip;
                }
                if (grf.IsSyllograph)
                {
                    strMarker = m_Settings.OptionSettings.CVSyllograph;
                    ndx = gi.FindSyllographIndex(grf.Symbol);
                    syllograph = gi.GetSyllograph(ndx);
                }
            }
            return strMarker;
        }

        private bool IsDoubleQuote(string strSymbol)
        {
            bool flag = false;
            if ( strSymbol == Word.DoubleQuote)
                flag = true;
            return  flag;
        }

        private bool IsRootStart(string strSymbol)
		{
			bool flag = false;
			if ( strSymbol == Word.BeginRootCharacter.ToString())
				flag = true;
			return flag;
		}

		private bool IsRootEnd(string strSymbol)
		{
			bool flag = false;
			if (strSymbol == Word.EndRootCharacter.ToString())
				flag = true;
			return flag;
		}

		private bool IsSyllableBreak(string strSymbol)
		{
			bool flag = false;
			if (strSymbol == Word.SyllableBreakCharacter.ToString())
				flag = true;
			return flag;
		}

	}
}

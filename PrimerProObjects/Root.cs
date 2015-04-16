using System;
using System.Collections;
using System.Text;
using System.Web.UI;
using GenLib;

namespace PrimerProObjects
{
    public class Root
    {
        private Settings m_Settings;
        private ArrayList m_RootGraphemes;
        private ArrayList m_RootSyllables;
        private string m_OrigRoot;
        private string m_DisplayRoot;
        private string m_CVPattern;

        public Root(string strRoot, Settings s)
        {
            m_Settings = s;
            m_OrigRoot = strRoot;
            BuildRoot();
        }

        public ArrayList Graphemes
        {
            get { return m_RootGraphemes; }
            set { m_RootGraphemes = value; }
        }

        public ArrayList Syllables
        {
            get { return m_RootSyllables; }
            set { m_RootSyllables = value; }
        }

        public string OrigRoot
        {
            get { return m_OrigRoot; }
        }

        public string DisplayRoot
        {
            get { return m_DisplayRoot; }
        }

        public string CVPattern
        {
            get {return m_CVPattern;}
        }

        public int RootLength()
        {
            return m_DisplayRoot.Length;
        }

        public string GetRootWithoutTone()
        {
            string strRoot = "";
            int ndx = 0;
            Grapheme seg = null;
            Tone tone = null;
            GraphemeInventory gi = m_Settings.GraphemeInventory;
            for (int i = 0; i < this.GraphemeCount(); i++)
            {
                seg = this.GetGrapheme(i);
                ndx = gi.FindToneIndex(seg.Symbol);
                if (ndx >= 0)
                {
                    tone = gi.GetTone(ndx);
                    Grapheme tbu = tone.ToneBearingUnit;
                    if (tbu != null)
                        strRoot += tbu.Symbol;
                }
                else strRoot += seg.Symbol;
            }
            return strRoot;
        }

        public string GetRootwithSyllBreaks()
        {
            string strRoot = "";
            Syllable syll = null;
            if (this.SyllableCount() > 0)
            {
                for (int i = 0; i < this.SyllableCount(); i++)
                {
                    syll = this.GetSyllable(i);
                    strRoot += syll.GetSyllableInLowerCase();
                    strRoot += Word.SyllableBreakCharacter;
                }
                strRoot = strRoot.Substring(0, strRoot.Length - 1);     // get ride of last syllable break chaacter
            }
            return strRoot;
        }

        public string GetCVShape()
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

        public Syllable GetSyllable(int n)
        {
            if (n < this.SyllableCount())
                return (Syllable)this.Syllables[n];
            else return null;
        }

        public Grapheme GetGrapheme(int n)
        {
            if (n < m_RootGraphemes.Count)
                return (Grapheme)m_RootGraphemes[n];
            else return null;
        }

        public Grapheme GetGraphemeWithoutTone(int n)
        {
            Grapheme seg = null;
            int ndx = 0;
            Tone tone = null;
            GraphemeInventory gi = m_Settings.GraphemeInventory;
            if (n < m_RootGraphemes.Count)
            {
                seg = GetGrapheme(n);
                ndx = gi.FindToneIndex(seg.Symbol);
                if (ndx >= 0)
                {
                    tone = gi.GetTone(ndx);
                    seg = tone.ToneBearingUnit;
                }
            }
            return seg;
        }

        public int IsMinimalPair(Root root, bool fIgnoreTone)
        {
            int nDiff = 0;      // Number of differences
            int nPosn = -1;     // Position of difference
            Grapheme grf1 = null;
            Grapheme grf2 = null;
            if (this.GraphemeCount() == root.GraphemeCount())
            {
                for (int i = 0; i < root.GraphemeCount(); i++)
                {
                    if (fIgnoreTone)
                        grf1 = this.GetGraphemeWithoutTone(i);
                    else grf1 = this.GetGrapheme(i);
                    if (fIgnoreTone)
                        grf2 = root.GetGraphemeWithoutTone(i);
                    else grf2 = root.GetGrapheme(i);
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

        public bool IsMinimalPair(Root root, bool fIgnoreTone, Grapheme grapheme1, Grapheme grapheme2)
        {
            bool fReturn = false;
            int nDiff = 0;
            Grapheme grf1 = null;
            Grapheme grf2 = null;

            if (this.GraphemeCount() == root.GraphemeCount())
            {
                for (int i = 0; i < root.GraphemeCount(); i++)
                {
                    if (fIgnoreTone)
                        grf1 = this.GetGraphemeWithoutTone(i);
                    else grf1 = this.GetGrapheme(i);
                    if (fIgnoreTone)
                        grf2 = root.GetGraphemeWithoutTone(i);
                    else grf2 = root.GetGrapheme(i);
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

        public bool IsMinimalPairHarmony(Root root, bool fIgnoreTone, Grapheme grapheme1, Grapheme grapheme2)
        {
            bool fReturn = false;
            Grapheme grf1 = null;
            Grapheme grf2 = null;
            ArrayList alDiff = new ArrayList();
            Pair pair = null;

            if (this.GraphemeCount() == root.GraphemeCount())
            {
                for (int i = 0; i < root.GraphemeCount(); i++)
                {
                    if (fIgnoreTone)
                        grf1 = this.GetGraphemeWithoutTone(i);
                    else grf1 = this.GetGrapheme(i);
                    if (fIgnoreTone)
                        grf2 = root.GetGraphemeWithoutTone(i);
                    else grf2 = root.GetGrapheme(i);

                    if (!grf1.IsSame(grf2))
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
                        pair = (Pair)alDiff[0];
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

        public int GraphemeCount()
		{
            if (m_RootGraphemes != null)
                return m_RootGraphemes.Count;
			else return 0;
		}

        public int SyllableCount()
        {
            if (this.Syllables != null)
                return this.Syllables.Count;
            else return 0;
        }

        public Root Replace(Grapheme grf1, Grapheme grf2)
        {
            string strRoot = "";
            Root root = null;
            Grapheme grf = null;
            for (int i = 0; i < this.GraphemeCount(); i++)
            {
                grf = this.GetGrapheme(i);
                if (grf.IsSame(grf1))
                    strRoot = strRoot + grf2.Symbol;
                else strRoot = strRoot + grf.Symbol;
            }
            root = new Root(strRoot, m_Settings);
            return root;
        }

        public bool ContainInRoot(string strGrapheme)
        {
            bool flag = false;
            string strSymbol = "";
            string strUpper = "";
            int ndx = 0;
            Grapheme grf = null;
            Tone tone = null;
            GraphemeInventory gi = m_Settings.GraphemeInventory;

            for (int n = 0; n < this.GraphemeCount(); n++)
            {
                grf = this.GetGrapheme(n);
                if (grf.IsTone)
                {
                    ndx = gi.FindToneIndex(grf.Symbol);
                    tone = gi.GetTone(ndx);
                    strSymbol = tone.ToneBearingUnit.Symbol;
                    strUpper = tone.ToneBearingUnit.UpperCase;
                }
                else
                {
                    strSymbol = grf.Symbol;
                    strUpper = grf.UpperCase;
                }
                if ((strGrapheme == strSymbol) || (strGrapheme == strUpper))
                    flag = true;
            }
            return flag;
        }

        public bool ToneContainInRoot(string strTone)
        {
            bool flag = false;
            string str = "";
            for (int n = 0; n < this.GraphemeCount(); n++)
                str += this.GetGrapheme(n).Symbol;
            if (str.IndexOf(strTone) >= 0)
                flag = true;
            return flag;
        }

        public bool IsSame(Root root)
        {
            bool fReturn = false;
            Grapheme grf = null;
            if (this.GraphemeCount() == root.GraphemeCount())
            {
                fReturn = true;
                for (int i = 0; i < this.GraphemeCount(); i++)
                {
                    grf = this.GetGraphemeWithoutTone(i);
                    if (!grf.IsSame(root.GetGraphemeWithoutTone(i)))
                    {
                        fReturn = false;
                        break;
                    }
                }
            }
            return fReturn;
        }

        public bool IsSameVowel()
        {
            bool flag = false;
            string strPrev = "";
            string strSym = "";
            if (this.GraphemeCount() > 0)
                flag = true;
            for (int i = 0; i < this.GraphemeCount(); i++)
            {
                if (this.GetGraphemeWithoutTone(i).IsVowel)
                {
                    strSym = this.GetGraphemeWithoutTone(i).Symbol;
                    if ((strPrev != "") && (strSym != strPrev))
                    {
                        flag = false;
                        break;
                    }
                    strPrev = strSym;
                }
            }
            return flag;
        }

        public bool IsRootInitial(string strGrf)
        {
            bool flag = false;
            if (this.GraphemeCount() > 0)
            {
                if ((strGrf == this.GetGrapheme(0).Symbol) || (strGrf == this.GetGrapheme(0).UpperCase))
                    flag = true;
            }
            return flag;
        }

        public bool IsRootMedial(string strGrf)
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

        public bool IsRootFinal(string strGrf)
        {
            bool flag = false;
            if (this.GraphemeCount() > 0)
            {
                int n = this.GraphemeCount() - 1;      //last grapheme in root
                if ((strGrf == this.GetGrapheme(n).Symbol) || (strGrf == this.GetGrapheme(n).UpperCase))
                    flag = true;
            }
            return flag;
        }

        public bool IsInRoot(string strGrf)
        {
            bool fReturn = false;
            string str = "";
            for (int i = 0; i < this.GraphemeCount(); i++)
            {
                str = this.GetGraphemeWithoutTone(i).Symbol;
                if (str == strGrf)
                {
                    fReturn = true;
                    break;
                }
            }
            return fReturn;
        }

        public bool IsInRoot(ArrayList alGraphemes)
        {
            bool fReturn = false;
            Grapheme grf = null;
            string strSymbol = "";
            string strUpper = "";
            string strGrapheme = "";

            for (int n = 0; n < this.GraphemeCount(); n++)
            {
                grf = this.GetGrapheme(n);
                strSymbol = grf.Symbol;
                strUpper = grf.UpperCase;
                for (int i = 0; i < alGraphemes.Count; i++)
                {
                    strGrapheme = (string)alGraphemes[i];
                    if ((strGrapheme == strSymbol) || (strGrapheme == strUpper))
                    {
                        fReturn = true;
                        break;
                    }
                }
            }
            return fReturn;
        }

        public bool IsFirstRootC(string strGrf)
        {
            bool fReturn = false;
            Grapheme grf = null;
            int nEnd = this.GraphemeCount();
            if (nEnd > 0)
            {
                grf = this.GetGraphemeWithoutTone(0);   //First Grapheme
                if (grf.IsConsonant)
                {
                    if (grf.Symbol == strGrf)
                        fReturn = true;
                }

            }
            return fReturn;
        }

        public bool IsFirstRootV(string strGrf)
        {
            bool fReturn = false;
            Grapheme grf = null;
            Syllable syll = null;
            if (this.SyllableCount() > 0)
            {
                syll = (Syllable) this.Syllables[0];
                for (int i = 0; i < syll.GraphemeCount(); i++)
                {
                    grf = this.GetGraphemeWithoutTone(i);
                    if (grf.IsVowel)
                    {
                        if (grf.Symbol == strGrf)
                        {
                            fReturn = true;
                            break;
                        }
                    }
                }
            }
            return fReturn;
        }

        public bool IsSecondRootC(string strGrf)
        {
            bool fReturn = false;
            bool fFoundFirstV = false;
            bool fFoundSecondC = false;
            Grapheme grf = null;
            int nEnd = this.GraphemeCount();
            if (nEnd > 1)
            {
                int n = 0;
                do
                {
                    grf = this.GetGraphemeWithoutTone(n);
                    if (grf != null)
                    {
                        if (fFoundFirstV)
                        {
                            if (grf.IsConsonant)
                            {
                                fFoundSecondC = true;
                                if (grf.Symbol == strGrf)
                                    fReturn = true;
                            }
                        }
                        if (grf.IsVowel)
                            fFoundFirstV = true;
                    }
                    n++;
                }
                while (!fFoundSecondC && (n < nEnd));
            }
            return fReturn;
        }

        public bool IsSecondRootV(string strGrf)
        {
            bool fReturn = false;
            Grapheme grf = null;
            Syllable syll = null;
            if (this.SyllableCount() > 1)
            {
                syll = (Syllable)this.Syllables[1];
                for (int i = 0; i < syll.GraphemeCount(); i++)
                {
                    grf = this.GetGraphemeWithoutTone(i);
                    if (grf.IsVowel)
                    {
                        if (grf.Symbol == strGrf)
                        {
                            fReturn = true;
                            break;
                        }
                    }
                }
            }
            return fReturn;
        }

        private void BuildRoot()
        {
  			this.Graphemes = new ArrayList();
            this.Syllables = new ArrayList();
			m_DisplayRoot = "";
			m_CVPattern = "";
	
			GraphemeInventory gi = m_Settings.GraphemeInventory;
            int nMaxSize = m_Settings.OptionSettings.MaxSizeGrapheme;
            Grapheme grf = null;
            string strSymbol = "";          //current symbol
            string str = "";
            string strRoot = "";
            ReplacementList list = null;    //Import replacement list

			//get rid of unwanted characters
            for (int i = 0; i < this.OrigRoot.Length; i++)
			{
				strSymbol = this.m_OrigRoot.Substring(i,1);
                if (!IsRootStart(strSymbol))
                {
				    if ( !IsRootEnd(strSymbol) )
				    {
                        // Process import characters to ignore
                        str = m_Settings.OptionSettings.ImportIgnoreChars;
                        if (strSymbol.IndexOfAny(str.ToCharArray()) < 0)
                        {
                            // Ignore General Punctuation
                            str = m_Settings.OptionSettings.GeneralPunct;
                            str = str.Replace(Word.SyllableBreakCharacter, Constants.NullChar);
                            str = str.Replace(Constants.Space, Constants.NullChar);
                            if (strSymbol.IndexOfAny(str.ToCharArray()) < 0)
                            {
                                //Ignore Ending Punctuation
                                str = m_Settings.OptionSettings.EndingPunct;
                                str = str.Replace(Word.SyllableBreakCharacter, Constants.NullChar);
                                if (strSymbol.IndexOfAny(str.ToCharArray()) < 0)
                                {
                                    if (!IsDoubleQuote(strSymbol))
                                    {
                                        str = m_Settings.OptionSettings.ImportIgnoreChars;
                                        if (strSymbol.IndexOfAny(str.ToCharArray()) < 0)
                                            strRoot += strSymbol;

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
                    strRoot = strRoot.Replace(list.GetReplaceString(k), list.GetWithString(k));
                }
            }

            // Build Grapheme list and syllable list (if specified by user)
            string strSyllable = "";
            Syllable syll = null;
            int nLookahead = nMaxSize;
            bool fSyllableBreaks = false;
            for (int i = 0; i < strRoot.Length; i++)
            {
                strSymbol = strRoot.Substring(i, 1);
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
                    if ( (i + nMaxSize) < strRoot.Length )
                        nLookahead = nMaxSize;
                    else nLookahead = strRoot.Length - i;
                    for (int j = nLookahead; j > 0; j--)
				    {
                        strSymbol = strRoot.Substring(i, j);

                        // Process import replacement list
                        list = m_Settings.OptionSettings.ImportReplacementList;
                        if (list != null)
                        {
                            for (int k = 0; k < list.ListCount(); k++)
                            {
                                if (strSymbol == list.GetReplaceString(k))
                                {
                                    strSymbol = list.GetWithString(k);
                                    break;
                                }
                            }
                        }

                        if (gi.IsInInventory(strSymbol))
						{
							grf = gi.GetGrapheme(strSymbol);
							i = i + j - 1;
							break;
						}
					}
                    this.Graphemes.Add(grf);
                    this.m_DisplayRoot += grf.Symbol;
                    strSyllable += grf.Symbol;
				}
			}
            if (fSyllableBreaks)
            {
                syll = new Syllable(strSyllable, m_Settings);
                this.Syllables.Add(syll);
            }

            //Build CV pattern for root
            this.m_CVPattern = BuildCVPattern();

            if (this.SyllableCount() == 0)		//No syll breaks yet
			{
				if (this.OrigRoot != "")
					BuildRootSyllBreaks();
			}
        }

        //private void BuildRootSyllBreaksOld()
        //{
        //    Grapheme grf = null;
        //    GraphemeInventory gi = m_Settings.GraphemeInventory;
        //    Syllable syll = null;
        //    ArrayList alSyllables = new ArrayList();
        //    string strSyllable = "";
        //    int n = 0;
            
        //    if (this.GraphemeCount() > 0)
        //    {
        //        for (int i = 0; i < this.GraphemeCount(); i++)
        //        {
        //            grf = this.GetGrapheme(i);
        //            if (grf != null)
        //            {
        //                if (grf.IsConsonant)
        //                {
        //                    int ndx = gi.FindConsonantIndex(grf.Symbol);
        //                    Consonant cns = gi.GetConsonant(ndx);
        //                    if (cns.IsSyllabic || grf.IsSyllabic)
        //                    {
        //                        strSyllable = strSyllable + grf.Symbol;
        //                        syll = new Syllable(strSyllable, m_Settings);
        //                        n = alSyllables.Add(syll);
        //                        strSyllable = "";
        //                    }
        //                    else strSyllable = strSyllable + grf.Symbol;
        //                }
        //                else if (grf.IsVowel)
        //                {
        //                    strSyllable = strSyllable + grf.Symbol;
        //                    syll = new Syllable(strSyllable, m_Settings);
        //                    n = alSyllables.Add(syll);
        //                    strSyllable = "";
        //                }
        //                else if (grf.IsTone)
        //                {
        //                    int ndx2 = gi.FindToneIndex(grf.Symbol);
        //                    Tone tone = gi.GetTone(ndx2);
        //                    Grapheme grf2 = tone.ToneBearingUnit;
        //                    if (grf2 != null)
        //                    {
        //                        if (grf2.IsConsonant)
        //                        {
        //                            ndx2 = gi.FindConsonantIndex(grf2.Symbol);
        //                            Consonant cns2 = gi.GetConsonant(ndx2);
        //                            if (cns2.IsSyllabic || grf2.IsSyllabic)
        //                            {
        //                                strSyllable = strSyllable + grf.Symbol;
        //                                syll = new Syllable(strSyllable, m_Settings);
        //                                n = alSyllables.Add(syll);
        //                                strSyllable = "";
        //                            }
        //                            else strSyllable = strSyllable + grf.Symbol;
        //                        }
        //                        else if (grf2.IsVowel)
        //                        {
        //                            strSyllable = strSyllable + grf.Symbol;
        //                            syll = new Syllable(strSyllable, m_Settings);
        //                            n = alSyllables.Add(syll);
        //                            strSyllable = "";
        //                        }
        //                        else strSyllable = strSyllable + grf.Symbol;
        //                    }
        //                }
        //                else strSyllable = strSyllable + grf.Symbol;
        //            }
        //        }
        //    }
        //    if ( (grf != null) && (!grf.IsVowel) )		//last grapheme was not a vowel
        //    {
        //        if (alSyllables.Count > 0 )
        //        {
        //            syll = (Syllable) alSyllables[alSyllables.Count - 1];   //Get last syllable
        //            strSyllable  = syll.GetSyllableInLowerCase() + strSyllable;
        //            syll = new Syllable(strSyllable, m_Settings);           //New syllable
        //            alSyllables.RemoveAt(alSyllables.Count -1);
        //            n = alSyllables.Add(syll);                              //Replace last syllable
        //        }
        //        else
        //        {
        //            syll = new Syllable(strSyllable, m_Settings);
        //            n = alSyllables.Add(syll);
        //        }
        //    }
        //    this.Syllables = alSyllables;
        //}

        private void BuildRootSyllBreaks()
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
            bool fCnsBreak = false;     //Indicates a break is needed in a series of Consonants

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

                            if (grfPrev2.IsSyllograph)   // S?
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
                            //grfCurr2 = grfCurr;
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
                                    strSyllable = "";       //ignore space in syllables
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
                                    if (grfPrev2.IsVowel || grfPrev2.IsSyllograph) //V? or S?
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
                            Syllable syll1 = (Syllable)alSyllables[alSyllables.Count - 2];  //2nd to last syl;lable
                            Syllable syll2 = (Syllable)alSyllables[alSyllables.Count - 1];  // last syllable
                            bool flag = true;
                            for (int i = 0; i < syll2.GraphemeCount(); i++)
                            {
                                grfCurr = syll2.GetGrapheme(i);
                                if (!grfCurr.IsConsonant  || grfCurr.IsSyllabicConsonant)
                                    flag = false;
                            }
                            grfPrev = syll1.GetGrapheme(syll1.GraphemeCount() - 1); // last grapheme
                            if (grfPrev.IsSyllograph || grfPrev.IsSyllabicConsonant)
                                flag = false;
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
            if (strSymbol == Word.DoubleQuote)
                flag = true;
            return flag;
        }

        private bool IsRootStart(string strSymbol)
        {
            bool flag = false;
            if (strSymbol == Word.BeginRootCharacter.ToString())
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

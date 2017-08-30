using System;
using System.Collections;
using GenLib;

namespace PrimerProObjects
{
    /// <summary>
    /// Syllable Class
    /// </summary>summary>
    public class Syllable
    {
        private Settings m_Settings;
        private string m_SyllableAsString;
        private ArrayList  m_Graphemes;
        private string m_CVPattern;
        private string m_Syllable;

        public const string Underscore = "_";

        public Syllable (string strSyll,  Settings s)
        {
            m_Settings = s;
            m_SyllableAsString = strSyll;
            m_Graphemes = new ArrayList();
            BuildSyllable(strSyll);
            m_CVPattern = BuildCVPattern();
        }

        public ArrayList Graphemes
        {
            get { return m_Graphemes; }
            set { m_Graphemes = value; }
        }

        public string DisplaySyllable
        {
            get {return m_SyllableAsString;}
        }

        public string CVPattern
        {
            get { return m_CVPattern; }
        }
        
        public int GraphemeCount()
        {
        	if (this.Graphemes != null)
				return this.Graphemes.Count;
			else return 0;
        }

        public Grapheme GetGrapheme(int n)
        {
            if (n < 0)
                return null;
            if (n < this.Graphemes.Count)
                return (Grapheme) this.Graphemes[n];
            else return null;
        }

        public Grapheme GetGraphemeWithoutTone(int n)
        {
            Grapheme grf = null;
            Tone tone = null;
            GraphemeInventory gi = m_Settings.GraphemeInventory;
            int ndx = 0;
            if (n < this.GraphemeCount())
            {
                grf = this.GetGrapheme(n);
                ndx = gi.FindToneIndex(grf.Symbol);
                if (ndx >= 0)
                {
                    tone = gi.GetTone(ndx);
                    grf = tone.ToneBearingUnit;
                }
            }
            return grf;
        }

        public string GetSyllableInLowerCase()
        {
			string strSyll = "";
			Grapheme grf = null;
			GraphemeInventory gi = m_Settings.GraphemeInventory;
			for (int i = 0; i < this.GraphemeCount(); i++)
			{
				grf = this.GetGrapheme(i);
				strSyll += grf.Symbol;
			}
			return strSyll;
        }

        public string GetSyllableWithoutTone()
        {
            string strSyll = "";
            int ndx = 0;
            Grapheme grf = null;
            Tone tone = null;
            GraphemeInventory gi = m_Settings.GraphemeInventory;
            for (int i = 0; i < this.GraphemeCount(); i++)
            {
                grf = this.GetGrapheme(i);
                ndx = gi.FindToneIndex(grf.Symbol);
                if (ndx >= 0)
                {
                    tone = gi.GetTone(ndx);
                    Grapheme tbu = tone.ToneBearingUnit;
                    if (tbu != null)
                        strSyll += tbu.Symbol;
                }
                else strSyll += grf.Symbol;
            }
            return strSyll;
        }
        
        public bool IsOpenSyllable()
        {
            bool fReturn = false;
            int n = this.GraphemeCount() - 1;
            Grapheme grf = null;
            grf = this.GetGraphemeWithoutTone(n);
            if (grf.IsVowel)
                fReturn = true;
            return fReturn;
        }

        public bool IsClosedSyllable()
        {
            bool fReturn = false;
            int n = this.GraphemeCount() - 1;
            Grapheme grf = null;
            grf = this.GetGraphemeWithoutTone(n);
            if (grf.IsConsonant)
                fReturn = true;
            return fReturn;
        }

        public bool IsOnset(string strGrapheme)
        {
            bool fReturn = false;
            Grapheme grf = this.GetGrapheme(0);
            if (grf.Symbol == strGrapheme)
                fReturn = true;
            return fReturn;
        }

        public bool IsCoda(string strGrapheme)
        {
            bool fReturn = false;
            int n = this.GraphemeCount() - 1;
            Grapheme grf = this.GetGrapheme(n);
            if (grf.Symbol == strGrapheme)
                fReturn = true;
            return fReturn;
        }

        public bool IsSyllableInitial(string strGrapheme)
        {
            bool fReturn = false;
            Grapheme grf = this.GetGrapheme(0);
            if (grf != null)
            {
                if (grf.Symbol == strGrapheme)
                    fReturn = true;
            }
            else fReturn = false;
            return fReturn;
        }

        public bool IsSyllableMedial(string strGrapheme)
        {
            bool fReturn = false;
            string str = "";
            for (int i = 1; i < this.GraphemeCount() - 1; i++)
                str += this.GetGrapheme(i).Symbol;
            if (str.IndexOf(strGrapheme) >= 0)
                fReturn = true;
            return fReturn;
        }

        public bool IsSyllableFinal(string strGrapheme)
        {
            bool fReturn = false;
            int n = this.GraphemeCount() - 1;
            Grapheme grf = this.GetGrapheme(n);
            if (grf != null)
            {
                if (grf.Symbol == strGrapheme)
                    fReturn = true;
            }
            else fReturn = false;
            return fReturn;
        }
        
        public bool IsInSyllable(string strGrf)
        {
            bool fReturn = false;
            for (int i = 0; i < this.GraphemeCount(); i++)
            {
                if (this.GetGraphemeWithoutTone(i).Symbol == strGrf)
                    fReturn = true;
            }
            return fReturn;
        }

        public bool IsBuildable(ArrayList alGTO)
        {
            bool flag = false;
            string strGrf = "";
            string strSymbol = "";
            int nLenght = 0;

            for (int i = 0; i < this.GraphemeCount(); i++)
            {
                strSymbol = this.GetGrapheme(i).Symbol;
                bool fMatch = false;
                if (i == 0)                             //if syllable initial
                {
                   for (int j = 0; j < alGTO.Count; j++)
                   {
                       strGrf = (string) alGTO[j];
                       nLenght = strGrf.Length;
                       if (strGrf == strSymbol)
                       {
                           fMatch =true;
                           break;
                       }
                       else if ((strGrf.EndsWith(Underscore) && (strGrf.Substring(0, nLenght - 1)) == strSymbol))
                       {
                           fMatch = true;
                           break;
                       }
                   }
                }
                else if (i == this.GraphemeCount() - 1)     //if syllable final
                {
                    for (int j = 0; j < alGTO.Count; j++)
                    {
                        strGrf = (string) alGTO[j];
                        nLenght = strGrf.Length;
                        if (strGrf == strSymbol)
                        {
                            fMatch = true;
                            break;
                        }
                        else if ((strGrf.StartsWith(Underscore)) && (strGrf.Substring(1) == strSymbol))
                        {
                            fMatch = true;
                            break;
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < alGTO.Count; j++)
                    {
                        strGrf = (string)alGTO[j];
                        if (strGrf == strSymbol)
                        {
                            fMatch = true;
                            break;
                        }

                    }
                }
                flag = fMatch;
                if (!fMatch)
                    break;
            }
            return flag;
        }
        
        private void BuildSyllable(string strSyllable)
        {
            GraphemeInventory gi = m_Settings.GraphemeInventory;
            int nMaxSize = this.m_Settings.OptionSettings.MaxSizeGrapheme;
            Grapheme grf = null;
            string strSymbol = "";
            for (int i = 0; i < strSyllable.Length; i++)
            {
                strSymbol = strSyllable.Substring(i, 1);
                grf = new Grapheme(strSymbol);
                for (int j = nMaxSize; j > 0; j--)
                {
                    if ((i + j) <= strSyllable.Length)
                    {
                        strSymbol = strSyllable.Substring(i, j);
                        if (gi.IsInInventory(strSymbol))
                        {
                            grf = gi.GetGrapheme(strSymbol);
                            i = i + j - 1;
                            break;
                        }
                    }
                }
                this.Graphemes.Add(grf);
            }
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

    }
}

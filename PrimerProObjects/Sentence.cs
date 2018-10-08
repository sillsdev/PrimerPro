using System;
using System.Collections;
using GenLib;

namespace PrimerProObjects
{
	/// <summary>
	/// 
	/// </summary>
	public class Sentence
	{
		private Settings m_Settings;
		private string m_OriginalSentence;
		private ArrayList m_Words;
		private char m_EndingPunctuation;

		public const char NoPunctation = ' ';

		public Sentence(string strSentence, Settings s)
		{
			m_Settings = s;
			m_OriginalSentence = strSentence;
			m_Words = new ArrayList();
			m_EndingPunctuation = strSentence[strSentence.Length - 1];
            //if (Sentence.EndingPunctuations.IndexOf(m_EndingPunctuation) < 0)
            if (m_Settings.OptionSettings.EndingPunct.IndexOf(m_EndingPunctuation) < 0)
				m_EndingPunctuation = Sentence.NoPunctation;						//no ending punctation found
			else strSentence = strSentence.Substring(0, strSentence.Length - 1);	//remove ending punctuation
			BuildWords(strSentence);
		}

		public string OriginalSentence
		{
            get { return m_OriginalSentence; }
		}

		public ArrayList Words
		{
			get {return m_Words;}
		}

		public char EndingPunctuation
		{
			get {return m_EndingPunctuation;}
		}

		public void AddWord(Word wrd)
		{
			m_Words.Add(wrd);
		}

		public void DelWord(int n)
		{
			m_Words.RemoveAt(n);
		}

		public Word GetWord(int n)
		{
			if (n < this.WordCount())
				return (Word) m_Words[n];
			else return null;
		}

		public int WordCount()
		{
			if (m_Words == null )
				return 0;
			else return m_Words.Count;
		}

        public int SyllableCount()
        {
            int nCount = 0;
            Word word = null;
            for (int i = 0; i < this.WordCount(); i++)
            {
                word = this.GetWord(i);
                if (word != null)
                    nCount = nCount + word.SyllableCount();
            }
            return nCount;
        }

		public string AsString()
		{
			string strSent = "";
			for (int i = 0; i < this.WordCount(); i++)
				strSent += GetWord(i).DisplayWord + Constants.Space;
			strSent = strSent.TrimEnd();
			strSent += EndingPunctuation;
			strSent = strSent.Trim();
			return strSent;
		}

		private void BuildWords(string strSentence)
		{
			Word wrd = null;
			string strWord = "";
            //strSentence = strSentence.ToLower();
			WordList wl = m_Settings.WordList;
            //char[] sep = Sentence.WordSeparators.ToCharArray();
            char[] sep = m_Settings.OptionSettings.GeneralPunct.ToCharArray();
			int nBeg = 0;
			int nEnd = 0;
            //int ndx = -1;
			do
			{
				nEnd = strSentence.IndexOfAny(sep, nBeg);
				if ( nEnd < 0 )
					nEnd = strSentence.Length;
				strWord = strSentence.Substring(nBeg,nEnd-nBeg).Trim();
				if (strWord != "")
				{
                    //This code makes the importing of text data really slow when you have a large word list
                    //ndx = wl.FindWordIndex(strWord);
                    //if (ndx >= 0)
                    //    wrd = wl.GetWord(ndx);
                    //else wrd = new Word(strWord, m_Settings);
                    wrd = new Word(strWord, m_Settings);
                    if (wrd.DisplayWord != "")
                        this.AddWord(wrd);
				}
				nBeg = nEnd +1;
			}
			while (nBeg < strSentence.Length);
			return;
		}

	}
}

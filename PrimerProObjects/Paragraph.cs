using System;
using System.Collections;
using GenLib;

namespace PrimerProObjects
{
	/// <summary>
	/// 
	/// </summary>
	public class Paragraph
	{
		private Settings m_Settings;
		private string m_OriginalParagraph;
		private ArrayList m_Sentences;
		
		public Paragraph(string strParagraph, Settings s)
		{
			m_Settings = s;
			m_OriginalParagraph = strParagraph;
			m_Sentences = new ArrayList();
			BuildSentences(strParagraph);
		}

		public string OriginalParagraph
		{
            get { return m_OriginalParagraph; }
		}

		public ArrayList Sentences
		{
			get {return m_Sentences;}
		}

		public void AddSentence(Sentence snt)
		{
			m_Sentences.Add(snt);
		}

		public void DelSentence(int n)
		{
			m_Sentences.RemoveAt(n);
		}

		public Sentence GetSentence(int n)
		{
			if (n < this.SentenceCount())
				return (Sentence) m_Sentences[n];
			else return null;
		}
		
		public int SentenceCount()
		{
			if (m_Sentences == null )
				return 0;
			else return m_Sentences.Count;
		}

		public int WordCount()
		{
			int nCount = 0;
			Sentence snt = null;
			for (int i = 0; i < this.SentenceCount(); i++)
			{
				snt = this.GetSentence(i);
				nCount = nCount + snt.WordCount();
			}
			return nCount;
		}

		public string AsString()
		{
			string strPara = "";
			for (int i = 0; i < this.SentenceCount(); i++)
				strPara += GetSentence(i).AsString() + Constants.Space;
			strPara = strPara.TrimEnd();
            strPara += Environment.NewLine;
			return strPara;
		}

		private void BuildSentences(string strParagraph)
		{
			Sentence snt = null;
			string strSent = "";
            char[] sep = m_Settings.OptionSettings.EndingPunct.ToCharArray();
            char chPunct = Sentence.NoPunctation;
			int nBeg = 0;
			int nEnd = 0;
			do
			{
				nEnd = strParagraph.IndexOfAny(sep, nBeg);
                if (nEnd < 0)
                {
                    nEnd = strParagraph.Length;
                    chPunct = Sentence.NoPunctation;
                }
                else chPunct = strParagraph[nEnd];
				strSent = strParagraph.Substring(nBeg, nEnd - nBeg);
                strSent = strSent.Trim();
				if ( strSent != "" )
				{
					strSent += chPunct;
					snt = new Sentence(strSent, m_Settings);
                    if (snt.WordCount() > 0)        //if words in sentence exist
	    				this.AddSentence(snt);
				}
				nBeg = nEnd + 1;
			}
			while (nBeg < strParagraph.Length);
			return;
		}

	}
}

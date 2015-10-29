using System;
using System.Collections;
using System.Web.UI;

namespace PrimerProObjects
{
	/// <summary>
	/// 
	/// </summary>
	public class Grapheme : System.Object
	{
        private string m_Symbol;
        private string m_UpperCase;
        private string m_Key;
		private bool m_IsConsonant;
		private bool m_IsVowel;
		private bool m_IsTone;
        private bool m_IsSyllograph;
        private bool m_IsSyllabicConsonant;
        private bool m_IsComplex;
        private ArrayList m_ComplexComponents;  //arraylist of strings (symbols)
        private int m_CountInWordList;
		private int m_CountInTextData;

        public enum GraphemeType { None, Consonant, Vowel, Tone, Syllograph };

    	public Grapheme(string strSymbol)
		{
            m_Symbol = strSymbol;
            m_UpperCase = "";
            m_Key = GetKey();
			m_IsConsonant = false;
			m_IsVowel = false;
            m_IsTone = false;
            m_IsSyllograph = false;
            m_IsSyllabicConsonant = false;
            m_IsComplex = false;
            m_ComplexComponents = null;
			m_CountInWordList = 0;
			m_CountInTextData = 0;
		}

		public string Symbol
		{
			get {return m_Symbol;}
			set {m_Symbol = value;}
		}

		public string UpperCase
		{
			get {return m_UpperCase;}
			set {m_UpperCase = value;}
		}

        public string Key
        {
            get {return m_Key;}
            set { m_Key = value; }
        }
 
		public bool IsConsonant
		{
			get {return m_IsConsonant;}
			set {m_IsConsonant = value;}
		}

		public bool IsVowel
		{
			get {return m_IsVowel;}
			set {m_IsVowel= value;}
		}

		public bool IsTone
		{
			get {return m_IsTone;}
			set {m_IsTone = value;}
		}

        public bool IsSyllograph
        {
            get { return m_IsSyllograph; }
            set { m_IsSyllograph = value; }
        }

        public bool IsSyllabicConsonant
        {
            get { return m_IsSyllabicConsonant; }
            set { m_IsSyllabicConsonant = value; }
        }

        public bool IsComplex
        {
            get { return m_IsComplex; }
            set { m_IsComplex = value; }
        }

        public ArrayList ComplexComponents
        {
            get { return m_ComplexComponents; }
            set { m_ComplexComponents = value; }
        }

        public int GetSymbolLength()
        {
            return m_Symbol.Length;
        }

        public string GetKey()
        {
            string strKey = "";
            char[] aChar;
            if (this.Symbol.Trim() != "")
            {
                aChar = this.Symbol.ToCharArray();
                foreach (char ch in aChar)
                    strKey = strKey + Convert.ToInt32(ch).ToString().PadLeft(6, '0');
            }
            return strKey;
        }

        public GraphemeType GetGraphemeType()
        {
            GraphemeType type = GraphemeType.None;
            if (this.IsConsonant)
                type = GraphemeType.Consonant;
            else if (this.IsVowel)
                type = GraphemeType.Vowel;
            else if (this.IsTone)
                type = GraphemeType.Tone;
            else if (this.IsSyllograph)
                type = GraphemeType.Syllograph;
            return type;
        }

        public void SetGraphemeType(GraphemeType type)
        {
            switch (type)
            {
                case GraphemeType.Consonant:
                    this.IsConsonant = true;
                    break;
                case GraphemeType.Vowel:
                    this.IsVowel = true;
                    break;
                case GraphemeType.Tone:
                    this.IsTone = true;
                    break;
                case GraphemeType.Syllograph:
                    this.IsSyllograph = true;
                    break;
                default:
                    break;
            }
        }

        public int GetCountInWordList()
        {
            return m_CountInWordList;
        }

        public void InitCountInWordList()
		{
			m_CountInWordList = 0;
		}

		public void IncrCountInWordList()
		{
			m_CountInWordList++;
		}
		
		public int GetCountInTextData()
		{
			return m_CountInTextData;
		}

		public void InitCountInTextData()
		{
			m_CountInTextData = 0;
		}

		public void IncrCountInTextData()
		{
			m_CountInTextData++;
		}
		
		public bool IsSame(Grapheme grf)
		{
			bool fReturn = false;
            if (grf != null)
            {
                if ((this.Symbol != "") && (grf.Symbol != ""))
                {
                    if (this.Symbol == grf.Symbol)
                        fReturn = true;
                }
            }
			return fReturn;
		}

        public bool IsFoundInWord(string strWord)
		{
			bool fReturn = false;
			if ( strWord.IndexOf(m_Symbol) > 0 )
				fReturn = true;
			return fReturn;
		}

        public int GetComplexCount()
        {
            if (m_ComplexComponents == null)
                return 0;
            else return m_ComplexComponents.Count;
        }

        public string GetComplexComponent(int n)
        {
            if (m_ComplexComponents == null)
                return null;
            if (m_ComplexComponents.Count > 0)
                return m_ComplexComponents[n].ToString();
            return null;
        }

        public void AddComplexComponent(string str)
        {
            if (m_ComplexComponents == null)
                m_ComplexComponents = new ArrayList();
            m_ComplexComponents.Add(str);
        }

    }
}

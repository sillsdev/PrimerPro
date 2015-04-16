using System;
using GenLib;

namespace PrimerProObjects
{
	/// <summary>
	/// 
	/// </summary>
	public class Tone : Grapheme
	{
		private string m_Level;
		private Grapheme m_ToneBearingUnit;
        private int m_TeachingOrder;

        private const string kConsonant = "C";
        private const string kVowel = "V";
        private const string kSyllograph = "S";

		public Tone(string strSymbol) : base(strSymbol)
		{
            this.UpperCase = "";
            this.IsTone = true;
			m_Level = "";
            m_ToneBearingUnit = new Grapheme(Constants.Empty);
		}

		public string Level
		{
			get {return m_Level;}
			set {m_Level = value;}
		}

        public Grapheme ToneBearingUnit
		{
			get {return m_ToneBearingUnit;}
			set {m_ToneBearingUnit = value;}
		}

        public int TeachingOrder
        {
            get { return m_TeachingOrder; }
            set { m_TeachingOrder = value; }
        }

        public bool MatchesLevel(string strLevel)
		{
			if (this.Level == strLevel)
				return true;
			else return false;
		}

        public bool MatchesToneBearingUnit(Grapheme grf)
		{
			return this.IsSame(grf);
		}

        public string GetMarker()
        {
            string strMarker = "";
            if (this.ToneBearingUnit != null)
            {
                if (this.ToneBearingUnit.IsConsonant)
                    strMarker = Tone.kConsonant;
                else if (this.ToneBearingUnit.IsVowel)
                    strMarker = Tone.kVowel;
                else if (this.ToneBearingUnit.IsSyllograph)
                    strMarker = Tone.kSyllograph;
                else strMarker = "";
            }
            return strMarker;
        }
    }
}

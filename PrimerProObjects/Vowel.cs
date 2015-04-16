using System;

namespace PrimerProObjects
{
	/// <summary>
	/// Vowel Class
	/// </summary>
	public class Vowel : Grapheme
	{
		private bool m_IsFront;
		private bool m_IsCentral;
		private bool m_IsBack;
		private bool m_IsHigh;
		private bool m_IsMid;
		private bool m_IsLow;
		private bool m_IsRound;
		private bool m_IsPlusATR;
		private bool m_IsLong;
		private bool m_IsNasal;
        private bool m_IsVoiceless;
        private int m_TeachingOrder;
		
		public Vowel(string strSymbol): base(strSymbol)
		{
            this.IsVowel = true;
			this.m_IsFront = false;
			this.m_IsCentral = false;
			this.m_IsBack = false;
			this.m_IsHigh = false;
			this.m_IsMid = false;
			this.m_IsLow = false;
			this.m_IsRound = false;
			this.m_IsPlusATR = false;
			this.m_IsLong = false;
			this.m_IsNasal = false;
            this.m_IsVoiceless = false;
		}

		public bool IsFront
		{
			get {return m_IsFront;}
			set {m_IsFront = value;}
		}

		public bool IsCentral
		{
			get {return m_IsCentral;}
			set {m_IsCentral = value;}
		}

		public bool IsBack
		{
			get {return m_IsBack;}
			set {m_IsBack = value;}
		}

		public string Backness
		{
			get
			{
				if (IsFront) return VowelFeatures.kFront;
				if (IsCentral) return VowelFeatures.kCentral;
				if (IsBack) return VowelFeatures.kBack;
				return "";
			}
		}

		public bool IsHigh
		{
			get {return m_IsHigh;}
			set {m_IsHigh = value;}
		}

		public bool IsMid
		{
			get {return m_IsMid;}
			set {m_IsMid = value;}
		}

		public bool IsLow
		{
			get {return m_IsLow;}
			set {m_IsLow = value;}
		}

		public string Height
		{
			get
			{
				if (IsHigh) return VowelFeatures.kHigh;
				if (IsMid) return VowelFeatures.kMid;
				if (IsLow) return VowelFeatures.kLow;
				return "";
			}
		}

		public bool IsRound
		{
			get {return m_IsRound;}
			set {m_IsRound = value;}
		}

		public bool IsPlusATR
		{
			get {return m_IsPlusATR;}
			set {m_IsPlusATR = value;}
		}

		public bool IsLong
		{
			get {return m_IsLong;}
			set {m_IsLong = value;}
		}

		public bool IsNasal
		{
			get {return m_IsNasal;}
			set {m_IsNasal = value;}
		}

        public bool IsVoiceless
        {
            get { return m_IsVoiceless; }
            set { m_IsVoiceless = value; }
        }

        public int TeachingOrder
        {
            get { return m_TeachingOrder; }
            set { m_TeachingOrder = value; }
        }

        public bool MatchesFeatures(VowelFeatures vf)
		{
			bool flag = true;
			if ( (vf.Backness != "") && (vf.Backness != this.Backness) )
				flag = false;
			if ( (vf.Height != "") && (vf.Height != this.Height) )
				flag = false;
			if ( (vf.Round) && (!this.IsRound) )
				flag = false;
			if ( (vf.Nasal) && (!this.IsNasal) )
				flag = false;
			if ( (vf.Long) && (!this.IsLong) )
				flag = false;
			if ( (vf.PlusAtr) && (!this.IsPlusATR) )
				flag = false;
            if ((vf.Voiceless) && (!this.IsVoiceless))
                flag = false;
            if ((vf.Diphthong) && (!this.IsComplex))
                flag = false;
            return flag;
		}

	}
}

using System;

namespace PrimerProObjects
{
	/// <summary>
	/// 
	/// </summary>
	public class VowelFeatures
	{
		private string m_Backness;
		private string m_Height;
		private bool m_Round;
		private bool m_PlusAtr;
		private bool m_Long;
		private bool m_Nasal;
        private bool m_Diphthong;
        private bool m_Voiceless;

		public const string kFront = "Frn";
		public const string kCentral = "Cnt";
		public const string kBack = "Bck";
		public const string kHigh = "Hgh";
		public const string kMid = "Mid";
		public const string kLow = "Low";
		public const string kRound = "Rnd";
		public const string kPlusAtr = "Atr";
		public const string kLong = "Lng";
		public const string kNasal = "Nsl";
        public const string kDipthong = "Dip";
        public const string kVoiceless = "Vcl";

		public VowelFeatures()
		{
			m_Backness = "";
			m_Height = "";
			m_Round = false;
			m_PlusAtr = false;
			m_Long = false;
			m_Nasal = false;
            m_Diphthong = false;
            m_Voiceless = false;
		}

		public string Backness
		{
			get {return m_Backness;}
			set {m_Backness = value;}
		}

		public string Height
		{
			get {return m_Height;}
			set {m_Height = value;}
		}

		public bool Round
		{
			get {return m_Round;}
			set {m_Round = value;}
		}

		public bool PlusAtr
		{
			get {return m_PlusAtr;}
			set {m_PlusAtr = value;}
		}

		public bool Long
		{
			get {return m_Long;}
			set {m_Long = value;}
		}

		public bool Nasal
		{
			get {return m_Nasal;}
			set {m_Nasal = value;}
		}

        public bool Diphthong
        {
            get { return m_Diphthong; }
            set { m_Diphthong = value; }
        }

        public bool Voiceless
        {
            get { return m_Voiceless; }
            set { m_Voiceless = value; }
        }

        public VowelFeatures SetFeature(string strFeature)
		{
			if (strFeature == VowelFeatures.kBack)
			{
				this.Backness = strFeature;
			}
			else if (strFeature == VowelFeatures.kCentral)
			{
				this.Backness = strFeature;
			}
			else if (strFeature == VowelFeatures.kFront)
			{
				this.Backness = strFeature;
			}
			else if (strFeature == VowelFeatures.kHigh)
			{
				this.Height = strFeature;
			}
			else if (strFeature == VowelFeatures.kMid)
			{
				this.Height = strFeature;
			}
			else if (strFeature == VowelFeatures.kLow)
			{
				this.Height = strFeature;
			}
			else if (strFeature == VowelFeatures.kLong)
			{
				this.Long = true;
			}
			else if (strFeature == VowelFeatures.kNasal)
			{
				this.Nasal = true;
			}
			else if (strFeature == VowelFeatures.kPlusAtr)
			{
				this.PlusAtr = true;
			}
			else if (strFeature == VowelFeatures.kRound)
			{
				this.Round = true;
			}
            else if (strFeature == VowelFeatures.kDipthong)
            {
                this.Diphthong = true;
            }
            else if (strFeature == VowelFeatures.kVoiceless)
            {
                this.Voiceless = true;
            }
            return this;
		}

	}
}

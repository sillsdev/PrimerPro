using System;

namespace PrimerProObjects
{
	/// <summary>
	/// 
	/// </summary>
	public class ConsonantFeatures
	{
		private string m_PointOfArticulation;
		private string m_MannerOfArticulation;
		private bool m_Voiced;
		private bool m_Voiceless;
		private bool m_Prenasalized;
		private bool m_Labialized;
		private bool m_Palatalized;
		private bool m_Velarized;
		private bool m_Syllabic;
        private bool m_Aspirated;
        private bool m_Long;
        private bool m_Glottalized;
        private bool m_Combination;

		public const string kBilabial = "Blb";
		public const string kLabiodental = "Lbd";
		public const string kDental = "Dnt";
		public const string kAlveolar = "Alv";
		public const string kPostalveolar = "Pst";
		public const string kRetroflex = "Rtr";
		public const string kPalatal = "Plt";
		public const string kVelar = "Vlr";
		public const string kLabialvelar = "Lbv";
		public const string kUvular = "Uvl";
		public const string kPharyngeal = "Phr";
		public const string kGlottal = "Glt";
		public const string kNoPA = "NoP";
		public const string kPlosive = "Pls";
		public const string kNasal = "Nsl";
		public const string kTrill = "Trl";
		public const string kFlap = "Flp";
		public const string kFricative = "Frc";
		public const string kAffricate = "Aff";
		public const string kLateralFricative = "Lfr";
		public const string kLateralApproximant = "Lap";
		public const string kApproximant = "App";
		public const string kImplosive = "Imp";
		public const string kEjective = "Ejc";
		public const string kClick = "Clc";
		public const string kNoMA = "NoM";
		public const string kVoiced = "Vcd";
		public const string kVoiceless = "Vcl";
		public const string kPrenasalized = "Prn";
		public const string kLabialized = "Lbz";
		public const string kPalatalized = "Plz";
		public const string kVelarized = "Vlz";
		public const string kSyllabic = "Syl";
        public const string kAspirated = "Asp";
        public const string kLong = "Lng";
        public const string kGlottalized = "Glz";
        public const string kCombination = "Cmb";

		public ConsonantFeatures()
		{
			m_PointOfArticulation = "";
			m_MannerOfArticulation = "";
			m_Voiced = false;
			m_Prenasalized = false;
			m_Labialized = false;
			m_Palatalized = false;
			m_Velarized = false;
			m_Syllabic = false;
            m_Aspirated = false;
            m_Long = false;
            m_Glottalized = false;
            m_Combination = false;
		}

		public string PointOfArticulation
		{
			get {return m_PointOfArticulation;}
			set {m_PointOfArticulation = value;}
		}

		public string MannerOfArticulation
		{
			get {return m_MannerOfArticulation;}
			set {m_MannerOfArticulation = value;}
		}

		public bool Voiced
		{
			get {return m_Voiced;}
			set {m_Voiced = value;}
		}

		public bool Voiceless
		{
			get {return m_Voiceless;}
			set {m_Voiceless = value;}
		}

		public bool Prenasalized
		{
			get {return m_Prenasalized;}
			set {m_Prenasalized = value;}
		}

		public bool Labialized
		{
			get {return m_Labialized;}
			set {m_Labialized = value;}
		}

		public bool Palatalized
		{
			get {return m_Palatalized;}
			set {m_Palatalized = value;}
		}

		public bool Velarized
		{
			get {return m_Velarized;}
			set {m_Velarized = value;}
		}

		public bool Syllabic
		{
			get {return m_Syllabic;}
			set {m_Syllabic = value;}
		}

        public bool Aspirated
        {
            get {return m_Aspirated;}
            set {m_Aspirated = value;}
        }

        public bool Long
        {
            get { return m_Long; }
            set { m_Long = value; }
        }

        public bool Glottalized
        {
            get { return m_Glottalized; }
            set { m_Glottalized = value; }
        }

        public bool Combination
        {
            get { return m_Combination; }
            set { m_Combination = value; }
        }

        public ConsonantFeatures SetFeature(string strFeature)
		{
			if (strFeature == ConsonantFeatures.kBilabial)
			{
				this.PointOfArticulation = strFeature;
			}
			else if (strFeature == ConsonantFeatures.kLabiodental)
			{
				this.PointOfArticulation = strFeature;
			}
			else if (strFeature == ConsonantFeatures.kDental)
			{
				this.PointOfArticulation = strFeature;
			}
			else if (strFeature == ConsonantFeatures.kAlveolar)
			{
				this.PointOfArticulation = strFeature;
			}
			else if (strFeature == ConsonantFeatures.kPostalveolar)
			{
				this.PointOfArticulation = strFeature;
			}
			else if (strFeature == ConsonantFeatures.kRetroflex)
			{
				this.PointOfArticulation = strFeature;
			}
			else if (strFeature == ConsonantFeatures.kPalatal)
			{
				this.PointOfArticulation = strFeature;
			}
			else if (strFeature == ConsonantFeatures.kVelar)
			{
				this.PointOfArticulation = strFeature;
			}
			else if (strFeature == ConsonantFeatures.kLabialvelar)
			{
				this.PointOfArticulation = strFeature;
			}
			else if (strFeature == ConsonantFeatures.kUvular)
			{
				this.PointOfArticulation = strFeature;
			}
			else if (strFeature == ConsonantFeatures.kPharyngeal)
			{
				this.PointOfArticulation = strFeature;
			}
			else if (strFeature == ConsonantFeatures.kGlottal)
			{
				this.PointOfArticulation = strFeature;
			}
			else if (strFeature == ConsonantFeatures.kPlosive)
			{
				this.MannerOfArticulation = strFeature;
			}
			else if (strFeature == ConsonantFeatures.kNasal)
			{
				this.MannerOfArticulation = strFeature;
			}
			else if (strFeature == ConsonantFeatures.kTrill)
			{
				this.MannerOfArticulation = strFeature;
			}
			else if (strFeature == ConsonantFeatures.kFlap)
			{
				this.MannerOfArticulation = strFeature;
			}
			else if (strFeature == ConsonantFeatures.kFricative)
			{
				this.MannerOfArticulation = strFeature;
			}
			else if (strFeature == ConsonantFeatures.kAffricate)
			{
				this.MannerOfArticulation = strFeature;
			}
			else if (strFeature == ConsonantFeatures.kLateralFricative)
			{
				this.MannerOfArticulation = strFeature;
			}
			else if (strFeature == ConsonantFeatures.kLateralApproximant)
			{
				this.MannerOfArticulation = strFeature;
			}
			else if (strFeature == ConsonantFeatures.kApproximant)
			{
				this.MannerOfArticulation = strFeature;
			}
			else if (strFeature == ConsonantFeatures.kImplosive)
			{
				this.MannerOfArticulation = strFeature;
			}
			else if (strFeature == ConsonantFeatures.kEjective)
			{
				this.MannerOfArticulation = strFeature;
			}
			else if (strFeature == ConsonantFeatures.kClick)
			{
				this.MannerOfArticulation = strFeature;
			}
			else if (strFeature == ConsonantFeatures.kVoiced)
			{
				this.Voiced = true;
			}
			else if (strFeature == ConsonantFeatures.kPrenasalized)
			{
				this.Prenasalized = true;
			}
			else if (strFeature == ConsonantFeatures.kLabialized)
			{
				this.Labialized = true;
			}
			else if (strFeature == ConsonantFeatures.kPalatalized)
			{
				this.Palatalized = true;
			}
			else if (strFeature == ConsonantFeatures.kVelarized)
			{
				this.Velarized = true;
			}
			else if (strFeature == ConsonantFeatures.kSyllabic)
			{
				this.Syllabic = true;
			}
            else if (strFeature == ConsonantFeatures.kAspirated)
            {
                this.Aspirated = true;
            }
            else if (strFeature == ConsonantFeatures.kLong)
            {
                this.Long= true;
            }
            else if (strFeature == ConsonantFeatures.kGlottalized)
            {
                this.Glottalized = true;
            }
            else if (strFeature == ConsonantFeatures.kCombination)
            {
                this.Combination = true;
            }
            return this;
		}

	}
}

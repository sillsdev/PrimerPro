using System;

namespace PrimerProObjects
{
	/// <summary>
	/// Consonant Class
	/// </summary>
	public class Consonant : Grapheme
	{
        // Point of articulation
		private bool m_IsBilabial;
		private bool m_IsLabiodental;
		private bool m_IsDental;
		private bool m_IsAlveolar;
		private bool m_IsPostalveolar;
		private bool m_IsRetroflex;
		private bool m_IsPalatal;
		private bool m_IsVelar;
		private bool m_IsLabialvelar;
		private bool m_IsUvular;
		private bool m_IsPharyngeal;
		private bool m_IsGlottal;

   		// Manner of articulation
        private bool m_IsPlosive;
		private bool m_IsNasal;
		private bool m_IsTrill;
		private bool m_IsFlap;
		private bool m_IsFricative;
		private bool m_IsAffricate;
		private bool m_IsLateralFric;
		private bool m_IsLateralAppr;
		private bool m_IsApproximant;
		private bool m_IsClick;
		private bool m_IsImplosive;
		private bool m_IsEjective;
		
        // Other features
        private bool m_IsVoiced;
		private bool m_IsPrenasalized;
		private bool m_IsLabialized;
		private	bool m_IsPalatalized;
		private bool m_IsVelarized;
		private bool m_IsSyllabic;
        private bool m_IsAspirated;
        private bool m_IsLong;
        private bool m_IsGlottalized;

        private int m_TeachingOrder;        //Teaching Order Number

		public Consonant(string strSymbol) : base(strSymbol)
		{
            this.IsConsonant = true;
			this.m_IsBilabial = false;
			this.m_IsLabiodental = false;
			this.m_IsDental = false;
			this.m_IsAlveolar = false;
			this.m_IsPostalveolar = false;
			this.m_IsRetroflex = false;
			this.m_IsPalatal = false;
			this.m_IsVelar = false;
			this.m_IsLabialvelar = false;
			this.m_IsUvular = false;
			this.m_IsPharyngeal = false;
			this.m_IsGlottal = false;

			this.m_IsPlosive = false;
			this.m_IsNasal = false;
			this.m_IsTrill = false;
			this.m_IsFlap = false;
			this.m_IsFricative = false;
			this.m_IsAffricate = false;
			this.m_IsLateralFric = false;
			this.m_IsLateralAppr = false;
			this.m_IsApproximant = false;
			this.m_IsClick = false;
			this.m_IsImplosive = false;
			this.m_IsEjective = false;

			this.m_IsVoiced = false;
			this.m_IsPrenasalized = false;
			this.m_IsLabialized = false;
			this.m_IsPalatalized = false;
			this.m_IsVelarized = false;
			this.m_IsSyllabic = false;
            this.m_IsAspirated = false;
            this.m_IsLong = false;
            this.m_IsGlottalized = false;
		}

		public bool IsBilabial
		{
			get {return m_IsBilabial;}
			set {m_IsBilabial = value;}
		}

		public bool IsLabiodental
		{
			get {return m_IsLabiodental;}
			set {m_IsLabiodental = value;}
		}

		public bool IsDental
		{
			get {return m_IsDental;}
			set {m_IsDental = value;}
		}

		public bool IsAlveolar
		{
			get {return m_IsAlveolar;}
			set {m_IsAlveolar = value;}
		}

		public bool IsPostalveolar
		{
			get {return m_IsPostalveolar;}
			set {m_IsPostalveolar = value;}
		}

		public bool IsRetroflex
		{
			get {return m_IsRetroflex;}
			set {m_IsRetroflex = value;}
		}

		public bool IsPalatal
		{
			get {return m_IsPalatal;}
			set {m_IsPalatal = value;}
		}

		public bool IsVelar
		{
			get {return m_IsVelar;}
			set {m_IsVelar = value;}
		}

		public bool IsLabialvelar
		{
			get {return m_IsLabialvelar;}
			set {m_IsLabialvelar = value;}
		}

		public bool IsUvular
		{
			get {return m_IsUvular;}
			set {m_IsUvular = value;}
		}

		public bool IsPharyngeal
		{
			get {return m_IsPharyngeal;}
			set {m_IsPharyngeal = value;}
		}

		public bool IsGlottal
		{
			get {return m_IsGlottal;}
			set {m_IsGlottal = value;}
		}

		public string PointOfArticulation
		{
			get
			{
				if (IsBilabial) return ConsonantFeatures.kBilabial;
				if (IsLabiodental) return ConsonantFeatures.kLabiodental;
				if (IsDental) return ConsonantFeatures.kDental;
				if (IsAlveolar) return ConsonantFeatures.kAlveolar;
				if (IsPostalveolar) return ConsonantFeatures.kPostalveolar;
				if (IsRetroflex) return ConsonantFeatures.kRetroflex;
				if (IsPalatal) return ConsonantFeatures.kPalatal;
				if (IsVelar) return ConsonantFeatures.kVelar;
				if (IsLabialvelar) return ConsonantFeatures.kLabialvelar;
				if (IsUvular) return ConsonantFeatures.kUvular;
				if (IsPharyngeal) return ConsonantFeatures.kPharyngeal;
				if (IsGlottal) return ConsonantFeatures.kGlottal;
				return "";
			}
		}

		public bool IsPlosive
		{
			get {return m_IsPlosive;}
			set {m_IsPlosive = value;}
		}

		public bool IsNasal
		{
			get {return m_IsNasal;}
			set {m_IsNasal = value;}
		}

		public bool IsTrill
		{
			get {return m_IsTrill;}
			set {m_IsTrill = value;}
		}

		public bool IsFlap
		{
			get {return m_IsFlap;}
			set {m_IsFlap = value;}
		}

		public bool IsFricative
		{
			get {return m_IsFricative;}
			set {m_IsFricative = value;}
		}

		public bool IsAffricate
		{
			get {return m_IsAffricate;}
			set {m_IsAffricate = value;}
		}

		public bool IsLateralFric
		{
			get {return m_IsLateralFric;}
			set {m_IsLateralFric = value;}
		}

		public bool IsLateralAppr
		{
			get {return m_IsLateralAppr;}
			set {m_IsLateralAppr = value;}
		}

		public bool IsApproximant
		{
			get {return m_IsApproximant;}
			set {m_IsApproximant = value;}
		}

		public bool IsClick
		{
			get {return m_IsClick;}
			set {m_IsClick = value;}
		}

		public bool IsImplosive
		{
			get {return m_IsImplosive;}
			set {m_IsImplosive = value;}
		}

		public bool IsEjective
		{
			get {return m_IsEjective;}
			set {m_IsEjective = value;}
		}

		public string MannerOfArticulation
		{
			get
			{
				if (IsPlosive) return ConsonantFeatures.kPlosive;
				if (IsNasal) return ConsonantFeatures.kNasal;
				if (IsTrill) return ConsonantFeatures.kTrill;
				if (IsFlap) return ConsonantFeatures.kFlap;
				if (IsFricative) return ConsonantFeatures.kFricative;
				if (IsAffricate) return ConsonantFeatures.kAffricate;
				if (IsLateralFric) return ConsonantFeatures.kLateralFricative;
				if (IsLateralAppr) return ConsonantFeatures.kLateralApproximant;
				if (IsApproximant) return ConsonantFeatures.kApproximant;
				if (IsClick) return ConsonantFeatures.kClick;
				if (IsImplosive) return ConsonantFeatures.kImplosive;
				if (IsEjective) return ConsonantFeatures.kEjective;
				return "";
			}
		}

		public bool IsVoiced
		{
			get {return m_IsVoiced;}
			set {m_IsVoiced = value;}
		}

		public bool IsPrenasalized
		{
			get {return m_IsPrenasalized;}
			set {m_IsPrenasalized = value;}
		}

		public bool IsLabialized
		{
			get {return m_IsLabialized;}
			set {m_IsLabialized = value;}
		}

		public bool IsVelarized
		{
			get {return m_IsVelarized;}
			set {m_IsVelarized = value;}
		}

		public bool IsPalatalized
		{
			get {return m_IsPalatalized;}
			set {m_IsPalatalized = value;}
		}

		public bool IsSyllabic
		{
			get {return m_IsSyllabic;}
			set {m_IsSyllabic = value;}
		}

        public bool IsAspirated
        {
            get { return m_IsAspirated; }
            set { m_IsAspirated = value; }
        }

        public bool IsLong
        {
            get { return m_IsLong; }
            set { m_IsLong = value; }
        }

        public bool IsGlottalized
        {
            get { return m_IsGlottalized; }
            set { m_IsGlottalized = value; }
        }

        public int TeachingOrder
        {
            get { return m_TeachingOrder; }
            set { m_TeachingOrder = value; }
        }

        public bool MatchesFeatures(ConsonantFeatures cf)
		{
			bool flag = true;
			if ( (cf.PointOfArticulation != "") && (cf.PointOfArticulation != this.PointOfArticulation) )
				flag = false;
			if ( (cf.MannerOfArticulation != "") && (cf.MannerOfArticulation != this.MannerOfArticulation) )
				flag = false;
            if ((cf.Combination) && (!this.IsComplex))
                flag = false;
            if ((cf.Glottalized) && (!this.IsGlottalized))
                flag = false;
            if ((cf.Long) && (!this.IsLong))
                flag = false;
            if ( (cf.Aspirated) && (!this.IsAspirated) )
                flag = false;
			if ( (cf.Labialized) && (!this.IsLabialized) )
				flag = false;
			if ( (cf.Palatalized) && (!this.IsPalatalized) )
				flag = false;
			if ( (cf.Prenasalized) && (!this.IsPrenasalized) )
				flag = false;
			if ( (cf.Syllabic) && !(this.IsSyllabic) )
				flag = false;
			if ( (cf.Velarized) && (!this.IsVelarized) )
				flag = false;
			if ( (cf.Voiced) && (!this.IsVoiced) )
				flag = false;
			if ( (cf.Voiceless) && (this.IsVoiced) )
				flag = false;
			return flag;
		}

    }
}

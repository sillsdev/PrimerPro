using System;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using PrimerProForms;
using PrimerProObjects;
using GenLib;

namespace PrimerProSearch
{
	/// <summary>
	/// Consonant Chart Search
	/// </summary>
	public class ConsonantChartSearch : Search
	{
		//Search parameters
        private bool m_Labialized;
		private bool m_Palatalized;
		private bool m_Velarized;
		private bool m_Prenasalized;
		private bool m_Syllabic;
        private bool m_Aspirated;
        private bool m_Long;
        private bool m_Glottalized;
        private bool m_Combination;         //same as complex

        private Settings m_Settings;
        private string m_Title;
		private ConsonantChartTable m_CnsTable;
        private CombinationChartTable m_CmbTable;

        //private const string kTitle = "Consonant Chart";

        //Search definition tags
        private const string kLabial = "labialized";
		private const string kPalat = "palatalized";
		private const string kVelar = "velarized";
		private const string kPrenas = "prenasalized";
		private const string kSyll = "syllabic";
        private const string kAspir = "aspirated";
        private const string kLong = "long";
        private const string kGlott = "glottalized";
        private const string kCombn = "combination";

		public ConsonantChartSearch(int number, Settings s) : base(number, SearchDefinition.kConsonant)
		{
			m_Labialized = false;
			m_Palatalized = false;
			m_Velarized = false;
			m_Prenasalized = false;
			m_Syllabic = false;
            m_Aspirated = false;
            m_Long = false;
            m_Glottalized = false;
            m_Combination = false;

            m_Settings = s;
            //m_Title = ConsonantChartSearch.kTitle;
            m_Title = m_Settings.LocalizationTable.GetMessage("ConsonantChartSearchT");
            if (m_Title == "")
                m_Title = "Consonant Chart";
			m_CnsTable = new ConsonantChartTable();
            m_CmbTable = new CombinationChartTable();
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

		public bool Prenasalized
		{
			get {return m_Prenasalized;}
			set {m_Prenasalized = value;}
		}

		public bool Syllabic
		{
			get {return m_Syllabic;}
			set {m_Syllabic = value;}
		}

        public bool Aspirated
        {
            get { return m_Aspirated; }
            set { m_Aspirated = value; }
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

        public string Title
		{
			get {return m_Title;}
		}

		public ConsonantChartTable CnsTable
		{
			get {return m_CnsTable;}
			set {m_CnsTable = value;}
		}

        public CombinationChartTable CmbTable
        {
            get { return m_CmbTable; }
            set { m_CmbTable = value; }
        }

       	public bool SetupSearch()
		{
			bool flag = false;
            //FormConsonantChart fpb = new FormConsonantChart();
			FormConsonantChart form = new FormConsonantChart(m_Settings.LocalizationTable);
			DialogResult dr = form.ShowDialog();
			if (dr == DialogResult.OK)
			{
                this.Labialized = form.Labialized;
                this.Palatalized = form.Palatalized;
                this.Velarized = form.Velarized;
                this.Prenasalized = form.Prenasalized;
                this.Syllabic = form.Syllabic;
                this.Aspirated = form.Aspirated;
                this.Long = form.Long;
                this.Glottalized = form.Glottalized;
                this.Combination = form.Combination;

				SearchDefinition sd = new SearchDefinition(SearchDefinition.kConsonant);
                SearchDefinitionParm sdp = null;
                this.SearchDefinition = sd;

                string strType = "";
                if (this.Labialized)
				{
                    strType += this.CapitalizeFirstChar(ConsonantChartSearch.kLabial) + Constants.Space;
                    sdp = new SearchDefinitionParm(ConsonantChartSearch.kLabial, "");
					sd.AddSearchParm(sdp);
				}
				if (this.Palatalized)
				{
                    strType += this.CapitalizeFirstChar(ConsonantChartSearch.kPalat) + Constants.Space;
                    sdp = new SearchDefinitionParm(ConsonantChartSearch.kPalat, "");
					sd.AddSearchParm(sdp);
				}
				if (this.Velarized)
				{
                    strType += this.CapitalizeFirstChar(ConsonantChartSearch.kVelar) + Constants.Space;
                    sdp = new SearchDefinitionParm(ConsonantChartSearch.kVelar, "");
					sd.AddSearchParm(sdp);
				}
				if (this.Prenasalized)
				{
                    strType += this.CapitalizeFirstChar(ConsonantChartSearch.kPrenas) + Constants.Space;
                    sdp = new SearchDefinitionParm(ConsonantChartSearch.kPrenas, "");
					sd.AddSearchParm(sdp);
				}
				if (this.Syllabic)
				{
                    strType += this.CapitalizeFirstChar(ConsonantChartSearch.kSyll) + Constants.Space;
                    sdp = new SearchDefinitionParm(ConsonantChartSearch.kSyll, "");
					sd.AddSearchParm(sdp);
				}
                if (this.Aspirated)
                {
                    strType += this.CapitalizeFirstChar(ConsonantChartSearch.kAspir) + Constants.Space;
                    sdp = new SearchDefinitionParm(ConsonantChartSearch.kAspir, "");
                    sd.AddSearchParm(sdp);
                }
                if (this.Long)
                {
                    strType += this.CapitalizeFirstChar(ConsonantChartSearch.kLong) + Constants.Space;
                    sdp = new SearchDefinitionParm(ConsonantChartSearch.kLong, "");
                    sd.AddSearchParm(sdp);
                }
                if (this.Glottalized)
                {
                    strType += this.CapitalizeFirstChar(ConsonantChartSearch.kGlott) + Constants.Space;
                    sdp = new SearchDefinitionParm(ConsonantChartSearch.kGlott, "");
                    sd.AddSearchParm(sdp);
                }
                if (this.Combination)
                {
                    strType += this.CapitalizeFirstChar(ConsonantChartSearch.kCombn) + Constants.Space;
                    sdp = new SearchDefinitionParm(ConsonantChartSearch.kCombn, "");
                    sd.AddSearchParm(sdp);
                }
				if (strType != "")
				    m_Title = strType + m_Title;
                this.SearchDefinition = sd;
                flag = true;
			}
			return flag;
		}

		public bool SetupSearch(SearchDefinition sd)
		{
			bool flag = true;
			string strTag = "";
			for (int i = 0; i < sd.SearchParmsCount(); i++)
			{
				strTag = sd.GetSearchParmAt(i).GetTag();
                m_Title = this.CapitalizeFirstChar(strTag) + Constants.Space + m_Title;
				switch (strTag)
				{
					case ConsonantChartSearch.kLabial:
						this.Labialized = true;
						break;
					case ConsonantChartSearch.kPalat:
						this.Palatalized = true;
						break;
					case ConsonantChartSearch.kVelar:
						this.Velarized = true;
						break;
					case ConsonantChartSearch.kPrenas:
						this.Prenasalized = true;
						break;
					case ConsonantChartSearch.kSyll:
						this.Syllabic = true;
						break;
                    case ConsonantChartSearch.kAspir:
                        this.Aspirated = true;
                        break;
                    case ConsonantChartSearch.kLong:
                        this.Long = true;
                        break;
                    case ConsonantChartSearch.kGlott:
                        this.Glottalized = true;
                        break;
                    case ConsonantChartSearch.kCombn:
                        this.Combination = true;
                        break;
                    default:
						break;
				}
			}
            this.SearchDefinition = sd;
			return flag;
		}

		public string BuildResults()
		{
			string strText = "";
			string strSN = Search.TagSN + this.SearchNumber.ToString().Trim();
			strText += Search.TagOpener + strSN + Search.TagCloser + Environment.NewLine;
			strText += this.Title;
			strText += Environment.NewLine + Environment.NewLine;
			strText += this.SearchResults;
			strText += Search.TagOpener + Search.TagForwardSlash + strSN
				+ Search.TagCloser;
			return strText;
		}

        public ConsonantChartSearch ExecuteConsonantChart(GraphemeInventory gi)
        {
            this.SearchResults = "";
            if (this.Combination)
            {
                CombinationChartTable tbl = BuildCombinationTable(gi);
                if (tbl != null)
                {
                    this.SearchResults += tbl.GetColumnHeaders();
                    this.SearchResults += tbl.GetRows();
                }
            }
            else
            {
                ConsonantChartTable tbl = BuildConsonantTable(gi);
                if (tbl != null)
                {
                    this.SearchResults += tbl.GetColumnHeaders();
                    this.SearchResults += tbl.GetRows(this);
                }
            }
            return this;
   }

        private ConsonantChartTable BuildConsonantTable(GraphemeInventory gi)
        {
            ConsonantChartTable tbl = null;
            Consonant cns = null;
            bool fLabialized = this.Labialized;
            bool fPalatalized = this.Palatalized;
            bool fVelarized = this.Velarized;
            bool fPrenasalized = this.Prenasalized;
            bool fSyllabic = this.Syllabic;
            bool fAspirated = this.Aspirated;
            bool fLong = this.Long;
            bool fGlottalized = this.Glottalized;
            bool fCombination = this.Combination;

            for (int i = 0; i < gi.ConsonantCount(); i++)
            {
                cns = gi.GetConsonant(i);
                if ((fLabialized == cns.IsLabialized) &&
                    (fPalatalized == cns.IsPalatalized) &&
                    (fVelarized == cns.IsVelarized) &&
                    (fPrenasalized == cns.IsPrenasalized) &&
                    (fSyllabic == cns.IsSyllabic) &&
                    (fAspirated == cns.IsAspirated) &&
                    (fLong == cns.IsLong) &&
                    (fGlottalized == cns.IsGlottalized) &&
                    (fCombination == cns.IsComplex))
                {
                    tbl = this.CnsTable;
                    AddConsonantToTable(gi, cns, tbl);
                }
                cns = null;
            }
            return tbl;
        }

        private void AddConsonantToTable(GraphemeInventory gi, Consonant cns, ConsonantChartTable tbl)
        {
            string strSymbol = "";
            int nRow = -1;
            int nCol = -1;

            strSymbol = cns.Symbol.PadLeft(gi.MaxGraphemeSize + 1, Constants.Space);
            if (cns.IsBilabial)
                nCol = tbl.GetColNumber("BL");
            if (cns.IsLabiodental)
                nCol = tbl.GetColNumber("LD");
            if (cns.IsDental)
                nCol = tbl.GetColNumber("DE");
            if (cns.IsAlveolar)
                nCol = tbl.GetColNumber("AL");
            if (cns.IsPostalveolar)
                nCol = tbl.GetColNumber("PO");
            if (cns.IsRetroflex)
                nCol = tbl.GetColNumber("RE");
            if (cns.IsPalatal)
                nCol = tbl.GetColNumber("PA");
            if (cns.IsVelar)
                nCol = tbl.GetColNumber("VE");
            if (cns.IsLabialvelar)
                nCol = tbl.GetColNumber("LV");
            if (cns.IsUvular)
                nCol = tbl.GetColNumber("UV");
            if (cns.IsPharyngeal)
                nCol = tbl.GetColNumber("PH");
            if (cns.IsGlottal)
                nCol = tbl.GetColNumber("GL");

            if (cns.IsPlosive)
            {
                if (cns.IsVoiced)
                    nRow = tbl.GetRowNumber("PL+");
                else nRow = tbl.GetRowNumber("PL-");
            }
            if (cns.IsNasal)
            {
                if (cns.IsVoiced)
                    nRow = tbl.GetRowNumber("NA+");
                else nRow = tbl.GetRowNumber("NA-");
            }
            if (cns.IsTrill)
            {
                if (cns.IsVoiced)
                    nRow = tbl.GetRowNumber("TR+");
                else nRow = tbl.GetRowNumber("TR-");
            }
            if (cns.IsFlap)
            {
                if (cns.IsVoiced)
                    nRow = tbl.GetRowNumber("FL+");
                else nRow = tbl.GetRowNumber("FL-");
            }
            if (cns.IsFricative)
            {
                if (cns.IsVoiced)
                    nRow = tbl.GetRowNumber("FR+");
                else nRow = tbl.GetRowNumber("FR-");
            }
            if (cns.IsAffricate)
            {
                if (cns.IsVoiced)
                    nRow = tbl.GetRowNumber("AF+");
                else nRow = tbl.GetRowNumber("AF-");
            }
            if (cns.IsLateralFric)
            {
                if (cns.IsVoiced)
                    nRow = tbl.GetRowNumber("LF+");
                else nRow = tbl.GetRowNumber("LF-");
            }
            if (cns.IsLateralAppr)
            {
                if (cns.IsVoiced)
                    nRow = tbl.GetRowNumber("LA+");
                else nRow = tbl.GetRowNumber("LA-");
            }
            if (cns.IsApproximant)
            {
                if (cns.IsVoiced)
                    nRow = tbl.GetRowNumber("AP+");
                else nRow = tbl.GetRowNumber("AP-");
            }
            if (cns.IsImplosive)
            {
                if (cns.IsVoiced)
                    nRow = tbl.GetRowNumber("IM+");
                else nRow = tbl.GetRowNumber("IM-");
            }
            if (cns.IsEjective)
            {
                if (cns.IsVoiced)
                    nRow = tbl.GetRowNumber("EJ+");
                else nRow = tbl.GetRowNumber("EJ-");
            }
            if (cns.IsClick)
            {
                if (cns.IsVoiced)
                    nRow = tbl.GetRowNumber("CL+");
                else nRow = tbl.GetRowNumber("CL-");
            }

            if ((nRow >= 0) && (nCol > 0))
            {
                tbl.UpdChartCell(strSymbol, nRow, nCol);
            }
            //else MessageBox.Show(strSymbol + " is not added to chart");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("ConsonantChartSearch1");
                if (strMsg == "")
                    strMsg = "is not added to chart";
                MessageBox.Show(strSymbol + Constants.Space + strMsg);
            }
        }
        
        private CombinationChartTable BuildCombinationTable(GraphemeInventory gi)
        {
            CombinationChartTable tbl = new CombinationChartTable();
            Consonant cns = null;
            string strSym = "";
            ArrayList alComponents = null;
            string strComponent = "";
            string strComponents = "";
            
            for (int i = 0; i < gi.ConsonantCount(); i++)
            {
                cns = gi.GetConsonant(i);
                strComponents = "";
                if (cns.IsComplex)
                {
                    strSym = cns.Symbol;
                    alComponents = cns.ComplexComponents;
                    for (int j = 0; j < alComponents.Count; j++)
                    {
                        strComponent = alComponents[j].ToString().Trim();
                        if (!gi.IsInInventory(strComponent))
                            strComponent = Constants.kHCOn + strComponent + Constants.kHCOff;
                        strComponents += strComponent + Constants.Space.ToString();
                    }
                    tbl = tbl.AddRow(strSym, strComponents);
                }
            }
            return tbl;
        }
        
        private string CapitalizeFirstChar(string str)
        {
            string strBegin = str.Substring(0, 1);
            string strRest = str.Substring(1);
            strBegin = strBegin.ToUpper();
            str = strBegin + strRest;
            return str;
        }
		
	}
}

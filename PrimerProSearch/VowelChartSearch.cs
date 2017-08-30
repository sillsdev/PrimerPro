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
	/// 
	/// </summary>
	public class VowelChartSearch : Search
	{
        //Search parameters
		private bool m_Nasal;
		private bool m_Long;
        private bool m_Diphthong;
        private bool m_Voiceless;

		private string m_Title;
        private Settings m_Settings;
		private VowelChartTable m_Table;

        //private const string kTitle = "Vowel Chart";

        //Search definition tags
        private const string kLong = "long";
		private const string kNasal = "nasal";
        private const string kVoiceless = "voiceless";
        private const string kDipthong = "diphthong";

		public VowelChartSearch(int number, Settings s) : base(number, SearchDefinition.kVowel)
		{
			m_Nasal = false;
			m_Long = false;
            m_Diphthong = false;
            m_Voiceless = false;
            m_Settings = s;
            //m_Title = VowelChartSearch.kTitle;
            m_Title = m_Settings.LocalizationTable.GetMessage("VowelChartSearchT",
                m_Settings.OptionSettings.UILanguage);
			m_Table = new VowelChartTable();
		}

		public bool Nasal
		{
			get {return m_Nasal;}
			set {m_Nasal = value;}
		}

		public bool Long
		{
			get {return m_Long;}
			set {m_Long = value;}
		}

        public bool Voiceless
        {
            get { return m_Voiceless; }
            set { m_Voiceless = value; }
        }

        public bool Diphthong
        {
            get { return m_Diphthong; }
            set { m_Diphthong = value; }
        }

        public string Title
		{
			get {return m_Title;}
		}

		public VowelChartTable Table
		{
			get {return m_Table;}
			set {m_Table = value;}
		}

		public bool SetupSearch()
		{
			bool flag = false;
            string strType = "";
            //FormVowelChart fpb = new FormVowelChart();
            FormVowelChart form = new FormVowelChart(m_Settings.LocalizationTable,
                m_Settings.OptionSettings.UILanguage);
			DialogResult dr;
			dr = form.ShowDialog();
			if (dr == DialogResult.OK)
			{
                this.Long = form.Long;
                this.Nasal = form.Nasal;
                this.Voiceless = form.Voiceless;
                this.Diphthong = form.Diphthong;

				SearchDefinition sd = new SearchDefinition(SearchDefinition.kVowel);
				SearchDefinitionParm sdp;
                this.SearchDefinition = sd;

				if (this.Long)
				{
                    strType += CapitalizeFirstChar(VowelChartSearch.kLong) + Constants.Space;
                    //strType += m_Settings.LocalizationTable.GetMessage("VowelChartSearch2",
                    //    m_Settings.OptionSettings.UILanguage) + Constants.Space;
                    sdp = new SearchDefinitionParm(VowelChartSearch.kLong, "");
					sd.AddSearchParm(sdp);
				}
				if (form.Nasal)
				{
                    strType += CapitalizeFirstChar(VowelChartSearch.kNasal) + Constants.Space;
                    //strType += m_Settings.LocalizationTable.GetMessage("VowelChartSearch3",
                    //    m_Settings.OptionSettings.UILanguage) + Constants.Space;
                    sdp = new SearchDefinitionParm(VowelChartSearch.kNasal, "");
					sd.AddSearchParm(sdp);
				}
                if (form.Voiceless)
                {
                    strType += CapitalizeFirstChar(VowelChartSearch.kVoiceless) + Constants.Space;
                    //strType += m_Settings.LocalizationTable.GetMessage("VowelChartSearch4",
                    //    m_Settings.OptionSettings.UILanguage) + Constants.Space;
                    sdp = new SearchDefinitionParm(VowelChartSearch.kVoiceless, "");
                    sd.AddSearchParm(sdp);
                }
                if (form.Diphthong)
                {
                    strType += CapitalizeFirstChar(VowelChartSearch.kDipthong) + Constants.Space;
                    //strType += m_Settings.LocalizationTable.GetMessage("VowelChartSearch5",
                    //    m_Settings.OptionSettings.UILanguage) + Constants.Space;
                    sdp = new SearchDefinitionParm(VowelChartSearch.kDipthong, "");
                    sd.AddSearchParm(sdp);
                }
                this.SearchDefinition = sd;
                if (strType != "")
                    m_Title = strType + m_Title;
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
                m_Title = CapitalizeFirstChar(strTag) + Constants.Space + this.Title;
                switch (strTag)
                {
                    case VowelChartSearch.kLong:
                        this.Long = true;
                        break;
                    case VowelChartSearch.kNasal:
                        this.Nasal = true;
                        break;
                    case VowelChartSearch.kVoiceless:
                        this.Voiceless = true;
                        break;
                    case VowelChartSearch.kDipthong:
                        this.Diphthong = true;
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

        public VowelChartSearch ExecuteVowelChart(GraphemeInventory gi)
        {
            this.SearchResults = "";
            if (this.Diphthong)
            {
                DiphthongChartTable tbl = BuildDiphthongTable(gi);
                if (tbl != null)
                {
                    this.SearchResults += tbl.GetColumnHeaders();
                    this.SearchResults += tbl.GetRows();
                }
            }
            else
            {
                VowelChartTable tbl = BuildVowelTable(gi);
                if (tbl != null)
                {
                    this.SearchResults += tbl.GetColumnHeaders();
                    this.SearchResults += tbl.GetRows();
                }
            }
            return this;
        }

        private VowelChartTable BuildVowelTable(GraphemeInventory gi)
        {
            VowelChartTable tbl = null; ;
            Vowel vwl = null;
            bool fLong = this.Long;
            bool fNasal = this.Nasal;
            bool fDipthong = this.Diphthong;
            bool fVoiceless = this.Voiceless;

            for (int i = 0; i < gi.VowelCount(); i++)
            {
                vwl = gi.GetVowel(i);
                if ((fLong == vwl.IsLong) &&
                    (fNasal == vwl.IsNasal) &&
                    (fDipthong == vwl.IsComplex) &&
                    (fVoiceless == vwl.IsVoiceless))
                {
                    tbl = this.Table;
                    AddVowelToTable(gi, vwl, tbl);
                }
                vwl = null;
            }
            return tbl;
        }

        private void AddVowelToTable(GraphemeInventory gi, Vowel vwl, VowelChartTable tbl)
        {
            string strSymbol = "";
            int nRow = -1;
            int nCol = -1;

            strSymbol = vwl.Symbol.PadLeft(gi.MaxGraphemeSize, Constants.Space);
            if (vwl.IsFront && !vwl.IsRound)
                nCol = tbl.GetColNumber("FU");
            if (vwl.IsFront && vwl.IsRound)
                nCol = tbl.GetColNumber("FR");
            if (vwl.IsCentral && !vwl.IsRound)
                nCol = tbl.GetColNumber("CU");
            if (vwl.IsCentral && vwl.IsRound)
                nCol = tbl.GetColNumber("CR");
            if (vwl.IsBack && !vwl.IsRound)
                nCol = tbl.GetColNumber("BU");
            if (vwl.IsBack && vwl.IsRound)
                nCol = tbl.GetColNumber("BR");


            if (vwl.IsHigh)
            {
                if (vwl.IsPlusATR)
                    nRow = tbl.GetRowNumber("HP");
                else nRow = tbl.GetRowNumber("HM");
            }
            if (vwl.IsMid)
            {
                if (vwl.IsPlusATR)
                    nRow = tbl.GetRowNumber("MP");
                else nRow = tbl.GetRowNumber("MM");
            }
            if (vwl.IsLow)
            {
                if (vwl.IsPlusATR)
                    nRow = tbl.GetRowNumber("LP");
                else nRow = tbl.GetRowNumber("LM");
            }

            if ((nRow >= 0) && (nCol >= 0))
            {
                tbl.UpdChartCell(strSymbol, nRow, nCol);
            }
            //else MessageBox.Show(strSymbol + " is not added to chart");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("VowelChartSearch1",
                    m_Settings.OptionSettings.UILanguage);
                MessageBox.Show(strSymbol + Constants.Space + strMsg);
            }
        }

        private DiphthongChartTable BuildDiphthongTable(GraphemeInventory gi)
        {
            DiphthongChartTable tbl = new DiphthongChartTable();
            Vowel vwl = null;
            string strSym = "";
            string strKey = "";
            ArrayList alComponents = null;
            string strComponent = "";
            string strComponents = "";

            for (int i = 0; i < gi.VowelCount(); i++)
            {
                vwl = gi.GetVowel(i);
                strComponents = "";
                if (vwl.IsComplex)
                {
                    strSym = vwl.Symbol;
                    strKey = vwl.GetKey();
                    alComponents = vwl.ComplexComponents;
                    for (int j = 0; j < alComponents.Count; j++)
                    {
                        strComponent = alComponents[j].ToString().Trim();
                        if (!gi.IsInInventory(strComponent))
                            strComponent = Constants.kHCOn + strComponent + Constants.kHCOff;
                        strComponents += strComponent + Constants.Space.ToString();
                    }
                    tbl = tbl.AddRow(strSym, strKey, strComponents);
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

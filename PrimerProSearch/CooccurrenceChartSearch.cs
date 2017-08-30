using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Collections;
using PrimerProForms;
using PrimerProObjects;
using GenLib;

namespace PrimerProSearch
{
	/// <summary>
	/// Summary description for CooccurenceChartSearch.
	/// </summary>
	public class CooccurrenceChartSearch : Search
	{
        //Search parameters 
		private ConsonantFeatures m_CFeatures1;     //Features of C1
		private VowelFeatures m_VFeatures1;         //Features of V1
        private SyllographFeatures m_SFeatures1;    //Features of S1
		private ConsonantFeatures m_CFeatures2;     //Features of C2
		private VowelFeatures m_VFeatures2;         //Features of V2
        private SyllographFeatures m_SFeatures2;    //Features of S2
        private SearchOptions m_SearchOptions;

        private string m_Title;
        private CooccurrenceChartTable m_Table;
        private Settings m_Settings;
        private PSTable m_PSTable;
        private GraphemeInventory m_GI;
        private Font m_Fnt;

		private const string kC1 = "C1";
		private const string kC2 = "C2";
		private const string kV1 = "V1";
		private const string kV2 = "V2";
        private const string kS1 = "S1";
        private const string kS2 = "S2";
		private const string kTarget = "target";
		private const string kFeature = "feature";
        private const string kInitial = "initial";
        private const string kMedial = "medial";
        private const string kFinal = "final";

        //private const string kTitle = "Co-occurrence Chart";
        //private const string kSearch = "Processing Co-occurrence Chart"; 

		public CooccurrenceChartSearch(int number, Settings s):
            base(number, SearchDefinition.kCooccurrence)
		{
            m_CFeatures1 = null;
            m_CFeatures2 = null;
            m_VFeatures1 = null;
            m_VFeatures2 = null;
            m_SFeatures1 = null;
            m_SFeatures2 = null;
            m_SearchOptions = null;

            m_Settings = s;
            //m_Title = CooccurrenceChartSearch.kTitle;
            m_Title = m_Settings.LocalizationTable.GetMessage("CooccurrenceChartSearchT",
                m_Settings.OptionSettings.UILanguage);
            m_Table = null;
			m_PSTable = m_Settings.PSTable;
            m_GI = m_Settings.GraphemeInventory;
            m_Fnt = m_Settings.OptionSettings.GetDefaultFont();
        }

		public ConsonantFeatures CFeatures1
		{
			get {return m_CFeatures1;}
			set {m_CFeatures1 = value;}
		}

		public VowelFeatures VFeatures1
		{
			get {return m_VFeatures1;}
			set {m_VFeatures1 = value;}
		}

        public SyllographFeatures SFeatures1
        {
            get { return m_SFeatures1; }
            set { m_SFeatures1 = value; }
        }

		public ConsonantFeatures CFeatures2
		{
			get {return m_CFeatures2;}
			set {m_CFeatures2 = value;}
		}

		public VowelFeatures VFeatures2
		{
			get {return m_VFeatures2;}
			set {m_VFeatures2 = value;}
		}

        public SyllographFeatures SFeatures2
        {
            get { return m_SFeatures2; }
            set { m_SFeatures2 = value; }
        }

        public SearchOptions SearchOptions
        {
            get { return m_SearchOptions; }
            set { m_SearchOptions = value; }
        }

        public string Title
        {
            get { return m_Title; }
        }

        public CooccurrenceChartTable Table
        {
            get { return m_Table; }
            set { m_Table = value; }
        }

        public PSTable PSTable
        {
            get { return m_PSTable; }
        }

        public GraphemeInventory GI
        {
            get { return m_GI; }
        }

        public bool SetupSearch()
		{
			bool flag = false;
            //FormCooccurrenceChart fpb = new FormCooccurrenceChart(m_PSTable);
            FormCooccurrenceChart form = new FormCooccurrenceChart(m_PSTable, m_GI, m_Fnt,
                m_Settings.LocalizationTable, m_Settings.OptionSettings.UILanguage);
			if (form.ShowDialog() == DialogResult.OK)
			{
                this.CFeatures1 = form.CnsFeatures1;
                this.CFeatures2 = form.CnsFeatures2;
                this.VFeatures1 = form.VwlFeatures1;
                this.VFeatures2 = form.VwlFeatures2;
                this.SFeatures1 = form.SyllFeatures1;
                this.SFeatures2 = form.SyllFeatures2;
                this.SearchOptions = form.SearchOptions;

				SearchDefinition sd = new SearchDefinition(SearchDefinition.kCooccurrence);
                //SearchDefinitionParm sdp = null;
                this.SearchDefinition = sd;

				ConsonantFeatures cf1 = this.CFeatures1;
				ConsonantFeatures cf2 = this.CFeatures2;
				VowelFeatures vf1 = this.VFeatures1;
				VowelFeatures vf2 = this.VFeatures2;
                SyllographFeatures sf1 = this.SFeatures1;
                SyllographFeatures sf2 = this.SFeatures2;
				if ( (cf1 != null) || (vf1 != null) || sf1 != null)
				{
					if (cf1 != null)
						sd = AddSearchParmForConsonantFeatures(sd, cf1, CooccurrenceChartSearch.kC1);
					if (vf1 != null)
						sd = AddSearchParmForVowelFeatures(sd, vf1,	CooccurrenceChartSearch.kV1);
                    if (sf1 != null)
                        sd = AddSearchParmForSyllographFeatures(sd, sf1, CooccurrenceChartSearch.kS1);
					flag = true;
				}
                if (flag)
                {
                    flag = false;
                    if ((cf2 != null) || (vf2 != null)  || sf2 != null)
                    {
                        if (cf2 != null)
                            sd = AddSearchParmForConsonantFeatures(sd, cf2, CooccurrenceChartSearch.kC2);
                        if (vf2 != null)
                            sd = AddSearchParmForVowelFeatures(sd, vf2, CooccurrenceChartSearch.kV2);
                        if (sf2 != null)
                            sd = AddSearchParmForSyllographFeatures(sd, sf2, CooccurrenceChartSearch.kS2);

                        if (m_SearchOptions != null)
                            sd.AddSearchOptions(m_SearchOptions);
                        this.SearchDefinition = sd;
                        flag = true;
                    }
                }
                //else MessageBox.Show("Both grapheme classes must be specified");
                else
                {
                    string strMsg = m_Settings.LocalizationTable.GetMessage("CooccurrenceChartSearch2",
                        m_Settings.OptionSettings.UILanguage);
                    MessageBox.Show(strMsg);
                }
			}
			return flag;
		}

		public bool SetupSearch(SearchDefinition sd)
		{
			bool flag = false;
			SearchOptions so = new SearchOptions(m_PSTable);
			string strTag = "";
			string strContent = "";
			string strTyp = "";
			for (int i = 0; i < sd.SearchParmsCount(); i++)
			{
				strTag = sd.GetSearchParmAt(i).GetTag();
				strContent = sd.GetSearchParmAt(i).GetContent();
				if (strTag == CooccurrenceChartSearch.kTarget)
				{
					if (strContent == CooccurrenceChartSearch.kC1)
						this.CFeatures1 = new ConsonantFeatures();
					if (strContent == CooccurrenceChartSearch.kV1)
						this.VFeatures1 = new VowelFeatures();
                    if (strContent == CooccurrenceChartSearch.kS1)
                        this.SFeatures1 = new SyllographFeatures();
					if (strContent == CooccurrenceChartSearch.kC2)
						this.CFeatures2 = new ConsonantFeatures();
					if (strContent == CooccurrenceChartSearch.kV2)
						this.VFeatures2 = new VowelFeatures();
                    if (strContent == CooccurrenceChartSearch.kS2)
                        this.SFeatures2 = new SyllographFeatures();
					strTyp = strContent;
                    flag = true;
				}
				if (strTag == CooccurrenceChartSearch.kFeature)
				{
					if (strTyp == CooccurrenceChartSearch.kC1)
						this.CFeatures1= this.CFeatures1.SetFeature(strContent);
					if (strTyp == CooccurrenceChartSearch.kV1)
						this.VFeatures1 = this.VFeatures1.SetFeature(strContent);
					if (strTyp == CooccurrenceChartSearch.kC2)
						this.CFeatures2 = this.CFeatures2.SetFeature(strContent);
					if (strTyp == CooccurrenceChartSearch.kV2)
						this.VFeatures2 = this.VFeatures2.SetFeature(strContent);
				}
                if (strTag == CooccurrenceChartSearch.kInitial)
                {
                    if (strTyp == CooccurrenceChartSearch.kS1)
                        this.SFeatures1 = this.SFeatures1.SetFeature(strContent, SyllographFeatures.SyllographType.Pri);
                    if (strTyp == CooccurrenceChartSearch.kS2)
                        this.SFeatures2 = this.SFeatures2.SetFeature(strContent, SyllographFeatures.SyllographType.Pri);
                }
                if (strTag == CooccurrenceChartSearch.kMedial)
                {
                    if (strTyp == CooccurrenceChartSearch.kS1)
                        this.SFeatures1 = this.SFeatures1.SetFeature(strContent, SyllographFeatures.SyllographType.Sec);
                    if (strTyp == CooccurrenceChartSearch.kS2)
                        this.SFeatures2 = this.SFeatures2.SetFeature(strContent, SyllographFeatures.SyllographType.Sec);
                }
                if (strTag == CooccurrenceChartSearch.kFinal)
                {
                    if (strTyp == CooccurrenceChartSearch.kS1)
                        this.SFeatures1 = this.SFeatures1.SetFeature(strContent, SyllographFeatures.SyllographType.Ter);
                    if (strTyp == CooccurrenceChartSearch.kS2)
                        this.SFeatures2 = this.SFeatures2.SetFeature(strContent, SyllographFeatures.SyllographType.Ter);
                }
			}

            this.SearchOptions = sd.MakeSearchOptions(so);
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

        public CooccurrenceChartSearch ExecuteCooccurChart(WordList wl)
        {
            this.SearchResults = "";
            CooccurrenceChartTable tbl = BuildCooccurTable(wl);
            this.Table = tbl;
            this.SearchResults += tbl.GetColumnHeaders();
            this.SearchResults += tbl.GetRows(m_Settings.LocalizationTable.GetMessage("CooccurrenceChartSearch1",
                m_Settings.OptionSettings.UILanguage));
            return this;
        }

        private CooccurrenceChartTable BuildCooccurTable(WordList wl)
        {
            Word wrd = null;
            CooccurrenceChartTable tbl = null;
            //FormProgressBar fpb = new FormProgressBar(CooccurrenceChartSearch.kSearch);
            FormProgressBar form = new FormProgressBar(m_Settings.LocalizationTable.GetMessage("CooccurrenceChartSearch1",
                m_Settings.OptionSettings.UILanguage));
            form.PB_Init(0, wl.WordCount());

            tbl = new CooccurrenceChartTable(this);
            for (int i = 0; i <wl.WordCount(); i++)
            {

                form.PB_Update(i);
                wrd = wl.GetWord(i);
                if (this.SearchOptions == null)
                    this.SearchOptions = new SearchOptions();
                if (this.SearchOptions.MatchesWord(wrd))
                {
                    Grapheme seg1 = null;
                    Grapheme seg2 = null;
                    int nRow = 0;
                    int nCol = 0;
                    for (int j = 0; j < wrd.GraphemeCount() - 1; j++)
                    {
                        seg1 = wrd.GetGraphemeWithoutTone(j);
                        seg2 = wrd.GetGraphemeWithoutTone(j + 1);
                        nRow = tbl.GetRowIndex(seg1.GetKey());
                        //nRow = tbl.GetRowIndex(seg1.Symbol);
                        nCol = tbl.GetColumnIndex(seg2.Symbol);
                        if ((nCol > 0) && (nRow >= 0))
                            tbl.UpdateChartCell(nRow, nCol, wrd); 
                    }
                }
            }
            form.Close();
            return tbl;
        }

        private SearchDefinition AddSearchParmForConsonantFeatures(SearchDefinition sd, ConsonantFeatures cf, string target)
		{
			SearchDefinitionParm sdp = null;
			string strTag = CooccurrenceChartSearch.kFeature;
			sdp = new SearchDefinitionParm(CooccurrenceChartSearch.kTarget, target);
			sd.AddSearchParm(sdp);

			if (cf.PointOfArticulation != "")
			{
				sdp = new SearchDefinitionParm(strTag, cf.PointOfArticulation);
				sd.AddSearchParm(sdp);
			}
			if (cf.MannerOfArticulation !=  "")
			{
				sdp = new SearchDefinitionParm(strTag, cf.MannerOfArticulation);
				sd.AddSearchParm(sdp);
			}
			if (cf.Voiced)
			{
				sdp = new SearchDefinitionParm(strTag, ConsonantFeatures.kVoiced);
				sd.AddSearchParm(sdp);
			}
			if (cf.Prenasalized)
			{
				sdp = new SearchDefinitionParm(strTag, ConsonantFeatures.kPrenasalized);
				sd.AddSearchParm(sdp);
			}
			if (cf.Labialized)
			{
				sdp = new SearchDefinitionParm(strTag, ConsonantFeatures.kLabialized);
				sd.AddSearchParm(sdp);
			}
			if (cf.Palatalized)
			{
				sdp = new SearchDefinitionParm(strTag, ConsonantFeatures.kPalatalized);
				sd.AddSearchParm(sdp);
			}
			if (cf.Velarized)
			{
				sdp = new SearchDefinitionParm(strTag, ConsonantFeatures.kVelarized);
				sd.AddSearchParm(sdp);
			}
			if (cf.Syllabic)
			{
				sdp = new SearchDefinitionParm(strTag, ConsonantFeatures.kSyllabic);
				sd.AddSearchParm(sdp);
			}
            if (cf.Aspirated)
            {
                sdp = new SearchDefinitionParm(strTag, ConsonantFeatures.kAspirated);
                sd.AddSearchParm(sdp);
            }
            if (cf.Long)
            {
                sdp = new SearchDefinitionParm(strTag, ConsonantFeatures.kLong);
                sd.AddSearchParm(sdp);
            }
            return sd;
		}

		private SearchDefinition AddSearchParmForVowelFeatures(SearchDefinition sd, VowelFeatures vf, string target)
		{
			SearchDefinitionParm sdp = null;
			string strTag = CooccurrenceChartSearch.kFeature;
			sdp = new SearchDefinitionParm(CooccurrenceChartSearch.kTarget, target);
			sd.AddSearchParm(sdp);

			if (vf.Backness != "")
			{
				sdp = new SearchDefinitionParm(strTag, vf.Backness);
				sd.AddSearchParm(sdp);
			}
			if (vf.Height !=  "")
			{
				sdp = new SearchDefinitionParm(strTag, vf.Height);
				sd.AddSearchParm(sdp);
			}
			if (vf.Round)
			{
				sdp = new SearchDefinitionParm(strTag, VowelFeatures.kRound);
				sd.AddSearchParm(sdp);
			}
			if (vf.PlusAtr)
			{
				sdp = new SearchDefinitionParm(strTag, VowelFeatures.kPlusAtr);
				sd.AddSearchParm(sdp);
			}
			if (vf.Long)
			{
				sdp = new SearchDefinitionParm(strTag, VowelFeatures.kLong);
				sd.AddSearchParm(sdp);
			}
			if (vf.Nasal)
			{
				sdp = new SearchDefinitionParm(strTag, VowelFeatures.kNasal);
				sd.AddSearchParm(sdp);
			}
            if (vf.Diphthong)
            {
                sdp = new SearchDefinitionParm(strTag, VowelFeatures.kDipthong);
                sd.AddSearchParm(sdp);
            }
            if (vf.Voiceless)
            {
                sdp = new SearchDefinitionParm(strTag, VowelFeatures.kVoiceless);
                sd.AddSearchParm(sdp);
            }
            return sd;
		}

        private SearchDefinition AddSearchParmForSyllographFeatures(SearchDefinition sd, SyllographFeatures sf, string target)
        {
            SearchDefinitionParm sdp = null;
            sdp = new SearchDefinitionParm(CooccurrenceChartSearch.kTarget, target);
            sd.AddSearchParm(sdp);

            if (sf != null)
            {
                if (sf.CategoryPrimary != "")
                {
                    sdp = new SearchDefinitionParm(CooccurrenceChartSearch.kInitial, sf.CategoryPrimary);
                    sd.AddSearchParm(sdp);
                }
                if (sf.CategorySecondary != "")
                {
                    sdp = new SearchDefinitionParm(CooccurrenceChartSearch.kMedial, sf.CategorySecondary);
                    sd.AddSearchParm(sdp);
                }
                if (sf.CategoryTertiary != "")
                {
                    sdp = new SearchDefinitionParm(CooccurrenceChartSearch.kFinal, sf.CategoryTertiary);
                    sd.AddSearchParm(sdp);
                }
            }
            return sd;
        }

        public bool IsConsonantCol()
		{
			bool flag = false;
			if ( this.CFeatures2 != null )
				flag = true;
			return flag;
		}

		public bool IsVowelCol()
		{
			bool flag = false;
			if ( this.VFeatures2 != null )
				flag = true;
			return flag;
		}

        public bool IsSyllographCol()
        {
            bool flag = false;
            if (this.SFeatures2 != null)
                flag = true;
            return flag;
        }

		public bool IsConsonantRow()
		{
			bool flag = false;
			if ( this.CFeatures1 != null )
				flag = true;
			return flag;
		}

		public bool IsVowelRow()
		{
			bool flag = false;
			if ( this.VFeatures1 != null )
				flag = true;
			return flag;
		}

        public bool IsSyllographRow()
        {
            bool flag = false;
            if (this.SFeatures1 != null)
                flag = true;
            return flag;
        }

	}
}

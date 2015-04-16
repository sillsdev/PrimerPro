using System;
using System.Windows.Forms;
using System.Data;
using System.Collections;
using PrimerProForms;
using PrimerProObjects;
using GenLib;

namespace PrimerProSearch
{
	/// <summary>
	/// 
	/// </summary>
	public class ContextChartSearch : Search
	{
        //Search parameters 
		private ConsonantFeatures m_CFeatures;
		private VowelFeatures m_VFeatures;
		private bool m_WordInit;
		private bool m_WordMedial;
		private bool m_WordFinal;
        private bool m_SyllableInit;
        private bool m_SyllableMedial;
        private bool m_SyllableFinal;
        private bool m_InitSyllable;
		private bool m_MedialSyllable;
		private bool m_FinalSyllable;
		private bool m_InRoots;
		private bool m_InAffixes;
		private bool m_OpenSyllables;
		private bool m_ClosedSyllables;
		private bool m_FirstRootC;
		private bool m_SecondRootC;
		private bool m_FirstRootV;
		private bool m_SecondRootV;
        private SearchOptions m_SearchOptions;
		
        private string m_Title;
        private Settings m_Settings;
        private ContextChartTable m_Table;
        private PSTable m_PSTable;
        private GraphemeInventory m_GI;

		//Search definition tags
        private const string kC	= "C";
		private const string kV = "V";
		private const string kTarget = "target";
		private const string kFeature = "feature";
		private const string kWordInit = "wordinit";
		private const string kWordMedial = "wordmedial";
		private const string kWordFinal = "wordfinal";
        private const string kSyllInit = "syllinit";
        private const string kSyllMedial = "syllmedial";
        private const string kSyllFinal = "syllfinal";
		private const string kInitSyllable = "initsyll";
		private const string kMedialSyllable = "medialsyll";
		private const string kFinalSyllable = "finalsyll";
		private const string kInRoots = "inroots";
		private const string kInAffixes = "inaffixes";
		private const string kOpenSyllables = "opensyll";
		private const string kClosedSyllables = "closesyll";
		private const string kFirstRootC = "firstrootc";
		private const string kSecondRootC = "secondrootc";
		private const string kFirstRootV = "firstrootv";
		private const string kSecondRootV = "secondrootv";
        
        //private const string kTitle = "Context Occurrence Chart";
        //private const string kSearch = "Processing Context Chart Search";

		public ContextChartSearch(int number, Settings s)
            : base(number, SearchDefinition.kContext)
		{
			m_CFeatures = null;
			m_VFeatures = null;
			m_SearchOptions = null;
			m_WordInit = false;
			m_WordMedial = false;
			m_WordFinal = false;
            m_SyllableInit = false;
            m_SyllableMedial = false;
            m_SyllableFinal = false;
			m_InitSyllable = false;
			m_MedialSyllable = false;
			m_FinalSyllable = false;
			m_InRoots = false;
			m_InAffixes = false;
			m_OpenSyllables = false;
			m_ClosedSyllables = false;
			m_FirstRootC = false;
			m_SecondRootC = false;
			m_FirstRootV = false;
			m_SecondRootV = false;
            m_SearchOptions = null;

            m_Settings = s;
            //m_Title = ContextChartSearch.kTitle;
            m_Title = m_Settings.LocalizationTable.GetMessage("ContextChartSearchT",
                m_Settings.OptionSettings.UILanguage);
            m_PSTable = m_Settings.PSTable;
            m_GI = m_Settings.GraphemeInventory;
        }

		public ConsonantFeatures CFeatures
		{
			get {return m_CFeatures;}
			set {m_CFeatures = value;}
		}

		public VowelFeatures VFeatures
		{
			get {return m_VFeatures;}
			set {m_VFeatures = value;}
		}

		public bool WordInit
		{
			get {return m_WordInit;}
			set {m_WordInit = value;}
		}

		public bool WordMedial
		{
			get {return m_WordMedial;}
			set {m_WordMedial = value;}
		}

		public bool WordFinal
		{
			get {return m_WordFinal;}
			set {m_WordFinal = value;}
		}

        public bool SyllableInit
        {
            get { return m_SyllableInit; }
            set { m_SyllableInit = value; }
        }

        public bool SyllableMedial
        {
            get { return m_SyllableMedial; }
            set { m_SyllableMedial = value; }
        }

        public bool SyllableFinal
        {
            get { return m_SyllableFinal; }
            set { m_SyllableFinal = value; }
        }

        public bool InitSyllable
		{
			get {return m_InitSyllable;}
			set {m_InitSyllable = value;}
		}

		public bool MedialSyllable
		{
			get {return m_MedialSyllable;}
			set {m_MedialSyllable = value;}
		}

		public bool FinalSyllable
		{
			get {return m_FinalSyllable;}
			set {m_FinalSyllable = value;}
		}

		public bool InRoots
		{
			get {return m_InRoots;}
			set {m_InRoots = value;}
		}

		public bool InAffixes
		{
			get {return m_InAffixes;}
			set {m_InAffixes = value;}
		}

		public bool OpenSyllables
		{
			get {return m_OpenSyllables;}
			set {m_OpenSyllables = value;}
		}

		public bool ClosedSyllables
		{
			get {return m_ClosedSyllables;}
			set {m_ClosedSyllables = value;}
		}

		public bool FirstRootC
		{
			get {return m_FirstRootC;}
			set {m_FirstRootC = value;}
		}

		public bool SecondRootC
		{
			get {return m_SecondRootC;}
			set {m_SecondRootC = value;}
		}

		public bool FirstRootV
		{
			get {return m_FirstRootV;}
			set {m_FirstRootV = value;}
		}

		public bool SecondRootV
		{
			get {return m_SecondRootV;}
			set {m_SecondRootV = value;}
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

        public PSTable PSTable
        {
            get { return m_PSTable; }
        }

        public GraphemeInventory GI
        {
            get { return m_GI; }
        }

        public ContextChartTable Table
        {
            get { return m_Table; }
            set { m_Table = value; }
        }

        public bool IsConsonantChart()
		{
			bool flag = false;
			if ( this.CFeatures != null )
				flag = true;
			return flag;
		}

		public bool IsVowelChart()
		{
			bool flag = false;
			if ( this.VFeatures != null )
				flag = true;
			return flag;
		}

		public bool SetupSearch()
		{
			bool flag = false;
            //FormContextChart fpb = new FormContextChart(this.PSTable);
            FormContextChart form = new FormContextChart(m_PSTable,
                m_Settings.LocalizationTable, m_Settings.OptionSettings.UILanguage);
			if (form.ShowDialog() == DialogResult.OK)
			{
                this.CFeatures = form.CnsFeatures;
                this.VFeatures = form.VwlFeatures;
                this.WordFinal = form.WordFinal;
                this.WordInit = form.WordInit;
                this.WordMedial = form.WordMedial;
                this.SyllableInit = form.SyllableInit;
                this.SyllableMedial = form.SyllableMedial;
                this.SyllableFinal = form.SyllableFinal;
                this.FinalSyllable = form.FinalSyllable;
                this.InitSyllable = form.InitSyllable;
                this.MedialSyllable = form.MedialSyllable;
                this.InRoots = form.InRoots;
                this.InAffixes = false;
                this.OpenSyllables = form.OpenSyllables;
                this.ClosedSyllables = form.ClosedSyllables;
                this.FirstRootC = form.FirstRootC;
                this.FirstRootV = form.FirstRootV;
                this.SecondRootC = form.SecondRootC;
                this.SecondRootV = form.SecondRootV;
                this.SearchOptions = form.SearchOptions;

				SearchDefinition sd = new SearchDefinition(SearchDefinition.kContext);
				SearchDefinitionParm sdp = null;
                this.SearchDefinition = sd;

				ConsonantFeatures cf = this.CFeatures;
				VowelFeatures vf = this.VFeatures;
                if ((this.CFeatures != null) || (this.VFeatures != null))
                {
                    if (this.CFeatures != null)
                        sd = AddSearchParmForConsonantFeatures(sd, this.CFeatures);
                    if (this.VFeatures != null)
                        sd = AddSearchParmForVowelFeatures(sd, this.VFeatures);
                    if (m_SearchOptions != null)
                        sd.AddSearchOptions(m_SearchOptions);

                    if (this.WordInit)
                    {
                        sdp = new SearchDefinitionParm(ContextChartSearch.kWordInit);
                        sd.AddSearchParm(sdp);
                    }
                    if (this.WordMedial)
                    {
                        sdp = new SearchDefinitionParm(ContextChartSearch.kWordMedial);
                        sd.AddSearchParm(sdp);
                    }
                    if (this.WordFinal)
                    {
                        sdp = new SearchDefinitionParm(ContextChartSearch.kWordFinal);
                        sd.AddSearchParm(sdp);
                    }
                    if (this.SyllableInit)
                    {
                        sdp = new SearchDefinitionParm(ContextChartSearch.kSyllInit);
                        sd.AddSearchParm(sdp);
                    }
                    if (this.SyllableMedial)
                    {
                        sdp = new SearchDefinitionParm(ContextChartSearch.kSyllMedial);
                        sd.AddSearchParm(sdp);
                    }
                    if (this.SyllableFinal)
                    {
                        sdp = new SearchDefinitionParm(ContextChartSearch.kSyllFinal);
                        sd.AddSearchParm(sdp);
                    }
                    if (this.InitSyllable)
                    {
                        sdp = new SearchDefinitionParm(ContextChartSearch.kInitSyllable);
                        sd.AddSearchParm(sdp);
                    }
                    if (this.MedialSyllable)
                    {
                        sdp = new SearchDefinitionParm(ContextChartSearch.kMedialSyllable);
                        sd.AddSearchParm(sdp);
                    }
                    if (this.FinalSyllable)
                    {
                        sdp = new SearchDefinitionParm(ContextChartSearch.kFinalSyllable);
                        sd.AddSearchParm(sdp);
                    }
                    if (this.InRoots)
                    {
                        sdp = new SearchDefinitionParm(ContextChartSearch.kInRoots);
                        sd.AddSearchParm(sdp);
                    }
                    if (this.InAffixes)
                    {
                        sdp = new SearchDefinitionParm(ContextChartSearch.kInAffixes);
                        sd.AddSearchParm(sdp);
                    }
                    if (this.OpenSyllables)
                    {
                        sdp = new SearchDefinitionParm(ContextChartSearch.kOpenSyllables);
                        sd.AddSearchParm(sdp);
                    }
                    if (this.ClosedSyllables)
                    {
                        sdp = new SearchDefinitionParm(ContextChartSearch.kClosedSyllables);
                        sd.AddSearchParm(sdp);
                    }
                    if (this.FirstRootC)
                    {
                        sdp = new SearchDefinitionParm(ContextChartSearch.kFirstRootC);
                        sd.AddSearchParm(sdp);
                    }
                    if (this.SecondRootC)
                    {
                        sdp = new SearchDefinitionParm(ContextChartSearch.kSecondRootC);
                        sd.AddSearchParm(sdp);
                    }
                    if (this.FirstRootV)
                    {
                        sdp = new SearchDefinitionParm(ContextChartSearch.kFirstRootV);
                        sd.AddSearchParm(sdp);
                    }
                    if (this.SecondRootV)
                    {
                        sdp = new SearchDefinitionParm(ContextChartSearch.kSecondRootV);
                        sd.AddSearchParm(sdp);
                    }
                    if (m_SearchOptions != null)
                        sd.AddSearchOptions(m_SearchOptions);
                    this.SearchDefinition = sd;
                    flag = true;
                }
                //else MessageBox.Show("Consonant or Vowel not specified");
                else
                {
                    string strMsg = m_Settings.LocalizationTable.GetMessage("ContextChartSearch2",
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
				if (strTag == ContextChartSearch.kTarget)
				{
					if ( strContent == ContextChartSearch.kC)
						this.CFeatures = new ConsonantFeatures();
					if (strContent == ContextChartSearch.kV)
						this.VFeatures = new VowelFeatures();
					strTyp = strContent;
				}
				if (strTag == ContextChartSearch.kFeature)
				{
					if (strTyp == ContextChartSearch.kC)
						this.CFeatures = this.CFeatures.SetFeature(strContent);
					if (strTyp == ContextChartSearch.kV)
						this.VFeatures = this.VFeatures.SetFeature(strContent);
				}
				if (strTag == ContextChartSearch.kWordInit)
					this.WordInit = true;
				if (strTag == ContextChartSearch.kWordMedial)
					this.WordMedial = true;
				if (strTag == ContextChartSearch.kWordFinal)
					this.WordFinal = true;
                if (strTag == ContextChartSearch.kSyllInit)
                    this.SyllableInit = true;
                if (strTag == ContextChartSearch.kSyllMedial)
                    this.SyllableMedial = true;
                if (strTag == ContextChartSearch.kSyllFinal)
                    this.SyllableFinal = true;
                if (strTag == ContextChartSearch.kInitSyllable)
					this.InitSyllable = true;
				if (strTag == ContextChartSearch.kMedialSyllable)
					this.MedialSyllable = true;
				if (strTag == ContextChartSearch.kFinalSyllable)
					this.FinalSyllable = true;
				if (strTag == ContextChartSearch.kInRoots)
					this.InRoots = true;
				if (strTag == ContextChartSearch.kInAffixes)
					this.InAffixes = true;
				if (strTag == ContextChartSearch.kOpenSyllables)
					this.OpenSyllables = true;
				if (strTag == ContextChartSearch.kClosedSyllables)
					this.ClosedSyllables = true;
				if (strTag == ContextChartSearch.kFirstRootC)
					this.FirstRootC = true;
				if (strTag == ContextChartSearch.kSecondRootC)
					this.SecondRootC = true;
				if (strTag == ContextChartSearch.kFirstRootV)
					this.FirstRootV = true;
				if (strTag == ContextChartSearch.kSecondRootV)
					this.SecondRootV = true;
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

        public ContextChartSearch ExecuteContextChart(WordList wl)
        {
            this.SearchResults = "";
            ContextChartTable tbl = BuildContextTable(wl);
            this.Table = tbl;
            this.SearchResults += tbl.GetColumnHeaders();
            this.SearchResults += tbl.GetRows();
            return this;
        }

        private ContextChartTable BuildContextTable(WordList wl)
        {
            Word wrd = null;
            ContextChartTable tbl = null;
            DataRow dr = null;
            string strSym = "";
            int nCol = 0;
            //FormProgressBar fpb = new FormProgressBar(ContextChartSearch.kSearch);
            FormProgressBar form = new FormProgressBar(m_Settings.LocalizationTable.GetMessage("ContextChartSearch1",
                m_Settings.OptionSettings.UILanguage));
            form.PB_Init(0, wl.WordCount());

            tbl = new ContextChartTable(this);
            for (int i = 0; i < wl.WordCount(); i++)
            {
                form.PB_Update(i);
                wrd = wl.GetWord(i);
                if (this.SearchOptions == null)
                    this.SearchOptions = new SearchOptions();
                if (this.SearchOptions.MatchesWord(wrd))
                {
                    for (int nRow = 0; nRow < tbl.Rows.Count; nRow++)
                    {
                        dr = tbl.GetDataRow(nRow);
                        strSym = dr[tbl.GetID()].ToString();
                        if (wrd.IsInitialGrapheme(strSym))
                        {
                            nCol = tbl.Columns.IndexOf(ContextChartTable.kWordInit);
                            if (nCol > 0)
                                //tbl.IncrChartCell(nRow, nCol);
                                tbl.UpdateChartCell(nRow, nCol, wrd);
                        }
                        if (wrd.IsMedialGrapheme(strSym))
                        {
                            nCol = tbl.Columns.IndexOf(ContextChartTable.kWordMedial);
                            if (nCol > 0)
                                //tbl.IncrChartCell(nRow, nCol);
                                tbl.UpdateChartCell(nRow, nCol, wrd);
                        }
                        if (wrd.IsFinalGrapheme(strSym))
                        {
                            nCol = tbl.Columns.IndexOf(ContextChartTable.kWordFinal);
                            if (nCol > 0)
                                //tbl.IncrChartCell(nRow, nCol);
                                tbl.UpdateChartCell(nRow, nCol, wrd);
                        }
                        if (wrd.IsSyllableInit(strSym))
                        {
                            nCol = tbl.Columns.IndexOf(ContextChartTable.kSyllInit);
                            if (nCol > 0)
                                //tbl.IncrChartCell(nRow, nCol);
                                tbl.UpdateChartCell(nRow, nCol, wrd);
                        }
                        if (wrd.IsSyllableMedial(strSym))
                        {
                            nCol = tbl.Columns.IndexOf(ContextChartTable.kSyllMedial);
                            if (nCol > 0)
                                //tbl.IncrChartCell(nRow, nCol);
                                tbl.UpdateChartCell(nRow, nCol, wrd);
                        }
                        if (wrd.IsSyllableFinal(strSym))
                        {
                            nCol = tbl.Columns.IndexOf(ContextChartTable.kSyllFinal);
                            if (nCol > 0)
                                //tbl.IncrChartCell(nRow, nCol);
                                tbl.UpdateChartCell(nRow, nCol, wrd);
                        }
                        if (wrd.IsInInitialSyllable(strSym))
                        {
                            nCol = tbl.Columns.IndexOf(ContextChartTable.kInitSyll);
                            if (nCol > 0)
                                //tbl.IncrChartCell(nRow, nCol);
                                tbl.UpdateChartCell(nRow, nCol, wrd);
                        }
                        if (wrd.IsInMedialSyllable(strSym))
                        {
                            nCol = tbl.Columns.IndexOf(ContextChartTable.kMedialSyll);
                            if (nCol > 0)
                                //tbl.IncrChartCell(nRow, nCol);
                                tbl.UpdateChartCell(nRow, nCol, wrd);
                        }
                        if (wrd.IsInFinalSyllable(strSym))
                        {
                            nCol = tbl.Columns.IndexOf(ContextChartTable.kFinalSyll);
                            if (nCol > 0)
                                //tbl.IncrChartCell(nRow, nCol);
                                tbl.UpdateChartCell(nRow, nCol, wrd);
                        }
                        if ((wrd.Root != null) && (wrd.Root.IsInRoot(strSym)))
                        {
                            nCol = tbl.Columns.IndexOf(ContextChartTable.kInRoots);
                            if (nCol > 0)
                                //tbl.IncrChartCell(nRow, nCol);
                                tbl.UpdateChartCell(nRow, nCol, wrd);
                        }
                        if (wrd.IsInOpenSyllable(strSym))
                        {
                            nCol = tbl.Columns.IndexOf(ContextChartTable.kOpenSyll);
                            if (nCol > 0)
                                //tbl.IncrChartCell(nRow, nCol);
                                tbl.UpdateChartCell(nRow, nCol, wrd);
                        }
                        if (wrd.IsInClosedSyllable(strSym))
                        {
                            nCol = tbl.Columns.IndexOf(ContextChartTable.kClosdSyll);
                            if (nCol > 0)
                                //tbl.IncrChartCell(nRow, nCol);
                                tbl.UpdateChartCell(nRow, nCol, wrd);
                        }
                        if ((wrd.Root != null) && (wrd.Root.IsFirstRootC(strSym)))
                        {
                            nCol = tbl.Columns.IndexOf(ContextChartTable.kFirstRootC);
                            if (nCol > 0)
                                //tbl.IncrChartCell(nRow, nCol);
                                tbl.UpdateChartCell(nRow, nCol, wrd);
                        }
                        if ((wrd.Root != null) && (wrd.Root.IsFirstRootV(strSym)))
                        {
                            nCol = tbl.Columns.IndexOf(ContextChartTable.kFirstRootV);
                            if (nCol > 0)
                                //tbl.IncrChartCell(nRow, nCol);
                                tbl.UpdateChartCell(nRow, nCol, wrd);
                        }
                        if ((wrd.Root != null) && (wrd.Root.IsSecondRootC(strSym)))
                        {
                            nCol = tbl.Columns.IndexOf(ContextChartTable.kSecndRootC);
                            if (nCol > 0)
                                //tbl.IncrChartCell(nRow, nCol);
                                tbl.UpdateChartCell(nRow, nCol, wrd);
                        }
                        if ((wrd.Root != null) && (wrd.Root.IsSecondRootV(strSym)))
                        {
                            nCol = tbl.Columns.IndexOf(ContextChartTable.kSecndRootV);
                            if (nCol > 0)
                                //tbl.IncrChartCell(nRow, nCol);
                                tbl.UpdateChartCell(nRow, nCol, wrd);
                        }
                    }
                }
            }
            form.Close();
            return tbl;
        }

        private SearchDefinition AddSearchParmForConsonantFeatures(SearchDefinition sd, ConsonantFeatures cf)
		{
			SearchDefinitionParm sdp = null;
			string strTag = ContextChartSearch.kFeature;
			sdp = new SearchDefinitionParm(ContextChartSearch.kTarget, ContextChartSearch.kC);
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

		private SearchDefinition AddSearchParmForVowelFeatures(SearchDefinition sd, VowelFeatures vf)
		{
			SearchDefinitionParm sdp = null;
			string strTag = ContextChartSearch.kFeature;
			sdp = new SearchDefinitionParm(ContextChartSearch.kTarget, ContextChartSearch.kV);
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

		public ArrayList ChartColumnIds()
		{
			ArrayList al = new ArrayList();
			if (this.WordInit)
				al.Add(ContextChartSearch.kWordInit);
			if (this.WordMedial)
				al.Add(ContextChartSearch.kWordMedial);
			if (this.WordFinal)
				al.Add(ContextChartSearch.kWordFinal);
			if (this.InitSyllable)
				al.Add(ContextChartSearch.kInitSyllable);
			if (this.MedialSyllable)
				al.Add(ContextChartSearch.kMedialSyllable);
			if (this.FinalSyllable)
				al.Add(ContextChartSearch.kFinalSyllable);
			if (this.InRoots)
				al.Add(ContextChartSearch.kInRoots);
			if (this.InAffixes)
				al.Add(ContextChartSearch.kInAffixes);
			if (this.OpenSyllables)
				al.Add(ContextChartSearch.kOpenSyllables);
			if (this.ClosedSyllables)
				al.Add(ContextChartSearch.kClosedSyllables);
			if (this.FirstRootC)
				al.Add(ContextChartSearch.kFirstRootC);
			if (this.SecondRootC)
				al.Add(ContextChartSearch.kSecondRootC);
			if (this.FirstRootV)
				al.Add(ContextChartSearch.kFirstRootV);
			if (this.SecondRootV)
				al.Add(ContextChartSearch.kSecondRootV);
			return al;
		}

		public ArrayList ChartRowIds()
		{
			ArrayList al = new ArrayList();
			if (this.IsConsonantChart())
			{
				ConsonantFeatures cf = this.CFeatures;
			}
			if (this.IsVowelChart())
			{
				VowelFeatures vf = this.VFeatures;
			}
			return al;
		}

	}
}

using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using PrimerProForms;
using PrimerProObjects;
using GenLib;

namespace PrimerProSearch
{
	/// <summary>
	/// 
	/// </summary>
	public class AdvancedSearch : Search
	{
        //Search parameters 
        private string m_Sequence1Grf;
		private ConsonantFeatures m_Sequence1Cns;
		private VowelFeatures m_Sequence1Vwl;
        private string m_Sequence2Grf;
		private ConsonantFeatures m_Sequence2Cns;
		private VowelFeatures m_Sequence2Vwl;
        private string m_Sequence3Grf;
		private ConsonantFeatures m_Sequence3Cns;
		private VowelFeatures m_Sequence3Vwl;
        private string m_Sequence4Grf;
		private ConsonantFeatures m_Sequence4Cns;
		private VowelFeatures m_Sequence4Vwl;
        private bool m_UseGraphemeTaughts;
        private bool m_BrowseView;
		private SearchOptions m_SearchOptions;

        private string m_Title;
        private Settings m_Settings;
        private PSTable m_PSTable;
        private GraphemeInventory m_GI;
        private GraphemeTaughtOrder m_GTO;
        private Font m_DefaultFont;             //Default Font
        private Color m_HighlightColor;         //Highlight Color
        
        // Search Definition Tags
		private const string kTarget = "target";
		private const string kFeature = "feature";
		private const string kC	= "_C";
		private const string kV = "_V";
        private const string kGraphemesTaught = "UseGrapemesTaught";
        private const string kBrowseView = "BrowseView";

        //private const string kTitle = "Advanced Grapheme Search";

		public AdvancedSearch(int number, Settings s)
            : base(number, SearchDefinition.kAdvanced)
		{
            m_Sequence1Grf = "";
			m_Sequence1Cns = null;
			m_Sequence1Vwl = null;
            m_Sequence2Grf = "";
			m_Sequence2Cns = null;
			m_Sequence2Vwl = null;
            m_Sequence3Grf = "";
			m_Sequence3Cns = null;
			m_Sequence3Vwl = null;
            m_Sequence4Grf = "";
			m_Sequence4Cns = null;
			m_Sequence4Vwl = null;
			m_SearchOptions = null;

            m_Settings = s;
            //m_Title = AdvancedSearch.kTitle;
            m_Title = m_Settings.LocalizationTable.GetMessage("AdvancedSearchT");
            if (m_Title == "")
                m_Title = "Advanced Grapheme Search";
            m_PSTable = m_Settings.PSTable;
            m_GI = m_Settings.GraphemeInventory;
            m_GTO = m_Settings.GraphemesTaught;
            m_DefaultFont = m_Settings.OptionSettings.GetDefaultFont();
            m_HighlightColor = m_Settings.OptionSettings.HighlightColor;
        }

        public bool UseGraphemesTaught
        {
            get { return m_UseGraphemeTaughts; }
            set { m_UseGraphemeTaughts = value; }
        }

        public bool BrowseView
        {
            get { return m_BrowseView; }
            set { m_BrowseView = value; }
        }

        public string Sequence1Grf
		{
			get {return m_Sequence1Grf;}
			set {m_Sequence1Grf = value;}
		}

		public ConsonantFeatures Sequence1Cns
		{
			get {return m_Sequence1Cns;}
			set {m_Sequence1Cns = value;}
		}

		public VowelFeatures Sequence1Vwl
		{
			get {return m_Sequence1Vwl;}
			set {m_Sequence1Vwl = value;}
		}

		public string Sequence2Grf
		{
			get {return m_Sequence2Grf;}
			set {m_Sequence2Grf = value;}
		}

		public ConsonantFeatures Sequence2Cns
		{
			get {return m_Sequence2Cns;}
			set {m_Sequence2Cns = value;}
		}

		public VowelFeatures Sequence2Vwl
		{
			get {return m_Sequence2Vwl;}
			set {m_Sequence2Vwl = value;}
		}

		public string Sequence3Grf
		{
			get {return m_Sequence3Grf;}
			set {m_Sequence3Grf = value;}
		}

		public ConsonantFeatures Sequence3Cns
		{
			get {return m_Sequence3Cns;}
			set {m_Sequence3Cns = value;}
		}

		public VowelFeatures Sequence3Vwl
		{
			get {return m_Sequence3Vwl;}
			set {m_Sequence3Vwl = value;}
		}

		public string Sequence4Grf
		{
			get {return m_Sequence4Grf;}
			set {m_Sequence4Grf = value;}
		}

		public ConsonantFeatures Sequence4Cns
		{
			get {return m_Sequence4Cns;}
			set {m_Sequence4Cns = value;}
		}

		public VowelFeatures Sequence4Vwl
		{
			get {return m_Sequence4Vwl;}
			set {m_Sequence4Vwl = value;}
		}

		public SearchOptions SearchOptions
		{
			get {return m_SearchOptions;}
			set {m_SearchOptions = value;}
		}

		public string Title
		{
			get {return m_Title;}
			set {m_Title = value;}
		}

		public PSTable PSTable
		{
			get {return m_PSTable;}
		}

        public GraphemeInventory GI
        {
            get { return m_GI; }
        }

        public GraphemeTaughtOrder GTO
        {
            get { return m_GTO; }
        }

        public int GetSequenceLength()
		{
			int n = 0;
			if ( (this.Sequence1Grf == "") && (this.Sequence1Cns == null)
				&& (this.Sequence1Vwl == null) )
			{
				n = 0;
			}
			else if ( (this.Sequence2Grf == "") && (this.Sequence2Cns == null)
				&& (this.Sequence2Vwl == null) )
			{
				n = 1;
			}
			else if ( (this.Sequence3Grf == "") && (this.Sequence3Cns == null)
				&& (this.Sequence3Vwl == null) )
			{
				n = 2;
			}
			else if ( (this.Sequence4Grf == "") && (this.Sequence4Cns == null)
				&& (this.Sequence4Vwl == null) )
			{
				n = 3;
			}
			else n = 4;
			return n;
		}

		public bool SetupSearch()
		{
			bool flag = false;
            //FormAdvanced fpb = new FormAdvanced(m_GI, m_PSTable, m_PSTable, m_DefaultFont);
 			FormAdvanced form = new FormAdvanced(m_GI, m_PSTable, m_DefaultFont, m_Settings.LocalizationTable);
			DialogResult dr;
			dr = form.ShowDialog();
			if (dr == DialogResult.OK)
			{
                this.Sequence1Cns = form.Sequence1CnsFeatures;
                this.Sequence1Grf = form.Sequence1Grapheme;
                this.Sequence1Vwl = form.Sequence1VwlFeatures;
                this.Sequence2Cns = form.Sequence2CnsFeatures;
                this.Sequence2Grf = form.Sequence2Grapheme;
                this.Sequence2Vwl = form.Sequence2VwlFeatures;
                this.Sequence3Cns = form.Sequence3CnsFeatures;
                this.Sequence3Grf = form.Sequence3Grapheme;
                this.Sequence3Vwl = form.Sequence3VwlFeatures;
                this.Sequence4Cns = form.Sequence4CnsFeatures;
                this.Sequence4Grf = form.Sequence4Grapheme;
                this.Sequence4Vwl = form.Sequence4VwlFeatures;
                this.UseGraphemesTaught = form.UseGraphemesTaught;
                this.BrowseView = form.BrowseView;
                this.SearchOptions = form.SearchOptions;

                if ((this.Sequence1Grf != "") || (this.Sequence1Cns != null)
                    || (this.Sequence1Vwl != null))
                {
                    SearchDefinition sd = new SearchDefinition(SearchDefinition.kAdvanced);
                    SearchDefinitionParm sdp = null;
                    this.SearchDefinition = sd;

                    if (this.Sequence1Grf != "")
                    {
                        sdp = new SearchDefinitionParm(AdvancedSearch.kTarget, this.Sequence1Grf);
                        sd.AddSearchParm(sdp);
                    }
                    else if (this.Sequence1Cns != null)
                    {
                        sd = AddSearchParmForConsonantFeatures(sd, Sequence1Cns);
                    }
                    else if (this.Sequence1Vwl != null)
                    {
                        sd = AddSearchParmForVowelFeatures(sd, Sequence1Vwl);
                    }

                    if (this.Sequence2Grf != "")
                    {
                        sdp = new SearchDefinitionParm(AdvancedSearch.kTarget, this.Sequence2Grf);
                        sd.AddSearchParm(sdp);
                    }
                    else if (this.Sequence2Cns != null)
                    {
                        sd = AddSearchParmForConsonantFeatures(sd, Sequence2Cns);
                    }
                    else if (this.Sequence2Vwl != null)
                    {
                        sd = AddSearchParmForVowelFeatures(sd, Sequence2Vwl);
                    }

                    if (this.Sequence3Grf != "")
                    {
                        sdp = new SearchDefinitionParm(AdvancedSearch.kTarget, this.Sequence3Grf);
                        sd.AddSearchParm(sdp);
                    }
                    else if (this.Sequence3Cns != null)
                    {
                        sd = AddSearchParmForConsonantFeatures(sd, Sequence3Cns);
                    }
                    else if (this.Sequence3Vwl != null)
                    {
                        sd = AddSearchParmForVowelFeatures(sd, Sequence3Vwl);
                    }

                    if (this.Sequence4Grf != "")
                    {
                        sdp = new SearchDefinitionParm(AdvancedSearch.kTarget, this.Sequence4Grf);
                        sd.AddSearchParm(sdp);
                    }
                    else if (this.Sequence4Cns != null)
                    {
                        sd = AddSearchParmForConsonantFeatures(sd, Sequence4Cns);
                    }
                    else if (this.Sequence4Vwl != null)
                    {
                        sd = AddSearchParmForVowelFeatures(sd, Sequence4Vwl);
                    }

                    if (this.UseGraphemesTaught)
                    {
                        sdp = new SearchDefinitionParm(AdvancedSearch.kGraphemesTaught);
                        sd.AddSearchParm(sdp);
                    }

                    if (this.BrowseView)
                    {
                        sdp = new SearchDefinitionParm(AdvancedSearch.kBrowseView);
                        sd.AddSearchParm(sdp);
                    }

                    if (m_SearchOptions != null)
                        sd.AddSearchOptions(m_SearchOptions);
                    this.SearchDefinition = sd;
                    flag = true;
                }
                //else MessageBox.Show("Grapheme not specified");
                else
                {
                    string strMsg = m_Settings.LocalizationTable.GetMessage("AdvancedSearch1");
                    if (strMsg == "")
                        strMsg = "Grapheme not specified";
                    MessageBox.Show(strMsg);
                }
			}
			return flag;
		}

		public bool SetupSearch(SearchDefinition sd)
		{
			bool flag = true;
			SearchOptions so = new SearchOptions(m_PSTable);
			SearchDefinitionParm sdp = null;
			string strTag = "";
			string strContent = "";
			char chType = ' ';		// Grapheme/Consonant/Vowel 
			int nSequence = 0;		// Sequence number

			this.SearchDefinition = sd;
			for (int i = 0; i < sd.SearchParmsCount(); i++)
			{
				sdp = sd.GetSearchParmAt(i);
				strTag = sdp.GetTag();
				strContent = sdp.GetContent();

				if (strTag == AdvancedSearch.kTarget)
				{
					nSequence++;
					switch (strContent)
					{
                        case AdvancedSearch.kGraphemesTaught:
                            this.UseGraphemesTaught = false;
                            this.BrowseView = false;
                            break;
						case AdvancedSearch.kC:
							chType = 'C';
							switch (nSequence)
							{
								case 1:
									this.Sequence1Cns = new ConsonantFeatures();
									break;
								case 2:
									this.Sequence2Cns = new ConsonantFeatures();
									break;
								case 3:
									this.Sequence3Cns = new ConsonantFeatures();
									break;
								case 4:
									this.Sequence4Cns = new ConsonantFeatures();
									break;
								default:
									break;
							}
							break;
						case AdvancedSearch.kV:
							chType = 'V';
							switch (nSequence)
							{
								case 1:
									this.Sequence1Vwl = new VowelFeatures();
									break;
								case 2:
									this.Sequence2Vwl = new VowelFeatures();
									break;
								case 3:
									this.Sequence3Vwl = new VowelFeatures();
									break;
								case 4:
									this.Sequence4Vwl = new VowelFeatures();
									break;
								default:
									break;
							}
							break;
						default:
							chType = ' ';
							switch (nSequence)
							{
								case 1:
									this.Sequence1Grf = strContent;
									break;
								case 2:
									this.Sequence2Grf = strContent;
									break;
								case 3:
									this.Sequence3Grf = strContent;
									break;
								case 4:
									this.Sequence4Grf = strContent;
									break;
								default:
									break;
							}
							break;
					}
				}

				if (strTag == AdvancedSearch.kFeature)
				{
					switch (chType)
					{
						case 'C':
							SetConsonantFeature(nSequence, strContent);
							break;
						case 'V':
							SetVowelFeature(nSequence, strContent);
							break;
						default:
							break;
					}
				}
			}

            this.SearchOptions = sd.MakeSearchOptions(so);
            this.SearchDefinition = sd;
			return flag;
		}

		public string BuildResults()
		{
			string strText = "";
            string str = "";
			string strSN = Search.TagSN + this.SearchNumber.ToString().Trim();
			strText += Search.TagOpener + strSN	+ Search.TagCloser + Environment.NewLine;
			strText += this.Title + Environment.NewLine + Environment.NewLine;
			strText += this.SearchResults;
			strText += Environment.NewLine;
            //strText += this.SearchCount.ToString() + " entries found" + Environment.NewLine;
            str = m_Settings.LocalizationTable.GetMessage("Search2");
            if (str == "")
                str = "entries found";
            strText += this.SearchCount.ToString() + Constants.Space + str + Environment.NewLine;
			strText += Search.TagOpener + Search.TagForwardSlash + strSN
				+ Search.TagCloser;
			return strText;
		}

        public AdvancedSearch ExecuteAdvancedSearch(WordList wl)
        {
            bool fUseGraphemesTaught = this.UseGraphemesTaught;
            ArrayList alGTO = new ArrayList();
            if (this.GTO != null)
                alGTO = this.GTO.Graphemes;
            SearchOptions so = this.SearchOptions;
            int nCount = 0;
            string strResult = wl.GetDisplayHeadings() + Environment.NewLine;

            Word wrd = null;
            int nWord = wl.WordCount();
            for (int i = 0; i < nWord; i++)
            {
                wrd = wl.GetWord(i);

                if (so == null)
                {
                    if (fUseGraphemesTaught)
                    {
                        if (this.MatchesWord(wrd) && wrd.IsBuildableWord(alGTO))
                        {
                            nCount++;
                            strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
                        }
                    }
                    else
                    {
                        if (this.MatchesWord(wrd))
                        {
                            nCount++;
                            strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
                        }
                    }
                }
                else
                {
                    if (so.MatchesWord(wrd))
                    {
                        if (so.IsRootOnly)
                        {
                            if (this.MatchesRoot(wrd))
                            {
                                nCount++;
                                strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
                            }
                        }
                        else
                        {
                            if (fUseGraphemesTaught)
                            {
                                if (this.MatchesWord(wrd) && wrd.IsBuildableWord(alGTO))
                                {
                                    nCount++;
                                    strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
                                }
                            }
                            else
                            {
                                if (this.MatchesWord(wrd))
                                {
                                    nCount++;
                                    strResult += wl.GetDisplayLineForWord(i) + Environment.NewLine;
                                }
                            }
                        }
                    }
                }
            }
            if (nCount > 0)
            {
                this.SearchResults = strResult;
                this.SearchCount = nCount;
            }
            else
            {
                //this.SearchResults = "***No Results***";
                this.SearchResults = m_Settings.LocalizationTable.GetMessage("Search1");
                if (this.SearchResults == "")
                    this.SearchResults = "***No Results***";
                this.SearchCount = 0;
            }
            return this;
        }

        public AdvancedSearch BrowseAdvancedSearch(WordList wl)
        {
            string str = "";
            bool fUseGraphemesTaught = this.UseGraphemesTaught;
            int nCount = 0;
            ArrayList al = null;
            Color clr = m_HighlightColor;
            Font fnt = m_DefaultFont;
            Word wrd = null;
            ArrayList alGTO = new ArrayList();
            if (this.GTO != null)
                alGTO = this.GTO.Graphemes;
            SearchOptions so = this.SearchOptions;
            FormBrowse form = new FormBrowse();
            //form.Text = m_Title + " - Browse View";
            str = m_Settings.LocalizationTable.GetMessage("SearchB");
            if (str == "")
                str = "Browse View";
            form.Text = m_Title + " - " + str;
            al = wl.GetDisplayHeadingsAsArray();
            form.AddColHeaders(al, clr, fnt);

            for (int i = 0; i < wl.WordCount(); i++)
            {
                wrd = wl.GetWord(i);
                if (so == null)
                {
                    if (fUseGraphemesTaught)
                    {
                        if ((this.MatchesWord(wrd)) && (wrd.IsBuildableWord(alGTO)))
                        {
                            nCount++;
                            al = wrd.GetWordInfoAsArray();
                            form.AddRow(al);
                        }
                    }
                    else
                    {
                        if (this.MatchesWord(wrd))
                        {
                            nCount++;
                            al = wrd.GetWordInfoAsArray();
                            form.AddRow(al);
                        }
                    }
                }
                else
                {
                    so = this.SearchDefinition.MakeSearchOptions(so);
                    if (so.MatchesWord(wrd))
                    {
                        if (so.IsRootOnly)
                        {
                            if (fUseGraphemesTaught)
                            {
                                if ((this.MatchesRoot(wrd)) && (wrd.IsBuildableWord(alGTO)))
                                {
                                    nCount++;
                                    al = wrd.GetWordInfoAsArray();
                                    form.AddRow(al);
                                }
                            }
                            else
                            {
                                if (this.MatchesRoot(wrd))
                                {
                                    nCount++;
                                    al = wrd.GetWordInfoAsArray();
                                    form.AddRow(al);
                                }
                            }
                        }
                        else
                        {
                            if (fUseGraphemesTaught)
                            {
                                if ((this.MatchesWord(wrd)) && (wrd.IsBuildableWord(alGTO)))
                                {
                                    nCount++;
                                    al = wrd.GetWordInfoAsArray();
                                    form.AddRow(al);
                                }
                            }
                            else
                            {
                                if (this.MatchesWord(wrd))
                                {
                                    nCount++;
                                    al = wrd.GetWordInfoAsArray();
                                    form.AddRow(al);
                                }
                            }
                        }
                    }
                }
            }
            //form.Text += " - " + nCount.ToString() + " entries";
            str = m_Settings.LocalizationTable.GetMessage("Search3");
            if (str == "")
                str = "entries";
            form.Text += " - " + nCount.ToString() + Constants.Space + str;
            form.Show();
            return this;
        }

        private SearchDefinition AddSearchParmForConsonantFeatures(SearchDefinition sd, ConsonantFeatures cf)
		{
			SearchDefinitionParm sdp = null;
			string strTag = AdvancedSearch.kFeature;
			sdp = new SearchDefinitionParm(AdvancedSearch.kTarget, AdvancedSearch.kC);
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
            if (cf.Glottalized)
            {
                sdp = new SearchDefinitionParm(strTag, ConsonantFeatures.kGlottalized);
                sd.AddSearchParm(sdp);
            }
            if (cf.Combination)
            {
                sdp = new SearchDefinitionParm(strTag, ConsonantFeatures.kCombination);
                sd.AddSearchParm(sdp);
            }
			return sd;
		}

		private SearchDefinition AddSearchParmForVowelFeatures(SearchDefinition sd, VowelFeatures vf)
		{
			SearchDefinitionParm sdp = null;
			string strTag = AdvancedSearch.kFeature;
			sdp = new SearchDefinitionParm(AdvancedSearch.kTarget, AdvancedSearch.kV);
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
			return sd;
		}

		private void SetConsonantFeature(int nSequence, string strFeature)
		{
			switch (nSequence)
			{
				case 1:
					if (strFeature == ConsonantFeatures.kBilabial)
					{
						this.Sequence1Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kLabiodental)
					{
						this.Sequence1Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kDental)
					{
						this.Sequence1Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kAlveolar)
					{
						this.Sequence1Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kPostalveolar)
					{
						this.Sequence1Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kRetroflex)
					{
						this.Sequence1Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kPalatal)
					{
						this.Sequence1Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kVelar)
					{
						this.Sequence1Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kLabialvelar)
					{
						this.Sequence1Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kUvular)
					{
						this.Sequence1Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kPharyngeal)
					{
						this.Sequence1Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kGlottal)
					{
						this.Sequence1Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kPlosive)
					{
						this.Sequence1Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kNasal)
					{
						this.Sequence1Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kTrill)
					{
						this.Sequence1Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kFlap)
					{
						this.Sequence1Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kFricative)
					{
						this.Sequence1Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kAffricate)
					{
						this.Sequence1Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kLateralFricative)
					{
						this.Sequence1Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kLateralApproximant)
					{
						this.Sequence1Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kApproximant)
					{
						this.Sequence1Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kImplosive)
					{
						this.Sequence1Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kEjective)
					{
						this.Sequence1Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kClick)
					{
						this.Sequence1Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kVoiced)
					{
						this.Sequence1Cns.Voiced = true;
					}
					else if (strFeature == ConsonantFeatures.kPrenasalized)
					{
						this.Sequence1Cns.Prenasalized = true;
					}
					else if (strFeature == ConsonantFeatures.kLabialized)
					{
						this.Sequence1Cns.Labialized = true;
					}
					else if (strFeature == ConsonantFeatures.kPalatalized)
					{
						this.Sequence1Cns.Palatalized = true;
					}
					else if (strFeature == ConsonantFeatures.kVelarized)
					{
						this.Sequence1Cns.Velarized = true;
					}
					else if (strFeature == ConsonantFeatures.kSyllabic)
					{
						this.Sequence1Cns.Syllabic = true;
					}
                    else if (strFeature == ConsonantFeatures.kAspirated)
                    {
                        this.Sequence1Cns.Aspirated = true;
                    }
                    else if (strFeature == ConsonantFeatures.kLong)
                    {
                        this.Sequence1Cns.Long = true;
                    }
                    else if (strFeature == ConsonantFeatures.kGlottalized)
                    {
                        this.Sequence1Cns.Glottalized = true;
                    }
                    else if (strFeature == ConsonantFeatures.kCombination)
                    {
                        this.Sequence1Cns.Combination = true;
                    }
                    break;
				case 2:
					if (strFeature == ConsonantFeatures.kBilabial)
					{
						this.Sequence2Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kLabiodental)
					{
						this.Sequence2Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kDental)
					{
						this.Sequence2Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kAlveolar)
					{
						this.Sequence2Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kPostalveolar)
					{
						this.Sequence2Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kRetroflex)
					{
						this.Sequence2Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kPalatal)
					{
						this.Sequence2Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kVelar)
					{
						this.Sequence2Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kLabialvelar)
					{
						this.Sequence2Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kUvular)
					{
						this.Sequence2Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kPharyngeal)
					{
						this.Sequence2Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kGlottal)
					{
						this.Sequence2Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kPlosive)
					{
						this.Sequence2Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kNasal)
					{
						this.Sequence2Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kTrill)
					{
						this.Sequence2Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kFlap)
					{
						this.Sequence2Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kFricative)
					{
						this.Sequence2Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kAffricate)
					{
						this.Sequence2Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kLateralFricative)
					{
						this.Sequence2Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kLateralApproximant)
					{
						this.Sequence2Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kApproximant)
					{
						this.Sequence2Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kImplosive)
					{
						this.Sequence2Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kEjective)
					{
						this.Sequence2Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kClick)
					{
						this.Sequence2Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kVoiced)
					{
						this.Sequence2Cns.Voiced = true;
					}
					else if (strFeature == ConsonantFeatures.kPrenasalized)
					{
						this.Sequence2Cns.Prenasalized = true;
					}
					else if (strFeature == ConsonantFeatures.kLabialized)
					{
						this.Sequence2Cns.Labialized = true;
					}
					else if (strFeature == ConsonantFeatures.kPalatalized)
					{
						this.Sequence2Cns.Palatalized = true;
					}
					else if (strFeature == ConsonantFeatures.kVelarized)
					{
						this.Sequence2Cns.Velarized = true;
					}
					else if (strFeature == ConsonantFeatures.kSyllabic)
					{
						this.Sequence2Cns.Syllabic = true;
					}
                    else if (strFeature == ConsonantFeatures.kAspirated)
                    {
                        this.Sequence2Cns.Aspirated = true;
                    }
                    else if (strFeature == ConsonantFeatures.kLong)
                    {
                        this.Sequence2Cns.Long = true;
                    }
                    else if (strFeature == ConsonantFeatures.kGlottalized)
                    {
                        this.Sequence2Cns.Glottalized = true;
                    }
                    else if (strFeature == ConsonantFeatures.kCombination)
                    {
                        this.Sequence2Cns.Combination = true;
                    }
                    break;
				case 3:
					if (strFeature == ConsonantFeatures.kBilabial)
					{
						this.Sequence3Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kLabiodental)
					{
						this.Sequence3Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kDental)
					{
						this.Sequence3Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kAlveolar)
					{
						this.Sequence3Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kPostalveolar)
					{
						this.Sequence3Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kRetroflex)
					{
						this.Sequence3Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kPalatal)
					{
						this.Sequence3Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kVelar)
					{
						this.Sequence3Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kLabialvelar)
					{
						this.Sequence3Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kUvular)
					{
						this.Sequence3Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kPharyngeal)
					{
						this.Sequence3Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kGlottal)
					{
						this.Sequence3Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kPlosive)
					{
						this.Sequence3Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kNasal)
					{
						this.Sequence3Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kTrill)
					{
						this.Sequence3Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kFlap)
					{
						this.Sequence3Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kFricative)
					{
						this.Sequence3Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kAffricate)
					{
						this.Sequence3Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kLateralFricative)
					{
						this.Sequence3Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kLateralApproximant)
					{
						this.Sequence3Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kApproximant)
					{
						this.Sequence3Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kImplosive)
					{
						this.Sequence3Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kEjective)
					{
						this.Sequence3Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kClick)
					{
						this.Sequence3Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kVoiced)
					{
						this.Sequence3Cns.Voiced = true;
					}
					else if (strFeature == ConsonantFeatures.kPrenasalized)
					{
						this.Sequence3Cns.Prenasalized = true;
					}
					else if (strFeature == ConsonantFeatures.kLabialized)
					{
						this.Sequence3Cns.Labialized = true;
					}
					else if (strFeature == ConsonantFeatures.kPalatalized)
					{
						this.Sequence3Cns.Palatalized = true;
					}
					else if (strFeature == ConsonantFeatures.kVelarized)
					{
						this.Sequence3Cns.Velarized = true;
					}
					else if (strFeature == ConsonantFeatures.kSyllabic)
					{
						this.Sequence3Cns.Syllabic = true;
					}
                    else if (strFeature == ConsonantFeatures.kAspirated)
                    {
                        this.Sequence3Cns.Aspirated = true;
                    }
                    else if (strFeature == ConsonantFeatures.kLong)
                    {
                        this.Sequence3Cns.Long = true;
                    }
                    else if (strFeature == ConsonantFeatures.kGlottalized)
                    {
                        this.Sequence3Cns.Glottalized = true;
                    }
                    else if (strFeature == ConsonantFeatures.kCombination)
                    {
                        this.Sequence3Cns.Combination = true;
                    }
                    break;
				case 4:
					if (strFeature == ConsonantFeatures.kBilabial)
					{
						this.Sequence4Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kLabiodental)
					{
						this.Sequence4Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kDental)
					{
						this.Sequence4Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kAlveolar)
					{
						this.Sequence4Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kPostalveolar)
					{
						this.Sequence4Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kRetroflex)
					{
						this.Sequence4Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kPalatal)
					{
						this.Sequence4Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kVelar)
					{
						this.Sequence4Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kLabialvelar)
					{
						this.Sequence4Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kUvular)
					{
						this.Sequence4Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kPharyngeal)
					{
						this.Sequence4Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kGlottal)
					{
						this.Sequence4Cns.PointOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kPlosive)
					{
						this.Sequence4Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kNasal)
					{
						this.Sequence4Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kTrill)
					{
						this.Sequence4Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kFlap)
					{
						this.Sequence4Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kFricative)
					{
						this.Sequence4Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kAffricate)
					{
						this.Sequence4Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kLateralFricative)
					{
						this.Sequence4Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kLateralApproximant)
					{
						this.Sequence4Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kApproximant)
					{
						this.Sequence4Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kImplosive)
					{
						this.Sequence4Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kEjective)
					{
						this.Sequence4Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kClick)
					{
						this.Sequence4Cns.MannerOfArticulation = strFeature;
					}
					else if (strFeature == ConsonantFeatures.kVoiced)
					{
						this.Sequence4Cns.Voiced = true;
					}
					else if (strFeature == ConsonantFeatures.kPrenasalized)
					{
						this.Sequence4Cns.Prenasalized = true;
					}
					else if (strFeature == ConsonantFeatures.kLabialized)
					{
						this.Sequence4Cns.Labialized = true;
					}
					else if (strFeature == ConsonantFeatures.kPalatalized)
					{
						this.Sequence4Cns.Palatalized = true;
					}
					else if (strFeature == ConsonantFeatures.kVelarized)
					{
						this.Sequence4Cns.Velarized = true;
					}
					else if (strFeature == ConsonantFeatures.kSyllabic)
					{
						this.Sequence4Cns.Syllabic = true;
					}
                    else if (strFeature == ConsonantFeatures.kAspirated)
                    {
                        this.Sequence4Cns.Aspirated = true;
                    }
                    else if (strFeature == ConsonantFeatures.kLong)
                    {
                        this.Sequence4Cns.Long = true;
                    }
                    else if (strFeature == ConsonantFeatures.kGlottalized)
                    {
                        this.Sequence4Cns.Glottalized = true;
                    }
                    else if (strFeature == ConsonantFeatures.kCombination)
                    {
                        this.Sequence4Cns.Combination = true;
                    }
                    break;
				default:
					break;
			}
		}

		private void SetVowelFeature(int nSequence, string strFeature)
		{
			switch (nSequence)
			{
				case 1:
					if (strFeature == VowelFeatures.kBack)
					{
						this.Sequence1Vwl.Backness = strFeature;
					}
					else if (strFeature == VowelFeatures.kCentral)
					{
						this.Sequence1Vwl.Backness = strFeature;
					}
					else if (strFeature == VowelFeatures.kFront)
					{
						this.Sequence1Vwl.Backness = strFeature;
					}
					else if (strFeature == VowelFeatures.kHigh)
					{
						this.Sequence1Vwl.Height = strFeature;
					}
					else if (strFeature == VowelFeatures.kMid)
					{
						this.Sequence1Vwl.Height = strFeature;
					}
					else if (strFeature == VowelFeatures.kLow)
					{
						this.Sequence1Vwl.Height = strFeature;
					}
					else if (strFeature == VowelFeatures.kLong)
					{
						this.Sequence1Vwl.Long = true;
					}
					else if (strFeature == VowelFeatures.kNasal)
					{
						this.Sequence1Vwl.Nasal = true;
					}
					else if (strFeature == VowelFeatures.kPlusAtr)
					{
						this.Sequence1Vwl.PlusAtr = true;
					}
					else if (strFeature == VowelFeatures.kRound)
					{
						this.Sequence1Vwl.Round = true;
					}
                    else if (strFeature == VowelFeatures.kDipthong)
                    {
                        this.Sequence1Vwl.Diphthong = true;
                    }
                    else if (strFeature == VowelFeatures.kVoiceless)
                    {
                        this.Sequence1Vwl.Voiceless = true;
                    }
                    break;
				case 2:
					if (strFeature == VowelFeatures.kBack)
					{
						this.Sequence2Vwl.Backness = strFeature;
					}
					else if (strFeature == VowelFeatures.kCentral)
					{
						this.Sequence2Vwl.Backness = strFeature;
					}
					else if (strFeature == VowelFeatures.kFront)
					{
						this.Sequence2Vwl.Backness = strFeature;
					}
					else if (strFeature == VowelFeatures.kHigh)
					{
						this.Sequence2Vwl.Height = strFeature;
					}
					else if (strFeature == VowelFeatures.kMid)
					{
						this.Sequence2Vwl.Height = strFeature;
					}
					else if (strFeature == VowelFeatures.kLow)
					{
						this.Sequence2Vwl.Height = strFeature;
					}
					else if (strFeature == VowelFeatures.kLong)
					{
						this.Sequence2Vwl.Long = true;
					}
					else if (strFeature == VowelFeatures.kNasal)
					{
						this.Sequence2Vwl.Nasal = true;
					}
					else if (strFeature == VowelFeatures.kPlusAtr)
					{
						this.Sequence2Vwl.PlusAtr = true;
					}
					else if (strFeature == VowelFeatures.kRound)
					{
						this.Sequence2Vwl.Round = true;
					}
                    else if (strFeature == VowelFeatures.kDipthong)
                    {
                        this.Sequence2Vwl.Diphthong = true;
                    }
                    else if (strFeature == VowelFeatures.kVoiceless)
                    {
                        this.Sequence2Vwl.Voiceless = true;
                    }
                    break;
				case 3:
					if (strFeature == VowelFeatures.kBack)
					{
						this.Sequence3Vwl.Backness = strFeature;
					}
					else if (strFeature == VowelFeatures.kCentral)
					{
						this.Sequence3Vwl.Backness = strFeature;
					}
					else if (strFeature == VowelFeatures.kFront)
					{
						this.Sequence3Vwl.Backness = strFeature;
					}
					else if (strFeature == VowelFeatures.kHigh)
					{
						this.Sequence3Vwl.Height = strFeature;
					}
					else if (strFeature == VowelFeatures.kMid)
					{
						this.Sequence3Vwl.Height = strFeature;
					}
					else if (strFeature == VowelFeatures.kLow)
					{
						this.Sequence3Vwl.Height = strFeature;
					}
					else if (strFeature == VowelFeatures.kLong)
					{
						this.Sequence3Vwl.Long = true;
					}
					else if (strFeature == VowelFeatures.kNasal)
					{
						this.Sequence3Vwl.Nasal = true;
					}
					else if (strFeature == VowelFeatures.kPlusAtr)
					{
						this.Sequence3Vwl.PlusAtr = true;
					}
					else if (strFeature == VowelFeatures.kRound)
					{
						this.Sequence3Vwl.Round = true;
					}
                    else if (strFeature == VowelFeatures.kDipthong)
                    {
                        this.Sequence3Vwl.Diphthong = true;
                    }
                    else if (strFeature == VowelFeatures.kVoiceless)
                    {
                        this.Sequence3Vwl.Voiceless = true;
                    }
                    break;
				case 4:
					if (strFeature == VowelFeatures.kBack)
					{
						this.Sequence4Vwl.Backness = strFeature;
					}
					else if (strFeature == VowelFeatures.kCentral)
					{
						this.Sequence4Vwl.Backness = strFeature;
					}
					else if (strFeature == VowelFeatures.kFront)
					{
						this.Sequence4Vwl.Backness = strFeature;
					}
					else if (strFeature == VowelFeatures.kHigh)
					{
						this.Sequence4Vwl.Height = strFeature;
					}
					else if (strFeature == VowelFeatures.kMid)
					{
						this.Sequence4Vwl.Height = strFeature;
					}
					else if (strFeature == VowelFeatures.kLow)
					{
						this.Sequence4Vwl.Height = strFeature;
					}
					else if (strFeature == VowelFeatures.kLong)
					{
						this.Sequence4Vwl.Long = true;
					}
					else if (strFeature == VowelFeatures.kNasal)
					{
						this.Sequence4Vwl.Nasal = true;
					}
					else if (strFeature == VowelFeatures.kPlusAtr)
					{
						this.Sequence4Vwl.PlusAtr = true;
					}
					else if (strFeature == VowelFeatures.kRound)
					{
						this.Sequence4Vwl.Round = true;
					}
                    else if (strFeature == VowelFeatures.kDipthong)
                    {
                        this.Sequence4Vwl.Diphthong = true;
                    }
                    else if (strFeature == VowelFeatures.kVoiceless)
                    {
                        this.Sequence4Vwl.Voiceless = true;
                    }
                    break;
				default:
					break;
			}
		}

        public bool MatchesWord(Word wrd)
        {
            bool flag = false;
            Grapheme grf = null;
            string strGrf = "";
            ConsonantFeatures cf = null;
            VowelFeatures vf = null;
            int nSeqLen = this.GetSequenceLength();

            for (int i = 0; i < wrd.GraphemeCount(); i++)
            {
                bool fMatch = false;
                for (int j = 0; j < this.GetSequenceLength(); j++)
                {
                    fMatch = false;
                    grf = wrd.GetGraphemeWithoutTone(i + j);
                    if (grf == null)
                        break;
                    switch (j)
                    {
                        case 0:
                            strGrf = this.Sequence1Grf;
                            cf = this.Sequence1Cns;
                            vf = this.Sequence1Vwl;
                            break;
                        case 1:
                            strGrf = this.Sequence2Grf;
                            cf = this.Sequence2Cns;
                            vf = this.Sequence2Vwl;
                            break;
                        case 2:
                            strGrf = this.Sequence3Grf;
                            cf = this.Sequence3Cns;
                            vf = this.Sequence3Vwl;
                            break;
                        case 3:
                            strGrf = this.Sequence4Grf;
                            cf = this.Sequence4Cns;
                            vf = this.Sequence4Vwl;
                            break;
                    }
                    GraphemeInventory gi = m_Settings.GraphemeInventory;
                    if ((strGrf != "") && ((strGrf == grf.Symbol) || (strGrf == grf.UpperCase)))
                        fMatch = true;
                    if (cf != null)
                    {
                        int n = gi.FindConsonantIndex(grf.Symbol);
                        if (n >= 0)
                        {
                            Consonant cns = gi.GetConsonant(n);
                            if (cns.MatchesFeatures(cf))
                                fMatch = true;
                        }
                    }
                    if (vf != null)
                    {
                        int n = gi.FindVowelIndex(grf.Symbol);
                        if (n >= 0)
                        {
                            Vowel vwl = gi.GetVowel(n);
                            if (vwl.MatchesFeatures(vf))
                                fMatch = true;
                        }
                    }
                    if (!fMatch)
                        break;
                }
                if (fMatch)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        public bool MatchesRoot(Word wrd)
        {
            bool flag = false;
            Grapheme grf = null;
            string strGrf = "";
            ConsonantFeatures cf = null;
            VowelFeatures vf = null;

            for (int i = 0; i < wrd.Root.GraphemeCount(); i++)
            {
                bool fMatch = false;
                for (int j = 0; j < this.GetSequenceLength(); j++)
                {
                    fMatch = false;
                    grf = wrd.Root.GetGraphemeWithoutTone(i + j);
                    if (grf == null)
                        break;
                    switch (j)
                    {
                        case 0:
                            strGrf = this.Sequence1Grf;
                            cf = this.Sequence1Cns;
                            vf = this.Sequence1Vwl;
                            break;
                        case 1:
                            strGrf = this.Sequence2Grf;
                            cf = this.Sequence2Cns;
                            vf = this.Sequence2Vwl;
                            break;
                        case 2:
                            strGrf = this.Sequence3Grf;
                            cf = this.Sequence3Cns;
                            vf = this.Sequence3Vwl;
                            break;
                        case 3:
                            strGrf = this.Sequence4Grf;
                            cf = this.Sequence4Cns;
                            vf = this.Sequence4Vwl;
                            break;
                    }
                    GraphemeInventory gi = m_Settings.GraphemeInventory;
                    if ((strGrf != "") && ((strGrf == grf.Symbol) || (strGrf == grf.UpperCase)))
                        fMatch = true;
                    if (cf != null)
                    {
                        int n = gi.FindConsonantIndex(grf.Symbol);
                        if (n >= 0)
                        {
                            Consonant cns = gi.GetConsonant(n);
                            if (cns.MatchesFeatures(cf))
                                fMatch = true;
                        }
                    }
                    if (vf != null)
                    {
                        int n = gi.FindVowelIndex(grf.Symbol);
                        if (n >= 0)
                        {
                            Vowel vwl = gi.GetVowel(n);
                            if (vwl.MatchesFeatures(vf))
                                fMatch = true;
                        }
                    }
                    if (!fMatch)
                        break;
                }
                if (fMatch)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

    }
}
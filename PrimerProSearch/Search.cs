using System;
using System.Xml;
using System.Drawing;

namespace PrimerProSearch
{
	/// <summary>
	/// Summary description for Search.
	/// </summary>
	public class Search
	{
		private int m_SearchNumber;			// Identifies search
		private SearchDefinition m_SearchDefinition;	//Search definition of the search
        private string m_SearchResults;		// Current results of the search
		private int m_SearchCount;			// Number of entries in search results

        public const char Colon = ':';
		public const string TagSearch = "search";
		public const string TagResults = "results";
		public const string TagType = "type";
		public const string TagSN = "SN";
		public const string TagOpener = "<";
		public const string TagCloser = ">";
		public const string TagForwardSlash = "/";

		public Search(int nSearchNumber, string strType)
		{
			if ( nSearchNumber > 0)
				m_SearchNumber = nSearchNumber;
			else m_SearchNumber = 0;
			m_SearchDefinition = new SearchDefinition(strType);
			m_SearchResults = "";
			m_SearchCount = 0;
		}

		public int SearchNumber
		{
			get {return m_SearchNumber;}
//			set {m_SearchNumber = value;}
		}

		public SearchDefinition SearchDefinition
		{
			get {return m_SearchDefinition;}
			set {m_SearchDefinition = value;}
		}

		public string SearchResults
		{
			get {return m_SearchResults;}
			set {m_SearchResults = value;}
		}

		public int SearchCount
		{
			get {return m_SearchCount;}
			set {m_SearchCount = value;}
		}

		public string GenSearchDefinitionAsString()
		{
			SearchDefinition sd;
			sd = this.SearchDefinition;
			return sd.GenSearchDefinitionAsString();
		}
		
		public string GenSearchFromXML(XmlDocument doc)
		{
			string strXML = "";
			XmlNode nodeSearch = doc.FirstChild;
			XmlNode nodeChild = null;

			strXML += Search.TagOpener + nodeSearch.Name + Search.TagCloser + Environment.NewLine;
			if (nodeSearch.HasChildNodes)
			{
				for (int i = 0; i < nodeSearch.ChildNodes.Count; i++)
				{
					nodeChild = nodeSearch.ChildNodes[i];
					string strName = nodeChild.Name;
					string strData = nodeChild.InnerText;
					if (nodeChild.Name != "#text")
						strXML += Search.TagOpener + nodeChild.Name + Search.TagCloser;

					if (nodeChild.Name == Search.TagResults)
					{
						strXML += Environment.NewLine;
						if (nodeChild.HasChildNodes)
						{
							strName = nodeChild.FirstChild.Name;
							strXML += Search.TagOpener + nodeChild.FirstChild.Name + Search.TagCloser;
							strXML += Environment.NewLine;
							strXML += nodeChild.FirstChild.InnerText + Environment.NewLine;
							strXML += Search.TagOpener + Search.TagForwardSlash
								+ nodeChild.FirstChild.Name + Search.TagCloser;
							strXML += Environment.NewLine;
						}
					}
					else strXML += nodeChild.InnerText;

					if (nodeChild.Name != "#text")
						strXML += Search.TagOpener + Search.TagForwardSlash + nodeChild.Name
							+ Search.TagCloser + Environment.NewLine;
				}
			}
			strXML += Search.TagOpener + Search.TagForwardSlash + nodeSearch.Name
				+ Search.TagCloser + Environment.NewLine;
			return strXML;
		}

		public XmlDocument AddSearchResultToXML(XmlDocument doc, string strResult)
		{
			string strSN = Search.TagSN + this.SearchNumber.ToString().Trim();
			XmlNode nodeResults = doc.CreateNode(XmlNodeType.Element, strSN, "");
			nodeResults.InnerText = strResult;
	
			if (doc.HasChildNodes)
			{
				if (doc.FirstChild.HasChildNodes)
				{
					XmlNodeList nodelist = doc.FirstChild.ChildNodes;
					for (int i = 0; i < nodelist.Count; i++)
					{
						string strName = nodelist[i].Name;
						if (nodelist[i].Name == Search.TagResults)
						{
							XmlNode node = nodelist[i];
							node.InsertBefore(nodeResults, node.FirstChild);
							break;
						}
					}									
				}
				else doc.InsertBefore(nodeResults, doc.FirstChild.FirstChild);
			}
			else
			{
				doc.InsertBefore(nodeResults, doc.FirstChild);
			}
			return doc;
		}

		public bool AlreadyProcessed()
		{
			bool flag = true;
			if (m_SearchResults.Trim() == "")
				flag = false;
			return flag;
		}

		public void MakeUnproccessed()
		{
			m_SearchResults = "";
		}

		public string BuildDefinition()
		{
			return this.GenSearchDefinitionAsString();
		}

		public string BuildSearch()
		{
			string strSrch = "";
			string strDefn = "";
			string strRslt = "";
			string strTag = "";
			int nBgn = 0;

			strRslt = this.BuildSearchResults();
			strDefn = this.BuildDefinition();
			strTag = Search.TagOpener + Search.TagResults + Search.TagCloser;
			nBgn = strDefn.IndexOf(strTag, 0);

			if (nBgn > 0)
			{
				nBgn = nBgn + strTag.Length;
				strSrch = strDefn;
				strSrch = strSrch.Insert(nBgn, strRslt);
				strSrch = strSrch.Insert(nBgn, Environment.NewLine);
			}
			return strSrch;
		}

		public string BuildSearchResults()
		{
			string strRslt = "";
			string strType = this.SearchDefinition.SearchType;
			switch (strType)
			{
                case SearchDefinition.kGeneral:
                    GeneralSearch srchGen = (GeneralSearch)this;
                    strRslt = srchGen.BuildResults();
                    break;
                case SearchDefinition.kGrapheme:
                    GraphemeSearchWL srchSeg = (GraphemeSearchWL)this;
                    strRslt = srchSeg.BuildResults();
                    break;
                case SearchDefinition.kFrequencyWL:
                    FrequencyWLSearch srchFrq = (FrequencyWLSearch)this;
                    strRslt = srchFrq.BuildResults();
                    break;
                case SearchDefinition.kBuildable:
                    BuildableWordSearchWL srchBdw = (BuildableWordSearchWL)this;
                    strRslt = srchBdw.BuildResults();
                    break;
                case SearchDefinition.kAdvanced:
                    AdvancedSearch srchAdv = (AdvancedSearch)this;
                    strRslt = srchAdv.BuildResults();
                    break;
                case SearchDefinition.kMinPairs:
                    MinPairsSearch srchMin = (MinPairsSearch)this;
                    strRslt = srchMin.BuildResults();
                    break;
                case SearchDefinition.kCooccurrence:
                    CooccurrenceChartSearch srchCoc = (CooccurrenceChartSearch)this;
                    strRslt = srchCoc.BuildResults();
                    break;
                case SearchDefinition.kContext:
                    ContextChartSearch srchCon = (ContextChartSearch)this;
                    strRslt = srchCon.BuildResults();
                    break;
                case SearchDefinition.kSyllable:
                    SyllableChartSearch srchSyl = (SyllableChartSearch)this;
                    strRslt = srchSyl.BuildResults();
                    break;
                case SearchDefinition.kToneWL:
                    ToneWLSearch srchTn1 = (ToneWLSearch)this;
                    strRslt = srchTn1.BuildResults();
                    break;
                case SearchDefinition.kSyllographWL:
                    SyllographWLSearch srchSg1 = (SyllographWLSearch)this;
                    strRslt = srchSg1.BuildResults();
                    break;
                case SearchDefinition.kOrderWL:
                    TeachingOrderWLSearch srchOrd1 = (TeachingOrderWLSearch)this;
                    strRslt = srchOrd1.BuildResults();
                    break;
                case SearchDefinition.kGraphemeTD:
                    GraphemeSearchTD srchGrf = (GraphemeSearchTD)this;
                    strRslt = srchGrf.BuildResults();
                    break;
                case SearchDefinition.kFrequencyTD:
                    FrequencyTDSearch srchFrq2 = (FrequencyTDSearch)this;
                    strRslt = srchFrq2.BuildResults();
                    break;
                case SearchDefinition.kWord:
                    WordSearch srchWrd = (WordSearch)this;
                    strRslt = srchWrd.BuildResults();
                    break;
                case SearchDefinition.kCount:
                    WordCountSearch srchWC = (WordCountSearch)this;
                    strRslt = srchWC.BuildResults();
                    break;
                case SearchDefinition.kSyllCount:
                    SyllableCountSearch srchSC = (SyllableCountSearch)this;
                    strRslt = srchSC.BuildResults();
                    break;
                case SearchDefinition.kPhrases:
                    PhraseSearch srchPhr = (PhraseSearch)this;
                    strRslt = srchPhr.BuildResults();
                    break;
                case SearchDefinition.kResidue:
                    ResidueSearch srchRsd = (ResidueSearch)this;
                    strRslt = srchRsd.BuildResults();
                    break;
                case SearchDefinition.kSight:
                    SightSearch srchSgh = (SightSearch)this;
                    strRslt = srchSgh.BuildResults();
                    break;
                case SearchDefinition.kBuilt:
                    BuildableWordSearchTD srchBwd = (BuildableWordSearchTD)this;
                    strRslt = srchBwd.BuildResults();
                    break;
                case SearchDefinition.kNewWord:
                    NewWordSearch srchNew = (NewWordSearch)this;
                    strRslt = srchNew.BuildResults();
                    break;
                case SearchDefinition.kToneTD:
                    ToneTDSearch srchTn2 = (ToneTDSearch)this;
                    strRslt = srchTn2.BuildResults();
                    break;
                case SearchDefinition.kSyllographTD:
                    SyllographTDSearch srchSg2 = (SyllographTDSearch)this;
                    strRslt = srchSg2.BuildResults();
                    break;
                case SearchDefinition.kOrderTD:
                    TeachingOrderTDSearch srchOrd2 = (TeachingOrderTDSearch)this;
                    strRslt = srchOrd2.BuildResults();
                    break;
                case SearchDefinition.kVowel:
                    VowelChartSearch srchVwl = (VowelChartSearch)this;
                    strRslt = srchVwl.BuildResults();
                    break;
                case SearchDefinition.kConsonant:
                    ConsonantChartSearch srchCns = (ConsonantChartSearch)this;
                    strRslt = srchCns.BuildResults();
                    break;
                case SearchDefinition.kTone:
                    ToneChartSearch srchTne = (ToneChartSearch)this;
                    strRslt = srchTne.BuildResults();
                    break;
                case SearchDefinition.kSyllograph:
                    SyllographChartSearch srchSylb = (SyllographChartSearch)this;
                    strRslt = srchSylb.BuildResults();
                    break;
				default:
					break;
			}
			return strRslt;
		}

     }
}

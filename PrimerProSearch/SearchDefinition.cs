using System;
using System.Collections;
using System.Xml;
using PrimerProObjects;
using GenLib;

namespace PrimerProSearch
{
	/// <summary>
	/// Summary description for SearchDefinition.
	/// </summary>
	public class SearchDefinition
	{
		private string m_SearchType;		//Search Type
		private ArrayList m_SearchParms;	//Array of Search Definition Parms

		public const string kGeneral = "General";
		public const string kGrapheme = "GraphemeWL";
        public const string kFrequencyWL = "FrequencyCountWL";
		public const string kBuildable = "BuildableWordsWL";
        public const string kAdvanced = "AdvancedGrapheme";
		public const string kMinPairs = "MinPairs";
		public const string kCooccurrence = "CooccurrenceChart";
		public const string kContext = "ContextChart";
		public const string kSyllable = "SyllableChart";
		public const string kToneWL = "ToneWL";
        public const string kSyllographWL = "SyllographWL";
        public const string kTonePairs = "MinTonePairs";
        public const string kGraphemeTD = "GraphemeTD";
        public const string kFrequencyTD = "FrequencyCountTD";
		public const string kWord = "Word";
        public const string kCount = "WordCount";
        public const string kSyllCount = "SyllableCount";
		public const string kPhrases = "UsablePhrases";
		public const string kResidue = "UnTaughtResidue";
        public const string kBuilt = "BuildableWordsTD";
		public const string kSight = "SightWord";
        public const string kNewWord = "NewWord";
		public const string kToneTD = "ToneTD";
        public const string kSyllographTD = "SyllographTD";
		public const string kVowel = "VowelChart";
		public const string kConsonant = "ConsonantChart";
		public const string kTone = "ToneChart";
        public const string kSyllograph = "SyllographChart";
        public const string kOrderWL = "TeachingOrderWL";
		public const string kOrderTD = "TeachingOrderTD";
	
		public SearchDefinition ()
		{
			m_SearchType = "";
			m_SearchParms = new ArrayList();
		}

		public SearchDefinition(string strType)
		{
			m_SearchType =  strType;
			m_SearchParms = new ArrayList();
		}

		public string SearchType
		{
			get {return m_SearchType;}
			set {m_SearchType = value;}
		}

		public void AddSearchParm(SearchDefinitionParm sdp)
		{
			m_SearchParms.Add(sdp);
		}

		public void ClearSearchParms()
		{
			m_SearchParms.Clear();
		}

		public SearchDefinitionParm GetSearchParmAt(int n)
		// Get nth search definition parameter
		{
			SearchDefinitionParm sdp = null;
			if ( (n >= 0 ) && (n < SearchParmsCount()) )
				sdp = (SearchDefinitionParm) m_SearchParms[n];
			return sdp;
		}

		public string GetSearchParmContent(string strTag)
		// Get content of search definition for a given tag
		{
			string strContent = "";
			SearchDefinitionParm sdp = null;
			for ( int i = 0; i < SearchParmsCount(); i++ )
			{
				sdp = (SearchDefinitionParm) m_SearchParms[i];
				if ( strTag == sdp.GetTag() )
					strContent = sdp.GetContent();
			}
			return strContent;
		}

		public void AddSearchOptions(SearchOptions so)
		{
			SearchDefinitionParm sdp;
			if (so.PS != null)
			{
				sdp = new SearchDefinitionParm(SearchOptions.kPS, so.PS.Code);
				this.AddSearchParm(sdp);
			}
			if (so.IsRootOnly)
			{
				sdp = new SearchDefinitionParm(SearchOptions.kRootsOnly, "");
				this.AddSearchParm(sdp);
			}
			if (so.IsIdenticalVowelsInWord)
			{
				sdp = new SearchDefinitionParm(SearchOptions.kSameVowelsInWord, "");
				this.AddSearchParm(sdp);
			}
			if (so.IsIdenticalVowelsInRoot)
			{
				sdp = new SearchDefinitionParm(SearchOptions.kSameVowelsInRoot, "");
				this.AddSearchParm(sdp);
			}
            if (so.IsBrowseView)
            {
                sdp = new SearchDefinitionParm(SearchOptions.kBrowseView, "");
                this.AddSearchParm(sdp);
            }
			if (so.WordCVShape != "")
			{
				sdp = new SearchDefinitionParm(SearchOptions.kWordCVShape, so.WordCVShape);
				this.AddSearchParm(sdp);
			}
			if (so.RootCVShape != "")
			{
				sdp = new SearchDefinitionParm(SearchOptions.kRootCVShape, so.RootCVShape);
				this.AddSearchParm(sdp);
			}

            if (so.MinSyllables > 0)
            {
                sdp = new SearchDefinitionParm(SearchOptions.kMinSyllables, so.MinSyllables.ToString());
                this.AddSearchParm(sdp);
            }

            if (so.MaxSyllables > 0)
            {
                sdp = new SearchDefinitionParm(SearchOptions.kMaxSyllales, so.MaxSyllables.ToString());
                this.AddSearchParm(sdp);
            }

			if (so.WordPosition != SearchOptions.Position.Any)
			{
				sdp = new SearchDefinitionParm(SearchOptions.kWordPosition, so.WordPosition.ToString());
				this.AddSearchParm(sdp);
			}
			if (so.RootPosition != SearchOptions.Position.Any)
			{
				sdp = new SearchDefinitionParm(SearchOptions.kRootPosition, so.RootPosition.ToString());
				this.AddSearchParm(sdp);
			}
		}

		public void BldSearchDefinitionFromString(string strDefn)
		{
			string strName = "";
			string strData = "";
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(strDefn);
			XmlNode nodeRoot = doc.FirstChild;
			XmlNode nodeChild = null;
			if (nodeRoot.HasChildNodes)
			{
				for (int i = 0; i < nodeRoot.ChildNodes.Count; i++)
				{
					nodeChild = nodeRoot.ChildNodes[i];
					strName = nodeChild.Name;
					strData = nodeChild.InnerText;
					switch (strName)
					{
						case Search.TagType:
							this.SearchType = strData;
							break;
						case Search.TagResults:
							break;
						case Search.TagSearch:
							break;
						case "#text":	//ignore this
							break;
						default:
							SearchDefinitionParm sdp = new SearchDefinitionParm(strName, strData);
							this.AddSearchParm(sdp);
							break;
					}
				}
			}
		}

		public string GenSearchDefinitionAsString()
		{
			SearchDefinitionParm sdp = null;
			string str = "";
			int nCount =0;

			str += Search.TagOpener + Search.TagSearch + Search.TagCloser + Environment.NewLine;
			str += Search.TagOpener + Search.TagType + Search.TagCloser;
			str	+= this.SearchType;
			str += Search.TagOpener + Search.TagForwardSlash + Search.TagType + Search.TagCloser;
			str	+= Environment.NewLine;
			nCount = this.SearchParmsCount();
			for (int i = 0; i < nCount; i++)
			{
				sdp = (SearchDefinitionParm) m_SearchParms[i];
				str += sdp.GenSearchDefintionParm() + Environment.NewLine;
			}
			str += Search.TagOpener + Search.TagResults + Search.TagCloser;
			str	+= Search.TagOpener + Search.TagForwardSlash + Search.TagResults + Search.TagCloser;
			str += Environment.NewLine;
			str += Search.TagOpener + Search.TagForwardSlash + Search.TagSearch + Search.TagCloser;
//			str += Environment.NewLine;
			return str;
		}
		
		public int SearchParmsCount()
		{
			return m_SearchParms.Count;
		}

        public SearchOptions MakeSearchOptions(SearchOptions so)
        // Build search options from search definition
        {
            SearchDefinitionParm sdp = null;
            string strTag = "";
            string strContent = "";

            for (int i = 0; i < this.SearchParmsCount(); i++)
            {
                sdp = this.GetSearchParmAt(i);
                strTag = sdp.GetTag();
                strContent = sdp.GetContent();
                
                so = so.SetOption(strTag, strContent);
            }
            return so;
        }

    }
}

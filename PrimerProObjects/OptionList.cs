using System;
using System.Drawing;
using System.Xml;
using System.IO;
using PrimerProLocalization;
using GenLib;

namespace PrimerProObjects
{
	/// <summary>
	/// OptionList - contains all application options
	/// </summary>
	public class OptionList
	{
		private string m_FileName;
        private string m_PrimerProFolder;
		private string m_DataFolder;
		private string m_TemplateFolder;
		private string m_GraphemeInventoryFile;
		private string m_SightWordsFile;
        private string m_GraphemeTaughtOrderFile;
		private string m_PSTableFile;
		private string m_WordListFile;
        private WordList.FileType m_WordListFileType;
		private string m_TextDataFile;
		private string m_DefaultFontName;
		private FontStyle m_DefaultFontStyle;
		private int m_DefaultFontSize;
		private Color m_HighlightColor;
		private bool m_ViewOrigWord;
		private bool m_ViewGlossEnglish;
		private bool m_ViewGlossNational;
		private bool m_ViewGlossRegional;
		private bool m_ViewPS;
		private bool m_ViewPlural;
		private bool m_ViewCVPattern;
		private bool m_ViewSyllBreaks;
		private bool m_ViewWordWithoutTone;
        private bool m_ViewRoot;
        private bool m_ViewRootCVPattern;
        private bool m_ViewRootSyllBreaks;
        private bool m_ViewRootWithoutTone;
        private bool m_ViewParaSentWord;
        private string m_FMRecordMarker;
		private string m_FMLexicon;
		private string m_FMGlossEnglish;
		private string m_FMGlossNational;
		private string m_FMGlossRegional;
		private string m_FMPS;
		private string m_FMPlural;
		private string m_FMRoot;
        private string m_LiftVernacular;
        private string m_LiftGlossEnglish;
        private string m_LiftGlossNational;
        private string m_LiftGlossRegional;
        private bool m_SyllabicNasals;
		private string m_CVCns;
		private string m_CVSyllbc;
        private string m_CVAspir;
		private string m_CVPrensl;
		private string m_CVLablzd;
		private string m_CVPaltzd;
		private string m_CVVelrzd;
		private string m_CVVwl;
		private string m_CVVwlNsl;
		private string m_CVVwlLng;
        private string m_CVVwlDip;
        private string m_CVSyllograph;
        private string m_CVTone;
        private string m_EndingPunct;
        private string m_GeneralPunct;
        private int m_MaxSizeGrapheme;
        private string m_ImportIgnoreChars;
        private ReplacementList m_ImportReplacementList;
        private string m_Lang;
        private LocalizationTable m_Table;
        private bool m_SimplifiedMenu;
        
        // XML Elements
        public const string kOptionList = "OptionList";
        public const string kDataFolder = "DataFolder";
        public const string kTemplateFolder = "TemplateFolder";
        public const string kGIFile = "GraphemeInventoryFile";
        public const string kSWFile = "SightWordsFile";
        public const string kGTOFile = "GraphemeTaughtOrderFile";
        public const string kPSTFile = "PSTableFile";
        public const string kWLFile = "WordListFile";
        public const string kWLType = "WordListFileType";
        public const string kLift = "Lift";
        public const string kStdFmt = "StandardFormat";
        public const string kTDFile = "TextDataFile";
        public const string kDftlFntName = "DefaultFontName";
        public const string kDfltFntSize = "DefaultFontSize";
        public const string kDfltFntStyle = "DefaultFontStyle";
        public const string kHighlightColor = "HighlightColor";
        public const string kViewOrigWord = "ViewOrigWord";
        public const string kViewGlossE = "ViewGlossEnglish";
        public const string kViewGlossN = "ViewGlossNational";
        public const string kViewGlossR = "ViewGlossRegional";
        public const string kViewPS = "ViewPS";
        public const string kViewPlural = "ViewPlural";
        public const string kViewCVPattern = "ViewCVPattern";
        public const string kViewSyllBreaks = "ViewSyllBreaks";
        public const string kViewWordNoTone = "ViewWordWithoutTone";
        public const string kViewRoot = "ViewRoot";
        public const string kViewRootCVPattern = "ViewRootCVPattern";
        public const string kViewRootSyllBreaks = "ViewRootSyllBreaks";
        public const string kViewRootNoTone = "ViewRootWithoutTone";
        public const string kViewParaSentWord = "ViewParaSentWord";
        public const string kFMRM = "FMRecordMarker";
        public const string kFMLX = "FMLexicon";
        public const string kFMGE = "FMGlossEnglish";
        public const string kFMGN = "FMGlossNational";
        public const string kFMGR = "FMGlossRegional";
        public const string kFMPS = "FMPS";
        public const string kFMPL = "FMPlural";
        public const string kFMRT = "FMRoot";
        public const string kLiftVr = "LiftVernacular";
        public const string kLiftGE = "LiftGlossEnglish";
        public const string kLiftGN = "LiftGlossNational";
        public const string kLiftGR = "LiftGlossRegional";
        public const string kSyllNasals = "HaveSyllabicNasals";
        public const string kCVCns = "CVCns";
        public const string kCVSyllbc = "CVSyllbc";
        public const string kCVAspir = "CVAspir";
        public const string kCVPrensl = "CVPrensl";
        public const string kCVLablzd = "CVLablzd";
        public const string kCVPaltzd = "CVPaltzd";
        public const string kCVVelrzd = "CVVelrzd";
        public const string kCVVwl = "CVVwl";
        public const string kCVVwlNsl = "CVVwlNsl";
        public const string kCVVwlLng = "CVVwlLng";
        public const string kCVVwlDip = "CVVwlDip";
        public const string kCVSyllograph = "CVSyllograph";
        public const string kCVTone = "CVTone";
        public const string kEndPunct = "EndingPunctation";
        public const string kGenPunct = "GeneralPunctation";
        public const string kMaxSizeGrapheme = "MaxSizeOfGrapheme";
        public const string kImportIgnoreChars = "ImportIgnorChars";
        public const string kImportReplacementList = "ImportReplacementList";
        public const string kReplace = "ReplaceThis";
        public const string kWith = "WithThis";
        public const string kUILanguage = "UILanguage";
        public const string kSimplifiedMenu = "SimplifiedMenu";

        private const string kPrimerProFolder = "PrimerPro";
        private const string kBackSlash = "\\";
        public const string kEnglish = "en";
        public const string kFrench = "fr";

		public OptionList()
		{
 			m_FileName = "";
            m_PrimerProFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
              + kBackSlash + kPrimerProFolder;
            m_DataFolder = this.PrimerProFolder;
            m_TemplateFolder = this.PrimerProFolder;
            m_GraphemeInventoryFile = this.PrimerProFolder + "\\GraphemeInventory.xml";
            m_SightWordsFile = this.PrimerProFolder + "\\SightWords.xml";
            m_GraphemeTaughtOrderFile = this.PrimerProFolder + "\\GraphemeTaughtOrder.xml";
            m_PSTableFile = this.PrimerProFolder + "\\PSTable.xml";
			m_WordListFile = "";
            m_WordListFileType = WordList.FileType.None;
			m_TextDataFile = "";
            m_DefaultFontName = Funct.GetInstalledFont();
            if (m_DefaultFontName == "")
                m_DefaultFontName = "Arial";
            m_DefaultFontStyle = FontStyle.Regular;
			m_DefaultFontSize = 12;
			m_HighlightColor = Color.Black;
			m_ViewOrigWord = false;
			m_ViewGlossEnglish = true;
			m_ViewGlossNational = false;
			m_ViewGlossRegional = false;
			m_ViewPS = false;
			m_ViewPlural = false;
			m_ViewCVPattern = false;
			m_ViewSyllBreaks = false;
			m_ViewWordWithoutTone = false;
            m_ViewRoot = false;
            m_ViewRootCVPattern = false;
            m_ViewRootSyllBreaks = false;
            m_ViewRootWithoutTone = false;
            m_ViewParaSentWord = false;
            m_FMRecordMarker = "lx";
			m_FMLexicon = "lx";
			m_FMGlossEnglish = "ge";
			m_FMGlossNational = "gn";
			m_FMGlossRegional = "gr";
			m_FMPS = "ps";
			m_FMPlural = "pl";
			m_FMRoot = "rt";
            m_LiftVernacular = "";
            m_LiftGlossEnglish = OptionList.kEnglish;
            m_LiftGlossNational = "";
            m_LiftGlossRegional = "";
            m_SyllabicNasals = false;
			m_CVCns = "C";
			m_CVSyllbc = "C";
            m_CVAspir = "C";
			m_CVPrensl = "NC";
			m_CVLablzd = "CW";
			m_CVPaltzd = "CY";
			m_CVVelrzd = "CG";
			m_CVVwl = "V";
			m_CVVwlNsl = "V";
			m_CVVwlLng = "VV";
            m_CVVwlDip = "VV";
            m_CVTone = "T";
            m_EndingPunct = ".?!";
            m_GeneralPunct = " ,:;-";
            m_MaxSizeGrapheme = 4;
            m_ImportIgnoreChars = "";
            m_ImportReplacementList = null;
            m_Lang = OptionList.kEnglish;
            m_Table = null;
            m_SimplifiedMenu = false;
        }

        public OptionList(string strFolder, string strFileName)
        {
            m_FileName = strFileName;
            m_PrimerProFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
              + kBackSlash + kPrimerProFolder;
            m_DataFolder = strFolder;
            m_TemplateFolder = strFolder;
            m_GraphemeInventoryFile = strFolder + "\\GraphemeInventory.xml";
            m_SightWordsFile = strFolder + "\\SightWords.xml";
            m_GraphemeTaughtOrderFile = strFolder + "\\GraphemeTaughtOrder.xml";
            m_PSTableFile = strFolder + "\\PSTable.xml";
            m_WordListFile = "";
            m_WordListFileType = WordList.FileType.None;
            m_TextDataFile = "";
            m_DefaultFontName = Funct.GetInstalledFont();
            if (m_DefaultFontName == "")
                m_DefaultFontName = "Arial";
            m_DefaultFontStyle = FontStyle.Regular;
            m_DefaultFontSize = 12;
            m_HighlightColor = Color.Black;
            m_ViewOrigWord = false;
            m_ViewGlossEnglish = true;
            m_ViewGlossNational = false;
            m_ViewGlossRegional = false;
            m_ViewPS = false;
            m_ViewPlural = false;
            m_ViewCVPattern = false;
            m_ViewSyllBreaks = false;
            m_ViewWordWithoutTone = false;
            m_ViewRoot = false;
            m_ViewRootCVPattern = false;
            m_ViewRootSyllBreaks = false;
            m_ViewRootWithoutTone = false;
            m_ViewParaSentWord = false;
            m_FMRecordMarker = "lx";
            m_FMLexicon = "lx";
            m_FMGlossEnglish = "ge";
            m_FMGlossNational = "gn";
            m_FMGlossRegional = "gr";
            m_FMPS = "ps";
            m_FMPlural = "pl";
            m_FMRoot = "rt";
            m_LiftVernacular = "";
            m_LiftGlossEnglish = OptionList.kEnglish;
            m_LiftGlossNational = "";
            m_LiftGlossRegional = "";
            m_SyllabicNasals = false;
            m_CVCns = "C";
            m_CVSyllbc = "C";
            m_CVAspir = "C";
            m_CVPrensl = "NC";
            m_CVLablzd = "CW";
            m_CVPaltzd = "CY";
            m_CVVelrzd = "CG";
            m_CVVwl = "V";
            m_CVVwlNsl = "V";
            m_CVVwlLng = "VV";
            m_CVVwlDip = "VV";
            m_CVSyllograph = "S";
            m_CVTone = "T";
            m_EndingPunct = ".?!";
            m_GeneralPunct = " ,:;-";
            m_MaxSizeGrapheme = 4;
            m_ImportIgnoreChars = "";
            m_ImportReplacementList = null;
            m_Lang = OptionList.kEnglish;
            m_Table = null;
            m_SimplifiedMenu = false;
        }

        public OptionList(string strFolder, string strFileName, LocalizationTable table, string lang)
        {
            m_FileName = strFileName;
            m_PrimerProFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
              + kBackSlash + kPrimerProFolder;
            m_DataFolder = strFolder;
            m_TemplateFolder = strFolder;
            m_GraphemeInventoryFile = strFolder + "\\GraphemeInventory.xml";
            m_SightWordsFile = strFolder + "\\SightWords.xml";
            m_GraphemeTaughtOrderFile = strFolder + "\\GraphemeTaughtOrder.xml";
            m_PSTableFile = strFolder + "\\PSTable.xml";
            m_WordListFile = "";
            m_WordListFileType = WordList.FileType.None;
            m_TextDataFile = "";
            m_DefaultFontName = Funct.GetInstalledFont();
            if (m_DefaultFontName == "")
                m_DefaultFontName = "Arial";
            m_DefaultFontStyle = FontStyle.Regular;
            m_DefaultFontSize = 12;
            m_HighlightColor = Color.Black;
            m_ViewOrigWord = false;
            m_ViewGlossEnglish = true;
            m_ViewGlossNational = false;
            m_ViewGlossRegional = false;
            m_ViewPS = false;
            m_ViewPlural = false;
            m_ViewCVPattern = false;
            m_ViewSyllBreaks = false;
            m_ViewWordWithoutTone = false;
            m_ViewRoot = false;
            m_ViewRootCVPattern = false;
            m_ViewRootSyllBreaks = false;
            m_ViewRootWithoutTone = false;
            m_ViewParaSentWord = false;
            m_FMRecordMarker = "lx";
            m_FMLexicon = "lx";
            m_FMGlossEnglish = "ge";
            m_FMGlossNational = "gn";
            m_FMGlossRegional = "gr";
            m_FMPS = "ps";
            m_FMPlural = "pl";
            m_FMRoot = "rt";
            m_LiftVernacular = "";
            m_LiftGlossEnglish = OptionList.kEnglish;
            m_LiftGlossNational = "";
            m_LiftGlossRegional = "";
            m_SyllabicNasals = false;
            m_CVCns = "C";
            m_CVSyllbc = "C";
            m_CVAspir = "C";
            m_CVPrensl = "NC";
            m_CVLablzd = "CW";
            m_CVPaltzd = "CY";
            m_CVVelrzd = "CG";
            m_CVVwl = "V";
            m_CVVwlNsl = "V";
            m_CVVwlLng = "VV";
            m_CVVwlDip = "VV";
            m_CVSyllograph = "S";
            m_CVTone = "T";
            m_EndingPunct = ".?!";
            m_GeneralPunct = " ,:;-";
            m_MaxSizeGrapheme = 4;
            m_ImportIgnoreChars = "";
            m_ImportReplacementList = null;
            m_Lang = lang;
            m_Table = table;
            m_SimplifiedMenu = false;
        }

        public string FileName
		{
			get { return m_FileName;}
			set {m_FileName = value;}
		}

        public string PrimerProFolder
        {
            get { return m_PrimerProFolder; }
            set { m_PrimerProFolder = value; }
        }

        public string DataFolder
		{
			get { return m_DataFolder;}
			set {m_DataFolder = value;}
		}

        public string TemplateFolder
		{
			get {return m_TemplateFolder;}
			set {m_TemplateFolder = value;}
		}

        public string GraphemeInventoryFile
		{
            get { return m_GraphemeInventoryFile; }
            set { m_GraphemeInventoryFile = value; }
		}

		public string SightWordsFile
		{
			get {return m_SightWordsFile;}
			set {m_SightWordsFile = value;}
		}

        public string GraphemeTaughtOrderFile
        {
            get { return m_GraphemeTaughtOrderFile; }
            set { m_GraphemeTaughtOrderFile = value; }
        }

		public string PSTableFile
		{
			get {return m_PSTableFile;}
			set {m_PSTableFile = value;}
		}

		public string WordListFile
		{
			get {return m_WordListFile;}
			set {m_WordListFile = value;}
		}

        public WordList.FileType WordListFileType
        {
            get { return m_WordListFileType; }
            set { m_WordListFileType = value; }
        }
		
        public string TextDataFile
		{
			get {return m_TextDataFile;}
			set {m_TextDataFile = value;}
		}

		public string DefaultFontName
		{
			get {return m_DefaultFontName;}
			set {m_DefaultFontName = value;}
		}

		public FontStyle DefaultFontStyle
		{
			get {return m_DefaultFontStyle;}
			set {m_DefaultFontStyle = value;}
		}

		public int DefaultFontSize
		{
			get {return m_DefaultFontSize;}
			set {m_DefaultFontSize = value;}
		}

		public Color HighlightColor
		{
			get {return m_HighlightColor;}
			set {m_HighlightColor = value;}
		}

		public bool ViewOrigWord
		{
			get {return m_ViewOrigWord;}
			set {m_ViewOrigWord = value;}
		}

		public bool ViewGlossEnglish
		{
			get {return m_ViewGlossEnglish;}
			set {m_ViewGlossEnglish = value;}
		}

		public bool ViewGlossNational
		{
			get {return m_ViewGlossNational;}
			set {m_ViewGlossNational = value;}
		}

		public bool ViewGlossRegional
		{
			get {return m_ViewGlossRegional;}
			set {m_ViewGlossRegional = value;}
		}
		
		public bool ViewPS
		{
			get {return m_ViewPS;}
			set {m_ViewPS = value;}
		}
		
		public bool ViewPlural
		{
			get {return m_ViewPlural;}
			set {m_ViewPlural = value;}
		}

		public bool ViewCVPattern
		{
			get {return m_ViewCVPattern;}
			set {m_ViewCVPattern = value;}
		}
		
		public bool ViewSyllBreaks
		{
			get {return m_ViewSyllBreaks;}
			set {m_ViewSyllBreaks = value;}
		}
		
		public bool ViewWordWithoutTone
		{
			get {return m_ViewWordWithoutTone;}
			set {m_ViewWordWithoutTone = value;}
		}

        public bool ViewRoot
        {
            get { return m_ViewRoot; }
            set { m_ViewRoot = value; }
        }

        public bool ViewRootCVPattern
        {
            get { return m_ViewRootCVPattern; }
            set { m_ViewRootCVPattern = value; }
        }

        public bool ViewRootSyllBreaks
        {
            get { return m_ViewRootSyllBreaks; }
            set { m_ViewRootSyllBreaks = value; }
        }

        public bool ViewRootWithoutTone
		{
			get {return m_ViewRootWithoutTone;}
			set {m_ViewRootWithoutTone = value;}
		}

        public bool ViewParaSentWord
        {
            get { return m_ViewParaSentWord; }
            set { m_ViewParaSentWord = value; }
        }

        public string FMRecordMarker
        {
            get { return m_FMRecordMarker; }
            set { m_FMRecordMarker = value; }
        }

        public string FMLexicon
		{
			get {return m_FMLexicon;}
			set {m_FMLexicon = value;}
		}
		
		public string FMGlossEnglish
		{
			get {return m_FMGlossEnglish;}
			set {m_FMGlossEnglish = value;}
		}
		
		public string FMGlossNational
		{
			get {return m_FMGlossNational;}
			set {m_FMGlossNational = value;}
		}
		
		public string FMGlossRegional
		{
			get {return m_FMGlossRegional;}
			set {m_FMGlossRegional = value;}
		}
		
		public string FMPS
		{
			get {return m_FMPS;}
			set {m_FMPS = value;}
		}
		
		public string FMPlural
		{
			get {return m_FMPlural;}
			set {m_FMPlural = value;}
		}
		
		public string FMRoot
		{
			get {return m_FMRoot;}
			set {m_FMRoot = value;}
		}

        public string LiftVernacular
        {
            get { return m_LiftVernacular; }
            set { m_LiftVernacular = value; }
        }

        public string LiftGlossEnglish
        {
            get { return m_LiftGlossEnglish; }
            set { m_LiftGlossEnglish = value; }
        }

        public string LiftGlossNational
        {
            get { return m_LiftGlossNational; }
            set { m_LiftGlossNational = value; }
        }

        public string LiftGlossRegional
        {
            get { return m_LiftGlossRegional; }
            set { m_LiftGlossRegional = value; }
        }

        public bool SyllabicNasals
        {
        	get {return m_SyllabicNasals;}
			set {m_SyllabicNasals = value;}
        }

        public string CVCns
		{
			get {return m_CVCns;}
			set {m_CVCns = value;}
		}

		public string CVSyllbc
		{
			get {return m_CVSyllbc;}
			set {m_CVSyllbc = value;}
		}

        public string CVAspir
        {
            get { return m_CVAspir; }
            set { m_CVAspir = value; }
        }

        public string CVPrensl
		{
			get {return m_CVPrensl;}
			set {m_CVPrensl = value;}
		}
		
		public string CVLablzd
		{
			get {return m_CVLablzd;}
			set {m_CVLablzd = value;}
		}

		public string CVPaltzd
		{
			get {return m_CVPaltzd;}
			set {m_CVPaltzd = value;}
		}

		public string CVVelrzd
		{
			get {return m_CVVelrzd;}
			set {m_CVVelrzd = value;}
		}

		public string CVVwl
		{
			get {return m_CVVwl;}
			set {m_CVVwl = value;}
		}

		public string CVVwlNsl
		{
			get {return m_CVVwlNsl;}
			set {m_CVVwlNsl = value;}
		}

		public string CVVwlLng
		{
			get {return m_CVVwlLng;}
			set {m_CVVwlLng = value;}
		}

        public string CVVwlDip
        {
            get { return m_CVVwlDip; }
            set { m_CVVwlDip = value; }
        }

        public string CVSyllograph
        {
            get { return m_CVSyllograph; }
            set { m_CVSyllograph = value; }
        }

        public string CVTone
        {
            get { return m_CVTone; }
            set { m_CVTone = value; }
        }

        public string EndingPunct
        {
            get { return m_EndingPunct; }
            set { m_EndingPunct = value; }
        }

        public string GeneralPunct
        {
            get { return m_GeneralPunct; }
            set { m_GeneralPunct = value; }
        }

        public int MaxSizeGrapheme
        {
            get { return m_MaxSizeGrapheme; }
            set { m_MaxSizeGrapheme = value; }
        }

        public string ImportIgnoreChars
        {
            get { return m_ImportIgnoreChars; }
            set { m_ImportIgnoreChars = value; }
        }

        public ReplacementList ImportReplacementList
        {
            get { return m_ImportReplacementList; }
            set { m_ImportReplacementList = value; }
        }

        public string UILanguage
        {
            get { return m_Lang; }
            set { m_Lang = value; }
        }

        public bool SimplifiedMenu
        {
            get {return m_SimplifiedMenu;}
            set {m_SimplifiedMenu = value;}
        }

        public bool LoadFromFile(string strFileName)
		{
			XmlTextReader reader = null;
			if (!File.Exists(strFileName))
				return false;
			try 
			{
  				// Load the reader with the data file and ignore all white space nodes.         
				reader = new XmlTextReader(strFileName);
				reader.WhitespaceHandling = WhitespaceHandling.None;

				// Parse the file
				string nam = "";
				string val = "";
                int kount = 0;
                string strReplace = "";
                string strWith = "";

				while (reader.Read()) 
				{
					switch (reader.NodeType) 
					{
						case XmlNodeType.Element:
							nam = reader.Name;
                            kount = reader.AttributeCount;
                            if ((nam == OptionList.kImportReplacementList) && (reader.AttributeCount > 1))
                            {
                                strReplace = reader.GetAttribute(OptionList.kReplace);
                                if (strReplace == null) strReplace = "";
                                if (strReplace != "")
                                {
                                    strWith = reader.GetAttribute(OptionList.kWith);
                                    if (strWith == null) strWith = "";
                                    if (m_ImportReplacementList == null)
                                        m_ImportReplacementList = new ReplacementList();
                                    m_ImportReplacementList.AddReplaceWith(strReplace, strWith); 
                                 }
                            }
							val = "";
							break;
						case XmlNodeType.Text:
							val = reader.Value;
							SetOption(nam, val);
							break;
						case XmlNodeType.CDATA:
							break;
						case XmlNodeType.ProcessingInstruction:
							break;
						case XmlNodeType.Comment:
							break;
						case XmlNodeType.XmlDeclaration:
							break;
						case XmlNodeType.Document:
							break;
						case XmlNodeType.DocumentType:
							break;
						case XmlNodeType.EntityReference:
							break;
						case XmlNodeType.EndElement:
							nam = reader.Name;
							break;
					}       
				}           
			}

			finally 
			{
				if (reader!=null)
				{
					m_FileName = strFileName;
					reader.Close();
				}
			}
			return true;
		}

		private void SetOption(string nam, string val)
		{
            if (nam == OptionList.kDataFolder)
            {
                m_DataFolder = val;
                if ( !Directory.Exists(Funct.GetFolder(m_DataFolder)) )
                    m_DataFolder = this.PrimerProFolder;
            }
			if ( nam == OptionList.kTemplateFolder )
            {
				m_TemplateFolder = val;
                if ( !Directory.Exists(Funct.GetFolder(m_TemplateFolder)) )
                    m_TemplateFolder = this.PrimerProFolder;
            }
            if (nam == OptionList.kGIFile)
            {
                m_GraphemeInventoryFile = val;
                if (!File.Exists(m_GraphemeInventoryFile))
                    m_GraphemeInventoryFile = this.PrimerProFolder + "\\GraphemeInventory.xml";
            }
            if (nam == OptionList.kSWFile)
            {
                m_SightWordsFile = val;
                if (!File.Exists(m_SightWordsFile))
                    m_SightWordsFile = this.PrimerProFolder + "\\SightWords.xml";
            }
            if (nam == OptionList.kGTOFile)
            {
                m_GraphemeTaughtOrderFile = val;
                if (!File.Exists(m_GraphemeTaughtOrderFile))
                    m_GraphemeTaughtOrderFile = this.PrimerProFolder + "\\GraphemeTaughtOrder.xml";
            }
			if ( nam == OptionList.kPSTFile )
            {
                m_PSTableFile = val;
                if ( !File.Exists(m_PSTableFile) )
                    m_PSTableFile = this.PrimerProFolder + "\\PSTable.xml";
            }
			if ( nam == OptionList.kWLFile )
            {
				m_WordListFile = val;
                
                if (!File.Exists(m_WordListFile))
                    m_WordListFile = "";
            }
            if ( nam == OptionList.kWLType )
            {
                switch (val)
                {
                    case OptionList.kLift:
                        m_WordListFileType = WordList.FileType.Lift;
                        break;
                    case OptionList.kStdFmt:
                        m_WordListFileType = WordList.FileType.StandardFormat;
                        break;
                    default:
                        m_WordListFileType = WordList.FileType.None;
                        break;
                }
            }
            if (nam == OptionList.kTDFile)
            {
                m_TextDataFile = val;
                if (!File.Exists(m_TextDataFile))
                    m_TextDataFile = "";
            }
			if ( nam == OptionList.kDftlFntName )
				m_DefaultFontName = val;
			if ( nam == OptionList.kDfltFntSize )
				m_DefaultFontSize = Convert.ToInt32(val);
			if ( nam == OptionList.kDfltFntStyle )
				m_DefaultFontStyle = this.ConvertStringToFontStyle(val);
			if ( nam == OptionList.kHighlightColor )
				m_HighlightColor = Color.FromName(val);
			if ( nam == OptionList.kViewOrigWord )
				m_ViewOrigWord = Convert.ToBoolean(val);
			if ( nam == OptionList.kViewGlossE )
				m_ViewGlossEnglish = Convert.ToBoolean(val);
			if ( nam == OptionList.kViewGlossN )
				m_ViewGlossNational = Convert.ToBoolean(val);
            if (nam == OptionList.kViewGlossR )
				m_ViewGlossRegional = Convert.ToBoolean(val);
			if ( nam == OptionList.kViewPS )
				m_ViewPS = Convert.ToBoolean(val);
			if ( nam == OptionList.kViewPlural )
				m_ViewPlural = Convert.ToBoolean(val);
			if ( nam == OptionList.kViewCVPattern )
				m_ViewCVPattern = Convert.ToBoolean(val);
			if ( nam == OptionList.kViewSyllBreaks )
				m_ViewSyllBreaks = Convert.ToBoolean(val);
			if ( nam == OptionList.kViewWordNoTone )
				m_ViewWordWithoutTone = Convert.ToBoolean(val);
            if ( nam == OptionList.kViewRoot )
                m_ViewRoot = Convert.ToBoolean(val);
            if ( nam == OptionList.kViewRootCVPattern )
                m_ViewRootCVPattern = Convert.ToBoolean(val);
            if ( nam == OptionList.kViewRootSyllBreaks )
                m_ViewRootSyllBreaks = Convert.ToBoolean(val);
            if ( nam == OptionList.kViewRootNoTone )
				m_ViewRootWithoutTone = Convert.ToBoolean(val);
            if (nam == OptionList.kViewParaSentWord)
                m_ViewParaSentWord = Convert.ToBoolean(val);
            if ( nam == OptionList.kFMRM )
                m_FMRecordMarker = val;
			if ( nam == OptionList.kFMLX )
				m_FMLexicon = val;
			if ( nam == OptionList.kFMGE )
				m_FMGlossEnglish = val;
            if ( nam == OptionList.kFMGN )
				m_FMGlossNational = val;
			if ( nam == OptionList.kFMGR )
				m_FMGlossRegional = val;
			if ( nam == OptionList.kFMPS )
				m_FMPS = val;
			if ( nam == OptionList.kFMPL )
				m_FMPlural = val;
			if ( nam == OptionList.kFMRT )
				m_FMRoot = val;
            if ( nam == OptionList.kLiftVr )
                m_LiftVernacular = val;
            if (nam == OptionList.kLiftGE)
                m_LiftGlossEnglish = val;
            if (nam == OptionList.kLiftGN)
                m_LiftGlossNational = val;
            if (nam == OptionList.kLiftGR)
                m_LiftGlossRegional = val;
            if (nam == OptionList.kSyllNasals)
                m_SyllabicNasals = Convert.ToBoolean(val);
			if ( nam == OptionList.kCVCns)
				m_CVCns = val;
			if ( nam == OptionList.kCVSyllbc)
				m_CVSyllbc = val;
            if (nam == OptionList.kCVAspir)
                m_CVAspir = val;
            if (nam == OptionList.kCVPrensl)
				m_CVPrensl = val;
			if ( nam == OptionList.kCVLablzd)
				m_CVLablzd = val;
			if ( nam == OptionList.kCVPaltzd)
				m_CVPaltzd = val;
			if ( nam == OptionList.kCVVelrzd)
				m_CVVelrzd = val;
			if ( nam == OptionList.kCVVwl)
				m_CVVwl = val;
			if ( nam == OptionList.kCVVwlNsl)
				m_CVVwlNsl = val;
			if ( nam == OptionList.kCVVwlLng)
				m_CVVwlLng = val;
            if (nam == OptionList.kCVVwlDip)
                m_CVVwlDip = val;
            if (nam == OptionList.kCVSyllograph)
                m_CVSyllograph = val;
            if (nam == OptionList.kCVTone)
                m_CVTone = val;
            if (nam == OptionList.kEndPunct)
                m_EndingPunct = val;
            if (nam == OptionList.kGenPunct)
                m_GeneralPunct = val;
            if (nam == OptionList.kMaxSizeGrapheme)
            {
                m_MaxSizeGrapheme = Convert.ToInt32(val);
                if (m_MaxSizeGrapheme < 1) m_MaxSizeGrapheme = 1;
                if (m_MaxSizeGrapheme > 9) m_MaxSizeGrapheme = 9;
            }
            if (nam == OptionList.kImportIgnoreChars)
                m_ImportIgnoreChars = val;
            if (nam == OptionList.kUILanguage)
                m_Lang = val;
            if (nam == OptionList.kSimplifiedMenu)
                m_SimplifiedMenu = Convert.ToBoolean(val);
		}

		public void SaveOptionList(string strFileName)
		{
			XmlTextWriter writer = new XmlTextWriter(strFileName, System.Text.Encoding.UTF8);
			string str = "";
			writer.Formatting = Formatting.Indented;
			writer.WriteStartElement(OptionList.kOptionList);

			writer.WriteElementString(OptionList.kDataFolder, m_DataFolder);
			writer.WriteElementString(OptionList.kTemplateFolder, m_TemplateFolder);

            writer.WriteElementString(OptionList.kGIFile, m_GraphemeInventoryFile);
			writer.WriteElementString(OptionList.kSWFile, m_SightWordsFile);
            writer.WriteElementString(OptionList.kGTOFile, m_GraphemeTaughtOrderFile);
			writer.WriteElementString(OptionList.kPSTFile, m_PSTableFile);
            if (m_WordListFile != "")
            {
                if (m_WordListFile != WordList.kMergeWordList)
                {
                    writer.WriteElementString(OptionList.kWLFile, m_WordListFile);
                    str = m_WordListFileType.ToString();
                    if (str != "")
                        writer.WriteElementString(OptionList.kWLType, str);
                }
            }
            if (m_TextDataFile != "")
            {
                if (m_TextDataFile != TextData.kMergeTextData)
                    writer.WriteElementString(OptionList.kTDFile, m_TextDataFile);
            }
			writer.WriteElementString(OptionList.kDftlFntName, m_DefaultFontName);

			str = m_DefaultFontSize.ToString();
			if ( str != "" )
				writer.WriteElementString(OptionList.kDfltFntSize, str);
			str = m_DefaultFontStyle.ToString();
			if ( str != "" )
				writer.WriteElementString(OptionList.kDfltFntStyle, str);
			str = m_HighlightColor.Name;
			if ( str != "")
				writer.WriteElementString(OptionList.kHighlightColor, str);

			str = m_ViewOrigWord.ToString();
			writer.WriteElementString(OptionList.kViewOrigWord, str);
			str = m_ViewGlossEnglish.ToString();
			writer.WriteElementString(OptionList.kViewGlossE, str);
			str = m_ViewGlossNational.ToString();
			writer.WriteElementString(OptionList.kViewGlossN, str);
			str = m_ViewGlossRegional.ToString();
			writer.WriteElementString(OptionList.kViewGlossR, str);
			str = m_ViewPS.ToString();
			writer.WriteElementString(OptionList.kViewPS, str);
			str = m_ViewPlural.ToString();
			writer.WriteElementString(OptionList.kViewPlural, str);
			str = m_ViewCVPattern.ToString();
			writer.WriteElementString(OptionList.kViewCVPattern, str);
			str = m_ViewSyllBreaks.ToString();
			writer.WriteElementString(OptionList.kViewSyllBreaks, str);
			str = m_ViewWordWithoutTone.ToString();
			writer.WriteElementString(OptionList.kViewWordNoTone, str);
            str = m_ViewRoot.ToString();
            writer.WriteElementString(OptionList.kViewRoot, str);
            str = m_ViewRootCVPattern.ToString();
            writer.WriteElementString(OptionList.kViewRootCVPattern, str);
            str = m_ViewRootSyllBreaks.ToString();
            writer.WriteElementString(OptionList.kViewRootSyllBreaks, str);
            str = m_ViewRootWithoutTone.ToString();
			writer.WriteElementString(OptionList.kViewRootNoTone, str);
            str = m_ViewParaSentWord.ToString();
            writer.WriteElementString(OptionList.kViewParaSentWord, str);

            writer.WriteElementString(OptionList.kFMRM, m_FMRecordMarker);
			writer.WriteElementString(OptionList.kFMLX, m_FMLexicon);
			writer.WriteElementString(OptionList.kFMGE, m_FMGlossEnglish);
			writer.WriteElementString(OptionList.kFMGN, m_FMGlossNational);
			writer.WriteElementString(OptionList.kFMGR, m_FMGlossRegional);
			writer.WriteElementString(OptionList.kFMPS, m_FMPS);
			writer.WriteElementString(OptionList.kFMPL, m_FMPlural);
			writer.WriteElementString(OptionList.kFMRT, m_FMRoot);
            writer.WriteElementString(OptionList.kLiftVr, m_LiftVernacular);
            writer.WriteElementString(OptionList.kLiftGE, m_LiftGlossEnglish);
            writer.WriteElementString(OptionList.kLiftGN, m_LiftGlossNational);
            writer.WriteElementString(OptionList.kLiftGR, m_LiftGlossRegional);
            writer.WriteElementString(OptionList.kSyllNasals, m_SyllabicNasals.ToString());

			writer.WriteElementString(OptionList.kCVCns, m_CVCns);
			writer.WriteElementString(OptionList.kCVSyllbc, m_CVSyllbc);
            writer.WriteElementString(OptionList.kCVAspir, m_CVAspir);
			writer.WriteElementString(OptionList.kCVPrensl, m_CVPrensl);
			writer.WriteElementString(OptionList.kCVLablzd, m_CVLablzd);
			writer.WriteElementString(OptionList.kCVPaltzd, m_CVPaltzd);
			writer.WriteElementString(OptionList.kCVVelrzd, m_CVVelrzd);
			writer.WriteElementString(OptionList.kCVVwl, m_CVVwl);
			writer.WriteElementString(OptionList.kCVVwlNsl, m_CVVwlNsl);
			writer.WriteElementString(OptionList.kCVVwlLng, m_CVVwlLng);
            writer.WriteElementString(OptionList.kCVVwlDip, m_CVVwlDip);
            writer.WriteElementString(OptionList.kCVSyllograph, m_CVSyllograph);
            writer.WriteElementString(OptionList.kCVTone, m_CVTone);

            writer.WriteElementString(OptionList.kEndPunct, m_EndingPunct);
            writer.WriteElementString(OptionList.kGenPunct, m_GeneralPunct);

            str = m_MaxSizeGrapheme.ToString();
            if (str != "")
                writer.WriteElementString(OptionList.kMaxSizeGrapheme, str);
            writer.WriteElementString(OptionList.kImportIgnoreChars, m_ImportIgnoreChars);
            if (m_ImportReplacementList != null)
            {
                for (int i = 0; i < m_ImportReplacementList.ListCount(); i++)
                {
                    writer.WriteStartElement(OptionList.kImportReplacementList);
                    str = m_ImportReplacementList.GetReplaceString(i);
                    writer.WriteAttributeString(OptionList.kReplace, str);
                    str = m_ImportReplacementList.GetWithString(i);
                    writer.WriteAttributeString(OptionList.kWith, str);
                    writer.WriteEndElement();
                }
            }

            writer.WriteElementString(OptionList.kUILanguage, m_Lang);
            writer.WriteElementString(OptionList.kSimplifiedMenu, m_SimplifiedMenu.ToString());

			writer.WriteEndElement();
			writer.Close();
		}

        public Font GetDefaultFont()
        {
            string strFont = this.DefaultFontName;
            float emSize = this.DefaultFontSize;
            FontStyle style = this.DefaultFontStyle;
            Font fnt = new Font(strFont, emSize, style);
            return fnt;
        }

        public FontStyle ConvertStringToFontStyle(string strStyle)
		{
			FontStyle style = FontStyle.Regular;
			string str = "";
			int nBeg = 0;
			int nEnd = 0;
	
			do
			{
				nEnd = strStyle.IndexOf(",", nBeg);
				if (nEnd < 0)
					nEnd = strStyle.Length;
				str = strStyle.Substring(nBeg, nEnd-nBeg).Trim();
				if (str != "")
				{
					switch (str)
					{
						case "Bold":
							style = style + 1;
							break;
						case "Italic":
							style = style + 2;
							break;
						case "Strikeout":
							style = style + 8;
							break;
						case "Underline":
							style = style + 4;
							break;
						default:
							style = style + 0;
							break;
					}
					nBeg = nEnd +1;
				}
				else str = "";
			}
			while (nBeg < strStyle.Length); 
			return style;
		}

	}
}

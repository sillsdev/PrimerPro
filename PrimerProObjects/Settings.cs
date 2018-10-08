using System;
using System.Windows.Forms;
using System.IO;
using GenLib;
using StandardFormatLib;
using PrimerProLocalization;

namespace PrimerProObjects
{
	/// <summary>
	/// Summary description for Settings.
	/// </summary>
	public class Settings 
	{
        private ProjectInfo m_ProjInfo;              //Project Info
        private string m_strAppFolder;		        //Application folder
		private string m_strPrimerProFolder;	//PrimePro Folder
        private string m_strOptionsFile;	        //Options file
		private string m_strHelpFile;		            //Help file
		private System.Drawing.Printing.PageSettings m_PageSettings = null;	//Application page settings
		private OptionList m_OptionsSettings = null;	//Application option settings
        private GraphemeInventory m_GraphemeInventory = null;	//Application grapheme inventory
		private SightWords m_SightWords = null;		//Application site words list
        private GraphemeTaughtOrder m_GraphemesTaught;  //Application graphemes taught order list
		private PSTable m_PSTable = null;			//Application parts of Speech table
        private LocalizationTable m_LocalizationTable;  //Application Localization Table;

		private WordList m_WordList;		//Imported Word List
		private TextData m_TextData;		//Imported Text Data
		private bool m_SearchInsertionResults;		//Mode = Results
		private bool m_SearchInsertionDefinitions;	//Mode = Definitions

        //private const string kOptionsFile = "\\OptionList.xml";
        private const string kHelpFile = "\\PrimerPro.chm";
        private const string kCRTemplate = "\\ConsonantReportTemplate.rtf";
        private const string kPPRTemplate = "\\PrimerProgressionReportTemplate.rtf";
        private const string kVRTemplate = "\\VowelReportTemplate.rtf";
        private const string kDfltGI = "\\DefaultGraphemeInventory.xml";
        private const string kDfltPST = "\\DefaultPSTable.xml";
        private const string kLocalizationFile = "\\PrimerProLocalization.xml";
        
        public Settings()
        {
            m_ProjInfo = new ProjectInfo();
            m_strAppFolder = Directory.GetCurrentDirectory();
            m_strPrimerProFolder = m_ProjInfo.PrimerProFolder;          //PrimerPro Folder
            if (!Directory.Exists(m_strPrimerProFolder))
                Directory.CreateDirectory(m_strPrimerProFolder);

            // if templates and xml files do not exist in PrimerPro folder, copy them from App folder
            //if (!File.Exists(m_strPrimerProFolder + Settings.kCRTemplate))
            //    File.Copy(m_strAppFolder + Settings.kCRTemplate,  m_strPrimerProFolder + Settings.kCRTemplate);
            //if (!File.Exists(m_strPrimerProFolder + Settings.kPPRTemplate))
            //    File.Copy(m_strAppFolder + Settings.kPPRTemplate,
            //        m_strPrimerProFolder + Settings.kPPRTemplate);
            //if (!File.Exists(m_strPrimerProFolder + Settings.kVRTemplate))
            //    File.Copy(m_strAppFolder + Settings.kVRTemplate,
            //        m_strPrimerProFolder + Settings.kVRTemplate);
            //if (!File.Exists(m_strPrimerProFolder + Settings.kDfltGI))
            //    File.Copy(m_strAppFolder + Settings.kDfltGI,
            //        m_strPrimerProFolder + Settings.kDfltGI);
            //if (!File.Exists(m_strPrimerProFolder + Settings.kDfltPST))
            //    File.Copy(m_strAppFolder + Settings.kDfltPST,
            //        m_strPrimerProFolder + Settings.kDfltPST);
            //if (!File.Exists(m_strPrimerProFolder + Settings.kDfltPST))
            //    File.Copy(m_strAppFolder + Settings.kDfltPST,
            //        m_strPrimerProFolder + Settings.kDfltPST);
            //if (!File.Exists(m_strPrimerProFolder + Settings.kLocalizationFile))
            //    File.Copy(m_strAppFolder + Settings.kLocalizationFile,
            //        m_strPrimerProFolder + Settings.kLocalizationFile);
 
            m_strOptionsFile = m_ProjInfo.OptionsFile;                  //Options File
            m_strHelpFile = m_strAppFolder + Settings.kHelpFile;		//Help File
            m_OptionsSettings = new OptionList();
            m_PageSettings = new System.Drawing.Printing.PageSettings();
            m_GraphemeInventory = new GraphemeInventory(this);
            m_GraphemesTaught = new GraphemeTaughtOrder(this);
            m_PSTable = new PSTable(this);
            m_SightWords = new SightWords(this);
            m_TextData = new TextData(this);
            m_WordList = new WordList(this);
            m_LocalizationTable = new LocalizationTable();
            m_SearchInsertionResults = true;
            m_SearchInsertionDefinitions = false;
        }

		public Settings(ProjectInfo info)
		{
            m_ProjInfo = info;
            m_strAppFolder = Directory.GetCurrentDirectory();
            m_strPrimerProFolder = m_ProjInfo.PrimerProFolder;          //PrimerPro Folder
			if ( !Directory.Exists(m_strPrimerProFolder) )
				Directory.CreateDirectory(m_strPrimerProFolder);
            m_strOptionsFile = m_ProjInfo.OptionsFile;                  //Options File
			m_strHelpFile =  m_strAppFolder + Settings.kHelpFile;		//Help File
            m_OptionsSettings = new OptionList();
            m_PageSettings = new System.Drawing.Printing.PageSettings();
            m_GraphemeInventory = new GraphemeInventory(this);
            m_GraphemesTaught = new GraphemeTaughtOrder(this);
            m_PSTable = new PSTable(this);
            m_SightWords = new SightWords(this);
            m_TextData = new TextData(this);
            m_WordList = new WordList(this);
            m_LocalizationTable = new LocalizationTable();
            m_SearchInsertionResults = true;
			m_SearchInsertionDefinitions = false;
 		}

        public ProjectInfo ProjInfo
        {
            get { return m_ProjInfo; }
        }

        public string PrimerProFolder
        {
            get { return m_strPrimerProFolder; }
            set { m_strPrimerProFolder = value; }
        }

        public void LoadOptions()
        // Load Options Settings
        {
            m_OptionsSettings = new OptionList(m_strPrimerProFolder, m_strOptionsFile);
            if (!m_OptionsSettings.LoadFromFile(m_strOptionsFile))
            {
                //MessageBox.Show("Options File does not exist - Will use defaults settings");
                string strText = this.LocalizationTable.GetMessage("Settings1");
                if (strText == "")
                    strText = "Options File does not exist - Will use defaults settings";
                MessageBox.Show(strText);
            }
        }

        public void LoadGraphemeInventory()
        {
            m_GraphemeInventory = new GraphemeInventory(this);
            if (!m_GraphemeInventory.LoadFromFile(this.OptionSettings.GraphemeInventoryFile))
            {
                //MessageBox.Show("Grapheme Inventory file does not exist - will create one");
                string strText = this.LocalizationTable.GetMessage("Settings2");
                if (strText == "")
                    strText = "Grapheme Inventory file does not exist - will create one";
                MessageBox.Show(strText);
                m_GraphemeInventory.SaveToFile(this.OptionSettings.GraphemeInventoryFile);
                m_GraphemeInventory.FileName = this.OptionSettings.GraphemeInventoryFile;
            }
        }

        public void LoadGraphemesTaught()
        {
            m_GraphemesTaught = new GraphemeTaughtOrder(this);
            if (!m_GraphemesTaught.LoadFromFile(this.OptionSettings.GraphemeTaughtOrderFile))
            {
                //MessageBox.Show("Grapheme Taught Order file does not exist - will create one");
                string strText = this.LocalizationTable.GetMessage("Settings3");
                if (strText == "")
                    strText = "Grapheme Taught Order file does not exist - will create one";
                MessageBox.Show(strText);
                m_GraphemesTaught.SaveToFile(this.OptionSettings.GraphemeTaughtOrderFile);
                m_GraphemesTaught.FileName = this.OptionSettings.GraphemeTaughtOrderFile;
            }
        }

        public void LoadSightWords()
        {
            m_SightWords = new SightWords(this);
            if (!m_SightWords.LoadFromFile(this.OptionSettings.SightWordsFile))
            {
                //MessageBox.Show("Sight Words file does not exist - will create one");
                string strText = this.LocalizationTable.GetMessage("Settings4");
                if (strText == "")
                    strText = "Sight Words file does not exist - will create one";
                MessageBox.Show(strText);
                m_SightWords.SaveToFile(this.OptionSettings.SightWordsFile);
                m_SightWords.FileName = this.OptionSettings.SightWordsFile;
            }
        }

        public void LoadTextData()
        {
            m_TextData = new TextData(this);
            if (m_OptionsSettings.TextDataFile != "")
            {
                if (m_TextData.LoadFile(m_OptionsSettings.TextDataFile))
                    m_TextData.FileName = m_OptionsSettings.TextDataFile;
                else m_TextData.FileName = "";
            }
        }

        public void LoadWordList()
        {
            m_WordList = new WordList(this);

            if (m_OptionsSettings.WordListFile != "")
            {
                switch (m_OptionsSettings.WordListFileType)
                {
                    case WordList.FileType.Lift:
                        //Lift support
                        m_WordList.FileName = m_OptionsSettings.WordListFile;
                        m_WordList.Type = m_OptionsSettings.WordListFileType;
                        m_WordList = m_WordList.LoadWordsFromLift();
                        break;
                    case WordList.FileType.StandardFormat:
                        if (m_WordList.SFFile.LoadFile(m_OptionsSettings.WordListFile, m_OptionsSettings.FMRecordMarker))
                        {
                            m_WordList = m_WordList.LoadWordsFromSF();
                            m_WordList.SFFile.FileName = m_OptionsSettings.WordListFile;
                            m_WordList.FileName = m_OptionsSettings.WordListFile;
                            m_WordList.Type = m_OptionsSettings.WordListFileType;
                        }
                        break;
                    default:
                        if (m_WordList.SFFile.LoadFile(m_OptionsSettings.WordListFile, m_OptionsSettings.FMRecordMarker))
                        {
                            m_WordList = m_WordList.LoadWordsFromSF();
                            m_WordList.SFFile.FileName = m_OptionsSettings.WordListFile;
                            m_WordList.Type = m_OptionsSettings.WordListFileType;
                        }
                        break;
                }
            }
        }

        public bool LoadPartsOfSpeech()
        {
            bool fReturn = true;
            m_PSTable = new PSTable(this);
            if (!m_PSTable.LoadFromFile(this.OptionSettings.PSTableFile))
            {
                //MessageBox.Show("Parts of Speech table does not exist");
                string strText = this.LocalizationTable.GetMessage("Settings5");
                if (strText == "")
                    strText = "Parts of Speech table does not exist";
                MessageBox.Show(strText);
                fReturn = false;
            }
            return fReturn;
        }

        public string GetAppFolder()
		{
			return m_strAppFolder;
		}

		public string GetPrimerProFolder()
		{
			return m_strPrimerProFolder;
		}

		public string GetHelpFile()
		{
			return m_strHelpFile;
		}

		public string GetOptionsFile()
		{
			return m_strOptionsFile;
		}

		public System.Drawing.Printing.PageSettings PageSettings
		{
			get {return m_PageSettings;}
			set {m_PageSettings = value;}
		}

		public OptionList OptionSettings
		{
			get {return m_OptionsSettings;}
			set {m_OptionsSettings = value;}
		}

		public GraphemeInventory GraphemeInventory
		{
			get {return m_GraphemeInventory;}
			set {m_GraphemeInventory = value;}
		}

		public SightWords SightWords
		{
			get {return m_SightWords;}
			set {m_SightWords = value;}
		}

        public GraphemeTaughtOrder GraphemesTaught
        {
            get { return m_GraphemesTaught; }
            set { m_GraphemesTaught = value; }
        }

        public PSTable PSTable
		{
			get {return m_PSTable;}
			set {m_PSTable = value;}
		}

		public WordList WordList
		{
			get {return m_WordList;}
			set {m_WordList = value;}
		}

		public TextData TextData
		{
			get {return m_TextData;}
			set {m_TextData = value;}
		}

        public LocalizationTable LocalizationTable
        {
            get {return m_LocalizationTable;}
            set { m_LocalizationTable = value; }
        }

		public bool SearchInsertionResults
		{
			get {return m_SearchInsertionResults;}
			set {m_SearchInsertionResults = value;}
		}

		public bool SearchInsertionDefinitions
		{
			get {return m_SearchInsertionDefinitions;}
			set {m_SearchInsertionDefinitions = value;}
		}

	}
}

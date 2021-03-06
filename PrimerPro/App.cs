using System;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.Xml;
using System.Threading;
using PrimerProObjects;
using PrimerProSearch;
using PrimerProForms;
using PrimerProLocalization;
using GenLib;
using StandardFormatLib;
using System.Web;
using System.Reflection;


namespace PrimerPro
{
	/// <summary>
	/// PrimerPro - main program with main menu.
	/// </summary>
	/// 


	public class AppWindow: System.Windows.Forms.Form
	{
		public static AppWindow pWindow;	//parent window fpb
        private static string strApp;       //Application Name
        private string strProj;             //Project Name
        private ProjectInfo m_ProjInfo;     //Project Information
        private int m_ViewCntr;				//child window fpb (view) counter
		private int m_SearchCntr;			//search counter
		private ArrayList m_SearchList;		//search list
		private Settings m_Settings;		//application settings
		private string m_PSTFileName;		//parts of Speech file name
        //private LocalizationTable m_LocalizationTable;      //Localization Table for En/Fr
  
        //private const string kReady = "...Ready...";
        private const string kPrimerPro = "PrimerPro";
        //private const string kSaveTDQuestion = "Do you want to save the merged text data?";
        //private const string kSaveWLQuestion = "Do you want to save the merged word list?";
        //private const string kFormatting = "Formatting";
        private const string kBackSlash = "\\";
        private const string kGraphemeInventoryName = "GraphemeInventory.xml";
        private const string kSightWordsName = "SightWords.xml";
        private const string kGraphemesTaughtName = "GraphemeTaughtOrder.xml";
        private const string kPSTableName = "PSTable.xml";
        private const string kDefaultPSTableName = "DefaultPSTable.xml";
        private const string kDefaultGIName = "DefaultGraphemeInventory.xml";
        private const string kPLName = "PackageList.xml";
        private const string kData = "DataFolder";
        private const string kTemplate = "TemplateFolder";
        private const string kDefaultLocalizationName = "PrimerProLocalization.xml";
        private const string kDefaultFontName = "Arial";

        private const string kEnglishLocalizationName = "PrimerProLocalization-en.xml";
        private const string kFrenchLocalizationName = "PrimerProLocalization-fr.xml";
        private const string kSpanishLocalizationName = "PrimerProLocalization-sp.xml";
        private const string kOtherLocalizationName = "PrimerProLocalization-other.xml";

		private System.Windows.Forms.MainMenu menuTop;
		private System.Windows.Forms.MenuItem menuFile;
		private System.Windows.Forms.MenuItem menuFileNew;
		private System.Windows.Forms.MenuItem menuFileOpen;
		private System.Windows.Forms.MenuItem menuFileClose;
		private System.Windows.Forms.MenuItem menuFileSave;
		private System.Windows.Forms.MenuItem menuFileAs;
		private System.Windows.Forms.MenuItem menuSep01;
		private System.Windows.Forms.MenuItem menuFilePrint;
		private System.Windows.Forms.MenuItem menuFilePreview;
		private System.Windows.Forms.MenuItem menuFileSetup;
		private System.Windows.Forms.MenuItem menuSep03;
		private System.Windows.Forms.MenuItem menuExit;

		private System.Windows.Forms.MenuItem menuEdit;
		private System.Windows.Forms.MenuItem menuEditUndo;
		private System.Windows.Forms.MenuItem menuSep10;
		private System.Windows.Forms.MenuItem menuEditCut;
		private System.Windows.Forms.MenuItem menuEditCopy;
		private System.Windows.Forms.MenuItem menuEditPaste;
		private System.Windows.Forms.MenuItem menuEditSelect;
		private System.Windows.Forms.MenuItem menuSep11;
		private System.Windows.Forms.MenuItem menuEditFind;
		private System.Windows.Forms.MenuItem menuEditNext;
		private System.Windows.Forms.MenuItem menuEditReplace;

		private System.Windows.Forms.MenuItem menuView;
		private System.Windows.Forms.MenuItem menuViewToolbar;
		private System.Windows.Forms.MenuItem menuViewStatus;
		private System.Windows.Forms.MenuItem menuSep20;
		private System.Windows.Forms.MenuItem menuViewMode;
		private System.Windows.Forms.MenuItem menuViewShow;
		private System.Windows.Forms.MenuItem menuViewHide;
		private System.Windows.Forms.MenuItem menuViewClear;
		private System.Windows.Forms.MenuItem menuViewUnprocessed;
		private System.Windows.Forms.MenuItem menuSep21;
		private System.Windows.Forms.MenuItem menuViewWordList;
		private System.Windows.Forms.MenuItem menuViewTextData;
        private System.Windows.Forms.MenuItem menuViewInventory;
		private System.Windows.Forms.MenuItem menuViewPS;
		private System.Windows.Forms.MenuItem menuViewSite;

		private System.Windows.Forms.MenuItem menuFormat;
		private System.Windows.Forms.MenuItem menuFormatFont;
		private System.Windows.Forms.MenuItem menuFormatColor;
        private System.Windows.Forms.MenuItem menuFormatWrap;

		private System.Windows.Forms.MenuItem menuReport;
		private System.Windows.Forms.MenuItem menuReportPrimer;
		private System.Windows.Forms.MenuItem menuReportGenerate;
		private System.Windows.Forms.MenuItem menuSep35;
		private System.Windows.Forms.MenuItem menuReportEdit;

		private System.Windows.Forms.MenuItem menuSearch;
		private System.Windows.Forms.MenuItem menuSearchWord;
		private System.Windows.Forms.MenuItem menuSearchWordGrapheme;
		private System.Windows.Forms.MenuItem menuSearchWordBuild;
		private System.Windows.Forms.MenuItem menuSearchWordAdvanced;
		private System.Windows.Forms.MenuItem menuSearchWordContext;
		private System.Windows.Forms.MenuItem menuSearchWordSyllable;
		private System.Windows.Forms.MenuItem menuSearchWordTone;
		private System.Windows.Forms.MenuItem menuSearchText;
		private System.Windows.Forms.MenuItem menuSearchTextWord;
		private System.Windows.Forms.MenuItem menuSearchTextPhrases;
		private System.Windows.Forms.MenuItem menuSearchTextResidue;
		private System.Windows.Forms.MenuItem menuSearchTextSight;
		private System.Windows.Forms.MenuItem menuSearchTextTone;
		private System.Windows.Forms.MenuItem menuSep40;
		private System.Windows.Forms.MenuItem menuSearchVowel;
		private System.Windows.Forms.MenuItem menuSearchConsonant;
        private System.Windows.Forms.MenuItem menuSearchTone;

		private System.Windows.Forms.MenuItem menuTools;
		private System.Windows.Forms.MenuItem menuToolsWord;
		private System.Windows.Forms.MenuItem menuToolsWordImport;
		private System.Windows.Forms.MenuItem menuToolsWordMerge;
		private System.Windows.Forms.MenuItem menuToolsWordExport;
		private System.Windows.Forms.MenuItem menuSep55;
		private System.Windows.Forms.MenuItem menuToolsWordCheck;
		private System.Windows.Forms.MenuItem menuToolsText;
		private System.Windows.Forms.MenuItem menuToolsTextMerge;
		private System.Windows.Forms.MenuItem menuToolsTextImport;
		private System.Windows.Forms.MenuItem menuToolsTextExport;
		private System.Windows.Forms.MenuItem menuSep56;
		private System.Windows.Forms.MenuItem menuToolsTextCheckGI;
		private System.Windows.Forms.MenuItem menuToolsTextCheckWL;
		private System.Windows.Forms.MenuItem menuToolsInventory;
		private System.Windows.Forms.MenuItem menuToolsInventoryConsonants;
		private System.Windows.Forms.MenuItem menuToolsInventoryVowels;
		private System.Windows.Forms.MenuItem menuToolsInventoryTone;
		private System.Windows.Forms.MenuItem menuToolsSight;
		private System.Windows.Forms.MenuItem menuToolsSightUpdate;
		private System.Windows.Forms.MenuItem menuToolsSightCheckWL;
		private System.Windows.Forms.MenuItem menuSep50;
		private System.Windows.Forms.MenuItem menuToolsOptions;

		private System.Windows.Forms.MenuItem menuWindow;
		private System.Windows.Forms.MenuItem menuWindowCascade;
		private System.Windows.Forms.MenuItem menuWindowTileH;
		private System.Windows.Forms.MenuItem menuWindowTileV;

		private System.Windows.Forms.MenuItem menuHelp;
		private System.Windows.Forms.MenuItem menuHelpHelp;
		private System.Windows.Forms.MenuItem menuSep70;
		private System.Windows.Forms.MenuItem menuHelpAbout;
		
		private System.Windows.Forms.MenuItem menuTest;
		private System.Windows.Forms.MenuItem menuTest1;

		private System.Windows.Forms.ImageList imageListPP;
		private System.Windows.Forms.ToolBar tbApp;
		private System.Windows.Forms.ToolBarButton tbbNew;
		private System.Windows.Forms.ToolBarButton tbbOpen;
		private System.Windows.Forms.ToolBarButton tbbSave;
		private System.Windows.Forms.ToolBarButton tbbPreview;
		private System.Windows.Forms.ToolBarButton tbbPrint;
		private System.Windows.Forms.ToolBarButton tbbHelp;
		private System.Windows.Forms.ToolBarButton tbbCut;
		private System.Windows.Forms.ToolBarButton tbbCopy;
		private System.Windows.Forms.ToolBarButton tbbPaste;
		private System.Windows.Forms.ToolBarButton tbbFind;
		private System.Windows.Forms.ToolBarButton tbbOptions;
		private System.Windows.Forms.MenuItem menuEditClear;
		private System.Windows.Forms.MenuItem menuSearchWordCoccur;
		private System.Windows.Forms.MenuItem menuSearchWordOrder;
		private System.Windows.Forms.MenuItem menuSearchTextOrder;
        private StatusStrip ssApp;
        private ToolStripStatusLabel tsslWordList;
        private ToolStripStatusLabel tsslTextData;
        private ToolStripStatusLabel tsslWnd;
        private ToolStripStatusLabel tsslInfo;
        private MenuItem menuSearchTextGrapheme;
        private MenuItem menuSearchWordFrequency;
        private MenuItem menuSearchTextFrequency;
        private MenuItem menuSearchTextCount;
        private MenuItem menuSearchWordGeneral;
        private MenuItem menuToolsOrder;
        private MenuItem menuToolsOrderUpdate;
        private MenuItem menuToolsOrderCheck;
        private MenuItem menuViewGraphemes;
        private MenuItem menuToolsSightSave;
        private MenuItem menuToolsOrderSave;
        private MenuItem menuToolsInventorySave;
        private MenuItem menuReportConsonant;
        private MenuItem menuReportVowel;
        private MenuItem menuTest2;
        private MenuItem menuTest3;
        private ToolStripProgressBar tspbPrimerPro;
        private MenuItem menuToolsInventoryClear;
        private MenuItem menuToolsParts;
        private MenuItem menuToolsPartsUpdate;
        private MenuItem menuSearchWordPairs;
        private MenuItem menuToolsWordUnload;
        private MenuItem menuToolsTextUnload;
        private MenuItem menuToolsTextBuildWL;
        private MenuItem menuSearchTextBuild;
        private MenuItem menuSearchTextNew;
        private MenuItem menuToolsWordImportSF;
        private MenuItem menuToolsWordImportLIFT;
        private MenuItem menuToolsWordReimport;
        private MenuItem menuToolsTextReimport;
        private MenuItem menuSearchTextSyllable;
        private MenuItem menuTestBrowse;
        private MenuItem menuToolsPartsSave;
        private MenuItem menuSep02;
        private MenuItem menuFileProjNew;
        private MenuItem menuFileProjSelect;
        private MenuItem menuToolsInventoryInit;
        private MenuItem menuTestTemp;
        private MenuItem menuToolsPartsInit;
        private MenuItem menuFileProjExport;
        private MenuItem menuFileProjImport;
        private MenuItem menuToolsInventorySyllograph;
        private MenuItem menuSearchSyllograph;
        private MenuItem menuFileProjDelete;
        private MenuItem menuHelpSetup;
        private MenuItem menuHelpPrimer;
        private MenuItem menuSearchWordSyllograph;
        private MenuItem menuSearchTextSyllograph;
        private MenuItem menuToolsInventorySyllabary;
        private MenuItem menuToolsInventoryInitWL;
        private MenuItem menuToolsInventoryInitTD;
        private MenuItem menuToolsInventoryInitPG;
        private MenuItem menuSearchTextGeneral;
        private MenuItem menuHelpNew;
        private System.ComponentModel.IContainer components;

		public AppWindow()
		{
			pWindow = this;
            strApp = kPrimerPro;
            strProj = "";
			InitializeComponent();
#if (DEBUG)
            this.menuTest.Visible = true;
#endif

            m_ProjInfo = new ProjectInfo();
            m_Settings = new Settings();
            m_ViewCntr = 0;					            //Window (active document) counter
            m_SearchCntr = 0;				            //Search counter 
            m_SearchList = new ArrayList();	            //List of active searches
            m_PSTFileName = "";

            string strMsg = "";
 
            if (Environment.GetEnvironmentVariable(AppWindow.kPrimerPro, EnvironmentVariableTarget.User) != null)
            {
                strProj = Environment.GetEnvironmentVariable(AppWindow.kPrimerPro, EnvironmentVariableTarget.User);
                this.ProjInfo.BuildProjectInfo(strProj);
                if (File.Exists(this.ProjInfo.FileName))
                {
                    if (this.ProjInfo.LoadInfo(this.ProjInfo.FileName))
                    {

                        pWindow.Text = AppWindow.kPrimerPro + " - " + m_ProjInfo.ProjectName;
                        this.SetupProject();
                        m_Settings.LocalizationTable = this.GetLocalizationTable();

                        //MessageBox.Show(m_ProjInfo.ProjectName + " Project has been loaded", AppWindow.kPrimerPro);
                        strMsg = m_Settings.LocalizationTable.GetMessage("App1");
                        if (strMsg == "")
                            strMsg = "Project has been loaded";
                        MessageBox.Show(m_ProjInfo.ProjectName + Constants.Space + strMsg,
                            AppWindow.kPrimerPro);
                    }
                    else
                    {
                        //MessageBox.Show(m_ProjInfo.ProjectName +
                        //    " Project has failed to load! You will need to create or select a project",
                        //    AppWindow.kPrimerPro);
                        strMsg = m_Settings.LocalizationTable.GetMessage("App2");
                        if (strMsg == "")
                            strMsg = "Project has failed to load! You will need to create or select a project";
                        MessageBox.Show(m_ProjInfo.ProjectName + Constants.Space + strMsg,
                            AppWindow.kPrimerPro);
                        Environment.SetEnvironmentVariable(AppWindow.kPrimerPro, "", EnvironmentVariableTarget.User);
                    }
                }
                else
                {
                    //MessageBox.Show(m_ProjInfo.ProjectName +
                    //    "Project does not exist!  You will need to create or select a project",
                    //    AppWindow.kPrimerPro);
                    strMsg = m_Settings.LocalizationTable.GetMessage("App3");
                    if (strMsg == "")
                        strMsg = "Project does not exist!  You will need to create or select a project";
                    strMsg = strMsg + Constants.Space + m_ProjInfo.ProjectName; 
                    MessageBox.Show(strMsg, AppWindow.kPrimerPro);
                    m_ProjInfo = new ProjectInfo();
                    Environment.SetEnvironmentVariable(AppWindow.kPrimerPro, "", EnvironmentVariableTarget.User);
                }
            }
            else
            {
                //MessageBox.Show("Project does not exist!  You will need to create or select a project", AppWindow.kPrimerPro);
                strMsg = m_Settings.LocalizationTable.GetMessage("App3");
                if (strMsg == "")
                    strMsg = "Project does not exist!  You will need to create or select a project";
                MessageBox.Show(strMsg, AppWindow.kPrimerPro);
                if (File.Exists(m_ProjInfo.OptionsFile))
                    m_Settings.LoadOptions();
                else
                {
                    OptionList ol = new OptionList(m_ProjInfo.PrimerProFolder, m_ProjInfo.OptionsFile,
                    m_Settings.LocalizationTable, OptionList.kEnglish);
                    m_Settings.OptionSettings = ol;
                }
            }

            //Update main menu
            UpdateMenuForLocalization();
            if (this.Settings.OptionSettings.SimplifiedMenu)
                UpdateMenuForSimplified();

            //Update status bar
            this.UpdStatusBarTD();
            this.UpdStatusBarWL();
            this.UpdStatusBarWnd();
            strMsg = m_Settings.LocalizationTable.GetMessage("App80");
            if (strMsg == "")
                strMsg = "…Ready…";
            this.UpdStatusBarInfo(strMsg);

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppWindow));
            this.menuTop = new System.Windows.Forms.MainMenu(this.components);
            this.menuFile = new System.Windows.Forms.MenuItem();
            this.menuFileNew = new System.Windows.Forms.MenuItem();
            this.menuFileOpen = new System.Windows.Forms.MenuItem();
            this.menuFileClose = new System.Windows.Forms.MenuItem();
            this.menuFileSave = new System.Windows.Forms.MenuItem();
            this.menuFileAs = new System.Windows.Forms.MenuItem();
            this.menuSep01 = new System.Windows.Forms.MenuItem();
            this.menuFileProjNew = new System.Windows.Forms.MenuItem();
            this.menuFileProjSelect = new System.Windows.Forms.MenuItem();
            this.menuFileProjDelete = new System.Windows.Forms.MenuItem();
            this.menuFileProjExport = new System.Windows.Forms.MenuItem();
            this.menuFileProjImport = new System.Windows.Forms.MenuItem();
            this.menuSep02 = new System.Windows.Forms.MenuItem();
            this.menuFilePrint = new System.Windows.Forms.MenuItem();
            this.menuFilePreview = new System.Windows.Forms.MenuItem();
            this.menuFileSetup = new System.Windows.Forms.MenuItem();
            this.menuSep03 = new System.Windows.Forms.MenuItem();
            this.menuExit = new System.Windows.Forms.MenuItem();
            this.menuEdit = new System.Windows.Forms.MenuItem();
            this.menuEditUndo = new System.Windows.Forms.MenuItem();
            this.menuSep10 = new System.Windows.Forms.MenuItem();
            this.menuEditCut = new System.Windows.Forms.MenuItem();
            this.menuEditCopy = new System.Windows.Forms.MenuItem();
            this.menuEditPaste = new System.Windows.Forms.MenuItem();
            this.menuEditSelect = new System.Windows.Forms.MenuItem();
            this.menuEditClear = new System.Windows.Forms.MenuItem();
            this.menuSep11 = new System.Windows.Forms.MenuItem();
            this.menuEditFind = new System.Windows.Forms.MenuItem();
            this.menuEditNext = new System.Windows.Forms.MenuItem();
            this.menuEditReplace = new System.Windows.Forms.MenuItem();
            this.menuView = new System.Windows.Forms.MenuItem();
            this.menuViewToolbar = new System.Windows.Forms.MenuItem();
            this.menuViewStatus = new System.Windows.Forms.MenuItem();
            this.menuSep20 = new System.Windows.Forms.MenuItem();
            this.menuViewMode = new System.Windows.Forms.MenuItem();
            this.menuViewShow = new System.Windows.Forms.MenuItem();
            this.menuViewHide = new System.Windows.Forms.MenuItem();
            this.menuViewClear = new System.Windows.Forms.MenuItem();
            this.menuViewUnprocessed = new System.Windows.Forms.MenuItem();
            this.menuSep21 = new System.Windows.Forms.MenuItem();
            this.menuViewWordList = new System.Windows.Forms.MenuItem();
            this.menuViewTextData = new System.Windows.Forms.MenuItem();
            this.menuViewInventory = new System.Windows.Forms.MenuItem();
            this.menuViewPS = new System.Windows.Forms.MenuItem();
            this.menuViewSite = new System.Windows.Forms.MenuItem();
            this.menuViewGraphemes = new System.Windows.Forms.MenuItem();
            this.menuFormat = new System.Windows.Forms.MenuItem();
            this.menuFormatFont = new System.Windows.Forms.MenuItem();
            this.menuFormatColor = new System.Windows.Forms.MenuItem();
            this.menuFormatWrap = new System.Windows.Forms.MenuItem();
            this.menuReport = new System.Windows.Forms.MenuItem();
            this.menuReportVowel = new System.Windows.Forms.MenuItem();
            this.menuReportConsonant = new System.Windows.Forms.MenuItem();
            this.menuReportPrimer = new System.Windows.Forms.MenuItem();
            this.menuReportGenerate = new System.Windows.Forms.MenuItem();
            this.menuSep35 = new System.Windows.Forms.MenuItem();
            this.menuReportEdit = new System.Windows.Forms.MenuItem();
            this.menuSearch = new System.Windows.Forms.MenuItem();
            this.menuSearchWord = new System.Windows.Forms.MenuItem();
            this.menuSearchWordGrapheme = new System.Windows.Forms.MenuItem();
            this.menuSearchWordFrequency = new System.Windows.Forms.MenuItem();
            this.menuSearchWordBuild = new System.Windows.Forms.MenuItem();
            this.menuSearchWordAdvanced = new System.Windows.Forms.MenuItem();
            this.menuSearchWordPairs = new System.Windows.Forms.MenuItem();
            this.menuSearchWordCoccur = new System.Windows.Forms.MenuItem();
            this.menuSearchWordContext = new System.Windows.Forms.MenuItem();
            this.menuSearchWordSyllable = new System.Windows.Forms.MenuItem();
            this.menuSearchWordTone = new System.Windows.Forms.MenuItem();
            this.menuSearchWordSyllograph = new System.Windows.Forms.MenuItem();
            this.menuSearchWordOrder = new System.Windows.Forms.MenuItem();
            this.menuSearchWordGeneral = new System.Windows.Forms.MenuItem();
            this.menuSearchText = new System.Windows.Forms.MenuItem();
            this.menuSearchTextGrapheme = new System.Windows.Forms.MenuItem();
            this.menuSearchTextFrequency = new System.Windows.Forms.MenuItem();
            this.menuSearchTextBuild = new System.Windows.Forms.MenuItem();
            this.menuSearchTextPhrases = new System.Windows.Forms.MenuItem();
            this.menuSearchTextResidue = new System.Windows.Forms.MenuItem();
            this.menuSearchTextWord = new System.Windows.Forms.MenuItem();
            this.menuSearchTextCount = new System.Windows.Forms.MenuItem();
            this.menuSearchTextSyllable = new System.Windows.Forms.MenuItem();
            this.menuSearchTextSight = new System.Windows.Forms.MenuItem();
            this.menuSearchTextNew = new System.Windows.Forms.MenuItem();
            this.menuSearchTextTone = new System.Windows.Forms.MenuItem();
            this.menuSearchTextSyllograph = new System.Windows.Forms.MenuItem();
            this.menuSearchTextOrder = new System.Windows.Forms.MenuItem();
            this.menuSearchTextGeneral = new System.Windows.Forms.MenuItem();
            this.menuSep40 = new System.Windows.Forms.MenuItem();
            this.menuSearchVowel = new System.Windows.Forms.MenuItem();
            this.menuSearchConsonant = new System.Windows.Forms.MenuItem();
            this.menuSearchTone = new System.Windows.Forms.MenuItem();
            this.menuSearchSyllograph = new System.Windows.Forms.MenuItem();
            this.menuTools = new System.Windows.Forms.MenuItem();
            this.menuToolsWord = new System.Windows.Forms.MenuItem();
            this.menuToolsWordImport = new System.Windows.Forms.MenuItem();
            this.menuToolsWordImportSF = new System.Windows.Forms.MenuItem();
            this.menuToolsWordImportLIFT = new System.Windows.Forms.MenuItem();
            this.menuToolsWordMerge = new System.Windows.Forms.MenuItem();
            this.menuToolsWordExport = new System.Windows.Forms.MenuItem();
            this.menuToolsWordReimport = new System.Windows.Forms.MenuItem();
            this.menuToolsWordUnload = new System.Windows.Forms.MenuItem();
            this.menuSep55 = new System.Windows.Forms.MenuItem();
            this.menuToolsWordCheck = new System.Windows.Forms.MenuItem();
            this.menuToolsText = new System.Windows.Forms.MenuItem();
            this.menuToolsTextImport = new System.Windows.Forms.MenuItem();
            this.menuToolsTextMerge = new System.Windows.Forms.MenuItem();
            this.menuToolsTextExport = new System.Windows.Forms.MenuItem();
            this.menuToolsTextReimport = new System.Windows.Forms.MenuItem();
            this.menuToolsTextUnload = new System.Windows.Forms.MenuItem();
            this.menuSep56 = new System.Windows.Forms.MenuItem();
            this.menuToolsTextCheckGI = new System.Windows.Forms.MenuItem();
            this.menuToolsTextCheckWL = new System.Windows.Forms.MenuItem();
            this.menuToolsTextBuildWL = new System.Windows.Forms.MenuItem();
            this.menuToolsInventory = new System.Windows.Forms.MenuItem();
            this.menuToolsInventoryInit = new System.Windows.Forms.MenuItem();
            this.menuToolsInventoryInitWL = new System.Windows.Forms.MenuItem();
            this.menuToolsInventoryInitTD = new System.Windows.Forms.MenuItem();
            this.menuToolsInventoryInitPG = new System.Windows.Forms.MenuItem();
            this.menuToolsInventorySyllabary = new System.Windows.Forms.MenuItem();
            this.menuToolsInventoryConsonants = new System.Windows.Forms.MenuItem();
            this.menuToolsInventoryVowels = new System.Windows.Forms.MenuItem();
            this.menuToolsInventoryTone = new System.Windows.Forms.MenuItem();
            this.menuToolsInventorySyllograph = new System.Windows.Forms.MenuItem();
            this.menuToolsInventorySave = new System.Windows.Forms.MenuItem();
            this.menuToolsInventoryClear = new System.Windows.Forms.MenuItem();
            this.menuToolsParts = new System.Windows.Forms.MenuItem();
            this.menuToolsPartsInit = new System.Windows.Forms.MenuItem();
            this.menuToolsPartsUpdate = new System.Windows.Forms.MenuItem();
            this.menuToolsPartsSave = new System.Windows.Forms.MenuItem();
            this.menuToolsSight = new System.Windows.Forms.MenuItem();
            this.menuToolsSightUpdate = new System.Windows.Forms.MenuItem();
            this.menuToolsSightSave = new System.Windows.Forms.MenuItem();
            this.menuToolsSightCheckWL = new System.Windows.Forms.MenuItem();
            this.menuToolsOrder = new System.Windows.Forms.MenuItem();
            this.menuToolsOrderUpdate = new System.Windows.Forms.MenuItem();
            this.menuToolsOrderSave = new System.Windows.Forms.MenuItem();
            this.menuToolsOrderCheck = new System.Windows.Forms.MenuItem();
            this.menuSep50 = new System.Windows.Forms.MenuItem();
            this.menuToolsOptions = new System.Windows.Forms.MenuItem();
            this.menuWindow = new System.Windows.Forms.MenuItem();
            this.menuWindowCascade = new System.Windows.Forms.MenuItem();
            this.menuWindowTileH = new System.Windows.Forms.MenuItem();
            this.menuWindowTileV = new System.Windows.Forms.MenuItem();
            this.menuHelp = new System.Windows.Forms.MenuItem();
            this.menuHelpHelp = new System.Windows.Forms.MenuItem();
            this.menuHelpSetup = new System.Windows.Forms.MenuItem();
            this.menuHelpPrimer = new System.Windows.Forms.MenuItem();
            this.menuSep70 = new System.Windows.Forms.MenuItem();
            this.menuHelpAbout = new System.Windows.Forms.MenuItem();
            this.menuTest = new System.Windows.Forms.MenuItem();
            this.menuTest1 = new System.Windows.Forms.MenuItem();
            this.menuTest2 = new System.Windows.Forms.MenuItem();
            this.menuTest3 = new System.Windows.Forms.MenuItem();
            this.menuTestBrowse = new System.Windows.Forms.MenuItem();
            this.menuTestTemp = new System.Windows.Forms.MenuItem();
            this.tbApp = new System.Windows.Forms.ToolBar();
            this.tbbNew = new System.Windows.Forms.ToolBarButton();
            this.tbbOpen = new System.Windows.Forms.ToolBarButton();
            this.tbbSave = new System.Windows.Forms.ToolBarButton();
            this.tbbPreview = new System.Windows.Forms.ToolBarButton();
            this.tbbPrint = new System.Windows.Forms.ToolBarButton();
            this.tbbCut = new System.Windows.Forms.ToolBarButton();
            this.tbbCopy = new System.Windows.Forms.ToolBarButton();
            this.tbbPaste = new System.Windows.Forms.ToolBarButton();
            this.tbbFind = new System.Windows.Forms.ToolBarButton();
            this.tbbOptions = new System.Windows.Forms.ToolBarButton();
            this.tbbHelp = new System.Windows.Forms.ToolBarButton();
            this.imageListPP = new System.Windows.Forms.ImageList(this.components);
            this.ssApp = new System.Windows.Forms.StatusStrip();
            this.tsslWordList = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslTextData = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslWnd = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspbPrimerPro = new System.Windows.Forms.ToolStripProgressBar();
            this.tsslInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuHelpNew = new System.Windows.Forms.MenuItem();
            this.ssApp.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.menuTop.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuFile,
            this.menuEdit,
            this.menuView,
            this.menuFormat,
            this.menuReport,
            this.menuSearch,
            this.menuTools,
            this.menuWindow,
            this.menuHelp,
            this.menuTest});
            // 
            // menuFile
            // 
            this.menuFile.Index = 0;
            this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuFileNew,
            this.menuFileOpen,
            this.menuFileClose,
            this.menuFileSave,
            this.menuFileAs,
            this.menuSep01,
            this.menuFileProjNew,
            this.menuFileProjSelect,
            this.menuFileProjDelete,
            this.menuFileProjExport,
            this.menuFileProjImport,
            this.menuSep02,
            this.menuFilePrint,
            this.menuFilePreview,
            this.menuFileSetup,
            this.menuSep03,
            this.menuExit});
            this.menuFile.Text = "&File";
            // 
            // menuFileNew
            // 
            this.menuFileNew.Index = 0;
            this.menuFileNew.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.menuFileNew.Text = "&New";
            this.menuFileNew.Click += new System.EventHandler(this.menuFileNew_Click);
            this.menuFileNew.Select += new System.EventHandler(this.menuFileNew_Select);
            // 
            // menuFileOpen
            // 
            this.menuFileOpen.Index = 1;
            this.menuFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.menuFileOpen.Text = "&Open...";
            this.menuFileOpen.Click += new System.EventHandler(this.menuFileOpen_Click);
            this.menuFileOpen.Select += new System.EventHandler(this.menuFileOpen_Select);
            // 
            // menuFileClose
            // 
            this.menuFileClose.Index = 2;
            this.menuFileClose.Text = "&Close";
            this.menuFileClose.Click += new System.EventHandler(this.menuFileClose_Click);
            this.menuFileClose.Select += new System.EventHandler(this.menuFileClose_Select);
            // 
            // menuFileSave
            // 
            this.menuFileSave.Index = 3;
            this.menuFileSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.menuFileSave.Text = "&Save";
            this.menuFileSave.Click += new System.EventHandler(this.menuFileSave_Click);
            this.menuFileSave.Select += new System.EventHandler(this.menuFileSave_Select);
            // 
            // menuFileAs
            // 
            this.menuFileAs.Index = 4;
            this.menuFileAs.Text = "Save &As...";
            this.menuFileAs.Click += new System.EventHandler(this.menuFileAs_Click);
            this.menuFileAs.Select += new System.EventHandler(this.menuFileAs_Select);
            // 
            // menuSep01
            // 
            this.menuSep01.Index = 5;
            this.menuSep01.Text = "-";
            // 
            // menuFileProjNew
            // 
            this.menuFileProjNew.Index = 6;
            this.menuFileProjNew.Text = "Create Ne&w Project";
            this.menuFileProjNew.Click += new System.EventHandler(this.menuFileProjNew_Click);
            this.menuFileProjNew.Select += new System.EventHandler(this.menuFileProjNew_Select);
            // 
            // menuFileProjSelect
            // 
            this.menuFileProjSelect.Index = 7;
            this.menuFileProjSelect.Text = "Se&lect Project";
            this.menuFileProjSelect.Click += new System.EventHandler(this.menuFileProjSelect_Click);
            this.menuFileProjSelect.Select += new System.EventHandler(this.menuFileProjSelect_Select);
            // 
            // menuFileProjDelete
            // 
            this.menuFileProjDelete.Index = 8;
            this.menuFileProjDelete.Text = "&Delete Project";
            this.menuFileProjDelete.Click += new System.EventHandler(this.menuFileProjDelete_Click);
            this.menuFileProjDelete.Select += new System.EventHandler(this.menuFileProjDelete_Select);
            // 
            // menuFileProjExport
            // 
            this.menuFileProjExport.Index = 9;
            this.menuFileProjExport.Text = "&Export/Backup Project ";
            this.menuFileProjExport.Click += new System.EventHandler(this.menuFileProjExport_Click);
            this.menuFileProjExport.Select += new System.EventHandler(this.menuFileProjExport_Select);
            // 
            // menuFileProjImport
            // 
            this.menuFileProjImport.Index = 10;
            this.menuFileProjImport.Text = "&Import/Restore Project";
            this.menuFileProjImport.Click += new System.EventHandler(this.menuFileProjImport_Click);
            this.menuFileProjImport.Select += new System.EventHandler(this.menuFileProjImport_Select);
            // 
            // menuSep02
            // 
            this.menuSep02.Index = 11;
            this.menuSep02.Text = "-";
            // 
            // menuFilePrint
            // 
            this.menuFilePrint.Index = 12;
            this.menuFilePrint.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
            this.menuFilePrint.Text = "&Print...";
            this.menuFilePrint.Click += new System.EventHandler(this.menuFilePrint_Click);
            this.menuFilePrint.Select += new System.EventHandler(this.menuFilePrint_Select);
            // 
            // menuFilePreview
            // 
            this.menuFilePreview.Index = 13;
            this.menuFilePreview.Text = "Print Pre&view";
            this.menuFilePreview.Click += new System.EventHandler(this.menuFilePreview_Click);
            this.menuFilePreview.Select += new System.EventHandler(this.menuFilePreview_Select);
            // 
            // menuFileSetup
            // 
            this.menuFileSetup.Index = 14;
            this.menuFileSetup.Text = "Pa&ge Setup...";
            this.menuFileSetup.Click += new System.EventHandler(this.menuFileSetup_Click);
            this.menuFileSetup.Select += new System.EventHandler(this.menuFileSetup_Select);
            // 
            // menuSep03
            // 
            this.menuSep03.Index = 15;
            this.menuSep03.Text = "-";
            // 
            // menuExit
            // 
            this.menuExit.Index = 16;
            this.menuExit.Text = "E&xit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            this.menuExit.Select += new System.EventHandler(this.menuExit_Select);
            // 
            // menuEdit
            // 
            this.menuEdit.Index = 1;
            this.menuEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuEditUndo,
            this.menuSep10,
            this.menuEditCut,
            this.menuEditCopy,
            this.menuEditPaste,
            this.menuEditSelect,
            this.menuEditClear,
            this.menuSep11,
            this.menuEditFind,
            this.menuEditNext,
            this.menuEditReplace});
            this.menuEdit.Text = "&Edit";
            // 
            // menuEditUndo
            // 
            this.menuEditUndo.Index = 0;
            this.menuEditUndo.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
            this.menuEditUndo.Text = "&Undo";
            this.menuEditUndo.Click += new System.EventHandler(this.menuEditUndo_Click);
            this.menuEditUndo.Select += new System.EventHandler(this.menuEditUndo_Select);
            // 
            // menuSep10
            // 
            this.menuSep10.Index = 1;
            this.menuSep10.Text = "-";
            // 
            // menuEditCut
            // 
            this.menuEditCut.Index = 2;
            this.menuEditCut.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.menuEditCut.Text = "Cu&t";
            this.menuEditCut.Click += new System.EventHandler(this.menuEditCut_Click);
            this.menuEditCut.Select += new System.EventHandler(this.menuEditCut_Select);
            // 
            // menuEditCopy
            // 
            this.menuEditCopy.Index = 3;
            this.menuEditCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this.menuEditCopy.Text = "&Copy";
            this.menuEditCopy.Click += new System.EventHandler(this.menuEditCopy_Click);
            this.menuEditCopy.Select += new System.EventHandler(this.menuEditCopy_Select);
            // 
            // menuEditPaste
            // 
            this.menuEditPaste.Index = 4;
            this.menuEditPaste.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
            this.menuEditPaste.Text = "&Paste";
            this.menuEditPaste.Click += new System.EventHandler(this.menuEditPaste_Click);
            this.menuEditPaste.Select += new System.EventHandler(this.menuEditPaste_Select);
            // 
            // menuEditSelect
            // 
            this.menuEditSelect.Index = 5;
            this.menuEditSelect.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
            this.menuEditSelect.Text = "Select &All";
            this.menuEditSelect.Click += new System.EventHandler(this.menuEditSelect_Click);
            this.menuEditSelect.Select += new System.EventHandler(this.menuEditSelect_Select);
            // 
            // menuEditClear
            // 
            this.menuEditClear.Index = 6;
            this.menuEditClear.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
            this.menuEditClear.Text = "C&lear All";
            this.menuEditClear.Click += new System.EventHandler(this.menuEditClear_Click);
            this.menuEditClear.Select += new System.EventHandler(this.menuEditClear_Select);
            // 
            // menuSep11
            // 
            this.menuSep11.Index = 7;
            this.menuSep11.Text = "-";
            // 
            // menuEditFind
            // 
            this.menuEditFind.Index = 8;
            this.menuEditFind.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
            this.menuEditFind.Text = "&Find...";
            this.menuEditFind.Click += new System.EventHandler(this.menuEditFind_Click);
            this.menuEditFind.Select += new System.EventHandler(this.menuEditFind_Select);
            // 
            // menuEditNext
            // 
            this.menuEditNext.Index = 9;
            this.menuEditNext.Shortcut = System.Windows.Forms.Shortcut.F3;
            this.menuEditNext.Text = "Find &Next";
            this.menuEditNext.Click += new System.EventHandler(this.menuEditNext_Click);
            this.menuEditNext.Select += new System.EventHandler(this.menuEditNext_Select);
            // 
            // menuEditReplace
            // 
            this.menuEditReplace.Index = 10;
            this.menuEditReplace.Shortcut = System.Windows.Forms.Shortcut.CtrlH;
            this.menuEditReplace.Text = "&Replace...";
            this.menuEditReplace.Click += new System.EventHandler(this.menuEditReplace_Click);
            this.menuEditReplace.Select += new System.EventHandler(this.menuEditReplace_Select);
            // 
            // menuView
            // 
            this.menuView.Index = 2;
            this.menuView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuViewToolbar,
            this.menuViewStatus,
            this.menuSep20,
            this.menuViewMode,
            this.menuViewShow,
            this.menuViewHide,
            this.menuViewClear,
            this.menuViewUnprocessed,
            this.menuSep21,
            this.menuViewWordList,
            this.menuViewTextData,
            this.menuViewInventory,
            this.menuViewPS,
            this.menuViewSite,
            this.menuViewGraphemes});
            this.menuView.Text = "&View";
            // 
            // menuViewToolbar
            // 
            this.menuViewToolbar.Checked = true;
            this.menuViewToolbar.Index = 0;
            this.menuViewToolbar.Text = "&Toolbar";
            this.menuViewToolbar.Click += new System.EventHandler(this.menuViewToolbar_Click);
            this.menuViewToolbar.Select += new System.EventHandler(this.menuViewToolbar_Select);
            // 
            // menuViewStatus
            // 
            this.menuViewStatus.Checked = true;
            this.menuViewStatus.Index = 1;
            this.menuViewStatus.Text = "Status &Bar";
            this.menuViewStatus.Click += new System.EventHandler(this.menuViewStatus_Click);
            this.menuViewStatus.Select += new System.EventHandler(this.menuViewStatus_Select);
            // 
            // menuSep20
            // 
            this.menuSep20.Index = 2;
            this.menuSep20.Text = "-";
            // 
            // menuViewMode
            // 
            this.menuViewMode.Index = 3;
            this.menuViewMode.Text = "Search Insertion &Mode...";
            this.menuViewMode.Click += new System.EventHandler(this.menuViewMode_Click);
            this.menuViewMode.Select += new System.EventHandler(this.menuViewMode_Select);
            // 
            // menuViewShow
            // 
            this.menuViewShow.Index = 4;
            this.menuViewShow.Text = "&Show Processed Searches";
            this.menuViewShow.Click += new System.EventHandler(this.menuViewShow_Click);
            this.menuViewShow.Select += new System.EventHandler(this.menuViewShow_Select);
            // 
            // menuViewHide
            // 
            this.menuViewHide.Index = 5;
            this.menuViewHide.Text = "&Hide Processed Searches";
            this.menuViewHide.Click += new System.EventHandler(this.menuViewHide_Click);
            this.menuViewHide.Select += new System.EventHandler(this.menuViewHide_Select);
            // 
            // menuViewClear
            // 
            this.menuViewClear.Index = 6;
            this.menuViewClear.Text = "&Clear Processed Searches";
            this.menuViewClear.Click += new System.EventHandler(this.menuViewClear_Click);
            this.menuViewClear.Select += new System.EventHandler(this.menuViewClear_Select);
            // 
            // menuViewUnprocessed
            // 
            this.menuViewUnprocessed.Index = 7;
            this.menuViewUnprocessed.Text = "Run &Unprocessed Searches";
            this.menuViewUnprocessed.Click += new System.EventHandler(this.menuViewUnprocessed_Click);
            this.menuViewUnprocessed.Select += new System.EventHandler(this.menuViewUnprocessed_Select);
            // 
            // menuSep21
            // 
            this.menuSep21.Index = 8;
            this.menuSep21.Text = "-";
            // 
            // menuViewWordList
            // 
            this.menuViewWordList.Index = 9;
            this.menuViewWordList.Text = "&Word List";
            this.menuViewWordList.Click += new System.EventHandler(this.menuViewWordList_Click);
            this.menuViewWordList.Select += new System.EventHandler(this.menuViewWordList_Select);
            // 
            // menuViewTextData
            // 
            this.menuViewTextData.Index = 10;
            this.menuViewTextData.Text = "Text &Data";
            this.menuViewTextData.Click += new System.EventHandler(this.menuViewTextData_Click);
            this.menuViewTextData.Select += new System.EventHandler(this.menuViewTextData_Select);
            // 
            // menuViewInventory
            // 
            this.menuViewInventory.Index = 11;
            this.menuViewInventory.Text = "Grapheme &Inventory";
            this.menuViewInventory.Click += new System.EventHandler(this.menuViewInventory_Click);
            this.menuViewInventory.Select += new System.EventHandler(this.menuViewInventory_Select);
            // 
            // menuViewPS
            // 
            this.menuViewPS.Index = 12;
            this.menuViewPS.Text = "&Parts of Speech";
            this.menuViewPS.Click += new System.EventHandler(this.menuViewPS_Click);
            this.menuViewPS.Select += new System.EventHandler(this.menuViewPS_Select);
            // 
            // menuViewSite
            // 
            this.menuViewSite.Index = 13;
            this.menuViewSite.Text = "Sight W&ords";
            this.menuViewSite.Click += new System.EventHandler(this.menuViewSite_Click);
            this.menuViewSite.Select += new System.EventHandler(this.menuViewSite_Select);
            // 
            // menuViewGraphemes
            // 
            this.menuViewGraphemes.Index = 14;
            this.menuViewGraphemes.Text = "&Graphemes Taught ";
            this.menuViewGraphemes.Click += new System.EventHandler(this.menuViewGraphemes_Click);
            this.menuViewGraphemes.Select += new System.EventHandler(this.menuViewGraphemes_Select);
            // 
            // menuFormat
            // 
            this.menuFormat.Index = 3;
            this.menuFormat.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuFormatFont,
            this.menuFormatColor,
            this.menuFormatWrap});
            this.menuFormat.Text = "F&ormat";
            // 
            // menuFormatFont
            // 
            this.menuFormatFont.Index = 0;
            this.menuFormatFont.Text = "&Font...";
            this.menuFormatFont.Click += new System.EventHandler(this.menuFormatFont_Click);
            this.menuFormatFont.Select += new System.EventHandler(this.menuFormatFont_Select);
            // 
            // menuFormatColor
            // 
            this.menuFormatColor.Index = 1;
            this.menuFormatColor.Text = "&Color...";
            this.menuFormatColor.Click += new System.EventHandler(this.menuFormatColor_Click);
            this.menuFormatColor.Select += new System.EventHandler(this.menuFormatColor_Select);
            // 
            // menuFormatWrap
            // 
            this.menuFormatWrap.Index = 2;
            this.menuFormatWrap.Text = "Word &Wrap";
            this.menuFormatWrap.Click += new System.EventHandler(this.menuFormatWrap_Click);
            this.menuFormatWrap.Select += new System.EventHandler(this.menuFormatWrap_Select);
            // 
            // menuReport
            // 
            this.menuReport.Index = 4;
            this.menuReport.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuReportVowel,
            this.menuReportConsonant,
            this.menuReportPrimer,
            this.menuReportGenerate,
            this.menuSep35,
            this.menuReportEdit});
            this.menuReport.Text = "&Report";
            // 
            // menuReportVowel
            // 
            this.menuReportVowel.Index = 0;
            this.menuReportVowel.Text = "Generate &Vowel Report";
            this.menuReportVowel.Click += new System.EventHandler(this.menuReportVowel_Click);
            this.menuReportVowel.Select += new System.EventHandler(this.menuReportVowel_Select);
            // 
            // menuReportConsonant
            // 
            this.menuReportConsonant.Index = 1;
            this.menuReportConsonant.Text = "Generate &Consonant Report";
            this.menuReportConsonant.Click += new System.EventHandler(this.menuReportConsonant_Click);
            this.menuReportConsonant.Select += new System.EventHandler(this.menuReportConsonant_Select);
            // 
            // menuReportPrimer
            // 
            this.menuReportPrimer.Index = 2;
            this.menuReportPrimer.Text = "Generate &Primer Progression Report";
            this.menuReportPrimer.Click += new System.EventHandler(this.menuReportPrimer_Click);
            this.menuReportPrimer.Select += new System.EventHandler(this.menuReportPrimer_Select);
            // 
            // menuReportGenerate
            // 
            this.menuReportGenerate.Index = 3;
            this.menuReportGenerate.Text = "&Generate Report from Template...";
            this.menuReportGenerate.Click += new System.EventHandler(this.menuReportGenerate_Click);
            this.menuReportGenerate.Select += new System.EventHandler(this.menuReportGenerate_Select);
            // 
            // menuSep35
            // 
            this.menuSep35.Index = 4;
            this.menuSep35.Text = "-";
            // 
            // menuReportEdit
            // 
            this.menuReportEdit.Index = 5;
            this.menuReportEdit.Text = "&Edit Report Template...";
            this.menuReportEdit.Click += new System.EventHandler(this.menuReportEdit_Click);
            this.menuReportEdit.Select += new System.EventHandler(this.menuReportEdit_Select);
            // 
            // menuSearch
            // 
            this.menuSearch.Index = 5;
            this.menuSearch.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuSearchWord,
            this.menuSearchText,
            this.menuSep40,
            this.menuSearchVowel,
            this.menuSearchConsonant,
            this.menuSearchTone,
            this.menuSearchSyllograph});
            this.menuSearch.Text = "&Search";
            // 
            // menuSearchWord
            // 
            this.menuSearchWord.Index = 0;
            this.menuSearchWord.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuSearchWordGrapheme,
            this.menuSearchWordFrequency,
            this.menuSearchWordBuild,
            this.menuSearchWordAdvanced,
            this.menuSearchWordPairs,
            this.menuSearchWordCoccur,
            this.menuSearchWordContext,
            this.menuSearchWordSyllable,
            this.menuSearchWordTone,
            this.menuSearchWordSyllograph,
            this.menuSearchWordOrder,
            this.menuSearchWordGeneral});
            this.menuSearchWord.Text = "&Word List";
            // 
            // menuSearchWordGrapheme
            // 
            this.menuSearchWordGrapheme.Index = 0;
            this.menuSearchWordGrapheme.Text = "&Grapheme Search...";
            this.menuSearchWordGrapheme.Click += new System.EventHandler(this.menuSearchWordGrapheme_Click);
            this.menuSearchWordGrapheme.Select += new System.EventHandler(this.menuSearchWordGrapheme_Select);
            // 
            // menuSearchWordFrequency
            // 
            this.menuSearchWordFrequency.Index = 1;
            this.menuSearchWordFrequency.Text = "&Frequency Count Search..";
            this.menuSearchWordFrequency.Click += new System.EventHandler(this.menuSearchWordFrequency_Click);
            this.menuSearchWordFrequency.Select += new System.EventHandler(this.menuSearchWordFrequency_Select);
            // 
            // menuSearchWordBuild
            // 
            this.menuSearchWordBuild.Index = 2;
            this.menuSearchWordBuild.Text = "&Buildable Words Search...";
            this.menuSearchWordBuild.Click += new System.EventHandler(this.menuSearchWordBuild_Click);
            this.menuSearchWordBuild.Select += new System.EventHandler(this.menuSearchWordBuild_Select);
            // 
            // menuSearchWordAdvanced
            // 
            this.menuSearchWordAdvanced.Index = 3;
            this.menuSearchWordAdvanced.Text = "&Advanced Grapheme Search...";
            this.menuSearchWordAdvanced.Click += new System.EventHandler(this.menuSearchWordAdvanced_Click);
            this.menuSearchWordAdvanced.Select += new System.EventHandler(this.menuSearchWordAdvanced_Select);
            // 
            // menuSearchWordPairs
            // 
            this.menuSearchWordPairs.Index = 4;
            this.menuSearchWordPairs.Text = "&Minimal Pairs Search...";
            this.menuSearchWordPairs.Click += new System.EventHandler(this.menuSearchWordPairs_Click);
            this.menuSearchWordPairs.Select += new System.EventHandler(this.menuSearchWordPairs_Select);
            // 
            // menuSearchWordCoccur
            // 
            this.menuSearchWordCoccur.Index = 5;
            this.menuSearchWordCoccur.Text = "Co-occu&rrence Chart Search...";
            this.menuSearchWordCoccur.Click += new System.EventHandler(this.menuSearchWordCoccur_Click);
            this.menuSearchWordCoccur.Select += new System.EventHandler(this.menuSearchWordCoccur_Select);
            // 
            // menuSearchWordContext
            // 
            this.menuSearchWordContext.Index = 6;
            this.menuSearchWordContext.Text = "&Context Occurrence Chart Search...";
            this.menuSearchWordContext.Click += new System.EventHandler(this.menuSearchWordContext_Click);
            this.menuSearchWordContext.Select += new System.EventHandler(this.menuSearchWordContext_Select);
            // 
            // menuSearchWordSyllable
            // 
            this.menuSearchWordSyllable.Index = 7;
            this.menuSearchWordSyllable.Text = "&Syllable Chart Search...";
            this.menuSearchWordSyllable.Click += new System.EventHandler(this.menuSearchWordSyllable_Click);
            this.menuSearchWordSyllable.Select += new System.EventHandler(this.menuSearchWordSyllable_Select);
            // 
            // menuSearchWordTone
            // 
            this.menuSearchWordTone.Index = 8;
            this.menuSearchWordTone.Text = "&Tone Search...";
            this.menuSearchWordTone.Click += new System.EventHandler(this.menuSearchWordTone_Click);
            this.menuSearchWordTone.Select += new System.EventHandler(this.menuSearchWordTone_Select);
            // 
            // menuSearchWordSyllograph
            // 
            this.menuSearchWordSyllograph.Index = 9;
            this.menuSearchWordSyllograph.Text = "Sy&llograph Search...";
            this.menuSearchWordSyllograph.Click += new System.EventHandler(this.menuSearchWordSyllograph_Click);
            this.menuSearchWordSyllograph.Select += new System.EventHandler(this.menuSearchWordSyllograph_Select);
            // 
            // menuSearchWordOrder
            // 
            this.menuSearchWordOrder.Index = 10;
            this.menuSearchWordOrder.Text = "Teaching &Order Search";
            this.menuSearchWordOrder.Click += new System.EventHandler(this.menuSearchWordOrder_Click);
            this.menuSearchWordOrder.Select += new System.EventHandler(this.menuSearchWordOrder_Select);
            // 
            // menuSearchWordGeneral
            // 
            this.menuSearchWordGeneral.Index = 11;
            this.menuSearchWordGeneral.Text = "General Searc&h...";
            this.menuSearchWordGeneral.Click += new System.EventHandler(this.menuSearchWordGeneral_Click);
            this.menuSearchWordGeneral.Select += new System.EventHandler(this.menuSearchWordGeneral_Select);
            // 
            // menuSearchText
            // 
            this.menuSearchText.Index = 1;
            this.menuSearchText.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuSearchTextGrapheme,
            this.menuSearchTextFrequency,
            this.menuSearchTextBuild,
            this.menuSearchTextPhrases,
            this.menuSearchTextResidue,
            this.menuSearchTextWord,
            this.menuSearchTextCount,
            this.menuSearchTextSyllable,
            this.menuSearchTextSight,
            this.menuSearchTextNew,
            this.menuSearchTextTone,
            this.menuSearchTextSyllograph,
            this.menuSearchTextOrder,
            this.menuSearchTextGeneral});
            this.menuSearchText.Text = "Text &Data";
            // 
            // menuSearchTextGrapheme
            // 
            this.menuSearchTextGrapheme.Index = 0;
            this.menuSearchTextGrapheme.Text = "&Grapheme Search...";
            this.menuSearchTextGrapheme.Click += new System.EventHandler(this.menuSearchTextGrapheme_Click);
            this.menuSearchTextGrapheme.Select += new System.EventHandler(this.menuSearchTextGrapheme_Select);
            // 
            // menuSearchTextFrequency
            // 
            this.menuSearchTextFrequency.Index = 1;
            this.menuSearchTextFrequency.Text = "&Frequency Count Search...";
            this.menuSearchTextFrequency.Click += new System.EventHandler(this.menuSearchTextFrequency_Click);
            this.menuSearchTextFrequency.Select += new System.EventHandler(this.menuSearchTextFrequency_Select);
            // 
            // menuSearchTextBuild
            // 
            this.menuSearchTextBuild.Index = 2;
            this.menuSearchTextBuild.Text = "&Buildable Word Search...";
            this.menuSearchTextBuild.Click += new System.EventHandler(this.menuSearchTextBuilt_Click);
            this.menuSearchTextBuild.Select += new System.EventHandler(this.menuSearchTextBuilt_Select);
            // 
            // menuSearchTextPhrases
            // 
            this.menuSearchTextPhrases.Index = 3;
            this.menuSearchTextPhrases.Text = "Usable &Phrases Search...";
            this.menuSearchTextPhrases.Click += new System.EventHandler(this.menuSearchTextPhrases_Click);
            this.menuSearchTextPhrases.Select += new System.EventHandler(this.menuSearchTextPhrases_Select);
            // 
            // menuSearchTextResidue
            // 
            this.menuSearchTextResidue.Index = 4;
            this.menuSearchTextResidue.Text = "Untaught &Residue Search...";
            this.menuSearchTextResidue.Click += new System.EventHandler(this.menuSearchTextResidue_Click);
            this.menuSearchTextResidue.Select += new System.EventHandler(this.menuSearchTextResidue_Select);
            // 
            // menuSearchTextWord
            // 
            this.menuSearchTextWord.Index = 5;
            this.menuSearchTextWord.Text = "&Word Search...";
            this.menuSearchTextWord.Click += new System.EventHandler(this.menuSearchTextWord_Click);
            this.menuSearchTextWord.Select += new System.EventHandler(this.menuSearchTextWord_Select);
            // 
            // menuSearchTextCount
            // 
            this.menuSearchTextCount.Index = 6;
            this.menuSearchTextCount.Text = "Word &Count Search...";
            this.menuSearchTextCount.Click += new System.EventHandler(this.menuSearchTextCount_Click);
            this.menuSearchTextCount.Select += new System.EventHandler(this.menuSearchTextCount_Select);
            // 
            // menuSearchTextSyllable
            // 
            this.menuSearchTextSyllable.Index = 7;
            this.menuSearchTextSyllable.Text = "&Syllable Count Search...";
            this.menuSearchTextSyllable.Click += new System.EventHandler(this.menuSearchTextSyllable_Click);
            this.menuSearchTextSyllable.Select += new System.EventHandler(this.menuSearchTextSyllable_Select);
            // 
            // menuSearchTextSight
            // 
            this.menuSearchTextSight.Index = 8;
            this.menuSearchTextSight.Text = "S&ight Word Search...";
            this.menuSearchTextSight.Click += new System.EventHandler(this.menuSearchTextSight_Click);
            this.menuSearchTextSight.Select += new System.EventHandler(this.menuSearchTextSight_Select);
            // 
            // menuSearchTextNew
            // 
            this.menuSearchTextNew.Index = 9;
            this.menuSearchTextNew.Text = "&New Word Search...";
            this.menuSearchTextNew.Click += new System.EventHandler(this.menuSearchTextNew_Click);
            this.menuSearchTextNew.Select += new System.EventHandler(this.menuSearchTextNew_Select);
            // 
            // menuSearchTextTone
            // 
            this.menuSearchTextTone.Index = 10;
            this.menuSearchTextTone.Text = "&Tone Search...";
            this.menuSearchTextTone.Click += new System.EventHandler(this.menuSearchTextTone_Click);
            this.menuSearchTextTone.Select += new System.EventHandler(this.menuSearchTextTone_Select);
            // 
            // menuSearchTextSyllograph
            // 
            this.menuSearchTextSyllograph.Index = 11;
            this.menuSearchTextSyllograph.Text = "Sy&llograph Search...";
            this.menuSearchTextSyllograph.Click += new System.EventHandler(this.menuSearchTextSyllograph_Click);
            this.menuSearchTextSyllograph.Select += new System.EventHandler(this.menuSearchTextSyllograph_Select);
            // 
            // menuSearchTextOrder
            // 
            this.menuSearchTextOrder.Index = 12;
            this.menuSearchTextOrder.Text = "Teaching &Order Search";
            this.menuSearchTextOrder.Click += new System.EventHandler(this.menuSearchTextOrder_Click);
            this.menuSearchTextOrder.Select += new System.EventHandler(this.menuSearchTextOrder_Select);
            // 
            // menuSearchTextGeneral
            // 
            this.menuSearchTextGeneral.Index = 13;
            this.menuSearchTextGeneral.Text = "General Searc&h...";
            this.menuSearchTextGeneral.Click += new System.EventHandler(this.menuSearchTextGeneral_Click);
            this.menuSearchTextGeneral.Select += new System.EventHandler(this.menuSearchTextGeneral_Select);
            // 
            // menuSep40
            // 
            this.menuSep40.Index = 2;
            this.menuSep40.Text = "-";
            // 
            // menuSearchVowel
            // 
            this.menuSearchVowel.Index = 3;
            this.menuSearchVowel.Text = "&Vowel Chart Search...";
            this.menuSearchVowel.Click += new System.EventHandler(this.menuSearchVowel_Click);
            this.menuSearchVowel.Select += new System.EventHandler(this.menuSearchVowel_Select);
            // 
            // menuSearchConsonant
            // 
            this.menuSearchConsonant.Index = 4;
            this.menuSearchConsonant.Text = "&Consonant Chart Search...";
            this.menuSearchConsonant.Click += new System.EventHandler(this.menuSearchConsonant_Click);
            this.menuSearchConsonant.Select += new System.EventHandler(this.menuSearchConsonant_Select);
            // 
            // menuSearchTone
            // 
            this.menuSearchTone.Index = 5;
            this.menuSearchTone.Text = "&Tone Chart Search";
            this.menuSearchTone.Click += new System.EventHandler(this.menuSearchTone_Click);
            this.menuSearchTone.Select += new System.EventHandler(this.menuSearchTone_Select);
            // 
            // menuSearchSyllograph
            // 
            this.menuSearchSyllograph.Index = 6;
            this.menuSearchSyllograph.Text = "&Syllograph Chart Search";
            this.menuSearchSyllograph.Click += new System.EventHandler(this.menuSearchSyllograph_Click);
            this.menuSearchSyllograph.Select += new System.EventHandler(this.menuSearchSyllograph_Select);
            // 
            // menuTools
            // 
            this.menuTools.Index = 6;
            this.menuTools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuToolsWord,
            this.menuToolsText,
            this.menuToolsInventory,
            this.menuToolsParts,
            this.menuToolsSight,
            this.menuToolsOrder,
            this.menuSep50,
            this.menuToolsOptions});
            this.menuTools.Text = "&Tools";
            // 
            // menuToolsWord
            // 
            this.menuToolsWord.Index = 0;
            this.menuToolsWord.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuToolsWordImport,
            this.menuToolsWordMerge,
            this.menuToolsWordExport,
            this.menuToolsWordReimport,
            this.menuToolsWordUnload,
            this.menuSep55,
            this.menuToolsWordCheck});
            this.menuToolsWord.Text = "&Word List";
            // 
            // menuToolsWordImport
            // 
            this.menuToolsWordImport.Index = 0;
            this.menuToolsWordImport.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuToolsWordImportSF,
            this.menuToolsWordImportLIFT});
            this.menuToolsWordImport.Text = "&Import";
            // 
            // menuToolsWordImportSF
            // 
            this.menuToolsWordImportSF.Index = 0;
            this.menuToolsWordImportSF.Text = "&Standard Format Lexicon...";
            this.menuToolsWordImportSF.Click += new System.EventHandler(this.menuToolsWordImportSF_Click);
            this.menuToolsWordImportSF.Select += new System.EventHandler(this.menuToolsWordImportSF_Select);
            // 
            // menuToolsWordImportLIFT
            // 
            this.menuToolsWordImportLIFT.Index = 1;
            this.menuToolsWordImportLIFT.Text = "&LIFT Lexicon...";
            this.menuToolsWordImportLIFT.Click += new System.EventHandler(this.menuToolsWordImportLIFT_Click);
            this.menuToolsWordImportLIFT.Select += new System.EventHandler(this.menuToolsWordImportLIFT_Select);
            // 
            // menuToolsWordMerge
            // 
            this.menuToolsWordMerge.Index = 1;
            this.menuToolsWordMerge.Text = "&Merge...";
            this.menuToolsWordMerge.Click += new System.EventHandler(this.menuToolsWordMerge_Click);
            this.menuToolsWordMerge.Select += new System.EventHandler(this.menuToolsWordMerge_Select);
            // 
            // menuToolsWordExport
            // 
            this.menuToolsWordExport.Index = 2;
            this.menuToolsWordExport.Text = "&Export...";
            this.menuToolsWordExport.Click += new System.EventHandler(this.menuToolsWordExport_Click);
            this.menuToolsWordExport.Select += new System.EventHandler(this.menuToolsWordExport_Select);
            // 
            // menuToolsWordReimport
            // 
            this.menuToolsWordReimport.Index = 3;
            this.menuToolsWordReimport.Text = "&Reimport";
            this.menuToolsWordReimport.Click += new System.EventHandler(this.menuToolsWordReimport_Click);
            this.menuToolsWordReimport.Select += new System.EventHandler(this.menuToolsWordReimport_Select);
            // 
            // menuToolsWordUnload
            // 
            this.menuToolsWordUnload.Index = 4;
            this.menuToolsWordUnload.Text = "&Unload";
            this.menuToolsWordUnload.Click += new System.EventHandler(this.menuToolsWordUnload_Click);
            this.menuToolsWordUnload.Select += new System.EventHandler(this.menuToolsWordUnload_Select);
            // 
            // menuSep55
            // 
            this.menuSep55.Index = 5;
            this.menuSep55.Text = "-";
            // 
            // menuToolsWordCheck
            // 
            this.menuToolsWordCheck.Index = 6;
            this.menuToolsWordCheck.Text = "&Check against Grapheme Inventory";
            this.menuToolsWordCheck.Click += new System.EventHandler(this.menuToolsWordCheck_Click);
            this.menuToolsWordCheck.Select += new System.EventHandler(this.menuToolsWordCheck_Select);
            // 
            // menuToolsText
            // 
            this.menuToolsText.Index = 1;
            this.menuToolsText.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuToolsTextImport,
            this.menuToolsTextMerge,
            this.menuToolsTextExport,
            this.menuToolsTextReimport,
            this.menuToolsTextUnload,
            this.menuSep56,
            this.menuToolsTextCheckGI,
            this.menuToolsTextCheckWL,
            this.menuToolsTextBuildWL});
            this.menuToolsText.Text = "Text &Data";
            // 
            // menuToolsTextImport
            // 
            this.menuToolsTextImport.Index = 0;
            this.menuToolsTextImport.Text = "&Import...";
            this.menuToolsTextImport.Click += new System.EventHandler(this.menuToolsTextImport_Click);
            this.menuToolsTextImport.Select += new System.EventHandler(this.menuToolsTextImport_Select);
            // 
            // menuToolsTextMerge
            // 
            this.menuToolsTextMerge.Index = 1;
            this.menuToolsTextMerge.Text = "&Merge...";
            this.menuToolsTextMerge.Click += new System.EventHandler(this.menuToolsTextMerge_Click);
            this.menuToolsTextMerge.Select += new System.EventHandler(this.menuToolsTextMerge_Select);
            // 
            // menuToolsTextExport
            // 
            this.menuToolsTextExport.Index = 2;
            this.menuToolsTextExport.Text = "&Export...";
            this.menuToolsTextExport.Click += new System.EventHandler(this.menuToolsTextExport_Click);
            this.menuToolsTextExport.Select += new System.EventHandler(this.menuToolsTextExport_Select);
            // 
            // menuToolsTextReimport
            // 
            this.menuToolsTextReimport.Index = 3;
            this.menuToolsTextReimport.Text = "&Reimport";
            this.menuToolsTextReimport.Click += new System.EventHandler(this.menuToolsTextReimport_Click);
            this.menuToolsTextReimport.Select += new System.EventHandler(this.menuToolsTextReimport_Select);
            // 
            // menuToolsTextUnload
            // 
            this.menuToolsTextUnload.Index = 4;
            this.menuToolsTextUnload.Text = "&Unload";
            this.menuToolsTextUnload.Click += new System.EventHandler(this.menuToolsTextUnload_Click);
            this.menuToolsTextUnload.Select += new System.EventHandler(this.menuToolsTextUnload_Select);
            // 
            // menuSep56
            // 
            this.menuSep56.Index = 5;
            this.menuSep56.Text = "-";
            // 
            // menuToolsTextCheckGI
            // 
            this.menuToolsTextCheckGI.Index = 6;
            this.menuToolsTextCheckGI.Text = "&Check against Grapheme Inventory";
            this.menuToolsTextCheckGI.Click += new System.EventHandler(this.menuToolsTextCheckGI_Click);
            this.menuToolsTextCheckGI.Select += new System.EventHandler(this.menuToolsTextCheckGI_Select);
            // 
            // menuToolsTextCheckWL
            // 
            this.menuToolsTextCheckWL.Index = 7;
            this.menuToolsTextCheckWL.Text = "Check against &Word List";
            this.menuToolsTextCheckWL.Click += new System.EventHandler(this.menuToolsTextCheckWL_Click);
            this.menuToolsTextCheckWL.Select += new System.EventHandler(this.menuToolsTextCheckWL_Select);
            // 
            // menuToolsTextBuildWL
            // 
            this.menuToolsTextBuildWL.Index = 8;
            this.menuToolsTextBuildWL.Text = "&Build SFM Word List File...";
            this.menuToolsTextBuildWL.Click += new System.EventHandler(this.menuToolsTextBuildWL_Click);
            this.menuToolsTextBuildWL.Select += new System.EventHandler(this.menuToolsTextBuildWL_Select);
            // 
            // menuToolsInventory
            // 
            this.menuToolsInventory.Index = 2;
            this.menuToolsInventory.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuToolsInventoryInit,
            this.menuToolsInventorySyllabary,
            this.menuToolsInventoryConsonants,
            this.menuToolsInventoryVowels,
            this.menuToolsInventoryTone,
            this.menuToolsInventorySyllograph,
            this.menuToolsInventorySave,
            this.menuToolsInventoryClear});
            this.menuToolsInventory.Text = "Grapheme &Inventory";
            // 
            // menuToolsInventoryInit
            // 
            this.menuToolsInventoryInit.Index = 0;
            this.menuToolsInventoryInit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuToolsInventoryInitWL,
            this.menuToolsInventoryInitTD,
            this.menuToolsInventoryInitPG});
            this.menuToolsInventoryInit.Text = "&Initialize Grapheme Inventory";
            // 
            // menuToolsInventoryInitWL
            // 
            this.menuToolsInventoryInitWL.Index = 0;
            this.menuToolsInventoryInitWL.Text = "From a &Word List...";
            this.menuToolsInventoryInitWL.Click += new System.EventHandler(this.menuToolsInventoryInitWL_Click);
            this.menuToolsInventoryInitWL.Select += new System.EventHandler(this.menuToolsInventoryInitWL_Select);
            // 
            // menuToolsInventoryInitTD
            // 
            this.menuToolsInventoryInitTD.Index = 1;
            this.menuToolsInventoryInitTD.Text = "From a &Text Data...";
            this.menuToolsInventoryInitTD.Click += new System.EventHandler(this.menuToolsInventoryInitTD_Click);
            this.menuToolsInventoryInitTD.Select += new System.EventHandler(this.menuToolsInventoryInitTD_Select);
            // 
            // menuToolsInventoryInitPG
            // 
            this.menuToolsInventoryInitPG.Index = 2;
            this.menuToolsInventoryInitPG.Text = "From Pre-defined &Graphemes...";
            this.menuToolsInventoryInitPG.Click += new System.EventHandler(this.menuToolsInventoryInitPG_Click);
            this.menuToolsInventoryInitPG.Select += new System.EventHandler(this.menuToolsInventoryInitPG_Select);
            // 
            // menuToolsInventorySyllabary
            // 
            this.menuToolsInventorySyllabary.Index = 1;
            this.menuToolsInventorySyllabary.Text = "Initialize Syllograph Inventory...";
            this.menuToolsInventorySyllabary.Click += new System.EventHandler(this.menuToolsInventorySyllabary_Click);
            this.menuToolsInventorySyllabary.Select += new System.EventHandler(this.menuToolsInventorySyllabary_Select);
            // 
            // menuToolsInventoryConsonants
            // 
            this.menuToolsInventoryConsonants.Index = 2;
            this.menuToolsInventoryConsonants.Text = "Update &Consonant Inventory...";
            this.menuToolsInventoryConsonants.Click += new System.EventHandler(this.menuToolsInventoryConsonants_Click);
            this.menuToolsInventoryConsonants.Select += new System.EventHandler(this.menuToolsInventoryConsonants_Select);
            // 
            // menuToolsInventoryVowels
            // 
            this.menuToolsInventoryVowels.Index = 3;
            this.menuToolsInventoryVowels.Text = "Update &Vowel Inventory...";
            this.menuToolsInventoryVowels.Click += new System.EventHandler(this.menuToolsInventoryVowels_Click);
            this.menuToolsInventoryVowels.Select += new System.EventHandler(this.menuToolsInventoryVowels_Select);
            // 
            // menuToolsInventoryTone
            // 
            this.menuToolsInventoryTone.Index = 4;
            this.menuToolsInventoryTone.Text = "Update &Tone Inventory...";
            this.menuToolsInventoryTone.Click += new System.EventHandler(this.menuToolsInventoryTone_Click);
            this.menuToolsInventoryTone.Select += new System.EventHandler(this.menuToolsInventoryTone_Select);
            // 
            // menuToolsInventorySyllograph
            // 
            this.menuToolsInventorySyllograph.Index = 5;
            this.menuToolsInventorySyllograph.Text = "Update Syllograph Inventory...";
            this.menuToolsInventorySyllograph.Click += new System.EventHandler(this.menuToolsInventorySyllograph_Click);
            this.menuToolsInventorySyllograph.Select += new System.EventHandler(this.menuToolsInventorySyllograph_Select);
            // 
            // menuToolsInventorySave
            // 
            this.menuToolsInventorySave.Index = 6;
            this.menuToolsInventorySave.Text = "&Save Grapheme Inventory...";
            this.menuToolsInventorySave.Click += new System.EventHandler(this.menuToolsInventorySave_Click);
            this.menuToolsInventorySave.Select += new System.EventHandler(this.menuToolsInventorySave_Select);
            // 
            // menuToolsInventoryClear
            // 
            this.menuToolsInventoryClear.Index = 7;
            this.menuToolsInventoryClear.MergeType = System.Windows.Forms.MenuMerge.Remove;
            this.menuToolsInventoryClear.Text = "&Clear Grapheme Inventory";
            this.menuToolsInventoryClear.Click += new System.EventHandler(this.menuToolsInventoryClear_Click);
            this.menuToolsInventoryClear.Select += new System.EventHandler(this.menuToolsInventoryClear_Select);
            // 
            // menuToolsParts
            // 
            this.menuToolsParts.Index = 3;
            this.menuToolsParts.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuToolsPartsInit,
            this.menuToolsPartsUpdate,
            this.menuToolsPartsSave});
            this.menuToolsParts.Text = "Parts of Speec&h";
            // 
            // menuToolsPartsInit
            // 
            this.menuToolsPartsInit.Index = 0;
            this.menuToolsPartsInit.Text = "&Initialize Parts of Speech";
            this.menuToolsPartsInit.Click += new System.EventHandler(this.menuToolsPartsInit_Click);
            this.menuToolsPartsInit.Select += new System.EventHandler(this.menuToolsPartsInit_Select);
            // 
            // menuToolsPartsUpdate
            // 
            this.menuToolsPartsUpdate.Index = 1;
            this.menuToolsPartsUpdate.Text = "&Update Parts of Speech...";
            this.menuToolsPartsUpdate.Click += new System.EventHandler(this.menuToolsPartsUpdate_Click);
            this.menuToolsPartsUpdate.Select += new System.EventHandler(this.menuToolsPartsUpdate_Select);
            // 
            // menuToolsPartsSave
            // 
            this.menuToolsPartsSave.Index = 2;
            this.menuToolsPartsSave.Text = "&Save Parts of Speech...";
            this.menuToolsPartsSave.Click += new System.EventHandler(this.menuToolsPartsSave_Click);
            this.menuToolsPartsSave.Select += new System.EventHandler(this.menuToolsPartsSave_Select);
            // 
            // menuToolsSight
            // 
            this.menuToolsSight.Index = 4;
            this.menuToolsSight.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuToolsSightUpdate,
            this.menuToolsSightSave,
            this.menuToolsSightCheckWL});
            this.menuToolsSight.Text = "&Sight Words";
            this.menuToolsSight.Select += new System.EventHandler(this.menuToolsSightUpdate_Select);
            // 
            // menuToolsSightUpdate
            // 
            this.menuToolsSightUpdate.Index = 0;
            this.menuToolsSightUpdate.Text = "&Update Sight Words...";
            this.menuToolsSightUpdate.Click += new System.EventHandler(this.menuToolsSightUpdate_Click);
            this.menuToolsSightUpdate.Select += new System.EventHandler(this.menuToolsSightUpdate_Select);
            // 
            // menuToolsSightSave
            // 
            this.menuToolsSightSave.Index = 1;
            this.menuToolsSightSave.Text = "&Save Sight Words...";
            this.menuToolsSightSave.Click += new System.EventHandler(this.menuToolsSightSave_Click);
            this.menuToolsSightSave.Select += new System.EventHandler(this.menuToolsSightSave_Select);
            // 
            // menuToolsSightCheckWL
            // 
            this.menuToolsSightCheckWL.Index = 2;
            this.menuToolsSightCheckWL.Text = "Check against &Word List";
            this.menuToolsSightCheckWL.Click += new System.EventHandler(this.menuToolsSightCheckWL_Click);
            this.menuToolsSightCheckWL.Select += new System.EventHandler(this.menuToolsSightCheckWL_Select);
            // 
            // menuToolsOrder
            // 
            this.menuToolsOrder.Index = 5;
            this.menuToolsOrder.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuToolsOrderUpdate,
            this.menuToolsOrderSave,
            this.menuToolsOrderCheck});
            this.menuToolsOrder.Text = "&Graphemes Taught";
            // 
            // menuToolsOrderUpdate
            // 
            this.menuToolsOrderUpdate.Index = 0;
            this.menuToolsOrderUpdate.Text = "&Update Graphemes Taught...";
            this.menuToolsOrderUpdate.Click += new System.EventHandler(this.menuToolsOrderUpdate_Click);
            this.menuToolsOrderUpdate.Select += new System.EventHandler(this.menuToolsOrderUpdate_Select);
            // 
            // menuToolsOrderSave
            // 
            this.menuToolsOrderSave.Index = 1;
            this.menuToolsOrderSave.Text = "&Save Graphemes Taught...";
            this.menuToolsOrderSave.Click += new System.EventHandler(this.menuToolsOrderSave_Click);
            this.menuToolsOrderSave.Select += new System.EventHandler(this.menuToolsOrderSave_Select);
            // 
            // menuToolsOrderCheck
            // 
            this.menuToolsOrderCheck.Index = 2;
            this.menuToolsOrderCheck.Text = "&Check against Grapheme Inventory";
            this.menuToolsOrderCheck.Click += new System.EventHandler(this.menuToolsOrderCheck_Click);
            this.menuToolsOrderCheck.Select += new System.EventHandler(this.menuToolsOrderCheck_Select);
            // 
            // menuSep50
            // 
            this.menuSep50.Index = 6;
            this.menuSep50.Text = "-";
            // 
            // menuToolsOptions
            // 
            this.menuToolsOptions.Index = 7;
            this.menuToolsOptions.Shortcut = System.Windows.Forms.Shortcut.CtrlJ;
            this.menuToolsOptions.Text = "&Options...";
            this.menuToolsOptions.Click += new System.EventHandler(this.menuToolsOptions_Click);
            this.menuToolsOptions.Select += new System.EventHandler(this.menuToolsOptions_Select);
            // 
            // menuWindow
            // 
            this.menuWindow.Index = 7;
            this.menuWindow.MdiList = true;
            this.menuWindow.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuWindowCascade,
            this.menuWindowTileH,
            this.menuWindowTileV});
            this.menuWindow.Text = "&Window";
            // 
            // menuWindowCascade
            // 
            this.menuWindowCascade.Index = 0;
            this.menuWindowCascade.Text = "&Cascade";
            this.menuWindowCascade.Click += new System.EventHandler(this.menuWindowCascade_Click);
            this.menuWindowCascade.Select += new System.EventHandler(this.menuWindowCascade_Select);
            // 
            // menuWindowTileH
            // 
            this.menuWindowTileH.Index = 1;
            this.menuWindowTileH.Text = "Tile &Horizontal";
            this.menuWindowTileH.Click += new System.EventHandler(this.menuWindowTileH_Click);
            this.menuWindowTileH.Select += new System.EventHandler(this.menuWindowTileH_Select);
            // 
            // menuWindowTileV
            // 
            this.menuWindowTileV.Index = 2;
            this.menuWindowTileV.Text = "Tile &Vertical";
            this.menuWindowTileV.Click += new System.EventHandler(this.menuWindowTileV_Click);
            this.menuWindowTileV.Select += new System.EventHandler(this.menuWindowTileV_Select);
            // 
            // menuHelp
            // 
            this.menuHelp.Index = 8;
            this.menuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuHelpHelp,
            this.menuHelpSetup,
            this.menuHelpPrimer,
            this.menuSep70,
            this.menuHelpNew,
            this.menuHelpAbout});
            this.menuHelp.Text = "&Help";
            this.menuHelp.Click += new System.EventHandler(this.menuHelpHelp_Click);
            // 
            // menuHelpHelp
            // 
            this.menuHelpHelp.Index = 0;
            this.menuHelpHelp.Shortcut = System.Windows.Forms.Shortcut.F1;
            this.menuHelpHelp.Text = "&Help";
            this.menuHelpHelp.Click += new System.EventHandler(this.menuHelpHelp_Click);
            this.menuHelpHelp.Select += new System.EventHandler(this.menuHelpHelp_Select);
            // 
            // menuHelpSetup
            // 
            this.menuHelpSetup.Index = 1;
            this.menuHelpSetup.Text = "&Setup Tutorial";
            this.menuHelpSetup.Click += new System.EventHandler(this.menuHelpSetup_Click);
            this.menuHelpSetup.Select += new System.EventHandler(this.menuHelpSetup_Select);
            // 
            // menuHelpPrimer
            // 
            this.menuHelpPrimer.Index = 2;
            this.menuHelpPrimer.Text = "&Primer Making Tutorial";
            this.menuHelpPrimer.Click += new System.EventHandler(this.menuHelpPrimer_Click);
            this.menuHelpPrimer.Select += new System.EventHandler(this.menuHelpPrimer_Select);
            // 
            // menuSep70
            // 
            this.menuSep70.Index = 3;
            this.menuSep70.Text = "-";
            // 
            // menuHelpAbout
            // 
            this.menuHelpAbout.Index = 5;
            this.menuHelpAbout.Text = "&About";
            this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
            this.menuHelpAbout.Select += new System.EventHandler(this.menuHelpAbout_Select);
            // 
            // menuTest
            // 
            this.menuTest.Index = 9;
            this.menuTest.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuTest1,
            this.menuTest2,
            this.menuTest3,
            this.menuTestBrowse,
            this.menuTestTemp});
            this.menuTest.Text = "Test";
            this.menuTest.Visible = false;
            // 
            // menuTest1
            // 
            this.menuTest1.Index = 0;
            this.menuTest1.Text = "Test1";
            this.menuTest1.Click += new System.EventHandler(this.menuTest1_Click);
            // 
            // menuTest2
            // 
            this.menuTest2.Index = 1;
            this.menuTest2.Text = "Test2";
            this.menuTest2.Click += new System.EventHandler(this.menuTest2_Click);
            // 
            // menuTest3
            // 
            this.menuTest3.Index = 2;
            this.menuTest3.Text = "Test3";
            this.menuTest3.Click += new System.EventHandler(this.menuTest3_Click);
            // 
            // menuTestBrowse
            // 
            this.menuTestBrowse.Index = 3;
            this.menuTestBrowse.Text = "&Browse Word List";
            this.menuTestBrowse.Click += new System.EventHandler(this.menuTestBrowse_Click);
            // 
            // menuTestTemp
            // 
            this.menuTestTemp.Index = 4;
            this.menuTestTemp.Text = "Temp";
            this.menuTestTemp.Click += new System.EventHandler(this.menuTestTemp_Click);
            // 
            // tbApp
            // 
            this.tbApp.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tbbNew,
            this.tbbOpen,
            this.tbbSave,
            this.tbbPreview,
            this.tbbPrint,
            this.tbbCut,
            this.tbbCopy,
            this.tbbPaste,
            this.tbbFind,
            this.tbbOptions,
            this.tbbHelp});
            this.tbApp.DropDownArrows = true;
            this.tbApp.ImageList = this.imageListPP;
            this.tbApp.Location = new System.Drawing.Point(0, 0);
            this.tbApp.Name = "tbApp";
            this.tbApp.ShowToolTips = true;
            this.tbApp.Size = new System.Drawing.Size(942, 28);
            this.tbApp.TabIndex = 1;
            this.tbApp.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbApp_ButtonClick);
            // 
            // tbbNew
            // 
            this.tbbNew.ImageIndex = 0;
            this.tbbNew.Name = "tbbNew";
            this.tbbNew.ToolTipText = "New";
            // 
            // tbbOpen
            // 
            this.tbbOpen.ImageIndex = 1;
            this.tbbOpen.Name = "tbbOpen";
            this.tbbOpen.ToolTipText = "Open";
            // 
            // tbbSave
            // 
            this.tbbSave.ImageIndex = 2;
            this.tbbSave.Name = "tbbSave";
            this.tbbSave.ToolTipText = "Save";
            // 
            // tbbPreview
            // 
            this.tbbPreview.ImageIndex = 3;
            this.tbbPreview.Name = "tbbPreview";
            this.tbbPreview.ToolTipText = "Preview";
            // 
            // tbbPrint
            // 
            this.tbbPrint.ImageIndex = 4;
            this.tbbPrint.Name = "tbbPrint";
            this.tbbPrint.ToolTipText = "Print";
            // 
            // tbbCut
            // 
            this.tbbCut.ImageIndex = 5;
            this.tbbCut.Name = "tbbCut";
            this.tbbCut.ToolTipText = "Cut";
            // 
            // tbbCopy
            // 
            this.tbbCopy.ImageIndex = 6;
            this.tbbCopy.Name = "tbbCopy";
            this.tbbCopy.ToolTipText = "Copy";
            // 
            // tbbPaste
            // 
            this.tbbPaste.ImageIndex = 7;
            this.tbbPaste.Name = "tbbPaste";
            this.tbbPaste.ToolTipText = "Paste";
            // 
            // tbbFind
            // 
            this.tbbFind.ImageIndex = 8;
            this.tbbFind.Name = "tbbFind";
            this.tbbFind.ToolTipText = "Find";
            // 
            // tbbOptions
            // 
            this.tbbOptions.ImageIndex = 9;
            this.tbbOptions.Name = "tbbOptions";
            this.tbbOptions.ToolTipText = "Options";
            // 
            // tbbHelp
            // 
            this.tbbHelp.ImageIndex = 10;
            this.tbbHelp.Name = "tbbHelp";
            this.tbbHelp.ToolTipText = "Help";
            // 
            // imageListPP
            // 
            this.imageListPP.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListPP.ImageStream")));
            this.imageListPP.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListPP.Images.SetKeyName(0, "");
            this.imageListPP.Images.SetKeyName(1, "");
            this.imageListPP.Images.SetKeyName(2, "");
            this.imageListPP.Images.SetKeyName(3, "");
            this.imageListPP.Images.SetKeyName(4, "");
            this.imageListPP.Images.SetKeyName(5, "");
            this.imageListPP.Images.SetKeyName(6, "");
            this.imageListPP.Images.SetKeyName(7, "");
            this.imageListPP.Images.SetKeyName(8, "");
            this.imageListPP.Images.SetKeyName(9, "");
            this.imageListPP.Images.SetKeyName(10, "");
            // 
            // ssApp
            // 
            this.ssApp.BackColor = System.Drawing.SystemColors.Control;
            this.ssApp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslWordList,
            this.tsslTextData,
            this.tsslWnd,
            this.tspbPrimerPro,
            this.tsslInfo});
            this.ssApp.Location = new System.Drawing.Point(0, 539);
            this.ssApp.Name = "ssApp";
            this.ssApp.Size = new System.Drawing.Size(942, 24);
            this.ssApp.TabIndex = 3;
            this.ssApp.Text = "Status bar";
            // 
            // tsslWordList
            // 
            this.tsslWordList.BackColor = System.Drawing.SystemColors.Control;
            this.tsslWordList.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslWordList.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.tsslWordList.Name = "tsslWordList";
            this.tsslWordList.Size = new System.Drawing.Size(76, 19);
            this.tsslWordList.Text = "WL: wordlist";
            this.tsslWordList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsslTextData
            // 
            this.tsslTextData.BackColor = System.Drawing.SystemColors.Control;
            this.tsslTextData.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslTextData.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.tsslTextData.Name = "tsslTextData";
            this.tsslTextData.Size = new System.Drawing.Size(74, 19);
            this.tsslTextData.Text = "TD: textdata";
            this.tsslTextData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsslWnd
            // 
            this.tsslWnd.BackColor = System.Drawing.SystemColors.Control;
            this.tsslWnd.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslWnd.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.tsslWnd.Name = "tsslWnd";
            this.tsslWnd.Size = new System.Drawing.Size(64, 19);
            this.tsslWnd.Text = "PrimerPro";
            this.tsslWnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tspbPrimerPro
            // 
            this.tspbPrimerPro.Enabled = false;
            this.tspbPrimerPro.Name = "tspbPrimerPro";
            this.tspbPrimerPro.Size = new System.Drawing.Size(208, 20);
            this.tspbPrimerPro.Step = 1;
            this.tspbPrimerPro.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.tspbPrimerPro.Visible = false;
            // 
            // tsslInfo
            // 
            this.tsslInfo.BackColor = System.Drawing.SystemColors.Control;
            this.tsslInfo.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslInfo.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.tsslInfo.Name = "tsslInfo";
            this.tsslInfo.Size = new System.Drawing.Size(713, 19);
            this.tsslInfo.Spring = true;
            this.tsslInfo.Text = "...info...";
            this.tsslInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // menuHelpNew
            // 
            this.menuHelpNew.Index = 4;
            this.menuHelpNew.Text = "What\'s &New";
            this.menuHelpNew.Click += new System.EventHandler(this.menuHelpNew_Click);
            this.menuHelpNew.Select += new System.EventHandler(this.menuHelpNew_Select);
            // 
            // AppWindow
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(942, 563);
            this.Controls.Add(this.ssApp);
            this.Controls.Add(this.tbApp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Menu = this.menuTop;
            this.Name = "AppWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrimerPro";
            this.Closed += new System.EventHandler(this.AppWindow_Closed);
            this.Load += new System.EventHandler(this.AppWindow_Load);
            this.ssApp.ResumeLayout(false);
            this.ssApp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new AppWindow());
		}

		private void AppWindow_Load(object sender, System.EventArgs e)
		{
            //SetVersionInfo();
		}

		private void AppWindow_Closed(object sender, System.EventArgs e)
		//Save information for future use
		{
            // Remember current project
            if (this.ProjInfo.ProjectName != "")
            {
                this.SaveProject();
                if (Environment.GetEnvironmentVariable(AppWindow.kPrimerPro, EnvironmentVariableTarget.User) != this.ProjInfo.ProjectName)
                    Environment.SetEnvironmentVariable(AppWindow.kPrimerPro, this.ProjInfo.ProjectName, EnvironmentVariableTarget.User);
            }
            else    //current project does not have a name, but save files anyway
            {
                this.SaveProject();
            }
		}

		//process menu options
		private void menuFileNew_Click(object sender, System.EventArgs e)
		{
			AppView mdiChild = new AppView(pWindow, "");
			m_ViewCntr++;

			mdiChild.Text = strApp + m_ViewCntr.ToString();
			mdiChild.MdiParent = this;
			mdiChild.Show();
			this.ResetStatusBar();
		}

		private void menuFileOpen_Click(object sender, System.EventArgs e)
        {
            UpdStatusBarInfo(menuFileOpen.Text.Replace("&", ""));
            OpenFileDialog ofd1 = new OpenFileDialog();
            ofd1.Filter = "RTF files (*.rtf)|*.rtf|All Files (*.*)|*.*";
            ofd1.FileName = "";
            ofd1.DefaultExt = "*.rtf";
            ofd1.InitialDirectory = Settings.OptionSettings.DataFolder;
            ofd1.CheckFileExists = true;
            ofd1.CheckPathExists = true;
            ofd1.Title = menuFileOpen.Text.Replace("&", ""); ;

            DialogResult dr1 = ofd1.ShowDialog();

            if (dr1 == DialogResult.OK)
            {
                AppView mdiChild = new AppView(pWindow, ofd1.FileName);
                m_ViewCntr++;
                string strFileName = mdiChild.FileName;
                int nStart = strFileName.LastIndexOf(Constants.Backslash) + 1;
                int nLen = strFileName.IndexOf(Constants.Period) - nStart;
                mdiChild.Text = strFileName.Substring(nStart, nLen);
                mdiChild.MdiParent = this;
                mdiChild.Show();
            }
            this.ResetStatusBar();
        }

        private void menuFileClose_Click(object sender, System.EventArgs e)
		{
            CloseActiveDocument();
            this.ResetStatusBar();
		}

		private void menuFileSave_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuFileSave.Text.Replace("&", ""));
			AppView mdiChild = (AppView) this.ActiveMdiChild;
            if (mdiChild != null)
            {
                string strFileName = mdiChild.FileName;
                if (strFileName != "")
                    mdiChild.SaveFile(strFileName);
                else menuFileAs_Click(sender, e);
                this.ResetStatusBar();
            }
            else
            {
                string strText = m_Settings.LocalizationTable.GetMessage("App5");
                if (strText == "")
                    strText = "No active document to save";
                else MessageBox.Show(strText);
            }
            this.ResetStatusBar();
		}

		private void menuFileAs_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuFileAs.Text.Replace("&", ""));
            AppView mdiChild = (AppView)this.ActiveMdiChild;
            if (mdiChild != null)
            {
                SaveFileDialog sfd1 = new SaveFileDialog();
                sfd1.Filter = "RTF files (*.rtf)|*.rtf|All Files (*.*)|*.*";
                sfd1.FileName = "";
                sfd1.DefaultExt = "*.rtf";
                sfd1.CheckFileExists = false;
                sfd1.CheckPathExists = true;
                sfd1.InitialDirectory = Settings.OptionSettings.DataFolder;
                sfd1.Title = menuFileAs.Text.Replace("&", "");

                DialogResult dr1 = sfd1.ShowDialog();

                if (dr1 == DialogResult.OK)
                {
                    string strFileName;
                    strFileName = sfd1.FileName;
                    mdiChild.SaveFile(strFileName);
                    int nStart = strFileName.LastIndexOf("\\") + 1;
                    int nLen = strFileName.IndexOf(".") - nStart;
                    mdiChild.Text = strFileName.Substring(nStart, nLen);
                }
            }
            //else MessageBox.Show("No active document to save");
            else
            {
                string strText = m_Settings.LocalizationTable.GetMessage("App5");
                if (strText == "")
                    strText = "No active document to save";
                MessageBox.Show(strText);
            }
            this.ResetStatusBar();
		}

        private void menuFileProjNew_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuFileProjNew.Text.Replace("&", ""));
            if (this.ProjInfo.ProjectName != "")
                this.SaveProject();

            FormNewProject form = new FormNewProject(m_Settings);
            form.ShowDialog();
            if (form.DialogResult != DialogResult.OK)
            {
                //MessageBox.Show("Project not created");
			    string strText = m_Settings.LocalizationTable.GetMessage("App6");
			    if (strText == "")
				    strText  = "Project not created";
			    MessageBox.Show(strText);
            }
            else
            {
                if (form.ProjectName != "")
                {
                    GraphemeInventory gi = form.InitialGraphemeInventory;
                    this.ProjInfo.BuildProjectInfo(form.ProjectName);
                    this.ProjInfo.SaveInfo(this.ProjInfo.FileName);
                    pWindow.Text = AppWindow.kPrimerPro + " - " + this.ProjInfo.ProjectName;

                    m_Settings = new Settings(this.ProjInfo);

                    //Rebuild localization table
                    m_Settings.LocalizationTable = this.GetLocalizationTable();

                    // determine project folder
                    string strProjectFolder = m_Settings.PrimerProFolder + AppWindow.kBackSlash +
                        this.ProjInfo.ProjectName;
                    if (!Directory.Exists(strProjectFolder))
                    {
                        try
                        {
                            Directory.CreateDirectory(strProjectFolder);
                        }
                        catch
                        {
                            strProjectFolder = m_Settings.PrimerProFolder;
                        }
                    }

                    //Build option settings
                    OptionList ol = new OptionList(strProjectFolder, m_ProjInfo.OptionsFile);
                    this.Settings.OptionSettings = ol;
                    this.Settings.OptionSettings.SaveToFile(m_ProjInfo.OptionsFile);	//Save options to xml file

                    // Build Parts of Speech table from default
                    PSTable pst = new PSTable(this.Settings);
                    string strFileName = this.Settings.GetAppFolder() + AppWindow.kBackSlash +
                        AppWindow.kDefaultPSTableName;
                    pst.LoadFromFile(strFileName);
                    strFileName = this.Settings.OptionSettings.PSTableFile;
                    pst.SaveToFile(strFileName);
                    this.Settings.PSTable = pst;

                    //Save Grapheme Inventory
                    this.Settings.GraphemeInventory = gi;               //Save initialized GI
                    strFileName = this.Settings.OptionSettings.GraphemeInventoryFile;
                    gi.SaveToFile(strFileName);

                    //Save Sight Words (empty)
                    SightWords sw = new SightWords(this.Settings);
                    this.Settings.SightWords = sw;
                    strFileName = this.Settings.OptionSettings.SightWordsFile;
                    sw.SaveToFile(strFileName);

                    //Save Graphemes Taught (empty)
                    GraphemeTaughtOrder gto = new GraphemeTaughtOrder(this.Settings);
                    this.Settings.GraphemesTaught = gto;
                    strFileName = this.Settings.OptionSettings.GraphemeTaughtOrderFile;
                    gto.SaveToFile(strFileName);
                }
                //else MessageBox.Show("Project name not specified - project not created");
                else
                {
                    string strText = m_Settings.LocalizationTable.GetMessage("App7");
                    if (strText == "")
                        strText = "Project name not specified - project not created";
                    MessageBox.Show(strText);
                }
            }
            this.UpdStatusBarTD();
            this.UpdStatusBarWL();
            this.UpdStatusBarWnd();
            string str = m_Settings.LocalizationTable.GetMessage("App80");
            if (str == "")
                str = "…Ready…";
            this.UpdStatusBarInfo(str);
            this.ResetStatusBar();
        }

        private void menuFileProjSelect_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuFileProjSelect.Text.Replace("&", ""));
            string strMsg = "";
            if (this.ProjInfo.ProjectName != "")
                SaveProject();          //Save current project info

            ArrayList alProjects = new ArrayList();
            Font fnt = m_Settings.OptionSettings.GetDefaultFont();
            string[] files = Directory.GetFiles(m_Settings.GetPrimerProFolder(),
                "*.prj");
            foreach (string file in files)
            {
                if (this.ProjInfo.FileName != file)
                    alProjects.Add(Funct.ShortFileName(file));
            }
            FormProjectSelect form = new FormProjectSelect(alProjects, fnt);
            form.Text = menuFileProjSelect.Text.Replace("&", "");
            DialogResult dr = form.ShowDialog();

            //if (ofd.ShowDialog() == DialogResult.OK)
            //{
            if (dr == DialogResult.OK)
            {
                string strFileName = m_Settings.GetPrimerProFolder() + AppWindow.kBackSlash +
                     form.SelectedProject + ".prj";

                //if (this.ProjInfo.LoadInfo(ofd.FileName))
                if (this.ProjInfo.LoadInfo(strFileName))
                {
                    strProj = this.ProjInfo.ProjectName;
                    this.ProjInfo.BuildProjectInfo(strProj);
                    //this.ProjInfo.SaveInfo(this.ProjInfo.FileName);
                    pWindow.Text = AppWindow.kPrimerPro + " - " + m_ProjInfo.ProjectName;
                    this.SetupProject();
                    //this.UpdateMenuForLanguage(m_Settings.OptionSettings.UILanguage);
                    this.UpdateMenuForLocalization();
                    if (this.Settings.OptionSettings.SimplifiedMenu)
                        this.UpdateMenuForSimplified();
                    //MessageBox.Show(m_ProjInfo.ProjectName + " project has been loaded");
                    strMsg = m_Settings.LocalizationTable.GetMessage("App1");
                    if (strMsg == "")
                        strMsg = "project has been loaded";
                    MessageBox.Show(m_ProjInfo.ProjectName + Constants.Space + strMsg);
                }
                //else MessageBox.Show(m_ProjInfo.ProjectName + " project has failed to load");
                else 
                {
                    strMsg = m_Settings.LocalizationTable.GetMessage("App2");
                    if (strMsg == "")
                        strMsg = "project has failed to load";
                    MessageBox.Show(m_ProjInfo.ProjectName + Constants.Space + strMsg);
                }
            }
            //else MessageBox.Show("Project not selected");
            else
            {
                strMsg = m_Settings.LocalizationTable.GetMessage("App8");
                if (strMsg == "")
                    strMsg = "Project not selected";
                MessageBox.Show(strMsg);
            }
            this.UpdStatusBarTD();
            this.UpdStatusBarWL();
            this.UpdStatusBarWnd();
            strMsg = m_Settings.LocalizationTable.GetMessage("App80");
            if (strMsg == "")
                strMsg = "…Ready…";
            this.UpdStatusBarInfo(strMsg);
            this.ResetStatusBar();
        }

        private void menuFileProjDelete_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuFileProjDelete.Text.Replace("&", ""));
            string strMsg = "";
            if (this.ProjInfo.ProjectName != "")
                SaveProject();          //Save current project info

            // Select project to be deleted
            ArrayList alProjects = new ArrayList();
            Font fnt = m_Settings.OptionSettings.GetDefaultFont();
            string[] files = Directory.GetFiles(m_Settings.GetPrimerProFolder(),
                "*.prj");
            foreach (string file in files)
            {
               if (this.ProjInfo.FileName != file)
                 alProjects.Add(Funct.ShortFileName(file));
            }

            FormProjectSelect form = new FormProjectSelect(alProjects, fnt);
            form.Text = menuFileProjDelete.Text.Replace("&", "");
            DialogResult dr = form.ShowDialog();
            form.Close();

            if (dr == DialogResult.OK)
            {
                string strFileName = m_Settings.GetPrimerProFolder() + AppWindow.kBackSlash +
                     form.SelectedProject + ".prj";
                string strProjName = Funct.ShortFileName(strFileName);
                ProjectInfo pi = new ProjectInfo();
                if (pi.LoadInfo(strFileName))
                {
                    OptionList ol = new OptionList();
                    ol.LoadFromFile(pi.OptionsFile);

                    //delete grapheme inventory file
                    strFileName = ol.GraphemeInventoryFile;
                    if (File.Exists(strFileName))
                            File.Delete(strFileName);

                    // delete sight words file
                    strFileName = ol.SightWordsFile;
                    if (File.Exists(strFileName))
                        File.Delete(strFileName);

                    // delete grapheme taught orderfile
                    strFileName = ol.GraphemeTaughtOrderFile;
                    if (File.Exists(strFileName))
                        File.Delete(strFileName);

                    // delete parts of speech file
                    strFileName = ol.PSTableFile;
                    if (File.Exists(strFileName))
                        File.Delete(strFileName);

                    // delete options file
                    strFileName = pi.OptionsFile;
                    if (File.Exists(strFileName))
                        File.Delete(strFileName);
                    
                    // delete project file
                    strFileName = pi.FileName;
                    if (File.Exists(strFileName))
                        File.Delete(strFileName);

                    //MessageBox.Show(strProjName + Constants.Space + "deleted");
                    strMsg = m_Settings.LocalizationTable.GetMessage("App121");
                    if (strMsg == "")
                        strMsg = "deleted";
                    MessageBox.Show(strProjName + Constants.Space + strMsg);
                }
                //else MessageBox.Show("Project not found");
                else
                {
                    strMsg = m_Settings.LocalizationTable.GetMessage("App122");
                    if (strMsg == "")
                        strMsg = "Project not found";
                    MessageBox.Show(strMsg);
                }
                
            }
            //else MessageBox.Show("Project not deleted");
            else
            {
                strMsg = m_Settings.LocalizationTable.GetMessage("App123");
                if (strMsg == "")
                    strMsg = "Project not deleted";
                MessageBox.Show(strMsg);
            }

            if (this.ProjInfo.ProjectName != "")
                this.ProjInfo.LoadInfo(this.ProjInfo.FileName);   //Restore current project
 
            this.UpdStatusBarTD();
            this.UpdStatusBarWL();
            this.UpdStatusBarWnd();
            string str = m_Settings.LocalizationTable.GetMessage("App80");
            if (str == "")
                str = "…Ready…";
            this.UpdStatusBarInfo(str);
            this.ResetStatusBar();
        }

        private void menuFileProjExport_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuFileProjExport.Text.Replace("&", ""));
            string strMsg = "";

            FormProjectExport form = new FormProjectExport(m_Settings.OptionSettings.DataFolder, m_Settings.OptionSettings.TemplateFolder, 
                m_Settings.LocalizationTable);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                if (form.ExportFolder != "")
                {
                    if (Directory.Exists(form.ExportFolder))
                    {
                        if (form.ExportFolder != m_Settings.OptionSettings.DataFolder)
                        {
                            if (form.ExportFolder != m_Settings.OptionSettings.TemplateFolder)
                            {
                                PackageList pl = new PackageList(m_Settings);
                                pl.Build();         // Build package list from current project.
                                if (pl.Write(AppWindow.kPLName, form.ExportFolder, form.IncludeDataFolder,
                                    form.IncludeTemplateFolder))
                                {
                                    //MessageBox.Show("Project has been exported and backed up")
                                    strMsg = m_Settings.LocalizationTable.GetMessage("App11");
                                    if (strMsg == "")
                                        strMsg = "Project has been exported and backed up";
                                    MessageBox.Show(strMsg);
                                }
                                else
                                {
                                    MessageBox.Show("Write Package List error");
                                }
                            }
                            //else MessageBox.Show("Export folder can not be the same as the template folder");
                            else
                            {
                                strMsg = m_Settings.LocalizationTable.GetMessage("App12");
                                if (strMsg == "")
                                    strMsg = "Export folder can not be the same as the template folder";
                                MessageBox.Show(strMsg);
                            }
                        }
                        //else MessageBox.Show("Export folder can not be the same as the data folder");
                        else
                        {
                            strMsg = m_Settings.LocalizationTable.GetMessage("App13");
                            if (strMsg == "")
                                strMsg = "Export folder can not be the same as the data folder";
                            MessageBox.Show(strMsg);
                        }
                    }
                    //else MessageBox.Show("Export folder does not exist");
                    else
                    {
                        strMsg = m_Settings.LocalizationTable.GetMessage("App14");
                        if (strMsg == "")
                            strMsg = "Export folder does not exist";
                        MessageBox.Show(strMsg);
                    }
                }
                //else MessageBox.Show("Export folder not specified - project not exported");
                else
                {
                    strMsg = m_Settings.LocalizationTable.GetMessage("App15");
                    if (strMsg == "")
                        strMsg = "Export folder not specified - project not exported";
                    MessageBox.Show(strMsg);
                }
            }
            //else MessageBox.Show("Project not exported or backed up");
            else
            {
                strMsg = m_Settings.LocalizationTable.GetMessage("App16");
                if (strMsg == "")
                    strMsg = "Project not exported or backed up";
                MessageBox.Show(strMsg);
            }

            this.UpdStatusBarTD();
            this.UpdStatusBarWL();
            this.UpdStatusBarWnd();
            string strText = m_Settings.LocalizationTable.GetMessage("App80");
            if (strText == "")
                this.UpdStatusBarInfo("...Ready...");
            else this.UpdStatusBarInfo(strText);
            this.ResetStatusBar();
        }

        private void menuFileProjImport_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuFileProjImport.Text.Replace("&", ""));
            string strPath = "";
            string strInpFile = "";
            string strOtpFile = "";
            string strMsg = "";

            //FormProjectImport fpb = new FormProjectImport();
            FormProjectImport form = new FormProjectImport(m_Settings, m_Settings.LocalizationTable);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                if (form.FromFolder != "")
                {
                    if (form.ToFolder != "")
                    {
                        if (Directory.Exists(form.FromFolder))
                        {
                            if (!Directory.Exists(form.ToFolder))
                            {
                                try
                                {
                                    Directory.CreateDirectory(form.ToFolder);
                                }
                                catch
                                {
                                    Directory.CreateDirectory(m_Settings.PrimerProFolder);
                                }
                            }
                            strPath = form.FromFolder + AppWindow.kBackSlash + AppWindow.kPLName;
                            if (File.Exists(strPath))
                            {
                                string strDataFolder = form.FromFolder + AppWindow.kBackSlash +
                                     AppWindow.kData;
                                string strTemplateFolder = form.FromFolder + AppWindow.kBackSlash +
                                     AppWindow.kTemplate;
                                if (form.TemplateFolder != "")
                                {
                                    strPath = form.FromFolder + AppWindow.kBackSlash + AppWindow.kTemplate;
                                    if (File.Exists(form.TemplateFolder))
                                        Funct.FolderCopy(strPath, form.TemplateFolder, true);
                                    else Funct.FolderCopy(strPath, form.ToFolder, true);
                                }
                                if (form.DataFolder != "")
                                {
                                    strPath = form.FromFolder + AppWindow.kBackSlash + AppWindow.kData;
                                    if (Directory.Exists(form.DataFolder))
                                        Funct.FolderCopy(strPath, form.DataFolder, true);
                                    else Funct.FolderCopy(strPath, form.ToFolder, true);
                                }

                                PackageList pl = new PackageList(m_Settings);
                                if (pl.Read(AppWindow.kPLName, form.FromFolder))
                                {
                                    strInpFile = form.FromFolder + AppWindow.kBackSlash + pl.OptionsFile;
                                    string strOptionsFile = m_Settings.OptionSettings.PrimerProFolder +
                                        AppWindow.kBackSlash + pl.OptionsFile;
                                    File.Copy(strInpFile, strOptionsFile, true);
                                    OptionList ol = new OptionList(m_Settings.PrimerProFolder,
                                        strOptionsFile);
                                    ol.LoadFromFile(strOptionsFile);
                                    if (form.DataFolder == "")
                                        ol.DataFolder = form.ToFolder;
                                    else ol.DataFolder = form.DataFolder;
                                    if (form.TemplateFolder == "")
                                        ol.TemplateFolder = ol.DataFolder;
                                    else ol.TemplateFolder = form.TemplateFolder;

                                    strInpFile = form.FromFolder + AppWindow.kBackSlash + pl.GraphemeInventoryFile;
                                    strOtpFile = form.ToFolder + AppWindow.kBackSlash + pl.GraphemeInventoryFile;
                                    File.Copy(strInpFile, strOtpFile, true);
                                    ol.GraphemeInventoryFile = strOtpFile;

                                    strInpFile = form.FromFolder + AppWindow.kBackSlash + pl.SightWordsFile;
                                    strOtpFile = form.ToFolder + AppWindow.kBackSlash + pl.SightWordsFile;
                                    File.Copy(strInpFile, strOtpFile, true);
                                    ol.SightWordsFile = strOtpFile;

                                    strInpFile = form.FromFolder + AppWindow.kBackSlash + pl.GraphemeTaughtOrderFile;
                                    strOtpFile = form.ToFolder + AppWindow.kBackSlash + pl.GraphemeTaughtOrderFile;
                                    File.Copy(strInpFile, strOtpFile, true);
                                    ol.GraphemeTaughtOrderFile = strOtpFile;

                                    strInpFile = form.FromFolder + AppWindow.kBackSlash + pl.PSTableFile;
                                    strOtpFile = form.ToFolder + AppWindow.kBackSlash + pl.PSTableFile;
                                    File.Copy(strInpFile, strOtpFile, true);
                                    ol.PSTableFile = strOtpFile;

                                    if (pl.WordListFile != "")
                                    {
                                        strInpFile = form.FromFolder + AppWindow.kBackSlash + pl.WordListFile;
                                        strOtpFile = form.ToFolder + AppWindow.kBackSlash + pl.WordListFile;
                                        File.Copy(strInpFile, strOtpFile, true);
                                        ol.WordListFile = strOtpFile;
                                    }

                                    if (pl.TextDataFile != "")
                                    {
                                        strInpFile = form.FromFolder + AppWindow.kBackSlash + pl.TextDataFile;
                                        strOtpFile = form.ToFolder + AppWindow.kBackSlash + pl.TextDataFile;
                                        File.Copy(strInpFile, strOtpFile, true);
                                        ol.TextDataFile = strOtpFile;
                                    }

                                    ol.SaveToFile(strOptionsFile);

                                    string strProjectFile = m_Settings.OptionSettings.PrimerProFolder +
                                        AppWindow.kBackSlash + pl.ProjectFile;
                                    ProjectInfo info = new ProjectInfo();
                                    info.BuildProjectInfo(pl.ProjectName);
                                    info.SaveInfo(strProjectFile);

                                    // If restored project is current project,  set it up again
                                    if (this.Settings.ProjInfo.ProjectName == pl.ProjectName)
                                        this.SetupProject();
 
                                    //MessageBox.Show("Project has been Imported");
                                    strMsg = m_Settings.LocalizationTable.GetMessage("App17");
                                    if (strMsg == "")
                                        strMsg = "Project has been Imported";
                                    MessageBox.Show(strMsg);
                                }
                                //else MessageBox.Show("Project was not imported");
                                else
                                {
                                    strMsg = m_Settings.LocalizationTable.GetMessage("App18");
                                    if (strMsg == "")
                                        strMsg = "Project was not imported";
                                    MessageBox.Show(strMsg);
                                }
                            }
                            //else MessageBox.Show("Packaging List not found in From folder - Project was not imported");
                            else
                            {
                                strMsg = m_Settings.LocalizationTable.GetMessage("App19");
                                if (strMsg == "")
                                    strMsg = "Packaging List not found in From folder - Project was not imported";
                                MessageBox.Show(strMsg);
                            }
                        }
                        //else MessageBox.Show("From folder does not exist");
                        else
                        {
                            strMsg = m_Settings.LocalizationTable.GetMessage("App21");
                            if (strMsg == "")
                                strMsg = "From folder does not exist";
                            MessageBox.Show(strMsg);
                        }
                    }
                    //else MessageBox.Show("To Folder not specified - project not imported");
                    else
                    {
                        strMsg = m_Settings.LocalizationTable.GetMessage("App22");
                        if (strMsg == "")
                            strMsg = "To Folder not specified - project not imported";
                        MessageBox.Show(strMsg);
                    }
                }
                //else MessageBox.Show("From folder not specified - project not imported");
                else
                {
                    strMsg = m_Settings.LocalizationTable.GetMessage("App23");
                    if (strMsg == "")
                        strMsg = "From folder not specified - project not imported";
                    MessageBox.Show(strMsg);
                }
            }
            //else MessageBox.Show("Project not imported or restored");
            else
            {
                strMsg = m_Settings.LocalizationTable.GetMessage("App24");
                if (strMsg == "")
                    strMsg = "Project not imported or restored";
                MessageBox.Show(strMsg);
            }

            this.UpdStatusBarTD();
            this.UpdStatusBarWL();
            this.UpdStatusBarWnd();
            string strText = m_Settings.LocalizationTable.GetMessage("App80");
            if (strText == "")
                this.UpdStatusBarInfo("...Ready...");
            else this.UpdStatusBarInfo(strText);
            this.ResetStatusBar();
        }

        private void menuFilePrint_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuFilePrint.Text.Replace("&", ""));
            string strMsg = "";
			AppView mdiChild = (AppView)this.ActiveMdiChild;
            if (mdiChild != null)
            {
                try
                {
                    StringReader strrdr = new StringReader(mdiChild.Rtb.Text);
                    Font fnt = mdiChild.GetFont();
                    TextPrintDocument tpd = new TextPrintDocument(strrdr, fnt);

                    if (this.Settings.PageSettings != null)
                        tpd.DefaultPageSettings = this.Settings.PageSettings;
                    PrintDialog dlg = new PrintDialog();
                    dlg.UseEXDialog = true;
                    dlg.Document = tpd;
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        tpd.Print();
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error on Print - " + ex.Message);
                    strMsg = m_Settings.LocalizationTable.GetMessage("App25");
                    if (strMsg == "")
                        strMsg = "Error on Print";
                    MessageBox.Show(strMsg + " - " + ex.Message);
                }
            }
            //else MessageBox.Show("No active document to print");
            else
            {
                strMsg = m_Settings.LocalizationTable.GetMessage("App26");
                if (strMsg == "")
                    strMsg = "No active document to print";
                MessageBox.Show(strMsg);
            }
			this.ResetStatusBar();
		}

        private void menuFilePreview_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuFilePreview.Text.Replace("&", ""));
            string strMsg = "";
			AppView mdiChild = (AppView)this.ActiveMdiChild;
			if (mdiChild != null)
			{
				try
				{
					StringReader strrdr = new StringReader(mdiChild.Rtb.Text);
                    Font fnt = mdiChild.GetFont();
                    TextPrintDocument tpd = new TextPrintDocument(strrdr, fnt);
					
					if (this.Settings.PageSettings != null)
						tpd.DefaultPageSettings = this.Settings.PageSettings;
					PrintPreviewDialog dlg = new PrintPreviewDialog();
					dlg.Document = tpd;
                    dlg.StartPosition = FormStartPosition.CenterParent;
					dlg.ShowDialog();
				}
				catch(Exception ex)
				{
                    //MessageBox.Show("Error on Print Preview - " + ex.Message);
                    strMsg = m_Settings.LocalizationTable.GetMessage("App27");
                    if (strMsg == "")
                        strMsg = "Error on Print Preview";
                    MessageBox.Show(strMsg + " - " + ex.Message);
                }
			}
            //else MessageBox.Show("No active document to preview");
            else
            {
                strMsg = m_Settings.LocalizationTable.GetMessage("App28");
                if (strMsg == "")
                    strMsg = "No active document to preview";
                MessageBox.Show(strMsg);
            }
            this.ResetStatusBar();
		}

		private void menuFileSetup_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuFileSetup.Text.Replace("&", ""));
			try
			{
				PageSetupDialog dlg = new PageSetupDialog();
				if (this.Settings.PageSettings == null)
				{
					this.Settings.PageSettings = new PageSettings();
				}
				dlg.PageSettings = this.Settings.PageSettings;
                //dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.ShowDialog();
			}
			catch(Exception ex)
			{
                //MessageBox.Show("Error on Page Setup - " + ex.Message);
                string strMsg = m_Settings.LocalizationTable.GetMessage("App29");
                if (strMsg == "")
                    strMsg = "Error on Page Setup";
                MessageBox.Show(strMsg + " - " + ex.Message);
            }
			this.ResetStatusBar();
		}

		private void menuExit_Click(object sender, System.EventArgs e)
		{
			AppWindow_Closed(sender, e);
			Application.Exit();
		}

		private void menuEditUndo_Click(object sender, System.EventArgs e)
		{
			AppView mdiChild = (AppView)this.ActiveMdiChild;
			if (mdiChild != null)
			{
				RichTextBox rtb = mdiChild.Rtb;
				rtb.Undo();
			}
			this.ResetStatusBar();
		}

		private void menuEditCut_Click(object sender, System.EventArgs e)
		{
			AppView mdiChild = (AppView)this.ActiveMdiChild;
            if (mdiChild != null)
            {
                RichTextBox rtb = mdiChild.Rtb;
                if (!rtb.SelectedText.Equals(""))
                {
                    Clipboard.SetDataObject(rtb.SelectedText, true);
                    rtb.SelectedText = "";
                }
            }
            //else MessageBox.Show("No active document available");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("App30");
                if (strMsg == "")
                    strMsg = "No active document available";
                MessageBox.Show(strMsg);
            }
			this.ResetStatusBar();
		}

		private void menuEditCopy_Click(object sender, System.EventArgs e)
		{
			AppView mdiChild = (AppView)this.ActiveMdiChild;
            if (mdiChild != null)
            {
                RichTextBox rtb = mdiChild.Rtb;
                if (!rtb.SelectedText.Equals(""))
                {
                    Clipboard.SetDataObject(rtb.SelectedText, true);
                }
            }
            //else MessageBox.Show("No active document available");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("App30");
                if (strMsg == "")
                    strMsg = "No active document available";
                MessageBox.Show(strMsg);
            }
            this.ResetStatusBar();
		}

		private void menuEditPaste_Click(object sender, System.EventArgs e)
		{
			AppView mdiChild = (AppView)this.ActiveMdiChild;
			if (mdiChild != null)
			{
				RichTextBox rtb = mdiChild.Rtb;
				try
				{
					DataObject data = (DataObject) Clipboard.GetDataObject();
					if ( data.GetDataPresent(DataFormats.Rtf) )
					{
						string text = (string) data.GetData(DataFormats.Rtf);
						if ( !text.Equals("") )
							rtb.SelectedRtf = text;
					}
					else if ( data.GetDataPresent(DataFormats.Text) )
					{
						string text = (string) data.GetData(DataFormats.Text);
						if ( !text.Equals("") )
							rtb.SelectedText= text;
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
            }
            //else MessageBox.Show("No active document available");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("App30");
                if (strMsg == "")
                    strMsg = "No active document available";
                MessageBox.Show(strMsg);
            }
            this.ResetStatusBar();
            this.ResetStatusBar();
		}

		private void menuEditSelect_Click(object sender, System.EventArgs e)
		{
            AppView mdiChild = (AppView)this.ActiveMdiChild;
            if (mdiChild != null)
			{
				RichTextBox rtb = mdiChild.Rtb;
				rtb.SelectAll();
			}
            //else MessageBox.Show("No active document available");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("App30");
                if (strMsg == "")
                    strMsg = "No active document available";
                MessageBox.Show(strMsg);
            }
            this.ResetStatusBar();
            this.ResetStatusBar();
		}

		private void menuEditClear_Click(object sender, System.EventArgs e)
		{
			AppView mdiChild = (AppView)this.ActiveMdiChild;
			if (mdiChild != null)
			{
				RichTextBox rtb = mdiChild.Rtb;
				rtb.Clear();
			}
            //else MessageBox.Show("No active document available");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("App30");
                if (strMsg == "")
                    strMsg = "No active document available";
                MessageBox.Show(strMsg);
            }
            this.ResetStatusBar();
            this.ResetStatusBar();
		}

		private void menuEditFind_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuEditFind.Text.Replace("&",""));
			AppView mdiChild = (AppView)this.ActiveMdiChild;
			if (mdiChild != null)
			{
				mdiChild.FindCmd();
			}
            //else MessageBox.Show("No active document available");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("App30");
                if (strMsg == "")
                    strMsg = "No active document available";
                MessageBox.Show(strMsg);
            }
            this.ResetStatusBar();
            this.ResetStatusBar();
		}

		private void menuEditNext_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuEditNext.Text.Replace("&",""));
			AppView mdiChild = (AppView)this.ActiveMdiChild;
			if (mdiChild != null)
			{
				mdiChild.FindNextCmd();
			}
            //else MessageBox.Show("No active document available");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("App30");
                if (strMsg == "")
                    strMsg = "No active document available";
                MessageBox.Show(strMsg);
            }
            this.ResetStatusBar();
		}

		private void menuEditReplace_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuEditReplace.Text.Replace("&",""));
			AppView mdiChild = (AppView)this.ActiveMdiChild;
			if (mdiChild != null)
			{
				mdiChild.ReplaceCmd();
			}
            //else MessageBox.Show("No active document available");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App30"));
            this.ResetStatusBar();
		}

		private void menuViewToolbar_Click(object sender, System.EventArgs e)
		{
			if (this.menuViewToolbar.Checked)
			{
				this.menuViewToolbar.Checked = false;
				this.tbApp.Hide();
			}
			else
			{
				this.menuViewToolbar.Checked = true;
				this.tbApp.Show();
			}
		this.ResetStatusBar();
		}

		private void menuViewStatus_Click(object sender, System.EventArgs e)
		{
			if (this.menuViewStatus.Checked)
			{
				this.menuViewStatus.Checked = false;
				this.ssApp.Hide();
			}
			else
			{
				this.menuViewStatus.Checked = true;
				this.ssApp.Show();
			}
            this.ResetStatusBar();
		}

		private void menuViewMode_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuViewMode.Text.Replace("&", ""));
            //FormSearchInsertionMode fpb = new FormSearchInsertionMode(this.Settings.SearchInsertionResults,
            //    this.Settings.SearchInsertionDefinitions);
            FormSearchInsertionMode form = new FormSearchInsertionMode(m_Settings, m_Settings.LocalizationTable);
			form.ShowDialog(this);
            if (form.DialogResult == DialogResult.OK)
            {
                this.Settings.SearchInsertionResults = form.SearchInsertionResults;
                this.Settings.SearchInsertionDefinitions = form.SearchInsertionDefinitions;
            }
			this.ResetStatusBar();
		}

		private void menuViewShow_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuViewShow.Text.Replace("&", ""));
			AppView mdiChild = (AppView)this.ActiveMdiChild;
			if (mdiChild != null)
			{
				mdiChild.HideProcessedSearchDefinitions();
				mdiChild.ShowProcessedSearchDefinitions();
			}
			this.ResetStatusBar();
		}

		private void menuViewHide_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuViewHide.Text.Replace("&", ""));
			AppView mdiChild = (AppView)this.ActiveMdiChild;
			if (mdiChild != null)
			{
				mdiChild.HideProcessedSearchDefinitions();
			}
			this.ResetStatusBar();
		}

		private void menuViewClear_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuViewClear.Text.Replace("&", ""));
			AppView mdiChild = (AppView)this.ActiveMdiChild;
			if (mdiChild != null)
			{
				mdiChild.HideProcessedSearchDefinitions();
				mdiChild.ShowProcessedSearchDefinitions();
				mdiChild.ClearProcessedSearchDefinitions();
				this.ResetStatusBar();
			}
		}

		private void menuViewUnprocessed_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuViewUnprocessed.Text.Replace("&", ""));
			AppView mdiChild = (AppView)this.ActiveMdiChild;
			if (mdiChild != null)
			{
				mdiChild.RunUnprocessedSearchDefinitions();
				string strRtf = mdiChild.Rtb.Rtf;
				mdiChild.Rtb.Clear();
				mdiChild.Display(strRtf);
			}
			this.ResetStatusBar();
		}

		private void menuViewWordList_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuViewWordList.Text.Replace("&", ""));
			string strText = "";
			string strRtf = "";
			AppView mdiChild = (AppView)this.ActiveMdiChild;
            if (mdiChild == null)
            {
                mdiChild = new AppView(pWindow, "");
                m_ViewCntr++;
                mdiChild.Text = strApp + m_ViewCntr.ToString();
                mdiChild.MdiParent = this;
                mdiChild.Show();
            }

            WordList wl = this.Settings.WordList;
            if (wl == null)
                wl = new WordList();

            //strText = "Word List" + Environment.NewLine;
            strText = m_Settings.LocalizationTable.GetMessage("App82");
            if (strText == "")
                strText = "Word List";
            strText += Environment.NewLine;
			strText += Environment.NewLine;
			strText += wl.GetDisplayHeadings();
            strRtf = mdiChild.FormatWordList(strText);
            mdiChild.Display(strRtf);

			ArrayList alText = wl.RetrieveWordListAsArray();
            strRtf = mdiChild.FormatWordList(alText);
            mdiChild.Display(strRtf);

            //strText += wl.WordCount() + " words in list" + Environment.NewLine;
            strText = m_Settings.LocalizationTable.GetMessage("App83");
            if (strText == "")
                strText = "words in list";

            strText = Environment.NewLine + wl.WordCount().ToString() + Constants.Space + strText;
			strText += Environment.NewLine;
			strRtf = mdiChild.FormatWordList(strText);
			mdiChild.Display(strRtf);
			this.ResetStatusBar();
		}

		private void menuViewTextData_Click(object sender, System.EventArgs e)
        {
            UpdStatusBarInfo(menuViewTextData.Text.Replace("&", ""));
            string strText = "";
            string strRtf = "";
            //ArrayList alText = null;
            AppView mdiChild = (AppView)this.ActiveMdiChild;
            if (mdiChild == null)
            {
                mdiChild = new AppView(pWindow, "");
                m_ViewCntr++;
                mdiChild.Text = strApp + m_ViewCntr.ToString();
                mdiChild.MdiParent = this;
                mdiChild.Show();
            }

            TextData td = this.Settings.TextData;
            if (td == null)
                td = new TextData(this.Settings);

            //strText = "Text Data" + Environment.NewLine;
            strText = m_Settings.LocalizationTable.GetMessage("App84");
            if (strText == "")
                strText = "Text Data";
            strText += Environment.NewLine;
            strRtf = mdiChild.FormatText(strText, false);
            mdiChild.Display(strRtf);

            strText = td.BuildTextDataAsString();
            strRtf = mdiChild.FormatText(strText, false);
            mdiChild.Display(strRtf);

            strText = "";
            string str = "";
            //strText += td.ParagraphCount() + " paragraphs in data" + Environment.NewLine;
            //strText += td.SentenceCount() + " sentences in data" + Environment.NewLine;
            //strText += td.WordCount() + " words in data" + Environment.NewLine;
            strText += td.ParagraphCount().ToString() + Constants.Space;
            str = m_Settings.LocalizationTable.GetMessage("App85");
            if (str == "")
                str = " paragraphs in data";
            strText += str + Environment.NewLine;
            strText += td.SentenceCount().ToString() + Constants.Space;
            str = m_Settings.LocalizationTable.GetMessage("App86");
            if (str == "")
                str = "sentences in data";
            strText += str + Environment.NewLine;
            strText += td.WordCount().ToString() + Constants.Space;
            str = m_Settings.LocalizationTable.GetMessage("App87");
            if (str == "")
                str = "words in data";
            strText += str + Environment.NewLine;
            strText += Environment.NewLine;
            strRtf = mdiChild.FormatText(strText, false);
            mdiChild.Display(strRtf);
            this.ResetStatusBar();
        }

        private void menuViewInventory_Click(object sender, EventArgs e)
 		{
			string strText = "";
            string str = "";
			string strRtf = "";
			UpdStatusBarInfo(menuViewInventory.Text.Replace("&", ""));
			AppView mdiChild = (AppView)this.ActiveMdiChild;
            if (mdiChild == null)
            {
                mdiChild = new AppView(pWindow, "");
                m_ViewCntr++;
                mdiChild.Text = strApp + m_ViewCntr.ToString();
                mdiChild.MdiParent = this;
                mdiChild.Show();
            }

            GraphemeInventory m_GraphemeInventory = this.Settings.GraphemeInventory;
            if (m_GraphemeInventory == null)
                m_GraphemeInventory = new GraphemeInventory(this.Settings);

            //strText = "Grapheme Inventory - Consonants" + Environment.NewLine;
            str = m_Settings.LocalizationTable.GetMessage("App88");
            if (str == "")
                str = "Grapheme Inventory - Consonants";
            strText += str + Environment.NewLine + Environment.NewLine;
            strText += m_GraphemeInventory.RetrieveSortedConsonants() + Environment.NewLine;
            //m_GraphemeInventory.ConsonantCount() + " consonants in inventory";
            str = m_Settings.LocalizationTable.GetMessage("App89");
            if (str == "")
                str = "consonants in inventory";
            strText += m_GraphemeInventory.ConsonantCount().ToString()  + Constants.Space + str + Environment.NewLine;
            strText += Environment.NewLine;
            
            //strText += "Grapheme Inventory - Vowels" + Environment.NewLine;
            str = m_Settings.LocalizationTable.GetMessage("App90");
            if (str == "")
                str = "Grapheme Inventory - Vowels";
            strText += str + Environment.NewLine + Environment.NewLine;
            strText += m_GraphemeInventory.RetrieveSortedVowels() + Environment.NewLine;
            //" vowels in inventory";
            str = m_Settings.LocalizationTable.GetMessage("App91");
            if (str ==  "")
                str = "vowels in inventory";
            strText += m_GraphemeInventory.VowelCount().ToString() + Constants.Space + str + Environment.NewLine;
            strText += Environment.NewLine;
            
            //strText += "Grapheme Inventory - Tones" + Environment.NewLine;
            str = m_Settings.LocalizationTable.GetMessage("App92");
            if (str == "")
                str = "Grapheme Inventory - Tones";
            strText += str + Environment.NewLine +  Environment.NewLine;
            strText += m_GraphemeInventory.RetrieveSortedTones() + Environment.NewLine;
            //" tones in inventory";
            str = m_Settings.LocalizationTable.GetMessage("App93");
            if (str == "")
                str = "tones in inventory";
            strText += m_GraphemeInventory.ToneCount().ToString() + Constants.Space + str + Environment.NewLine;
            strText += Environment.NewLine;

            //strText += "Grapheme Inventory - Syllographs" + Environment.NewLine;
            str = m_Settings.LocalizationTable.GetMessage("App119");
            if (str == "")
                str = "Grapheme Inventory - Syllographs";
            strText += str + Environment.NewLine + Environment.NewLine;
            strText += m_GraphemeInventory.RetrieveSortedSyllographs() + Environment.NewLine;
            //" syllographs in inventory";
            str = m_Settings.LocalizationTable.GetMessage("App120");
            if (str == "")
                str = "syllographs in inventory";
            strText += m_GraphemeInventory.SyllographCount().ToString() + Constants.Space + str + Environment.NewLine;
            strText += Environment.NewLine;

            strRtf = mdiChild.FormatGraphemes(strText);
            mdiChild.Display(strRtf);
			this.ResetStatusBar();
		}

		private void menuViewPS_Click(object sender, System.EventArgs e)
		{
			string strText = "";
            string str = "";
			string strRtf = "";
			UpdStatusBarInfo(menuViewPS.Text.Replace("&", ""));
			AppView mdiChild = (AppView)this.ActiveMdiChild;
            if (mdiChild == null)
            {
                mdiChild = new AppView(pWindow, "");
                m_ViewCntr++;
                mdiChild.Text = strApp + m_ViewCntr.ToString();
                mdiChild.MdiParent = this;
                mdiChild.Show();
            }

            PSTable pst = this.Settings.PSTable;
            if (pst == null)
                pst = new PSTable(this.Settings);

            //strText = "Parts of Speech" + Environment.NewLine;
            str = m_Settings.LocalizationTable.GetMessage("App94");
            if (str == "")
                str = "Parts of Speech";
            strText += str + Environment.NewLine + Environment.NewLine;
            strText += pst.RetrieveSortedTable() + Environment.NewLine;
            strText += pst.Count().ToString() + Constants.Space;
            //" entries" + Environment.NewLine;
            str = m_Settings.LocalizationTable.GetMessage("App95");
            if (str == "")
                str = "entries";
            strText += str + Environment.NewLine + Environment.NewLine;
            strRtf = mdiChild.FormatTable(strText);
            mdiChild.Display(strRtf);
 			this.ResetStatusBar();
		}

		private void menuViewSite_Click(object sender, System.EventArgs e)
		{
			string strText = "";
            string str = "";
			string strRtf = "";
			UpdStatusBarInfo(menuViewSite.Text.Replace("&", ""));
			AppView mdiChild = (AppView)this.ActiveMdiChild;
            if (mdiChild == null)
            {
                mdiChild = new AppView(pWindow, "");
                m_ViewCntr++;
                mdiChild.Text = strApp + m_ViewCntr.ToString();
                mdiChild.MdiParent = this;
                mdiChild.Show();
            }

            SightWords sw = this.Settings.SightWords;
            if (sw == null)
                sw = new SightWords(this.Settings);

            //strText = "Sight Words" + Environment.NewLine;
            str = m_Settings.LocalizationTable.GetMessage("App96");
            if (str == "")
                str = "Sight Words";
            strText += str + Environment.NewLine + Environment.NewLine;
            strText += sw.RetrieveSortedTable() + Environment.NewLine;
            strText += sw.Count().ToString() + Constants.Space;
            //" entries" + Environment.NewLine;
            str = m_Settings.LocalizationTable.GetMessage("App95");
            if (str == "")
                str = " entries";
            strText += str + Environment.NewLine + Environment.NewLine;
            strRtf = mdiChild.FormatTable(strText);
            mdiChild.Display(strRtf);
 			this.ResetStatusBar();
		}

        private void menuViewGraphemes_Click(object sender, EventArgs e)
        {
            string strText = "";
            string str = "";
            string strRtf = "";
            UpdStatusBarInfo(menuViewGraphemes.Text.Replace("&", ""));
            
            AppView mdiChild = (AppView)this.ActiveMdiChild;
            if (mdiChild == null)
            {
                mdiChild = new AppView(pWindow, "");
                m_ViewCntr++;
                mdiChild.Text = strApp + m_ViewCntr.ToString();
                mdiChild.MdiParent = this;
                mdiChild.Show();
            }

            GraphemeTaughtOrder gto = this.Settings.GraphemesTaught;
            if (gto == null)
                gto = new GraphemeTaughtOrder(this.Settings);

            //strText = "Graphemes Taught" + Environment.NewLine;
            str = m_Settings.LocalizationTable.GetMessage("App97");
            if (str == "")
                str = "Graphemes Taught";
            strText = str + Environment.NewLine;
            strText += Environment.NewLine;
            strText += gto.RetrieveGraphemes();
            strText += Environment.NewLine;
            strText += gto.Count().ToString();
            strText += Constants.Space;
            //" entries" + Environment.NewLine;
            str = m_Settings.LocalizationTable.GetMessage("App95");
            if (str == "")
                str = "entries";
            strText += str + Environment.NewLine;
            strText += Environment.NewLine;
            strRtf = mdiChild.FormatTable(strText);
            mdiChild.Display(strRtf);
            this.ResetStatusBar();
        }

		private void menuFormatFont_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuFormatFont.Text.Replace("&", ""));
			AppView mdiChild = (AppView)this.ActiveMdiChild;
			if (mdiChild != null)
			{
				RichTextBox rtb = mdiChild.Rtb;
				string strFont = this.Settings.OptionSettings.DefaultFontName;
				float emSize = (float) this.Settings.OptionSettings.DefaultFontSize;
				FontStyle style = this.Settings.OptionSettings.DefaultFontStyle;

				FontDialog dlg = new FontDialog();
				dlg.Font = new Font(strFont, emSize, style);
				if ( dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK )
				{
					rtb.SelectionFont = dlg.Font;
				}
			}
            //else MessageBox.Show("Need to open a new active document");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("App31");
                if (strMsg == "")
                    strMsg = "Need to open a new active document";
                MessageBox.Show(strMsg);
            }
            this.ResetStatusBar();
		}

		private void menuFormatColor_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuFormatColor.Text.Replace("&", ""));
			AppView mdiChild = (AppView)this.ActiveMdiChild;
			if (mdiChild != null)
			{
				RichTextBox rtb = mdiChild.Rtb;
				ColorDialog dlg = new ColorDialog();
				dlg.AllowFullOpen  = false;
				dlg.SolidColorOnly = true;
				if ( dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK )
				{
					rtb.SelectionColor = dlg.Color;
				}
			}
            //else MessageBox.Show("Need to open a new active document");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("App31");
                if (strMsg == "")
                    strMsg = "Need to open a new active document";
                MessageBox.Show(strMsg);
            }
            this.ResetStatusBar();
		}

		private void menuFormatWrap_Click(object sender, System.EventArgs e)
		{
			AppView mdiChild = (AppView)this.ActiveMdiChild;
			if (mdiChild != null)
			{
				RichTextBox rtb = mdiChild.Rtb;
				if ( this.menuFormatWrap.Checked )
				{
					this.menuFormatWrap.Checked = false;
					rtb.WordWrap = false;
				}
				else
				{
					this.menuFormatWrap.Checked = true;
					rtb.WordWrap = true;
				}
			}
            //else MessageBox.Show("Need to open a new active document");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("App31");
                if (strMsg == "")
                    strMsg = "Need to open a new active document";
                MessageBox.Show(strMsg);
            }
        }

        private void menuReportVowel_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuReportVowel.Text.Replace("&", ""));
            string strTemplateName = Settings.GetAppFolder() + Constants.Backslash
                + "VowelReportTemplate.rtf";
            string strReportName = Settings.OptionSettings.DataFolder + Constants.Backslash
                + "VowelReport.rtf";
            if (File.Exists(strTemplateName))
            {
                string strRtf = "";
                int nBgn = 0;
                int nLen = 0;
                AppView mdiChild = new AppView(pWindow, strTemplateName);
                m_ViewCntr++;
                nBgn = strReportName.LastIndexOf(Constants.Backslash) + 1;
                nLen = strReportName.IndexOf(Constants.Period) - nBgn;
                mdiChild.FileName = strReportName;
                mdiChild.Text = strReportName.Substring(nBgn, nLen);
                mdiChild.MdiParent = this;
                mdiChild.Show();

                mdiChild.RunUnprocessedSearchDefinitions();
                strRtf = mdiChild.Rtb.Rtf;
                mdiChild.Rtb.Clear();
                mdiChild.Display(strRtf);
            }
            //else MessageBox.Show("Report Templates does not exist.");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("App32");
                if (strMsg == "")
                    strMsg = "Report Templates does not exist.";
                MessageBox.Show(strMsg);
            }
            this.ResetStatusBar();
        }

        private void menuReportConsonant_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuReportConsonant.Text.Replace("&", ""));
            string strTemplateName = Settings.GetAppFolder() + Constants.Backslash
                + "ConsonantReportTemplate.rtf";
            string strReportName = Settings.OptionSettings.DataFolder + Constants.Backslash
                + "ConsonantReport.rtf";
            if (File.Exists(strTemplateName))
            {
                string strRtf = "";
                int nBgn = 0;
                int nLen = 0;
                AppView mdiChild = new AppView(pWindow, strTemplateName);
                m_ViewCntr++;
                nBgn = strReportName.LastIndexOf(Constants.Backslash) + 1;
                nLen = strReportName.IndexOf(Constants.Period) - nBgn;
                mdiChild.FileName = strReportName;
                mdiChild.Text = strReportName.Substring(nBgn, nLen);
                mdiChild.MdiParent = this;
                mdiChild.Show();

                mdiChild.RunUnprocessedSearchDefinitions();
                strRtf = mdiChild.Rtb.Rtf;
                mdiChild.Rtb.Clear();
                mdiChild.Display(strRtf);
            }
            //else MessageBox.Show("Report Template does not exist.");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("App32");
                if (strMsg == "")
                    strMsg = "Report Template does not exist.";
                MessageBox.Show(strMsg);
            }
            this.ResetStatusBar();
        }

        private void menuReportPrimer_Click(object sender, EventArgs e)
        {
			UpdStatusBarInfo(menuReportPrimer.Text.Replace("&", ""));
			string strTemplateName = Settings.GetAppFolder() + Constants.Backslash
				+ "PrimerProgressionReportTemplate.rtf";
			string strReportName = Settings.OptionSettings.DataFolder + Constants.Backslash
				+ "PrimerProgressionReport.rtf";
            if (File.Exists(strTemplateName))
            {
                string strRtf = "";
                int nBgn = 0;
                int nLen = 0;
                AppView mdiChild = new AppView(pWindow, strTemplateName);
                m_ViewCntr++;
                nBgn = strReportName.LastIndexOf(Constants.Backslash) + 1;
                nLen = strReportName.IndexOf(Constants.Period) - nBgn;
                mdiChild.FileName = strReportName;
                mdiChild.Text = strReportName.Substring(nBgn, nLen);
                mdiChild.MdiParent = this;
                mdiChild.Show();

                mdiChild.RunUnprocessedSearchDefinitions();
                strRtf = mdiChild.Rtb.Rtf;
                mdiChild.Rtb.Clear();
                mdiChild.Display(strRtf);
            }
            //else MessageBox.Show("Report template does not exist");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("App32");
                if (strMsg == "")
                    strMsg = "Report template does not exist";
                MessageBox.Show(strMsg);
            }
        }

        private void menuReportGenerate_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuReportGenerate.Text.Replace("&", ""));
			OpenFileDialog ofd1 = new OpenFileDialog();
			ofd1.Filter = "RTF files (*.rtf)|*.rtf|All Files (*.*)|*.*";
			ofd1.FileName = "";
			ofd1.DefaultExt = "*.rtf";
			ofd1.InitialDirectory = this.Settings.OptionSettings.TemplateFolder;
			ofd1.CheckFileExists = true;
			ofd1.CheckPathExists = true;
            ofd1.Title = menuReportGenerate.Text.Replace("&", "");

			DialogResult dr1 = ofd1.ShowDialog();
			if (dr1 == DialogResult.OK)
			{
				string strFileName = "";
				string strRtf = "";
				int nBgn = 0;
				int nLen = 0;
				AppView mdiChild = new AppView(pWindow, ofd1.FileName);
				m_ViewCntr++;
				strFileName = mdiChild.FileName;
				nBgn = strFileName.LastIndexOf(Constants.Backslash) + 1;
				nLen = strFileName.IndexOf(Constants.Period)- nBgn;
				mdiChild.Text = strFileName.Substring(nBgn, nLen);
				mdiChild.FileName = "";
				mdiChild.MdiParent = this;
				mdiChild.Show();

				mdiChild.RunUnprocessedSearchDefinitions();
				strRtf = mdiChild.Rtb.Rtf;
				mdiChild.Rtb.Clear();
				mdiChild.Display(strRtf);
			}
			this.ResetStatusBar();
		}

        private void menuReportEdit_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuReportEdit.Text.Replace("&", ""));
			OpenFileDialog ofd1 = new OpenFileDialog();
			ofd1.Filter = "RTF files (*.rtf)|*.rtf|All Files (*.*)|*.*";
			ofd1.FileName = "";
			ofd1.DefaultExt = "*.rtf";
			ofd1.InitialDirectory = this.Settings.OptionSettings.TemplateFolder;
			ofd1.CheckFileExists = true;
			ofd1.CheckPathExists = true;
            ofd1.Title = menuReportEdit.Text.Replace("&", "");

			DialogResult dr1 = ofd1.ShowDialog();
			if (dr1 == DialogResult.OK)
			{
				string strFileName = "";
				int nBgn = 0;
				int nLen = 0;
				AppView mdiChild = new AppView(pWindow, ofd1.FileName);
				m_ViewCntr++;
				strFileName = mdiChild.FileName;
				nBgn = strFileName.LastIndexOf(Constants.Backslash) + 1;
				nLen = strFileName.IndexOf(Constants.Period)- nBgn;
				mdiChild.Text = strFileName.Substring(nBgn, nLen);
				mdiChild.MdiParent = this;
				mdiChild.Show();
			}
			this.ResetStatusBar();
		}

		private void menuSearchWordGrapheme_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuSearchWordGrapheme.Text.Replace("&", ""));
			m_SearchCntr++;
			string strText = "";
			string strRtf = "";
			
			AppView mdiChild = (AppView)this.ActiveMdiChild;
            GraphemeSearchWL search = new GraphemeSearchWL(m_SearchCntr, m_Settings);
            if (search.SetupSearch())
            {
                if (search.BrowseView)
                {
                    WordList wl = this.Settings.WordList;
                    m_SearchList.Add(search);       //Add search to List for future use
                    search.BrowseGraphemeSearch(wl);
                }
                else
                {
                    if (mdiChild == null)
                    {
                        mdiChild = new AppView(pWindow, "");
                        m_ViewCntr++;
                        mdiChild.Text = strApp + m_ViewCntr.ToString();
                        mdiChild.MdiParent = this;
                        mdiChild.Show();
                    }

                    if (this.Settings.SearchInsertionDefinitions)
                    {
                        if (this.Settings.SearchInsertionResults)
                        {
                            WordList wl = this.Settings.WordList;
                            m_SearchList.Add(search);	//Add search to List for future use
                            search = search.ExecuteGraphemeSearch(wl);
                            strText = search.BuildSearch();
                        }
                        else
                        {
                            strText = search.BuildDefinition();
                        }
                    }
                    else
                    {
                        if (this.Settings.SearchInsertionResults)
                        {
                            WordList wl = this.Settings.WordList;
                            m_SearchList.Add(search);	//Add search to List for future use
                            search = search.ExecuteGraphemeSearch(wl);
                            strText = search.BuildResults();
                        }
                    }
                    if (search.SearchCount > AppView.kBlockLines)
                    {
                        ArrayList al = mdiChild.RetrieveAsArray(strText);
                        strRtf = mdiChild.FormatWordList(al);
                    }
                    else strRtf = mdiChild.FormatWordList(strText);
                    mdiChild.Display(strRtf);
                }
            }
            //else MessageBox.Show("Search cancel");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("App10");
                if (strMsg == "")
                    strMsg = "Search cancel";
                MessageBox.Show(strMsg);
            }
 			this.ResetStatusBar();
		}

        private void menuSearchWordFrequency_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuSearchWordGrapheme.Text.Replace("&", ""));
            m_SearchCntr++;
            string strText = "";
            string strRtf = "";

            AppView mdiChild = (AppView)this.ActiveMdiChild;
            FrequencyWLSearch search = new FrequencyWLSearch(m_SearchCntr, m_Settings);
            if (search.SetupSearch())
            {
                if (mdiChild == null)
                {
                    mdiChild = new AppView(pWindow, "");
                    m_ViewCntr++;
                    mdiChild.Text = strApp + m_ViewCntr.ToString();
                    mdiChild.MdiParent = this;
                    mdiChild.Show();
                }

                if (this.Settings.SearchInsertionDefinitions)
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        WordList wl = this.Settings.WordList;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteFrequencySearch(wl);
                        strText = search.BuildSearch();
                    }
                    else
                    {
                        strText = search.BuildDefinition();
                    }
                }
                else
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        WordList wl = this.Settings.WordList;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteFrequencySearch(wl);
                        strText = search.BuildResults();
                    }
                }

                strRtf = mdiChild.FormatTable(strText);
                mdiChild.Display(strRtf);
            }
            //else MessageBox.Show("Search cancel");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("App10");
                if (strMsg == "")
                    strMsg = "Search cancel";
                MessageBox.Show(strMsg);
            }
            this.ResetStatusBar();
        }

        private void menuSearchWordBuild_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuSearchWordBuild.Text.Replace("&", ""));
			m_SearchCntr++;
			string strText = "";
			string strRtf = "";
			
			AppView mdiChild = (AppView)this.ActiveMdiChild;
			BuildableWordSearchWL search = new BuildableWordSearchWL(m_SearchCntr, m_Settings);
            if (search.SetupSearch())
            {
                if (search.BrowseView)
                {
                    WordList wl = this.Settings.WordList;
                    m_SearchList.Add(search);       //Add search to List for future use
                    search = search.BrowseBuildableSearch(wl);
                }
                else
                {
                    if (mdiChild == null)
                    {
                        mdiChild = new AppView(pWindow, "");
                        m_ViewCntr++;
                        mdiChild.Text = strApp + m_ViewCntr.ToString();
                        mdiChild.MdiParent = this;
                        mdiChild.Show();
                    }

                    if (this.Settings.SearchInsertionDefinitions)
                    {
                        if (this.Settings.SearchInsertionResults)
                        {
                            WordList wl = this.Settings.WordList;
                            m_SearchList.Add(search);		//Add search to List for future use
                            search = search.ExecuteBuildableSearch(wl);
                            strText = search.BuildSearch();
                        }
                        else strText = search.BuildDefinition();
                    }
                    else
                    {
                        if (this.Settings.SearchInsertionResults)
                        {
                            WordList wl = this.Settings.WordList;
                            m_SearchList.Add(search);		//Add search to List for future use
                            search = search.ExecuteBuildableSearch(wl);
                            strText = search.BuildResults();
                        }
                    }
                    if (search.SearchCount > AppView.kBlockLines)
                    {
                        ArrayList al = mdiChild.RetrieveAsArray(strText);
                        strRtf = mdiChild.FormatWordList(al);
                    }
                    else strRtf = mdiChild.FormatWordList(strText);
                    mdiChild.Display(strRtf);
                }
            }
            //else MessageBox.Show("Search Cancel");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("App10");
                if (strMsg == "")
                    strMsg = "Search cancel";
                MessageBox.Show(strMsg);
            }
            this.ResetStatusBar();
		}

		private void menuSearchWordAdvanced_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuSearchWordAdvanced.Text.Replace("&", ""));
			m_SearchCntr++;
			string strText = "";
			string strRtf = "";
			
			AppView mdiChild = (AppView)this.ActiveMdiChild;
			AdvancedSearch search = new AdvancedSearch(m_SearchCntr, m_Settings);
            if (search.SetupSearch())
            {
                if (search.BrowseView)
                {
                    WordList wl = this.Settings.WordList;
                    m_SearchList.Add(search);       //Add search to List for future use
                    search = search.BrowseAdvancedSearch(wl);
                }
                else
                {
                    if (mdiChild == null)
                    {
                        mdiChild = new AppView(pWindow, "");
                        m_ViewCntr++;
                        mdiChild.Text = strApp + m_ViewCntr.ToString();
                        mdiChild.MdiParent = this;
                        mdiChild.Show();
                    }

                    if (this.Settings.SearchInsertionDefinitions)
                    {
                        if (this.Settings.SearchInsertionResults)
                        {
                            WordList wl = this.Settings.WordList;
                            m_SearchList.Add(search);	//Add search to List for future use
                            search = search.ExecuteAdvancedSearch(wl);
                            strText = search.BuildSearch();
                        }
                        else
                        {
                            strText = search.BuildDefinition();
                        }
                    }
                    else
                    {
                        if (this.Settings.SearchInsertionResults)
                        {
                            WordList wl = this.Settings.WordList;
                            m_SearchList.Add(search);	//Add search to List for future use
                            search = search.ExecuteAdvancedSearch(wl);
                            strText = search.BuildResults();
                        }
                    }
                    if (search.SearchCount > AppView.kBlockLines)
                    {
                        ArrayList al = mdiChild.RetrieveAsArray(strText);
                        strRtf = mdiChild.FormatWordList(al);
                    }
                    else strRtf = mdiChild.FormatWordList(strText);
                    mdiChild.Display(strRtf);
                }
            }
            //else MessageBox.Show("Search Cancel");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("App10");
                if (strMsg == "")
                    strMsg = "Search cancel";
                MessageBox.Show(strMsg);
            }
            this.ResetStatusBar();
		}

        private void menuSearchWordPairs_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuSearchWordPairs.Text.Replace("&", ""));
            m_SearchCntr++;
            string strText = "";
            string strRtf = "";

            AppView mdiChild = (AppView)this.ActiveMdiChild;
            MinPairsSearch search = new MinPairsSearch(m_SearchCntr, m_Settings);
            if (search.SetupSearch())
            {
                if (mdiChild == null)
                {
                    mdiChild = new AppView(pWindow, "");
                    m_ViewCntr++;
                    mdiChild.Text = strApp + m_ViewCntr.ToString();
                    mdiChild.MdiParent = this;
                    mdiChild.Show();
                }

                if (this.Settings.SearchInsertionDefinitions)
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        WordList wl = this.Settings.WordList;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteMinPairsSearch(wl);
                        strText = search.BuildSearch();
                    }
                    else
                    {
                        strText = search.BuildDefinition();
                    }
                }
                else
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        WordList wl = this.Settings.WordList;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteMinPairsSearch(wl);
                        strText = search.BuildResults();
                    }
                }
                strRtf = mdiChild.FormatWordList(strText);
                mdiChild.Display(strRtf);
            }
            //else MessageBox.Show("Search cancel");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("App10");
                if (strMsg == "")
                    strMsg = "Search cancel";
                MessageBox.Show(strMsg);
            }
            this.ResetStatusBar();
        }

        private void menuSearchWordCoccur_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuSearchWordContext.Text.Replace("&", ""));
            m_SearchCntr++;
            string strText = "";
			string strRtf = "";
			
			AppView mdiChild = (AppView)this.ActiveMdiChild;
			CooccurrenceChartSearch search = new  CooccurrenceChartSearch(m_SearchCntr, m_Settings);
            if (search.SetupSearch())
            {
                if (mdiChild == null)
                {
                    mdiChild = new AppView(pWindow, "");
                    m_ViewCntr++;
                    mdiChild.Text = strApp + m_ViewCntr.ToString();
                    mdiChild.MdiParent = this;
                    mdiChild.Show();
                }

                if (this.Settings.SearchInsertionDefinitions)
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        WordList wl = this.Settings.WordList;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteCooccurChart(wl);
                        strText = search.BuildSearch();
                    }
                    else
                    {
                        strText = search.BuildDefinition();
                    }
                }
                else
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        WordList wl = this.Settings.WordList;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteCooccurChart(wl);
                        strText = search.BuildResults();
                    }
                }
                strRtf = mdiChild.FormatChart(strText);
                mdiChild.Display(strRtf);
            }
            //else MessageBox.Show("Search Cancel");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("App10");
                if (strMsg == "")
                    strMsg = "Search cancel";
                MessageBox.Show(strMsg);
            }
            this.ResetStatusBar();
		}

		private void menuSearchWordContext_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuSearchWordContext.Text.Replace("&", ""));
			m_SearchCntr++;
			string strText = "";
			string strRtf = "";
			
			AppView mdiChild = (AppView)this.ActiveMdiChild;
			ContextChartSearch search = new ContextChartSearch(m_SearchCntr, m_Settings);
            if (search.SetupSearch())
            {
                if (mdiChild == null)
                {
                    mdiChild = new AppView(pWindow, "");
                    m_ViewCntr++;
                    mdiChild.Text = strApp + m_ViewCntr.ToString();
                    mdiChild.MdiParent = this;
                    mdiChild.Show();
                }

                if (this.Settings.SearchInsertionDefinitions)
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        WordList wl = this.Settings.WordList;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteContextChart(wl);
                        strText = search.BuildSearch();
                    }
                    else
                    {
                        strText = search.BuildDefinition();
                    }
                }
                else
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        WordList wl = this.Settings.WordList;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteContextChart(wl);
                        strText = search.BuildResults();
                    }
                }
                strRtf = mdiChild.FormatChart(strText);
                mdiChild.Display(strRtf);
            }
            //else MessageBox.Show("Search Cancel");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("App10");
                if (strMsg == "")
                    strMsg = "Search cancel";
                MessageBox.Show(strMsg);
            }
            this.ResetStatusBar();
		}

		private void menuSearchWordSyllable_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuSearchWordSyllable.Text.Replace("&", ""));
			m_SearchCntr++;
			string strText = "";
			string strRtf = "";
			
			AppView mdiChild = (AppView)this.ActiveMdiChild;
			SyllableChartSearch search = new SyllableChartSearch(m_SearchCntr, m_Settings);
            if (search.SetupSearch())
            {
                if (mdiChild == null)
                {
                    mdiChild = new AppView(pWindow, "");
                    m_ViewCntr++;
                    mdiChild.Text = strApp + m_ViewCntr.ToString();
                    mdiChild.MdiParent = this;
                    mdiChild.Show();
                }

                if (this.Settings.SearchInsertionDefinitions)
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        WordList wl = this.Settings.WordList;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteSyllableChart(wl);
                        strText = search.BuildSearch();
                    }
                    else
                    {
                        strText = search.BuildDefinition();
                    }
                }
                else
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        WordList wl = this.Settings.WordList;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteSyllableChart(wl); ;
                        strText = search.BuildResults();
                    }
                }

                strRtf = mdiChild.FormatChart(strText);
                mdiChild.Display(strRtf);
            }
            //else MessageBox.Show("Search cancel");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("App10");
                if (strMsg == "")
                    strMsg = "Search cancel";
                MessageBox.Show(strMsg);
            }
            this.ResetStatusBar();
		}

        private void menuSearchWordTone_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuSearchWordTone.Text.Replace("&", ""));
			m_SearchCntr++;
			string strText = "";
			string strRtf = "";
			
			AppView mdiChild = (AppView)this.ActiveMdiChild;
			ToneWLSearch search = new ToneWLSearch(m_SearchCntr, m_Settings);
            if (search.SetupSearch())
            {
                if (mdiChild == null)
                {
                    mdiChild = new AppView(pWindow, "");
                    m_ViewCntr++;
                    mdiChild.Text = strApp + m_ViewCntr.ToString();
                    mdiChild.MdiParent = this;
                    mdiChild.Show();
                }

                if (this.Settings.SearchInsertionDefinitions)
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        WordList wl = this.Settings.WordList;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteToneSearch(wl);
                        if (search != null)
                            strText = search.BuildSearch();
                    }
                    else
                    {
                        strText = search.BuildDefinition();
                    }
                }
                else
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        WordList wl = this.Settings.WordList;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteToneSearch(wl);
                        if (search != null)
                            strText = search.BuildResults();
                    }
                }
                if (search.SearchCount > AppView.kBlockLines)
                {
                    ArrayList al = mdiChild.RetrieveAsArray(strText);
                    strRtf = mdiChild.FormatWordList(al);
                }
                else strRtf = mdiChild.FormatWordList(strText);
                mdiChild.Display(strRtf);
            }
            //else MessageBox.Show("Search cancel");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("App10");
                if (strMsg == "")
                    strMsg = "Search cancel";
                MessageBox.Show(strMsg);
            }
            this.ResetStatusBar();
		}

        private void menuSearchWordSyllograph_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuSearchWordSyllograph.Text.Replace("&", ""));
            m_SearchCntr++;
            string strText = "";
            string strRtf = "";

            AppView mdiChild = (AppView)this.ActiveMdiChild;
            SyllographWLSearch search = new SyllographWLSearch(m_SearchCntr, m_Settings);
            if (search.SetupSearch())
            {
                if (search.BrowseView)
                {
                    WordList wl = this.Settings.WordList;
                    m_SearchList.Add(search);       //Add search to List for future use
                    search.BrowseSyllographWLSearch(wl);
                }
                else
                {
                    if (mdiChild == null)
                    {
                        mdiChild = new AppView(pWindow, "");
                        m_ViewCntr++;
                        mdiChild.Text = strApp + m_ViewCntr.ToString();
                        mdiChild.MdiParent = this;
                        mdiChild.Show();
                    }

                    if (this.Settings.SearchInsertionDefinitions)
                    {
                        if (this.Settings.SearchInsertionResults)
                        {
                            WordList wl = this.Settings.WordList;
                            m_SearchList.Add(search);	//Add search to List for future use
                            search = search.ExecuteSyllographSearch(wl);
                            if (search != null)
                                strText = search.BuildSearch();
                        }
                        else
                        {
                            strText = search.BuildDefinition();
                        }
                    }
                    else
                    {
                        if (this.Settings.SearchInsertionResults)
                        {
                            WordList wl = this.Settings.WordList;
                            m_SearchList.Add(search);	//Add search to List for future use
                            search = search.ExecuteSyllographSearch(wl);
                            if (search != null)
                                strText = search.BuildResults();
                        }
                    }
                    if (search.SearchCount > AppView.kBlockLines)
                    {
                        ArrayList al = mdiChild.RetrieveAsArray(strText);
                        strRtf = mdiChild.FormatWordList(al);
                    }
                    else strRtf = mdiChild.FormatWordList(strText);
                    mdiChild.Display(strRtf);
                }
            }
            //else MessageBox.Show("Search cancel");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("App10");
                if (strMsg == "")
                    strMsg = "Search cancel";
                MessageBox.Show(strMsg);
            }
            this.ResetStatusBar();
        }

        private void menuSearchWordOrder_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuSearchWordOrder.Text.Replace("&", ""));
			m_SearchCntr++;
			string strText = "";
			string strRtf = "";
			
			AppView mdiChild = (AppView)this.ActiveMdiChild;
			TeachingOrderWLSearch search = new TeachingOrderWLSearch(m_SearchCntr, m_Settings);
            if (search.SetupSearch())
            {
                if (mdiChild == null)
                {
                    mdiChild = new AppView(pWindow, "");
                    m_ViewCntr++;
                    mdiChild.Text = strApp + m_ViewCntr.ToString();
                    mdiChild.MdiParent = this;
                    mdiChild.Show();
                }

                if (this.Settings.SearchInsertionDefinitions)
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        WordList wl = this.Settings.WordList;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteOrderSearch(wl);
                        if (search != null)
                            strText = search.BuildSearch();
                    }
                    else
                    {
                        strText = search.BuildDefinition();
                    }
                }
                else
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        WordList wl = this.Settings.WordList;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteOrderSearch(wl);
                        if (search != null)
                            strText = search.BuildResults();
                    }
                }
                strRtf = mdiChild.FormatTable(strText);
                mdiChild.Display(strRtf);
            }
            //else MessageBox.Show("Search cancel");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("App10");
                if (strMsg == "")
                    strMsg = "Search cancel";
                MessageBox.Show(strMsg);
            }
            this.ResetStatusBar();
		}

        private void menuSearchWordGeneral_Click(object sender, System.EventArgs e)
        {
            m_SearchCntr++;
            string strText = "";
            string strRtf = "";

            UpdStatusBarInfo(menuSearchWordGeneral.Text.Replace("&", ""));
            AppView mdiChild = (AppView)this.ActiveMdiChild;
            GeneralWLSearch search = new GeneralWLSearch(m_SearchCntr, m_Settings);
            if (search.SetupSearch())
            {
                if (search.BrowseView)
                {
                    WordList wl = this.Settings.WordList;
                    m_SearchList.Add(search);	//Add search to List for future use
                    search = search.BrowseGeneralSearch(wl);
                }
                else
                {
                    if (mdiChild == null)
                    {
                        mdiChild = new AppView(pWindow, "");
                        m_ViewCntr++;
                        mdiChild.Text = strApp + m_ViewCntr.ToString();
                        mdiChild.MdiParent = this;
                        mdiChild.Show();
                    }

                    if (this.Settings.SearchInsertionDefinitions)
                    {
                        if (this.Settings.SearchInsertionResults)
                        {
                            WordList wl = this.Settings.WordList;
                            m_SearchList.Add(search);	//Add search to List for future use
                            search = search.ExecuteGeneralSearch(wl);
                            strText = search.BuildSearch();
                        }
                        else
                        {
                            strText = search.BuildDefinition();
                        }
                    }
                    else
                    {
                        if (this.Settings.SearchInsertionResults)
                        {
                            WordList wl = this.Settings.WordList;
                            m_SearchList.Add(search);	//Add search to List for future use
                            search.ExecuteGeneralSearch(wl);
                            strText = search.BuildResults();
                        }
                    }
                    if (search.SearchCount > AppView.kBlockLines)
                    {
                        ArrayList al = mdiChild.RetrieveAsArray(strText);
                        strRtf = mdiChild.FormatWordList(al);
                    }
                    else strRtf = mdiChild.FormatWordList(strText);
                    mdiChild.Display(strRtf);
                }
            }
            //else MessageBox.Show("Search Cancel");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("App10");
                if (strMsg == "")
                    strMsg = "Search cancel";
                MessageBox.Show(strMsg);
            }
            this.ResetStatusBar();
        }

        private void menuSearchTextGrapheme_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuSearchTextWord.Text.Replace("&", ""));
            m_SearchCntr++;
            string strText = "";
            string strRtf = "";
            AppView mdiChild = (AppView)this.ActiveMdiChild;
            GraphemeSearchTD search = new GraphemeSearchTD(m_SearchCntr, m_Settings);
            if (search.SetupSearch())
            {
                if (mdiChild == null)
                {
                    mdiChild = new AppView(pWindow, "");
                    m_ViewCntr++;
                    mdiChild.Text = strApp + m_ViewCntr.ToString();
                    mdiChild.MdiParent = this;
                    mdiChild.Show();
                }

                if (this.Settings.SearchInsertionDefinitions)
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        TextData td = this.Settings.TextData;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteGraphemeSearch(td);
                        strText = search.BuildSearch();
                    }
                    else strText = search.BuildDefinition();
                }
                else
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        TextData td = this.Settings.TextData;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteGraphemeSearch(td);
                        strText = search.BuildResults();
                    }
                }
                //ArrayList alText = Funct.ConvertStringToArrayList(strText, Environment.NewLine);
                //strRtf = mdiChild.FormatText(alText);
                strRtf = mdiChild.FormatText(strText, true);
                mdiChild.Display(strRtf);
            }
            //else MessageBox.Show("Search cancel");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("App10");
                if (strMsg == "")
                    strMsg = "Search cancel";
                MessageBox.Show(strMsg);
            }
            this.ResetStatusBar();
        }

        private void menuSearchTextFrequency_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuSearchTextGrapheme.Text.Replace("&", ""));
            m_SearchCntr++;
            string strText = "";
            string strRtf = "";

            AppView mdiChild = (AppView)this.ActiveMdiChild;
            FrequencyTDSearch search = new FrequencyTDSearch(m_SearchCntr, m_Settings);
            if (search.SetupSearch())
            {
                if (mdiChild == null)
                {
                    mdiChild = new AppView(pWindow, "");
                    m_ViewCntr++;
                    mdiChild.Text = strApp + m_ViewCntr.ToString();
                    mdiChild.MdiParent = this;
                    mdiChild.Show();
                }

                if (this.Settings.SearchInsertionDefinitions)
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        TextData td = this.Settings.TextData;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteFrequencySearch(td);
                        strText = search.BuildSearch();
                    }
                    else
                    {
                        strText = search.BuildDefinition();
                    }
                }
                else
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        TextData td = this.Settings.TextData;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteFrequencySearch(td);
                        strText = search.BuildResults();
                    }
                }

                strRtf = mdiChild.FormatTable(strText);
                mdiChild.Display(strRtf);
            }
            //else MessageBox.Show("Search cancel");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("App10");
                if (strMsg == "")
                    strMsg = "Search cancel";
                MessageBox.Show(strMsg);
            }
            this.ResetStatusBar();
        }

        private void menuSearchTextWord_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuSearchTextWord.Text.Replace("&", ""));
			m_SearchCntr++;
			string strText = "";
			string strRtf = "";
			
			AppView mdiChild = (AppView)this.ActiveMdiChild;
			WordSearch search = new WordSearch(m_SearchCntr, m_Settings);
            if (search.SetupSearch())
            {
                if (mdiChild == null)
                {
                    mdiChild = new AppView(pWindow, "");
                    m_ViewCntr++;
                    mdiChild.Text = strApp + m_ViewCntr.ToString();
                    mdiChild.MdiParent = this;
                    mdiChild.Show();
                }

                if (this.Settings.SearchInsertionDefinitions)
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        TextData td = this.Settings.TextData;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteWordSearch(td);
                        strText = search.BuildSearch();
                    }
                    else
                    {
                        strText = search.BuildDefinition();
                    }
                }
                else
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        TextData td = this.Settings.TextData;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteWordSearch(td);
                        strText = search.BuildResults();
                    }
                }

                //ArrayList alText = Funct.ConvertStringToArrayList(strText, Environment.NewLine);
                //strRtf = mdiChild.FormatText(alText);
                strRtf = mdiChild.FormatText(strText, true);
                mdiChild.Display(strRtf);
            }
            //else MessageBox.Show("Search cancel");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("App10");
                if (strMsg == "")
                    strMsg = "Search cancel";
                MessageBox.Show(strMsg);
            }
            this.ResetStatusBar();
		}

        private void menuSearchTextCount_Click(object sender, System.EventArgs e)
        {
            UpdStatusBarInfo(menuSearchTextCount.Text.Replace("&", ""));
            m_SearchCntr++;
            string strText = "";
            string strRtf = "";

            AppView mdiChild = (AppView)this.ActiveMdiChild;
            WordCountSearch search = new WordCountSearch(m_SearchCntr, m_Settings);
            if (search.SetupSearch())
            {
                if (mdiChild == null)
                {
                    mdiChild = new AppView(pWindow, "");
                    m_ViewCntr++;
                    mdiChild.Text = strApp + m_ViewCntr.ToString();
                    mdiChild.MdiParent = this;
                    mdiChild.Show();
                }

                if (this.Settings.SearchInsertionDefinitions)
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        TextData td = this.Settings.TextData;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteWordCountSearch(td);
                        strText = search.BuildSearch();
                    }
                    else
                    {
                        strText = search.BuildDefinition();
                    }
                }
                else
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        TextData td = this.Settings.TextData;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteWordCountSearch(td);
                        strText = search.BuildResults();
                    }
                }

                strRtf = mdiChild.FormatTable(strText);
                mdiChild.Display(strRtf);
            }
            //else MessageBox.Show("Search cancel");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("App10");
                if (strMsg == "")
                    strMsg = "Search cancel";
                MessageBox.Show(strMsg);
            }
            this.ResetStatusBar();
        }

        private void menuSearchTextSyllable_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuSearchTextSyllable.Text.Replace("&", ""));
            m_SearchCntr++;
            string strText = "";
            string strRtf = "";

            AppView mdiChild = (AppView)this.ActiveMdiChild;
            SyllableCountSearch search = new SyllableCountSearch(m_SearchCntr, m_Settings);
            if (search.SetupSearch())
            {
                if (mdiChild == null)
                {
                    mdiChild = new AppView(pWindow, "");
                    m_ViewCntr++;
                    mdiChild.Text = strApp + m_ViewCntr.ToString();
                    mdiChild.MdiParent = this;
                    mdiChild.Show();
                }

                if (this.Settings.SearchInsertionDefinitions)
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        TextData td = this.Settings.TextData;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteSyllableCountSearch(td);
                        strText = search.BuildSearch();
                    }
                    else
                    {
                        strText = search.BuildDefinition();
                    }
                }
                else
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        TextData td = this.Settings.TextData;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteSyllableCountSearch(td);
                        strText = search.BuildResults();
                    }
                }

                strRtf = mdiChild.FormatTable(strText);
                mdiChild.Display(strRtf);
            }
            //else MessageBox.Show("Search cancel");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("App10");
                if (strMsg == "")
                    strMsg = "Search cancel";
                MessageBox.Show(strMsg);
            }
            this.ResetStatusBar();
        }

        private void menuSearchTextPhrases_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuSearchTextPhrases.Text.Replace("&", ""));
			m_SearchCntr++;
			string strText = "";
			string strRtf = "";
			AppView mdiChild = (AppView)this.ActiveMdiChild;
			PhraseSearch search = new PhraseSearch(m_SearchCntr, m_Settings);
            if (search.SetupSearch())
            {
                if (mdiChild == null)
                {
                    mdiChild = new AppView(pWindow, "");
                    m_ViewCntr++;
                    mdiChild.Text = strApp + m_ViewCntr.ToString();
                    mdiChild.MdiParent = this;
                    mdiChild.Show();
                }

                if (this.Settings.SearchInsertionDefinitions)
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        TextData td = this.Settings.TextData;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecutePhraseSearch(td);
                        strText = search.BuildSearch();
                    }
                    else
                    {
                        strText = search.BuildDefinition();
                    }
                }
                else
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        TextData td = this.Settings.TextData;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecutePhraseSearch(td);
                        strText = search.BuildResults();
                    }
                }

                //ArrayList alText = Funct.ConvertStringToArrayList(strText, Environment.NewLine);
                //strRtf = mdiChild.FormatText(alText);
                strRtf = mdiChild.FormatText(strText, true);
                mdiChild.Display(strRtf);
            }
            //else MessageBox.Show("Search cancel");
            else
            {
                string strMsg = m_Settings.LocalizationTable.GetMessage("App10");
                if (strMsg == "")
                    strMsg = "Search cancel";
                MessageBox.Show(strMsg);
            }
            this.ResetStatusBar();
        }

		private void menuSearchTextResidue_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuSearchTextResidue.Text.Replace("&", ""));
			m_SearchCntr++;
			string strText = "";
			string strRtf = "";
            string strFile = "";
			AppView mdiChild = (AppView)this.ActiveMdiChild;
			ResidueSearch search = new ResidueSearch(m_SearchCntr, m_Settings);
            if (search.SetupSearch())
            {
                if (mdiChild == null)
                {
                    mdiChild = new AppView(pWindow, "");
                    m_ViewCntr++;
                    mdiChild.Text = strApp + m_ViewCntr.ToString();
                    mdiChild.MdiParent = this;
                    mdiChild.Show();
                }

                if (this.Settings.SearchInsertionDefinitions)
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        TextData td = null;
                        if (search.UseCurrentTextData)
                            td = this.Settings.TextData;
                        else
                        {
                            strFile = search.TextDataFile;
                            if (strFile != "")
                            {
                                td = new TextData(this.Settings);
                                if (!td.LoadFile(strFile))
                                {
                                    //MessageBox.Show("Search Cancel: Story file failed to load");
                                    strText = m_Settings.LocalizationTable.GetMessage("App33");
                                    if (strText == "")
                                        strText = "Search Cancel: Story file failed to load";
                                    MessageBox.Show(strText);
                                    return;
                                }
                            }
                            else
                            {
                                //MessageBox.Show("Search cancel: Story file was not specified");
                                strText = m_Settings.LocalizationTable.GetMessage("App34");
                                if (strText == "")
                                    strText = "Search cancel: Story file was not specified";
                                MessageBox.Show(strText);
                                return;
                            }
                        }
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteResidueSearch(td);
                        strText = search.BuildSearch();
                    }
                    else
                    {
                        strText = search.BuildDefinition();
                    }
                }
                else
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        TextData td = null;
                        if (search.UseCurrentTextData)
                            td = this.Settings.TextData;
                        else
                        {
                            strFile = search.TextDataFile;
                            if (strFile != "")
                            {
                                td = new TextData(this.Settings);
                                if (!td.LoadFile(strFile))
                                {
                                    //MessageBox.Show("Search cancel: Text Data file failed to load");
                                    strText = m_Settings.LocalizationTable.GetMessage("App98");
                                    if (strText == "")
                                        strText = "Search cancel: Text Data file failed to load";
                                    MessageBox.Show(strText);
                                    return;
                                }
                            }
                            else
                            {
                                //MessageBox.Show("Search cancel: Text Data file was not specified");
                                strText = m_Settings.LocalizationTable.GetMessage("App99");
                                if (strText == "")
                                    strText = "Search cancel: Text Data file was not specified";
                                MessageBox.Show(strText);
                                return;
                            }
                        }
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteResidueSearch(td);
                        strText = search.BuildResults();
                    }
                }

                strRtf = mdiChild.FormatText(strText, true);
                mdiChild.Display(strRtf);
            }
            //else MessageBox.Show("Search cancel");
            else
            {
                strText = m_Settings.LocalizationTable.GetMessage("App10");
                if (strText == "")
                    strText = "Search cancel";
                MessageBox.Show(strText);
            }
            this.ResetStatusBar();
		}

		private void menuSearchTextSight_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuSearchTextSight.Text.Replace("&", ""));
			m_SearchCntr++;
			string strText = "";
			string strRtf = "";
			AppView mdiChild = (AppView)this.ActiveMdiChild;
			SightSearch search = new SightSearch(m_SearchCntr, m_Settings);
			if ( search.SetupSearch() )
			{
                if (mdiChild == null)
                {
                    mdiChild = new AppView(pWindow, "");
                    m_ViewCntr++;
                    mdiChild.Text = strApp + m_ViewCntr.ToString();
                    mdiChild.MdiParent = this;
                    mdiChild.Show();
                }

                if (this.Settings.SearchInsertionDefinitions)
				{
					if ( this.Settings.SearchInsertionResults) 
					{
						m_SearchList.Add(search);	//Add search to List for future use
						search = search.ExecuteSightSearch();
						strText = search.BuildSearch();
					}
					else
					{
						strText = search.BuildDefinition();
					}
				}
				else
				{
					if ( this.Settings.SearchInsertionResults )
					{
						m_SearchList.Add(search);	//Add search to List for future use
						search = search.ExecuteSightSearch();
						strText = search.BuildResults();
					}
				}

                //ArrayList alText = Funct.ConvertStringToArrayList(strText, Environment.NewLine);
                //strRtf = mdiChild.FormatText(alText);
                strRtf = mdiChild.FormatText(strText, true);
				mdiChild.Display(strRtf);
			}
            //else MessageBox.Show("Search cancel");
            else
            {
                strText = m_Settings.LocalizationTable.GetMessage("App10");
                if (strText == "")
                    strText = "Search cancel";
                MessageBox.Show(strText);
            }
            this.ResetStatusBar();
		}

        private void menuSearchTextBuilt_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuSearchTextSight.Text.Replace("&", ""));
            m_SearchCntr++;
            string strText = "";
            string strRtf = "";

            AppView mdiChild = (AppView)this.ActiveMdiChild;
            BuildableWordSearchTD search = new BuildableWordSearchTD(m_SearchCntr, m_Settings);
            if (search.SetupSearch())
            {
                if (mdiChild == null)
                {
                    mdiChild = new AppView(pWindow, "");
                    m_ViewCntr++;
                    mdiChild.Text = strApp + m_ViewCntr.ToString();
                    mdiChild.MdiParent = this;
                    mdiChild.Show();
                }

                if (this.Settings.SearchInsertionDefinitions)
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        TextData td = this.Settings.TextData;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteBuildableWordSearch(td);
                        strText = search.BuildSearch();
                    }
                    else
                    {
                        strText = search.BuildDefinition();
                    }
                }
                else
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        TextData td = this.Settings.TextData;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteBuildableWordSearch(td);
                        strText = search.BuildResults();
                    }
                }

                //ArrayList alText = Funct.ConvertStringToArrayList(strText, Environment.NewLine);
                //strRtf = mdiChild.FormatText(alText);
                strRtf = mdiChild.FormatText(strText, true);
                mdiChild.Display(strRtf);
            }
            //else MessageBox.Show("Search cancel");
            else
            {
                strText = m_Settings.LocalizationTable.GetMessage("App10");
                if (strText == "")
                    strText = "Search cancel";
                MessageBox.Show(strText);
            }
            this.ResetStatusBar();
        }

        private void menuSearchTextNew_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuSearchTextNew.Text.Replace("&", ""));
            m_SearchCntr++;
            string strText = "";
            string strRtf = "";
            AppView mdiChild = (AppView)this.ActiveMdiChild;
            NewWordSearch search = new NewWordSearch(m_SearchCntr, m_Settings);
            if (search.SetupSearch())
            {
                if (mdiChild == null)
                {
                    mdiChild = new AppView(pWindow, "");
                    m_ViewCntr++;
                    mdiChild.Text = strApp + m_ViewCntr.ToString();
                    mdiChild.MdiParent = this;
                    mdiChild.Show();
                }

                if (this.Settings.SearchInsertionDefinitions)
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        TextData td = this.Settings.TextData;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteNewWordSearch();
                        strText = search.BuildSearch();
                    }
                    else
                    {
                        strText = search.BuildDefinition();
                    }
                }
                else
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        TextData td = this.Settings.TextData;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteNewWordSearch();
                        strText = search.BuildResults();
                    }
                }
                strRtf = mdiChild.FormatText(strText, true);
                mdiChild.Display(strRtf);
            }
            //else MessageBox.Show("Search cancel");
            else
            {
                strText = m_Settings.LocalizationTable.GetMessage("App10");
                if (strText == "")
                    strText = "Search cancel";
                MessageBox.Show(strText);
            }
            this.ResetStatusBar();
        }

        private void menuSearchTextTone_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuSearchTextTone.Text.Replace("&", ""));
			m_SearchCntr++;
			string strText = "";
			string strRtf = "";
			AppView mdiChild = (AppView)this.ActiveMdiChild;
			ToneTDSearch search = new ToneTDSearch(m_SearchCntr, m_Settings);
			if ( search.SetupSearch() )
			{
                if (mdiChild == null)
                {
                    mdiChild = new AppView(pWindow, "");
                    m_ViewCntr++;
                    mdiChild.Text = strApp + m_ViewCntr.ToString();
                    mdiChild.MdiParent = this;
                    mdiChild.Show();
                }

                if (this.Settings.SearchInsertionDefinitions)
				{
					if ( this.Settings.SearchInsertionResults) 
					{
						TextData td = this.Settings.TextData;
						m_SearchList.Add(search);	//Add search to List for future use
						search = search.ExecuteToneSearch(td);
						if (search != null)
							strText = search.BuildSearch();
					}
					else
					{
						strText = search.BuildDefinition();
					}
				}
				else
				{
					if ( this.Settings.SearchInsertionResults )
					{
						TextData td = this.Settings.TextData;
						m_SearchList.Add(search);	//Add search to List for future use
						search = search.ExecuteToneSearch(td);
						strText = search.BuildResults();
					}
				}

                //ArrayList alText = Funct.ConvertStringToArrayList(strText, Environment.NewLine);
                //strRtf = mdiChild.FormatText(alText);
                strRtf = mdiChild.FormatText(strText, true);
				mdiChild.Display(strRtf);
			}
            //else MessageBox.Show("Search cancel");
            else
            {
                strText = m_Settings.LocalizationTable.GetMessage("App10");
                if (strText == "")
                    strText = "Search cancel";
                MessageBox.Show(strText);
            }
            this.ResetStatusBar();
		}

        private void menuSearchTextSyllograph_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuSearchTextSyllograph.Text.Replace("&", ""));
            m_SearchCntr++;
            string strText = "";
            string strRtf = "";
            AppView mdiChild = (AppView)this.ActiveMdiChild;
            SyllographTDSearch search = new SyllographTDSearch(m_SearchCntr, m_Settings);
            if (search.SetupSearch())
            {
                if (mdiChild == null)
                {
                    mdiChild = new AppView(pWindow, "");
                    m_ViewCntr++;
                    mdiChild.Text = strApp + m_ViewCntr.ToString();
                    mdiChild.MdiParent = this;
                    mdiChild.Show();
                }

                if (this.Settings.SearchInsertionDefinitions)
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        TextData td = this.Settings.TextData;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteSyllographSearch(td);
                        if (search != null)
                            strText = search.BuildSearch();
                    }
                    else
                    {
                        strText = search.BuildDefinition();
                    }
                }
                else
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        TextData td = this.Settings.TextData;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteSyllographSearch(td);
                        strText = search.BuildResults();
                    }
                }

                //ArrayList alText = Funct.ConvertStringToArrayList(strText, Environment.NewLine);
                //strRtf = mdiChild.FormatText(alText);
                strRtf = mdiChild.FormatText(strText, true);
                mdiChild.Display(strRtf);
            }
            //else MessageBox.Show("Search cancel");
            else
            {
                strText = m_Settings.LocalizationTable.GetMessage("App10");
                if (strText == "")
                    strText = "Search cancel";
                MessageBox.Show(strText);
            }
            this.ResetStatusBar();
        }

        private void menuSearchTextOrder_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuSearchWordOrder.Text.Replace("&", ""));
			m_SearchCntr++;
			string strText = "";
			string strRtf = "";
			AppView mdiChild = (AppView)this.ActiveMdiChild;
            TeachingOrderTDSearch search = new TeachingOrderTDSearch(m_SearchCntr, m_Settings);
            if (search.SetupSearch())
            {
                if (mdiChild == null)
                {
                    mdiChild = new AppView(pWindow, "");
                    m_ViewCntr++;
                    mdiChild.Text = strApp + m_ViewCntr.ToString();
                    mdiChild.MdiParent = this;
                    mdiChild.Show();
                }

                if (this.Settings.SearchInsertionDefinitions)
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        TextData td = this.Settings.TextData;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteOrderSearch(td);
                        if (search != null)
                            strText = search.BuildSearch();
                    }
                    else
                    {
                        strText = search.BuildDefinition();
                    }
                }
                else
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        TextData td = this.Settings.TextData;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteOrderSearch(td);
                        if (search != null)
                            strText = search.BuildResults();
                    }
                }
                strRtf = mdiChild.FormatTable(strText);
                mdiChild.Display(strRtf);
            }
            //else MessageBox.Show("Search cancel");
            else
            {
                strText = m_Settings.LocalizationTable.GetMessage("App10");
                if (strText == "")
                    strText = "Search cancel";
                MessageBox.Show(strText);
            }
        }

        private void menuSearchTextGeneral_Click(object sender, EventArgs e)
        {
			UpdStatusBarInfo(menuSearchWordOrder.Text.Replace("&", ""));
			m_SearchCntr++;
			string strText = "";
			string strRtf = "";
			AppView mdiChild = (AppView)this.ActiveMdiChild;
            GeneralTDSearch search = new GeneralTDSearch(m_SearchCntr, m_Settings);
            if (search.SetupSearch())
            {
                if (mdiChild == null)
                {
                    mdiChild = new AppView(pWindow, "");
                    m_ViewCntr++;
                    mdiChild.Text = strApp + m_ViewCntr.ToString();
                    mdiChild.MdiParent = this;
                    mdiChild.Show();
                }

                if (this.Settings.SearchInsertionDefinitions)
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        TextData td = this.Settings.TextData;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteGeneralSearch(td);
                        if (search != null)
                            strText = search.BuildSearch();
                    }
                    else
                    {
                        strText = search.BuildDefinition();
                    }
                }
                else
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        TextData td = this.Settings.TextData;
                        m_SearchList.Add(search);	//Add search to List for future use
                        search = search.ExecuteGeneralSearch(td);
                        if (search != null)
                            strText = search.BuildResults();
                    }
                }
                strRtf = mdiChild.FormatText(strText, true);
                mdiChild.Display(strRtf);
            }
            //else MessageBox.Show("Search cancel");
            else
            {
                strText = m_Settings.LocalizationTable.GetMessage("App10");
                if (strText == "")
                    strText = "Search cancel";
                MessageBox.Show(strText);
            }
        }
         
        private void menuSearchVowel_Click(object sender, System.EventArgs e)
		{
			m_SearchCntr++;
			string strText = "";
			string strRtf = "";
			
			UpdStatusBarInfo(menuSearchVowel.Text.Replace("&", ""));
			AppView mdiChild = (AppView)this.ActiveMdiChild;
			VowelChartSearch search = new VowelChartSearch(m_SearchCntr, m_Settings);
			if ( search.SetupSearch() )
			{
                if (mdiChild == null)
                {
                    mdiChild = new AppView(pWindow, "");
                    m_ViewCntr++;
                    mdiChild.Text = strApp + m_ViewCntr.ToString();
                    mdiChild.MdiParent = this;
                    mdiChild.Show();
                }

                if (this.Settings.SearchInsertionDefinitions)
				{
					if (this.Settings.SearchInsertionResults)
					{
						GraphemeInventory gi = this.Settings.GraphemeInventory;
						m_SearchList.Add(search);		//Add search to List for future use
                        search = search.ExecuteVowelChart(gi);
                        strText = search.BuildSearch();

					}
					else strText = search.BuildDefinition();
				}
				else
				{
					if  (this.Settings.SearchInsertionResults)
					{
						GraphemeInventory gi = this.Settings.GraphemeInventory;
                        m_SearchList.Add(search);		//Add search to List for future use
                        search = search.ExecuteVowelChart(gi);
						strText = search.BuildResults();
					}
				}
				strRtf = mdiChild.FormatChart(strText);
				mdiChild.Display(strRtf);
			}
            //else MessageBox.Show("Search Cancel");
            else
            {
                strText = m_Settings.LocalizationTable.GetMessage("App10");
                if (strText == "")
                    strText = "Search cancel";
                MessageBox.Show(strText);
            }
            this.ResetStatusBar();
		}

		private void menuSearchConsonant_Click(object sender, System.EventArgs e)
		{
			m_SearchCntr++;
			string strText = "";
			string strRtf = "";
			
			UpdStatusBarInfo(menuSearchConsonant.Text.Replace("&", ""));
			AppView mdiChild = (AppView)this.ActiveMdiChild;
			ConsonantChartSearch search = new ConsonantChartSearch(m_SearchCntr, m_Settings);
			if ( search.SetupSearch() )
			{
                if (mdiChild == null)
                {
                    mdiChild = new AppView(pWindow, "");
                    m_ViewCntr++;
                    mdiChild.Text = strApp + m_ViewCntr.ToString();
                    mdiChild.MdiParent = this;
                    mdiChild.Show();
                }

                if (this.Settings.SearchInsertionDefinitions)
				{
					if (this.Settings.SearchInsertionResults)
					{
						GraphemeInventory gi = this.Settings.GraphemeInventory;
						m_SearchList.Add(search);		//Add search to List for future use
                        search = search.ExecuteConsonantChart(gi);
						strText = search.BuildSearch();
					}
					else strText = search.BuildDefinition();
				}
				else
				{
					if  (this.Settings.SearchInsertionResults)
					{
						GraphemeInventory gi = this.Settings.GraphemeInventory;
						m_SearchList.Add(search);		//Add search to List for future use
						search = search.ExecuteConsonantChart(gi);
						strText = search.BuildResults();
					}
				}
				strRtf = mdiChild.FormatChart(strText);
				mdiChild.Display(strRtf);
			}
            //else MessageBox.Show("Search Cancel");
            else
            {
                strText = m_Settings.LocalizationTable.GetMessage("App10");
                if (strText == "")
                    strText = "Search cancel";
                MessageBox.Show(strText);
            }
            this.ResetStatusBar();
		}

		private void menuSearchTone_Click(object sender, System.EventArgs e)
		{
			m_SearchCntr++;
			string strText = "";
			string strRtf = "";
			
			UpdStatusBarInfo(menuSearchTone.Text.Replace("&", ""));
			AppView mdiChild = (AppView)this.ActiveMdiChild;
			ToneChartSearch search = new ToneChartSearch(m_SearchCntr, m_Settings);
			if ( search.SetupSearch() )
			{
                if (mdiChild == null)
                {
                    mdiChild = new AppView(pWindow, "");
                    m_ViewCntr++;
                    mdiChild.Text = strApp + m_ViewCntr.ToString();
                    mdiChild.MdiParent = this;
                    mdiChild.Show();
                }

                if (this.Settings.SearchInsertionDefinitions)
				{
					if (this.Settings.SearchInsertionResults)
					{
						GraphemeInventory gi = this.Settings.GraphemeInventory;
                        int nMax = this.Settings.OptionSettings.MaxSizeGrapheme;
						m_SearchList.Add(search);		//Add search to List for future use
						search.ExecuteToneChart(gi);
						strText = search.BuildSearch();

					}
					else strText = search.BuildDefinition();
				}
				else
				{
					if  (this.Settings.SearchInsertionResults)
					{
						GraphemeInventory gi = this.Settings.GraphemeInventory;
                        int nMax = this.Settings.OptionSettings.MaxSizeGrapheme;
						m_SearchList.Add(search);		//Add search to List for future use
                        search.ExecuteToneChart(gi);
						strText = search.BuildResults();
					}
				}
				strRtf = mdiChild.FormatChart(strText);
				mdiChild.Display(strRtf);
			}
            //else MessageBox.Show("Search Cancel");
            else
            {
                strText = m_Settings.LocalizationTable.GetMessage("App10");
                if (strText == "")
                    strText = "Search cancel";
                MessageBox.Show(strText);
            }
            this.ResetStatusBar();
		}

        private void menuSearchSyllograph_Click(object sender, EventArgs e)
        {
            m_SearchCntr++;
            string strText = "";
            string strRtf = "";

            UpdStatusBarInfo(menuSearchSyllograph.Text.Replace("&", ""));
            AppView mdiChild = (AppView)this.ActiveMdiChild;
            SyllographChartSearch search = new SyllographChartSearch(m_SearchCntr, m_Settings);
            if (search.SetupSearch())
            {
                if (mdiChild == null)
                {
                    mdiChild = new AppView(pWindow, "");
                    m_ViewCntr++;
                    mdiChild.Text = strApp + m_ViewCntr.ToString();
                    mdiChild.MdiParent = this;
                    mdiChild.Show();
                }

                if (this.Settings.SearchInsertionDefinitions)
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        GraphemeInventory gi = this.Settings.GraphemeInventory;
                        int nMax = this.Settings.OptionSettings.MaxSizeGrapheme;
                        m_SearchList.Add(search);		//Add search to List for future use
                        search.ExecuteSyllographChart(gi);
                        strText = search.BuildSearch();

                    }
                    else strText = search.BuildDefinition();
                }
                else
                {
                    if (this.Settings.SearchInsertionResults)
                    {
                        GraphemeInventory gi = this.Settings.GraphemeInventory;
                        int nMax = this.Settings.OptionSettings.MaxSizeGrapheme;
                        m_SearchList.Add(search);		//Add search to List for future use
                        search.ExecuteSyllographChart(gi);
                        strText = search.BuildResults();
                    }
                }
                strRtf = mdiChild.FormatChart(strText);
                mdiChild.Display(strRtf);
            }
            //else MessageBox.Show("Search Cancel");
            else
            {
                strText = m_Settings.LocalizationTable.GetMessage("App10");
                if (strText == "")
                    strText = "Search cancel";
                MessageBox.Show(strText);
            }
            this.ResetStatusBar();
        }

        private void menuToolsWordImportSF_Click(object sender, System.EventArgs e)
		{
            string strText = "";
			UpdStatusBarInfo(menuToolsWordImport.Text.Replace("&", ""));
			WordList wl = this.Settings.WordList;
			wl = wl.LoadSFM(this.Settings.OptionSettings.DataFolder);
            if (wl != null)
            {
                GraphemeInventory gi = this.Settings.GraphemeInventory;
                this.Settings.WordList = wl;
                this.Settings.OptionSettings.WordListFile = wl.SFFile.FileName;
                this.Settings.OptionSettings.WordListFileType = wl.Type;
                UpdStatusBarWL();
                //MessageBox.Show("Word List imported");
                strText = m_Settings.LocalizationTable.GetMessage("App35");
                if (strText == "")
                    strText = "Word List imported";
                MessageBox.Show(strText);
            }
            //else MessageBox.Show("Word List not imported");
            else
            {
                strText = m_Settings.LocalizationTable.GetMessage("App36");
                if (strText == "")
                    strText = "Word List not imported";
                MessageBox.Show(strText);
            }
            this.ResetStatusBar();
		}

        private void menuToolsWordImportLIFT_Click(object sender, System.EventArgs e)
        {
            string strText = "";
            UpdStatusBarInfo(menuToolsWordImportLIFT.Text.Replace("&", ""));
            WordList wl = this.Settings.WordList;
            if (wl == null)
                wl = new WordList(this.Settings);
            wl = wl.LoadLIFT(this.Settings.OptionSettings.DataFolder);
            if (wl != null)
            {
                GraphemeInventory gi = this.Settings.GraphemeInventory;
                this.Settings.WordList = wl;
                this.Settings.OptionSettings.WordListFile = wl.FileName;
                this.Settings.OptionSettings.WordListFileType = wl.Type;
                UpdStatusBarWL();
                //MessageBox.Show("Word List imported");
                strText = m_Settings.LocalizationTable.GetMessage("App35");
                if (strText == "")
                    strText = "Word List imported";
                MessageBox.Show(strText);
            }
            //else MessageBox.Show("Word List not imported");
            else
            {
                strText = m_Settings.LocalizationTable.GetMessage("App36");
                if (strText == "")
                    strText = "Word List not imported";
                MessageBox.Show(strText);
            }
            this.ResetStatusBar();
        }

        private void menuToolsWordMerge_Click(object sender, System.EventArgs e)
        {
            UpdStatusBarInfo(menuToolsWordMerge.Text.Replace("&", ""));
            string strText = "";
            WordList wl = this.Settings.WordList;
            char chDuplicateProcessing = WordList.kKeepBoth;
            string strFileName = "";

            if (wl.Type == WordList.FileType.Lift)
            {
                //MessageBox.Show("Cannot merge to a Lift file");
                strText = m_Settings.LocalizationTable.GetMessage("App37");
                if (strText == "")
                    strText = "Cannot merge to a Lift file";
                MessageBox.Show(strText);
            }
            else
            {
                if (wl.WordCount() > 0)           //if there is a word list
                {
                    string strFolder = this.Settings.OptionSettings.DataFolder;
                    //FormMergeWordList fpb = new FormMergeWordList(strFolder);
                    FormMergeWordList form = new FormMergeWordList(strFolder, m_Settings.LocalizationTable);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        chDuplicateProcessing = form.DuplicateProcesssing;
                        strFileName = form.FileToMerge;
                        wl = wl.MergeSF(strFileName, chDuplicateProcessing);
                        if (wl.Merged)
                        {
                            this.Settings.WordList = wl;
                            this.Settings.OptionSettings.WordListFile = wl.SFFile.FileName;
                            UpdStatusBarWL();
                            //MessageBox.Show("Word List merged");
			                strText = m_Settings.LocalizationTable.GetMessage("App38");
			                if (strText == "")
				                strText  = "Word List merged";
			                MessageBox.Show(strText);
                        }
                        //else MessageBox.Show("Word List not merged");
                        else
                        {
                            strText = m_Settings.LocalizationTable.GetMessage("App39");
                            if (strText == "")
                                strText = "Word List not merged";
                            MessageBox.Show(strText);
                        }
                    }
                    //else MessageBox.Show("Merged cancelled");
                    else
                    {
                        strText = m_Settings.LocalizationTable.GetMessage("App40");
                        if (strText == "")
                            strText = "Merged cancelled";
                        MessageBox.Show(strText);
                    }
                }
                //else MessageBox.Show("Need to import a Word List first");
                else
                {
                    strText = m_Settings.LocalizationTable.GetMessage("App41");
                    if (strText == "")
                        strText = "Need to import a Word List first";
                    MessageBox.Show(strText);
                }
            }
            this.ResetStatusBar();
        }

        private void menuToolsWordReimport_Click(object sender, System.EventArgs e)
        {
            UpdStatusBarInfo(menuToolsWordReimport.Text.Replace("&", ""));
            string strFileName = "";
            WordList.FileType ft = WordList.FileType.None;

            WordList wl = this.Settings.WordList;
            strFileName = wl.FileName;
            ft = wl.Type;
            if ( strFileName == "" )
            {
                //MessageBox.Show("Word List File is not specified");
			    string strText = m_Settings.LocalizationTable.GetMessage("App42");
			    if (strText == "")
				    strText  = "Word List File is not specified";
			    MessageBox.Show(strText);
                return;
            }

            wl = new WordList(m_Settings);
            if (ft == WordList.FileType.Lift)
            {
                wl.FileName = strFileName;
                wl.Type = ft;
                this.Settings.WordList = wl;
                this.Settings.OptionSettings.WordListFile = strFileName;
                wl.LoadWordsFromLift();
                //MessageBox.Show("Word List LIFT file reimported");
			    string strText = m_Settings.LocalizationTable.GetMessage("App43");
			    if (strText == "")
				    strText  = "Word List LIFT file reimported";
			    MessageBox.Show(strText);
            }
            else if (ft == WordList.FileType.StandardFormat)
            {
                wl.FileName = strFileName;
                wl.Type = ft;
                if (wl.SFFile.LoadFile(strFileName, this.Settings.OptionSettings.FMRecordMarker))
                {
                    this.Settings.WordList = wl;
                    this.Settings.OptionSettings.WordListFile = strFileName;
                    if (wl.SFFile.Count() > 0)
                        wl.LoadWordsFromSF();
                    //MessageBox.Show("Word List SFM file reimported");
			        string strText = m_Settings.LocalizationTable.GetMessage("App44");
			        if (strText == "")
				        strText  = "Word List SFM file reimported";
			        MessageBox.Show(strText);
                }
                else
                {
                    wl = null;
                    this.Settings.WordList = wl;
                    this.Settings.OptionSettings.WordListFile = "";
                    //MessageBox.Show("Failed to reimport Word List file");
			        string strText = m_Settings.LocalizationTable.GetMessage("App45");
			        if (strText == "")
				        strText  = "Failed to reimport Word List file";
			        MessageBox.Show(strText);
                }
            }
            else
            {
                //MessageBox.Show("Word List File is not specified");
			    string strText = m_Settings.LocalizationTable.GetMessage("App46");
			    if (strText == "")
				    strText  = "Word List File is not specified";
			    MessageBox.Show(strText);
                return;
            }
            this.ResetStatusBar();
        }

        private void menuToolsWordExport_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuToolsWordExport.Text.Replace("&", ""));
            string strText = "";
            WordList wl = this.Settings.WordList;
            if (wl.Type == WordList.FileType.Lift)
            {
                //MessageBox.Show("Cannot export a Lift file");
                strText = m_Settings.LocalizationTable.GetMessage("App47");
                if (strText == "")
                    strText = "Cannot export a Lift file";
                MessageBox.Show(strText);
            }
            else
            {
                if (wl.SaveAs(this.Settings.OptionSettings.DataFolder))
                {
                    this.Settings.WordList = wl;
                    this.Settings.WordList.FileName = wl.FileName;
                    this.Settings.OptionSettings.WordListFile = wl.SFFile.FileName;
                    UpdStatusBarWL();
                    //MessageBox.Show("Current Word List exported");
                    strText = m_Settings.LocalizationTable.GetMessage("App48");
                    if (strText == "")
                        strText = "Current Word List exported";
                    MessageBox.Show(strText);
                }
                //else MessageBox.Show("Word List not exported");
                else
                {
                    strText = m_Settings.LocalizationTable.GetMessage("App49");
                    if (strText == "")
                        strText = "Word List not exported";
                    MessageBox.Show(strText);
                }
            }
			this.ResetStatusBar();
		}

        private void menuToolsWordUnload_Click(object sender, System.EventArgs e)
        {
            UpdStatusBarInfo(menuToolsWordUnload.Text.Replace("&", ""));
            WordList wl = this.Settings.WordList;
            string strText = "";
            if (wl != null)
            {
                if (wl.FileName != "")
                {
                    this.Settings.WordList = new WordList(m_Settings);
                    this.Settings.OptionSettings.WordListFile = "";
                    this.Settings.OptionSettings.WordListFileType = WordList.FileType.None;
                    UpdStatusBarWL();
                    //MessageBox.Show("Current Word List unloaded");
                    strText = m_Settings.LocalizationTable.GetMessage("App50");
                    if (strText == "")
                        strText = "Current Word List unloaded";
                    MessageBox.Show(strText);
                }
                //else MessageBox.Show("Word List already unloaded");
                else
                {
                    strText = m_Settings.LocalizationTable.GetMessage("App51");
                    if (strText == "")
                        strText = "Word List already unloaded";
                    MessageBox.Show(strText);
                }
            }
            //else MessageBox.Show("Word List already unloaded");
            else
            {
                strText = m_Settings.LocalizationTable.GetMessage("App51");
                if (strText == "")
                    strText = "Word List already unloaded";
                MessageBox.Show(strText);
            }
            this.ResetStatusBar();
        }

        private void menuToolsWordCheck_Click(object sender, System.EventArgs e)
		{
			string strText = "";
			string strResults = "";
			string strRtf = "";
			UpdStatusBarInfo(menuToolsWordCheck.Text.Replace("&", ""));

			AppView mdiChild = (AppView)this.ActiveMdiChild;
            if (mdiChild == null)
            {
                mdiChild = new AppView(pWindow, "");
                m_ViewCntr++;
                mdiChild.Text = strApp + m_ViewCntr.ToString();
                mdiChild.MdiParent = this;
                mdiChild.Show();
            }

			WordList wl = this.Settings.WordList;
			GraphemeInventory gi = this.Settings.GraphemeInventory;
            //strText = "Word List Graphemes missing from Inventory";
            strText = m_Settings.LocalizationTable.GetMessage("App100");
			strText += System.Environment.NewLine;
			strText += System.Environment.NewLine;
            strResults = wl.GetMissingGraphemes();
            if (strResults == "")
                //strText += "None";
                strText += m_Settings.LocalizationTable.GetMessage("App101");
            else strText += strResults;
			strRtf = mdiChild.FormatGraphemes(strText);
			mdiChild.Display(strRtf);
			this.ResetStatusBar();
		}

		private void menuToolsTextImport_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuToolsTextImport.Text.Replace("&", ""));
			TextData td = new TextData(m_Settings);
			String strFolder = this.Settings.OptionSettings.DataFolder;
            string strText = "";
			td = td.Load(strFolder);
            if (td != null)
            {
                this.Settings.TextData = td;
                this.Settings.OptionSettings.TextDataFile = td.FileName;
                UpdStatusBarTD();
                //MessageBox.Show("Text Data imported");
                strText = m_Settings.LocalizationTable.GetMessage("App52");
                if (strText == "")
                    strText = "Text Data imported";
                MessageBox.Show(strText);
            }
            //else MessageBox.Show("Text Data not imported");
            else
            {
                strText = m_Settings.LocalizationTable.GetMessage("App53");
                if (strText == "")
                    strText = "Text Data not imported";
                MessageBox.Show(strText);
            }
            this.ResetStatusBar();
		}

		private void menuToolsTextMerge_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuToolsTextMerge.Text.Replace("&", ""));
			TextData td = this.Settings.TextData;
            string strText = "";
			String strFolder = this.Settings.OptionSettings.DataFolder;
			td = td.Merge(strFolder);
            if (td.FileName == TextData.kMergeTextData)
            {
                this.Settings.TextData = td;
                this.Settings.OptionSettings.TextDataFile = td.FileName;
                UpdStatusBarTD();
                //MessageBox.Show("Text Data merged");
                strText = m_Settings.LocalizationTable.GetMessage("App54");
                if (strText == "")
                    strText = "Text Data merged";
                MessageBox.Show(strText);
            }
            //else MessageBox.Show("Text Data not merged");
            else
            {
                strText = m_Settings.LocalizationTable.GetMessage("App55");
                if (strText == "")
                    strText = "Text Data not merged";
                MessageBox.Show(strText);
            }
            this.ResetStatusBar();
		}

		private void menuToolsTextExport_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuToolsTextExport.Text.Replace("&", ""));
			bool flag = false;
            string strText = "";
			TextData td = this.Settings.TextData;
			flag = td.Save(this.Settings.OptionSettings.DataFolder);
            if (flag)
            {
                this.Settings.TextData = td;
                this.Settings.OptionSettings.TextDataFile = td.FileName;
                UpdStatusBarTD();
                //MessageBox.Show("Current Text Data exported");
                strText = m_Settings.LocalizationTable.GetMessage("App56");
                if (strText == "")
                    strText = "Current Text Data exported";
                MessageBox.Show(strText);
            }
            //else MessageBox.Show("Text Data not exported");
            else
            {
                strText = m_Settings.LocalizationTable.GetMessage("App57");
                if (strText == "")
                    strText = "Text Data not exported";
                MessageBox.Show(strText);
            }
            this.ResetStatusBar();
		}

        private void menuToolsTextReimport_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuToolsTextReimport.Text.Replace("&", ""));
            TextData td = this.Settings.TextData;
            string strFileName = td.FileName;
            td = new TextData(m_Settings);
            if (td.LoadFile(strFileName))
            {
                this.Settings.TextData = td;
                this.Settings.OptionSettings.TextDataFile = strFileName;
                UpdStatusBarTD();
                //MessageBox.Show("Text Data file reimported");
			    string strText = m_Settings.LocalizationTable.GetMessage("App58");
			    if (strText == "")
				    strText  = "Text Data file reimported";
			    MessageBox.Show(strText);
            }
            else
            {
                td = null;
                this.Settings.TextData = td;
                this.Settings.OptionSettings.TextDataFile = "";
                //MessageBox.Show("Failed to reimport Text Data file");
			    string strText = m_Settings.LocalizationTable.GetMessage("App59");
			    if (strText == "")
				    strText  = "Failed to reimport Text Data file";
			    MessageBox.Show(strText);
            }
            this.ResetStatusBar();
        }

        private void menuToolsTextUnload_Click(object sender, System.EventArgs e)
        {
            UpdStatusBarInfo(menuToolsTextUnload.Text.Replace("&", ""));
            TextData td = this.Settings.TextData;
            string strText = "";
            if (td != null)
            {
                if (td.FileName != "")
                {
                    this.Settings.TextData = new TextData(m_Settings);
                    this.Settings.OptionSettings.TextDataFile = "";
                    UpdStatusBarTD();
                    //MessageBox.Show("Current Text Data unloaded");
                    strText = m_Settings.LocalizationTable.GetMessage("App60");
                    if (strText == "")
                        strText = "Current Text Data unloaded";
                    MessageBox.Show(strText);
                }
                //else MessageBox.Show("Text Data already unloaded");
                else
                {
                    strText = m_Settings.LocalizationTable.GetMessage("App61");
                    if (strText == "")
                        strText = "Text Data already unloaded";
                    MessageBox.Show(strText);
                }
            }
            //else MessageBox.Show("Text Data already unloaded");
            else
            {
                strText = m_Settings.LocalizationTable.GetMessage("App61");
                if (strText == "")
                    strText = "Text Data already unloaded";
                MessageBox.Show(strText);
            }
            this.ResetStatusBar();
        }

        private void menuToolsTextCheckGI_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuToolsTextCheckGI.Text.Replace("&", ""));
			string strText = "";
			string strResults = "";
			string strRtf = "";

			AppView mdiChild = (AppView)this.ActiveMdiChild;
            if (mdiChild == null)
            {
                mdiChild = new AppView(pWindow, "");
                m_ViewCntr++;
                mdiChild.Text = strApp + m_ViewCntr.ToString();
                mdiChild.MdiParent = this;
                mdiChild.Show();
            }

			TextData td = this.Settings.TextData;
			GraphemeInventory gi = this.Settings.GraphemeInventory;
            //strText = "Text Data Graphemes missing from Inventory";
            strText = m_Settings.LocalizationTable.GetMessage("App102");
			strText += System.Environment.NewLine;
			strText += System.Environment.NewLine;
            strResults = td.GetMissingGraphemes();
            if (strResults == "")
                //strText += "None";
                strText = m_Settings.LocalizationTable.GetMessage("App101");
            else strText += strResults;
			strRtf = mdiChild.FormatGraphemes(strText);
			mdiChild.Display(strRtf);
			this.ResetStatusBar();
		}

		private void menuToolsTextCheckWL_Click(object sender, System.EventArgs e)
		{
			string strText = "";
			string strResults = "";
			string strRtf = "";
			UpdStatusBarInfo(menuToolsTextCheckWL.Text.Replace("&", ""));

			AppView mdiChild = (AppView)this.ActiveMdiChild;
            if (mdiChild == null)
            {
                mdiChild = new AppView(pWindow, "");
                m_ViewCntr++;
                mdiChild.Text = strApp + m_ViewCntr.ToString();
                mdiChild.MdiParent = this;
                mdiChild.Show();
            }

			TextData td = this.Settings.TextData;
			GraphemeInventory gi = this.Settings.GraphemeInventory;
            //strText = "Text Data Words missing from Word List";
            strText = m_Settings.LocalizationTable.GetMessage("App103");
            strText += System.Environment.NewLine;
			strText += System.Environment.NewLine;
			strResults = td.GetMissingWords();
			if (strResults == "")
                //strText += "None";
                strText = m_Settings.LocalizationTable.GetMessage("App101");
            else strText += strResults;
			strRtf = mdiChild.FormatWordList(strText);
			mdiChild.Display(strRtf);
			this.ResetStatusBar();
		}

        private void menuToolsTextBuildWL_Click(object sender, System.EventArgs e)
        {
            UpdStatusBarInfo(menuToolsTextBuildWL.Text.Replace("&", ""));
            AppView mdiChild = (AppView)this.ActiveMdiChild;
            TextData td = this.Settings.TextData;
            WordList wl = this.Settings.WordList;
            string strFileName = "";
            string strText = "";
            if (td.FileName != "")
            {
                strFileName = GetSaveFileName();
                if (strFileName != "")
                {
                    StandardFormatFile sff = td.BuildStandardFormatFile();
                    sff.SaveFile(strFileName);
                    //MessageBox.Show("Built word list saved");
                    strText = m_Settings.LocalizationTable.GetMessage("App62");
                    if (strText == "")
                        strText = "Built word list saved";
                    MessageBox.Show(strText);
                }
            }
            //else MessageBox.Show("Need import to text data first");
            else
            {
                strText = m_Settings.LocalizationTable.GetMessage("App63");
                if (strText == "")
                    strText = "Need import to text data first";
                MessageBox.Show(strText);
            }
        }

        private void menuToolsInventoryInitWL_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuToolsInventoryInit.Text.Replace("&", ""));
            if (this.Settings.GraphemeInventory.GraphemeCount() > 0)
            {
                string StrCount = this.Settings.GraphemeInventory.GraphemeCount().ToString();
                //string strMsg = "The GraphemeInventory has" + StrCount + " graphemes.  Do you want to clear it?";
                string strMsg = m_Settings.LocalizationTable.GetMessage("App126");
                string strMsg2 = m_Settings.LocalizationTable.GetMessage("App127");
                if (strMsg == "")
                    strMsg = "The GraphemeInventory has";
                if (strMsg2 == "")
                    strMsg2 = "graphemes.  Do you want to clear it?";
                strMsg = strMsg + StrCount.PadLeft(5, ' ') + Constants.Space.ToString() + strMsg2;
                //string strCaption = "Initialize Grapheme Inventory";
                string strCaption = menuToolsInventoryInit.Text.Replace("&", "");
                if (MessageBox.Show(strMsg, strCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    this.InitGraphemeInventoryWL(true);
                else this.InitGraphemeInventoryWL(false);
            }
            else this.InitGraphemeInventoryWL(true);
            this.ResetStatusBar();
        }

        private void menuToolsInventoryInitTD_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuToolsInventoryInit.Text.Replace("&", ""));
            if (this.Settings.GraphemeInventory.GraphemeCount() > 0)
            {
                string StrCount = this.Settings.GraphemeInventory.GraphemeCount().ToString();
                //string strMsg = "The GraphemeInventory has" + StrCount + " graphemes.  Do you want to clear it?";
                string strMsg = m_Settings.LocalizationTable.GetMessage("App126");
                string strMsg2 = m_Settings.LocalizationTable.GetMessage("App127");
                if (strMsg == "")
                    strMsg = "The GraphemeInventory has";
                if (strMsg2 == "")
                    strMsg2 = "graphemes.  Do you want to clear it?";
                strMsg = strMsg + StrCount.PadLeft(5, ' ') + Constants.Space.ToString() + strMsg2;
                //string strCaption = "Initialize Grapheme Inventory";
                string strCaption = menuToolsInventoryInit.Text.Replace("&", "");
                if (MessageBox.Show(strMsg, strCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    this.InitGraphemeInventoryTD(true);
                else this.InitGraphemeInventoryTD(false);
            }
            else this.InitGraphemeInventoryTD(true);
            this.ResetStatusBar();
        }

        private void menuToolsInventoryInitPG_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuToolsInventoryInit.Text.Replace("&", ""));
            if (this.Settings.GraphemeInventory.GraphemeCount() > 0)
            {
                string StrCount = this.Settings.GraphemeInventory.GraphemeCount().ToString();
                //string strMsg = "The GraphemeInventory has" + StrCount + " graphemes.  Do you want to clear it?";
                string strMsg = m_Settings.LocalizationTable.GetMessage("App126");
                string strMsg2 = m_Settings.LocalizationTable.GetMessage("App127");
                if (strMsg == "")
                    strMsg = "The GraphemeInventory has";
                if (strMsg2 == "")
                    strMsg2 = "graphemes.  Do you want to clear it?";
                strMsg = strMsg + StrCount.PadLeft(5, ' ') + Constants.Space.ToString() + strMsg2;
                //string strCaption = "Initialize Grapheme Inventory";
                string strCaption = menuToolsInventoryInit.Text.Replace("&", "");
                if (MessageBox.Show(strMsg, strCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    this.InitGraphemeInventoryPG();
            }
            else this.InitGraphemeInventoryPG();
            this.ResetStatusBar();
        }

        private void menuToolsInventorySyllabary_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuToolsInventorySyllabary.Text.Replace("&", ""));
            if (this.Settings.GraphemeInventory.GraphemeCount() > 0)
            {
                string StrCount = this.Settings.GraphemeInventory.GraphemeCount().ToString();
                //string strMsg = "The GraphemeInventory has" + StrCount + " graphemes.  Do you want to clear it?";
                string strMsg = m_Settings.LocalizationTable.GetMessage("App126");
                string strMsg2 = m_Settings.LocalizationTable.GetMessage("App127");
                if (strMsg == "")
                    strMsg = "The GraphemeInventory has";
                if (strMsg2 == "")
                    strMsg2 = "graphemes.  Do you want to clear it?";
                strMsg = strMsg + StrCount.PadLeft(5, ' ') + Constants.Space.ToString() + strMsg2;
                //string strCaption = "Initialize Syllabary Inventory";
                string strCaption = menuToolsInventorySyllabary.Text.Replace("&", "");
                if (MessageBox.Show(strMsg, strCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    this.InitGraphemeInventorySyllabary(true);
                else this.InitGraphemeInventorySyllabary(false);
            }
            else this.InitGraphemeInventorySyllabary(true);
            this.ResetStatusBar();
        }

        private void menuToolsInventoryConsonants_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuToolsInventoryConsonants.Text.Replace("&", ""));
			FormConsonantInventory form = new FormConsonantInventory(m_Settings);
			form.ShowDialog(this);

            GraphemeInventory gi = this.Settings.GraphemeInventory;
            gi.SaveToFile(gi.FileName);
			this.ResetStatusBar();
		}

		private void menuToolsInventoryVowels_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuToolsInventoryVowels.Text.Replace("&", ""));
			FormVowelInventory form = new FormVowelInventory(m_Settings, m_Settings.LocalizationTable);
			form.ShowDialog(this);

            GraphemeInventory gi = this.Settings.GraphemeInventory;
            gi.SaveToFile(gi.FileName);
            this.ResetStatusBar();
		}

		private void menuToolsInventoryTone_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuToolsInventoryTone.Text.Replace("&", ""));
			FormToneInventory form = new  FormToneInventory(m_Settings);
			form.ShowDialog(this);
            
            GraphemeInventory gi = this.Settings.GraphemeInventory;
            gi.SaveToFile(gi.FileName);
            this.ResetStatusBar();
		}

        private void menuToolsInventorySyllograph_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuToolsInventoryConsonants.Text.Replace("&", ""));
            FormSyllographInventory form = new FormSyllographInventory(m_Settings, m_Settings.LocalizationTable);
            form.ShowDialog(this);

            GraphemeInventory gi = this.Settings.GraphemeInventory;
            gi.SaveToFile(gi.FileName);
            this.ResetStatusBar();
        }

        private void menuToolsInventorySave_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuToolsInventorySave.Text.Replace("&", ""));
            SaveFileDialog sfd1 = new SaveFileDialog();
            sfd1.Filter = "XML files (*.xml)|*.xml";
            sfd1.FileName = m_Settings.OptionSettings.GraphemeInventoryFile;
            sfd1.DefaultExt = "*.xml";
            sfd1.CheckFileExists = false;
            sfd1.CheckPathExists = true;
            sfd1.InitialDirectory = Settings.OptionSettings.DataFolder;

            DialogResult dr1 = sfd1.ShowDialog();
            string strMsg = "";

            if (dr1 == DialogResult.OK)
            {
                GraphemeInventory gi = Settings.GraphemeInventory;
                string strFileName = sfd1.FileName;
                m_Settings.OptionSettings.GraphemeInventoryFile = strFileName;
                gi.SaveToFile(strFileName);
                gi.FileName = strFileName;
                //MessageBox.Show(strFileName + " saved");
                strMsg = m_Settings.LocalizationTable.GetMessage("App65");
                MessageBox.Show(strFileName + Constants.Space + strMsg);
            }
            //else MessageBox.Show("Save cancelled");
            else
            {
                strMsg = m_Settings.LocalizationTable.GetMessage("App66");
                if (strMsg == "")
                    strMsg = "Save cancelled";
                MessageBox.Show(strMsg);
            }
            this.ResetStatusBar();
        }

        private void menuToolsInventoryClear_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuToolsInventoryClear.Text.Replace("&", ""));
            //if (MessageBox.Show("Are you sure?", "Clear Grapheme Inventory", MessageBoxButtons.YesNo,
            //    MessageBoxIcon.Question) == DialogResult.Yes)
            string strMsg = m_Settings.LocalizationTable.GetMessage("App9");
            string strCaption = m_Settings.LocalizationTable.GetMessage("App67");
            if (MessageBox.Show(strMsg, strCaption, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Settings.GraphemeInventory = new GraphemeInventory(Settings);
                GraphemeInventory gi = Settings.GraphemeInventory;
                Settings.GraphemeInventory.FileName = Settings.OptionSettings.GraphemeInventoryFile;
                gi.SaveToFile(Settings.GraphemeInventory.FileName);
            }
            this.ResetStatusBar();
        }

        private void menuToolsPartsInit_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuToolsPartsInit.Text.Replace("&", ""));
            PSTable pst = new PSTable(m_Settings);
            string strFileName = m_Settings.GetAppFolder() + AppWindow.kBackSlash + AppWindow.kDefaultPSTableName;
            string strText = "";
            if (pst.LoadFromFile(strFileName))
            {
                strFileName = this.Settings.PrimerProFolder + AppWindow.kBackSlash +
                    AppWindow.kPSTableName;
                pst.SaveToFile(strFileName);
                this.Settings.PSTable = pst;
                //MessageBox.Show("Parts of Speech table has been initialized");
                strText = m_Settings.LocalizationTable.GetMessage("App68");
                if (strText == "")
                    strText = "Parts of Speech table has been initialized";
                MessageBox.Show(strText);
            }
            //else MessageBox.Show("Initialization of Parts of Speech failed");
            else
            {
                strText = m_Settings.LocalizationTable.GetMessage("App69");
                if (strText == "")
                    strText = "Initialization of Parts of Speech failed";
                MessageBox.Show(strText);
            }
            this.ResetStatusBar();
        }

        private void menuToolsPartsUpdate_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuToolsPartsUpdate.Text.Replace("&", ""));
            //FormPSTable fpb = new FormPSTable(this.Settings.PSTable);
            FormPSTable form = new FormPSTable(m_Settings.PSTable, m_Settings.LocalizationTable);
            form.ShowDialog(this);
            
            PSTable pst = this.Settings.PSTable;
            pst.SaveToFile(pst.FileName);
            this.ResetStatusBar();
        }

        private void menuToolsPartsSave_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuToolsPartsSave.Text.Replace("&", ""));
            SaveFileDialog sfd1 = new SaveFileDialog();
            sfd1.Filter = "XML files (*.xml)|*.xml";
            sfd1.FileName = m_Settings.OptionSettings.PSTableFile;
            sfd1.DefaultExt = "*.xml";
            sfd1.CheckFileExists = false;
            sfd1.CheckPathExists = true;
            sfd1.InitialDirectory = Settings.OptionSettings.DataFolder;

            DialogResult dr1 = sfd1.ShowDialog();

            if (dr1 == DialogResult.OK)
            {
                PSTable pst = this.Settings.PSTable;
                string strFileName = sfd1.FileName;
                m_Settings.OptionSettings.PSTableFile = strFileName;
                pst.SaveToFile(strFileName);
                pst.FileName = strFileName;
            }
            //else MessageBox.Show("Save cancelled");
            else
            {
                string strText = m_Settings.LocalizationTable.GetMessage("App66");
                if (strText == "")
                    strText = "Save cancelled";
                MessageBox.Show(strText);
            }
            this.ResetStatusBar();
        }

        private void menuToolsSightUpdate_Click(object sender, System.EventArgs e)
		{
            UpdStatusBarInfo(menuToolsSightUpdate.Text.Replace("&", ""));
            FormSightWords form = new FormSightWords(m_Settings, m_Settings.LocalizationTable);
            if (form.ShowDialog(this) == DialogResult.Cancel)
            {
                //MessageBox.Show("Update Sight Words cancelled");
                string strText = m_Settings.LocalizationTable.GetMessage("App70");
                if (strText == "")
                    strText = "Update Sight Words cancelled";
                MessageBox.Show(strText);
            }
            SightWords sw = this.Settings.SightWords;
            sw.SaveToFile(sw.FileName);
            this.ResetStatusBar();
  		}

        private void menuToolsSightSave_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuToolsSightSave.Text.Replace("&", ""));
            SaveFileDialog sfd1 = new SaveFileDialog();
            sfd1.Filter = "XML files (*.xml)|*.xml";
            sfd1.FileName = m_Settings.OptionSettings.SightWordsFile;
            sfd1.DefaultExt = "*.xml";
            sfd1.CheckFileExists = false;
            sfd1.CheckPathExists = true;
            sfd1.InitialDirectory = Settings.OptionSettings.DataFolder;

            DialogResult dr1 = sfd1.ShowDialog();

            if (dr1 == DialogResult.OK)
            {
                SightWords sw = this.m_Settings.SightWords;
                string strFileName = sfd1.FileName;
                m_Settings.OptionSettings.SightWordsFile = strFileName;
                sw.SaveToFile(strFileName);
                sw.FileName = strFileName;
            }
            //else MessageBox.Show("Save cancelled");
            else
            {
                string strText = m_Settings.LocalizationTable.GetMessage("App66");
                if (strText == "")
                    strText = "Save cancelled";
                MessageBox.Show(strText);
            }
            this.ResetStatusBar();
        }

        private void menuToolsSightCheckWL_Click(object sender, System.EventArgs e)
		{
			string strText = "";
			string strResults = "";
			string strRtf = "";
            UpdStatusBarInfo(menuToolsSightCheckWL.Text.Replace("&", ""));

			AppView mdiChild = (AppView)this.ActiveMdiChild;
            if (mdiChild == null)
            {
                mdiChild = new AppView(pWindow, "");
                m_ViewCntr++;
                mdiChild.Text = strApp + m_ViewCntr.ToString();
                mdiChild.MdiParent = this;
                mdiChild.Show();
            }

	        SightWords sw = this.Settings.SightWords;
	        GraphemeInventory gi = this.Settings.GraphemeInventory;
            //strText = "Sight Words missing from Word List";
            strText = m_Settings.LocalizationTable.GetMessage("App104");
	        strText += System.Environment.NewLine;
	        strText += System.Environment.NewLine;
	        strResults = sw.GetMissingWords();
	        if (strResults == "")
                //strText += "None";
                strText = m_Settings.LocalizationTable.GetMessage("App101");
            else strText += strResults;
	        strRtf = mdiChild.FormatTable(strText);
	        mdiChild.Display(strRtf);
	        this.ResetStatusBar();
		}

        private void menuToolsOrderUpdate_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuToolsOrderUpdate.Text.Replace("&", ""));
            FormGraphemesTaught form = new FormGraphemesTaught(m_Settings.GraphemesTaught, m_Settings.OptionSettings.GetDefaultFont(),
                m_Settings.LocalizationTable);
            if (form.ShowDialog(this) == DialogResult.Cancel)
            {
                //MessageBox.Show("Update Taught Graphemes cancelled");
                string strText = m_Settings.LocalizationTable.GetMessage("App71");
                if (strText == "")
                    strText = "Update Taught Graphemes cancelled";
                MessageBox.Show(strText);
            }

            GraphemeTaughtOrder gto = this.Settings.GraphemesTaught;
            gto.SaveToFile(gto.FileName);
            this.ResetStatusBar();
        }

        private void menuToolsOrderSave_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuToolsOrderSave.Text.Replace("&", ""));
            SaveFileDialog sfd1 = new SaveFileDialog();
            sfd1.Filter = "XML files (*.xml)|*.xml";
            sfd1.FileName = m_Settings.OptionSettings.GraphemeTaughtOrderFile;
            sfd1.DefaultExt = "*.xml";
            sfd1.CheckFileExists = false;
            sfd1.CheckPathExists = true;
            sfd1.InitialDirectory = Settings.OptionSettings.DataFolder;

            DialogResult dr1 = sfd1.ShowDialog();

            if (dr1 == DialogResult.OK)
            {
                GraphemeTaughtOrder gto = this.m_Settings.GraphemesTaught;
                string strFileName = sfd1.FileName;
                m_Settings.OptionSettings.GraphemeTaughtOrderFile = strFileName;
                gto.SaveToFile(strFileName);
                gto.FileName = strFileName;
            }
            //else MessageBox.Show("Save cancelled");
            else
            {
                string strText = m_Settings.LocalizationTable.GetMessage("App66");
                if (strText == "")
                    strText = "Save cancelled";
                MessageBox.Show(strText);
            }
            this.ResetStatusBar();
        }

        private void menuToolsOrderCheck_Click(object sender, EventArgs e)
        {
            string strText = "";
            string strResults = "";
            string strRtf = "";
            UpdStatusBarInfo(menuToolsOrderCheck.Text.Replace("&", ""));

            AppView mdiChild = (AppView)this.ActiveMdiChild;
            if (mdiChild == null)
            {
                mdiChild = new AppView(pWindow, "");
                m_ViewCntr++;
                mdiChild.Text = strApp + m_ViewCntr.ToString();
                mdiChild.MdiParent = this;
                mdiChild.Show();
            }

            GraphemeTaughtOrder gto = this.Settings.GraphemesTaught;
            GraphemeInventory gi = this.Settings.GraphemeInventory;
            //strText = "Graphemes Taught missing from Inventory";
            strText = m_Settings.LocalizationTable.GetMessage("App105");
            strText += System.Environment.NewLine;
            strText += System.Environment.NewLine;
            strResults = gto.GetMissingGraphemes();
            if (strResults == "")
                //strText += "None";
                strText += m_Settings.LocalizationTable.GetMessage("App101");
            else strText += strResults;
            strRtf = mdiChild.FormatTable(strText);
            mdiChild.Display(strRtf);
            this.ResetStatusBar();
        }

        private void menuToolsOptions_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuToolsOptions.Text.Replace("&", ""));
			FormOptions form = new FormOptions(m_Settings);
			form.ShowDialog(this);
            m_Settings.LocalizationTable = this.GetLocalizationTable();
            this.UpdateMenuForLocalization();
            if (m_Settings.OptionSettings.SimplifiedMenu)
                this.UpdateMenuForSimplified();
            else this.UpdateMenuForNormal();
            AppView mdiChild = (AppView)this.ActiveMdiChild;
            if (mdiChild != null)
                mdiChild.UpdateMenu();
            this.UpdStatusBarWL();
            this.UpdStatusBarTD();
            this.ResetStatusBar();
        }

		private void menuWindowCascade_Click(object sender, System.EventArgs e)
		{
			this.LayoutMdi(MdiLayout.Cascade);
			this.ResetStatusBar();
		}

		private void menuWindowTileH_Click(object sender, System.EventArgs e)
		{
			this.LayoutMdi(MdiLayout.TileHorizontal);
			this.ResetStatusBar();
		}

		private void menuWindowTileV_Click(object sender, System.EventArgs e)
		{
			this.LayoutMdi(MdiLayout.TileVertical);
			this.ResetStatusBar();
		}

		private void menuHelpHelp_Click(object sender, System.EventArgs e)
		{
            // Help code to open a chm file
            string strPath = this.Settings.GetHelpFile();
            if (File.Exists(strPath))
                Help.ShowHelp(this, strPath);       //Open chm file
            //else MessageBox.Show("Help is not available");
            else
            {
                string strText = m_Settings.LocalizationTable.GetMessage("App72");
                if (strText == "")
                    strText = "Help is not available";
                MessageBox.Show(strText);
            }
		}

        private void menuHelpSetup_Click(object sender, EventArgs e)
        {
            //Open setup tutorial as a pdf file in a separate process
            string strPath = this.Settings.GetAppFolder() + AppWindow.kBackSlash +
                "PrimerPro Setup Tutorial.pdf";
            if (File.Exists(strPath))
            {
                Process proc = new Process();
                proc.StartInfo.FileName = strPath;
                proc.StartInfo.Arguments = "Open";
                proc.Start();
            }
            //else MessageBox.Show("Tutorial is not available");
            else
            {
                string strText = m_Settings.LocalizationTable.GetMessage("App125");
                if (strText == "")
                    strText = "Tutorial is not available";
                MessageBox.Show(strText);
                this.ResetStatusBar();
            }
        }

        private void menuHelpPrimer_Click(object sender, EventArgs e)
        {
            //Open primer making tutorial as a pdf file in a separate process
            string strPath = this.Settings.GetAppFolder() + AppWindow.kBackSlash +
                "PrimerPro PrimerMaking Tutorial.pdf";
            if (File.Exists(strPath))
            {
                Process proc = new Process();
                proc.StartInfo.FileName = strPath;
                proc.StartInfo.Arguments = "Open";
                proc.Start();
            }
            //else MessageBox.Show("Tutorial is not available");
            else
            {
                string strText = "";
                strText = m_Settings.LocalizationTable.GetMessage("App125");
                if (strText == "")
                    strText = "Tutorial is not available";
                MessageBox.Show(strText);
            }
            this.ResetStatusBar();
        }

        private void menuHelpNew_Click(object sender, EventArgs e)
        {
            //Open What'sNewl as a pdf file in a separate process
            string strPath = this.Settings.GetAppFolder() + AppWindow.kBackSlash +
                "PrimerPro What's New.pdf";
            if (File.Exists(strPath))
            {
                Process proc = new Process();
                proc.StartInfo.FileName = strPath;
                proc.StartInfo.Arguments = "Open";
                proc.Start();
            }
            else MessageBox.Show("What's New is not available");
            this.ResetStatusBar();

        }

        private void menuHelpAbout_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuHelpAbout.Text.Replace("&", ""));
 			FormAbout form = new FormAbout(m_Settings.LocalizationTable);
            form.ShowDialog(this);
			this.ResetStatusBar();
		}

		private void menuTest1_Click(object sender, System.EventArgs e)
        //Text datak
		{
            UpdStatusBarInfo(menuViewWordList.Text.Replace("&", ""));
            string strText = "";
            string strRtf = "";
            AppView mdiChild = (AppView)this.ActiveMdiChild;
            if (mdiChild == null)
            {
                mdiChild = new AppView(pWindow, "");
                m_ViewCntr++;
                mdiChild.Text = strApp + m_ViewCntr.ToString();
                mdiChild.MdiParent = this;
                mdiChild.Show();
            }

            TextData td = m_Settings.TextData;
            int kount = 0;
            kount = td.MaxNumberOfWordsInSentences();
            MessageBox.Show("Max no of words in sentences: " + kount.ToString());
            kount = td.MaxNumberOfSyllablesInWords();
            MessageBox.Show("Max no of syllables in words: " + kount.ToString());
            kount = td.WordCount();
            MessageBox.Show("Number of Words: " + kount.ToString());
            kount = td.AvgNumberOfWordsInSentences();
            MessageBox.Show("Avg no of words in sentences: " + kount.ToString());
            kount = td.AvgNumberOfSyllablesInWords();
            MessageBox.Show("Avg no of syllables in words: " + kount.ToString());
            
            strRtf = mdiChild.FormatText(strText, false);
            mdiChild.Display(strRtf);

            this.ResetStatusBar();
        }

        private void menuTest2_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuHelpAbout.Text.Replace("&", "Testing something"));
            AppView mdiChild = (AppView)this.ActiveMdiChild;
            if (mdiChild == null)
            {
                mdiChild = new AppView(pWindow, "");
                m_ViewCntr++;
                mdiChild.Text = strApp + m_ViewCntr.ToString();
                mdiChild.MdiParent = this;
                mdiChild.Show();
            }
            
            FormTestMethod form = new FormTestMethod();
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            //string strRslt = "";
            
            GraphemeInventory gi = m_Settings.GraphemeInventory;
            GraphemeTaughtOrder gto = m_Settings.GraphemesTaught;
            WordList wl = m_Settings.WordList;
            TextData td = m_Settings.TextData;
            RichTextBox rtb = null;

            do
            {
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    str1 = form.Parm1;
                    str2 = form.Parm2;
                    str3 = form.Parm3;
                    str4 = form.Parm4;

                    if (str1 != "")
                    {
                        Word wrd = null;
                        string strText = "";
                        string strRtf = "";
                        wl = new WordList();

                        wrd = new Word(str1, m_Settings);
                        wl.AddWord(wrd);
                        if (str2 != "")
                        {
                            wrd = new Word(str2, m_Settings);
                            wl.AddWord(wrd);
                        }
                        if (str3 != "")
                        {
                            wrd = new Word(str3, m_Settings);
                            wl.AddWord(wrd);
                        }
                        if (str4 != "")
                        {
                            wrd = new Word(str4, m_Settings);
                            wl.AddWord(wrd);
                        }

                        SortedList sl = wl.BuildSortedCharacterList();
                        for (int i = 0; i < sl.Count; i++)
                        {
                            strText = strText + sl.GetByIndex(i).ToString() + Environment.NewLine;
                        }
                        strRtf = mdiChild.FormatText(strText, false);
                        mdiChild.Display(strRtf);
                        MessageBox.Show("press any key to continue");
                        rtb = mdiChild.Rtb;
                        rtb.Clear();
                    }

                }
                form.Reset();
            }
            while (form.DialogResult != DialogResult.Cancel);
            this.ResetStatusBar();
        }

        private void menuTest3_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuViewWordList.Text.Replace("&", ""));
            AppView mdiChild = (AppView)this.ActiveMdiChild;
            if (mdiChild == null)
            {
                mdiChild = new AppView(pWindow, "");
                m_ViewCntr++;
                mdiChild.Text = strApp + m_ViewCntr.ToString();
                mdiChild.MdiParent = this;
                mdiChild.Show();
            }

            OpenFileDialog ofd1 = new OpenFileDialog();
			ofd1.Filter = "XML files (*.xml)|*.xml|All Files (*.*)|*.*";
			ofd1.FileName = "";
			ofd1.DefaultExt = "*.xml";
			ofd1.InitialDirectory = this.Settings.GetAppFolder();;
			ofd1.CheckFileExists = true;
			ofd1.CheckPathExists = true;

			DialogResult dr1 = ofd1.ShowDialog();
            if (dr1 == DialogResult.OK)
            {
                string strFileName = ofd1.FileName;
                LocalizationTable table = m_Settings.LocalizationTable;
                if (table.SaveToFile(strFileName))
                    return;
                return;
            }
        }

        private void menuTestBrowse_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuTestBrowse.Text.Replace("&", ""));
            ArrayList al = null;
            Color clr = this.Settings.OptionSettings.HighlightColor;
            Font fnt  = this.Settings.OptionSettings.GetDefaultFont();
            Word wrd = null;;
            FormBrowse form = new FormBrowse();
            form.Text = "Browse Word List";
            
            WordList wl = this.Settings.WordList;
            //wl = wl.SortWordList();
            al = wl.GetDisplayHeadingsAsArray();
            form.AddColHeaders(al, clr, fnt);

            for (int i = 0; i < wl.WordCount(); i++)
            {
                wrd = wl.GetWord(i);
                al = wrd.GetWordInfoAsArray();
                form.AddRow(al);
            }

            form.Text += " - " + wl.WordCount().ToString() + " entries";
            form.ShowDialog();
            this.ResetStatusBar();
        }

        private void menuTestTemp_Click(object sender, EventArgs e)
        {
            string strText = "";
            string strRtf = "";
            UpdStatusBarInfo(menuViewInventory.Text.Replace("&", ""));
            AppView mdiChild = (AppView)this.ActiveMdiChild;
            if (mdiChild == null)
            {
                mdiChild = new AppView(pWindow, "");
                m_ViewCntr++;
                mdiChild.Text = strApp + m_ViewCntr.ToString();
                mdiChild.MdiParent = this;
                mdiChild.Show();
            }

            GraphemeInventory m_GraphemeInventory = this.Settings.GraphemeInventory;
            if (m_GraphemeInventory == null)
                m_GraphemeInventory = new GraphemeInventory(this.Settings);

            ArrayList alVowels = m_GraphemeInventory.Vowels;
            ArrayList alCons = m_GraphemeInventory.Consonants;
            ArrayList alSyllo = m_GraphemeInventory.Syllographs;
            Vowel vwl = null;
            Consonant cns = null;
            Syllograph syl = null;
            string strSymbol = "";
            string strKey = "";
            for (int i = 0; i < alVowels.Count; i++)
            {
                vwl = (Vowel)alVowels[i];
                strSymbol = vwl.Symbol;
                strKey = vwl.GetKey();
                strText += strSymbol + "   " + strKey + Environment.NewLine;
            }
            strText += Environment.NewLine;

            for (int i = 0; i < alCons.Count; i++)
            {
                cns = (Consonant)alCons[i];
                strSymbol = cns.Symbol;
                strKey = cns.GetKey();
                strText += strSymbol + "   " + strKey + Environment.NewLine;
            }
            strText += Environment.NewLine;

            for (int i = 0; i < alSyllo.Count; i++)
            {
                syl = (Syllograph)alSyllo[i];
                strSymbol = syl.Symbol;
                strKey = syl.GetKey();
                strText += strSymbol + "   " + strKey + Environment.NewLine;
            }
            strText += Environment.NewLine;

            strRtf = mdiChild.FormatGraphemes(strText);
            mdiChild.Display(strRtf);
            this.ResetStatusBar();
        }

        //Process menu selects		
        private void menuFileNew_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Opens a new active document");
			string strText = m_Settings.LocalizationTable.GetMessage("App201");
			if (strText == "")
				strText  = "Opens a new active document";
			UpdStatusBarInfo(strText);
 		}
		
		private void menuFileOpen_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Opens a document and make its active");
			string strText = m_Settings.LocalizationTable.GetMessage("App202");
			if (strText == "")
				strText  = "Opens a document and make its active";
			UpdStatusBarInfo(strText);
 		}

		private void menuFileClose_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Closes the active document");
			string strText = m_Settings.LocalizationTable.GetMessage("App203");
			if (strText == "")
				strText  = "Closes the active document";
			UpdStatusBarInfo(strText);
  	    }

		private void menuFileSave_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Saves the active document");
			string strText = m_Settings.LocalizationTable.GetMessage("App204");
			if (strText == "")
				strText  = "Saves the active document";
			UpdStatusBarInfo(strText);
		}

		private void menuFileAs_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Saves the active document to another file name");
			string strText = m_Settings.LocalizationTable.GetMessage("App205");
			if (strText == "")
				strText  = "Saves the active document to another file name";
			UpdStatusBarInfo(strText);
        }

        private void menuFileProjNew_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Create a new project");
			string strText = m_Settings.LocalizationTable.GetMessage("App206");
			if (strText == "")
				strText  = "Create a new project";
			UpdStatusBarInfo(strText);
        }

        private void menuFileProjSelect_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Select an existing project from list - projects have a prj extension");
			string strText = m_Settings.LocalizationTable.GetMessage("App207");
			if (strText == "")
				strText  = "Select an existing project from list - projects have a prj extension";
			UpdStatusBarInfo(strText);
        }

        private void menuFileProjDelete_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Delete an existing project from list");
			string strText = m_Settings.LocalizationTable.GetMessage("App207A");
			if (strText == "")
				strText  = "Delete an existing project from list";
			UpdStatusBarInfo(strText);
        }

        private void menuFileProjExport_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Export/backup the current project to the Export subfolder");
			string strText = m_Settings.LocalizationTable.GetMessage("App208");
			if (strText == "")
				strText  = "Export/backup the current project to the Export subfolder";
			UpdStatusBarInfo(strText);
        }

        private void menuFileProjImport_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Import/restore a given project from a given folder");
			string strText = m_Settings.LocalizationTable.GetMessage("App209");
			if (strText == "")
				strText  = "Import/restore a given project from a given folder";
			UpdStatusBarInfo(strText);
        }

        private void menuFilePrint_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Prints the active document");
			string strText = m_Settings.LocalizationTable.GetMessage("App210");
			if (strText == "")
				strText  = "Prints the active document";
			UpdStatusBarInfo(strText);
        }

		private void menuFilePreview_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Displays the active document");
			string strText = m_Settings.LocalizationTable.GetMessage("App211");
			if (strText == "")
				strText  = "Displays the active document";
			UpdStatusBarInfo(strText);
        }

		private void menuFileSetup_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Set Paper size, orientation and margins");
			string strText = m_Settings.LocalizationTable.GetMessage("App212");
			if (strText == "")
				strText  = "Set Paper size, orientation and margins";
			UpdStatusBarInfo(strText);
        }

		private void menuExit_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Exit the application and save the option settings");
			string strText = m_Settings.LocalizationTable.GetMessage("App213");
			if (strText == "")
				strText  = "Exit the application and save the option settings";
			UpdStatusBarInfo(strText);
        }

		private void menuEditUndo_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Undo the last change made");
			string strText = m_Settings.LocalizationTable.GetMessage("App214");
			if (strText == "")
				strText  = "Undo the last change made";
			UpdStatusBarInfo(strText);
        }

		private void menuEditCut_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Move the selected text of the active document to the clipboard");
			string strText = m_Settings.LocalizationTable.GetMessage("App215");
			if (strText == "")
				strText  = "Move the selected text of the active document to the clipboard";
			UpdStatusBarInfo(strText);
        }

		private void menuEditCopy_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Copy the selected text of the active document to the clipboard");
			string strText = m_Settings.LocalizationTable.GetMessage("App216");
			if (strText == "")
				strText  = "Copy the selected text of the active document to the clipboard";
			UpdStatusBarInfo(strText);
        }

		private void menuEditPaste_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Copy the contents of the clipboard to the active document at the insertion point");
			string strText = m_Settings.LocalizationTable.GetMessage("App217");
			if (strText == "")
				strText  = "Copy the contents of the clipboard to the active document at the insertion point";
			UpdStatusBarInfo(strText);
        }

		private void menuEditSelect_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Select all of the contents of the active document");
			string strText = m_Settings.LocalizationTable.GetMessage("App218");
			if (strText == "")
				strText  = "Select all of the contents of the active document";
			UpdStatusBarInfo(strText);
        }

		private void menuEditClear_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Delete all the contents of the active document");
			string strText = m_Settings.LocalizationTable.GetMessage("App219");
			if (strText == "")
				strText  = "Delete all the contents of the active document";
			UpdStatusBarInfo(strText);
        }

		private void menuEditFind_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Find the first occurrence of a given text in the active document");
			string strText = m_Settings.LocalizationTable.GetMessage("App220");
			if (strText == "")
				strText  = "Find the first occurrence of a given text in the active document";
			UpdStatusBarInfo(strText);
        }

		private void menuEditNext_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Find the next occurrence of selected text in the active document");
			string strText = m_Settings.LocalizationTable.GetMessage("App221");
			if (strText == "")
				strText  = "Find the next occurrence of selected text in the active document";
			UpdStatusBarInfo(strText);
        }

		private void menuEditReplace_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Replace a given text with another given text in the active document");
			string strText = m_Settings.LocalizationTable.GetMessage("App222");
			if (strText == "")
				strText  = "Replace a given text with another given text in the active document";
			UpdStatusBarInfo(strText);
        }

		private void menuViewToolbar_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Display the toolbar or not");
			string strText = m_Settings.LocalizationTable.GetMessage("App223");
			if (strText == "")
				strText  = "Display the toolbar or not";
			UpdStatusBarInfo(strText);
        }

		private void menuViewStatus_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Display the status bar or not");
			string strText = m_Settings.LocalizationTable.GetMessage("App224");
			if (strText == "")
				strText  = "Display the status bar or not";
			UpdStatusBarInfo(strText);
        }

		private void menuViewMode_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Select whether you want search results and/or search definitions to be displayed");
			string strText = m_Settings.LocalizationTable.GetMessage("App225");
			if (strText == "")
				strText  = "Select whether you want search results and/or search definitions to be displayed";
			UpdStatusBarInfo(strText);
        }

		private void menuViewShow_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Show the search definitions of the processed searchs in active document");
			string strText = m_Settings.LocalizationTable.GetMessage("App226");
			if (strText == "")
				strText  = "Show the search definitions of the processed searchs in active document";
			UpdStatusBarInfo(strText);
        }

		private void menuViewHide_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Hide the search definitions of the processed searchs in active document");
			string strText = m_Settings.LocalizationTable.GetMessage("App227");
			if (strText == "")
				strText  = "Hide the search definitions of the processed searchs in active document";
			UpdStatusBarInfo(strText);
        }

		private void menuViewClear_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Clear the processed searchs (show only search definitions) in active document");
			string strText = m_Settings.LocalizationTable.GetMessage("App228");
			if (strText == "")
				strText  = "Clear the processed searchs (show only search definitions) in active document";
			UpdStatusBarInfo(strText);
        }

		private void menuViewUnprocessed_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Process the unprocessed searches in active document");
			string strText = m_Settings.LocalizationTable.GetMessage("App229");
			if (strText == "")
				strText  = "Process the unprocessed searches in active document";
			UpdStatusBarInfo(strText);
        }

		private void menuViewWordList_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Display all the words in the word list");
			string strText = m_Settings.LocalizationTable.GetMessage("App230");
			if (strText == "")
				strText  = "Display all the words in the word list";
			UpdStatusBarInfo(strText);
        }

		private void menuViewTextData_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Display the text data in paragraph format");
			string strText = m_Settings.LocalizationTable.GetMessage("App231");
			if (strText == "")
				strText  = "Display the text data in paragraph format";
			UpdStatusBarInfo(strText);
        }

        private void menuViewInventory_Select(object sender, EventArgs e)
		{
            //UpdStatusBarInfo("Display the lists of consonants, vowels and tones in the inventory");
			string strText = m_Settings.LocalizationTable.GetMessage("App232");
			if (strText == "")
				strText  = "Display the lists of consonants, vowels and tones in the inventory";
			UpdStatusBarInfo(strText);
        }

		private void menuViewPS_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Display a listing of all the parts of speech");
			string strText = m_Settings.LocalizationTable.GetMessage("App233");
			if (strText == "")
				strText  = "Display a listing of all the parts of speech";
			UpdStatusBarInfo(strText);
        }

		private void menuViewSite_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Display a listing of all the sight words");
			string strText = m_Settings.LocalizationTable.GetMessage("App234");
			if (strText == "")
				strText  = "Display a listing of all the sight words";
			UpdStatusBarInfo(strText);
        }

        private void menuViewGraphemes_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Display a listing of all the taught graphemes");
			string strText = m_Settings.LocalizationTable.GetMessage("App235");
			if (strText == "")
				strText  = "Display a listing of all the taught graphemes";
			UpdStatusBarInfo(strText);
        }

        private void menuFormatFont_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Choose the font for the selected text in the active document");
			string strText = m_Settings.LocalizationTable.GetMessage("App236");
			if (strText == "")
				strText  = "Choose the font for the selected text in the active document";
			UpdStatusBarInfo(strText);
        }

		private void menuFormatColor_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Choose the color for the selected text in the active document");
			string strText = m_Settings.LocalizationTable.GetMessage("App237");
			if (strText == "")
				strText  = "Choose the color for the selected text in the active document";
			UpdStatusBarInfo(strText);
        }

		private void menuFormatWrap_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Toggle Word Wrap for the active document");
			string strText = m_Settings.LocalizationTable.GetMessage("App238");
			if (strText == "")
				strText  = "Toggle Word Wrap for the active document";
			UpdStatusBarInfo(strText);
        }

        private void menuReportVowel_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Generate the Vowel Report in the active document");
			string strText = m_Settings.LocalizationTable.GetMessage("App239");
			if (strText == "")
				strText  = "Generate the Vowel Report in the active document";
			UpdStatusBarInfo(strText);
        }
        
        private void menuReportConsonant_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Generate the Consonant Report in the active document");
			string strText = m_Settings.LocalizationTable.GetMessage("App240");
			if (strText == "")
				strText  = "Generate the Consonant Report in the active document";
			UpdStatusBarInfo(strText);
        }

        private void menuReportPrimer_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Generate the Primer Progression Report in the active document");
			string strText = m_Settings.LocalizationTable.GetMessage("App241");
			if (strText == "")
				strText  = "Generate the Primer Progression Report in the active document";
			UpdStatusBarInfo(strText);
        }

        private void menuReportGenerate_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Generate a report in the active document from a given report template");
			string strText = m_Settings.LocalizationTable.GetMessage("App242");
			if (strText == "")
				strText  = "Generate a report in the active document from a given report template";
			UpdStatusBarInfo(strText);
        }

		private void menuReportEdit_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Edit a given report template in the active document");
			string strText = m_Settings.LocalizationTable.GetMessage("App243");
			if (strText == "")
				strText  = "Edit a given report template in the active document";
			UpdStatusBarInfo(strText);
        }

		private void menuSearchWordGrapheme_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Execute a grapheme search on the current word list");
			string strText = m_Settings.LocalizationTable.GetMessage("App244");
			if (strText == "")
				strText  = "Execute a grapheme search on the current word list";
			UpdStatusBarInfo(strText);
        }

        private void menuSearchWordFrequency_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Execute a frequency count search on the current word list");
			string strText = m_Settings.LocalizationTable.GetMessage("App245");
			if (strText == "")
				strText  = "Execute a frequency count search on the current word list";
			UpdStatusBarInfo(strText);
        }

        private void menuSearchWordBuild_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Execute a buildable word search on the current word list");
			string strText = m_Settings.LocalizationTable.GetMessage("App246");
			if (strText == "")
				strText  = "Execute a buildable word search on the current word list";
			UpdStatusBarInfo(strText);
        }

		private void menuSearchWordAdvanced_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Execute an advanced grapheme search on the current word list");
			string strText = m_Settings.LocalizationTable.GetMessage("App247");
			if (strText == "")
				strText  = "Execute an advanced grapheme search on the current word list";
			UpdStatusBarInfo(strText);
        }

        private void menuSearchWordPairs_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Execute a minimal pair search on the current word list");
			string strText = m_Settings.LocalizationTable.GetMessage("App248");
			if (strText == "")
				strText  = "Execute a minimal pair search on the current word list";
			UpdStatusBarInfo(strText);
        }

        private void menuSearchWordCoccur_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Execute a co-occurrence search on the current word list");
			string strText = m_Settings.LocalizationTable.GetMessage("App249");
			if (strText == "")
				strText  = "Execute a co-occurrence search on the current word list";
			UpdStatusBarInfo(strText);
        }

		private void menuSearchWordContext_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Execute a context occurrence chart search on the current word list");
			string strText = m_Settings.LocalizationTable.GetMessage("App250");
			if (strText == "")
				strText  = "Execute a context occurrence chart search on the current word list";
			UpdStatusBarInfo(strText);
        }

		private void menuSearchWordSyllable_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Execute a syllable chart search on the current word list");
			string strText = m_Settings.LocalizationTable.GetMessage("App251");
			if (strText == "")
				strText  = "Execute a syllable chart search on the current word list";
			UpdStatusBarInfo(strText);
        }

        private void menuSearchWordTone_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Execute a tone search on the current word list");
			string strText = m_Settings.LocalizationTable.GetMessage("App252");
			if (strText == "")
				strText  = "Execute a tone search on the current word list";
			UpdStatusBarInfo(strText);
        }

        private void menuSearchWordSyllograph_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Execute a syllograph search on the current word list");
			string strText = m_Settings.LocalizationTable.GetMessage("App252A");
			if (strText == "")
				strText  = "Execute a syllograph search on the current word list";
			UpdStatusBarInfo(strText);
        }

        private void menuSearchWordOrder_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Execute a Teaching Order search on the current word list");
			string strText = m_Settings.LocalizationTable.GetMessage("App253");
			if (strText == "")
				strText  = "Execute a Teaching Order search on the current word list";
			UpdStatusBarInfo(strText);
        }

        private void menuSearchWordGeneral_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Execute a General search on the current word list");
			string strText = m_Settings.LocalizationTable.GetMessage("App254");
			if (strText == "")
				strText  = "Execute a General search on the current word list";
			UpdStatusBarInfo(strText);
        }

        private void menuSearchTextGrapheme_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Execute a grapheme search on the current text data");
			string strText = m_Settings.LocalizationTable.GetMessage("App255");
			if (strText == "")
				strText  = "Execute a grapheme search on the current text data";
			UpdStatusBarInfo(strText);
        }

        private void menuSearchTextFrequency_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Execute a frequency count search on the current text data");
			string strText = m_Settings.LocalizationTable.GetMessage("App256");
			if (strText == "")
				strText  = "Execute a frequency count search on the current text data";
			UpdStatusBarInfo(strText);
        }

        private void menuSearchTextWord_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Execute a word/root search on the current text data");
			string strText = m_Settings.LocalizationTable.GetMessage("App257");
			if (strText == "")
				strText  = "Execute a word/root search on the current text data";
			UpdStatusBarInfo(strText);
        }

        private void menuSearchTextCount_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Execute a word count search on the current text data");
			string strText = m_Settings.LocalizationTable.GetMessage("App258");
			if (strText == "")
				strText  = "Execute a word count search on the current text data";
			UpdStatusBarInfo(strText);
        }

        private void menuSearchTextSyllable_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Execute a syllable count search on the current text data");
			string strText = m_Settings.LocalizationTable.GetMessage("App259");
			if (strText == "")
				strText  = "Execute a syllable count search on the current text data";
			UpdStatusBarInfo(strText);
        }

        private void menuSearchTextPhrases_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Execute a usable phrases search on the current text data");
			string strText = m_Settings.LocalizationTable.GetMessage("App260");
			if (strText == "")
				strText  = "Execute a usable phrases search on the current text data";
			UpdStatusBarInfo(strText);
        }

		private void menuSearchTextResidue_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Execute a untaught residue search on the current text data");
			string strText = m_Settings.LocalizationTable.GetMessage("App261");
			if (strText == "")
				strText  = "Execute a untaught residue search on the current text data";
			UpdStatusBarInfo(strText);
        }

		private void menuSearchTextSight_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Execute a sight word search on the current text data");
			string strText = m_Settings.LocalizationTable.GetMessage("App262");
			if (strText == "")
				strText  = "Execute a sight word search on the current text data";
			UpdStatusBarInfo(strText);
        }

        private void menuSearchTextBuilt_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Execute a built word search on the current text data");
			string strText = m_Settings.LocalizationTable.GetMessage("App263");
			if (strText == "")
				strText  = "Execute a built word search on the current text data";
			UpdStatusBarInfo(strText);
        }

        private void menuSearchTextNew_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Execute a new word search on the current text data");
			string strText = m_Settings.LocalizationTable.GetMessage("App264");
			if (strText == "")
				strText  = "Execute a new word search on the current text data";
			UpdStatusBarInfo(strText);
        }

        private void menuSearchTextTone_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Execute a tone search on the current text data");
			string strText = m_Settings.LocalizationTable.GetMessage("App265");
			if (strText == "")
				strText  = "Execute a tone search on the current text data";
			UpdStatusBarInfo(strText);
        }

        private void menuSearchTextSyllograph_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Execute a syllograph search on the current text data");
			string strText = m_Settings.LocalizationTable.GetMessage("App265A");
			if (strText == "")
				strText  = "Execute a syllograph search on the current text data";
			UpdStatusBarInfo(strText);
        }

        private void menuSearchTextOrder_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Execute a Teaching Order search on the current text data");
			string strText = m_Settings.LocalizationTable.GetMessage("App266");
			if (strText == "")
				strText  = "Execute a Teaching Order search on the current text data";
			UpdStatusBarInfo(strText);
        }

        private void menuSearchTextGeneral_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Execute a General search on the current text data");
			string strText = m_Settings.LocalizationTable.GetMessage("App266A");
			if (strText == "")
				strText  = "Execute a General search on the current text data";
			UpdStatusBarInfo(strText);
        }
        
        private void menuSearchVowel_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Execute a vowel chart search from the inventory");
			string strText = m_Settings.LocalizationTable.GetMessage("App267");
			if (strText == "")
				strText  = "Execute a vowel chart search from the inventory";
			UpdStatusBarInfo(strText);
        }

		private void menuSearchConsonant_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Execute a consonant chart search from the inventory");
			string strText = m_Settings.LocalizationTable.GetMessage("App268");
			if (strText == "")
				strText  = "Execute a consonant chart search from the inventory";
			UpdStatusBarInfo(strText);
        }

		private void menuSearchTone_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Execute a Tone chart search from the inventory");
			string strText = m_Settings.LocalizationTable.GetMessage("App269");
			if (strText == "")
				strText  = "Execute a Tone chart search from the inventory";
			UpdStatusBarInfo(strText);
        }

        private void menuSearchSyllograph_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Execute a Syllograph chart search from the inventory");
			string strText = m_Settings.LocalizationTable.GetMessage("App269A");
			if (strText == "")
				strText  = "Execute a Syllograph chart search from the inventory";
			UpdStatusBarInfo(strText);
        }

        private void menuToolsWordImportSF_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Import a standard format file as the current word list");
			string strText = m_Settings.LocalizationTable.GetMessage("App270");
			if (strText == "")
				strText  = "Import a standard format file as the current word list";
			UpdStatusBarInfo(strText);
        }

        private void menuToolsWordImportLIFT_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Import a LIFT file as the current word list");
			string strText = m_Settings.LocalizationTable.GetMessage("App271");
			if (strText == "")
				strText  = "Import a LIFT file as the current word list";
			UpdStatusBarInfo(strText);
        }

        private void menuToolsWordMerge_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Merge a standard format file with the current word list");
			string strText = m_Settings.LocalizationTable.GetMessage("App272");
			if (strText == "")
				strText  = "Merge a standard format file with the current word list";
			UpdStatusBarInfo(strText);
        }

		private void menuToolsWordExport_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Export the current word list as a standard format file");
			string strText = m_Settings.LocalizationTable.GetMessage("App273");
			if (strText == "")
				strText  = "Export the current word list as a standard format file";
			UpdStatusBarInfo(strText);
        }

        private void menuToolsWordReimport_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Reimport the current word list file");
			string strText = m_Settings.LocalizationTable.GetMessage("App274");
			if (strText == "")
				strText  = "Reimport the current word list file";
			UpdStatusBarInfo(strText);
        }

        private void menuToolsWordUnload_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Unload the current word list from the application");
			string strText = m_Settings.LocalizationTable.GetMessage("App275");
			if (strText == "")
				strText  = "Unload the current word list from the application";
			UpdStatusBarInfo(strText);
        }

        private void menuToolsWordCheck_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Check the current word list for graphemes not in the inventory");
			string strText = m_Settings.LocalizationTable.GetMessage("App276");
			if (strText == "")
				strText  = "Check the current word list for graphemes not in the inventory";
			UpdStatusBarInfo(strText);
        }

		private void menuToolsTextImport_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Import a plain text file as the current text data");
			string strText = m_Settings.LocalizationTable.GetMessage("App277");
			if (strText == "")
				strText  = "Import a plain text file as the current text data";
			UpdStatusBarInfo(strText);
        }

		private void menuToolsTextMerge_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Merge a plain text file with the current text data");
			string strText = m_Settings.LocalizationTable.GetMessage("App278");
			if (strText == "")
				strText  = "Merge a plain text file with the current text data";
			UpdStatusBarInfo(strText);
        }

		private void menuToolsTextExport_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Export the current text data as a plain text file");
			string strText = m_Settings.LocalizationTable.GetMessage("App279");
			if (strText == "")
				strText  = "Export the current text data as a plain text file";
			UpdStatusBarInfo(strText);
        }

        private void menuToolsTextReimport_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Reimport the current text data file");
			string strText = m_Settings.LocalizationTable.GetMessage("App280");
			if (strText == "")
				strText  = "Reimport the current text data file";
			UpdStatusBarInfo(strText);
        }

        private void menuToolsTextUnload_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Unload the current text data from the application");
			string strText = m_Settings.LocalizationTable.GetMessage("App281");
			if (strText == "")
				strText  = "Unload the current text data from the application";
			UpdStatusBarInfo(strText);
        }

        private void menuToolsTextCheckGI_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Check the current text data for graphemes not in the inventory");
			string strText = m_Settings.LocalizationTable.GetMessage("App282");
			if (strText == "")
				strText  = "Check the current text data for graphemes not in the inventory";
			UpdStatusBarInfo(strText);
        }

		private void menuToolsTextCheckWL_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Check the current text data for words not in the current word list");
			string strText = m_Settings.LocalizationTable.GetMessage("App283");
			if (strText == "")
				strText  = "Check the current text data for words not in the current word list";
			UpdStatusBarInfo(strText);
        }

        private void menuToolsTextBuildWL_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Build standard format file as word list from words in current text data");
			string strText = m_Settings.LocalizationTable.GetMessage("App284");
			if (strText == "")
				strText  = "Build standard format file as word list from words in current text data";
			UpdStatusBarInfo(strText);
        }

        private void menuToolsInventoryInitWL_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Initialize the grapheme inventory from a word list");
			string strText = m_Settings.LocalizationTable.GetMessage("App285");
			if (strText == "")
				strText  = "Initialize the grapheme inventory from a word list";
			UpdStatusBarInfo(strText);
        }

        private void menuToolsInventoryInitTD_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Initialize the grapheme inventory from a text data");
			string strText = m_Settings.LocalizationTable.GetMessage("App285A");
			if (strText == "")
				strText  = "Initialize the grapheme inventory from a text data";
			UpdStatusBarInfo(strText);
        }

        private void menuToolsInventoryInitPG_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Initialize the grapheme inventory from predefined graphemest");
			string strText = m_Settings.LocalizationTable.GetMessage("App286A");
			if (strText == "")
				strText  = "Initialize the grapheme inventory from predefined graphemest";
			UpdStatusBarInfo(strText);
        }

        private void menuToolsInventorySyllabary_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Initialize the grapheme inventory for syllographs");
			string strText = m_Settings.LocalizationTable.GetMessage("App287A");
			if (strText == "")
				strText  = "Initialize the grapheme inventory for syllographs";
			UpdStatusBarInfo(strText);
        }
        
        private void menuToolsInventoryConsonants_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Add, update or delete consonants in the grapheme inventory");
			string strText = m_Settings.LocalizationTable.GetMessage("App286");
			if (strText == "")
				strText  = "Add, update or delete consonants in the grapheme inventory";
			UpdStatusBarInfo(strText);
        }

		private void menuToolsInventoryVowels_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Add, update or delete vowels in the grapheme inventory");
			string strText = m_Settings.LocalizationTable.GetMessage("App287");
			if (strText == "")
				strText  = "Add, update or delete vowels in the grapheme inventory";
			UpdStatusBarInfo(strText);
        }

        private void menuToolsInventoryTone_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Add, update or delete tones in the grapheme inventory");
			string strText = m_Settings.LocalizationTable.GetMessage("App288");
			if (strText == "")
				strText  = "Add, update or delete tones in the grapheme inventory";
			UpdStatusBarInfo(strText);
        }

        private void menuToolsInventorySyllograph_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Add, update or delete syllographs in the grapheme inventory");
			string strText = m_Settings.LocalizationTable.GetMessage("App288A");
			if (strText == "")
				strText  = "Add, update or delete syllographs in the grapheme inventory";
			UpdStatusBarInfo(strText);
        }
        
        private void menuToolsInventorySave_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Save the grapheme inventory to a XML file");
			string strText = m_Settings.LocalizationTable.GetMessage("App289");
			if (strText == "")
				strText  = "Save the grapheme inventory to a XML file";
			UpdStatusBarInfo(strText);
        }

        private void menuToolsInventoryClear_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Deleta all the graphemes from the inventory");
			string strText = m_Settings.LocalizationTable.GetMessage("App290");
			if (strText == "")
				strText  = "Deleta all the graphemes from the inventory";
			UpdStatusBarInfo(strText);
        }

        private void menuToolsPartsInit_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Initialize Parts of Speech to default");
			string strText = m_Settings.LocalizationTable.GetMessage("App291");
			if (strText == "")
				strText  = "Initialize Parts of Speech to default";
			UpdStatusBarInfo(strText);
        }

        private void menuToolsPartsUpdate_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Add, update or delete parts of speechs");
			string strText = m_Settings.LocalizationTable.GetMessage("App292");
			if (strText == "")
				strText  = "Add, update or delete parts of speechs";
			UpdStatusBarInfo(strText);
        }

        private void menuToolsPartsSave_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Save the Parts of Speech list to a XML file");
			string strText = m_Settings.LocalizationTable.GetMessage("App293");
			if (strText == "")
				strText  = "Save the Parts of Speech list to a XML file";
			UpdStatusBarInfo(strText);
        }

        private void menuToolsSightUpdate_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Add or delete words in the sight word list");
			string strText = m_Settings.LocalizationTable.GetMessage("App294");
			if (strText == "")
				strText  = "Add or delete words in the sight word list";
			UpdStatusBarInfo(strText);
        }

        private void menuToolsSightSave_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Save the sight word list to a XML file");
			string strText = m_Settings.LocalizationTable.GetMessage("App295");
			if (strText == "")
				strText  = "Save the sight word list to a XML file";
			UpdStatusBarInfo(strText);
        }

        private void menuToolsSightCheckWL_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Check the sight word list for words not in the current word list");
			string strText = m_Settings.LocalizationTable.GetMessage("App296");
			if (strText == "")
				strText  = "Check the sight word list for words not in the current word list";
			UpdStatusBarInfo(strText);
        }

        private void menuToolsOrderUpdate_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Add or delete graphemes in the grapheme taught order list");
			string strText = m_Settings.LocalizationTable.GetMessage("App297");
			if (strText == "")
				strText  = "Add or delete graphemes in the grapheme taught order list";
			UpdStatusBarInfo(strText);
        }

        private void menuToolsOrderSave_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Save grapheme taught order list to a XML file");
			string strText = m_Settings.LocalizationTable.GetMessage("App298");
			if (strText == "")
				strText  = "Save grapheme taught order list to a XML file";
			UpdStatusBarInfo(strText);
        }

        private void menuToolsOrderCheck_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Check the grapheme taught order list for graphemes not in the current inventory");
			string strText = m_Settings.LocalizationTable.GetMessage("App299");
			if (strText == "")
				strText  = "Check the grapheme taught order list for graphemes not in the current inventory";
			UpdStatusBarInfo(strText);
        }

        private void menuToolsOptions_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Update the options settings for the application");
			string strText = m_Settings.LocalizationTable.GetMessage("App300");
			if (strText == "")
				strText  = "Update the options settings for the application";
			UpdStatusBarInfo(strText);
        }

		private void menuWindowCascade_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Redisplay all the windows of the application as cascading");
			string strText = m_Settings.LocalizationTable.GetMessage("App301");
			if (strText == "")
				strText  = "Redisplay all the windows of the application as cascading";
			UpdStatusBarInfo(strText);
        }

		private void menuWindowTileH_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Redisplay all the windows of the application as horizontal tiles");
			string strText = m_Settings.LocalizationTable.GetMessage("App302");
			if (strText == "")
				strText  = "Redisplay all the windows of the application as horizontal tiles";
			UpdStatusBarInfo(strText);
        }

		private void menuWindowTileV_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Redisplay all the windows of the application as vertical tiles");
            string strText = m_Settings.LocalizationTable.GetMessage("App303");
            if (strText == "")
                strText = "Redisplay all the windows of the application as vertical tiles";
            UpdStatusBarInfo(strText);
        }

		private void menuHelpHelp_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Display the help facility");
            string strText = m_Settings.LocalizationTable.GetMessage("App304");
            if (strText == "")
                strText = "Display the help facility";
            UpdStatusBarInfo(strText);
        }

        private void menuHelpSetup_Select(object sender, EventArgs e)
        {
            UpdStatusBarInfo("Display the setup tutorial (pdf file)");
        }

        private void menuHelpPrimer_Select(object sender, EventArgs e)
        {
            UpdStatusBarInfo("Display the primer making tutorial (pdf file)");
        }

        private void menuHelpNew_Select(object sender, EventArgs e)
        {
            UpdStatusBarInfo("Display What's New in this version (pdf file)");
        }

        private void menuHelpAbout_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Display version, date and copyright of application");
            string strText = "";
            strText = m_Settings.LocalizationTable.GetMessage("App305");
            if (strText == "")
                strText = "Display version, date and copyright of application";
            UpdStatusBarInfo(strText);
        }

        // Control events
        private void tbApp_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (e.Button == this.tbbNew)
			{
				this.menuFileNew_Click(sender, e);
			}
			else if (e.Button == this.tbbOpen)
			{
				this.menuFileOpen_Click(sender, e);
			}
			else if (e.Button == this.tbbSave)
			{
				this.menuFileSave_Click(sender, e);
			}
			else if (e.Button == this.tbbPreview)
			{
				this.menuFilePreview_Click(sender, e);
			}
			else if (e.Button == this.tbbPrint)
			{
				this.menuFilePrint_Click(sender, e);
			}
			else if (e.Button == this.tbbCut)
			{
				this.menuEditCut_Click(sender, e);
			}
			else if (e.Button == this.tbbCopy)
			{
				this.menuEditCopy_Click(sender, e);
			}
			else if (e.Button == this.tbbPaste)
			{
				this.menuEditPaste_Click(sender, e);
			}
			else if (e.Button == this.tbbFind)
			{
				this.menuEditFind_Click(sender, e);
			}
			else if (e.Button == this.tbbOptions)
			{
				this.menuToolsOptions_Click(sender, e);
			}
			else if (e.Button == this.tbbHelp)
			{
				this.menuHelpHelp_Click(sender, e);
			}
		}
  
		// Accessors
        public ProjectInfo ProjInfo
        {
            get { return m_ProjInfo; }
            set { m_ProjInfo = value; }
        }

        public Settings Settings
		{
			get {return m_Settings;}
			set {m_Settings = value;}
		}

		public ArrayList SearchList
		{
			get {return m_SearchList;}
		}

		public int SearchCntr
		{
			get {return m_SearchCntr;}
			set {m_SearchCntr = value;}
		}

		public string PSTFileName
		{
			get {return m_PSTFileName;}
		}

		public StatusStrip PPStatusBar
		{
			get{return this.ssApp;}
		}

		public MenuItem mnFormatWrap
		{
			get {return menuFormatWrap;}
			set	{menuFormatWrap = value;}
		}

		// Others

        public void InitGraphemeInventoryWL(bool fClearGraphemeInventory)
        {
            string strFileName = m_Settings.GraphemeInventory.FileName;
            string strText = "";
            GraphemeInventory gi = null;
            if (fClearGraphemeInventory)
                gi = new GraphemeInventory(m_Settings);
            else gi = m_Settings.GraphemeInventory;

            // get sorted list of graphemes from given word list
            {
                FormInitGraphemeInventoryWL form = new FormInitGraphemeInventoryWL(m_Settings, gi);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    gi = form.GraphemeInventory;
                    if (gi != null)
                    {
                        m_Settings.GraphemeInventory = gi;
                        gi.SaveToFile(gi.FileName);
                        //MessageBox.Show("Since the graphene inventory has been updated, you need to reimport the word list and text data.");
                        strText = m_Settings.LocalizationTable.GetMessage("App131");
                        if (strText == "")
                            strText = "Since the graphene inventory has been updated, you need to reimport the word list and text data.";
                        MessageBox.Show(strText);
                    }
                }
                else
                {
                    //MessageBox.Show("Initialization cancelled");
                    strText = m_Settings.LocalizationTable.GetMessage("App130");
                    if (strText == "")
                        strText = "Initialization cancelled";
                    MessageBox.Show(strText);
                }
            }
         }

        public void InitGraphemeInventoryTD(bool fClearGraphemeInventory)
        {
            string strText = "";
            string strFileName = m_Settings.GraphemeInventory.FileName;
            GraphemeInventory gi = null;
            if (fClearGraphemeInventory)
                gi = new GraphemeInventory(m_Settings);
            else gi = m_Settings.GraphemeInventory;

            // get sorted list of graphemes from given text data
            {
                FormInitGraphemeInventoryTD form = new FormInitGraphemeInventoryTD(m_Settings, gi);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    gi = form.GraphemeInventory;
                    if (gi != null)
                    {
                        m_Settings.GraphemeInventory = gi;
                        gi.SaveToFile(gi.FileName);
                        //MessageBox.Show("Since the graphene inventory has been initialized, you need to reimport the word list and text data.");
                        strText = m_Settings.LocalizationTable.GetMessage("App131");
                        if (strText == "")
                            strText = "Since the graphene inventory has been initialized, you need to reimport the word list and text data.";
                        MessageBox.Show(strText);
                    }
                }
                else
                {
                    //MessageBox.Show("Initialization cancelled");
                    strText = m_Settings.LocalizationTable.GetMessage("App130");
                    if (strText == "")
                        strText = "Initialization cancelled";
                    MessageBox.Show(strText);
                }
            }
        }

        public void InitGraphemeInventoryPG()
        {
            string strText = "";
            string strFileName = m_Settings.GetAppFolder() + AppWindow.kBackSlash +
                 AppWindow.kDefaultGIName;
            GraphemeInventory gi = new GraphemeInventory(m_Settings);
            if (gi.InitializeGraphemeInventoryFromPredefinedGraphemes(strFileName))
            {
                m_Settings.GraphemeInventory = gi;
                gi.SaveToFile(m_Settings.OptionSettings.GraphemeInventoryFile);
                //MessageBox.Show("Grapheme Inventory has been initialized");
                strText = m_Settings.LocalizationTable.GetMessage("FormNewProject2");
                if (strText == "")
                    strText = "Grapheme Inventory has been initialized";
                MessageBox.Show(strText);
            }
            else
            {
                //MessageBox.Show("Grapheme Inventory was not initialized");
                strText = m_Settings.LocalizationTable.GetMessage("FormNewProject1");
                if (strText == "")
                    strText = "Grapheme Inventory was not initialized";
                MessageBox.Show(strText);
            }
        }

        public void InitGraphemeInventorySyllabary(bool fClearGraphemeInventory)
        {
            string strFileName = m_Settings.GraphemeInventory.FileName;
            string strText = "";
            GraphemeInventory gi = null;
            if (fClearGraphemeInventory)
                gi = new GraphemeInventory(m_Settings);
            else gi = m_Settings.GraphemeInventory;

            // get sorted list of graphemes
            FormNewSyllabary form = new FormNewSyllabary(m_Settings, gi);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                m_Settings.GraphemeInventory = form.GI;
                m_Settings.GraphemeInventory.FileName = strFileName;
                m_Settings.GraphemeInventory.SaveToFile(m_Settings.GraphemeInventory.FileName);
                //MessageBox.Show("Syllograph Inventory has been initialized.");
                strText = m_Settings.LocalizationTable.GetMessage("App306");
                if (strText == "")
                    strText = "Syllograph Inventory has been initialized";
                MessageBox.Show(strText);
            }
            //else MessageBox.Show("Syllograph Inventory was not initialized");
            else
            {
                strText = m_Settings.LocalizationTable.GetMessage("App307");
                if (strText == "")
                    strText = "Syllograph Inventory was not initialized";
                MessageBox.Show(strText);
            }
            form.Close();
        }
        
        public void SetupProject()
        {
            //First close all ActiveControl documents
            AppView mdiChild = (AppView)this.ActiveMdiChild;
            while (mdiChild != null)
            {
                CloseActiveDocument();
                mdiChild = (AppView)this.ActiveMdiChild;
            }
                        
            m_ViewCntr = 0;					    //Window (active document) counter
			m_SearchCntr = 0;				    //Search counter 
			m_SearchList = new ArrayList();	    //List of active searches
            
            m_Settings = new Settings(m_ProjInfo);	    //App Settings
            m_Settings.LocalizationTable = this.GetLocalizationTable();
            m_Settings.LoadOptions();
            m_Settings.LoadGraphemeInventory();
            if (!m_Settings.LoadPartsOfSpeech())
            {
                string strFileName = m_Settings.GetAppFolder() + AppWindow.kBackSlash +
                    AppWindow.kDefaultPSTableName;
                PSTable pst = new PSTable(m_Settings);
                pst.LoadFromFile(strFileName);
            }             
            m_PSTFileName = this.Settings.OptionSettings.PSTableFile;  //Filename for Parts of Speech
            m_Settings.LoadSightWords();
            m_Settings.LoadGraphemesTaught();

            m_Settings.LoadWordList();
            m_Settings.LoadTextData();

            // Setup new appview for selected project. otherwise it may use the appview for previous project
            mdiChild = new AppView(pWindow, "");
            m_ViewCntr++;
            mdiChild.Text = strApp + m_ViewCntr.ToString();
            mdiChild.MdiParent = this;
            mdiChild.Show();
            this.LayoutMdi(MdiLayout.Cascade);
        }

        public void SaveProject()
        {
            //FormProgressBar fpb = new FormProgressBar("...Exiting PrimerPro");
            string strMsg = m_Settings.LocalizationTable.GetMessage("App106");
            if (strMsg == "")
                strMsg = "...Exiting PrimerPro";
            FormProgressBar form = new FormProgressBar(strMsg);
            form.PB_Init(0, 7);
            string strFileName = "";

            if (m_Settings != null)
            {
                if (m_Settings.OptionSettings != null)
                {
                    //form.Text = "Saving Word List";
                    strMsg = m_Settings.LocalizationTable.GetMessage("App107");
                    if (strMsg == "")
                        strMsg = "Saving Word List";
                    form.Text = strMsg;
                    form.PB_Update(0);
                    if (m_Settings.OptionSettings.WordListFile == WordList.kMergeWordList)
                    {
                        strMsg = m_Settings.LocalizationTable.GetMessage("App73");
                        if (strMsg == "")
                            strMsg = "Do you want to save the merged word list?";
                        if (MessageBox.Show(strMsg, "", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            WordList wl = this.Settings.WordList;
                            if (wl.SaveAs(this.Settings.OptionSettings.DataFolder))
                            {
                                this.Settings.WordList = wl;
                                this.Settings.OptionSettings.WordListFile = wl.SFFile.FileName;
                                this.Settings.OptionSettings.WordListFileType = wl.Type;
                                //MessageBox.Show("Current Word List saved");
                                strMsg = m_Settings.LocalizationTable.GetMessage("App74");
                                if (strMsg == "")
                                    MessageBox.Show("Current Word List saved");
                                MessageBox.Show(strMsg);
                            }
                            //else MessageBox.Show("Current Word List not saved");
                            else
                            {
                                strMsg = m_Settings.LocalizationTable.GetMessage("App75");
                                if (strMsg == "")
                                    MessageBox.Show("Current Word List not saved");
                                else MessageBox.Show(strMsg);
                            }
                        }
                    }

                    strMsg = m_Settings.LocalizationTable.GetMessage("App108");
                    if (strMsg == "")
                        form.Text = "Saving Text Data";
                    else form.Text = strMsg;
                    form.PB_Update(1);
                    if (m_Settings.OptionSettings.TextDataFile == TextData.kMergeTextData)
                    {
                        strMsg = m_Settings.LocalizationTable.GetMessage("App76");
                        if (strMsg == "")
                            strMsg = "Do you want to save the merged text data?";
                        if (MessageBox.Show(strMsg, "", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            TextData td = this.Settings.TextData;
                            if (td.Save(this.Settings.OptionSettings.DataFolder))
                            {
                                this.Settings.TextData = td;
                                this.Settings.OptionSettings.TextDataFile = td.FileName;
                                //MessageBox.Show("Current Text Data saved");
                                strMsg = m_Settings.LocalizationTable.GetMessage("App77");
                                if (strMsg == "")
                                    MessageBox.Show("Current Text Data saved");
                                MessageBox.Show(strMsg);
                            }
                            //else MessageBox.Show("Current Text Data not saved");
                            else
                            {
                                strMsg = m_Settings.LocalizationTable.GetMessage("App78");
                                if (strMsg == "")
                                    MessageBox.Show("Current Text Data not saved");
                                else MessageBox.Show(strMsg);

                            }
                        }
                    }

                    //Saving Options
                    strMsg = m_Settings.LocalizationTable.GetMessage("App109");
                    if (strMsg == "")
                        form.Text = "Saving Options";
                    else form.Text = strMsg;
                    form.PB_Update(2);
                    if (this.Settings.OptionSettings != null)
                    {
                        strFileName = this.ProjInfo.OptionsFile;
                        if (!File.Exists(strFileName))
                            strFileName = m_Settings.PrimerProFolder + Constants.Backslash +
                                m_Settings.ProjInfo.ProjectName + ".xml";
                        this.Settings.OptionSettings.SaveToFile(strFileName);		//Save options to xml file
                    }

                    //Saving Grapheme Inventory
                    strMsg= m_Settings.LocalizationTable.GetMessage("App110");
                    if (strMsg == "")
                        form.Text = "Saving Grapheme Inventory";
                    else form.Text = strMsg;
                    form.PB_Update(3);
                    if (this.Settings.GraphemeInventory != null)
                    {
                        strFileName = this.Settings.GraphemeInventory.FileName;
                        if (strFileName != "")
                            this.Settings.GraphemeInventory.SaveToFile(strFileName);  //Save grapheme inventory to xml file
                    }
                    
                    //Saving Parts of Speech
                    strMsg = m_Settings.LocalizationTable.GetMessage("App111");
                    if (strMsg == "")
                        form.Text  = "Saving Parts of Speech";
                    form.Text = strMsg;
                    form.PB_Update(4);
                    if (this.Settings.PSTable != null)
                    {
                        strFileName = this.Settings.PSTable.FileName;
                        if (strFileName != "")
                            this.Settings.PSTable.SaveToFile(strFileName);            //Save Parts of Speech to xml file
                    }

                    //Saving Sight Words
                    
                    strMsg = m_Settings.LocalizationTable.GetMessage("App112");
                    if (strMsg == "")
                        form.Text = "Saving Graphemes Taught";
                    else form.Text = strMsg ;
                    form.PB_Update(5);
                    if (this.Settings.SightWords != null)
                    {
                        strFileName = this.Settings.SightWords.FileName;
                        if (strFileName != "")
                            this.Settings.SightWords.SaveToFile(strFileName);			//Save sight words to xml file
                    }

                    //Saving Graphemes Taught
                    strMsg = m_Settings.LocalizationTable.GetMessage("App113");
                    if (strMsg == "")
                        form.Text = "Saving Graphemes Taught Order";
                    else form.Text = strMsg;
                    form.PB_Update(6);
                    if (this.Settings.GraphemesTaught != null)
                    {
                        strFileName = this.Settings.GraphemesTaught.FileName;
                        if (strFileName != "")
                            this.Settings.GraphemesTaught.SaveToFile(strFileName);    //Save graphemes taught to xml file;
                    }
                }
            }

            form.Close();
        }

        public void CloseActiveDocument()
        {
            AppView mdiChild = (AppView)this.ActiveMdiChild;
            if (mdiChild != null)
            {
                mdiChild.Close();
            }
            //else ;
            else
            {
                string strText = m_Settings.LocalizationTable.GetMessage("App4");
                if (strText == "")
                    MessageBox.Show("No active document to close");
                else MessageBox.Show(strText);
            }
        }

        public Search GetSearchFromSearchList(int sn)
        // sn = search number
		{
			Search search = null;
			for (int i = 0; i < SearchList.Count; i++)
			{
				search = (Search) SearchList[i];
				if (search.SearchNumber == sn)
					break;
				search = null;
			}
			return search;
		}

        private string GetSaveFileName()
        {
            string strFileName = "";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "txt files (*.txt)|*.txt|All Files (*.*)|*.*";
            sfd.FileName = strFileName;
            sfd.DefaultExt = "*.txt";
            sfd.InitialDirectory = Settings.OptionSettings.DataFolder;
            sfd.CheckPathExists = true;

            if (sfd.ShowDialog() == DialogResult.OK)
                strFileName = sfd.FileName;
            return strFileName;
        }

        public void UpdStatusBarWL()
        {
            string strText = m_Settings.LocalizationTable.GetMessage("App114");
            if (strText == "")
                strText = "WL:";
            if (this.Settings != null)
            {
                if (this.Settings.WordList != null)
                {
                    if (this.Settings.WordList.FileName == "")
                    {
                        if (m_Settings.LocalizationTable.GetMessage("App116") ==  "")
                            strText += "<none>";
                        else strText += m_Settings.LocalizationTable.GetMessage("App116");
                    }
                    else
                    {
                        if (this.Settings.WordList.FileName == WordList.kMergeWordList)
                            if (m_Settings.LocalizationTable.GetMessage("App117") == "")
                                strText += "<Merged Text Data>";
                            else strText += m_Settings.LocalizationTable.GetMessage("App117");
                        else strText += Funct.ShortFileName(this.Settings.WordList.FileName);
                    }
                }
               else strText += " none";
            }
            else strText += " none";
            this.tsslWordList.Text = strText;
            if (this.ssApp.Visible)
                this.ssApp.Show();
        }

        public void UpdStatusBarTD()
        {
            string strText = m_Settings.LocalizationTable.GetMessage("App115");
            if (strText == "")
                strText = "TD:";
            if (this.Settings != null)
            {
                if (this.Settings.TextData != null)
                {
                    if (this.Settings.TextData.FileName == "")
                    {
                        if (m_Settings.LocalizationTable.GetMessage("App116") ==  "")
                            strText += "<none>";
                        else strText += m_Settings.LocalizationTable.GetMessage("App116");
                    }
                    else
                    {
                        if (this.Settings.TextData.FileName == TextData.kMergeTextData)
                            if (m_Settings.LocalizationTable.GetMessage("App118") == "")
                                strText += "<Merged Text Data>";
                            else strText += m_Settings.LocalizationTable.GetMessage("App118");
                        else strText += Funct.ShortFileName(this.Settings.TextData.FileName);
                    }
                }
                else strText += " none";
            }
            else strText += " none";
            this.tsslTextData.Text = strText;
            if (this.ssApp.Visible)
                this.ssApp.Show();
        }

        public void UpdStatusBarWnd()
        {
            string strText = m_Settings.LocalizationTable.GetMessage("App116");
            if (strText == "")
                strText = "<none>";
            AppView mdiChild = (AppView)this.ActiveMdiChild;
            if (mdiChild != null)
                strText = mdiChild.Text;
            this.tsslWnd.Text = strText.Trim();
            if (this.ssApp.Visible)
                this.ssApp.Show();
        }

        public void UpdStatusBarInfo(string strInfo)
        {
            this.tsslInfo.Text = strInfo.Trim();
            if (this.ssApp.Visible)
                this.ssApp.Show();
        }

        //private void UpdateMenuForLanguage(string lang)
        //// lang = UI language
        //{
        //    LocalizationEntry entry = null;
        //    SortedList ml = m_Settings.LocalizationTable.MenuList;
        //    for (int i = 0; i < ml.Count; i++)
        //    {
        //        entry = (LocalizationEntry)ml.GetByIndex(i);
        //        switch (entry.Idn)
        //        {
        //            case "menuFile":
        //                this.menuFile.Text = m_Settings.LocalizationTable.GetMenu("menuFile");
        //                break;
        //            case "menuFileNew":
        //                this.menuFileNew.Text = m_Settings.LocalizationTable.GetMenu("menuFileNew");
        //                break;
        //            case "menuFileOpen":
        //                this.menuFileOpen.Text = m_Settings.LocalizationTable.GetMenu("menuFileOpen");
        //                break;
        //            case "menuFileClose":
        //                this.menuFileClose.Text = m_Settings.LocalizationTable.GetMenu("menuFileClose");
        //                break;
        //            case "menuFileSave":
        //                this.menuFileSave.Text = m_Settings.LocalizationTable.GetMenu("menuFileSave");
        //                break;
        //            case "menuFileAs":
        //                this.menuFileAs.Text = m_Settings.LocalizationTable.GetMenu("menuFileAs");
        //                break;
        //            case "menuFileProjNew":
        //                this.menuFileProjNew.Text = m_Settings.LocalizationTable.GetMenu("menuFileProjNew");
        //                break;
        //            case "menuFileProjSelect":
        //                this.menuFileProjSelect.Text = m_Settings.LocalizationTable.GetMenu("menuFileProjSelect");
        //                break;
        //            case "menuFileProjDelete":
        //                this.menuFileProjDelete.Text = m_Settings.LocalizationTable.GetMenu("menuFileProjDelete");
        //                break;
        //            case "menuFileProjExport":
        //                this.menuFileProjExport.Text = m_Settings.LocalizationTable.GetMenu("menuFileProjExport");
        //                break;
        //            case "menuFileProjImport":
        //                this.menuFileProjImport.Text = m_Settings.LocalizationTable.GetMenu("menuFileProjImport");
        //                break;
        //            case "menuFilePrint":
        //                this.menuFilePrint.Text = m_Settings.LocalizationTable.GetMenu("menuFilePrint");
        //                break;
        //            case "menuFilePreview":
        //                this.menuFilePreview.Text = m_Settings.LocalizationTable.GetMenu("menuFilePreview");
        //                break;
        //            case "menuFileSetup":
        //                this.menuFileSetup.Text = m_Settings.LocalizationTable.GetMenu("menuFileSetup");
        //                break;
        //            case "menuExit":
        //                this.menuExit.Text = m_Settings.LocalizationTable.GetMenu("menuExit");
        //                break;
        //            case "menuEdit":
        //                this.menuEdit.Text = m_Settings.LocalizationTable.GetMenu("menuEdit");
        //                break;
        //            case "menuEditUndo":
        //                this.menuEditUndo.Text = m_Settings.LocalizationTable.GetMenu("menuEditUndo");
        //                break;
        //            case "menuEditCut":
        //                this.menuEditCut.Text = m_Settings.LocalizationTable.GetMenu("menuEditCut");
        //                break;
        //            case "menuEditCopy":
        //                this.menuEditCopy.Text = m_Settings.LocalizationTable.GetMenu("menuEditCopy");
        //                break;
        //            case "menuEditPaste":
        //                this.menuEditPaste.Text = m_Settings.LocalizationTable.GetMenu("menuEditPaste");
        //                break;
        //            case "menuEditSelect":
        //                this.menuEditSelect.Text = m_Settings.LocalizationTable.GetMenu("menuEditSelect");
        //                break;
        //            case "menuEditClear":
        //                this.menuEditClear.Text = m_Settings.LocalizationTable.GetMenu("menuEditClear");
        //                break;
        //            case "menuEditFind":
        //                this.menuEditFind.Text = m_Settings.LocalizationTable.GetMenu("menuEditFind");
        //                break;
        //            case "menuEditNext":
        //                this.menuEditNext.Text = m_Settings.LocalizationTable.GetMenu("menuEditNext");
        //                break;
        //            case "menuEditReplace":
        //                this.menuEditReplace.Text  = m_Settings.LocalizationTable.GetMenu("menuEditReplace");
        //                break;
        //            case "menuView":
        //                this.menuView.Text = m_Settings.LocalizationTable.GetMenu("menuView");
        //                break;
        //            case "menuViewToolbar":
        //                this.menuViewToolbar.Text = m_Settings.LocalizationTable.GetMenu("menuViewToolbar");
        //                break;
        //            case "menuViewStatus":
        //                this.menuViewStatus.Text = m_Settings.LocalizationTable.GetMenu("menuViewStatus");
        //                break;
        //            case "menuViewMode":
        //                this.menuViewMode.Text = m_Settings.LocalizationTable.GetMenu("menuViewMode");
        //                break;
        //            case "menuViewShow":
        //                this.menuViewShow.Text = m_Settings.LocalizationTable.GetMenu("menuViewShow");
        //                break;
        //            case "menuViewHide":
        //                this.menuViewHide.Text = m_Settings.LocalizationTable.GetMenu("menuViewHide");
        //                break;
        //            case "menuViewClear":
        //                this.menuViewClear.Text = m_Settings.LocalizationTable.GetMenu("menuViewClear");
        //                break;
        //            case "menuViewUnprocessed":
        //                this.menuViewUnprocessed.Text  = m_Settings.LocalizationTable.GetMenu("menuViewUnprocessed");
        //                break;
        //            case "menuViewWordList":
        //                this.menuViewWordList.Text  = m_Settings.LocalizationTable.GetMenu("menuViewWordList");
        //                break;
        //            case "menuViewTextData":
        //                this.menuViewTextData.Text  = m_Settings.LocalizationTable.GetMenu("menuViewTextData");
        //                break;
        //            case "menuViewInventory":
        //                this.menuViewInventory.Text  = m_Settings.LocalizationTable.GetMenu("menuViewInventory");
        //                break;
        //            case "menuViewPS":
        //                this.menuViewPS.Text  = m_Settings.LocalizationTable.GetMenu("menuViewPS");
        //                break;
        //            case "menuViewSite":
        //                this.menuViewSite.Text  = m_Settings.LocalizationTable.GetMenu("menuViewSite");
        //                break;
        //            case "menuViewGraphemes":
        //                this.menuViewGraphemes.Text  = m_Settings.LocalizationTable.GetMenu("menuViewGraphemes");
        //                break;
        //            case "menuFormat":
        //                 this.menuFormat.Text  = m_Settings.LocalizationTable.GetMenu("menuFormat");
        //                break;
        //            case "menuFormatFont":
        //                 this.menuFormatFont.Text  = m_Settings.LocalizationTable.GetMenu("menuFormatFont");
        //                break;
        //            case "menuFormatColor":
        //                this.menuFormatColor.Text  = m_Settings.LocalizationTable.GetMenu("menuFormatColor");
        //                break;
        //            case "menuFormatWrap":
        //                this.menuFormatWrap.Text  = m_Settings.LocalizationTable.GetMenu("menuFormatWrap");
        //                break;
        //            case "menuReport":
        //                this.menuReport.Text = m_Settings.LocalizationTable.GetMenu("menuReport");
        //                break;
        //            case "menuReportVowel":
        //                this.menuReportVowel.Text = m_Settings.LocalizationTable.GetMenu("menuReportVowel");
        //                break;
        //            case "menuReportConsonant":
        //                this.menuReportConsonant.Text = m_Settings.LocalizationTable.GetMenu("menuReportConsonant");
        //                break;
        //            case "menuReportPrimer":
        //                this.menuReportPrimer.Text = m_Settings.LocalizationTable.GetMenu("menuReportPrimer");
        //                break;
        //            case "menuReportGenerate":
        //                this.menuReportGenerate.Text = m_Settings.LocalizationTable.GetMenu("menuReportGenerate");
        //                break;
        //            case "menuReportEdit":
        //                this.menuReportEdit.Text = m_Settings.LocalizationTable.GetMenu("menuReportEdit");
        //                break;
        //            case "menuSearch":
        //                this.menuSearch.Text = m_Settings.LocalizationTable.GetMenu("menuSearch");
        //                break;
        //            case "menuSearchWord":
        //                this.menuSearchWord.Text = m_Settings.LocalizationTable.GetMenu("menuSearchWord");
        //                break;
        //            case "menuSearchWordGrapheme":
        //                this.menuSearchWordGrapheme.Text = m_Settings.LocalizationTable.GetMenu("menuSearchWordGrapheme");
        //                break;
        //            case "menuSearchWordFrequency":
        //                this.menuSearchWordFrequency.Text = m_Settings.LocalizationTable.GetMenu("menuSearchWordFrequency");
        //                break;
        //            case "menuSearchWordBuild":
        //                this.menuSearchWordBuild.Text = m_Settings.LocalizationTable.GetMenu("menuSearchWordBuild");
        //                break;
        //            case "menuSearchWordAdvanced":
        //                this.menuSearchWordAdvanced.Text = m_Settings.LocalizationTable.GetMenu("menuSearchWordAdvanced");
        //                break;
        //            case "menuSearchWordPairs":
        //                this.menuSearchWordPairs.Text = m_Settings.LocalizationTable.GetMenu("menuSearchWordPairs");
        //                break;
        //            case "menuSearchWordCoccur":
        //                this.menuSearchWordCoccur.Text = m_Settings.LocalizationTable.GetMenu("menuSearchWordCoccur");
        //                break;
        //            case "menuSearchWordContext":
        //                this.menuSearchWordContext.Text = m_Settings.LocalizationTable.GetMenu("menuSearchWordContext");
        //                break;
        //            case "menuSearchWordSyllable":
        //                this.menuSearchWordSyllable.Text = m_Settings.LocalizationTable.GetMenu("menuSearchWordSyllable");
        //                break;
        //            case "menuSearchWordTone":
        //                this.menuSearchWordTone.Text = m_Settings.LocalizationTable.GetMenu("menuSearchWordTone");
        //                break;
        //            case "menuSearchWordSyllograph":
        //                this.menuSearchWordSyllograph.Text = m_Settings.LocalizationTable.GetMenu("menuSearchWordSyllograph");
        //                break;
        //            case "menuSearchWordOrder":
        //                this.menuSearchWordOrder.Text = m_Settings.LocalizationTable.GetMenu("menuSearchWordOrder");
        //                break;
        //            case "menuSearchWordGeneral":
        //                this.menuSearchWordGeneral.Text = m_Settings.LocalizationTable.GetMenu("menuSearchWordGeneral");
        //                break;
        //            case "menuSearchText":
        //                this.menuSearchText.Text = m_Settings.LocalizationTable.GetMenu("menuSearchText");
        //                break;
        //            case "menuSearchTextGrapheme":
        //                this.menuSearchTextGrapheme.Text = m_Settings.LocalizationTable.GetMenu("menuSearchTextGrapheme");
        //                break;
        //            case "menuSearchTextFrequency":
        //                this.menuSearchTextFrequency.Text = m_Settings.LocalizationTable.GetMenu("menuSearchTextFrequency");
        //                break;
        //            case "menuSearchTextBuilt":
        //                this.menuSearchTextBuild.Text = m_Settings.LocalizationTable.GetMenu("menuSearchTextBuilt");
        //                break;
        //            case "menuSearchTextPhrases":
        //                this.menuSearchTextPhrases.Text = m_Settings.LocalizationTable.GetMenu("menuSearchTextPhrases");
        //                break;
        //            case "menuSearchTextResidue":
        //                this.menuSearchTextResidue.Text = m_Settings.LocalizationTable.GetMenu("menuSearchTextResidue");
        //                break;
        //            case "menuSearchTextWord":
        //                this.menuSearchTextWord.Text = m_Settings.LocalizationTable.GetMenu("menuSearchTextWord");
        //                break;
        //            case "menuSearchTextCount":
        //                this.menuSearchTextCount.Text = m_Settings.LocalizationTable.GetMenu("menuSearchTextCount");
        //                break;
        //            case "menuSearchTextSyllable":
        //                this.menuSearchTextSyllable.Text  = m_Settings.LocalizationTable.GetMenu("menuSearchTextSyllable");
        //                break;
        //            case "menuSearchTextSight":
        //                this.menuSearchTextSight.Text = m_Settings.LocalizationTable.GetMenu("menuSearchTextSight");
        //                break;
        //            case "menuSearchTextNew":
        //                this.menuSearchTextNew.Text = m_Settings.LocalizationTable.GetMenu("menuSearchTextNew");
        //                break;
        //            case "menuSearchTextTone":
        //                this.menuSearchTextTone.Text = m_Settings.LocalizationTable.GetMenu("menuSearchTextTone");
        //                break;
        //            case "menuSearchTextSyllograph":
        //                this.menuSearchTextSyllograph.Text = m_Settings.LocalizationTable.GetMenu("menuSearchTextSyllograph");
        //                break;
        //            case "menuSearchTextOrder":
        //                this.menuSearchTextOrder.Text = m_Settings.LocalizationTable.GetMenu("menuSearchTextOrder");
        //                break;
        //            case "menuSearchTextGeneral":
        //                this.menuSearchTextGeneral.Text = m_Settings.LocalizationTable.GetMenu("menuSearchTextGeneral");
        //                break;
        //            case "menuSearchVowel":
        //                this.menuSearchVowel.Text = m_Settings.LocalizationTable.GetMenu("menuSearchVowel");
        //                break;
        //            case "menuSearchConsonant":
        //                this.menuSearchConsonant.Text = m_Settings.LocalizationTable.GetMenu("menuSearchConsonant");
        //                break;
        //            case "menuSearchTone":
        //                this.menuSearchTone.Text = m_Settings.LocalizationTable.GetMenu("menuSearchTone");
        //                break;
        //            case "menuSearchSyllograph":
        //                this.menuSearchSyllograph.Text = m_Settings.LocalizationTable.GetMenu("menuSearchSyllograph");
        //                break;
        //            case "menuTools":
        //                this.menuTools.Text = m_Settings.LocalizationTable.GetMenu("menuTools");
        //                break;
        //            case "menuToolsWord":
        //                this.menuToolsWord.Text = m_Settings.LocalizationTable.GetMenu("menuToolsWord");
        //                break;
        //            case "menuToolsWordImport":
        //                this.menuToolsWordImport.Text = m_Settings.LocalizationTable.GetMenu("menuToolsWordImport");
        //                break;
        //            case "menuToolsWordImportSF":
        //                this.menuToolsWordImportSF.Text = m_Settings.LocalizationTable.GetMenu("menuToolsWordImportSF");
        //                break;
        //            case "menuToolsWordImportLIFT":
        //                this.menuToolsWordImportLIFT.Text = m_Settings.LocalizationTable.GetMenu("menuToolsWordImportLIFT");
        //                break;
        //            case "menuToolsWordMerge":
        //                this.menuToolsWordMerge.Text = m_Settings.LocalizationTable.GetMenu("menuToolsWordMerge");
        //                break;
        //            case "menuToolsWordExport":
        //                this.menuToolsWordExport.Text = m_Settings.LocalizationTable.GetMenu("menuToolsWordExport");
        //                break;
        //            case "menuToolsWordReimport":
        //                this.menuToolsWordReimport.Text = m_Settings.LocalizationTable.GetMenu("menuToolsWordReimport");
        //                break;
        //            case "menuToolsWordUnload":
        //                this.menuToolsWordUnload.Text = m_Settings.LocalizationTable.GetMenu("menuToolsWordUnload");
        //                break;
        //            case "menuToolsWordCheck":
        //                this.menuToolsWordCheck.Text = m_Settings.LocalizationTable.GetMenu("menuToolsWordCheck");
        //                break;
        //            case "menuToolsText":
        //                this.menuToolsText.Text = m_Settings.LocalizationTable.GetMenu("menuToolsText");
        //                break;
        //            case "menuToolsTextImport":
        //                this.menuToolsTextImport.Text = m_Settings.LocalizationTable.GetMenu("menuToolsTextImport");
        //                break;
        //            case "menuToolsTextMerge":
        //                this.menuToolsTextMerge.Text = m_Settings.LocalizationTable.GetMenu("menuToolsTextMerge");
        //                break;
        //            case "menuToolsTextExport":
        //                this.menuToolsTextExport.Text = m_Settings.LocalizationTable.GetMenu("menuToolsTextExport");
        //                break;
        //            case "menuToolsTextReimport":
        //                this.menuToolsTextReimport.Text = m_Settings.LocalizationTable.GetMenu("menuToolsTextReimport");
        //                break;
        //            case "menuToolsTextUnload":
        //                 this.menuToolsTextUnload.Text  = m_Settings.LocalizationTable.GetMenu("menuToolsTextUnload");
        //                break;
        //            case "menuToolsTextCheckGI":
        //                this.menuToolsTextCheckGI.Text = m_Settings.LocalizationTable.GetMenu("menuToolsTextCheckGI");
        //                break;
        //            case "menuToolsTextCheckWL":
        //                this.menuToolsTextCheckWL.Text = m_Settings.LocalizationTable.GetMenu("menuToolsTextCheckWL");
        //                break;
        //            case "menuToolsTextBuildWL":
        //                this.menuToolsTextBuildWL.Text = m_Settings.LocalizationTable.GetMenu("menuToolsTextBuildWL");
        //                break;
        //            case "menuToolsInventory":
        //                this.menuToolsInventory.Text = m_Settings.LocalizationTable.GetMenu("menuToolsInventory");
        //                break;
        //            case "menuToolsInventoryInit":
        //                this.menuToolsInventoryInit.Text = m_Settings.LocalizationTable.GetMenu("menuToolsInventoryInit");
        //                break;
        //            case "menuToolsInventoryInitWL":
        //                this.menuToolsInventoryInitWL.Text = m_Settings.LocalizationTable.GetMenu("menuToolsInventoryInitWL");
        //                break;
        //            case "menuToolsInventoryInitTD":
        //                this.menuToolsInventoryInitTD.Text = m_Settings.LocalizationTable.GetMenu("menuToolsInventoryInitTD");
        //                break;
        //            case "menuToolsInventoryInitPG":
        //                this.menuToolsInventoryInitPG.Text = m_Settings.LocalizationTable.GetMenu("menuToolsInventoryInitPG");
        //                break;
        //            case "menuToolsInventorySyllabary":
        //                this.menuToolsInventorySyllabary.Text = m_Settings.LocalizationTable.GetMenu("menuToolsInventorySyllabary");
        //                break;
        //            case "menuToolsInventoryConsonants":
        //                this.menuToolsInventoryConsonants.Text = m_Settings.LocalizationTable.GetMenu("menuToolsInventoryConsonants");
        //                break;
        //            case "menuToolsInventoryVowels":
        //                this.menuToolsInventoryVowels.Text = m_Settings.LocalizationTable.GetMenu("menuToolsInventoryVowels");
        //                break;
        //            case "menuToolsInventoryTone":
        //                this.menuToolsInventoryTone.Text = m_Settings.LocalizationTable.GetMenu("menuToolsInventoryTone");
        //                break;
        //            case "menuToolsInventorySyllograph":
        //                this.menuToolsInventorySyllograph.Text = m_Settings.LocalizationTable.GetMenu("menuToolsInventorySyllograph");
        //                break;
        //            case "menuToolsInventorySave":
        //                this.menuToolsInventorySave.Text = m_Settings.LocalizationTable.GetMenu("menuToolsInventorySave");
        //                break;
        //            case "menuToolsInventoryClear":
        //                this.menuToolsInventoryClear.Text = m_Settings.LocalizationTable.GetMenu("menuToolsInventoryClear");
        //                break;
        //            case "menuToolsParts":
        //                this.menuToolsParts.Text = m_Settings.LocalizationTable.GetMenu("menuToolsParts");
        //                break;
        //            case "menuToolsPartsInit":
        //                this.menuToolsPartsInit.Text  = m_Settings.LocalizationTable.GetMenu("menuToolsPartsInit");
        //                break;
        //            case "menuToolsPartsUpdate":
        //                this.menuToolsPartsUpdate.Text  = m_Settings.LocalizationTable.GetMenu("menuToolsPartsUpdate");
        //                break;
        //            case "menuToolsPartsSave":
        //                this.menuToolsPartsSave.Text = m_Settings.LocalizationTable.GetMenu("menuToolsPartsSave");
        //                break;
        //            case "menuToolsSight":
        //                this.menuToolsSight.Text = m_Settings.LocalizationTable.GetMenu("menuToolsSight");
        //                break;
        //            case "menuToolsSightUpdate":
        //                this.menuToolsSightUpdate.Text = m_Settings.LocalizationTable.GetMenu("menuToolsSightUpdate");
        //                break;
        //            case "menuToolsSightSave":
        //                this.menuToolsSightSave.Text = m_Settings.LocalizationTable.GetMenu("menuToolsSightSave");
        //                break;
        //            case "menuToolsSightCheckWL":
        //                this.menuToolsSightCheckWL.Text = m_Settings.LocalizationTable.GetMenu("menuToolsSightCheckWL");
        //                break;
        //            case "menuToolsOrder":
        //                this.menuToolsOrder.Text = m_Settings.LocalizationTable.GetMenu("menuToolsOrder");
        //                break;
        //            case "menuToolsOrderUpdate":
        //                this.menuToolsOrderUpdate.Text = m_Settings.LocalizationTable.GetMenu("menuToolsOrderUpdate");
        //                break;
        //            case "menuToolsOrderSave":
        //                this.menuToolsOrderSave.Text  = m_Settings.LocalizationTable.GetMenu("menuToolsOrderSave");
        //                break;
        //            case "menuToolsOrderCheck":
        //                this.menuToolsOrderCheck.Text = m_Settings.LocalizationTable.GetMenu("menuToolsOrderCheck");
        //                break;
        //            case "menuToolsOptions":
        //                this.menuToolsOptions.Text = m_Settings.LocalizationTable.GetMenu("menuToolsOptions");
        //                break;
        //            case "menuWindow":
        //                this.menuWindow.Text = m_Settings.LocalizationTable.GetMenu("menuWindow");
        //                break;
        //            case "menuWindowCascade":
        //                this.menuWindowCascade.Text = m_Settings.LocalizationTable.GetMenu("menuWindowCascade");
        //                break;
        //            case "menuWindowTileH":
        //                this.menuWindowTileH.Text = m_Settings.LocalizationTable.GetMenu("menuWindowTileH");
        //                break;
        //            case "menuWindowTileV":
        //                this.menuWindowTileV.Text = m_Settings.LocalizationTable.GetMenu("menuWindowTileV");
        //                break;
        //            case "menuHelp":
        //                this.menuHelp.Text = m_Settings.LocalizationTable.GetMenu("menuHelp");
        //                break;
        //            case "menuHelpHelp":
        //                this.menuHelpHelp.Text = m_Settings.LocalizationTable.GetMenu("menuHelpHelp");
        //                break;
        //            case "menuHelpAbout":
        //                this.menuHelpAbout.Text = m_Settings.LocalizationTable.GetMenu("menuHelpAbout");
        //                break;
        //        }
        //    }
        //}

        private LocalizationTable GetLocalizationTable()
        {
            LocalizationTable table = new LocalizationTable();
            string strPath = m_Settings.GetAppFolder() + AppWindow.kBackSlash + AppWindow.kDefaultLocalizationName;
            string strLanguage = m_Settings.OptionSettings.UILanguage;
            switch (strLanguage)
            {
                case LocalizationTable.kEnglish:
                    strPath = m_Settings.GetAppFolder() + AppWindow.kBackSlash + AppWindow.kEnglishLocalizationName;
                    break;
                case LocalizationTable.kFrench:
                    strPath = m_Settings.GetAppFolder() + AppWindow.kBackSlash + AppWindow.kFrenchLocalizationName;
                    break;
                case LocalizationTable.kSpanish:
                    strPath = m_Settings.GetAppFolder() + AppWindow.kBackSlash + AppWindow.kSpanishLocalizationName;
                    break;
                case LocalizationTable.kOther:
                    strPath = m_Settings.GetAppFolder() + AppWindow.kBackSlash + AppWindow.kOtherLocalizationName;
                    break;
            }
            if (!table.LoadFromFile(strPath))
                MessageBox.Show("Localization failure");
            return table;;
        }

        private void UpdateMenuForLocalization()
        {
            LocalizationEntry entry = null;
            SortedList ml = m_Settings.LocalizationTable.MenuList;
            string strText = "";
            for (int i = 0; i < ml.Count; i++)
            {
                entry = (LocalizationEntry)ml.GetByIndex(i);
                switch (entry.Idn)
                {
                    case "menuFile":
                        strText = m_Settings.LocalizationTable.GetMenu("menuFile");
                        if (strText != "") 
                            this.menuFile.Text = strText;
                        break;
                    case "menuFileNew":
                        strText = m_Settings.LocalizationTable.GetMenu("menuFileNew");
                        if (strText != "")
                            this.menuFileNew.Text = strText;
                        break;
                    case "menuFileOpen":
                        strText = m_Settings.LocalizationTable.GetMenu("menuFileOpen");
						if (strText != "")
							this.menuFileOpen.Text = strText;
                        break;
                    case "menuFileClose":
                        strText = m_Settings.LocalizationTable.GetMenu("menuFileClose");
						if (strText != "")
							this.menuFileClose.Text = strText;
                        break;
                    case "menuFileSave":
                        strText = m_Settings.LocalizationTable.GetMenu("menuFileSave");
						if (strText != "")
							this.menuFileSave.Text = strText;
                        break;
                    case "menuFileAs":
                        strText = m_Settings.LocalizationTable.GetMenu("menuFileAs");
						if (strText != "")
							this.menuFileAs.Text = strText;
                        break;
                    case "menuFileProjNew":
                        strText = m_Settings.LocalizationTable.GetMenu("menuFileProjNew");
						if (strText != "")
							this.menuFileProjNew.Text = strText;
                        break;
                    case "menuFileProjSelect":
                        strText = m_Settings.LocalizationTable.GetMenu("menuFileProjSelect");
						if (strText != "")
							this.menuFileProjSelect.Text = strText;
                        break;
                    case "menuFileProjDelete":
                        strText = m_Settings.LocalizationTable.GetMenu("menuFileProjDelete");
						if (strText != "")
							this.menuFileProjDelete.Text = strText;
                        break;
                    case "menuFileProjExport":
                        strText = m_Settings.LocalizationTable.GetMenu("menuFileProjExport");
						if (strText != "")
							this.menuFileProjExport.Text = strText;
                        break;
                    case "menuFileProjImport":
                        strText = m_Settings.LocalizationTable.GetMenu("menuFileProjImport");
						if (strText != "")
							this.menuFileProjImport.Text = strText;
                        break;
                    case "menuFilePrint":
                        strText = m_Settings.LocalizationTable.GetMenu("menuFilePrint");
						if (strText != "")
							this.menuFilePrint.Text = strText;
                        break;
                    case "menuFilePreview":
                        strText = m_Settings.LocalizationTable.GetMenu("menuFilePreview");
						if (strText != "")
							this.menuFilePreview.Text = strText;
                        break;
                    case "menuFileSetup":
                        strText = m_Settings.LocalizationTable.GetMenu("menuFileSetup");
						if (strText != "")
							this.menuFileSetup.Text = strText;
                        break;
                    case "menuExit":
                        strText = m_Settings.LocalizationTable.GetMenu("menuExit");
						if (strText != "")
							this.menuExit.Text = strText;
                        break;
                    case "menuEdit":
                        strText = m_Settings.LocalizationTable.GetMenu("menuEdit");
						if (strText != "")
							this.menuEdit.Text = strText;
                        break;
                    case "menuEditUndo":
                        strText = m_Settings.LocalizationTable.GetMenu("menuEditUndo");
						if (strText != "")
							this.menuEditUndo.Text = strText;
                        break;
                    case "menuEditCut":
                        strText = m_Settings.LocalizationTable.GetMenu("menuEditCut");
						if (strText != "")
							this.menuEditCut.Text = strText;
                        break;
                    case "menuEditCopy":
                        strText = m_Settings.LocalizationTable.GetMenu("menuEditCopy");
						if (strText != "")
							this.menuEditCopy.Text = strText;
                        break;
                    case "menuEditPaste":
                        strText = m_Settings.LocalizationTable.GetMenu("menuEditPaste");
						if (strText != "")
							this.menuEditPaste.Text = strText;
                        break;
                    case "menuEditSelect":
                        strText = m_Settings.LocalizationTable.GetMenu("menuEditSelect");
						if (strText != "")
							this.menuEditSelect.Text = strText;
                        break;
                    case "menuEditClear":
                        strText = m_Settings.LocalizationTable.GetMenu("menuEditClear");
						if (strText != "")
							this.menuEditClear.Text = strText;
                        break;
                    case "menuEditFind":
                        strText = m_Settings.LocalizationTable.GetMenu("menuEditFind");
						if (strText != "")
							this.menuEditFind.Text = strText;
                        break;
                    case "menuEditNext":
                        strText = m_Settings.LocalizationTable.GetMenu("menuEditNext");
						if (strText != "")
							this.menuEditNext.Text = strText;
                        break;
                    case "menuEditReplace":
                        strText = m_Settings.LocalizationTable.GetMenu("menuEditReplace");
						if (strText != "")
							this.menuEditReplace.Text = strText;
                        break;
                    case "menuView":
                        strText = m_Settings.LocalizationTable.GetMenu("menuView");
						if (strText != "")
							this.menuView.Text = strText;
                        break;
                    case "menuViewToolbar":
                        strText = m_Settings.LocalizationTable.GetMenu("menuViewToolbar");
						if (strText != "")
							this.menuViewToolbar.Text = strText;
                        break;
                    case "menuViewStatus":
                        strText = m_Settings.LocalizationTable.GetMenu("menuViewStatus");
						if (strText != "")
							this.menuViewStatus.Text = strText;
                        break;
                    case "menuViewMode":
                        strText = m_Settings.LocalizationTable.GetMenu("menuViewMode");
						if (strText != "")
							this.menuViewMode.Text = strText;
                        break;
                    case "menuViewShow":
                        strText = m_Settings.LocalizationTable.GetMenu("menuViewShow");
						if (strText != "")
							this.menuViewShow.Text = strText;
                        break;
                    case "menuViewHide":
                        strText = m_Settings.LocalizationTable.GetMenu("menuViewHide");
						if (strText != "")
							this.menuViewHide.Text = strText;
                        break;
                    case "menuViewClear":
                        strText = m_Settings.LocalizationTable.GetMenu("menuViewClear");
						if (strText != "")
							this.menuViewClear.Text = strText;
                        break;
                    case "menuViewUnprocessed":
                        strText = m_Settings.LocalizationTable.GetMenu("menuViewUnprocessed");
						if (strText != "")
							this.menuViewUnprocessed.Text = strText;
                        break;
                    case "menuViewWordList":
                        strText = m_Settings.LocalizationTable.GetMenu("menuViewWordList");
						if (strText != "")
							this.menuViewWordList.Text = strText;
                        break;
                    case "menuViewTextData":
                        strText = m_Settings.LocalizationTable.GetMenu("menuViewTextData");
						if (strText != "")
							this.menuViewTextData.Text = strText;
                        break;
                    case "menuViewInventory":
                        strText = m_Settings.LocalizationTable.GetMenu("menuViewInventory");
						if (strText != "")
							this.menuViewInventory.Text = strText;
                        break;
                    case "menuViewPS":
                        strText = m_Settings.LocalizationTable.GetMenu("menuViewPS");
						if (strText != "")
							this.menuViewPS.Text = strText;
                        break;
                    case "menuViewSite":
                        strText = m_Settings.LocalizationTable.GetMenu("menuViewSite");
						if (strText != "")
							this.menuViewSite.Text = strText;
                        break;
                    case "menuViewGraphemes":
                        strText = m_Settings.LocalizationTable.GetMenu("menuViewGraphemes");
						if (strText != "")
							this.menuViewGraphemes.Text = strText;
                        break;
                    case "menuFormat":
                        strText = m_Settings.LocalizationTable.GetMenu("menuFormat");
						if (strText != "")
							this.menuFormat.Text = strText;
                        break;
                    case "menuFormatFont":
                        strText = m_Settings.LocalizationTable.GetMenu("menuFormatFont");
						if (strText != "")
							this.menuFormatFont.Text = strText;
                        break;
                    case "menuFormatColor":
                        strText = m_Settings.LocalizationTable.GetMenu("menuFormatColor");
						if (strText != "")
							this.menuFormatColor.Text = strText;
                        break;
                    case "menuFormatWrap":
                        strText = m_Settings.LocalizationTable.GetMenu("menuFormatWrap");
						if (strText != "")
							this.menuFormatWrap.Text = strText;
                        break;
                    case "menuReport":
                        strText = m_Settings.LocalizationTable.GetMenu("menuReport");
						if (strText != "")
							this.menuReport.Text = strText;
                        break;
                    case "menuReportVowel":
                        strText = m_Settings.LocalizationTable.GetMenu("menuReportVowel");
						if (strText != "")
							this.menuReportVowel.Text = strText;
                        break;
                    case "menuReportConsonant":
                        strText = m_Settings.LocalizationTable.GetMenu("menuReportConsonant");
						if (strText != "")
							this.menuReportConsonant.Text = strText;
                        break;
                    case "menuReportPrimer":
                        strText = m_Settings.LocalizationTable.GetMenu("menuReportPrimer");
						if (strText != "")
							this.menuReportPrimer.Text = strText;
                        break;
                    case "menuReportGenerate":
                        strText = m_Settings.LocalizationTable.GetMenu("menuReportGenerate");
						if (strText != "")
							this.menuReportGenerate.Text = strText;
                        break;
                    case "menuReportEdit":
                        strText = m_Settings.LocalizationTable.GetMenu("menuReportEdit");
						if (strText != "")
							this.menuReportEdit.Text = strText;
                        break;
                    case "menuSearch":
                        strText = m_Settings.LocalizationTable.GetMenu("menuSearch");
						if (strText != "")
							this.menuSearch.Text = strText;
                        break;
                    case "menuSearchWord":
                        strText = m_Settings.LocalizationTable.GetMenu("menuSearchWord");
						if (strText != "")
							this.menuSearchWord.Text = strText;
                        break;
                    case "menuSearchWordGrapheme":
                        strText = m_Settings.LocalizationTable.GetMenu("menuSearchWordGrapheme");
						if (strText != "")
							this.menuSearchWordGrapheme.Text = strText;
                        break;
                    case "menuSearchWordFrequency":
                        strText = m_Settings.LocalizationTable.GetMenu("menuSearchWordFrequency");
						if (strText != "")
							this.menuSearchWordFrequency.Text = strText;
                        break;
                    case "menuSearchWordBuild":
                        strText = m_Settings.LocalizationTable.GetMenu("menuSearchWordBuild");
						if (strText != "")
							this.menuSearchWordBuild.Text = strText;
                        break;
                    case "menuSearchWordAdvanced":
                        strText = m_Settings.LocalizationTable.GetMenu("menuSearchWordAdvanced");
						if (strText != "")
							this.menuSearchWordAdvanced.Text = strText;
                        break;
                    case "menuSearchWordPairs":
                        strText = m_Settings.LocalizationTable.GetMenu("menuSearchWordPairs");
						if (strText != "")
							this.menuSearchWordPairs.Text = strText;
                        break;
                    case "menuSearchWordCoccur":
                        strText = m_Settings.LocalizationTable.GetMenu("menuSearchWordCoccur");
						if (strText != "")
							this.menuSearchWordCoccur.Text = strText;
                        break;
                    case "menuSearchWordContext":
                        strText = m_Settings.LocalizationTable.GetMenu("menuSearchWordContext");
						if (strText != "")
							this.menuSearchWordContext.Text = strText;
                        break;
                    case "menuSearchWordSyllable":
                        strText = m_Settings.LocalizationTable.GetMenu("menuSearchWordSyllable");
						if (strText != "")
							this.menuSearchWordSyllable.Text = strText;
                        break;
                    case "menuSearchWordTone":
                        strText = m_Settings.LocalizationTable.GetMenu("menuSearchWordTone");
						if (strText != "")
							this.menuSearchWordTone.Text = strText;
                        break;
                    case "menuSearchWordSyllograph":
                        strText = m_Settings.LocalizationTable.GetMenu("menuSearchWordSyllograph");
						if (strText != "")
							this.menuSearchWordSyllograph.Text = strText;
                        break;
                    case "menuSearchWordOrder":
                        strText = m_Settings.LocalizationTable.GetMenu("menuSearchWordOrder");
						if (strText != "")
							this.menuSearchWordOrder.Text = strText;
                        break;
                    case "menuSearchWordGeneral":
                        strText = m_Settings.LocalizationTable.GetMenu("menuSearchWordGeneral");
						if (strText != "")
							this.menuSearchWordGeneral.Text = strText;
                        break;
                    case "menuSearchText":
                        strText = m_Settings.LocalizationTable.GetMenu("menuSearchText");
						if (strText != "")
							this.menuSearchText.Text = strText;
                        break;
                    case "menuSearchTextGrapheme":
                        strText = m_Settings.LocalizationTable.GetMenu("menuSearchTextGrapheme");
						if (strText != "")
							this.menuSearchTextGrapheme.Text = strText;
                        break;
                    case "menuSearchTextFrequency":
                        strText = m_Settings.LocalizationTable.GetMenu("menuSearchTextFrequency");
						if (strText != "")
							this.menuSearchTextFrequency.Text = strText;
                        break;
                    case "menuSearchTextBuilt":
                        strText = m_Settings.LocalizationTable.GetMenu("menuSearchTextBuilt");
						if (strText != "")
							this.menuSearchTextBuild.Text = strText;
                        break;
                    case "menuSearchTextPhrases":
                        strText = m_Settings.LocalizationTable.GetMenu("menuSearchTextPhrases");
						if (strText != "")
							this.menuSearchTextPhrases.Text = strText;
                        break;
                    case "menuSearchTextResidue":
                        strText = m_Settings.LocalizationTable.GetMenu("menuSearchTextResidue");
						if (strText != "")
							this.menuSearchTextResidue.Text = strText;
                        break;
                    case "menuSearchTextWord":
                        strText = m_Settings.LocalizationTable.GetMenu("menuSearchTextWord");
						if (strText != "")
							this.menuSearchTextWord.Text = strText;
                        break;
                    case "menuSearchTextCount":
                        strText = m_Settings.LocalizationTable.GetMenu("menuSearchTextCount");
						if (strText != "")
							this.menuSearchTextCount.Text = strText;
                        break;
                    case "menuSearchTextSyllable":
                        strText = m_Settings.LocalizationTable.GetMenu("menuSearchTextSyllable");
						if (strText != "")
							this.menuSearchTextSyllable.Text = strText;
                        break;
                    case "menuSearchTextSight":
                        strText = m_Settings.LocalizationTable.GetMenu("menuSearchTextSight");
						if (strText != "")
							this.menuSearchTextSight.Text = strText;
                        break;
                    case "menuSearchTextNew":
                        strText = m_Settings.LocalizationTable.GetMenu("menuSearchTextNew");
						if (strText != "")
							this.menuSearchTextNew.Text = strText;
                        break;
                    case "menuSearchTextTone":
                        strText = m_Settings.LocalizationTable.GetMenu("menuSearchTextTone");
						if (strText != "")
							this.menuSearchTextTone.Text = strText;
                        break;
                    case "menuSearchTextSyllograph":
                        strText = m_Settings.LocalizationTable.GetMenu("menuSearchTextSyllograph");
						if (strText != "")
							this.menuSearchTextSyllograph.Text = strText;
                        break;
                    case "menuSearchTextOrder":
                        strText = m_Settings.LocalizationTable.GetMenu("menuSearchTextOrder");
						if (strText != "")
							this.menuSearchTextOrder.Text = strText;
                        break;
                    case "menuSearchTextGeneral":
                        strText = m_Settings.LocalizationTable.GetMenu("menuSearchTextGeneral");
						if (strText != "")
							this.menuSearchTextGeneral.Text = strText;
                        break;
                    case "menuSearchVowel":
                        strText = m_Settings.LocalizationTable.GetMenu("menuSearchVowel");
						if (strText != "")
							this.menuSearchVowel.Text = strText;
                        break;
                    case "menuSearchConsonant":
                        strText = m_Settings.LocalizationTable.GetMenu("menuSearchConsonant");
						if (strText != "")
							this.menuSearchConsonant.Text = strText;
                        break;
                    case "menuSearchTone":
                        strText = m_Settings.LocalizationTable.GetMenu("menuSearchTone");
						if (strText != "")
							this.menuSearchTone.Text = strText;
                        break;
                    case "menuSearchSyllograph":
                        strText = m_Settings.LocalizationTable.GetMenu("menuSearchSyllograph");
						if (strText != "")
							this.menuSearchSyllograph.Text = strText;
                        break;
                    case "menuTools":
                        strText = m_Settings.LocalizationTable.GetMenu("menuTools");
						if (strText != "")
							this.menuTools.Text = strText;
                        break;
                    case "menuToolsWord":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsWord");
						if (strText != "")
							this.menuToolsWord.Text = strText;
                        break;
                    case "menuToolsWordImport":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsWordImport");
						if (strText != "")
							this.menuToolsWordImport.Text = strText;
                        break;
                    case "menuToolsWordImportSF":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsWordImportSF");
						if (strText != "")
							this.menuToolsWordImportSF.Text = strText;
                        break;
                    case "menuToolsWordImportLIFT":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsWordImportLIFT");
						if (strText != "")
							this.menuToolsWordImportLIFT.Text = strText;
                        break;
                    case "menuToolsWordMerge":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsWordMerge");
						if (strText != "")
							this.menuToolsWordMerge.Text = strText;
                        break;
                    case "menuToolsWordExport":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsWordExport");
						if (strText != "")
							this.menuToolsWordExport.Text = strText;
                        break;
                    case "menuToolsWordReimport":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsWordReimport");
						if (strText != "")
							this.menuToolsWordReimport.Text = strText;
                        break;
                    case "menuToolsWordUnload":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsWordUnload");
						if (strText != "")
							this.menuToolsWordUnload.Text = strText;
                        break;
                    case "menuToolsWordCheck":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsWordCheck");
						if (strText != "")
							this.menuToolsWordCheck.Text = strText;
                        break;
                    case "menuToolsText":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsText");
						if (strText != "")
							this.menuToolsText.Text = strText;
                        break;
                    case "menuToolsTextImport":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsTextImport");
						if (strText != "")
							this.menuToolsTextImport.Text = strText;
                        break;
                    case "menuToolsTextMerge":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsTextMerge");
						if (strText != "")
							this.menuToolsTextMerge.Text = strText;
                        break;
                    case "menuToolsTextExport":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsTextExport");
						if (strText != "")
							this.menuToolsTextExport.Text = strText;
                        break;
                    case "menuToolsTextReimport":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsTextReimport");
						if (strText != "")
							this.menuToolsTextReimport.Text = strText;
                        break;
                    case "menuToolsTextUnload":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsTextUnload");
						if (strText != "")
							this.menuToolsTextUnload.Text = strText;
                        break;
                    case "menuToolsTextCheckGI":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsTextCheckGI");
						if (strText != "")
							this.menuToolsTextCheckGI.Text = strText;
                        break;
                    case "menuToolsTextCheckWL":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsTextCheckWL");
						if (strText != "")
							this.menuToolsTextCheckWL.Text = strText;
                        break;
                    case "menuToolsTextBuildWL":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsTextBuildWL");
						if (strText != "")
							this.menuToolsTextBuildWL.Text = strText;
                        break;
                    case "menuToolsInventory":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsInventory");
						if (strText != "")
							this.menuToolsInventory.Text = strText;
                        break;
                    case "menuToolsInventoryInit":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsInventoryInit");
						if (strText != "")
							this.menuToolsInventoryInit.Text = strText;
                        break;
                    case "menuToolsInventoryInitWL":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsInventoryInitWL");
						if (strText != "")
							this.menuToolsInventoryInitWL.Text = strText;
                        break;
                    case "menuToolsInventoryInitTD":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsInventoryInitTD");
						if (strText != "")
							this.menuToolsInventoryInitTD.Text = strText;
                        break;
                    case "menuToolsInventoryInitPG":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsInventoryInitPG");
						if (strText != "")
							this.menuToolsInventoryInitPG.Text = strText;
                        break;
                    case "menuToolsInventorySyllabary":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsInventorySyllabary");
						if (strText != "")
							this.menuToolsInventorySyllabary.Text = strText;
                        break;
                    case "menuToolsInventoryConsonants":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsInventoryConsonants");
						if (strText != "")
							this.menuToolsInventoryConsonants.Text = strText;
                        break;
                    case "menuToolsInventoryVowels":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsInventoryVowels");
						if (strText != "")
							this.menuToolsInventoryVowels.Text = strText;
                        break;
                    case "menuToolsInventoryTone":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsInventoryTone");
						if (strText != "")
							this.menuToolsInventoryTone.Text = strText;
                        break;
                    case "menuToolsInventorySyllograph":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsInventorySyllograph");
						if (strText != "")
							this.menuToolsInventorySyllograph.Text = strText;
                        break;
                    case "menuToolsInventorySave":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsInventorySave");
						if (strText != "")
							this.menuToolsInventorySave.Text = strText;
                        break;
                    case "menuToolsInventoryClear":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsInventoryClear");
						if (strText != "")
							this.menuToolsInventoryClear.Text = strText;
                        break;
                    case "menuToolsParts":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsParts");
						if (strText != "")
							this.menuToolsParts.Text = strText;
                        break;
                    case "menuToolsPartsInit":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsPartsInit");
						if (strText != "")
							this.menuToolsPartsInit.Text = strText;
                        break;
                    case "menuToolsPartsUpdate":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsPartsUpdate");
						if (strText != "")
							this.menuToolsPartsUpdate.Text = strText;
                        break;
                    case "menuToolsPartsSave":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsPartsSave");
						if (strText != "")
							this.menuToolsPartsSave.Text = strText;
                        break;
                    case "menuToolsSight":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsSight");
						if (strText != "")
							this.menuToolsSight.Text = strText;
                        break;
                    case "menuToolsSightUpdate":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsSightUpdate");
						if (strText != "")
							this.menuToolsSightUpdate.Text = strText;
                        break;
                    case "menuToolsSightSave":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsSightSave");
						if (strText != "")
							this.menuToolsSightSave.Text = strText;
                        break;
                    case "menuToolsSightCheckWL":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsSightCheckWL");
						if (strText != "")
							this.menuToolsSightCheckWL.Text = strText;
                        break;
                    case "menuToolsOrder":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsOrder");
						if (strText != "")
							this.menuToolsOrder.Text = strText;
                        break;
                    case "menuToolsOrderUpdate":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsOrderUpdate");
						if (strText != "")
							this.menuToolsOrderUpdate.Text = strText;
                        break;
                    case "menuToolsOrderSave":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsOrderSave");
						if (strText != "")
							this.menuToolsOrderSave.Text = strText;
                        break;
                    case "menuToolsOrderCheck":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsOrderCheck");
						if (strText != "")
							this.menuToolsOrderCheck.Text = strText;
                        break;
                    case "menuToolsOptions":
                        strText = m_Settings.LocalizationTable.GetMenu("menuToolsOptions");
						if (strText != "")
							this.menuToolsOptions.Text = strText;
                        break;
                    case "menuWindow":
                        strText = m_Settings.LocalizationTable.GetMenu("menuWindow");
						if (strText != "")
							this.menuWindow.Text = strText;
                        break;
                    case "menuWindowCascade":
                        strText = m_Settings.LocalizationTable.GetMenu("menuWindowCascade");
						if (strText != "")
							this.menuWindowCascade.Text = strText;
                        break;
                    case "menuWindowTileH":
                        strText = m_Settings.LocalizationTable.GetMenu("menuWindowTileH");
						if (strText != "")
							this.menuWindowTileH.Text = strText;
                        break;
                    case "menuWindowTileV":
                        strText = m_Settings.LocalizationTable.GetMenu("menuWindowTileV");
						if (strText != "")
							this.menuWindowTileV.Text = strText;
                        break;
                    case "menuHelp":
                        strText = m_Settings.LocalizationTable.GetMenu("menuHelp");
						if (strText != "")
							this.menuHelp.Text = strText;
                        break;
                    case "menuHelpHelp":
                        strText = m_Settings.LocalizationTable.GetMenu("menuHelpHelp");
                        if (strText != "")
                            this.menuHelpHelp.Text = strText;
                        break;
                    case "menuHelpAbout":
                        strText = m_Settings.LocalizationTable.GetMenu("menuHelpAbout");
                        if (strText != "")
                            this.menuHelpAbout.Text = strText;
                        break;
                }
            }
        }
       
        private void UpdateMenuForSimplified()
        {
            LocalizationEntry entry = null;
            SortedList ml = m_Settings.LocalizationTable.MenuList;
            for (int i = 0; i < ml.Count; i++)
            {
                entry = (LocalizationEntry)ml.GetByIndex(i);
                switch (entry.Idn)
                {
                    case "menuFile":
                        break;
                    case "menuFileNew":
                        break;
                    case "menuFileOpen":
                        break;
                    case "menuFileClose":
                        break;
                    case "menuFileSave":
                        break;
                    case "menuFileAs":
                        break;
                    case "menuFileProjNew":
                        break;
                    case "menuFileProjSelect":
                        break;
                    case "menuFileProjDelete":
                        break;
                    case "menuFileProjExport":
                        break;
                    case "menuFileProjImport":
                        break;
                    case "menuFilePrint":
                        break;
                    case "menuFilePreview":
                        break;
                    case "menuFileSetup":
                        break;
                    case "menuExit":
                        break;
                    case "menuEdit":
                        break;
                    case "menuEditUndo":
                        break;
                    case "menuEditCut":
                        break;
                    case "menuEditCopy":
                        break;
                    case "menuEditPaste":
                        break;
                    case "menuEditSelect":
                        break;
                    case "menuEditClear":
                        break;
                    case "menuEditFind":
                        break;
                    case "menuEditNext":
                        break;
                    case "menuEditReplace":
                        break;
                    case "menuView":
                        break;
                    case "menuViewToolbar":
                        break;
                    case "menuViewStatus":
                        break;
                    case "menuViewMode":
                        this.menuViewMode.Visible = false;
                        break;
                    case "menuViewShow":
                        this.menuViewShow.Visible = false;
                        break;
                    case "menuViewHide":
                        this.menuViewHide.Visible = false;
                        break;
                    case "menuViewClear":
                        this.menuViewClear.Visible = false;
                        break;
                    case "menuViewUnprocessed":
                        this.menuViewUnprocessed.Visible = false;
                        break;
                    case "menuViewWordList":
                        break;
                    case "menuViewTextData":
                        break;
                    case "menuViewInventory":
                        break;
                    case "menuViewPS":
                        break;
                    case "menuViewSite":
                        break;
                    case "menuViewGraphemes":
                        break;
                    case "menuFormat":
                        break;
                    case "menuFormatFont":
                        break;
                    case "menuFormatColor":
                        break;
                    case "menuFormatWrap":
                        break;
                    case "menuReport":
                        break;
                    case "menuReportVowel":
                        break;
                    case "menuReportConsonant":
                        break;
                    case "menuReportPrimer":
                        break;
                    case "menuReportGenerate":
                        this.menuReportGenerate.Visible = false;
                        break;
                    case "menuReportEdit":
                        this.menuReportEdit.Visible = false;
                        break;
                    case "menuSearch":
                        break;
                    case "menuSearchWord":
                        break;
                    case "menuSearchWordGrapheme":
                        break;
                    case "menuSearchWordFrequency":
                        break;
                    case "menuSearchWordBuild":
                        break;
                    case "menuSearchWordAdvanced":
                        this.menuSearchWordAdvanced.Visible = false;
                        break;
                    case "menuSearchWordPairs":
                        this.menuSearchWordPairs.Visible = false;
                        break;
                    case "menuSearchWordCoccur":
                        break;
                    case "menuSearchWordContext":
                        break;
                    case "menuSearchWordSyllable":
                        this.menuSearchWordSyllable.Visible = false;
                        break;
                    case "menuSearchWordTone":
                        break;
                    case "menuSearchWordSyllograph":
                        this.menuSearchWordSyllograph.Visible = false;
                        break;
                    case "menuSearchWordOrder":
                        this.menuSearchWordOrder.Visible = false;
                        break;
                    case "menuSearchWordGeneral":
                        break;
                    case "menuSearchText":
                        break;
                    case "menuSearchTextGrapheme":
                        break;
                    case "menuSearchTextFrequency":
                        break;
                    case "menuSearchTextBuilt":
                        break;
                    case "menuSearchTextPhrases":
                        break;
                    case "menuSearchTextResidue":
                        break;
                    case "menuSearchTextWord":
                        this.menuSearchTextWord.Visible = false;
                        break;
                    case "menuSearchTextCount":
                        this.menuSearchTextCount.Visible = false;
                        break;
                    case "menuSearchTextSyllable":
                        this.menuSearchTextSyllable.Visible = false;
                        break;
                    case "menuSearchTextSight":
                        this.menuSearchTextSight.Visible = false;
                        break;
                    case "menuSearchTextNew":
                        break;
                    case "menuSearchTextTone":
                        break;
                    case "menuSearchTextSyllograph":
                        this.menuSearchTextSyllograph.Visible = false;
                        break;
                    case "menuSearchTextOrder":
                        break;
                    case "menuSearchVowel":
                        break;
                    case "menuSearchConsonant":
                        break;
                    case "menuSearchTone":
                        break;
                    case "menuSearchSyllograph":
                        this.menuSearchSyllograph.Visible = false;
                        break;
                    case "menuTools":
                        break;
                    case "menuToolsWord":
                        break;
                    case "menuToolsWordImport":
                        break;
                    case "menuToolsWordImportSF":
                        break;
                    case "menuToolsWordImportLIFT":
                        break;
                    case "menuToolsWordMerge":
                        this.menuToolsWordMerge.Visible = false;;
                        break;
                    case "menuToolsWordExport":
                        this.menuToolsWordExport.Visible = false;
                        break;
                    case "menuToolsWordReimport":
                        break;
                    case "menuToolsWordUnload":
                        this.menuToolsWordUnload.Visible = false;
                        break;
                    case "menuToolsWordCheck":
                        break;
                    case "menuToolsText":
                        break;
                    case "menuToolsTextImport":
                        break;
                    case "menuToolsTextMerge":
                        this.menuToolsTextMerge.Visible = false;;
                        break;
                    case "menuToolsTextExport":
                        this.menuToolsTextExport.Visible = false;;
                        break;
                    case "menuToolsTextReimport":
                        break;
                    case "menuToolsTextUnload":
                        this.menuToolsTextUnload.Visible = false;
                        break;
                    case "menuToolsTextCheckGI":
                        break;
                    case "menuToolsTextCheckWL":
                        this.menuToolsTextCheckWL.Visible = false;
                        break;
                    case "menuToolsTextBuildWL":
                        this.menuToolsTextBuildWL.Visible= false;
                        break;
                    case "menuToolsInventory":
                        break;
                    case "menuToolsInventoryInit":
                        this.menuToolsInventoryInit.Visible = false;
                        break;
                    case "menuToolsInventorySyllabary":
                        this.menuToolsInventorySyllabary.Visible = false;
                        break;
                    case "menuToolsInventoryConsonants":
                        break;
                    case "menuToolsInventoryVowels":
                        break;
                    case "menuToolsInventoryTone":
                        break;
                    case "menuToolsInventorySyllograph":
                        this.menuToolsInventorySyllograph.Visible = false;
                        break;
                    case "menuToolsInventorySave":
                        this.menuToolsInventorySave.Visible = false;
                        break;
                    case "menuToolsInventoryClear":
                        this.menuToolsInventoryClear.Visible = false;
                        break;
                    case "menuToolsParts":
                        break;
                    case "menuToolsPartsInit":
                        break;
                    case "menuToolsPartsUpdate":
                        break;
                    case "menuToolsPartsSave":
                        this.menuToolsPartsSave.Visible = false;
                        break;
                    case "menuToolsSight":
                        break;
                    case "menuToolsSightUpdate":
                        break;
                    case "menuToolsSightSave":
                        this.menuToolsSightSave.Visible = false;
                        break;
                    case "menuToolsSightCheckWL":
                        this.menuToolsSightCheckWL.Visible = false;
                        break;
                    case "menuToolsOrder":
                        break;
                    case "menuToolsOrderUpdate":
                        break;
                    case "menuToolsOrderSave":
                        this.menuToolsOrderSave.Visible = false;
                        break;
                    case "menuToolsOrderCheck":
                        break;
                    case "menuToolsOptions":
                        break;
                    case "menuWindow":
                        break;
                    case "menuWindowCascade":
                        break;
                    case "menuWindowTileH":
                        break;
                    case "menuWindowTileV":
                        break;
                    case "menuHelp":
                        break;
                    case "menuHelpHelp":
                        break;
                    case "menuHelpAbout":
                        break;
                }
            }
        }

        private void UpdateMenuForNormal()
        {
            LocalizationEntry entry = null;
            SortedList ml = m_Settings.LocalizationTable.MenuList;
            for (int i = 0; i < ml.Count; i++)
            {
                entry = (LocalizationEntry)ml.GetByIndex(i);
                switch (entry.Idn)
                {
                    case "menuFile":
                        break;
                    case "menuFileNew":
                        break;
                    case "menuFileOpen":
                        break;
                    case "menuFileClose":
                        break;
                    case "menuFileSave":
                        break;
                    case "menuFileAs":
                        break;
                    case "menuFileProjNew":
                        break;
                    case "menuFileProjSelect":
                        break;
                    case "menuFileProjDelete":
                        break;
                    case "menuFileProjExport":
                        break;
                    case "menuFileProjImport":
                        break;
                    case "menuFilePrint":
                        break;
                    case "menuFilePreview":
                        break;
                    case "menuFileSetup":
                        break;
                    case "menuExit":
                        break;
                    case "menuEdit":
                        break;
                    case "menuEditUndo":
                        break;
                    case "menuEditCut":
                        break;
                    case "menuEditCopy":
                        break;
                    case "menuEditPaste":
                        break;
                    case "menuEditSelect":
                        break;
                    case "menuEditClear":
                        break;
                    case "menuEditFind":
                        break;
                    case "menuEditNext":
                        break;
                    case "menuEditReplace":
                        break;
                    case "menuView":
                        break;
                    case "menuViewToolbar":
                        break;
                    case "menuViewStatus":
                        break;
                    case "menuViewMode":
                        this.menuViewMode.Visible = true;
                        break;
                    case "menuViewShow":
                        this.menuViewShow.Visible = true;
                        break;
                    case "menuViewHide":
                        this.menuViewHide.Visible = true;
                        break;
                    case "menuViewClear":
                        this.menuViewClear.Visible = true;
                        break;
                    case "menuViewUnprocessed":
                        this.menuViewUnprocessed.Visible = true;
                        break;
                    case "menuViewWordList":
                        break;
                    case "menuViewTextData":
                        break;
                    case "menuViewInventory":
                        break;
                    case "menuViewPS":
                        break;
                    case "menuViewSite":
                        break;
                    case "menuViewGraphemes":
                        break;
                    case "menuFormat":
                        break;
                    case "menuFormatFont":
                        break;
                    case "menuFormatColor":
                        break;
                    case "menuFormatWrap":
                        break;
                    case "menuReport":
                        break;
                    case "menuReportVowel":
                        break;
                    case "menuReportConsonant":
                        break;
                    case "menuReportPrimer":
                        break;
                    case "menuReportGenerate":
                        this.menuReportGenerate.Visible = true;
                        break;
                    case "menuReportEdit":
                        this.menuReportEdit.Visible = true;
                        break;
                    case "menuSearch":
                        break;
                    case "menuSearchWord":
                        break;
                    case "menuSearchWordGrapheme":
                        break;
                    case "menuSearchWordFrequency":
                        break;
                    case "menuSearchWordBuild":
                        break;
                    case "menuSearchWordAdvanced":
                        this.menuSearchWordAdvanced.Visible = true;
                        break;
                    case "menuSearchWordPairs":
                        this.menuSearchWordPairs.Visible = true;
                        break;
                    case "menuSearchWordCoccur":
                        break;
                    case "menuSearchWordContext":
                        break;
                    case "menuSearchWordSyllable":
                        this.menuSearchWordSyllable.Visible = true;
                        break;
                    case "menuSearchWordTone":
                        break;
                    case "menuSearchWordSyllograph":
                        this.menuSearchWordSyllograph.Visible = true;
                        break;
                    case "menuSearchWordOrder":
                        this.menuSearchWordOrder.Visible = true;
                        break;
                    case "menuSearchWordGeneral":
                        break;
                    case "menuSearchText":
                        break;
                    case "menuSearchTextGrapheme":
                        break;
                    case "menuSearchTextFrequency":
                        break;
                    case "menuSearchTextBuilt":
                        break;
                    case "menuSearchTextPhrases":
                        break;
                    case "menuSearchTextResidue":
                        break;
                    case "menuSearchTextWord":
                        this.menuSearchTextWord.Visible = true;
                        break;
                    case "menuSearchTextCount":
                        this.menuSearchTextCount.Visible = true;
                        break;
                    case "menuSearchTextSyllable":
                        this.menuSearchTextSyllable.Visible = true;
                        break;
                    case "menuSearchTextSight":
                        this.menuSearchTextSight.Visible = true;
                        break;
                    case "menuSearchTextNew":
                        break;
                    case "menuSearchTextTone":
                        break;
                    case "menuSearchTextSyllograph":
                        this.menuSearchTextSyllograph.Visible = true;
                        break;
                    case "menuSearchTextOrder":
                        break;
                    case "menuSearchVowel":
                        break;
                    case "menuSearchConsonant":
                        break;
                    case "menuSearchTone":
                        break;
                    case "menuSearchSyllograph":
                        this.menuSearchSyllograph.Visible = true;
                        break;
                    case "menuTools":
                        break;
                    case "menuToolsWord":
                        break;
                    case "menuToolsWordImport":
                        break;
                    case "menuToolsWordImportSF":
                        break;
                    case "menuToolsWordImportLIFT":
                        break;
                    case "menuToolsWordMerge":
                        this.menuToolsWordMerge.Visible = true ;
                        break;
                    case "menuToolsWordExport":
                        this.menuToolsWordExport.Visible = true;
                        break;
                    case "menuToolsWordReimport":
                        break;
                    case "menuToolsWordUnload":
                        this.menuToolsWordUnload.Visible = true;
                        break;
                    case "menuToolsWordCheck":
                        break;
                    case "menuToolsText":
                        break;
                    case "menuToolsTextImport":
                        break;
                    case "menuToolsTextMerge":
                        this.menuToolsTextMerge.Visible = true;
                        break;
                    case "menuToolsTextExport":
                        this.menuToolsTextExport.Visible = true;
                        break;
                    case "menuToolsTextReimport":
                        break;
                    case "menuToolsTextUnload":
                        this.menuToolsTextUnload.Visible = true;
                        break;
                    case "menuToolsTextCheckGI":
                        break;
                    case "menuToolsTextCheckWL":
                        this.menuToolsTextCheckWL.Visible = true;
                        break;
                    case "menuToolsTextBuildWL":
                        this.menuToolsTextBuildWL.Visible = true;
                        break;
                    case "menuToolsInventory":
                        break;
                    case "menuToolsInventoryInit":
                        this.menuToolsInventoryInit.Visible = true;
                        break;
                    case "menuToolsInventorySyllabary":
                        this.menuToolsInventorySyllabary.Visible = true;
                        break;
                    case "menuToolsInventoryConsonants":
                        break;
                    case "menuToolsInventoryVowels":
                        break;
                    case "menuToolsInventoryTone":
                        break;
                    case "menuToolsInventorySyllograph":
                        this.menuToolsInventorySyllograph.Visible = true;
                        break;
                    case "menuToolsInventorySave":
                        this.menuToolsInventorySave.Visible = true;
                        break;
                    case "menuToolsInventoryClear":
                        this.menuToolsInventoryClear.Visible = true;
                        break;
                    case "menuToolsParts":
                        break;
                    case "menuToolsPartsInit":
                        break;
                    case "menuToolsPartsUpdate":
                        break;
                    case "menuToolsPartsSave":
                        this.menuToolsPartsSave.Visible = true;
                        break;
                    case "menuToolsSight":
                        break;
                    case "menuToolsSightUpdate":
                        break;
                    case "menuToolsSightSave":
                        this.menuToolsSightSave.Visible = true;
                        break;
                    case "menuToolsSightCheckWL":
                        this.menuToolsSightCheckWL.Visible = true;
                        break;
                    case "menuToolsOrder":
                        break;
                    case "menuToolsOrderUpdate":
                        break;
                    case "menuToolsOrderSave":
                        this.menuToolsOrderSave.Visible = true;
                        break;
                    case "menuToolsOrderCheck":
                        break;
                    case "menuToolsOptions":
                        break;
                    case "menuWindow":
                        break;
                    case "menuWindowCascade":
                        break;
                    case "menuWindowTileH":
                        break;
                    case "menuWindowTileV":
                        break;
                    case "menuHelp":
                        break;
                    case "menuHelpHelp":
                        break;
                    case "menuHelpAbout":
                        break;
                }
            }
        }
        
        private void ResetStatusBar()
        {
            if (this.ssApp.Visible)
            {
                this.UpdStatusBarWnd();
                string strText = m_Settings.LocalizationTable.GetMessage("App80");
                if (strText == "")
                    this.UpdStatusBarInfo("...Ready...");
                else this.UpdStatusBarInfo(strText);
            }
        }

        private void SetVersionInfo()
        {
            Version versionInfo = Assembly.GetExecutingAssembly().GetName().Version;
            DateTime dtStart = new DateTime(2000, 1, 1);
            int nDiffDays = versionInfo.Build;
            DateTime dtComputed = dtStart.AddDays(nDiffDays);
            string strLastBuild = dtComputed.ToShortDateString();
            this.Text = string.Format("{0} - Version {1} ({2})", this.Text, versionInfo.ToString(), strLastBuild);
        }

        private void NIY()
        // Not Implement Yet
        {
            string strText = m_Settings.LocalizationTable.GetMessage("App79");
            if (strText == "")
                MessageBox.Show("Not Implemented Yet");
            else MessageBox.Show(strText);
        }

      }
}



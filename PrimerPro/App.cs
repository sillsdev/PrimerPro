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
        private LocalizationTable m_LocalizationTable;      //Localization Table for En/Fr
  
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
        private const string kLocalizationName = "PrimerProLocalization.xml";
        private const string kDefaultFontName = "Arial";

		private System.Windows.Forms.MainMenu mainMenu1;
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
            m_ViewCntr = 0;					             //Window (active document) counter
            m_SearchCntr = 0;				            //Search counter 
            m_SearchList = new ArrayList();	            //List of active searches
            m_PSTFileName = "";

            //Load localization file
            string strMsg = "";
            string strFilePath = m_Settings.GetAppFolder() + AppWindow.kBackSlash +
                AppWindow.kLocalizationName;
            m_LocalizationTable = new LocalizationTable();
            if (m_LocalizationTable.LoadFromFile(strFilePath))
                m_Settings.LocalizationTable = m_LocalizationTable;

            if (Environment.GetEnvironmentVariable(AppWindow.kPrimerPro,
                EnvironmentVariableTarget.User) != null)
            {
                strProj = Environment.GetEnvironmentVariable(AppWindow.kPrimerPro, EnvironmentVariableTarget.User);
                this.ProjInfo.BuildProjectInfo(strProj);
                if (File.Exists(this.ProjInfo.FileName))
                {
                    if (this.ProjInfo.LoadInfo(this.ProjInfo.FileName))
                    {
                        pWindow.Text = AppWindow.kPrimerPro + " - " + m_ProjInfo.ProjectName;
                        this.SetupProject();
                        this.Settings.LocalizationTable = m_LocalizationTable;
                        //MessageBox.Show(m_ProjInfo.ProjectName + 
                        //    " Project has been loaded", AppWindow.kPrimerPro);
                        strMsg = m_LocalizationTable.GetMessage("App1", m_Settings.OptionSettings.UILanguage);
                        MessageBox.Show(m_ProjInfo.ProjectName + Constants.Space + strMsg,
                            AppWindow.kPrimerPro);
                    }
                    else
                    {
                        //MessageBox.Show(m_ProjInfo.ProjectName +
                        //    " Project has failed to load! You will need to create or select a project",
                        //    AppWindow.kPrimerPro);
                        strMsg = m_LocalizationTable.GetMessage("App2", m_Settings.OptionSettings.UILanguage);
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
                    strMsg = m_ProjInfo.ProjectName + 
                        m_LocalizationTable.GetMessage("App3", m_Settings.OptionSettings.UILanguage);
                    MessageBox.Show(strMsg, AppWindow.kPrimerPro);
                    m_ProjInfo = new ProjectInfo();
                    Environment.SetEnvironmentVariable(AppWindow.kPrimerPro, "", EnvironmentVariableTarget.User);
                }
            }
            else
            {
                //MessageBox.Show("Project does not exist!  You will need to create or select a project",
                //    AppWindow.kPrimerPro);
                strMsg = m_LocalizationTable.GetMessage("App3", m_Settings.OptionSettings.UILanguage);
                MessageBox.Show(strMsg, AppWindow.kPrimerPro);
                if (File.Exists(m_ProjInfo.OptionsFile))
                    m_Settings.LoadOptions();
                else
                {
                    OptionList ol = new OptionList(m_ProjInfo.PrimerProFolder, m_ProjInfo.OptionsFile,
                        m_LocalizationTable, m_Settings.OptionSettings.UILanguage);
                    m_Settings.OptionSettings = ol;
                }

                string strFileName = m_Settings.GetAppFolder() + AppWindow.kBackSlash +
                    AppWindow.kDefaultPSTableName;
                PSTable pst = new PSTable(m_Settings);
                if (pst.LoadFromFile(strFileName))
                    m_Settings.PSTable = pst;
                else m_Settings.PSTable = new PSTable(m_Settings);
            }

            //Update main menu
            UpdateMenuForLanguage(m_Settings.OptionSettings.UILanguage);
            if (this.Settings.OptionSettings.SimplifiedMenu)
                UpdateMenuForSimplified();

            //Open new active document (window) - No longer needed as this is done in the SetupProject routine
            //AppView mdiChild = new AppView(pWindow, "");
            //m_ViewCntr++;
            //mdiChild.Text = strApp + m_ViewCntr.ToString();
            //mdiChild.MdiParent = this;
            //mdiChild.Show();

            //Update status bar
            this.UpdStatusBarTD();
            this.UpdStatusBarWL();
            this.UpdStatusBarWnd();
            this.UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App80",
                m_Settings.OptionSettings.UILanguage));

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
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
            this.ssApp.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
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
            this.menuSearchTextOrder});
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
            this.menuHelpAbout.Index = 4;
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
            // AppWindow
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(942, 563);
            this.Controls.Add(this.ssApp);
            this.Controls.Add(this.tbApp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Menu = this.mainMenu1;
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

		}

		private void AppWindow_Closed(object sender, System.EventArgs e)
		//Save information for future use
		{
            // Remember current project
            if (this.ProjInfo.ProjectName != "")
            {
                this.SaveProject();
                Environment.SetEnvironmentVariable(AppWindow.kPrimerPro, this.ProjInfo.ProjectName,
                    EnvironmentVariableTarget.User);
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
            //else MessageBox.Show("No active document to save");
            else MessageBox.Show(m_LocalizationTable.GetMessage("App5", m_Settings.OptionSettings.UILanguage));
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
            else MessageBox.Show(m_LocalizationTable.GetMessage("App5", m_Settings.OptionSettings.UILanguage));
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
                MessageBox.Show(m_LocalizationTable.GetMessage("App6", m_Settings.OptionSettings.UILanguage));
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
                    string strFilePath = m_Settings.GetAppFolder() + AppWindow.kBackSlash +
                        AppWindow.kLocalizationName;
                    m_LocalizationTable = new LocalizationTable();
                    if (m_LocalizationTable.LoadFromFile(strFilePath))
                        m_Settings.LocalizationTable = m_LocalizationTable;
                    
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
                    this.Settings.OptionSettings.SaveOptionList(m_ProjInfo.OptionsFile);	//Save options to xml file

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
                else MessageBox.Show(m_LocalizationTable.GetMessage("App7", m_Settings.OptionSettings.UILanguage));
            }
            this.UpdStatusBarTD();
            this.UpdStatusBarWL();
            this.UpdStatusBarWnd();
            this.UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App80",
                m_Settings.OptionSettings.UILanguage));
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
                    this.UpdateMenuForLanguage(m_Settings.OptionSettings.UILanguage);
                    if (this.Settings.OptionSettings.SimplifiedMenu)
                        this.UpdateMenuForSimplified();
                    //MessageBox.Show(m_ProjInfo.ProjectName + " has been loaded");
                    strMsg = m_LocalizationTable.GetMessage("App1", m_Settings.OptionSettings.UILanguage);
                    MessageBox.Show(m_ProjInfo.ProjectName + Constants.Space + strMsg);
                }
                //else MessageBox.Show(m_ProjInfo.ProjectName + " has failed to load");
                else 
                {
                    strMsg = m_LocalizationTable.GetMessage("App2", m_Settings.OptionSettings.UILanguage);
                    MessageBox.Show(m_ProjInfo.ProjectName + Constants.Space + strMsg);
                }
            }
            //else MessageBox.Show("Project not selected");
            else
            {
                strMsg = m_LocalizationTable.GetMessage("App8", m_Settings.OptionSettings.UILanguage);
                MessageBox.Show(strMsg);
            }
            this.UpdStatusBarTD();
            this.UpdStatusBarWL();
            this.UpdStatusBarWnd();
            this.UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App80",
                m_Settings.OptionSettings.UILanguage));
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
                    strMsg = m_LocalizationTable.GetMessage("App121", m_Settings.OptionSettings.UILanguage);
                    MessageBox.Show(strProjName + Constants.Space + strMsg);
                    
                }
                //else MessageBox.Show("Project not found");
                else
                {
                    strMsg = m_LocalizationTable.GetMessage("App122", m_Settings.OptionSettings.UILanguage);
                    MessageBox.Show(strMsg);
                }
                
            }
            //else MessageBox.Show("Project not deleted");
            else
            {
                strMsg = m_LocalizationTable.GetMessage("App123", m_Settings.OptionSettings.UILanguage);
                MessageBox.Show(strMsg);
            }

            if (this.ProjInfo.ProjectName != "")
                this.ProjInfo.LoadInfo(this.ProjInfo.FileName);   //Restore current project
 
            this.UpdStatusBarTD();
            this.UpdStatusBarWL();
            this.UpdStatusBarWnd();
            this.UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App80",
                m_Settings.OptionSettings.UILanguage));
            this.ResetStatusBar();
        }

        private void menuFileProjExport_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuFileProjExport.Text.Replace("&", ""));
            string strMsg = "";

            FormProjectExport form = new FormProjectExport(m_Settings.OptionSettings.DataFolder,
                m_Settings.OptionSettings.TemplateFolder, m_Settings.LocalizationTable,
                m_Settings.OptionSettings.UILanguage);
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
                                    strMsg = m_Settings.LocalizationTable.GetMessage("App11",
                                        m_Settings.OptionSettings.UILanguage);
                                    MessageBox.Show(strMsg);
                                }
                                else MessageBox.Show("Write Package List error");
                            }
                            //else MessageBox.Show("Export folder can not be the same as the template folder");
                            else
                            {
                                strMsg = m_Settings.LocalizationTable.GetMessage("App12",
                                    m_Settings.OptionSettings.UILanguage);
                                MessageBox.Show(strMsg);
                            }
                        }
                        //else MessageBox.Show("Export folder can not be the same as the data folder");
                        else
                        {
                            strMsg = m_Settings.LocalizationTable.GetMessage("App13",
                                m_Settings.OptionSettings.UILanguage);
                            MessageBox.Show(strMsg);
                        }
                    }
                    //else MessageBox.Show("Export folder does not exist");
                    else
                    {
                        strMsg = m_Settings.LocalizationTable.GetMessage("App14",
                            m_Settings.OptionSettings.UILanguage);
                        MessageBox.Show(strMsg);
                    }
                }
                //else MessageBox.Show("Export folder not specified - project not exported");
                else
                {
                    strMsg = m_Settings.LocalizationTable.GetMessage("App15",
                        m_Settings.OptionSettings.UILanguage);
                    MessageBox.Show(strMsg);
                }
            }
            //else MessageBox.Show("Project not exported or backed up");
            else
            {
                strMsg = m_Settings.LocalizationTable.GetMessage("App16",
                    m_Settings.OptionSettings.UILanguage);
                MessageBox.Show(strMsg);
            }

            this.UpdStatusBarTD();
            this.UpdStatusBarWL();
            this.UpdStatusBarWnd();
            this.UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App80",
                m_Settings.OptionSettings.UILanguage));
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
            FormProjectImport form = new FormProjectImport(m_Settings, m_Settings.LocalizationTable,
                m_Settings.OptionSettings.UILanguage);
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

                                    ol.SaveOptionList(strOptionsFile);

                                    string strProjectFile = m_Settings.OptionSettings.PrimerProFolder +
                                        AppWindow.kBackSlash + pl.ProjectFile;
                                    ProjectInfo info = new ProjectInfo();
                                    info.BuildProjectInfo(pl.ProjectName);
                                    info.SaveInfo(strProjectFile);

                                    // If restored project is current project,  set it up again
                                    if (this.Settings.ProjInfo.ProjectName == pl.ProjectName)
                                        this.SetupProject();
 
                                    //MessageBox.Show("Project has been Imported");
                                    strMsg = m_Settings.LocalizationTable.GetMessage("App17",
                                        m_Settings.OptionSettings.UILanguage);
                                    MessageBox.Show(strMsg);
                                }
                                //else MessageBox.Show("Project was not imported");
                                else
                                {
                                    strMsg = m_Settings.LocalizationTable.GetMessage("App18",
                                        m_Settings.OptionSettings.UILanguage);
                                    MessageBox.Show(strMsg);
                                }
                            }
                            //else MessageBox.Show("Packaging List not found in From folder - Project was not imported");
                            else
                            {
                                strMsg = m_Settings.LocalizationTable.GetMessage("App19",
                                m_Settings.OptionSettings.UILanguage);
                                MessageBox.Show(strMsg);
                            }
                        }
                        //else MessageBox.Show("From folder does not exist");
                        else
                        {
                            strMsg = m_Settings.LocalizationTable.GetMessage("App21",
                                m_Settings.OptionSettings.UILanguage);
                            MessageBox.Show(strMsg);
                        }
                    }
                    //else MessageBox.Show("To Folder not specified - project not imported");
                    else
                    {
                        strMsg = m_Settings.LocalizationTable.GetMessage("App22",
                            m_Settings.OptionSettings.UILanguage);
                        MessageBox.Show(strMsg);
                    }
                }
                //else MessageBox.Show("From folder not specified - project not imported");
                else
                {
                    strMsg = m_Settings.LocalizationTable.GetMessage("App23",
                        m_Settings.OptionSettings.UILanguage);
                    MessageBox.Show(strMsg);
                }
            }
            //else MessageBox.Show("Project not imported or restored");
            else
            {
                strMsg = m_Settings.LocalizationTable.GetMessage("App24",
                    m_Settings.OptionSettings.UILanguage);
                MessageBox.Show(strMsg);
            }

            this.UpdStatusBarTD();
            this.UpdStatusBarWL();
            this.UpdStatusBarWnd();
            this.UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App80",
                m_Settings.OptionSettings.UILanguage));
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
                    strMsg = m_Settings.LocalizationTable.GetMessage("App25",
                        m_Settings.OptionSettings.UILanguage);
                    MessageBox.Show(strMsg + " - " + ex.Message);
                }
            }
            //else MessageBox.Show("No active document to print");
            else
            {
                strMsg = m_Settings.LocalizationTable.GetMessage("App26",
                    m_Settings.OptionSettings.UILanguage);
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
                    strMsg = m_Settings.LocalizationTable.GetMessage("App27",
                        m_Settings.OptionSettings.UILanguage);
                    MessageBox.Show(strMsg + " - " + ex.Message);
                }
			}
            //else MessageBox.Show("No active document to preview");
            else
            {
                strMsg = m_Settings.LocalizationTable.GetMessage("App28",
                    m_Settings.OptionSettings.UILanguage);
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
                string strMsg = m_Settings.LocalizationTable.GetMessage("App29",
                    m_Settings.OptionSettings.UILanguage);
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App30",
                m_Settings.OptionSettings.UILanguage));
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App30",
                m_Settings.OptionSettings.UILanguage));
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App30",
                m_Settings.OptionSettings.UILanguage));
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App30",
                m_Settings.OptionSettings.UILanguage));
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App30",
                m_Settings.OptionSettings.UILanguage));
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App30",
                m_Settings.OptionSettings.UILanguage));
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App30",
                m_Settings.OptionSettings.UILanguage));
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App30",
                m_Settings.OptionSettings.UILanguage));
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
            FormSearchInsertionMode form = new FormSearchInsertionMode(m_Settings.SearchInsertionResults,
                m_Settings.SearchInsertionDefinitions, m_Settings.LocalizationTable,
                m_Settings.OptionSettings.UILanguage);
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
            strText = m_Settings.LocalizationTable.GetMessage("App82",
                m_Settings.OptionSettings.UILanguage) + Environment.NewLine;
			strText += Environment.NewLine;
			strText += wl.GetDisplayHeadings();
            strRtf = mdiChild.FormatWordList(strText);
            mdiChild.Display(strRtf);

			ArrayList alText = wl.RetrieveWordListAsArray();
            strRtf = mdiChild.FormatWordList(alText);
            mdiChild.Display(strRtf);

            strText = "";
            strText += Environment.NewLine;
            //strText += wl.WordCount() + " words in list" + Environment.NewLine;
            strText += wl.WordCount().ToString() + Constants.Space
                + m_Settings.LocalizationTable.GetMessage("App83", m_Settings.OptionSettings.UILanguage);
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
            strText = m_Settings.LocalizationTable.GetMessage("App84",
                m_Settings.OptionSettings.UILanguage) + Environment.NewLine;
            strRtf = mdiChild.FormatText(strText, false);
            mdiChild.Display(strRtf);

            strText = td.BuildTextDataAsString();
            strRtf = mdiChild.FormatText(strText, false);
            mdiChild.Display(strRtf);

            strText =  "";
            //strText += td.ParagraphCount() + " paragraphs in data" + Environment.NewLine;
            //strText += td.SentenceCount() + " sentences in data" + Environment.NewLine;
            //strText += td.WordCount() + " words in data" + Environment.NewLine;
            strText += td.ParagraphCount().ToString() + Constants.Space +
                m_Settings.LocalizationTable.GetMessage("App85", m_Settings.OptionSettings.UILanguage) +
                Environment.NewLine;
            strText += td.SentenceCount().ToString() + Constants.Space +
                m_Settings.LocalizationTable.GetMessage("App86", m_Settings.OptionSettings.UILanguage) +
                Environment.NewLine;
            strText += td.WordCount().ToString() + Constants.Space +
                m_Settings.LocalizationTable.GetMessage("App87", m_Settings.OptionSettings.UILanguage) +
                Environment.NewLine;
            strText += Environment.NewLine;
            strRtf = mdiChild.FormatText(strText, false);
            mdiChild.Display(strRtf);
            this.ResetStatusBar();
        }

        private void menuViewInventory_Click(object sender, EventArgs e)
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

            //strText = "Grapheme Inventory - Consonants" + Environment.NewLine;
            strText = m_Settings.LocalizationTable.GetMessage("App88",
                m_Settings.OptionSettings.UILanguage) + Environment.NewLine;
            strText += Environment.NewLine;
            strText += m_GraphemeInventory.RetrieveSortedConsonants();
            strText += Environment.NewLine;
            strText += m_GraphemeInventory.ConsonantCount();
            //" consonants in inventory";
            strText += Constants.Space;
            strText += m_Settings.LocalizationTable.GetMessage("App89",
                m_Settings.OptionSettings.UILanguage);
            strText += Environment.NewLine;
            strText += Environment.NewLine;
            
            //strText += "Grapheme Inventory - Vowels" + Environment.NewLine;
            strText += m_Settings.LocalizationTable.GetMessage("App90",
                m_Settings.OptionSettings.UILanguage) + Environment.NewLine;
            strText += Environment.NewLine;
            strText += m_GraphemeInventory.RetrieveSortedVowels();
            strText += Environment.NewLine;
            strText += m_GraphemeInventory.VowelCount();
            strText += Constants.Space;
            //" vowels in inventory";
            strText += m_Settings.LocalizationTable.GetMessage("App91",
                m_Settings.OptionSettings.UILanguage);
            strText += Environment.NewLine;
            strText += Environment.NewLine;
            
            //strText += "Grapheme Inventory - Tones" + Environment.NewLine;
            strText += m_Settings.LocalizationTable.GetMessage("App92",
                m_Settings.OptionSettings.UILanguage) + Environment.NewLine;
            strText += Environment.NewLine;
            strText += m_GraphemeInventory.RetrieveSortedTones();
            strText += Environment.NewLine;
            strText += m_GraphemeInventory.ToneCount();
            strText += Constants.Space;
            //" tones in inventory";
            strText += m_Settings.LocalizationTable.GetMessage("App93",
                m_Settings.OptionSettings.UILanguage);
            strText += Environment.NewLine;
            strText += Environment.NewLine;

            //strText += "Grapheme Inventory - Syllographs" + Environment.NewLine;
            strText += m_Settings.LocalizationTable.GetMessage("App119",
                m_Settings.OptionSettings.UILanguage) + Environment.NewLine;
            strText += Environment.NewLine;
            strText += m_GraphemeInventory.RetrieveSortedSyllographs();
            strText += Environment.NewLine;
            strText += m_GraphemeInventory.SyllographCount();
            strText += Constants.Space;
            //" syllographs in inventory";
            strText += m_Settings.LocalizationTable.GetMessage("App120",
                m_Settings.OptionSettings.UILanguage);
            strText += Environment.NewLine;

            strRtf = mdiChild.FormatGraphemes(strText);
            mdiChild.Display(strRtf);
			this.ResetStatusBar();
		}

		private void menuViewPS_Click(object sender, System.EventArgs e)
		{
			string strText = "";
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
            strText = m_Settings.LocalizationTable.GetMessage("App94",
                m_Settings.OptionSettings.UILanguage) + Environment.NewLine;
            strText += Environment.NewLine;
            strText += pst.RetrieveSortedTable();
            strText += Environment.NewLine;
            strText += pst.Count();
            strText += Constants.Space;
            //" entries" + Environment.NewLine;
            strText += m_Settings.LocalizationTable.GetMessage("App95",
                m_Settings.OptionSettings.UILanguage) + Environment.NewLine;
            strText += Environment.NewLine;
            strRtf = mdiChild.FormatTable(strText);
            mdiChild.Display(strRtf);
 			this.ResetStatusBar();
		}

		private void menuViewSite_Click(object sender, System.EventArgs e)
		{
			string strText = "";
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
            strText = m_Settings.LocalizationTable.GetMessage("App96",
                m_Settings.OptionSettings.UILanguage) + Environment.NewLine;
            strText += Environment.NewLine;
            strText += sw.RetrieveSortedTable();
            strText += Environment.NewLine;
            strText += sw.Count().ToString();
            strText += Constants.Space;
            //" entries" + Environment.NewLine;
            strText += m_Settings.LocalizationTable.GetMessage("App95",
                m_Settings.OptionSettings.UILanguage) + Environment.NewLine;
            strText += Environment.NewLine;
            strRtf = mdiChild.FormatTable(strText);
            mdiChild.Display(strRtf);
 			this.ResetStatusBar();
		}

        private void menuViewGraphemes_Click(object sender, EventArgs e)
        {
            string strText = "";
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
            strText = m_Settings.LocalizationTable.GetMessage("App97",
                m_Settings.OptionSettings.UILanguage) + Environment.NewLine;
            strText += Environment.NewLine;
            strText += gto.RetrieveGraphemes();
            strText += Environment.NewLine;
            strText += gto.Count().ToString();
            strText += Constants.Space;
            //" entries" + Environment.NewLine;
            strText += m_Settings.LocalizationTable.GetMessage("App95",
                m_Settings.OptionSettings.UILanguage) + Environment.NewLine;
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
                string strMsg = m_Settings.LocalizationTable.GetMessage("App31",
                    m_Settings.OptionSettings.UILanguage);
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
                string strMsg = m_Settings.LocalizationTable.GetMessage("App31",
                    m_Settings.OptionSettings.UILanguage);
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
                string strMsg = m_Settings.LocalizationTable.GetMessage("App31",
                    m_Settings.OptionSettings.UILanguage);
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
                string strMsg = m_Settings.LocalizationTable.GetMessage("App32",
                    m_Settings.OptionSettings.UILanguage);
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
                string strMsg = m_Settings.LocalizationTable.GetMessage("App32",
                    m_Settings.OptionSettings.UILanguage);
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App32",
                m_Settings.OptionSettings.UILanguage));
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
			if ( search.SetupSearch() )
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App10",
                    m_Settings.OptionSettings.UILanguage));
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App10",
                    m_Settings.OptionSettings.UILanguage));
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App10",
                    m_Settings.OptionSettings.UILanguage));
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App10",
                    m_Settings.OptionSettings.UILanguage));
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App10",
                    m_Settings.OptionSettings.UILanguage));
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
					if ( this.Settings.SearchInsertionResults )
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App10",
                    m_Settings.OptionSettings.UILanguage));
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
					if ( this.Settings.SearchInsertionResults )
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App10",
                   m_Settings.OptionSettings.UILanguage));
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
					if ( this.Settings.SearchInsertionResults )
					{
						WordList wl = this.Settings.WordList;
						m_SearchList.Add(search);	//Add search to List for future use
						search = search.ExecuteSyllableChart(wl);;
						strText = search.BuildResults();
					}
				}
			
				strRtf = mdiChild.FormatChart(strText);
				mdiChild.Display(strRtf);
			}
            //else MessageBox.Show("Search cancel");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App10",
                    m_Settings.OptionSettings.UILanguage));
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
					if ( this.Settings.SearchInsertionResults )
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App10",
                    m_Settings.OptionSettings.UILanguage));
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App10",
                    m_Settings.OptionSettings.UILanguage));
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
					if ( this.Settings.SearchInsertionResults )
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App10",
                    m_Settings.OptionSettings.UILanguage));
            this.ResetStatusBar();
		}

        private void menuSearchWordGeneral_Click(object sender, System.EventArgs e)
        {
            m_SearchCntr++;
            string strText = "";
            string strRtf = "";

            UpdStatusBarInfo(menuSearchWordGeneral.Text.Replace("&", ""));
            AppView mdiChild = (AppView)this.ActiveMdiChild;
            GeneralSearch search = new GeneralSearch(m_SearchCntr, m_Settings);
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
                            search =search.ExecuteGeneralSearch(wl);
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App10",
                    m_Settings.OptionSettings.UILanguage));
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App10",
                    m_Settings.OptionSettings.UILanguage));
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App10",
                    m_Settings.OptionSettings.UILanguage));
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
					if ( this.Settings.SearchInsertionResults )
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App10",
                    m_Settings.OptionSettings.UILanguage));
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App10",
                    m_Settings.OptionSettings.UILanguage));
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App10",
                    m_Settings.OptionSettings.UILanguage));
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
					if ( this.Settings.SearchInsertionResults )
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App10",
                    m_Settings.OptionSettings.UILanguage));
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
                                    MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App33",
                                        m_Settings.OptionSettings.UILanguage));
                                    return;
                                }
                            }
                            else
                            {
                                //MessageBox.Show("Search cancel: Story file was not specified");
                                MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App34",
                                    m_Settings.OptionSettings.UILanguage));

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
					if ( this.Settings.SearchInsertionResults )
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
                                    MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App98",
                                        m_Settings.OptionSettings.UILanguage));
                                    return;
                                }
                            }
                            else
                            {
                                //MessageBox.Show("Search cancel: Text Data file was not specified");
                                MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App99",
                                    m_Settings.OptionSettings.UILanguage));
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App10",
                    m_Settings.OptionSettings.UILanguage));
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App10",
                    m_Settings.OptionSettings.UILanguage));
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App10",
                    m_Settings.OptionSettings.UILanguage));
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App10",
                    m_Settings.OptionSettings.UILanguage));
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App10",
                    m_Settings.OptionSettings.UILanguage));
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App10",
                    m_Settings.OptionSettings.UILanguage));
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App10",
                    m_Settings.OptionSettings.UILanguage));
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App10",
                    m_Settings.OptionSettings.UILanguage));
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App10",
                    m_Settings.OptionSettings.UILanguage));
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App10",
                    m_Settings.OptionSettings.UILanguage));
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App10",
                    m_Settings.OptionSettings.UILanguage));
            this.ResetStatusBar();
        }

        private void menuToolsWordImportSF_Click(object sender, System.EventArgs e)
		{
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
                MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App35",
                    m_Settings.OptionSettings.UILanguage));

			}
            //else MessageBox.Show("Word List not imported");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App36",
                m_Settings.OptionSettings.UILanguage));
            this.ResetStatusBar();
		}

        private void menuToolsWordImportLIFT_Click(object sender, System.EventArgs e)
        {
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
                MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App35",
                    m_Settings.OptionSettings.UILanguage));

            }
            //else MessageBox.Show("Word List not imported");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App36",
                m_Settings.OptionSettings.UILanguage));
            this.ResetStatusBar();
        }

        private void menuToolsWordMerge_Click(object sender, System.EventArgs e)
        {
            UpdStatusBarInfo(menuToolsWordMerge.Text.Replace("&", ""));
            WordList wl = this.Settings.WordList;
            char chDuplicateProcessing = WordList.kKeepBoth;
            string strFileName = "";

            if (wl.Type == WordList.FileType.Lift)
                //MessageBox.Show("Cannot merge to a Lift file");
                MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App37",
                    m_Settings.OptionSettings.UILanguage));
            else
            {
                if (wl.WordCount() > 0)           //if there is a word list
                {
                    string strFolder = this.Settings.OptionSettings.DataFolder;
                    //FormMergeWordList fpb = new FormMergeWordList(strFolder);
                    FormMergeWordList form = new FormMergeWordList(strFolder,
                        m_Settings.LocalizationTable, m_Settings.OptionSettings.UILanguage);
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
                            MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App38",
                                m_Settings.OptionSettings.UILanguage));

                        }
                        //else MessageBox.Show("Word List not merged");
                        else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App39",
                            m_Settings.OptionSettings.UILanguage));
                    }
                    //else MessageBox.Show("Merged cancelled");
                    else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App40",
                        m_Settings.OptionSettings.UILanguage));
                }
                //else MessageBox.Show("Need to import a Word List first");
                else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App41",
                    m_Settings.OptionSettings.UILanguage));
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
                MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App42",
                    m_Settings.OptionSettings.UILanguage));
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
                MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App43",
                    m_Settings.OptionSettings.UILanguage));
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
                    MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App44",
                        m_Settings.OptionSettings.UILanguage));
                }
                else
                {
                    wl = null;
                    this.Settings.WordList = wl;
                    this.Settings.OptionSettings.WordListFile = "";
                    //MessageBox.Show("Failed to reimport Word List file");
                    MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App45",
                        m_Settings.OptionSettings.UILanguage));
                }
            }
            else
            {
                //MessageBox.Show("Word List File is not specified");
                MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App46",
                    m_Settings.OptionSettings.UILanguage));
                return;
            }
            this.ResetStatusBar();
        }

        private void menuToolsWordExport_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuToolsWordExport.Text.Replace("&", ""));
            WordList wl = this.Settings.WordList;
            if (wl.Type == WordList.FileType.Lift)
                //MessageBox.Show("Cannot export a Lift file");
                MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App47",
                    m_Settings.OptionSettings.UILanguage));
            else
            {
                if (wl.SaveAs(this.Settings.OptionSettings.DataFolder))
                {
                    this.Settings.WordList = wl;
                    this.Settings.WordList.FileName = wl.FileName;
                    this.Settings.OptionSettings.WordListFile = wl.SFFile.FileName;
                    UpdStatusBarWL();
                    //MessageBox.Show("Current Word List exported");
                    MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App48",
                        m_Settings.OptionSettings.UILanguage));
                }
                //else MessageBox.Show("Word List not exported");
                else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App49",
                    m_Settings.OptionSettings.UILanguage));
            }
			this.ResetStatusBar();
		}

        private void menuToolsWordUnload_Click(object sender, System.EventArgs e)
        {
            UpdStatusBarInfo(menuToolsWordUnload.Text.Replace("&", ""));
            WordList wl = this.Settings.WordList;
            if (wl != null)
            {
                if (wl.FileName != "")
                {
                    this.Settings.WordList = new WordList(m_Settings);
                    this.Settings.OptionSettings.WordListFile = "";
                    this.Settings.OptionSettings.WordListFileType = WordList.FileType.None;
                    UpdStatusBarWL();
                    //MessageBox.Show("Current Word List unloaded");
                    MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App50",
                        m_Settings.OptionSettings.UILanguage));
                }
                //else MessageBox.Show("Word List already unloaded");
                else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App51",
                    m_Settings.OptionSettings.UILanguage));
            }
            //else MessageBox.Show("Word List already unloaded");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App51",
                m_Settings.OptionSettings.UILanguage));
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
            strText = m_Settings.LocalizationTable.GetMessage("App100",
                m_Settings.OptionSettings.UILanguage);
			strText += System.Environment.NewLine;
			strText += System.Environment.NewLine;
            strResults = wl.GetMissingGraphemes();
            if (strResults == "")
                //strText += "None";
                strText = m_Settings.LocalizationTable.GetMessage("App101",
                    m_Settings.OptionSettings.UILanguage);
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
			td = td.Load(strFolder);
			if (td != null)
			{
				this.Settings.TextData = td;
				this.Settings.OptionSettings.TextDataFile = td.FileName;
                UpdStatusBarTD();
                //MessageBox.Show("Text Data imported");
                MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App52",
                    m_Settings.OptionSettings.UILanguage));
			}
            //else MessageBox.Show("Text Data not imported");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App53",
                m_Settings.OptionSettings.UILanguage));
            this.ResetStatusBar();
		}

		private void menuToolsTextMerge_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuToolsTextMerge.Text.Replace("&", ""));
			TextData td = this.Settings.TextData;
			String strFolder = this.Settings.OptionSettings.DataFolder;
			td = td.Merge(strFolder);
			if (td.FileName == TextData.kMergeTextData)
			{
				this.Settings.TextData = td;
				this.Settings.OptionSettings.TextDataFile = td.FileName;
                UpdStatusBarTD();
                //MessageBox.Show("Text Data merged");
                MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App54",
                    m_Settings.OptionSettings.UILanguage));
			}
            //else MessageBox.Show("Text Data not merged");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App55",
                m_Settings.OptionSettings.UILanguage));
            this.ResetStatusBar();
		}

		private void menuToolsTextExport_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuToolsTextExport.Text.Replace("&", ""));
			bool flag = false;
			TextData td = this.Settings.TextData;
			flag = td.Save(this.Settings.OptionSettings.DataFolder);
			if (flag)
			{
				this.Settings.TextData = td;
				this.Settings.OptionSettings.TextDataFile = td.FileName;
                UpdStatusBarTD();
                //MessageBox.Show("Current Text Data exported");
                MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App56",
                    m_Settings.OptionSettings.UILanguage));
			}
            //else MessageBox.Show("Text Data not exported");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App57",
                m_Settings.OptionSettings.UILanguage));
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
                MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App58",
                    m_Settings.OptionSettings.UILanguage));
            }
            else
            {
                td = null;
                this.Settings.TextData = td;
                this.Settings.OptionSettings.TextDataFile = "";
                //MessageBox.Show("Failed to reimport Text Data file");
                MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App59",
                    m_Settings.OptionSettings.UILanguage));
            }
            this.ResetStatusBar();
        }

        private void menuToolsTextUnload_Click(object sender, System.EventArgs e)
        {
            UpdStatusBarInfo(menuToolsTextUnload.Text.Replace("&", ""));
            TextData td = this.Settings.TextData;
            if (td != null)
            {
                if (td.FileName != "")
                {
                    this.Settings.TextData = new TextData(m_Settings);
                    this.Settings.OptionSettings.TextDataFile = "";
                    UpdStatusBarTD();
                    //MessageBox.Show("Current Text Data unloaded");
                    MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App60",
                        m_Settings.OptionSettings.UILanguage));
                }
                //else MessageBox.Show("Text Data already unloaded");
                else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App61",
                    m_Settings.OptionSettings.UILanguage));
            }
            //else MessageBox.Show("Text Data already unloaded");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App61",
               m_Settings.OptionSettings.UILanguage));
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
            strText = m_Settings.LocalizationTable.GetMessage("App102",
                m_Settings.OptionSettings.UILanguage);
			strText += System.Environment.NewLine;
			strText += System.Environment.NewLine;
            strResults = td.GetMissingGraphemes();
            if (strResults == "")
                //strText += "None";
                strText = m_Settings.LocalizationTable.GetMessage("App101",
                    m_Settings.OptionSettings.UILanguage);
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
            strText = m_Settings.LocalizationTable.GetMessage("App103",
                m_Settings.OptionSettings.UILanguage);
            strText += System.Environment.NewLine;
			strText += System.Environment.NewLine;
			strResults = td.GetMissingWords();
			if (strResults == "")
                //strText += "None";
                strText = m_Settings.LocalizationTable.GetMessage("App101",
                    m_Settings.OptionSettings.UILanguage);
            else strText += strResults;
			strRtf = mdiChild.FormatWordList(strText);
			mdiChild.Display(strRtf);
			this.ResetStatusBar();
		}

        private void menuToolsTextBuildWL_Click(object sender, System.EventArgs e)
        {
            UpdStatusBarInfo(menuToolsTextBuildWL.Text.Replace("&", ""));
            AppView mdiChild = (AppView)this.ActiveMdiChild;
            //if (mdiChild == null)
            //{
                TextData td = this.Settings.TextData;
                WordList wl = this.Settings.WordList;
                string strFileName = "";
                if (td.FileName != "")
                {
                    strFileName = GetSaveFileName();
                    if (strFileName != "")
                    {
                        StandardFormatFile sff = td.BuildStandardFormatFile();
                        sff.SaveFile(strFileName);
                        //MessageBox.Show("Built word list saved");
                        MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App62",
                            m_Settings.OptionSettings.UILanguage));
                    }
                }
                //else MessageBox.Show("Need import to text data first");
                else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App63",
                    m_Settings.OptionSettings.UILanguage));
            //}
            ////else MessageBox.Show("Need to open a new active document");
            //else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App31",
            //    m_Settings.OptionSettings.UILanguage));
            //this.ResetStatusBar();
        }

        private void menuToolsInventoryInitWL_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuToolsInventoryInit.Text.Replace("&", ""));
            if (this.Settings.GraphemeInventory.GraphemeCount() > 0)
            {
                string StrCount = this.Settings.GraphemeInventory.GraphemeCount().ToString();
                //string strMsg = "The GraphemeInventory has" + StrCount + " graphemes.  Are you sure you want to clear it?";
                //string strCaption = "Initialize Grapheme Inventory";
                string strMsg = m_Settings.LocalizationTable.GetMessage("App126", m_Settings.OptionSettings.UILanguage) +
                    StrCount.PadLeft(5, ' ') + Constants.Space.ToString() + 
                    m_Settings.LocalizationTable.GetMessage("App127", m_Settings.OptionSettings.UILanguage);
                string strCaption = m_Settings.LocalizationTable.GetMessage("App128", m_Settings.OptionSettings.UILanguage);
                if (MessageBox.Show(strMsg, strCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    this.InitGraphemeInventoryWL();
            }
            else this.InitGraphemeInventoryWL();
            this.ResetStatusBar();
        }

        private void menuToolsInventoryInitTD_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuToolsInventoryInit.Text.Replace("&", ""));
            if (this.Settings.GraphemeInventory.GraphemeCount() > 0)
            {
                string StrCount = this.Settings.GraphemeInventory.GraphemeCount().ToString();
                //string strMsg = "The GraphemeInventory has" + StrCount + " graphemes.  Are you sure you want to clear it?";
                //string strCaption = "Initialize Grapheme Inventory";
                string strMsg = m_Settings.LocalizationTable.GetMessage("App126", m_Settings.OptionSettings.UILanguage) +
                    StrCount.PadLeft(5, ' ') + Constants.Space.ToString() +
                    m_Settings.LocalizationTable.GetMessage("App127", m_Settings.OptionSettings.UILanguage);
                string strCaption = m_Settings.LocalizationTable.GetMessage("App128", m_Settings.OptionSettings.UILanguage);
                if (MessageBox.Show(strMsg, strCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    this.InitGraphemeInventoryTD();
            }
            else this.InitGraphemeInventoryTD();
            this.ResetStatusBar();
        }

        private void menuToolsInventoryInitPG_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuToolsInventoryInit.Text.Replace("&", ""));
            if (this.Settings.GraphemeInventory.GraphemeCount() > 0)
            {
                string StrCount = this.Settings.GraphemeInventory.GraphemeCount().ToString();
                //string strMsg = "The GraphemeInventory has " + StrCount + " graphemes.  Are you sure you want to clear it?";
                //string strCaption = "Initialize Grapheme Inventory";
                string strMsg = m_Settings.LocalizationTable.GetMessage("App126", m_Settings.OptionSettings.UILanguage) +
                    StrCount.PadLeft(5, ' ') + Constants.Space.ToString() +
                    m_Settings.LocalizationTable.GetMessage("App127", m_Settings.OptionSettings.UILanguage);
                string strCaption = m_Settings.LocalizationTable.GetMessage("App128", m_Settings.OptionSettings.UILanguage);
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
                //string strMsg = "The GraphemeInventory has " + StrCount + " graphemes.  Are you sure you want to clear it?";
                //string strCaption = "Initialize Syllabary Inventory";
                string strMsg = m_Settings.LocalizationTable.GetMessage("App126", m_Settings.OptionSettings.UILanguage) +
                    StrCount.PadRight(4) +
                    m_Settings.LocalizationTable.GetMessage("App127", m_Settings.OptionSettings.UILanguage);
                string strCaption = m_Settings.LocalizationTable.GetMessage("App129", m_Settings.OptionSettings.UILanguage);
                if (MessageBox.Show(strMsg, strCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    this.InitGraphemeInventorySyllabary();
            }
            else this.InitGraphemeInventorySyllabary();
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
			FormVowelInventory form = new FormVowelInventory(m_Settings);
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
            FormSyllographInventory form = new FormSyllographInventory(m_Settings);
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

            if (dr1 == DialogResult.OK)
            {
                GraphemeInventory gi = Settings.GraphemeInventory;
                string strFileName = sfd1.FileName;
                m_Settings.OptionSettings.GraphemeInventoryFile = strFileName;
                gi.SaveToFile(strFileName);
                gi.FileName = strFileName;
                //MessageBox.Show(strFileName + " saved");
                string strMsg = m_Settings.LocalizationTable.GetMessage("App65",
                    m_Settings.OptionSettings.UILanguage);
                MessageBox.Show(strFileName + Constants.Space + strMsg);
            }
            //else MessageBox.Show("Save cancelled");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App66",
                m_Settings.OptionSettings.UILanguage));
            this.ResetStatusBar();
        }

        private void menuToolsInventoryClear_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuToolsInventoryClear.Text.Replace("&", ""));
            //if (MessageBox.Show("Are you sure?", "Clear Grapheme Inventory", MessageBoxButtons.YesNo,
            //    MessageBoxIcon.Question) == DialogResult.Yes)
            string strMsg = m_Settings.LocalizationTable.GetMessage("App9",
                m_Settings.OptionSettings.UILanguage);
            string strCaption = m_Settings.LocalizationTable.GetMessage("App67",
                m_Settings.OptionSettings.UILanguage);
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
            string strFileName = m_Settings.GetAppFolder() + AppWindow.kBackSlash +
                AppWindow.kDefaultPSTableName;
            if (pst.LoadFromFile(strFileName))
            {
                strFileName = this.Settings.PrimerProFolder + AppWindow.kBackSlash + 
                    AppWindow.kPSTableName;
                pst.SaveToFile(strFileName);
                this.Settings.PSTable = pst;
                //MessageBox.Show("Parts of Speech table has been initialized");
                MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App68",
                    m_Settings.OptionSettings.UILanguage));
            }
            //else MessageBox.Show("Initialization of Parts of Speech failed");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App69",
                m_Settings.OptionSettings.UILanguage));
            this.ResetStatusBar();
        }

        private void menuToolsPartsUpdate_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuToolsPartsUpdate.Text.Replace("&", ""));
            //FormPSTable fpb = new FormPSTable(this.Settings.PSTable);
            FormPSTable form = new FormPSTable(m_Settings.PSTable, m_Settings.LocalizationTable,
                m_Settings.OptionSettings.UILanguage);
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App66",
                m_Settings.OptionSettings.UILanguage));
            this.ResetStatusBar();
        }

        private void menuToolsSightUpdate_Click(object sender, System.EventArgs e)
		{
            UpdStatusBarInfo(menuToolsSightUpdate.Text.Replace("&", ""));
            //FormSightWords fpb = new FormSightWords(this.Settings.SightWords,
            //    this.Settings.OptionSettings.GetDefaultFont());
            FormSightWords form = new FormSightWords(m_Settings.SightWords,
                m_Settings.OptionSettings.GetDefaultFont(), m_Settings.LocalizationTable,
                m_Settings.OptionSettings.UILanguage);
            if (form.ShowDialog(this) == DialogResult.Cancel)
                //MessageBox.Show("Update Sight Words cancelled");
                MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App70",
                    m_Settings.OptionSettings.UILanguage));

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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App66",
                m_Settings.OptionSettings.UILanguage));
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
            strText = m_Settings.LocalizationTable.GetMessage("App104",
                m_Settings.OptionSettings.UILanguage);
	        strText += System.Environment.NewLine;
	        strText += System.Environment.NewLine;
	        strResults = sw.GetMissingWords();
	        if (strResults == "")
                //strText += "None";
                strText = m_Settings.LocalizationTable.GetMessage("App101",
                    m_Settings.OptionSettings.UILanguage);
            else strText += strResults;
	        strRtf = mdiChild.FormatTable(strText);
	        mdiChild.Display(strRtf);
	        this.ResetStatusBar();
		}

        private void menuToolsOrderUpdate_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuToolsOrderUpdate.Text.Replace("&", ""));
            //FormGraphemesTaught fpb = new FormGraphemesTaught(this.Settings.GraphemesTaught,
            //    this.Settings.OptionSettings.GetDefaultFont());
            FormGraphemesTaught form = new FormGraphemesTaught(m_Settings.GraphemesTaught,
                m_Settings.OptionSettings.GetDefaultFont(), m_Settings.LocalizationTable,
                m_Settings.OptionSettings.UILanguage);
            if (form.ShowDialog(this) == DialogResult.Cancel)
                //MessageBox.Show("Update Taught Graphemes cancelled");
                MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App71",
                    m_Settings.OptionSettings.UILanguage));

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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App66",
                m_Settings.OptionSettings.UILanguage));
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
            strText = m_Settings.LocalizationTable.GetMessage("App105",
                m_Settings.OptionSettings.UILanguage);
            strText += System.Environment.NewLine;
            strText += System.Environment.NewLine;
            strResults = gto.GetMissingGraphemes();
            if (strResults == "")
                //strText += "None";
                strText += m_Settings.LocalizationTable.GetMessage("App101",
                    m_Settings.OptionSettings.UILanguage);
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
            this.UpdateMenuForLanguage(m_Settings.OptionSettings.UILanguage);
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App72",
                m_Settings.OptionSettings.UILanguage));
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App125",
                m_Settings.OptionSettings.UILanguage));
            this.ResetStatusBar();
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
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App125",
                m_Settings.OptionSettings.UILanguage));
            this.ResetStatusBar();
        }

        private void menuHelpAbout_Click(object sender, System.EventArgs e)
		{
			UpdStatusBarInfo(menuHelpAbout.Text.Replace("&", ""));
            string strLang = m_Settings.OptionSettings.UILanguage;
			FormAbout form = new FormAbout(m_Settings.LocalizationTable, strLang);
            form.ShowDialog(this);
			this.ResetStatusBar();
		}

		private void menuTest1_Click(object sender, System.EventArgs e)
        //Word list check
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

            DataGridView dgv = new DataGridView();

            
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
        }

        private void menuTest3_Click(object sender, EventArgs e)
        {
            UpdStatusBarInfo(menuViewWordList.Text.Replace("&", ""));
            PackageList pl = new PackageList(m_Settings);
            this.ResetStatusBar();

           
 
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
            int total = 1000;
            int[] numbers = {400, 401,402, 403, 404, 405, 406, 407, 408, 409, 410 , 500, 549, 550, 551, 600};
            foreach (int num in numbers)
            {
                int n = Funct.GetPercentage(num, total);
                MessageBox.Show(num.ToString() + " - " + n.ToString() + "%");
            }
        }

        //Process menu selects		
        private void menuFileNew_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Opens a new active document");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App201",
                m_Settings.OptionSettings.UILanguage));
		}
		
		private void menuFileOpen_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Opens a document and make its active");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App202",
                m_Settings.OptionSettings.UILanguage));
		}

		private void menuFileClose_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Closes the active document");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App203",
                m_Settings.OptionSettings.UILanguage));
		}

		private void menuFileSave_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Saves the active document");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App204",
                m_Settings.OptionSettings.UILanguage));
		}

		private void menuFileAs_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Saves the active document to another file name");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App205",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuFileProjNew_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Create a new project");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App206",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuFileProjSelect_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Select an existing project from list - projects have a prj extension");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App207",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuFileProjDelete_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Delete an existing project from list");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App207A",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuFileProjExport_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Export/backup the current project to the Export subfolder");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App208",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuFileProjImport_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Import/restore a given project from a given folder");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App209",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuFilePrint_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Prints the active document");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App210",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuFilePreview_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Displays the active document");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App211",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuFileSetup_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Set Paper size, orientation and margins");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App212",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuExit_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Exit the application and save the option settings");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App213",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuEditUndo_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Undo the last change made");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App214",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuEditCut_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Move the selected text of the active document to the clipboard");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App215",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuEditCopy_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Copy the selected text of the active document to the clipboard");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App216",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuEditPaste_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Copy the contents of the clipboard to the active document at the insertion point");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App217",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuEditSelect_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Select all of the contents of the active document");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App218",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuEditClear_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Delete all the contents of the active document");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App219",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuEditFind_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Find the first occurrence of a given text in the active document");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App220",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuEditNext_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Find the next occurrence of selected text in the active document");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App221",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuEditReplace_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Replace a given text with another given text in the active document");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App222",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuViewToolbar_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Display the toolbar or not");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App223",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuViewStatus_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Display the status bar or not");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App224",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuViewMode_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Select whether you want search results and/or search definitions to be displayed");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App225",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuViewShow_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Show the search definitions of the processed searchs in active document");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App226",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuViewHide_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Hide the search definitions of the processed searchs in active document");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App227",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuViewClear_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Clear the processed searchs (show only search definitions) in active document");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App228",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuViewUnprocessed_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Process the unprocessed searches in active document");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App229",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuViewWordList_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Display all the words in the word list");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App230",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuViewTextData_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Display the text data in paragraph format");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App231",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuViewInventory_Select(object sender, EventArgs e)
		{
            //UpdStatusBarInfo("Display the lists of consonants, vowels and tones in the inventory");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App232",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuViewPS_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Display a listing of all the parts of speech");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App233",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuViewSite_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Display a listing of all the sight words");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App234",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuViewGraphemes_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Display a listing of all the taught graphemes");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App235",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuFormatFont_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Choose the font for the selected text in the active document");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App236",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuFormatColor_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Choose the color for the selected text in the active document");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App237",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuFormatWrap_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Toggle Word Wrap for the active document");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App238",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuReportVowel_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Generate the Vowel Report in the active document");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App239",
                m_Settings.OptionSettings.UILanguage));
        }
        
        private void menuReportConsonant_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Generate the Consonant Report in the active document");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App240",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuReportPrimer_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Generate the Primer Progression Report in the active document");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App241",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuReportGenerate_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Generate a report in the active document from a given report template");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App242",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuReportEdit_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Edit a given report template in the active document");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App243",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuSearchWordGrapheme_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Execute a grapheme search on the current word list");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App244",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuSearchWordFrequency_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Execute a frequency count search on the current word list");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App245",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuSearchWordBuild_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Execute a buildable word search on the current word list");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App246",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuSearchWordAdvanced_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Execute an advanced grapheme search on the current word list");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App247",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuSearchWordPairs_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Execute a minimal pair search on the current word list");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App248",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuSearchWordCoccur_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Execute a co-occurrence search on the current word list");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App249",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuSearchWordContext_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Execute a context occurrence chart search on the current word list");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App250",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuSearchWordSyllable_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Execute a syllable chart search on the current word list");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App251",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuSearchWordTone_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Execute a tone search on the current word list");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App252",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuSearchWordSyllograph_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Execute a syllograph search on the current word list");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App252A",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuSearchWordOrder_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Execute a Teaching Order search on the current word list");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App253",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuSearchWordGeneral_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Execute a General search on the current word list");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App254",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuSearchTextGrapheme_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Execute a grapheme search on the current text data");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App255",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuSearchTextFrequency_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Execute a frequency count search on the current text data");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App256",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuSearchTextWord_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Execute a word/root search on the current text data");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App257",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuSearchTextCount_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Execute a word count search on the current text data");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App258",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuSearchTextSyllable_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Execute a syllable count search on the current text data");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App259",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuSearchTextPhrases_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Execute a usable phrases search on the current text data");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App260",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuSearchTextResidue_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Execute a untaught residue search on the current text data");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App261",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuSearchTextSight_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Execute a sight word search on the current text data");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App262",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuSearchTextBuilt_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Execute a built word search on the current text data");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App263",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuSearchTextNew_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Execute a new word search on the current text data");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App264",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuSearchTextTone_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Execute a tone search on the current text data");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App265",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuSearchTextSyllograph_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Execute a syllograph search on the current text data");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App265A",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuSearchTextOrder_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Execute a Teaching Order search on the current text data");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App266",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuSearchVowel_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Execute a vowel chart search from the inventory");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App267",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuSearchConsonant_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Execute a consonant chart search from the inventory");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App268",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuSearchTone_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Execute a Tone chart search from the inventory");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App269",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuSearchSyllograph_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Execute a Syllograph chart search from the inventory");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App269A",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuToolsWordImportSF_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Import a standard format file as the current word list");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App270",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuToolsWordImportLIFT_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Import a LIFT file as the current word list");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App271",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuToolsWordMerge_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Merge a standard format file with the current word list");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App272",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuToolsWordExport_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Export the current word list as a standard format file");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App273",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuToolsWordReimport_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Reimport the current word list file");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App274",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuToolsWordUnload_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Unload the current word list from the application");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App275",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuToolsWordCheck_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Check the current word list for graphemes not in the inventory");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App276",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuToolsTextImport_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Import a plain text file as the current text data");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App277",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuToolsTextMerge_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Merge a plain text file with the current text data");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App278",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuToolsTextExport_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Export the current text data as a plain text file");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App279",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuToolsTextReimport_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Reimport the current text data file");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App280",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuToolsTextUnload_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Unload the current text data from the application");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App281",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuToolsTextCheckGI_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Check the current text data for graphemes not in the inventory");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App282",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuToolsTextCheckWL_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Check the current text data for words not in the current word list");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App283",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuToolsTextBuildWL_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Build standard format file as word list from words in current text data");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App284",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuToolsInventoryInitWL_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Initialize the grapheme inventory from a word list");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App285",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuToolsInventoryInitTD_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Initialize the grapheme inventory from a text data");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App285A",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuToolsInventoryInitPG_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Initialize the grapheme inventory from predefined graphemest");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App286A",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuToolsInventorySyllabary_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Initialize the grapheme inventory for syllographs");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App287A",
                m_Settings.OptionSettings.UILanguage));
        }
        
        private void menuToolsInventoryConsonants_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Add, update or delete consonants in the grapheme inventory");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App286",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuToolsInventoryVowels_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Add, update or delete vowels in the grapheme inventory");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App287",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuToolsInventoryTone_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Add, update or delete tones in the grapheme inventory");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App288",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuToolsInventorySyllograph_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Add, update or delete syllographs in the grapheme inventory");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App288A",
                m_Settings.OptionSettings.UILanguage));
        }
        
        private void menuToolsInventorySave_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Save the grapheme inventory to a XML file");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App289",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuToolsInventoryClear_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Deleta all the graphemes from the inventory");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App290",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuToolsPartsInit_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Initialize Parts of Speech to default");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App291",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuToolsPartsUpdate_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Add, update or delete parts of speechs");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App292",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuToolsPartsSave_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Save the Parts of Speech list to a XML file");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App293",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuToolsSightUpdate_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Add or delete words in the sight word list");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App294",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuToolsSightSave_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Save the sight word list to a XML file");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App295",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuToolsSightCheckWL_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Check the sight word list for words not in the current word list");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App296",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuToolsOrderUpdate_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Add or delete graphemes in the grapheme taught order list");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App297",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuToolsOrderSave_Select(object sender, EventArgs e)
        {
            //UpdStatusBarInfo("Save grapheme taught order list to a XML file");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App298",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuToolsOrderCheck_Select(object sender, System.EventArgs e)
        {
            //UpdStatusBarInfo("Check the grapheme taught order list for graphemes not in the current inventory");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App299",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuToolsOptions_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Update the options settings for the application");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App300",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuWindowCascade_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Redisplay all the windows of the application as cascading");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App301",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuWindowTileH_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Redisplay all the windows of the application as horizontal tiles");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App302",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuWindowTileV_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Redisplay all the windows of the application as vertical tiles");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App303",
                m_Settings.OptionSettings.UILanguage));
        }

		private void menuHelpHelp_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Display the help facility");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App304",
                m_Settings.OptionSettings.UILanguage));
        }

        private void menuHelpSetup_Select(object sender, EventArgs e)
        {
            UpdStatusBarInfo("Display the setup tutorial (pdf file)");
            //UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App304",
            //    m_Settings.OptionSettings.UILanguage));

        }

        private void menuHelpPrimer_Select(object sender, EventArgs e)
        {
            UpdStatusBarInfo("Display the primer making utorial (pdf file)");
            //UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App304",
            //    m_Settings.OptionSettings.UILanguage));

        }
        
        private void menuHelpAbout_Select(object sender, System.EventArgs e)
		{
            //UpdStatusBarInfo("Display version, date and copyright of application");
            UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App305",
                m_Settings.OptionSettings.UILanguage));
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

        public void InitGraphemeInventory()
        {
        //    string strFolder = m_Settings.OptionSettings.DataFolder;
        //    LocalizationTable table = m_Settings.LocalizationTable;
        //    string strLang = m_Settings.OptionSettings.UILanguage;

        //    bool fDone = false;
        //    string strFileName = m_Settings.GraphemeInventory.FileName;
        //    WordList.FileType fileType = WordList.FileType.None; 
        //    WordList wl = new WordList(m_Settings);
        //    GraphemeInventory gi = new GraphemeInventory(m_Settings);
        //    SortedList slAvailable = new SortedList();
        //    ArrayList alSelection = new ArrayList();
        //    ArrayList alAvailable = new ArrayList();

        //    if (!fDone)
        //    // get sorted list of characters from given word list
        //    {
        //        FormInitGraphemeInventoryWL form = new FormInitGraphemeInventoryWL(strFolder, table, strLang);
        //        if (form.ShowDialog() == DialogResult.OK)
        //        {
        //            strFileName = form.FileName;
        //            if (form.IsLift)
        //                fileType = WordList.FileType.Lift;
        //            else fileType = WordList.FileType.StandardFormat;

        //            if (fileType == WordList.FileType.Lift)
        //                wl = wl.LoadLIFTFromFile(strFileName);
        //            else wl = wl.LoadSFMFromFile(strFileName);
        //            if (wl != null)
        //            {
        //                slAvailable = wl.BuildSortedCharacterList();
        //            }
        //            else fDone = true;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Initialization cancelled");
        //            fDone = true; ;
        //        }
        //    }

        //    if (!fDone)
        //    // Get simple consonants from sorted list of characters
        //    {
        //        string str = "";
        //        for (int i = 0; i < slAvailable.Count; i++)
        //        {
        //            str = (string)slAvailable.GetByIndex(i);
        //            alAvailable.Add(str);
        //        }
        //        FormInitGraphemeInventory2 form = new FormInitGraphemeInventory2(alAvailable, table, strLang);
        //        if (form.ShowDialog() == DialogResult.OK)
        //        {
        //            Consonant cns = null;
        //            alSelection = form.Consonants;
        //            if (alSelection != null)
        //            {
        //                for (int i = 0; i < alSelection.Count; i++)
        //                {
        //                    cns = new Consonant((string)alSelection[i]);
        //                    gi.AddConsonant(cns);
        //                }
        //            }
        //            alAvailable = form.NonConsonants;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Initialization cancelled");
        //            fDone = true; ;
        //        }

        //    }

        //    if (!fDone)
        //    //Get simple vowels from available list of characters
        //    {
        //        FormInitGraphemeInventory3 form = new FormInitGraphemeInventory3(alAvailable, table, strLang);
        //        if (form.ShowDialog() == DialogResult.OK)
        //        {
        //            Vowel vwl = null;
        //            alSelection = form.Vowels;
        //            if (alSelection != null)
        //            {
        //                for (int i = 0; i < alSelection.Count; i++)
        //                {
        //                    vwl = new Vowel((string)alSelection[i]);
        //                    gi.AddVowel(vwl);
        //                }
        //            }
        //            alAvailable = form.NonVowels;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Initialization cancelled");
        //            fDone = true;
        //        }
        //    }

        //    if (!fDone)
        //    //Get simple tones from available list of characters
        //    {
        //        FormInitGraphemeInventory4 form = new FormInitGraphemeInventory4(alAvailable, table, strLang);
        //        if (form.ShowDialog() == DialogResult.OK)
        //        {
        //            Tone tone = null;
        //            alSelection = form.Tones;
        //            if (alSelection != null)
        //            {
        //                for (int i = 0; i < alSelection.Count; i++)
        //                {
        //                    tone = new Tone( (string)alSelection[i]);
        //                    gi.AddTone(tone);
        //                }
        //            }
        //            alAvailable = form.NonTones;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Initialization cancelled");
        //            fDone = true;
        //        }
        //    }

        //    if (!fDone)
        //    //Get multigraph symbols from available list of characters
        //    {
        //        slAvailable = wl.BuildSortedMultiGraphList(gi);
        //        alAvailable = new ArrayList();
        //        Grapheme grf = null;
        //        for (int i = 0; i < slAvailable.Count; i++)
        //        {
        //            grf = (Grapheme)slAvailable.GetByIndex(i);
        //            alAvailable.Add(grf.Symbol);
        //        }
        //        FormInitGraphemeInventory5 form = new FormInitGraphemeInventory5(alAvailable, table, strLang);
        //        if (form.ShowDialog() == DialogResult.OK)
        //        {
        //            alSelection = form.Multigraphs;
        //            string str = "";
        //            //int ndx = -1;
        //            if (alSelection != null)
        //            {
        //                for (int i = 0; i < alSelection.Count; i++)
        //                {
        //                    str = (string)alSelection[i];
        //                    grf = (Grapheme)slAvailable[str];
        //                    switch (grf.GetGraphemeType())
        //                    {
        //                        case Grapheme.GraphemeType.Consonant:
        //                            Consonant cns = new Consonant(grf.Symbol);
        //                            gi.AddConsonant(cns);
        //                            break;
        //                        case Grapheme.GraphemeType.Vowel:
        //                            Vowel vwl = new Vowel(grf.Symbol);
        //                            gi.AddVowel(vwl);
        //                            break;
        //                        case Grapheme.GraphemeType.Tone:
        //                            Tone tone = new Tone(grf.Symbol);
        //                            gi.AddTone(tone);
        //                            break;
        //                        default:
        //                            break;
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Initialization cancelled");
        //            fDone = true;
        //        }

        //        if (!fDone)
        //        {
        //            m_Settings.GraphemeInventory = gi;
        //            gi.SaveToFile(strFileName);
        //        }

        //    }

        }

        public void InitGraphemeInventoryWL()
        {
            string strFileName = m_Settings.GraphemeInventory.FileName;
            GraphemeInventory gi = new GraphemeInventory(m_Settings);

            // get sorted list of graphemes from given word list
            {
                FormInitGraphemeInventoryWL form = new FormInitGraphemeInventoryWL(m_Settings);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    gi = form.GraphemeInventory;
                    if (gi != null)
                    {
                        m_Settings.GraphemeInventory = gi;
                        gi.SaveToFile(gi.FileName);
                        //MessageBox.Show("Since the graphene inventory has been updated, you need to reimport the word list and text data.");
                        MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App131", m_Settings.OptionSettings.UILanguage));
                    }
                }
                else
                {
                    //MessageBox.Show("Initialization cancelled");
                    MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App130", m_Settings.OptionSettings.UILanguage));
                }
            }
         }

        public void InitGraphemeInventoryTD()
        {
            string strFileName = m_Settings.GraphemeInventory.FileName;
            GraphemeInventory gi = new GraphemeInventory(m_Settings);

            // get sorted list of graphemes from given text data
            {
                FormInitGraphemeInventoryTD form = new FormInitGraphemeInventoryTD(m_Settings);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    gi = form.GraphemeInventory;
                    if (gi != null)
                    {
                        m_Settings.GraphemeInventory = gi;
                        gi.SaveToFile(gi.FileName);
                        //MessageBox.Show("Since the graphene inventory has been initialized, you need to reimport the word list and text data.");
                        MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App131", m_Settings.OptionSettings.UILanguage));
                    }
                }
                else
                {
                    //MessageBox.Show("Initialization cancelled");
                    MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App130", m_Settings.OptionSettings.UILanguage));
                }
            }
        }

        public void InitGraphemeInventoryPG()
        {
            string strFileName = m_Settings.GetAppFolder() + AppWindow.kBackSlash +
                 AppWindow.kDefaultGIName;
            GraphemeInventory gi = new GraphemeInventory(m_Settings);
            if (gi.InitializeGraphemeInventoryFromPredefinedGraphemes(strFileName))
            {
                m_Settings.GraphemeInventory = gi;
                gi.SaveToFile(m_Settings.OptionSettings.GraphemeInventoryFile);
                //MessageBox.Show("Grapheme Inventory has been initialized");
                MessageBox.Show(m_Settings.LocalizationTable.GetMessage("FormNewProject2",
                   m_Settings.OptionSettings.UILanguage));
            }
            else
            {
                //MessageBox.Show("Grapheme Inventory was not initialized");
                MessageBox.Show(m_Settings.LocalizationTable.GetMessage("FormNewProject1",
                    m_Settings.OptionSettings.UILanguage));
            }
        }
        
        public void InitGraphemeInventorySyllabary()
        {
            FormNewSyllabary form = new FormNewSyllabary(m_Settings);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                string strFileName = m_Settings.GraphemeInventory.FileName;
                m_Settings.GraphemeInventory = form.GI;
                m_Settings.GraphemeInventory.FileName = strFileName;
                m_Settings.GraphemeInventory.SaveToFile(m_Settings.GraphemeInventory.FileName);
                //MessageBox.Show("Syllograph Inventory has been initialized.");
                MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App306",
                    m_Settings.OptionSettings.UILanguage));
            }
            //else MessageBox.Show("Syllograph Inventory was not initialized");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App307",
                m_Settings.OptionSettings.UILanguage));
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
            m_Settings.LocalizationTable = m_LocalizationTable;
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
            string strMsg = m_Settings.LocalizationTable.GetMessage("App106",
                m_Settings.OptionSettings.UILanguage);
            FormProgressBar form = new FormProgressBar(strMsg);
            form.PB_Init(0, 7);
            string strFileName = "";

            if (m_Settings != null)
            {
                if (m_Settings.OptionSettings != null)
                {
                    form.Text = m_Settings.LocalizationTable.GetMessage("App107",
                        m_Settings.OptionSettings.UILanguage);
                    form.PB_Update(0);
                    if (m_Settings.OptionSettings.WordListFile == WordList.kMergeWordList)
                    {
                        strMsg = m_Settings.LocalizationTable.GetMessage("App73",
                            m_Settings.OptionSettings.UILanguage);
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
                                MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App74",
                                    m_Settings.OptionSettings.UILanguage));
                            }
                            //else MessageBox.Show("Current Word List not saved");
                            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App75",
                                m_Settings.OptionSettings.UILanguage));
                        }
                    }

                    form.Text = m_Settings.LocalizationTable.GetMessage("App108",
                        m_Settings.OptionSettings.UILanguage);
                    form.PB_Update(1);
                    if (m_Settings.OptionSettings.TextDataFile == TextData.kMergeTextData)
                    {
                        strMsg = m_Settings.LocalizationTable.GetMessage("App76",
                            m_Settings.OptionSettings.UILanguage);
                        if (MessageBox.Show(strMsg, "", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            TextData td = this.Settings.TextData;
                            if (td.Save(this.Settings.OptionSettings.DataFolder))
                            {
                                this.Settings.TextData = td;
                                this.Settings.OptionSettings.TextDataFile = td.FileName;
                                //MessageBox.Show("Current Text Data saved");
                                 MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App77",
                                    m_Settings.OptionSettings.UILanguage));
                           }
                            //else MessageBox.Show("Current Text Data not saved");
                            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App78",
                                m_Settings.OptionSettings.UILanguage));
                        }
                    }

                    //Saving Options
                    form.Text = m_Settings.LocalizationTable.GetMessage("App109",
                        m_Settings.OptionSettings.UILanguage);
                    form.PB_Update(2);
                    if (this.Settings.OptionSettings != null)
                    {
                        strFileName = this.ProjInfo.OptionsFile;
                        if (!File.Exists(strFileName))
                            strFileName = m_Settings.PrimerProFolder + Constants.Backslash +
                                m_Settings.ProjInfo.ProjectName + ".xml";
                        this.Settings.OptionSettings.SaveOptionList(strFileName);		//Save options to xml file
                    }

                    //Saving Grapheme Inventory
                    form.Text = m_Settings.LocalizationTable.GetMessage("App110",
                        m_Settings.OptionSettings.UILanguage);
                    form.PB_Update(3);
                    if (this.Settings.GraphemeInventory != null)
                    {
                        strFileName = this.Settings.GraphemeInventory.FileName;
                        if (strFileName != "")
                            this.Settings.GraphemeInventory.SaveToFile(strFileName);  //Save grapheme inventory to xml file
                    }
                    
                    //Saving Parts of Speech
                    form.Text = m_Settings.LocalizationTable.GetMessage("App111",
                        m_Settings.OptionSettings.UILanguage);
                    form.PB_Update(4);
                    if (this.Settings.PSTable != null)
                    {
                        strFileName = this.Settings.PSTable.FileName;
                        if (strFileName != "")
                            this.Settings.PSTable.SaveToFile(strFileName);            //Save Parts of Speech to xml file
                    }

                    //Saving Sight Words
                    form.Text = m_Settings.LocalizationTable.GetMessage("App112",
                        m_Settings.OptionSettings.UILanguage);
                    form.PB_Update(5);
                    if (this.Settings.SightWords != null)
                    {
                        strFileName = this.Settings.SightWords.FileName;
                        if (strFileName != "")
                            this.Settings.SightWords.SaveToFile(strFileName);			//Save sight words to xml file
                    }

                    //Saving Graphemes Taught
                    form.Text = m_Settings.LocalizationTable.GetMessage("App113",
                        m_Settings.OptionSettings.UILanguage);
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
            //else MessageBox.Show("No active document to close");
            else MessageBox.Show(m_LocalizationTable.GetMessage("App4", m_Settings.OptionSettings.UILanguage));
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
            //string strText = "WL:<none>";
            string strText = m_Settings.LocalizationTable.GetMessage("App114",
                m_Settings.OptionSettings.UILanguage) + m_Settings.LocalizationTable.GetMessage("App101",
                m_Settings.OptionSettings.UILanguage);
            if (this.Settings != null)
            {
                if (this.Settings.WordList != null)
                {
                        if (this.Settings.WordList.FileName != "")
                        {
                            //strText = "WL:";
                            strText = m_Settings.LocalizationTable.GetMessage("App114",
                                m_Settings.OptionSettings.UILanguage);
                            if (this.Settings.WordList.FileName == WordList.kMergeWordList)
                                strText += m_Settings.LocalizationTable.GetMessage("App117",
                                    m_Settings.OptionSettings.UILanguage);
                            else strText += Funct.ShortFileName(this.Settings.WordList.FileName);
                            strText += "->";
                            strText += this.Settings.WordList.WordCount().ToString();
                        }
                }
            }
            this.tsslWordList.Text = strText;
            if (this.ssApp.Visible)
                this.ssApp.Show();
        }

        public void UpdStatusBarTD()
        {
            //string strText = "TD:<none>";
            string strText = m_Settings.LocalizationTable.GetMessage("App115",
                m_Settings.OptionSettings.UILanguage) + m_Settings.LocalizationTable.GetMessage("App101",
                m_Settings.OptionSettings.UILanguage);
            if (this.Settings != null)
            {
                if (this.Settings.TextData != null)
                {
                    if (this.Settings.TextData.FileName != "")
                    {
                        //strText = "TD:";
                        strText = m_Settings.LocalizationTable.GetMessage("App115",
                            m_Settings.OptionSettings.UILanguage);
                        if (this.Settings.TextData.FileName == TextData.kMergeTextData)
                            strText += m_Settings.LocalizationTable.GetMessage("App118",
                                m_Settings.OptionSettings.UILanguage);
                        else strText += Funct.ShortFileName(this.Settings.TextData.FileName);
                    }
                }
            }
            this.tsslTextData.Text = strText;
            if (this.ssApp.Visible)
                this.ssApp.Show();
        }

        public void UpdStatusBarWnd()
        {
            //string strText = "<none>";
            string strText = m_Settings.LocalizationTable.GetMessage("App116",
                m_Settings.OptionSettings.UILanguage);
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

        private void UpdateMenuForLanguage(string lang)
        // lang = UI language
        {
            LocalizationEntry entry = null;
            SortedList ml = m_Settings.LocalizationTable.MenuList;
            for (int i = 0; i < ml.Count; i++)
            {
                entry = (LocalizationEntry)ml.GetByIndex(i);
                switch (entry.Idn)
                {
                    case "menuFile":
                        this.menuFile.Text = m_Settings.LocalizationTable.GetMenu("menuFile", lang);
                        break;
                    case "menuFileNew":
                        this.menuFileNew.Text = m_Settings.LocalizationTable.GetMenu("menuFileNew", lang);
                        break;
                    case "menuFileOpen":
                        this.menuFileOpen.Text = m_Settings.LocalizationTable.GetMenu("menuFileOpen", lang);
                        break;
                    case "menuFileClose":
                        this.menuFileClose.Text = m_Settings.LocalizationTable.GetMenu("menuFileClose", lang);
                        break;
                    case "menuFileSave":
                        this.menuFileSave.Text = m_Settings.LocalizationTable.GetMenu("menuFileSave", lang);
                        break;
                    case "menuFileAs":
                        this.menuFileAs.Text = m_Settings.LocalizationTable.GetMenu("menuFileAs", lang);
                        break;
                    case "menuFileProjNew":
                        this.menuFileProjNew.Text = m_Settings.LocalizationTable.GetMenu("menuFileProjNew", lang);
                        break;
                    case "menuFileProjSelect":
                        this.menuFileProjSelect.Text = m_Settings.LocalizationTable.GetMenu("menuFileProjSelect", lang);
                        break;
                    case "menuFileProjDelete":
                        this.menuFileProjDelete.Text = m_Settings.LocalizationTable.GetMenu("menuFileProjDelete", lang);
                        break;
                    case "menuFileProjExport":
                        this.menuFileProjExport.Text = m_Settings.LocalizationTable.GetMenu("menuFileProjExport", lang);
                        break;
                    case "menuFileProjImport":
                        this.menuFileProjImport.Text = m_Settings.LocalizationTable.GetMenu("menuFileProjImport", lang);
                        break;
                    case "menuFilePrint":
                        this.menuFilePrint.Text = m_Settings.LocalizationTable.GetMenu("menuFilePrint", lang);
                        break;
                    case "menuFilePreview":
                        this.menuFilePreview.Text = m_Settings.LocalizationTable.GetMenu("menuFilePreview", lang);
                        break;
                    case "menuFileSetup":
                        this.menuFileSetup.Text = m_Settings.LocalizationTable.GetMenu("menuFileSetup", lang);
                        break;
                    case "menuExit":
                        this.menuExit.Text = m_Settings.LocalizationTable.GetMenu("menuExit", lang);
                        break;
                    case "menuEdit":
                        this.menuEdit.Text = m_Settings.LocalizationTable.GetMenu("menuEdit", lang);
                        break;
                    case "menuEditUndo":
                        this.menuEditUndo.Text = m_Settings.LocalizationTable.GetMenu("menuEditUndo", lang);
                        break;
                    case "menuEditCut":
                        this.menuEditCut.Text = m_Settings.LocalizationTable.GetMenu("menuEditCut", lang);
                        break;
                    case "menuEditCopy":
                        this.menuEditCopy.Text = m_Settings.LocalizationTable.GetMenu("menuEditCopy", lang);
                        break;
                    case "menuEditPaste":
                        this.menuEditPaste.Text = m_Settings.LocalizationTable.GetMenu("menuEditPaste", lang);
                        break;
                    case "menuEditSelect":
                        this.menuEditSelect.Text = m_Settings.LocalizationTable.GetMenu("menuEditSelect", lang);
                        break;
                    case "menuEditClear":
                        this.menuEditClear.Text = m_Settings.LocalizationTable.GetMenu("menuEditClear", lang);
                        break;
                    case "menuEditFind":
                        this.menuEditFind.Text = m_Settings.LocalizationTable.GetMenu("menuEditFind", lang);
                        break;
                    case "menuEditNext":
                        this.menuEditNext.Text = m_Settings.LocalizationTable.GetMenu("menuEditNext", lang);
                        break;
                    case "menuEditReplace":
                        this.menuEditReplace.Text  = m_Settings.LocalizationTable.GetMenu("menuEditReplace", lang);
                        break;
                    case "menuView":
                        this.menuView.Text = m_Settings.LocalizationTable.GetMenu("menuView", lang);
                        break;
                    case "menuViewToolbar":
                        this.menuViewToolbar.Text = m_Settings.LocalizationTable.GetMenu("menuViewToolbar", lang);
                        break;
                    case "menuViewStatus":
                        this.menuViewStatus.Text = m_Settings.LocalizationTable.GetMenu("menuViewStatus", lang);
                        break;
                    case "menuViewMode":
                        this.menuViewMode.Text = m_Settings.LocalizationTable.GetMenu("menuViewMode", lang);
                        break;
                    case "menuViewShow":
                        this.menuViewShow.Text = m_Settings.LocalizationTable.GetMenu("menuViewShow", lang);
                        break;
                    case "menuViewHide":
                        this.menuViewHide.Text = m_Settings.LocalizationTable.GetMenu("menuViewHide", lang);
                        break;
                    case "menuViewClear":
                        this.menuViewClear.Text = m_Settings.LocalizationTable.GetMenu("menuViewClear", lang);
                        break;
                    case "menuViewUnprocessed":
                        this.menuViewUnprocessed.Text  = m_Settings.LocalizationTable.GetMenu("menuViewUnprocessed", lang);
                        break;
                    case "menuViewWordList":
                        this.menuViewWordList.Text  = m_Settings.LocalizationTable.GetMenu("menuViewWordList", lang);
                        break;
                    case "menuViewTextData":
                        this.menuViewTextData.Text  = m_Settings.LocalizationTable.GetMenu("menuViewTextData", lang);
                        break;
                    case "menuViewInventory":
                        this.menuViewInventory.Text  = m_Settings.LocalizationTable.GetMenu("menuViewInventory", lang);
                        break;
                    case "menuViewPS":
                        this.menuViewPS.Text  = m_Settings.LocalizationTable.GetMenu("menuViewPS", lang);
                        break;
                    case "menuViewSite":
                        this.menuViewSite.Text  = m_Settings.LocalizationTable.GetMenu("menuViewSite", lang);
                        break;
                    case "menuViewGraphemes":
                        this.menuViewGraphemes.Text  = m_Settings.LocalizationTable.GetMenu("menuViewGraphemes", lang);
                        break;
                    case "menuFormat":
                         this.menuFormat.Text  = m_Settings.LocalizationTable.GetMenu("menuFormat", lang);
                        break;
                    case "menuFormatFont":
                         this.menuFormatFont.Text  = m_Settings.LocalizationTable.GetMenu("menuFormatFont", lang);
                        break;
                    case "menuFormatColor":
                        this.menuFormatColor.Text  = m_Settings.LocalizationTable.GetMenu("menuFormatColor", lang);
                        break;
                    case "menuFormatWrap":
                        this.menuFormatWrap.Text  = m_Settings.LocalizationTable.GetMenu("menuFormatWrap", lang);
                        break;
                    case "menuReport":
                        this.menuReport.Text = m_Settings.LocalizationTable.GetMenu("menuReport", lang);
                        break;
                    case "menuReportVowel":
                        this.menuReportVowel.Text = m_Settings.LocalizationTable.GetMenu("menuReportVowel", lang);
                        break;
                    case "menuReportConsonant":
                        this.menuReportConsonant.Text = m_Settings.LocalizationTable.GetMenu("menuReportConsonant", lang);
                        break;
                    case "menuReportPrimer":
                        this.menuReportPrimer.Text = m_Settings.LocalizationTable.GetMenu("menuReportPrimer", lang);
                        break;
                    case "menuReportGenerate":
                        this.menuReportGenerate.Text = m_Settings.LocalizationTable.GetMenu("menuReportGenerate", lang);
                        break;
                    case "menuReportEdit":
                        this.menuReportEdit.Text = m_Settings.LocalizationTable.GetMenu("menuReportEdit", lang);
                        break;
                    case "menuSearch":
                        this.menuSearch.Text = m_Settings.LocalizationTable.GetMenu("menuSearch", lang);
                        break;
                    case "menuSearchWord":
                        this.menuSearchWord.Text = m_Settings.LocalizationTable.GetMenu("menuSearchWord", lang);
                        break;
                    case "menuSearchWordGrapheme":
                        this.menuSearchWordGrapheme.Text = m_Settings.LocalizationTable.GetMenu("menuSearchWordGrapheme", lang);
                        break;
                    case "menuSearchWordFrequency":
                        this.menuSearchWordFrequency.Text = m_Settings.LocalizationTable.GetMenu("menuSearchWordFrequency", lang);
                        break;
                    case "menuSearchWordBuild":
                        this.menuSearchWordBuild.Text = m_Settings.LocalizationTable.GetMenu("menuSearchWordBuild", lang);
                        break;
                    case "menuSearchWordAdvanced":
                        this.menuSearchWordAdvanced.Text = m_Settings.LocalizationTable.GetMenu("menuSearchWordAdvanced", lang);
                        break;
                    case "menuSearchWordPairs":
                        this.menuSearchWordPairs.Text = m_Settings.LocalizationTable.GetMenu("menuSearchWordPairs", lang);
                        break;
                    case "menuSearchWordCoccur":
                        this.menuSearchWordCoccur.Text = m_Settings.LocalizationTable.GetMenu("menuSearchWordCoccur", lang);
                        break;
                    case "menuSearchWordContext":
                        this.menuSearchWordContext.Text = m_Settings.LocalizationTable.GetMenu("menuSearchWordContext", lang);
                        break;
                    case "menuSearchWordSyllable":
                        this.menuSearchWordSyllable.Text = m_Settings.LocalizationTable.GetMenu("menuSearchWordSyllable", lang);
                        break;
                    case "menuSearchWordTone":
                        this.menuSearchWordTone.Text = m_Settings.LocalizationTable.GetMenu("menuSearchWordTone", lang);
                        break;
                    case "menuSearchWordSyllograph":
                        this.menuSearchWordSyllograph.Text = m_Settings.LocalizationTable.GetMenu("menuSearchWordSyllograph", lang);
                        break;
                    case "menuSearchWordOrder":
                        this.menuSearchWordOrder.Text = m_Settings.LocalizationTable.GetMenu("menuSearchWordOrder", lang);
                        break;
                    case "menuSearchWordGeneral":
                        this.menuSearchWordGeneral.Text = m_Settings.LocalizationTable.GetMenu("menuSearchWordGeneral", lang);
                        break;
                    case "menuSearchText":
                        this.menuSearchText.Text = m_Settings.LocalizationTable.GetMenu("menuSearchText", lang);
                        break;
                    case "menuSearchTextGrapheme":
                        this.menuSearchTextGrapheme.Text = m_Settings.LocalizationTable.GetMenu("menuSearchTextGrapheme", lang);
                        break;
                    case "menuSearchTextFrequency":
                        this.menuSearchTextFrequency.Text = m_Settings.LocalizationTable.GetMenu("menuSearchTextFrequency", lang);
                        break;
                    case "menuSearchTextBuilt":
                        this.menuSearchTextBuild.Text = m_Settings.LocalizationTable.GetMenu("menuSearchTextBuilt", lang);
                        break;
                    case "menuSearchTextPhrases":
                        this.menuSearchTextPhrases.Text = m_Settings.LocalizationTable.GetMenu("menuSearchTextPhrases", lang);
                        break;
                    case "menuSearchTextResidue":
                        this.menuSearchTextResidue.Text = m_Settings.LocalizationTable.GetMenu("menuSearchTextResidue", lang);
                        break;
                    case "menuSearchTextWord":
                        this.menuSearchTextWord.Text = m_Settings.LocalizationTable.GetMenu("menuSearchTextWord", lang);
                        break;
                    case "menuSearchTextCount":
                        this.menuSearchTextCount.Text = m_Settings.LocalizationTable.GetMenu("menuSearchTextCount", lang);
                        break;
                    case "menuSearchTextSyllable":
                        this.menuSearchTextSyllable.Text  = m_Settings.LocalizationTable.GetMenu("menuSearchTextSyllable", lang);
                        break;
                    case "menuSearchTextSight":
                        this.menuSearchTextSight.Text = m_Settings.LocalizationTable.GetMenu("menuSearchTextSight", lang);
                        break;
                    case "menuSearchTextNew":
                        this.menuSearchTextNew.Text = m_Settings.LocalizationTable.GetMenu("menuSearchTextNew", lang);
                        break;
                    case "menuSearchTextTone":
                        this.menuSearchTextTone.Text = m_Settings.LocalizationTable.GetMenu("menuSearchTextTone", lang);
                        break;
                    case "menuSearchTextSyllograph":
                        this.menuSearchTextSyllograph.Text = m_Settings.LocalizationTable.GetMenu("menuSearchTextSyllograph", lang);
                        break;
                    case "menuSearchTextOrder":
                        this.menuSearchTextOrder.Text = m_Settings.LocalizationTable.GetMenu("menuSearchTextOrder", lang);
                        break;
                    case "menuSearchVowel":
                        this.menuSearchVowel.Text = m_Settings.LocalizationTable.GetMenu("menuSearchVowel", lang);
                        break;
                    case "menuSearchConsonant":
                        this.menuSearchConsonant.Text = m_Settings.LocalizationTable.GetMenu("menuSearchConsonant", lang);
                        break;
                    case "menuSearchTone":
                        this.menuSearchTone.Text = m_Settings.LocalizationTable.GetMenu("menuSearchTone", lang);
                        break;
                    case "menuSearchSyllograph":
                        this.menuSearchSyllograph.Text = m_Settings.LocalizationTable.GetMenu("menuSearchSyllograph", lang);
                        break;
                    case "menuTools":
                        this.menuTools.Text = m_Settings.LocalizationTable.GetMenu("menuTools", lang);
                        break;
                    case "menuToolsWord":
                        this.menuToolsWord.Text = m_Settings.LocalizationTable.GetMenu("menuToolsWord", lang);
                        break;
                    case "menuToolsWordImport":
                        this.menuToolsWordImport.Text = m_Settings.LocalizationTable.GetMenu("menuToolsWordImport", lang);
                        break;
                    case "menuToolsWordImportSF":
                        this.menuToolsWordImportSF.Text = m_Settings.LocalizationTable.GetMenu("menuToolsWordImportSF", lang);
                        break;
                    case "menuToolsWordImportLIFT":
                        this.menuToolsWordImportLIFT.Text = m_Settings.LocalizationTable.GetMenu("menuToolsWordImportLIFT", lang);
                        break;
                    case "menuToolsWordMerge":
                        this.menuToolsWordMerge.Text = m_Settings.LocalizationTable.GetMenu("menuToolsWordMerge", lang);
                        break;
                    case "menuToolsWordExport":
                        this.menuToolsWordExport.Text = m_Settings.LocalizationTable.GetMenu("menuToolsWordExport", lang);
                        break;
                    case "menuToolsWordReimport":
                        this.menuToolsWordReimport.Text = m_Settings.LocalizationTable.GetMenu("menuToolsWordReimport", lang);
                        break;
                    case "menuToolsWordUnload":
                        this.menuToolsWordUnload.Text = m_Settings.LocalizationTable.GetMenu("menuToolsWordUnload", lang);
                        break;
                    case "menuToolsWordCheck":
                        this.menuToolsWordCheck.Text = m_Settings.LocalizationTable.GetMenu("menuToolsWordCheck", lang);
                        break;
                    case "menuToolsText":
                        this.menuToolsText.Text = m_Settings.LocalizationTable.GetMenu("menuToolsText", lang);
                        break;
                    case "menuToolsTextImport":
                        this.menuToolsTextImport.Text = m_Settings.LocalizationTable.GetMenu("menuToolsTextImport", lang);
                        break;
                    case "menuToolsTextMerge":
                        this.menuToolsTextMerge.Text = m_Settings.LocalizationTable.GetMenu("menuToolsTextMerge", lang);
                        break;
                    case "menuToolsTextExport":
                        this.menuToolsTextExport.Text = m_Settings.LocalizationTable.GetMenu("menuToolsTextExport", lang);
                        break;
                    case "menuToolsTextReimport":
                        this.menuToolsTextReimport.Text = m_Settings.LocalizationTable.GetMenu("menuToolsTextReimport", lang);
                        break;
                    case "menuToolsTextUnload":
                         this.menuToolsTextUnload.Text  = m_Settings.LocalizationTable.GetMenu("menuToolsTextUnload", lang);
                        break;
                    case "menuToolsTextCheckGI":
                        this.menuToolsTextCheckGI.Text = m_Settings.LocalizationTable.GetMenu("menuToolsTextCheckGI", lang);
                        break;
                    case "menuToolsTextCheckWL":
                        this.menuToolsTextCheckWL.Text = m_Settings.LocalizationTable.GetMenu("menuToolsTextCheckWL", lang);
                        break;
                    case "menuToolsTextBuildWL":
                        this.menuToolsTextBuildWL.Text = m_Settings.LocalizationTable.GetMenu("menuToolsTextBuildWL", lang);
                        break;
                    case "menuToolsInventory":
                        this.menuToolsInventory.Text = m_Settings.LocalizationTable.GetMenu("menuToolsInventory", lang);
                        break;
                    case "menuToolsInventoryInit":
                        this.menuToolsInventoryInit.Text = m_Settings.LocalizationTable.GetMenu("menuToolsInventoryInit", lang);
                        break;
                    case "menuToolsInventoryInitWL":
                        this.menuToolsInventoryInitWL.Text = m_Settings.LocalizationTable.GetMenu("menuToolsInventoryInitWL", lang);
                        break;
                    case "menuToolsInventoryInitTD":
                        this.menuToolsInventoryInitTD.Text = m_Settings.LocalizationTable.GetMenu("menuToolsInventoryInitTD", lang);
                        break;
                    case "menuToolsInventoryInitPG":
                        this.menuToolsInventoryInitPG.Text = m_Settings.LocalizationTable.GetMenu("menuToolsInventoryInitPG", lang);
                        break;
                    case "menuToolsInventorySyllabary":
                        this.menuToolsInventorySyllabary.Text = m_Settings.LocalizationTable.GetMenu("menuToolsInventorySyllabary", lang);
                        break;
                    case "menuToolsInventoryConsonants":
                        this.menuToolsInventoryConsonants.Text = m_Settings.LocalizationTable.GetMenu("menuToolsInventoryConsonants", lang);
                        break;
                    case "menuToolsInventoryVowels":
                        this.menuToolsInventoryVowels.Text = m_Settings.LocalizationTable.GetMenu("menuToolsInventoryVowels", lang);
                        break;
                    case "menuToolsInventoryTone":
                        this.menuToolsInventoryTone.Text = m_Settings.LocalizationTable.GetMenu("menuToolsInventoryTone", lang);
                        break;
                    case "menuToolsInventorySyllograph":
                        this.menuToolsInventorySyllograph.Text = m_Settings.LocalizationTable.GetMenu("menuToolsInventorySyllograph", lang);
                        break;
                    case "menuToolsInventorySave":
                        this.menuToolsInventorySave.Text = m_Settings.LocalizationTable.GetMenu("menuToolsInventorySave", lang);
                        break;
                    case "menuToolsInventoryClear":
                        this.menuToolsInventoryClear.Text = m_Settings.LocalizationTable.GetMenu("menuToolsInventoryClear", lang);
                        break;
                    case "menuToolsParts":
                        this.menuToolsParts.Text = m_Settings.LocalizationTable.GetMenu("menuToolsParts", lang);
                        break;
                    case "menuToolsPartsInit":
                        this.menuToolsPartsInit.Text  = m_Settings.LocalizationTable.GetMenu("menuToolsPartsInit", lang);
                        break;
                    case "menuToolsPartsUpdate":
                        this.menuToolsPartsUpdate.Text  = m_Settings.LocalizationTable.GetMenu("menuToolsPartsUpdate", lang);
                        break;
                    case "menuToolsPartsSave":
                        this.menuToolsPartsSave.Text = m_Settings.LocalizationTable.GetMenu("menuToolsPartsSave", lang);
                        break;
                    case "menuToolsSight":
                        this.menuToolsSight.Text = m_Settings.LocalizationTable.GetMenu("menuToolsSight", lang);
                        break;
                    case "menuToolsSightUpdate":
                        this.menuToolsSightUpdate.Text = m_Settings.LocalizationTable.GetMenu("menuToolsSightUpdate", lang);
                        break;
                    case "menuToolsSightSave":
                        this.menuToolsSightSave.Text = m_Settings.LocalizationTable.GetMenu("menuToolsSightSave", lang);
                        break;
                    case "menuToolsSightCheckWL":
                        this.menuToolsSightCheckWL.Text = m_Settings.LocalizationTable.GetMenu("menuToolsSightCheckWL", lang);
                        break;
                    case "menuToolsOrder":
                        this.menuToolsOrder.Text = m_Settings.LocalizationTable.GetMenu("menuToolsOrder", lang);
                        break;
                    case "menuToolsOrderUpdate":
                        this.menuToolsOrderUpdate.Text = m_Settings.LocalizationTable.GetMenu("menuToolsOrderUpdate", lang);
                        break;
                    case "menuToolsOrderSave":
                        this.menuToolsOrderSave.Text  = m_Settings.LocalizationTable.GetMenu("menuToolsOrderSave", lang);
                        break;
                    case "menuToolsOrderCheck":
                        this.menuToolsOrderCheck.Text = m_Settings.LocalizationTable.GetMenu("menuToolsOrderCheck", lang);
                        break;
                    case "menuToolsOptions":
                        this.menuToolsOptions.Text = m_Settings.LocalizationTable.GetMenu("menuToolsOptions", lang);
                        break;
                    case "menuWindow":
                        this.menuWindow.Text = m_Settings.LocalizationTable.GetMenu("menuWindow", lang);
                        break;
                    case "menuWindowCascade":
                        this.menuWindowCascade.Text = m_Settings.LocalizationTable.GetMenu("menuWindowCascade", lang);
                        break;
                    case "menuWindowTileH":
                        this.menuWindowTileH.Text = m_Settings.LocalizationTable.GetMenu("menuWindowTileH", lang);
                        break;
                    case "menuWindowTileV":
                        this.menuWindowTileV.Text = m_Settings.LocalizationTable.GetMenu("menuWindowTileV", lang);
                        break;
                    case "menuHelp":
                        this.menuHelp.Text = m_Settings.LocalizationTable.GetMenu("menuHelp", lang);
                        break;
                    case "menuHelpHelp":
                        this.menuHelpHelp.Text = m_Settings.LocalizationTable.GetMenu("menuHelpHelp", lang);
                        break;
                    case "menuHelpAbout":
                        this.menuHelpAbout.Text = m_Settings.LocalizationTable.GetMenu("menuHelpAbout", lang);
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
                this.UpdStatusBarInfo(m_Settings.LocalizationTable.GetMessage("App80",
                    m_Settings.OptionSettings.UILanguage));
            }
        }

        private void NIY()
        // Not Implement Yet
        {
            //MessageBox.Show("Not Implemented Yet");
            MessageBox.Show(m_Settings.LocalizationTable.GetMessage("App79",
                m_Settings.OptionSettings.UILanguage));
        }

     }
}



using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using PrimerProObjects;
using PrimerProLocalization;
using GenLib;

namespace PrimerProForms
{
	/// <summary>
	/// Summary description for FormOptions.
	/// </summary>
	public class FormOptions : System.Windows.Forms.Form
    {
        public TabControl tabPage;
		private System.Windows.Forms.TabPage tabPageFile;
		private System.Windows.Forms.TabPage tabPageFormat;
		private System.Windows.Forms.TabPage tabPageView;
		private System.Windows.Forms.Button btnOptionsOK;
		private System.Windows.Forms.Button btnOptionsCancel;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button btnInventory;
		private System.Windows.Forms.TextBox tbFontName;
		private System.Windows.Forms.Button btnDfltFont;
		private System.Windows.Forms.Label labFontStyle;
		private System.Windows.Forms.Label labFontSize;
		private System.Windows.Forms.TextBox tbFontStyle;
		private System.Windows.Forms.TextBox tbFontSize;
		private System.Windows.Forms.CheckBox chkGlossEnglish;
		private System.Windows.Forms.CheckBox chkGlossNational;
		private System.Windows.Forms.CheckBox chkGlossRegional;
		private System.Windows.Forms.CheckBox chkPS;
		private System.Windows.Forms.CheckBox chkRoot;
		private System.Windows.Forms.CheckBox chkPlural;
		private System.Windows.Forms.CheckBox chkCVPattern;
		private System.Windows.Forms.CheckBox chkSyllBreaks;
		private System.Windows.Forms.TextBox tbInfoView;
		private System.Windows.Forms.TabPage tabPageSFM;
		private System.Windows.Forms.TextBox tbInfoSFM;
		private System.Windows.Forms.TextBox tbInfoSFM2;
		private System.Windows.Forms.Label labFMLX;
		private System.Windows.Forms.TextBox tbLX;
		private System.Windows.Forms.Label labFMGN;
		private System.Windows.Forms.Label labFMGE;
		private System.Windows.Forms.Label labFMGR;
		private System.Windows.Forms.Label labFMPS;
		private System.Windows.Forms.Label labFMPL;
		private System.Windows.Forms.Label labFMRT;
		private System.Windows.Forms.TextBox tbGE;
		private System.Windows.Forms.TextBox tbGN;
		private System.Windows.Forms.TextBox tbGR;
		private System.Windows.Forms.TextBox tbPS;
		private System.Windows.Forms.TextBox tbPL;
		private System.Windows.Forms.TextBox tbRT;
		private System.Windows.Forms.CheckBox chkOrigWord;
		private System.Windows.Forms.TabPage tabPageFolder;
		private System.Windows.Forms.Button btnSightWords;
		private System.Windows.Forms.Button btnHighlight;
		private System.Windows.Forms.TextBox tbHighlight;
		private System.Windows.Forms.Label labHighlight;
		private System.Windows.Forms.Label labFontName;
		private System.Windows.Forms.TextBox tbAppFolder;
		private System.Windows.Forms.Label labAppFolder;
		private System.Windows.Forms.Button btnTemplateFolder;
		private System.Windows.Forms.TextBox tbTemplateFolder;
		private System.Windows.Forms.Label labTemplateFolder;
		private System.Windows.Forms.Button btnDataFolder;
		private System.Windows.Forms.TextBox tbDataFolder;
		private System.Windows.Forms.Label labDataFolder;
		private System.Windows.Forms.TextBox tbSightWords;
		private System.Windows.Forms.Label labSightWords;
		private System.Windows.Forms.Label labInventory;
		private System.Windows.Forms.TextBox tbTextData;
		private System.Windows.Forms.Label labTextData;
		private System.Windows.Forms.TextBox tbWordList;
		private System.Windows.Forms.Label labWordList;
		private System.Windows.Forms.TextBox tbInventory;
		private System.Windows.Forms.TabPage tabPageCV;
		private System.Windows.Forms.Label labInfoCV;
		private System.Windows.Forms.Label labCns;
        private System.Windows.Forms.Label labCnsPrn;
		private System.Windows.Forms.Label labCnsVel;
		private System.Windows.Forms.Label labCnsPal;
		private System.Windows.Forms.Label labCnsLab;
		private System.Windows.Forms.TextBox tbCns;
		private System.Windows.Forms.TextBox tbCnsVel;
		private System.Windows.Forms.TextBox tbCnsPal;
		private System.Windows.Forms.TextBox tbCnsLab;
		private System.Windows.Forms.TextBox tbCnsPrn;
		private System.Windows.Forms.TextBox tbCnsSyl;
		private System.Windows.Forms.Label labVwl;
		private System.Windows.Forms.Label labVwlLng;
		private System.Windows.Forms.Label labVwlNsl;
		private System.Windows.Forms.TextBox tbVwl;
		private System.Windows.Forms.TextBox tbVwlNsl;
		private System.Windows.Forms.TextBox tbVwlLng;
		private System.Windows.Forms.CheckBox chkWordNoTone;
		private System.Windows.Forms.CheckBox chkRootNoTone;
        private TextBox tbCnsAsp;
        private Label labCnsAsp;
        private Label labGT;
        private Button btnGT;
        //private TextBox tbTaughtOrder;
        private Label labColor;
        private TabPage tabPagePunct;
        private Label labInfoPunct;
        private Label labEnding;
        private Label labGeneral;
        public Label labEnding2;
        private TextBox tbGeneral;
        private TextBox tbEnding;
        private Label labGeneral2;
        private Label labFMRM;
        private TextBox tbRM;
        private Label labCnsSyl;
        private Label labNoTBU;
        private TextBox tbTones;
        private Label labTones;
        private Label labText;
        private TabPage tabPageImport;
        private NumericUpDown nudMax;
        private Label labMax;
        private TextBox tbIgnoreChar;
        private Label labIgnore;
        private TextBox tbInfoImport;
        private CheckBox chkRootSyllBreaks;
        private CheckBox chkRootCVPattern;
        private DataGridView dgvReplace;
        private Label labReplace;
        private TextBox tbDipthongs;
        private Label labDiphthongs;
        private Button btnPoS;
        private TextBox tbPoS;
        private Label labPoS;
        private TabPage tabPageLift;
        private TextBox tbInfoLift;
        private Label labLiftGR;
        private Label labLiftVern;
        private Label labLiftGE;
        private Label labLiftGN;
        private TextBox tbLiftGR;
        private TextBox tbLiftGN;
        private TextBox tbLiftGE;
        private TextBox tbLiftVern;
        private TextBox tbInfoView2;
        private CheckBox chkParaSentWord;
        private TabPage tabPageUI;
        private GroupBox gbUILang;
        private RadioButton rbEnglish;
        private RadioButton rbFrench;
        private TextBox tbGT;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private TextBox tbSyllograph;
        private Label labSyllograph;
        private GroupBox gbMenu;
        private CheckBox chkSimplified;
		/// <summary>
		/// Required designer variable.
		/// </summary>

		private Settings m_Settings;

		public FormOptions(Settings s)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            if (s == null)
                m_Settings = new Settings();
			else m_Settings = s;
			OptionList m_OptionList = m_Settings.OptionSettings;
            string strReplace = "";
            string strWith = "";
            DataGridViewRow row = null;
			
			this.tbAppFolder.Text = m_Settings.GetAppFolder();
			this.tbDataFolder.Text = m_OptionList.DataFolder;
			this.tbTemplateFolder.Text = m_OptionList.TemplateFolder;
			this.tbInventory.Text = m_OptionList.GraphemeInventoryFile;
			this.tbWordList.Text = m_OptionList.WordListFile;
			this.tbTextData.Text = m_OptionList.TextDataFile;
			this.tbSightWords.Text = m_OptionList.SightWordsFile;
            this.tbGT.Text = m_OptionList.GraphemeTaughtOrderFile;
            this.tbPoS.Text = m_OptionList.PSTableFile;
			this.tbFontName.Text = m_OptionList.DefaultFontName;
			this.tbFontStyle.Text = m_OptionList.DefaultFontStyle.ToString();
			this.tbFontSize.Text = m_OptionList.DefaultFontSize.ToString();
            this.labText.Font = m_OptionList.GetDefaultFont();
            this.labColor.BackColor = m_OptionList.HighlightColor;
            this.labColor.ForeColor = Color.White;
            this.tbHighlight.Text = m_OptionList.HighlightColor.Name;
			this.chkOrigWord.Checked = m_OptionList.ViewOrigWord;
			this.chkGlossEnglish.Checked = m_OptionList.ViewGlossEnglish;
			this.chkGlossNational.Checked = m_OptionList.ViewGlossNational;
			this.chkGlossRegional.Checked = m_OptionList.ViewGlossRegional;
			this.chkPS.Checked = m_OptionList.ViewPS;
			this.chkPlural.Checked = m_OptionList.ViewPlural;
			this.chkRoot.Checked = m_OptionList.ViewRoot;
			this.chkCVPattern.Checked = m_OptionList.ViewCVPattern;
			this.chkSyllBreaks.Checked = m_OptionList.ViewSyllBreaks;
			this.chkWordNoTone.Checked = m_OptionList.ViewWordWithoutTone;
            this.chkRoot.Checked = m_OptionList.ViewRoot;
            this.chkRootCVPattern.Checked = m_OptionList.ViewRootCVPattern;
            this.chkRootSyllBreaks.Checked = m_OptionList.ViewRootSyllBreaks;
            this.chkRootNoTone.Checked = m_OptionList.ViewRootWithoutTone;
            this.chkParaSentWord.Checked = m_OptionList.ViewParaSentWord;
            this.tbRM.Text = m_OptionList.FMRecordMarker;
			this.tbLX.Text = m_OptionList.FMLexicon;
			this.tbGE.Text = m_OptionList.FMGlossEnglish;
			this.tbGN.Text = m_OptionList.FMGlossNational;
			this.tbGR.Text = m_OptionList.FMGlossRegional;
			this.tbPS.Text = m_OptionList.FMPS;
			this.tbPL.Text = m_OptionList.FMPlural;
			this.tbRT.Text = m_OptionList.FMRoot;
            this.tbLiftVern.Text = m_OptionList.LiftVernacular;
            this.tbLiftGE.Text = m_OptionList.LiftGlossEnglish;
            this.tbLiftGN.Text = m_OptionList.LiftGlossNational;
            this.tbLiftGR.Text = m_OptionList.LiftGlossRegional;
			this.tbCns.Text = m_OptionList.CVCns;
			this.tbCnsSyl.Text = m_OptionList.CVSyllbc;
			this.tbCnsPrn.Text = m_OptionList.CVPrensl;
			this.tbCnsLab.Text = m_OptionList.CVLablzd;
			this.tbCnsPal.Text = m_OptionList.CVPaltzd;
			this.tbCnsVel.Text = m_OptionList.CVVelrzd;
            this.tbCnsAsp.Text = m_OptionList.CVAspir;
			this.tbVwl.Text = m_OptionList.CVVwl;
			this.tbVwlNsl.Text = m_OptionList.CVVwlNsl;
			this.tbVwlLng.Text = m_OptionList.CVVwlLng;
            this.tbDipthongs.Text = m_OptionList.CVVwlDip;
            this.tbSyllograph.Text = m_OptionList.CVSyllograph;
            this.tbTones.Text = m_OptionList.CVTone;
            this.tbEnding.Text = m_OptionList.EndingPunct;
            if (m_OptionList.GeneralPunct.IndexOf(Constants.Space) < 0)
                m_OptionList.GeneralPunct = Constants.Space.ToString() + m_OptionList.GeneralPunct;
            this.tbGeneral.Text = m_OptionList.GeneralPunct;
            this.nudMax.Value = Convert.ToDecimal(m_OptionList.MaxSizeGrapheme);
            this.tbIgnoreChar.Text = m_OptionList.ImportIgnoreChars;
            if (m_OptionList.ImportReplacementList != null)
            {
                for (int i = 0; i < m_OptionList.ImportReplacementList.ListCount(); i++)
                {
                    strReplace = m_OptionList.ImportReplacementList.GetReplaceString(i);
                    strWith = m_OptionList.ImportReplacementList.GetWithString(i);
                    row = new DataGridViewRow();
                    row.CreateCells(dgvReplace);
                    row.Cells[0].Value = strReplace;
                    row.Cells[1].Value = strWith;
                    this.dgvReplace.Rows.Add(row);
                }
            }
            if (m_OptionList.UILanguage == OptionList.kFrench)
                this.rbFrench.Checked = true;
            else this.rbEnglish.Checked = true;
			this.chkPlural.Checked = m_OptionList.ViewPlural;
            this.chkSimplified.Checked = m_OptionList.SimplifiedMenu;

            LocalizationTable table = m_Settings.LocalizationTable;
            string lang = m_OptionList.UILanguage;
            this.Text = table.GetForm("FormOptionsT", lang);
            this.tabPageFolder.Text = table.GetForm("FormOptionsFT", lang);
            this.labDataFolder.Text = table.GetForm("FormOptionsF0", lang);
            this.btnDataFolder.Text = table.GetForm("FormOptionsF2", lang);
            this.labTemplateFolder.Text = table.GetForm("FormOptionsF3", lang);
            this.btnTemplateFolder.Text = table.GetForm("FormOptionsF5", lang);
            this.labAppFolder.Text = table.GetForm("FormOptionsF6", lang);
            this.tabPageFile.Text = table.GetForm("FormOptionsXT", lang);
            this.labInventory.Text = table.GetForm("FormOptionsX0", lang);
            this.btnInventory.Text = table.GetForm("FormOptionsX2", lang);
            this.labSightWords.Text = table.GetForm("FormOptionsX3", lang);
            this.btnSightWords.Text = table.GetForm("FormOptionsX5", lang);
            this.labGT.Text = table.GetForm("FormOptionsX6", lang);
            this.btnGT.Text = table.GetForm("FormOptionsX8", lang);
            this.labPoS.Text = table.GetForm("FormOptionsX9", lang);
            this.btnPoS.Text = table.GetForm("FormOptionsX11", lang);
            this.labWordList.Text = table.GetForm("FormOptionsX12", lang);
            this.labTextData.Text = table.GetForm("FormOptionsX14", lang);
            this.tabPageFormat.Text = table.GetForm("FormOptionsOT", lang);
            this.btnDfltFont.Text = table.GetForm("FormOptionsO0", lang);
            this.labText.Text = table.GetForm("FormOptionsO1", lang);
            this.labFontName.Text = table.GetForm("FormOptionsO2", lang);
            this.labFontStyle.Text = table.GetForm("FormOptionsO4", lang);
            this.labFontSize.Text = table.GetForm("FormOptionsO6", lang);
            this.btnHighlight.Text = table.GetForm("FormOptionsO8", lang);
            this.labColor.Text = table.GetForm("FormOptionsO9", lang);
            this.labHighlight.Text = table.GetForm("FormOptionsO10", lang);
            this.tabPageView.Text = table.GetForm("FormOptionsVT", lang);
            this.tbInfoView.Text = table.GetForm("FormOptionsV0", lang);
            this.chkOrigWord.Text = table.GetForm("FormOptionsV1", lang);
            this.chkGlossEnglish.Text = table.GetForm("FormOptionsV2", lang);
            this.chkGlossNational.Text = table.GetForm("FormOptionsV3", lang);
            this.chkGlossRegional.Text = table.GetForm("FormOptionsV4", lang);
            this.chkPS.Text = table.GetForm("FormOptionsV5", lang);
            this.chkPlural.Text = table.GetForm("FormOptionsV6", lang);
            this.chkCVPattern.Text = table.GetForm("FormOptionsV7", lang);
            this.chkSyllBreaks.Text = table.GetForm("FormOptionsV8", lang);
            this.chkWordNoTone.Text = table.GetForm("FormOptionsV9", lang);
            this.chkRoot.Text = table.GetForm("FormOptionsV10", lang);
            this.chkRootCVPattern.Text = table.GetForm("FormOptionsV11", lang);
            this.chkRootSyllBreaks.Text = table.GetForm("FormOptionsV12", lang);
            this.chkRootNoTone.Text = table.GetForm("FormOptionsV13", lang);
            this.tbInfoView2.Text = table.GetForm("FormOptionsV14", lang);
            this.chkParaSentWord.Text = table.GetForm("FormOptionsV15", lang);
            this.tabPageSFM.Text = table.GetForm("FormOptionsST", lang);
            this.tbInfoSFM.Text = table.GetForm("FormOptionsS0", lang);
            this.labFMRM.Text = table.GetForm("FormOptionsS1", lang);
            this.labFMLX.Text = table.GetForm("FormOptionsS3", lang);
            this.labFMGE.Text = table.GetForm("FormOptionsS5", lang);
            this.labFMGN.Text = table.GetForm("FormOptionsS7", lang);
            this.labFMGR.Text = table.GetForm("FormOptionsS9", lang);
            this.labFMPS.Text = table.GetForm("FormOptionsS11", lang);
            this.labFMRT.Text = table.GetForm("FormOptionsS13", lang);
            this.labFMPL.Text = table.GetForm("FormOptionsS15", lang);
            this.tbInfoSFM2.Text = table.GetForm("FormOptionsS17", lang);
            this.tabPageLift.Text = table.GetForm("FormOptionsLT", lang);
            this.tbInfoLift.Text = table.GetForm("FormOptionsL0", lang);
            this.labLiftVern.Text = table.GetForm("FormOptionsL1", lang);
            this.labLiftGE.Text = table.GetForm("FormOptionsL3", lang);
            this.labLiftGN.Text = table.GetForm("FormOptionsL5", lang);
            this.labLiftGR.Text = table.GetForm("FormOptionsL7", lang);
            this.tabPageCV.Text = table.GetForm("FormOptionsCT", lang);
            this.labInfoCV.Text = table.GetForm("FormOptionsC0", lang);
            this.labCns.Text = table.GetForm("FormOptionsC1", lang);
            this.labCnsSyl.Text = table.GetForm("FormOptionsC3", lang);
            this.labCnsPrn.Text = table.GetForm("FormOptionsC5", lang);
            this.labCnsLab.Text = table.GetForm("FormOptionsC7", lang);
            this.labCnsPal.Text = table.GetForm("FormOptionsC9", lang);
            this.labCnsVel.Text = table.GetForm("FormOptionsC11", lang);
            this.labCnsAsp.Text = table.GetForm("FormOptionsC13", lang);
            this.labVwl.Text = table.GetForm("FormOptionsC15", lang);
            this.labVwlNsl.Text = table.GetForm("FormOptionsC17", lang);
            this.labVwlLng.Text = table.GetForm("FormOptionsC19", lang);
            this.labDiphthongs.Text = table.GetForm("FormOptionsC21", lang);
            this.labSyllograph.Text = table.GetForm("FormOptionsC23", lang);
            this.labTones.Text = table.GetForm("FormOptionsC25", lang);
            this.labNoTBU.Text = table.GetForm("FormOptionsC27", lang);
            this.tabPagePunct.Text = table.GetForm("FormOptionsPT", lang);
            this.labInfoPunct.Text = table.GetForm("FormOptionsP0", lang);
            this.labEnding.Text = table.GetForm("FormOptionsP1", lang);
            this.labGeneral.Text = table.GetForm("FormOptionsP3", lang);
            this.labEnding2.Text = table.GetForm("FormOptionsP4", lang);
            this.labGeneral2.Text = table.GetForm("FormOptionsP6", lang);
            this.tabPageImport.Text = table.GetForm("FormOptionsIT", lang);
            this.tbInfoImport.Text = table.GetForm("FormOptionsI0", lang);
            this.labMax.Text = table.GetForm("FormOptionsI1", lang);
            this.labIgnore.Text = table.GetForm("FormOptionsI3", lang);
            this.labReplace.Text = table.GetForm("FormOptionsI5", lang);
            this.dgvReplace.Columns[0].HeaderText = table.GetForm("FormOptionsI6A", lang);
            this.dgvReplace.Columns[1].HeaderText = table.GetForm("FormOptionsI6B", lang);
            this.tabPageUI.Text = table.GetForm("FormOptionsUT", lang);
            this.gbUILang.Text = table.GetForm("FormOptionsU0", lang);
// To Do
//            this.gbMenu.Text = table.GetForm("FormOptionsU1", lang);
//            this.chkSimplified.Text = table.GetForm("FormOptionsU2", lang);
            this.btnOptionsOK.Text = table.GetForm("FormOptions1", lang);
            this.btnOptionsCancel.Text = table.GetForm("FormOptions2", lang);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOptions));
            this.tabPage = new System.Windows.Forms.TabControl();
            this.tabPageFolder = new System.Windows.Forms.TabPage();
            this.tbAppFolder = new System.Windows.Forms.TextBox();
            this.labAppFolder = new System.Windows.Forms.Label();
            this.btnTemplateFolder = new System.Windows.Forms.Button();
            this.tbTemplateFolder = new System.Windows.Forms.TextBox();
            this.labTemplateFolder = new System.Windows.Forms.Label();
            this.btnDataFolder = new System.Windows.Forms.Button();
            this.tbDataFolder = new System.Windows.Forms.TextBox();
            this.labDataFolder = new System.Windows.Forms.Label();
            this.tabPageFile = new System.Windows.Forms.TabPage();
            this.btnPoS = new System.Windows.Forms.Button();
            this.tbPoS = new System.Windows.Forms.TextBox();
            this.labPoS = new System.Windows.Forms.Label();
            this.btnGT = new System.Windows.Forms.Button();
            this.tbGT = new System.Windows.Forms.TextBox();
            this.labGT = new System.Windows.Forms.Label();
            this.btnSightWords = new System.Windows.Forms.Button();
            this.tbSightWords = new System.Windows.Forms.TextBox();
            this.labSightWords = new System.Windows.Forms.Label();
            this.btnInventory = new System.Windows.Forms.Button();
            this.tbInventory = new System.Windows.Forms.TextBox();
            this.labInventory = new System.Windows.Forms.Label();
            this.tbTextData = new System.Windows.Forms.TextBox();
            this.labTextData = new System.Windows.Forms.Label();
            this.tbWordList = new System.Windows.Forms.TextBox();
            this.labWordList = new System.Windows.Forms.Label();
            this.tabPageFormat = new System.Windows.Forms.TabPage();
            this.labText = new System.Windows.Forms.Label();
            this.labColor = new System.Windows.Forms.Label();
            this.btnHighlight = new System.Windows.Forms.Button();
            this.tbHighlight = new System.Windows.Forms.TextBox();
            this.labHighlight = new System.Windows.Forms.Label();
            this.tbFontSize = new System.Windows.Forms.TextBox();
            this.tbFontStyle = new System.Windows.Forms.TextBox();
            this.labFontSize = new System.Windows.Forms.Label();
            this.labFontStyle = new System.Windows.Forms.Label();
            this.btnDfltFont = new System.Windows.Forms.Button();
            this.tbFontName = new System.Windows.Forms.TextBox();
            this.labFontName = new System.Windows.Forms.Label();
            this.tabPageView = new System.Windows.Forms.TabPage();
            this.chkParaSentWord = new System.Windows.Forms.CheckBox();
            this.tbInfoView2 = new System.Windows.Forms.TextBox();
            this.chkRootSyllBreaks = new System.Windows.Forms.CheckBox();
            this.chkRootCVPattern = new System.Windows.Forms.CheckBox();
            this.chkRootNoTone = new System.Windows.Forms.CheckBox();
            this.chkWordNoTone = new System.Windows.Forms.CheckBox();
            this.chkOrigWord = new System.Windows.Forms.CheckBox();
            this.chkSyllBreaks = new System.Windows.Forms.CheckBox();
            this.chkCVPattern = new System.Windows.Forms.CheckBox();
            this.chkPlural = new System.Windows.Forms.CheckBox();
            this.chkRoot = new System.Windows.Forms.CheckBox();
            this.chkPS = new System.Windows.Forms.CheckBox();
            this.chkGlossRegional = new System.Windows.Forms.CheckBox();
            this.chkGlossNational = new System.Windows.Forms.CheckBox();
            this.tbInfoView = new System.Windows.Forms.TextBox();
            this.chkGlossEnglish = new System.Windows.Forms.CheckBox();
            this.tabPageSFM = new System.Windows.Forms.TabPage();
            this.tbRM = new System.Windows.Forms.TextBox();
            this.labFMRM = new System.Windows.Forms.Label();
            this.tbRT = new System.Windows.Forms.TextBox();
            this.tbPL = new System.Windows.Forms.TextBox();
            this.tbPS = new System.Windows.Forms.TextBox();
            this.tbGR = new System.Windows.Forms.TextBox();
            this.tbGN = new System.Windows.Forms.TextBox();
            this.tbGE = new System.Windows.Forms.TextBox();
            this.labFMRT = new System.Windows.Forms.Label();
            this.labFMPL = new System.Windows.Forms.Label();
            this.labFMPS = new System.Windows.Forms.Label();
            this.labFMGR = new System.Windows.Forms.Label();
            this.labFMGE = new System.Windows.Forms.Label();
            this.labFMGN = new System.Windows.Forms.Label();
            this.tbLX = new System.Windows.Forms.TextBox();
            this.labFMLX = new System.Windows.Forms.Label();
            this.tbInfoSFM2 = new System.Windows.Forms.TextBox();
            this.tbInfoSFM = new System.Windows.Forms.TextBox();
            this.tabPageLift = new System.Windows.Forms.TabPage();
            this.tbLiftGR = new System.Windows.Forms.TextBox();
            this.tbLiftGN = new System.Windows.Forms.TextBox();
            this.tbLiftGE = new System.Windows.Forms.TextBox();
            this.tbLiftVern = new System.Windows.Forms.TextBox();
            this.labLiftVern = new System.Windows.Forms.Label();
            this.labLiftGE = new System.Windows.Forms.Label();
            this.labLiftGN = new System.Windows.Forms.Label();
            this.labLiftGR = new System.Windows.Forms.Label();
            this.tbInfoLift = new System.Windows.Forms.TextBox();
            this.tabPageCV = new System.Windows.Forms.TabPage();
            this.tbSyllograph = new System.Windows.Forms.TextBox();
            this.labSyllograph = new System.Windows.Forms.Label();
            this.tbDipthongs = new System.Windows.Forms.TextBox();
            this.labDiphthongs = new System.Windows.Forms.Label();
            this.labNoTBU = new System.Windows.Forms.Label();
            this.tbTones = new System.Windows.Forms.TextBox();
            this.labTones = new System.Windows.Forms.Label();
            this.labCnsSyl = new System.Windows.Forms.Label();
            this.tbCnsAsp = new System.Windows.Forms.TextBox();
            this.labCnsAsp = new System.Windows.Forms.Label();
            this.tbVwlLng = new System.Windows.Forms.TextBox();
            this.tbVwlNsl = new System.Windows.Forms.TextBox();
            this.tbVwl = new System.Windows.Forms.TextBox();
            this.labVwlNsl = new System.Windows.Forms.Label();
            this.labVwlLng = new System.Windows.Forms.Label();
            this.labVwl = new System.Windows.Forms.Label();
            this.tbCnsSyl = new System.Windows.Forms.TextBox();
            this.tbCnsPrn = new System.Windows.Forms.TextBox();
            this.tbCnsLab = new System.Windows.Forms.TextBox();
            this.tbCnsPal = new System.Windows.Forms.TextBox();
            this.tbCnsVel = new System.Windows.Forms.TextBox();
            this.tbCns = new System.Windows.Forms.TextBox();
            this.labCnsLab = new System.Windows.Forms.Label();
            this.labCnsPal = new System.Windows.Forms.Label();
            this.labCnsVel = new System.Windows.Forms.Label();
            this.labCnsPrn = new System.Windows.Forms.Label();
            this.labCns = new System.Windows.Forms.Label();
            this.labInfoCV = new System.Windows.Forms.Label();
            this.tabPagePunct = new System.Windows.Forms.TabPage();
            this.labGeneral2 = new System.Windows.Forms.Label();
            this.tbGeneral = new System.Windows.Forms.TextBox();
            this.tbEnding = new System.Windows.Forms.TextBox();
            this.labGeneral = new System.Windows.Forms.Label();
            this.labEnding2 = new System.Windows.Forms.Label();
            this.labEnding = new System.Windows.Forms.Label();
            this.labInfoPunct = new System.Windows.Forms.Label();
            this.tabPageImport = new System.Windows.Forms.TabPage();
            this.labReplace = new System.Windows.Forms.Label();
            this.dgvReplace = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbInfoImport = new System.Windows.Forms.TextBox();
            this.tbIgnoreChar = new System.Windows.Forms.TextBox();
            this.labIgnore = new System.Windows.Forms.Label();
            this.nudMax = new System.Windows.Forms.NumericUpDown();
            this.labMax = new System.Windows.Forms.Label();
            this.tabPageUI = new System.Windows.Forms.TabPage();
            this.gbMenu = new System.Windows.Forms.GroupBox();
            this.chkSimplified = new System.Windows.Forms.CheckBox();
            this.gbUILang = new System.Windows.Forms.GroupBox();
            this.rbFrench = new System.Windows.Forms.RadioButton();
            this.rbEnglish = new System.Windows.Forms.RadioButton();
            this.btnOptionsOK = new System.Windows.Forms.Button();
            this.btnOptionsCancel = new System.Windows.Forms.Button();
            this.tabPage.SuspendLayout();
            this.tabPageFolder.SuspendLayout();
            this.tabPageFile.SuspendLayout();
            this.tabPageFormat.SuspendLayout();
            this.tabPageView.SuspendLayout();
            this.tabPageSFM.SuspendLayout();
            this.tabPageLift.SuspendLayout();
            this.tabPageCV.SuspendLayout();
            this.tabPagePunct.SuspendLayout();
            this.tabPageImport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReplace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMax)).BeginInit();
            this.tabPageUI.SuspendLayout();
            this.gbMenu.SuspendLayout();
            this.gbUILang.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage
            // 
            this.tabPage.Controls.Add(this.tabPageFolder);
            this.tabPage.Controls.Add(this.tabPageFile);
            this.tabPage.Controls.Add(this.tabPageFormat);
            this.tabPage.Controls.Add(this.tabPageView);
            this.tabPage.Controls.Add(this.tabPageSFM);
            this.tabPage.Controls.Add(this.tabPageLift);
            this.tabPage.Controls.Add(this.tabPageCV);
            this.tabPage.Controls.Add(this.tabPagePunct);
            this.tabPage.Controls.Add(this.tabPageImport);
            this.tabPage.Controls.Add(this.tabPageUI);
            this.tabPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage.Location = new System.Drawing.Point(7, 2);
            this.tabPage.Name = "tabPage";
            this.tabPage.SelectedIndex = 0;
            this.tabPage.ShowToolTips = true;
            this.tabPage.Size = new System.Drawing.Size(656, 303);
            this.tabPage.TabIndex = 1;
            // 
            // tabPageFolder
            // 
            this.tabPageFolder.Controls.Add(this.tbAppFolder);
            this.tabPageFolder.Controls.Add(this.labAppFolder);
            this.tabPageFolder.Controls.Add(this.btnTemplateFolder);
            this.tabPageFolder.Controls.Add(this.tbTemplateFolder);
            this.tabPageFolder.Controls.Add(this.labTemplateFolder);
            this.tabPageFolder.Controls.Add(this.btnDataFolder);
            this.tabPageFolder.Controls.Add(this.tbDataFolder);
            this.tabPageFolder.Controls.Add(this.labDataFolder);
            this.tabPageFolder.Location = new System.Drawing.Point(4, 24);
            this.tabPageFolder.Name = "tabPageFolder";
            this.tabPageFolder.Size = new System.Drawing.Size(648, 275);
            this.tabPageFolder.TabIndex = 5;
            this.tabPageFolder.Text = "Folders";
            this.tabPageFolder.UseVisualStyleBackColor = true;
            // 
            // tbAppFolder
            // 
            this.tbAppFolder.Location = new System.Drawing.Point(120, 132);
            this.tbAppFolder.Name = "tbAppFolder";
            this.tbAppFolder.ReadOnly = true;
            this.tbAppFolder.Size = new System.Drawing.Size(507, 21);
            this.tbAppFolder.TabIndex = 7;
            this.tbAppFolder.TabStop = false;
            // 
            // labAppFolder
            // 
            this.labAppFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labAppFolder.Location = new System.Drawing.Point(17, 132);
            this.labAppFolder.Name = "labAppFolder";
            this.labAppFolder.Size = new System.Drawing.Size(108, 38);
            this.labAppFolder.TabIndex = 6;
            this.labAppFolder.Text = "Application folder";
            // 
            // btnTemplateFolder
            // 
            this.btnTemplateFolder.Location = new System.Drawing.Point(559, 62);
            this.btnTemplateFolder.Name = "btnTemplateFolder";
            this.btnTemplateFolder.Size = new System.Drawing.Size(83, 28);
            this.btnTemplateFolder.TabIndex = 5;
            this.btnTemplateFolder.Text = "Browse";
            this.btnTemplateFolder.Click += new System.EventHandler(this.btnTemplateFolder_Click);
            // 
            // tbTemplateFolder
            // 
            this.tbTemplateFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTemplateFolder.Location = new System.Drawing.Point(120, 60);
            this.tbTemplateFolder.Name = "tbTemplateFolder";
            this.tbTemplateFolder.Size = new System.Drawing.Size(426, 21);
            this.tbTemplateFolder.TabIndex = 4;
            // 
            // labTemplateFolder
            // 
            this.labTemplateFolder.Location = new System.Drawing.Point(17, 62);
            this.labTemplateFolder.Name = "labTemplateFolder";
            this.labTemplateFolder.Size = new System.Drawing.Size(100, 40);
            this.labTemplateFolder.TabIndex = 3;
            this.labTemplateFolder.Text = "Template folder";
            // 
            // btnDataFolder
            // 
            this.btnDataFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDataFolder.Location = new System.Drawing.Point(559, 21);
            this.btnDataFolder.Name = "btnDataFolder";
            this.btnDataFolder.Size = new System.Drawing.Size(83, 28);
            this.btnDataFolder.TabIndex = 2;
            this.btnDataFolder.Text = "Browse";
            this.btnDataFolder.Click += new System.EventHandler(this.btnDataFolder_Click);
            // 
            // tbDataFolder
            // 
            this.tbDataFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDataFolder.Location = new System.Drawing.Point(120, 21);
            this.tbDataFolder.Name = "tbDataFolder";
            this.tbDataFolder.Size = new System.Drawing.Size(426, 21);
            this.tbDataFolder.TabIndex = 1;
            // 
            // labDataFolder
            // 
            this.labDataFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDataFolder.Location = new System.Drawing.Point(17, 21);
            this.labDataFolder.Name = "labDataFolder";
            this.labDataFolder.Size = new System.Drawing.Size(100, 34);
            this.labDataFolder.TabIndex = 0;
            this.labDataFolder.Text = "Data folder";
            // 
            // tabPageFile
            // 
            this.tabPageFile.Controls.Add(this.btnPoS);
            this.tabPageFile.Controls.Add(this.tbPoS);
            this.tabPageFile.Controls.Add(this.labPoS);
            this.tabPageFile.Controls.Add(this.btnGT);
            this.tabPageFile.Controls.Add(this.tbGT);
            this.tabPageFile.Controls.Add(this.labGT);
            this.tabPageFile.Controls.Add(this.btnSightWords);
            this.tabPageFile.Controls.Add(this.tbSightWords);
            this.tabPageFile.Controls.Add(this.labSightWords);
            this.tabPageFile.Controls.Add(this.btnInventory);
            this.tabPageFile.Controls.Add(this.tbInventory);
            this.tabPageFile.Controls.Add(this.labInventory);
            this.tabPageFile.Controls.Add(this.tbTextData);
            this.tabPageFile.Controls.Add(this.labTextData);
            this.tabPageFile.Controls.Add(this.tbWordList);
            this.tabPageFile.Controls.Add(this.labWordList);
            this.tabPageFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageFile.Location = new System.Drawing.Point(4, 24);
            this.tabPageFile.Name = "tabPageFile";
            this.tabPageFile.Size = new System.Drawing.Size(648, 275);
            this.tabPageFile.TabIndex = 0;
            this.tabPageFile.Text = "Files";
            this.tabPageFile.UseVisualStyleBackColor = true;
            // 
            // btnPoS
            // 
            this.btnPoS.Location = new System.Drawing.Point(561, 165);
            this.btnPoS.Name = "btnPoS";
            this.btnPoS.Size = new System.Drawing.Size(83, 27);
            this.btnPoS.TabIndex = 11;
            this.btnPoS.Text = "Browse";
            this.btnPoS.Click += new System.EventHandler(this.btnPoS_Click);
            // 
            // tbPoS
            // 
            this.tbPoS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPoS.Location = new System.Drawing.Point(126, 165);
            this.tbPoS.Multiline = true;
            this.tbPoS.Name = "tbPoS";
            this.tbPoS.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbPoS.Size = new System.Drawing.Size(430, 38);
            this.tbPoS.TabIndex = 10;
            // 
            // labPoS
            // 
            this.labPoS.Location = new System.Drawing.Point(12, 159);
            this.labPoS.Name = "labPoS";
            this.labPoS.Size = new System.Drawing.Size(117, 35);
            this.labPoS.TabIndex = 9;
            this.labPoS.Text = "Current Parts of Speech";
            // 
            // btnGT
            // 
            this.btnGT.Location = new System.Drawing.Point(561, 119);
            this.btnGT.Name = "btnGT";
            this.btnGT.Size = new System.Drawing.Size(83, 27);
            this.btnGT.TabIndex = 8;
            this.btnGT.Text = "Browse";
            this.btnGT.Click += new System.EventHandler(this.btnTaughtOrder_Click);
            // 
            // tbGT
            // 
            this.tbGT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGT.Location = new System.Drawing.Point(127, 119);
            this.tbGT.Multiline = true;
            this.tbGT.Name = "tbGT";
            this.tbGT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbGT.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbGT.Size = new System.Drawing.Size(429, 38);
            this.tbGT.TabIndex = 0;
            // 
            // labGT
            // 
            this.labGT.Location = new System.Drawing.Point(13, 117);
            this.labGT.Name = "labGT";
            this.labGT.Size = new System.Drawing.Size(117, 35);
            this.labGT.TabIndex = 6;
            this.labGT.Text = "Current Graphemes Taught";
            // 
            // btnSightWords
            // 
            this.btnSightWords.Location = new System.Drawing.Point(562, 70);
            this.btnSightWords.Name = "btnSightWords";
            this.btnSightWords.Size = new System.Drawing.Size(84, 28);
            this.btnSightWords.TabIndex = 5;
            this.btnSightWords.Text = "Browse";
            this.btnSightWords.Click += new System.EventHandler(this.btnSightWords_Click);
            // 
            // tbSightWords
            // 
            this.tbSightWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSightWords.Location = new System.Drawing.Point(127, 69);
            this.tbSightWords.Multiline = true;
            this.tbSightWords.Name = "tbSightWords";
            this.tbSightWords.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbSightWords.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbSightWords.Size = new System.Drawing.Size(429, 38);
            this.tbSightWords.TabIndex = 4;
            // 
            // labSightWords
            // 
            this.labSightWords.Location = new System.Drawing.Point(13, 70);
            this.labSightWords.Name = "labSightWords";
            this.labSightWords.Size = new System.Drawing.Size(117, 35);
            this.labSightWords.TabIndex = 3;
            this.labSightWords.Text = "Current Sight Words";
            // 
            // btnInventory
            // 
            this.btnInventory.Location = new System.Drawing.Point(562, 21);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(84, 28);
            this.btnInventory.TabIndex = 2;
            this.btnInventory.Text = "Browse";
            this.btnInventory.Click += new System.EventHandler(this.btnGrfInventory_Click);
            // 
            // tbInventory
            // 
            this.tbInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInventory.Location = new System.Drawing.Point(127, 21);
            this.tbInventory.Multiline = true;
            this.tbInventory.Name = "tbInventory";
            this.tbInventory.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbInventory.Size = new System.Drawing.Size(429, 38);
            this.tbInventory.TabIndex = 1;
            // 
            // labInventory
            // 
            this.labInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInventory.Location = new System.Drawing.Point(13, 21);
            this.labInventory.Name = "labInventory";
            this.labInventory.Size = new System.Drawing.Size(117, 34);
            this.labInventory.TabIndex = 0;
            this.labInventory.Text = "Current Grapheme Inventory";
            // 
            // tbTextData
            // 
            this.tbTextData.Location = new System.Drawing.Point(148, 235);
            this.tbTextData.Name = "tbTextData";
            this.tbTextData.ReadOnly = true;
            this.tbTextData.Size = new System.Drawing.Size(485, 21);
            this.tbTextData.TabIndex = 15;
            this.tbTextData.TabStop = false;
            // 
            // labTextData
            // 
            this.labTextData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTextData.Location = new System.Drawing.Point(13, 235);
            this.labTextData.Name = "labTextData";
            this.labTextData.Size = new System.Drawing.Size(130, 20);
            this.labTextData.TabIndex = 14;
            this.labTextData.Text = "Current Text Data";
            // 
            // tbWordList
            // 
            this.tbWordList.Location = new System.Drawing.Point(148, 209);
            this.tbWordList.Name = "tbWordList";
            this.tbWordList.ReadOnly = true;
            this.tbWordList.Size = new System.Drawing.Size(485, 21);
            this.tbWordList.TabIndex = 13;
            this.tbWordList.TabStop = false;
            // 
            // labWordList
            // 
            this.labWordList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labWordList.Location = new System.Drawing.Point(12, 211);
            this.labWordList.Name = "labWordList";
            this.labWordList.Size = new System.Drawing.Size(131, 20);
            this.labWordList.TabIndex = 12;
            this.labWordList.Text = "Current Word List";
            // 
            // tabPageFormat
            // 
            this.tabPageFormat.Controls.Add(this.labText);
            this.tabPageFormat.Controls.Add(this.labColor);
            this.tabPageFormat.Controls.Add(this.btnHighlight);
            this.tabPageFormat.Controls.Add(this.tbHighlight);
            this.tabPageFormat.Controls.Add(this.labHighlight);
            this.tabPageFormat.Controls.Add(this.tbFontSize);
            this.tabPageFormat.Controls.Add(this.tbFontStyle);
            this.tabPageFormat.Controls.Add(this.labFontSize);
            this.tabPageFormat.Controls.Add(this.labFontStyle);
            this.tabPageFormat.Controls.Add(this.btnDfltFont);
            this.tabPageFormat.Controls.Add(this.tbFontName);
            this.tabPageFormat.Controls.Add(this.labFontName);
            this.tabPageFormat.Location = new System.Drawing.Point(4, 24);
            this.tabPageFormat.Name = "tabPageFormat";
            this.tabPageFormat.Size = new System.Drawing.Size(648, 275);
            this.tabPageFormat.TabIndex = 2;
            this.tabPageFormat.Text = "Format";
            this.tabPageFormat.UseVisualStyleBackColor = true;
            // 
            // labText
            // 
            this.labText.AutoSize = true;
            this.labText.BackColor = System.Drawing.SystemColors.Window;
            this.labText.ForeColor = System.Drawing.SystemColors.WindowText;
            this.labText.Location = new System.Drawing.Point(403, 23);
            this.labText.Name = "labText";
            this.labText.Size = new System.Drawing.Size(76, 15);
            this.labText.TabIndex = 1;
            this.labText.Text = "Sample Text";
            // 
            // labColor
            // 
            this.labColor.AutoSize = true;
            this.labColor.BackColor = System.Drawing.SystemColors.Window;
            this.labColor.ForeColor = System.Drawing.SystemColors.WindowText;
            this.labColor.Location = new System.Drawing.Point(403, 165);
            this.labColor.Name = "labColor";
            this.labColor.Size = new System.Drawing.Size(82, 15);
            this.labColor.TabIndex = 9;
            this.labColor.Text = "Sample Color";
            // 
            // btnHighlight
            // 
            this.btnHighlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHighlight.Location = new System.Drawing.Point(162, 162);
            this.btnHighlight.Name = "btnHighlight";
            this.btnHighlight.Size = new System.Drawing.Size(214, 28);
            this.btnHighlight.TabIndex = 8;
            this.btnHighlight.Text = "Change hightlight &color";
            this.btnHighlight.Click += new System.EventHandler(this.btnHighlight_Click);
            // 
            // tbHighlight
            // 
            this.tbHighlight.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbHighlight.Location = new System.Drawing.Point(162, 201);
            this.tbHighlight.Name = "tbHighlight";
            this.tbHighlight.ReadOnly = true;
            this.tbHighlight.Size = new System.Drawing.Size(214, 21);
            this.tbHighlight.TabIndex = 11;
            // 
            // labHighlight
            // 
            this.labHighlight.Location = new System.Drawing.Point(33, 201);
            this.labHighlight.Name = "labHighlight";
            this.labHighlight.Size = new System.Drawing.Size(124, 34);
            this.labHighlight.TabIndex = 10;
            this.labHighlight.Text = "Highlight color";
            // 
            // tbFontSize
            // 
            this.tbFontSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFontSize.Location = new System.Drawing.Point(162, 111);
            this.tbFontSize.Name = "tbFontSize";
            this.tbFontSize.ReadOnly = true;
            this.tbFontSize.Size = new System.Drawing.Size(214, 21);
            this.tbFontSize.TabIndex = 7;
            // 
            // tbFontStyle
            // 
            this.tbFontStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFontStyle.Location = new System.Drawing.Point(162, 83);
            this.tbFontStyle.Name = "tbFontStyle";
            this.tbFontStyle.ReadOnly = true;
            this.tbFontStyle.Size = new System.Drawing.Size(214, 21);
            this.tbFontStyle.TabIndex = 5;
            // 
            // labFontSize
            // 
            this.labFontSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labFontSize.Location = new System.Drawing.Point(33, 111);
            this.labFontSize.Name = "labFontSize";
            this.labFontSize.Size = new System.Drawing.Size(124, 20);
            this.labFontSize.TabIndex = 6;
            this.labFontSize.Text = "Font size";
            // 
            // labFontStyle
            // 
            this.labFontStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labFontStyle.Location = new System.Drawing.Point(33, 83);
            this.labFontStyle.Name = "labFontStyle";
            this.labFontStyle.Size = new System.Drawing.Size(124, 20);
            this.labFontStyle.TabIndex = 4;
            this.labFontStyle.Text = "Font style";
            // 
            // btnDfltFont
            // 
            this.btnDfltFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDfltFont.Location = new System.Drawing.Point(162, 16);
            this.btnDfltFont.Name = "btnDfltFont";
            this.btnDfltFont.Size = new System.Drawing.Size(214, 28);
            this.btnDfltFont.TabIndex = 0;
            this.btnDfltFont.Text = "Change default &font";
            this.btnDfltFont.Click += new System.EventHandler(this.btnDfltFont_Click);
            // 
            // tbFontName
            // 
            this.tbFontName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFontName.Location = new System.Drawing.Point(162, 55);
            this.tbFontName.Name = "tbFontName";
            this.tbFontName.ReadOnly = true;
            this.tbFontName.Size = new System.Drawing.Size(214, 21);
            this.tbFontName.TabIndex = 3;
            // 
            // labFontName
            // 
            this.labFontName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labFontName.Location = new System.Drawing.Point(33, 55);
            this.labFontName.Name = "labFontName";
            this.labFontName.Size = new System.Drawing.Size(124, 20);
            this.labFontName.TabIndex = 2;
            this.labFontName.Text = "Font name";
            // 
            // tabPageView
            // 
            this.tabPageView.Controls.Add(this.chkParaSentWord);
            this.tabPageView.Controls.Add(this.tbInfoView2);
            this.tabPageView.Controls.Add(this.chkRootSyllBreaks);
            this.tabPageView.Controls.Add(this.chkRootCVPattern);
            this.tabPageView.Controls.Add(this.chkRootNoTone);
            this.tabPageView.Controls.Add(this.chkWordNoTone);
            this.tabPageView.Controls.Add(this.chkOrigWord);
            this.tabPageView.Controls.Add(this.chkSyllBreaks);
            this.tabPageView.Controls.Add(this.chkCVPattern);
            this.tabPageView.Controls.Add(this.chkPlural);
            this.tabPageView.Controls.Add(this.chkRoot);
            this.tabPageView.Controls.Add(this.chkPS);
            this.tabPageView.Controls.Add(this.chkGlossRegional);
            this.tabPageView.Controls.Add(this.chkGlossNational);
            this.tabPageView.Controls.Add(this.tbInfoView);
            this.tabPageView.Controls.Add(this.chkGlossEnglish);
            this.tabPageView.Location = new System.Drawing.Point(4, 24);
            this.tabPageView.Name = "tabPageView";
            this.tabPageView.Size = new System.Drawing.Size(648, 275);
            this.tabPageView.TabIndex = 3;
            this.tabPageView.Text = "View";
            this.tabPageView.UseVisualStyleBackColor = true;
            // 
            // chkParaSentWord
            // 
            this.chkParaSentWord.AutoSize = true;
            this.chkParaSentWord.Location = new System.Drawing.Point(20, 229);
            this.chkParaSentWord.Name = "chkParaSentWord";
            this.chkParaSentWord.Size = new System.Drawing.Size(282, 19);
            this.chkParaSentWord.TabIndex = 15;
            this.chkParaSentWord.Text = "Display paragraph, sentence and word number";
            this.chkParaSentWord.UseVisualStyleBackColor = true;
            // 
            // tbInfoView2
            // 
            this.tbInfoView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbInfoView2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInfoView2.Location = new System.Drawing.Point(13, 195);
            this.tbInfoView2.Name = "tbInfoView2";
            this.tbInfoView2.ReadOnly = true;
            this.tbInfoView2.Size = new System.Drawing.Size(614, 14);
            this.tbInfoView2.TabIndex = 14;
            this.tbInfoView2.Text = "Choose which items should be displayed when displaying a text data";
            this.tbInfoView2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkRootSyllBreaks
            // 
            this.chkRootSyllBreaks.AutoSize = true;
            this.chkRootSyllBreaks.Location = new System.Drawing.Point(360, 106);
            this.chkRootSyllBreaks.Name = "chkRootSyllBreaks";
            this.chkRootSyllBreaks.Size = new System.Drawing.Size(136, 19);
            this.chkRootSyllBreaks.TabIndex = 12;
            this.chkRootSyllBreaks.Text = "Root syllable breaks";
            this.chkRootSyllBreaks.UseVisualStyleBackColor = true;
            // 
            // chkRootCVPattern
            // 
            this.chkRootCVPattern.AutoSize = true;
            this.chkRootCVPattern.Location = new System.Drawing.Point(360, 76);
            this.chkRootCVPattern.Name = "chkRootCVPattern";
            this.chkRootCVPattern.Size = new System.Drawing.Size(111, 19);
            this.chkRootCVPattern.TabIndex = 11;
            this.chkRootCVPattern.Text = "Root CV pattern";
            this.chkRootCVPattern.UseVisualStyleBackColor = true;
            // 
            // chkRootNoTone
            // 
            this.chkRootNoTone.AutoSize = true;
            this.chkRootNoTone.Location = new System.Drawing.Point(360, 132);
            this.chkRootNoTone.Name = "chkRootNoTone";
            this.chkRootNoTone.Size = new System.Drawing.Size(133, 19);
            this.chkRootNoTone.TabIndex = 13;
            this.chkRootNoTone.Text = "Root w/o syllograph";
            // 
            // chkWordNoTone
            // 
            this.chkWordNoTone.AutoSize = true;
            this.chkWordNoTone.Location = new System.Drawing.Point(200, 132);
            this.chkWordNoTone.Name = "chkWordNoTone";
            this.chkWordNoTone.Size = new System.Drawing.Size(136, 19);
            this.chkWordNoTone.TabIndex = 9;
            this.chkWordNoTone.Text = "Word w/o syllograph";
            // 
            // chkOrigWord
            // 
            this.chkOrigWord.AutoSize = true;
            this.chkOrigWord.Location = new System.Drawing.Point(20, 49);
            this.chkOrigWord.Name = "chkOrigWord";
            this.chkOrigWord.Size = new System.Drawing.Size(99, 19);
            this.chkOrigWord.TabIndex = 1;
            this.chkOrigWord.Text = "Original word";
            // 
            // chkSyllBreaks
            // 
            this.chkSyllBreaks.AutoSize = true;
            this.chkSyllBreaks.Location = new System.Drawing.Point(200, 104);
            this.chkSyllBreaks.Name = "chkSyllBreaks";
            this.chkSyllBreaks.Size = new System.Drawing.Size(109, 19);
            this.chkSyllBreaks.TabIndex = 8;
            this.chkSyllBreaks.Text = "Syllable breaks";
            // 
            // chkCVPattern
            // 
            this.chkCVPattern.AutoSize = true;
            this.chkCVPattern.Location = new System.Drawing.Point(200, 76);
            this.chkCVPattern.Name = "chkCVPattern";
            this.chkCVPattern.Size = new System.Drawing.Size(82, 19);
            this.chkCVPattern.TabIndex = 7;
            this.chkCVPattern.Text = "CV pattern";
            // 
            // chkPlural
            // 
            this.chkPlural.AutoSize = true;
            this.chkPlural.Location = new System.Drawing.Point(200, 49);
            this.chkPlural.Name = "chkPlural";
            this.chkPlural.Size = new System.Drawing.Size(58, 19);
            this.chkPlural.TabIndex = 6;
            this.chkPlural.Text = "Plural";
            // 
            // chkRoot
            // 
            this.chkRoot.AutoSize = true;
            this.chkRoot.Location = new System.Drawing.Point(360, 49);
            this.chkRoot.Name = "chkRoot";
            this.chkRoot.Size = new System.Drawing.Size(52, 19);
            this.chkRoot.TabIndex = 10;
            this.chkRoot.Text = "Root";
            // 
            // chkPS
            // 
            this.chkPS.AutoSize = true;
            this.chkPS.Location = new System.Drawing.Point(20, 160);
            this.chkPS.Name = "chkPS";
            this.chkPS.Size = new System.Drawing.Size(110, 19);
            this.chkPS.TabIndex = 5;
            this.chkPS.Text = "Parts of speech";
            // 
            // chkGlossRegional
            // 
            this.chkGlossRegional.AutoSize = true;
            this.chkGlossRegional.Location = new System.Drawing.Point(20, 132);
            this.chkGlossRegional.Name = "chkGlossRegional";
            this.chkGlossRegional.Size = new System.Drawing.Size(108, 19);
            this.chkGlossRegional.TabIndex = 4;
            this.chkGlossRegional.Text = "Regional gloss";
            // 
            // chkGlossNational
            // 
            this.chkGlossNational.AutoSize = true;
            this.chkGlossNational.Location = new System.Drawing.Point(20, 104);
            this.chkGlossNational.Name = "chkGlossNational";
            this.chkGlossNational.Size = new System.Drawing.Size(104, 19);
            this.chkGlossNational.TabIndex = 3;
            this.chkGlossNational.Text = "National gloss";
            // 
            // tbInfoView
            // 
            this.tbInfoView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbInfoView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInfoView.Location = new System.Drawing.Point(13, 14);
            this.tbInfoView.Name = "tbInfoView";
            this.tbInfoView.ReadOnly = true;
            this.tbInfoView.Size = new System.Drawing.Size(614, 14);
            this.tbInfoView.TabIndex = 0;
            this.tbInfoView.Text = "Choose which items of a word should be displayed when displaying a word list";
            this.tbInfoView.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkGlossEnglish
            // 
            this.chkGlossEnglish.AutoSize = true;
            this.chkGlossEnglish.Location = new System.Drawing.Point(20, 76);
            this.chkGlossEnglish.Name = "chkGlossEnglish";
            this.chkGlossEnglish.Size = new System.Drawing.Size(99, 19);
            this.chkGlossEnglish.TabIndex = 2;
            this.chkGlossEnglish.Text = "English gloss";
            // 
            // tabPageSFM
            // 
            this.tabPageSFM.Controls.Add(this.tbRM);
            this.tabPageSFM.Controls.Add(this.labFMRM);
            this.tabPageSFM.Controls.Add(this.tbRT);
            this.tabPageSFM.Controls.Add(this.tbPL);
            this.tabPageSFM.Controls.Add(this.tbPS);
            this.tabPageSFM.Controls.Add(this.tbGR);
            this.tabPageSFM.Controls.Add(this.tbGN);
            this.tabPageSFM.Controls.Add(this.tbGE);
            this.tabPageSFM.Controls.Add(this.labFMRT);
            this.tabPageSFM.Controls.Add(this.labFMPL);
            this.tabPageSFM.Controls.Add(this.labFMPS);
            this.tabPageSFM.Controls.Add(this.labFMGR);
            this.tabPageSFM.Controls.Add(this.labFMGE);
            this.tabPageSFM.Controls.Add(this.labFMGN);
            this.tabPageSFM.Controls.Add(this.tbLX);
            this.tabPageSFM.Controls.Add(this.labFMLX);
            this.tabPageSFM.Controls.Add(this.tbInfoSFM2);
            this.tabPageSFM.Controls.Add(this.tbInfoSFM);
            this.tabPageSFM.Location = new System.Drawing.Point(4, 24);
            this.tabPageSFM.Name = "tabPageSFM";
            this.tabPageSFM.Size = new System.Drawing.Size(648, 275);
            this.tabPageSFM.TabIndex = 4;
            this.tabPageSFM.Text = "SFM";
            this.tabPageSFM.UseVisualStyleBackColor = true;
            // 
            // tbRM
            // 
            this.tbRM.Location = new System.Drawing.Point(166, 45);
            this.tbRM.Name = "tbRM";
            this.tbRM.Size = new System.Drawing.Size(50, 21);
            this.tbRM.TabIndex = 2;
            this.tbRM.Text = "rm";
            // 
            // labFMRM
            // 
            this.labFMRM.Location = new System.Drawing.Point(19, 48);
            this.labFMRM.Name = "labFMRM";
            this.labFMRM.Size = new System.Drawing.Size(133, 20);
            this.labFMRM.TabIndex = 1;
            this.labFMRM.Text = "Record marker";
            // 
            // tbRT
            // 
            this.tbRT.Location = new System.Drawing.Point(420, 123);
            this.tbRT.Name = "tbRT";
            this.tbRT.Size = new System.Drawing.Size(50, 21);
            this.tbRT.TabIndex = 16;
            this.tbRT.Text = "rt";
            // 
            // tbPL
            // 
            this.tbPL.Location = new System.Drawing.Point(420, 97);
            this.tbPL.Name = "tbPL";
            this.tbPL.Size = new System.Drawing.Size(50, 21);
            this.tbPL.TabIndex = 14;
            this.tbPL.Text = "pl";
            // 
            // tbPS
            // 
            this.tbPS.Location = new System.Drawing.Point(420, 71);
            this.tbPS.Name = "tbPS";
            this.tbPS.Size = new System.Drawing.Size(50, 21);
            this.tbPS.TabIndex = 12;
            this.tbPS.Text = "ps";
            // 
            // tbGR
            // 
            this.tbGR.Location = new System.Drawing.Point(420, 45);
            this.tbGR.Name = "tbGR";
            this.tbGR.Size = new System.Drawing.Size(50, 21);
            this.tbGR.TabIndex = 10;
            this.tbGR.Text = "gr";
            // 
            // tbGN
            // 
            this.tbGN.Location = new System.Drawing.Point(166, 124);
            this.tbGN.Name = "tbGN";
            this.tbGN.Size = new System.Drawing.Size(50, 21);
            this.tbGN.TabIndex = 8;
            this.tbGN.Text = "gn";
            // 
            // tbGE
            // 
            this.tbGE.Location = new System.Drawing.Point(166, 98);
            this.tbGE.Name = "tbGE";
            this.tbGE.Size = new System.Drawing.Size(50, 21);
            this.tbGE.TabIndex = 6;
            this.tbGE.Text = "ge";
            // 
            // labFMRT
            // 
            this.labFMRT.Location = new System.Drawing.Point(273, 123);
            this.labFMRT.Name = "labFMRT";
            this.labFMRT.Size = new System.Drawing.Size(134, 21);
            this.labFMRT.TabIndex = 15;
            this.labFMRT.Text = "Root";
            // 
            // labFMPL
            // 
            this.labFMPL.Location = new System.Drawing.Point(273, 97);
            this.labFMPL.Name = "labFMPL";
            this.labFMPL.Size = new System.Drawing.Size(134, 21);
            this.labFMPL.TabIndex = 13;
            this.labFMPL.Text = "Plural";
            // 
            // labFMPS
            // 
            this.labFMPS.Location = new System.Drawing.Point(273, 71);
            this.labFMPS.Name = "labFMPS";
            this.labFMPS.Size = new System.Drawing.Size(134, 21);
            this.labFMPS.TabIndex = 11;
            this.labFMPS.Text = "Parts of speech";
            // 
            // labFMGR
            // 
            this.labFMGR.Location = new System.Drawing.Point(273, 45);
            this.labFMGR.Name = "labFMGR";
            this.labFMGR.Size = new System.Drawing.Size(134, 21);
            this.labFMGR.TabIndex = 9;
            this.labFMGR.Text = "Regional gloss";
            // 
            // labFMGE
            // 
            this.labFMGE.Location = new System.Drawing.Point(19, 98);
            this.labFMGE.Name = "labFMGE";
            this.labFMGE.Size = new System.Drawing.Size(133, 21);
            this.labFMGE.TabIndex = 5;
            this.labFMGE.Text = "English gloss";
            // 
            // labFMGN
            // 
            this.labFMGN.Location = new System.Drawing.Point(19, 124);
            this.labFMGN.Name = "labFMGN";
            this.labFMGN.Size = new System.Drawing.Size(133, 21);
            this.labFMGN.TabIndex = 7;
            this.labFMGN.Text = "National gloss";
            // 
            // tbLX
            // 
            this.tbLX.Location = new System.Drawing.Point(166, 72);
            this.tbLX.Name = "tbLX";
            this.tbLX.Size = new System.Drawing.Size(50, 21);
            this.tbLX.TabIndex = 4;
            this.tbLX.Text = "lx";
            // 
            // labFMLX
            // 
            this.labFMLX.Location = new System.Drawing.Point(19, 72);
            this.labFMLX.Name = "labFMLX";
            this.labFMLX.Size = new System.Drawing.Size(133, 21);
            this.labFMLX.TabIndex = 3;
            this.labFMLX.Text = "Word transcription ";
            // 
            // tbInfoSFM2
            // 
            this.tbInfoSFM2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbInfoSFM2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInfoSFM2.Location = new System.Drawing.Point(483, 74);
            this.tbInfoSFM2.Multiline = true;
            this.tbInfoSFM2.Name = "tbInfoSFM2";
            this.tbInfoSFM2.ReadOnly = true;
            this.tbInfoSFM2.Size = new System.Drawing.Size(144, 45);
            this.tbInfoSFM2.TabIndex = 17;
            this.tbInfoSFM2.Text = "Do not include the back slash marker.";
            this.tbInfoSFM2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbInfoSFM
            // 
            this.tbInfoSFM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbInfoSFM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInfoSFM.Location = new System.Drawing.Point(13, 14);
            this.tbInfoSFM.Name = "tbInfoSFM";
            this.tbInfoSFM.ReadOnly = true;
            this.tbInfoSFM.Size = new System.Drawing.Size(614, 14);
            this.tbInfoSFM.TabIndex = 0;
            this.tbInfoSFM.Text = "Indicate which field markers you are using for the SFM word list.";
            this.tbInfoSFM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabPageLift
            // 
            this.tabPageLift.Controls.Add(this.tbLiftGR);
            this.tabPageLift.Controls.Add(this.tbLiftGN);
            this.tabPageLift.Controls.Add(this.tbLiftGE);
            this.tabPageLift.Controls.Add(this.tbLiftVern);
            this.tabPageLift.Controls.Add(this.labLiftVern);
            this.tabPageLift.Controls.Add(this.labLiftGE);
            this.tabPageLift.Controls.Add(this.labLiftGN);
            this.tabPageLift.Controls.Add(this.labLiftGR);
            this.tabPageLift.Controls.Add(this.tbInfoLift);
            this.tabPageLift.Location = new System.Drawing.Point(4, 24);
            this.tabPageLift.Name = "tabPageLift";
            this.tabPageLift.Size = new System.Drawing.Size(648, 275);
            this.tabPageLift.TabIndex = 9;
            this.tabPageLift.Text = "Lift";
            this.tabPageLift.UseVisualStyleBackColor = true;
            // 
            // tbLiftGR
            // 
            this.tbLiftGR.Location = new System.Drawing.Point(167, 130);
            this.tbLiftGR.Name = "tbLiftGR";
            this.tbLiftGR.Size = new System.Drawing.Size(50, 21);
            this.tbLiftGR.TabIndex = 8;
            // 
            // tbLiftGN
            // 
            this.tbLiftGN.Location = new System.Drawing.Point(167, 104);
            this.tbLiftGN.Name = "tbLiftGN";
            this.tbLiftGN.Size = new System.Drawing.Size(50, 21);
            this.tbLiftGN.TabIndex = 6;
            // 
            // tbLiftGE
            // 
            this.tbLiftGE.Location = new System.Drawing.Point(167, 78);
            this.tbLiftGE.Name = "tbLiftGE";
            this.tbLiftGE.Size = new System.Drawing.Size(50, 21);
            this.tbLiftGE.TabIndex = 4;
            this.tbLiftGE.Text = "en";
            // 
            // tbLiftVern
            // 
            this.tbLiftVern.Location = new System.Drawing.Point(167, 52);
            this.tbLiftVern.Name = "tbLiftVern";
            this.tbLiftVern.Size = new System.Drawing.Size(50, 21);
            this.tbLiftVern.TabIndex = 2;
            // 
            // labLiftVern
            // 
            this.labLiftVern.Location = new System.Drawing.Point(20, 52);
            this.labLiftVern.Name = "labLiftVern";
            this.labLiftVern.Size = new System.Drawing.Size(133, 21);
            this.labLiftVern.TabIndex = 1;
            this.labLiftVern.Text = "Vernacular";
            // 
            // labLiftGE
            // 
            this.labLiftGE.Location = new System.Drawing.Point(20, 78);
            this.labLiftGE.Name = "labLiftGE";
            this.labLiftGE.Size = new System.Drawing.Size(133, 21);
            this.labLiftGE.TabIndex = 3;
            this.labLiftGE.Text = "English gloss";
            // 
            // labLiftGN
            // 
            this.labLiftGN.Location = new System.Drawing.Point(20, 104);
            this.labLiftGN.Name = "labLiftGN";
            this.labLiftGN.Size = new System.Drawing.Size(133, 21);
            this.labLiftGN.TabIndex = 5;
            this.labLiftGN.Text = "National gloss";
            // 
            // labLiftGR
            // 
            this.labLiftGR.Location = new System.Drawing.Point(20, 130);
            this.labLiftGR.Name = "labLiftGR";
            this.labLiftGR.Size = new System.Drawing.Size(133, 21);
            this.labLiftGR.TabIndex = 7;
            this.labLiftGR.Text = "Regional gloss";
            // 
            // tbInfoLift
            // 
            this.tbInfoLift.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbInfoLift.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInfoLift.Location = new System.Drawing.Point(17, 23);
            this.tbInfoLift.Name = "tbInfoLift";
            this.tbInfoLift.ReadOnly = true;
            this.tbInfoLift.Size = new System.Drawing.Size(613, 14);
            this.tbInfoLift.TabIndex = 0;
            this.tbInfoLift.Text = "Indicate the language codes you are using in the LIFT word list";
            this.tbInfoLift.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabPageCV
            // 
            this.tabPageCV.Controls.Add(this.tbSyllograph);
            this.tabPageCV.Controls.Add(this.labSyllograph);
            this.tabPageCV.Controls.Add(this.tbDipthongs);
            this.tabPageCV.Controls.Add(this.labDiphthongs);
            this.tabPageCV.Controls.Add(this.labNoTBU);
            this.tabPageCV.Controls.Add(this.tbTones);
            this.tabPageCV.Controls.Add(this.labTones);
            this.tabPageCV.Controls.Add(this.labCnsSyl);
            this.tabPageCV.Controls.Add(this.tbCnsAsp);
            this.tabPageCV.Controls.Add(this.labCnsAsp);
            this.tabPageCV.Controls.Add(this.tbVwlLng);
            this.tabPageCV.Controls.Add(this.tbVwlNsl);
            this.tabPageCV.Controls.Add(this.tbVwl);
            this.tabPageCV.Controls.Add(this.labVwlNsl);
            this.tabPageCV.Controls.Add(this.labVwlLng);
            this.tabPageCV.Controls.Add(this.labVwl);
            this.tabPageCV.Controls.Add(this.tbCnsSyl);
            this.tabPageCV.Controls.Add(this.tbCnsPrn);
            this.tabPageCV.Controls.Add(this.tbCnsLab);
            this.tabPageCV.Controls.Add(this.tbCnsPal);
            this.tabPageCV.Controls.Add(this.tbCnsVel);
            this.tabPageCV.Controls.Add(this.tbCns);
            this.tabPageCV.Controls.Add(this.labCnsLab);
            this.tabPageCV.Controls.Add(this.labCnsPal);
            this.tabPageCV.Controls.Add(this.labCnsVel);
            this.tabPageCV.Controls.Add(this.labCnsPrn);
            this.tabPageCV.Controls.Add(this.labCns);
            this.tabPageCV.Controls.Add(this.labInfoCV);
            this.tabPageCV.Location = new System.Drawing.Point(4, 24);
            this.tabPageCV.Name = "tabPageCV";
            this.tabPageCV.Size = new System.Drawing.Size(648, 275);
            this.tabPageCV.TabIndex = 6;
            this.tabPageCV.Text = "CV";
            this.tabPageCV.UseVisualStyleBackColor = true;
            // 
            // tbSyllograph
            // 
            this.tbSyllograph.Location = new System.Drawing.Point(487, 178);
            this.tbSyllograph.Name = "tbSyllograph";
            this.tbSyllograph.Size = new System.Drawing.Size(53, 21);
            this.tbSyllograph.TabIndex = 24;
            // 
            // labSyllograph
            // 
            this.labSyllograph.Location = new System.Drawing.Point(367, 178);
            this.labSyllograph.Name = "labSyllograph";
            this.labSyllograph.Size = new System.Drawing.Size(115, 20);
            this.labSyllograph.TabIndex = 23;
            this.labSyllograph.Text = "Syllographs";
            // 
            // tbDipthongs
            // 
            this.tbDipthongs.Location = new System.Drawing.Point(487, 139);
            this.tbDipthongs.Name = "tbDipthongs";
            this.tbDipthongs.Size = new System.Drawing.Size(53, 21);
            this.tbDipthongs.TabIndex = 22;
            // 
            // labDiphthongs
            // 
            this.labDiphthongs.Location = new System.Drawing.Point(367, 139);
            this.labDiphthongs.Name = "labDiphthongs";
            this.labDiphthongs.Size = new System.Drawing.Size(115, 20);
            this.labDiphthongs.TabIndex = 21;
            this.labDiphthongs.Text = "Diphthongs";
            // 
            // labNoTBU
            // 
            this.labNoTBU.AutoSize = true;
            this.labNoTBU.Location = new System.Drawing.Point(558, 221);
            this.labNoTBU.Name = "labNoTBU";
            this.labNoTBU.Size = new System.Drawing.Size(56, 15);
            this.labNoTBU.TabIndex = 27;
            this.labNoTBU.Text = "(no TBU)";
            // 
            // tbTones
            // 
            this.tbTones.Location = new System.Drawing.Point(487, 221);
            this.tbTones.Name = "tbTones";
            this.tbTones.Size = new System.Drawing.Size(53, 21);
            this.tbTones.TabIndex = 26;
            // 
            // labTones
            // 
            this.labTones.Location = new System.Drawing.Point(367, 221);
            this.labTones.Name = "labTones";
            this.labTones.Size = new System.Drawing.Size(115, 20);
            this.labTones.TabIndex = 25;
            this.labTones.Text = "Tones:";
            // 
            // labCnsSyl
            // 
            this.labCnsSyl.Location = new System.Drawing.Point(27, 83);
            this.labCnsSyl.Name = "labCnsSyl";
            this.labCnsSyl.Size = new System.Drawing.Size(166, 20);
            this.labCnsSyl.TabIndex = 3;
            this.labCnsSyl.Text = "Syllabic consonants:";
            // 
            // tbCnsAsp
            // 
            this.tbCnsAsp.Location = new System.Drawing.Point(207, 221);
            this.tbCnsAsp.Name = "tbCnsAsp";
            this.tbCnsAsp.Size = new System.Drawing.Size(53, 21);
            this.tbCnsAsp.TabIndex = 14;
            // 
            // labCnsAsp
            // 
            this.labCnsAsp.Location = new System.Drawing.Point(27, 222);
            this.labCnsAsp.Name = "labCnsAsp";
            this.labCnsAsp.Size = new System.Drawing.Size(166, 20);
            this.labCnsAsp.TabIndex = 13;
            this.labCnsAsp.Text = "Aspirated consonants:";
            // 
            // tbVwlLng
            // 
            this.tbVwlLng.Location = new System.Drawing.Point(487, 111);
            this.tbVwlLng.Name = "tbVwlLng";
            this.tbVwlLng.Size = new System.Drawing.Size(53, 21);
            this.tbVwlLng.TabIndex = 20;
            // 
            // tbVwlNsl
            // 
            this.tbVwlNsl.Location = new System.Drawing.Point(487, 83);
            this.tbVwlNsl.Name = "tbVwlNsl";
            this.tbVwlNsl.Size = new System.Drawing.Size(53, 21);
            this.tbVwlNsl.TabIndex = 18;
            // 
            // tbVwl
            // 
            this.tbVwl.Location = new System.Drawing.Point(487, 55);
            this.tbVwl.Name = "tbVwl";
            this.tbVwl.Size = new System.Drawing.Size(53, 21);
            this.tbVwl.TabIndex = 16;
            // 
            // labVwlNsl
            // 
            this.labVwlNsl.Location = new System.Drawing.Point(367, 83);
            this.labVwlNsl.Name = "labVwlNsl";
            this.labVwlNsl.Size = new System.Drawing.Size(115, 20);
            this.labVwlNsl.TabIndex = 17;
            this.labVwlNsl.Text = "Nasal vowels:";
            // 
            // labVwlLng
            // 
            this.labVwlLng.Location = new System.Drawing.Point(367, 111);
            this.labVwlLng.Name = "labVwlLng";
            this.labVwlLng.Size = new System.Drawing.Size(115, 20);
            this.labVwlLng.TabIndex = 19;
            this.labVwlLng.Text = "Long vowels:";
            // 
            // labVwl
            // 
            this.labVwl.Location = new System.Drawing.Point(367, 55);
            this.labVwl.Name = "labVwl";
            this.labVwl.Size = new System.Drawing.Size(115, 20);
            this.labVwl.TabIndex = 15;
            this.labVwl.Text = "Vowels:";
            // 
            // tbCnsSyl
            // 
            this.tbCnsSyl.Location = new System.Drawing.Point(207, 83);
            this.tbCnsSyl.Name = "tbCnsSyl";
            this.tbCnsSyl.Size = new System.Drawing.Size(53, 21);
            this.tbCnsSyl.TabIndex = 4;
            // 
            // tbCnsPrn
            // 
            this.tbCnsPrn.Location = new System.Drawing.Point(207, 111);
            this.tbCnsPrn.Name = "tbCnsPrn";
            this.tbCnsPrn.Size = new System.Drawing.Size(53, 21);
            this.tbCnsPrn.TabIndex = 6;
            // 
            // tbCnsLab
            // 
            this.tbCnsLab.Location = new System.Drawing.Point(207, 139);
            this.tbCnsLab.Name = "tbCnsLab";
            this.tbCnsLab.Size = new System.Drawing.Size(53, 21);
            this.tbCnsLab.TabIndex = 8;
            // 
            // tbCnsPal
            // 
            this.tbCnsPal.Location = new System.Drawing.Point(207, 166);
            this.tbCnsPal.Name = "tbCnsPal";
            this.tbCnsPal.Size = new System.Drawing.Size(53, 21);
            this.tbCnsPal.TabIndex = 10;
            // 
            // tbCnsVel
            // 
            this.tbCnsVel.Location = new System.Drawing.Point(207, 194);
            this.tbCnsVel.Name = "tbCnsVel";
            this.tbCnsVel.Size = new System.Drawing.Size(53, 21);
            this.tbCnsVel.TabIndex = 12;
            // 
            // tbCns
            // 
            this.tbCns.Location = new System.Drawing.Point(207, 55);
            this.tbCns.Name = "tbCns";
            this.tbCns.Size = new System.Drawing.Size(53, 21);
            this.tbCns.TabIndex = 2;
            // 
            // labCnsLab
            // 
            this.labCnsLab.Location = new System.Drawing.Point(27, 139);
            this.labCnsLab.Name = "labCnsLab";
            this.labCnsLab.Size = new System.Drawing.Size(166, 20);
            this.labCnsLab.TabIndex = 7;
            this.labCnsLab.Text = "Labialized consonants:";
            // 
            // labCnsPal
            // 
            this.labCnsPal.Location = new System.Drawing.Point(27, 166);
            this.labCnsPal.Name = "labCnsPal";
            this.labCnsPal.Size = new System.Drawing.Size(166, 20);
            this.labCnsPal.TabIndex = 9;
            this.labCnsPal.Text = "Palatalized consonants:";
            // 
            // labCnsVel
            // 
            this.labCnsVel.Location = new System.Drawing.Point(27, 192);
            this.labCnsVel.Name = "labCnsVel";
            this.labCnsVel.Size = new System.Drawing.Size(166, 20);
            this.labCnsVel.TabIndex = 11;
            this.labCnsVel.Text = "Velarized consonants:";
            // 
            // labCnsPrn
            // 
            this.labCnsPrn.Location = new System.Drawing.Point(27, 111);
            this.labCnsPrn.Name = "labCnsPrn";
            this.labCnsPrn.Size = new System.Drawing.Size(166, 20);
            this.labCnsPrn.TabIndex = 5;
            this.labCnsPrn.Text = "Prenasalized consonants:";
            // 
            // labCns
            // 
            this.labCns.Location = new System.Drawing.Point(27, 55);
            this.labCns.Name = "labCns";
            this.labCns.Size = new System.Drawing.Size(166, 20);
            this.labCns.TabIndex = 1;
            this.labCns.Text = "Consonants:";
            // 
            // labInfoCV
            // 
            this.labInfoCV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfoCV.Location = new System.Drawing.Point(13, 14);
            this.labInfoCV.Name = "labInfoCV";
            this.labInfoCV.Size = new System.Drawing.Size(614, 15);
            this.labInfoCV.TabIndex = 0;
            this.labInfoCV.Text = "Indicate which symbol(s) to use for the following items in the CV pattern of a wo" +
    "rd.";
            this.labInfoCV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPagePunct
            // 
            this.tabPagePunct.Controls.Add(this.labGeneral2);
            this.tabPagePunct.Controls.Add(this.tbGeneral);
            this.tabPagePunct.Controls.Add(this.tbEnding);
            this.tabPagePunct.Controls.Add(this.labGeneral);
            this.tabPagePunct.Controls.Add(this.labEnding2);
            this.tabPagePunct.Controls.Add(this.labEnding);
            this.tabPagePunct.Controls.Add(this.labInfoPunct);
            this.tabPagePunct.Location = new System.Drawing.Point(4, 24);
            this.tabPagePunct.Name = "tabPagePunct";
            this.tabPagePunct.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePunct.Size = new System.Drawing.Size(648, 275);
            this.tabPagePunct.TabIndex = 7;
            this.tabPagePunct.Text = "Punctuation";
            this.tabPagePunct.UseVisualStyleBackColor = true;
            // 
            // labGeneral2
            // 
            this.labGeneral2.AutoEllipsis = true;
            this.labGeneral2.AutoSize = true;
            this.labGeneral2.Location = new System.Drawing.Point(365, 120);
            this.labGeneral2.Name = "labGeneral2";
            this.labGeneral2.Size = new System.Drawing.Size(186, 15);
            this.labGeneral2.TabIndex = 6;
            this.labGeneral2.Text = "(Used to determine word breaks)";
            // 
            // tbGeneral
            // 
            this.tbGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGeneral.Location = new System.Drawing.Point(200, 120);
            this.tbGeneral.Name = "tbGeneral";
            this.tbGeneral.Size = new System.Drawing.Size(152, 24);
            this.tbGeneral.TabIndex = 5;
            // 
            // tbEnding
            // 
            this.tbEnding.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEnding.Location = new System.Drawing.Point(200, 75);
            this.tbEnding.Name = "tbEnding";
            this.tbEnding.Size = new System.Drawing.Size(152, 24);
            this.tbEnding.TabIndex = 2;
            // 
            // labGeneral
            // 
            this.labGeneral.AutoSize = true;
            this.labGeneral.CausesValidation = false;
            this.labGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labGeneral.Location = new System.Drawing.Point(24, 120);
            this.labGeneral.Name = "labGeneral";
            this.labGeneral.Size = new System.Drawing.Size(136, 15);
            this.labGeneral.TabIndex = 4;
            this.labGeneral.Text = "General punctuation list";
            // 
            // labEnding2
            // 
            this.labEnding2.AutoEllipsis = true;
            this.labEnding2.AutoSize = true;
            this.labEnding2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labEnding2.Location = new System.Drawing.Point(365, 75);
            this.labEnding2.Name = "labEnding2";
            this.labEnding2.Size = new System.Drawing.Size(209, 15);
            this.labEnding2.TabIndex = 3;
            this.labEnding2.Text = "(Used to determine sentence breaks)";
            // 
            // labEnding
            // 
            this.labEnding.AutoSize = true;
            this.labEnding.CausesValidation = false;
            this.labEnding.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labEnding.Location = new System.Drawing.Point(24, 75);
            this.labEnding.Name = "labEnding";
            this.labEnding.Size = new System.Drawing.Size(131, 15);
            this.labEnding.TabIndex = 1;
            this.labEnding.Text = "Ending punctuation list";
            // 
            // labInfoPunct
            // 
            this.labInfoPunct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfoPunct.Location = new System.Drawing.Point(13, 14);
            this.labInfoPunct.Name = "labInfoPunct";
            this.labInfoPunct.Size = new System.Drawing.Size(614, 15);
            this.labInfoPunct.TabIndex = 0;
            this.labInfoPunct.Text = "Indicate which symbols are used for punctuation within text data.";
            this.labInfoPunct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPageImport
            // 
            this.tabPageImport.Controls.Add(this.labReplace);
            this.tabPageImport.Controls.Add(this.dgvReplace);
            this.tabPageImport.Controls.Add(this.tbInfoImport);
            this.tabPageImport.Controls.Add(this.tbIgnoreChar);
            this.tabPageImport.Controls.Add(this.labIgnore);
            this.tabPageImport.Controls.Add(this.nudMax);
            this.tabPageImport.Controls.Add(this.labMax);
            this.tabPageImport.Location = new System.Drawing.Point(4, 24);
            this.tabPageImport.Name = "tabPageImport";
            this.tabPageImport.Size = new System.Drawing.Size(648, 275);
            this.tabPageImport.TabIndex = 8;
            this.tabPageImport.Text = "Import";
            this.tabPageImport.UseVisualStyleBackColor = true;
            // 
            // labReplace
            // 
            this.labReplace.AutoSize = true;
            this.labReplace.Location = new System.Drawing.Point(443, 42);
            this.labReplace.Name = "labReplace";
            this.labReplace.Size = new System.Drawing.Size(123, 15);
            this.labReplace.TabIndex = 5;
            this.labReplace.Text = "Characters to replace";
            // 
            // dgvReplace
            // 
            this.dgvReplace.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReplace.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvReplace.Location = new System.Drawing.Point(417, 69);
            this.dgvReplace.Name = "dgvReplace";
            this.dgvReplace.RowTemplate.Height = 24;
            this.dgvReplace.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvReplace.Size = new System.Drawing.Size(179, 139);
            this.dgvReplace.TabIndex = 6;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Replace this";
            this.Column1.MinimumWidth = 10;
            this.Column1.Name = "Column1";
            this.Column1.Width = 85;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "With this";
            this.Column2.MinimumWidth = 10;
            this.Column2.Name = "Column2";
            this.Column2.Width = 85;
            // 
            // tbInfoImport
            // 
            this.tbInfoImport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbInfoImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInfoImport.Location = new System.Drawing.Point(13, 14);
            this.tbInfoImport.Name = "tbInfoImport";
            this.tbInfoImport.ReadOnly = true;
            this.tbInfoImport.Size = new System.Drawing.Size(614, 14);
            this.tbInfoImport.TabIndex = 0;
            this.tbInfoImport.Text = "Instructions for importing Word List and Text Data";
            this.tbInfoImport.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbIgnoreChar
            // 
            this.tbIgnoreChar.Location = new System.Drawing.Point(198, 64);
            this.tbIgnoreChar.Name = "tbIgnoreChar";
            this.tbIgnoreChar.Size = new System.Drawing.Size(155, 21);
            this.tbIgnoreChar.TabIndex = 4;
            // 
            // labIgnore
            // 
            this.labIgnore.AutoSize = true;
            this.labIgnore.Location = new System.Drawing.Point(25, 69);
            this.labIgnore.Name = "labIgnore";
            this.labIgnore.Size = new System.Drawing.Size(117, 15);
            this.labIgnore.TabIndex = 3;
            this.labIgnore.Text = "Characters to ignore";
            // 
            // nudMax
            // 
            this.nudMax.Location = new System.Drawing.Point(198, 36);
            this.nudMax.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nudMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMax.Name = "nudMax";
            this.nudMax.Size = new System.Drawing.Size(29, 21);
            this.nudMax.TabIndex = 2;
            this.nudMax.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // labMax
            // 
            this.labMax.AutoSize = true;
            this.labMax.Location = new System.Drawing.Point(25, 41);
            this.labMax.Name = "labMax";
            this.labMax.Size = new System.Drawing.Size(159, 15);
            this.labMax.TabIndex = 1;
            this.labMax.Text = "Maximal size of graphemes";
            // 
            // tabPageUI
            // 
            this.tabPageUI.Controls.Add(this.gbMenu);
            this.tabPageUI.Controls.Add(this.gbUILang);
            this.tabPageUI.Location = new System.Drawing.Point(4, 24);
            this.tabPageUI.Name = "tabPageUI";
            this.tabPageUI.Size = new System.Drawing.Size(648, 275);
            this.tabPageUI.TabIndex = 10;
            this.tabPageUI.Text = "UI";
            this.tabPageUI.UseVisualStyleBackColor = true;
            // 
            // gbMenu
            // 
            this.gbMenu.Controls.Add(this.chkSimplified);
            this.gbMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMenu.Location = new System.Drawing.Point(24, 140);
            this.gbMenu.Name = "gbMenu";
            this.gbMenu.Size = new System.Drawing.Size(187, 76);
            this.gbMenu.TabIndex = 1;
            this.gbMenu.TabStop = false;
            this.gbMenu.Text = "UI Menu";
            // 
            // chkSimplified
            // 
            this.chkSimplified.AutoSize = true;
            this.chkSimplified.Location = new System.Drawing.Point(22, 35);
            this.chkSimplified.Name = "chkSimplified";
            this.chkSimplified.Size = new System.Drawing.Size(81, 19);
            this.chkSimplified.TabIndex = 0;
            this.chkSimplified.Text = "Simplified";
            this.chkSimplified.UseVisualStyleBackColor = true;
            // 
            // gbUILang
            // 
            this.gbUILang.Controls.Add(this.rbFrench);
            this.gbUILang.Controls.Add(this.rbEnglish);
            this.gbUILang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbUILang.Location = new System.Drawing.Point(24, 37);
            this.gbUILang.Name = "gbUILang";
            this.gbUILang.Size = new System.Drawing.Size(285, 87);
            this.gbUILang.TabIndex = 0;
            this.gbUILang.TabStop = false;
            this.gbUILang.Text = "User Interface Language";
            // 
            // rbFrench
            // 
            this.rbFrench.AutoSize = true;
            this.rbFrench.Location = new System.Drawing.Point(22, 54);
            this.rbFrench.Name = "rbFrench";
            this.rbFrench.Size = new System.Drawing.Size(72, 19);
            this.rbFrench.TabIndex = 1;
            this.rbFrench.TabStop = true;
            this.rbFrench.Text = "Français";
            this.rbFrench.UseVisualStyleBackColor = true;
            // 
            // rbEnglish
            // 
            this.rbEnglish.AutoSize = true;
            this.rbEnglish.Location = new System.Drawing.Point(22, 21);
            this.rbEnglish.Name = "rbEnglish";
            this.rbEnglish.Size = new System.Drawing.Size(66, 19);
            this.rbEnglish.TabIndex = 0;
            this.rbEnglish.TabStop = true;
            this.rbEnglish.Text = "English";
            this.rbEnglish.UseVisualStyleBackColor = true;
            // 
            // btnOptionsOK
            // 
            this.btnOptionsOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOptionsOK.Location = new System.Drawing.Point(382, 310);
            this.btnOptionsOK.Name = "btnOptionsOK";
            this.btnOptionsOK.Size = new System.Drawing.Size(84, 28);
            this.btnOptionsOK.TabIndex = 1;
            this.btnOptionsOK.Text = "OK";
            this.btnOptionsOK.Click += new System.EventHandler(this.btnOptionsOK_Click);
            // 
            // btnOptionsCancel
            // 
            this.btnOptionsCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOptionsCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOptionsCancel.Location = new System.Drawing.Point(507, 310);
            this.btnOptionsCancel.Name = "btnOptionsCancel";
            this.btnOptionsCancel.Size = new System.Drawing.Size(83, 28);
            this.btnOptionsCancel.TabIndex = 2;
            this.btnOptionsCancel.Text = "Cancel";
            this.btnOptionsCancel.Click += new System.EventHandler(this.btnOptionsCancel_Click);
            // 
            // FormOptions
            // 
            this.AcceptButton = this.btnOptionsOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnOptionsCancel;
            this.ClientSize = new System.Drawing.Size(808, 394);
            this.Controls.Add(this.tabPage);
            this.Controls.Add(this.btnOptionsOK);
            this.Controls.Add(this.btnOptionsCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.tabPage.ResumeLayout(false);
            this.tabPageFolder.ResumeLayout(false);
            this.tabPageFolder.PerformLayout();
            this.tabPageFile.ResumeLayout(false);
            this.tabPageFile.PerformLayout();
            this.tabPageFormat.ResumeLayout(false);
            this.tabPageFormat.PerformLayout();
            this.tabPageView.ResumeLayout(false);
            this.tabPageView.PerformLayout();
            this.tabPageSFM.ResumeLayout(false);
            this.tabPageSFM.PerformLayout();
            this.tabPageLift.ResumeLayout(false);
            this.tabPageLift.PerformLayout();
            this.tabPageCV.ResumeLayout(false);
            this.tabPageCV.PerformLayout();
            this.tabPagePunct.ResumeLayout(false);
            this.tabPagePunct.PerformLayout();
            this.tabPageImport.ResumeLayout(false);
            this.tabPageImport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReplace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMax)).EndInit();
            this.tabPageUI.ResumeLayout(false);
            this.gbMenu.ResumeLayout(false);
            this.gbMenu.PerformLayout();
            this.gbUILang.ResumeLayout(false);
            this.gbUILang.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void btnOptionsOK_Click(object sender, System.EventArgs e)
		{
			OptionList m_OptionList = m_Settings.OptionSettings;
			m_OptionList.DataFolder = tbDataFolder.Text;
			m_OptionList.TemplateFolder = tbTemplateFolder.Text;

            if (m_OptionList.GraphemeInventoryFile != tbInventory.Text)
            {
                m_OptionList.GraphemeInventoryFile = tbInventory.Text;
                GraphemeInventory gi = new GraphemeInventory(m_Settings);
                if (gi.LoadFromFile(m_OptionList.GraphemeInventoryFile))
                    m_Settings.GraphemeInventory = gi;
            }
            if (m_OptionList.SightWordsFile != tbSightWords.Text)
            {
                m_OptionList.SightWordsFile = tbSightWords.Text;
                SightWords sw = new SightWords(m_Settings);
                if (sw.LoadFromFile(m_OptionList.SightWordsFile))
                    m_Settings.SightWords = sw;
            }
            if (m_OptionList.GraphemeTaughtOrderFile != tbGT.Text)
            {
                m_OptionList.GraphemeTaughtOrderFile = tbGT.Text;
                GraphemeTaughtOrder gto = new GraphemeTaughtOrder(m_Settings);
                if (gto.LoadFromFile(m_OptionList.GraphemeTaughtOrderFile))
                    m_Settings.GraphemesTaught = gto;
            }
            if (m_OptionList.PSTableFile != tbPoS.Text)
            {
                m_OptionList.PSTableFile = tbPoS.Text;
                PSTable pst = new PSTable(m_Settings);
                if (pst.LoadFromFile(m_OptionList.PSTableFile))
                    m_Settings.PSTable = pst;
            }

            m_OptionList.ViewOrigWord = chkOrigWord.Checked;
			if (chkGlossEnglish.Checked || chkGlossNational.Checked ||
				chkGlossRegional.Checked)
			{
				m_OptionList.ViewGlossEnglish = chkGlossEnglish.Checked;
				m_OptionList.ViewGlossNational = chkGlossNational.Checked;
				m_OptionList.ViewGlossRegional = chkGlossRegional.Checked;
			}
			else
			{
                //MessageBox.Show("Must select at least one of the glosses");
                MessageBox.Show(m_Settings.LocalizationTable.GetMessage("FormOptions1",
                    m_Settings.OptionSettings.UILanguage));
				return;
			}
			m_OptionList.ViewPS = chkPS.Checked;
			m_OptionList.ViewPlural = chkPlural.Checked;
			m_OptionList.ViewRoot = chkRoot.Checked;
			m_OptionList.ViewCVPattern = chkCVPattern.Checked;
			m_OptionList.ViewSyllBreaks = chkSyllBreaks.Checked;
			m_OptionList.ViewWordWithoutTone = chkWordNoTone.Checked;
            m_OptionList.ViewRoot = chkRoot.Checked;
            m_OptionList.ViewRootCVPattern = chkRootCVPattern.Checked;
            m_OptionList.ViewRootSyllBreaks = chkRootSyllBreaks.Checked;
            m_OptionList.ViewRootWithoutTone = chkRootNoTone.Checked;
            m_OptionList.ViewParaSentWord = chkParaSentWord.Checked;

            m_OptionList.FMRecordMarker = this.tbRM.Text;
            m_OptionList.FMLexicon = this.tbLX.Text;
			m_OptionList.FMGlossEnglish = this.tbGE.Text;
			m_OptionList.FMGlossNational = this.tbGN.Text;
			m_OptionList.FMGlossRegional = this.tbGR.Text;
			m_OptionList.FMPS = this.tbPS.Text;
			m_OptionList.FMPlural = this.tbPL.Text;
			m_OptionList.FMRoot = this.tbRT.Text;

            m_OptionList.LiftVernacular = this.tbLiftVern.Text;
            m_OptionList.LiftGlossEnglish = this.tbLiftGE.Text;
            m_OptionList.LiftGlossNational = this.tbLiftGN.Text;
            m_OptionList.LiftGlossRegional = this.tbLiftGR.Text;
			
            m_OptionList.CVCns = this.tbCns.Text;
			m_OptionList.CVSyllbc = this.tbCnsSyl.Text;
			m_OptionList.CVPrensl = this.tbCnsPrn.Text;
			m_OptionList.CVLablzd = this.tbCnsLab.Text;
			m_OptionList.CVPaltzd = this.tbCnsPal.Text;
			m_OptionList.CVVelrzd = this.tbCnsVel.Text;
            m_OptionList.CVAspir = this.tbCnsAsp.Text;
			m_OptionList.CVVwl = this.tbVwl.Text;
			m_OptionList.CVVwlNsl= this.tbVwlNsl.Text;
			m_OptionList.CVVwlLng = this.tbVwlLng.Text;
            m_OptionList.CVVwlDip = this.tbDipthongs.Text;
            m_OptionList.CVTone = this.tbTones.Text;

            m_OptionList.EndingPunct = this.tbEnding.Text;
            m_OptionList.GeneralPunct = this.tbGeneral.Text;
            if (m_OptionList.GeneralPunct.IndexOf(Constants.Space) < 0)
                m_OptionList.GeneralPunct = Constants.Space.ToString() + m_OptionList.GeneralPunct;

            m_OptionList.MaxSizeGrapheme = Convert.ToInt32(this.nudMax.Value);
            m_OptionList.ImportIgnoreChars = this.tbIgnoreChar.Text;
            m_OptionList.ImportReplacementList = new ReplacementList();
            string strReplace = "";
            string strWith = "";
            foreach (DataGridViewRow row in dgvReplace.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells[0].Value != null)
                {
                    strReplace = row.Cells[0].Value.ToString();
                    if (row.Cells[1].Value != null)
                        strWith = row.Cells[1].Value.ToString();
                    else strWith = "";
                    m_OptionList.ImportReplacementList.AddReplaceWith(strReplace, strWith);
                }
            }
            if (this.rbFrench.Checked)
                m_OptionList.UILanguage = OptionList.kFrench;
            else m_OptionList.UILanguage = OptionList.kEnglish;
            m_OptionList.SimplifiedMenu = this.chkSimplified.Checked;

			this.Close();
		}

		private void btnOptionsCancel_Click(object sender, System.EventArgs e)
		{
			Form.ActiveForm.Close();
		}

		private void btnDataFolder_Click(object sender, System.EventArgs e)
		{
			FolderBrowserDialog fbd1 = new FolderBrowserDialog();
            fbd1.RootFolder = Environment.SpecialFolder.Personal;
            //fbd1.Description = "Data Folder";
            fbd1.Description = m_Settings.LocalizationTable.GetMessage("FormOptions4",
                m_Settings.OptionSettings.UILanguage);
			fbd1.ShowNewFolderButton = true;
			if (fbd1.ShowDialog() == DialogResult.OK) 
			{
				tbDataFolder.Text = fbd1.SelectedPath;
			}
		}

		private void btnTemplateFolder_Click(object sender, System.EventArgs e)
		{
			FolderBrowserDialog fbd1 = new FolderBrowserDialog();
            fbd1.RootFolder = Environment.SpecialFolder.Personal;
            //fbd1.Description = "Template Folder";
            fbd1.Description = m_Settings.LocalizationTable.GetMessage("FormOptions5",
                m_Settings.OptionSettings.UILanguage);
            fbd1.ShowNewFolderButton = true;
			if (fbd1.ShowDialog() == DialogResult.OK) 
			{
				tbTemplateFolder.Text = fbd1.SelectedPath;
			}
		}

		private void btnGrfInventory_Click(object sender, System.EventArgs e)
		{
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "xml files (*.xml)|*.xml|All Files (*.*)|*.*";
            ofd.FileName = "";
            ofd.DefaultExt = "*.xml";
            ofd.InitialDirectory = tbDataFolder.Text;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tbInventory.Text = ofd.FileName;
            }
        }

        private void btnSightWords_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "xml files (*.xml)|*.xml|All Files (*.*)|*.*";
            ofd.FileName = "";
            ofd.DefaultExt = "*.xml";
            ofd.InitialDirectory = tbDataFolder.Text;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
                tbSightWords.Text = ofd.FileName;
        }

        private void btnTaughtOrder_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "xml files (*.xml)|*.xml|All Files (*.*)|*.*";
            ofd.FileName = "";
            ofd.DefaultExt = "*.xml";
            ofd.InitialDirectory = tbDataFolder.Text;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
                tbGT.Text = ofd.FileName;
        }

        private void btnPoS_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "xml files (*.xml)|*.xml|All Files (*.*)|*.*";
            ofd.FileName = "";
            ofd.DefaultExt = "*.xml";
            ofd.InitialDirectory = tbDataFolder.Text;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
                tbPoS.Text = ofd.FileName;
        }

        private void btnDfltFont_Click(object sender, System.EventArgs e)
        {
            string strName = m_Settings.OptionSettings.DefaultFontName;
            FontStyle style = m_Settings.OptionSettings.DefaultFontStyle;
            float emSize = (float)m_Settings.OptionSettings.DefaultFontSize;
            int nSize = 0;

            FontDialog dlg = new FontDialog();
            dlg.Font = new Font(strName, emSize, style);
            DialogResult dr = dlg.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                this.tbFontName.Text = dlg.Font.FontFamily.Name;
                emSize = dlg.Font.Size + 0.5F;
                nSize = (int)emSize;
                this.tbFontSize.Text = nSize.ToString();
                FontStyle style2 = dlg.Font.Style;
                this.tbFontStyle.Text = dlg.Font.Style.ToString();
                m_Settings.OptionSettings.DefaultFontName = tbFontName.Text;
                m_Settings.OptionSettings.DefaultFontSize = Convert.ToInt32(tbFontSize.Text);
                m_Settings.OptionSettings.DefaultFontStyle =
                    m_Settings.OptionSettings.ConvertStringToFontStyle(tbFontStyle.Text);
                this.labText.Font = m_Settings.OptionSettings.GetDefaultFont();
            }
            //else MessageBox.Show("Font Dialog cancelled");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("FormOptions2",
                m_Settings.OptionSettings.UILanguage));
        }

        private void btnHighlight_Click(object sender, System.EventArgs e)
		{
			Color hc = m_Settings.OptionSettings.HighlightColor;

			ColorDialog dlg = new ColorDialog();
			dlg.Color = hc;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Color hc2 = dlg.Color;
                this.tbHighlight.ForeColor = hc2;       //does not work

                //this.labSample.ForeColor = hc2;
                this.labColor.BackColor = hc2;
                this.labColor.ForeColor = Color.White;

                this.tbHighlight.Text = hc2.Name;
                if (hc2.IsNamedColor)
                    m_Settings.OptionSettings.HighlightColor = Color.FromName(tbHighlight.Text);
                else
                    m_Settings.OptionSettings.HighlightColor =
                        Color.FromArgb(Convert.ToInt32(hc2.A), Convert.ToInt32(hc2.R),
                        Convert.ToInt32(hc2.G), Convert.ToInt32(hc2.B));

            }
            //else MessageBox.Show("Color Dialog cancelled");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("FormOptions3",
                m_Settings.OptionSettings.UILanguage));
		}

    }
}

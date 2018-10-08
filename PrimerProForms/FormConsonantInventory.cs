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
	/// Summary description for FormConsonantInventory.
	/// </summary>
	public class FormConsonantInventory : System.Windows.Forms.Form
	{
		private Settings m_Settings;
		private int nCurrent;		// index of current consonant
		private Consonant cns;		// current consonant
        private bool fIsUpdated;    // Indicate the inventory has been updated

        //private const string cSaveText = "Do you want to save changes?";
        //private const string cSaveCaption = "Save Displayed Consonant";

		private System.Windows.Forms.Label labConsonant;
		private System.Windows.Forms.GroupBox gbPoint;
		private System.Windows.Forms.GroupBox gbManner;
		private System.Windows.Forms.CheckBox ckVoiced;
		private System.Windows.Forms.TextBox tbCns;
		private System.Windows.Forms.TextBox tbCurrent;
		private System.Windows.Forms.Label labOf;
		private System.Windows.Forms.TextBox tbCount;
		private System.Windows.Forms.Button btnPrev;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnDel;
		private System.Windows.Forms.Button btnFind;
		private System.Windows.Forms.TextBox tbFind;
		private System.Windows.Forms.Button btnSav;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.RadioButton rbBilabial;
		private System.Windows.Forms.RadioButton rbLabiodental;
		private System.Windows.Forms.RadioButton rbDental;
		private System.Windows.Forms.RadioButton rbAlveolar;
		private System.Windows.Forms.RadioButton rbPostalveolar;
		private System.Windows.Forms.RadioButton rbRetroflex;
		private System.Windows.Forms.RadioButton rbPalatal;
		private System.Windows.Forms.RadioButton rbVelar;
		private System.Windows.Forms.RadioButton rbLabialvelar;
		private System.Windows.Forms.RadioButton rbUvular;
		private System.Windows.Forms.RadioButton rbPharyngeal;
		private System.Windows.Forms.RadioButton rbGlottal;
		private System.Windows.Forms.RadioButton rbPlosive;
		private System.Windows.Forms.RadioButton rbNasal;
		private System.Windows.Forms.RadioButton rbTrill;
		private System.Windows.Forms.RadioButton rbFlap;
		private System.Windows.Forms.RadioButton rbFricative;
		private System.Windows.Forms.RadioButton rbAffricate;
		private System.Windows.Forms.RadioButton rbLateralFric;
		private System.Windows.Forms.CheckBox ckPrenasalized;
		private System.Windows.Forms.CheckBox ckLabialized;
		private System.Windows.Forms.CheckBox ckPalatized;
		private System.Windows.Forms.CheckBox ckVelarized;
		private System.Windows.Forms.RadioButton rbLateralAppr;
		private System.Windows.Forms.RadioButton rbApproximant;
		private System.Windows.Forms.RadioButton rbImplosive;
		private System.Windows.Forms.RadioButton rbEjective;
		private System.Windows.Forms.RadioButton rbClick;
		private System.Windows.Forms.RadioButton rbNotPOA;
		private System.Windows.Forms.RadioButton rbNotMOA;
		private System.Windows.Forms.CheckBox ckSyllabic;
		private System.Windows.Forms.Splitter splitter1;
        private CheckBox ckAspirated;
        private TextBox tbUC;
        private Label labUC;
        private CheckBox ckLong;
        private CheckBox ckCombination;
        private CheckBox ckGlottalized;
        private TextBox tbCombination;
		private System.ComponentModel.Container components = null;

		public FormConsonantInventory(Settings s)
		{
			InitializeComponent();
            if (s == null)
                m_Settings = new Settings();
            else m_Settings = s;
            Font font = m_Settings.OptionSettings.GetDefaultFont();
            this.tbCns.Font = font;
            this.tbUC.Font = font;
            this.tbFind.Font = font;
            this.tbCombination.Enabled = false;
			nCurrent = 0;			// First Consonant
            fIsUpdated = false;

            this.UpdateFormForLocalization(m_Settings.LocalizationTable);
            Redisplay();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConsonantInventory));
            this.ckVoiced = new System.Windows.Forms.CheckBox();
            this.labConsonant = new System.Windows.Forms.Label();
            this.tbCns = new System.Windows.Forms.TextBox();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnSav = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.tbCurrent = new System.Windows.Forms.TextBox();
            this.labOf = new System.Windows.Forms.Label();
            this.tbCount = new System.Windows.Forms.TextBox();
            this.gbPoint = new System.Windows.Forms.GroupBox();
            this.rbNotPOA = new System.Windows.Forms.RadioButton();
            this.rbGlottal = new System.Windows.Forms.RadioButton();
            this.rbPharyngeal = new System.Windows.Forms.RadioButton();
            this.rbUvular = new System.Windows.Forms.RadioButton();
            this.rbLabialvelar = new System.Windows.Forms.RadioButton();
            this.rbVelar = new System.Windows.Forms.RadioButton();
            this.rbPalatal = new System.Windows.Forms.RadioButton();
            this.rbRetroflex = new System.Windows.Forms.RadioButton();
            this.rbPostalveolar = new System.Windows.Forms.RadioButton();
            this.rbAlveolar = new System.Windows.Forms.RadioButton();
            this.rbDental = new System.Windows.Forms.RadioButton();
            this.rbLabiodental = new System.Windows.Forms.RadioButton();
            this.rbBilabial = new System.Windows.Forms.RadioButton();
            this.gbManner = new System.Windows.Forms.GroupBox();
            this.rbNotMOA = new System.Windows.Forms.RadioButton();
            this.rbClick = new System.Windows.Forms.RadioButton();
            this.rbEjective = new System.Windows.Forms.RadioButton();
            this.rbImplosive = new System.Windows.Forms.RadioButton();
            this.rbApproximant = new System.Windows.Forms.RadioButton();
            this.rbLateralAppr = new System.Windows.Forms.RadioButton();
            this.rbLateralFric = new System.Windows.Forms.RadioButton();
            this.rbAffricate = new System.Windows.Forms.RadioButton();
            this.rbFricative = new System.Windows.Forms.RadioButton();
            this.rbFlap = new System.Windows.Forms.RadioButton();
            this.rbTrill = new System.Windows.Forms.RadioButton();
            this.rbNasal = new System.Windows.Forms.RadioButton();
            this.rbPlosive = new System.Windows.Forms.RadioButton();
            this.btnFind = new System.Windows.Forms.Button();
            this.tbFind = new System.Windows.Forms.TextBox();
            this.ckPrenasalized = new System.Windows.Forms.CheckBox();
            this.ckLabialized = new System.Windows.Forms.CheckBox();
            this.ckPalatized = new System.Windows.Forms.CheckBox();
            this.ckVelarized = new System.Windows.Forms.CheckBox();
            this.ckSyllabic = new System.Windows.Forms.CheckBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.ckAspirated = new System.Windows.Forms.CheckBox();
            this.tbUC = new System.Windows.Forms.TextBox();
            this.labUC = new System.Windows.Forms.Label();
            this.ckLong = new System.Windows.Forms.CheckBox();
            this.ckCombination = new System.Windows.Forms.CheckBox();
            this.ckGlottalized = new System.Windows.Forms.CheckBox();
            this.tbCombination = new System.Windows.Forms.TextBox();
            this.gbPoint.SuspendLayout();
            this.gbManner.SuspendLayout();
            this.SuspendLayout();
            // 
            // ckVoiced
            // 
            this.ckVoiced.Location = new System.Drawing.Point(342, 154);
            this.ckVoiced.Name = "ckVoiced";
            this.ckVoiced.Size = new System.Drawing.Size(103, 20);
            this.ckVoiced.TabIndex = 11;
            this.ckVoiced.Text = "Voiced";
            // 
            // labConsonant
            // 
            this.labConsonant.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labConsonant.Location = new System.Drawing.Point(14, 13);
            this.labConsonant.Name = "labConsonant";
            this.labConsonant.Size = new System.Drawing.Size(75, 19);
            this.labConsonant.TabIndex = 0;
            this.labConsonant.Text = "Consonant:";
            // 
            // tbCns
            // 
            this.tbCns.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCns.Location = new System.Drawing.Point(117, 12);
            this.tbCns.Name = "tbCns";
            this.tbCns.Size = new System.Drawing.Size(54, 21);
            this.tbCns.TabIndex = 1;
            this.tbCns.Enter += new System.EventHandler(this.tbCns_Enter);
            this.tbCns.Leave += new System.EventHandler(this.tbCns_Leave);
            // 
            // btnPrev
            // 
            this.btnPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrev.Location = new System.Drawing.Point(494, 144);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(85, 26);
            this.btnPrev.TabIndex = 20;
            this.btnPrev.Text = "&Previous";
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnSav
            // 
            this.btnSav.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSav.Location = new System.Drawing.Point(494, 319);
            this.btnSav.Name = "btnSav";
            this.btnSav.Size = new System.Drawing.Size(85, 26);
            this.btnSav.TabIndex = 26;
            this.btnSav.Text = "&Save";
            this.btnSav.Click += new System.EventHandler(this.btnSav_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(589, 319);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(86, 26);
            this.btnExit.TabIndex = 27;
            this.btnExit.Text = "E&xit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(494, 177);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(85, 26);
            this.btnNext.TabIndex = 21;
            this.btnNext.Text = "&Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(494, 210);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 26);
            this.btnAdd.TabIndex = 22;
            this.btnAdd.Text = "&Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(494, 243);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(85, 26);
            this.btnDel.TabIndex = 23;
            this.btnDel.Text = "&Delete";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // tbCurrent
            // 
            this.tbCurrent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCurrent.Location = new System.Drawing.Point(206, 13);
            this.tbCurrent.Name = "tbCurrent";
            this.tbCurrent.ReadOnly = true;
            this.tbCurrent.Size = new System.Drawing.Size(27, 14);
            this.tbCurrent.TabIndex = 2;
            this.tbCurrent.TabStop = false;
            this.tbCurrent.Text = "???";
            this.tbCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labOf
            // 
            this.labOf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labOf.Location = new System.Drawing.Point(240, 13);
            this.labOf.Name = "labOf";
            this.labOf.Size = new System.Drawing.Size(21, 13);
            this.labOf.TabIndex = 3;
            this.labOf.Text = "of";
            this.labOf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbCount
            // 
            this.tbCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCount.Location = new System.Drawing.Point(261, 13);
            this.tbCount.Name = "tbCount";
            this.tbCount.ReadOnly = true;
            this.tbCount.Size = new System.Drawing.Size(27, 14);
            this.tbCount.TabIndex = 4;
            this.tbCount.TabStop = false;
            this.tbCount.Text = "???";
            this.tbCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gbPoint
            // 
            this.gbPoint.Controls.Add(this.rbNotPOA);
            this.gbPoint.Controls.Add(this.rbGlottal);
            this.gbPoint.Controls.Add(this.rbPharyngeal);
            this.gbPoint.Controls.Add(this.rbUvular);
            this.gbPoint.Controls.Add(this.rbLabialvelar);
            this.gbPoint.Controls.Add(this.rbVelar);
            this.gbPoint.Controls.Add(this.rbPalatal);
            this.gbPoint.Controls.Add(this.rbRetroflex);
            this.gbPoint.Controls.Add(this.rbPostalveolar);
            this.gbPoint.Controls.Add(this.rbAlveolar);
            this.gbPoint.Controls.Add(this.rbDental);
            this.gbPoint.Controls.Add(this.rbLabiodental);
            this.gbPoint.Controls.Add(this.rbBilabial);
            this.gbPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPoint.Location = new System.Drawing.Point(21, 64);
            this.gbPoint.Name = "gbPoint";
            this.gbPoint.Size = new System.Drawing.Size(137, 290);
            this.gbPoint.TabIndex = 7;
            this.gbPoint.TabStop = false;
            this.gbPoint.Text = "Point of Articulation";
            // 
            // rbNotPOA
            // 
            this.rbNotPOA.Location = new System.Drawing.Point(14, 257);
            this.rbNotPOA.Name = "rbNotPOA";
            this.rbNotPOA.Size = new System.Drawing.Size(109, 20);
            this.rbNotPOA.TabIndex = 12;
            this.rbNotPOA.Text = "Not Applicable";
            // 
            // rbGlottal
            // 
            this.rbGlottal.Location = new System.Drawing.Point(14, 237);
            this.rbGlottal.Name = "rbGlottal";
            this.rbGlottal.Size = new System.Drawing.Size(103, 20);
            this.rbGlottal.TabIndex = 11;
            this.rbGlottal.Text = "Glottal";
            // 
            // rbPharyngeal
            // 
            this.rbPharyngeal.Location = new System.Drawing.Point(14, 217);
            this.rbPharyngeal.Name = "rbPharyngeal";
            this.rbPharyngeal.Size = new System.Drawing.Size(103, 20);
            this.rbPharyngeal.TabIndex = 10;
            this.rbPharyngeal.Text = "Pharyngeal";
            // 
            // rbUvular
            // 
            this.rbUvular.Location = new System.Drawing.Point(14, 198);
            this.rbUvular.Name = "rbUvular";
            this.rbUvular.Size = new System.Drawing.Size(103, 19);
            this.rbUvular.TabIndex = 9;
            this.rbUvular.Text = "Uvular";
            // 
            // rbLabialvelar
            // 
            this.rbLabialvelar.Location = new System.Drawing.Point(14, 178);
            this.rbLabialvelar.Name = "rbLabialvelar";
            this.rbLabialvelar.Size = new System.Drawing.Size(103, 20);
            this.rbLabialvelar.TabIndex = 8;
            this.rbLabialvelar.Text = "Labial-velar";
            // 
            // rbVelar
            // 
            this.rbVelar.Location = new System.Drawing.Point(14, 158);
            this.rbVelar.Name = "rbVelar";
            this.rbVelar.Size = new System.Drawing.Size(103, 20);
            this.rbVelar.TabIndex = 7;
            this.rbVelar.Text = "Velar";
            // 
            // rbPalatal
            // 
            this.rbPalatal.Location = new System.Drawing.Point(14, 138);
            this.rbPalatal.Name = "rbPalatal";
            this.rbPalatal.Size = new System.Drawing.Size(103, 20);
            this.rbPalatal.TabIndex = 6;
            this.rbPalatal.Text = "Palatal";
            // 
            // rbRetroflex
            // 
            this.rbRetroflex.Location = new System.Drawing.Point(14, 119);
            this.rbRetroflex.Name = "rbRetroflex";
            this.rbRetroflex.Size = new System.Drawing.Size(103, 19);
            this.rbRetroflex.TabIndex = 5;
            this.rbRetroflex.Text = "Retroflex";
            // 
            // rbPostalveolar
            // 
            this.rbPostalveolar.Location = new System.Drawing.Point(14, 99);
            this.rbPostalveolar.Name = "rbPostalveolar";
            this.rbPostalveolar.Size = new System.Drawing.Size(103, 20);
            this.rbPostalveolar.TabIndex = 4;
            this.rbPostalveolar.Text = "Postalveolar";
            // 
            // rbAlveolar
            // 
            this.rbAlveolar.Location = new System.Drawing.Point(14, 79);
            this.rbAlveolar.Name = "rbAlveolar";
            this.rbAlveolar.Size = new System.Drawing.Size(103, 20);
            this.rbAlveolar.TabIndex = 3;
            this.rbAlveolar.Text = "Alveolar";
            // 
            // rbDental
            // 
            this.rbDental.Location = new System.Drawing.Point(14, 59);
            this.rbDental.Name = "rbDental";
            this.rbDental.Size = new System.Drawing.Size(103, 20);
            this.rbDental.TabIndex = 2;
            this.rbDental.Text = "Dental";
            // 
            // rbLabiodental
            // 
            this.rbLabiodental.Location = new System.Drawing.Point(14, 40);
            this.rbLabiodental.Name = "rbLabiodental";
            this.rbLabiodental.Size = new System.Drawing.Size(103, 19);
            this.rbLabiodental.TabIndex = 1;
            this.rbLabiodental.Text = "Labiodental";
            // 
            // rbBilabial
            // 
            this.rbBilabial.Location = new System.Drawing.Point(14, 20);
            this.rbBilabial.Name = "rbBilabial";
            this.rbBilabial.Size = new System.Drawing.Size(103, 20);
            this.rbBilabial.TabIndex = 0;
            this.rbBilabial.Text = "Bilabial";
            // 
            // gbManner
            // 
            this.gbManner.Controls.Add(this.rbNotMOA);
            this.gbManner.Controls.Add(this.rbClick);
            this.gbManner.Controls.Add(this.rbEjective);
            this.gbManner.Controls.Add(this.rbImplosive);
            this.gbManner.Controls.Add(this.rbApproximant);
            this.gbManner.Controls.Add(this.rbLateralAppr);
            this.gbManner.Controls.Add(this.rbLateralFric);
            this.gbManner.Controls.Add(this.rbAffricate);
            this.gbManner.Controls.Add(this.rbFricative);
            this.gbManner.Controls.Add(this.rbFlap);
            this.gbManner.Controls.Add(this.rbTrill);
            this.gbManner.Controls.Add(this.rbNasal);
            this.gbManner.Controls.Add(this.rbPlosive);
            this.gbManner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbManner.Location = new System.Drawing.Point(178, 63);
            this.gbManner.Name = "gbManner";
            this.gbManner.Size = new System.Drawing.Size(151, 289);
            this.gbManner.TabIndex = 8;
            this.gbManner.TabStop = false;
            this.gbManner.Text = "Manner of Articulation";
            // 
            // rbNotMOA
            // 
            this.rbNotMOA.Location = new System.Drawing.Point(14, 257);
            this.rbNotMOA.Name = "rbNotMOA";
            this.rbNotMOA.Size = new System.Drawing.Size(109, 20);
            this.rbNotMOA.TabIndex = 12;
            this.rbNotMOA.Text = "Not Applicable";
            // 
            // rbClick
            // 
            this.rbClick.Location = new System.Drawing.Point(14, 237);
            this.rbClick.Name = "rbClick";
            this.rbClick.Size = new System.Drawing.Size(103, 20);
            this.rbClick.TabIndex = 11;
            this.rbClick.Text = "Click";
            // 
            // rbEjective
            // 
            this.rbEjective.Location = new System.Drawing.Point(14, 217);
            this.rbEjective.Name = "rbEjective";
            this.rbEjective.Size = new System.Drawing.Size(103, 20);
            this.rbEjective.TabIndex = 10;
            this.rbEjective.Text = "Ejective";
            // 
            // rbImplosive
            // 
            this.rbImplosive.Location = new System.Drawing.Point(14, 198);
            this.rbImplosive.Name = "rbImplosive";
            this.rbImplosive.Size = new System.Drawing.Size(103, 19);
            this.rbImplosive.TabIndex = 9;
            this.rbImplosive.Text = "Implosive";
            // 
            // rbApproximant
            // 
            this.rbApproximant.Location = new System.Drawing.Point(14, 178);
            this.rbApproximant.Name = "rbApproximant";
            this.rbApproximant.Size = new System.Drawing.Size(103, 20);
            this.rbApproximant.TabIndex = 8;
            this.rbApproximant.Text = "Approximant";
            // 
            // rbLateralAppr
            // 
            this.rbLateralAppr.Location = new System.Drawing.Point(14, 158);
            this.rbLateralAppr.Name = "rbLateralAppr";
            this.rbLateralAppr.Size = new System.Drawing.Size(103, 20);
            this.rbLateralAppr.TabIndex = 7;
            this.rbLateralAppr.Text = "Lateral Appr";
            // 
            // rbLateralFric
            // 
            this.rbLateralFric.Location = new System.Drawing.Point(14, 138);
            this.rbLateralFric.Name = "rbLateralFric";
            this.rbLateralFric.Size = new System.Drawing.Size(103, 20);
            this.rbLateralFric.TabIndex = 6;
            this.rbLateralFric.Text = "Lateral Fric";
            // 
            // rbAffricate
            // 
            this.rbAffricate.Location = new System.Drawing.Point(14, 119);
            this.rbAffricate.Name = "rbAffricate";
            this.rbAffricate.Size = new System.Drawing.Size(103, 19);
            this.rbAffricate.TabIndex = 5;
            this.rbAffricate.Text = "Affricate";
            // 
            // rbFricative
            // 
            this.rbFricative.Location = new System.Drawing.Point(14, 99);
            this.rbFricative.Name = "rbFricative";
            this.rbFricative.Size = new System.Drawing.Size(103, 20);
            this.rbFricative.TabIndex = 4;
            this.rbFricative.Text = "Fricative";
            // 
            // rbFlap
            // 
            this.rbFlap.Location = new System.Drawing.Point(14, 79);
            this.rbFlap.Name = "rbFlap";
            this.rbFlap.Size = new System.Drawing.Size(103, 20);
            this.rbFlap.TabIndex = 3;
            this.rbFlap.Text = "Flap or Tap";
            // 
            // rbTrill
            // 
            this.rbTrill.Location = new System.Drawing.Point(14, 59);
            this.rbTrill.Name = "rbTrill";
            this.rbTrill.Size = new System.Drawing.Size(103, 20);
            this.rbTrill.TabIndex = 2;
            this.rbTrill.Text = "Trill";
            // 
            // rbNasal
            // 
            this.rbNasal.Location = new System.Drawing.Point(14, 40);
            this.rbNasal.Name = "rbNasal";
            this.rbNasal.Size = new System.Drawing.Size(103, 19);
            this.rbNasal.TabIndex = 1;
            this.rbNasal.Text = "Nasal";
            // 
            // rbPlosive
            // 
            this.rbPlosive.Location = new System.Drawing.Point(14, 20);
            this.rbPlosive.Name = "rbPlosive";
            this.rbPlosive.Size = new System.Drawing.Size(132, 20);
            this.rbPlosive.TabIndex = 0;
            this.rbPlosive.Text = "Plosive";
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Location = new System.Drawing.Point(571, 276);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(86, 26);
            this.btnFind.TabIndex = 25;
            this.btnFind.Text = "&Find";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // tbFind
            // 
            this.tbFind.AcceptsReturn = true;
            this.tbFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFind.Location = new System.Drawing.Point(497, 276);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(69, 23);
            this.tbFind.TabIndex = 24;
            this.tbFind.Enter += new System.EventHandler(this.tbFind_Enter);
            this.tbFind.Leave += new System.EventHandler(this.tbFind_Leave);
            // 
            // ckPrenasalized
            // 
            this.ckPrenasalized.Location = new System.Drawing.Point(342, 174);
            this.ckPrenasalized.Name = "ckPrenasalized";
            this.ckPrenasalized.Size = new System.Drawing.Size(103, 20);
            this.ckPrenasalized.TabIndex = 12;
            this.ckPrenasalized.Text = "Prenasalized";
            // 
            // ckLabialized
            // 
            this.ckLabialized.Location = new System.Drawing.Point(342, 194);
            this.ckLabialized.Name = "ckLabialized";
            this.ckLabialized.Size = new System.Drawing.Size(103, 19);
            this.ckLabialized.TabIndex = 13;
            this.ckLabialized.Text = "Labialized";
            // 
            // ckPalatized
            // 
            this.ckPalatized.Location = new System.Drawing.Point(342, 213);
            this.ckPalatized.Name = "ckPalatized";
            this.ckPalatized.Size = new System.Drawing.Size(103, 20);
            this.ckPalatized.TabIndex = 14;
            this.ckPalatized.Text = "Palatalized";
            // 
            // ckVelarized
            // 
            this.ckVelarized.Location = new System.Drawing.Point(342, 233);
            this.ckVelarized.Name = "ckVelarized";
            this.ckVelarized.Size = new System.Drawing.Size(103, 20);
            this.ckVelarized.TabIndex = 15;
            this.ckVelarized.Text = "Velarized";
            // 
            // ckSyllabic
            // 
            this.ckSyllabic.Location = new System.Drawing.Point(342, 253);
            this.ckSyllabic.Name = "ckSyllabic";
            this.ckSyllabic.Size = new System.Drawing.Size(103, 20);
            this.ckSyllabic.TabIndex = 16;
            this.ckSyllabic.Text = "Syllabic";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 445);
            this.splitter1.TabIndex = 40;
            this.splitter1.TabStop = false;
            // 
            // ckAspirated
            // 
            this.ckAspirated.Location = new System.Drawing.Point(342, 273);
            this.ckAspirated.Name = "ckAspirated";
            this.ckAspirated.Size = new System.Drawing.Size(103, 19);
            this.ckAspirated.TabIndex = 17;
            this.ckAspirated.Text = "Aspirated";
            // 
            // tbUC
            // 
            this.tbUC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUC.Location = new System.Drawing.Point(456, 13);
            this.tbUC.Name = "tbUC";
            this.tbUC.Size = new System.Drawing.Size(55, 21);
            this.tbUC.TabIndex = 6;
            // 
            // labUC
            // 
            this.labUC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labUC.Location = new System.Drawing.Point(354, 13);
            this.labUC.Name = "labUC";
            this.labUC.Size = new System.Drawing.Size(75, 19);
            this.labUC.TabIndex = 5;
            this.labUC.Text = "Upper case";
            // 
            // ckLong
            // 
            this.ckLong.Location = new System.Drawing.Point(342, 295);
            this.ckLong.Name = "ckLong";
            this.ckLong.Size = new System.Drawing.Size(103, 20);
            this.ckLong.TabIndex = 18;
            this.ckLong.Text = "Long";
            // 
            // ckCombination
            // 
            this.ckCombination.AutoSize = true;
            this.ckCombination.Location = new System.Drawing.Point(342, 64);
            this.ckCombination.Name = "ckCombination";
            this.ckCombination.Size = new System.Drawing.Size(158, 19);
            this.ckCombination.TabIndex = 9;
            this.ckCombination.Text = "Consonant Combination";
            this.ckCombination.UseVisualStyleBackColor = true;
            this.ckCombination.CheckedChanged += new System.EventHandler(this.ckCombination_CheckedChanged);
            // 
            // ckGlottalized
            // 
            this.ckGlottalized.Location = new System.Drawing.Point(342, 320);
            this.ckGlottalized.Name = "ckGlottalized";
            this.ckGlottalized.Size = new System.Drawing.Size(103, 19);
            this.ckGlottalized.TabIndex = 19;
            this.ckGlottalized.Text = "Glottalized";
            // 
            // tbCombination
            // 
            this.tbCombination.AcceptsReturn = true;
            this.tbCombination.Location = new System.Drawing.Point(530, 63);
            this.tbCombination.Multiline = true;
            this.tbCombination.Name = "tbCombination";
            this.tbCombination.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbCombination.Size = new System.Drawing.Size(68, 69);
            this.tbCombination.TabIndex = 10;
            this.tbCombination.WordWrap = false;
            // 
            // FormConsonantInventory
            // 
            this.AcceptButton = this.btnSav;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(807, 445);
            this.Controls.Add(this.tbCombination);
            this.Controls.Add(this.ckGlottalized);
            this.Controls.Add(this.ckCombination);
            this.Controls.Add(this.ckLong);
            this.Controls.Add(this.labUC);
            this.Controls.Add(this.tbUC);
            this.Controls.Add(this.ckAspirated);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.ckSyllabic);
            this.Controls.Add(this.ckVelarized);
            this.Controls.Add(this.ckPalatized);
            this.Controls.Add(this.ckLabialized);
            this.Controls.Add(this.ckPrenasalized);
            this.Controls.Add(this.tbFind);
            this.Controls.Add(this.tbCount);
            this.Controls.Add(this.tbCurrent);
            this.Controls.Add(this.tbCns);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.gbManner);
            this.Controls.Add(this.labOf);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSav);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.labConsonant);
            this.Controls.Add(this.ckVoiced);
            this.Controls.Add(this.gbPoint);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormConsonantInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Consonant Inventory";
            this.gbPoint.ResumeLayout(false);
            this.gbManner.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private void tbCns_Enter(object sender, EventArgs e)
        {
            if (m_Settings.GraphemeInventory.ConsonantCount() == 0)
            {
                Consonant cns = new Consonant(" ");
                int nCount = m_Settings.GraphemeInventory.ConsonantCount();
                m_Settings.GraphemeInventory.AddConsonant(cns);
                nCurrent = nCount;
                Redisplay();
            }
        }

        private void tbCns_Leave(object sender, EventArgs e)
        {
            string str;
            if (this.tbCns.Text.Substring(0,1) == "_")
            {
            }

            if (this.tbUC.Text == "")
            {
                str = this.tbCns.Text;
                if (str.Length > 1)
                    str = str.Substring(0, 1).ToUpper() + str.Substring(1);
                else str = str.ToUpper();
                this.tbUC.Text = str;
            }
        }

        private void btnPrev_Click(object sender, System.EventArgs e)
		{
            if (HasChanged())
            {
                //if (MessageBox.Show("Do you want to save the changes?", "Saved Displayed Consonant", MessageBoxButtons.YesNo) == DialogResult.Yes)
                //    SaveIt();
                string strText = m_Settings.LocalizationTable.GetMessage("FormConsonantInventory1");
                if (strText == "")
                    strText = "Do you want to save the changes?";
                string strCaption = m_Settings.LocalizationTable.GetMessage("FormConsonantInventory2");
                if (strCaption == "")
                    strCaption = "Saved Displayed Consonant";
                if (MessageBox.Show(strText, strCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    SaveIt();
            }
			if ( nCurrent > 0 )
				nCurrent--;
			Redisplay();
		}

		private void btnNext_Click(object sender, System.EventArgs e)
		{
            if (HasChanged())
            {
                //if (MessageBox.Show("Do you want to save the changes?", "Saved Displayed Consonant", MessageBoxButtons.YesNo) == DialogResult.Yes)
                //    SaveIt();
                string strText = m_Settings.LocalizationTable.GetMessage("FormConsonantInventory1");
                if (strText == "")
                    strText = "Do you want to save the changes?";
                string strCaption = m_Settings.LocalizationTable.GetMessage("FormConsonantInventory2");
                if (strCaption == "")
                    strCaption = "Saved Displayed Consonant";
                if (MessageBox.Show(strText, strCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    SaveIt();
            }
			if ( nCurrent < m_Settings.GraphemeInventory.ConsonantCount()-1) 
				nCurrent++;
			Redisplay();
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
            if (HasChanged())
            {
                //if (MessageBox.Show("Do you want to save the changes?", "Saved Displayed Consonant", MessageBoxButtons.YesNo) == DialogResult.Yes)
                //    SaveIt();
                string strText = m_Settings.LocalizationTable.GetMessage("FormConsonantInventory1");
                if (strText == "")
                    strText = "Do you want to save the changes?";
                string strCaption = m_Settings.LocalizationTable.GetMessage("FormConsonantInventory2");
                if (strCaption == "")
                    strCaption = "Saved Displayed Consonant";
                if (MessageBox.Show(strText, strCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    SaveIt();
            }
			Consonant cns = new Consonant(" ");
			int nCount = m_Settings.GraphemeInventory.ConsonantCount();
            m_Settings.GraphemeInventory.AddConsonant(cns);
			nCurrent = nCount;
			Redisplay();
 		}

		private void btnDel_Click(object sender, System.EventArgs e)
		{
			int next = nCurrent;
			m_Settings.GraphemeInventory.DelConsonant(nCurrent);
			if ( next < m_Settings.GraphemeInventory.ConsonantCount() )
				nCurrent = next;
			else nCurrent = m_Settings.GraphemeInventory.ConsonantCount() - 1;
            fIsUpdated = true;
			Redisplay();
		}

		private void btnFind_Click(object sender, System.EventArgs e)
		{
            string strText = "";
            string strCaption = "";
            if (HasChanged())
            {
                //if (MessageBox.Show("Do you want to save the changes?", "Saved Displayed Consonant", MessageBoxButtons.YesNo) == DialogResult.Yes)
                //    SaveIt();
                strText = m_Settings.LocalizationTable.GetMessage("FormConsonantInventory1");
                if (strText == "")
                    strText = "Do you want to save the changes?";
                strCaption = m_Settings.LocalizationTable.GetMessage("FormConsonantInventory2");
                if (strCaption == "")
                    strCaption = "Saved Displayed Consonant";
                if (MessageBox.Show(strText, strCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    SaveIt();
            }

            string strSymbol = this.tbFind.Text;
			int n = 0;
            if (strSymbol != "")
            {
                n = m_Settings.GraphemeInventory.FindConsonantIndex(strSymbol);
                if ((n >= 0) && (n < m_Settings.GraphemeInventory.ConsonantCount()))
                {
                    nCurrent = n;
                    Redisplay();
                }
                //else MessageBox.Show("Grapheme not found");
                else
                {
                    strText = m_Settings.LocalizationTable.GetMessage("FormConsonantInventory3");
                    if (strText == "")
                        strText = "Grapheme not found";
                    MessageBox.Show(m_Settings.LocalizationTable.GetMessage("FormConsonantInventory3"));
                }
            }
            //else MessageBox.Show("Grapheme must be specified in the adjacent box");
            else
            {
                strText = m_Settings.LocalizationTable.GetMessage("FormConsonantInventory4");
                if (strText == "")
                    strText = "Grapheme must be specified in the adjacent box";
                MessageBox.Show(strText);
            }

		}

		private void btnSav_Click(object sender, System.EventArgs e)
		{
            SaveIt();
			return;
        }

        private void SaveIt()
        {
            string strText = "";
			string strSymbol = this.tbCns.Text.Trim();
            if (strSymbol != "")
            {
                if ((!m_Settings.GraphemeInventory.IsInInventory(strSymbol))
                    || (nCurrent == m_Settings.GraphemeInventory.GetGraphemeIndex(strSymbol)))
                {
                    cns.Symbol = this.tbCns.Text.Trim();
                    cns.Key = cns.GetKey(); ;
                    cns.UpperCase = this.tbUC.Text.Trim();
                    cns.IsBilabial = this.rbBilabial.Checked;
                    cns.IsLabiodental = this.rbLabiodental.Checked;
                    cns.IsDental = this.rbDental.Checked;
                    cns.IsAlveolar = this.rbAlveolar.Checked;
                    cns.IsPostalveolar = this.rbPostalveolar.Checked;
                    cns.IsRetroflex = this.rbRetroflex.Checked;
                    cns.IsPalatal = this.rbPalatal.Checked;
                    cns.IsVelar = this.rbVelar.Checked;
                    cns.IsLabialvelar = this.rbLabialvelar.Checked;
                    cns.IsUvular = this.rbUvular.Checked;
                    cns.IsPharyngeal = this.rbPharyngeal.Checked;
                    cns.IsGlottal = this.rbGlottal.Checked;

                    cns.IsPlosive = this.rbPlosive.Checked;
                    cns.IsNasal = this.rbNasal.Checked;
                    cns.IsTrill = this.rbTrill.Checked;
                    cns.IsFlap = this.rbFlap.Checked;
                    cns.IsFricative = this.rbFricative.Checked;
                    cns.IsAffricate = this.rbAffricate.Checked;
                    cns.IsLateralFric = this.rbLateralFric.Checked;
                    cns.IsLateralAppr = this.rbLateralAppr.Checked;
                    cns.IsApproximant = this.rbApproximant.Checked;
                    cns.IsImplosive = this.rbImplosive.Checked;
                    cns.IsEjective = this.rbEjective.Checked;
                    cns.IsClick = this.rbClick.Checked; ;

                    cns.IsVoiced = this.ckVoiced.Checked;
                    cns.IsPrenasalized = this.ckPrenasalized.Checked;
                    cns.IsLabialized = this.ckLabialized.Checked;
                    cns.IsPalatalized = this.ckPalatized.Checked;
                    cns.IsVelarized = this.ckVelarized.Checked;
                    cns.IsSyllabic = this.ckSyllabic.Checked;
                    cns.IsSyllabicConsonant = cns.IsSyllabic;
                    cns.IsAspirated = this.ckAspirated.Checked;
                    cns.IsLong = this.ckLong.Checked;
                    cns.IsGlottalized = this.ckGlottalized.Checked;

                    cns.IsComplex = this.ckCombination.Checked;
                    cns.ComplexComponents = Funct.ConvertStringToArrayList(this.tbCombination.Text,
                        Environment.NewLine);

                    fIsUpdated = true;
                    //MessageBox.Show("Consonant Saved");
                    MessageBox.Show(m_Settings.LocalizationTable.GetMessage("FormConsonantInventory5"));
                }
                else
                {
                    //MessageBox.Show("Consonant is already in inventory");
                    strText = m_Settings.LocalizationTable.GetMessage("FormConsonantInventory6");
                    if (strText == "")
                        strText = "Consonant is already in inventory";
                    MessageBox.Show(strText);
                    cns = m_Settings.GraphemeInventory.GetConsonant(nCurrent);
                    this.tbCns.Text = cns.Symbol;
                }
            }
            //else MessageBox.Show("Consonant must be specified");
            else
            {
                strText = m_Settings.LocalizationTable.GetMessage("FormConsonantInventory7");
                if (strText == "")
                    strText = "Consonant must be specified";
                MessageBox.Show(strText);
            }
			return;
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
            string strText = "";
            string strCaption = "";
            if (HasChanged())
            {
                //if (MessageBox.Show("Do you want to save the changes?", "Saved Displayed Consonant", MessageBoxButtons.YesNo) == DialogResult.Yes)
                //    SaveIt();
                strText = m_Settings.LocalizationTable.GetMessage("FormConsonantInventory1");
                if (strText == "")
                    strText = "Do you want to save the changes?";
                strCaption = m_Settings.LocalizationTable.GetMessage("FormConsonantInventory2");
                if (strCaption == "")
                    strCaption = "Saved Displayed Consonant";
                if (MessageBox.Show(strText, strCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    SaveIt();
                else
                {
                    // delete empty consonants
                    ArrayList alConsonants = m_Settings.GraphemeInventory.Consonants;
                    for (int i = alConsonants.Count - 1; 0 <= i; i--)
                    {
                        Consonant cns = (Consonant) alConsonants[i];
                        if (cns.Symbol.Trim() == "")
                            m_Settings.GraphemeInventory.DelConsonant(i);
                    }
                }
            }

            if (fIsUpdated)
            {
                //MessageBox.Show("Since the graphene inventory has been updated, you need to reimport the word list and text data.");
                strText  = m_Settings.LocalizationTable.GetMessage("FormConsonantInventory8");
                if (strText == "")
                    strText = "Since the graphene inventory has been updated, you need to reimport the word list and text data.";
                MessageBox.Show(strText);
            }
			this.Close();
		}

		private void AtClosed(object sender, System.EventArgs e)
		{
            GraphemeInventory gi = m_Settings.GraphemeInventory;
			int nConsonants = gi.ConsonantCount();
            if (nConsonants > 0)
            {
                Consonant cns = null;
                for (int i = nConsonants; 0 < i; i--)
                {
                    cns = m_Settings.GraphemeInventory.GetConsonant(i - 1);
                    if (cns == null)
                        gi.DelConsonant(i - 1);
                    else if (cns.Symbol.Trim() == "")
                        gi.DelConsonant(i - 1);
                }
                m_Settings.GraphemeInventory = gi;
            }
		}

		private void Redisplay()
		{
			int n = 0;
            if (m_Settings.GraphemeInventory.ConsonantCount() > 0)
            {
                n = nCurrent + 1;
                cns = m_Settings.GraphemeInventory.GetConsonant(nCurrent);
            }
            else
            {
                cns = new Consonant(" ");
            }

			this.tbFind.Text = "";	// Clear Find box
			this.tbCns.Text = cns.Symbol;
            this.tbUC.Text = cns.UpperCase;
			this.tbCurrent.Text = n.ToString();
			this.tbCount.Text = m_Settings.GraphemeInventory.ConsonantCount().ToString();
			this.rbBilabial.Checked = cns.IsBilabial;
			this.rbLabiodental.Checked = cns.IsLabiodental;
			this.rbDental.Checked= cns.IsDental;
			this.rbAlveolar.Checked = cns.IsAlveolar;
			this.rbPostalveolar.Checked = cns.IsPostalveolar;
			this.rbRetroflex.Checked = cns.IsRetroflex;
			this.rbPalatal.Checked = cns.IsPalatal;
			this.rbVelar.Checked = cns.IsVelar;
			this.rbLabialvelar.Checked = cns.IsLabialvelar;
			this.rbUvular.Checked = cns.IsUvular;
			this.rbPharyngeal.Checked = cns.IsPharyngeal;
			this.rbGlottal.Checked = cns.IsGlottal;
			if ( !(this.rbBilabial.Checked ||
				this.rbLabiodental.Checked ||
				this.rbDental.Checked ||
				this.rbAlveolar.Checked ||
				this.rbPostalveolar.Checked ||
				this.rbRetroflex.Checked ||
				this.rbPalatal.Checked ||
				this.rbVelar.Checked ||
				this.rbLabialvelar.Checked||
				this.rbUvular.Checked ||
				this.rbPharyngeal.Checked ||
				this.rbGlottal.Checked) )
			{
				this.rbNotPOA.Checked = true;
			}
          
			this.rbPlosive.Checked = cns.IsPlosive;
			this.rbNasal.Checked = cns.IsNasal;
			this.rbTrill.Checked = cns.IsTrill;
			this.rbFlap.Checked = cns.IsFlap;
			this.rbFricative.Checked = cns.IsFricative;
			this.rbAffricate.Checked = cns.IsAffricate;
			this.rbLateralFric.Checked = cns.IsLateralFric;
			this.rbLateralAppr.Checked = cns.IsLateralAppr;
			this.rbApproximant.Checked = cns.IsApproximant;
			this.rbImplosive.Checked = cns.IsImplosive;
			this.rbEjective.Checked = cns.IsEjective;
			this.rbClick.Checked = cns.IsClick;
			if ( !(this.rbPlosive.Checked ||
				this.rbNasal.Checked ||
				this.rbTrill.Checked ||
				this.rbFlap.Checked ||
				this.rbFricative.Checked ||
				this.rbAffricate.Checked ||
				this.rbLateralFric.Checked ||
				this.rbLateralAppr.Checked ||
				this.rbApproximant.Checked ||
				this.rbImplosive.Checked ||
				this.rbEjective.Checked ||
				this.rbClick.Checked) )
			{
				this.rbNotMOA.Checked = true;
			}
			this.ckVoiced.Checked = cns.IsVoiced;
			this.ckPrenasalized.Checked = cns.IsPrenasalized;
			this.ckLabialized.Checked = cns.IsLabialized;
			this.ckPalatized.Checked = cns.IsPalatalized;
			this.ckVelarized.Checked = cns.IsVelarized;
			this.ckSyllabic.Checked = cns.IsSyllabic;
            this.ckAspirated.Checked = cns.IsAspirated;
            this.ckLong.Checked = cns.IsLong;
            this.ckGlottalized.Checked = cns.IsGlottalized;
 
            this.ckCombination.Checked = cns.IsComplex;
            this.tbCombination.Text = "";
            if (this.ckCombination.Checked)
            {
                this.tbCombination.Enabled = true;
                this.tbCombination.Text = Funct.ConvertArrayListToString(cns.ComplexComponents,
                    Environment.NewLine);
            }
            else this.tbCombination.Enabled = false;
            this.tbCns.Focus();
		}

        private bool HasChanged()
        {
            bool fChange = false;
            Consonant cns = null;
            int n = 0;
            if (m_Settings.GraphemeInventory.ConsonantCount() > 0)
            {
                n = nCurrent + 1;
                cns = m_Settings.GraphemeInventory.GetConsonant(nCurrent);
            }
            else return fChange;
            
            if (this.tbCns.Text != cns.Symbol) fChange = true;
            if (this.tbUC.Text != cns.UpperCase) fChange = true;
            if (this.rbBilabial.Checked != cns.IsBilabial) fChange = true;
            if (this.rbLabiodental.Checked != cns.IsLabiodental) fChange = true;
            if (this.rbDental.Checked != cns.IsDental) fChange = true;
            if (this.rbAlveolar.Checked != cns.IsAlveolar) fChange = true;
            if (this.rbPostalveolar.Checked != cns.IsPostalveolar) fChange = true;
            if (this.rbRetroflex.Checked != cns.IsRetroflex) fChange = true;
            if (this.rbPalatal.Checked != cns.IsPalatal) fChange = true;
            if (this.rbVelar.Checked != cns.IsVelar) fChange = true;
            if (this.rbLabialvelar.Checked != cns.IsLabialvelar) fChange = true;
            if (this.rbUvular.Checked != cns.IsUvular) fChange = true;
            if (this.rbPharyngeal.Checked != cns.IsPharyngeal) fChange = true;
            if (this.rbGlottal.Checked != cns.IsGlottal) fChange = true;
            if (this.rbPlosive.Checked != cns.IsPlosive) fChange = true;
            if (this.rbNasal.Checked != cns.IsNasal) fChange = true;
            if (this.rbTrill.Checked != cns.IsTrill) fChange = true;
            if (this.rbFlap.Checked != cns.IsFlap) fChange = true;
            if (this.rbFricative.Checked != cns.IsFricative) fChange = true;
            if (this.rbAffricate.Checked != cns.IsAffricate) fChange = true;
            if (this.rbLateralFric.Checked != cns.IsLateralFric) fChange = true;
            if (this.rbLateralAppr.Checked != cns.IsLateralAppr) fChange = true;
            if (this.rbApproximant.Checked != cns.IsApproximant) fChange = true;
            if (this.rbImplosive.Checked != cns.IsImplosive) fChange = true;
            if (this.rbEjective.Checked != cns.IsEjective) fChange = true;
            if (this.rbClick.Checked != cns.IsClick) fChange = true;
            if (this.ckVoiced.Checked != cns.IsVoiced) fChange = true;
            if (this.ckPrenasalized.Checked != cns.IsPrenasalized) fChange = true;
            if (this.ckLabialized.Checked != cns.IsLabialized) fChange = true;
            if (this.ckPalatized.Checked != cns.IsPalatalized) fChange = true;
            if (this.ckVelarized.Checked != cns.IsVelarized) fChange = true;
            if (this.ckSyllabic.Checked != cns.IsSyllabic) fChange = true;
            if (this.ckAspirated.Checked != cns.IsAspirated) fChange = true;
            if (this.ckLong.Checked != cns.IsLong) fChange = true;
            if (this.ckGlottalized.Checked != cns.IsGlottalized) fChange = true;
            return fChange;
        }

        private void ckCombination_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckCombination.Checked)
            {
                this.rbNotMOA.Checked = true;
                this.rbNotPOA.Checked = true;
                this.ckVoiced.Checked = false;
                this.ckPrenasalized.Checked = false;
                this.ckLabialized.Checked = false;
                this.ckPalatized.Checked = false;
                this.ckVelarized.Checked = false;
                this.ckSyllabic.Checked = false;
                this.ckAspirated.Checked = false;
                this.ckLong.Checked = false;
                this.ckGlottalized.Checked = false;
                this.tbCombination.Enabled = true;
                
                this.rbBilabial.Enabled = false;
                this.rbLabiodental.Enabled = false;
                this.rbDental.Enabled =false;
                this.rbAlveolar.Enabled = false;
                this.rbPostalveolar.Enabled = false;
                this.rbRetroflex.Enabled = false;
                this.rbPalatal.Enabled = false;
                this.rbVelar.Enabled = false;
                this.rbLabialvelar.Enabled = false;
                this.rbUvular.Enabled = false;
                this.rbPharyngeal.Enabled = false;
                this.rbGlottal.Enabled = false;

                this.rbPlosive.Enabled = false;
                this.rbNasal.Enabled = false;
                this.rbTrill.Enabled = false;
                this.rbFlap.Enabled = false;
                this.rbFricative.Enabled = false;
                this.rbAffricate.Enabled = false;
                this.rbLateralFric.Enabled = false;
                this.rbLateralAppr.Enabled = false;
                this.rbApproximant.Enabled = false;
                this.rbImplosive.Enabled = false;
                this.rbEjective.Enabled = false;
                this.rbClick.Enabled = false;

			    this.ckVoiced.Enabled = false;
                this.ckPrenasalized.Enabled = false;
                this.ckLabialized.Enabled = false;
                this.ckPalatized.Enabled = false;
                this.ckVelarized.Enabled = false;
                this.ckSyllabic.Enabled = false;
                this.ckAspirated.Enabled = false;
                this.ckLong.Enabled = false;
                this.ckGlottalized.Enabled = false;
                this.tbCombination.Focus();
            }
            else
            {
                this.tbCombination.Enabled = false;
                this.tbCombination.Text = "";

                this.rbBilabial.Enabled = true;
                this.rbLabiodental.Enabled = true;
                this.rbDental.Enabled = true;
                this.rbAlveolar.Enabled = true;
                this.rbPostalveolar.Enabled = true;
                this.rbRetroflex.Enabled = true;
                this.rbPalatal.Enabled = true;
                this.rbVelar.Enabled = true;
                this.rbLabialvelar.Enabled = true;
                this.rbUvular.Enabled = true;
                this.rbPharyngeal.Enabled = true;
                this.rbGlottal.Enabled = true;

                this.rbPlosive.Enabled = true;
                this.rbNasal.Enabled = true;
                this.rbTrill.Enabled = true;
                this.rbFlap.Enabled = true;
                this.rbFricative.Enabled = true;
                this.rbAffricate.Enabled = true;
                this.rbLateralFric.Enabled = true;
                this.rbLateralAppr.Enabled = true;
                this.rbApproximant.Enabled = true;
                this.rbImplosive.Enabled = true;
                this.rbEjective.Enabled = true;
                this.rbClick.Enabled = true;

                this.ckVoiced.Enabled = true;
                this.ckPrenasalized.Enabled = true;
                this.ckLabialized.Enabled = true;
                this.ckPalatized.Enabled = true;
                this.ckVelarized.Enabled = true;
                this.ckSyllabic.Enabled = true;
                this.ckAspirated.Enabled = true;
                this.ckLong.Enabled = true;
                this.ckGlottalized.Enabled = true;
            }
        }

        private void tbFind_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = btnSav;
        }

        private void tbFind_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = btnFind;
        }

        private void DisableAllControls()
        {
            this.ckVoiced.Checked = false;
            this.ckPrenasalized.Checked = false;
            this.ckLabialized.Checked = false;
            this.ckPalatized.Checked = false;
            this.ckVelarized.Checked = false;
            this.ckSyllabic.Checked = false;
            this.ckAspirated.Checked = false;
            this.ckLong.Checked = false;
            this.ckGlottalized.Checked = false;
            this.tbCombination.Enabled = false;
                
            this.rbBilabial.Enabled = false;
            this.rbLabiodental.Enabled = false;
            this.rbDental.Enabled =false;
            this.rbAlveolar.Enabled = false;
            this.rbPostalveolar.Enabled = false;
            this.rbRetroflex.Enabled = false;
            this.rbPalatal.Enabled = false;
            this.rbVelar.Enabled = false;
            this.rbLabialvelar.Enabled = false;
            this.rbUvular.Enabled = false;
            this.rbPharyngeal.Enabled = false;
            this.rbGlottal.Enabled = false;
            this.rbNotMOA.Enabled = false;

            this.rbPlosive.Enabled = false;
            this.rbNasal.Enabled = false;
            this.rbTrill.Enabled = false;
            this.rbFlap.Enabled = false;
            this.rbFricative.Enabled = false;
            this.rbAffricate.Enabled = false;
            this.rbLateralFric.Enabled = false;
            this.rbLateralAppr.Enabled = false;
            this.rbApproximant.Enabled = false;
            this.rbImplosive.Enabled = false;
            this.rbEjective.Enabled = false;
            this.rbClick.Enabled = false;
            this.rbNotPOA.Enabled = false;

			this.ckVoiced.Enabled = false;
            this.ckPrenasalized.Enabled = false;
            this.ckLabialized.Enabled = false;
            this.ckPalatized.Enabled = false;
            this.ckVelarized.Enabled = false;
            this.ckSyllabic.Enabled = false;
            this.ckAspirated.Enabled = false;
            this.ckLong.Enabled = false;
            this.ckGlottalized.Enabled = false;
        }

        private void UpdateFormForLocalization(LocalizationTable table)
        {
            string strText = "";
            strText = table.GetForm("FormConsonantInventoryT");
			if (strText != "")
				this.Text = strText;
            strText = table.GetForm("FormConsonantInventory0");
			if (strText != "")
				this.labConsonant.Text = strText;
            strText = table.GetForm("FormConsonantInventory3");
			if (strText != "")
				this.labOf.Text = strText;
            strText = table.GetForm("FormConsonantInventory5");
			if (strText != "")
				this.labUC.Text = strText;
            strText = table.GetForm("FormConsonantInventory7");
			if (strText != "")
				this.gbPoint.Text = strText;
            strText = table.GetForm("FormConsonantInventoryP0");
			if (strText != "")
				this.rbBilabial.Text = strText;
            strText = table.GetForm("FormConsonantInventoryP1");
			if (strText != "")
				this.rbLabiodental.Text = strText;
            strText = table.GetForm("FormConsonantInventoryP2");
			if (strText != "")
				this.rbDental.Text = strText;
            strText = table.GetForm("FormConsonantInventoryP3");
			if (strText != "")
				this.rbAlveolar.Text = strText;
            strText = table.GetForm("FormConsonantInventoryP4");
			if (strText != "")
				this.rbPostalveolar.Text = strText;
            strText = table.GetForm("FormConsonantInventoryP5");
			if (strText != "")
				this.rbRetroflex.Text = strText;
            strText = table.GetForm("FormConsonantInventoryP6");
			if (strText != "")
				this.rbPalatal.Text = strText;
            strText = table.GetForm("FormConsonantInventoryP7");
			if (strText != "")
				this.rbVelar.Text = strText;
            strText = table.GetForm("FormConsonantInventoryP8");
			if (strText != "")
				this.rbLabialvelar.Text = strText;
            strText = table.GetForm("FormConsonantInventoryP9");
			if (strText != "")
				this.rbUvular.Text = strText;
            strText = table.GetForm("FormConsonantInventoryP10");
			if (strText != "")
				this.rbPharyngeal.Text = strText;
            strText = table.GetForm("FormConsonantInventoryP11");
			if (strText != "")
				this.rbGlottal.Text = strText;
            strText = table.GetForm("FormConsonantInventoryP12");
			if (strText != "")
				this.rbNotPOA.Text = strText;
            strText = table.GetForm("FormConsonantInventory8");
			if (strText != "")
				this.gbManner.Text = strText;
            strText = table.GetForm("FormConsonantInventoryM0");
			if (strText != "")
				this.rbPlosive.Text = strText;
            strText = table.GetForm("FormConsonantInventoryM1");
			if (strText != "")
				this.rbNasal.Text = strText;
            strText = table.GetForm("FormConsonantInventoryM2");
			if (strText != "")
				this.rbTrill.Text = strText;
            strText = table.GetForm("FormConsonantInventoryM3");
			if (strText != "")
				this.rbFlap.Text = strText;
            strText = table.GetForm("FormConsonantInventoryM4");
			if (strText != "")
				this.rbFricative.Text = strText;
            strText = table.GetForm("FormConsonantInventoryM5");
			if (strText != "")
				this.rbAffricate.Text = strText;
            strText = table.GetForm("FormConsonantInventoryM6");
			if (strText != "")
				this.rbLateralFric.Text = strText;
            strText = table.GetForm("FormConsonantInventoryM7");
			if (strText != "")
				this.rbLateralAppr.Text = strText;
            strText = table.GetForm("FormConsonantInventoryM8");
			if (strText != "")
				this.rbApproximant.Text = strText;
            strText = table.GetForm("FormConsonantInventoryM9");
			if (strText != "")
				this.rbImplosive.Text = strText;
            strText = table.GetForm("FormConsonantInventoryM10");
			if (strText != "")
				this.rbEjective.Text = strText;
            strText = table.GetForm("FormConsonantInventoryM11");
			if (strText != "")
				this.rbClick.Text = strText;
            strText = table.GetForm("FormConsonantInventoryM12");
			if (strText != "")
				this.rbNotMOA.Text = strText;
            strText = table.GetForm("FormConsonantInventory9");
			if (strText != "")
				this.ckCombination.Text = strText;
            strText = table.GetForm("FormConsonantInventory11");
			if (strText != "")
				this.ckVoiced.Text = strText;
            strText = table.GetForm("FormConsonantInventory12");
			if (strText != "")
				this.ckPrenasalized.Text = strText;
            strText = table.GetForm("FormConsonantInventory13");
			if (strText != "")
				this.ckLabialized.Text = strText;
            strText = table.GetForm("FormConsonantInventory14");
			if (strText != "")
				this.ckPalatized.Text = strText;
            strText = table.GetForm("FormConsonantInventory15");
			if (strText != "")
				this.ckVelarized.Text = strText;
            strText = table.GetForm("FormConsonantInventory16");
			if (strText != "")
				this.ckSyllabic.Text = strText;
            strText = table.GetForm("FormConsonantInventory17");
			if (strText != "")
				this.ckAspirated.Text = strText;
            strText = table.GetForm("FormConsonantInventory18");
			if (strText != "")
				this.ckLong.Text = strText;
            strText = table.GetForm("FormConsonantInventory19");
			if (strText != "")
				this.ckGlottalized.Text = strText;
            strText = table.GetForm("FormConsonantInventory20");
			if (strText != "")
				this.btnPrev.Text = strText;
            strText = table.GetForm("FormConsonantInventory21");
			if (strText != "")
				this.btnNext.Text = strText;
            strText = table.GetForm("FormConsonantInventory22");
			if (strText != "")
				this.btnAdd.Text = strText;
            strText = table.GetForm("FormConsonantInventory23");
			if (strText != "")
				this.btnDel.Text = strText;
            strText = table.GetForm("FormConsonantInventory25");
			if (strText != "")
				this.btnFind.Text = strText;
            strText = table.GetForm("FormConsonantInventory26");
			if (strText != "")
				this.btnSav.Text = strText;
            strText = table.GetForm("FormConsonantInventory27");
			if (strText != "")
				this.btnExit.Text = strText;
            return;
        }
    }
}

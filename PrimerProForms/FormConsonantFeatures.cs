using System;
using System.ComponentModel;
using System.Windows.Forms;
using PrimerProObjects;
using PrimerProLocalization;

namespace PrimerProForms
{
	/// <summary>
	/// Summary description for FormConsonantInventory.
	/// </summary>
	public class FormConsonantFeatures : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox gbPoint;
		private System.Windows.Forms.GroupBox gbManner;
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
		private System.Windows.Forms.RadioButton rbNotPOA;
		private System.Windows.Forms.RadioButton rbPlosive;
		private System.Windows.Forms.RadioButton rbNasal;
		private System.Windows.Forms.RadioButton rbTrill;
		private System.Windows.Forms.RadioButton rbFlap;
		private System.Windows.Forms.RadioButton rbFricative;
		private System.Windows.Forms.RadioButton rbAffricate;
		private System.Windows.Forms.RadioButton rbLateralFric;
		private System.Windows.Forms.RadioButton rbLateralAppr;
		private System.Windows.Forms.RadioButton rbApproximant;
		private System.Windows.Forms.RadioButton rbImplosive;
		private System.Windows.Forms.RadioButton rbEjective;
		private System.Windows.Forms.RadioButton rbClick;
		private System.Windows.Forms.RadioButton rbNotMOA;
		private System.Windows.Forms.GroupBox gbVoicing;
		private System.Windows.Forms.CheckBox ckVoiced;
		private System.Windows.Forms.CheckBox ckVoiceless;
		private System.Windows.Forms.GroupBox gbMod;
		private System.Windows.Forms.CheckBox ckPrenasalized;
		private System.Windows.Forms.CheckBox ckLabialized;
		private System.Windows.Forms.CheckBox ckPalatalized;
		private System.Windows.Forms.CheckBox ckVelarized;
		private System.Windows.Forms.CheckBox ckSyllabic;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.ComponentModel.Container components = null;
        private CheckBox ckAspirated;
        private CheckBox ckLong;
        private CheckBox ckGlottalized;
        private CheckBox ckCombination;

		private ConsonantFeatures m_Features;

		public FormConsonantFeatures(ConsonantFeatures cf)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m_Features = cf;

		}

        public FormConsonantFeatures(ConsonantFeatures cf, LocalizationTable table, string lang)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            m_Features = cf;

            this.Text = table.GetForm("FormConsonantFeaturesT", lang);
            this.gbPoint.Text = table.GetForm("FormConsonantFeatures0", lang);
            this.rbBilabial.Text = table.GetForm("FormConsonantFeaturesP0", lang);
            this.rbLabiodental.Text = table.GetForm("FormConsonantFeaturesP1", lang);
            this.rbDental.Text = table.GetForm("FormConsonantFeaturesP2", lang);
            this.rbAlveolar.Text = table.GetForm("FormConsonantFeaturesP3", lang);
            this.rbPostalveolar.Text = table.GetForm("FormConsonantFeaturesP4", lang);
            this.rbRetroflex.Text = table.GetForm("FormConsonantFeaturesP5", lang);
            this.rbPalatal.Text = table.GetForm("FormConsonantFeaturesP6", lang);
            this.rbVelar.Text = table.GetForm("FormConsonantFeaturesP7", lang);
            this.rbLabialvelar.Text = table.GetForm("FormConsonantFeaturesP8", lang);
            this.rbUvular.Text = table.GetForm("FormConsonantFeaturesP9", lang);
            this.rbPharyngeal.Text = table.GetForm("FormConsonantFeaturesP10", lang);
            this.rbGlottal.Text = table.GetForm("FormConsonantFeaturesP11", lang);
            this.rbNotPOA.Text = table.GetForm("FormConsonantFeaturesP12", lang);
            this.gbManner.Text = table.GetForm("FormConsonantFeatures1", lang);
            this.rbPlosive.Text = table.GetForm("FormConsonantFeaturesM0", lang);
            this.rbNasal.Text = table.GetForm("FormConsonantFeaturesM1", lang);
            this.rbTrill.Text = table.GetForm("FormConsonantFeaturesM2", lang);
            this.rbFlap.Text = table.GetForm("FormConsonantFeaturesM3", lang);
            this.rbFricative.Text = table.GetForm("FormConsonantFeaturesM4", lang);
            this.rbAffricate.Text = table.GetForm("FormConsonantFeaturesM5", lang);
            this.rbLateralFric.Text = table.GetForm("FormConsonantFeaturesM6", lang);
            this.rbLateralAppr.Text = table.GetForm("FormConsonantFeaturesM7", lang);
            this.rbApproximant.Text = table.GetForm("FormConsonantFeaturesM8", lang);
            this.rbImplosive.Text = table.GetForm("FormConsonantFeaturesM9", lang);
            this.rbEjective.Text = table.GetForm("FormConsonantFeaturesM10", lang);
            this.rbClick.Text = table.GetForm("FormConsonantFeaturesM11", lang);
            this.rbNotMOA.Text = table.GetForm("FormConsonantFeaturesM12", lang);
            this.gbVoicing.Text = table.GetForm("FormConsonantFeatures2", lang);
            this.ckVoiced.Text = table.GetForm("FormConsonantFeaturesV0", lang);
            this.ckVoiceless.Text = table.GetForm("FormConsonantFeaturesV1", lang);
            this.gbMod.Text = table.GetForm("FormConsonantFeatures3", lang);
            this.ckPrenasalized.Text = table.GetForm("FormConsonantFeaturesC0", lang);
            this.ckLabialized.Text = table.GetForm("FormConsonantFeaturesC1", lang);
            this.ckPalatalized.Text = table.GetForm("FormConsonantFeaturesC2", lang);
            this.ckVelarized.Text = table.GetForm("FormConsonantFeaturesC3", lang);
            this.ckSyllabic.Text = table.GetForm("FormConsonantFeaturesC4", lang);
            this.ckAspirated.Text = table.GetForm("FormConsonantFeaturesC5", lang);
            this.ckLong.Text = table.GetForm("FormConsonantFeaturesC6", lang);
            this.ckGlottalized.Text = table.GetForm("FormConsonantFeaturesC7", lang);
            this.ckCombination.Text = table.GetForm("FormConsonantFeatures4", lang);
            this.btnOK.Text = table.GetForm("FormConsonantFeatures5", lang);
            this.btnCancel.Text = table.GetForm("FormConsonantFeatures6", lang);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConsonantFeatures));
            this.ckVoiced = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
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
            this.ckPrenasalized = new System.Windows.Forms.CheckBox();
            this.ckLabialized = new System.Windows.Forms.CheckBox();
            this.ckPalatalized = new System.Windows.Forms.CheckBox();
            this.ckVelarized = new System.Windows.Forms.CheckBox();
            this.ckSyllabic = new System.Windows.Forms.CheckBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.gbVoicing = new System.Windows.Forms.GroupBox();
            this.ckVoiceless = new System.Windows.Forms.CheckBox();
            this.gbMod = new System.Windows.Forms.GroupBox();
            this.ckGlottalized = new System.Windows.Forms.CheckBox();
            this.ckLong = new System.Windows.Forms.CheckBox();
            this.ckAspirated = new System.Windows.Forms.CheckBox();
            this.ckCombination = new System.Windows.Forms.CheckBox();
            this.gbPoint.SuspendLayout();
            this.gbManner.SuspendLayout();
            this.gbVoicing.SuspendLayout();
            this.gbMod.SuspendLayout();
            this.SuspendLayout();
            // 
            // ckVoiced
            // 
            this.ckVoiced.Location = new System.Drawing.Point(7, 20);
            this.ckVoiced.Name = "ckVoiced";
            this.ckVoiced.Size = new System.Drawing.Size(103, 20);
            this.ckVoiced.TabIndex = 0;
            this.ckVoiced.Text = "Voiced";
            this.ckVoiced.CheckedChanged += new System.EventHandler(this.ckVoiced_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(243, 315);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(86, 27);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(350, 315);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 27);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.gbPoint.Location = new System.Drawing.Point(21, 13);
            this.gbPoint.Name = "gbPoint";
            this.gbPoint.Size = new System.Drawing.Size(137, 290);
            this.gbPoint.TabIndex = 0;
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
            this.gbManner.Location = new System.Drawing.Point(178, 13);
            this.gbManner.Name = "gbManner";
            this.gbManner.Size = new System.Drawing.Size(151, 290);
            this.gbManner.TabIndex = 1;
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
            this.rbPlosive.Size = new System.Drawing.Size(103, 20);
            this.rbPlosive.TabIndex = 0;
            this.rbPlosive.Text = "Plosive";
            // 
            // ckPrenasalized
            // 
            this.ckPrenasalized.Location = new System.Drawing.Point(7, 26);
            this.ckPrenasalized.Name = "ckPrenasalized";
            this.ckPrenasalized.Size = new System.Drawing.Size(103, 20);
            this.ckPrenasalized.TabIndex = 0;
            this.ckPrenasalized.Text = "Prenasalized";
            // 
            // ckLabialized
            // 
            this.ckLabialized.Location = new System.Drawing.Point(7, 46);
            this.ckLabialized.Name = "ckLabialized";
            this.ckLabialized.Size = new System.Drawing.Size(103, 20);
            this.ckLabialized.TabIndex = 1;
            this.ckLabialized.Text = "Labialized";
            // 
            // ckPalatalized
            // 
            this.ckPalatalized.Location = new System.Drawing.Point(7, 66);
            this.ckPalatalized.Name = "ckPalatalized";
            this.ckPalatalized.Size = new System.Drawing.Size(103, 20);
            this.ckPalatalized.TabIndex = 2;
            this.ckPalatalized.Text = "Palatalized";
            // 
            // ckVelarized
            // 
            this.ckVelarized.Location = new System.Drawing.Point(7, 86);
            this.ckVelarized.Name = "ckVelarized";
            this.ckVelarized.Size = new System.Drawing.Size(103, 19);
            this.ckVelarized.TabIndex = 3;
            this.ckVelarized.Text = "Velarized";
            // 
            // ckSyllabic
            // 
            this.ckSyllabic.Location = new System.Drawing.Point(7, 105);
            this.ckSyllabic.Name = "ckSyllabic";
            this.ckSyllabic.Size = new System.Drawing.Size(103, 20);
            this.ckSyllabic.TabIndex = 4;
            this.ckSyllabic.Text = "Syllabic";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 372);
            this.splitter1.TabIndex = 11;
            this.splitter1.TabStop = false;
            // 
            // gbVoicing
            // 
            this.gbVoicing.Controls.Add(this.ckVoiceless);
            this.gbVoicing.Controls.Add(this.ckVoiced);
            this.gbVoicing.Location = new System.Drawing.Point(350, 13);
            this.gbVoicing.Name = "gbVoicing";
            this.gbVoicing.Size = new System.Drawing.Size(120, 66);
            this.gbVoicing.TabIndex = 2;
            this.gbVoicing.TabStop = false;
            this.gbVoicing.Text = "Voicing";
            // 
            // ckVoiceless
            // 
            this.ckVoiceless.Location = new System.Drawing.Point(7, 40);
            this.ckVoiceless.Name = "ckVoiceless";
            this.ckVoiceless.Size = new System.Drawing.Size(103, 20);
            this.ckVoiceless.TabIndex = 1;
            this.ckVoiceless.Text = "Voiceless";
            this.ckVoiceless.CheckedChanged += new System.EventHandler(this.ckVoiceless_CheckedChanged);
            // 
            // gbMod
            // 
            this.gbMod.Controls.Add(this.ckGlottalized);
            this.gbMod.Controls.Add(this.ckLong);
            this.gbMod.Controls.Add(this.ckAspirated);
            this.gbMod.Controls.Add(this.ckPrenasalized);
            this.gbMod.Controls.Add(this.ckLabialized);
            this.gbMod.Controls.Add(this.ckPalatalized);
            this.gbMod.Controls.Add(this.ckVelarized);
            this.gbMod.Controls.Add(this.ckSyllabic);
            this.gbMod.Location = new System.Drawing.Point(350, 91);
            this.gbMod.Name = "gbMod";
            this.gbMod.Size = new System.Drawing.Size(120, 188);
            this.gbMod.TabIndex = 3;
            this.gbMod.TabStop = false;
            this.gbMod.Text = "Modifications";
            // 
            // ckGlottalized
            // 
            this.ckGlottalized.AutoSize = true;
            this.ckGlottalized.Location = new System.Drawing.Point(7, 165);
            this.ckGlottalized.Name = "ckGlottalized";
            this.ckGlottalized.Size = new System.Drawing.Size(84, 19);
            this.ckGlottalized.TabIndex = 7;
            this.ckGlottalized.Text = "Glottalized";
            this.ckGlottalized.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.ckGlottalized.UseVisualStyleBackColor = true;
            // 
            // ckLong
            // 
            this.ckLong.AutoSize = true;
            this.ckLong.Location = new System.Drawing.Point(7, 145);
            this.ckLong.Name = "ckLong";
            this.ckLong.Size = new System.Drawing.Size(54, 19);
            this.ckLong.TabIndex = 6;
            this.ckLong.Text = "Long";
            this.ckLong.UseVisualStyleBackColor = true;
            // 
            // ckAspirated
            // 
            this.ckAspirated.AutoSize = true;
            this.ckAspirated.Location = new System.Drawing.Point(7, 125);
            this.ckAspirated.Name = "ckAspirated";
            this.ckAspirated.Size = new System.Drawing.Size(77, 19);
            this.ckAspirated.TabIndex = 5;
            this.ckAspirated.Text = "Aspirated";
            this.ckAspirated.UseVisualStyleBackColor = true;
            // 
            // ckCombination
            // 
            this.ckCombination.AutoSize = true;
            this.ckCombination.Location = new System.Drawing.Point(34, 308);
            this.ckCombination.Name = "ckCombination";
            this.ckCombination.Size = new System.Drawing.Size(96, 19);
            this.ckCombination.TabIndex = 4;
            this.ckCombination.Text = "Combination";
            this.ckCombination.UseVisualStyleBackColor = true;
            // 
            // FormConsonantFeatures
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(526, 372);
            this.Controls.Add(this.ckCombination);
            this.Controls.Add(this.gbMod);
            this.Controls.Add(this.gbVoicing);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.gbManner);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbPoint);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormConsonantFeatures";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set Consonant Features";
            this.gbPoint.ResumeLayout(false);
            this.gbManner.ResumeLayout(false);
            this.gbVoicing.ResumeLayout(false);
            this.gbMod.ResumeLayout(false);
            this.gbMod.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        public ConsonantFeatures Features
        {
            get { return m_Features; }
        }

        private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (rbBilabial.Checked)
				m_Features.PointOfArticulation = ConsonantFeatures.kBilabial;
			if (rbLabiodental.Checked)
				m_Features.PointOfArticulation = ConsonantFeatures.kLabiodental;
			if (rbDental.Checked)
				m_Features.PointOfArticulation = ConsonantFeatures.kDental;
			if (rbAlveolar.Checked)
				m_Features.PointOfArticulation = ConsonantFeatures.kAlveolar;
			if (rbPostalveolar.Checked)
				m_Features.PointOfArticulation = ConsonantFeatures.kPostalveolar;
			if (rbRetroflex.Checked)
				m_Features.PointOfArticulation = ConsonantFeatures.kRetroflex;
			if (rbPalatal.Checked)
				m_Features.PointOfArticulation = ConsonantFeatures.kPalatal;
			if (rbVelar.Checked)
				m_Features.PointOfArticulation = ConsonantFeatures.kVelar;
			if (rbLabialvelar.Checked)
				m_Features.PointOfArticulation = ConsonantFeatures.kLabialvelar;
			if (rbUvular.Checked)
				m_Features.PointOfArticulation = ConsonantFeatures.kUvular;
			if (rbPharyngeal.Checked)
				m_Features.PointOfArticulation = ConsonantFeatures.kPharyngeal;
			if (rbGlottal.Checked)
				m_Features.PointOfArticulation = ConsonantFeatures.kGlottal;
			if (rbNotPOA.Checked)
				m_Features.PointOfArticulation = ConsonantFeatures.kNoPA;

			if (rbPlosive.Checked)
				m_Features.MannerOfArticulation = ConsonantFeatures.kPlosive;
			if (rbNasal.Checked)
				m_Features.MannerOfArticulation = ConsonantFeatures.kNasal;
			if (rbTrill.Checked)
				m_Features.MannerOfArticulation = ConsonantFeatures.kTrill;
			if (rbFlap.Checked)
				m_Features.MannerOfArticulation = ConsonantFeatures.kFlap;
			if (rbFricative.Checked)
				m_Features.MannerOfArticulation = ConsonantFeatures.kFricative;
			if (rbAffricate.Checked)
				m_Features.MannerOfArticulation = ConsonantFeatures.kAffricate;
			if (rbLateralFric.Checked)
				m_Features.MannerOfArticulation = ConsonantFeatures.kLateralFricative;
			if (rbLateralAppr.Checked)
				m_Features.MannerOfArticulation = ConsonantFeatures.kLateralApproximant;
			if (rbApproximant.Checked)
				m_Features.MannerOfArticulation = ConsonantFeatures.kApproximant;
			if (rbImplosive.Checked)
				m_Features.MannerOfArticulation = ConsonantFeatures.kImplosive;
			if (rbEjective.Checked)
				m_Features.MannerOfArticulation = ConsonantFeatures.kEjective;
			if (rbClick.Checked)
				m_Features.MannerOfArticulation = ConsonantFeatures.kClick;
			if(rbNotMOA.Checked)
				m_Features.MannerOfArticulation = ConsonantFeatures.kNoMA;
			
			m_Features.Voiced = ckVoiced.Checked;
			m_Features.Voiceless = ckVoiceless.Checked;
			m_Features.Prenasalized = ckPrenasalized.Checked;
			m_Features.Labialized = ckLabialized.Checked;
			m_Features.Palatalized = ckPalatalized.Checked;
			m_Features.Velarized = ckVelarized.Checked;
			m_Features.Syllabic = ckSyllabic.Checked;
            m_Features.Aspirated = ckAspirated.Checked;
            m_Features.Long = ckLong.Checked;
            m_Features.Glottalized = ckGlottalized.Checked;
            m_Features.Combination = ckCombination.Checked;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			m_Features = null;
			this.Close();		
		}

        private void ckVoiced_CheckedChanged(object sender, EventArgs e)
        {
//          ckVoiced.Checked = true;
            ckVoiceless.Checked = false;
        }

        private void ckVoiceless_CheckedChanged(object sender, EventArgs e)
        {
//          ckVoiceless.Checked = true;
            ckVoiced.Checked = false;
        }

	}
}

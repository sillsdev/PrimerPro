using System;
using System.ComponentModel;
using System.Windows.Forms;
using PrimerProObjects;
using PrimerProLocalization;
using GenLib;

namespace PrimerProForms
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FormContextChart : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox gbCV;
		private System.Windows.Forms.RadioButton rbC;
		private System.Windows.Forms.RadioButton rbV;
		private System.Windows.Forms.Button btnSearchOptions;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.GroupBox gbContexts;
		private System.Windows.Forms.CheckBox chkInRoots;
		private System.Windows.Forms.CheckBox chkOpenSyll;
		private System.Windows.Forms.CheckBox chkWordFinal;
		private System.Windows.Forms.CheckBox chkFinalSyll;
		private System.Windows.Forms.CheckBox chkSecondRootC;
		private System.Windows.Forms.CheckBox chkFirstRootC;
		private System.Windows.Forms.CheckBox chkFirstRootV;
		private System.Windows.Forms.CheckBox chkClosedSyll;
		private System.Windows.Forms.CheckBox chkSecondRootV;
		private System.Windows.Forms.Button btnFeatures;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.CheckBox chkMedialSyll;
		private System.Windows.Forms.CheckBox chkInitSyll;
		private System.Windows.Forms.CheckBox chkWordInit;
		private System.Windows.Forms.CheckBox chkWordMedial;

        private ConsonantFeatures m_CFeatures;
        private VowelFeatures  m_VFeatures;
        private bool m_WordInit;
		private bool m_WordMedial;
		private bool m_WordFinal;
        private bool m_SyllableInit;
        private bool m_SyllableMedial;
        private bool m_SyllableFinal;
		private bool m_InitSyllable;
		private bool m_MedialSyllable;
		private bool m_FinalSyllable;
		private bool m_InRoots;
		private bool m_OpenSyllables;
		private bool m_ClosedSyllables;
		private bool m_FirstRootC;
		private bool m_SecondRootC;
		private bool m_FirstRootV;
		private bool m_SecondRootV;
        private PSTable m_PSTable;
        private LocalizationTable m_Table;          //Localization table
        private string m_Lang;
        private CheckBox chkSyllFinal;
        private CheckBox chkSyllMedial;
        private CheckBox chkSyllInit;                      //UI language
        private SearchOptions m_SearchOptions;

		public FormContextChart(PSTable pstable)
		{
			InitializeComponent();
            m_PSTable = pstable;
            m_Table = null;
            m_Lang = "";
			rbC.Checked = true;
		}

        public FormContextChart(PSTable pstable, LocalizationTable table, string lang)
        {
            InitializeComponent();
            m_PSTable = pstable;
            m_Table = table;
            m_Lang = lang;
            rbC.Checked = true;
            this.UpdateFormForLocalization(table);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormContextChart));
            this.gbCV = new System.Windows.Forms.GroupBox();
            this.btnFeatures = new System.Windows.Forms.Button();
            this.rbV = new System.Windows.Forms.RadioButton();
            this.rbC = new System.Windows.Forms.RadioButton();
            this.btnSearchOptions = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbContexts = new System.Windows.Forms.GroupBox();
            this.chkSyllFinal = new System.Windows.Forms.CheckBox();
            this.chkSyllMedial = new System.Windows.Forms.CheckBox();
            this.chkSyllInit = new System.Windows.Forms.CheckBox();
            this.chkSecondRootV = new System.Windows.Forms.CheckBox();
            this.chkClosedSyll = new System.Windows.Forms.CheckBox();
            this.chkFirstRootV = new System.Windows.Forms.CheckBox();
            this.chkFirstRootC = new System.Windows.Forms.CheckBox();
            this.chkSecondRootC = new System.Windows.Forms.CheckBox();
            this.chkFinalSyll = new System.Windows.Forms.CheckBox();
            this.chkMedialSyll = new System.Windows.Forms.CheckBox();
            this.chkWordFinal = new System.Windows.Forms.CheckBox();
            this.chkWordMedial = new System.Windows.Forms.CheckBox();
            this.chkOpenSyll = new System.Windows.Forms.CheckBox();
            this.chkInRoots = new System.Windows.Forms.CheckBox();
            this.chkInitSyll = new System.Windows.Forms.CheckBox();
            this.chkWordInit = new System.Windows.Forms.CheckBox();
            this.gbCV.SuspendLayout();
            this.gbContexts.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCV
            // 
            this.gbCV.Controls.Add(this.btnFeatures);
            this.gbCV.Controls.Add(this.rbV);
            this.gbCV.Controls.Add(this.rbC);
            this.gbCV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCV.Location = new System.Drawing.Point(20, 21);
            this.gbCV.Name = "gbCV";
            this.gbCV.Size = new System.Drawing.Size(265, 86);
            this.gbCV.TabIndex = 0;
            this.gbCV.TabStop = false;
            this.gbCV.Text = "Specify as C or V";
            // 
            // btnFeatures
            // 
            this.btnFeatures.Location = new System.Drawing.Point(80, 35);
            this.btnFeatures.Name = "btnFeatures";
            this.btnFeatures.Size = new System.Drawing.Size(167, 27);
            this.btnFeatures.TabIndex = 2;
            this.btnFeatures.Text = "Choose &features";
            this.btnFeatures.Click += new System.EventHandler(this.btnFeatures_Click);
            // 
            // rbV
            // 
            this.rbV.Location = new System.Drawing.Point(20, 49);
            this.rbV.Name = "rbV";
            this.rbV.Size = new System.Drawing.Size(33, 20);
            this.rbV.TabIndex = 1;
            this.rbV.Text = "&V";
            this.rbV.CheckedChanged += new System.EventHandler(this.rbV_CheckedChanged);
            // 
            // rbC
            // 
            this.rbC.Location = new System.Drawing.Point(20, 21);
            this.rbC.Name = "rbC";
            this.rbC.Size = new System.Drawing.Size(33, 21);
            this.rbC.TabIndex = 0;
            this.rbC.Text = "&C";
            this.rbC.CheckedChanged += new System.EventHandler(this.rbC_CheckedChanged);
            // 
            // btnSearchOptions
            // 
            this.btnSearchOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchOptions.Location = new System.Drawing.Point(339, 55);
            this.btnSearchOptions.Name = "btnSearchOptions";
            this.btnSearchOptions.Size = new System.Drawing.Size(167, 28);
            this.btnSearchOptions.TabIndex = 1;
            this.btnSearchOptions.Text = "&Search Options";
            this.btnSearchOptions.Click += new System.EventHandler(this.btnSearchOptions_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(339, 347);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(83, 27);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(457, 347);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 27);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gbContexts
            // 
            this.gbContexts.Controls.Add(this.chkSyllFinal);
            this.gbContexts.Controls.Add(this.chkSyllMedial);
            this.gbContexts.Controls.Add(this.chkSyllInit);
            this.gbContexts.Controls.Add(this.chkSecondRootV);
            this.gbContexts.Controls.Add(this.chkClosedSyll);
            this.gbContexts.Controls.Add(this.chkFirstRootV);
            this.gbContexts.Controls.Add(this.chkFirstRootC);
            this.gbContexts.Controls.Add(this.chkSecondRootC);
            this.gbContexts.Controls.Add(this.chkFinalSyll);
            this.gbContexts.Controls.Add(this.chkMedialSyll);
            this.gbContexts.Controls.Add(this.chkWordFinal);
            this.gbContexts.Controls.Add(this.chkWordMedial);
            this.gbContexts.Controls.Add(this.chkOpenSyll);
            this.gbContexts.Controls.Add(this.chkInRoots);
            this.gbContexts.Controls.Add(this.chkInitSyll);
            this.gbContexts.Controls.Add(this.chkWordInit);
            this.gbContexts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbContexts.Location = new System.Drawing.Point(20, 132);
            this.gbContexts.Name = "gbContexts";
            this.gbContexts.Size = new System.Drawing.Size(644, 200);
            this.gbContexts.TabIndex = 2;
            this.gbContexts.TabStop = false;
            this.gbContexts.Text = "Choose contexts to include as columns (maximun of six)";
            // 
            // chkSyllFinal
            // 
            this.chkSyllFinal.Location = new System.Drawing.Point(400, 55);
            this.chkSyllFinal.Name = "chkSyllFinal";
            this.chkSyllFinal.Size = new System.Drawing.Size(167, 21);
            this.chkSyllFinal.TabIndex = 5;
            this.chkSyllFinal.Text = "Syllable-final";
            // 
            // chkSyllMedial
            // 
            this.chkSyllMedial.Location = new System.Drawing.Point(196, 55);
            this.chkSyllMedial.Name = "chkSyllMedial";
            this.chkSyllMedial.Size = new System.Drawing.Size(167, 21);
            this.chkSyllMedial.TabIndex = 4;
            this.chkSyllMedial.Text = "Syllable-medial";
            // 
            // chkSyllInit
            // 
            this.chkSyllInit.Location = new System.Drawing.Point(13, 55);
            this.chkSyllInit.Name = "chkSyllInit";
            this.chkSyllInit.Size = new System.Drawing.Size(167, 21);
            this.chkSyllInit.TabIndex = 3;
            this.chkSyllInit.Text = "Syllable-initial";
            // 
            // chkSecondRootV
            // 
            this.chkSecondRootV.Location = new System.Drawing.Point(196, 166);
            this.chkSecondRootV.Name = "chkSecondRootV";
            this.chkSecondRootV.Size = new System.Drawing.Size(167, 21);
            this.chkSecondRootV.TabIndex = 15;
            this.chkSecondRootV.Text = "Second root V";
            // 
            // chkClosedSyll
            // 
            this.chkClosedSyll.Location = new System.Drawing.Point(400, 111);
            this.chkClosedSyll.Name = "chkClosedSyll";
            this.chkClosedSyll.Size = new System.Drawing.Size(216, 21);
            this.chkClosedSyll.TabIndex = 11;
            this.chkClosedSyll.Text = "In closed syllables";
            // 
            // chkFirstRootV
            // 
            this.chkFirstRootV.Location = new System.Drawing.Point(13, 166);
            this.chkFirstRootV.Name = "chkFirstRootV";
            this.chkFirstRootV.Size = new System.Drawing.Size(167, 21);
            this.chkFirstRootV.TabIndex = 14;
            this.chkFirstRootV.Text = "First root V";
            // 
            // chkFirstRootC
            // 
            this.chkFirstRootC.Location = new System.Drawing.Point(13, 139);
            this.chkFirstRootC.Name = "chkFirstRootC";
            this.chkFirstRootC.Size = new System.Drawing.Size(167, 20);
            this.chkFirstRootC.TabIndex = 12;
            this.chkFirstRootC.Text = "First root C";
            // 
            // chkSecondRootC
            // 
            this.chkSecondRootC.Location = new System.Drawing.Point(196, 139);
            this.chkSecondRootC.Name = "chkSecondRootC";
            this.chkSecondRootC.Size = new System.Drawing.Size(167, 20);
            this.chkSecondRootC.TabIndex = 13;
            this.chkSecondRootC.Text = "Second root C";
            // 
            // chkFinalSyll
            // 
            this.chkFinalSyll.Location = new System.Drawing.Point(400, 83);
            this.chkFinalSyll.Name = "chkFinalSyll";
            this.chkFinalSyll.Size = new System.Drawing.Size(167, 21);
            this.chkFinalSyll.TabIndex = 8;
            this.chkFinalSyll.Text = "Final syllable";
            // 
            // chkMedialSyll
            // 
            this.chkMedialSyll.Location = new System.Drawing.Point(196, 83);
            this.chkMedialSyll.Name = "chkMedialSyll";
            this.chkMedialSyll.Size = new System.Drawing.Size(167, 21);
            this.chkMedialSyll.TabIndex = 7;
            this.chkMedialSyll.Text = "Medial syllable";
            // 
            // chkWordFinal
            // 
            this.chkWordFinal.Location = new System.Drawing.Point(401, 28);
            this.chkWordFinal.Name = "chkWordFinal";
            this.chkWordFinal.Size = new System.Drawing.Size(167, 21);
            this.chkWordFinal.TabIndex = 2;
            this.chkWordFinal.Text = "Word-final";
            // 
            // chkWordMedial
            // 
            this.chkWordMedial.Location = new System.Drawing.Point(196, 28);
            this.chkWordMedial.Name = "chkWordMedial";
            this.chkWordMedial.Size = new System.Drawing.Size(167, 21);
            this.chkWordMedial.TabIndex = 1;
            this.chkWordMedial.Text = "Word-medial";
            // 
            // chkOpenSyll
            // 
            this.chkOpenSyll.Location = new System.Drawing.Point(196, 111);
            this.chkOpenSyll.Name = "chkOpenSyll";
            this.chkOpenSyll.Size = new System.Drawing.Size(198, 21);
            this.chkOpenSyll.TabIndex = 10;
            this.chkOpenSyll.Text = "In open syllables";
            // 
            // chkInRoots
            // 
            this.chkInRoots.Location = new System.Drawing.Point(13, 111);
            this.chkInRoots.Name = "chkInRoots";
            this.chkInRoots.Size = new System.Drawing.Size(167, 21);
            this.chkInRoots.TabIndex = 9;
            this.chkInRoots.Text = "In roots";
            // 
            // chkInitSyll
            // 
            this.chkInitSyll.Location = new System.Drawing.Point(13, 83);
            this.chkInitSyll.Name = "chkInitSyll";
            this.chkInitSyll.Size = new System.Drawing.Size(167, 21);
            this.chkInitSyll.TabIndex = 6;
            this.chkInitSyll.Text = "Initial syllable";
            // 
            // chkWordInit
            // 
            this.chkWordInit.Location = new System.Drawing.Point(13, 28);
            this.chkWordInit.Name = "chkWordInit";
            this.chkWordInit.Size = new System.Drawing.Size(167, 21);
            this.chkWordInit.TabIndex = 0;
            this.chkWordInit.Text = "Word-initial";
            // 
            // FormContextChart
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(708, 397);
            this.Controls.Add(this.gbContexts);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnSearchOptions);
            this.Controls.Add(this.gbCV);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormContextChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Context Occurrence Chart Search";
            this.gbCV.ResumeLayout(false);
            this.gbContexts.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        public ConsonantFeatures CnsFeatures
        {
            get { return m_CFeatures; }
        }

        public VowelFeatures VwlFeatures
        {
            get { return m_VFeatures; }
        }

        public bool WordInit
        {
            get { return m_WordInit; }
        }

        public bool WordMedial
        {
            get { return m_WordMedial; }
        }

        public bool WordFinal
        {
            get { return m_WordFinal; }
        }

        public bool SyllableInit
        {
            get { return m_SyllableInit; }
        }

        public bool SyllableMedial
        {
            get { return m_SyllableMedial; }
        }

        public bool SyllableFinal
        {
            get { return m_SyllableFinal; }
        }

        public bool InitSyllable
        {
            get { return m_InitSyllable; }
        }

        public bool MedialSyllable
        {
            get { return m_MedialSyllable;}
        }

        public bool FinalSyllable
        {
            get { return m_FinalSyllable;}
        }

        public bool InRoots
        {
            get { return m_InRoots;}
        }

        public bool OpenSyllables
        {
            get { return m_OpenSyllables;}
        }

        public bool ClosedSyllables
        {
            get { return m_ClosedSyllables;}
        }

        public bool FirstRootC
        {
            get { return m_FirstRootC;}
        }

        public bool SecondRootC
        {
            get { return m_SecondRootC;}
        }

        public bool FirstRootV
        {
            get { return m_FirstRootV;}
        }

        public bool SecondRootV
        {
            get { return m_SecondRootV;}
        }

        public SearchOptions SearchOptions
        {
            get { return m_SearchOptions; }
        }
        
        private void btnOK_Click(object sender, System.EventArgs e)
		{
			if ( (m_CFeatures == null) && (m_VFeatures == null) )
				return;
			else
			{
				m_WordInit = chkWordInit.Checked;
				m_WordMedial = chkWordMedial.Checked;
				m_WordFinal = chkWordFinal.Checked;
                m_SyllableInit = chkSyllInit.Checked;
                m_SyllableMedial = chkSyllMedial.Checked;
                m_SyllableFinal = chkSyllFinal.Checked;
				m_InitSyllable = chkInitSyll.Checked;
				m_MedialSyllable = chkMedialSyll.Checked;
				m_FinalSyllable = chkFinalSyll.Checked;
				m_InRoots = chkInRoots.Checked;
				m_OpenSyllables = chkOpenSyll.Checked;
				m_ClosedSyllables = chkClosedSyll.Checked;
				m_FirstRootC = chkFirstRootC.Checked;
				m_SecondRootC = chkSecondRootC.Checked;
				m_FirstRootV = chkFirstRootV.Checked;
				m_SecondRootV = chkSecondRootV.Checked;
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Form.ActiveForm.Close();
		}

		private void btnSearchOptions_Click(object sender, System.EventArgs e)
		{
            SearchOptions so = new SearchOptions(m_PSTable);
            CodeTable ct = (CodeTable)m_PSTable;
            //FormSearchOptions form = new FormSearchOptions(ct, true, false);
            FormSearchOptions form = new FormSearchOptions(ct, true, false, m_Table);
            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                so.PS = form.PSTE;
                so.IsRootOnly = form.IsRootOnly;
                so.IsIdenticalVowelsInRoot = form.IsIdenticalVowelsInRoot;
                so.IsIdenticalVowelsInWord = form.IsIdenticalVowelsInWord;
                so.IsBrowseView = form.IsBrowseView;
                so.WordCVShape = form.WordCVShape;
                so.RootCVShape = form.RootCVShape;
                so.MinSyllables = form.MinSyllables;
                so.MaxSyllables = form.MaxSyllables;
                so.WordPosition = form.WordPosition;
                so.RootPosition = form.RootPosition;
                m_SearchOptions = so;
            }
        }

		private void rbC_CheckedChanged(object sender, System.EventArgs e)
		{
			ConsonantFeatures cf = new ConsonantFeatures();
			m_CFeatures = cf;
			m_VFeatures = null;
			btnFeatures.Enabled = true;
		}

		private void rbV_CheckedChanged(object sender, System.EventArgs e)
		{
			VowelFeatures vf = new VowelFeatures();
			m_VFeatures = vf;
			m_CFeatures = null;
			btnFeatures.Enabled = true;
		}
	
		private void btnFeatures_Click(object sender, System.EventArgs e)
		{
			if (rbC.Checked)
			{
				ConsonantFeatures cf = new ConsonantFeatures();
                //FormConsonantFeatures form = new FormConsonantFeatures(cf);
                FormConsonantFeatures form = new FormConsonantFeatures(cf, m_Table);
				if (form.ShowDialog() == DialogResult.OK)
					m_CFeatures = cf;
			}

			if (rbV.Checked)
			{
				VowelFeatures vf = new VowelFeatures();
                //FormVowelFeatures form = new FormVowelFeatures(vf);
                FormVowelFeatures form = new FormVowelFeatures(vf, m_Table);
                if (form.ShowDialog() == DialogResult.OK)
					m_VFeatures = vf;
			}
		}

        private void UpdateFormForLocalization(LocalizationTable table)
        {
            string strText = "";
            strText = table.GetForm("FormContextChartT");
			if (strText != "")
				this.Text = strText;
            strText = table.GetForm("FormContextChart0");
			if (strText != "")
				this.gbCV.Text = strText;
            strText = table.GetForm("FormContextChartS0");
			if (strText != "")
				this.rbC.Text = strText;
            strText = table.GetForm("FormContextChartS1");
			if (strText != "")
				this.rbV.Text = strText;
            strText = table.GetForm("FormContextChartS2");
			if (strText != "")
				this.btnFeatures.Text = strText;
            strText = table.GetForm("FormContextChart1");
			if (strText != "")
				this.btnSearchOptions.Text = strText;
            strText = table.GetForm("FormContextChart2");
			if (strText != "")
				this.gbContexts.Text = strText;
            strText = table.GetForm("FormContextChartC0");
			if (strText != "")
				this.chkWordInit.Text = strText;
            strText = table.GetForm("FormContextChartC1");
			if (strText != "")
				this.chkWordMedial.Text = strText;
            strText = table.GetForm("FormContextChartC2");
			if (strText != "")
				this.chkWordFinal.Text = strText;
            strText = table.GetForm("FormContextChartC3");
			if (strText != "")
				this.chkInitSyll.Text = strText;
            strText = table.GetForm("FormContextChartC4");
			if (strText != "")
				this.chkMedialSyll.Text = strText;
            strText = table.GetForm("FormContextChartC5");
			if (strText != "")
				this.chkFinalSyll.Text = strText;
            strText = table.GetForm("FormContextChartC6");
			if (strText != "")
				this.chkInRoots.Text = strText;
            strText = table.GetForm("FormContextChartC7");
			if (strText != "")
				this.chkOpenSyll.Text = strText;
            strText = table.GetForm("FormContextChartC8");
			if (strText != "")
				this.chkClosedSyll.Text = strText;
            strText = table.GetForm("FormContextChartC9");
			if (strText != "")
				this.chkFirstRootC.Text = strText;
            strText = table.GetForm("FormContextChartC10");
			if (strText != "")
				this.chkSecondRootC.Text = strText;
            strText = table.GetForm("FormContextChartC11");
			if (strText != "")
				this.chkFirstRootV.Text = strText;
            strText = table.GetForm("FormContextChartC12");
			if (strText != "")
				this.chkSecondRootV.Text = strText;
            strText = table.GetForm("FormContextChart3");
			if (strText != "")
				this.btnOK.Text = strText;
            strText = table.GetForm("FormContextChart4");
			if (strText != "")
				this.btnCancel.Text = strText;
            return;
        }
    }
}

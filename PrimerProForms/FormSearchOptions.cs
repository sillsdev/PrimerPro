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
	/// Summary description for FormSearchOptions.
	/// </summary>
	public class FormSearchOptions : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label labPS;
		private System.Windows.Forms.ComboBox cbPS;
		private System.Windows.Forms.CheckBox ckRootsOnly;
		private System.Windows.Forms.CheckBox ckVwlInRootSame;
		private System.Windows.Forms.CheckBox ckVwlSame;
		private System.Windows.Forms.Label labWordCV;
		private System.Windows.Forms.TextBox tbWordCV;
		private System.Windows.Forms.Label labRootCV;
		private System.Windows.Forms.TextBox tbRootCV;

		private System.Windows.Forms.GroupBox gbWordPosition;
		private System.Windows.Forms.RadioButton rbWordAny;
		private System.Windows.Forms.RadioButton rbWordInitial;
		private System.Windows.Forms.RadioButton rbWordMedial;
		private System.Windows.Forms.RadioButton rbWordFinal;
		private System.Windows.Forms.GroupBox gbRootPosition;
		private System.Windows.Forms.RadioButton rbRootAny;
		private System.Windows.Forms.RadioButton rbRootInitial;
		private System.Windows.Forms.RadioButton rbRootMedial;
		private System.Windows.Forms.RadioButton rbRootFinal;
        private CheckBox ckBrowseView;

        private bool m_IsRootOnly;
        private bool m_IsIdenticalVowelsInWord;
        private bool m_IsIdenticalVowelsInRoot;
        private bool m_IsBrowseView;
        private string m_WordCVShape;
        private string m_RootCVShape;
        private int m_MinSyllables;
        private int m_MaxSyllables;
        private SearchOptions.Position m_WordPosition;
        private SearchOptions.Position m_RootPosition;
        private CodeTableEntry m_PSTE;          //PSTable Entry
        private CodeTable m_PST;                //PSTable
        private bool m_MiniForm;
        private bool m_Browse;

        private NumericUpDown nudMinSyllables;
        private Label labMinSyllable;
        private Label labMaxSyllables;
        private NumericUpDown nudMaxSyllables;
        
        //public enum Position { Any, Initial, Medial, Final };

        public FormSearchOptions(CodeTable PST, bool fMiniForm, bool fBrowse)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            m_PST = PST;
			m_MiniForm = fMiniForm;
            m_Browse = fBrowse;
			InitializeCT();
			if (m_MiniForm)
			{
				this.ckRootsOnly.Enabled = false;
				this.rbRootFinal.Enabled = false;
				this.rbRootInitial.Enabled = false;
				this.rbRootMedial.Enabled = false;
				this.rbWordFinal.Enabled = false;
				this.rbWordInitial.Enabled = false;
				this.rbWordMedial.Enabled = false;
			}
            if (m_Browse)
            {
                this.ckBrowseView.Visible = true;
                this.ckBrowseView.Checked = false;
            }
		}

        public FormSearchOptions(CodeTable PST, bool fMiniForm, bool fBrowse,
            LocalizationTable table, string lang)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            m_PST = PST;
            m_MiniForm = fMiniForm;
            m_Browse = fBrowse;
            InitializeCT();
            if (m_MiniForm)
            {
                this.ckRootsOnly.Enabled = false;
                this.rbRootFinal.Enabled = false;
                this.rbRootInitial.Enabled = false;
                this.rbRootMedial.Enabled = false;
                this.rbWordFinal.Enabled = false;
                this.rbWordInitial.Enabled = false;
                this.rbWordMedial.Enabled = false;
            }
            if (m_Browse)
            {
                this.ckBrowseView.Visible = true;
                this.ckBrowseView.Checked = false;
            }

            this.Text = table.GetForm("FormSearchOptionsT", lang);
            this.labPS.Text = table.GetForm("FormSearchOptions0", lang);
            this.ckRootsOnly.Text = table.GetForm("FormSearchOptions2", lang);
            this.ckVwlSame.Text = table.GetForm("FormSearchOptions3", lang);
            this.ckVwlInRootSame.Text = table.GetForm("FormSearchOptions4", lang);
            this.labWordCV.Text = table.GetForm("FormSearchOptions5", lang);
            this.labRootCV.Text = table.GetForm("FormSearchOptions7", lang);
            this.ckBrowseView.Text = table.GetForm("FormSearchOptions9", lang);
            this.gbWordPosition.Text = table.GetForm("FormSearchOptions10", lang);
            this.rbWordAny.Text = table.GetForm("FormSearchOptionsW0", lang);
            this.rbWordInitial.Text = table.GetForm("FormSearchOptionsW1", lang);
            this.rbWordMedial.Text = table.GetForm("FormSearchOptionsW2", lang);
            this.rbWordFinal.Text = table.GetForm("FormSearchOptionsW3", lang);
            this.gbRootPosition.Text = table.GetForm("FormSearchOptions11", lang);
            this.rbRootAny.Text = table.GetForm("FormSearchOptionsR0", lang);
            this.rbRootInitial.Text = table.GetForm("FormSearchOptionsR1", lang);
            this.rbRootMedial.Text = table.GetForm("FormSearchOptionsR2", lang);
            this.rbRootFinal.Text = table.GetForm("FormSearchOptionsR3", lang);
            this.btnOK.Text = table.GetForm("FormSearchOptions12", lang);
            this.btnCancel.Text = table.GetForm("FormSearchOptions13", lang);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSearchOptions));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbPS = new System.Windows.Forms.ComboBox();
            this.labPS = new System.Windows.Forms.Label();
            this.ckRootsOnly = new System.Windows.Forms.CheckBox();
            this.ckVwlSame = new System.Windows.Forms.CheckBox();
            this.ckVwlInRootSame = new System.Windows.Forms.CheckBox();
            this.labWordCV = new System.Windows.Forms.Label();
            this.tbWordCV = new System.Windows.Forms.TextBox();
            this.labRootCV = new System.Windows.Forms.Label();
            this.tbRootCV = new System.Windows.Forms.TextBox();
            this.gbWordPosition = new System.Windows.Forms.GroupBox();
            this.rbWordFinal = new System.Windows.Forms.RadioButton();
            this.rbWordMedial = new System.Windows.Forms.RadioButton();
            this.rbWordInitial = new System.Windows.Forms.RadioButton();
            this.rbWordAny = new System.Windows.Forms.RadioButton();
            this.gbRootPosition = new System.Windows.Forms.GroupBox();
            this.rbRootFinal = new System.Windows.Forms.RadioButton();
            this.rbRootMedial = new System.Windows.Forms.RadioButton();
            this.rbRootInitial = new System.Windows.Forms.RadioButton();
            this.rbRootAny = new System.Windows.Forms.RadioButton();
            this.ckBrowseView = new System.Windows.Forms.CheckBox();
            this.nudMinSyllables = new System.Windows.Forms.NumericUpDown();
            this.labMinSyllable = new System.Windows.Forms.Label();
            this.labMaxSyllables = new System.Windows.Forms.Label();
            this.nudMaxSyllables = new System.Windows.Forms.NumericUpDown();
            this.gbWordPosition.SuspendLayout();
            this.gbRootPosition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinSyllables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxSyllables)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(329, 345);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(86, 26);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(465, 345);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 26);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbPS
            // 
            this.cbPS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPS.Location = new System.Drawing.Point(21, 46);
            this.cbPS.Name = "cbPS";
            this.cbPS.Size = new System.Drawing.Size(226, 23);
            this.cbPS.TabIndex = 1;
            // 
            // labPS
            // 
            this.labPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labPS.Location = new System.Drawing.Point(21, 20);
            this.labPS.Name = "labPS";
            this.labPS.Size = new System.Drawing.Size(150, 19);
            this.labPS.TabIndex = 0;
            this.labPS.Text = "Parts of speech:";
            // 
            // ckRootsOnly
            // 
            this.ckRootsOnly.AutoSize = true;
            this.ckRootsOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckRootsOnly.Location = new System.Drawing.Point(27, 86);
            this.ckRootsOnly.Name = "ckRootsOnly";
            this.ckRootsOnly.Size = new System.Drawing.Size(83, 19);
            this.ckRootsOnly.TabIndex = 2;
            this.ckRootsOnly.Text = "&Roots only";
            // 
            // ckVwlSame
            // 
            this.ckVwlSame.AutoSize = true;
            this.ckVwlSame.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckVwlSame.Location = new System.Drawing.Point(27, 125);
            this.ckVwlSame.Name = "ckVwlSame";
            this.ckVwlSame.Size = new System.Drawing.Size(149, 19);
            this.ckVwlSame.TabIndex = 3;
            this.ckVwlSame.Text = "&All vowels are identical";
            this.ckVwlSame.CheckedChanged += new System.EventHandler(this.ckVwlSame_CheckedChanged);
            // 
            // ckVwlInRootSame
            // 
            this.ckVwlInRootSame.AutoSize = true;
            this.ckVwlInRootSame.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckVwlInRootSame.Location = new System.Drawing.Point(27, 152);
            this.ckVwlInRootSame.Name = "ckVwlInRootSame";
            this.ckVwlInRootSame.Size = new System.Drawing.Size(186, 19);
            this.ckVwlInRootSame.TabIndex = 4;
            this.ckVwlInRootSame.Text = "All &vowels in root are identical";
            this.ckVwlInRootSame.CheckedChanged += new System.EventHandler(this.ckVwlInRootSame_CheckedChanged);
            // 
            // labWordCV
            // 
            this.labWordCV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labWordCV.Location = new System.Drawing.Point(27, 198);
            this.labWordCV.Name = "labWordCV";
            this.labWordCV.Size = new System.Drawing.Size(139, 19);
            this.labWordCV.TabIndex = 5;
            this.labWordCV.Text = "Word CV Shape";
            // 
            // tbWordCV
            // 
            this.tbWordCV.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbWordCV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbWordCV.Location = new System.Drawing.Point(171, 198);
            this.tbWordCV.Name = "tbWordCV";
            this.tbWordCV.Size = new System.Drawing.Size(103, 21);
            this.tbWordCV.TabIndex = 6;
            this.tbWordCV.TextChanged += new System.EventHandler(this.tbWordCV_TextChanged);
            // 
            // labRootCV
            // 
            this.labRootCV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labRootCV.Location = new System.Drawing.Point(27, 224);
            this.labRootCV.Name = "labRootCV";
            this.labRootCV.Size = new System.Drawing.Size(139, 19);
            this.labRootCV.TabIndex = 7;
            this.labRootCV.Text = "Root CV Shape";
            // 
            // tbRootCV
            // 
            this.tbRootCV.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbRootCV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRootCV.Location = new System.Drawing.Point(171, 224);
            this.tbRootCV.Name = "tbRootCV";
            this.tbRootCV.Size = new System.Drawing.Size(103, 21);
            this.tbRootCV.TabIndex = 8;
            this.tbRootCV.TextChanged += new System.EventHandler(this.tbRootCV_TextChanged);
            // 
            // gbWordPosition
            // 
            this.gbWordPosition.Controls.Add(this.rbWordFinal);
            this.gbWordPosition.Controls.Add(this.rbWordMedial);
            this.gbWordPosition.Controls.Add(this.rbWordInitial);
            this.gbWordPosition.Controls.Add(this.rbWordAny);
            this.gbWordPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbWordPosition.Location = new System.Drawing.Point(329, 13);
            this.gbWordPosition.Name = "gbWordPosition";
            this.gbWordPosition.Size = new System.Drawing.Size(221, 132);
            this.gbWordPosition.TabIndex = 10;
            this.gbWordPosition.TabStop = false;
            this.gbWordPosition.Text = "By word position";
            // 
            // rbWordFinal
            // 
            this.rbWordFinal.AutoSize = true;
            this.rbWordFinal.Location = new System.Drawing.Point(14, 99);
            this.rbWordFinal.Name = "rbWordFinal";
            this.rbWordFinal.Size = new System.Drawing.Size(127, 19);
            this.rbWordFinal.TabIndex = 4;
            this.rbWordFinal.Text = "Word-&final position";
            // 
            // rbWordMedial
            // 
            this.rbWordMedial.AutoSize = true;
            this.rbWordMedial.Location = new System.Drawing.Point(14, 74);
            this.rbWordMedial.Name = "rbWordMedial";
            this.rbWordMedial.Size = new System.Drawing.Size(142, 19);
            this.rbWordMedial.TabIndex = 3;
            this.rbWordMedial.Text = "Word-&medial position";
            // 
            // rbWordInitial
            // 
            this.rbWordInitial.AutoSize = true;
            this.rbWordInitial.Location = new System.Drawing.Point(14, 49);
            this.rbWordInitial.Name = "rbWordInitial";
            this.rbWordInitial.Size = new System.Drawing.Size(133, 19);
            this.rbWordInitial.TabIndex = 1;
            this.rbWordInitial.Text = "Word-&initial position";
            // 
            // rbWordAny
            // 
            this.rbWordAny.AutoSize = true;
            this.rbWordAny.Checked = true;
            this.rbWordAny.Location = new System.Drawing.Point(14, 25);
            this.rbWordAny.Name = "rbWordAny";
            this.rbWordAny.Size = new System.Drawing.Size(90, 19);
            this.rbWordAny.TabIndex = 0;
            this.rbWordAny.TabStop = true;
            this.rbWordAny.Text = "An&y position";
            // 
            // gbRootPosition
            // 
            this.gbRootPosition.Controls.Add(this.rbRootFinal);
            this.gbRootPosition.Controls.Add(this.rbRootMedial);
            this.gbRootPosition.Controls.Add(this.rbRootInitial);
            this.gbRootPosition.Controls.Add(this.rbRootAny);
            this.gbRootPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRootPosition.Location = new System.Drawing.Point(329, 170);
            this.gbRootPosition.Name = "gbRootPosition";
            this.gbRootPosition.Size = new System.Drawing.Size(221, 131);
            this.gbRootPosition.TabIndex = 11;
            this.gbRootPosition.TabStop = false;
            this.gbRootPosition.Text = "By root position";
            // 
            // rbRootFinal
            // 
            this.rbRootFinal.AutoSize = true;
            this.rbRootFinal.Location = new System.Drawing.Point(14, 99);
            this.rbRootFinal.Name = "rbRootFinal";
            this.rbRootFinal.Size = new System.Drawing.Size(124, 19);
            this.rbRootFinal.TabIndex = 4;
            this.rbRootFinal.Text = "Root-final positio&n";
            // 
            // rbRootMedial
            // 
            this.rbRootMedial.AutoSize = true;
            this.rbRootMedial.Location = new System.Drawing.Point(14, 74);
            this.rbRootMedial.Name = "rbRootMedial";
            this.rbRootMedial.Size = new System.Drawing.Size(139, 19);
            this.rbRootMedial.TabIndex = 3;
            this.rbRootMedial.Text = "Root-medial po&sition";
            // 
            // rbRootInitial
            // 
            this.rbRootInitial.AutoSize = true;
            this.rbRootInitial.Location = new System.Drawing.Point(14, 49);
            this.rbRootInitial.Name = "rbRootInitial";
            this.rbRootInitial.Size = new System.Drawing.Size(130, 19);
            this.rbRootInitial.TabIndex = 1;
            this.rbRootInitial.Text = "Root-initial &position";
            // 
            // rbRootAny
            // 
            this.rbRootAny.AutoSize = true;
            this.rbRootAny.Checked = true;
            this.rbRootAny.Location = new System.Drawing.Point(14, 25);
            this.rbRootAny.Name = "rbRootAny";
            this.rbRootAny.Size = new System.Drawing.Size(90, 19);
            this.rbRootAny.TabIndex = 0;
            this.rbRootAny.TabStop = true;
            this.rbRootAny.Text = "Any p&osition";
            // 
            // ckBrowseView
            // 
            this.ckBrowseView.AutoSize = true;
            this.ckBrowseView.Location = new System.Drawing.Point(30, 345);
            this.ckBrowseView.Name = "ckBrowseView";
            this.ckBrowseView.Size = new System.Drawing.Size(152, 19);
            this.ckBrowseView.TabIndex = 9;
            this.ckBrowseView.Text = "Display in Browse View";
            this.ckBrowseView.UseVisualStyleBackColor = true;
            this.ckBrowseView.Visible = false;
            // 
            // nudMinSyllables
            // 
            this.nudMinSyllables.Location = new System.Drawing.Point(236, 272);
            this.nudMinSyllables.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nudMinSyllables.Name = "nudMinSyllables";
            this.nudMinSyllables.Size = new System.Drawing.Size(32, 21);
            this.nudMinSyllables.TabIndex = 14;
            this.nudMinSyllables.ValueChanged += new System.EventHandler(this.nudMinSyllables_ValueChanged);
            // 
            // labMinSyllable
            // 
            this.labMinSyllable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMinSyllable.Location = new System.Drawing.Point(27, 272);
            this.labMinSyllable.Name = "labMinSyllable";
            this.labMinSyllable.Size = new System.Drawing.Size(203, 19);
            this.labMinSyllable.TabIndex = 15;
            this.labMinSyllable.Text = "Minimal Number of Syllables";
            // 
            // labMaxSyllables
            // 
            this.labMaxSyllables.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMaxSyllables.Location = new System.Drawing.Point(27, 300);
            this.labMaxSyllables.Name = "labMaxSyllables";
            this.labMaxSyllables.Size = new System.Drawing.Size(203, 19);
            this.labMaxSyllables.TabIndex = 17;
            this.labMaxSyllables.Text = "Maximal Number of Syllables";
            // 
            // nudMaxSyllables
            // 
            this.nudMaxSyllables.Location = new System.Drawing.Point(236, 300);
            this.nudMaxSyllables.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nudMaxSyllables.Name = "nudMaxSyllables";
            this.nudMaxSyllables.Size = new System.Drawing.Size(32, 21);
            this.nudMaxSyllables.TabIndex = 16;
            this.nudMaxSyllables.ValueChanged += new System.EventHandler(this.nudMaxSyllables_ValueChanged);
            // 
            // FormSearchOptions
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(654, 437);
            this.Controls.Add(this.labMaxSyllables);
            this.Controls.Add(this.nudMaxSyllables);
            this.Controls.Add(this.labMinSyllable);
            this.Controls.Add(this.nudMinSyllables);
            this.Controls.Add(this.ckBrowseView);
            this.Controls.Add(this.gbWordPosition);
            this.Controls.Add(this.tbRootCV);
            this.Controls.Add(this.tbWordCV);
            this.Controls.Add(this.labRootCV);
            this.Controls.Add(this.labWordCV);
            this.Controls.Add(this.labPS);
            this.Controls.Add(this.cbPS);
            this.Controls.Add(this.ckVwlSame);
            this.Controls.Add(this.ckVwlInRootSame);
            this.Controls.Add(this.ckRootsOnly);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbRootPosition);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSearchOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search Options Filter";
            this.gbWordPosition.ResumeLayout(false);
            this.gbWordPosition.PerformLayout();
            this.gbRootPosition.ResumeLayout(false);
            this.gbRootPosition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinSyllables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxSyllables)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        public bool IsRootOnly
        {
            get {return m_IsRootOnly;}
        }

        public bool IsIdenticalVowelsInWord
        {
            get {return m_IsIdenticalVowelsInWord;}
        }

        public bool IsIdenticalVowelsInRoot
        {
            get {return m_IsIdenticalVowelsInRoot;}
        }

        public bool IsBrowseView
        {
            get {return m_IsBrowseView;}
        }

        public string WordCVShape
        {
            get {return m_WordCVShape;}
        }

        public string RootCVShape
        {
            get {return m_RootCVShape;}
        }

        public int MinSyllables
        {
            get { return m_MinSyllables; }
        }

        public int MaxSyllables
        {
            get { return m_MaxSyllables; }
        }

        public SearchOptions.Position WordPosition
        {
            get {return m_WordPosition;}
        }

        public SearchOptions.Position RootPosition
        {
            get {return m_RootPosition;}
        }

        public CodeTableEntry PSTE
        {
            get { return m_PSTE; }
        }

        private void InitializeCT()
		{
            //PSTable pst = m_SearchOptions.PSTable;
 			CodeTableEntry cte = null;
			Object[] objItem = new object[m_PST.Count() + 1];
			string strItem = "";
			objItem[0] = "None";
			for ( int i = 0; i < m_PST.Count(); i++)
			{
				cte = m_PST.GetEntry(i);
				strItem = cte.Description + " (" + cte.Code + ")";
				objItem[i+1] = strItem;
			}
			cbPS.Items.AddRange(objItem);
			cbPS.Text = objItem[0].ToString();
		}

		private void ckVwlSame_CheckedChanged(object sender, System.EventArgs e)
		{
            //ckVwlInRootSame.Checked = ckVwlSame.Checked;
		}

		private void ckVwlInRootSame_CheckedChanged(object sender, System.EventArgs e)
		{
            //if (ckVwlSame.Checked)
            //    ckVwlInRootSame.Checked = ckVwlSame.Checked;
		}

		private void tbWordCV_TextChanged(object sender, System.EventArgs e)
		{
			string str1 = tbWordCV.Text;
			string str2 = "";
			for (int i = 0; i < str1.Length; i++)
			{
				if ( (str1.Substring(i,1) == "C") || (str1.Substring(i,1) == "V") )
					str2 += str1.Substring(i,1);
			}
			tbWordCV.Text = str2;
		}

		private void tbRootCV_TextChanged(object sender, System.EventArgs e)
		{
			string str1 = tbRootCV.Text;
			string str2 = "";
			for (int i = 0; i < str1.Length; i++)
			{
				if ( (str1.Substring(i,1) == "C") || (str1.Substring(i,1) == "V") )
					str2 += str1.Substring(i,1);
			}
			tbRootCV.Text = str2;
		}

        private void nudMinSyllables_ValueChanged(object sender, EventArgs e)
        {
            if (nudMaxSyllables.Value < nudMinSyllables.Value)
                nudMaxSyllables.Value = nudMinSyllables.Value;
        }

        private void nudMaxSyllables_ValueChanged(object sender, EventArgs e)
        {
            if (nudMinSyllables.Value > nudMaxSyllables.Value)
                nudMinSyllables.Value = nudMaxSyllables.Value;
        }

        private void btnOK_Click(object sender, System.EventArgs e)
		{
			m_PSTE = BuildCTE(cbPS.Text.Trim());
			m_IsRootOnly = ckRootsOnly.Checked;
			m_IsIdenticalVowelsInWord = ckVwlSame.Checked;
			m_IsIdenticalVowelsInRoot = ckVwlInRootSame.Checked;
			m_WordCVShape = tbWordCV.Text;
			m_RootCVShape = tbRootCV.Text;
            m_MinSyllables = Convert.ToInt16(nudMinSyllables.Value);
            m_MaxSyllables = Convert.ToInt16(nudMaxSyllables.Value);

			if (rbWordFinal.Checked)
                m_WordPosition = SearchOptions.Position.Final;
			else if (rbWordMedial.Checked)
				m_WordPosition = SearchOptions.Position.Medial;
			else if (rbWordInitial.Checked)
				m_WordPosition = SearchOptions.Position.Initial;
			else m_WordPosition = SearchOptions.Position.Any;

			if (rbRootFinal.Checked)
				m_RootPosition = SearchOptions.Position.Final;
			else if (rbRootMedial.Checked)
				m_RootPosition = SearchOptions.Position.Medial;
			else if (rbRootInitial.Checked)
				m_RootPosition = SearchOptions.Position.Initial;
			else m_RootPosition = SearchOptions.Position.Any;

            if (m_Browse)
            {
                m_IsBrowseView = this.ckBrowseView.Checked;
            }
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			m_PSTE = null;
			m_IsRootOnly = false;
			m_IsIdenticalVowelsInWord = false;
			m_IsIdenticalVowelsInRoot = false;
            m_IsBrowseView = false;
			m_WordCVShape = "";
			m_RootCVShape = "";
            m_MinSyllables = 0;
            m_MaxSyllables = 0;
			m_WordPosition = SearchOptions.Position.Any;
			m_RootPosition = SearchOptions.Position.Any;
            m_PSTE = null;
			this.Close();
		}

		private CodeTableEntry BuildCTE(string strPS)
		{
			CodeTableEntry cte = null;
			string strCode = "";
			string strDesc = "";
			int ndx1 = 0;
			int ndx2 = 0;

			if ( strPS == "None")
				return cte;

			ndx1 = strPS.IndexOf( "(" );
			ndx2 = strPS.IndexOf( ")" );
			strDesc = strPS.Substring(0, ndx1);
			strCode = strPS.Substring(ndx1 + 1, ndx2 - ndx1 - 1);
			cte = new CodeTableEntry(strCode, strDesc);
			return cte;
		}

	}
}

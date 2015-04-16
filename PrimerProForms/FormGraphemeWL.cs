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
	/// Summary description for FormGrapheme.
	/// </summary>
	public class FormGraphemeWL : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label labGraphemes;
		private System.Windows.Forms.TextBox tbGraphemes;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSO;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private CheckBox chkGraphemesTaught;
        private CheckBox chkBrowseView;

        //private string m_Grapheme;              //Grapheme selected;
        private ArrayList m_Graphemes;          //Graphemes selected
        private bool m_UseGraphemesTaught;      //Restrict to graphemes taught
        private bool m_BrowseView;              //Display in browse view
        private SearchOptions m_SearchOptions;  //Search options selected
        private GraphemeInventory m_GI;         //Grapheme Inventory
        private PSTable m_PSTable;              //Parts of Speech table
        private LocalizationTable m_Table;
        private Button btnGraphemes;      //Localization table
        private string m_Lang;                  //UI language

        public FormGraphemeWL(GraphemeInventory gi, PSTable pstable, Font fnt)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            this.tbGraphemes.Font = fnt;     //font for displaying grapheme
            m_GI = gi;
            m_PSTable = pstable;            //PoS Table used by Search Options
            m_Table = null;
            m_Lang = "";
        }

        public FormGraphemeWL(GraphemeInventory gi, PSTable pstable, Font fnt, LocalizationTable table, string lang)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            this.tbGraphemes.Font = fnt;     //font for displaying grapheme
            m_GI = gi;
            m_PSTable = pstable;            //PoS Table used by Search Options
            m_Table = table;
            m_Lang = lang;

            this.Text = table.GetForm("FormGraphemeWLT", lang);
            this.labGraphemes.Text = table.GetForm("FormGraphemeWL0", lang);
            this.chkGraphemesTaught.Text = table.GetForm("FormGraphemeWL2", lang);
            this.chkBrowseView.Text = table.GetForm("FormGraphemeWL3", lang);
            this.btnSO.Text = table.GetForm("FormGraphemeWL4", lang);
            this.btnOK.Text = table.GetForm("FormGraphemeWL5", lang);
            this.btnCancel.Text = table.GetForm("FormGraphemeWL6", lang);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGraphemeWL));
            this.labGraphemes = new System.Windows.Forms.Label();
            this.tbGraphemes = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSO = new System.Windows.Forms.Button();
            this.chkGraphemesTaught = new System.Windows.Forms.CheckBox();
            this.chkBrowseView = new System.Windows.Forms.CheckBox();
            this.btnGraphemes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labGraphemes
            // 
            this.labGraphemes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labGraphemes.Location = new System.Drawing.Point(14, 13);
            this.labGraphemes.Name = "labGraphemes";
            this.labGraphemes.Size = new System.Drawing.Size(151, 25);
            this.labGraphemes.TabIndex = 0;
            this.labGraphemes.Text = "Graphemes to find";
            this.labGraphemes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labGraphemes.UseWaitCursor = true;
            // 
            // tbGraphemes
            // 
            this.tbGraphemes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGraphemes.Location = new System.Drawing.Point(171, 18);
            this.tbGraphemes.Name = "tbGraphemes";
            this.tbGraphemes.Size = new System.Drawing.Size(200, 21);
            this.tbGraphemes.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(271, 132);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(439, 132);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSO
            // 
            this.btnSO.Location = new System.Drawing.Point(339, 72);
            this.btnSO.Name = "btnSO";
            this.btnSO.Size = new System.Drawing.Size(200, 32);
            this.btnSO.TabIndex = 4;
            this.btnSO.Text = "&Search Options";
            this.btnSO.Click += new System.EventHandler(this.btnSO_Click);
            // 
            // chkGraphemesTaught
            // 
            this.chkGraphemesTaught.AutoSize = true;
            this.chkGraphemesTaught.Location = new System.Drawing.Point(16, 59);
            this.chkGraphemesTaught.Name = "chkGraphemesTaught";
            this.chkGraphemesTaught.Size = new System.Drawing.Size(189, 19);
            this.chkGraphemesTaught.TabIndex = 2;
            this.chkGraphemesTaught.Text = "&Restrict to Graphemes Taught";
            this.chkGraphemesTaught.UseVisualStyleBackColor = true;
            // 
            // chkBrowseView
            // 
            this.chkBrowseView.AutoSize = true;
            this.chkBrowseView.Location = new System.Drawing.Point(16, 100);
            this.chkBrowseView.Name = "chkBrowseView";
            this.chkBrowseView.Size = new System.Drawing.Size(152, 19);
            this.chkBrowseView.TabIndex = 3;
            this.chkBrowseView.Text = "Display in &Browse View";
            this.chkBrowseView.UseVisualStyleBackColor = true;
            // 
            // btnGraphemes
            // 
            this.btnGraphemes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGraphemes.Location = new System.Drawing.Point(389, 14);
            this.btnGraphemes.Name = "btnGraphemes";
            this.btnGraphemes.Size = new System.Drawing.Size(150, 32);
            this.btnGraphemes.TabIndex = 7;
            this.btnGraphemes.Text = "Item Selection";
            this.btnGraphemes.UseVisualStyleBackColor = true;
            this.btnGraphemes.Click += new System.EventHandler(this.btnGraphemes_Click);
            // 
            // FormGrapheme
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(591, 191);
            this.Controls.Add(this.btnGraphemes);
            this.Controls.Add(this.chkBrowseView);
            this.Controls.Add(this.chkGraphemesTaught);
            this.Controls.Add(this.btnSO);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbGraphemes);
            this.Controls.Add(this.labGraphemes);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormGrapheme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Grapheme Search";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public ArrayList Graphemes
        {
            get { return m_Graphemes; }
        }
        
        public bool UseGraphemesTaught
        {
            get {return m_UseGraphemesTaught;}
        }

        public bool BrowseView
        {
            get {return m_BrowseView;}
        }

        public PrimerProObjects.SearchOptions SearchOptions
        {
            get { return m_SearchOptions; }
        }

        private void btnGraphemes_Click(object sender, EventArgs e)
        {
            GraphemeInventory gi = m_GI;
            ArrayList alGI = new ArrayList();
            ArrayList alSelection = new ArrayList();

            for (int i = 0; i < gi.ConsonantCount(); i++)
                alGI.Add(gi.GetConsonant(i).Symbol);
            for (int i = 0; i < gi.VowelCount(); i++)
                alGI.Add(gi.GetVowel(i).Symbol);
            for (int i = 0; i < gi.ToneCount(); i++)
                alGI.Add(gi.GetTone(i).Symbol);
            for (int i = 0; i < gi.SyllographCount(); i++)
                alGI.Add(gi.GetSyllograph(i).Symbol);
            alSelection = Funct.ConvertStringToArrayList(this.tbGraphemes.Text, Constants.Space.ToString());

            if ((m_Lang != "") && (m_Lang == OptionList.kFrench))
            {
                FormItemSelectionFrench form = new FormItemSelectionFrench(alGI, alSelection, labGraphemes.Text, tbGraphemes.Font);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    ArrayList al = form.Selection();
                    string strGraphemes = Funct.ConvertArrayListToString(al, Constants.Space.ToString());
                    this.tbGraphemes.Text = strGraphemes;
                }
            }
            else
            {
                FormItemSelection form = new FormItemSelection(alGI, alSelection, labGraphemes.Text, tbGraphemes.Font);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    ArrayList al = form.Selection();
                    string strGraphemes = Funct.ConvertArrayListToString(al, Constants.Space.ToString());
                    this.tbGraphemes.Text = strGraphemes;
                }
            }

        }

        private void btnOK_Click(object sender, System.EventArgs e)
		{
            string strGrfs = tbGraphemes.Text.Trim();
            if (strGrfs != "")
            {
                m_Graphemes = Funct.ConvertStringToArrayList(strGrfs, Constants.Space.ToString());
                m_UseGraphemesTaught = chkGraphemesTaught.Checked;
                m_BrowseView = chkBrowseView.Checked;
            }
            else
            {
                m_Graphemes = null;
                m_UseGraphemesTaught = false;
                m_BrowseView = false;
            }
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
            m_Graphemes = null;
            m_UseGraphemesTaught = false;
            m_BrowseView = false;
			this.Close();
		}

        private void btnSO_Click(object sender, System.EventArgs e)
        {
            SearchOptions so = new SearchOptions(m_PSTable);
            CodeTable ct = (CodeTable) m_PSTable;
            //FormSearchOptions form = new FormSearchOptions(ct, false, false);
            FormSearchOptions form = new FormSearchOptions(ct, false, false, m_Table, m_Lang);
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

	}
}

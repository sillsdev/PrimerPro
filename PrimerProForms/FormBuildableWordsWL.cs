using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PrimerProObjects;
using GenLib;
using PrimerProLocalization;

namespace PrimerProForms
{
	/// <summary>
	/// Summary description for FormBuildableWordsWL.
	/// </summary>
	public class FormBuildableWordsWL : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label labTitle;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label labGrapheme;
        private System.Windows.Forms.TextBox tbGraphemes;
		private System.Windows.Forms.Button btnSO;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private Label labHighlight;
        private TextBox tbHighlights;
        private CheckBox chkBrowseView;
        private Button btnGraphemes;
        private Button btnHighlight;

        private GraphemeInventory m_GraphemeInventory;
        private PSTable m_PSTable;
        private Font m_Font;
        private LocalizationTable m_Table;          //Localization table
        private string m_Lang;                      //UI language

        private ArrayList m_Graphemes;
        private ArrayList m_Highlights;
        private bool m_BrowseView;
        private SearchOptions m_SearchOptions;

		public FormBuildableWordsWL(GraphemeInventory gi, GraphemeTaughtOrder gto, PSTable pst, Font fnt)
		{
			InitializeComponent();
			m_GraphemeInventory = gi;
            m_PSTable = pst;
            m_Font = fnt;

            this.tbGraphemes.Text = this.GetGraphemesTaught(gto);
            this.tbHighlights.Text = "";
            this.chkBrowseView.Checked = false;
            this.tbGraphemes.Font = m_Font;
            this.tbHighlights.Font = m_Font;
            m_Table = null;
            m_Lang = "";

		}

        public FormBuildableWordsWL(GraphemeInventory gi, GraphemeTaughtOrder gto, PSTable pst, Font fnt,
            LocalizationTable table, string lang)
        {
            InitializeComponent();
            
            m_GraphemeInventory = gi;
            m_PSTable = pst;
            m_Font = fnt;
            m_Table = table;
            m_Lang = lang;

            this.tbGraphemes.Text = this.GetGraphemesTaught(gto);
            this.tbHighlights.Text = "";
            this.chkBrowseView.Checked = false;
            this.tbGraphemes.Font = m_Font;
            this.tbHighlights.Font = m_Font;

            this.UpdateFormForLocalization(m_Table);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBuildableWordsWL));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.labTitle = new System.Windows.Forms.Label();
            this.labGrapheme = new System.Windows.Forms.Label();
            this.tbGraphemes = new System.Windows.Forms.TextBox();
            this.btnSO = new System.Windows.Forms.Button();
            this.labHighlight = new System.Windows.Forms.Label();
            this.tbHighlights = new System.Windows.Forms.TextBox();
            this.chkBrowseView = new System.Windows.Forms.CheckBox();
            this.btnGraphemes = new System.Windows.Forms.Button();
            this.btnHighlight = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(484, 206);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(83, 28);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(583, 206);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 28);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labTitle
            // 
            this.labTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTitle.Location = new System.Drawing.Point(100, 14);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(567, 48);
            this.labTitle.TabIndex = 0;
            this.labTitle.Text = "List only graphemes (consonants and vowels) which have been taught.  The grapheme" +
    "s should be separated by a space.  (e.g. p b m mp mb mpw mbw a e i o u aa)";
            // 
            // labGrapheme
            // 
            this.labGrapheme.AutoEllipsis = true;
            this.labGrapheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labGrapheme.Location = new System.Drawing.Point(20, 73);
            this.labGrapheme.Name = "labGrapheme";
            this.labGrapheme.Size = new System.Drawing.Size(75, 21);
            this.labGrapheme.TabIndex = 1;
            this.labGrapheme.Text = "Graphemes";
            // 
            // tbGraphemes
            // 
            this.tbGraphemes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGraphemes.Location = new System.Drawing.Point(100, 73);
            this.tbGraphemes.Name = "tbGraphemes";
            this.tbGraphemes.Size = new System.Drawing.Size(467, 21);
            this.tbGraphemes.TabIndex = 2;
            // 
            // btnSO
            // 
            this.btnSO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSO.Location = new System.Drawing.Point(103, 202);
            this.btnSO.Name = "btnSO";
            this.btnSO.Size = new System.Drawing.Size(200, 32);
            this.btnSO.TabIndex = 8;
            this.btnSO.Text = "&Search Options";
            this.btnSO.Click += new System.EventHandler(this.btnSO_Click);
            // 
            // labHighlight
            // 
            this.labHighlight.AutoEllipsis = true;
            this.labHighlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labHighlight.Location = new System.Drawing.Point(20, 113);
            this.labHighlight.Name = "labHighlight";
            this.labHighlight.Size = new System.Drawing.Size(315, 21);
            this.labHighlight.TabIndex = 4;
            this.labHighlight.Text = "Highlight words with these graphemes";
            this.labHighlight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbHighlights
            // 
            this.tbHighlights.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHighlights.Location = new System.Drawing.Point(358, 113);
            this.tbHighlights.Name = "tbHighlights";
            this.tbHighlights.Size = new System.Drawing.Size(209, 21);
            this.tbHighlights.TabIndex = 5;
            // 
            // chkBrowseView
            // 
            this.chkBrowseView.AutoSize = true;
            this.chkBrowseView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBrowseView.Location = new System.Drawing.Point(103, 162);
            this.chkBrowseView.Name = "chkBrowseView";
            this.chkBrowseView.Size = new System.Drawing.Size(149, 19);
            this.chkBrowseView.TabIndex = 7;
            this.chkBrowseView.Text = "Display in &browse view";
            this.chkBrowseView.UseVisualStyleBackColor = true;
            this.chkBrowseView.CheckedChanged += new System.EventHandler(this.chkBrowseView_CheckedChanged);
            // 
            // btnGraphemes
            // 
            this.btnGraphemes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGraphemes.Location = new System.Drawing.Point(583, 73);
            this.btnGraphemes.Name = "btnGraphemes";
            this.btnGraphemes.Size = new System.Drawing.Size(150, 32);
            this.btnGraphemes.TabIndex = 3;
            this.btnGraphemes.Text = "Item Selection";
            this.btnGraphemes.UseVisualStyleBackColor = true;
            this.btnGraphemes.Click += new System.EventHandler(this.btnGraphemes_Click);
            // 
            // btnHighlight
            // 
            this.btnHighlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHighlight.Location = new System.Drawing.Point(583, 113);
            this.btnHighlight.Name = "btnHighlight";
            this.btnHighlight.Size = new System.Drawing.Size(150, 32);
            this.btnHighlight.TabIndex = 6;
            this.btnHighlight.Text = "Item Selection";
            this.btnHighlight.UseVisualStyleBackColor = true;
            this.btnHighlight.Click += new System.EventHandler(this.btnHighlight_Click);
            // 
            // FormBuildableWordsWL
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(784, 269);
            this.Controls.Add(this.btnHighlight);
            this.Controls.Add(this.btnGraphemes);
            this.Controls.Add(this.chkBrowseView);
            this.Controls.Add(this.tbHighlights);
            this.Controls.Add(this.labHighlight);
            this.Controls.Add(this.btnSO);
            this.Controls.Add(this.tbGraphemes);
            this.Controls.Add(this.labGrapheme);
            this.Controls.Add(this.labTitle);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormBuildableWordsWL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Buildable Words Search";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        public ArrayList Graphemes
        {
            get { return m_Graphemes; }
        }

        public ArrayList Highlights
        {
            get { return m_Highlights; }
        }

        public bool BrowseView
        {
            get { return m_BrowseView; }
        }

        public SearchOptions SearchOptions
        {
            get { return m_SearchOptions; }
        }
        
        private void btnOK_Click(object sender, System.EventArgs e)
		{
			string strGrfs = tbGraphemes.Text.Trim();
            string strHlts = tbHighlights.Text.Trim();
            if (strGrfs != "")
            {
                m_Graphemes = Funct.ConvertStringToArrayList(strGrfs, Constants.Space.ToString());
                m_Highlights = Funct.ConvertStringToArrayList(strHlts, Constants.Space.ToString());
                m_BrowseView = chkBrowseView.Checked;
            }
            else
            {
                m_Graphemes = null;
                m_Highlights = null;
                m_BrowseView = false;
            }
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			m_Graphemes = null;
            m_Highlights = null;
            m_BrowseView = false;
			this.Close();
		}

		private void btnSO_Click(object sender, System.EventArgs e)
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
                so.MinSyllables = form.MaxSyllables;
                so.MaxSyllables = form.MaxSyllables;
                so.WordPosition = form.WordPosition;
                so.RootPosition = form.RootPosition;
                m_SearchOptions = so;
            }
        }

        private void chkBrowseView_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBrowseView.Checked)
                tbHighlights.Enabled = false;
            else tbHighlights.Enabled = true;
        }

        private void btnGraphemes_Click(object sender, EventArgs e)
        {
            GraphemeInventory gi = m_GraphemeInventory;
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
                FormItemSelectionFrench form = new FormItemSelectionFrench(alGI, alSelection,labGrapheme.Text, m_Font);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    ArrayList al = form.Selection();
                    string strGraphemes = Funct.ConvertArrayListToString(al, Constants.Space.ToString());
                    this.tbGraphemes.Text = strGraphemes;
                }
            }
            else if ((m_Lang != "") && (m_Lang == OptionList.kSpanish))
            {
                FormItemSelectionSpanish form = new FormItemSelectionSpanish(alGI, alSelection, labGrapheme.Text, m_Font);
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
                FormItemSelection form = new FormItemSelection(alGI, alSelection, labGrapheme.Text, m_Font);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    ArrayList al = form.Selection();
                    string strGraphemes = Funct.ConvertArrayListToString(al, Constants.Space.ToString());
                    this.tbGraphemes.Text = strGraphemes;
                }
            }
        }

        private void btnHighlight_Click(object sender, EventArgs e)
        {
            ArrayList alAvailable = Funct.ConvertStringToArrayList(tbGraphemes.Text, Constants.Space.ToString());
            ArrayList alHighlight = Funct.ConvertStringToArrayList(tbHighlights.Text, Constants.Space.ToString());
            string strSymbol = "";

            // remove underscores
            for (int i = 0; i < alAvailable.Count; i++)
            {
                strSymbol = alAvailable[i].ToString();
                strSymbol = strSymbol.Replace(Syllable.Underscore, "");
                alAvailable[i] = strSymbol;
            }

            if ((m_Lang != "") && (m_Lang == OptionList.kFrench))
            {
                FormItemSelectionFrench form = new FormItemSelectionFrench(alAvailable, alHighlight, labHighlight.Text, m_Font);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    ArrayList al = form.Selection();
                    this.tbHighlights.Text = Funct.ConvertArrayListToString(al, Constants.Space.ToString());
                }
            }
            else if ((m_Lang != "") && (m_Lang == OptionList.kSpanish))
            {
                FormItemSelectionSpanish form = new FormItemSelectionSpanish(alAvailable, alHighlight, labHighlight.Text, m_Font);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    ArrayList al = form.Selection();
                    this.tbHighlights.Text = Funct.ConvertArrayListToString(al, Constants.Space.ToString());
                }
            }
            else
            {
                FormItemSelection form = new FormItemSelection(alAvailable, alHighlight, labHighlight.Text, m_Font);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    ArrayList al = form.Selection();
                    this.tbHighlights.Text = Funct.ConvertArrayListToString(al, Constants.Space.ToString());
                }
            }
        }

        private string GetGraphemesTaught(GraphemeTaughtOrder gto)
        {
            string strText = "";
            for (int i = 0; i < gto.Count(); i++)
            {
                strText += gto.GetGrapheme(i).Trim() + Constants.Space;
            }
            strText = strText.Trim();
            return strText;
        }

        private void UpdateFormForLocalization(LocalizationTable table)
        {
            string strText = "";
            strText = table.GetForm("FormBuildableWordsWLT");
			if (strText != "")
				this.Text = strText;
            strText = table.GetForm("FormBuildableWordsWL0");
			if (strText != "")
				this.labTitle.Text = strText;
            strText = table.GetForm("FormBuildableWordsWL1");
			if (strText != "")
				this.labGrapheme.Text = strText;
            strText = table.GetForm("FormBuildableWordsWL3");
			if (strText != "")
				this.btnGraphemes.Text = strText;
            strText = table.GetForm("FormBuildableWordsWL4");
			if (strText != "")
				this.labHighlight.Text = strText;
            strText = table.GetForm("FormBuildableWordsWL6");
			if (strText != "")
				this.btnHighlight.Text = strText;
            strText = table.GetForm("FormBuildableWordsWL7");
			if (strText != "")
				this.chkBrowseView.Text = strText;
            strText = table.GetForm("FormBuildableWordsWL8");
			if (strText != "")
				this.btnSO.Text = strText;
            strText = table.GetForm("FormBuildableWordsWL9");
			if (strText != "")
				this.btnOK.Text = strText;
            strText = table.GetForm("FormBuildableWordsWL10");
			if (strText != "")
				this.btnCancel.Text = strText;
            return;
        }

    }
}

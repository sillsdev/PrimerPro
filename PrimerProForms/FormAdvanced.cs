using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Text;
using PrimerProObjects;
using PrimerProLocalization;
using GenLib;

namespace PrimerProForms
{
	/// <summary>
	/// Summary description for FormAdvGen.
	/// </summary>
	public class FormAdvanced : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label labelDirections;
		private System.Windows.Forms.GroupBox gbGrf1;
		private System.Windows.Forms.RadioButton rbGrf1Sym;
		private System.Windows.Forms.TextBox tbGrf1Sym;
		private System.Windows.Forms.RadioButton rbGrf1Cns;
		private System.Windows.Forms.Button btnGrf1Cns;
		private System.Windows.Forms.RadioButton rbGrf1Vwl;
		private System.Windows.Forms.Button btnGrf1Vwl;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnGrf1Add;
		private System.Windows.Forms.Label labelGrf1;
        private System.Windows.Forms.Label labelFeat1;
		private System.Windows.Forms.TextBox tbFeat1;
		private System.Windows.Forms.GroupBox gbGrf2;
		private System.Windows.Forms.Button btnGrf2Add;
		private System.Windows.Forms.Button btnGrf2Vwl;
		private System.Windows.Forms.RadioButton rbGrf2Vwl;
		private System.Windows.Forms.Button btnGrf2Cns;
		private System.Windows.Forms.RadioButton rbGrf2Cns;
		private System.Windows.Forms.TextBox tbGrf2Sym;
		private System.Windows.Forms.RadioButton rbGrf2Sym;
		private System.Windows.Forms.GroupBox gbGrf3;
		private System.Windows.Forms.Button btnGrf3Add;
		private System.Windows.Forms.Button btnGrf3Vwl;
		private System.Windows.Forms.RadioButton rbGrf3Vwl;
		private System.Windows.Forms.Button btnGrf3Cns;
		private System.Windows.Forms.RadioButton rbGrf3Cns;
		private System.Windows.Forms.TextBox tbGrf3Sym;
		private System.Windows.Forms.GroupBox gbGrf4;
		private System.Windows.Forms.Button btnGrf4Add;
		private System.Windows.Forms.Button btnGrf4Vwl;
		private System.Windows.Forms.RadioButton rbGrf4Vwl;
		private System.Windows.Forms.Button btnGrf4Cns;
		private System.Windows.Forms.RadioButton rbGrf4Cns;
		private System.Windows.Forms.TextBox tbGrf4Sym;
		private System.Windows.Forms.RadioButton rbGrf4Sym;
		private System.Windows.Forms.TextBox tbFeat2;
		private System.Windows.Forms.TextBox tbGrf2;
		private System.Windows.Forms.Label labelFeat2;
		private System.Windows.Forms.Label labelGrf2;
		private System.Windows.Forms.TextBox tbFeat3;
		private System.Windows.Forms.TextBox tbGrf3;
		private System.Windows.Forms.Label labelFeat3;
		private System.Windows.Forms.Label labelGrf3;
		private System.Windows.Forms.TextBox tbFeat4;
		private System.Windows.Forms.TextBox tbGrf4;
		private System.Windows.Forms.Label labelFeat4;
		private System.Windows.Forms.Label labelGrf4;
		private System.Windows.Forms.RadioButton rbGrf3Sym;
        private CheckBox chkGraphemesTaught;
        /// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button btnSO;
        private CheckBox chkBrowseView;

        //private AdvancedSearch m_Search;		//Advanced Grapheme Search calling form
        private string m_Sequence1Grf;
        private ConsonantFeatures m_Sequence1Cns;
        private VowelFeatures m_Sequence1Vwl;
        private string m_Sequence2Grf;
        private ConsonantFeatures m_Sequence2Cns;
        private VowelFeatures m_Sequence2Vwl;
        private string m_Sequence3Grf;
        private ConsonantFeatures m_Sequence3Cns;
        private VowelFeatures m_Sequence3Vwl;
        private string m_Sequence4Grf;
        private ConsonantFeatures m_Sequence4Cns;
        private VowelFeatures m_Sequence4Vwl;
        private bool m_UseGraphemesTaught;
        private bool m_BrowseView;
        private GraphemeInventory m_GI;
        private PSTable m_PSTable;
        private SearchOptions m_SearchOptions;
        private LocalizationTable m_Table;
        private TextBox tbGrf1;      //Localization table
        private string m_Lang;                  //UI lamguage

		public FormAdvanced(GraphemeInventory gi, PSTable pstable, Font fnt)
		{
			InitializeComponent();
            m_Sequence1Grf = "";
            m_Sequence1Cns = null;
            m_Sequence1Vwl = null;
            m_Sequence2Grf = "";
            m_Sequence2Cns = null;
            m_Sequence2Vwl = null;
            m_Sequence3Grf = "";
            m_Sequence3Cns = null;
            m_Sequence3Vwl = null;
            m_Sequence4Grf = "";
            m_Sequence4Cns = null;
            m_Sequence4Cns = null;
            m_UseGraphemesTaught = false;
            m_BrowseView = false;
            m_GI = gi;
            m_PSTable = pstable;
            m_Table = null;
            m_Lang = "";

            this.tbGrf1Sym.Font = fnt;
            this.tbGrf2Sym.Font = fnt;
            this.tbGrf3Sym.Font = fnt;
            this.tbGrf4Sym.Font = fnt;
            this.tbGrf1.Font = fnt;
            this.tbGrf2.Font = fnt;
            this.tbGrf3.Font = fnt;
            this.tbGrf4.Font = fnt;
 		}

        public FormAdvanced(GraphemeInventory gi, PSTable pstable, Font fnt,
            LocalizationTable table, string lang)
        {
            InitializeComponent();
            m_Sequence1Grf = "";
            m_Sequence1Cns = null;
            m_Sequence1Vwl = null;
            m_Sequence2Grf = "";
            m_Sequence2Cns = null;
            m_Sequence2Vwl = null;
            m_Sequence3Grf = "";
            m_Sequence3Cns = null;
            m_Sequence3Vwl = null;
            m_Sequence4Grf = "";
            m_Sequence4Cns = null;
            m_Sequence4Cns = null;
            m_UseGraphemesTaught = false;
            m_BrowseView = false;
            m_GI = gi;
            m_PSTable = pstable;
            m_Table = table;
            m_Lang = lang;

            this.tbGrf1Sym.Font = fnt;
            this.tbGrf2Sym.Font = fnt;
            this.tbGrf3Sym.Font = fnt;
            this.tbGrf4Sym.Font = fnt;
            this.tbGrf1.Font = fnt;
            this.tbGrf2.Font = fnt;
            this.tbGrf3.Font = fnt;
            this.tbGrf4.Font = fnt;

            this.Text = table.GetForm("FormAdvancedT", lang);
            this.labelDirections.Text = table.GetForm("FormAdvanced0", lang);
            this.gbGrf1.Text = table.GetForm("FormAdvanced1", lang);
            this.labelGrf1.Text = table.GetForm("FormAdvanced2", lang);
            this.labelFeat1.Text = table.GetForm("FormAdvanced3", lang);
            this.rbGrf1Sym.Text = table.GetForm("FormAdvancedx0", lang);
            this.rbGrf1Cns.Text = table.GetForm("FormAdvancedx2", lang);
            this.btnGrf1Cns.Text = table.GetForm("FormAdvancedx3", lang);
            this.rbGrf1Vwl.Text = table.GetForm("FormAdvancedx4", lang);
            this.btnGrf1Vwl.Text = table.GetForm("FormAdvancedx5", lang);
            this.btnGrf1Add.Text = table.GetForm("FormAdvancedx61", lang);
            this.gbGrf2.Text = table.GetForm("FormAdvanced6", lang);
            this.labelGrf2.Text = table.GetForm("FormAdvanced7", lang);
            this.labelFeat2.Text = table.GetForm("FormAdvanced8", lang);
            this.rbGrf2Sym.Text = table.GetForm("FormAdvancedx0", lang);
            this.rbGrf2Cns.Text = table.GetForm("FormAdvancedx2", lang);
            this.btnGrf2Cns.Text = table.GetForm("FormAdvancedx3", lang);
            this.rbGrf2Vwl.Text = table.GetForm("FormAdvancedx4", lang);
            this.btnGrf2Vwl.Text = table.GetForm("FormAdvancedx5", lang);
            this.btnGrf2Add.Text = table.GetForm("FormAdvancedx62", lang);
            this.gbGrf3.Text = table.GetForm("FormAdvanced11", lang);
            this.labelGrf3.Text = table.GetForm("FormAdvanced12", lang);
            this.labelFeat3.Text = table.GetForm("FormAdvanced13", lang);
            this.rbGrf3Sym.Text = table.GetForm("FormAdvancedx0", lang);
            this.rbGrf3Cns.Text = table.GetForm("FormAdvancedx2", lang);
            this.btnGrf3Cns.Text = table.GetForm("FormAdvancedx3", lang);
            this.rbGrf3Vwl.Text = table.GetForm("FormAdvancedx4", lang);
            this.btnGrf3Vwl.Text = table.GetForm("FormAdvancedx5", lang);
            this.btnGrf3Add.Text = table.GetForm("FormAdvancedx63", lang);
            this.gbGrf4.Text = table.GetForm("FormAdvanced16", lang);
            this.labelGrf4.Text = table.GetForm("FormAdvanced17", lang);
            this.labelFeat4.Text = table.GetForm("FormAdvanced18", lang);
            this.rbGrf4Sym.Text = table.GetForm("FormAdvancedx0", lang);
            this.rbGrf4Cns.Text = table.GetForm("FormAdvancedx2", lang);
            this.btnGrf4Cns.Text = table.GetForm("FormAdvancedx3", lang);
            this.rbGrf4Vwl.Text = table.GetForm("FormAdvancedx4", lang);
            this.btnGrf4Vwl.Text = table.GetForm("FormAdvancedx5", lang);
            this.btnGrf4Add.Text = table.GetForm("FormAdvancedx64", lang);
            this.chkGraphemesTaught.Text = table.GetForm("FormAdvanced21", lang);
            this.chkBrowseView.Text = table.GetForm("FormAdvanced22", lang);
            this.btnSO.Text = table.GetForm("FormAdvanced23", lang);
            this.btnOK.Text = table.GetForm("FormAdvanced24", lang);
            this.btnCancel.Text = table.GetForm("FormAdvanced25", lang);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdvanced));
            this.labelDirections = new System.Windows.Forms.Label();
            this.gbGrf1 = new System.Windows.Forms.GroupBox();
            this.btnGrf1Add = new System.Windows.Forms.Button();
            this.btnGrf1Vwl = new System.Windows.Forms.Button();
            this.rbGrf1Vwl = new System.Windows.Forms.RadioButton();
            this.btnGrf1Cns = new System.Windows.Forms.Button();
            this.rbGrf1Cns = new System.Windows.Forms.RadioButton();
            this.tbGrf1Sym = new System.Windows.Forms.TextBox();
            this.rbGrf1Sym = new System.Windows.Forms.RadioButton();
            this.labelGrf1 = new System.Windows.Forms.Label();
            this.labelFeat1 = new System.Windows.Forms.Label();
            this.tbFeat1 = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbGrf2 = new System.Windows.Forms.GroupBox();
            this.btnGrf2Add = new System.Windows.Forms.Button();
            this.btnGrf2Vwl = new System.Windows.Forms.Button();
            this.rbGrf2Vwl = new System.Windows.Forms.RadioButton();
            this.btnGrf2Cns = new System.Windows.Forms.Button();
            this.rbGrf2Cns = new System.Windows.Forms.RadioButton();
            this.tbGrf2Sym = new System.Windows.Forms.TextBox();
            this.rbGrf2Sym = new System.Windows.Forms.RadioButton();
            this.gbGrf3 = new System.Windows.Forms.GroupBox();
            this.btnGrf3Add = new System.Windows.Forms.Button();
            this.btnGrf3Vwl = new System.Windows.Forms.Button();
            this.rbGrf3Vwl = new System.Windows.Forms.RadioButton();
            this.btnGrf3Cns = new System.Windows.Forms.Button();
            this.rbGrf3Cns = new System.Windows.Forms.RadioButton();
            this.rbGrf3Sym = new System.Windows.Forms.RadioButton();
            this.tbGrf3Sym = new System.Windows.Forms.TextBox();
            this.gbGrf4 = new System.Windows.Forms.GroupBox();
            this.btnGrf4Add = new System.Windows.Forms.Button();
            this.btnGrf4Vwl = new System.Windows.Forms.Button();
            this.rbGrf4Vwl = new System.Windows.Forms.RadioButton();
            this.btnGrf4Cns = new System.Windows.Forms.Button();
            this.rbGrf4Cns = new System.Windows.Forms.RadioButton();
            this.tbGrf4Sym = new System.Windows.Forms.TextBox();
            this.rbGrf4Sym = new System.Windows.Forms.RadioButton();
            this.tbFeat2 = new System.Windows.Forms.TextBox();
            this.tbGrf2 = new System.Windows.Forms.TextBox();
            this.labelFeat2 = new System.Windows.Forms.Label();
            this.labelGrf2 = new System.Windows.Forms.Label();
            this.tbFeat3 = new System.Windows.Forms.TextBox();
            this.tbGrf3 = new System.Windows.Forms.TextBox();
            this.labelFeat3 = new System.Windows.Forms.Label();
            this.labelGrf3 = new System.Windows.Forms.Label();
            this.tbFeat4 = new System.Windows.Forms.TextBox();
            this.tbGrf4 = new System.Windows.Forms.TextBox();
            this.labelFeat4 = new System.Windows.Forms.Label();
            this.labelGrf4 = new System.Windows.Forms.Label();
            this.btnSO = new System.Windows.Forms.Button();
            this.chkGraphemesTaught = new System.Windows.Forms.CheckBox();
            this.chkBrowseView = new System.Windows.Forms.CheckBox();
            this.tbGrf1 = new System.Windows.Forms.TextBox();
            this.gbGrf1.SuspendLayout();
            this.gbGrf2.SuspendLayout();
            this.gbGrf3.SuspendLayout();
            this.gbGrf4.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelDirections
            // 
            this.labelDirections.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDirections.Location = new System.Drawing.Point(14, 13);
            this.labelDirections.Name = "labelDirections";
            this.labelDirections.Size = new System.Drawing.Size(771, 19);
            this.labelDirections.TabIndex = 0;
            this.labelDirections.Text = "Specify up to four graphemes by symbol or features (sequence extends from left to" +
                " right)";
            // 
            // gbGrf1
            // 
            this.gbGrf1.Controls.Add(this.btnGrf1Add);
            this.gbGrf1.Controls.Add(this.btnGrf1Vwl);
            this.gbGrf1.Controls.Add(this.rbGrf1Vwl);
            this.gbGrf1.Controls.Add(this.btnGrf1Cns);
            this.gbGrf1.Controls.Add(this.rbGrf1Cns);
            this.gbGrf1.Controls.Add(this.tbGrf1Sym);
            this.gbGrf1.Controls.Add(this.rbGrf1Sym);
            this.gbGrf1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbGrf1.Location = new System.Drawing.Point(14, 40);
            this.gbGrf1.Name = "gbGrf1";
            this.gbGrf1.Size = new System.Drawing.Size(197, 254);
            this.gbGrf1.TabIndex = 1;
            this.gbGrf1.TabStop = false;
            this.gbGrf1.Text = "Grapheme 1";
            // 
            // btnGrf1Add
            // 
            this.btnGrf1Add.Enabled = false;
            this.btnGrf1Add.Location = new System.Drawing.Point(14, 216);
            this.btnGrf1Add.Name = "btnGrf1Add";
            this.btnGrf1Add.Size = new System.Drawing.Size(128, 32);
            this.btnGrf1Add.TabIndex = 6;
            this.btnGrf1Add.Text = "Add grapheme &1";
            this.btnGrf1Add.Click += new System.EventHandler(this.btnSeg1Add_Click);
            // 
            // btnGrf1Vwl
            // 
            this.btnGrf1Vwl.Enabled = false;
            this.btnGrf1Vwl.Location = new System.Drawing.Point(34, 171);
            this.btnGrf1Vwl.Name = "btnGrf1Vwl";
            this.btnGrf1Vwl.Size = new System.Drawing.Size(124, 32);
            this.btnGrf1Vwl.TabIndex = 5;
            this.btnGrf1Vwl.Text = "Choose &features";
            this.btnGrf1Vwl.Click += new System.EventHandler(this.btnSeg1Vwl_Click);
            // 
            // rbGrf1Vwl
            // 
            this.rbGrf1Vwl.Location = new System.Drawing.Point(14, 144);
            this.rbGrf1Vwl.Name = "rbGrf1Vwl";
            this.rbGrf1Vwl.Size = new System.Drawing.Size(171, 20);
            this.rbGrf1Vwl.TabIndex = 4;
            this.rbGrf1Vwl.Text = "Specify as &V";
            this.rbGrf1Vwl.CheckedChanged += new System.EventHandler(this.rbSeg1Vwl_CheckedChanged);
            // 
            // btnGrf1Cns
            // 
            this.btnGrf1Cns.Enabled = false;
            this.btnGrf1Cns.Location = new System.Drawing.Point(34, 108);
            this.btnGrf1Cns.Name = "btnGrf1Cns";
            this.btnGrf1Cns.Size = new System.Drawing.Size(124, 32);
            this.btnGrf1Cns.TabIndex = 3;
            this.btnGrf1Cns.Text = "Choose &features";
            this.btnGrf1Cns.Click += new System.EventHandler(this.btnSeg1Cns_Click);
            // 
            // rbGrf1Cns
            // 
            this.rbGrf1Cns.Location = new System.Drawing.Point(14, 84);
            this.rbGrf1Cns.Name = "rbGrf1Cns";
            this.rbGrf1Cns.Size = new System.Drawing.Size(171, 19);
            this.rbGrf1Cns.TabIndex = 2;
            this.rbGrf1Cns.Text = "Specify as &C";
            this.rbGrf1Cns.CheckedChanged += new System.EventHandler(this.rbSeg1Cns_CheckedChanged);
            // 
            // tbGrf1Sym
            // 
            this.tbGrf1Sym.Enabled = false;
            this.tbGrf1Sym.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGrf1Sym.Location = new System.Drawing.Point(34, 53);
            this.tbGrf1Sym.Name = "tbGrf1Sym";
            this.tbGrf1Sym.Size = new System.Drawing.Size(65, 21);
            this.tbGrf1Sym.TabIndex = 1;
            this.tbGrf1Sym.TextChanged += new System.EventHandler(this.tbSeg1Sym_TextChanged);
            // 
            // rbGrf1Sym
            // 
            this.rbGrf1Sym.Location = new System.Drawing.Point(14, 26);
            this.rbGrf1Sym.Name = "rbGrf1Sym";
            this.rbGrf1Sym.Size = new System.Drawing.Size(181, 20);
            this.rbGrf1Sym.TabIndex = 0;
            this.rbGrf1Sym.Text = "Specify as &grapheme";
            this.rbGrf1Sym.CheckedChanged += new System.EventHandler(this.rbSeg1Sym_CheckedChanged);
            // 
            // labelGrf1
            // 
            this.labelGrf1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGrf1.Location = new System.Drawing.Point(14, 308);
            this.labelGrf1.Name = "labelGrf1";
            this.labelGrf1.Size = new System.Drawing.Size(99, 20);
            this.labelGrf1.TabIndex = 2;
            this.labelGrf1.Text = "Grapheme 1:";
            // 
            // labelFeat1
            // 
            this.labelFeat1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFeat1.Location = new System.Drawing.Point(14, 333);
            this.labelFeat1.Name = "labelFeat1";
            this.labelFeat1.Size = new System.Drawing.Size(85, 19);
            this.labelFeat1.TabIndex = 3;
            this.labelFeat1.Text = "Features:";
            // 
            // tbFeat1
            // 
            this.tbFeat1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbFeat1.Enabled = false;
            this.tbFeat1.Location = new System.Drawing.Point(110, 337);
            this.tbFeat1.Multiline = true;
            this.tbFeat1.Name = "tbFeat1";
            this.tbFeat1.ReadOnly = true;
            this.tbFeat1.Size = new System.Drawing.Size(86, 33);
            this.tbFeat1.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(586, 389);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 24;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(716, 389);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gbGrf2
            // 
            this.gbGrf2.Controls.Add(this.btnGrf2Add);
            this.gbGrf2.Controls.Add(this.btnGrf2Vwl);
            this.gbGrf2.Controls.Add(this.rbGrf2Vwl);
            this.gbGrf2.Controls.Add(this.btnGrf2Cns);
            this.gbGrf2.Controls.Add(this.rbGrf2Cns);
            this.gbGrf2.Controls.Add(this.tbGrf2Sym);
            this.gbGrf2.Controls.Add(this.rbGrf2Sym);
            this.gbGrf2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbGrf2.Location = new System.Drawing.Point(219, 40);
            this.gbGrf2.Name = "gbGrf2";
            this.gbGrf2.Size = new System.Drawing.Size(198, 254);
            this.gbGrf2.TabIndex = 6;
            this.gbGrf2.TabStop = false;
            this.gbGrf2.Text = "Grapheme 2";
            // 
            // btnGrf2Add
            // 
            this.btnGrf2Add.Enabled = false;
            this.btnGrf2Add.Location = new System.Drawing.Point(14, 216);
            this.btnGrf2Add.Name = "btnGrf2Add";
            this.btnGrf2Add.Size = new System.Drawing.Size(128, 32);
            this.btnGrf2Add.TabIndex = 6;
            this.btnGrf2Add.Text = "Add grapheme &2";
            this.btnGrf2Add.Click += new System.EventHandler(this.btnSeg2Add_Click);
            // 
            // btnGrf2Vwl
            // 
            this.btnGrf2Vwl.Enabled = false;
            this.btnGrf2Vwl.Location = new System.Drawing.Point(34, 171);
            this.btnGrf2Vwl.Name = "btnGrf2Vwl";
            this.btnGrf2Vwl.Size = new System.Drawing.Size(124, 32);
            this.btnGrf2Vwl.TabIndex = 5;
            this.btnGrf2Vwl.Text = "Choose &features";
            this.btnGrf2Vwl.Click += new System.EventHandler(this.btnSeg2Vwl_Click);
            // 
            // rbGrf2Vwl
            // 
            this.rbGrf2Vwl.Enabled = false;
            this.rbGrf2Vwl.Location = new System.Drawing.Point(14, 144);
            this.rbGrf2Vwl.Name = "rbGrf2Vwl";
            this.rbGrf2Vwl.Size = new System.Drawing.Size(171, 20);
            this.rbGrf2Vwl.TabIndex = 4;
            this.rbGrf2Vwl.Text = "Specify as &V";
            this.rbGrf2Vwl.Click += new System.EventHandler(this.rbSeg2Vwl_CheckedChanged);
            // 
            // btnGrf2Cns
            // 
            this.btnGrf2Cns.Enabled = false;
            this.btnGrf2Cns.Location = new System.Drawing.Point(34, 108);
            this.btnGrf2Cns.Name = "btnGrf2Cns";
            this.btnGrf2Cns.Size = new System.Drawing.Size(124, 32);
            this.btnGrf2Cns.TabIndex = 3;
            this.btnGrf2Cns.Text = "Choose &features";
            this.btnGrf2Cns.Click += new System.EventHandler(this.btnSeg2Cns_Click);
            // 
            // rbGrf2Cns
            // 
            this.rbGrf2Cns.Enabled = false;
            this.rbGrf2Cns.Location = new System.Drawing.Point(14, 85);
            this.rbGrf2Cns.Name = "rbGrf2Cns";
            this.rbGrf2Cns.Size = new System.Drawing.Size(171, 20);
            this.rbGrf2Cns.TabIndex = 2;
            this.rbGrf2Cns.Text = "Specify as &C";
            this.rbGrf2Cns.CheckedChanged += new System.EventHandler(this.rbSeg2Cns_CheckedChanged);
            // 
            // tbGrf2Sym
            // 
            this.tbGrf2Sym.Enabled = false;
            this.tbGrf2Sym.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGrf2Sym.Location = new System.Drawing.Point(34, 53);
            this.tbGrf2Sym.Name = "tbGrf2Sym";
            this.tbGrf2Sym.Size = new System.Drawing.Size(65, 21);
            this.tbGrf2Sym.TabIndex = 1;
            this.tbGrf2Sym.TextChanged += new System.EventHandler(this.tbSeg2Sym_TextChanged);
            // 
            // rbGrf2Sym
            // 
            this.rbGrf2Sym.Enabled = false;
            this.rbGrf2Sym.Location = new System.Drawing.Point(14, 26);
            this.rbGrf2Sym.Name = "rbGrf2Sym";
            this.rbGrf2Sym.Size = new System.Drawing.Size(181, 20);
            this.rbGrf2Sym.TabIndex = 0;
            this.rbGrf2Sym.Text = "Specify as &grapheme";
            this.rbGrf2Sym.CheckedChanged += new System.EventHandler(this.rbSeg2Sym_CheckedChanged);
            // 
            // gbGrf3
            // 
            this.gbGrf3.Controls.Add(this.btnGrf3Add);
            this.gbGrf3.Controls.Add(this.btnGrf3Vwl);
            this.gbGrf3.Controls.Add(this.rbGrf3Vwl);
            this.gbGrf3.Controls.Add(this.btnGrf3Cns);
            this.gbGrf3.Controls.Add(this.rbGrf3Cns);
            this.gbGrf3.Controls.Add(this.rbGrf3Sym);
            this.gbGrf3.Controls.Add(this.tbGrf3Sym);
            this.gbGrf3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbGrf3.Location = new System.Drawing.Point(425, 40);
            this.gbGrf3.Name = "gbGrf3";
            this.gbGrf3.Size = new System.Drawing.Size(197, 254);
            this.gbGrf3.TabIndex = 11;
            this.gbGrf3.TabStop = false;
            this.gbGrf3.Text = "Grapheme 3";
            // 
            // btnGrf3Add
            // 
            this.btnGrf3Add.Enabled = false;
            this.btnGrf3Add.Location = new System.Drawing.Point(14, 216);
            this.btnGrf3Add.Name = "btnGrf3Add";
            this.btnGrf3Add.Size = new System.Drawing.Size(128, 32);
            this.btnGrf3Add.TabIndex = 6;
            this.btnGrf3Add.Text = "Add grapheme &3";
            this.btnGrf3Add.Click += new System.EventHandler(this.btnSeg3Add_Click);
            // 
            // btnGrf3Vwl
            // 
            this.btnGrf3Vwl.Enabled = false;
            this.btnGrf3Vwl.Location = new System.Drawing.Point(34, 171);
            this.btnGrf3Vwl.Name = "btnGrf3Vwl";
            this.btnGrf3Vwl.Size = new System.Drawing.Size(124, 32);
            this.btnGrf3Vwl.TabIndex = 5;
            this.btnGrf3Vwl.Text = "Choose &features";
            this.btnGrf3Vwl.Click += new System.EventHandler(this.btnSeg3Vwl_Click);
            // 
            // rbGrf3Vwl
            // 
            this.rbGrf3Vwl.Enabled = false;
            this.rbGrf3Vwl.Location = new System.Drawing.Point(14, 144);
            this.rbGrf3Vwl.Name = "rbGrf3Vwl";
            this.rbGrf3Vwl.Size = new System.Drawing.Size(171, 20);
            this.rbGrf3Vwl.TabIndex = 4;
            this.rbGrf3Vwl.Text = "Specify as &V";
            this.rbGrf3Vwl.CheckedChanged += new System.EventHandler(this.rbSeg3Vwl_CheckedChanged);
            // 
            // btnGrf3Cns
            // 
            this.btnGrf3Cns.Enabled = false;
            this.btnGrf3Cns.Location = new System.Drawing.Point(34, 108);
            this.btnGrf3Cns.Name = "btnGrf3Cns";
            this.btnGrf3Cns.Size = new System.Drawing.Size(124, 32);
            this.btnGrf3Cns.TabIndex = 3;
            this.btnGrf3Cns.Text = "Choose &features";
            this.btnGrf3Cns.Click += new System.EventHandler(this.btnSeg3Cns_Click);
            // 
            // rbGrf3Cns
            // 
            this.rbGrf3Cns.Enabled = false;
            this.rbGrf3Cns.Location = new System.Drawing.Point(14, 84);
            this.rbGrf3Cns.Name = "rbGrf3Cns";
            this.rbGrf3Cns.Size = new System.Drawing.Size(171, 19);
            this.rbGrf3Cns.TabIndex = 2;
            this.rbGrf3Cns.Text = "Specify as &C";
            this.rbGrf3Cns.CheckedChanged += new System.EventHandler(this.rbSeg3Cns_CheckedChanged);
            // 
            // rbGrf3Sym
            // 
            this.rbGrf3Sym.Enabled = false;
            this.rbGrf3Sym.Location = new System.Drawing.Point(14, 26);
            this.rbGrf3Sym.Name = "rbGrf3Sym";
            this.rbGrf3Sym.Size = new System.Drawing.Size(181, 20);
            this.rbGrf3Sym.TabIndex = 0;
            this.rbGrf3Sym.Text = "Specify as &grapheme";
            this.rbGrf3Sym.CheckedChanged += new System.EventHandler(this.rbSeg3Sym_CheckedChanged);
            // 
            // tbGrf3Sym
            // 
            this.tbGrf3Sym.Enabled = false;
            this.tbGrf3Sym.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGrf3Sym.Location = new System.Drawing.Point(34, 53);
            this.tbGrf3Sym.Name = "tbGrf3Sym";
            this.tbGrf3Sym.Size = new System.Drawing.Size(65, 21);
            this.tbGrf3Sym.TabIndex = 1;
            this.tbGrf3Sym.TextChanged += new System.EventHandler(this.tbSeg3Sym_TextChanged);
            // 
            // gbGrf4
            // 
            this.gbGrf4.Controls.Add(this.btnGrf4Add);
            this.gbGrf4.Controls.Add(this.btnGrf4Vwl);
            this.gbGrf4.Controls.Add(this.rbGrf4Vwl);
            this.gbGrf4.Controls.Add(this.btnGrf4Cns);
            this.gbGrf4.Controls.Add(this.rbGrf4Cns);
            this.gbGrf4.Controls.Add(this.tbGrf4Sym);
            this.gbGrf4.Controls.Add(this.rbGrf4Sym);
            this.gbGrf4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbGrf4.Location = new System.Drawing.Point(631, 40);
            this.gbGrf4.Name = "gbGrf4";
            this.gbGrf4.Size = new System.Drawing.Size(197, 254);
            this.gbGrf4.TabIndex = 16;
            this.gbGrf4.TabStop = false;
            this.gbGrf4.Text = "Grapheme 4";
            // 
            // btnGrf4Add
            // 
            this.btnGrf4Add.Enabled = false;
            this.btnGrf4Add.Location = new System.Drawing.Point(14, 216);
            this.btnGrf4Add.Name = "btnGrf4Add";
            this.btnGrf4Add.Size = new System.Drawing.Size(128, 32);
            this.btnGrf4Add.TabIndex = 6;
            this.btnGrf4Add.Text = "Add grapheme &4";
            this.btnGrf4Add.Click += new System.EventHandler(this.btnSeg4Add_Click);
            // 
            // btnGrf4Vwl
            // 
            this.btnGrf4Vwl.Enabled = false;
            this.btnGrf4Vwl.Location = new System.Drawing.Point(34, 171);
            this.btnGrf4Vwl.Name = "btnGrf4Vwl";
            this.btnGrf4Vwl.Size = new System.Drawing.Size(124, 32);
            this.btnGrf4Vwl.TabIndex = 5;
            this.btnGrf4Vwl.Text = "Choose &features";
            this.btnGrf4Vwl.Click += new System.EventHandler(this.btnSeg4Vwl_Click);
            // 
            // rbGrf4Vwl
            // 
            this.rbGrf4Vwl.Enabled = false;
            this.rbGrf4Vwl.Location = new System.Drawing.Point(14, 144);
            this.rbGrf4Vwl.Name = "rbGrf4Vwl";
            this.rbGrf4Vwl.Size = new System.Drawing.Size(171, 20);
            this.rbGrf4Vwl.TabIndex = 4;
            this.rbGrf4Vwl.Text = "Specify as &V";
            this.rbGrf4Vwl.Click += new System.EventHandler(this.rbSeg4Vwl_CheckedChanged);
            // 
            // btnGrf4Cns
            // 
            this.btnGrf4Cns.Enabled = false;
            this.btnGrf4Cns.Location = new System.Drawing.Point(34, 108);
            this.btnGrf4Cns.Name = "btnGrf4Cns";
            this.btnGrf4Cns.Size = new System.Drawing.Size(124, 32);
            this.btnGrf4Cns.TabIndex = 3;
            this.btnGrf4Cns.Text = "Choose &features";
            this.btnGrf4Cns.Click += new System.EventHandler(this.btnSeg4Cns_Click);
            // 
            // rbGrf4Cns
            // 
            this.rbGrf4Cns.Enabled = false;
            this.rbGrf4Cns.Location = new System.Drawing.Point(14, 84);
            this.rbGrf4Cns.Name = "rbGrf4Cns";
            this.rbGrf4Cns.Size = new System.Drawing.Size(171, 19);
            this.rbGrf4Cns.TabIndex = 2;
            this.rbGrf4Cns.Text = "Specify as &C";
            this.rbGrf4Cns.CheckedChanged += new System.EventHandler(this.rbSeg4Cns_CheckedChanged);
            // 
            // tbGrf4Sym
            // 
            this.tbGrf4Sym.Enabled = false;
            this.tbGrf4Sym.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGrf4Sym.Location = new System.Drawing.Point(34, 53);
            this.tbGrf4Sym.Name = "tbGrf4Sym";
            this.tbGrf4Sym.Size = new System.Drawing.Size(65, 21);
            this.tbGrf4Sym.TabIndex = 1;
            this.tbGrf4Sym.TextChanged += new System.EventHandler(this.tbSeg4Sym_TextChanged);
            // 
            // rbGrf4Sym
            // 
            this.rbGrf4Sym.Enabled = false;
            this.rbGrf4Sym.Location = new System.Drawing.Point(14, 26);
            this.rbGrf4Sym.Name = "rbGrf4Sym";
            this.rbGrf4Sym.Size = new System.Drawing.Size(181, 20);
            this.rbGrf4Sym.TabIndex = 0;
            this.rbGrf4Sym.Text = "Spécifier comme graphème";
            this.rbGrf4Sym.CheckedChanged += new System.EventHandler(this.rbSeg4Sym_CheckedChanged);
            // 
            // tbFeat2
            // 
            this.tbFeat2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbFeat2.Enabled = false;
            this.tbFeat2.Location = new System.Drawing.Point(325, 333);
            this.tbFeat2.Multiline = true;
            this.tbFeat2.Name = "tbFeat2";
            this.tbFeat2.ReadOnly = true;
            this.tbFeat2.Size = new System.Drawing.Size(85, 33);
            this.tbFeat2.TabIndex = 10;
            // 
            // tbGrf2
            // 
            this.tbGrf2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbGrf2.Enabled = false;
            this.tbGrf2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGrf2.Location = new System.Drawing.Point(325, 308);
            this.tbGrf2.Name = "tbGrf2";
            this.tbGrf2.ReadOnly = true;
            this.tbGrf2.Size = new System.Drawing.Size(85, 14);
            this.tbGrf2.TabIndex = 9;
            // 
            // labelFeat2
            // 
            this.labelFeat2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFeat2.Location = new System.Drawing.Point(219, 333);
            this.labelFeat2.Name = "labelFeat2";
            this.labelFeat2.Size = new System.Drawing.Size(86, 19);
            this.labelFeat2.TabIndex = 8;
            this.labelFeat2.Text = "Features:";
            // 
            // labelGrf2
            // 
            this.labelGrf2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGrf2.Location = new System.Drawing.Point(219, 308);
            this.labelGrf2.Name = "labelGrf2";
            this.labelGrf2.Size = new System.Drawing.Size(99, 20);
            this.labelGrf2.TabIndex = 7;
            this.labelGrf2.Text = "Grapheme 2:";
            // 
            // tbFeat3
            // 
            this.tbFeat3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbFeat3.Enabled = false;
            this.tbFeat3.Location = new System.Drawing.Point(525, 333);
            this.tbFeat3.Multiline = true;
            this.tbFeat3.Name = "tbFeat3";
            this.tbFeat3.ReadOnly = true;
            this.tbFeat3.Size = new System.Drawing.Size(86, 33);
            this.tbFeat3.TabIndex = 15;
            // 
            // tbGrf3
            // 
            this.tbGrf3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbGrf3.Enabled = false;
            this.tbGrf3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGrf3.Location = new System.Drawing.Point(525, 308);
            this.tbGrf3.Name = "tbGrf3";
            this.tbGrf3.ReadOnly = true;
            this.tbGrf3.Size = new System.Drawing.Size(86, 14);
            this.tbGrf3.TabIndex = 14;
            // 
            // labelFeat3
            // 
            this.labelFeat3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFeat3.Location = new System.Drawing.Point(425, 333);
            this.labelFeat3.Name = "labelFeat3";
            this.labelFeat3.Size = new System.Drawing.Size(86, 19);
            this.labelFeat3.TabIndex = 13;
            this.labelFeat3.Text = "Features:";
            // 
            // labelGrf3
            // 
            this.labelGrf3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGrf3.Location = new System.Drawing.Point(425, 308);
            this.labelGrf3.Name = "labelGrf3";
            this.labelGrf3.Size = new System.Drawing.Size(99, 20);
            this.labelGrf3.TabIndex = 12;
            this.labelGrf3.Text = "Grapheme 3:";
            // 
            // tbFeat4
            // 
            this.tbFeat4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbFeat4.Enabled = false;
            this.tbFeat4.Location = new System.Drawing.Point(735, 333);
            this.tbFeat4.Multiline = true;
            this.tbFeat4.Name = "tbFeat4";
            this.tbFeat4.ReadOnly = true;
            this.tbFeat4.Size = new System.Drawing.Size(86, 33);
            this.tbFeat4.TabIndex = 20;
            // 
            // tbGrf4
            // 
            this.tbGrf4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbGrf4.Enabled = false;
            this.tbGrf4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGrf4.Location = new System.Drawing.Point(735, 308);
            this.tbGrf4.Name = "tbGrf4";
            this.tbGrf4.ReadOnly = true;
            this.tbGrf4.Size = new System.Drawing.Size(86, 14);
            this.tbGrf4.TabIndex = 19;
            // 
            // labelFeat4
            // 
            this.labelFeat4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFeat4.Location = new System.Drawing.Point(631, 333);
            this.labelFeat4.Name = "labelFeat4";
            this.labelFeat4.Size = new System.Drawing.Size(64, 19);
            this.labelFeat4.TabIndex = 18;
            this.labelFeat4.Text = "Features:";
            // 
            // labelGrf4
            // 
            this.labelGrf4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGrf4.Location = new System.Drawing.Point(631, 308);
            this.labelGrf4.Name = "labelGrf4";
            this.labelGrf4.Size = new System.Drawing.Size(98, 20);
            this.labelGrf4.TabIndex = 17;
            this.labelGrf4.Text = "Grapheme 4:";
            // 
            // btnSO
            // 
            this.btnSO.Location = new System.Drawing.Point(274, 389);
            this.btnSO.Name = "btnSO";
            this.btnSO.Size = new System.Drawing.Size(172, 32);
            this.btnSO.TabIndex = 23;
            this.btnSO.Text = "&Search Options";
            this.btnSO.Click += new System.EventHandler(this.btnSO_Click);
            // 
            // chkGraphemesTaught
            // 
            this.chkGraphemesTaught.AutoSize = true;
            this.chkGraphemesTaught.Location = new System.Drawing.Point(14, 381);
            this.chkGraphemesTaught.Name = "chkGraphemesTaught";
            this.chkGraphemesTaught.Size = new System.Drawing.Size(189, 19);
            this.chkGraphemesTaught.TabIndex = 21;
            this.chkGraphemesTaught.Text = "&Restrict to Graphemes Taught";
            this.chkGraphemesTaught.UseVisualStyleBackColor = true;
            // 
            // chkBrowseView
            // 
            this.chkBrowseView.AutoSize = true;
            this.chkBrowseView.Location = new System.Drawing.Point(14, 407);
            this.chkBrowseView.Name = "chkBrowseView";
            this.chkBrowseView.Size = new System.Drawing.Size(152, 19);
            this.chkBrowseView.TabIndex = 22;
            this.chkBrowseView.Text = "Display in &Browse View";
            this.chkBrowseView.UseVisualStyleBackColor = true;
            // 
            // tbGrf1
            // 
            this.tbGrf1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbGrf1.Enabled = false;
            this.tbGrf1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGrf1.Location = new System.Drawing.Point(110, 308);
            this.tbGrf1.Name = "tbGrf1";
            this.tbGrf1.ReadOnly = true;
            this.tbGrf1.Size = new System.Drawing.Size(65, 14);
            this.tbGrf1.TabIndex = 4;
            // 
            // FormAdvanced
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(837, 438);
            this.Controls.Add(this.chkBrowseView);
            this.Controls.Add(this.chkGraphemesTaught);
            this.Controls.Add(this.tbFeat4);
            this.Controls.Add(this.tbGrf4);
            this.Controls.Add(this.tbFeat3);
            this.Controls.Add(this.tbGrf3);
            this.Controls.Add(this.tbFeat2);
            this.Controls.Add(this.tbGrf2);
            this.Controls.Add(this.tbFeat1);
            this.Controls.Add(this.tbGrf1);
            this.Controls.Add(this.labelFeat4);
            this.Controls.Add(this.labelGrf4);
            this.Controls.Add(this.labelFeat3);
            this.Controls.Add(this.labelGrf3);
            this.Controls.Add(this.labelFeat2);
            this.Controls.Add(this.labelGrf2);
            this.Controls.Add(this.gbGrf4);
            this.Controls.Add(this.gbGrf3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labelFeat1);
            this.Controls.Add(this.labelGrf1);
            this.Controls.Add(this.gbGrf1);
            this.Controls.Add(this.labelDirections);
            this.Controls.Add(this.gbGrf2);
            this.Controls.Add(this.btnSO);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAdvanced";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Advanced Grapheme Search";
            this.gbGrf1.ResumeLayout(false);
            this.gbGrf1.PerformLayout();
            this.gbGrf2.ResumeLayout(false);
            this.gbGrf2.PerformLayout();
            this.gbGrf3.ResumeLayout(false);
            this.gbGrf3.PerformLayout();
            this.gbGrf4.ResumeLayout(false);
            this.gbGrf4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public string Sequence1Grapheme
        {
            get {return m_Sequence1Grf;}
        }

        public ConsonantFeatures Sequence1CnsFeatures
        {
            get {return m_Sequence1Cns;}
        }

        public VowelFeatures Sequence1VwlFeatures
        {
            get {return m_Sequence1Vwl;}
        }

		public string Sequence2Grapheme
        {
            get {return m_Sequence2Grf;}
        }

        public ConsonantFeatures Sequence2CnsFeatures
        {
            get {return m_Sequence2Cns;}
        }

        public VowelFeatures Sequence2VwlFeatures
        {
            get {return m_Sequence2Vwl;}
        }

		public string Sequence3Grapheme
        {
            get {return m_Sequence3Grf;}
        }

        public ConsonantFeatures Sequence3CnsFeatures
        {
            get {return m_Sequence3Cns;}
        }

        public VowelFeatures Sequence3VwlFeatures
        {
            get {return m_Sequence3Vwl;}
        }

		public string Sequence4Grapheme
        {
            get {return m_Sequence4Grf;}
        }

        public ConsonantFeatures Sequence4CnsFeatures
        {
            get {return m_Sequence4Cns;}
        }

        public VowelFeatures Sequence4VwlFeatures
        {
            get {return m_Sequence4Vwl;}
        }

        public bool UseGraphemesTaught
        {
            get { return m_UseGraphemesTaught; }
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
            m_UseGraphemesTaught = chkGraphemesTaught.Checked;
            m_BrowseView = chkBrowseView.Checked;
		}

        private void btnCancel_Click(object sender, System.EventArgs e)
		{
            m_UseGraphemesTaught = false;
            m_BrowseView = false;
            Form.ActiveForm.Close();
		}
        
		private void btnSO_Click(object sender, System.EventArgs e)
		{
            SearchOptions so = new SearchOptions(m_PSTable);
            CodeTable ct = (CodeTable) m_PSTable;
            //FormSearchOptions form = new FormSearchOptions(ct, true, false);
            FormSearchOptions form = new FormSearchOptions(ct, true, true,
                m_Table, m_Lang);
            DialogResult dr;
            dr = form.ShowDialog();
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

		private void rbSeg1Sym_CheckedChanged(object sender, System.EventArgs e)
		{
			tbGrf1Sym.Enabled = true;
			btnGrf1Cns.Enabled = false;
			btnGrf1Vwl.Enabled = false;
			btnGrf1Add.Enabled = true;
		}

		private void tbSeg1Sym_TextChanged(object sender, System.EventArgs e)
		{
            m_Sequence1Grf = tbGrf1Sym.Text;
		}

		private void rbSeg1Cns_CheckedChanged(object sender, System.EventArgs e)
		{
			ConsonantFeatures cf = new ConsonantFeatures();
			m_Sequence1Cns = cf;
			tbGrf1Sym.Enabled = false;
			tbGrf1Sym.Text = "";
			btnGrf1Cns.Enabled = true;
			btnGrf1Vwl.Enabled = false;
			btnGrf1Add.Enabled = true;
		}

		private void btnSeg1Cns_Click(object sender, System.EventArgs e)
		{
			ConsonantFeatures cf = new ConsonantFeatures();
            //FormConsonantFeatures form = new FormConsonantFeatures(cf);
            FormConsonantFeatures form = new FormConsonantFeatures(cf, m_Table, m_Lang);
            DialogResult dr = form.ShowDialog();
			if (dr == DialogResult.OK)
				m_Sequence1Cns = cf;
		}

		private void rbSeg1Vwl_CheckedChanged(object sender, System.EventArgs e)
		{
			VowelFeatures vf = new VowelFeatures();
			m_Sequence1Vwl = vf;
			tbGrf1Sym.Enabled = false;
			tbGrf1Sym.Text = "";
			btnGrf1Cns.Enabled = false;
			btnGrf1Vwl.Enabled = true;
			btnGrf1Add.Enabled = true;
		}

		private void btnSeg1Vwl_Click(object sender, System.EventArgs e)
		{
			VowelFeatures vf = new VowelFeatures();
            //FormVowelFeatures form = new FormVowelFeatures(vf);
            FormVowelFeatures form = new FormVowelFeatures(vf, m_Table, m_Lang);
			DialogResult dr = form.ShowDialog();
			if (dr == DialogResult.OK)
				m_Sequence1Vwl = vf;
		}

		private void btnSeg1Add_Click(object sender, System.EventArgs e)
		{
			bool flag = true;
			if (rbGrf1Sym.Checked)
			{
				if (tbGrf1Sym.Text == "")
				{
                    if (m_Table == null)
                        MessageBox.Show("You must enter a grapheme");
                    else MessageBox.Show(m_Table.GetMessage("FormAdvanced1", m_Lang));
                    flag = false;
				}
				else
				{
                    if (m_GI.IsInInventory(tbGrf1Sym.Text))
                    {
                        tbGrf1.Text = tbGrf1Sym.Text;
                        tbGrf1Sym.Enabled = false;
                    }
                    else
                    {
                        if (m_Table == null)
                            MessageBox.Show("Grapheme is not in inventory");
                        else MessageBox.Show(m_Table.GetMessage("FormAdvanced2", m_Lang));
                        flag = false;
                    }
				}
   			}
			else if (rbGrf1Cns.Checked)
			{
				tbGrf1.Text = "C";
				tbFeat1.Text = CnsFeatureList(m_Sequence1Cns);
				btnGrf1Cns.Enabled = false;
			}
			else if (rbGrf1Vwl.Checked)
			{
				tbGrf1.Text = "V";
				tbFeat1.Text = VwlFeatureList(m_Sequence1Vwl);
				btnGrf1Vwl.Enabled = false;
			}

			if (flag)
			{
				rbGrf1Sym.Enabled = false;
				rbGrf1Cns.Enabled = false;
				rbGrf1Vwl.Enabled = false;
				btnGrf1Add.Enabled = false;
				rbGrf2Sym.Enabled = true;
				rbGrf2Cns.Enabled = true;
				rbGrf2Vwl.Enabled = true;
				tbGrf1.Show();
			}
		}

		private void rbSeg2Sym_CheckedChanged(object sender, System.EventArgs e)
		{
			tbGrf2Sym.Enabled = true;
			btnGrf2Cns.Enabled = false;
			btnGrf2Vwl.Enabled = false;
			btnGrf2Add.Enabled = true;
		}

		private void tbSeg2Sym_TextChanged(object sender, System.EventArgs e)
		{

            m_Sequence2Grf = tbGrf2Sym.Text;		
		}

		private void rbSeg2Cns_CheckedChanged(object sender, System.EventArgs e)
		{
			ConsonantFeatures cf = new ConsonantFeatures();
			m_Sequence2Cns = cf;
			tbGrf2Sym.Enabled = false;
			tbGrf2Sym.Text = "";
			btnGrf2Cns.Enabled = true;
			btnGrf2Vwl.Enabled = false;
			btnGrf2Add.Enabled = true;
		}

		private void btnSeg2Cns_Click(object sender, System.EventArgs e)
		{
			ConsonantFeatures cf = new ConsonantFeatures();
            //FormConsonantFeatures form = new FormConsonantFeatures(cf);
            FormConsonantFeatures form = new FormConsonantFeatures(cf, m_Table, m_Lang);
			DialogResult dr = form.ShowDialog();
			if (dr == DialogResult.OK)
				m_Sequence2Cns = cf;
 		}

		private void rbSeg2Vwl_CheckedChanged(object sender, System.EventArgs e)
		{
			VowelFeatures vf = new VowelFeatures();
			m_Sequence2Vwl = vf;
			tbGrf2Sym.Enabled = false;
			tbGrf2Sym.Text = "";
			btnGrf2Cns.Enabled = false;
			btnGrf2Vwl.Enabled = true;
			btnGrf2Add.Enabled = true;
		}

		private void btnSeg2Vwl_Click(object sender, System.EventArgs e)
		{
			VowelFeatures vf = new VowelFeatures();
            //FormVowelFeatures form = new FormVowelFeatures(vf);
            FormVowelFeatures form = new FormVowelFeatures(vf, m_Table, m_Lang);
            DialogResult dr = form.ShowDialog();
			if (dr == DialogResult.OK)
				m_Sequence2Vwl = vf;
		}

		private void btnSeg2Add_Click(object sender, System.EventArgs e)
		{
			bool flag = true;
			if (rbGrf2Sym.Checked)
			{
				if (tbGrf2Sym.Text == "")
				{
                    if (m_Table == null)
                        MessageBox.Show("You must enter a grapheme");
                    else MessageBox.Show(m_Table.GetMessage("FormAdvanced1", m_Lang));
                    flag = false;
				}
				else
                {
                    if (m_GI.IsInInventory(tbGrf2Sym.Text))
				    {
   					    tbGrf2.Text = tbGrf2Sym.Text;
					    tbGrf2Sym.Enabled = false;
                    }
                    else
                    {
                        if (m_Table == null)
                            MessageBox.Show("Grapheme is not in inventory");
                        else MessageBox.Show(m_Table.GetMessage("FormAdvanced2", m_Lang));
                        flag = false;
                    }
				}
			}

			else if (rbGrf2Cns.Checked)
			{
				tbGrf2.Text = "C";
				tbFeat2.Text = CnsFeatureList(m_Sequence2Cns);
				btnGrf2Cns.Enabled = false;
			}

			else if (rbGrf2Vwl.Checked)
			{
				tbGrf2.Text = "V";
				tbFeat2.Text = VwlFeatureList(m_Sequence2Vwl);
				btnGrf2Vwl.Enabled = false;
			}

			if (flag)
			{
				rbGrf2Sym.Enabled = false;
				rbGrf2Cns.Enabled = false;
				rbGrf2Vwl.Enabled = false;
				btnGrf2Add.Enabled = false;
				rbGrf3Sym.Enabled = true;
				rbGrf3Cns.Enabled = true;
				rbGrf3Vwl.Enabled = true;
				tbGrf2.Show();
			}
		}

		private void rbSeg3Sym_CheckedChanged(object sender, System.EventArgs e)
		{
			tbGrf3Sym.Enabled = true;
			btnGrf3Cns.Enabled = false;
			btnGrf3Vwl.Enabled = false;
			btnGrf3Add.Enabled = true;
		}

		private void tbSeg3Sym_TextChanged(object sender, System.EventArgs e)
		{
            m_Sequence3Grf = tbGrf3Sym.Text;
		}

		private void rbSeg3Cns_CheckedChanged(object sender, System.EventArgs e)
		{
			ConsonantFeatures cf = new ConsonantFeatures();
			m_Sequence3Cns = cf;
			tbGrf3Sym.Enabled = false;
			tbGrf3Sym.Text = "";
			btnGrf3Cns.Enabled = true;
			btnGrf3Vwl.Enabled = false;
			btnGrf3Add.Enabled = true;
		}

		private void btnSeg3Cns_Click(object sender, System.EventArgs e)
		{
			ConsonantFeatures cf = new ConsonantFeatures();
            //FormConsonantFeatures form = new FormConsonantFeatures(cf);
            FormConsonantFeatures form = new FormConsonantFeatures(cf, m_Table, m_Lang);
			DialogResult dr = form.ShowDialog();
			if (dr == DialogResult.OK)
				m_Sequence3Cns = cf;
		}

		private void rbSeg3Vwl_CheckedChanged(object sender, System.EventArgs e)
		{
			VowelFeatures vf = new VowelFeatures();
			m_Sequence3Vwl = vf;
			tbGrf3Sym.Enabled = false;
			tbGrf3Sym.Text = "";
			btnGrf3Cns.Enabled = false;
			btnGrf3Vwl.Enabled = true;
			btnGrf3Add.Enabled = true;
		}

		private void btnSeg3Vwl_Click(object sender, System.EventArgs e)
		{
			VowelFeatures vf = new VowelFeatures();
            //FormVowelFeatures form = new FormVowelFeatures(vf);
            FormVowelFeatures form = new FormVowelFeatures(vf, m_Table, m_Lang);
            DialogResult dr = form.ShowDialog();
			if (dr == DialogResult.OK)
				m_Sequence3Vwl = vf;
		}

		private void btnSeg3Add_Click(object sender, System.EventArgs e)
		{
			bool flag = true;
			if (rbGrf3Sym.Checked)
			{
				if (tbGrf3Sym.Text == "")
				{
                    if (m_Table == null)
                        MessageBox.Show("You must enter a grapheme");
                    else MessageBox.Show(m_Table.GetMessage("FormAdvanced1", m_Lang));
                    flag = false;
                }
				else
				{
                    if (m_GI.IsInInventory(tbGrf3Sym.Text))
                    {
                        tbGrf3.Text = tbGrf3Sym.Text;
                        tbGrf3Sym.Enabled = false;
                    }
                    else
                    {
                        if (m_Table == null)
                            MessageBox.Show("Grapheme is not in inventory");
                        else MessageBox.Show(m_Table.GetMessage("FormAdvanced2", m_Lang));
                        flag = false;
                    }
 				}
			}

			else if (rbGrf3Cns.Checked)
			{
				tbGrf3.Text = "C";
				tbFeat3.Text = CnsFeatureList(m_Sequence3Cns);
				btnGrf3Cns.Enabled = false;
			}

			else if (rbGrf3Vwl.Checked)
			{
				tbGrf3.Text = "V";
				tbFeat3.Text = VwlFeatureList(m_Sequence3Vwl);
				btnGrf3Vwl.Enabled = false;
			}

			if (flag)
			{
				rbGrf3Sym.Enabled = false;
				rbGrf3Cns.Enabled = false;
				rbGrf3Vwl.Enabled = false;
				btnGrf3Add.Enabled = false;
				rbGrf4Sym.Enabled = true;
				rbGrf4Cns.Enabled = true;
				rbGrf4Vwl.Enabled = true;
				tbGrf3.Show();
			}
		}

		private void rbSeg4Sym_CheckedChanged(object sender, System.EventArgs e)
		{
			tbGrf4Sym.Enabled = true;
			btnGrf4Cns.Enabled = false;
			btnGrf4Vwl.Enabled = false;
			btnGrf4Add.Enabled = true;
		}

		private void tbSeg4Sym_TextChanged(object sender, System.EventArgs e)
		{
            m_Sequence4Grf = tbGrf4Sym.Text;		
		}

		private void rbSeg4Cns_CheckedChanged(object sender, System.EventArgs e)
		{
			ConsonantFeatures cf = new ConsonantFeatures();
			m_Sequence4Cns = cf;
			tbGrf4Sym.Enabled = false;
			tbGrf4Sym.Text = "";
			btnGrf4Cns.Enabled = true;
			btnGrf4Vwl.Enabled = false;
			btnGrf4Add.Enabled = true;
		}

		private void btnSeg4Cns_Click(object sender, System.EventArgs e)
		{
			ConsonantFeatures cf = new ConsonantFeatures();
            //FormConsonantFeatures form = new FormConsonantFeatures(cf);
            FormConsonantFeatures form = new FormConsonantFeatures(cf, m_Table, m_Lang);
            DialogResult dr = form.ShowDialog();
			if (dr == DialogResult.OK)
				m_Sequence4Cns = cf;
		}

		private void rbSeg4Vwl_CheckedChanged(object sender, System.EventArgs e)
		{
			VowelFeatures vf = new VowelFeatures();
			m_Sequence4Vwl = vf;
			tbGrf4Sym.Enabled = false;
			tbGrf4Sym.Text = "";
			btnGrf4Cns.Enabled = false;
			btnGrf4Vwl.Enabled = true;
			btnGrf4Add.Enabled = true;
		}

		private void btnSeg4Vwl_Click(object sender, System.EventArgs e)
		{
			VowelFeatures vf = new VowelFeatures();
            //FormVowelFeatures form = new FormVowelFeatures(vf);
            FormVowelFeatures form = new FormVowelFeatures(vf, m_Table, m_Lang);
            DialogResult dr = form.ShowDialog();
			if (dr == DialogResult.OK)
				m_Sequence4Vwl = vf;
		}

		private void btnSeg4Add_Click(object sender, System.EventArgs e)
		{
			bool flag = true;
			if (rbGrf4Sym.Checked)
			{
				if (tbGrf4Sym.Text == "")
				{
                    if (m_Table == null)
                        MessageBox.Show("You must enter a grapheme");
                    else MessageBox.Show(m_Table.GetMessage("FormAdvanced1", m_Lang));
                    flag = false;
                }
				else
				{
                    if (m_GI.IsInInventory(tbGrf4Sym.Text))
                    {
                        tbGrf4.Text = tbGrf4Sym.Text;
                        tbGrf4Sym.Enabled = false;
                    }
                    else
                    {
                        if (m_Table == null)
                            MessageBox.Show("Grapheme is not in inventory");
                        else MessageBox.Show(m_Table.GetMessage("FormAdvanced2", m_Lang));
                        flag = false;
                    }
 				}
			}

			else if (rbGrf4Cns.Checked)
			{
				tbGrf4.Text = "C";
				tbFeat4.Text = CnsFeatureList(m_Sequence4Cns);
				btnGrf4Cns.Enabled = false;
			}

			else if (rbGrf4Vwl.Checked)
			{
				tbGrf4.Text = "V";
				tbFeat4.Text = VwlFeatureList(m_Sequence4Vwl);
				btnGrf4Vwl.Enabled = false;
			}

			if (flag)
			{
				rbGrf4Sym.Enabled = false;
				rbGrf4Cns.Enabled = false;
				rbGrf4Vwl.Enabled = false;
				btnGrf4Add.Enabled = false;
				tbGrf4.Show();
			}
		}

		private string CnsFeatureList(ConsonantFeatures cf)
		{
			string strList = "";
			if (cf.PointOfArticulation != "")
                strList += cf.PointOfArticulation + Constants.Space;
			if (cf.MannerOfArticulation != "")
                strList += cf.MannerOfArticulation + Constants.Space;
			if (cf.Voiced)
                strList += ConsonantFeatures.kVoiced + Constants.Space;
            if (cf.Voiceless)
                strList += ConsonantFeatures.kVoiceless + Constants.Space;
            if (cf.Prenasalized)
                strList += ConsonantFeatures.kPrenasalized + Constants.Space;
			if (cf.Labialized)
                strList += ConsonantFeatures.kLabialized + Constants.Space;
			if (cf.Palatalized)
                strList += ConsonantFeatures.kPalatalized + Constants.Space;
			if (cf.Velarized)
                strList += ConsonantFeatures.kVelarized + Constants.Space;
			if (cf.Syllabic)
                strList += ConsonantFeatures.kSyllabic + Constants.Space;
            if (cf.Aspirated)
                strList += ConsonantFeatures.kAspirated + Constants.Space;
            if (cf.Long)
                strList += ConsonantFeatures.kLong + Constants.Space;
            if (cf.Glottalized)
                strList += ConsonantFeatures.kGlottalized + Constants.Space;
            if (cf.Combination)
                strList += ConsonantFeatures.kCombination + Constants.Space;
            strList = strList.Trim();
			return strList;
		}

		private string VwlFeatureList(VowelFeatures vf)
		{
			string strList = "";
			if (vf.Backness != "")
                strList += vf.Backness + Constants.Space;
			if (vf.Height != "")
                strList += vf.Height + Constants.Space;
			if (vf.Round)
                strList += VowelFeatures.kRound + Constants.Space;
			if (vf.PlusAtr)
                strList += VowelFeatures.kPlusAtr + Constants.Space;
			if (vf.Long)
                strList += VowelFeatures.kLong + Constants.Space;
			if (vf.Nasal)
                strList += VowelFeatures.kNasal + Constants.Space;
            if (vf.Diphthong)
                strList += VowelFeatures.kDipthong + Constants.Space;
            if (vf.Voiceless)
                strList += VowelFeatures.kVoiceless + Constants.Space;
			strList = strList.Trim();
			return strList;
		}

	}
}

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
	/// Summary description for FormCooccurrenceChart.
	/// </summary>
	public class FormCooccurrenceChart : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnSearchOptions;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.GroupBox gbSeg1;
		private System.Windows.Forms.Label labSeg1;
		private System.Windows.Forms.Button btnFeatures1;
		private System.Windows.Forms.RadioButton rbV1;
		private System.Windows.Forms.RadioButton rbC1;
		private System.Windows.Forms.GroupBox gbSeg2;
		private System.Windows.Forms.Label labSeg2;
		private System.Windows.Forms.RadioButton rbV2;
		private System.Windows.Forms.Button btnFeatures2;
		private System.Windows.Forms.RadioButton rbC2;
        private RadioButton rbS1;
        private RadioButton rbS2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        private ConsonantFeatures m_CFeatures1;
        private ConsonantFeatures m_CFeatures2;
        private VowelFeatures m_VFeatures1;
        private VowelFeatures m_VFeatures2;
        private SyllographFeatures m_SFeatures1;
        private SyllographFeatures m_SFeatures2;
        private SearchOptions m_SearchOptions;
        private PSTable m_PSTable;
        private GraphemeInventory m_GI;
        private Font m_Fnt;
        private LocalizationTable m_Table;      //Localization table
        private string m_Lang;                  //UI language

		public FormCooccurrenceChart(PSTable pstable, GraphemeInventory gi, Font fnt)
		{
			InitializeComponent();
            m_PSTable = pstable;
            m_GI = gi;
            m_Fnt = fnt;
            m_Table = null;
            m_Lang = "";
			this.rbC1.Checked = true;
			this.rbC2.Checked = true;
		}

        public FormCooccurrenceChart(PSTable pstable, GraphemeInventory gi, Font fnt, LocalizationTable table, string lang)
        {
            InitializeComponent();
            m_PSTable = pstable;
            m_GI = gi;
            m_Fnt = fnt;
            m_Table = table;
            m_Lang = lang;
            this.rbC1.Checked = true;
            this.rbC2.Checked = true;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCooccurrenceChart));
            this.btnSearchOptions = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.gbSeg1 = new System.Windows.Forms.GroupBox();
            this.rbS1 = new System.Windows.Forms.RadioButton();
            this.labSeg1 = new System.Windows.Forms.Label();
            this.rbV1 = new System.Windows.Forms.RadioButton();
            this.btnFeatures1 = new System.Windows.Forms.Button();
            this.rbC1 = new System.Windows.Forms.RadioButton();
            this.gbSeg2 = new System.Windows.Forms.GroupBox();
            this.rbS2 = new System.Windows.Forms.RadioButton();
            this.labSeg2 = new System.Windows.Forms.Label();
            this.rbV2 = new System.Windows.Forms.RadioButton();
            this.btnFeatures2 = new System.Windows.Forms.Button();
            this.rbC2 = new System.Windows.Forms.RadioButton();
            this.gbSeg1.SuspendLayout();
            this.gbSeg2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearchOptions
            // 
            this.btnSearchOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchOptions.Location = new System.Drawing.Point(21, 295);
            this.btnSearchOptions.Name = "btnSearchOptions";
            this.btnSearchOptions.Size = new System.Drawing.Size(160, 32);
            this.btnSearchOptions.TabIndex = 2;
            this.btnSearchOptions.Text = "&Search Options";
            this.btnSearchOptions.Click += new System.EventHandler(this.btnSearchOptions_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(325, 295);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(201, 295);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // gbSeg1
            // 
            this.gbSeg1.Controls.Add(this.rbS1);
            this.gbSeg1.Controls.Add(this.labSeg1);
            this.gbSeg1.Controls.Add(this.rbV1);
            this.gbSeg1.Controls.Add(this.btnFeatures1);
            this.gbSeg1.Controls.Add(this.rbC1);
            this.gbSeg1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSeg1.Location = new System.Drawing.Point(21, 13);
            this.gbSeg1.Name = "gbSeg1";
            this.gbSeg1.Size = new System.Drawing.Size(390, 122);
            this.gbSeg1.TabIndex = 0;
            this.gbSeg1.TabStop = false;
            this.gbSeg1.Text = "Define first grapheme class - list vertically";
            // 
            // rbS1
            // 
            this.rbS1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbS1.Location = new System.Drawing.Point(34, 97);
            this.rbS1.Name = "rbS1";
            this.rbS1.Size = new System.Drawing.Size(35, 20);
            this.rbS1.TabIndex = 3;
            this.rbS1.Text = "&S";
            this.rbS1.CheckedChanged += new System.EventHandler(this.rbS1_CheckedChanged);
            // 
            // labSeg1
            // 
            this.labSeg1.Location = new System.Drawing.Point(27, 26);
            this.labSeg1.Name = "labSeg1";
            this.labSeg1.Size = new System.Drawing.Size(226, 19);
            this.labSeg1.TabIndex = 0;
            this.labSeg1.Text = "Specify as C or V or S";
            // 
            // rbV1
            // 
            this.rbV1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbV1.Location = new System.Drawing.Point(34, 72);
            this.rbV1.Name = "rbV1";
            this.rbV1.Size = new System.Drawing.Size(35, 20);
            this.rbV1.TabIndex = 2;
            this.rbV1.Text = "&V";
            this.rbV1.CheckedChanged += new System.EventHandler(this.rbV1_CheckedChanged);
            // 
            // btnFeatures1
            // 
            this.btnFeatures1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFeatures1.Location = new System.Drawing.Point(96, 59);
            this.btnFeatures1.Name = "btnFeatures1";
            this.btnFeatures1.Size = new System.Drawing.Size(171, 32);
            this.btnFeatures1.TabIndex = 4;
            this.btnFeatures1.Text = "Choose &features";
            this.btnFeatures1.Click += new System.EventHandler(this.btnFeatures1_Click);
            // 
            // rbC1
            // 
            this.rbC1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbC1.Location = new System.Drawing.Point(34, 46);
            this.rbC1.Name = "rbC1";
            this.rbC1.Size = new System.Drawing.Size(35, 20);
            this.rbC1.TabIndex = 1;
            this.rbC1.Text = "&C";
            this.rbC1.CheckedChanged += new System.EventHandler(this.rbC1_CheckedChanged);
            // 
            // gbSeg2
            // 
            this.gbSeg2.Controls.Add(this.rbS2);
            this.gbSeg2.Controls.Add(this.labSeg2);
            this.gbSeg2.Controls.Add(this.rbV2);
            this.gbSeg2.Controls.Add(this.btnFeatures2);
            this.gbSeg2.Controls.Add(this.rbC2);
            this.gbSeg2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSeg2.Location = new System.Drawing.Point(21, 149);
            this.gbSeg2.Name = "gbSeg2";
            this.gbSeg2.Size = new System.Drawing.Size(390, 129);
            this.gbSeg2.TabIndex = 1;
            this.gbSeg2.TabStop = false;
            this.gbSeg2.Text = "Define second grapheme class - list horizontally";
            // 
            // rbS2
            // 
            this.rbS2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbS2.Location = new System.Drawing.Point(34, 101);
            this.rbS2.Name = "rbS2";
            this.rbS2.Size = new System.Drawing.Size(35, 20);
            this.rbS2.TabIndex = 3;
            this.rbS2.Text = "&S";
            this.rbS2.CheckedChanged += new System.EventHandler(this.rbS2_CheckedChanged);
            // 
            // labSeg2
            // 
            this.labSeg2.Location = new System.Drawing.Point(27, 26);
            this.labSeg2.Name = "labSeg2";
            this.labSeg2.Size = new System.Drawing.Size(226, 19);
            this.labSeg2.TabIndex = 0;
            this.labSeg2.Text = "Specify as C or V or S";
            // 
            // rbV2
            // 
            this.rbV2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbV2.Location = new System.Drawing.Point(34, 72);
            this.rbV2.Name = "rbV2";
            this.rbV2.Size = new System.Drawing.Size(35, 20);
            this.rbV2.TabIndex = 2;
            this.rbV2.Text = "&V";
            this.rbV2.CheckedChanged += new System.EventHandler(this.rbV2_CheckedChanged);
            // 
            // btnFeatures2
            // 
            this.btnFeatures2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFeatures2.Location = new System.Drawing.Point(96, 59);
            this.btnFeatures2.Name = "btnFeatures2";
            this.btnFeatures2.Size = new System.Drawing.Size(171, 32);
            this.btnFeatures2.TabIndex = 4;
            this.btnFeatures2.Text = "Choose &features";
            this.btnFeatures2.Click += new System.EventHandler(this.btnFeatures2_Click);
            // 
            // rbC2
            // 
            this.rbC2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbC2.Location = new System.Drawing.Point(34, 46);
            this.rbC2.Name = "rbC2";
            this.rbC2.Size = new System.Drawing.Size(35, 20);
            this.rbC2.TabIndex = 1;
            this.rbC2.Text = "&C";
            this.rbC2.CheckedChanged += new System.EventHandler(this.rbC2_CheckedChanged);
            // 
            // FormCooccurrenceChart
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(466, 355);
            this.Controls.Add(this.gbSeg2);
            this.Controls.Add(this.gbSeg1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnSearchOptions);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCooccurrenceChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Co-occurrence Chart Search";
            this.gbSeg1.ResumeLayout(false);
            this.gbSeg2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        public ConsonantFeatures CnsFeatures1
        {
            get { return m_CFeatures1; }
        }

        public ConsonantFeatures CnsFeatures2
        {
            get { return m_CFeatures2; }
        }

        public VowelFeatures VwlFeatures1
        {
            get { return m_VFeatures1; }
        }

        public VowelFeatures VwlFeatures2
        {
            get { return m_VFeatures2; }
        }

        public SyllographFeatures SyllFeatures1
        {
            get { return m_SFeatures1; }
        }

        public SyllographFeatures SyllFeatures2
        {
            get { return m_SFeatures2; }
        }
        
        public SearchOptions SearchOptions
        {
            get { return m_SearchOptions;}
        }
        
        private void btnOK_Click(object sender, System.EventArgs e)
		{
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

		private void rbC1_CheckedChanged(object sender, System.EventArgs e)
		{
			m_CFeatures1 = new ConsonantFeatures();
			m_VFeatures1 = null;
            m_SFeatures1 = null;;
			btnFeatures1.Enabled = true;
		}

		private void rbV1_CheckedChanged(object sender, System.EventArgs e)
		{
            m_VFeatures1 = new VowelFeatures();
			m_CFeatures1 = null;
            m_SFeatures1 = null;;
			btnFeatures1.Enabled = true;
		}

        private void rbS1_CheckedChanged(object sender, EventArgs e)
        {
            m_SFeatures1 = new SyllographFeatures();;
            m_CFeatures1 = null;
            m_VFeatures1 = null;
            btnFeatures1.Enabled = true;
        }

        private void btnFeatures1_Click(object sender, System.EventArgs e)
		{
			if (rbC1.Checked)
			{
				ConsonantFeatures cf = new ConsonantFeatures();
                //FormConsonantFeatures form = new FormConsonantFeatures(cf);
                FormConsonantFeatures form = new FormConsonantFeatures(cf, m_Table);

				if (form.ShowDialog() == DialogResult.OK)
					m_CFeatures1 = form.Features;
			}

			if (rbV1.Checked)
			{
				VowelFeatures vf = new VowelFeatures();
                //FormVowelFeatures form = new FormVowelFeatures(vf);
                FormVowelFeatures form = new FormVowelFeatures(vf, m_Table);
                if (form.ShowDialog() == DialogResult.OK)
					m_VFeatures1 = form.Features;
			}

            if (rbS1.Checked)
            {
                SyllographFeatures sf = new SyllographFeatures();
                FormSyllographFeatures form = new FormSyllographFeatures(sf, m_GI, m_Fnt, m_Table);
                if (form.ShowDialog() == DialogResult.OK)
                    m_SFeatures1 = form.Features;
            }
		}

		private void rbC2_CheckedChanged(object sender, System.EventArgs e)
		{
			m_CFeatures2 = new ConsonantFeatures();
			m_VFeatures2 = null;
            m_SFeatures2 = null;;
			btnFeatures2.Enabled = true;
		}

		private void rbV2_CheckedChanged(object sender, System.EventArgs e)
		{
			m_VFeatures2 = new VowelFeatures();
			m_CFeatures2 = null;
            m_SFeatures2 = null;;
			btnFeatures2.Enabled = true;
		}

        private void rbS2_CheckedChanged(object sender, EventArgs e)
        {
            m_SFeatures2 = new SyllographFeatures();
            m_VFeatures2 = null;
            m_CFeatures2 = null;
            btnFeatures2.Enabled = true;
        }

        private void btnFeatures2_Click(object sender, System.EventArgs e)
		{
			if (rbC2.Checked)
			{
				ConsonantFeatures cf = new ConsonantFeatures();
                //FormConsonantFeatures form = new FormConsonantFeatures(cf);
                FormConsonantFeatures form = new FormConsonantFeatures(cf, m_Table);
                if (form.ShowDialog() == DialogResult.OK)
                    m_CFeatures2 = form.Features;
                        ;
			}

			if (rbV2.Checked)
			{
				VowelFeatures vf = new VowelFeatures();
                //FormVowelFeatures form = new FormVowelFeatures(vf);
                FormVowelFeatures form = new FormVowelFeatures(vf, m_Table);
                if (form.ShowDialog() == DialogResult.OK)
                    m_VFeatures2 = form.Features; ;
			}

            if (rbS2.Checked)
            {
                SyllographFeatures sf = new SyllographFeatures();
                FormSyllographFeatures form = new FormSyllographFeatures(sf, m_GI, m_Fnt, m_Table);
                if (form.ShowDialog() == DialogResult.OK)
                    m_SFeatures2 = form.Features;
            }
		}

        private void UpdateFormForLocalization(LocalizationTable table)
        {
            string strText = "";
            strText = table.GetForm("FormCooccurrenceChartT");
			if (strText != "")
				this.Text = strText;
            strText = table.GetForm("FormCooccurrenceChart0");
			if (strText != "")
				this.gbSeg1.Text = strText;
            strText = table.GetForm("FormCooccurrenceChartF0");
			if (strText != "")
				this.labSeg1.Text = strText;
            strText = table.GetForm("FormCooccurrenceChartF1");
			if (strText != "")
				this.rbC1.Text = strText;
            strText = table.GetForm("FormCooccurrenceChartF2");
			if (strText != "")
				this.rbV1.Text = strText;
            strText = table.GetForm("FormCooccurrenceChartF3");
			if (strText != "")
				this.btnFeatures1.Text = strText;
            strText = table.GetForm("FormCooccurrenceChartF4");
			if (strText != "")
				this.rbS1.Text = strText;
            strText = table.GetForm("FormCooccurrenceChart1");
			if (strText != "")
				this.gbSeg2.Text = strText;
            strText = table.GetForm("FormCooccurrenceChartS0");
			if (strText != "")
				this.labSeg2.Text = strText;
            strText = table.GetForm("FormCooccurrenceChartS1");
			if (strText != "")
				this.rbC2.Text = strText;
            strText = table.GetForm("FormCooccurrenceChartS2");
			if (strText != "")
				this.rbV2.Text = strText;
            strText = table.GetForm("FormCooccurrenceChartS3");
			if (strText != "")
				this.btnFeatures2.Text = strText;
            strText = table.GetForm("FormCooccurrenceChartS4");
			if (strText != "")
				this.rbS2.Text = strText;
            strText = table.GetForm("FormCooccurrenceChart2");
			if (strText != "")
				this.btnSearchOptions.Text = strText;
            strText = table.GetForm("FormCooccurrenceChart3");
			if (strText != "")
				this.btnOK.Text = strText;
            strText = table.GetForm("FormCooccurrenceChart4");
			if (strText != "")
				this.btnCancel.Text = strText;
            return;
        }

    }
}

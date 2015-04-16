using System;
using System.ComponentModel;
using System.Windows.Forms;
using PrimerProLocalization;

namespace PrimerProForms
{
	/// <summary>
	/// Summary description for FormSyllableChart.
	/// </summary>
	public class FormSyllableChart : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.RadioButton rbRoots;
		private System.Windows.Forms.RadioButton rbWords;
		private System.Windows.Forms.Label labInfo;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.GroupBox gbType;

        private StructureType m_Type;
		public enum StructureType {Word, Root};

        public FormSyllableChart()
		{
			InitializeComponent();
			rbWords.Checked = true;
		}

        public FormSyllableChart(LocalizationTable table, string lang)
        {
            InitializeComponent();
            rbWords.Checked = true;

            this.Text = table.GetForm("FormSyllableChartT", lang);
            this.labInfo.Text = table.GetForm("FormSyllableChart0", lang);
            this.gbType.Text = table.GetForm("FormSyllableChart1", lang);
            this.rbWords.Text = table.GetForm("FormSyllableChart2", lang);
            this.rbRoots.Text = table.GetForm("FormSyllableChart3", lang);
            this.btnOK.Text = table.GetForm("FormSyllableChart4", lang);
            this.btnCancel.Text = table.GetForm("FormSyllableChart5", lang);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSyllableChart));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rbRoots = new System.Windows.Forms.RadioButton();
            this.rbWords = new System.Windows.Forms.RadioButton();
            this.labInfo = new System.Windows.Forms.Label();
            this.gbType = new System.Windows.Forms.GroupBox();
            this.gbType.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(157, 152);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(277, 152);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rbRoots
            // 
            this.rbRoots.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbRoots.Location = new System.Drawing.Point(151, 24);
            this.rbRoots.Name = "rbRoots";
            this.rbRoots.Size = new System.Drawing.Size(80, 24);
            this.rbRoots.TabIndex = 3;
            this.rbRoots.Text = "&Roots";
            // 
            // rbWords
            // 
            this.rbWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbWords.Location = new System.Drawing.Point(64, 96);
            this.rbWords.Name = "rbWords";
            this.rbWords.Size = new System.Drawing.Size(80, 24);
            this.rbWords.TabIndex = 2;
            this.rbWords.Text = "&Words";
            // 
            // labInfo
            // 
            this.labInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfo.Location = new System.Drawing.Point(19, 24);
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(446, 45);
            this.labInfo.TabIndex = 0;
            this.labInfo.Text = "Generate a syllable chart for the specified type below";
            // 
            // gbType
            // 
            this.gbType.Controls.Add(this.rbRoots);
            this.gbType.Location = new System.Drawing.Point(40, 72);
            this.gbType.Name = "gbType";
            this.gbType.Size = new System.Drawing.Size(294, 64);
            this.gbType.TabIndex = 1;
            this.gbType.TabStop = false;
            this.gbType.Text = "Type";
            // 
            // FormSyllableChart
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(482, 203);
            this.Controls.Add(this.labInfo);
            this.Controls.Add(this.rbWords);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbType);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSyllableChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Syllable Chart Search";
            this.gbType.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        public StructureType Type
        {
            get { return m_Type; }
        }

        private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (this.rbRoots.Checked)
				m_Type = StructureType.Root;
			else m_Type = StructureType.Word;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			m_Type = StructureType.Word;
		}
	}
}

using System;
using System.ComponentModel;
using System.Windows.Forms;
using PrimerProLocalization;

namespace PrimerProForms
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FormConsonantChart : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label labDflt;
		private System.Windows.Forms.CheckBox ckPrenasalized;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.CheckBox ckSyllabic;
		private System.Windows.Forms.CheckBox ckLabialized;
		private System.Windows.Forms.CheckBox ckPalatalized;
		private System.Windows.Forms.CheckBox ckVelarized;
		private System.ComponentModel.Container components = null;
        private CheckBox ckAspirated;
        private CheckBox ckLong;
        private CheckBox ckGlottalized;
        private CheckBox ckCombination;

        //private ConsonantChartSearch m_Search;
        private bool m_Palatalized;
        private bool m_Labialized;
        private bool m_Velarized;
        private bool m_Prenasalized;
        private bool m_Syllabic;
        private bool m_Aspirated;
        private bool m_Long;
        private bool m_Glottalized;
        private bool m_Combination;

		public FormConsonantChart()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

        public FormConsonantChart(LocalizationTable table)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConsonantChart));
            this.labDflt = new System.Windows.Forms.Label();
            this.ckPrenasalized = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ckSyllabic = new System.Windows.Forms.CheckBox();
            this.ckLabialized = new System.Windows.Forms.CheckBox();
            this.ckPalatalized = new System.Windows.Forms.CheckBox();
            this.ckVelarized = new System.Windows.Forms.CheckBox();
            this.ckAspirated = new System.Windows.Forms.CheckBox();
            this.ckLong = new System.Windows.Forms.CheckBox();
            this.ckGlottalized = new System.Windows.Forms.CheckBox();
            this.ckCombination = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labDflt
            // 
            this.labDflt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDflt.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.labDflt.Location = new System.Drawing.Point(16, 16);
            this.labDflt.Name = "labDflt";
            this.labDflt.Size = new System.Drawing.Size(464, 23);
            this.labDflt.TabIndex = 0;
            this.labDflt.Text = "The default chart displays only simple consonants.";
            this.labDflt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ckPrenasalized
            // 
            this.ckPrenasalized.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckPrenasalized.Location = new System.Drawing.Point(48, 184);
            this.ckPrenasalized.Name = "ckPrenasalized";
            this.ckPrenasalized.Size = new System.Drawing.Size(120, 24);
            this.ckPrenasalized.TabIndex = 4;
            this.ckPrenasalized.Text = "Pre&nasalized";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(241, 238);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(380, 238);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ckSyllabic
            // 
            this.ckSyllabic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckSyllabic.Location = new System.Drawing.Point(208, 64);
            this.ckSyllabic.Name = "ckSyllabic";
            this.ckSyllabic.Size = new System.Drawing.Size(120, 24);
            this.ckSyllabic.TabIndex = 5;
            this.ckSyllabic.Text = "&Syllabic";
            // 
            // ckLabialized
            // 
            this.ckLabialized.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckLabialized.Location = new System.Drawing.Point(48, 104);
            this.ckLabialized.Name = "ckLabialized";
            this.ckLabialized.Size = new System.Drawing.Size(120, 24);
            this.ckLabialized.TabIndex = 2;
            this.ckLabialized.Text = "&Labialized";
            // 
            // ckPalatalized
            // 
            this.ckPalatalized.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckPalatalized.Location = new System.Drawing.Point(48, 64);
            this.ckPalatalized.Name = "ckPalatalized";
            this.ckPalatalized.Size = new System.Drawing.Size(104, 24);
            this.ckPalatalized.TabIndex = 1;
            this.ckPalatalized.Text = "&Palatalized";
            // 
            // ckVelarized
            // 
            this.ckVelarized.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckVelarized.Location = new System.Drawing.Point(48, 144);
            this.ckVelarized.Name = "ckVelarized";
            this.ckVelarized.Size = new System.Drawing.Size(120, 24);
            this.ckVelarized.TabIndex = 3;
            this.ckVelarized.Text = "&Velarized";
            // 
            // ckAspirated
            // 
            this.ckAspirated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckAspirated.Location = new System.Drawing.Point(208, 104);
            this.ckAspirated.Name = "ckAspirated";
            this.ckAspirated.Size = new System.Drawing.Size(120, 24);
            this.ckAspirated.TabIndex = 6;
            this.ckAspirated.Text = "&Aspirated";
            // 
            // ckLong
            // 
            this.ckLong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckLong.Location = new System.Drawing.Point(208, 144);
            this.ckLong.Name = "ckLong";
            this.ckLong.Size = new System.Drawing.Size(120, 24);
            this.ckLong.TabIndex = 7;
            this.ckLong.Text = "L&ong";
            // 
            // ckGlottalized
            // 
            this.ckGlottalized.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckGlottalized.Location = new System.Drawing.Point(208, 184);
            this.ckGlottalized.Name = "ckGlottalized";
            this.ckGlottalized.Size = new System.Drawing.Size(120, 24);
            this.ckGlottalized.TabIndex = 8;
            this.ckGlottalized.Text = "&Glottalized";
            // 
            // ckCombination
            // 
            this.ckCombination.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckCombination.Location = new System.Drawing.Point(360, 64);
            this.ckCombination.Name = "ckCombination";
            this.ckCombination.Size = new System.Drawing.Size(120, 24);
            this.ckCombination.TabIndex = 9;
            this.ckCombination.Text = "&Combination";
            this.ckCombination.CheckedChanged += new System.EventHandler(this.ckCombination_CheckedChanged);
            // 
            // FormConsonantChart
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 17);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(502, 282);
            this.Controls.Add(this.ckCombination);
            this.Controls.Add(this.ckGlottalized);
            this.Controls.Add(this.ckLong);
            this.Controls.Add(this.ckAspirated);
            this.Controls.Add(this.ckVelarized);
            this.Controls.Add(this.ckPalatalized);
            this.Controls.Add(this.ckLabialized);
            this.Controls.Add(this.ckSyllabic);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.ckPrenasalized);
            this.Controls.Add(this.labDflt);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormConsonantChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Consonant Chart Search";
            this.ResumeLayout(false);

		}
		#endregion

        public bool Palatalized
        {
            get { return m_Palatalized; }
        }

        public bool Labialized
        {
            get { return m_Labialized; }
        }

        public bool Velarized
        {
            get { return m_Velarized; }
        }

        public bool Prenasalized
        {
            get { return m_Prenasalized; }
        }

        public bool Syllabic
        {
            get { return m_Syllabic; }
        }

        public bool Aspirated
        {
            get { return m_Aspirated; }
        }

        public bool Long
        {
            get { return m_Long; }
        }

        public bool Glottalized
        {
            get { return m_Glottalized; }
        }

        public bool Combination
        {
            get { return m_Combination; }
        }
        
        private void btnOK_Click(object sender, System.EventArgs e)
		{
			m_Labialized = this.ckLabialized.Checked;
			m_Palatalized = this.ckPalatalized.Checked;
			m_Velarized = this.ckVelarized.Checked;
			m_Prenasalized = this.ckPrenasalized.Checked;
			m_Syllabic = this.ckSyllabic.Checked;
            m_Aspirated = this.ckAspirated.Checked;
            m_Long = this.ckLong.Checked;
            m_Glottalized = this.ckGlottalized.Checked;
            m_Combination = this.ckCombination.Checked;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			m_Labialized = false;
			m_Palatalized = false;
			m_Velarized = false;
			m_Prenasalized = false;
			m_Syllabic = false;
            m_Aspirated = false;
            m_Long = false;
            m_Glottalized = false;
            m_Combination = false;
		}

        private void ckCombination_CheckedChanged(object sender, EventArgs e)
        {
            if (ckCombination.Checked)
            {
                this.ckLabialized.Checked = false;
                this.ckPalatalized.Checked = false;
                this.ckVelarized.Checked = false;
                this.ckPrenasalized.Checked = false;
                this.ckSyllabic.Checked = false;
                this.ckAspirated.Checked = false;
                this.ckLong.Checked = false;
                this.ckGlottalized.Checked = false;
                this.ckLabialized.Enabled = false;
                this.ckPalatalized.Enabled = false;
                this.ckVelarized.Enabled = false;
                this.ckPrenasalized.Enabled = false;
                this.ckSyllabic.Enabled = false;
                this.ckAspirated.Enabled = false;
                this.ckLong.Enabled = false;
                this.ckGlottalized.Enabled = false;
            }
            else
            {
                this.ckLabialized.Enabled = true;
                this.ckPalatalized.Enabled = true;
                this.ckVelarized.Enabled = true;
                this.ckPrenasalized.Enabled = true;
                this.ckSyllabic.Enabled = true;
                this.ckAspirated.Enabled = true;
                this.ckLong.Enabled = true;
                this.ckGlottalized.Enabled = true;
            }
         }

        private void UpdateFormForLocalization(LocalizationTable table)
        {
            string strText = "";
            strText = table.GetForm("FormConsonantChartT");
			if (strText != "")
				this.Text = strText;
            strText = table.GetForm("FormConsonantChart0");
			if (strText != "")
				this.labDflt.Text = strText;
            strText = table.GetForm("FormConsonantChart1");
			if (strText != "")
				this.ckPalatalized.Text = strText;
            strText = table.GetForm("FormConsonantChart2");
			if (strText != "")
				this.ckLabialized.Text = strText;
            strText = table.GetForm("FormConsonantChart3");
			if (strText != "")
				this.ckVelarized.Text = strText;
            strText = table.GetForm("FormConsonantChart4");
			if (strText != "")
				this.ckPrenasalized.Text = strText;
            strText = table.GetForm("FormConsonantChart5");
			if (strText != "")
				this.ckSyllabic.Text = strText;
            strText = table.GetForm("FormConsonantChart6");
			if (strText != "")
				this.ckAspirated.Text = strText;
            strText = table.GetForm("FormConsonantChart7");
			if (strText != "")
				this.ckLong.Text = strText;
            strText = table.GetForm("FormConsonantChart8");
			if (strText != "")
				this.ckGlottalized.Text = strText;
            strText = table.GetForm("FormConsonantChart9");
			if (strText != "")
				this.ckCombination.Text = strText;
            strText = table.GetForm("FormConsonantChart10");
			if (strText != "")
				this.btnOK.Text = strText;
            strText = table.GetForm("FormConsonantChart11");
			if (strText != "")
				this.btnCancel.Text = strText; 
            return;
        }
	}
}

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using PrimerProLocalization;

namespace PrimerProForms
{
	/// <summary>
	/// Summary description for FormVowelChart.
	/// </summary>
	public class FormVowelChart : System.Windows.Forms.Form
	{
		private System.Windows.Forms.CheckBox ckNasal;
		private System.Windows.Forms.CheckBox ckLong;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label labDflt;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private CheckBox ckVoiceless;
        private CheckBox ckDiphthongs;

        private bool m_Nasal;
        private bool m_Long;
        private bool m_Voiceless;
        private bool m_Diphthong;

		public FormVowelChart()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

        public FormVowelChart(LocalizationTable table, string lang)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            this.Text = table.GetForm("FormVowelChartT", lang);
            this.labDflt.Text = table.GetForm("FormVowelChart0", lang);
            this.ckNasal.Text = table.GetForm("FormVowelChart1", lang);
            this.ckLong.Text = table.GetForm("FormVowelChart2", lang);
            this.ckVoiceless.Text = table.GetForm("FormVowelChart3", lang);
            this.ckDiphthongs.Text = table.GetForm("FormVowelChart4", lang);
            this.btnOK.Text = table.GetForm("FormVowelChart5", lang);
            this.btnCancel.Text = table.GetForm("FormVowelChart6", lang);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVowelChart));
            this.ckNasal = new System.Windows.Forms.CheckBox();
            this.ckLong = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.labDflt = new System.Windows.Forms.Label();
            this.ckVoiceless = new System.Windows.Forms.CheckBox();
            this.ckDiphthongs = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ckNasal
            // 
            this.ckNasal.AutoSize = true;
            this.ckNasal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckNasal.Location = new System.Drawing.Point(40, 56);
            this.ckNasal.Name = "ckNasal";
            this.ckNasal.Size = new System.Drawing.Size(118, 22);
            this.ckNasal.TabIndex = 1;
            this.ckNasal.Text = "&Nasal vowels";
            // 
            // ckLong
            // 
            this.ckLong.AutoSize = true;
            this.ckLong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckLong.Location = new System.Drawing.Point(208, 56);
            this.ckLong.Name = "ckLong";
            this.ckLong.Size = new System.Drawing.Size(113, 22);
            this.ckLong.TabIndex = 2;
            this.ckLong.Text = "&Long vowels";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(208, 170);
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
            this.btnCancel.Location = new System.Drawing.Point(340, 170);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labDflt
            // 
            this.labDflt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDflt.Location = new System.Drawing.Point(12, 16);
            this.labDflt.Name = "labDflt";
            this.labDflt.Size = new System.Drawing.Size(441, 24);
            this.labDflt.TabIndex = 0;
            this.labDflt.Text = "The default chart displays short oral vowels.";
            this.labDflt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ckVoiceless
            // 
            this.ckVoiceless.AutoSize = true;
            this.ckVoiceless.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckVoiceless.Location = new System.Drawing.Point(40, 106);
            this.ckVoiceless.Name = "ckVoiceless";
            this.ckVoiceless.Size = new System.Drawing.Size(119, 22);
            this.ckVoiceless.TabIndex = 3;
            this.ckVoiceless.Text = "&Voiceless vwl";
            // 
            // ckDiphthongs
            // 
            this.ckDiphthongs.AutoSize = true;
            this.ckDiphthongs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckDiphthongs.Location = new System.Drawing.Point(208, 106);
            this.ckDiphthongs.Name = "ckDiphthongs";
            this.ckDiphthongs.Size = new System.Drawing.Size(105, 22);
            this.ckDiphthongs.TabIndex = 4;
            this.ckDiphthongs.Text = "&Diphthongs";
            // 
            // FormVowelChart
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(465, 223);
            this.Controls.Add(this.ckVoiceless);
            this.Controls.Add(this.ckDiphthongs);
            this.Controls.Add(this.labDflt);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.ckLong);
            this.Controls.Add(this.ckNasal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormVowelChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vowel Chart Search";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        public bool Nasal
        {
            get { return m_Nasal; }
        }

        public bool Long
        {
            get { return m_Long; }
        }

        public bool Voiceless
        {
            get { return m_Voiceless; }
        }

        public bool Diphthong
        {
            get { return m_Diphthong; }
        }
                
        private void btnOK_Click(object sender, System.EventArgs e)
		{
			m_Long = this.ckLong.Checked;
			m_Nasal = this.ckNasal.Checked;
            m_Diphthong = this.ckDiphthongs.Checked;
            m_Voiceless = this.ckVoiceless.Checked;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			m_Nasal = false;
			m_Long = false;
            m_Diphthong = false;
            m_Voiceless = false;
		}

	}
}

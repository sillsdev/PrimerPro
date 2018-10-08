using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using PrimerProObjects;
using PrimerProLocalization;

namespace PrimerProForms
{
	/// <summary>
	/// Summary description for FormVowelInventory.
	/// </summary>
	public class FormVowelFeatures : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox gbBackness;
		private System.Windows.Forms.GroupBox gbHeight;
		private System.Windows.Forms.CheckBox ckRound;
		private System.Windows.Forms.CheckBox ckATR;
		private System.Windows.Forms.CheckBox ckLong;
		private System.Windows.Forms.CheckBox ckNasal;
		private System.Windows.Forms.RadioButton rbFront;
		private System.Windows.Forms.RadioButton rbCentral;
		private System.Windows.Forms.RadioButton rbBack;
		private System.Windows.Forms.RadioButton rbHigh;
		private System.Windows.Forms.RadioButton rbMid;
		private System.Windows.Forms.RadioButton rbLow;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.ComponentModel.Container components = null;
        private CheckBox ckVoiceless;
        private CheckBox ckDiphthong;

		private VowelFeatures m_Features;

		public FormVowelFeatures(VowelFeatures vf)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m_Features = vf;
		}

        public FormVowelFeatures(VowelFeatures vf, LocalizationTable table)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            m_Features = vf;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVowelFeatures));
            this.gbBackness = new System.Windows.Forms.GroupBox();
            this.rbBack = new System.Windows.Forms.RadioButton();
            this.rbCentral = new System.Windows.Forms.RadioButton();
            this.rbFront = new System.Windows.Forms.RadioButton();
            this.gbHeight = new System.Windows.Forms.GroupBox();
            this.rbLow = new System.Windows.Forms.RadioButton();
            this.rbMid = new System.Windows.Forms.RadioButton();
            this.rbHigh = new System.Windows.Forms.RadioButton();
            this.ckRound = new System.Windows.Forms.CheckBox();
            this.ckATR = new System.Windows.Forms.CheckBox();
            this.ckLong = new System.Windows.Forms.CheckBox();
            this.ckNasal = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.ckVoiceless = new System.Windows.Forms.CheckBox();
            this.ckDiphthong = new System.Windows.Forms.CheckBox();
            this.gbBackness.SuspendLayout();
            this.gbHeight.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbBackness
            // 
            this.gbBackness.Controls.Add(this.rbBack);
            this.gbBackness.Controls.Add(this.rbCentral);
            this.gbBackness.Controls.Add(this.rbFront);
            this.gbBackness.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBackness.Location = new System.Drawing.Point(20, 14);
            this.gbBackness.Name = "gbBackness";
            this.gbBackness.Size = new System.Drawing.Size(167, 97);
            this.gbBackness.TabIndex = 0;
            this.gbBackness.TabStop = false;
            this.gbBackness.Text = "Backness Feature";
            // 
            // rbBack
            // 
            this.rbBack.AutoSize = true;
            this.rbBack.Location = new System.Drawing.Point(7, 62);
            this.rbBack.Name = "rbBack";
            this.rbBack.Size = new System.Drawing.Size(52, 19);
            this.rbBack.TabIndex = 2;
            this.rbBack.Text = "&Back";
            // 
            // rbCentral
            // 
            this.rbCentral.AutoSize = true;
            this.rbCentral.Cursor = System.Windows.Forms.Cursors.Default;
            this.rbCentral.Location = new System.Drawing.Point(7, 42);
            this.rbCentral.Name = "rbCentral";
            this.rbCentral.Size = new System.Drawing.Size(64, 19);
            this.rbCentral.TabIndex = 1;
            this.rbCentral.Text = "&Central";
            // 
            // rbFront
            // 
            this.rbFront.AutoSize = true;
            this.rbFront.Location = new System.Drawing.Point(7, 21);
            this.rbFront.Name = "rbFront";
            this.rbFront.Size = new System.Drawing.Size(53, 19);
            this.rbFront.TabIndex = 0;
            this.rbFront.Text = "Fron&t";
            // 
            // gbHeight
            // 
            this.gbHeight.Controls.Add(this.rbLow);
            this.gbHeight.Controls.Add(this.rbMid);
            this.gbHeight.Controls.Add(this.rbHigh);
            this.gbHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbHeight.Location = new System.Drawing.Point(20, 125);
            this.gbHeight.Name = "gbHeight";
            this.gbHeight.Size = new System.Drawing.Size(167, 97);
            this.gbHeight.TabIndex = 1;
            this.gbHeight.TabStop = false;
            this.gbHeight.Text = "Height Feature";
            // 
            // rbLow
            // 
            this.rbLow.AutoSize = true;
            this.rbLow.Location = new System.Drawing.Point(7, 62);
            this.rbLow.Name = "rbLow";
            this.rbLow.Size = new System.Drawing.Size(48, 19);
            this.rbLow.TabIndex = 2;
            this.rbLow.Text = "Lo&w";
            // 
            // rbMid
            // 
            this.rbMid.AutoSize = true;
            this.rbMid.Location = new System.Drawing.Point(7, 42);
            this.rbMid.Name = "rbMid";
            this.rbMid.Size = new System.Drawing.Size(46, 19);
            this.rbMid.TabIndex = 1;
            this.rbMid.Text = "&Mid";
            // 
            // rbHigh
            // 
            this.rbHigh.AutoSize = true;
            this.rbHigh.Location = new System.Drawing.Point(7, 21);
            this.rbHigh.Name = "rbHigh";
            this.rbHigh.Size = new System.Drawing.Size(51, 19);
            this.rbHigh.TabIndex = 0;
            this.rbHigh.Text = "&High";
            // 
            // ckRound
            // 
            this.ckRound.AutoSize = true;
            this.ckRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckRound.Location = new System.Drawing.Point(208, 35);
            this.ckRound.Name = "ckRound";
            this.ckRound.Size = new System.Drawing.Size(63, 19);
            this.ckRound.TabIndex = 2;
            this.ckRound.Text = "&Round";
            // 
            // ckATR
            // 
            this.ckATR.AutoSize = true;
            this.ckATR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckATR.Location = new System.Drawing.Point(208, 69);
            this.ckATR.Name = "ckATR";
            this.ckATR.Size = new System.Drawing.Size(56, 19);
            this.ckATR.TabIndex = 3;
            this.ckATR.Text = "&+ATR";
            // 
            // ckLong
            // 
            this.ckLong.AutoSize = true;
            this.ckLong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckLong.Location = new System.Drawing.Point(208, 104);
            this.ckLong.Name = "ckLong";
            this.ckLong.Size = new System.Drawing.Size(54, 19);
            this.ckLong.TabIndex = 4;
            this.ckLong.Text = "Lon&g";
            // 
            // ckNasal
            // 
            this.ckNasal.AutoSize = true;
            this.ckNasal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckNasal.Location = new System.Drawing.Point(208, 139);
            this.ckNasal.Name = "ckNasal";
            this.ckNasal.Size = new System.Drawing.Size(58, 19);
            this.ckNasal.TabIndex = 5;
            this.ckNasal.Text = "Nasa&l";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(224, 246);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 28);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(124, 246);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(83, 28);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ckVoiceless
            // 
            this.ckVoiceless.AutoSize = true;
            this.ckVoiceless.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckVoiceless.Location = new System.Drawing.Point(208, 173);
            this.ckVoiceless.Name = "ckVoiceless";
            this.ckVoiceless.Size = new System.Drawing.Size(78, 19);
            this.ckVoiceless.TabIndex = 6;
            this.ckVoiceless.Text = "Voiceless";
            this.ckVoiceless.UseVisualStyleBackColor = true;
            // 
            // ckDiphthong
            // 
            this.ckDiphthong.AutoSize = true;
            this.ckDiphthong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckDiphthong.Location = new System.Drawing.Point(208, 208);
            this.ckDiphthong.Name = "ckDiphthong";
            this.ckDiphthong.Size = new System.Drawing.Size(83, 19);
            this.ckDiphthong.TabIndex = 7;
            this.ckDiphthong.Text = "Diphthong";
            this.ckDiphthong.UseVisualStyleBackColor = true;
            // 
            // FormVowelFeatures
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(404, 330);
            this.Controls.Add(this.ckVoiceless);
            this.Controls.Add(this.ckDiphthong);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.ckNasal);
            this.Controls.Add(this.ckLong);
            this.Controls.Add(this.ckATR);
            this.Controls.Add(this.ckRound);
            this.Controls.Add(this.gbHeight);
            this.Controls.Add(this.gbBackness);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormVowelFeatures";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set Vowel Features";
            this.gbBackness.ResumeLayout(false);
            this.gbBackness.PerformLayout();
            this.gbHeight.ResumeLayout(false);
            this.gbHeight.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public VowelFeatures Features
        {
            get {return m_Features;}
        }

        private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (rbFront.Checked)
				m_Features.Backness = VowelFeatures.kFront;
			if (rbCentral.Checked)
				m_Features.Backness = VowelFeatures.kCentral;
			if (rbBack.Checked)
				m_Features.Backness = VowelFeatures.kBack;

			if (rbHigh.Checked)
				m_Features.Height = VowelFeatures.kHigh;
			if (rbMid.Checked)
				m_Features.Height = VowelFeatures.kMid;
			if (rbLow.Checked)
				m_Features.Height = VowelFeatures.kLow;
			
			m_Features.Round = ckRound.Checked;
			m_Features.PlusAtr = ckATR.Checked;
			m_Features.Long = ckLong.Checked;
			m_Features.Nasal = ckNasal.Checked;
            m_Features.Diphthong = ckDiphthong.Checked;
            m_Features.Voiceless = ckVoiceless.Checked;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			m_Features = null;
			this.Close();		
		}

        private void UpdateFormForLocalization(LocalizationTable table)
        {
            string strText = "";
            strText = table.GetForm("FormVowelFeaturesT");
			if (strText != "")
				this.Text = strText;
            strText = table.GetForm("FormVowelFeatures0");
			if (strText != "")
				this.gbBackness.Text = strText;
            strText = table.GetForm("FormVowelFeaturesB0");
			if (strText != "")
				this.rbFront.Text = strText;
            strText = table.GetForm("FormVowelFeaturesB1");
			if (strText != "")
				this.rbCentral.Text = strText;
            strText = table.GetForm("FormVowelFeaturesB2");
			if (strText != "")
				this.rbBack.Text = strText;
            strText = table.GetForm("FormVowelFeatures1");
			if (strText != "")
				this.gbHeight.Text = strText;
            strText = table.GetForm("FormVowelFeaturesH0");
			if (strText != "")
				this.rbHigh.Text = strText;
            strText = table.GetForm("FormVowelFeaturesH1");
			if (strText != "")
				this.rbMid.Text = strText;
            strText = table.GetForm("FormVowelFeaturesH2");
			if (strText != "")
				this.rbLow.Text = strText;
            strText = table.GetForm("FormVowelFeatures2");
			if (strText != "")
				this.ckRound.Text = strText;
            strText = table.GetForm("FormVowelFeatures3");
			if (strText != "")
				this.ckATR.Text = strText;
            strText = table.GetForm("FormVowelFeatures4");
			if (strText != "")
				this.ckLong.Text = strText;
            strText = table.GetForm("FormVowelFeatures5");
			if (strText != "")
				this.ckNasal.Text = strText;
            strText = table.GetForm("FormVowelFeatures6");
			if (strText != "")
				this.ckVoiceless.Text = strText;
            strText = table.GetForm("FormVowelFeatures7");
			if (strText != "")
				this.ckDiphthong.Text = strText;
            strText = table.GetForm("FormVowelFeatures8");
			if (strText != "")
				this.btnOK.Text = strText;
            strText = table.GetForm("FormVowelFeatures9");
			if (strText != "")
				this.btnCancel.Text = strText;
            return;
        }
	}
}

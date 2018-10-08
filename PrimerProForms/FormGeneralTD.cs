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
	public class FormGeneralTD : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.CheckBox ckVwlSame;
		private System.Windows.Forms.Label labWordCV;
        private System.Windows.Forms.TextBox tbWordCV;

        private bool m_ParaFormat;  	    //how to display the results
        private bool m_UseGraphemesTaught;  //restrict to graphemes taught
        private bool m_NoDuplicates;        //do not display duplicate words
        private bool m_IsIdenticalVowelsInWord;
        private string m_WordCVShape;
        private int m_MinSyllables;
        private int m_MaxSyllables;

        private NumericUpDown nudMinSyllables;
        private Label labMinSyllable;
        private Label labMaxSyllables;
        private NumericUpDown nudMaxSyllables;

        //private string m_Title;             //Search title
        private Settings m_Settings;        // Global settings
        private Font m_DefaultFont;
        private CheckBox ckNoDup;
        private CheckBox ckGraphemesTaught;
        private CheckBox ckParaFmt;         // Default Font
        private bool m_ViewParaSentWord;    //Flag for viewing ParaSentWord number
                
        public FormGeneralTD(Settings s)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            m_Settings = s;
            m_DefaultFont = m_Settings.OptionSettings.GetDefaultFont();
            m_ViewParaSentWord = m_Settings.OptionSettings.ViewParaSentWord;
            m_ParaFormat = false;
            m_UseGraphemesTaught = false;
            m_NoDuplicates = false;
            m_IsIdenticalVowelsInWord = false;
            m_WordCVShape = "";
            m_MinSyllables = 0;
            m_MaxSyllables = 0;
        }

        public FormGeneralTD(Settings s, LocalizationTable table)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            m_Settings = s;
            m_DefaultFont = m_Settings.OptionSettings.GetDefaultFont();
            m_ViewParaSentWord = m_Settings.OptionSettings.ViewParaSentWord;
            m_ParaFormat = false;
            m_UseGraphemesTaught = false;
            m_NoDuplicates = false;
            m_IsIdenticalVowelsInWord = false;
            m_WordCVShape = "";
            m_MinSyllables = 0;
            m_MaxSyllables = 0;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGeneralTD));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ckVwlSame = new System.Windows.Forms.CheckBox();
            this.labWordCV = new System.Windows.Forms.Label();
            this.tbWordCV = new System.Windows.Forms.TextBox();
            this.nudMinSyllables = new System.Windows.Forms.NumericUpDown();
            this.labMinSyllable = new System.Windows.Forms.Label();
            this.labMaxSyllables = new System.Windows.Forms.Label();
            this.nudMaxSyllables = new System.Windows.Forms.NumericUpDown();
            this.ckNoDup = new System.Windows.Forms.CheckBox();
            this.ckGraphemesTaught = new System.Windows.Forms.CheckBox();
            this.ckParaFmt = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinSyllables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxSyllables)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(302, 183);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(86, 26);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(423, 183);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 26);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ckVwlSame
            // 
            this.ckVwlSame.AutoSize = true;
            this.ckVwlSame.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckVwlSame.Location = new System.Drawing.Point(24, 24);
            this.ckVwlSame.Name = "ckVwlSame";
            this.ckVwlSame.Size = new System.Drawing.Size(149, 19);
            this.ckVwlSame.TabIndex = 0;
            this.ckVwlSame.Text = "&All vowels are identical";
            this.ckVwlSame.CheckedChanged += new System.EventHandler(this.ckVwlSame_CheckedChanged);
            // 
            // labWordCV
            // 
            this.labWordCV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labWordCV.Location = new System.Drawing.Point(24, 64);
            this.labWordCV.Name = "labWordCV";
            this.labWordCV.Size = new System.Drawing.Size(140, 19);
            this.labWordCV.TabIndex = 1;
            this.labWordCV.Text = "Word CV Shape";
            // 
            // tbWordCV
            // 
            this.tbWordCV.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbWordCV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbWordCV.Location = new System.Drawing.Point(160, 64);
            this.tbWordCV.Name = "tbWordCV";
            this.tbWordCV.Size = new System.Drawing.Size(103, 21);
            this.tbWordCV.TabIndex = 2;
            this.tbWordCV.TextChanged += new System.EventHandler(this.tbWordCV_TextChanged);
            // 
            // nudMinSyllables
            // 
            this.nudMinSyllables.Location = new System.Drawing.Point(236, 102);
            this.nudMinSyllables.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nudMinSyllables.Name = "nudMinSyllables";
            this.nudMinSyllables.Size = new System.Drawing.Size(32, 21);
            this.nudMinSyllables.TabIndex = 4;
            this.nudMinSyllables.ValueChanged += new System.EventHandler(this.nudMinSyllables_ValueChanged);
            // 
            // labMinSyllable
            // 
            this.labMinSyllable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMinSyllable.Location = new System.Drawing.Point(24, 102);
            this.labMinSyllable.Name = "labMinSyllable";
            this.labMinSyllable.Size = new System.Drawing.Size(204, 19);
            this.labMinSyllable.TabIndex = 3;
            this.labMinSyllable.Text = "Minimal Number of Syllables";
            // 
            // labMaxSyllables
            // 
            this.labMaxSyllables.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMaxSyllables.Location = new System.Drawing.Point(24, 132);
            this.labMaxSyllables.Name = "labMaxSyllables";
            this.labMaxSyllables.Size = new System.Drawing.Size(203, 19);
            this.labMaxSyllables.TabIndex = 5;
            this.labMaxSyllables.Text = "Maximal Number of Syllables";
            // 
            // nudMaxSyllables
            // 
            this.nudMaxSyllables.Location = new System.Drawing.Point(236, 132);
            this.nudMaxSyllables.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nudMaxSyllables.Name = "nudMaxSyllables";
            this.nudMaxSyllables.Size = new System.Drawing.Size(32, 21);
            this.nudMaxSyllables.TabIndex = 6;
            this.nudMaxSyllables.ValueChanged += new System.EventHandler(this.nudMaxSyllables_ValueChanged);
            // 
            // ckNoDup
            // 
            this.ckNoDup.AutoSize = true;
            this.ckNoDup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckNoDup.Location = new System.Drawing.Point(330, 120);
            this.ckNoDup.Margin = new System.Windows.Forms.Padding(2);
            this.ckNoDup.Name = "ckNoDup";
            this.ckNoDup.Size = new System.Drawing.Size(103, 19);
            this.ckNoDup.TabIndex = 9;
            this.ckNoDup.Text = "No Duplicates";
            this.ckNoDup.UseVisualStyleBackColor = true;
            // 
            // ckGraphemesTaught
            // 
            this.ckGraphemesTaught.AutoSize = true;
            this.ckGraphemesTaught.Location = new System.Drawing.Point(330, 72);
            this.ckGraphemesTaught.Name = "ckGraphemesTaught";
            this.ckGraphemesTaught.Size = new System.Drawing.Size(189, 19);
            this.ckGraphemesTaught.TabIndex = 8;
            this.ckGraphemesTaught.Text = "&Restrict to Graphemes Taught";
            this.ckGraphemesTaught.UseVisualStyleBackColor = true;
            // 
            // ckParaFmt
            // 
            this.ckParaFmt.AutoSize = true;
            this.ckParaFmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckParaFmt.Location = new System.Drawing.Point(330, 24);
            this.ckParaFmt.Name = "ckParaFmt";
            this.ckParaFmt.Size = new System.Drawing.Size(177, 19);
            this.ckParaFmt.TabIndex = 7;
            this.ckParaFmt.Text = "Display in &paragraph format";
            this.ckParaFmt.UseVisualStyleBackColor = true;
            this.ckParaFmt.CheckedChanged += new System.EventHandler(this.ckParaFmt_CheckedChanged);
            // 
            // FormGeneralTD
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(571, 221);
            this.Controls.Add(this.ckNoDup);
            this.Controls.Add(this.ckGraphemesTaught);
            this.Controls.Add(this.ckParaFmt);
            this.Controls.Add(this.labMaxSyllables);
            this.Controls.Add(this.nudMaxSyllables);
            this.Controls.Add(this.labMinSyllable);
            this.Controls.Add(this.nudMinSyllables);
            this.Controls.Add(this.tbWordCV);
            this.Controls.Add(this.labWordCV);
            this.Controls.Add(this.ckVwlSame);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormGeneralTD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "General Search";
            ((System.ComponentModel.ISupportInitialize)(this.nudMinSyllables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxSyllables)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        public bool ParaFormat
        {
            get { return m_ParaFormat; }
        }

        public bool UseGraphemesTaught
        {
            get { return m_UseGraphemesTaught; }
        }

        public bool NoDuplicates
        {
            get { return m_NoDuplicates; }
        }

        public bool IsIdenticalVowelsInWord
        {
            get {return m_IsIdenticalVowelsInWord;}
        }

        public string WordCVShape
        {
            get {return m_WordCVShape;}
        }

        public int MinSyllables
        {
            get { return m_MinSyllables; }
        }

        public int MaxSyllables
        {
            get { return m_MaxSyllables; }
        }

		private void ckVwlSame_CheckedChanged(object sender, System.EventArgs e)
		{
            //ckVwlInRootSame.Checked = ckVwlSame.Checked;
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

        private void ckParaFmt_CheckedChanged(object sender, EventArgs e)
        {
            if (ckParaFmt.Checked)
            {
                ckNoDup.Checked = false;
                ckNoDup.Enabled = false;
            }
            else ckNoDup.Enabled = true;
        }

        private void btnOK_Click(object sender, System.EventArgs e)
		{
			m_IsIdenticalVowelsInWord = ckVwlSame.Checked;
			m_WordCVShape = tbWordCV.Text;
            m_MinSyllables = Convert.ToInt16(nudMinSyllables.Value);
            m_MaxSyllables = Convert.ToInt16(nudMaxSyllables.Value);
            m_ParaFormat = ckParaFmt.Checked;
            m_UseGraphemesTaught = ckGraphemesTaught.Checked;
            m_NoDuplicates = ckNoDup.Checked;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			m_IsIdenticalVowelsInWord = false;
			m_WordCVShape = "";
            m_MinSyllables = 0;
            m_MaxSyllables = 0;
			this.Close();
		}

        private void UpdateFormForLocalization(LocalizationTable table)
        {
            string strText = "";
            strText = table.GetForm("FormGeneralTDT");
			if (strText != "")
				this.Text = strText;
            strText = table.GetForm("FormGeneralTD0");
			if (strText != "")
				this.ckVwlSame.Text = strText;
            strText = table.GetForm("FormGeneralTD1");
			if (strText != "")
				this.labWordCV.Text = strText;
            strText = table.GetForm("FormGeneralTD3");
			if (strText != "")
				this.labMinSyllable.Text = strText;
            strText = table.GetForm("FormGeneralTD5");
			if (strText != "")
				this.labMaxSyllables.Text = strText;
            strText = table.GetForm("FormGeneralTD7");
			if (strText != "")
				this.ckParaFmt.Text = strText;
            strText = table.GetForm("FormGeneralTD8");
			if (strText != "")
				this.ckGraphemesTaught.Text = strText;
            strText = table.GetForm("FormGeneralTD9");
			if (strText != "")
				this.ckNoDup.Text = strText;
            strText = table.GetForm("FormGeneralTD10");
			if (strText != "")
				this.btnOK.Text = strText;
            strText = table.GetForm("FormGeneralTD11");
			if (strText != "")
				this.btnCancel.Text = strText;
            return;
        }
	}
}

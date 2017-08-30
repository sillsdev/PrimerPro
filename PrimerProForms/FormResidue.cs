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
	/// Summary description for FormResidue.
	/// </summary>
	public class FormResidue : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.CheckBox chkParaFmt;
		private System.Windows.Forms.Label labGraphemes;
		private System.Windows.Forms.Label labSample;
		private System.Windows.Forms.TextBox tbGraphemes;
		private System.Windows.Forms.Label labInfo;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private CheckBox chkIgnoreSightWords;
        private CheckBox chkTDFile;
        private Button btnStoryFile;
        private TextBox tbStoryFile;
        private Label labStoryFile;

        private ArrayList m_Graphemes;
        private string m_GraphemeToBeCounted;
        private string m_TextDataFile;
        private bool m_UseCurrentTextData;
        private bool m_ParaFormat;
        private bool m_IgnoreSightWords;
        private Label labGrf2BCounted;
        private TextBox tbGrf2BCounted;
        private string m_Folder;

		public FormResidue(GraphemeTaughtOrder gto, Font fnt, string folder)
		{
			InitializeComponent();
            this.tbGraphemes.Text = this.GetGraphemesTaught(gto);
            this.tbGrf2BCounted.Text = "";
            this.tbGraphemes.Font = fnt;
            this.tbGrf2BCounted.Font = fnt;
            this.chkIgnoreSightWords.Checked = true;
            this.chkParaFmt.Checked = true;
            m_Folder = folder;
		}

        public FormResidue(GraphemeTaughtOrder gto, Font fnt, string folder,
            LocalizationTable table, string lang)
        {
            InitializeComponent();
            this.tbGraphemes.Text = this.GetGraphemesTaught(gto);
            this.tbGrf2BCounted.Text = "";
            this.tbGraphemes.Font = fnt;
            this.tbGrf2BCounted.Font = fnt;
            this.chkIgnoreSightWords.Checked = true;
            this.chkParaFmt.Checked = true;
            m_Folder = folder;

            this.Text = table.GetForm("FormResidueT", lang);
            this.labInfo.Text = table.GetForm("FormResidue0", lang);
            this.labGraphemes.Text = table.GetForm("FormResidue1", lang);
            this.chkTDFile.Text = table.GetForm("FormResidue4", lang);
            this.labStoryFile.Text = table.GetForm("FormResidue5", lang);
            this.btnStoryFile.Text = table.GetForm("FormResidue7", lang);
            this.chkParaFmt.Text = table.GetForm("FormResidue8", lang);
            this.chkIgnoreSightWords.Text = table.GetForm("FormResidue9", lang);
            this.btnOK.Text = table.GetForm("FormResidue10", lang);
            this.btnCancel.Text = table.GetForm("FormResidue11", lang);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormResidue));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.chkParaFmt = new System.Windows.Forms.CheckBox();
            this.labGraphemes = new System.Windows.Forms.Label();
            this.labSample = new System.Windows.Forms.Label();
            this.tbGraphemes = new System.Windows.Forms.TextBox();
            this.labInfo = new System.Windows.Forms.Label();
            this.chkIgnoreSightWords = new System.Windows.Forms.CheckBox();
            this.chkTDFile = new System.Windows.Forms.CheckBox();
            this.btnStoryFile = new System.Windows.Forms.Button();
            this.tbStoryFile = new System.Windows.Forms.TextBox();
            this.labStoryFile = new System.Windows.Forms.Label();
            this.labGrf2BCounted = new System.Windows.Forms.Label();
            this.tbGrf2BCounted = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(552, 243);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 27);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(443, 243);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 27);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // chkParaFmt
            // 
            this.chkParaFmt.AutoSize = true;
            this.chkParaFmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkParaFmt.Location = new System.Drawing.Point(31, 207);
            this.chkParaFmt.Name = "chkParaFmt";
            this.chkParaFmt.Size = new System.Drawing.Size(177, 19);
            this.chkParaFmt.TabIndex = 8;
            this.chkParaFmt.Text = "Display in &paragraph format";
            // 
            // labGraphemes
            // 
            this.labGraphemes.AutoSize = true;
            this.labGraphemes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labGraphemes.Location = new System.Drawing.Point(27, 76);
            this.labGraphemes.Name = "labGraphemes";
            this.labGraphemes.Size = new System.Drawing.Size(72, 15);
            this.labGraphemes.TabIndex = 1;
            this.labGraphemes.Text = "Graphemes";
            // 
            // labSample
            // 
            this.labSample.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labSample.Location = new System.Drawing.Point(411, 76);
            this.labSample.Name = "labSample";
            this.labSample.Size = new System.Drawing.Size(153, 20);
            this.labSample.TabIndex = 3;
            this.labSample.Text = "(e.g. p b m mp mb a e i o)";
            // 
            // tbGraphemes
            // 
            this.tbGraphemes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGraphemes.Location = new System.Drawing.Point(107, 76);
            this.tbGraphemes.Name = "tbGraphemes";
            this.tbGraphemes.Size = new System.Drawing.Size(299, 21);
            this.tbGraphemes.TabIndex = 2;
            // 
            // labInfo
            // 
            this.labInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfo.Location = new System.Drawing.Point(27, 17);
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(500, 35);
            this.labInfo.TabIndex = 0;
            this.labInfo.Text = "List graphemes (consonants and vowels) that should be in the selected text data (" +
    "story).  The graphemes should be separated by a space.";
            // 
            // chkIgnoreSightWords
            // 
            this.chkIgnoreSightWords.AutoSize = true;
            this.chkIgnoreSightWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIgnoreSightWords.Location = new System.Drawing.Point(29, 243);
            this.chkIgnoreSightWords.Name = "chkIgnoreSightWords";
            this.chkIgnoreSightWords.Size = new System.Drawing.Size(130, 19);
            this.chkIgnoreSightWords.TabIndex = 9;
            this.chkIgnoreSightWords.Text = "&Ignore Sight Words";
            this.chkIgnoreSightWords.UseVisualStyleBackColor = true;
            // 
            // chkTDFile
            // 
            this.chkTDFile.AutoSize = true;
            this.chkTDFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTDFile.Location = new System.Drawing.Point(497, 114);
            this.chkTDFile.Name = "chkTDFile";
            this.chkTDFile.Size = new System.Drawing.Size(138, 19);
            this.chkTDFile.TabIndex = 4;
            this.chkTDFile.Text = "Use current text data";
            this.chkTDFile.UseVisualStyleBackColor = true;
            this.chkTDFile.CheckedChanged += new System.EventHandler(this.chkTDFile_CheckedChanged);
            // 
            // btnStoryFile
            // 
            this.btnStoryFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStoryFile.Location = new System.Drawing.Point(552, 156);
            this.btnStoryFile.Name = "btnStoryFile";
            this.btnStoryFile.Size = new System.Drawing.Size(83, 28);
            this.btnStoryFile.TabIndex = 7;
            this.btnStoryFile.Text = "Bro&wse";
            this.btnStoryFile.Click += new System.EventHandler(this.btnTDFile_Click);
            // 
            // tbStoryFile
            // 
            this.tbStoryFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStoryFile.Location = new System.Drawing.Point(107, 156);
            this.tbStoryFile.Multiline = true;
            this.tbStoryFile.Name = "tbStoryFile";
            this.tbStoryFile.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbStoryFile.Size = new System.Drawing.Size(440, 38);
            this.tbStoryFile.TabIndex = 6;
            // 
            // labStoryFile
            // 
            this.labStoryFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labStoryFile.Location = new System.Drawing.Point(28, 156);
            this.labStoryFile.Name = "labStoryFile";
            this.labStoryFile.Size = new System.Drawing.Size(72, 35);
            this.labStoryFile.TabIndex = 5;
            this.labStoryFile.Text = "Story File";
            // 
            // labGrf2BCounted
            // 
            this.labGrf2BCounted.AutoSize = true;
            this.labGrf2BCounted.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labGrf2BCounted.Location = new System.Drawing.Point(28, 115);
            this.labGrf2BCounted.Name = "labGrf2BCounted";
            this.labGrf2BCounted.Size = new System.Drawing.Size(143, 15);
            this.labGrf2BCounted.TabIndex = 12;
            this.labGrf2BCounted.Text = "Grapheme to be counted";
            // 
            // tbGrf2BCounted
            // 
            this.tbGrf2BCounted.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGrf2BCounted.Location = new System.Drawing.Point(188, 113);
            this.tbGrf2BCounted.Name = "tbGrf2BCounted";
            this.tbGrf2BCounted.Size = new System.Drawing.Size(67, 21);
            this.tbGrf2BCounted.TabIndex = 13;
            // 
            // FormResidue
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(783, 330);
            this.Controls.Add(this.tbGrf2BCounted);
            this.Controls.Add(this.labGrf2BCounted);
            this.Controls.Add(this.btnStoryFile);
            this.Controls.Add(this.tbStoryFile);
            this.Controls.Add(this.labStoryFile);
            this.Controls.Add(this.chkTDFile);
            this.Controls.Add(this.chkIgnoreSightWords);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkParaFmt);
            this.Controls.Add(this.labGraphemes);
            this.Controls.Add(this.labSample);
            this.Controls.Add(this.tbGraphemes);
            this.Controls.Add(this.labInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormResidue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Untaught Residue Search";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public ArrayList Graphemes
        {
            get { return m_Graphemes; }
        }

        public string GraphemeToBeCounted
        {
            get { return m_GraphemeToBeCounted; }
        }

        public string TextDataFile
        {
            get { return m_TextDataFile; }
        }

        public bool UseCurrentTextData
        {
            get { return m_UseCurrentTextData; }
        }

        public bool ParaFormat
        {
            get { return m_ParaFormat; }
        }

        public bool IgnoreSightWords
        {
            get { return m_IgnoreSightWords; }
        }
        
        private void btnOK_Click(object sender, System.EventArgs e)
		{
			string strGrfs = tbGraphemes.Text.Trim();
            if (strGrfs != "")
			{
				ArrayList alGrfs = null;
				alGrfs = Funct.ConvertStringToArrayList(strGrfs, " ");
				m_Graphemes = alGrfs;
			}
			else m_Graphemes = null;
            m_GraphemeToBeCounted = tbGrf2BCounted.Text.Trim();
			m_ParaFormat = this.chkParaFmt.Checked;
            m_IgnoreSightWords = this.chkIgnoreSightWords.Checked;
            m_UseCurrentTextData = this.chkTDFile.Checked;
            if (!m_UseCurrentTextData)
                m_TextDataFile = this.tbStoryFile.Text.Trim();
    	}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			m_Graphemes = null;
            m_GraphemeToBeCounted = "";
			m_ParaFormat = false;
            m_IgnoreSightWords = false;
            m_UseCurrentTextData = false;
            m_TextDataFile = "";
		}

        private void btnTDFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files (*.txt)|*.txt|All Files (*.*)|*.*";
            ofd.FileName = "";
            ofd.DefaultExt = "*.txt";
            ofd.InitialDirectory = m_Folder;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.tbStoryFile.Text = ofd.FileName;
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

        private void chkTDFile_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkTDFile.Checked)
            {
                this.tbStoryFile.Text = "";
                this.tbStoryFile.Enabled = false;
                this.btnStoryFile.Enabled = false;
            }
            else
            {
                this.tbStoryFile.Enabled = true;
                this.btnStoryFile.Enabled = true;
            }
        }

	}
}

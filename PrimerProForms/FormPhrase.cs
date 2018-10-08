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
	/// Summary description for FormPhrase.
	/// </summary>
	public class FormPhrase : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label labTitle;
		private System.Windows.Forms.Label labSample;
        private System.Windows.Forms.TextBox tbGraphemes;
		private System.Windows.Forms.Label labGraphemes;
		private System.Windows.Forms.CheckBox chkParaFmt;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private Label labMin;
        private NumericUpDown nudMin;
        private Label labHighlight;
        private TextBox tbHighlight;
        private CheckBox chkGraphemesTaught;
        private Label labRestrict;
        private TextBox tbRestiction;

        private ArrayList m_Graphemes;
        private string m_Highlight;
        private string m_Restriction;
        private bool m_ParaFormat;
        private bool m_UseGraphemesTaught;
        private Int32 m_Min;

		public FormPhrase(GraphemeTaughtOrder gto, Font fnt)
		{
			InitializeComponent();
            this.tbGraphemes.Text = this.GetGraphemesTaught(gto);
            this.tbHighlight.Text = "";
            this.tbRestiction.Text = "";
            this.chkParaFmt.Checked = false;
            this.chkGraphemesTaught.Checked = false;
            this.nudMin.Value = 1;
            this.tbGraphemes.Font = fnt;
            this.tbHighlight.Font = fnt;
            this.tbRestiction.Font = fnt;
  		}

        public FormPhrase(GraphemeTaughtOrder gto, Font fnt, LocalizationTable table)
        {
            InitializeComponent();
            this.tbGraphemes.Text = this.GetGraphemesTaught(gto);
            this.tbHighlight.Text = "";
            this.tbRestiction.Text = "";
            this.chkParaFmt.Checked = false;
            this.chkGraphemesTaught.Checked = false;
            this.nudMin.Value = 1;
            this.tbGraphemes.Font = fnt;
            this.tbHighlight.Font = fnt;
            this.tbRestiction.Font = fnt;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPhrase));
            this.labTitle = new System.Windows.Forms.Label();
            this.labSample = new System.Windows.Forms.Label();
            this.tbGraphemes = new System.Windows.Forms.TextBox();
            this.labGraphemes = new System.Windows.Forms.Label();
            this.chkParaFmt = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.labMin = new System.Windows.Forms.Label();
            this.nudMin = new System.Windows.Forms.NumericUpDown();
            this.labHighlight = new System.Windows.Forms.Label();
            this.tbHighlight = new System.Windows.Forms.TextBox();
            this.chkGraphemesTaught = new System.Windows.Forms.CheckBox();
            this.labRestrict = new System.Windows.Forms.Label();
            this.tbRestiction = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).BeginInit();
            this.SuspendLayout();
            // 
            // labTitle
            // 
            this.labTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTitle.Location = new System.Drawing.Point(10, 26);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(527, 36);
            this.labTitle.TabIndex = 0;
            this.labTitle.Text = "List graphemes (consonants and vowels) to be found in the phrases (a series of ad" +
    "jacent words in a sentence) in the text data.  The graphemes should be separated" +
    " by a space.";
            // 
            // labSample
            // 
            this.labSample.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labSample.Location = new System.Drawing.Point(91, 99);
            this.labSample.Name = "labSample";
            this.labSample.Size = new System.Drawing.Size(264, 20);
            this.labSample.TabIndex = 3;
            this.labSample.Text = "(e.g. p b m mp mb mpw mbw a e i o u aa)";
            // 
            // tbGraphemes
            // 
            this.tbGraphemes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGraphemes.Location = new System.Drawing.Point(93, 69);
            this.tbGraphemes.Name = "tbGraphemes";
            this.tbGraphemes.Size = new System.Drawing.Size(448, 21);
            this.tbGraphemes.TabIndex = 2;
            // 
            // labGraphemes
            // 
            this.labGraphemes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labGraphemes.Location = new System.Drawing.Point(13, 70);
            this.labGraphemes.Name = "labGraphemes";
            this.labGraphemes.Size = new System.Drawing.Size(75, 20);
            this.labGraphemes.TabIndex = 1;
            this.labGraphemes.Text = "Graphemes";
            // 
            // chkParaFmt
            // 
            this.chkParaFmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkParaFmt.Location = new System.Drawing.Point(16, 141);
            this.chkParaFmt.Name = "chkParaFmt";
            this.chkParaFmt.Size = new System.Drawing.Size(220, 21);
            this.chkParaFmt.TabIndex = 4;
            this.chkParaFmt.Text = "Display in &paragraph format";
            this.chkParaFmt.CheckedChanged += new System.EventHandler(this.chkParaFmt_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(379, 225);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(83, 28);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(477, 225);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 28);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labMin
            // 
            this.labMin.AutoSize = true;
            this.labMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMin.Location = new System.Drawing.Point(13, 234);
            this.labMin.Name = "labMin";
            this.labMin.Size = new System.Drawing.Size(198, 15);
            this.labMin.TabIndex = 10;
            this.labMin.Text = "Minimal number words in a phrase";
            // 
            // nudMin
            // 
            this.nudMin.Cursor = System.Windows.Forms.Cursors.Default;
            this.nudMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMin.Location = new System.Drawing.Point(257, 232);
            this.nudMin.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMin.Name = "nudMin";
            this.nudMin.Size = new System.Drawing.Size(41, 21);
            this.nudMin.TabIndex = 11;
            this.nudMin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labHighlight
            // 
            this.labHighlight.AutoSize = true;
            this.labHighlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labHighlight.Location = new System.Drawing.Point(290, 147);
            this.labHighlight.Name = "labHighlight";
            this.labHighlight.Size = new System.Drawing.Size(210, 15);
            this.labHighlight.TabIndex = 5;
            this.labHighlight.Text = "Highlight phrases with this grapheme";
            // 
            // tbHighlight
            // 
            this.tbHighlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHighlight.Location = new System.Drawing.Point(520, 144);
            this.tbHighlight.Name = "tbHighlight";
            this.tbHighlight.Size = new System.Drawing.Size(41, 21);
            this.tbHighlight.TabIndex = 6;
            this.tbHighlight.TextChanged += new System.EventHandler(this.tbHighlight_TextChanged);
            // 
            // chkGraphemesTaught
            // 
            this.chkGraphemesTaught.AutoSize = true;
            this.chkGraphemesTaught.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGraphemesTaught.Location = new System.Drawing.Point(16, 180);
            this.chkGraphemesTaught.Name = "chkGraphemesTaught";
            this.chkGraphemesTaught.Size = new System.Drawing.Size(183, 19);
            this.chkGraphemesTaught.TabIndex = 7;
            this.chkGraphemesTaught.Text = "Restrict to graphemes taught";
            this.chkGraphemesTaught.UseVisualStyleBackColor = true;
            // 
            // labRestrict
            // 
            this.labRestrict.AutoSize = true;
            this.labRestrict.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labRestrict.Location = new System.Drawing.Point(290, 180);
            this.labRestrict.Name = "labRestrict";
            this.labRestrict.Size = new System.Drawing.Size(202, 15);
            this.labRestrict.TabIndex = 8;
            this.labRestrict.Text = "Restrict phrases with this grapheme";
            // 
            // tbRestiction
            // 
            this.tbRestiction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRestiction.Location = new System.Drawing.Point(520, 180);
            this.tbRestiction.Name = "tbRestiction";
            this.tbRestiction.Size = new System.Drawing.Size(41, 21);
            this.tbRestiction.TabIndex = 9;
            this.tbRestiction.TextChanged += new System.EventHandler(this.tbRestrict_TextChanged);
            // 
            // FormPhrase
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(644, 295);
            this.Controls.Add(this.tbRestiction);
            this.Controls.Add(this.labRestrict);
            this.Controls.Add(this.chkGraphemesTaught);
            this.Controls.Add(this.tbHighlight);
            this.Controls.Add(this.labHighlight);
            this.Controls.Add(this.nudMin);
            this.Controls.Add(this.labMin);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkParaFmt);
            this.Controls.Add(this.labGraphemes);
            this.Controls.Add(this.labSample);
            this.Controls.Add(this.tbGraphemes);
            this.Controls.Add(this.labTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPhrase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Usable Phrases Search";
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        public ArrayList Graphemes
        {
            get { return m_Graphemes; }
        }

        public string Highlight
        {
            get { return m_Highlight; }
        }

        public string Restriction
        {
            get { return m_Restriction; }
        }

        public bool ParaFormat
        {
            get {return m_ParaFormat;}
        }

        public bool UseGraphemesTaught
        {
            get { return m_UseGraphemesTaught; }
        }

        public Int32 Min
        {
            get {return m_Min;}
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
			m_ParaFormat = this.chkParaFmt.Checked;
            m_UseGraphemesTaught = this.chkGraphemesTaught.Checked;
            m_Highlight = this.tbHighlight.Text;
            m_Restriction = this.tbRestiction.Text;
            m_Min = Convert.ToInt32(this.nudMin.Value);
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
            m_Graphemes = null;
            m_Highlight = "";
            m_Restriction = "";
            m_ParaFormat = false;
            m_UseGraphemesTaught = false;
            m_Min = 0;
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

        private void chkParaFmt_CheckedChanged(object sender, EventArgs e)
        {
            if (chkParaFmt.Checked)
            {
                tbHighlight.Enabled = false;
                tbRestiction.Enabled = false;
                tbHighlight.Text = "";
                tbRestiction.Text = "";
            }
            else
            {
                tbHighlight.Enabled = true;
                tbRestiction.Enabled = true;
            }
        }

        private void tbHighlight_TextChanged(object sender, EventArgs e)
        {
            if (tbHighlight.Text != "")
                tbRestiction.Text = "";
        }

        private void tbRestrict_TextChanged(object sender, EventArgs e)
        {
            if (tbRestiction.Text != "")
                tbHighlight.Text = "";
        }

        private void UpdateFormForLocalization(LocalizationTable table)
        {
            string strText = "";
            strText = table.GetForm("FormPhraseT");
			if (strText != "")
				this.Text = strText;
            strText = table.GetForm("FormPhrase0");
			if (strText != "")
				this.labTitle.Text = strText;
            strText = table.GetForm("FormPhrase1");
			if (strText != "")
				this.labGraphemes.Text = strText;
            strText = table.GetForm("FormPhrase4");
			if (strText != "")
				this.chkParaFmt.Text = strText;
            strText = table.GetForm("FormPhrase7");
			if (strText != "")
				this.chkGraphemesTaught.Text = strText;
            strText = table.GetForm("FormPhrase5");
			if (strText != "")
				this.labHighlight.Text = strText;
            strText = table.GetForm("FormPhrase8");
			if (strText != "")
				this.labRestrict.Text = strText;
            strText = table.GetForm("FormPhrase10");
			if (strText != "")
				this.labMin.Text = strText;
            strText = table.GetForm("FormPhrase12");
			if (strText != "")
				this.btnOK.Text = strText;
            strText = table.GetForm("FormPhrase13");
			if (strText != "")
				this.btnCancel.Text = strText;
            return;
        }

	}
}

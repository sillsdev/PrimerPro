using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using PrimerProLocalization;

namespace PrimerProForms
{
    /// <summary>
	/// Summary description for FormWord.
	/// </summary>
	public class FormWord : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label labWord;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TextBox tbTarget;
		private System.Windows.Forms.GroupBox gbSearch;
		private System.Windows.Forms.RadioButton rbRoots;
		private System.Windows.Forms.RadioButton rbWords;
		private System.Windows.Forms.CheckBox chkParaFmt;
        private CheckBox chkIgnoreTone;

        public enum TargetType { Word, Root };
        private string m_Target;
        private TargetType m_Type;
        private bool m_ParaFormat;
        private bool m_IgnoreTone;

        public FormWord(Font fnt)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			rbWords.Checked = true;
            rbRoots.Checked = false;
            chkParaFmt.Checked = false;
            chkIgnoreTone.Checked = false;
            tbTarget.Text = "";
            tbTarget.Font = fnt;
		}

        public FormWord(Font fnt, LocalizationTable table, string lang)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            rbWords.Checked = true;
            rbRoots.Checked = false;
            chkParaFmt.Checked = false;
            chkIgnoreTone.Checked = false;
            tbTarget.Text = "";
            tbTarget.Font = fnt;

            this.Text = table.GetForm("FormWordT", lang);
            this.labWord.Text = table.GetForm("FormWord0", lang);
            this.gbSearch.Text = table.GetForm("FormWord2", lang);
            this.rbWords.Text = table.GetForm("FormWordS0", lang);
            this.rbRoots.Text = table.GetForm("FormWordS1", lang);
            this.chkParaFmt.Text = table.GetForm("FormWord3", lang);
            this.chkIgnoreTone.Text = table.GetForm("FormWord4", lang);
            this.btnOK.Text = table.GetForm("FormWord5", lang);
            this.btnCancel.Text = table.GetForm("FormWord6", lang);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWord));
            this.labWord = new System.Windows.Forms.Label();
            this.tbTarget = new System.Windows.Forms.TextBox();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.rbRoots = new System.Windows.Forms.RadioButton();
            this.rbWords = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkParaFmt = new System.Windows.Forms.CheckBox();
            this.chkIgnoreTone = new System.Windows.Forms.CheckBox();
            this.gbSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // labWord
            // 
            this.labWord.AutoSize = true;
            this.labWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labWord.Location = new System.Drawing.Point(21, 32);
            this.labWord.Name = "labWord";
            this.labWord.Size = new System.Drawing.Size(144, 18);
            this.labWord.TabIndex = 0;
            this.labWord.Text = "Word or Root to find";
            this.labWord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbTarget
            // 
            this.tbTarget.Location = new System.Drawing.Point(287, 32);
            this.tbTarget.Name = "tbTarget";
            this.tbTarget.Size = new System.Drawing.Size(176, 24);
            this.tbTarget.TabIndex = 1;
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.rbRoots);
            this.gbSearch.Controls.Add(this.rbWords);
            this.gbSearch.Location = new System.Drawing.Point(24, 72);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(189, 96);
            this.gbSearch.TabIndex = 2;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Search";
            // 
            // rbRoots
            // 
            this.rbRoots.AutoSize = true;
            this.rbRoots.Location = new System.Drawing.Point(24, 64);
            this.rbRoots.Name = "rbRoots";
            this.rbRoots.Size = new System.Drawing.Size(101, 22);
            this.rbRoots.TabIndex = 1;
            this.rbRoots.Text = "&Roots only";
            // 
            // rbWords
            // 
            this.rbWords.AutoSize = true;
            this.rbWords.Location = new System.Drawing.Point(24, 32);
            this.rbWords.Name = "rbWords";
            this.rbWords.Size = new System.Drawing.Size(105, 22);
            this.rbWords.TabIndex = 0;
            this.rbWords.Text = "&Words only";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(231, 191);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(363, 191);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkParaFmt
            // 
            this.chkParaFmt.AutoSize = true;
            this.chkParaFmt.Location = new System.Drawing.Point(231, 90);
            this.chkParaFmt.Name = "chkParaFmt";
            this.chkParaFmt.Size = new System.Drawing.Size(210, 22);
            this.chkParaFmt.TabIndex = 3;
            this.chkParaFmt.Text = "Display in &paragraph format";
            // 
            // chkIgnoreTone
            // 
            this.chkIgnoreTone.AutoSize = true;
            this.chkIgnoreTone.Location = new System.Drawing.Point(231, 136);
            this.chkIgnoreTone.Name = "chkIgnoreTone";
            this.chkIgnoreTone.Size = new System.Drawing.Size(186, 22);
            this.chkIgnoreTone.TabIndex = 4;
            this.chkIgnoreTone.Text = "&Ignore syllograph in Text Data";
            this.chkIgnoreTone.UseVisualStyleBackColor = true;
            // 
            // FormWord
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 17);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(490, 238);
            this.Controls.Add(this.chkIgnoreTone);
            this.Controls.Add(this.chkParaFmt);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.tbTarget);
            this.Controls.Add(this.labWord);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormWord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Word Search";
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public string Target
        {
            get { return m_Target;}
        }

        public TargetType Type
        {
            get { return m_Type;}
        }

        public bool ParaFormat
        {
            get { return m_ParaFormat;}
        }

        public bool IgnoreTone
        {
            get { return m_IgnoreTone;}
        }

        private void btnOK_Click(object sender, System.EventArgs e)
		{
			m_Target = this.tbTarget.Text;
			if (this.rbRoots.Checked)
				m_Type = TargetType.Root;
			else m_Type = TargetType.Word;
			m_ParaFormat = this.chkParaFmt.Checked;
            m_IgnoreTone = this.chkIgnoreTone.Checked;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			m_Target = "";
			m_Type = TargetType.Word;
			m_ParaFormat = false;
            m_IgnoreTone = false;
		}

	}
}

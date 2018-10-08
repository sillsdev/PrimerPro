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
	/// Summary description for FormToneWL.
	/// </summary>
	public class FormToneWL : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSO;
		private System.Windows.Forms.Label labTone;
		/// <summary>
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.Container components = null;
        private CheckedListBox clbTones;
        private Button btnUncheck;
        private Button btnCheck;

        //private ToneWLSearch m_Search;			//WordList Tone Search
        private ArrayList m_SelectedTones;
        private SearchOptions m_SearchOptions;
        private PSTable m_PSTable;
        private LocalizationTable m_Table;

		public FormToneWL(Settings s)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            GraphemeInventory gi = s.GraphemeInventory;
            m_PSTable = s.PSTable;
            Font fnt = s.OptionSettings.GetDefaultFont();

			for (int i = 0; i < gi.ToneCount(); i++)
			{
				this.clbTones.Items.Add(gi.GetTone(i).Symbol);
			}
            this.clbTones.Font = fnt;
            m_Table = null;
		}

        public FormToneWL(Settings s, LocalizationTable table)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            GraphemeInventory gi = s.GraphemeInventory;
            m_PSTable = s.PSTable;
            Font fnt = s.OptionSettings.GetDefaultFont();

            for (int i = 0; i < gi.ToneCount(); i++)
            {
                this.clbTones.Items.Add(gi.GetTone(i).Symbol);
            }
            this.clbTones.Font = fnt;
            m_Table = table;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormToneWL));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSO = new System.Windows.Forms.Button();
            this.labTone = new System.Windows.Forms.Label();
            this.clbTones = new System.Windows.Forms.CheckedListBox();
            this.btnUncheck = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(292, 255);
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
            this.btnCancel.Location = new System.Drawing.Point(410, 255);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSO
            // 
            this.btnSO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSO.Location = new System.Drawing.Point(242, 32);
            this.btnSO.Name = "btnSO";
            this.btnSO.Size = new System.Drawing.Size(200, 32);
            this.btnSO.TabIndex = 2;
            this.btnSO.Text = "&Search Options";
            this.btnSO.Click += new System.EventHandler(this.btnSO_Click);
            // 
            // labTone
            // 
            this.labTone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTone.Location = new System.Drawing.Point(24, 32);
            this.labTone.Name = "labTone";
            this.labTone.Size = new System.Drawing.Size(177, 32);
            this.labTone.TabIndex = 0;
            this.labTone.Text = "Select Tones to find";
            this.labTone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // clbTones
            // 
            this.clbTones.CheckOnClick = true;
            this.clbTones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbTones.FormattingEnabled = true;
            this.clbTones.HorizontalScrollbar = true;
            this.clbTones.Location = new System.Drawing.Point(27, 67);
            this.clbTones.Name = "clbTones";
            this.clbTones.Size = new System.Drawing.Size(174, 232);
            this.clbTones.TabIndex = 1;
            this.clbTones.TabStop = false;
            // 
            // btnUncheck
            // 
            this.btnUncheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUncheck.Location = new System.Drawing.Point(410, 120);
            this.btnUncheck.Name = "btnUncheck";
            this.btnUncheck.Size = new System.Drawing.Size(150, 32);
            this.btnUncheck.TabIndex = 4;
            this.btnUncheck.Text = "&Uncheck All";
            this.btnUncheck.UseVisualStyleBackColor = true;
            this.btnUncheck.Click += new System.EventHandler(this.btnUncheck_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.Location = new System.Drawing.Point(242, 120);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(150, 32);
            this.btnCheck.TabIndex = 3;
            this.btnCheck.Text = "&Check All";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // FormToneWL
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(586, 314);
            this.Controls.Add(this.btnUncheck);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.clbTones);
            this.Controls.Add(this.btnSO);
            this.Controls.Add(this.labTone);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormToneWL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tone Search";
            this.ResumeLayout(false);

		}
		#endregion

        public ArrayList SelectedTones
        {
            get { return m_SelectedTones; }
        }

        public SearchOptions SearchOptions
        {
            get { return m_SearchOptions; }
        }

        private void btnOK_Click(object sender, System.EventArgs e)
		{
            if (this.clbTones.CheckedItems.Count > 0)
            {
                string strTone = "";
                m_SelectedTones = new ArrayList();
                foreach (object obj in clbTones.CheckedItems)
                {
                    strTone = obj.ToString();
                    m_SelectedTones.Add(strTone);
                }
            }
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
            m_SelectedTones = null;
			this.Close();
		}

		private void btnSO_Click(object sender, System.EventArgs e)
		{
            SearchOptions so = new SearchOptions(m_PSTable);
            CodeTable ct = (CodeTable) m_PSTable;
            //FormSearchOptions form = new FormSearchOptions(ct, false, false);
            FormSearchOptions form = new FormSearchOptions(ct, false, false, m_Table);
            DialogResult dr= form.ShowDialog();
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

        private void btnCheck_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbTones.Items.Count; i++)
                clbTones.SetItemChecked(i, true);
            clbTones.Show();
        }

        private void btnUncheck_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbTones.Items.Count; i++)
                clbTones.SetItemChecked(i, false);
            clbTones.Show();
        }

        private void UpdateFormForLocalization(LocalizationTable table)
        {
            string strText = "";
            strText = table.GetForm("FormToneWLT");
			if (strText != "")
				this.Text = strText;
            strText = table.GetForm("FormToneWL0");
			if (strText != "")
				this.labTone.Text = strText;
            strText = table.GetForm("FormToneWL2");
			if (strText != "")
				this.btnSO.Text = strText;
            strText = table.GetForm("FormToneWL3");
			if (strText != "")
				this.btnCheck.Text = strText;
            strText = table.GetForm("FormToneWL4");
			if (strText != "")
				this.btnUncheck.Text = strText;
            strText = table.GetForm("FormToneWL5");
			if (strText != "")
				this.btnOK.Text = strText;
            strText = table.GetForm("FormToneWL6");
			if (strText != "")
				this.btnCancel.Text = strText;
            return;
        }

    }
}

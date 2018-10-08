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
	/// Summary description for FormSearchInsertionMode.
	/// </summary>
	public class FormSearchInsertionMode : System.Windows.Forms.Form
	{
		private System.Windows.Forms.RadioButton rbResults;
		private System.Windows.Forms.RadioButton rbDefinitions;
		private System.Windows.Forms.RadioButton rbBoth;
		private System.Windows.Forms.GroupBox gbMode;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        private bool m_SearchInsertionResults;
        private bool m_SearchInsertionDefinitions;

		public FormSearchInsertionMode(Settings s)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m_SearchInsertionResults = s.SearchInsertionResults;
            m_SearchInsertionDefinitions = s.SearchInsertionDefinitions;

			if (m_SearchInsertionDefinitions)
			{
				if (m_SearchInsertionResults)
					this.rbBoth.Checked = true;
				else this.rbDefinitions.Checked = true;
			}
			else this.rbResults.Checked = true;
		}

        public FormSearchInsertionMode(Settings s, LocalizationTable table)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            m_SearchInsertionResults = s.SearchInsertionResults;
            m_SearchInsertionDefinitions = s.SearchInsertionDefinitions;

            if (m_SearchInsertionDefinitions)
            {
                if (m_SearchInsertionResults)
                    this.rbBoth.Checked = true;
                else this.rbDefinitions.Checked = true;
            }
            else this.rbResults.Checked = true;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSearchInsertionMode));
            this.rbResults = new System.Windows.Forms.RadioButton();
            this.rbDefinitions = new System.Windows.Forms.RadioButton();
            this.rbBoth = new System.Windows.Forms.RadioButton();
            this.gbMode = new System.Windows.Forms.GroupBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbResults
            // 
            this.rbResults.CausesValidation = false;
            this.rbResults.Checked = true;
            this.rbResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbResults.Location = new System.Drawing.Point(24, 36);
            this.rbResults.Name = "rbResults";
            this.rbResults.Size = new System.Drawing.Size(372, 25);
            this.rbResults.TabIndex = 1;
            this.rbResults.TabStop = true;
            this.rbResults.Text = "Display search &results only";
            // 
            // rbDefinitions
            // 
            this.rbDefinitions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDefinitions.Location = new System.Drawing.Point(24, 67);
            this.rbDefinitions.Name = "rbDefinitions";
            this.rbDefinitions.Size = new System.Drawing.Size(372, 25);
            this.rbDefinitions.TabIndex = 2;
            this.rbDefinitions.Text = "Display search &definitions only";
            // 
            // rbBoth
            // 
            this.rbBoth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBoth.Location = new System.Drawing.Point(24, 98);
            this.rbBoth.Name = "rbBoth";
            this.rbBoth.Size = new System.Drawing.Size(372, 25);
            this.rbBoth.TabIndex = 3;
            this.rbBoth.Text = "Display &both";
            // 
            // gbMode
            // 
            this.gbMode.Controls.Add(this.rbBoth);
            this.gbMode.Controls.Add(this.rbDefinitions);
            this.gbMode.Controls.Add(this.rbResults);
            this.gbMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMode.Location = new System.Drawing.Point(16, 16);
            this.gbMode.Name = "gbMode";
            this.gbMode.Size = new System.Drawing.Size(438, 145);
            this.gbMode.TabIndex = 0;
            this.gbMode.TabStop = false;
            this.gbMode.Text = "Set Search Insertion Mode";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(108, 198);
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
            this.btnCancel.Location = new System.Drawing.Point(242, 198);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            // 
            // FormSearchInsertionMode
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 17);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(480, 242);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbMode);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSearchInsertionMode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search Insertion Mode";
            this.gbMode.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        public bool SearchInsertionResults
        {
            get { return m_SearchInsertionResults; }
        }

        public bool SearchInsertionDefinitions
        {
            get { return m_SearchInsertionDefinitions; }
        }

        private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (this.rbResults.Checked)
			{
				m_SearchInsertionResults = true;
				m_SearchInsertionDefinitions = false;
			}
			else if (this.rbDefinitions.Checked)
			{
				m_SearchInsertionResults = false;
				m_SearchInsertionDefinitions = true;
			}
			else if (this.rbBoth.Checked)
			{
				m_SearchInsertionResults = true;
				m_SearchInsertionDefinitions = true;
			}
		}

        private void UpdateFormForLocalization(LocalizationTable table)
        {
            string strText = "";
            strText = table.GetForm("FormSearchInsertionModeT");
			if (strText != "")
				this.Text = strText;
            strText = table.GetForm("FormSearchInsertionMode0");
			if (strText != "")
				this.gbMode.Text = strText;
            strText = table.GetForm("FormSearchInsertionMode1");
			if (strText != "")
				this.rbResults.Text = strText;
            strText = table.GetForm("FormSearchInsertionMode2");
			if (strText != "")
				this.rbDefinitions.Text = strText;
            strText = table.GetForm("FormSearchInsertionMode3");
			if (strText != "")
				this.rbBoth.Text = strText;
            strText = table.GetForm("FormSearchInsertionMode4");
			if (strText != "")
				this.btnOK.Text = strText;
            strText = table.GetForm("FormSearchInsertionMode5");
			if (strText != "")
				this.btnCancel.Text = strText;
            return;
        }
	}
}

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
	/// Summary description for FormSight.
	/// </summary>
	public class FormSight : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label labWord;
        private System.Windows.Forms.CheckBox chkParaFmt;
        private CheckedListBox clbWords;
        private Button btnCheck;
        private Button btnUncheck;
        private TextBox tbStory;
        private Button btnStory;
        private Label labStory;

        private ArrayList m_SelectedWords;
        private string m_StoryFileName;
        private bool m_ParaFormat;
        private string m_Folder;
        private LocalizationTable m_Table;      //Localization table

		public FormSight(SightWords sw, string folder)
		{
			InitializeComponent();
			for (int i = 0; i < sw.Count(); i++)
            {
                clbWords.Items.Add(sw.GetWord(i));
            }
            chkParaFmt.Checked = false;
            m_SelectedWords = new ArrayList();
            m_StoryFileName = "";
            m_ParaFormat = false;
            m_Folder = folder;
            m_Table = null;
		}

        public FormSight(SightWords sw, string folder, LocalizationTable table)
        {
            InitializeComponent();
            for (int i = 0; i < sw.Count(); i++)
            {
                clbWords.Items.Add(sw.GetWord(i));
            }
            chkParaFmt.Checked = false;
            m_SelectedWords = new ArrayList();
            m_StoryFileName = "";
            m_ParaFormat = false;
            m_Folder = folder;
            m_Table = table;

            this.UpdateFormForLocalization(table);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSight));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.labWord = new System.Windows.Forms.Label();
            this.chkParaFmt = new System.Windows.Forms.CheckBox();
            this.clbWords = new System.Windows.Forms.CheckedListBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnUncheck = new System.Windows.Forms.Button();
            this.tbStory = new System.Windows.Forms.TextBox();
            this.btnStory = new System.Windows.Forms.Button();
            this.labStory = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(421, 299);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(594, 299);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labWord
            // 
            this.labWord.AutoSize = true;
            this.labWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labWord.Location = new System.Drawing.Point(24, 88);
            this.labWord.Name = "labWord";
            this.labWord.Size = new System.Drawing.Size(247, 18);
            this.labWord.TabIndex = 3;
            this.labWord.Text = "Select sight words to find in story file";
            // 
            // chkParaFmt
            // 
            this.chkParaFmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkParaFmt.Location = new System.Drawing.Point(371, 114);
            this.chkParaFmt.Name = "chkParaFmt";
            this.chkParaFmt.Size = new System.Drawing.Size(229, 40);
            this.chkParaFmt.TabIndex = 5;
            this.chkParaFmt.Text = "Display in &paragraph format";
            // 
            // clbWords
            // 
            this.clbWords.CheckOnClick = true;
            this.clbWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbWords.FormattingEnabled = true;
            this.clbWords.HorizontalScrollbar = true;
            this.clbWords.Location = new System.Drawing.Point(27, 114);
            this.clbWords.Name = "clbWords";
            this.clbWords.Size = new System.Drawing.Size(318, 232);
            this.clbWords.TabIndex = 4;
            this.clbWords.TabStop = false;
            // 
            // btnCheck
            // 
            this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.Location = new System.Drawing.Point(371, 188);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(150, 32);
            this.btnCheck.TabIndex = 6;
            this.btnCheck.Text = "&Check all";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnUncheck
            // 
            this.btnUncheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUncheck.Location = new System.Drawing.Point(544, 188);
            this.btnUncheck.Name = "btnUncheck";
            this.btnUncheck.Size = new System.Drawing.Size(150, 32);
            this.btnUncheck.TabIndex = 7;
            this.btnUncheck.Text = "&Uncheck all";
            this.btnUncheck.UseVisualStyleBackColor = true;
            this.btnUncheck.Click += new System.EventHandler(this.btnUncheck_Click);
            // 
            // tbStory
            // 
            this.tbStory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStory.Location = new System.Drawing.Point(131, 24);
            this.tbStory.Multiline = true;
            this.tbStory.Name = "tbStory";
            this.tbStory.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbStory.Size = new System.Drawing.Size(457, 44);
            this.tbStory.TabIndex = 1;
            // 
            // btnStory
            // 
            this.btnStory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStory.Location = new System.Drawing.Point(594, 24);
            this.btnStory.Name = "btnStory";
            this.btnStory.Size = new System.Drawing.Size(100, 32);
            this.btnStory.TabIndex = 2;
            this.btnStory.Text = "Bro&wse";
            this.btnStory.Click += new System.EventHandler(this.btnStory_Click);
            // 
            // labStory
            // 
            this.labStory.AutoSize = true;
            this.labStory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labStory.Location = new System.Drawing.Point(24, 33);
            this.labStory.Name = "labStory";
            this.labStory.Size = new System.Drawing.Size(65, 18);
            this.labStory.TabIndex = 0;
            this.labStory.Text = "Story file";
            // 
            // FormSight
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(710, 370);
            this.Controls.Add(this.tbStory);
            this.Controls.Add(this.btnStory);
            this.Controls.Add(this.labStory);
            this.Controls.Add(this.btnUncheck);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.clbWords);
            this.Controls.Add(this.chkParaFmt);
            this.Controls.Add(this.labWord);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSight";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sight Word Search";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        public ArrayList SelectedWords
        {
            get { return m_SelectedWords; }
        }

        public string StoryFileName
        {
            get { return m_StoryFileName; }
        }

        public bool ParaFormat
        {
            get { return m_ParaFormat; }
        }

        private void btnOK_Click(object sender, System.EventArgs e)
		{
            string strText = "";
            if (this.tbStory.Text == "")
            {
                if (m_Table == null)
                    MessageBox.Show("Story File not specified");
                else
                {
                    strText = m_Table.GetMessage("FormSight1");
                    if (strText == "")
                        strText = "Story File not specified";
                    MessageBox.Show(strText);
                }
            }
            else m_StoryFileName = this.tbStory.Text;
            
            if (this.clbWords.CheckedItems.Count > 0)
            {
                string strWord = "";
                foreach(object obj in clbWords.CheckedItems)
                {
                    strWord = obj.ToString();
                    m_SelectedWords.Add(strWord);
                }
            }
			m_ParaFormat = chkParaFmt.Checked;
  		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
            m_SelectedWords = null;
			m_ParaFormat = false;
            m_StoryFileName = "";
		}

        private void btnCheck_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbWords.Items.Count; i++)
                clbWords.SetItemChecked(i, true);
            clbWords.Show();
        }

        private void btnUncheck_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbWords.Items.Count; i++)
                clbWords.SetItemChecked(i, false);
            clbWords.Show();
        }

        private void btnStory_Click(object sender, EventArgs e)
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
                this.tbStory.Text = ofd.FileName;
            }
        }

        private void UpdateFormForLocalization(LocalizationTable table)
        {
            string strText = "";
            strText = table.GetForm("FormSightT");
			if (strText != "")
				this.Text = strText;
            strText = table.GetForm("FormSight0");
			if (strText != "")
				this.labStory.Text = strText;
            strText = table.GetForm("FormSight2");
			if (strText != "")
				this.btnStory.Text = strText;
            strText = table.GetForm("FormSight3");
			if (strText != "")
				this.labWord.Text = strText;
            strText = table.GetForm("FormSight5");
			if (strText != "")
				this.chkParaFmt.Text = strText;
            strText = table.GetForm("FormSight6");
			if (strText != "")
				this.btnCheck.Text = strText;
            strText = table.GetForm("FormSight7");
			if (strText != "")
				this.btnUncheck.Text = strText;
            strText = table.GetForm("FormSight8");
			if (strText != "")
				this.btnOK.Text = strText;
            strText = table.GetForm("FormSight9");
			if (strText != "")
				this.btnCancel.Text = strText;
            return;
        }

    }
}

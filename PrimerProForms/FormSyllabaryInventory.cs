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
	/// Summary description for FormToneInventory.
	/// </summary>
	public class FormSyllographInventory : System.Windows.Forms.Form
	{
		private Settings m_Settings;
        private int nCurrent;	            //index of current syllograph
		private Syllograph syllograph;		//current syllograph
        private bool fIsUpdated;            //Indicated the iventory has been updated

        //private const string cSaveText = "Do you want to save changes?";
        //private const string cSaveCaption = "Save Displayed Changes";

		private System.Windows.Forms.TextBox tbFind;
		private System.Windows.Forms.Button btnFind;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.TextBox tbCount;
		private System.Windows.Forms.Label labOf;
		private System.Windows.Forms.TextBox tbCurrent;
		private System.Windows.Forms.Label labSyllograph;
		private System.Windows.Forms.Button btnPrevious;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox tbSyllograph;
        private TextBox tbUC;
        private Label labUC;
        private TextBox tbPrimary;
        private TextBox tbSecondary;
        private Label labPrimary;
        private Label labSecondary;
        private Label labTertiary;
        private TextBox tbTertiary;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormSyllographInventory(Settings s)
		{
			InitializeComponent();
            if (s == null)
                m_Settings = new Settings();
			else m_Settings = s;
            Font font = m_Settings.OptionSettings.GetDefaultFont();
            this.tbSyllograph.Font = font;
            this.tbUC.Font = font;
            this.tbFind.Font = font;
            this.tbPrimary.Font = font;
            this.tbSecondary.Font = font;
            this.tbTertiary.Font = font;
            nCurrent = 0;		//First Tone
            fIsUpdated = false;

            LocalizationTable table = m_Settings.LocalizationTable;
            string lang = m_Settings.OptionSettings.UILanguage;
            this.Text = table.GetForm("FormSyllographInventoryT", lang);
            this.labSyllograph.Text = table.GetForm("FormSyllographInventory0", lang);
            this.labOf.Text = table.GetForm("FormSyllographInventory3", lang);
            this.labUC.Text = table.GetForm("FormSyllographInventory5", lang);
            this.labPrimary.Text = table.GetForm("FormSyllographInventory7", lang);
            this.labSecondary.Text = table.GetForm("FormSyllographInventory9", lang);
            this.labTertiary.Text = table.GetForm("FormSyllographInventory11", lang);
            this.btnPrevious.Text = table.GetForm("FormSyllographInventory13", lang);
            this.btnNext.Text = table.GetForm("FormSyllographInventory14", lang);
            this.btnAdd.Text = table.GetForm("FormSyllographInventory15", lang);
            this.btnDelete.Text = table.GetForm("FormSyllographInventory16", lang);
            this.btnFind.Text = table.GetForm("FormSyllographInventory18", lang);
            this.btnSave.Text = table.GetForm("FormSyllographInventory19", lang);
            this.btnExit.Text = table.GetForm("FormSyllographInventory20", lang);

            Redisplay();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSyllographInventory));
            this.tbFind = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbCount = new System.Windows.Forms.TextBox();
            this.labOf = new System.Windows.Forms.Label();
            this.tbCurrent = new System.Windows.Forms.TextBox();
            this.tbSyllograph = new System.Windows.Forms.TextBox();
            this.labSyllograph = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.tbUC = new System.Windows.Forms.TextBox();
            this.labUC = new System.Windows.Forms.Label();
            this.tbPrimary = new System.Windows.Forms.TextBox();
            this.tbSecondary = new System.Windows.Forms.TextBox();
            this.labPrimary = new System.Windows.Forms.Label();
            this.labSecondary = new System.Windows.Forms.Label();
            this.labTertiary = new System.Windows.Forms.Label();
            this.tbTertiary = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbFind
            // 
            this.tbFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFind.Location = new System.Drawing.Point(240, 198);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(83, 23);
            this.tbFind.TabIndex = 17;
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Location = new System.Drawing.Point(328, 198);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(86, 26);
            this.btnFind.TabIndex = 18;
            this.btnFind.Text = "&Find";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(331, 251);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(86, 27);
            this.btnExit.TabIndex = 20;
            this.btnExit.Text = "E&xit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(240, 251);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 27);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbCount
            // 
            this.tbCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCount.Location = new System.Drawing.Point(201, 26);
            this.tbCount.Name = "tbCount";
            this.tbCount.ReadOnly = true;
            this.tbCount.Size = new System.Drawing.Size(28, 14);
            this.tbCount.TabIndex = 4;
            this.tbCount.TabStop = false;
            this.tbCount.Text = "???";
            this.tbCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labOf
            // 
            this.labOf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labOf.Location = new System.Drawing.Point(181, 26);
            this.labOf.Name = "labOf";
            this.labOf.Size = new System.Drawing.Size(20, 18);
            this.labOf.TabIndex = 3;
            this.labOf.Text = "of";
            this.labOf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbCurrent
            // 
            this.tbCurrent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCurrent.Location = new System.Drawing.Point(147, 26);
            this.tbCurrent.Name = "tbCurrent";
            this.tbCurrent.ReadOnly = true;
            this.tbCurrent.Size = new System.Drawing.Size(27, 14);
            this.tbCurrent.TabIndex = 2;
            this.tbCurrent.TabStop = false;
            this.tbCurrent.Text = "???";
            this.tbCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbSyllograph
            // 
            this.tbSyllograph.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSyllograph.Location = new System.Drawing.Point(93, 26);
            this.tbSyllograph.Name = "tbSyllograph";
            this.tbSyllograph.Size = new System.Drawing.Size(41, 21);
            this.tbSyllograph.TabIndex = 1;
            this.tbSyllograph.Enter += new System.EventHandler(this.tbTone_Syllograph);
            this.tbSyllograph.Leave += new System.EventHandler(this.tbSyllograph_Leave);
            // 
            // labSyllograph
            // 
            this.labSyllograph.AutoSize = true;
            this.labSyllograph.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labSyllograph.Location = new System.Drawing.Point(21, 26);
            this.labSyllograph.Name = "labSyllograph";
            this.labSyllograph.Size = new System.Drawing.Size(65, 15);
            this.labSyllograph.TabIndex = 0;
            this.labSyllograph.Text = "Syllograph";
            this.labSyllograph.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(331, 66);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(86, 26);
            this.btnPrevious.TabIndex = 13;
            this.btnPrevious.Text = "&Previous";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(331, 160);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(86, 26);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(331, 128);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(86, 27);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "&Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(331, 97);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(86, 27);
            this.btnNext.TabIndex = 14;
            this.btnNext.Text = "&Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tbUC
            // 
            this.tbUC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUC.Location = new System.Drawing.Point(327, 25);
            this.tbUC.Name = "tbUC";
            this.tbUC.Size = new System.Drawing.Size(42, 21);
            this.tbUC.TabIndex = 6;
            // 
            // labUC
            // 
            this.labUC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labUC.Location = new System.Drawing.Point(237, 26);
            this.labUC.Name = "labUC";
            this.labUC.Size = new System.Drawing.Size(83, 18);
            this.labUC.TabIndex = 5;
            this.labUC.Text = "Upper Case";
            // 
            // tbPrimary
            // 
            this.tbPrimary.Location = new System.Drawing.Point(165, 66);
            this.tbPrimary.Name = "tbPrimary";
            this.tbPrimary.Size = new System.Drawing.Size(55, 21);
            this.tbPrimary.TabIndex = 8;
            // 
            // tbSecondary
            // 
            this.tbSecondary.Location = new System.Drawing.Point(165, 107);
            this.tbSecondary.Name = "tbSecondary";
            this.tbSecondary.Size = new System.Drawing.Size(55, 21);
            this.tbSecondary.TabIndex = 10;
            // 
            // labPrimary
            // 
            this.labPrimary.AutoSize = true;
            this.labPrimary.Location = new System.Drawing.Point(21, 66);
            this.labPrimary.Name = "labPrimary";
            this.labPrimary.Size = new System.Drawing.Size(100, 15);
            this.labPrimary.TabIndex = 7;
            this.labPrimary.Text = "Primary Category";
            // 
            // labSecondary
            // 
            this.labSecondary.AutoSize = true;
            this.labSecondary.Location = new System.Drawing.Point(21, 107);
            this.labSecondary.Name = "labSecondary";
            this.labSecondary.Size = new System.Drawing.Size(116, 15);
            this.labSecondary.TabIndex = 9;
            this.labSecondary.Text = "Secondary Category";
            // 
            // labTertiary
            // 
            this.labTertiary.AutoSize = true;
            this.labTertiary.Location = new System.Drawing.Point(21, 151);
            this.labTertiary.Name = "labTertiary";
            this.labTertiary.Size = new System.Drawing.Size(98, 15);
            this.labTertiary.TabIndex = 11;
            this.labTertiary.Text = "Tertiary Category";
            // 
            // tbTertiary
            // 
            this.tbTertiary.Location = new System.Drawing.Point(165, 148);
            this.tbTertiary.Name = "tbTertiary";
            this.tbTertiary.Size = new System.Drawing.Size(55, 21);
            this.tbTertiary.TabIndex = 12;
            // 
            // FormSyllographInventory
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(509, 364);
            this.Controls.Add(this.tbTertiary);
            this.Controls.Add(this.labTertiary);
            this.Controls.Add(this.labSecondary);
            this.Controls.Add(this.labPrimary);
            this.Controls.Add(this.tbSecondary);
            this.Controls.Add(this.tbPrimary);
            this.Controls.Add(this.tbUC);
            this.Controls.Add(this.labUC);
            this.Controls.Add(this.tbFind);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbCount);
            this.Controls.Add(this.labOf);
            this.Controls.Add(this.tbCurrent);
            this.Controls.Add(this.tbSyllograph);
            this.Controls.Add(this.labSyllograph);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnNext);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSyllographInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Syllograph Inventory";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private void tbTone_Syllograph(object sender, EventArgs e)
        {
            if (m_Settings.GraphemeInventory.SyllographCount() == 0)
            {
                Syllograph syllograph = new Syllograph(" ");
                int nCount = m_Settings.GraphemeInventory.SyllographCount();
                m_Settings.GraphemeInventory.AddSyllograph(syllograph);
                nCurrent = nCount;
                Redisplay();
            }
        }

        private void tbSyllograph_Leave(object sender, EventArgs e)
        {
            string str;
            if (this.tbUC.Text == "")
            {
                str = this.tbSyllograph.Text;
                if (str.Length > 1)
                    str = str.Substring(0, 1).ToUpper() + str.Substring(1);
                else str = str.ToUpper();
                this.tbUC.Text = str;
            }
        }

        private void btnPrevious_Click(object sender, System.EventArgs e)
		{
            if (HasChanged())
            {
                //if (MessageBox.Show(cSaveText, cSaveCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                //    SaveIt();
                string strText = m_Settings.LocalizationTable.GetMessage("FormSyllographInventory1",
                    m_Settings.OptionSettings.UILanguage);
                string strCaption = m_Settings.LocalizationTable.GetMessage("FormSyllographInventory2",
                    m_Settings.OptionSettings.UILanguage);
                if (MessageBox.Show(strText, strCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    SaveIt();
            }
			if (nCurrent > 0 )
				nCurrent--;
			Redisplay();
		}

		private void btnNext_Click(object sender, System.EventArgs e)
		{
            if (HasChanged())
            {
                //if (MessageBox.Show(cSaveText, cSaveCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                //    SaveIt();
                string strText = m_Settings.LocalizationTable.GetMessage("FormSyllographInventory1",
                    m_Settings.OptionSettings.UILanguage);
                string strCaption = m_Settings.LocalizationTable.GetMessage("FormSyllographInventory2",
                    m_Settings.OptionSettings.UILanguage);
                if (MessageBox.Show(strText, strCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    SaveIt();
            }
			if ( nCurrent < (m_Settings.GraphemeInventory.SyllographCount()-1) )
				nCurrent++;
			Redisplay();
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
            if (HasChanged())
            {
                //if (MessageBox.Show(cSaveText, cSaveCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                //    SaveIt();
                string strText = m_Settings.LocalizationTable.GetMessage("FormSyllographInventory1",
                    m_Settings.OptionSettings.UILanguage);
                string strCaption = m_Settings.LocalizationTable.GetMessage("FormSyllographInventory2",
                    m_Settings.OptionSettings.UILanguage);
                if (MessageBox.Show(strText, strCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    SaveIt();
            }
			Syllograph syllograph = new Syllograph(" ");
			int nCount = m_Settings.GraphemeInventory.SyllographCount();
			m_Settings.GraphemeInventory.AddSyllograph(syllograph);
			nCurrent = nCount;
			Redisplay();
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			int next = nCurrent;
			m_Settings.GraphemeInventory.DelSyllograph(nCurrent);
			if ( next < m_Settings.GraphemeInventory.SyllographCount() )
				nCurrent = next;
			else nCurrent = m_Settings.GraphemeInventory.SyllographCount() - 1;
            fIsUpdated = true;
			Redisplay();
		}

		private void btnFind_Click(object sender, System.EventArgs e)
		{
            if (HasChanged())
            {
                //if (MessageBox.Show(cSaveText, cSaveCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                //    SaveIt();
                string strText = m_Settings.LocalizationTable.GetMessage("FormSyllographInventory1",
                    m_Settings.OptionSettings.UILanguage);
                string strCaption = m_Settings.LocalizationTable.GetMessage("FormSyllographInventory2",
                    m_Settings.OptionSettings.UILanguage);
                if (MessageBox.Show(strText, strCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    SaveIt();
            }
			string strSymbol = this.tbFind.Text.Trim();
			int n = 0;
            if (strSymbol != "")
            {
                n = m_Settings.GraphemeInventory.FindSyllographIndex(strSymbol);
                if ((n >= 0) && (n < m_Settings.GraphemeInventory.SyllographCount()))
                {
                    nCurrent = n;
                    Redisplay();
                }
                //else MessageBox.Show("Grapheme not found");
                else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("FormSyllographInventory3",
                    m_Settings.OptionSettings.UILanguage));
            }
            //else MessageBox.Show("Grapheme must be specified in the adjacent box");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("FormSyllographInventory4",
                m_Settings.OptionSettings.UILanguage));
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
            SaveIt();
            return;
        }
		
        private void SaveIt()
        {
            string strSymbol = this.tbSyllograph.Text.Trim();
			if (strSymbol != "")
			{
				if ( (!m_Settings.GraphemeInventory.IsInInventory(strSymbol)) 
					|| (nCurrent ==  m_Settings.GraphemeInventory.GetGraphemeIndex(strSymbol)) )
				{
					syllograph.Symbol = strSymbol;
                    syllograph.UpperCase = this.tbUC.Text;
                    syllograph.CategoryPrimary = this.tbPrimary.Text;
                    syllograph.CategorySecondary = this.tbSecondary.Text;
                    syllograph.CategoryTertiary = this.tbTertiary.Text;
                    fIsUpdated = true;
                    //MessageBox.Show("Syllograph saved");
                    MessageBox.Show(m_Settings.LocalizationTable.GetMessage("FormSyllographInventory6",
                        m_Settings.OptionSettings.UILanguage));
                }
				else 
				{
                    //MessageBox.Show("Syllograph is already in inventory");
                    MessageBox.Show(m_Settings.LocalizationTable.GetMessage("FormSyllographInventory7",
                        m_Settings.OptionSettings.UILanguage));
                    syllograph = m_Settings.GraphemeInventory.GetSyllograph(nCurrent);
					this.tbSyllograph.Text = syllograph.Symbol;
				}
			}
            //else MessageBox.Show("Syllograph must be specified");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("FormSyllographInventory8",
                m_Settings.OptionSettings.UILanguage));
        }

		private void btnExit_Click(object sender, System.EventArgs e)
		{
            if (HasChanged())
            {
                //if (MessageBox.Show(cSaveText, cSaveCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                //    SaveIt();
                string strText = m_Settings.LocalizationTable.GetMessage("FormSyllographInventory1",
                    m_Settings.OptionSettings.UILanguage);
                string strCaption = m_Settings.LocalizationTable.GetMessage("FormSyllographInventory2",
                    m_Settings.OptionSettings.UILanguage);
                if (MessageBox.Show(strText, strCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    SaveIt();
            }
            if (fIsUpdated)
                //MessageBox.Show("Since the grapheme inventory has been updated, you need to reimport the word list and text data.");
                MessageBox.Show(m_Settings.LocalizationTable.GetMessage("FormSyllographInventory9",
                    m_Settings.OptionSettings.UILanguage));
            this.Close();
		}

		private void AtClosed(object sender, System.EventArgs e)
		{
            GraphemeInventory gi = m_Settings.GraphemeInventory;
			int nSyllograph = gi.SyllographCount();
            if (nSyllograph > 0)
            {
			    Syllograph syllograph = null;
                for (int i = nSyllograph; 0 < i; i--)
			    {
				    syllograph = m_Settings.GraphemeInventory.GetSyllograph(i - 1);
                    if (syllograph == null)
                       gi.DelSyllograph(i - 1);
				    else if (syllograph.Symbol.Trim() == "")
                       gi.DelSyllograph(i - 1);
			    }
                m_Settings.GraphemeInventory = gi;
            }
		}

		private void Redisplay ()
		{
			int n = 0;
            if (m_Settings.GraphemeInventory.SyllographCount() > 0)
            {
                n = nCurrent + 1;
                syllograph = m_Settings.GraphemeInventory.GetSyllograph(nCurrent);
            }
            else
            {
                syllograph = new Syllograph(" ");
            }
			
            this.tbFind.Text = "";					// Clear Find box
			this.tbSyllograph.Text = syllograph.Symbol;
            this.tbUC.Text = syllograph.UpperCase;
			this.tbCurrent.Text = n.ToString();
			this.tbCount.Text = m_Settings.GraphemeInventory.SyllographCount().ToString();
            this.tbPrimary.Text = syllograph.CategoryPrimary;
            this.tbSecondary.Text = syllograph.CategorySecondary;
            this.tbTertiary.Text = syllograph.CategoryTertiary;
            this.tbSyllograph.Focus();
		}

        private bool HasChanged()
        {
            bool fChange = false;
            Syllograph syllograph = null;
            int n = 0;
            if (m_Settings.GraphemeInventory.SyllographCount() > 0)
            {
                n = nCurrent + 1;
                syllograph = m_Settings.GraphemeInventory.GetSyllograph(nCurrent);
            }
            else return fChange;

            if (this.tbSyllograph.Text != syllograph.Symbol) fChange = true;
            if (this.tbUC.Text != syllograph.UpperCase) fChange = true;
            if (this.tbPrimary.Text != syllograph.CategoryPrimary) fChange = true;
            if (this.tbSecondary.Text != syllograph.CategorySecondary) fChange = true;
            if (this.tbTertiary.Text != syllograph.CategoryTertiary) fChange = true;
            return fChange;
        }

	}
}

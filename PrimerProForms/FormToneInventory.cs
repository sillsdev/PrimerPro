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
	/// Summary description for FormToneInventory.
	/// </summary>
	public class FormToneInventory : System.Windows.Forms.Form
	{
		private Settings m_Settings;
		private int nCurrent;	    //index of current syllograph
		private Tone tone;		    //current syllograph
        private bool fIsUpdated;    //Indicated the inventory has been updated

        //private const string cSaveText = "Do you want to save changes?";
        //private const string cSaveCaption = "Save Displayed Changes";

		private System.Windows.Forms.TextBox tbFind;
		private System.Windows.Forms.Button btnFind;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.TextBox tbCount;
		private System.Windows.Forms.Label labOf;
		private System.Windows.Forms.TextBox tbCurrent;
		private System.Windows.Forms.Label labTone;
		private System.Windows.Forms.Button btnPrevious;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.TextBox tbTone;
		private System.Windows.Forms.Label labLevel;
		private System.Windows.Forms.TextBox tbLevel;
		private System.Windows.Forms.Label labTBU;
		private System.Windows.Forms.TextBox tbTBU;
        private TextBox tbUC;
        private Label labUC;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormToneInventory(Settings s)
		{
			InitializeComponent();
            if (s == null)
                m_Settings = new Settings();
			else m_Settings = s;
            Font font = m_Settings.OptionSettings.GetDefaultFont();
            this.tbTone.Font = font;
            this.tbUC.Font = font;
            this.tbFind.Font = font;
            nCurrent = 0;		//First Tone
            fIsUpdated = false;

            LocalizationTable table = m_Settings.LocalizationTable;
            string lang = m_Settings.OptionSettings.UILanguage;
            this.Text = table.GetForm("FormToneInventoryT", lang);
            this.labTone.Text = table.GetForm("FormToneInventory0", lang);
            this.labOf.Text = table.GetForm("FormToneInventory3", lang);
            this.labUC.Text = table.GetForm("FormToneInventory5", lang);
            this.labLevel.Text = table.GetForm("FormToneInventory7", lang);
            this.labTBU.Text = table.GetForm("FormToneInventory9", lang);
            this.btnPrevious.Text = table.GetForm("FormToneInventory11", lang);
            this.btnNext.Text = table.GetForm("FormToneInventory12", lang);
            this.btnAdd.Text = table.GetForm("FormToneInventory13", lang);
            this.btnDelete.Text = table.GetForm("FormToneInventory14", lang);
            this.btnFind.Text = table.GetForm("FormToneInventory16", lang);
            this.btnSave.Text = table.GetForm("FormToneInventory17", lang);
            this.btnExit.Text = table.GetForm("FormToneInventory18", lang);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormToneInventory));
            this.tbFind = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbCount = new System.Windows.Forms.TextBox();
            this.labOf = new System.Windows.Forms.Label();
            this.tbCurrent = new System.Windows.Forms.TextBox();
            this.tbTone = new System.Windows.Forms.TextBox();
            this.labTone = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.labLevel = new System.Windows.Forms.Label();
            this.tbLevel = new System.Windows.Forms.TextBox();
            this.labTBU = new System.Windows.Forms.Label();
            this.tbTBU = new System.Windows.Forms.TextBox();
            this.tbUC = new System.Windows.Forms.TextBox();
            this.labUC = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbFind
            // 
            this.tbFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFind.Location = new System.Drawing.Point(280, 240);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(97, 27);
            this.tbFind.TabIndex = 15;
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Location = new System.Drawing.Point(383, 240);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(100, 32);
            this.btnFind.TabIndex = 16;
            this.btnFind.Text = "&Find";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(386, 305);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 32);
            this.btnExit.TabIndex = 18;
            this.btnExit.Text = "E&xit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(280, 305);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 32);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbCount
            // 
            this.tbCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCount.Location = new System.Drawing.Point(216, 32);
            this.tbCount.Name = "tbCount";
            this.tbCount.ReadOnly = true;
            this.tbCount.Size = new System.Drawing.Size(32, 17);
            this.tbCount.TabIndex = 4;
            this.tbCount.TabStop = false;
            this.tbCount.Text = "???";
            this.tbCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labOf
            // 
            this.labOf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labOf.Location = new System.Drawing.Point(192, 32);
            this.labOf.Name = "labOf";
            this.labOf.Size = new System.Drawing.Size(24, 22);
            this.labOf.TabIndex = 3;
            this.labOf.Text = "of";
            this.labOf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbCurrent
            // 
            this.tbCurrent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCurrent.Location = new System.Drawing.Point(152, 32);
            this.tbCurrent.Name = "tbCurrent";
            this.tbCurrent.ReadOnly = true;
            this.tbCurrent.Size = new System.Drawing.Size(32, 17);
            this.tbCurrent.TabIndex = 2;
            this.tbCurrent.TabStop = false;
            this.tbCurrent.Text = "???";
            this.tbCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbTone
            // 
            this.tbTone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTone.Location = new System.Drawing.Point(80, 24);
            this.tbTone.Name = "tbTone";
            this.tbTone.Size = new System.Drawing.Size(40, 24);
            this.tbTone.TabIndex = 1;
            this.tbTone.Leave += new System.EventHandler(this.tbTone_Leave);
            this.tbTone.Enter += new System.EventHandler(this.tbTone_Enter);
            // 
            // labTone
            // 
            this.labTone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTone.Location = new System.Drawing.Point(24, 32);
            this.labTone.Name = "labTone";
            this.labTone.Size = new System.Drawing.Size(50, 23);
            this.labTone.TabIndex = 0;
            this.labTone.Text = "Tone";
            // 
            // btnPrevious
            // 
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(386, 80);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(100, 32);
            this.btnPrevious.TabIndex = 11;
            this.btnPrevious.Text = "&Previous";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(386, 194);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 32);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(386, 156);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 32);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "&Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(386, 118);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 32);
            this.btnNext.TabIndex = 12;
            this.btnNext.Text = "&Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // labLevel
            // 
            this.labLevel.AutoSize = true;
            this.labLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labLevel.Location = new System.Drawing.Point(24, 104);
            this.labLevel.Name = "labLevel";
            this.labLevel.Size = new System.Drawing.Size(154, 18);
            this.labLevel.TabIndex = 7;
            this.labLevel.Text = "Level (High, Mid, Low)";
            // 
            // tbLevel
            // 
            this.tbLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLevel.Location = new System.Drawing.Point(27, 128);
            this.tbLevel.Name = "tbLevel";
            this.tbLevel.Size = new System.Drawing.Size(213, 24);
            this.tbLevel.TabIndex = 8;
            // 
            // labTBU
            // 
            this.labTBU.AutoSize = true;
            this.labTBU.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTBU.Location = new System.Drawing.Point(24, 207);
            this.labTBU.Name = "labTBU";
            this.labTBU.Size = new System.Drawing.Size(174, 18);
            this.labTBU.TabIndex = 9;
            this.labTBU.Text = "Tone Bearing Unit (if any)";
            // 
            // tbTBU
            // 
            this.tbTBU.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTBU.Location = new System.Drawing.Point(27, 240);
            this.tbTBU.Name = "tbTBU";
            this.tbTBU.Size = new System.Drawing.Size(64, 24);
            this.tbTBU.TabIndex = 10;
            // 
            // tbUC
            // 
            this.tbUC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUC.Location = new System.Drawing.Point(382, 30);
            this.tbUC.Name = "tbUC";
            this.tbUC.Size = new System.Drawing.Size(65, 24);
            this.tbUC.TabIndex = 6;
            // 
            // labUC
            // 
            this.labUC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labUC.Location = new System.Drawing.Point(277, 31);
            this.labUC.Name = "labUC";
            this.labUC.Size = new System.Drawing.Size(96, 23);
            this.labUC.TabIndex = 5;
            this.labUC.Text = "Upper Case";
            // 
            // FormToneInventory
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 17);
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(509, 364);
            this.Controls.Add(this.tbUC);
            this.Controls.Add(this.labUC);
            this.Controls.Add(this.tbTBU);
            this.Controls.Add(this.labTBU);
            this.Controls.Add(this.tbLevel);
            this.Controls.Add(this.labLevel);
            this.Controls.Add(this.tbFind);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbCount);
            this.Controls.Add(this.labOf);
            this.Controls.Add(this.tbCurrent);
            this.Controls.Add(this.tbTone);
            this.Controls.Add(this.labTone);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnNext);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormToneInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Tone Inventory";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private void tbTone_Enter(object sender, EventArgs e)
        {
            if (m_Settings.GraphemeInventory.ToneCount() == 0)
            {
                Tone tone = new Tone(" ");
                int nCount = m_Settings.GraphemeInventory.ToneCount();
                m_Settings.GraphemeInventory.AddTone(tone);
                nCurrent = nCount;
                Redisplay();
            }
        }

        private void tbTone_Leave(object sender, EventArgs e)
        {
            string str;
            if (this.tbUC.Text == "")
            {
                str = this.tbTone.Text;
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
                string strText = m_Settings.LocalizationTable.GetMessage("FormToneInventory1",
                    m_Settings.OptionSettings.UILanguage);
                string strCaption = m_Settings.LocalizationTable.GetMessage("FormToneInventory2",
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
                string strText = m_Settings.LocalizationTable.GetMessage("FormToneInventory1",
                    m_Settings.OptionSettings.UILanguage);
                string strCaption = m_Settings.LocalizationTable.GetMessage("FormToneInventory2",
                    m_Settings.OptionSettings.UILanguage);
                if (MessageBox.Show(strText, strCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    SaveIt();
            }
			if ( nCurrent < (m_Settings.GraphemeInventory.ToneCount()-1) )
				nCurrent++;
			Redisplay();
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
            if (HasChanged())
            {
                //if (MessageBox.Show(cSaveText, cSaveCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                //    SaveIt();
                string strText = m_Settings.LocalizationTable.GetMessage("FormToneInventory1",
                    m_Settings.OptionSettings.UILanguage);
                string strCaption = m_Settings.LocalizationTable.GetMessage("FormToneInventory2",
                    m_Settings.OptionSettings.UILanguage);
                if (MessageBox.Show(strText, strCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    SaveIt();
            }
			Tone tone = new Tone(" ");
			int nCount = m_Settings.GraphemeInventory.ToneCount();
			m_Settings.GraphemeInventory.AddTone(tone);
			nCurrent = nCount;
			Redisplay();
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			int next = nCurrent;
			m_Settings.GraphemeInventory.DelTone(nCurrent);
			if ( next < m_Settings.GraphemeInventory.ToneCount() )
				nCurrent = next;
			else nCurrent = m_Settings.GraphemeInventory.ToneCount() - 1;
            fIsUpdated = true;
			Redisplay();
		}

		private void btnFind_Click(object sender, System.EventArgs e)
		{
            if (HasChanged())
            {
                //if (MessageBox.Show(cSaveText, cSaveCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                //    SaveIt();
                string strText = m_Settings.LocalizationTable.GetMessage("FormToneInventory1",
                    m_Settings.OptionSettings.UILanguage);
                string strCaption = m_Settings.LocalizationTable.GetMessage("FormToneInventory2",
                    m_Settings.OptionSettings.UILanguage);
                if (MessageBox.Show(strText, strCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    SaveIt();
            }
			string strSymbol = this.tbFind.Text.Trim();
			int n = 0;
            if (strSymbol != "")
            {
                n = m_Settings.GraphemeInventory.FindToneIndex(strSymbol);
                if ((n >= 0) && (n < m_Settings.GraphemeInventory.ToneCount()))
                {
                    nCurrent = n;
                    Redisplay();
                }
                //else MessageBox.Show("Grapheme not found");
                else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("FormToneInventory3",
                    m_Settings.OptionSettings.UILanguage));
            }
            //else MessageBox.Show("Grapheme must be specified in the adjacent box");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("FormToneInventory4",
                m_Settings.OptionSettings.UILanguage));
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
            //if (m_Settings.GraphemeInventory.ToneCount() == 0)
            //    MessageBox.Show("Need to add first, before you can save");
            //else SaveIt();
            SaveIt();
            return;
        }
		
        private void SaveIt()
        {
            string strSymbol = this.tbTone.Text.Trim();
			string strTBU = "";
			if (strSymbol != "")
			{
				if ( (!m_Settings.GraphemeInventory.IsInInventory(strSymbol)) 
					|| (nCurrent ==  m_Settings.GraphemeInventory.GetGraphemeIndex(strSymbol)) )
				{
					tone.Symbol = strSymbol;
                    tone.UpperCase = this.tbUC.Text;
                    Grapheme seg = null;
					GraphemeInventory gi = m_Settings.GraphemeInventory;
					tone.Level = this.tbLevel.Text;
					strTBU = this.tbTBU.Text;
					if (strTBU != "") 
					{
						if (gi.IsInInventory(strTBU))
						{
							seg = gi.GetGrapheme(strTBU);
							tone.ToneBearingUnit = seg;
						}
						else 
						{
                            //MessageBox.Show("Tone Bearing Unit is not in Inventory");
                            MessageBox.Show(m_Settings.LocalizationTable.GetMessage("FormToneInventory5",
                                m_Settings.OptionSettings.UILanguage));
							tone.ToneBearingUnit = null;
							this.tbTBU.Text = "";
						}
					}
					else tone.ToneBearingUnit = null;
                    fIsUpdated = true;
                    //MessageBox.Show("Tone saved");
                    MessageBox.Show(m_Settings.LocalizationTable.GetMessage("FormToneInventory6",
                        m_Settings.OptionSettings.UILanguage));
                }
				else 
				{
                    //MessageBox.Show("Tone is already in inventory");
                    MessageBox.Show(m_Settings.LocalizationTable.GetMessage("FormToneInventory7",
                        m_Settings.OptionSettings.UILanguage));
                    tone = m_Settings.GraphemeInventory.GetTone(nCurrent);
					this.tbTone.Text = tone.Symbol;
				}
			}
            //else MessageBox.Show("Tone must be specified");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("FormToneInventory8",
                m_Settings.OptionSettings.UILanguage));
        }

		private void btnExit_Click(object sender, System.EventArgs e)
		{
            if (HasChanged())
            {
                //if (MessageBox.Show(cSaveText, cSaveCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                //    SaveIt();
                string strText = m_Settings.LocalizationTable.GetMessage("FormToneInventory1",
                    m_Settings.OptionSettings.UILanguage);
                string strCaption = m_Settings.LocalizationTable.GetMessage("FormToneInventory2",
                    m_Settings.OptionSettings.UILanguage);
                if (MessageBox.Show(strText, strCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    SaveIt();
            }
            if (fIsUpdated)
                //MessageBox.Show("Since the graphene inventory has been updated, you need to reimport the word list and text data.");
                MessageBox.Show(m_Settings.LocalizationTable.GetMessage("FormToneInventory9",
                    m_Settings.OptionSettings.UILanguage));
            this.Close();
		}

		private void AtClosed(object sender, System.EventArgs e)
		{
            GraphemeInventory gi = m_Settings.GraphemeInventory;
			int nTones = gi.ToneCount();
            if (nTones > 0)
            {
			    Tone tone = null;
			    for (int i = nTones; 0 < i; i--)
			    {
				    tone = m_Settings.GraphemeInventory.GetTone(i - 1);
                    if (tone == null)
                       gi.DelTone(i - 1);
				    else if (tone.Symbol.Trim() == "")
                       gi.DelTone(i - 1);
			    }
                m_Settings.GraphemeInventory = gi;
            }
		}

		private void Redisplay ()
		{
			int n = 0;
            if (m_Settings.GraphemeInventory.ToneCount() > 0)
            {
                n = nCurrent + 1;
                tone = m_Settings.GraphemeInventory.GetTone(nCurrent);
            }
            else
            {
                tone = new Tone(" ");
            }
			
            this.tbFind.Text = "";					// Clear Find box
			this.tbTone.Text = tone.Symbol;
            this.tbUC.Text = tone.UpperCase;
			this.tbCurrent.Text = n.ToString();
			this.tbCount.Text = m_Settings.GraphemeInventory.ToneCount().ToString();
			this.tbLevel.Text = tone.Level;
			if (tone.ToneBearingUnit == null)
				this.tbTBU.Text = "";
			else this.tbTBU.Text = tone.ToneBearingUnit.Symbol;
            this.tbTone.Focus();
		}

        private bool HasChanged()
        {
            bool fChange = false;
            Tone tone = null;
            int n = 0;
            if (m_Settings.GraphemeInventory.ToneCount() > 0)
            {
                n = nCurrent + 1;
                tone = m_Settings.GraphemeInventory.GetTone(nCurrent);
            }
            else return fChange;

            if (this.tbTone.Text != tone.Symbol) fChange = true;
            if (this.tbUC.Text != tone.UpperCase) fChange = true;
            if (this.tbLevel.Text != tone.Level) fChange = true;
            if (tone.ToneBearingUnit == null)
            {
                if (this.tbTBU.Text != "") fChange = true;
            }
            else
            {
                if (this.tbTBU.Text != tone.ToneBearingUnit.Symbol) fChange = true;
            }
            return fChange;
        }

	}
}

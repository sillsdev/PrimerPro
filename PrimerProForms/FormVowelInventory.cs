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
	/// Summary description for FormVowelInventory.
	/// </summary>
	public class FormVowelInventory : System.Windows.Forms.Form
	{
		private Settings m_Settings;
		private int nCurrent;	    //index of current vowel
		private Vowel vwl;		    //current vowel
        private bool fIsUpdated;    //Indicates the iventory has been updated

        //private const string cSaveText = "Do you want to save changes?";
        //private const string cSaveCaption = "Save Displayed Vowel";

		private System.Windows.Forms.Label labVowel;
		private System.Windows.Forms.TextBox tbVowel;
		private System.Windows.Forms.TextBox tbCount;
		private System.Windows.Forms.Label labOf;
		private System.Windows.Forms.TextBox tbCurrent;
		private System.Windows.Forms.GroupBox gbBackness;
		private System.Windows.Forms.GroupBox gbHeight;
		private System.Windows.Forms.CheckBox ckRound;
		private System.Windows.Forms.CheckBox ckATR;
		private System.Windows.Forms.CheckBox ckLong;
		private System.Windows.Forms.CheckBox ckNasal;
		private System.Windows.Forms.TextBox tbFind;
		private System.Windows.Forms.Button btnFind;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.RadioButton rbFront;
		private System.Windows.Forms.RadioButton rbCentral;
		private System.Windows.Forms.RadioButton rbBack;
		private System.Windows.Forms.RadioButton rbHigh;
		private System.Windows.Forms.RadioButton rbMid;
		private System.Windows.Forms.RadioButton rbLow;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnPrevious;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnNext;
        private TextBox tbUpper;
        private Label labUC;
        private CheckBox ckDipthong;
        private CheckBox ckVoiceless;
        private TextBox tbDiphthong;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormVowelInventory(Settings s)
		{
			InitializeComponent();
			m_Settings = s;
            Font font = m_Settings.OptionSettings.GetDefaultFont();
            this.tbVowel.Font = font;
            this.tbUpper.Font = font;
            this.tbFind.Font = font;
            nCurrent = 0;			// First Vowel
            fIsUpdated = false;

            LocalizationTable table = m_Settings.LocalizationTable;
            string lang = m_Settings.OptionSettings.UILanguage;
            this.Text = table.GetForm("FormVowelInventoryT", lang);
            this.labVowel.Text = table.GetForm("FormVowelInventory0", lang);
            this.labOf.Text = table.GetForm("FormVowelInventory3", lang);
            this.labUC.Text = table.GetForm("FormVowelInventory5", lang);
            this.gbBackness.Text = table.GetForm("FormVowelInventory7", lang);
            this.rbFront.Text = table.GetForm("FormVowelInventoryB0", lang);
            this.rbCentral.Text = table.GetForm("FormVowelInventoryB1", lang);
            this.rbBack.Text = table.GetForm("FormVowelInventoryB2", lang);
            this.gbHeight.Text = table.GetForm("FormVowelInventory8", lang);
            this.rbHigh.Text = table.GetForm("FormVowelInventoryH0", lang);
            this.rbMid.Text = table.GetForm("FormVowelInventoryH1", lang);
            this.rbLow.Text = table.GetForm("FormVowelInventoryH2", lang);
            this.ckRound.Text = table.GetForm("FormVowelInventory9", lang);
            this.ckATR.Text = table.GetForm("FormVowelInventory10", lang);
            this.ckLong.Text = table.GetForm("FormVowelInventory11", lang);
            this.ckNasal.Text = table.GetForm("FormVowelInventory12", lang);
            this.ckVoiceless.Text = table.GetForm("FormVowelInventory13", lang);
            this.ckDipthong.Text = table.GetForm("FormVowelInventory14", lang);
            this.btnPrevious.Text = table.GetForm("FormVowelInventory16", lang);
            this.btnNext.Text = table.GetForm("FormVowelInventory17", lang);
            this.btnAdd.Text = table.GetForm("FormVowelInventory18", lang);
            this.btnDelete.Text = table.GetForm("FormVowelInventory19", lang);
            this.btnFind.Text = table.GetForm("FormVowelInventory21", lang);
            this.btnSave.Text = table.GetForm("FormVowelInventory22", lang);
            this.btnExit.Text = table.GetForm("FormVowelInventory23", lang);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVowelInventory));
            this.labVowel = new System.Windows.Forms.Label();
            this.tbVowel = new System.Windows.Forms.TextBox();
            this.tbCount = new System.Windows.Forms.TextBox();
            this.labOf = new System.Windows.Forms.Label();
            this.tbCurrent = new System.Windows.Forms.TextBox();
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
            this.tbFind = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.tbUpper = new System.Windows.Forms.TextBox();
            this.labUC = new System.Windows.Forms.Label();
            this.ckDipthong = new System.Windows.Forms.CheckBox();
            this.ckVoiceless = new System.Windows.Forms.CheckBox();
            this.tbDiphthong = new System.Windows.Forms.TextBox();
            this.gbBackness.SuspendLayout();
            this.gbHeight.SuspendLayout();
            this.SuspendLayout();
            // 
            // labVowel
            // 
            this.labVowel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labVowel.Location = new System.Drawing.Point(16, 16);
            this.labVowel.Name = "labVowel";
            this.labVowel.Size = new System.Drawing.Size(56, 23);
            this.labVowel.TabIndex = 0;
            this.labVowel.Text = "Vowel";
            // 
            // tbVowel
            // 
            this.tbVowel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVowel.Location = new System.Drawing.Point(80, 16);
            this.tbVowel.Name = "tbVowel";
            this.tbVowel.Size = new System.Drawing.Size(40, 24);
            this.tbVowel.TabIndex = 1;
            this.tbVowel.Leave += new System.EventHandler(this.tbVowel_Leave);
            this.tbVowel.Enter += new System.EventHandler(this.tbVowel_Enter);
            // 
            // tbCount
            // 
            this.tbCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCount.Location = new System.Drawing.Point(208, 16);
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
            this.labOf.Location = new System.Drawing.Point(184, 16);
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
            this.tbCurrent.Location = new System.Drawing.Point(144, 16);
            this.tbCurrent.Name = "tbCurrent";
            this.tbCurrent.ReadOnly = true;
            this.tbCurrent.Size = new System.Drawing.Size(32, 17);
            this.tbCurrent.TabIndex = 2;
            this.tbCurrent.TabStop = false;
            this.tbCurrent.Text = "???";
            this.tbCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gbBackness
            // 
            this.gbBackness.Controls.Add(this.rbBack);
            this.gbBackness.Controls.Add(this.rbCentral);
            this.gbBackness.Controls.Add(this.rbFront);
            this.gbBackness.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBackness.Location = new System.Drawing.Point(24, 60);
            this.gbBackness.Name = "gbBackness";
            this.gbBackness.Size = new System.Drawing.Size(167, 112);
            this.gbBackness.TabIndex = 7;
            this.gbBackness.TabStop = false;
            this.gbBackness.Text = "Backness Feature";
            // 
            // rbBack
            // 
            this.rbBack.AutoSize = true;
            this.rbBack.Location = new System.Drawing.Point(8, 76);
            this.rbBack.Name = "rbBack";
            this.rbBack.Size = new System.Drawing.Size(63, 22);
            this.rbBack.TabIndex = 2;
            this.rbBack.Text = "&Back";
            // 
            // rbCentral
            // 
            this.rbCentral.AutoSize = true;
            this.rbCentral.Cursor = System.Windows.Forms.Cursors.Default;
            this.rbCentral.Location = new System.Drawing.Point(8, 48);
            this.rbCentral.Name = "rbCentral";
            this.rbCentral.Size = new System.Drawing.Size(76, 22);
            this.rbCentral.TabIndex = 1;
            this.rbCentral.Text = "&Central";
            // 
            // rbFront
            // 
            this.rbFront.AutoSize = true;
            this.rbFront.Location = new System.Drawing.Point(8, 24);
            this.rbFront.Name = "rbFront";
            this.rbFront.Size = new System.Drawing.Size(64, 22);
            this.rbFront.TabIndex = 0;
            this.rbFront.Text = "Fron&t";
            // 
            // gbHeight
            // 
            this.gbHeight.Controls.Add(this.rbLow);
            this.gbHeight.Controls.Add(this.rbMid);
            this.gbHeight.Controls.Add(this.rbHigh);
            this.gbHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbHeight.Location = new System.Drawing.Point(24, 192);
            this.gbHeight.Name = "gbHeight";
            this.gbHeight.Size = new System.Drawing.Size(167, 112);
            this.gbHeight.TabIndex = 8;
            this.gbHeight.TabStop = false;
            this.gbHeight.Text = "Height Feature";
            // 
            // rbLow
            // 
            this.rbLow.AutoSize = true;
            this.rbLow.Location = new System.Drawing.Point(8, 72);
            this.rbLow.Name = "rbLow";
            this.rbLow.Size = new System.Drawing.Size(57, 22);
            this.rbLow.TabIndex = 2;
            this.rbLow.Text = "Lo&w";
            // 
            // rbMid
            // 
            this.rbMid.AutoSize = true;
            this.rbMid.Location = new System.Drawing.Point(8, 48);
            this.rbMid.Name = "rbMid";
            this.rbMid.Size = new System.Drawing.Size(53, 22);
            this.rbMid.TabIndex = 1;
            this.rbMid.Text = "&Mid";
            // 
            // rbHigh
            // 
            this.rbHigh.AutoSize = true;
            this.rbHigh.Location = new System.Drawing.Point(8, 24);
            this.rbHigh.Name = "rbHigh";
            this.rbHigh.Size = new System.Drawing.Size(59, 22);
            this.rbHigh.TabIndex = 0;
            this.rbHigh.Text = "&High";
            // 
            // ckRound
            // 
            this.ckRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckRound.Location = new System.Drawing.Point(208, 60);
            this.ckRound.Name = "ckRound";
            this.ckRound.Size = new System.Drawing.Size(75, 25);
            this.ckRound.TabIndex = 9;
            this.ckRound.Text = "&Round";
            // 
            // ckATR
            // 
            this.ckATR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckATR.Location = new System.Drawing.Point(208, 100);
            this.ckATR.Name = "ckATR";
            this.ckATR.Size = new System.Drawing.Size(75, 25);
            this.ckATR.TabIndex = 10;
            this.ckATR.Text = "&+ATR";
            // 
            // ckLong
            // 
            this.ckLong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckLong.Location = new System.Drawing.Point(208, 140);
            this.ckLong.Name = "ckLong";
            this.ckLong.Size = new System.Drawing.Size(75, 25);
            this.ckLong.TabIndex = 11;
            this.ckLong.Text = "Lon&g";
            // 
            // ckNasal
            // 
            this.ckNasal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckNasal.Location = new System.Drawing.Point(208, 180);
            this.ckNasal.Name = "ckNasal";
            this.ckNasal.Size = new System.Drawing.Size(75, 25);
            this.ckNasal.TabIndex = 12;
            this.ckNasal.Text = "Nasa&l";
            // 
            // tbFind
            // 
            this.tbFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFind.Location = new System.Drawing.Point(370, 220);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(74, 27);
            this.tbFind.TabIndex = 20;
            this.tbFind.DragEnter += new System.Windows.Forms.DragEventHandler(this.tbFind_DragEnter);
            this.tbFind.MouseEnter += new System.EventHandler(this.tbFind_MouseEnter);
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Location = new System.Drawing.Point(450, 220);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(100, 32);
            this.btnFind.TabIndex = 21;
            this.btnFind.Text = "&Find";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(370, 356);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 32);
            this.btnExit.TabIndex = 23;
            this.btnExit.Text = "E&xit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(370, 310);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 32);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSav_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(370, 60);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(100, 32);
            this.btnPrevious.TabIndex = 16;
            this.btnPrevious.Text = "&Previous";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(370, 180);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 32);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(370, 140);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 32);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.Text = "&Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(370, 100);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 32);
            this.btnNext.TabIndex = 17;
            this.btnNext.Text = "&Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tbUpper
            // 
            this.tbUpper.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUpper.Location = new System.Drawing.Point(380, 16);
            this.tbUpper.Name = "tbUpper";
            this.tbUpper.Size = new System.Drawing.Size(40, 24);
            this.tbUpper.TabIndex = 6;
            // 
            // labUC
            // 
            this.labUC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labUC.Location = new System.Drawing.Point(273, 16);
            this.labUC.Name = "labUC";
            this.labUC.Size = new System.Drawing.Size(96, 25);
            this.labUC.TabIndex = 5;
            this.labUC.Text = "Upper Case";
            // 
            // ckDipthong
            // 
            this.ckDipthong.AutoSize = true;
            this.ckDipthong.Location = new System.Drawing.Point(208, 260);
            this.ckDipthong.Name = "ckDipthong";
            this.ckDipthong.Size = new System.Drawing.Size(97, 22);
            this.ckDipthong.TabIndex = 14;
            this.ckDipthong.Text = "Diphthong";
            this.ckDipthong.UseVisualStyleBackColor = true;
            this.ckDipthong.CheckedChanged += new System.EventHandler(this.ckDipthong_CheckedChanged);
            // 
            // ckVoiceless
            // 
            this.ckVoiceless.AutoSize = true;
            this.ckVoiceless.Location = new System.Drawing.Point(208, 220);
            this.ckVoiceless.Name = "ckVoiceless";
            this.ckVoiceless.Size = new System.Drawing.Size(94, 22);
            this.ckVoiceless.TabIndex = 13;
            this.ckVoiceless.Text = "Voiceless";
            this.ckVoiceless.UseVisualStyleBackColor = true;
            // 
            // tbDiphthong
            // 
            this.tbDiphthong.AcceptsReturn = true;
            this.tbDiphthong.Location = new System.Drawing.Point(208, 300);
            this.tbDiphthong.Multiline = true;
            this.tbDiphthong.Name = "tbDiphthong";
            this.tbDiphthong.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDiphthong.Size = new System.Drawing.Size(100, 83);
            this.tbDiphthong.TabIndex = 15;
            this.tbDiphthong.WordWrap = false;
            // 
            // FormVowelInventory
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 17);
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(565, 400);
            this.Controls.Add(this.tbDiphthong);
            this.Controls.Add(this.ckVoiceless);
            this.Controls.Add(this.ckDipthong);
            this.Controls.Add(this.tbUpper);
            this.Controls.Add(this.labUC);
            this.Controls.Add(this.tbFind);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ckNasal);
            this.Controls.Add(this.ckLong);
            this.Controls.Add(this.ckATR);
            this.Controls.Add(this.ckRound);
            this.Controls.Add(this.gbHeight);
            this.Controls.Add(this.gbBackness);
            this.Controls.Add(this.tbCount);
            this.Controls.Add(this.labOf);
            this.Controls.Add(this.tbCurrent);
            this.Controls.Add(this.tbVowel);
            this.Controls.Add(this.labVowel);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnNext);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormVowelInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Vowel Inventory";
            this.gbBackness.ResumeLayout(false);
            this.gbBackness.PerformLayout();
            this.gbHeight.ResumeLayout(false);
            this.gbHeight.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private void tbVowel_Enter(object sender, EventArgs e)
        {
            if (m_Settings.GraphemeInventory.VowelCount() == 0)
            {
                Vowel vwl = new Vowel(" ");
                int nCount = m_Settings.GraphemeInventory.VowelCount();
                m_Settings.GraphemeInventory.AddVowel(vwl);
                nCurrent = nCount;
                Redisplay();
            }
        }

        private void tbVowel_Leave(object sender, EventArgs e)
        {
            string str;
            if (this.tbUpper.Text == "")
            {
                str = this.tbVowel.Text;
                if (str.Length > 1)
                    str = str.Substring(0, 1).ToUpper() + str.Substring(1);
                else str = str.ToUpper();
                this.tbUpper.Text = str;
            }
        }

        private void btnPrev_Click(object sender, System.EventArgs e)
		{
            if (HasChanged())
            {
                //if (MessageBox.Show(cSaveText, cSaveCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                //    SaveIt();
                string strText = m_Settings.LocalizationTable.GetMessage("FormVowelInventory1",
                    m_Settings.OptionSettings.UILanguage);
                string strCaption = m_Settings.LocalizationTable.GetMessage("FormVowelInventory2",
                    m_Settings.OptionSettings.UILanguage);
                if (MessageBox.Show(strText, strCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    SaveIt();
            }
            if (nCurrent > 0)
				nCurrent--;
			Redisplay();
		}

		private void btnNext_Click(object sender, System.EventArgs e)
		{
            if (HasChanged())
            {
                //if (MessageBox.Show(cSaveText, cSaveCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                //    SaveIt();
                string strText = m_Settings.LocalizationTable.GetMessage("FormVowelInventory1",
                    m_Settings.OptionSettings.UILanguage);
                string strCaption = m_Settings.LocalizationTable.GetMessage("FormVowelInventory2",
                    m_Settings.OptionSettings.UILanguage);
                if (MessageBox.Show(strText, strCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    SaveIt();
            }
            if (nCurrent < (m_Settings.GraphemeInventory.VowelCount() - 1))
				nCurrent++;
			Redisplay();
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
            if (HasChanged())
            {
                //if (MessageBox.Show(cSaveText, cSaveCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                //    SaveIt();
                string strText = m_Settings.LocalizationTable.GetMessage("FormVowelInventory1",
                   m_Settings.OptionSettings.UILanguage);
                string strCaption = m_Settings.LocalizationTable.GetMessage("FormVowelInventory2",
                    m_Settings.OptionSettings.UILanguage);
                if (MessageBox.Show(strText, strCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    SaveIt();
            }
 			Vowel vwl = new Vowel(" ");
			int nCount = m_Settings.GraphemeInventory.VowelCount();
			m_Settings.GraphemeInventory.AddVowel(vwl);
			nCurrent = nCount;
			Redisplay();
		}

		private void btnDel_Click(object sender, System.EventArgs e)
		{
			int next = nCurrent;
			m_Settings.GraphemeInventory.DelVowel(nCurrent);
			if ( next < m_Settings.GraphemeInventory.VowelCount() )
				nCurrent = next;
			else nCurrent = m_Settings.GraphemeInventory.VowelCount() - 1;
            fIsUpdated = true;
			Redisplay();
		}

		private void btnFind_Click(object sender, System.EventArgs e)
		{
            if (HasChanged())
            {
                //if (MessageBox.Show(cSaveText, cSaveCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                //    SaveIt();
                string strText = m_Settings.LocalizationTable.GetMessage("FormVowelInventory1",
                    m_Settings.OptionSettings.UILanguage);
                string strCaption = m_Settings.LocalizationTable.GetMessage("FormVowelInventory2",
                    m_Settings.OptionSettings.UILanguage);
                if (MessageBox.Show(strText, strCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    SaveIt();
            }
            
            string strSymbol = this.tbFind.Text.Trim();
			int n = 0;
			if ( strSymbol != "" )
			{
				n = m_Settings.GraphemeInventory.FindVowelIndex(strSymbol);
				if ( (n >= 0) && (n < m_Settings.GraphemeInventory.VowelCount()) )
				{
					nCurrent = n;
					Redisplay();
				}
                //else MessageBox.Show("Grapheme not found");
                else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("FormVowelInventory3",
                    m_Settings.OptionSettings.UILanguage));
			}
            //else MessageBox.Show("Grapheme must be specified in the adjacent box");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("FormVowelInventory4",
                m_Settings.OptionSettings.UILanguage));
        }

		private void btnSav_Click(object sender, System.EventArgs e)
		{
            //if (m_Settings.GraphemeInventory.VowelCount() == 0)
            //    MessageBox.Show("Need to add first, before you can save");
            //else SaveIt();
            SaveIt();
            return;
		}

        private void SaveIt()
        {
            string strSymbol = this.tbVowel.Text.Trim();
            if (strSymbol != "")
			{
				if ( (!m_Settings.GraphemeInventory.IsInInventory(strSymbol)) 
					|| (nCurrent ==  m_Settings.GraphemeInventory.GetGraphemeIndex(strSymbol)) )
				{
					vwl.Symbol = this.tbVowel.Text.Trim();
                    vwl.UpperCase = this.tbUpper.Text.Trim();
					vwl.IsFront = this.rbFront.Checked;
					vwl.IsCentral = this.rbCentral.Checked;
					vwl.IsBack = this.rbBack.Checked;
					vwl.IsHigh = this.rbHigh.Checked;
					vwl.IsMid = this.rbMid.Checked;
					vwl.IsLow = this.rbLow.Checked;
					vwl.IsRound = this.ckRound.Checked;
					vwl.IsPlusATR = this.ckATR.Checked;
					vwl.IsLong = this.ckLong.Checked;
					vwl.IsNasal = this.ckNasal.Checked;
                    vwl.IsVoiceless = this.ckVoiceless.Checked;

                    vwl.IsComplex = this.ckDipthong.Checked;
                    vwl.ComplexComponents = Funct.ConvertStringToArrayList(this.tbDiphthong.Text,
                        Environment.NewLine);
                    
                    fIsUpdated = true;
                    //MessageBox.Show("Vowel saved");
                    MessageBox.Show(m_Settings.LocalizationTable.GetMessage("FormVowelInventory5",
                        m_Settings.OptionSettings.UILanguage));
				}
				else 
				{
                    //MessageBox.Show("Vowel is already in inventory");
                    MessageBox.Show(m_Settings.LocalizationTable.GetMessage("FormVowelInventory6",
                        m_Settings.OptionSettings.UILanguage));
					vwl = m_Settings.GraphemeInventory.GetVowel(nCurrent);
					this.tbVowel.Text = vwl.Symbol;
				}
            }
            //else MessageBox.Show("Vowel must be specified");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("FormVowelInventory7",
                m_Settings.OptionSettings.UILanguage));
        }
		
        private void btnExit_Click(object sender, System.EventArgs e)
		{
            if (HasChanged())
            {
                //if (MessageBox.Show(cSaveText, cSaveCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                //    SaveIt();
                string strText = m_Settings.LocalizationTable.GetMessage("FormVowelInventory1",
                    m_Settings.OptionSettings.UILanguage);
                string strCaption = m_Settings.LocalizationTable.GetMessage("FormVowelInventory2",
                    m_Settings.OptionSettings.UILanguage);
                if (MessageBox.Show(strText, strCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    SaveIt();
            }
            if (fIsUpdated)
                //MessageBox.Show("Since the graphene inventory has been updated, you need to reimport the word list and text data.");
                MessageBox.Show(m_Settings.LocalizationTable.GetMessage("FormVowelInventory8",
                    m_Settings.OptionSettings.UILanguage));
            this.Close();
		}

		private void AtClosed(object sender, System.EventArgs e)
		{
            GraphemeInventory gi = m_Settings.GraphemeInventory;
            int nVowels = gi.VowelCount();
            if (nVowels > 0)
            {
                Vowel vwl = null;
                for (int i = nVowels; 0 < i; i--)
                {
                    vwl = m_Settings.GraphemeInventory.GetVowel(i - 1);
                    if (vwl == null)
                        gi.DelVowel(i - 1);
                    else if (vwl.Symbol.Trim() == "")
                        gi.DelVowel(i - 1);
                }
                m_Settings.GraphemeInventory = gi;
            }
		}

		private void Redisplay ()
		{
			int n = 0;
            if (m_Settings.GraphemeInventory.VowelCount() > 0)
            {
                n = nCurrent + 1;
                vwl = m_Settings.GraphemeInventory.GetVowel(nCurrent);
            }
            else
            {
                vwl = new Vowel(" ");
            }

			this.tbFind.Text = "";					// Clear Find box
			this.tbVowel.Text = vwl.Symbol;
            this.tbUpper.Text = vwl.UpperCase;
            this.tbCurrent.Text = n.ToString();
            this.tbCount.Text = m_Settings.GraphemeInventory.VowelCount().ToString();
			this.rbFront.Checked = vwl.IsFront;
			this.rbCentral.Checked = vwl.IsCentral;
			this.rbBack.Checked= vwl.IsBack;
			this.rbHigh.Checked = vwl.IsHigh;
			this.rbMid.Checked = vwl.IsMid;
			this.rbLow.Checked = vwl.IsLow;
			this.ckRound.Checked = vwl.IsRound;
			this.ckATR.Checked = vwl.IsPlusATR;
			this.ckLong.Checked = vwl.IsLong;
			this.ckNasal.Checked = vwl.IsNasal;
            this.ckVoiceless.Checked = vwl.IsVoiceless;

            this.ckDipthong.Checked = vwl.IsComplex;
            this.tbDiphthong.Text = "";
            if (this.ckDipthong.Checked)
            {
                this.tbDiphthong.Enabled = true;
                if (vwl.ComplexComponents.Count > 0)
                {
                    this.tbDiphthong.Text = Funct.ConvertArrayListToString(vwl.ComplexComponents,
                        Environment.NewLine);
                }
                else this.tbDiphthong.Text = "";
            }
            else this.tbDiphthong.Enabled = false;
            this.tbVowel.Focus();
		}

        private bool HasChanged()
        {
            bool fChange = false;
            Vowel vwl = null;
            int n = 0;
            if (m_Settings.GraphemeInventory.VowelCount() > 0)
            {
                n = nCurrent + 1;
                vwl = m_Settings.GraphemeInventory.GetVowel(nCurrent);
            }
            else return fChange;

            if (this.tbVowel.Text != vwl.Symbol) fChange = true; ;
            if (this.tbUpper.Text != vwl.UpperCase) fChange = true; ;
            if (this.rbFront.Checked != vwl.IsFront) fChange = true;
            if (this.rbCentral.Checked != vwl.IsCentral) fChange = true;
            if (this.rbBack.Checked != vwl.IsBack) fChange = true;
            if (this.rbHigh.Checked != vwl.IsHigh) fChange = true;
            if (this.rbMid.Checked != vwl.IsMid) fChange = true;
            if (this.rbLow.Checked != vwl.IsLow) fChange = true;
            if (this.ckRound.Checked != vwl.IsRound) fChange = true;
            if (this.ckATR.Checked != vwl.IsPlusATR) fChange = true;
            if (this.ckLong.Checked != vwl.IsLong) fChange = true;
            if (this.ckNasal.Checked != vwl.IsNasal) fChange = true;
            if (this.ckDipthong.Checked != vwl.IsComplex) fChange = true;
            if (this.ckVoiceless.Checked != vwl.IsVoiceless) fChange = true;
            return fChange;
        }

        private void ckDipthong_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckDipthong.Checked)
            {
                this.rbFront.Checked = false;
                this.rbCentral.Checked = false;
                this.rbBack.Checked = false;
                this.rbHigh.Checked = false;
                this.rbMid.Checked = false;
                this.rbLow.Checked = false;
                this.ckRound.Checked = false;
                this.ckATR.Checked = false;
                this.ckLong.Checked = false;
                this.ckNasal.Checked = false;
                this.ckVoiceless.Checked = false;
                this.tbDiphthong.Enabled = true;

                this.rbFront.Enabled = false;
                this.rbCentral.Enabled = false;
                this.rbBack.Enabled = false;
                this.rbHigh.Enabled = false;
                this.rbMid.Enabled = false;
                this.rbLow.Enabled = false;
                this.ckRound.Enabled = false;
                this.ckATR.Enabled = false;
                this.ckLong.Enabled = false;
                this.ckNasal.Enabled = false;
                this.ckVoiceless.Enabled = false;
                this.tbDiphthong.Focus();
            }
            else
            {
                this.tbDiphthong.Text = "";
                this.tbDiphthong.Enabled = false;

                this.rbFront.Enabled = true;
                this.rbCentral.Enabled = true;
                this.rbBack.Enabled = true;
                this.rbHigh.Enabled = true;
                this.rbMid.Enabled = true;
                this.rbLow.Enabled = true;
                this.ckRound.Enabled = true;
                this.ckATR.Enabled = true;
                this.ckLong.Enabled = true;
                this.ckNasal.Enabled = true;
                this.ckVoiceless.Enabled = true;
            }
        }

        private void tbFind_MouseEnter(object sender, EventArgs e)
        {
            this.AcceptButton = this.btnFind;
        }

        private void tbFind_DragEnter(object sender, DragEventArgs e)
        {
            this.AcceptButton = this.btnSave;
        }

    }
}

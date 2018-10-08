using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PrimerProObjects;
using PrimerProLocalization;
using GenLib;

namespace PrimerProForms
{

    public partial class FormPSTable : Form
    {
        //private Settings m_Settings;
        private PSTable m_PSTable;
        private int nCurrent;	        //index of current entry
        private CodeTableEntry cte;     //Current entry

        //private const string cSaveText = "Do you want to save changes?";
        //private const String cSaveCaption = "Save Displayed Parts of Speech";

        private LocalizationTable m_Table;      //Localization table

        public FormPSTable(PSTable pstable)
        {
            InitializeComponent();
            m_PSTable = pstable;
            m_Table = null;
            nCurrent = 0;		//First PoS
            Redisplay();
        }

        public FormPSTable(PSTable pstable, LocalizationTable table)
        {
            InitializeComponent();
            m_PSTable = pstable;
            m_Table = table;
            nCurrent = 0;		//First PoS
            Redisplay();

            this.UpdateFormForLocalization(table);
        }

        public PSTable PSTable
        {
            get { return m_PSTable; }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (HasChanged())
            {
                //if (MessageBox.Show("Do you want to save the changes?", "Save Displayed Parts of Speech", MessageBoxButtons.YesNo) == DialogResult.Yes)
                //    SaveIt();
                string strText = m_Table.GetMessage("FormPSTable8");
                if (strText == "")
                    strText = "Do you want to save the changes?";
                string strCaption = m_Table.GetMessage("FormPSTable9");
                if (strCaption == "")
                    strCaption = "Save Displayed Parts of Speech";
                if (MessageBox.Show(strText, strCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    SaveIt();
            }
            if (nCurrent > 0)
                nCurrent--;
            Redisplay();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (HasChanged())
            {
                //if (MessageBox.Show("Do you want to save the changes?", "Save Displayed Parts of Speech", MessageBoxButtons.YesNo) == DialogResult.Yes)
                //    SaveIt();
                string strText = m_Table.GetMessage("FormPSTable8");
                if (strText == "")
                    strText = "Do you want to save the changes?";
                string strCaption = m_Table.GetMessage("FormPSTable9");
                if (strCaption == "")
                    strCaption = "Save Displayed Parts of Speech";
                if (MessageBox.Show(strText, strCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    SaveIt();
            }
            if (nCurrent < (m_PSTable.Count() - 1))
                nCurrent++;
            Redisplay();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (HasChanged())
            {
                //if (MessageBox.Show("Do you want to save the changes?", "Save Displayed Parts of Speech", MessageBoxButtons.YesNo) == DialogResult.Yes)
                //    SaveIt();
                string strText = m_Table.GetMessage("FormPSTable8");
                if (strText == "")
                    strText = "Do you want to save the changes?";
                string strCaption = m_Table.GetMessage("FormPSTable9");
                if (strCaption == "")
                    strCaption = "Save Displayed Parts of Speech";
                if (MessageBox.Show(strText, strCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    SaveIt();
            }
            cte = new CodeTableEntry("", "");
            int nCount = m_PSTable.Count();
            m_PSTable.AddEntry(cte);
            nCurrent = nCount;
            Redisplay();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int next = nCurrent;
            m_PSTable.DeleteEntry(nCurrent);
            if (next < m_PSTable.Count())
                nCurrent = next;
            else nCurrent = m_PSTable.Count() - 1;
            Redisplay();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string strText = "";
            string strCaption = "";
            if (HasChanged())
            {
                //if (MessageBox.Show("Do you want to save the changes?", "Save Displayed Parts of Speech", MessageBoxButtons.YesNo) == DialogResult.Yes)
                //    SaveIt();
                strText = m_Table.GetMessage("FormPSTable8");
                if (strText == "")
                    strText = "Do you want to save the changes?";
                strCaption = m_Table.GetMessage("FormPSTable9");
                if (strCaption == "")
                    strCaption = "Save Displayed Parts of Speech";
                if (MessageBox.Show(strText, strCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    SaveIt();
            }
            string strCode = this.tbFind.Text;
            int n = 0;
            if (strCode != "")
            {
                n = m_PSTable.GetIndex(strCode);
                if ((n >= 0) && (n < m_PSTable.Count()))
                {
                    nCurrent = n;
                    Redisplay();
                }
                else if (m_Table == null)
                    MessageBox.Show("Code not found");
                else
                {
                    strText = m_Table.GetMessage("FormPSTable1");
                    if (strText == "")
                        strText = "Code not found";
                    MessageBox.Show(strText);
                }
            }
            else if (m_Table == null)
                    MessageBox.Show("Code must be specified in the adjacent box");
            else
            {
                strText = m_Table.GetMessage("FormPSTable2");
                if (strText == "")
                    strText = "Code must be specified in the adjacent box";
                MessageBox.Show(strText);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strText = "";
            if (m_PSTable.Count() == 0)
                if (m_Table == null)
                    MessageBox.Show("Need to add first, before you can save");
                else
                {
                    strText = m_Table.GetMessage("FormPSTable3");
                    if (strText == "")
                        strText = "Need to add first, before you can save";
                    MessageBox.Show(strText);
                }
            else SaveIt();
            return;
        }

        private void SaveIt()
        {
            string strText = "";
            string strCode = this.tbCode.Text.Trim();
            if (strCode != "")
            {
                if ((m_PSTable.GetIndex(strCode) < 0) || (nCurrent == m_PSTable.GetIndex(strCode)))
                {
                    cte.Code = strCode;
                    cte.Description = this.tbDesc.Text.Trim();
                    if (m_Table == null)
                        MessageBox.Show("Part of Speech saved");
                    else
                    {
                        strText = m_Table.GetMessage("FormPSTable4");
                        if (strText == "")
                            strText = "Part of Speech saved";
                        MessageBox.Show(strText);
                    }
                }
                else
                {
                    if (m_Table == null)
                        MessageBox.Show("Part of Speech is already in table");
                    else
                    {
                        strText = m_Table.GetMessage("FormPSTable5");
                        if (strText == "")
                            strText = "Part of Speech is already in table";
                        MessageBox.Show(strText);
                    }
                    cte = m_PSTable.GetEntry(nCurrent);
                    this.tbCode.Text = cte.Code;
                }
            }
            else
            {
                if (m_Table == null)
                    MessageBox.Show("Code must be specified");
                else
                {
                    strText = m_Table.GetMessage("FormPSTable6");
                    if (strText == "")
                        strText = "Code must be specified";
                    MessageBox.Show(strText);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AtClosed(object sender, System.EventArgs e)
        {
            PSTable pst = m_PSTable;
            int nEntries = pst.Count();
            if (nEntries > 0)
            {
                CodeTableEntry cte = null;
                for (int i = nEntries; 0 < i; i--)
                {
                    cte = m_PSTable.GetEntry(i - 1);
                    if (cte == null)
                        pst.DeleteEntry(i - 1);
                    else if (cte.Code.Trim() == "")
                        pst.DeleteEntry(i - 1);
                }
                m_PSTable = pst;
            }
        }

        private void Redisplay()
        {
            string strText ="";;
            int n = 0;
            if (m_PSTable.Count() > 0)
            {
                n = nCurrent + 1;
                cte = m_PSTable.GetEntry(nCurrent);
            }
            else
            {
                if (m_Table == null)
                    MessageBox.Show("Table is empty, select Add to add first Part of Speech");
                else
                {
                    strText = m_Table.GetMessage("FormPSTable7");
                    if (strText == "")
                        strText = "Table is empty, select Add to add first Part of Speech";
                    MessageBox.Show(strText);
                }
                cte = new CodeTableEntry("", "");
            }
 
            this.tbFind.Text = "";					// Clear Find box
            this.tbCode.Text = cte.Code;
            this.tbDesc.Text = cte.Description;
            this.tbCurrent.Text = n.ToString();
            this.tbCount.Text = m_PSTable.Count().ToString();
        }

        private bool HasChanged()
        {
            bool fChange = false;
            CodeTableEntry cte = null;
            int n = 0;
            if (m_PSTable.Count() > 0)
            {
                n = nCurrent + 1;
                cte = m_PSTable.GetEntry(nCurrent);
            }
            else return fChange;
            if (this.tbCode.Text != cte.Code) fChange = true;
            if (this.tbDesc.Text != cte.Description) fChange = true;
            return fChange;
        }

        private void UpdateFormForLocalization(LocalizationTable table)
        {
            string strText = "";
            strText = table.GetForm("FormPSTableT");
			if (strText != "")
				this.Text = strText;
            strText = table.GetForm("FormPSTable0");
			if (strText != "")
				this.labCode.Text = strText;
            strText = table.GetForm("FormPSTable3");
			if (strText != "")
				this.labOf.Text = strText;
            strText = table.GetForm("FormPSTable5");
			if (strText != "")
				this.labDesc.Text = strText;
            strText = table.GetForm("FormPSTable7");
			if (strText != "")
				this.btnPrevious.Text = strText;
            strText = table.GetForm("FormPSTable8");
			if (strText != "")
				this.btnNext.Text = strText;
            strText = table.GetForm("FormPSTable9");
			if (strText != "")
				this.btnAdd.Text = strText;
            strText = table.GetForm("FormPSTable10");
			if (strText != "")
				this.btnDelete.Text = strText;
            strText = table.GetForm("FormPSTable11");
			if (strText != "")
				this.btnFind.Text = strText;
            strText = table.GetForm("FormPSTable13");
			if (strText != "")
				this.btnSave.Text = strText;
            strText = table.GetForm("FormPSTable14");
			if (strText != "")
				this.btnExit.Text = strText;
            return;
        }
    }
}
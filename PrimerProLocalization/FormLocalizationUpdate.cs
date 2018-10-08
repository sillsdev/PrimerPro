using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrimerProLocalization
{
    public partial class FormLocalizationUpdate : Form
    {
        LocalizationTable m_TableTarget = null;
        LocalizationTable m_TableSource = null;
        SortedList m_MenuListSource = new SortedList();
        SortedList m_MenuListTarget = new SortedList();
        SortedList m_FormListSource = new SortedList();
        SortedList m_FormListTarget = new SortedList();
        SortedList m_TextListSource = new SortedList();
        SortedList m_TextListTarget = new SortedList();
        DataGridViewRow row = null;
        LocalizationEntry entrySrc = null;
        LocalizationEntry entryTrg = null;

        public FormLocalizationUpdate(LocalizationTable tableTarget, LocalizationTable tableSource)
        {
            m_TableTarget = tableTarget;
            m_TableSource = tableSource;
            string strKey = "";
            this.dgvText = new DataGridView();
            this.dgvForm = new DataGridView();
            this.dgvMenu = new DataGridView();
            InitializeComponent();

            m_MenuListSource = tableTarget.MenuList;
            m_MenuListTarget = tableSource.MenuList;
            for (int i = 0; i < m_MenuListSource.Count; i++)
            {
                strKey = (string) m_MenuListSource.GetKey(i);
                entrySrc = (LocalizationEntry) m_MenuListSource[strKey];
                entryTrg = (LocalizationEntry) m_MenuListTarget[strKey];
                if (entrySrc.Idn != "")
                {
                    row = new DataGridViewRow();
                    row.CreateCells(dgvMenu);
                    row.Cells[0].Value = entrySrc.Idn;
                    row.Cells[1].Value = entrySrc.Index;
                    row.Cells[2].Value = entrySrc.Content;
                    if (entryTrg != null)
                        row.Cells[3].Value = entryTrg.Content;
                    else row.Cells[3].Value = "";
                    this.dgvMenu.Rows.Add(row);
                }
                else MessageBox.Show("empty menu");
            }

            m_FormListSource = tableTarget.FormList;
            m_FormListTarget = tableSource.FormList;
            int  nKount = this.dgvMenu.ColumnCount;
            DataGridViewColumn  col  = this.dgvMenu.Columns[2];
                      
            for (int i = 0; i < m_FormListSource.Count; i++)
            {
                strKey = (string)m_FormListSource.GetKey(i);
                entrySrc = (LocalizationEntry)m_FormListSource[strKey];
                entryTrg = (LocalizationEntry)m_FormListTarget[strKey];
                if (entrySrc.Idn != "")
                {
                    row = new DataGridViewRow();
                    row.CreateCells(dgvText);
                    row.Cells[0].Value = entrySrc.Idn;
                    row.Cells[1].Value = entrySrc.Index;
                    row.Cells[2].Value = entrySrc.Content;
                    if (entryTrg != null)
                        row.Cells[3].Value = entryTrg.Content;
                    else row.Cells[3].Value = "";
                    this.dgvForm.Rows.Add(row);
                }
                else MessageBox.Show("empty form");
            }

            m_TextListSource = tableTarget.MessageList;
            m_TextListTarget = tableSource.MessageList;
            for (int i = 0; i < m_TextListSource.Count; i++)
            {
                strKey = (string)m_TextListSource.GetKey(i);
                entrySrc = (LocalizationEntry)m_TextListSource[strKey];
                entryTrg = (LocalizationEntry)m_TextListTarget[strKey];
                if (entrySrc.Idn != "")
                {
                    row = new DataGridViewRow();
                    row.CreateCells(dgvText);
                    row.Cells[0].Value = entrySrc.Idn;
                    row.Cells[1].Value = entrySrc.Index;
                    row.Cells[2].Value = entrySrc.Content;
                    if (entryTrg != null)
                        row.Cells[3].Value = entryTrg.Content;
                    else row.Cells[3].Value = "";
                    this.dgvText.Rows.Add(row);
                }
                else MessageBox.Show("empty text");
            }
        }

        public LocalizationTable TableSource
        {
            get {return m_TableSource;}
        }

        public LocalizationTable TableTarget
        {
            get { return m_TableTarget; }
            set { m_TableTarget = value; }
        }
        
        private void btnOptionsOK_Click(object sender, EventArgs e)
        {
            DataGridView dgvMenu = this.dgvMenu;
            string strKey = "";
            string strIdn = "";
            string strIndex = "";
            String strContent = "";
            int ndx = 0;
            string strText;
 
            for (int i = 0; i < dgvMenu.RowCount; i++)
            {
                row = dgvMenu.Rows[i];
                if (row.Cells[0].Value != null)
                {
                    strIdn = row.Cells[0].Value.ToString();
                    strIndex = row.Cells[1].Value.ToString();
                    strContent = row.Cells[3].Value.ToString();
                    entrySrc = new LocalizationEntry(strIdn, strIndex, strContent);
                    strKey = strIdn + strIndex;
                    ndx = this.TableTarget.MenuList.IndexOfKey(strKey);
                    this.TableTarget.MenuList.SetByIndex(ndx, entrySrc);
                    strText = this.TableTarget.GetMenu(strKey);
                }
            }

            for (int i = 0; i < dgvForm.RowCount; i++)
            {
                row = dgvForm.Rows[i];
                if (row.Cells[0].Value != null)
                {
                    strIdn = row.Cells[0].Value.ToString();
                    strIndex = row.Cells[1].Value.ToString();
                    strContent = row.Cells[3].Value.ToString();
                    entrySrc = new LocalizationEntry(strIdn, strIndex, strContent);
                    strKey = strIdn + strIndex;
                    ndx = this.TableTarget.FormList.IndexOfKey(strKey);
                    this.TableTarget.FormList.SetByIndex(ndx, entrySrc);
                    strText = this.TableTarget.GetForm(strKey);
                }
            }

            for (int i = 0; i < dgvText.RowCount; i++)
            {
                row = dgvText.Rows[i];
                if (row.Cells[0].Value != null)
                {
                    strIdn = row.Cells[0].Value.ToString().Trim();
                    strIndex = row.Cells[1].Value.ToString().Trim();
                    strContent = row.Cells[3].Value.ToString().Trim();
                    entrySrc = new LocalizationEntry(strIdn, strIndex, strContent);
                    strKey = strIdn + strIndex;
                    ndx = this.TableTarget.MessageList.IndexOfKey(strKey);
                    this.TableTarget.MessageList.SetByIndex(ndx, entrySrc);
                    strText = this.TableTarget.GetMessage(strKey);
                }
            }

        }

        private void btnOptionsCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     }
}

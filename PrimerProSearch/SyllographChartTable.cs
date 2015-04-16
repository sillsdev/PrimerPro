using System;
using System.Windows.Forms;
using System.Data;
using GenLib;

namespace PrimerProSearch
{
    /// <summary>
    /// Syllograph Chart Table
    /// </summary>
    public class SyllographChartTable : System.Data.DataTable
    {
        private DataColumn m_DataColumn = null;
        private DataRow m_DataRow = null;
        private DataSet m_DataSet = null;
        private string m_Id = "ID";

        public SyllographChartTable()
        {
            // ID column
            m_DataColumn = new DataColumn();
            m_DataColumn.DataType = System.Type.GetType("System.String");
            m_DataColumn.ColumnName = m_Id;
            
            m_DataColumn.AutoIncrement = false;
            m_DataColumn.ReadOnly = false;
            m_DataColumn.Unique = true;
            this.Columns.Add(m_DataColumn);

            // Second Column
            m_DataColumn = new DataColumn();
            m_DataColumn.DataType = System.Type.GetType("System.String");
            m_DataColumn.ColumnName = "Pri";
            m_DataColumn.Caption = " Primary";
            m_DataColumn.AutoIncrement = false;
            m_DataColumn.ReadOnly = false;
            m_DataColumn.Unique = false;
            this.Columns.Add(m_DataColumn);

            // Third Column
            m_DataColumn = new DataColumn();
            m_DataColumn.DataType = System.Type.GetType("System.String");
            m_DataColumn.ColumnName = "Sec";
            m_DataColumn.Caption = " Secondary";
            m_DataColumn.AutoIncrement = false;
            m_DataColumn.ReadOnly = false;
            m_DataColumn.Unique = false;
            this.Columns.Add(m_DataColumn);

            // Fourth Column
            m_DataColumn = new DataColumn();
            m_DataColumn.DataType = System.Type.GetType("System.String");
            m_DataColumn.ColumnName = "Ter";
            m_DataColumn.Caption = "Tertiary";
            m_DataColumn.AutoIncrement = false;
            m_DataColumn.ReadOnly = false;
            m_DataColumn.Unique = false;
            this.Columns.Add(m_DataColumn);

            // Cresate Rows on the fly later as needed

            // Make the ID column the primary key column
            DataColumn[] dcPrimaryKey = new DataColumn[1];
            dcPrimaryKey[0] = this.Columns[m_Id];
            this.PrimaryKey = dcPrimaryKey;

            // Add the new DataTable to the DataSet
            m_DataSet = new DataSet();
            m_DataSet.EnforceConstraints = false;
            m_DataSet.Tables.Add(this);
        }

        public DataSet GetDataSet()
        {
            return m_DataSet;
        }

        public DataRow GetDataRow(int n)
        {
            return this.Rows[n];
        }

        public DataColumn GetDataColumn(int n)
        {
            return this.Columns[n];
        }

        public string GetId()
        {
            return m_Id;
        }

        public string GetColumnHeaders()
        {
            string strHdr = "";
            string strHdrs = "";
            string strTab = Constants.Tab;

            foreach (DataColumn dc in this.Columns)
            {
                if (dc.ColumnName != this.GetId())
                {
                    strHdr = Constants.kHCOn + dc.Caption.PadLeft(9) + strTab + Constants.kHCOff;
                    strHdrs += strHdr;
                }
                else
                {
                    strHdrs = Constants.kHCOn + "Syllograph" + strTab + Constants.kHCOff;
                }
            }
            strHdrs += Environment.NewLine;
            return strHdrs;
        }

        public string GetRows()
        {
            string strRows = "";
            foreach (DataRow dr in this.Rows)
            {
                string strRow = dr[this.GetId()].ToString();
                for (int i = 1; i < dr.ItemArray.Length; i++)
                {
                    strRow += Constants.Tab + dr.ItemArray[i].ToString().PadLeft(7);
                }
                strRow += Environment.NewLine;
                strRows += strRow;
            }
            return strRows;
        }

        public SyllographChartTable AddRow(string symbol, string catPrimary, string catSecondary, string catTertiary)
        {
            m_DataRow = this.NewRow();
            m_DataRow[m_Id] = symbol;
            m_DataRow[1] = catPrimary;
            m_DataRow[2] = catSecondary;
            m_DataRow[3] = catTertiary;
            this.Rows.Add(m_DataRow);
            return this;
        }

    }
}

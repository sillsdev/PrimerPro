using System;
using System.Data;
using System.Text;
using GenLib;

namespace PrimerProSearch
{
    public class DiphthongChartTable : DataTable
    {
        private DataColumn m_DataColumn = null;
        private DataRow m_DataRow = null;
        private DataSet m_DataSet = null;
        private string m_Key = "key";
        private string m_Id = "ID";
        private string m_Graphemes = "Graphemes";

        public DiphthongChartTable()
        {
            //Key column
            m_DataColumn = new DataColumn();
            m_DataColumn.DataType = System.Type.GetType("System.String");
            m_DataColumn.ColumnName = m_Key;
            m_DataColumn.Caption = "Key";
            m_DataColumn.AutoIncrement = false;
            m_DataColumn.ReadOnly = false;
            m_DataColumn.Unique = true;
            this.Columns.Add(m_DataColumn);

            //ID Column
            m_DataColumn = new DataColumn();
            m_DataColumn.DataType = System.Type.GetType("System.String");
            m_DataColumn.ColumnName = m_Id;
            m_DataColumn.Caption = "ID";
            m_DataColumn.AutoIncrement = false;
            m_DataColumn.ReadOnly = false;
            m_DataColumn.Unique = false;
            this.Columns.Add(m_DataColumn);

            //Graphemes Column
            m_DataColumn = new DataColumn();
            m_DataColumn.DataType = System.Type.GetType("System.String");
            m_DataColumn.ColumnName = m_Graphemes;
            m_DataColumn.Caption = "Graphemes";
            m_DataColumn.AutoIncrement = false;
            m_DataColumn.ReadOnly = false;
            m_DataColumn.Unique = false;
            this.Columns.Add(m_DataColumn);

            // Create Rows on the fly later as needed

            // Make the ID column the primary key column.
            DataColumn[] dcPrimaryKey = new DataColumn[1];
            dcPrimaryKey[0] = this.Columns[m_Key];
            this.PrimaryKey = dcPrimaryKey;

            // Add the new DataTable to the DataSet.
            m_DataSet = new DataSet();
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

        public string GetKey()
        {
            return m_Key;
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
                    strHdr = Constants.kHCOn + dc.Caption.Trim() + strTab + Constants.kHCOff;
                    strHdrs += strHdr;
                }
                else
                {
                    strHdrs = Constants.kHCOn + "Diph" + strTab + Constants.kHCOff;
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
                for (int i = 2; i < dr.ItemArray.Length; i++)
                {
                    strRow += Constants.Tab + dr.ItemArray[i].ToString();
                }
                strRow += Environment.NewLine;
                strRows += strRow;
            }
            return strRows;
        }

        public DiphthongChartTable AddRow(string symbol, string key, string graphemes)
        {
            m_DataRow = this.NewRow();
            m_DataRow[m_Key] = key;
            m_DataRow[m_Id] = symbol;
            m_DataRow[m_Graphemes] = graphemes;
            try
            {
                this.Rows.Add(m_DataRow);
            }
            catch (System.Exception ex)
            {
                string msg = symbol + " row not processed due to exception: "
                    + ex.GetType().ToString();
                System.Windows.Forms.MessageBox.Show(msg);
            }
            return this;
        }

    }
}

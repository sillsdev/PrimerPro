using System;
using System.Windows.Forms;
using System.Data;
using GenLib;

namespace PrimerProSearch
{
	/// <summary>
	/// 
	/// </summary>
	public class ToneChartTable : System.Data.DataTable
	{
		private DataColumn m_DataColumn = null;
		private DataRow m_DataRow = null;
		private DataSet m_DataSet = null;
		private string m_Id = "ID";

		public ToneChartTable()
		{
			//ID column
			m_DataColumn = new DataColumn();
			m_DataColumn.DataType = System.Type.GetType("System.String");
			m_DataColumn.ColumnName = m_Id;
			m_DataColumn.AutoIncrement = false;
			m_DataColumn.ReadOnly = false;
			m_DataColumn.Unique = true;
			this.Columns.Add(m_DataColumn);

			//Second Column
            m_DataColumn = new DataColumn();
            m_DataColumn.DataType = System.Type.GetType("System.String");
            m_DataColumn.ColumnName = "TBU";
            m_DataColumn.Caption = "TBU";
            m_DataColumn.AutoIncrement = false;
            m_DataColumn.ReadOnly = false;
            m_DataColumn.Unique = false;
            this.Columns.Add(m_DataColumn);

			// Third column
            m_DataColumn = new DataColumn();
            m_DataColumn.DataType = System.Type.GetType("System.String");
            m_DataColumn.ColumnName = "LVL";
            m_DataColumn.Caption = "Level";
            m_DataColumn.AutoIncrement = false;
            m_DataColumn.ReadOnly = false;
            m_DataColumn.Unique = false;
            this.Columns.Add(m_DataColumn);

			// Create Rows on the fly later as needed
			
			// Make the ID column the primary key column.
			DataColumn[] dcPrimaryKey = new DataColumn[1];
			dcPrimaryKey[0] = this.Columns[m_Id];
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
					strHdrs  = Constants.kHCOn + "Tone" + strTab + Constants.kHCOff;
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
                    strRow += Constants.Tab + dr.ItemArray[i].ToString();
				}
				strRow += Environment.NewLine;
				strRows += strRow;
			}
			return strRows;
		}

		public ToneChartTable AddRow(string symbol, string level, string tbu)
		{
			m_DataRow = this.NewRow();
			m_DataRow[m_Id] = symbol;
			m_DataRow[1] = tbu;
			m_DataRow[2] = level;
			this.Rows.Add(m_DataRow);
			return this;
		}
		
	}
}

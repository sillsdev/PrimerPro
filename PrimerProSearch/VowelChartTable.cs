using System;
using System.Windows.Forms;
using System.Data;
using GenLib;

namespace PrimerProSearch
{
	/// <summary>
	/// 
	/// </summary>
	public class VowelChartTable : DataTable
	{
		private DataColumn m_DataColumn = null;
		private DataRow m_DataRow = null;
		private DataSet m_DataSet = null;
		private string m_Id = "ID";

		public VowelChartTable()
		{
			//ID column
			m_DataColumn = new DataColumn();
			m_DataColumn.DataType = System.Type.GetType("System.String");
			m_DataColumn.ColumnName = m_Id;
			m_DataColumn.AutoIncrement = false;
			m_DataColumn.ReadOnly = false;
			m_DataColumn.Unique = true;
			this.Columns.Add(m_DataColumn);

			//First Column
			m_DataColumn = new DataColumn();
			m_DataColumn.DataType = System.Type.GetType("System.String");
			m_DataColumn.ColumnName = "FU";
			m_DataColumn.Caption = "Front Unrnd";
			m_DataColumn.AutoIncrement = false;
			m_DataColumn.ReadOnly = false;
			m_DataColumn.Unique = false;
			this.Columns.Add(m_DataColumn);

			// Second column.
			m_DataColumn = new DataColumn();
			m_DataColumn.DataType = System.Type.GetType("System.String");
			m_DataColumn.ColumnName = "FR";
			m_DataColumn.Caption = "Front Round";
			m_DataColumn.AutoIncrement = false;
			m_DataColumn.ReadOnly = false;
			m_DataColumn.Unique = false;
			this.Columns.Add(m_DataColumn);

			// Third column.
			m_DataColumn = new DataColumn();
			m_DataColumn.DataType = System.Type.GetType("System.String");
			m_DataColumn.ColumnName = "CU";
			m_DataColumn.Caption = "Cntrl Unrnd";
			m_DataColumn.AutoIncrement = false;
			m_DataColumn.ReadOnly = false;
			m_DataColumn.Unique = false;
			this.Columns.Add(m_DataColumn);

			// Fourth column.
			m_DataColumn = new DataColumn();
			m_DataColumn.DataType = System.Type.GetType("System.String");
			m_DataColumn.ColumnName = "CR";
			m_DataColumn.Caption = "Cntrl Round";
			m_DataColumn.AutoIncrement = false;
			m_DataColumn.ReadOnly = false;
			m_DataColumn.Unique = false;
			this.Columns.Add(m_DataColumn);

			// Fifth column.
			m_DataColumn = new DataColumn();
			m_DataColumn.DataType = System.Type.GetType("System.String");
			m_DataColumn.ColumnName = "BU";
			m_DataColumn.Caption = "Back Unrnd";
			m_DataColumn.AutoIncrement = false;
			m_DataColumn.ReadOnly = false;
			m_DataColumn.Unique = false;
			this.Columns.Add(m_DataColumn);

			// Sixth column.
			m_DataColumn = new DataColumn();
			m_DataColumn.DataType = System.Type.GetType("System.String");
			m_DataColumn.ColumnName = "BR";
			m_DataColumn.Caption = "Back Round";
			m_DataColumn.AutoIncrement = false;
			m_DataColumn.ReadOnly = false;
			m_DataColumn.Unique = false;
			this.Columns.Add(m_DataColumn);

			// Create six rows and add them to the DataTable
			m_DataRow = this.NewRow();
			m_DataRow[m_Id] = "High +ATR";
			this.Rows.Add(m_DataRow);

			m_DataRow = this.NewRow();
			m_DataRow[m_Id] = "High -ATR";
			this.Rows.Add(m_DataRow);

			m_DataRow = this.NewRow();
			m_DataRow[m_Id] = "Mid  +ATR";
			this.Rows.Add(m_DataRow);
			
			m_DataRow = this.NewRow();
			m_DataRow[m_Id] = "Mid  -ATR";
			this.Rows.Add(m_DataRow);

			m_DataRow = this.NewRow();
			m_DataRow[m_Id] = "Low +ATR";
			this.Rows.Add(m_DataRow);

			m_DataRow = this.NewRow();
			m_DataRow[m_Id] = "Low -ATR";
			this.Rows.Add(m_DataRow);

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

		public void UpdChartCell(string sym, int row, int col)
		{
			DataRow dr = this.Rows[row];
			object [] ia = dr.ItemArray;
			ia.SetValue(sym, col);
			this.AcceptChanges();
			this.BeginLoadData();
			dr = this.LoadDataRow(ia,false);
			this.EndLoadData();
		}

		public string GetId()
		{
			return m_Id;
		}

		public int GetRowNumber(string strCode)
		{
			int nRow = -1;
			switch  (strCode)
			{
				case "HP":
					nRow = 0;
					break;
				case "HM":
					nRow = 1;
					break;
				case "MP":
					nRow = 2;
					break;
				case "MM":
					nRow = 3;
					break;
				case "LP":
					nRow = 4;
					break;
				case "LM":
				    nRow = 5;
					break;
				default:
                    MessageBox.Show("Error: Undefined row in vowel chart");
                    break;
			}
			return nRow;
		}

		public int GetColNumber(string strCode)
		{
			int nCol = -1;
			switch  (strCode)
			{
				case "FU":
					nCol = 1;
					break;
				case "FR":
					nCol = 2;
					break;
				case "CU":
					nCol = 3;
					break;
				case "CR":
					nCol = 4;
					break;
				case "BU":
					nCol = 5;
					break;
				case "BR":
					nCol = 6;
					break;
				default:
					MessageBox.Show("Error: Undefined column in vowel chart");
					break;
			}
			return nCol;
		}

		public string GetColumnHeaders()
		{
			string strHdrs = "";
			string strHdrs1 = "";
			string strHdrs2 = "";
			string strTab = Constants.Tab;
            char chSpace = Constants.Space;
			int ndx;

			foreach (DataColumn dc in this.Columns)
			{
				if (dc.ColumnName != this.GetId())
				{
					ndx = dc.Caption.IndexOf(chSpace);
					strHdrs1 += strTab + dc.Caption.Substring(0, ndx).Trim();
					strHdrs2 += strTab + dc.Caption.Substring(ndx+1).Trim();
				}
				strHdrs  = strHdrs1 + strTab + Environment.NewLine;
				strHdrs += strHdrs2 + strTab + Environment.NewLine;
				strHdrs = Constants.kHCOn + strHdrs + Constants.kHCOff;
			}
			return strHdrs;
		}

		public string GetRows()
		{
			string strRow = "";
			int nSize = 0;

			foreach (DataRow dr in this.Rows)
			{
				nSize = dr.ItemArray.Length;
                strRow += Constants.kHCOn + dr[this.GetId()].ToString()
                    + Constants.Tab + Constants.kHCOff;
				for (int i = 1; i < nSize; i++)
				{
                    strRow += dr.ItemArray[i] + Constants.Tab;
				}
				strRow += Environment.NewLine;
			}
			return strRow;
		}

	}
}

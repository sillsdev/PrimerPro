using System;
using System.Data;
using System.Collections;
using PrimerProObjects;
using PrimerProForms;
using GenLib;

namespace PrimerProSearch
{
	/// <summary>
	/// 
	/// </summary>
	public class SyllableChartTable : DataTable
	{
		private FormSyllableChart.StructureType m_Type; 
		private DataColumn m_DataColumn;
		private DataRow m_DataRow;
		private DataSet m_DataSet;
		private string m_ID;

		public SyllableChartTable(FormSyllableChart.StructureType st)
		{
			m_Type = st;			//Word or Root
			m_ID = "ID";
			//ID column
			m_DataColumn = new DataColumn();
			m_DataColumn.DataType = System.Type.GetType("System.String");
			m_DataColumn.ColumnName = m_ID;
			m_DataColumn.AutoIncrement = false;
			m_DataColumn.ReadOnly = false;
			m_DataColumn.Unique = true;
			this.Columns.Add(m_DataColumn);
		
			//3 Columns
			string strName = "";
			string strCapt = "";
			for (int i = 1; i < 4; i++)
			{
				switch ( i )
				{
					case 1:
                        if (m_Type == FormSyllableChart.StructureType.Root)
						{
							strName = "RI";
							strCapt = "Init";
						}
						else
						{
							strName = "WI";
							strCapt = "Init";
						}
						break;
					case 2:
                        if (m_Type == FormSyllableChart.StructureType.Root)
						{
							strName = "RM";
							strCapt = "Medial";
						}
						else
						{
							strName = "WM";
							strCapt = "Medial";
						}
						break;
					case 3:
                        if (m_Type == FormSyllableChart.StructureType.Root)
						{
							strName = "RF";
							strCapt = "Final";
						}
						else
						{
							strName = "WF";
							strCapt = "Final";
						}
						break;
					default:
						strName = "";
						strCapt = "";
						break;
				}
				m_DataColumn = new DataColumn();
                //m_DataColumn.DataType = System.Type.GetType("PrimerProObjects.WordList");
                m_DataColumn.DataType = typeof(PrimerProObjects.WordList);
				m_DataColumn.ColumnName = strName;
				m_DataColumn.Caption = strCapt;
				m_DataColumn.AutoIncrement = false;
				m_DataColumn.ReadOnly = false;
				m_DataColumn.Unique = false;
				this.Columns.Add(m_DataColumn);
 			}

			// Create Rows on the fly later as needed
			
			// Make the ID column the primary key column.
			DataColumn[] dcPrimaryKey = new DataColumn[1];
			dcPrimaryKey[0] = this.Columns[m_ID];
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
			if (n < this.Rows.Count)
				return this.Rows[n];
			else return null;
		}

		public DataColumn GetDataColumn(int n)
		{
			if (n < this.Columns.Count)
				return this.Columns[n];
			else return null;
		}

		public string GetID()
		{
			return m_ID;
		}

        public int GetRowIndex(string strPatt)
        {
            int num = 0;
            bool found = false;
            DataRow dr = null;

            for (int i = 0; i < this.Rows.Count; i++)
            {
                dr = this.GetDataRow(i);
                if ((string)dr[m_ID] == strPatt)
                {
                    num = i;
                    found = true;
                    break;
                }
            }
            if (!found)			//Row does not exist yet, so add it
            {
                m_DataRow = this.NewRow();
                m_DataRow[m_ID] = strPatt;
                this.Rows.Add(m_DataRow);
                num = this.Rows.Count - 1;
            }
            return num;
        }

        public string GetColumnHeaders()
        {
            string strHdrs = "";
            string strHdr1 = "";
            string strHdr2 = "";
            foreach (DataColumn dc in this.Columns)
            {
                if (dc.ColumnName != "ID")
                {
                    strHdr1 += Constants.Tab + m_Type.ToString();
                    strHdr2 += Constants.Tab + dc.Caption;
                }
            }
            strHdr1 += Constants.Tab + Environment.NewLine;
            strHdr2 += Constants.Tab + Environment.NewLine;
            strHdrs = Constants.kHCOn + strHdr1 + strHdr2 + Constants.kHCOff;
            return strHdrs;
        }

        public string GetRows()
        {
            string strRow = "";
            WordList wl = null;
            int nSize = 0;

            foreach (DataRow dr in this.Rows)
            {
                nSize = dr.ItemArray.Length;
                strRow += Constants.kHCOn + dr[this.GetID()].ToString()
                    + Constants.Tab + Constants.kHCOff;
                for (int i = 1; i < nSize; i++)
                {
                    if (dr.ItemArray[i].ToString() != "")
                    {
                        wl = (WordList)dr.ItemArray[i];
                        strRow += wl.WordCount().ToString().PadLeft(5) + Constants.Tab;
                    }
                    else strRow += Constants.Space.ToString().PadLeft(5) + Constants.Tab;
                    ;
                }
                strRow += Environment.NewLine;
            }
            return strRow;
        }

        public WordList GetWordList(int row, int col)
        {
            WordList wl = null;
            DataRow dr = this.Rows[row];
            if (dr.ItemArray[col].ToString() != "")
                wl = (WordList)dr.ItemArray[col];
            return wl;
        }

        public void IncrChartCell(int row, int col)
		{
			int num = 0;
			string str = "";
			DataRow dr = null;
			num = this.Rows.Count;
            dr = this.Rows[row];
			object [] ia = dr.ItemArray;
 
			if (ia.GetValue(col) != null)
			{
				str = ia.GetValue(col).ToString();
				if (str == "")
					num = 0;
				else num = Convert.ToInt32(str);
				num++;
				str = num.ToString();
			}
			else str = "1";

			ia.SetValue(str, col);
			this.AcceptChanges();
			this.BeginLoadData();
			dr = this.LoadDataRow(ia,false);
			this.EndLoadData();
		}

		public int GetChartCell(int row, int col)
		{
			int num = 0;
			object [] ia = this.Rows[row].ItemArray;
			if ( ia == null)
				return 0;
			if ( ia.GetValue(col) == null)
				num = 0;
			else 
			{
				string str = ia.GetValue(col).ToString();
				if (str == "")
					num = 0;
				else num = Convert.ToInt32(str);
			}
			return num;
		}

        public void UpdateChartCell(int row, int col, Word wrd)
        {
            int num = 0;
            object obj = null;
            WordList wl = null;
            DataRow dr = null;
            num = this.Rows.Count;
            dr = this.Rows[row];
            object[] ia = dr.ItemArray;

            if (ia.GetValue(col).ToString() != "")
            {
                obj = ia.GetValue(col);
                if (obj == null)
                    wl = new WordList();
                else wl = (WordList)obj;
                wl.AddWord(wrd);
                obj = (object)wl;
            }
            else
            {
                wl = new WordList();
                wl.AddWord(wrd);
                obj = (object)wl;
            }

            ia.SetValue(obj, col);
            this.AcceptChanges();
            this.BeginLoadData();
            dr = this.LoadDataRow(ia, false);
            this.EndLoadData();
        }

    }
}

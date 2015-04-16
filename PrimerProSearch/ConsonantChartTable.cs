using System;
using System.Data;
using System.Windows.Forms;
using PrimerProObjects;
using GenLib;

namespace PrimerProSearch
{
	/// <summary>
	/// 
	/// </summary>
	public class ConsonantChartTable : DataTable
	{
		private DataColumn m_DataColumn = null;
		private DataRow m_DataRow = null;
		private DataSet m_DataSet = null;
		private string m_Id = "ID";

        public ConsonantChartTable()
		{
			//ID column
			m_DataColumn = new DataColumn();
			m_DataColumn.DataType = System.Type.GetType("System.String");
			m_DataColumn.ColumnName = m_Id;
			m_DataColumn.AutoIncrement = false;
			m_DataColumn.ReadOnly = false;
			m_DataColumn.Unique = true;
			this.Columns.Add(m_DataColumn);

			//12 Columns
			string strName = "";
			string strCapt = "";
			for (int i = 1; i < 13; i++)
			{
				switch ( i )
				{
					case 1:
						strName = "BL";
						strCapt = "Bilab";
						break;
					case 2:
						strName = "LD";
						strCapt = "LbDen";
						break;
					case 3:
						strName = "DE";
						strCapt = "Dent";
						break;
					case 4:
						strName = "AL";
						strCapt = "Alveo";
						break;
					case 5:
						strName = "PO";
						strCapt = "Posta";
						break;
					case 6:
						strName = "RE";
						strCapt = "Retro";
						break;
					case 7:
						strName = "PA";
						strCapt = "Palat";
						break;
					case 8:
						strName = "VE";
						strCapt = "Velar";
						break;
					case 9:
						strName = "LV";
						strCapt = "LbVel";
						break;
					case 10:
						strName = "UV";
						strCapt = "Uvula";
						break;
					case 11:
						strName = "PH";
						strCapt = "Phary";
						break;
					case 12:
						strName = "GL";
						strCapt = "Glott";
						break;
					default:
						strName = "";
						strCapt = "";
						break;
				}
				m_DataColumn = new DataColumn();
				m_DataColumn.DataType = System.Type.GetType("System.String");
				m_DataColumn.ColumnName = strName;
				m_DataColumn.Caption = strCapt;
				m_DataColumn.AutoIncrement = false;
				m_DataColumn.ReadOnly = false;
				m_DataColumn.Unique = false;
				this.Columns.Add(m_DataColumn);
			}

			// Create 24 rows and add them to the DataTable
			string strLabel = "";
			for (int i = 1; i < 25; i++)
			{
				switch ( i )
				{
					case 1:
						strLabel = "Vl Stop";
						break;
					case 2:
						strLabel = "Vd Stop";
						break;
					case 3:
						strLabel = "Vl Nasal";
						break;
					case 4:
						strLabel = "Vd Nasal";
						break;
					case 5:
						strLabel = "Vl Trill";
						break;
					case 6:
						strLabel = "Vd Trill";
						break;
					case 7:
						strLabel = "Vl Flap";
						break;
					case 8:
						strLabel = "Vd Flap";
						break;
					case 9:
						strLabel = "Vl Fric";
						break;
					case 10:
						strLabel = "Vd Fric";
						break;
					case 11:
						strLabel = "Vl Affr";
						break;
					case 12:
						strLabel = "Vd Affr";
						break;
					case 13:
						strLabel = "Vl LatFr";
						break;
					case 14:
						strLabel = "Vd LatFr?";
						break;
					case 15:
						strLabel = "Vl LatAp";
						break;
					case 16:
						strLabel = "Vd LatAp";
						break;
					case 17:
						strLabel = "Vl Appr";
						break;
					case 18:
						strLabel = "Vd Appr";
						break;
					case 19:
						strLabel = "Vl Impl";
						break;
					case 20:
						strLabel = "Vd Impl";
						break;
					case 21:
						strLabel = "Vl Eject";
						break;
					case 22:
						strLabel = "Vd Eject";
						break;
					case 23:
						strLabel = "Vl Click";
						break;
					case 24:
						strLabel = "Vd Click";
						break;
					default:
						strLabel = "";
						break;
				}
				m_DataRow = this.NewRow();
				m_DataRow[m_Id] = strLabel;
				this.Rows.Add(m_DataRow);
			}

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

		public int GetRowNumber(string strCode)
		{
			int nRow = -1;
			switch  (strCode)
			{
				case "PL-":
					nRow = 0;
					break;
				case "PL+":
					nRow = 1;
					break;
				case "NA-":
					nRow = 2;
					break;
				case "NA+":
					nRow = 3;
					break;
				case "TR-":
					nRow = 4;
					break;
				case "TR+":
					nRow = 5;
					break;
				case "FL-":
					nRow = 6;
					break;
				case "FL+":
					nRow = 7;
					break;
				case "FR-":
					nRow = 8;
					break;
				case "FR+":
					nRow = 9;
					break;
				case "AF-":
					nRow = 10;
					break;
				case "AF+":
					nRow = 11;
					break;
				case "LF-":
					nRow = 12;
					break;
				case "LF+":
					nRow = 13;
					break;
				case "LA-":
					nRow = 14;
					break;
				case "LA+":
					nRow = 15;
					break;
				case "AP-":
					nRow = 16;
					break;
				case "AP+":
					nRow = 17;
					break;
				case "IM-":
					nRow = 18;
					break;
				case "IM+":
					nRow = 19;
					break;
				case "EJ-":
					nRow = 20;
					break;
				case "EJ+":
					nRow = 21;
					break;
				case "CL-":
					nRow = 22;
					break;
				case "CL+":
					nRow = 23;
					break;
				default:
					MessageBox.Show("Error: Undefined row in consonant chart");
					break;
			}
			return nRow;
		}

		public int GetColNumber(string strCode)
		{
			int nCol = -1;
			switch  (strCode)
			{
				case "BL":
					nCol = 1;
					break;
				case "LD":
					nCol = 2;
					break;
				case "DE":
					nCol = 3;
					break;
				case "AL":
					nCol = 4;
					break;
				case "PO":
					nCol = 5;
					break;
				case "RE":
					nCol = 6;
					break;
				case "PA":
					nCol = 7;
					break;
				case "VE":
					nCol = 8;
					break;
				case "LV":
					nCol = 9;
					break;
				case "UV":
					nCol = 10;
					break;
				case "PH":
					nCol = 11;
					break;
				case "GL":
					nCol = 12;
					break;
				default:
					MessageBox.Show("Error: Undefined column in consonant chart");
					break;
			}
			return nCol;
		}

		public string GetColumnHeaders()
		{
			bool fEmptyCol = false;
			int nColNum = 0;
			string strColNam = "";
			string strHdrs = "";
			string strTab = Constants.Tab;
			
			foreach (DataColumn dc in this.Columns)
			{
				if (dc.ColumnName != this.GetId())
				{
					strColNam = dc.ColumnName;
					nColNum = this.GetColNumber(strColNam);
					fEmptyCol = true;

					foreach (DataRow dr in this.Rows)
					{
						if ( dr.ItemArray[nColNum].ToString() != "")
						{
							fEmptyCol = false;
							break;
						}
					}
					if ( fEmptyCol )
						dc.Caption = "";			//Column is marked to be skipped
					else strHdrs += strTab + dc.Caption;
				}
			}
			strHdrs = strHdrs + strTab + Environment.NewLine;
			strHdrs = Constants.kHCOn + strHdrs + Constants.kHCOff;
			return strHdrs;
		}

		public string GetRows(ConsonantChartSearch search)
		{
			string strRow = "";
            string strTbl = "";
			bool fEmptyRow = false;
			string str = "";
			int nSize = 0;;
			bool fLabialized = search.Labialized;
			bool fPalatalized = search.Palatalized;
			bool fVelarized = search.Velarized;
			bool fPrenasalized = search.Prenasalized;
			bool fSyllabic = search.Syllabic;
            bool fAspirated = search.Aspirated;
            bool fLong = search.Long;
            bool fGlottalized = search.Glottalized;
 
			foreach (DataRow dr in this.Rows)
			{
				
				fEmptyRow = true;
				nSize = dr.ItemArray.Length;
				for (int i = 1; i < nSize; i++)
				{
					str = dr.ItemArray[i].ToString();
					if (str != "")
					{
						fEmptyRow = false;
						break;
					}
				}

				if ( !fEmptyRow )
				{
					DataColumn dc = null;

					strRow = Constants.kHCOn + dr[this.GetId()].ToString() 
                        + Constants.Tab + Constants.kHCOff;
				
					for (int i = 1; i < nSize; i++)
					{
						dc =this.GetDataColumn(i);
						// if Column is not to be skipped
                        if (dc.Caption != "")
                        {
                            strRow += dr.ItemArray[i] + Constants.Tab;
                        }
					}
					strTbl += strRow + Environment.NewLine;
				}
			}
			return strTbl;
		}

	}
}

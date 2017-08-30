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
	public class CooccurrenceChartTable : DataTable
	{
        private CooccurrenceChartSearch m_Search;
		private DataColumn m_DataColumn;
		private DataRow m_DataRow;
		private DataSet m_DataSet;
        private string m_Key;
 		private string m_ID;


		public CooccurrenceChartTable(CooccurrenceChartSearch search)
		{
            m_Search = search;

            // Key column
            m_Key = "Key";
            m_DataColumn = new DataColumn();
            m_DataColumn.DataType = System.Type.GetType("System.String");
            m_DataColumn.ColumnName = m_Key;
            m_DataColumn.Caption = m_Key;
            m_DataColumn.AutoIncrement = false;
            m_DataColumn.ReadOnly = false;
            m_DataColumn.Unique = true;
            this.Columns.Add(m_DataColumn);

			// ID column
            m_ID = "ID";
            m_DataColumn = new DataColumn();
			m_DataColumn.DataType = System.Type.GetType("System.String");
			m_DataColumn.ColumnName = m_ID;
            m_DataColumn.Caption = m_ID;
			m_DataColumn.AutoIncrement = false;
			m_DataColumn.ReadOnly = false;
            m_DataColumn.Unique = false;
			this.Columns.Add(m_DataColumn);

			// Columns
			if (search.IsConsonantCol())
			{
				Consonant cns = null;
				for (int i = 0; i < search.GI.ConsonantCount(); i++)
				{
					cns = search.GI.GetConsonant(i);
					if (cns.MatchesFeatures(search.CFeatures2))
						this.AddColumn(cns.Symbol);
				}
			}
			if (search.IsVowelCol())
			{
				Vowel vwl = null;
				for (int i = 0; i < search.GI.VowelCount(); i++)
				{
					vwl = search.GI.GetVowel(i);
					if (vwl.MatchesFeatures(search.VFeatures2))
						this.AddColumn(vwl.Symbol);
				}
			}
            if (search.IsSyllographCol())
            {
                Syllograph syllograph = null;
                for (int i = 0; i < search.GI.SyllographCount(); i++)
                {
                    syllograph = search.GI.GetSyllograph(i);
                    if (syllograph.MatchesFeatures(search.SFeatures2))
                        this.AddColumn(syllograph.Symbol);
                }
            }

			//Rows
			if (search.IsConsonantRow())
			{
				Consonant cns = null;
				for (int i = 0; i < search.GI.ConsonantCount(); i++)
				{
					cns = search.GI.GetConsonant(i);
					if (cns.MatchesFeatures(search.CFeatures1))
					{
						m_DataRow = this.NewRow();
                        m_DataRow[m_Key] = cns.GetKey();
						m_DataRow[m_ID] = cns.Symbol;
                        try
                        {
                            this.Rows.Add(m_DataRow);
                        }
                        catch (System.Exception ex)
                        {
                            string msg = cns.Symbol + " row not processed due to exception: "
                                + ex.GetType().ToString();
                            MessageBox.Show(msg);
                        }
                    }
				}
			}
			if (search.IsVowelRow())
			{
				Vowel vwl = null;
				for (int i = 0; i < search.GI.VowelCount(); i++)
				{
					vwl = search.GI.GetVowel(i);
					if (vwl.MatchesFeatures(search.VFeatures1))
					{
                        m_DataRow = this.NewRow();
                        m_DataRow[m_Key] = vwl.GetKey();
                        m_DataRow[m_ID] = vwl.Symbol;
                        try
                        {
                            this.Rows.Add(m_DataRow);
                        }
                        catch (System.Exception ex)
                        {
                            string msg = vwl.Symbol + " row not processed due to exception: "
                                + ex.GetType().ToString();
                            MessageBox.Show(msg);
                        }
 					}
				}
			}
            if (search.IsSyllographRow())
            {
                Syllograph syllograph = null;
                for (int i = 0; i < search.GI.SyllographCount(); i++)
                {
                    syllograph = search.GI.GetSyllograph(i);
                    if (syllograph.MatchesFeatures(search.SFeatures1))
                    {
                        m_DataRow = this.NewRow();
                        m_DataRow[m_Key] = ToUnicodeScalarValue(syllograph.Symbol);
                        m_DataRow[m_ID] = syllograph.Symbol;
                        try
                        {
                            this.Rows.Add(m_DataRow);
                        }
                        catch (System.Exception ex)
                        {
                            string msg = syllograph.Symbol + " row not processed due to exception: "
                                + ex.GetType().ToString();
                            MessageBox.Show(msg);
                        }
                    }
                }
            }

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

        //public string GetID()
        //{
        //    return m_ID;
        //}

		public int GetRowIndex(string strSym)
		{
			int num = -1;
			DataRow dr = null;
            string strKey = "";

			for (int i = 0; i < this.Rows.Count; i++)
			{
				dr = this.GetDataRow(i);
                strKey = strSym;
                if (m_Search.IsSyllographRow())
                    strKey = ToUnicodeScalarValue(strSym);

				if ((string) dr[m_Key] == strKey)
				{
					num = i;
					break;
				}
			}
			return num;
		}

		public int GetColumnIndex(string strSym)
		{
			return this.Columns.IndexOf(strSym);
		}

		public string GetColumnHeaders()
		{
			string strHdrs = "";
			string strTab = Constants.Tab;

			foreach (DataColumn dc in this.Columns)
			{
				if ( (dc.ColumnName != m_ID) && (dc.ColumnName != m_Key) )
				{
					strHdrs += strTab + dc.Caption.ToString().PadLeft(5);
				}
			}
			strHdrs = Constants.kHCOn + strHdrs + Constants.kHCOff + Environment.NewLine;
			return strHdrs;
		}

        public string GetRows(string Caption)
        {
            string strRow = "";
            WordList wl = null;
            int nSize = 0;
            int nCnt = 0;
            FormProgressBar pb = new FormProgressBar(Caption);
            pb.PB_Init(0, this.Rows.Count);

            foreach (DataRow dr in this.Rows)
            {
                nCnt++;
                pb.PB_Update(nCnt);
                nSize = dr.ItemArray.Length;
                strRow += Constants.kHCOn + dr[m_ID].ToString()
                    + Constants.Tab + Constants.kHCOff;
                for (int i = 2; i < nSize; i++)
                {
                    if (dr.ItemArray[i].ToString() != "")
                    {
                        wl = (WordList) dr.ItemArray[i];
                        strRow += wl.WordCount().ToString().PadLeft(5) + Constants.Tab;
                    }
                    else strRow += Constants.Space.ToString().PadLeft(5) + Constants.Tab;
                    ;
                }
                strRow += Environment.NewLine;
            }
            pb.Close();
            return strRow;
        }

        public WordList GetWordList(int row, int col)
        {
            WordList wl = null;
            DataRow dr = this.Rows[row];
            if (dr.ItemArray[col].ToString() != "")
                wl = (WordList) dr.ItemArray[col];
            return wl;
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
                else wl = (WordList) obj;
                wl.AddWord(wrd);
                obj = (object) wl;
            }
            else
            {
                wl = new WordList();
                wl.AddWord(wrd);
                obj = (object) wl;
            }

            ia.SetValue(obj, col);
            this.AcceptChanges();
            this.BeginLoadData();
            dr = this.LoadDataRow(ia, false);
            this.EndLoadData();
        }

        private void AddColumn(string strName)
		{
			m_DataColumn = new DataColumn();
            m_DataColumn.DataType = typeof(PrimerProObjects.WordList);
            m_DataColumn.ColumnName = strName;
			m_DataColumn.Caption = strName;
			m_DataColumn.AutoIncrement = false;
			m_DataColumn.ReadOnly = false;
			m_DataColumn.Unique = false;
			this.Columns.Add(m_DataColumn);
		}

        private string ToUnicodeScalarValue(string str)
        {
            string strUnicode = "";
            int num = 0;
            foreach (char c in str)
            {
                num = (int)c;
                strUnicode = strUnicode + num.ToString();
            }
            return strUnicode;
        }
	
    }
}

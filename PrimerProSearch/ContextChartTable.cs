using System;
using System.Data;
using PrimerProObjects;
using GenLib;

namespace PrimerProSearch
{
	/// <summary>
	/// 
	/// </summary>
	public class ContextChartTable : DataTable
	{
		private DataColumn m_DataColumn;
		private DataRow m_DataRow;
		private DataSet m_DataSet;
		private string m_ID;

		public const string kWordInit = "WI";
		public const string kWordMedial = "WM";
		public const string kWordFinal = "WF";
		public const string kSyllInit = "SI";
		public const string kSyllMedial = "SM";
		public const string kSyllFinal = "SF";
        public const string kInitSyll = "IS";
        public const string kMedialSyll = "MS";
        public const string kFinalSyll = "FS";
		public const string kInRoots = "IR";
		public const string kInAffxs = "IA";
		public const string kOpenSyll = "OS";
		public const string kClosdSyll = "CS";
		public const string kFirstRootC = "FRC";
		public const string kSecndRootC = "SRC";
		public const string kFirstRootV = "FRV";
		public const string kSecndRootV = "SRV";

		public ContextChartTable(ContextChartSearch search)
		{
			m_ID = "ID";
			//ID column
			m_DataColumn = new DataColumn();
			m_DataColumn.DataType = System.Type.GetType("System.String");
			m_DataColumn.ColumnName = m_ID;
			m_DataColumn.AutoIncrement = false;
			m_DataColumn.ReadOnly = false;
			m_DataColumn.Unique = true;
			this.Columns.Add(m_DataColumn);

			// Columns
			if (search.WordInit)
				this.AddColumn(ContextChartTable.kWordInit, "Word Init");
			if (search.WordMedial)
				this.AddColumn(ContextChartTable.kWordMedial, "Word Med");
			if (search.WordFinal)
				this.AddColumn(ContextChartTable.kWordFinal, "Word Fina");
			if (search.SyllableInit)
				this.AddColumn(ContextChartTable.kSyllInit, "Syll Init");
			if (search.SyllableMedial)
                this.AddColumn(ContextChartTable.kSyllMedial, "Syll Med");
			if (search.SyllableFinal)
                this.AddColumn(ContextChartTable.kSyllFinal, "Syll Fina");
            if (search.InitSyllable)
                this.AddColumn(ContextChartTable.kInitSyll, "Init Syll");
            if (search.MedialSyllable)
                this.AddColumn(ContextChartTable.kMedialSyll, "Med Syll");
            if (search.FinalSyllable)
                this.AddColumn(ContextChartTable.kFinalSyll, "Fina Syll");
			if (search.InRoots)
				this.AddColumn(ContextChartTable.kInRoots, "In Roots");
			if (search.InAffixes)
				this.AddColumn(ContextChartTable.kInAffxs, "In Affxs");
			if (search.OpenSyllables)
				this.AddColumn(ContextChartTable.kOpenSyll, "Open Syll");
			if (search.ClosedSyllables)
				this.AddColumn(ContextChartTable.kClosdSyll, "Clos Syll");
			if (search.FirstRootC)
				this.AddColumn(ContextChartTable.kFirstRootC, "1st RootC");
			if (search.SecondRootC)
				this.AddColumn(ContextChartTable.kSecndRootC, "2nd RootC");
			if (search.FirstRootV)
				this.AddColumn(ContextChartTable.kFirstRootV, "1st RootV");
			if (search.SecondRootV)
				this.AddColumn(ContextChartTable.kSecndRootV, "2nd RootV");

			//Rows
			if (search.IsConsonantChart())
			{
				Consonant cns = null;
				for (int i = 0; i < search.GI.ConsonantCount(); i++)
				{
					cns = search.GI.GetConsonant(i);
					if (cns.MatchesFeatures(search.CFeatures))
					{
						m_DataRow = this.NewRow();
						m_DataRow[m_ID] = cns.Symbol;
						this.Rows.Add(m_DataRow);
					}
				}
			}
			if (search.IsVowelChart())
			{
				Vowel vwl = null;
				for (int i = 0; i < search.GI.VowelCount(); i++)
				{
					vwl = search.GI.GetVowel(i);
					if (vwl.MatchesFeatures(search.VFeatures))
					{
						m_DataRow = this.NewRow();
						m_DataRow[m_ID] = vwl.Symbol;
						this.Rows.Add(m_DataRow);
					}
				}
			}
		
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

		public int GetRowIndex(string strId)
		{
			int num = 0;
			bool found = false;
			DataRow dr = null;

			for (int i = 0; i < this.Rows.Count; i++)
			{
				dr = this.GetDataRow(i);
				if ((string) dr[m_ID] == strId)
				{
					num = i;
					found = true;
					break;
				}
			}
			if (!found)			//Row does not exist yet, so add it
			{
				m_DataRow = this.NewRow();
				m_DataRow[m_ID] = strId;
				this.Rows.Add(m_DataRow);
				num = this.Rows.Count - 1;
			}
			return num;
		}

		public int GetColumnIndex(string strColName)
		{
			return this.Columns.IndexOf(strColName);
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
				if (dc.ColumnName != this.GetID())
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

        private void AddColumn(string strName, string strCaption)
		{
			m_DataColumn = new DataColumn();
            //m_DataColumn.DataType = System.Type.GetType("System.String");
            //m_DataColumn.DataType = System.Type.GetType("PrimerProObjects.WordList");
            m_DataColumn.DataType = typeof(PrimerProObjects.WordList);
            m_DataColumn.ColumnName = strName;
			m_DataColumn.Caption = strCaption;
			m_DataColumn.AutoIncrement = false;
			m_DataColumn.ReadOnly = false;
			m_DataColumn.Unique = false;
			this.Columns.Add(m_DataColumn);
		}

	}
}

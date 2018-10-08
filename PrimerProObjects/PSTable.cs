using System;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Xml;
using GenLib;

namespace PrimerProObjects
{
	/// <summary>
	/// 
	/// </summary>
	public class PSTable : CodeTable
	{
        Settings m_Settings;
        string m_FileName;
        
        private const string cTagTable = "Table";
        private const string cTagEntry = "Entry";
        private const string cTagCode = "Code";
        private const string cTagDesc = "Desc";

        public PSTable(Settings s)
		{
            m_Settings = s;
			m_FileName = "";
		}

		public string FileName
		{
			get {return m_FileName;}
			set {m_FileName = value;}
		}

 		public bool LoadFromFile(string strFileName)
		{
			bool flag = false;
			XmlTextReader reader = null;
			CodeTableEntry cte = null;

			if ( File.Exists(strFileName) )
			{
				try 
				{
	       
					// Load the reader with the data file and ignore all white space nodes.         
					reader = new XmlTextReader(strFileName);
					reader.WhitespaceHandling = WhitespaceHandling.None;

					// Parse the file
					string strElement = "";
					string strCode = "";
					string strDesc = "";
					int kount = 0;

					while (reader.Read()) 
					{
						switch (reader.NodeType) 
						{
							case XmlNodeType.Element:
								strElement = reader.Name;
								kount = reader.AttributeCount;
								if ( (strElement == PSTable.cTagEntry) && (reader.AttributeCount > 1) )
								{
									strCode = reader.GetAttribute(PSTable.cTagCode);
									strDesc = reader.GetAttribute(PSTable.cTagDesc);
									cte  = new CodeTableEntry(strCode, strDesc);
									this.AddEntry(cte);
								}
								break;
							case XmlNodeType.Text:
								break;
							case XmlNodeType.CDATA:
								break;
							case XmlNodeType.ProcessingInstruction:
								break;
							case XmlNodeType.Comment:
								break;
							case XmlNodeType.XmlDeclaration:
								break;
							case XmlNodeType.Document:
								break;
							case XmlNodeType.DocumentType:
								break;
							case XmlNodeType.EntityReference:
								break;
							case XmlNodeType.EndElement:
								strElement = reader.Name;
								break;
						}       
					}           
				}

				finally 
				{
					if (reader!=null)
					{
						m_FileName = strFileName;
						reader.Close();
						flag = true;
					}
				}
			}
			return flag;
		}

        public void SaveToFile(string strFileName)
        {
            string strPath = "";
            if (m_Settings.OptionSettings.PSTableFile != "")
            {
                m_FileName = strFileName;
                strPath = Funct.GetFolder(m_FileName);
                if (!Directory.Exists(strPath))
                {
                    m_FileName = m_Settings.PrimerProFolder + Constants.Backslash
                        + Funct.ShortFileNameWithExt(m_FileName);
                    m_Settings.OptionSettings.PSTableFile = m_FileName;
                }
                if (!File.Exists(m_FileName))
                {
                    StreamWriter sw = File.CreateText(m_FileName);
                    sw.Close();
                }
                XmlTextWriter writer = new XmlTextWriter(m_FileName, System.Text.Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartElement(cTagTable);
                CodeTableEntry cte = null;
                string strCode = "";
                string strDesc = "";
                for (int i = 0; i < this.Count(); i++)
                {
                    cte = this.GetEntry(i);
                    strCode = cte.Code;
                    strDesc = cte.Description;
                    writer.WriteStartElement(cTagEntry);
                    writer.WriteAttributeString(cTagCode, strCode);
                    writer.WriteAttributeString(cTagDesc, strDesc);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.Close();
            }
            //else MessageBox.Show("Parts of Speech file not specified");
			else
			{
				string strText = m_Settings.LocalizationTable.GetMessage("PSTable1");
				if (strText == "")
					strText  = "Parts of Speech file not specified";
				MessageBox.Show(strText);
			}
        }

        public string RetrieveSortedTable()
		{
			string strText = "";
			string strKey = "";
			string strLine = "";
			CodeTableEntry cte = null;
			SortedList sl = new SortedList(StringComparer.OrdinalIgnoreCase);

			if ( this.FileName != "" )
			{
				for (int i = 0; i < this.Count(); i++)
				{
					cte = this.GetEntry(i);
					strKey = cte.Description;
					strLine = cte.Code + Constants.Tab + cte.Description;
					sl.Add(strKey, strLine);
				}
				for ( int i = 0; i < sl.Count; i++)
				{
					strLine = (string) sl.GetByIndex(i);
					strText += strLine + Environment.NewLine;
				}
			}
            //else MessageBox.Show("Parts of Speech table is missing");
			else
			{
				strText = m_Settings.LocalizationTable.GetMessage("PSTable2");
				if (strText == "")
					strText  = "Parts of Speech table is missing";
				MessageBox.Show(strText);
			}
            return strText;
		}

		public string RetrieveTable()
		{
			string strText = "";
			CodeTableEntry cte = null;
			if ( this.FileName != "" )
			{
				for (int i = 0; i < this.Count(); i++)
				{
					cte = this.GetEntry(i);
					strText += cte.Code + Constants.Tab;
					strText += cte.Description + Environment.NewLine;
				}
			}
            //else MessageBox.Show("Parts of Speech table is missing");
			else
			{
				strText = m_Settings.LocalizationTable.GetMessage("PSTable2");
				if (strText == "")
					strText  = "Parts of Speech table is missing";
				MessageBox.Show(strText);
			}
            return strText;
		}

	}
}

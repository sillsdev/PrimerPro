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
	public class SightWords
	{
		private Settings m_Settings;
		private string m_FileName;
		private ArrayList m_Words;

		private const string cTagSightWords = "sightwords";
		private const string cTagWord = "word";

		public SightWords(Settings s)
		{
			m_Settings = s;
			m_FileName = "";
			m_Words = new ArrayList();
		}
		
		public string FileName
		{
			get {return m_FileName;}
			set {m_FileName = value;}
		}

		public ArrayList Words
		{
			get {return m_Words;}
			set {m_Words = value;}
		}

		public void AddWord(string strWord)
		{
			m_Words.Add(strWord);
		}

		public void DelWord(int n)
		{
			m_Words.RemoveAt(n);
		}

		public string GetWord(int n)
		{
			if (n < this.Count())
				return (string) m_Words[n];
			else return null;
		}

        public string GetWordInLowerCase(int n)
        {
            if (n < this.Count())
            {
                string str = (string) m_Words[n];
                return str;
            }
            else return null;
        }

		public int Count()
		{
			if (m_Words == null )
				return 0;
			else return m_Words.Count;
		}

		public bool IsSightWord(string strWord)
		{
			bool flag = false;
			for (int i = 0; i < this.Count(); i++)
			{
				if (this.GetWord(i) == strWord)
				{
					flag = true;
					break;
				}
			}
			return flag;
		}

		public bool LoadFromFile(string strFileName)
		{
			bool flag = false;
			m_Words = new ArrayList();
			if (File.Exists(strFileName))
			{
				XmlTextReader reader = null;
				try 
				{
					// Load the reader with the data file and ignore all white space nodes.         
					reader = new XmlTextReader(strFileName);
					reader.WhitespaceHandling = WhitespaceHandling.None;

					// Parse the file
					string nam = "";
					string val = "";
					while (reader.Read()) 
					{
						switch (reader.NodeType) 
						{
							case XmlNodeType.Element:
								nam = reader.Name;
								val = "";
								break;
							case XmlNodeType.Text:
								val = reader.Value;
								if (nam == SightWords.cTagWord)
								{
									this.AddWord(val);
								}
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
								nam = reader.Name;
								break;
						}       
					}           
					flag = true;
				}

				catch
				{
					flag = false;
				}
				finally 
				{
					if (reader!=null)
					{
						m_FileName = strFileName;
						reader.Close();
					}
				}
			}
			return flag;
		}

		public void SaveToFile(string strFileName)
		{
            string strPath = "";
            if (m_Settings.OptionSettings.SightWordsFile != "")
            {
                m_FileName = strFileName;
                strPath = Funct.GetFolder(m_FileName);
                if (!Directory.Exists(strPath))
                {
                    m_FileName = m_Settings.PrimerProFolder + Constants.Backslash
                        + Funct.ShortFileNameWithExt(m_FileName);
                    m_Settings.OptionSettings.SightWordsFile = m_FileName;
                }
                if (!File.Exists(m_FileName))
                {
                    StreamWriter sw = File.CreateText(m_FileName);
                    sw.Close();
                }
                XmlTextWriter writer = new XmlTextWriter(m_FileName, System.Text.Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartElement(cTagSightWords);
                string strWord = "";
                for (int i = 0; i < m_Words.Count; i++)
                {
                    strWord = (string)m_Words[i];
                    writer.WriteElementString(cTagWord, strWord);
                }
                writer.WriteEndElement();
                writer.Close();
            }
            //else MessageBox.Show("Sight Words file not specified");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("SightWords1",
                m_Settings.OptionSettings.UILanguage));
        }

		public string RetrieveSortedTable()
		{
			string strText = "";
			string strKey = "";
			string strLine = "";
            SortedList sl = new SortedList(StringComparer.OrdinalIgnoreCase);

			if (this != null)
			{
				for (int i = 0; i < this.Count(); i++)
				{
					strLine = this.GetWord(i);
					strKey = strLine;
					sl.Add(strKey, strLine);
				}
				for ( int i = 0; i < sl.Count; i++)
				{
					strLine = (string) sl.GetByIndex(i);
					strText += strLine + Environment.NewLine;
				}
			}
            //else MessageBox.Show("Sight Word List is missing");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("SightWords2",
                m_Settings.OptionSettings.UILanguage));
            return strText;
		}

		public string GetMissingWords()
		{
			string strText = "";
			ArrayList alMissingWords = new ArrayList();
			string strWord = "";

			for (int i = 0; i < this.Count(); i++)
			{
				strWord = (string) this.Words[i];
				if ( !m_Settings.WordList.IsWordInList(strWord) )
				{
					if ( !alMissingWords.Contains(strWord) )
					{
						alMissingWords.Add(strWord);
						strText += strWord + Environment.NewLine;
					}
				}
			}
			return strText;
		}

	}
}

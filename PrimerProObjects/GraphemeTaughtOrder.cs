using System;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Xml;
using GenLib;

namespace PrimerProObjects
{
    /// <summary>
    /// Grapheme Taught Order
    /// </summary>
    public class GraphemeTaughtOrder
    {
        private Settings m_Settings;
        private string m_FileName;
        private ArrayList m_Graphemes;

        private const string cTagOrder = "graphemetaughtorder";
        private const string cTagGrapheme = "grapheme";
        private const string cTagGraphemeX = "Grapheme";
        private const string cUndercore = "_";

        public GraphemeTaughtOrder(Settings s)
        {
            m_Settings = s;
            m_FileName = "";
            m_Graphemes = new ArrayList();
        }

 		public string FileName
		{
			get {return m_FileName;}
			set {m_FileName = value;}
		}

		public ArrayList Graphemes
		{
			get {return m_Graphemes;}
			set {m_Graphemes = value;}
		}

        public void AddGrapheme(string grf)
		{
			m_Graphemes.Add(grf);
		}

		public void DelGrapheme(int n)
		{
			m_Graphemes.RemoveAt(n);
		}

		public string GetGrapheme(int n)
		{
			if (n < this.Count())
				return (string) m_Graphemes[n];
			else return null;
		}

		public int Count()
		{
			if (m_Graphemes == null )
				return 0;
			else return m_Graphemes.Count;
		}

        public bool IsTaughtGrapheme(string strGrapheme)
        {
            bool fReturn = false;
            for (int i = 0; i < this.Count(); i++)
            {
                if (this.GetGrapheme(i) == strGrapheme)
                {
                    fReturn = true;
                    break;
                }
            }
            return fReturn;
        }

        public bool LoadFromFile(string strFileName)
        {
            bool flag = false;
            m_Graphemes = new ArrayList();
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
                                if ( (nam == GraphemeTaughtOrder.cTagGrapheme) 
                                    || (nam == GraphemeTaughtOrder.cTagGraphemeX) )
                                {
                                    this.AddGrapheme(val);
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
                    if (reader != null)
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
            
           if (m_Settings.OptionSettings.GraphemeTaughtOrderFile != "")
           {
               m_FileName = m_Settings.OptionSettings.GraphemeTaughtOrderFile;
               strPath = Funct.GetFolder(m_FileName);
               if (!Directory.Exists(strPath))
               {
                   m_FileName = m_Settings.PrimerProFolder + Constants.Backslash
                       + Funct.ShortFileNameWithExt(m_FileName);
                   m_Settings.OptionSettings.GraphemeTaughtOrderFile = m_FileName;
               }
               if (!File.Exists(m_FileName))
               {
                   StreamWriter sw = File.CreateText(m_FileName);
                   sw.Close();
               }
               XmlTextWriter writer = new XmlTextWriter(m_FileName, System.Text.Encoding.UTF8);
               writer.Formatting = Formatting.Indented;
               writer.WriteStartElement(cTagOrder);
               string strGrapheme = "";
               for (int i = 0; i < m_Graphemes.Count; i++)
               {
                   strGrapheme = (string)m_Graphemes[i];
                   writer.WriteElementString(cTagGrapheme, strGrapheme);
               }
               writer.WriteEndElement();
               writer.Close();
           }
           //else MessageBox.Show("Grapheme Taught Order file not specified");
			else
			{
				string strText = m_Settings.LocalizationTable.GetMessage("GraphemeTaughtOrder1");
				if (strText == "")
					strText  = "Grapheme Taught Order file not specified";
				MessageBox.Show(strText);
			}
        }

        public string RetrieveGraphemes()
        {
            string strText = "";
            string strLine = "";

            if (this != null)
            {
                for (int i = 0; i < this.Count(); i++)
                {
                    strLine = this.GetGrapheme(i);
                    strText += strLine + Environment.NewLine;
                }
            }
            //else MessageBox.Show("Graphemes Taught List is missing");
			else
			{
				strText = m_Settings.LocalizationTable.GetMessage("GraphemeTaughtOrder2");
				if (strText == "")
					strText  = "Graphemes Taught List is missing";
				MessageBox.Show(strText);
			}
            return strText;
        }

        //public string GetMissingGraphemes()
        //{
        //    string strText = "";
        //    ArrayList alMissingGraphemes = new ArrayList();
        //    string strGrapheme = "";

        //    for (int i = 0; i < this.Count(); i++)
        //    {
        //        strGrapheme = (string)this.GetGrapheme(i);
        //        if (!m_Settings.GraphemeInventory.IsInInventory(strGrapheme))
        //        {
        //            if (!alMissingGraphemes.Contains(strGrapheme))
        //            {
        //                alMissingGraphemes.Add(strGrapheme);
        //                strText += strGrapheme + Environment.NewLine;
        //            }
        //        }
        //    }
        //    return strText;
        //}

        public string GetMissingGraphemes()
        {
            string strText = "";
            ArrayList alMissingGraphemes = new ArrayList();
            string strGrapheme = "";

            for (int i = 0; i < this.Count(); i++)
            {
                strGrapheme = (string)this.GetGrapheme(i);
                int nLenght = strGrapheme.Length;
                string strGrf = strGrapheme;
                if (nLenght > 1)
                {
                    if (strGrf.Substring(0, 1) == cUndercore)
                        strGrf = strGrf.Substring(1);
                    else if (strGrf.Substring(nLenght - 1, 1) == cUndercore)
                        strGrf = strGrapheme.Substring(0, nLenght - 1);
                }
            if (!m_Settings.GraphemeInventory.IsInInventory(strGrf))
                {
                    if (!alMissingGraphemes.Contains(strGrf))
                    {
                        alMissingGraphemes.Add(strGrapheme);
                        strText += strGrapheme + Environment.NewLine;
                    }
                }
            }
            return strText;
        }
    }
}

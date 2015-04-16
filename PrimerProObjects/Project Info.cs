using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace PrimerProObjects
{
    public class ProjectInfo
    {
        private string m_ProjectName;
        private string m_OptionsFile;
        private string m_PrimerProFolder;
        private string m_FileName;

        private const string kPrimerProFolder = "PrimerPro";
        private const string kBackSlash = "\\";
        private const string kOptions = "Options.xml";
        private const string kExt = ".prj";

        public ProjectInfo()
        {
            m_PrimerProFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
              + kBackSlash + kPrimerProFolder;
            m_ProjectName = "";
            m_OptionsFile = m_PrimerProFolder + kBackSlash + kOptions;
            m_FileName = "";
        }

        public string ProjectName
        {
            get { return m_ProjectName; }
        }

        public string OptionsFile
        {
            get { return m_OptionsFile; }
        }

        public string PrimerProFolder
        {
            get { return m_PrimerProFolder; }
        }

        public string FileName
        {
            get { return m_FileName; }
        }

        public void BuildProjectInfo(string strName)
        {
            m_ProjectName = strName;
            m_OptionsFile = m_PrimerProFolder + kBackSlash + strName + kOptions;
            m_FileName = m_PrimerProFolder + kBackSlash + strName + kExt;
        }

        public bool LoadInfo(string strFileName)
        {
            XmlTextReader reader = null;
            if (!File.Exists(strFileName))
                return false;
            try
            {
                // Load the reader with the data file and ignore all white space nodes.         
                reader = new XmlTextReader(strFileName);
                reader.WhitespaceHandling = WhitespaceHandling.None;

                // Parse the file
                string nam = "";
                string val = "";
                m_FileName = strFileName;

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
                            if (nam == "Name")
                                m_ProjectName = val;
                            if (nam == "OptionsFile")
                                m_OptionsFile = val;
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
            }

            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return true;
        }

        public void SaveInfo(string strFileName)
        {
            XmlTextWriter writer = new XmlTextWriter(strFileName, System.Text.Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartElement("ProjectInfo");
            writer.WriteElementString("Name", m_ProjectName);
            writer.WriteElementString("OptionsFile", m_OptionsFile);
            writer.WriteEndElement();
            writer.Close();
        }

    }
}


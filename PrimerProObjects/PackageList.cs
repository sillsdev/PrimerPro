using System;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using GenLib;

namespace PrimerProObjects
{
    public class PackageList
    {
        private string m_PrimerProFolder;
        private string m_ProjectName;
        private string m_ProjectFile;
        private string m_OptionsFile;
        private string m_DataFolder;
        private string m_TemplateFolder;
        private string m_GraphemeInventoryFile;
        private string m_SightWordsFile;
        private string m_GraphemeTaughtOrderFile;
        private string m_PSTableFile;
        private string m_WordListFile;
        private string m_TextDataFile;
        private Settings m_Settings;

        // XML Elements
        public const string kPackageList = "PackageList";
        public const string kProjectName = "ProjectName";
        public const string kProjectFile = "ProjectFile";
        public const string kOptionsFile = "Options";
        public const string kDataFolder = "DataFolder";
        public const string kTemplateFolder = "TemplateFolder";
        public const string kGIFile = "GraphemeInventoryFile";
        public const string kSWFile = "SightWordsFile";
        public const string kGTOFile = "GraphemeTaughtOrderFile";
        public const string kPSTFile = "PSTableFile";
        public const string kWLFile = "WordListFile";
        public const string kTDFile = "TextDataFile";

        private const string kPrimerProFolder = "PrimerPro";
        private const string kBackSlash = "\\";
    
		public PackageList(Settings s)
		{
            m_Settings = s;
            m_PrimerProFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
              + kBackSlash + kPrimerProFolder;
            
            //m_ProjectName = m_Settings.ProjInfo.ProjectName;
            //m_ProjectFile = m_Settings.ProjInfo.FileName;
            //m_OptionsFile = m_Settings.ProjInfo.OptionsFile;
            //m_DataFolder = m_Settings.OptionSettings.DataFolder;
            //m_TemplateFolder = m_Settings.OptionSettings.PrimerProFolder;
            //m_GraphemeInventoryFile = m_Settings.OptionSettings.GraphemeInventoryFile;
            //m_SightWordsFile = m_Settings.OptionSettings.SightWordsFile;
            //m_GraphemeTaughtOrderFile = m_Settings.OptionSettings.GraphemeTaughtOrderFile;
            //m_PSTableFile = m_Settings.OptionSettings.PSTableFile;
            //m_WordListFile = m_Settings.OptionSettings.WordListFile;
            //m_TextDataFile = m_Settings.OptionSettings.TextDataFile;
   
            m_ProjectName = "";
            m_ProjectFile = "";
            m_OptionsFile = "";
            m_GraphemeInventoryFile = "";
            m_SightWordsFile = "";
            m_GraphemeTaughtOrderFile = "";
            m_PSTableFile = "";
            m_WordListFile = "";
            m_TextDataFile = "";
            m_DataFolder = "";
            m_TemplateFolder = "";
        }

        public string PrimerProFolder
        {
            get { return m_PrimerProFolder; }
        }

        public string ProjectName
        {
            get { return m_ProjectName; }
            set { m_ProjectName = value; }
        }

        public string ProjectFile
        {
            get { return m_ProjectFile; }
            set { m_ProjectFile = value; }
        }

        public string OptionsFile
        {
            get { return m_OptionsFile; }
            set { m_OptionsFile = value; }
        }

        public string DataFolder
        {
            get { return m_DataFolder; }
            set { m_DataFolder = value; }
        }

        public string TemplateFolder
        {
            get { return m_TemplateFolder; }
            set { m_TemplateFolder = value; }
        }

        public string GraphemeInventoryFile
        {
            get { return m_GraphemeInventoryFile; }
            set { m_GraphemeInventoryFile = value; }
        }

        public string SightWordsFile
        {
            get { return m_SightWordsFile; }
            set { m_SightWordsFile = value; }
        }

        public string GraphemeTaughtOrderFile
        {
            get { return m_GraphemeTaughtOrderFile; }
            set { m_GraphemeTaughtOrderFile = value; }
        }

        public string PSTableFile
        {
            get { return m_PSTableFile; }
            set { m_PSTableFile = value; }
        }

        public string WordListFile
        {
            get { return m_WordListFile; }
            set { m_WordListFile = value; }
        }

        public string TextDataFile
        {
            get { return m_TextDataFile; }
            set { m_TextDataFile = value; }
        }

        public void Build()
        {
            m_ProjectName = m_Settings.ProjInfo.ProjectName;
            m_ProjectFile = m_Settings.ProjInfo.FileName;
            m_OptionsFile = m_Settings.ProjInfo.OptionsFile;
            m_DataFolder = m_Settings.OptionSettings.DataFolder;
            m_TemplateFolder = m_Settings.OptionSettings.PrimerProFolder;
            m_GraphemeInventoryFile = m_Settings.OptionSettings.GraphemeInventoryFile;
            m_SightWordsFile = m_Settings.OptionSettings.SightWordsFile;
            m_GraphemeTaughtOrderFile = m_Settings.OptionSettings.GraphemeTaughtOrderFile;
            m_PSTableFile = m_Settings.OptionSettings.PSTableFile;
            m_WordListFile = m_Settings.OptionSettings.WordListFile;
            m_TextDataFile = m_Settings.OptionSettings.TextDataFile;
        }

        public bool Write(string strFileName, string strFolder, bool fIncludeData, bool fIncludeTemplate)
        {
            if (strFileName == "") return false;
            if (strFolder == "") return false;
            
            string str = "";
            str = strFolder + PackageList.kBackSlash + strFileName;
            XmlTextWriter writer = new XmlTextWriter(str, System.Text.Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartElement(PackageList.kPackageList);
            writer.WriteElementString(PackageList.kProjectName, this.ProjectName);
            
            // ProjectFile File
            str = strFolder + PackageList.kBackSlash + Funct.ShortFileNameWithExt(this.ProjectFile);
            File.Copy(this.ProjectFile, str, true);
            str = Funct.ShortFileNameWithExt(this.ProjectFile);
            writer.WriteElementString(PackageList.kProjectFile, str);
            // OptionsFile File
            str = strFolder + PackageList.kBackSlash + Funct.ShortFileNameWithExt(this.OptionsFile);
            File.Copy(this.OptionsFile, str, true);
            str = Funct.ShortFileNameWithExt(this.OptionsFile);
            writer.WriteElementString(PackageList.kOptionsFile, str);
            // Grapheme Inventory File
            str = strFolder + PackageList.kBackSlash + Funct.ShortFileNameWithExt(this.GraphemeInventoryFile);
            File.Copy(this.GraphemeInventoryFile, str, true);
            str = Funct.ShortFileNameWithExt(this.GraphemeInventoryFile);
            writer.WriteElementString(PackageList.kGIFile, str);
            // Sight Words File
            str = strFolder + PackageList.kBackSlash + Funct.ShortFileNameWithExt(this.SightWordsFile);
            File.Copy(this.SightWordsFile, str, true);
            str = Funct.ShortFileNameWithExt(this.SightWordsFile);
            writer.WriteElementString(PackageList.kSWFile, str);
            // Graphemes Taught File
            str = strFolder + PackageList.kBackSlash + Funct.ShortFileNameWithExt(this.GraphemeTaughtOrderFile);
            File.Copy(this.GraphemeTaughtOrderFile, str, true);
            str = Funct.ShortFileNameWithExt(this.GraphemeTaughtOrderFile);
            writer.WriteElementString(PackageList.kGTOFile, str);
            // Parts of Speech File
            str = strFolder + PackageList.kBackSlash + Funct.ShortFileNameWithExt(this.PSTableFile);
            File.Copy(this.PSTableFile, str, true);
            str = Funct.ShortFileNameWithExt(this.PSTableFile);
            writer.WriteElementString(PackageList.kPSTFile, str);
            // Word List File
            if (this.WordListFile != "")
            {
                str = strFolder + PackageList.kBackSlash + Funct.ShortFileNameWithExt(this.WordListFile);
                File.Copy(this.WordListFile, str, true);
                str = Funct.ShortFileNameWithExt(this.WordListFile);
                writer.WriteElementString(PackageList.kWLFile, str);
            }
            // Text Data File
            if (this.TextDataFile != "")
            {
                str = strFolder + PackageList.kBackSlash + Funct.ShortFileNameWithExt(this.TextDataFile);
                File.Copy(this.TextDataFile, str, true);
                str = Funct.ShortFileNameWithExt(this.TextDataFile);
                writer.WriteElementString(PackageList.kTDFile, str);
            }
            if (fIncludeData)
            {
                str = strFolder + PackageList.kBackSlash + PackageList.kDataFolder;
                Funct.FolderCopy(this.DataFolder, str, true);
                str = this.DataFolder.Substring(this.DataFolder.LastIndexOf(PackageList.kBackSlash) + 1);
                writer.WriteElementString(PackageList.kDataFolder, str);
            }
            if (fIncludeTemplate)
            {
                str = strFolder + PackageList.kBackSlash + PackageList.kTemplateFolder;
                Funct.FolderCopy(this.TemplateFolder, str, true);
                str = this.TemplateFolder.Substring(this.TemplateFolder.LastIndexOf(PackageList.kBackSlash) + 1);
                writer.WriteElementString(PackageList.kTemplateFolder, str);
            }

            writer.WriteEndElement();
            writer.Close();
            return true;
        }

        public bool Read(string strFileName, string strFolder)
        {
            if (strFileName == "") return false;
            if (strFolder == "") return false;

			XmlTextReader reader = null;
            string strPath = strFolder + PackageList.kBackSlash + strFileName;
            if (File.Exists(strPath))
            {
                try
                {
                    // Load the reader with the data file and ignore all white space nodes.         
                    reader = new XmlTextReader(strPath);
                    reader.WhitespaceHandling = WhitespaceHandling.None;

                    // Parse the file
                    string nam = "";
                    string val = "";
                    int kount = 0;

                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                nam = reader.Name;
                                kount = reader.AttributeCount;
                                val = "";
                                break;
                            case XmlNodeType.Text:
                                val = reader.Value;
                                SetValue(nam, val);
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
            else
            {
               //MessageBox.Show("Package list is missing from folder");
               MessageBox.Show(m_Settings.LocalizationTable.GetMessage("PackageList1",
                   m_Settings.OptionSettings.UILanguage));
               return false;
            }
        }

        private void SetValue(string nam, string val)
        {
            switch (nam)
            {
                case PackageList.kProjectName:
                    this.ProjectName = val;
                    break;
                case PackageList.kProjectFile:
                    this.ProjectFile = val;
                    break;
                case PackageList.kOptionsFile:
                    this.OptionsFile = val;
                    break;
                case PackageList.kGIFile:
                    this.GraphemeInventoryFile = val;
                    break;
                case PackageList.kSWFile:
                    this.SightWordsFile = val;
                    break;
                case PackageList.kGTOFile:
                    this.GraphemeTaughtOrderFile = val;
                    break;
                case PackageList.kPSTFile:
                    this.PSTableFile = val;
                    break;
                case PackageList.kWLFile:
                    this.WordListFile = val;
                    break;
                case PackageList.kTDFile:
                    this.TextDataFile = val;
                    break;
                case PackageList.kDataFolder:
                    this.DataFolder = val;
                    break;
                case PackageList.kTemplateFolder:
                    this.TemplateFolder = val;
                    break;
                default:
                    break;
            }
        }
 
    }
}


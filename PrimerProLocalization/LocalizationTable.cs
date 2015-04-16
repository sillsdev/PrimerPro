using System;
using System.Collections;
using System.IO;
using System.Xml;

namespace PrimerProLocalization
{
    public class LocalizationTable
    {
        private SortedList m_MenuList;
        private SortedList m_FormList;
        private SortedList m_MessageList;
        private string m_FileName;

        private const string kEntry = "entry";
        private const string kType = "type";
        private const string kIdn = "idn";
        private const string kIndex = "index";
        private const string kEnglish = "en";
        private const string kFrench = "fr";
        private const string kMenu = "M";
        private const string kForms = "F";
        
        public LocalizationTable()
        {
            m_MenuList = new SortedList();
            m_FormList = new SortedList();
            m_MessageList = new SortedList();
            m_FileName = "";
        }

        public SortedList MenuList
        {
            get {return m_MenuList;}
        }

        public SortedList FormList
        {
            get { return m_FormList; }
        }

        public SortedList MessageList
        {
            get { return m_MessageList; }
        }

        public string FileName
        {
            get { return m_FileName; }
        }

        public bool LoadFromFile(string strFileName)
        {
            bool fReturn = false;
            XmlTextReader reader = null;

            if (File.Exists(strFileName))
            {
                try
                {
                    // Load the reader with the data file and ignore all white space nodes.         
                    reader = new XmlTextReader(strFileName);
                    reader.WhitespaceHandling = WhitespaceHandling.None;

                    // parse the file
                    string strElement = "";
                    string strContents = "";
                    string strType = "";
                    string strIdn = "";
                    string strIndex = "";
                    string strEnglish = "";
                    string strFrench = "";
                    LocalizationEntry entry = null;

                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                strElement = reader.Name;
                                switch (strElement)
                                {
                                    case LocalizationTable.kEntry:
                                        strType = reader.GetAttribute(LocalizationTable.kType).Trim();
                                        strIdn = reader.GetAttribute(LocalizationTable.kIdn).Trim();
                                        strIndex = reader.GetAttribute(LocalizationTable.kIndex).Trim();
                                        break;
                                    case LocalizationTable.kEnglish:
                                        break;
                                    case LocalizationTable.kFrench:
                                        break;
                                }
                                strContents = "";
                                break;
                            case XmlNodeType.Text:
                                strContents = reader.Value;
                                switch (strElement)
                                {
                                    case LocalizationTable.kEntry:
                                        break;
                                    case LocalizationTable.kEnglish:
                                        strEnglish = strContents.Trim();
                                        break;
                                    case LocalizationTable.kFrench:
                                        strFrench = strContents.Trim();
                                        break;
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
                                strElement = reader.Name;
                                string strKey = "";
                                if (strElement == LocalizationTable.kEntry)
                                {
                                    entry = new LocalizationEntry(strIdn, strIndex,
                                        strEnglish, strFrench);
                                    if (strType == LocalizationTable.kMenu)
                                        m_MenuList.Add(strIdn, entry);
                                    else if (strType == LocalizationTable.kForms)
                                        m_FormList.Add(strIdn + strIndex.Trim(), entry);
                                    else
                                    {
                                        strKey = strIdn + strIndex;
                                        if (m_MessageList.IndexOfKey(strKey) < 0)
                                            m_MessageList.Add(strKey, entry);
                                    }
                                    strFrench = "";
                                    strEnglish = "";
                                }
                                break;
                        }
                    }
                }
                finally
                {
                    m_FileName = strFileName;
                    reader.Close();
                    fReturn = true;
                }
            }
            return fReturn;
        }

        public string GetMenu(string strKey, string strLang)
        // en = English, fr =French
        {
            string strMenu = "";
            LocalizationEntry entry = (LocalizationEntry)this.MenuList[strKey];
            if (entry != null)
            {
                switch (strLang)
                {
                    case LocalizationTable.kFrench:
                        if (entry.French == "")
                            strMenu = entry.English;
                        else strMenu = entry.French;
                        break;
                    case LocalizationTable.kEnglish:
                        strMenu = entry.English;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (strLang)
                {
                    case LocalizationTable.kFrench:
                        strMenu = "Aucune iteme demenu";
                        break;
                    default:
                        strMenu = "No menu item";
                        break;
                }
            }
            return strMenu;
        }

        public string GetForm(string strKey, string strLang)
        // en = English, fr =French
                {
            string strForm = "";
            LocalizationEntry entry = (LocalizationEntry)this.FormList[strKey];
            if (entry != null)
            {
                switch (strLang)
                {
                    case LocalizationTable.kFrench:
                        if (entry.French == "")
                            strForm = entry.English;
                        else strForm = entry.French;
                        break;
                    case LocalizationTable.kEnglish:
                        strForm = entry.English;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (strLang)
                {
                    case LocalizationTable.kFrench:
                        strForm = "Aucune forme texte";
                        break;
                    default:
                        strForm = "No form text";
                        break;
                }
            }
            return strForm;
        }

        public string GetMessage(string strKey, string strLang)
        // en = English, fr = French 
        {
            string strMessage = "";
            LocalizationEntry entry = (LocalizationEntry)this.MessageList[strKey];
            if (entry != null)
            {
                switch (strLang)
                {
                    case LocalizationTable.kFrench:
                        if (entry.French == "")
                            strMessage = entry.English;
                        else strMessage = entry.French;
                        break;
                    case LocalizationTable.kEnglish:
                        strMessage = entry.English;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (strLang)
                {
                    case LocalizationTable.kFrench:
                        strMessage = "Aucune Message";
                        break;
                    default:
                        strMessage = "No Message";
                        break;
                }
            }
            return strMessage;
        }

        public SortedList GetSubsetOfFormlist(string idn)
        {
            SortedList sl = new SortedList();
            LocalizationEntry entry = null;
            for (int i = 0; i < m_FormList.Count; i++)
            {
                entry = (LocalizationEntry) m_FormList.GetByIndex(i);
                if (entry.Idn == idn)
                    sl.Add(entry.Index, entry);
            }
            return sl;
        }
    }
}

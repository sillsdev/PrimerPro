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

        private const string kLocalization = "localization";
        private const string kEntry = "entry";
        private const string kType = "type";
        private const string kIdn = "idn";
        private const string kIndex = "index";
        private const string kContent = "content";
        public const string kEnglish = "en";
        public const string kFrench = "fr";
        public const string kSpanish = "sp";
        public const string kOther = "oth";
        private const string kMenu = "M";
        private const string kForms = "F";
        private const string kText = "T";
                
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

        //public bool LoadFromFile(string strFileName)
        //{
        //    bool fReturn = false;
        //    XmlTextReader reader = null;

        //    if (File.Exists(strFileName))
        //    {
        //        try
        //        {
        //            // Load the reader with the data file and ignore all white space nodes.         
        //            reader = new XmlTextReader(strFileName);
        //            reader.WhitespaceHandling = WhitespaceHandling.None;

        //            // parse the file
        //            string strElement = "";
        //            string strContents = "";
        //            string strType = "";
        //            string strIdn = "";
        //            string strIndex = "";
        //            string strEnglish = "";
        //            string strFrench = "";
        //            string strSpanish = "";
        //            LocalizationEntry entry = null;

        //            while (reader.Read())
        //            {
        //                switch (reader.NodeType)
        //                {
        //                    case XmlNodeType.Element:
        //                        strElement = reader.Name;
        //                        switch (strElement)
        //                        {
        //                            case LocalizationTable.kEntry:
        //                                strType = reader.GetAttribute(LocalizationTable.kType).Trim();
        //                                strIdn = reader.GetAttribute(LocalizationTable.kIdn).Trim();
        //                                strIndex = reader.GetAttribute(LocalizationTable.kIndex).Trim();
        //                                break;
        //                            case LocalizationTable.kEnglish:
        //                                break;
        //                            case LocalizationTable.kFrench:
        //                                break;
        //                            case LocalizationTable.kSpanish:
        //                                break;
        //                        }
        //                        strContents = "";
        //                        break;
        //                    case XmlNodeType.Text:
        //                        strContents = reader.Value;
        //                        switch (strElement)
        //                        {
        //                            case LocalizationTable.kEntry:
        //                                break;
        //                            case LocalizationTable.kEnglish:
        //                                strEnglish = strContents.Trim();
        //                                break;
        //                            case LocalizationTable.kFrench:
        //                                strFrench = strContents.Trim();
        //                                break;
        //                            case LocalizationTable.kSpanish:
        //                                strSpanish = strContents.Trim();
        //                                break;
        //                        }
        //                        break;
        //                    case XmlNodeType.CDATA:
        //                        break;
        //                    case XmlNodeType.ProcessingInstruction:
        //                        break;
        //                    case XmlNodeType.Comment:
        //                        break;
        //                    case XmlNodeType.XmlDeclaration:
        //                        break;
        //                    case XmlNodeType.Document:
        //                        break;
        //                    case XmlNodeType.DocumentType:
        //                        break;
        //                    case XmlNodeType.EntityReference:
        //                        break;
        //                    case XmlNodeType.EndElement:
        //                        strElement = reader.Name;
        //                        string strKey = "";
        //                        if (strElement == LocalizationTable.kEntry)
        //                        {
        //                            entry = new LocalizationEntry(strIdn, strIndex,
        //                                strEnglish, strFrench, strSpanish);
        //                            if (strType == LocalizationTable.kMenu)
        //                                m_MenuList.Add(strIdn, entry);
        //                            else if (strType == LocalizationTable.kForms)
        //                                m_FormList.Add(strIdn + strIndex.Trim(), entry);
        //                            else
        //                            {
        //                                strKey = strIdn + strIndex;
        //                                if (m_MessageList.IndexOfKey(strKey) < 0)
        //                                    m_MessageList.Add(strKey, entry);
        //                            }
        //                            strFrench = "";
        //                            strEnglish = "";
        //                            strSpanish = "";
        //                        }
        //                        break;
        //                }
        //            }
        //        }
        //        finally
        //        {
        //            m_FileName = strFileName;
        //            reader.Close();
        //            fReturn = true;
        //        }
        //    }
        //    return fReturn;
        //}

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
                    string strType = "";
                    string strIdn = "";
                    string strIndex = "";
                    string strContent = "";
                    LocalizationEntry entry = null;

                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                strElement = reader.Name;
                                if (strElement == LocalizationTable.kEntry)
                                {
                                    strType = reader.GetAttribute(LocalizationTable.kType).Trim();
                                    strIdn = reader.GetAttribute(LocalizationTable.kIdn).Trim();
                                    strIndex = reader.GetAttribute(LocalizationTable.kIndex).Trim();
                                    strContent = "";
                                    if (strIdn == "")
                                        System.Windows.Forms.MessageBox.Show(strType + ": " + strIndex);
                                }
                                break;
                            case XmlNodeType.Text:
                                if (strElement == LocalizationTable.kContent)
                                    strContent = reader.Value;
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
                                if (strElement == LocalizationTable.kEntry)
                                {
                                    entry = new LocalizationEntry(strIdn, strIndex, strContent);
                                    if (strType == LocalizationTable.kMenu)
                                        m_MenuList.Add(strIdn, entry);
                                    if (strType == LocalizationTable.kForms)
                                        m_FormList.Add(strIdn + strIndex.Trim(), entry);
                                    if (strType == LocalizationTable.kText)
                                        m_MessageList.Add(strIdn + strIndex.Trim(), entry);
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

        public bool SaveToFile(string strFileName)
        {
            bool fReturn = true;
            XmlTextWriter writer = null;
            string strKey = "";
            LocalizationEntry entry = null;

            writer = new XmlTextWriter(strFileName, System.Text.Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartElement(LocalizationTable.kLocalization);
            for (int i = 0; i < this.MenuList.Count; i++)
            {
                strKey = (string)this.MenuList.GetKey(i);
                entry = (LocalizationEntry)this.MenuList[strKey];
                writer.WriteStartElement(LocalizationTable.kEntry);
                writer.WriteAttributeString(LocalizationTable.kType, LocalizationTable.kMenu);
                writer.WriteAttributeString(LocalizationTable.kIdn, entry.Idn);
                writer.WriteAttributeString(LocalizationTable.kIndex, entry.Index);
                writer.WriteElementString(LocalizationTable.kContent, entry.Content);
                writer.WriteEndElement();
            }

            for (int i = 0; i < this.FormList.Count; i++)
            {
                strKey = (string)this.FormList.GetKey(i);
                entry = (LocalizationEntry)this.FormList[strKey];
                writer.WriteStartElement(LocalizationTable.kEntry);
                writer.WriteAttributeString(LocalizationTable.kType, LocalizationTable.kForms);
                writer.WriteAttributeString(LocalizationTable.kIdn, entry.Idn);
                writer.WriteAttributeString(LocalizationTable.kIndex, entry.Index);
                writer.WriteElementString(LocalizationTable.kContent, entry.Content);
                writer.WriteEndElement();
            }

            for (int i = 0; i < this.MessageList.Count; i++)
            {
                strKey = (string)this.MessageList.GetKey(i);
                entry = (LocalizationEntry)this.MessageList[strKey];
                writer.WriteStartElement(LocalizationTable.kEntry);
                writer.WriteAttributeString(LocalizationTable.kType, LocalizationTable.kText);
                writer.WriteAttributeString(LocalizationTable.kIdn, entry.Idn);
                writer.WriteAttributeString(LocalizationTable.kIndex, entry.Index);
                writer.WriteElementString(LocalizationTable.kContent, entry.Content);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.Close();
            return fReturn;
        }
       
        //public string GetMenu(string strKey, string strLang)
        //// en = English, fr = French, sp = Spanish
        //{
        //    string strMenu = "";
        //    LocalizationEntry entry = (LocalizationEntry)this.MenuList[strKey];
        //    if (entry != null)
        //    {
        //        switch (strLang)
        //        {
        //            case LocalizationTable.kFrench:
        //                if (entry.French == "")
        //                    strMenu = entry.English;
        //                else strMenu = entry.French;
        //                break;
        //            case LocalizationTable.kSpanish:
        //                if (entry.Spanish == "")
        //                    strMenu = entry.English;
        //                else strMenu = entry.Spanish;
        //                break;
        //            case LocalizationTable.kEnglish:
        //                strMenu = entry.English;
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    else
        //    {
        //        switch (strLang)
        //        {
        //            case LocalizationTable.kFrench:
        //                strMenu = "Pas d'élément de menu";
        //                break;
        //            case LocalizationTable.kSpanish:
        //                strMenu = "Sin elemento de menú";
        //                break;
        //            default:
        //                strMenu = "No menu item";
        //                break;
        //        }
        //    }
        //    return strMenu;
        //}

        public string GetMenu(string strKey)
        {
            string strMenu = "";
            LocalizationEntry entry = (LocalizationEntry)this.MenuList[strKey];
            if (entry != null)
                strMenu = entry.Content;
            else strMenu = "";
            return strMenu;
        }

        //public string GetForm(string strKey, string strLang)
        //// en = English, fr = French, sp = Spanish
        //{
        //    string strForm = "";
        //    LocalizationEntry entry = (LocalizationEntry)this.FormList[strKey];
        //    if (entry != null)
        //    {
        //        switch (strLang)
        //        {
        //            case LocalizationTable.kFrench:
        //                if (entry.French == "")
        //                    strForm = entry.English;
        //                else strForm = entry.French;
        //                break;
        //            case LocalizationTable.kSpanish:
        //                if (entry.Spanish == "")
        //                    strForm = entry.English;
        //                else strForm = entry.Spanish;
        //                break;
        //            case LocalizationTable.kEnglish:
        //                strForm = entry.English;
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    else
        //    {
        //        switch (strLang)
        //        {
        //            case LocalizationTable.kFrench:
        //                strForm = "Pas de texte de formulaire";
        //                break;
        //            case LocalizationTable.kSpanish:
        //                strForm = "Sin texto del formulario";
        //                break;
        //            default:
        //                strForm = "No form text";
        //                break;
        //        }
        //    }
        //    return strForm;
        //}

        public string GetForm(string strKey)
        {
            string strForm = "";
            LocalizationEntry entry = (LocalizationEntry)this.FormList[strKey];
            if (entry != null)
                strForm = entry.Content;
            else strForm = "";
            return strForm;
        }

        //public string GetMessage(string strKey, string strLang)
        //// en = English, fr = French, sp = Spanish
        //{
        //    string strMessage = "";
        //    LocalizationEntry entry = (LocalizationEntry)this.MessageList[strKey];
        //    if (entry != null)
        //    {
        //        switch (strLang)
        //        {
        //            case LocalizationTable.kFrench:
        //                if (entry.French == "")
        //                    strMessage = entry.English;
        //                else strMessage = entry.French;
        //                break;
        //            case LocalizationTable.kSpanish:
        //                if (entry.Spanish == "")
        //                    strMessage = entry.English;
        //                else strMessage = entry.Spanish;
        //                break;
        //            case LocalizationTable.kEnglish:
        //                strMessage = entry.English;
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    else
        //    {
        //        switch (strLang)
        //        {
        //            case LocalizationTable.kFrench:
        //                strMessage = "Pas de Message";
        //                break;
        //            case LocalizationTable.kSpanish:
        //                strMessage = "Sin mensaje";
        //                break;
        //            default:
        //                strMessage = "No Message";
        //                break;
        //        }
        //    }
        //    return strMessage;
        //}

        public string GetMessage(string strKey)
        {
            string strMessage = "";
            LocalizationEntry entry = (LocalizationEntry)this.MessageList[strKey];
            if (entry != null)
                strMessage = entry.Content;
            else strMessage = "";
            return strMessage;
        }

        //public SortedList GetSubsetOfFormlist(string idn)
        //{
        //    SortedList sl = new SortedList();
        //    LocalizationEntry entry = null;
        //    for (int i = 0; i < m_FormList.Count; i++)
        //    {
        //        entry = (LocalizationEntry) m_FormList.GetByIndex(i);
        //        if (entry.Idn == idn)
        //            sl.Add(entry.Index, entry);
        //    }
        //    return sl;
        //}
    }
}

﻿using System;

namespace PrimerProLocalization
{
    public class LocalizationEntry
    {
        private string m_Idn;
        private string m_Index;
        private string m_English;
        private string m_French;

        public LocalizationEntry(string Idn, string Index, string English, string French)
        {
            m_Idn = Idn;
            m_Index = Index;
            m_English = English;
            m_French = French;
        }

        public string Idn
        {
            get { return m_Idn; }
        }

        public string Index
        {
            get { return m_Index; }
        }

        public string English
        {
            get { return m_English; }
        }

        public string French
        {
            get { return m_French; }
        }

    }
}
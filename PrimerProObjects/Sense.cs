using System;
using System.Collections;
using System.Web.UI;
using GenLib;

namespace PrimerProObjects
{
    class Sense
    {
        //private Settings m_Settings;
        private string m_Key;               //key to sorted word list
        private string m_PartOfSpeech;
        private string m_GlossEnglish;
        private string m_GlossNational;
        private string m_GlossRegional;

        public Sense(string key, string PoS, string GlossE, string GlossN, string GlossR)
        {
            m_Key = key;
            m_PartOfSpeech = PoS;
            m_GlossEnglish = GlossE;
            m_GlossNational = GlossN;
            m_GlossRegional = GlossR;
        }

        public string Key
        {
            get { return m_Key;}
            set { m_Key = value; }
        }

        public string PartOfSpeech
        {
            get { return m_PartOfSpeech; }
            set { m_PartOfSpeech = value; }
        }

        public string GlossEnglish
        {
            get { return m_GlossEnglish; }
            set { m_GlossEnglish = value; }
        }

        public string GlossNational
        {
            get { return m_GlossNational; }
            set { m_GlossNational = value; }
        }

        public string GlossRegional
        {
            get { return m_GlossRegional; }
            set { m_GlossRegional = value; }
        }

    }
}

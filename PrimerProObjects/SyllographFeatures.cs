using System;

namespace PrimerProObjects
{
    public class SyllographFeatures
    {
        private string m_CategoryPrimary;
        private string m_CategorySecondary;
        private string m_CategoryTertiary;
        
        public enum SyllographType { None, Pri, Sec, Ter }; 

        public SyllographFeatures()
        {
            m_CategoryPrimary = "";
            m_CategorySecondary = "";
            m_CategoryTertiary = "";
        }

        public string CategoryPrimary
        {
            get { return m_CategoryPrimary; }
            set { m_CategoryPrimary = value; }
        }

        public string CategorySecondary
        {
            get { return m_CategorySecondary; }
            set { m_CategorySecondary = value; }
        }

        public string CategoryTertiary
        {
            get { return m_CategoryTertiary; }
            set { m_CategoryTertiary = value; }
        }

        public SyllographFeatures SetFeature(string strFeature, SyllographType typ)
        {
            switch (typ)
            {
                case SyllographType.Pri:
                    this.CategoryPrimary = strFeature;
                    break;
                case SyllographType.Sec:
                    this.CategorySecondary = strFeature;
                    break;
                case SyllographType.Ter:
                    this.CategoryTertiary = strFeature;
                    break;
                default:
                    break;
            }
            return this;
        }

    }
}

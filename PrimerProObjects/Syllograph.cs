using System;

namespace PrimerProObjects
{
    /// <summary>
    /// Syllograph Class
    /// </summary>
    public class Syllograph : Grapheme
    {
        // Transliteration for Syllograph
        private string m_CategoryPrimary;
        private string m_CategorySecondary;
        private string m_CategoryTertiary;

        private int m_TeachingOrder;

        public Syllograph(string strSymbol): base(strSymbol)
        {
            this.IsSyllograph = true;
            this.CategoryPrimary = "";
            this.CategorySecondary = "";
            this.CategoryTertiary = "";
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

        public int TeachingOrder
        {
            get { return m_TeachingOrder; }
            set { m_TeachingOrder = value; }
        }

        public bool MatchesFeatures(SyllographFeatures sf)
        {
            bool flag = true;
            if (sf != null)
            {
                if ((sf.CategoryPrimary != "") && (sf.CategoryPrimary != this.CategoryPrimary))
                    flag = false;
                if ((sf.CategorySecondary != "") && (sf.CategorySecondary != this.m_CategorySecondary))
                    flag = false;
                if ((sf.CategoryTertiary != "") && (sf.CategoryTertiary != this.m_CategoryTertiary))
                    flag = false;
            }
            return flag;
        }

    }
}

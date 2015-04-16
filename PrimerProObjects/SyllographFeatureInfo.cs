using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrimerProObjects
{
    public class SyllographFeatureInfo
    {
        private string m_Feature;
        private SyllographFeatures.SyllographType m_Type;
        private int m_OrderNumber;
        private int m_CountInWordList;
        private bool m_Available;

        public SyllographFeatureInfo(string strFeature, SyllographFeatures.SyllographType type)
        {
            m_Feature = strFeature;
            m_Type = type;
            m_OrderNumber = 0;
            m_CountInWordList = 0;
            m_Available = true;
        }

        public string Feature
        {
            get { return m_Feature; }
        }

        public SyllographFeatures.SyllographType Type
        {
            get { return m_Type; }
        }

        public int OrderNumber
        {
            get { return m_OrderNumber; }
            set { m_OrderNumber = value; }
        }

        public int CountInWordList
        {
            get { return m_CountInWordList; }
            set { m_CountInWordList = value; }
        }

        public bool Available
        {
            get { return m_Available; }
            set { m_Available = value; }
        }

    }
}

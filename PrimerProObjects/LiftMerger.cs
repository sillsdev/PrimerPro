using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using LiftIO;
using LiftIO.Parsing;

namespace PrimerProObjects
{
    public class LiftMerger : ILexiconMerger <LiftObject, LiftEntry, LiftSense, LiftExample>
    {
        Settings m_Settings;
        SortedList m_SortedList;
        
        public LiftMerger(SortedList sl, Settings s)
        {
            m_SortedList = sl;
            m_Settings = s;
        }
 
        #region ILexiconMerger<LiftObject,LiftEntry,LiftSense,LiftExample> Members

        public void EntryWasDeleted(Extensible info, DateTime dateDeleted)
        {
           //do not need this
        }

        public void FinishEntry(LiftEntry entry)
        {
            string strLexForm;
            if (entry.LexForm == null)
                return;
            if (!entry.LexForm.AsSimpleStrings.TryGetValue(m_Settings.OptionSettings.LiftVernacular,out strLexForm))
                return;
            if (string.IsNullOrEmpty(strLexForm))
                return;
            // Ignore affixes and clitics
            if (entry.MorphType != null && (entry.MorphType.EndsWith("fix") || entry.MorphType.EndsWith("clitic")))
                return;

            Word wrd = new Word(strLexForm, m_Settings);
            if (entry.CitForm != null)
            {
                 string strCitForm;
                 if (entry.CitForm.AsSimpleStrings.TryGetValue(m_Settings.OptionSettings.LiftVernacular, out strCitForm))
                 {
                     //wrd.Root = new Root(strForm, m_Settings);
                     wrd = new Word(strCitForm, m_Settings);
                     wrd.Root = new Root(strLexForm, m_Settings);
                 }
            }

            if (entry.Sense != null)
            {
                 if (!string.IsNullOrEmpty(entry.Sense.PartOfSpeech))
                     wrd.PartOfSpeech = entry.Sense.PartOfSpeech;
                 if (entry.Sense.Gloss != null)
                 {
                     foreach (string lang in entry.Sense.Gloss.Keys)
                     {
                         if (lang == m_Settings.OptionSettings.LiftGlossEnglish)
                             wrd.GlossEnglish = entry.Sense.Gloss[lang].Text;
                         else if (lang == m_Settings.OptionSettings.LiftGlossNational)
                             wrd.GlossNational = entry.Sense.Gloss[lang].Text;
                         else if (lang == m_Settings.OptionSettings.LiftGlossRegional)
                             wrd.GlossRegional = entry.Sense.Gloss[lang].Text;
                     }
                 }
            }
            if ( !m_SortedList.ContainsKey(strLexForm) )
                m_SortedList.Add(strLexForm, wrd);
        }

        public LiftEntry GetOrMakeEntry(Extensible info, int order)
        {
            return new LiftEntry();
        }

        public LiftExample GetOrMakeExample(LiftSense sense, Extensible info)
        {
            return new LiftExample();
        }

        public LiftObject GetOrMakeParentReversal(LiftObject parent, LiftMultiText contents, string type)
        {
            return new LiftObject();
        }

        public LiftSense GetOrMakeSense(LiftEntry entry, Extensible info, string rawXml)
        {
            LiftSense sense = new LiftSense();
            if (entry.Sense == null)
            {
                entry.Sense = sense;
            }
            return sense;
        }

        public LiftSense GetOrMakeSubsense(LiftSense sense, Extensible info, string rawXml)
        {
            return new LiftSense();
        }

        public void MergeInCitationForm(LiftEntry entry, LiftMultiText contents)
        {
            if (entry.CitForm == null)
                entry.CitForm = contents;
        }

        public void MergeInDefinition(LiftSense sense, LiftMultiText liftMultiText)
        {
            //do not need this
        }

        public LiftObject MergeInEtymology(LiftEntry entry, string source, string type, LiftMultiText form, LiftMultiText gloss, string rawXml)
        {
            return new LiftObject();
        }

        public void MergeInExampleForm(LiftExample example, LiftMultiText multiText)
        {
            //throw new NotImplementedException();
            //do not need this
        }

        public void MergeInField(LiftObject extensible, string typeAttribute, DateTime dateCreated, DateTime dateModified, LiftMultiText contents, List<Trait> traits)
        {
            //do not need this
        }

        public void MergeInGloss(LiftSense sense, LiftMultiText multiText)
        {
            if (sense.Gloss == null)
                sense.Gloss = multiText;
        }

        public void MergeInGrammaticalInfo(LiftObject senseOrReversal, string val, List<Trait> traits)
        {
            if (senseOrReversal is LiftSense)
            {
                (senseOrReversal as LiftSense).PartOfSpeech = val;
            }
        }

        public void MergeInLexemeForm(LiftEntry entry, LiftMultiText contents)
        {
            if (entry.LexForm == null)
                entry.LexForm = contents;
        }

        public void MergeInMedia(LiftObject pronunciation, string href, LiftMultiText caption)
        {
            //do not need this
        }

        public void MergeInNote(LiftObject extensible, string type, LiftMultiText contents, string rawXml)
        {
            //do not need this
        }

        public void MergeInPicture(LiftSense sense, string href, LiftMultiText caption)
        {
            //do not need this
        }

        public LiftObject MergeInPronunciation(LiftEntry entry, LiftMultiText contents, string rawXml)
        {
            return new LiftObject();
        }

        public void MergeInRelation(LiftObject extensible, string relationTypeName, string targetId, string rawXml)
        {
            //do not need this
        }

        public LiftObject MergeInReversal(LiftSense sense, LiftObject parent, LiftMultiText contents, string type, string rawXml)
        {
            return new LiftObject();
        }

        public void MergeInSource(LiftExample example, string source)
        {
            //do not need this
        }

        public void MergeInTrait(LiftObject extensible, Trait trait)
        {
            LiftEntry entry = extensible as LiftEntry; 
            if (entry != null)
            {
                if (trait.Name == "MorphType" || trait.Name == "morph-type")
                    entry.MorphType = trait.Value;
            }
        }

        public void MergeInTranslationForm(LiftExample example, string type, LiftMultiText multiText, string rawXml)
        {
            //do not need this
        }

        public LiftObject MergeInVariant(LiftEntry entry, LiftMultiText contents, string rawXml)
        {
            // refer to allomorphs
            return new LiftObject();
        }

        public void ProcessFieldDefinition(string tag, LiftMultiText description)
        {
            //do not need this
        }

        public void ProcessRangeElement(string range, string id, string guid, string parent, LiftMultiText description, LiftMultiText label, LiftMultiText abbrev, string rawXml)
        {
            //do not need this
        }

        #endregion
    }

    public class LiftObject
    {
    }


    public class LiftEntry : LiftObject
    {
        LiftMultiText m_LexForm;
        LiftMultiText m_CitForm;
        string m_MorphType;
        LiftSense m_Sense;

        public LiftMultiText LexForm
        {
            get { return m_LexForm; }
            set { m_LexForm = value; }
        }

        public LiftMultiText CitForm
        {
            get { return m_CitForm; }
            set { m_CitForm = value; }
        }

        public string MorphType
        {
            get { return m_MorphType; }
            set { m_MorphType = value; }
        }

        public LiftSense Sense
        {
            get { return m_Sense; }
            set { m_Sense = value; }
        }

    }

    public class LiftSense : LiftObject
    {
        LiftMultiText m_Gloss;
        string m_PartOfSpeech;

        public LiftMultiText Gloss
        {
            get { return m_Gloss; }
            set { m_Gloss = value; }
        }

        public string PartOfSpeech
        {
            get { return m_PartOfSpeech; }
            set { m_PartOfSpeech = value; }
        }
    }

    public class LiftExample : LiftObject
    {
    }
}

using System;
using System.Windows.Forms;
using System.Collections;
using GenLib;

namespace PrimerProObjects
{
	/// <summary>
	/// 
	/// </summary>
	public class SearchOptions
	{
		private PSTable m_PSTable;			//Parts of Speech code table
		private CodeTableEntry m_PS;		//Parts of Speech entry
		private bool m_IsRootOnly;
		private bool m_IsIdenticalVowelsInWord;
		private bool m_IsIdenticalVowelsInRoot;
        private bool m_IsBrowseView;
		private string m_WordCVShape;
		private string m_RootCVShape;
        private int m_MinSyllables;
        private int m_MaxSyllables;
		private Position m_WordPosition;
		private Position m_RootPosition;

		public enum Position {Any, Initial, Medial, Final};
		public const string kPS = "ps";
		public const string kRootsOnly = "rootsonly";
		public const string kSameVowelsInWord = "samevowelsinword";
		public const string kSameVowelsInRoot = "samevowelsinroot";
        public const string kBrowseView = "browseview";
		public const string kWordCVShape = "wordCVshape";
		public const string kRootCVShape = "rootCVshape";
        public const string kMinSyllables = "minsyllables";
        public const string kMaxSyllales = "maxsyllables";
		public const string kWordPosition = "wordposition";
		public const string kRootPosition = "rootposition";
		private const string kInitial = "Initial";
		private const string kMedial = "Medial";
		private const string kFinal = "Final";

		public SearchOptions(PSTable pst)
		{
			m_PSTable = pst;
			m_PS = null;
			m_IsRootOnly = false;
			m_IsIdenticalVowelsInWord = false;
			m_IsIdenticalVowelsInRoot = false;
            m_IsBrowseView = false;
			m_WordCVShape = "";
			m_RootCVShape = "";
            m_MinSyllables = 0;
            m_MaxSyllables = 0;
			m_WordPosition = Position.Any;
			m_RootPosition = Position.Any;
		}

		public SearchOptions()
		{
			m_PSTable = null;
			m_PS = null;
			m_IsRootOnly = false;
			m_IsIdenticalVowelsInWord = false;
			m_IsIdenticalVowelsInRoot = false;
            m_IsBrowseView = false;
			m_WordCVShape = "";
			m_RootCVShape = "";
            m_MinSyllables = 0;
            m_MaxSyllables = 0;
			m_WordPosition = Position.Any;
			m_RootPosition = Position.Any;
		}

		public PSTable PSTable
		{
			get {return m_PSTable;}
		}

		public CodeTableEntry PS
		{
			get {return m_PS;}
			set {m_PS = value;}
		}

		public bool IsRootOnly
		{
			get {return m_IsRootOnly;}
			set {m_IsRootOnly = value;}
		}

		public bool IsIdenticalVowelsInWord
		{
			get {return m_IsIdenticalVowelsInWord;}
			set {m_IsIdenticalVowelsInWord = value;}
		}
		
		public bool IsIdenticalVowelsInRoot
		{
			get {return m_IsIdenticalVowelsInRoot;}
			set {m_IsIdenticalVowelsInRoot = value;}
		}

        public bool IsBrowseView
        {
            get { return m_IsBrowseView; }
            set { m_IsBrowseView = value; }
        }

		public string WordCVShape
		{
			get {return m_WordCVShape;}
			set {m_WordCVShape = value;}
		}

		public string RootCVShape
		{
			get {return m_RootCVShape;}
			set {m_RootCVShape = value;}
		}

        public int MinSyllables
        {
            get { return m_MinSyllables; }
            set { m_MinSyllables = value; }
        }

        public int MaxSyllables
        {
            get { return m_MaxSyllables; }
            set { m_MaxSyllables = value; }
        }

        public Position WordPosition
		{
			get	{return m_WordPosition;}
			set {m_WordPosition = value;}
		}

		public Position RootPosition
		{
			get {return m_RootPosition;}
			set {m_RootPosition = value;}
		}

		public SearchOptions SetOption(string tag, string content)
		{
			switch (tag)
			{
				case SearchOptions.kPS:
					CodeTableEntry entry = PSTable.GetEntry(content);
					this.PS = entry;
					break;
				case SearchOptions.kRootsOnly:
					this.IsRootOnly = true;
					break;
				case SearchOptions.kSameVowelsInWord:
					this.IsIdenticalVowelsInWord = true;
					break;
				case SearchOptions.kSameVowelsInRoot:
					this.IsIdenticalVowelsInRoot = true;
					break;
                case SearchOptions.kBrowseView:
                    this.m_IsBrowseView = true;
                    break;
				case SearchOptions.kWordCVShape:
					this.WordCVShape = content;
					break;
				case SearchOptions.kRootCVShape:
					this.RootCVShape = content;
					break;
                case SearchOptions.kMinSyllables:
                    this.MinSyllables = Convert.ToInt16(content);
                    break;
                case SearchOptions.kMaxSyllales:
                    this.MaxSyllables = Convert.ToInt16(content);
                    break;
				case SearchOptions.kWordPosition:
					this.WordPosition = SetPosition(content);
					break;
				case SearchOptions.kRootPosition:
					this.RootPosition = SetPosition(content);
					break;
				default:
					break;
			}
            return this;
		}

		public Position SetPosition(string position)
		{
			Position p;
			switch (position)
			{
				case SearchOptions.kInitial:
					p = SearchOptions.Position.Initial;
					break;
				case SearchOptions.kMedial:
					p = SearchOptions.Position.Medial;
					break;
				case SearchOptions.kFinal:
					p = SearchOptions.Position.Final;
					break;
				default:
					p = SearchOptions.Position.Any;
					break;
			}
			return p;
		}

        public bool MatchesWord(Word wrd)
        {
            bool flag = true;

            if (this.PS != null)
            {
                if (this.PS.Code != wrd.PartOfSpeech)
                    flag = false;
            }

            if (this.IsIdenticalVowelsInWord)
            {
                if (!wrd.IsSameVowel())
                    flag = false;
            }

            if (this.IsIdenticalVowelsInRoot)
            {
                if (!wrd.Root.IsSameVowel())
                    flag = false;
            }

            if (this.WordCVShape != "")
            {
                if (this.WordCVShape != wrd.GetCVShapeOfWord())
                    flag = false;
            }

            if (this.RootCVShape != "")
            {
                if (this.RootCVShape != wrd.Root.GetCVShape())
                    flag = false;
            }

            if (this.MinSyllables > 0)
            {
                if (this.MinSyllables > wrd.SyllableCount())
                    flag = false;
            }

            if (this.MaxSyllables > 0)
            {
                if (this.MaxSyllables < wrd.SyllableCount())
                    flag = false;
            }
            
            return flag;
        }

        public bool MatchesPosition(Word wrd, string strGrapheme)
        {
            bool flag = true;
            if (this.WordPosition == SearchOptions.Position.Final)
            {
                if (!wrd.IsWordFinal(strGrapheme))
                    flag = false;
            }
            if (this.WordPosition == SearchOptions.Position.Medial)
            {
                if (!wrd.IsWordMedial(strGrapheme))
                    flag = false;
            }
            if (this.WordPosition == SearchOptions.Position.Initial)
            {
                if (!wrd.IsWordInitial(strGrapheme))
                    flag = false;
            }
            if (this.RootPosition == SearchOptions.Position.Final)
            {
                if (!wrd.Root.IsRootFinal(strGrapheme))
                    flag = false;
            }

            if (this.RootPosition == SearchOptions.Position.Medial)
            {
                if (!wrd.Root.IsRootMedial(strGrapheme))
                    flag = false;
            }

            if (this.RootPosition == SearchOptions.Position.Initial)
            {
                if (!wrd.Root.IsRootInitial(strGrapheme))
                    flag = false;
            }
            return flag;
        }

        public bool MatchesPosition(Word wrd, ArrayList alGraphemes)
        {
            bool flag = false;
            string strGrapheme = "";
            for (int n = 0; n < alGraphemes.Count; n++)
            {
                strGrapheme = (string) alGraphemes[n];
                if (MatchesPosition(wrd, strGrapheme))
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

    }
}

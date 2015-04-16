using System;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Xml;
using System.Drawing;
using System.Text;
using GenLib;

namespace PrimerProObjects
{
	/// <summary>
	/// 
	/// </summary>
	public class GraphemeInventory
	{
		private Settings m_Settings;
		private string m_FileName;
		private ArrayList m_Consonants;
		private ArrayList m_Vowels;
		private ArrayList m_Tones;
        private ArrayList m_Syllographs;
        private int m_MaxGraphemeSize;

        private const string cTagGrfInvent = "GraphemeInventory";
        private const string cTagGrf = "Grapheme";
		private const string cTagFeatures = "Features";
		private const string cTagFeature = "Feature";
        private const string cTagCombination = "Combination";
        private const string cTagDiphthong = "Diphthong";
        private const string cTagSyllograph = "Syllograph";
		private const string cTagSym = "Symbol";
        private const string cTagUpp = "UpperCase";
		private const string cTagTyp = "Type";
		private const string cTagLevel = "Level";
		private const string cTagTBU = "ToneBearingUnit";
        private const string cTagInitial = "Initia1";
        private const string cTagMedial = "Medial";
        private const string cTagFinal = "Final";


		public const string kConsonant = "C";
		public const string kVowel = "V";
		public const string kTone = "T";
        public const string kSyllograph = "S";
		public const string kUnknown = "?";

		private const string cBilabial = "bilabial";
		private const string cLabiodental = "labiodental";
		private const string cDental = "dental";
		private const string cAlveolar = "alveolar";
		private const string cPostalveolar = "postalveolar";
		private const string cRetroflex = "retroflex";
		private const string cPalatal = "palatal";
		private const string cVelar = "velar";
		private const string cLabialvelar = "labialvelar";
		private const string cUvular = "uvular";
		private const string cPharyngeal = "pharyngeal";
		private const string cGlottal = "glottal";
 
		private const string cPlosive = "plosive";
		private const string cNasalC = "nasal";
		private const string cTrill = "trill";
		private const string cFlap = "flap";
		private const string cFricative = "fricative";
		private const string cAffricate = "affricate";
		private const string cLateral = "lateral";
		private const string cApprox = "approximant";
		private const string cLateralApprox = "lateralapproximant";
		private const string cClick = "click";
		private const string cImplosive = "implosive";
		private const string cEjective = "ejective";

		private const string cVoiced = "voiced";
		private const string cPrenasalized = "prenasalized";
		private const string cLabialized = "labialized";
		private const string cPalatalized = "palatalized";
		private const string cVelarized = "velarized";
		private const string cSyllabic = "syllabic";
        private const string cAspirated = "aspirated";
        //private const string cLong = "long";  //already defined in vowel section
        private const string cGlottalized = "glottalized";
        private const string cCombination = "combination";

		public const string cFront = "front";
		public const string cCentral = "central";
		public const string cBack = "back";
		public const string cHigh = "high";
		public const string cMid = "mid";
		public const string cLow = "low";
		public const string cRound = "round";
		public const string cPlusATR = "+atr";
		public const string cLong = "long";
        public const string cNasalV = "nasal";
        public const string cDiphthong = "diphthong";
        public const string cVoiceless = "voiceless";

        private const int nCountMaxWidth = 6;
        private const string cPercent = "%";
        private const string cOpenParen = "(";
        private const string cCloseParen = ")";
        
		public GraphemeInventory(Settings s)
		{
			m_Settings = s;
			m_FileName = "";
			m_Consonants = new ArrayList();
            m_Vowels = new ArrayList();
            m_Tones = new ArrayList();
            m_Syllographs = new ArrayList();
            m_MaxGraphemeSize = m_Settings.OptionSettings.MaxSizeGrapheme;
		}

		public string FileName
		{
			get {return m_FileName;}
			set {m_FileName = value;}
		}

		public int MaxGraphemeSize
        {
            get { return m_MaxGraphemeSize; }
            set { m_MaxGraphemeSize = value; }
        }
        
        private Consonant SetFeature(Consonant cns, string strFeature)
		{
			switch (strFeature)
			{
				case cBilabial:
					cns.IsBilabial = true;
					break;
				case cLabiodental:
					cns.IsLabiodental = true;
					break;
				case cDental:
					cns.IsDental = true;
					break;
				case cAlveolar:
					cns.IsAlveolar = true;
					break;
				case cPostalveolar:
					cns.IsPostalveolar = true;
					break;
				case cRetroflex:
					cns.IsRetroflex = true;
					break;
				case cPalatal:
					cns.IsPalatal = true;
					break;
				case cVelar:
					cns.IsVelar = true;
					break;
				case cLabialvelar:
					cns.IsLabialvelar = true;
					break;
				case cUvular:
					cns.IsUvular = true;
					break;
				case cPharyngeal:
					cns.IsPharyngeal = true;
					break;
				case cGlottal:
					cns.IsGlottal = true;
					break;
				case cPlosive:
					cns.IsPlosive = true;
					break;
				case cNasalC:
					cns.IsNasal = true;
					break;
				case cTrill:
					cns.IsTrill = true;
					break;
				case cFlap:
					cns.IsFlap= true;
					break;
				case cFricative:
					cns.IsFricative = true;
					break;
				case cAffricate:
					cns.IsAffricate = true;
					break;
				case cLateral:
					cns.IsLateralFric = true;
					break;
				case cApprox:
					cns.IsApproximant = true;
					break;
				case cLateralApprox:
					cns.IsLateralAppr = true;
					break;
				case cImplosive:
					cns.IsImplosive = true;
					break;
				case cEjective:
					cns.IsEjective = true;
					break;
				case cClick:
					cns.IsClick = true;
					break;
				case cVoiced:
					cns.IsVoiced = true;
					break;
				case cPrenasalized:
					cns.IsPrenasalized = true;
					break;
				case cLabialized:
					cns.IsLabialized = true;
					break;
				case cPalatalized:
					cns.IsPalatalized = true;
					break;
				case cVelarized:
					cns.IsVelarized = true;
					break;
				case cSyllabic:
					cns.IsSyllabic = true;
                    cns.IsSyllabicConsonant = cns.IsSyllabic;
					break;
                case cAspirated:
                    cns.IsAspirated = true;
                    break;
                case cLong:
                    cns.IsLong = true;
                    break;
                case cGlottalized:
                    cns.IsGlottalized = true;
                    break;
                case cCombination:
                    cns.IsComplex = true;
                    break;
            }
			return cns;
		}

		private Vowel SetFeature(Vowel vwl, string strFeature)
		{
			switch (strFeature)
			{
				case cFront:
					vwl.IsFront = true;
					break;
				case cCentral:
					vwl.IsCentral = true;
					break;
				case cBack:
					vwl.IsBack = true;
					break;
				case cHigh:
					vwl.IsHigh = true;
					break;
				case cMid:
					vwl.IsMid = true;
					break;
				case cLow:
					vwl.IsLow = true;
					break;
				case cRound:
					vwl.IsRound = true;
					break;
				case cPlusATR:
					vwl.IsPlusATR = true;
					break;
				case cLong:
					vwl.IsLong = true;
					break;
				case cNasalV:
					vwl.IsNasal = true;
					break;
                case cVoiceless:
                    vwl.IsVoiceless = true;
                    break;
                case cDiphthong:
                    vwl.IsComplex = true;
                    break;
            }
			return vwl;
		}

		private Tone SetLevel(Tone tone, string strLevel)
		{
			tone.Level = strLevel;
			return tone;
		}

        private Tone SetTBU(Tone tone, Grapheme seg)
		{
			tone.ToneBearingUnit = seg;
			return tone;
		}

        private Syllograph SetInitialOnset(Syllograph syllograph, string cns)
        {
            syllograph.CategoryPrimary = cns;
            return syllograph;
        }

        private Syllograph SetMedialNucleus(Syllograph syllograph, string vwl)
        {
            syllograph.CategorySecondary = vwl;
            return syllograph;
        }

        private Syllograph SetFinalCoda(Syllograph syllograph, string cns)
        {
            syllograph.CategoryTertiary = cns;
            return syllograph;
        }
    
        public bool InitializeGraphemeInventoryFromPredefinedGraphemes(string strFileName)
        {
            bool fReturn = true;
            int nFormWidth = 800;
            int nFormHeight = 500;
            int nChkWidth = 60;
            int nChkHeight = 24;

            //Setup form
            FormEmpty form = new FormEmpty();
            form.Height = nFormHeight;
            form.Width = nFormWidth;
            //form.Text = "Initialize Grapheme Inventory";
            form.Text = m_Settings.LocalizationTable.GetMessage("GraphemeInventory1",
                m_Settings.OptionSettings.UILanguage);
            form.StartPosition = FormStartPosition.CenterParent;
            form.buttonOk.Location = new Point(nFormWidth - 240, nFormHeight - 80);
            form.buttonCancel.Location = new Point(nFormWidth - 140, nFormHeight - 80);
            if (m_Settings.OptionSettings.UILanguage == OptionList.kFrench)
                form.buttonCancel.Text = "Annuler";                      
            //Load default grapheme inventory
            GraphemeInventory dgi = new GraphemeInventory(m_Settings);
            dgi.LoadFromFile(strFileName);
            
            int x = 20; int y = 20;     //Starting location

            // Add consonants to form
            Label lblCns = new Label();
            //lblCns.Text = "Check the Consonants you want to include in the grapheme inventory:";
            lblCns.Text = m_Settings.LocalizationTable.GetMessage("GraphemeInventory2",
                    m_Settings.OptionSettings.UILanguage);
            lblCns.Size = new Size(nFormWidth - 100, 24);
            lblCns.Location = new Point(x, y);
            lblCns.ForeColor = Color.DarkGreen;
            form.Controls.Add(lblCns);

            y = y + nChkHeight + 6;
            CheckBox chkCns = null;
            for (int i = 0; i < dgi.ConsonantCount(); i++)
            {
                chkCns = new CheckBox();
                chkCns.Text = dgi.GetConsonant(i).Symbol;
                chkCns.Size = new Size(nChkWidth, nChkHeight);
                chkCns.Location = new Point(x, y);
                form.Controls.Add(chkCns);
                x = x + nChkWidth + 10;
                if (x > (nFormWidth - nChkWidth - 10))
                {
                    x = 20;
                    y = y + nChkHeight + 6;
                }
            }

            // Add vowels to form
            Label lblVwl = new Label();
            x = 20; y = y + nChkHeight + 16;
            //lblVwl.Text = "Check the vowels you want to include in the grapheme inventory:";
            lblVwl.Text = m_Settings.LocalizationTable.GetMessage("GraphemeInventory3",
                m_Settings.OptionSettings.UILanguage);
            lblVwl.Size = new Size(nFormWidth - 100, 24);
            lblVwl.Location = new Point(x, y);
            lblVwl.ForeColor = Color.DarkGreen;
            form.Controls.Add(lblVwl);

            y = y + nChkHeight + 6;
            CheckBox chkVwl = null;
            for (int i = 0; i < dgi.VowelCount(); i++)
            {
                chkVwl = new CheckBox();
                chkVwl.Text = dgi.GetVowel(i).Symbol;
                chkVwl.Size = new Size(nChkWidth, nChkHeight);
                chkVwl.Location = new Point(x, y);
                form.Controls.Add(chkVwl);
                x = x + nChkWidth + 10;
                if (x > (nFormWidth - nChkWidth - 10))
                {
                    x = 20;
                    y = y + nChkHeight + 6;
                }
            }

            //Show form
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                //Process each checked grapheme
                Consonant cns = null;
                Vowel vwl = null;
                string strSymbol = "";
                int ndx = 0;
                foreach (Control cntl in form.Controls)
                {
                    AccessibleObject obj = cntl.AccessibilityObject;
                    if (obj.Role == AccessibleRole.CheckButton)
                    {
                        string strStates = obj.State.ToString();
                        if (strStates.Contains(AccessibleStates.Checked.ToString()))
                        {
                            strSymbol = cntl.AccessibilityObject.Name;
                            ndx = dgi.FindConsonantIndex(strSymbol);
                            if (ndx >= 0)
                            {
                                cns = dgi.GetConsonant(ndx);
                                if (this.FindConsonantIndex(strSymbol) < 0)
                                    this.AddConsonant(cns);
                            }

                            ndx = dgi.FindVowelIndex(strSymbol);
                            if (ndx >= 0)
                            {
                                vwl = dgi.GetVowel(ndx);
                                if (this.FindVowelIndex(strSymbol) < 0)
                                    this.AddVowel(vwl);
                            }
                        }
                    }
                }
            }
            else
            {
                //MessageBox.Show("Grapheme Inventory not initialized");
                fReturn = false;
            }
            return fReturn;
        }
     
        public GraphemeInventory InitializeSyllabaryInventory(TextData td)
        {
            GraphemeInventory gi = new GraphemeInventory(m_Settings);
            if (td != null)
            {
                gi = td.BuildSyllabaryInventory();
            }
            return gi;
        }

        public bool LoadFromFile(string strFileName)
        {
            bool flag = false;
            m_Consonants = new ArrayList();
            m_Vowels = new ArrayList();
            m_Tones = new ArrayList();
            m_Syllographs = new ArrayList();
            if (File.Exists(strFileName))
            {
                XmlTextReader reader = null;
                try
                {
                    // Load the reader with the data file and ignore all white space nodes.         
                    reader = new XmlTextReader(strFileName);
                    reader.WhitespaceHandling = WhitespaceHandling.None;

                    // Parse the file
                    Consonant cns = null;
                    Vowel vwl = null;
                    Tone tone = null;
                    Syllograph syllograph = null;
                    string strElement = "";
                    string strSymbol = "";
                    string strUpper = "";
                    string strType = "";
                    bool fCombination = false;
                    bool fDiphthong = false;
                    //bool fSyllograph = false;

                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                strElement = reader.Name;
                                if ((strElement == GraphemeInventory.cTagGrf)
                                    && (reader.AttributeCount > 1))
                                {
                                    strSymbol = reader.GetAttribute(GraphemeInventory.cTagSym);
                                    if ((strSymbol != null) && (strSymbol != ""))
                                    {
                                        strUpper = reader.GetAttribute(GraphemeInventory.cTagUpp);
                                        if (strUpper == null) strUpper = "";
                                        strType = reader.GetAttribute(GraphemeInventory.cTagTyp);
                                        if (strType == "") strType = GraphemeInventory.kConsonant;

                                        if (strType == GraphemeInventory.kConsonant)
                                        {
                                            cns = new Consonant(strSymbol);
                                            cns.UpperCase = strUpper;
                                            m_Consonants.Add(cns);
                                        }
                                        if (strType == GraphemeInventory.kVowel)
                                        {
                                            vwl = new Vowel(strSymbol);
                                            vwl.UpperCase = strUpper;
                                            m_Vowels.Add(vwl);
                                        }
                                        if (strType == GraphemeInventory.kTone)
                                        {
                                            tone = new Tone(strSymbol);
                                            tone.UpperCase = strUpper;
                                            m_Tones.Add(tone);
                                        }
                                        if (strType == GraphemeInventory.kSyllograph)
                                        {
                                            syllograph = new Syllograph(strSymbol);
                                            syllograph.UpperCase = strUpper;
                                            m_Syllographs.Add(syllograph);
                                        }
                                    }
                                }
                                if (strElement == GraphemeInventory.cTagCombination)
                                {
                                    fCombination = true;
                                    cns.IsComplex = true;
                                }
                                if (strElement == GraphemeInventory.cTagDiphthong)
                                {
                                    fDiphthong = true;
                                    vwl.IsComplex = true;
                                }
                                break;
                            case XmlNodeType.Text:
                                if (strElement == GraphemeInventory.cTagFeature)
                                {
                                    if ((strType == GraphemeInventory.kConsonant) && (cns != null))
                                        cns = SetFeature(cns, reader.Value);
                                    if ((strType == GraphemeInventory.kVowel) && (vwl != null))
                                        vwl = SetFeature(vwl, reader.Value);
                                }
                                if (strElement == GraphemeInventory.cTagSym)
                                {
                                    if (fCombination)
                                    {
                                        if ((strType == GraphemeInventory.kConsonant)  && (cns != null))
                                            cns.AddComplexComponent(reader.Value);
                                    }
                                    if (fDiphthong)
                                    {
                                        if ((strType == GraphemeInventory.kVowel) && (vwl != null))
                                            vwl.AddComplexComponent(reader.Value);
                                    }
                                }
                                if (strElement == GraphemeInventory.cTagLevel)
                                    tone.Level = reader.Value;
                                if (strElement == GraphemeInventory.cTagTBU)
                                    tone.ToneBearingUnit = this.GetGrapheme(reader.Value);
                                if (strElement == GraphemeInventory.cTagInitial)
                                    syllograph.CategoryPrimary = reader.Value;
                                if (strElement == GraphemeInventory.cTagMedial)
                                    syllograph.CategorySecondary = reader.Value;
                                if (strElement == GraphemeInventory.cTagFinal)
                                    syllograph.CategoryTertiary = reader.Value;
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
                                if (strElement == GraphemeInventory.cTagCombination)
                                    fCombination = false;
                                if (strElement ==  GraphemeInventory.cTagDiphthong)
                                    fDiphthong = false;
                                break;
                        }
                    }
                    flag = true;
                }

                catch
                {
                    flag = false;
                }

                finally
                {
                    if (reader != null)
                    {
                        m_FileName = strFileName;
                        reader.Close();
                    }
                }
            }
            return flag;
        }

        public void SaveToFile(string strFileName)
		{
            string strPath = "";
            if (m_Settings.OptionSettings.GraphemeInventoryFile != "")
            {
                m_FileName = strFileName;
                strPath = Funct.GetFolder(m_FileName);
                if (!Directory.Exists(strPath))
                {
                    m_FileName = m_Settings.PrimerProFolder + Constants.Backslash
                        + Funct.ShortFileNameWithExt(m_FileName);
                    m_Settings.OptionSettings.GraphemeInventoryFile = m_FileName;
                }
                if (!File.Exists(m_FileName))
                {
                    StreamWriter sw = File.CreateText(m_FileName);
                    sw.Close();
                }
                XmlTextWriter writer = new XmlTextWriter(m_FileName, System.Text.Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartElement(cTagGrfInvent);
                Consonant cns = null;
                Vowel vwl = null;
                Tone tone = null;
                Syllograph syllograph = null;
                
                if (m_Consonants != null)
                {
                    for (int i = 0; i < m_Consonants.Count; i++)
                    {
                        cns = (Consonant)m_Consonants[i];
                        if (cns.Symbol.Trim() != "")
                        {
                            writer.WriteStartElement(cTagGrf);
                            writer.WriteAttributeString(cTagSym, cns.Symbol.Trim());
                            writer.WriteAttributeString(cTagUpp, cns.UpperCase.Trim());
                            writer.WriteAttributeString(cTagTyp, GraphemeInventory.kConsonant);
                            if (cns.IsComplex)
                                writer = WriteCombinationSymbols(writer, cns);
                            else
                            {
                                writer.WriteStartElement(cTagFeatures);
                                writer = WriteConsonantFeatures(writer, cns);
                                writer.WriteEndElement();   //end cTagFeatures
                            }
                            writer.WriteEndElement();       //end cTagGrf
                        }
                    }
                }

                if (m_Vowels != null)
                {
                    for (int i = 0; i < m_Vowels.Count; i++)
                    {
                        vwl = (Vowel)m_Vowels[i];
                        if (vwl.Symbol.Trim() != "")
                        {
                            writer.WriteStartElement(cTagGrf);
                            writer.WriteAttributeString(cTagSym, vwl.Symbol.Trim());
                            writer.WriteAttributeString(cTagUpp, vwl.UpperCase.Trim());
                            writer.WriteAttributeString(cTagTyp, GraphemeInventory.kVowel);
                            if (vwl.IsComplex)
                                writer = WriteDiphthongSymbols(writer, vwl);
                            else
                            {
                                writer.WriteStartElement(cTagFeatures);
                                writer = WriteVowelFeatures(writer, vwl);
                                writer.WriteEndElement();   //end cTagFeatures
                            }
                            writer.WriteEndElement();       //end CTagGrf
                        }
                    }
                }

                if (m_Tones != null)
                {
                    for (int i = 0; i < m_Tones.Count; i++)
                    {
                        tone = (Tone)m_Tones[i];
                        if (tone.Symbol.Trim() != "")
                        {
                            writer.WriteStartElement(cTagGrf);
                            writer.WriteAttributeString(cTagSym, tone.Symbol.Trim());
                            writer.WriteAttributeString(cTagUpp, tone.UpperCase.Trim());
                            writer.WriteAttributeString(cTagTyp, GraphemeInventory.kTone);
                            if (tone.Level != "")
                                writer.WriteElementString(GraphemeInventory.cTagLevel, tone.Level);
                            if (tone.ToneBearingUnit != null)
                                writer.WriteElementString(GraphemeInventory.cTagTBU, tone.ToneBearingUnit.Symbol);
                            writer.WriteEndElement();   //end cTagGrf
                        }
                    }
                }
                
                if (m_Syllographs != null)
                {
                    for (int i = 0; i < m_Syllographs.Count; i++)
                    {
                        syllograph = (Syllograph)m_Syllographs[i];
                        if (syllograph.Symbol.Trim() != "")
                        {
                            writer.WriteStartElement(cTagGrf);
                            writer.WriteAttributeString(cTagSym, syllograph.Symbol.Trim());
                            writer.WriteAttributeString(cTagUpp, syllograph.UpperCase.Trim());
                            writer.WriteAttributeString(cTagTyp, GraphemeInventory.kSyllograph);
                            if (syllograph.CategoryPrimary != "")
                                writer.WriteElementString(GraphemeInventory.cTagInitial,
                                    syllograph.CategoryPrimary);
                            if (syllograph.CategorySecondary != "")
                                writer.WriteElementString(GraphemeInventory.cTagMedial,
                                    syllograph.CategorySecondary);
                            if (syllograph.CategoryTertiary != "")
                                writer.WriteElementString(GraphemeInventory.cTagFinal,
                                    syllograph.CategoryTertiary);
                            writer.WriteEndElement();   //end cTagGrf
                        }
                    }
                }

                writer.WriteEndElement();  //end cTagGrfInvent
                writer.Close();
            }
            //else MessageBox.Show("Inventory file not specified");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("GraphemeInventory4",
                m_Settings.OptionSettings.UILanguage));
        }

		private XmlTextWriter WriteConsonantFeatures(XmlTextWriter writer, Consonant cns)
		{
			if ( cns.IsBilabial )
				writer.WriteElementString(cTagFeature, cBilabial);
			if ( cns.IsLabiodental )
				writer.WriteElementString(cTagFeature, cLabiodental);
			if ( cns.IsDental )
				writer.WriteElementString(cTagFeature, cDental);
			if ( cns.IsAlveolar )
				writer.WriteElementString(cTagFeature, cAlveolar);
			if ( cns.IsPostalveolar )
				writer.WriteElementString(cTagFeature, cPostalveolar);
			if ( cns.IsRetroflex )
				writer.WriteElementString(cTagFeature, cRetroflex);
			if ( cns.IsPalatal )
				writer.WriteElementString(cTagFeature, cPalatal);
			if ( cns.IsVelar )
				writer.WriteElementString(cTagFeature, cVelar);
			if ( cns.IsLabialvelar )
				writer.WriteElementString(cTagFeature, cLabialvelar);
			if ( cns.IsUvular )
				writer.WriteElementString(cTagFeature, cUvular);
			if ( cns.IsPharyngeal )
				writer.WriteElementString(cTagFeature, cPharyngeal);
			if ( cns.IsGlottal )
				writer.WriteElementString(cTagFeature, cGlottal);
			if ( cns.IsPlosive )
				writer.WriteElementString(cTagFeature, cPlosive);
			if ( cns.IsNasal )
				writer.WriteElementString(cTagFeature, cNasalC);
			if ( cns.IsTrill )
				writer.WriteElementString(cTagFeature, cTrill);
			if ( cns.IsFlap )
				writer.WriteElementString(cTagFeature, cFlap);
			if ( cns.IsFricative )
				writer.WriteElementString(cTagFeature, cFricative);
			if ( cns.IsAffricate )
				writer.WriteElementString(cTagFeature, cAffricate);
			if ( cns.IsLateralFric )
				writer.WriteElementString(cTagFeature, cLateral);
			if ( cns.IsApproximant )
				writer.WriteElementString(cTagFeature, cApprox);
			if ( cns.IsLateralAppr )
				writer.WriteElementString(cTagFeature, cLateralApprox);
			if ( cns.IsImplosive )
				writer.WriteElementString(cTagFeature, cImplosive);
			if ( cns.IsEjective )
				writer.WriteElementString(cTagFeature, cEjective);
			if ( cns.IsClick)
				writer.WriteElementString(cTagFeature, cClick);
			if ( cns.IsVoiced )
				writer.WriteElementString(cTagFeature, cVoiced);
			if ( cns.IsPrenasalized )
				writer.WriteElementString(cTagFeature, cPrenasalized);
			if ( cns.IsLabialized )
				writer.WriteElementString(cTagFeature, cLabialized);
			if ( cns.IsPalatalized )
				writer.WriteElementString(cTagFeature, cPalatalized);
			if ( cns.IsVelarized )
				writer.WriteElementString(cTagFeature, cVelarized);
            if (cns.IsAspirated)
                writer.WriteElementString(cTagFeature, cAspirated);
            if (cns.IsSyllabic)
                writer.WriteElementString(cTagFeature, cSyllabic);
            if (cns.IsLong)
                writer.WriteElementString(cTagFeature, cLong);
            if (cns.IsGlottalized)
                writer.WriteElementString(cTagFeature, cGlottalized);
			return writer;
		}

        private XmlTextWriter WriteCombinationSymbols(XmlTextWriter writer, Consonant cns)
        {
            if (cns.ComplexComponents != null)
            {
                writer.WriteStartElement(cTagCombination);
                for (int i = 0; i < cns.ComplexComponents.Count; i++)
                {
                    string str = cns.GetComplexComponent(i);
                    writer.WriteElementString(cTagSym, str);
                }
                writer.WriteEndElement();   //end cTagCombination
            }
            return writer;
        }

		private XmlTextWriter WriteVowelFeatures(XmlTextWriter writer, Vowel vwl)
		{
			if ( vwl.IsFront )
				writer.WriteElementString(cTagFeature, cFront);
			if ( vwl.IsCentral)
				writer.WriteElementString(cTagFeature, cCentral);
			if ( vwl.IsBack )
				writer.WriteElementString(cTagFeature, cBack);
			if ( vwl.IsHigh )
				writer.WriteElementString(cTagFeature, cHigh);
			if ( vwl.IsMid )
				writer.WriteElementString(cTagFeature, cMid);
			if ( vwl.IsLow )
				writer.WriteElementString(cTagFeature, cLow);
			if ( vwl.IsRound)
				writer.WriteElementString(cTagFeature, cRound);
			if ( vwl.IsPlusATR )
				writer.WriteElementString(cTagFeature, cPlusATR );
			if ( vwl.IsLong )
				writer.WriteElementString(cTagFeature, cLong);
			if ( vwl.IsNasal )
				writer.WriteElementString(cTagFeature, cNasalV);
            if ( vwl.IsVoiceless )
                writer.WriteElementString(cTagFeature, cVoiceless);
            if (vwl.IsComplex)
                writer.WriteElementString(cTagFeature, cDiphthong);
            return writer;
		}

        private XmlTextWriter WriteDiphthongSymbols(XmlTextWriter writer, Vowel vwl)
        {
            if (vwl.ComplexComponents != null)
            {
                writer.WriteStartElement(cTagDiphthong);
                for (int i = 0; i < vwl.ComplexComponents.Count; i++)
                {
                    string str = vwl.GetComplexComponent(i);
                    writer.WriteElementString(cTagSym, str);
                }
                writer.WriteEndElement();   //endCTagDiphthong
            }
            return writer;
        }

        public string RetrieveConsonants()
		{
			Consonant cns = null;
			string strText = "";
            //int nWidth = Grapheme.this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
            int nWidth = this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
			char chSpace = Constants.Space;

			if ( this != null)
			{
				for (int i = 0; i < this.ConsonantCount(); i++)
				{
					cns = (Consonant) m_Consonants[i];
					if (cns.Symbol.Trim() != "")
                        strText += cns.Symbol.PadRight(nWidth,chSpace);
				}
				strText += Environment.NewLine;
			}
            //else MessageBox.Show("Grapheme Inventory is missing");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("GraphemeInventory5",
                m_Settings.OptionSettings.UILanguage));
            return strText;
		}

		public string RetrieveSortedConsonants()
		{
			Consonant cns = null;
			string strCns = "";
			string strText = "";
			SortedList sl = new SortedList();
            int nWidth = this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
			char chSpace = Constants.Space;
            string strKey = "";
            char[] aChar;

			if ( this != null )
			{
				for (int i = 0; i < this.ConsonantCount(); i++)
				{
					cns = (Consonant) m_Consonants[i];
                    if (cns.Symbol.Trim() != "")
                    {
                        strCns = cns.Symbol.PadRight(nWidth, chSpace);
                        strKey = "";
                        aChar = cns.Symbol.ToCharArray();
                        foreach (char ch in aChar)
                            strKey = strKey + Convert.ToInt32(ch).ToString().PadLeft(6,'0');
                        if (sl.IndexOfKey(strKey) < 0)
                            sl.Add(strKey, strCns);
                        else sl.Add(strKey + "X", strCns);
                    }
				}
				for (int i = 0; i < sl.Count; i++)
				{
					strText += sl.GetByIndex(i);
				}
				strText += Environment.NewLine;
			}
            //else MessageBox.Show("Grapheme Inventory is missing");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("GraphemeInventory5",
                m_Settings.OptionSettings.UILanguage));
            return strText;
		}

        public void InitConsonantList(ArrayList alConsonants)
        {
            m_Consonants = alConsonants;
        }

        public void AddConsonant(Consonant cns)
		{
            if (m_Consonants == null)
                m_Consonants = new ArrayList();
			m_Consonants.Add(cns);
		}

		public void DelConsonant(int n)
		{
            if ( (this.ConsonantCount() > 0) && (n < this.ConsonantCount()) )
			    m_Consonants.RemoveAt(n);
		}

		public void UpdConsonant(int n, Consonant cns)
		{
			m_Consonants[n] = cns;
		}
		
		public Consonant GetConsonant(int n)
		{
            if (n < 0)
                return null;
			if (m_Consonants == null)
				return null;
			if (m_Consonants.Count > 0)
				return (Consonant) m_Consonants[n];
			return null;
		}

		public int FindConsonantIndex(string strSymbol)
		// returns index number of specified consonant symbol
		{
			Consonant cns =  null;
			int n = -1;
			for ( int i = 0; i < ConsonantCount(); i++ )
			{
				cns = (Consonant) m_Consonants[i];
				if ( (cns.Symbol == strSymbol)  || (cns.UpperCase == strSymbol) )
				{
					n = i;
					break;
				}
			}
			return n;
		}

		public int ConsonantCount()
		{
			if (m_Consonants == null)
				return 0;
			else return m_Consonants.Count;
		}

		public string RetrieveVowels()
		{
			Vowel vwl = null;
			string strText = "";
            int nWidth = this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
			char chSpace = Constants.Space;

			if ( this != null )
			{
				for (int i = 0; i < this.VowelCount(); i++)
				{
					vwl = (Vowel) m_Vowels[i];
                    if (vwl.Symbol.Trim() != "")
					    strText += vwl.Symbol.PadRight(nWidth,chSpace);
				}
				strText += Environment.NewLine;
			}
            //else MessageBox.Show("Grapheme Inventory is missing");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("GraphemeInventory5",
                m_Settings.OptionSettings.UILanguage));
            return strText;
		}

		public string RetrieveSortedVowels()
		{
			Vowel vwl = null;
			string strText = "";
			string strVwl = "";
			SortedList sl = new SortedList();
            int nWidth = this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
			char chSpace = Constants.Space;
            string strKey = "";
            char [] aChar;

			if ( this != null )
			{
				for (int i = 0; i < this.VowelCount(); i++)
				{
					vwl = (Vowel) m_Vowels[i];
                    if (vwl.Symbol.Trim() != "")
                    {
                        strVwl = vwl.Symbol.PadRight(nWidth, chSpace);
                        strKey = "";
                        aChar = vwl.Symbol.ToCharArray();
                        foreach (char ch in aChar)
                            strKey = strKey + Convert.ToInt32(ch).ToString().PadLeft(6,'0');
                        if (sl.IndexOfKey(strKey) < 0)
                            sl.Add(strKey, strVwl);
                        else sl.Add(strKey  + "X", strVwl);
                    }
				}
				for (int i = 0; i < sl.Count; i++)
				{
					strText += sl.GetByIndex(i);
				}
				strText += Environment.NewLine;
			}
            //else MessageBox.Show("Grapheme Inventory is missing");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("GraphemeInventory5",
                m_Settings.OptionSettings.UILanguage));
            return strText;
		}

        public void InitVowelList(ArrayList alVowels)
        {
            m_Vowels = alVowels;
        }

        public void AddVowel(Vowel vwl)
		{
            if (m_Vowels == null)
                m_Vowels = new ArrayList();
			m_Vowels.Add(vwl);
		}

		public void DelVowel(int n)
		{
            if ( (this.VowelCount() > 0) && (n < this.VowelCount()) )
                m_Vowels.RemoveAt(n);
		}

		public void UpdVowel(int n, Vowel vwl)
		{
			m_Vowels[n] = vwl;
		}

		public Vowel GetVowel(int n)
		{
            if (n < 0)
                return null;
			if (m_Vowels == null)
				return null;
			if ( (0 < m_Vowels.Count) && (n <  m_Vowels.Count) )
				return (Vowel) m_Vowels[n];
			return null;
		}
		
		public int FindVowelIndex(string strSymbol)
		// returns index number of specified vowel symbol
		{
			Vowel vwl =  null;
			int n = -1;
			for ( int i = 0; i < VowelCount(); i++ )
			{
				vwl = (Vowel) m_Vowels[i];
				if ( (vwl.Symbol == strSymbol ) || (vwl.UpperCase == strSymbol) )
				{
					n = i;
					break;
				}
			}
			return n;
		}

		public int VowelCount()
		{
			if (m_Vowels == null)
				return 0;
			else return m_Vowels.Count;
		}

		public string RetrieveTones()
		{
			Tone tone = null;
			string strText = "";
            int nWidth = this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
			char chSpace = Constants.Space;

			if ( this != null)
			{
				for (int i = 0; i < ToneCount(); i++)
				{
					tone = (Tone) m_Tones[i];
                    if (tone.Symbol.Trim() != "")
					    strText += tone.Symbol.PadRight(nWidth,chSpace);
				}
				strText += Environment.NewLine;
			}
            //else MessageBox.Show("Grapheme Inventory is missing");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("GraphemeInventory5",
                m_Settings.OptionSettings.UILanguage));
            return strText;
		}

		public string RetrieveSortedTones()
		{
			Tone tone = null;
			string strText = "";
			string strTone = "";
			SortedList sl = new SortedList();
            int nWidth = this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
			char chSpace = Constants.Space;
            string strKey = "";
            char[] aChar;

			if ( this != null)
			{
				for (int i = 0; i < this.ToneCount(); i++)
				{
					tone = (Tone) m_Tones[i];
                    if (tone.Symbol.Trim() != "")
                    {
                        strTone = tone.Symbol.PadRight(nWidth, chSpace);
                        strKey = "";
                        aChar = tone.Symbol.ToCharArray();
                        foreach (char ch in aChar)
                            strKey = strKey + Convert.ToInt32(ch).ToString().PadLeft(6,'0');
                        if (sl.IndexOfKey(strKey) < 0)
                            sl.Add(strKey, strTone);
                        else sl.Add(strKey + "X", strTone);
                    }
				}
				for (int i = 0; i < sl.Count; i++)
				{
					strText += sl.GetByIndex(i);
				}
				strText += Environment.NewLine;
			}
            //else MessageBox.Show("Grapheme Inventory is missing");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("GraphemeInventory5",
                m_Settings.OptionSettings.UILanguage));
            return strText;
		}

        public void InitToneList(ArrayList alTones)
        {
            m_Tones = alTones;
        }

        public void AddTone(Tone tone)
		{
			if (m_Tones == null)
				m_Tones = new ArrayList();
			m_Tones.Add(tone);
		}

		public void DelTone(int n)
		{
            if ( (this.ToneCount() > 0) && (n < this.ToneCount()) )
			    m_Tones.RemoveAt(n);
            return;
		}

		public void UpdTone(int n, Tone tone)
		{
			m_Tones[n] = tone;
		}

		public Tone GetTone(int n)
		{
            if (n < 0)
                return null;
			if (m_Tones == null)
				return null;
			if (m_Tones.Count > 0)
				return (Tone) m_Tones[n];
			return null;
		}
		
		public int FindToneIndex(string strSymbol)
		// returns index number of specified vowel symbol
		{
			Tone tone =  null;
			int n = -1;
			for ( int i = 0; i < ToneCount(); i++ )
			{
				tone = (Tone) m_Tones[i];
				if ( (tone.Symbol == strSymbol) || (tone.UpperCase == strSymbol) )				{
					n = i;
					break;
				}
			}
			return n;
		}

		public int ToneCount()
		{
			if (m_Tones == null)
				return 0;
			else return m_Tones.Count;
		}

        public string RetrieveSyllographs()
        {
            Syllograph syllograph = null;
            string strText = "";
            int nWidth = this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
            char chSpace = Constants.Space;

            if (this != null)
            {
                for (int i = 0; i < this.SyllographCount(); i++)
                {
                    syllograph = (Syllograph)m_Syllographs[i];
                    if (syllograph.Symbol.Trim() != "")
                        strText += syllograph.Symbol.PadRight(nWidth, chSpace);
                }
                strText += Environment.NewLine;
            }
            //else MessageBox.Show("Grapheme Inventory is missing");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("GraphemeInventory5",
                m_Settings.OptionSettings.UILanguage));
            return strText;
        }

        public string RetrieveSortedSyllographs()
        {
            Syllograph syllograph = null;
            string strSyllograph = "";
            string strText = "";
            SortedList sl = new SortedList(StringComparer.OrdinalIgnoreCase);
            int nWidth = this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
            char chSpace = Constants.Space;
            string strKey = "";
            char[] aChar;

            if (this != null)
            {
                for (int i = 0; i < this.SyllographCount(); i++)
                {
                    syllograph = (Syllograph)m_Syllographs[i];
                    if (syllograph.Symbol.Trim() != "")
                    {
                        strSyllograph = syllograph.Symbol.PadRight(nWidth, chSpace);
                        strKey = "";
                        aChar = syllograph.Symbol.ToCharArray();
                        foreach (char ch in aChar)
                            strKey = strKey + Convert.ToInt32(ch).ToString().PadLeft(6, '0');
                        if (sl.IndexOfKey(strKey) < 0)
                            sl.Add(strKey, strSyllograph);
                        else sl.Add(strKey + "X", strSyllograph);
                    }
                }
                for (int i = 0; i < sl.Count; i++)
                {
                    strText += sl.GetByIndex(i);
                }
                strText += Environment.NewLine;
            }
            //else MessageBox.Show("Grapheme Inventory is missing");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("GraphemeInventory5",
                m_Settings.OptionSettings.UILanguage));
            return strText;
        }

        public void AddSyllograph(Syllograph syllograph)
        {
            if (m_Syllographs == null)
                m_Syllographs = new ArrayList();
            m_Syllographs.Add(syllograph);
        }

        public void DelSyllograph(int n)
        {
            if ((this.SyllographCount() > 0) && (n < this.SyllographCount()))
                m_Syllographs.RemoveAt(n);
        }

        public void UpdSyllograph(int n, Syllograph syllograph)
        {
            m_Syllographs[n] = syllograph;
        }

        public Syllograph GetSyllograph(int n)
        {
            if (n < 0)
                return null;
            if (m_Syllographs == null)
                return null;
            if (m_Syllographs.Count > 0)
                return (Syllograph)m_Syllographs[n];
            return null;
        }

        public int FindSyllographIndex(string strSymbol)
        // returns index number of specified syllograph symbol
        {
            Syllograph syllograph = null;
            int n = -1;
            for (int i = 0; i < SyllographCount(); i++)
            {
                syllograph = (Syllograph)m_Syllographs[i];
                if ((syllograph.Symbol == strSymbol) || (syllograph.UpperCase == strSymbol))
                {
                    n = i;
                    break;
                }
            }
            return n;
        }

        public int SyllographCount()
        {
            if (m_Syllographs == null)
                return 0;
            else return m_Syllographs.Count;
        }

        public int GraphemeCount()
        {
            int n = 0;
            n = n + ConsonantCount() + VowelCount() + ToneCount() + SyllographCount();
            return n;
        }

        public bool IsInInventory(string strGrapheme)
		{
			bool flag = false;
            if (FindConsonantIndex(strGrapheme) >= 0)
                flag = true;
            else if (FindVowelIndex(strGrapheme) >= 0)
                flag = true;
            else if (FindToneIndex(strGrapheme) >= 0)
                flag = true;
            else if (FindSyllographIndex(strGrapheme) >= 0)
                flag = true;
			return flag;
		}

        public Grapheme GetGrapheme(string strGrapheme)
		{
            Grapheme grf = new Grapheme(strGrapheme);
			Consonant cns = null;
			Vowel vwl = null;
			Tone tone = null;
            Syllograph syllograph = null;

			for (int i = 0; i < m_Consonants.Count; i++)
			{
				cns = (Consonant) m_Consonants[i];
                if ( (cns.Symbol == strGrapheme) || (cns.UpperCase == strGrapheme) )
				{
					grf.IsConsonant = true;
                    grf.IsSyllabicConsonant = cns.IsSyllabic;
                    grf.Symbol = cns.Symbol;
                    grf.UpperCase = cns.UpperCase;
					break;
				}
			}

			for (int i = 0; i < m_Vowels.Count; i++)
			{
				vwl = (Vowel) m_Vowels[i];
                if ( (vwl.Symbol == strGrapheme) || (vwl.UpperCase == strGrapheme) )
				{
					grf.IsVowel = true;
                    grf.Symbol = vwl.Symbol;
                    grf.UpperCase = vwl.UpperCase;
					break;
				}
			}

			for (int i = 0; i < m_Tones.Count; i++)
			{
				tone = (Tone) m_Tones[i];
                if ( (tone.Symbol == strGrapheme) || (tone.UpperCase == strGrapheme) )
				{
					grf.IsTone = true;
                    grf.Symbol = tone.Symbol;
                    grf.UpperCase = tone.UpperCase;
					break;
				}
			}

            for (int i = 0; i < m_Syllographs.Count; i++)
            {
                syllograph = (Syllograph) m_Syllographs[i];
                if ((syllograph.Symbol == strGrapheme) || (syllograph.UpperCase == strGrapheme))
                {
                    grf.IsSyllograph = true;
                    grf.Symbol = syllograph.Symbol;
                    grf.UpperCase = syllograph.UpperCase;
                    break;
                }
            }
			return grf;
		}

        public int GetGraphemeIndex(string strGrapheme)
		{
			int ndx = -1;
            Grapheme grf= new Grapheme(strGrapheme);
			Consonant cns = null;
			Vowel vwl = null;
			Tone tone = null;
            Syllograph syllograph = null;

			for (int i = 0; i < m_Consonants.Count; i++)
			{
				cns = (Consonant) m_Consonants[i];
                if (cns.Symbol == strGrapheme)
				{
					ndx = i;
					break;
				}
			}

			for (int i = 0; i < m_Vowels.Count; i++)
			{
				vwl = (Vowel) m_Vowels[i];
                if (vwl.Symbol == strGrapheme)
				{
					ndx = i;
					break;
				}
			}

			for (int i = 0; i < m_Tones.Count; i++)
			{
				tone = (Tone)m_Tones[i];
                if (tone.Symbol == strGrapheme)
				{
					ndx = i;
					break;
				}
			}

            for (int i = 0; i < m_Syllographs.Count; i++)
            {
                syllograph = (Syllograph)m_Syllographs[i];
                if (syllograph.Symbol == strGrapheme)
                {
                    ndx = i;
                    break;
                }
            }
            return ndx;
		}

        public string SortedConsonantCountsInWordList()
		{
			string strSymbol = "";
			int nCount = 0;
			int n = 0;
			string strLine = "";
			string strText ="";
			string strKey = "";
			SortedList sl = new SortedList();

            int nWidth = this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
			char chSpace = Constants.Space;
			string strTab = Constants.Tab;

			if ( this.FileName != "" )
			{
				Consonant cns = null;
				for (int i = 0; i < this.ConsonantCount(); i++)
				{
					cns = (Consonant) m_Consonants[i];
					strSymbol = cns.Symbol;
					nCount = cns.GetCountInWordList();
					n = 999999 - nCount;		// want descending order
					strKey = n.ToString().PadLeft(nCountMaxWidth, chSpace)
						+ strSymbol.PadRight(nWidth, chSpace);
					strLine = strSymbol.PadRight(nWidth, chSpace) + strTab +
                        nCount.ToString().PadLeft(nCountMaxWidth, chSpace);
					sl.Add(strKey, strLine);
				}
				for (int i = 0; i < sl.Count; i++)
				{
					strLine = (string) sl.GetByIndex(i);
					strText += strLine + Environment.NewLine;
				}
			}
            //else MessageBox.Show("Inventory is missing");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("GraphemeInventory5",
                m_Settings.OptionSettings.UILanguage));
            return strText;
		}

        public string SortedConsonantPercentagesInWordList()
        {
            string strText = "";
            string strSymbol = "";
            int nCount = 0;
            int nTotal = 0;
            string strLine = "";
            string strKey = "";
            SortedList sl = new SortedList();

            int nWidth = this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
            char chSpace = Constants.Space;
            string strTab = Constants.Tab;

            if (this.FileName != "")
            {
                Consonant cns = null;
                int n = 0;
                string str = "";
                for (int i = 0; i < this.ConsonantCount(); i++)
                {
                    cns = (Consonant)m_Consonants[i];
                    nTotal = nTotal + cns.GetCountInWordList();
                }

                for (int i = 0; i < this.ConsonantCount(); i++)
                {
                    cns = (Consonant)m_Consonants[i];
                    strSymbol = cns.Symbol;
                    nCount = cns.GetCountInWordList();
                    n = 999999 - nCount;		                                    //want descending order
                    strKey = n.ToString().PadLeft(nCountMaxWidth, chSpace)
						+ strSymbol.PadRight(nWidth, chSpace);
                    n = Funct.GetPercentage(nCount, nTotal);                        //want percentsge
                    str = n.ToString() + GraphemeInventory.cPercent;
                    strLine = strSymbol.PadRight(nWidth, chSpace) + strTab +
                        nCount.ToString().PadLeft(nCountMaxWidth, chSpace) + Constants.Space + Constants.Hyphen + Constants.Space +
                        str.PadLeft(nCountMaxWidth - 1, chSpace);
                    sl.Add(strKey, strLine);
                }

                for (int i = 0; i < sl.Count; i++)
                {
                    strLine = (string)sl.GetByIndex(i);
                    strText += strLine + Environment.NewLine;
                }
            }
            //else MessageBox.Show("Inventory is missing");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("GraphemeInventory5",
                m_Settings.OptionSettings.UILanguage));
            return strText;
        }

        public string SortedVowelCountsInWordList()
		{
			string strSymbol = "";
			int nCount = 0;
			int n = 0;;
			string strLine = "";
			string strText = "";
			string strKey = "";
			SortedList sl = new SortedList();

            int nWidth = this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
			char chSpace = Constants.Space;
			string strTab = Constants.Tab;

			if ( this.FileName != "" )
			{
				Vowel vwl = null;
				for (int i = 0; i < this.VowelCount(); i++)
				{
					vwl = (Vowel) m_Vowels[i];
					strSymbol = vwl.Symbol;
					nCount = vwl.GetCountInWordList();
					n = 999999 - nCount;		//want descending order
                    strKey = n.ToString().PadLeft(nCountMaxWidth, chSpace) + strSymbol.PadRight(nWidth, chSpace);
					strLine = strSymbol.PadRight(nWidth, chSpace) + strTab +
                        nCount.ToString().PadLeft(nCountMaxWidth, chSpace);
					sl.Add(strKey, strLine);
				}
				for (int i = 0; i < sl.Count; i++)
				{
					strLine = (string) sl.GetByIndex(i);
					strText += strLine + Environment.NewLine;
				}
			}
            //else MessageBox.Show("Inventory is missing");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("GraphemeInventory5",
                m_Settings.OptionSettings.UILanguage));
            return strText;
		}

        public string SortedVowelPercentagesInWordList()
        {
            string strText = "";
            string strSymbol = "";
            int nCount = 0;
            int nTotal = 0;
            string strLine = "";
            string strKey = "";
            SortedList sl = new SortedList();

            int nWidth = this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
            char chSpace = Constants.Space;
            string strTab = Constants.Tab;

            if (this.FileName != "")
            {
                Vowel vwl = null;
                int n = 0;
                string str = "";
                for (int i = 0; i < this.VowelCount(); i++)
                {
                    vwl = (Vowel)m_Vowels[i];
                    nTotal = nTotal + vwl.GetCountInWordList();
                }

                for (int i = 0; i < this.VowelCount(); i++)
                {
                    vwl = (Vowel)m_Vowels[i];
                    strSymbol = vwl.Symbol;
                    nCount = vwl.GetCountInWordList();
                    n = 999999 - nCount;		                                    //want descending order
                    strKey = n.ToString().PadLeft(nCountMaxWidth, chSpace) + strSymbol.PadRight(nWidth, chSpace);
                    n = Funct.GetPercentage(nCount, nTotal);                        //want percentage
                    str = n.ToString() + GraphemeInventory.cPercent;
                    strLine = strSymbol.PadRight(nWidth, chSpace) + strTab +
                        nCount.ToString().PadLeft(nCountMaxWidth, chSpace) + Constants.Space + Constants.Hyphen + Constants.Space +
                        str.PadLeft(nCountMaxWidth - 1, chSpace);
                    sl.Add(strKey, strLine);
                }
                for (int i = 0; i < sl.Count; i++)
                {
                    strLine = (string)sl.GetByIndex(i);
                    strText += strLine + Environment.NewLine;
                }
            }
            //else MessageBox.Show("Inventory is missing");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("GraphemeInventory5",
                m_Settings.OptionSettings.UILanguage));
            return strText;
        }
        
        public string SortedToneCountsInWordList()
        {
            string strSymbol = "";
            int nCount = 0;
            int n = 0;
            string strLine = "";
            string strText = "";
            string strKey = "";
            SortedList sl = new SortedList();

            int nWidth = this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
            char chSpace = Constants.Space;
            string strTab = Constants.Tab;

            if (this.FileName != "")
            {
                Tone tone = null;
                for (int i = 0; i < this.ToneCount(); i++)
                {
                    tone = (Tone)m_Tones[i];
                    strSymbol = tone.Symbol;
                    nCount = tone.GetCountInWordList();
                    n = 999999 - nCount;		// want descending order
                    strKey = n.ToString().PadLeft(nCountMaxWidth, chSpace)
                        + strSymbol.PadRight(nWidth, chSpace);
                    strLine = strSymbol.PadRight(nWidth, chSpace) + strTab +
                        nCount.ToString().PadLeft(nCountMaxWidth, chSpace);
                    sl.Add(strKey, strLine);
                }
                for (int i = 0; i < sl.Count; i++)
                {
                    strLine = (string)sl.GetByIndex(i);
                    strText += strLine + Environment.NewLine;
                }
            }
            //else MessageBox.Show("Inventory is missing");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("GraphemeInventory5",
                m_Settings.OptionSettings.UILanguage));
            return strText;
        }

        public string SortedTonePercentsgesInWordList()
        {
            string strText = "";
            string strSymbol = "";
            int nCount = 0;
            int nTotal = 0;
            string strLine = "";
            string strKey = "";
            SortedList sl = new SortedList();

            int nWidth = this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
            char chSpace = Constants.Space;
            string strTab = Constants.Tab;

            if (this.FileName != "")
            {
                Tone tone = null;
                int n = 0;
                string str = "";
                for (int i = 0; i < this.ToneCount(); i++)
                {
                    tone = (Tone)m_Tones[i];
                    nTotal = nTotal + tone.GetCountInWordList();
                }

                for (int i = 0; i < this.ToneCount(); i++)
                {
                    tone = (Tone)m_Tones[i];
                    strSymbol = tone.Symbol;
                    nCount = tone.GetCountInWordList();
                    n = 999999 - nCount;		                                // want descending order
                    strKey = n.ToString().PadLeft(nCountMaxWidth, chSpace) + strSymbol.PadRight(nWidth, chSpace);
                    n = Funct.GetPercentage(nCount, nTotal);                    // want percentage
                    str = n.ToString() + GraphemeInventory.cPercent;
                    strLine = strSymbol.PadRight(nWidth, chSpace) + strTab +
                        nCount.ToString().PadLeft(nCountMaxWidth, chSpace) + Constants.Space + Constants.Hyphen + Constants.Space +
                        str.PadLeft(nCountMaxWidth - 1, chSpace);
                    sl.Add(strKey, strLine);
                }

                for (int i = 0; i < sl.Count; i++)
                {
                    strLine = (string)sl.GetByIndex(i);
                    strText += strLine + Environment.NewLine;
                }
            }
            //else MessageBox.Show("Inventory is missing");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("GraphemeInventory5",
                m_Settings.OptionSettings.UILanguage));
            return strText;
        }

        public string SortedSyllographCountsInWordList()
        {
            string strSymbol = "";
            int nCount = 0;
            int n = 0;
            string strLine = "";
            string strText = "";
            string strKey = "";
            SortedList sl = new SortedList(StringComparer.OrdinalIgnoreCase);

            int nWidth = this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
            char chSpace = Constants.Space;
            string strTab = Constants.Tab;

            if (this.FileName != "")
            {
                Syllograph syllograph = null;
                for (int i = 0; i < this.SyllographCount(); i++)
                {
                    syllograph = (Syllograph)m_Syllographs[i];
                    strSymbol = syllograph.Symbol;
                    nCount = syllograph.GetCountInWordList();
                    n = 999999 - nCount;		// want descending order

                    // for syllographs need to convert symbol to unicode for add method of
                    // sorted list to work properly
                    //int num = 0;
                    //string strNumber = "";
                    //foreach (char c in strSymbol)
                    //{
                    //    num = (int)c;
                    //    strNumber = strNumber + num.ToString();
                    //}

                    //strKey = n.ToString().PadLeft(nCountMaxWidth, chSpace) + strNumber;
                    strKey = n.ToString().PadLeft(nCountMaxWidth, chSpace)
                        + strSymbol.PadRight(nWidth, chSpace);
                    strLine = strSymbol.PadRight(nWidth, chSpace) + strTab +
                        nCount.ToString().PadLeft(nCountMaxWidth, chSpace);
                    try
                    {
                        sl.Add(strKey, strLine);
                    }
                    catch (System.Exception ex)
                    {
                        string strMsg = strKey + ": " + ex.GetType().ToString();
                        MessageBox.Show(strMsg);
                    }
                }
                for (int i = 0; i < sl.Count; i++)
                {
                    strLine = (string)sl.GetByIndex(i);
                    strText += strLine + Environment.NewLine;
                }
            }
            //else MessageBox.Show("Inventory is missing");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("GraphemeInventory5",
                m_Settings.OptionSettings.UILanguage));
            return strText;
        }

        public string SortedSyllographPercentagesInWordList()
        {
            string strText = "";
            string strSymbol = "";
            int nCount = 0;
            int nTotal = 0;
            string strLine = "";
            string strKey = "";
            SortedList sl = new SortedList(StringComparer.OrdinalIgnoreCase);

            int nWidth = this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
            char chSpace = Constants.Space;
            string strTab = Constants.Tab;

            if (this.FileName != "")
            {
                Syllograph syllograph = null;
                int n = 0;
                string str = "";
                for (int i = 0; i < this.SyllographCount(); i++)
                {
                    syllograph = (Syllograph)m_Syllographs[i];
                    nTotal = nTotal + syllograph.GetCountInWordList();
                }
                
                for (int i = 0; i < this.SyllographCount(); i++)
                {
                    syllograph = (Syllograph)m_Syllographs[i];
                    strSymbol = syllograph.Symbol;
                    nCount = syllograph.GetCountInWordList();
                    n = 999999 - nCount;		// want descending order

                    // for syllographs need to convert symbol to unicode for add method of
                    // sorted list to work properly
                    //int num = 0;
                    //string strNumber = "";
                    //foreach (char c in strSymbol)
                    //{
                    //    num = (int)c;
                    //    strNumber = strNumber + num.ToString();
                    //}

                    //strKey = n.ToString().PadLeft(nCountMaxWidth, chSpace) + strNumber;
                    strKey = n.ToString().PadLeft(nCountMaxWidth, chSpace) + strSymbol.PadRight(nWidth, chSpace);
                    n = Funct.GetPercentage(nCount, nTotal);
                    str = n.ToString().PadLeft(nCountMaxWidth, chSpace);
                    strLine = strSymbol.PadRight(nWidth, chSpace) + strTab +
                        nCount.ToString().PadLeft(nCountMaxWidth, chSpace) + Constants.Space + Constants.Hyphen + Constants.Space +
                        str.PadLeft(nCountMaxWidth - 1, chSpace);
                        
                    try
                    {
                        sl.Add(strKey, strLine);
                    }
                    catch (System.Exception ex)
                    {
                        string strMsg = strKey + ": " + ex.GetType().ToString();
                        MessageBox.Show(strMsg);
                    }
                }
                for (int i = 0; i < sl.Count; i++)
                {
                    strLine = (string)sl.GetByIndex(i);
                    strText += strLine + Environment.NewLine;
                }
            }
            //else MessageBox.Show("Inventory is missing");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("GraphemeInventory5",
                m_Settings.OptionSettings.UILanguage));
            return strText;
        }

        public string SortedConsonantCountsInTextData()
		{
			string strSymbol = "";
			int nCount = 0;
			int n = 0;
			string strLine = "";
			string strText = "";
			string strKey = "";
			SortedList sl = new SortedList();

            int nWidth = this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
			char chSpace = Constants.Space;
			string strTab = Constants.Tab;

			if ( this.FileName != "" )
			{
				Consonant cns = null;
				for (int i = 0; i < this.ConsonantCount(); i++)
				{
					cns = (Consonant) m_Consonants[i];
					strSymbol = cns.Symbol;
					nCount = cns.GetCountInTextData();
					n = 999999 - nCount;			//want descending order
                    strKey = n.ToString().PadLeft(nCountMaxWidth, chSpace) 
						+ strSymbol.PadRight(nWidth, chSpace);
					strLine = strSymbol.PadRight(nWidth, chSpace) + strTab +
                        nCount.ToString().PadLeft(nCountMaxWidth, chSpace);
					sl.Add(strKey, strLine);
				}
				for (int i = 0; i < sl.Count; i++)
				{
					strLine = (string) sl.GetByIndex(i);
					strText += strLine + Environment.NewLine;
				}
			}
            //else MessageBox.Show("Inventory is missing");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("GraphemeInventory5",
                m_Settings.OptionSettings.UILanguage));
            return strText;
		}

        public string SortedConsonantPercentagesInTextData()
        {
            string strSymbol = "";
            int nCount = 0;
            int nTotal = 0;
            string strLine = "";
            string strText = "";
            string strKey = "";
            SortedList sl = new SortedList();

            int nWidth = this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
            char chSpace = Constants.Space;
            string strTab = Constants.Tab;

            if (this.FileName != "")
            {
                Consonant cns = null;
                int n = 0;
                string str = "";

                for (int i = 0; i < this.ConsonantCount(); i++)
                {
                    cns = (Consonant)m_Consonants[i];
                    nTotal = nTotal + cns.GetCountInTextData();
                }

                for (int i = 0; i < this.ConsonantCount(); i++)
                {
                    cns = (Consonant)m_Consonants[i];
                    strSymbol = cns.Symbol;
                    nCount = cns.GetCountInTextData();
                    n = 999999 - nCount;			//want descending order
                    strKey = n.ToString().PadLeft(nCountMaxWidth, chSpace) + strSymbol.PadRight(nWidth, chSpace);
                    n = Funct.GetPercentage(nCount, nTotal);
                    str = n.ToString() + GraphemeInventory.cPercent;
                    strLine = strSymbol.PadRight(nWidth, chSpace) + strTab +
                        nCount.ToString().PadLeft(nCountMaxWidth, chSpace) + Constants.Space + Constants.Hyphen + Constants.Space +
                        str.PadLeft(nCountMaxWidth - 1, chSpace);
                    sl.Add(strKey, strLine);
                }

                for (int i = 0; i < sl.Count; i++)
                {
                    strLine = (string)sl.GetByIndex(i);
                    strText += strLine + Environment.NewLine;
                }
            }
            //else MessageBox.Show("Inventory is missing");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("GraphemeInventory5",
                m_Settings.OptionSettings.UILanguage));
            return strText;
        }

        public string SortedVowelCountsInTextData()
		{
			string strSymbol = "";
			int nCount = 0;
			int n = 0;
			string strLine = "";
			string strText = "";
			string strKey = "";
            SortedList sl = new SortedList();

            int nWidth = this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
			char chSpace = Constants.Space;
			string strTab = Constants.Tab;

			if ( this.FileName != "" )
			{
				Vowel vwl = null;
				for (int i = 0; i < this.VowelCount(); i++)
				{
					vwl = (Vowel) m_Vowels[i];
					strSymbol = vwl.Symbol;
					nCount = vwl.GetCountInTextData();
					n = 999999 - nCount;		//want descending order
                    strKey = n.ToString().PadLeft(nCountMaxWidth, chSpace) 
						+ strSymbol.PadRight(nWidth, chSpace);
					strLine = strSymbol.PadRight(nWidth, chSpace) + strTab +
                        nCount.ToString().PadLeft(nCountMaxWidth, chSpace);
					sl.Add(strKey, strLine);
				}
				for (int i = 0; i < sl.Count; i++)
				{
					strLine = (string) sl.GetByIndex(i);
					strText += strLine + Environment.NewLine;
				}
			}
            //else MessageBox.Show("Inventory is missing");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("GraphemeInventory5",
                m_Settings.OptionSettings.UILanguage));
            return strText;
		}

        public string SortedVowelPercentagesInTextData()
        {
            string strText = "";
            string strSymbol = "";
            int nCount = 0;
            int nTotal = 0;
            string strLine = "";
            string strKey = "";
            SortedList sl = new SortedList();

            int nWidth = this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
            char chSpace = Constants.Space;
            string strTab = Constants.Tab;

            if (this.FileName != "")
            {
                Vowel vwl = null;
                int n = 0;
                string str = "";

                for (int i = 0; i < this.VowelCount(); i++)
                {
                    vwl = (Vowel)m_Vowels[i];
                    nTotal = nTotal + vwl.GetCountInTextData();
                }

                for (int i = 0; i < this.VowelCount(); i++)
                {
                    vwl = (Vowel)m_Vowels[i];
                    strSymbol = vwl.Symbol;
                    nCount = vwl.GetCountInTextData();
                    n = 999999 - nCount;		//want descending order
                    strKey = n.ToString().PadLeft(nCountMaxWidth, chSpace) + strSymbol.PadRight(nWidth, chSpace);
                    n = Funct.GetPercentage(nCount, nTotal);
                    str = n.ToString() + GraphemeInventory.cPercent;
                    strLine = strSymbol.PadRight(nWidth, chSpace) + strTab + 
                        nCount.ToString().PadLeft(nCountMaxWidth, chSpace) + Constants.Space + Constants.Hyphen + Constants.Space +
                        str.PadLeft(nCountMaxWidth - 1, chSpace);
                    sl.Add(strKey, strLine);
                }

                for (int i = 0; i < sl.Count; i++)
                {
                    strLine = (string)sl.GetByIndex(i);
                    strText += strLine + Environment.NewLine;
                }
            }
            //else MessageBox.Show("Inventory is missing");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("GraphemeInventory5",
                m_Settings.OptionSettings.UILanguage));
            return strText;
        }

        public string SortedToneCountsInTextData()
        {
            string strSymbol = "";
            int nCount = 0;
            int n = 0;
            string strLine = "";
            string strText = "";
            string strKey = "";
            SortedList sl = new SortedList();

            int nWidth = this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
            char chSpace = Constants.Space;
            string strTab = Constants.Tab;

            if (this.FileName != "")
            {
                Tone tone = null;
                for (int i = 0; i < this.ToneCount(); i++)
                {
                    tone = (Tone)m_Tones[i];
                    strSymbol = tone.Symbol;
                    nCount = tone.GetCountInTextData();
                    n = 999999 - nCount;			//want descending order
                    strKey = n.ToString().PadLeft(nCountMaxWidth, chSpace)
                        + strSymbol.PadRight(nWidth, chSpace);
                    strLine = strSymbol.PadRight(nWidth, chSpace) + strTab +
                        nCount.ToString().PadLeft(nCountMaxWidth, chSpace);
                    sl.Add(strKey, strLine);
                }
                for (int i = 0; i < sl.Count; i++)
                {
                    strLine = (string)sl.GetByIndex(i);
                    strText += strLine + Environment.NewLine;
                }
            }
            //else MessageBox.Show("Inventory is missing");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("GraphemeInventory5",
                m_Settings.OptionSettings.UILanguage));
            return strText;
        }

        public string SortedTonePercentagesInTextData()
        {
            string strText = "";
            string strSymbol = "";
            int nCount = 0;
            int nTotal = 0;
            string strLine = "";
            string strKey = "";
            SortedList sl = new SortedList();

            int nWidth = this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
            char chSpace = Constants.Space;
            string strTab = Constants.Tab;

            if (this.FileName != "")
            {
                Tone tone = null;
                int n = 0;
                string str = "";

                for (int i = 0; i < this.ToneCount(); i++)
                {
                    tone = (Tone)m_Tones[i];
                    nTotal = nTotal + tone.GetCountInTextData();
                }
            
                for (int i = 0; i < this.ToneCount(); i++)
                {
                    tone = (Tone)m_Tones[i];
                    strSymbol = tone.Symbol;
                    nCount = tone.GetCountInTextData();
                    n = 999999 - nCount;			//want descending order
                    strKey = n.ToString().PadLeft(nCountMaxWidth, chSpace) + strSymbol.PadRight(nWidth, chSpace);
                    n = Funct.GetPercentage(nCount, nTotal);
                    str = n.ToString() + GraphemeInventory.cPercent;
                    strLine = strSymbol.PadRight(nWidth, chSpace) + strTab +
                        nCount.ToString().PadLeft(nCountMaxWidth, chSpace) + Constants.Space + Constants.Hyphen + Constants.Space +
                        str.PadLeft(nCountMaxWidth - 1, chSpace);
                    sl.Add(strKey, strLine);
                }

                for (int i = 0; i < sl.Count; i++)
                {
                    strLine = (string)sl.GetByIndex(i);
                    strText += strLine + Environment.NewLine;
                }
            }
            //else MessageBox.Show("Inventory is missing");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("GraphemeInventory5",
                m_Settings.OptionSettings.UILanguage));
            return strText;
        }

        public string SortedSyllographCountsInTextData()
        {
            string strSymbol = "";
            int nCount = 0;
            int n = 0;
            string strLine = "";
            string strText = "";
            string strKey = "";
            SortedList sl = new SortedList(StringComparer.OrdinalIgnoreCase);
            
            int nWidth = this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
            char chSpace = Constants.Space;
            string strTab = Constants.Tab;

            if (this.FileName != "")
            {
                Syllograph syllograph = null;
                for (int i = 0; i < this.SyllographCount(); i++)
                {
                    syllograph = (Syllograph)m_Syllographs[i];
                    strSymbol = syllograph.Symbol;
                    nCount = syllograph.GetCountInTextData();
                    n = 999999 - nCount;			//want descending order

                    // for syllographs need to convert symbol to unicode string for add method of
                    // sorted list to work properly
                    //int num = 0;
                    //string strNumber = "";
                    //foreach (char c in strSymbol)
                    //{
                    //    num = (int)c;
                    //    strNumber = strNumber + num.ToString();
                    //}

                    //strKey = n.ToString().PadLeft(nCountMaxWidth, chSpace) + strNumber;
                    strKey = n.ToString().PadLeft(nCountMaxWidth, chSpace)
                        + strSymbol.PadRight(nWidth, chSpace);
                    strLine = strSymbol.PadRight(nWidth, chSpace) + strTab +
                        nCount.ToString().PadLeft(nCountMaxWidth, chSpace);
                    try
                    {
                        sl.Add(strKey, strLine);
                    }
                    catch (System.Exception ex)
                    {
                        string strMsg = strKey + ": " + ex.GetType().ToString();
                        MessageBox.Show(strMsg);
                    }

                }
                for (int i = 0; i < sl.Count; i++)
                {
                    strLine = (string)sl.GetByIndex(i);
                    strText += strLine + Environment.NewLine;
                }
            }
            //else MessageBox.Show("Inventory is missing");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("GraphemeInventory5",
                m_Settings.OptionSettings.UILanguage));
            return strText;
        }

        public string SortedSyllographlPercentagesInTextData()
        {
            string strText = "";
            string strSymbol = "";
            int nCount = 0;
            int nTotal = 0;
            string strLine = "";
            string strKey = "";
            SortedList sl = new SortedList(StringComparer.OrdinalIgnoreCase);

            int nWidth = this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
            char chSpace = Constants.Space;
            string strTab = Constants.Tab;

            if (this.FileName != "")
            {
                Syllograph syllograph = null;
                int n = 0;
                string str = "";

                for (int i = 0; i < this.SyllographCount(); i++)
                {
                    syllograph = (Syllograph)m_Syllographs[i];
                    nTotal = nTotal + syllograph.GetCountInTextData();
                }
            
                for (int i = 0; i < this.SyllographCount(); i++)
                {
                    syllograph = (Syllograph)m_Syllographs[i];
                    strSymbol = syllograph.Symbol;
                    nCount = syllograph.GetCountInTextData();
                    n = 999999 - nCount;			//want descending order
                    strKey = n.ToString().PadLeft(nCountMaxWidth, chSpace) + strSymbol.PadRight(nWidth, chSpace);
                    n = Funct.GetPercentage(nCount, nTotal);
                    str = n.ToString() + GraphemeInventory.cPercent;
                    strLine = strSymbol.PadRight(nWidth, chSpace) + strTab +
                        nCount.ToString().PadLeft(nCountMaxWidth, chSpace) + Constants.Space + Constants.Hyphen + Constants.Space +
                        str.PadLeft(nCountMaxWidth - 1, chSpace);
                    try
                    {
                        sl.Add(strKey, strLine);
                    }
                    catch (System.Exception ex)
                    {
                        string strMsg = strKey + ": " + ex.GetType().ToString();
                        MessageBox.Show(strMsg);
                    }

                }
                for (int i = 0; i < sl.Count; i++)
                {
                    strLine = (string)sl.GetByIndex(i);
                    strText += strLine + Environment.NewLine;
                }
            }
            //else MessageBox.Show("Inventory is missing");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("GraphemeInventory5",
                m_Settings.OptionSettings.UILanguage));
            return strText;
        }

        public string RetrieveConsonantCountsInWordList()
		{
			string strSymbol = "";
			int nCount = 0;
			string strLine = "";
			string strLines ="";

            int nWidth = this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
			char chSpace = Constants.Space;
		    string strTab = Constants.Tab;

			if ( this.FileName != "" )
			{
				Consonant cns = null;
				for (int i = 0; i < this.ConsonantCount(); i++)
				{
					cns = (Consonant) m_Consonants[i];
					strSymbol = cns.Symbol;
					nCount = cns.GetCountInWordList();
					strLine = strSymbol.PadRight(nWidth, chSpace) + strTab +
						nCount.ToString().PadLeft(nWidth, chSpace) + Environment.NewLine;
					strLines += strLine;
				}
			}
            //else MessageBox.Show("Inventory is missing");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("GraphemeInventory5",
                m_Settings.OptionSettings.UILanguage));
            return strLines;
		}

		public string RetrieveVowelCountsInWordList()
		{
			string strSymbol = "";
			string strLine = "";
			string strLines ="";
			int nCount = 0;

            int nWidth = this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
			char chSpace = Constants.Space;
			string strTab = Constants.Tab;

			if ( this.FileName != "" )
			{
				Vowel vwl = null;
				for (int i = 0; i < this.VowelCount(); i++)
				{
					vwl = (Vowel) m_Vowels[i];
					strSymbol = vwl.Symbol;
					nCount = vwl.GetCountInWordList();
					strLine = strSymbol.PadRight(nWidth, chSpace) + strTab +
						nCount.ToString().PadLeft(nWidth, chSpace) + Environment.NewLine;
					strLines += strLine;
				}
			}
            //else MessageBox.Show("Inventory is missing");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("GraphemeInventory5",
                m_Settings.OptionSettings.UILanguage));
            return strLines;
		}

        public string RetrieveToneCountsInWordList()
        {
            string strSymbol = "";
            int nCount = 0;
            string strLine = "";
            string strLines = "";

            int nWidth = this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
            char chSpace = Constants.Space;
            string strTab = Constants.Tab;

            if (this.FileName != "")
            {
                Tone tone = null;
                for (int i = 0; i < this.ToneCount(); i++)
                {
                    tone = (Tone)m_Tones[i];
                    strSymbol = tone.Symbol;
                    nCount = tone.GetCountInWordList();
                    strLine = strSymbol.PadRight(nWidth, chSpace) + strTab +
                        nCount.ToString().PadLeft(nWidth, chSpace) + Environment.NewLine;
                    strLines += strLine;
                }
            }
            //else MessageBox.Show("Inventory is missing");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("GraphemeInventory5",
                m_Settings.OptionSettings.UILanguage));
            return strLines;
        }

        public string RetrieveSyllographCountsInWordList()
        {
            string strSymbol = "";
            int nCount = 0;
            string strLine = "";
            string strLines = "";

            int nWidth = this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
            char chSpace = Constants.Space;
            string strTab = Constants.Tab;

            if (this.FileName != "")
            {
                Syllograph syllograph = null;
                for (int i = 0; i < this.SyllographCount(); i++)
                {
                    syllograph = (Syllograph)m_Syllographs[i];
                    strSymbol = syllograph.Symbol;
                    nCount = syllograph.GetCountInWordList();
                    strLine = strSymbol.PadRight(nWidth, chSpace) + strTab +
                        nCount.ToString().PadLeft(nWidth, chSpace) + Environment.NewLine;
                    strLines += strLine;
                }
            }
            //else MessageBox.Show("Inventory is missing");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("GraphemeInventory5",
                m_Settings.OptionSettings.UILanguage));
            return strLines;
        }
        
        public string RetrieveConsonantCountsInTextData()
		{
			string strSymbol = "";
			int nCount = 0;
			string strLine = "";
			string strLines ="";

            int nWidth = this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
			char chSpace = Constants.Space;
			string strTab = Constants.Tab;

			if ( this.FileName != "" )
			{
				Consonant cns = null;
				for (int i = 0; i < this.ConsonantCount(); i++)
				{
					cns = (Consonant) m_Consonants[i];
					strSymbol = cns.Symbol;
					nCount = cns.GetCountInTextData();
					strLine = strSymbol.PadRight(nWidth, chSpace) + strTab +
						nCount.ToString().PadLeft(nWidth, chSpace) + Environment.NewLine;
					strLines += strLine;
				}
			}
            //else MessageBox.Show("Inventory is missing");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("GraphemeInventory5",
                m_Settings.OptionSettings.UILanguage));
            return strLines;
		}

		public string RetrieveVowelCountsInTextData()
		{
			string strSymbol = "";
			string strLine = "";
			string strLines ="";
			int nCount = 0;

            int nWidth = this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
			char chSpace = Constants.Space;
			string strTab = Constants.Tab;

			if ( this.FileName != "" )
			{
				Vowel vwl = null;
				for (int i = 0; i < this.VowelCount(); i++)
				{
					vwl = (Vowel) m_Vowels[i];
					strSymbol = vwl.Symbol;
					nCount = vwl.GetCountInTextData();
					strLine = strSymbol.PadRight(nWidth, chSpace) + strTab +
						nCount.ToString().PadLeft(nWidth, chSpace) + Environment.NewLine;
					strLines += strLine;
				}
			}
            //else MessageBox.Show("Inventory is missing");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("GraphemeInventory5",
                m_Settings.OptionSettings.UILanguage));
            return strLines;
		}

        public string RetrieveToneCountsInTextData()
        {
            string strSymbol = "";
            int nCount = 0;
            string strLine = "";
            string strLines = "";

            int nWidth = this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
            char chSpace = Constants.Space;
            string strTab = Constants.Tab;

            if (this.FileName != "")
            {
                Tone tone = null;
                for (int i = 0; i < this.ToneCount(); i++)
                {
                    tone = (Tone)m_Tones[i];
                    strSymbol = tone.Symbol;
                    nCount = tone.GetCountInTextData();
                    strLine = strSymbol.PadRight(nWidth, chSpace) + strTab +
                        nCount.ToString().PadLeft(nWidth, chSpace) + Environment.NewLine;
                    strLines += strLine;
                }
            }
            //else MessageBox.Show("Inventory is missing");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("GraphemeInventory5",
                m_Settings.OptionSettings.UILanguage));
            return strLines;
        }

        public string RetrieveSyllographCountsInTextData()
        {
            string strSymbol = "";
            int nCount = 0;
            string strLine = "";
            string strLines = "";

            int nWidth = this.m_Settings.OptionSettings.MaxSizeGrapheme + 2;
            char chSpace = Constants.Space;
            string strTab = Constants.Tab;

            if (this.FileName != "")
            {
                Syllograph syllograph = null;
                for (int i = 0; i < this.SyllographCount(); i++)
                {
                    syllograph = (Syllograph)m_Syllographs[i];
                    strSymbol = syllograph.Symbol;
                    nCount = syllograph.GetCountInTextData();
                    strLine = strSymbol.PadRight(nWidth, chSpace) + strTab +
                        nCount.ToString().PadLeft(nWidth, chSpace) + Environment.NewLine;
                    strLines += strLine;
                }
            }
            //else MessageBox.Show("Inventory is missing");
            else MessageBox.Show(m_Settings.LocalizationTable.GetMessage("GraphemeInventory5",
                m_Settings.OptionSettings.UILanguage));
            return strLines;
        }


	}
}

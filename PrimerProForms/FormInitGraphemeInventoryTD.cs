using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GenLib;
using PrimerProLocalization;
using PrimerProObjects;

namespace PrimerProForms
{

    public partial class FormInitGraphemeInventoryTD : Form
    {
        private Settings m_Settings;
        private string m_Folder;
        private LocalizationTable m_Table;
        private string m_Lang;
        private Font m_Font;
        private string m_FileName;
        private GraphemeInventory m_GraphemeInventory;
        private GraphemeInventory m_DefaultGraphemeInventory;

        TextData td = null;
        WordList wl = null;
        private ArrayList m_AvailableSymbols;
        private ArrayList m_SelectedSymbols;
        private ArrayList m_Consonants;                 //List of consonants
        private ArrayList m_Vowels;                     //List of vowels
        private ArrayList m_Tones;                      //List of tones
        private ArrayList m_AvailablelMultiGraphs;
        private ArrayList m_SelectedMultiGraphs;

        private const string kDefaultGIName = "DefaultGraphemeInventory.xml";

        
        public FormInitGraphemeInventoryTD(Settings s, GraphemeInventory gi)
        {
            InitializeComponent();
            m_Settings = s;
            m_GraphemeInventory = gi;
            m_Folder = m_Settings.OptionSettings.DataFolder;
            m_Table = m_Settings.LocalizationTable;
            m_Lang = m_Settings.OptionSettings.UILanguage;
            m_Font = m_Settings.OptionSettings.GetDefaultFont();
            m_FileName = "";

            string strFileName = m_Settings.GetAppFolder() + Constants.Backslash + FormInitGraphemeInventoryTD.kDefaultGIName;
            m_DefaultGraphemeInventory = new GraphemeInventory(m_Settings);
            if (!m_DefaultGraphemeInventory.LoadFromFile(strFileName))
                m_DefaultGraphemeInventory = new GraphemeInventory(m_Settings); ;

            td = new TextData(m_Settings);
            wl = new WordList(m_Settings);
            m_AvailableSymbols = new ArrayList();
            m_SelectedSymbols = new ArrayList();
            m_Consonants = m_GraphemeInventory.Consonants;
            m_Vowels = m_GraphemeInventory.Vowels;
            m_Tones = m_GraphemeInventory.Tones;
            m_AvailablelMultiGraphs = new ArrayList();
            m_SelectedMultiGraphs = new ArrayList();
            
            this.btnConsonants.Enabled = false;
            this.tbConsonants.Text = ConvertListOfConsonantsToString(m_Consonants, Constants.Space.ToString());
            this.btnVowels.Enabled = false;
            this.tbVowels.Text = ConvertListOfVowelsToString(m_Vowels, Constants.Space.ToString());
            this.btnTones.Enabled = false;
            this.tbTones.Text = ConvertListOfTonesToString(m_Tones, Constants.Space.ToString());
            this.btnMulti.Enabled = false;
            this.btnOK.Enabled = false;
            if (m_Font != null)
            {
                this.tbConsonants.Font = m_Font;
                this.tbVowels.Font = m_Font;
                this.tbTones.Font = m_Font;
                this.tbTDFile.Font = m_Font;
            }

            this.UpdateFormForLocalization(m_Table);
        }

        public string FileName
        {
            get { return m_FileName; }
        }

        public GraphemeInventory GraphemeInventory
        {
            get { return m_GraphemeInventory; }
        }

        private GraphemeInventory DefaultGraphemeInventory
        {
            get {return m_DefaultGraphemeInventory;}
        }
        
        private void btnTDFile_Click(object sender, EventArgs e)
        {
            string strText = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files (*.txt)|*.txt|All Files (*.*)|*.*";
            ofd.FileName = "";
            ofd.DefaultExt = "*.txt";
            ofd.InitialDirectory = m_Folder;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.tbTDFile.Text = ofd.FileName;
                m_FileName = ofd.FileName;
                td = new TextData(m_Settings);
                if (td.LoadFile(m_FileName))
                    wl = td.BuildWordListWithNoDuplicates();
                else wl = new WordList();
            }
            else wl = null;

            if (wl != null)
            {
                if (wl.WordCount() > 0)
                {
                    string strSymbol = "";
                    bool found = false;
                    Consonant cns = null;
                    Vowel vwl = null;
                    Tone tone = null;
                    SortedList sl = wl.BuildSortedCharacterList();
                    for (int i = 0; i < sl.Count; i++)
                    {
                        strSymbol = (string)sl.GetByIndex(i);
                        found = false;
                        for (int j = 0; j < m_Consonants.Count; j++)
                        {
                            cns = (Consonant)m_Consonants[j];
                            if (cns.Symbol == strSymbol)
                                found = true;
                        }
                        for (int j = 0; j < m_Vowels.Count; j++)
                        {
                            vwl = (Vowel)m_Vowels[j];
                            if (vwl.Symbol == strSymbol)
                                found = true;
                        }
                        for (int j = 0; j < m_Tones.Count; j++)
                        {
                            tone = (Tone)m_Tones[j];
                            if (tone.Symbol == strSymbol)
                                found = true;
                        }
                        if (!found)
                            m_AvailableSymbols.Add(strSymbol);
                    }
                    this.btnConsonants.Enabled = true;
                    this.btnVowels.Enabled = true;
                    this.btnTones.Enabled = true;
                    this.btnOK.Enabled = true;
                    if ((m_Consonants.Count > 0) || (m_Vowels.Count > 0))
                        this.btnMulti.Enabled = true;
                }
                //else MessageBox.Show("Text Data is empty");
                else
                {
                    strText = m_Table.GetMessage("FormInitGraphemeInventoryTD1");
                    if (strText == "")
                        strText = "Text Data is empty";
                    MessageBox.Show(strText);
                }
            }
            //else MessageBox.Show("Text Data not specified");
            else
            {
                strText = m_Table.GetMessage("FormInitGraphemeInventoryTD2");
                if (strText == "")
                    strText = "Text Data not specified";
                MessageBox.Show(strText);
            }
        }

        private void btnConsonants_Click(object sender, EventArgs e)
        {
            bool flag = false;
            ArrayList alSymbols = new ArrayList();
            Consonant cns = null;
            string strTitle = btnConsonants.Text;
            for (int i = 0; i < m_Consonants.Count; i++)
            {
                cns = (Consonant)m_Consonants[i];
                alSymbols.Add(cns.Symbol);
            }

            if ((m_Lang != "") && (m_Lang == OptionList.kFrench))       //Get french form
            {
                FormItemSelectionFrench form = new FormItemSelectionFrench(m_AvailableSymbols, alSymbols, strTitle, m_Font);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    m_SelectedSymbols = form.Selection();
                    m_AvailableSymbols = form.Available();
                    flag = true;
                }
            }
            else if ((m_Lang != "") && (m_Lang == OptionList.kSpanish))       //Get spanish form
            {
                FormItemSelectionSpanish form = new FormItemSelectionSpanish(m_AvailableSymbols, alSymbols, strTitle, m_Font);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    m_SelectedSymbols = form.Selection();
                    m_AvailableSymbols = form.Available();
                    flag = true;
                }
            }
            else
            {
                FormItemSelection form = new FormItemSelection(m_AvailableSymbols, alSymbols, strTitle, m_Font);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    m_SelectedSymbols = form.Selection();
                    m_AvailableSymbols = form.Available();
                    flag = true;
                }
            }

            if (flag)
            {
                bool found = false;
                string strChar = "";
                cns = null;

                for (int i = 0; i < m_SelectedSymbols.Count; i++)       //Process added consonants
                {
                    found = false;
                    strChar = m_SelectedSymbols[i].ToString();
                    for (int n = 0; n < m_Consonants.Count; n++)
                    {
                        cns = (Consonant)m_Consonants[n];
                        if (cns.Symbol == strChar)
                            found = true;
                    }
                    if (!found)
                    {
                        cns = new Consonant(strChar);
                        if (cns.Symbol.Length > 1)
                            cns.UpperCase = cns.Symbol.Substring(0, 1).ToUpper() + cns.Symbol.Substring(1);
                        else cns.UpperCase = cns.Symbol.ToUpper();
                        m_Consonants.Add(cns);
                    }
                }

                for (int i = 0; i < m_AvailableSymbols.Count; i++)      //Process removed consonants
                {
                    strChar = m_AvailableSymbols[i].ToString();
                    for (int n = 0; n < m_Consonants.Count; n++)
                    {
                        cns = (Consonant)m_Consonants[n];
                        if (cns.Symbol == strChar)
                            m_Consonants.RemoveAt(n);
                    }
                }

                tbConsonants.Text = ConvertListOfConsonantsToString(m_Consonants, Constants.Space.ToString());
                if (m_Consonants.Count > 0)
                    this.btnMulti.Enabled = true;
            }
        }

        private void btnVowels_Click(object sender, EventArgs e)
        {
            bool flag = false;
            ArrayList alSymbols = new ArrayList();
            Vowel vwl = null;
            string strTitle = btnVowels.Text;
            for (int i = 0; i < m_Vowels.Count; i++)
            {
                vwl = (Vowel)m_Vowels[i];
                alSymbols.Add(vwl.Symbol);
            }

            if ((m_Lang != "") && (m_Lang == OptionList.kFrench))       //Get French form
            {
                FormItemSelectionFrench form = new FormItemSelectionFrench(m_AvailableSymbols, alSymbols, strTitle, m_Font);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    m_SelectedSymbols = form.Selection();
                    m_AvailableSymbols = form.Available();
                    flag = true;
                }
            }
            else if ((m_Lang != "") && (m_Lang == OptionList.kSpanish))       //Get spanish form
            {
                FormItemSelectionSpanish form = new FormItemSelectionSpanish(m_AvailableSymbols, alSymbols, strTitle, m_Font);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    m_SelectedSymbols = form.Selection();
                    m_AvailableSymbols = form.Available();
                    flag = true;
                }
            }
            else
            {
                FormItemSelection form = new FormItemSelection(m_AvailableSymbols, alSymbols, strTitle, m_Font);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    m_SelectedSymbols = form.Selection();
                    m_AvailableSymbols = form.Available();
                    flag = true;
                }
            }

            if (flag)
            {
                bool found = false;
                string strChar = "";
                vwl = null;

                for (int i = 0; i < m_SelectedSymbols.Count; i++)       //Process added vowels
                {
                    found = false;
                    strChar = m_SelectedSymbols[i].ToString();
                    for (int n = 0; n < m_Vowels.Count; n++)
                    {
                        vwl = (Vowel)m_Vowels[n];
                        if (vwl.Symbol == strChar)
                            found = true;
                    }
                    if (!found)
                    {
                        vwl = new Vowel(strChar);
                        if (vwl.Symbol.Length > 1)
                            vwl.UpperCase = vwl.Symbol.Substring(0, 1).ToUpper() + vwl.Symbol.Substring(1);
                        else vwl.UpperCase = vwl.Symbol.ToUpper();
                        m_Vowels.Add(vwl);
                    }
                }

                for (int i = 0; i < m_AvailableSymbols.Count; i++)      //Process removed vowels
                {
                    strChar = m_AvailableSymbols[i].ToString();
                    for (int n = 0; n < m_Vowels.Count; n++)
                    {
                        vwl = (Vowel)m_Vowels[n];
                        if (vwl.Symbol == strChar)
                            m_Vowels.RemoveAt(n);
                    }
                }

                tbVowels.Text = ConvertListOfVowelsToString(m_Vowels, Constants.Space.ToString());
                if (m_Vowels.Count > 0)
                    this.btnMulti.Enabled = true;
            }

        }

        private void btnTones_Click(object sender, EventArgs e)
        {
            bool flag = false;
            ArrayList alSymbols = new ArrayList();
            Tone tone = null;
            string strTitle = "";
            for (int i = 0; i < m_Tones.Count; i++)
            {
                tone = (Tone)m_Tones[i];
                alSymbols.Add(tone.Symbol);
            }

            if ((m_Lang != "") && (m_Lang == OptionList.kFrench))       //Get french form
            {
                FormItemSelectionFrench form = new FormItemSelectionFrench(m_AvailableSymbols, alSymbols, strTitle, m_Font);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    m_SelectedSymbols = form.Selection();
                    m_AvailableSymbols = form.Available();
                    flag = true;
                }
            }
            else if ((m_Lang != "") && (m_Lang == OptionList.kSpanish))       //Get spanish form
            {
                FormItemSelectionSpanish form = new FormItemSelectionSpanish(m_AvailableSymbols, alSymbols, strTitle, m_Font);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    m_SelectedSymbols = form.Selection();
                    m_AvailableSymbols = form.Available();
                    flag = true;
                }
            }
            else
            {
                FormItemSelection form = new FormItemSelection(m_AvailableSymbols, alSymbols, strTitle, m_Font);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    m_SelectedSymbols = form.Selection();
                    m_AvailableSymbols = form.Available();
                    flag = true;
                }
            }

            if (flag)
            {
                bool found = false;
                string strChar = "";
                tone = null;

                for (int i = 0; i < m_SelectedSymbols.Count; i++)       //Process added tones
                {
                    found = false;
                    strChar = m_SelectedSymbols[i].ToString();
                    for (int n = 0; n < m_Tones.Count; n++)
                    {
                        tone = (Tone)m_Tones[n];
                        if (tone.Symbol == strChar)
                            found = true;
                    }
                    if (!found)
                    {
                        tone = new Tone(strChar);
                        tone.UpperCase = tone.Symbol.ToUpper();
                        m_Tones.Add(tone);
                    }
                }

                for (int i = 0; i < m_AvailableSymbols.Count; i++)      //Process removed tones
                {
                    strChar = m_AvailableSymbols[i].ToString();
                    for (int n = 0; n < m_Tones.Count; n++)
                    {
                        tone = (Tone)m_Tones[n];
                        if (tone.Symbol == strChar)
                            m_Tones.RemoveAt(n);
                    }
                }

                tbTones.Text = ConvertListOfTonesToString(m_Tones, Constants.Space.ToString());
                if (m_Tones.Count > 0)
                    this.btnMulti.Enabled = true;
            }
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {
            string strText = "";
            if (wl != null)
            {
                if (wl.WordCount() > 0)
                {
                    Grapheme grapheme = null;
                    GraphemeInventory giTemp = new GraphemeInventory(m_Settings);
                    Consonant cns = null;
                    Vowel vwl = null;
                    Tone tone = null;
                    string strTitle = btnMulti.Text;
                    string str = "";

                    giTemp.InitConsonantList(m_Consonants);
                    giTemp.InitVowelList(m_Vowels);
                    giTemp.InitToneList(m_Tones);
                    SortedList sl = wl.BuildSortedMultiGraphList(giTemp);       //SortedList of Graphemes
                    m_AvailablelMultiGraphs = new ArrayList();

                    for (int i = 0; i < sl.Count; i++)
                    {
                        grapheme = (Grapheme)sl.GetByIndex(i);
                        str = grapheme.Symbol;
                        if (!m_SelectedMultiGraphs.Contains(grapheme.Symbol))         //no dups
                            m_AvailablelMultiGraphs.Add(grapheme.Symbol);
                    }

                    bool flag = false;
                    if ((m_Lang != "") && (m_Lang == OptionList.kFrench))       //Get french form
                    {
                        FormItemSelectionFrench form = new FormItemSelectionFrench(m_AvailablelMultiGraphs, m_SelectedMultiGraphs, strTitle, m_Font);
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            m_SelectedMultiGraphs = form.Selection();
                            m_AvailablelMultiGraphs = form.Available();
                            flag = true;
                        }
                    }
                    else if ((m_Lang != "") && (m_Lang == OptionList.kSpanish))       //Get spanish form
                    {
                        FormItemSelectionSpanish form = new FormItemSelectionSpanish(m_AvailablelMultiGraphs, m_SelectedMultiGraphs, strTitle, m_Font);
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            m_SelectedSymbols = form.Selection();
                            m_AvailableSymbols = form.Available();
                            flag = true;
                        }
                    }
                    else
                    {
                        FormItemSelection form = new FormItemSelection(m_AvailablelMultiGraphs, m_SelectedMultiGraphs, strTitle, m_Font);
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            m_SelectedMultiGraphs = form.Selection();
                            m_AvailablelMultiGraphs = form.Available();
                            flag = true;
                        }
                    }

                    if (flag)
                    {
                        for (int i = 0; i < m_SelectedMultiGraphs.Count; i++)       //Process added Multi-graphs
                        {
                            str = m_SelectedMultiGraphs[i].ToString();
                            if (sl.ContainsKey(str))        // if multigraph is available for processing
                            {
                                grapheme = (Grapheme)sl[str];
                                bool Found = false;
                                switch (grapheme.GetGraphemeType())
                                {
                                    case Grapheme.GraphemeType.Consonant:
                                        for (int n = 0; n < m_Consonants.Count; n++)
                                        {
                                            cns = (Consonant)m_Consonants[n];
                                            if (cns.Symbol == grapheme.Symbol)
                                                Found = true;
                                        }
                                        if (!Found)
                                        {
                                            cns = new Consonant(grapheme.Symbol);
                                            if (cns.Symbol.Length > 1)
                                                cns.UpperCase = cns.Symbol.Substring(0, 1).ToUpper() + cns.Symbol.Substring(1);
                                            else cns.UpperCase = cns.Symbol.ToUpper();
                                            m_Consonants.Add(cns);
                                        }
                                        break;
                                    case Grapheme.GraphemeType.Vowel:
                                        for (int n = 0; n < m_Vowels.Count; n++)
                                        {
                                            vwl = (Vowel)m_Vowels[n];
                                            if (vwl.Symbol == grapheme.Symbol)
                                                Found = true;
                                        }
                                        if (!Found)
                                        {
                                            vwl = new Vowel(grapheme.Symbol);
                                            if (vwl.Symbol.Length > 1)
                                                vwl.UpperCase = vwl.Symbol.Substring(0, 1).ToUpper() + vwl.Symbol.Substring(1);
                                            else vwl.UpperCase = vwl.Symbol.ToUpper();
                                            m_Vowels.Add(vwl);
                                        }
                                        break;
                                    case Grapheme.GraphemeType.Tone:
                                        for (int n = 0; n < m_Tones.Count; n++)
                                        {
                                            tone = (Tone)m_Tones[n];
                                            if (tone.Symbol == grapheme.Symbol)
                                                Found = true;
                                        }
                                        if (!Found)
                                        {
                                            tone = new Tone(grapheme.Symbol);
                                            if (tone.Symbol.Length > 1)
                                                tone.UpperCase = tone.Symbol.Substring(0, 1).ToUpper() + tone.Symbol.Substring(1);
                                            else tone.UpperCase = tone.Symbol.ToUpper();
                                            m_Tones.Add(tone);
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }

                        for (int i = 0; i < m_AvailablelMultiGraphs.Count; i++)         //Process removed multi-graphs
                        {
                            str = m_AvailablelMultiGraphs[i].ToString();
                            if (sl.ContainsKey(str))        // if multigraph is available for processing
                            {
                                grapheme = (Grapheme)sl[str];
                                switch (grapheme.GetGraphemeType())
                                {
                                    case Grapheme.GraphemeType.Consonant:
                                        for (int n = 0; n < m_Consonants.Count; n++)
                                        {
                                            cns = (Consonant)m_Consonants[n];
                                            if (cns.Symbol == grapheme.Symbol)
                                                m_Consonants.RemoveAt(n);
                                        }
                                        break;
                                    case Grapheme.GraphemeType.Vowel:
                                        for (int n = 0; n < m_Vowels.Count; n++)
                                        {
                                            vwl = (Vowel)m_Vowels[n];
                                            if (vwl.Symbol == grapheme.Symbol)
                                                m_Vowels.RemoveAt(n);
                                        }
                                        break;
                                    case Grapheme.GraphemeType.Tone:
                                        for (int n = 0; n < m_Tones.Count; n++)
                                        {
                                            tone = (Tone)m_Tones[n];
                                            if (tone.Symbol == grapheme.Symbol)
                                                m_Tones.RemoveAt(n);
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }

                        tbConsonants.Text = ConvertListOfConsonantsToString(m_Consonants, Constants.Space.ToString());
                        tbVowels.Text = ConvertListOfVowelsToString(m_Vowels, Constants.Space.ToString());
                        tbTones.Text = ConvertListOfTonesToString(m_Tones, Constants.Space.ToString());
                    }
                }
                //else MessageBox.Show("Word list is empty");
                else
                {
                    strText = m_Table.GetMessage("FormInitGraphemeInventoryTD3");
                    if (strText == "")
                        strText = "Word list is empty";
                    MessageBox.Show(strText);
                }
            }
            //else MessageBox.Show("Word list not specified");
            else
            {
                strText = m_Table.GetMessage("FormInitGraphemeInventoryTD4");
                if (strText == "")
                    strText = "Word list not specified";
                MessageBox.Show(strText);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            m_FileName = this.tbTDFile.Text;
            Consonant cns = null;
            Vowel vwl = null;
            Tone tone = null;
            string strSymbol = "";
            int ndx = 0;
            if (m_FileName != "")
            {
                m_GraphemeInventory = new GraphemeInventory(m_Settings);

                for (int i = 0; i < m_Consonants.Count; i++)
                {
                    cns = (Consonant)m_Consonants[i];
                    strSymbol = cns.Symbol;
                    ndx = this.DefaultGraphemeInventory.FindConsonantIndex(strSymbol);
                    if (ndx >= 0)
                        cns = this.DefaultGraphemeInventory.GetConsonant(ndx);
                    m_Consonants[i] = cns;
                }
                m_GraphemeInventory.InitConsonantList(m_Consonants);

                for (int i = 0; i < m_Vowels.Count; i++)
                {
                    vwl = (Vowel)m_Vowels[i];
                    strSymbol = vwl.Symbol;
                    ndx = this.DefaultGraphemeInventory.FindVowelIndex(strSymbol);
                    if (ndx >= 0)
                        vwl = this.DefaultGraphemeInventory.GetVowel(ndx);
                    m_Vowels[i] = vwl;
                }
                m_GraphemeInventory.InitVowelList(m_Vowels);

                for (int i = 0; i < m_Tones.Count; i++)
                {
                    tone = (Tone)m_Tones[i];
                    strSymbol = tone.Symbol;
                    ndx = this.DefaultGraphemeInventory.FindToneIndex(strSymbol);
                    if (ndx >= 0)
                        tone = this.DefaultGraphemeInventory.GetTone(ndx);
                    m_Tones[i] = tone;
                }
                m_GraphemeInventory.InitToneList(m_Tones);

                m_GraphemeInventory.FileName = m_Settings.OptionSettings.GraphemeInventoryFile;
                m_Settings.GraphemeInventory = m_GraphemeInventory;
            }
            //else MessageBox.Show("File Name is not specified.");
            else
            {
                string strText = m_Table.GetMessage("FormInitGraphemeInventoryTD5");
                if (strText == "")
                    strText = "File Name is not specified.";
                MessageBox.Show(strText);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_FileName = "";
        }

        private string ConvertListOfConsonantsToString(ArrayList consonants, string separator)
        {
            string str = "";
            Consonant cns = null;
            SortedList sl = new SortedList();

            for (int i = 0; i < consonants.Count; i++)
            {
                cns = (Consonant)consonants[i];
                sl.Add(cns.Symbol, cns);
            }

            for (int i = 0; i < sl.Count; i++)
            {
                cns = (Consonant)sl.GetByIndex(i);
                if (str == "")
                    str = cns.Symbol;
                else str = str + separator + cns.Symbol;
            }
            return str;
        }

        private string ConvertListOfVowelsToString(ArrayList vowels, string separator)
        {
            string str = "";
            Vowel vwl = null;
            SortedList sl = new SortedList();

            for (int i = 0; i < vowels.Count; i++)
            {
                vwl = (Vowel)vowels[i];
                sl.Add(vwl.Symbol, vwl);
            }

            for (int i = 0; i < sl.Count; i++)
            {
                vwl = (Vowel)sl.GetByIndex(i);
                if (str == "")
                    str = vwl.Symbol;
                else str = str + separator + vwl.Symbol;
            }
            return str;
        }

        private string ConvertListOfTonesToString(ArrayList tones, string separator)
        {
            string str = "";
            Tone tone = null;
            SortedList sl = new SortedList();

            for (int i = 0; i < tones.Count; i++)
            {
                tone = (Tone)tones[i];
                sl.Add(tone.Symbol, tone);
            }

            for (int i = 0; i < sl.Count; i++)
            {
                tone = (Tone)sl.GetByIndex(i);
                if (str == "")
                    str = tone.Symbol;
                else str = str + separator + tone.Symbol;
            }
            return str;
        }

        private void UpdateFormForLocalization(LocalizationTable table)
        {
            string strText = "";
            strText = table.GetForm("FormInitGraphemeInventoryTDT");
			if (strText != "")
				this.Text = strText;
            strText = table.GetForm("FormInitGraphemeInventoryTD0");
			if (strText != "")
				this.labWLFile.Text = strText;
            strText = table.GetForm("FormInitGraphemeInventoryTD2");
			if (strText != "")
				this.btnTDFile.Text = strText;
            strText = table.GetForm("FormInitGraphemeInventoryTD3");
			if (strText != "")
				this.btnConsonants.Text = strText;
            strText = table.GetForm("FormInitGraphemeInventoryTD5");
			if (strText != "")
				this.btnVowels.Text = strText;
            strText = table.GetForm("FormInitGraphemeInventoryTD7");
			if (strText != "")
				this.btnTones.Text = strText;
            strText = table.GetForm("FormInitGraphemeInventoryTD9");
			if (strText != "")
				this.btnMulti.Text = strText;
            strText = table.GetForm("FormInitGraphemeInventoryTD10");
			if (strText != "")
				this.btnOK.Text = strText;
            strText = table.GetForm("FormInitGraphemeInventoryTD11");
			if (strText != "")
				this.btnCancel.Text = strText;
            return;
        }

    }
}

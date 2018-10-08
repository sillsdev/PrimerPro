using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PrimerProObjects;
using PrimerProLocalization;
using GenLib;

namespace PrimerProForms
{
    public partial class FormBuildableWordsTD : Form
    {
        private Font m_Font;
        private GraphemeInventory m_GI;
        private string m_Lang;

        private ArrayList m_Graphemes;
        private ArrayList m_Highlights;
        private bool m_ParaFormat;
        private bool m_NoDuplicates;
        
        public FormBuildableWordsTD(GraphemeInventory gi, GraphemeTaughtOrder gto, Font fnt)
        {
            InitializeComponent();
            m_Font = fnt;
            m_GI = gi;

            this.tbGraphemes.Text = this.GetGraphemesTaught(gto);
            this.tbHighlights.Text = "";
            this.chkParaFmt.Checked = false;
            this.chkNoDup.Checked = true;
            this.tbGraphemes.Font = m_Font;
            this.tbHighlights.Font = m_Font;
            m_Lang = "";
        }

        public FormBuildableWordsTD(GraphemeInventory gi, GraphemeTaughtOrder gto, Font fnt, LocalizationTable table, string Lang)
        {
            InitializeComponent();
            m_Font = fnt;
            m_GI = gi;
            m_Lang = Lang;

            this.tbGraphemes.Text = this.GetGraphemesTaught(gto);
            this.tbHighlights.Text = "";
            this.chkParaFmt.Checked = false;
            this.chkNoDup.Checked = true;
            this.tbGraphemes.Font = m_Font;
            this.tbHighlights.Font = m_Font;

            this.UpdateFormForLocalization(table);
        }

        public ArrayList Graphemes
        {
            get { return m_Graphemes; }
        }

        public ArrayList Highlights
        {
            get { return m_Highlights; }
        }

        public bool ParaFormat
        {
            get { return m_ParaFormat; }
        }

        public bool NoDuplicates
        {
            get { return m_NoDuplicates; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string strGrfs = tbGraphemes.Text.Trim();
            string strHlts = tbHighlights.Text.Trim();
            if (strGrfs != "")
            {
                ArrayList alGrfs = null;
                ArrayList alHlts = null;
                alGrfs = Funct.ConvertStringToArrayList(strGrfs, Constants.Space.ToString());
                alHlts = Funct.ConvertStringToArrayList(strHlts, Constants.Space.ToString());
                m_Graphemes = alGrfs;
                m_Highlights = alHlts;
                m_ParaFormat = chkParaFmt.Checked;
                m_NoDuplicates = chkNoDup.Checked;
            }
            else
            {
                m_Graphemes = null;
                m_Highlights = null;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_Graphemes = null;
            m_Highlights = null;
            m_ParaFormat = false;
            m_NoDuplicates = false;
            this.Close();
        }

        private void btnGraphemes_Click(object sender, EventArgs e)
        {
            GraphemeInventory gi = m_GI;
            ArrayList alGI = new ArrayList();
            ArrayList alSelection = new ArrayList();

            for (int i = 0; i < gi.ConsonantCount(); i++)
                alGI.Add(gi.GetConsonant(i).Symbol);
            for (int i = 0; i < gi.VowelCount(); i++)
                alGI.Add(gi.GetVowel(i).Symbol);
            for (int i = 0; i < gi.ToneCount(); i++)
                alGI.Add(gi.GetTone(i).Symbol);
            for (int i = 0; i < gi.SyllographCount(); i++)
                alGI.Add(gi.GetSyllograph(i).Symbol);
            alSelection = Funct.ConvertStringToArrayList(this.tbGraphemes.Text, Constants.Space.ToString());

            if ((m_Lang != "") && (m_Lang == OptionList.kFrench))
            {
                FormItemSelectionFrench form = new FormItemSelectionFrench(alGI, alSelection, labGrapheme.Text, m_Font);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    ArrayList al = form.Selection();
                    string strGraphemes = Funct.ConvertArrayListToString(al, Constants.Space.ToString());
                    this.tbGraphemes.Text = strGraphemes;
                }
            }
            else if ((m_Lang != "") && (m_Lang == OptionList.kSpanish))
            {
                FormItemSelectionSpanish form = new FormItemSelectionSpanish(alGI, alSelection, labGrapheme.Text, m_Font);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    ArrayList al = form.Selection();
                    string strGraphemes = Funct.ConvertArrayListToString(al, Constants.Space.ToString());
                    this.tbGraphemes.Text = strGraphemes;
                }
            }
            else
            {
                FormItemSelection form = new FormItemSelection(alGI, alSelection, labGrapheme.Text, m_Font);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    ArrayList al = form.Selection();
                    string strGraphemes = Funct.ConvertArrayListToString(al, Constants.Space.ToString());
                    this.tbGraphemes.Text = strGraphemes;
                }
            }
        }

        private void btnHighlight_Click(object sender, EventArgs e)
        {
            ArrayList alAvailable = Funct.ConvertStringToArrayList(tbGraphemes.Text, Constants.Space.ToString());
            ArrayList alHighlight = Funct.ConvertStringToArrayList(tbHighlights.Text, Constants.Space.ToString());
            string strSymbol = "";

            // remove underscores
            for (int i = 0; i < alAvailable.Count; i++)
            {
                strSymbol = alAvailable[i].ToString();
                strSymbol = strSymbol.Replace(Syllable.Underscore, "");
                alAvailable[i] = strSymbol;
            }

            if ((m_Lang != "") && (m_Lang == OptionList.kFrench))
            {
                FormItemSelectionFrench form = new FormItemSelectionFrench(alAvailable, alHighlight, labHighlight.Text, m_Font);
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    ArrayList al = form.Selection();
                    this.tbHighlights.Text = Funct.ConvertArrayListToString(al, Constants.Space.ToString());
                }
            }
            else if ((m_Lang != "") && (m_Lang == OptionList.kSpanish))
            {
                FormItemSelectionSpanish form = new FormItemSelectionSpanish(alAvailable, alHighlight, labHighlight.Text, m_Font);
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    ArrayList al = form.Selection();
                    this.tbHighlights.Text = Funct.ConvertArrayListToString(al, Constants.Space.ToString());
                }
            }
            else
            {
                FormItemSelection form = new FormItemSelection(alAvailable, alHighlight, labHighlight.Text, m_Font);
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    ArrayList al = form.Selection();
                    this.tbHighlights.Text = Funct.ConvertArrayListToString(al, Constants.Space.ToString());
                }
            }
        }

        private void chkParaFmt_CheckedChanged(object sender, EventArgs e)
        {
            if (chkParaFmt.Checked)
            {
                tbHighlights.Enabled = false;
                tbHighlights.Text = "";
            }
            else tbHighlights.Enabled = true;
        }

        private void chkNoDup_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNoDup.Checked)
            {
                chkParaFmt.Enabled = false;
                chkParaFmt.Checked = false;
            }
            else chkParaFmt.Enabled = true;
        }

        private string GetGraphemesTaught(GraphemeTaughtOrder gto)
        {
            string strText = "";
            for (int i = 0; i < gto.Count(); i++)
            {
                strText += gto.GetGrapheme(i).Trim() + Constants.Space;
            }
            strText = strText.Trim();
            return strText;
        }

        private void UpdateFormForLocalization(LocalizationTable table)
        {
            string strText = "";
            strText = table.GetForm("FormBuildableWordsTDT");
			if (strText != "")
				this.Text = strText;
            strText = table.GetForm("FormBuildableWordsTD0");
			if (strText != "")
				this.labTitle.Text = strText;
            strText = table.GetForm("FormBuildableWordsTD1");
			if (strText != "")
				this.labGrapheme.Text = strText;
            strText = table.GetForm("FormBuildableWordsTD3");
			if (strText != "")
				this.btnGraphemes.Text = strText;
            strText = table.GetForm("FormBuildableWordsTD4");
			if (strText != "")
				this.labHighlight.Text = strText;
            strText = table.GetForm("FormBuildableWordsTD6");
			if (strText != "")
				this.btnHighlight.Text = strText;
            strText = table.GetForm("FormBuildableWordsTD7");
			if (strText != "")
				this.chkParaFmt.Text = strText;
            //strText = table.GetForm("FormBuildableWordsTD7A");
            //if (strText != "")
            //    this.chkNoDup.Text = strText;
            strText = table.GetForm("FormBuildableWordsTD8");
			if (strText != "")
				this.btnOK.Text = strText;
            strText = table.GetForm("FormBuildableWordsTD9");
			if (strText != "")
				this.btnCancel.Text = strText;
            return;
        }
    }
}
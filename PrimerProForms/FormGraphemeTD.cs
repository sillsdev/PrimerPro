using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GenLib;
using PrimerProObjects;
using PrimerProLocalization;

namespace PrimerProForms
{
    /// <summary>
    /// Summary description for FormGraphemeTD.
    /// </summary>
    public partial class FormGraphemeTD : Form
    {
        //private GraphemeTDSearch m_Search;		//Grapheme Search for Text Data
        //private string m_Grapheme;
        private ArrayList m_Graphemes;
        private bool m_ParaFormat;
        private bool m_UseGraphemesTaught;
        private bool m_NoDuplicates;
        private GraphemeInventory m_GI;
        private string m_Lang;                  //UI language

      
        public FormGraphemeTD(Font font, GraphemeInventory gi)
        {
            InitializeComponent();
            this.chkGraphemesTaught.Checked = false;
            this.chkParaFmt.Checked = false;
            this.chkNoDup.Checked = false;
            this.tbGraphemes.Font = font;
            m_GI = gi; ;
            m_Lang = "";
        }

        public FormGraphemeTD(Font font, GraphemeInventory gi, LocalizationTable table, string lang)
        {
            InitializeComponent();
            this.chkGraphemesTaught.Checked = false;
            this.chkParaFmt.Checked = false;
            this.chkNoDup.Checked = false;
            this.tbGraphemes.Font = font;
            m_GI = gi;
            m_Lang = lang;

            this.UpdateFormForLocalization(table);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        public ArrayList Graphemes
        {
            get { return m_Graphemes; }
        }

        public bool ParaFormat
        {
            get { return m_ParaFormat; }
        }

        public bool UseGraphemesTaught
        {
            get { return m_UseGraphemesTaught; }
        }

        public bool NoDuplicates
        {
            get { return m_NoDuplicates; }
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
                FormItemSelectionFrench form = new FormItemSelectionFrench(alGI, alSelection, labGraphemes.Text, tbGraphemes.Font);
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
                FormItemSelectionSpanish form = new FormItemSelectionSpanish(alGI, alSelection, labGraphemes.Text, tbGraphemes.Font);
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
                FormItemSelection form = new FormItemSelection(alGI, alSelection, labGraphemes.Text, tbGraphemes.Font);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    ArrayList al = form.Selection();
                    string strGraphemes = Funct.ConvertArrayListToString(al, Constants.Space.ToString());
                    this.tbGraphemes.Text = strGraphemes;
                }
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string strGrfs = tbGraphemes.Text.Trim();
            if (strGrfs != "")
            {
                m_Graphemes = Funct.ConvertStringToArrayList(strGrfs, Constants.Space.ToString()); ;
                m_ParaFormat = chkParaFmt.Checked;
                m_UseGraphemesTaught = chkGraphemesTaught.Checked;
                m_NoDuplicates = chkNoDup.Checked;
            }
            else
            {
                m_Graphemes = null;
                m_ParaFormat = false;
                m_UseGraphemesTaught = false;
                m_NoDuplicates = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_Graphemes = null; ;
            m_ParaFormat = false;
            m_UseGraphemesTaught = false;
            m_NoDuplicates = false;
            this.Close();
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

        private void UpdateFormForLocalization(LocalizationTable table)
        {
            string strText = "";
            strText = table.GetForm("FormGraphemeTDT");
			if (strText != "")
				this.Text = strText;
            strText = table.GetForm("FormGraphemeTD0");
			if (strText != "")
				this.labGraphemes.Text = strText;
            strText = table.GetForm("FormGraphemeTD2");
			if (strText != "")
				this.chkParaFmt.Text = strText;
            strText = table.GetForm("FormGraphemeTD4");
			if (strText != "")
				this.chkGraphemesTaught.Text = strText;
            strText = table.GetForm("FormGraphemeTD5");
			if (strText != "")
				this.chkNoDup.Text = strText;
            strText = table.GetForm("FormGraphemeTD6");
			if (strText != "")
				this.btnOK.Text = strText;
            strText = table.GetForm("FormGraphemeTD7");
			if (strText != "")
				this.btnCancel.Text = strText;
            return;
        }
    }
}
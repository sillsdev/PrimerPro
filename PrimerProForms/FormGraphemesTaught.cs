using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using PrimerProObjects;
using PrimerProLocalization;

namespace PrimerProForms
{
    public partial class FormGraphemesTaught : Form
    {
        //private Settings m_Settings;
        private GraphemeTaughtOrder m_GraphemesTaught;

        public FormGraphemesTaught(GraphemeTaughtOrder gto, Font fnt)
        {
            InitializeComponent();
            //m_Settings = s;
            m_GraphemesTaught = gto;
            // Add taught graphemes to text box
            ArrayList al = m_GraphemesTaught.Graphemes;
            tbGraphemes.Text = "";
            for (int i = 0; i < al.Count; i++)
            {
                tbGraphemes.Text += (string) al[i] + Environment.NewLine;
            }
            tbGraphemes.Font = fnt;
            tbGraphemes.SelectionStart = tbGraphemes.Text.Length;
            tbGraphemes.SelectionLength = 0;
        }

        public FormGraphemesTaught(GraphemeTaughtOrder gto, Font fnt, LocalizationTable table, string lang)
        {
            InitializeComponent();
            //m_Settings = s;
            m_GraphemesTaught = gto;
            // Add taught graphemes to text box
            ArrayList al = m_GraphemesTaught.Graphemes;
            tbGraphemes.Text = "";
            for (int i = 0; i < al.Count; i++)
            {
                tbGraphemes.Text += (string)al[i] + Environment.NewLine;
            }
            tbGraphemes.Font = fnt;
            tbGraphemes.SelectionStart = tbGraphemes.Text.Length;
            tbGraphemes.SelectionLength = 0;

            this.Text = table.GetForm("FormGraphemesTaughtT", lang);
            this.labTitle.Text = table.GetForm("FormGraphemesTaught0", lang);
            this.btnOK.Text = table.GetForm("FormGraphemesTaught2", lang);
            this.btnCancel.Text = table.GetForm("FormGraphemesTaught3", lang);
        }

        public GraphemeTaughtOrder GraphemesTaught
        {
            get { return m_GraphemesTaught; }
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {

            string strText = tbGraphemes.Text;
            string strItem = "";
            string nl = Environment.NewLine;
            int nBeg = 0;
            int nEnd = 0;
            ArrayList al = null;

            al = new ArrayList();
            do
            {
                nEnd = strText.IndexOf(nl, nBeg);
                if (nEnd < 0)
                    nEnd = strText.Length;
                strItem = strText.Substring(nBeg, nEnd - nBeg);
                if (strItem.Trim() != "")
                    al.Add(strItem);
                nBeg = nEnd + nl.Length;
            }
            while (nBeg < strText.Length);
            m_GraphemesTaught.Graphemes = al;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
        }

    }
}
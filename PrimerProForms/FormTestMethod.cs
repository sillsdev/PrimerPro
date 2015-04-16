using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PrimerProForms
{
    public partial class FormTestMethod : Form
    {
        private string m_Parm1;
        private string m_Parm2;
        private string m_Parm3;
        private string m_Parm4;

        public FormTestMethod()
        {
            InitializeComponent();
        }

        public string Parm1
        {
            get { return m_Parm1; }
        }

        public string Parm2
        {
            get { return m_Parm2; }
        }

        public string Parm3
        {
            get { return m_Parm3; }
        }

        public string Parm4
        {
            get { return m_Parm4; }
        }

        public void Reset()
        {
            tbParm1.Text = "";
            tbParm2.Text = "";
            tbParm3.Text = "";
            tbParm4.Text = "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            m_Parm1 = tbParm1.Text;
            m_Parm2 = tbParm2.Text;
            m_Parm3 = tbParm3.Text;
            m_Parm4 = tbParm4.Text;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
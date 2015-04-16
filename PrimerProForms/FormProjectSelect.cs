using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PrimerProForms
{
    public partial class FormProjectSelect : Form
    {
        private string m_SelectedProject;

        public FormProjectSelect(ArrayList al, Font fnt)
        {
            InitializeComponent();
            this.lbProjects.Font = fnt;
            for (int i = 0; i < al.Count; i++)
            {
                this.lbProjects.Items.Add(al[i]);
            }
            m_SelectedProject = "";
        }

        public string SelectedProject
        {
            get { return m_SelectedProject; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int i = this.lbProjects.SelectedIndex;
            if (i >= 0)
                m_SelectedProject = this.lbProjects.Items[i].ToString();
            else m_SelectedProject = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_SelectedProject = "";
        }
    }
}

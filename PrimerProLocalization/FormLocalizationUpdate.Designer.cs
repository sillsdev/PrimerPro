namespace PrimerProLocalization
{
    partial class FormLocalizationUpdate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLocalizationUpdate));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabPage = new System.Windows.Forms.TabControl();
            this.tabPageMenu = new System.Windows.Forms.TabPage();
            this.dgvMenu = new System.Windows.Forms.DataGridView();
            this.colMenuIdn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMenuIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMenuEnglish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMenuOther = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageForm = new System.Windows.Forms.TabPage();
            this.dgvForm = new System.Windows.Forms.DataGridView();
            this.colFormIdn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFormIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFromEnglish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFormOther = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageText = new System.Windows.Forms.TabPage();
            this.dgvText = new System.Windows.Forms.DataGridView();
            this.ColTextIdn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTextIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTextEnglish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTextOther = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOptionsOK = new System.Windows.Forms.Button();
            this.btnOptionsCancel = new System.Windows.Forms.Button();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.tabPage.SuspendLayout();
            this.tabPageMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).BeginInit();
            this.tabPageForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForm)).BeginInit();
            this.tabPageText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvText)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage
            // 
            this.tabPage.Controls.Add(this.tabPageMenu);
            this.tabPage.Controls.Add(this.tabPageForm);
            this.tabPage.Controls.Add(this.tabPageText);
            resources.ApplyResources(this.tabPage, "tabPage");
            this.tabPage.Name = "tabPage";
            this.tabPage.SelectedIndex = 0;
            // 
            // tabPageMenu
            // 
            this.tabPageMenu.Controls.Add(this.dgvMenu);
            resources.ApplyResources(this.tabPageMenu, "tabPageMenu");
            this.tabPageMenu.Name = "tabPageMenu";
            this.tabPageMenu.UseVisualStyleBackColor = true;
            // 
            // dgvMenu
            // 
            this.dgvMenu.AllowUserToAddRows = false;
            this.dgvMenu.AllowUserToDeleteRows = false;
            this.dgvMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMenu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMenuIdn,
            this.colMenuIndex,
            this.colMenuEnglish,
            this.colMenuOther});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMenu.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.dgvMenu, "dgvMenu");
            this.dgvMenu.MultiSelect = false;
            this.dgvMenu.Name = "dgvMenu";
            this.dgvMenu.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMenu.RowsDefaultCellStyle = dataGridViewCellStyle2;
            // 
            // colMenuIdn
            // 
            this.colMenuIdn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colMenuIdn.Frozen = true;
            resources.ApplyResources(this.colMenuIdn, "colMenuIdn");
            this.colMenuIdn.Name = "colMenuIdn";
            this.colMenuIdn.ReadOnly = true;
            this.colMenuIdn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colMenuIndex
            // 
            this.colMenuIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            resources.ApplyResources(this.colMenuIndex, "colMenuIndex");
            this.colMenuIndex.Name = "colMenuIndex";
            this.colMenuIndex.ReadOnly = true;
            this.colMenuIndex.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colMenuEnglish
            // 
            resources.ApplyResources(this.colMenuEnglish, "colMenuEnglish");
            this.colMenuEnglish.Name = "colMenuEnglish";
            this.colMenuEnglish.ReadOnly = true;
            // 
            // colMenuOther
            // 
            resources.ApplyResources(this.colMenuOther, "colMenuOther");
            this.colMenuOther.Name = "colMenuOther";
            // 
            // tabPageForm
            // 
            this.tabPageForm.Controls.Add(this.dgvForm);
            resources.ApplyResources(this.tabPageForm, "tabPageForm");
            this.tabPageForm.Name = "tabPageForm";
            this.tabPageForm.UseVisualStyleBackColor = true;
            // 
            // dgvForm
            // 
            this.dgvForm.AllowUserToAddRows = false;
            this.dgvForm.AllowUserToDeleteRows = false;
            this.dgvForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvForm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFormIdn,
            this.colFormIndex,
            this.colFromEnglish,
            this.colFormOther});
            resources.ApplyResources(this.dgvForm, "dgvForm");
            this.dgvForm.Name = "dgvForm";
            this.dgvForm.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvForm.RowsDefaultCellStyle = dataGridViewCellStyle3;
            // 
            // colFormIdn
            // 
            this.colFormIdn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            resources.ApplyResources(this.colFormIdn, "colFormIdn");
            this.colFormIdn.Name = "colFormIdn";
            this.colFormIdn.ReadOnly = true;
            this.colFormIdn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colFormIndex
            // 
            this.colFormIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            resources.ApplyResources(this.colFormIndex, "colFormIndex");
            this.colFormIndex.Name = "colFormIndex";
            this.colFormIndex.ReadOnly = true;
            this.colFormIndex.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colFromEnglish
            // 
            resources.ApplyResources(this.colFromEnglish, "colFromEnglish");
            this.colFromEnglish.Name = "colFromEnglish";
            this.colFromEnglish.ReadOnly = true;
            // 
            // colFormOther
            // 
            resources.ApplyResources(this.colFormOther, "colFormOther");
            this.colFormOther.Name = "colFormOther";
            // 
            // tabPageText
            // 
            this.tabPageText.Controls.Add(this.dgvText);
            resources.ApplyResources(this.tabPageText, "tabPageText");
            this.tabPageText.Name = "tabPageText";
            this.tabPageText.UseVisualStyleBackColor = true;
            // 
            // dgvText
            // 
            this.dgvText.AllowUserToAddRows = false;
            this.dgvText.AllowUserToDeleteRows = false;
            this.dgvText.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvText.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColTextIdn,
            this.colTextIndex,
            this.ColTextEnglish,
            this.ColTextOther});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvText.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.dgvText, "dgvText");
            this.dgvText.MultiSelect = false;
            this.dgvText.Name = "dgvText";
            this.dgvText.RowHeadersVisible = false;
            this.dgvText.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvText.TabStop = false;
            // 
            // ColTextIdn
            // 
            this.ColTextIdn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ColTextIdn.FillWeight = 50F;
            resources.ApplyResources(this.ColTextIdn, "ColTextIdn");
            this.ColTextIdn.Name = "ColTextIdn";
            this.ColTextIdn.ReadOnly = true;
            this.ColTextIdn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colTextIndex
            // 
            this.colTextIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            resources.ApplyResources(this.colTextIndex, "colTextIndex");
            this.colTextIndex.Name = "colTextIndex";
            this.colTextIndex.ReadOnly = true;
            this.colTextIndex.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ColTextEnglish
            // 
            resources.ApplyResources(this.ColTextEnglish, "ColTextEnglish");
            this.ColTextEnglish.Name = "ColTextEnglish";
            this.ColTextEnglish.ReadOnly = true;
            // 
            // ColTextOther
            // 
            resources.ApplyResources(this.ColTextOther, "ColTextOther");
            this.ColTextOther.Name = "ColTextOther";
            // 
            // btnOptionsOK
            // 
            this.btnOptionsOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnOptionsOK, "btnOptionsOK");
            this.btnOptionsOK.Name = "btnOptionsOK";
            this.btnOptionsOK.Click += new System.EventHandler(this.btnOptionsOK_Click);
            // 
            // btnOptionsCancel
            // 
            this.btnOptionsCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnOptionsCancel, "btnOptionsCancel");
            this.btnOptionsCancel.Name = "btnOptionsCancel";
            this.btnOptionsCancel.Click += new System.EventHandler(this.btnOptionsCancel_Click);
            // 
            // lblInstructions
            // 
            resources.ApplyResources(this.lblInstructions, "lblInstructions");
            this.lblInstructions.Name = "lblInstructions";
            // 
            // FormLocalizationUpdate
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.btnOptionsCancel);
            this.Controls.Add(this.btnOptionsOK);
            this.Controls.Add(this.tabPage);
            this.Name = "FormLocalizationUpdate";
            this.tabPage.ResumeLayout(false);
            this.tabPageMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).EndInit();
            this.tabPageForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvForm)).EndInit();
            this.tabPageText.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvText)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabPage;
        private System.Windows.Forms.TabPage tabPageMenu;
        private System.Windows.Forms.TabPage tabPageForm;
        private System.Windows.Forms.TabPage tabPageText;
        private System.Windows.Forms.DataGridView dgvText;
        private System.Windows.Forms.Button btnOptionsOK;
        private System.Windows.Forms.Button btnOptionsCancel;
        private System.Windows.Forms.DataGridView dgvMenu;
        private System.Windows.Forms.DataGridView dgvForm;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMenuIdn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMenuIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMenuEnglish;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMenuOther;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFormIdn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFormIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFromEnglish;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFormOther;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTextIdn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTextIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTextEnglish;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTextOther;
    }
}
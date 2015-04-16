namespace PrimerProObjects
{
    partial class FormMergeAskMe
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
            this.labOrigWord = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.labNewWord = new System.Windows.Forms.Label();
            this.labWord = new System.Windows.Forms.Label();
            this.labGloss = new System.Windows.Forms.Label();
            this.labPoS = new System.Windows.Forms.Label();
            this.labPlural = new System.Windows.Forms.Label();
            this.labRoot = new System.Windows.Forms.Label();
            this.tbOWord = new System.Windows.Forms.TextBox();
            this.tbNWord = new System.Windows.Forms.TextBox();
            this.tbOGloss = new System.Windows.Forms.TextBox();
            this.tbOPoS = new System.Windows.Forms.TextBox();
            this.tbORoot = new System.Windows.Forms.TextBox();
            this.tbOPlural = new System.Windows.Forms.TextBox();
            this.tbNGloss = new System.Windows.Forms.TextBox();
            this.tbNPoS = new System.Windows.Forms.TextBox();
            this.tbNRoot = new System.Windows.Forms.TextBox();
            this.tbNPlural = new System.Windows.Forms.TextBox();
            this.rbKeep = new System.Windows.Forms.RadioButton();
            this.rbReplace = new System.Windows.Forms.RadioButton();
            this.rbBoth = new System.Windows.Forms.RadioButton();
            this.gbAsk = new System.Windows.Forms.GroupBox();
            this.labInfo = new System.Windows.Forms.Label();
            this.gbAsk.SuspendLayout();
            this.SuspendLayout();
            // 
            // labOrigWord
            // 
            this.labOrigWord.AutoSize = true;
            this.labOrigWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labOrigWord.Location = new System.Drawing.Point(183, 42);
            this.labOrigWord.Name = "labOrigWord";
            this.labOrigWord.Size = new System.Drawing.Size(95, 18);
            this.labOrigWord.TabIndex = 1;
            this.labOrigWord.Text = "Original word";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(156, 296);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 19;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(331, 296);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labNewWord
            // 
            this.labNewWord.AutoSize = true;
            this.labNewWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labNewWord.Location = new System.Drawing.Point(357, 42);
            this.labNewWord.Name = "labNewWord";
            this.labNewWord.Size = new System.Drawing.Size(106, 18);
            this.labNewWord.TabIndex = 2;
            this.labNewWord.Text = "Duplicate word";
            // 
            // labWord
            // 
            this.labWord.AutoSize = true;
            this.labWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labWord.Location = new System.Drawing.Point(12, 70);
            this.labWord.Name = "labWord";
            this.labWord.Size = new System.Drawing.Size(130, 18);
            this.labWord.TabIndex = 3;
            this.labWord.Text = "Word transcription";
            // 
            // labGloss
            // 
            this.labGloss.AutoSize = true;
            this.labGloss.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labGloss.Location = new System.Drawing.Point(12, 99);
            this.labGloss.Name = "labGloss";
            this.labGloss.Size = new System.Drawing.Size(48, 18);
            this.labGloss.TabIndex = 6;
            this.labGloss.Text = "Gloss";
            // 
            // labPoS
            // 
            this.labPoS.AutoSize = true;
            this.labPoS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labPoS.Location = new System.Drawing.Point(12, 127);
            this.labPoS.Name = "labPoS";
            this.labPoS.Size = new System.Drawing.Size(104, 18);
            this.labPoS.TabIndex = 9;
            this.labPoS.Text = "Part of speech";
            // 
            // labPlural
            // 
            this.labPlural.AutoSize = true;
            this.labPlural.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labPlural.Location = new System.Drawing.Point(12, 183);
            this.labPlural.Name = "labPlural";
            this.labPlural.Size = new System.Drawing.Size(45, 18);
            this.labPlural.TabIndex = 15;
            this.labPlural.Text = "Plural";
            // 
            // labRoot
            // 
            this.labRoot.AutoSize = true;
            this.labRoot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labRoot.Location = new System.Drawing.Point(12, 155);
            this.labRoot.Name = "labRoot";
            this.labRoot.Size = new System.Drawing.Size(41, 18);
            this.labRoot.TabIndex = 12;
            this.labRoot.Text = "Root";
            // 
            // tbOWord
            // 
            this.tbOWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOWord.Location = new System.Drawing.Point(156, 71);
            this.tbOWord.Name = "tbOWord";
            this.tbOWord.ReadOnly = true;
            this.tbOWord.Size = new System.Drawing.Size(157, 24);
            this.tbOWord.TabIndex = 4;
            // 
            // tbNWord
            // 
            this.tbNWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNWord.Location = new System.Drawing.Point(331, 71);
            this.tbNWord.Name = "tbNWord";
            this.tbNWord.ReadOnly = true;
            this.tbNWord.Size = new System.Drawing.Size(157, 24);
            this.tbNWord.TabIndex = 5;
            // 
            // tbOGloss
            // 
            this.tbOGloss.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOGloss.Location = new System.Drawing.Point(156, 99);
            this.tbOGloss.Name = "tbOGloss";
            this.tbOGloss.ReadOnly = true;
            this.tbOGloss.Size = new System.Drawing.Size(157, 24);
            this.tbOGloss.TabIndex = 7;
            // 
            // tbOPoS
            // 
            this.tbOPoS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOPoS.Location = new System.Drawing.Point(156, 127);
            this.tbOPoS.Name = "tbOPoS";
            this.tbOPoS.ReadOnly = true;
            this.tbOPoS.Size = new System.Drawing.Size(157, 24);
            this.tbOPoS.TabIndex = 10;
            // 
            // tbORoot
            // 
            this.tbORoot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbORoot.Location = new System.Drawing.Point(156, 155);
            this.tbORoot.Name = "tbORoot";
            this.tbORoot.ReadOnly = true;
            this.tbORoot.Size = new System.Drawing.Size(157, 24);
            this.tbORoot.TabIndex = 13;
            // 
            // tbOPlural
            // 
            this.tbOPlural.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOPlural.Location = new System.Drawing.Point(156, 183);
            this.tbOPlural.Name = "tbOPlural";
            this.tbOPlural.ReadOnly = true;
            this.tbOPlural.Size = new System.Drawing.Size(157, 24);
            this.tbOPlural.TabIndex = 16;
            // 
            // tbNGloss
            // 
            this.tbNGloss.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNGloss.Location = new System.Drawing.Point(331, 99);
            this.tbNGloss.Name = "tbNGloss";
            this.tbNGloss.ReadOnly = true;
            this.tbNGloss.Size = new System.Drawing.Size(157, 24);
            this.tbNGloss.TabIndex = 8;
            // 
            // tbNPoS
            // 
            this.tbNPoS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNPoS.Location = new System.Drawing.Point(331, 127);
            this.tbNPoS.Name = "tbNPoS";
            this.tbNPoS.ReadOnly = true;
            this.tbNPoS.Size = new System.Drawing.Size(157, 24);
            this.tbNPoS.TabIndex = 11;
            // 
            // tbNRoot
            // 
            this.tbNRoot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNRoot.Location = new System.Drawing.Point(331, 155);
            this.tbNRoot.Name = "tbNRoot";
            this.tbNRoot.ReadOnly = true;
            this.tbNRoot.Size = new System.Drawing.Size(157, 24);
            this.tbNRoot.TabIndex = 14;
            // 
            // tbNPlural
            // 
            this.tbNPlural.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNPlural.Location = new System.Drawing.Point(331, 183);
            this.tbNPlural.Name = "tbNPlural";
            this.tbNPlural.ReadOnly = true;
            this.tbNPlural.Size = new System.Drawing.Size(157, 24);
            this.tbNPlural.TabIndex = 17;
            // 
            // rbKeep
            // 
            this.rbKeep.AutoSize = true;
            this.rbKeep.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbKeep.Location = new System.Drawing.Point(10, 25);
            this.rbKeep.Name = "rbKeep";
            this.rbKeep.Size = new System.Drawing.Size(114, 22);
            this.rbKeep.TabIndex = 0;
            this.rbKeep.TabStop = true;
            this.rbKeep.Text = "&Keep original";
            this.rbKeep.UseVisualStyleBackColor = true;
            // 
            // rbReplace
            // 
            this.rbReplace.AutoSize = true;
            this.rbReplace.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbReplace.Location = new System.Drawing.Point(180, 25);
            this.rbReplace.Name = "rbReplace";
            this.rbReplace.Size = new System.Drawing.Size(134, 22);
            this.rbReplace.TabIndex = 1;
            this.rbReplace.TabStop = true;
            this.rbReplace.Text = "&Replace original";
            this.rbReplace.UseVisualStyleBackColor = true;
            // 
            // rbBoth
            // 
            this.rbBoth.AutoSize = true;
            this.rbBoth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBoth.Location = new System.Drawing.Point(350, 25);
            this.rbBoth.Name = "rbBoth";
            this.rbBoth.Size = new System.Drawing.Size(96, 22);
            this.rbBoth.TabIndex = 2;
            this.rbBoth.TabStop = true;
            this.rbBoth.Text = "Keep &both";
            this.rbBoth.UseVisualStyleBackColor = true;
            // 
            // gbAsk
            // 
            this.gbAsk.Controls.Add(this.rbBoth);
            this.gbAsk.Controls.Add(this.rbKeep);
            this.gbAsk.Controls.Add(this.rbReplace);
            this.gbAsk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAsk.Location = new System.Drawing.Point(15, 216);
            this.gbAsk.Name = "gbAsk";
            this.gbAsk.Size = new System.Drawing.Size(520, 64);
            this.gbAsk.TabIndex = 18;
            this.gbAsk.TabStop = false;
            // 
            // labInfo
            // 
            this.labInfo.AutoSize = true;
            this.labInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfo.Location = new System.Drawing.Point(153, 9);
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(323, 20);
            this.labInfo.TabIndex = 0;
            this.labInfo.Text = "This is a duplicate entry (same word)";
            this.labInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormMergeAskMe
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(550, 339);
            this.Controls.Add(this.labInfo);
            this.Controls.Add(this.tbNPlural);
            this.Controls.Add(this.tbNRoot);
            this.Controls.Add(this.tbNPoS);
            this.Controls.Add(this.tbNGloss);
            this.Controls.Add(this.tbOPlural);
            this.Controls.Add(this.tbORoot);
            this.Controls.Add(this.tbOPoS);
            this.Controls.Add(this.tbOGloss);
            this.Controls.Add(this.tbNWord);
            this.Controls.Add(this.tbOWord);
            this.Controls.Add(this.labRoot);
            this.Controls.Add(this.labPlural);
            this.Controls.Add(this.labPoS);
            this.Controls.Add(this.labGloss);
            this.Controls.Add(this.labWord);
            this.Controls.Add(this.labNewWord);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labOrigWord);
            this.Controls.Add(this.gbAsk);
            this.Name = "FormMergeAskMe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Merge Word List - Ask Me Option";
            this.gbAsk.ResumeLayout(false);
            this.gbAsk.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labOrigWord;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label labNewWord;
        private System.Windows.Forms.Label labWord;
        private System.Windows.Forms.Label labGloss;
        private System.Windows.Forms.Label labPoS;
        private System.Windows.Forms.Label labPlural;
        private System.Windows.Forms.Label labRoot;
        private System.Windows.Forms.TextBox tbOWord;
        private System.Windows.Forms.TextBox tbNWord;
        private System.Windows.Forms.TextBox tbOGloss;
        private System.Windows.Forms.TextBox tbOPoS;
        private System.Windows.Forms.TextBox tbORoot;
        private System.Windows.Forms.TextBox tbOPlural;
        private System.Windows.Forms.TextBox tbNGloss;
        private System.Windows.Forms.TextBox tbNPoS;
        private System.Windows.Forms.TextBox tbNRoot;
        private System.Windows.Forms.TextBox tbNPlural;
        private System.Windows.Forms.RadioButton rbKeep;
        private System.Windows.Forms.RadioButton rbReplace;
        private System.Windows.Forms.RadioButton rbBoth;
        private System.Windows.Forms.GroupBox gbAsk;
        private System.Windows.Forms.Label labInfo;
    }
}
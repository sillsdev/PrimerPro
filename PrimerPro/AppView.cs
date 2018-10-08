using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using PrimerProObjects;
using PrimerProSearch;
using GenLib;

namespace PrimerPro
{
	/// <summary>
	/// Summary description for PrimerProView.
	/// </summary>
	public class AppView : System.Windows.Forms.Form
	{
		private AppWindow win;							//Application window
		private Settings m_Settings;
		private System.Windows.Forms.RichTextBox m_Rtb; //Rich text Box for file
		private string m_Filename;						//Name of file associated with view
        private string m_FindText;						//Current Find Text
		private System.Windows.Forms.MenuItem menuExamplesWL;
		private System.Windows.Forms.MenuItem menuExamplesTD;
		private System.Windows.Forms.ContextMenu contextMenuRTB;

        //private const string kReady = "...Ready...";
        //private const string kFormatWL = "Formatting Word List";
        //private const string kFormatTD = "Formatting Text data";
        public const int kBlockLines = 100;
        public const int kTextLength = 10000;
 
        /// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AppView(AppWindow pWindow, string strFileName)
		{
			//
			// strFileName - rtf file to be associated with view
			//
			InitializeComponent();
			win = pWindow;
			m_Settings = win.Settings;
			m_FindText = "";
            this.UpdateMenu();
			
            if (strFileName != "")
			{
				m_Filename = strFileName;
				if (strFileName.EndsWith("rtf"))
				{
					m_Rtb.LoadFile(strFileName,RichTextBoxStreamType.RichText);
				}
				else
				{
					m_Rtb.LoadFile(strFileName,RichTextBoxStreamType.PlainText);
				}
			}
			else m_Filename = "";
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppView));
            this.m_Rtb = new System.Windows.Forms.RichTextBox();
            this.contextMenuRTB = new System.Windows.Forms.ContextMenu();
            this.menuExamplesWL = new System.Windows.Forms.MenuItem();
            this.menuExamplesTD = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // m_Rtb
            // 
            this.m_Rtb.ContextMenu = this.contextMenuRTB;
            this.m_Rtb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_Rtb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_Rtb.Location = new System.Drawing.Point(0, 0);
            this.m_Rtb.Name = "m_Rtb";
            this.m_Rtb.Size = new System.Drawing.Size(582, 353);
            this.m_Rtb.TabIndex = 0;
            this.m_Rtb.Text = "";
            this.m_Rtb.WordWrap = false;
            // 
            // contextMenuRTB
            // 
            this.contextMenuRTB.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuExamplesWL,
            this.menuExamplesTD});
            // 
            // menuExamplesWL
            // 
            this.menuExamplesWL.Index = 0;
            this.menuExamplesWL.Text = "View Examples from Word List";
            this.menuExamplesWL.Click += new System.EventHandler(this.menuExamplesWL_Click);
            // 
            // menuExamplesTD
            // 
            this.menuExamplesTD.Index = 1;
            this.menuExamplesTD.Text = "View Examples from Text Data";
            this.menuExamplesTD.Click += new System.EventHandler(this.menuExamplesTD_Click);
            // 
            // AppView
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(582, 353);
            this.Controls.Add(this.m_Rtb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AppView";
            this.Text = "AppView";
            this.Activated += new System.EventHandler(this.AppView_Activated);
            this.Deactivate += new System.EventHandler(this.AppView_Deactivate);
            this.ResumeLayout(false);

		}
		#endregion

		public RichTextBox Rtb
		{
			get {return m_Rtb;}
			set {m_Rtb = value;}
		}

		public string FileName
		{
			get {return m_Filename;}
			set {m_Filename = value;}
		}

		public string FindText
		{
			get {return m_FindText;}
			set {m_FindText = value;}
		}

		public void SaveFile(string strFileName)
		{
			try
			{
				m_Rtb.SaveFile(strFileName);
			}

			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		public void Display(string strRtf)
		{
			int start;
			if (strRtf != "" )
			{
				start = m_Rtb.SelectionStart;
				m_Rtb.SelectedRtf = strRtf;
				m_Rtb.WordWrap = win.mnFormatWrap.Checked;
			}
			m_Rtb.Show();
		}

        public Font GetFont()
        {
            string strFont = win.Settings.OptionSettings.DefaultFontName;
            float emSize = win.Settings.OptionSettings.DefaultFontSize;
            FontStyle style = win.Settings.OptionSettings.DefaultFontStyle;
            Font fnt = new Font(strFont, emSize, style);
            return fnt;
        }

        public string FormatAsRtf(string strText)
		{
			string strRtf = "";
			RichTextBox rtb = new RichTextBox();

			rtb.Clear();
			rtb.Text = strText;
			rtb.SelectAll();
			rtb.SelectionAlignment = HorizontalAlignment.Left;
			rtb.SelectionFont = GetFont();
			strRtf = rtb.Rtf;
			return strRtf;
		}

		public string FormatText(string strText, bool fHighlight)
		{
			string strRtf = "";
            //int[] nTabs = new int[8] { 96, 192, 288, 384, 480 ,576, 672, 768 };
            RichTextBox rtb = new RichTextBox();

			rtb.Clear();
            rtb.Text = strText;
            rtb.SelectAll();
			rtb.SelectionAlignment = HorizontalAlignment.Left;
           	rtb.SelectionFont = GetFont();
            //rtb.SelectionTabs = nTabs;
            //rtb.SelectedText = strText;
            if (fHighlight)
			    rtb = this.FormatHighlightColor(rtb);
            strRtf = rtb.Rtf;
           	return strRtf;
		}

        public String FormatText(ArrayList alText)
        {
            string strRtf = "";
            string strText = "";
            //string strCaption = "Formatting Text Data"; 
            string strCaption = m_Settings.LocalizationTable.GetMessage("AppView9");
            if (strCaption == "")
                strCaption = "Formatting Text Data";
            FormProgressBar form = new FormProgressBar(strCaption);

            if (alText.Count < AppView.kBlockLines)
            {
                for (int i = 0; i < alText.Count; i++)
                    strText += alText[i] + Environment.NewLine;
                strRtf = this.FormatText(strText, true);
            }
            else
            {
                form.PB_Init(0,alText.Count);
                int k = 0;
                while ((k + AppView.kBlockLines) < alText.Count)
                {
                    strText = "";
                    for (int i = k; i < (k + AppView.kBlockLines); i++)
                        strText += alText[i] + Environment.NewLine;
                    strRtf = this.FormatText(strText, true);
                    this.Display(strRtf);
                    k = k + AppView.kBlockLines;
                    form.PB_Update(k);
                }
                strText = "";
                for (int i = k; i < alText.Count; i++)
                    strText += alText[i] + Environment.NewLine;
                strRtf = this.FormatText(strText, true);
            }

            form.Close();
            return strRtf;
        }

        public string FormatWordList(ArrayList alText)
        {
            string strRtf = "";
            string strText = "";
            //string strCaption = "Formatting Word List"; 
            string strCaption = m_Settings.LocalizationTable.GetMessage("AppView8");
            if (strCaption == "")
                strCaption = "Formatting Word List";
            FormProgressBar form = new FormProgressBar(strCaption);
            
            if (alText.Count < AppView.kBlockLines)
            {
                for (int i = 0; i < alText.Count;  i++)
                    strText += alText[i] + Environment.NewLine;
                strRtf = this.FormatWordList(strText);
            }
            else
            {
                form.PB_Init(0, alText.Count);
                int k = 0;

                while ( (k + AppView.kBlockLines) < alText.Count)
                {
                    strText = "";
                    for (int  i = k; i < (k + AppView.kBlockLines); i++)
                        strText += alText[i] + Environment.NewLine;
                    strRtf = this.FormatWordList(strText);
                    this.Display(strRtf);
                    k = k + AppView.kBlockLines;
                    form.PB_Update(k);
                }
                strText = "";
                for (int i = k; i < alText.Count; i++)
                    strText += alText[i] + Environment.NewLine;
                strRtf = this.FormatWordList(strText);
            }
            form.Close();
            return strRtf;
        }
        
        public string FormatWordList(string strText)
		{
 			string strRtf = "";
			RichTextBox rtb = new RichTextBox();
			int[] nTabs = new int[7] {240, 480, 720, 960, 1200, 1440, 1680};

			rtb.Clear();
			rtb.Text = strText;
			rtb.SelectAll();
			rtb.SelectionAlignment = HorizontalAlignment.Left;
			rtb.SelectionFont = GetFont();
			rtb.SelectionTabs = nTabs;
			rtb = this.FormatHighlightColor(rtb);

			strRtf = rtb.Rtf;
			return strRtf;
		}

        public string FormatChart(string strText)
        {
            string strRtf = "";
            //string strCaption = "Formatting Chart"; 
            string strCaption = m_Settings.LocalizationTable.GetMessage("AppView14");
            if (strCaption == "")
                strCaption = "Formatting Chart";
            RichTextBox rtb = new RichTextBox();

            // Calculate number of  tabsets required
            ArrayList al = new ArrayList();
            string strLine = "";
            int kount = 0;
            int[] nTabs = new int[1] {144};
            ArrayList alLines = Funct.ConvertStringToArrayList(strText, Constants.CRLF);
            for (int i = 0; i < alLines.Count; i++)
            {
                strLine = (string) alLines[i];
                al = Funct.ConvertStringToArrayList(strLine, Constants.Tab);
                if (kount < al.Count)
                    kount = al.Count;
            }
            if (kount > 32)         // max limit is 32
                kount = 32;
            if (kount > 1)
            {
                nTabs = new int[kount];
                for (int i = 0; i < kount; i++)
                   nTabs[i]= 144+(72*i);
            }
                       
            //int[] nTabs = new int[28] {144, 216, 288, 360, 432, 504, 576, 648, 720,
            //                               792, 864, 936, 1008, 1080, 1152, 1224, 1296, 1368, 1440,
            //                               1512,1584,1656, 1728, 1800, 1872, 1944, 2016, 2088};
            
            rtb.Clear();
            rtb.Text = strText;
            rtb.SelectAll();
            rtb.SelectionAlignment = HorizontalAlignment.Left;
            rtb.SelectionFont = GetFont();
            rtb.SelectionTabs = nTabs;

            // If text is large, use a progress bar
            if (rtb.TextLength > kTextLength)
                rtb = this.FormatHighlightColor(rtb, strCaption);
            else rtb = this.FormatHighlightColor(rtb);

            strRtf = rtb.Rtf;
            return strRtf;
        }

        public string FormatGraphemes(string strText)
		{
			string strRtf = "";
			RichTextBox rtb = new RichTextBox();
		
			rtb.Clear();
			rtb.Text = strText;
			rtb.SelectAll();
			rtb.SelectionAlignment = HorizontalAlignment.Left;
			rtb.SelectionFont = GetFont();
			strRtf = rtb.Rtf;
			return strRtf;
		}

		public string FormatSortedTable(SortedList sl, string strHeader)
		{
			string strLine = "";
			string strText = "";
			string strRtf = "";
			RichTextBox rtb = new RichTextBox();
			int[] nTabs = new int[5] {240, 480, 720, 960, 1200};
			
			if (strHeader != "")
				strText = strHeader + Environment.NewLine + Environment.NewLine;

			for ( int i = 0; i < sl.Count; i++)
			{
				strLine = sl.GetKey(i) + Constants.Tab + sl.GetByIndex(i) +
					Environment.NewLine;
				strText += strLine;
			}
		
			rtb.Clear();
			rtb.Text = strText;
			rtb.SelectAll();
			rtb.SelectionAlignment = HorizontalAlignment.Left;
			rtb.SelectionFont = GetFont();
			rtb.SelectionTabs = nTabs;
			strRtf = rtb.Rtf;
			return strRtf;
		}

		public string FormatTable(string strText)
		{
			string str;
			string strRtf = "";
			RichTextBox rtb = new RichTextBox();
			int[] nTabs = new int[5] {240, 480, 720, 960, 1200};

			rtb.Clear();
			rtb.Text = strText;
			rtb.SelectAll();
			rtb.SelectionAlignment = HorizontalAlignment.Left;
			rtb.SelectionFont = GetFont();
			rtb.SelectionTabs = nTabs;
			int len = rtb.SelectionLength;
			str = rtb.Text;
			strRtf = rtb.Rtf;
			return strRtf;
		}

		private RichTextBox FormatParaText(RichTextBox rtb)
		{
			int nBeg = 0;
			int nEnd = 0;
			string str = "";
			bool done = false;
			int nIP = rtb.SelectionStart;	//Remember insertion point
            int[] nTabs = new int[8] { 96, 192, 288, 384, 480 ,576, 672, 768 };

			do 
			{
				nBeg = rtb.Find(Constants.kXPOn);
				if (nBeg >= 0)
				{
					nEnd = rtb.Find(Constants.kXPOff) + Constants.kXPOff.Length;
					if ( nBeg < nEnd )
					{
						rtb.Select(nBeg, nEnd - nBeg);
						str = rtb.SelectedText;
						str = str.Replace(Constants.kXPOn, "");
						str = str.Replace(Constants.kXPOff, "");
						rtb.SelectedText = str;
						nEnd = nEnd - Constants.kXPOn.Length - Constants.kXPOff.Length;
						rtb.Select(nBeg, nEnd - nBeg);
						rtb.SelectionAlignment = HorizontalAlignment.Left;
						rtb.SelectionFont = GetFont();
                        rtb.SelectionTabs = nTabs;
                        rtb.SelectionColor = Color.Black;
					}
					else done = true;
				}
				else done = true;
			}
			while (!done);
			rtb.Select(0, 0);
			rtb.SelectionStart = nIP;	//Restore insertion point
			return rtb;
		}

		private RichTextBox FormatParaList(RichTextBox rtb)
		{
			int nBeg = 0;
			int nEnd = 0;
			string str = "";
			bool done = false;
			int nIP = rtb.SelectionStart;	//Remember insertion point

            int[] nTabs = new int[7] { 240, 480, 720, 960, 1200, 1440, 1680 };
            do 
			{
				nBeg = rtb.Find(Constants.kLPOn);
				if (nBeg >= 0)
				{
					nEnd = rtb.Find(Constants.kLPOff) + Constants.kXPOff.Length;
					if ( nBeg < nEnd )
					{
						rtb.Select(nBeg, nEnd - nBeg);
						str = rtb.SelectedText;
						str = str.Replace(Constants.kLPOn, "");
						str = str.Replace(Constants.kLPOff, "");
						rtb.SelectedText = str;
						nEnd = nEnd - Constants.kLPOn.Length - Constants.kLPOff.Length;
						rtb.Select(nBeg, nEnd - nBeg);
						rtb.SelectionAlignment = HorizontalAlignment.Left;
						rtb.SelectionFont = GetFont();
						rtb.SelectionTabs = nTabs;
						rtb.SelectionColor = Color.Black;
					}
					else done = true;
				}
				else done = true;
			}
			while (!done);
			rtb.Select(0, 0);
			rtb.SelectionStart = nIP;	//Restore insertion point
			return rtb;
		}

		private RichTextBox FormatParaChart(RichTextBox rtb)
		{
			int nBeg = 0;
			int nEnd = 0;
			string str = "";
			bool done = false;
			int nIP = rtb.SelectionStart;	//Remember insertion point

            int[] nTabs = new int[14] {144, 216, 288, 360, 432, 504, 576, 648,
										  720, 792, 864, 936, 1008, 1080};
            do 
			{
				nBeg = rtb.Find(Constants.kCPOn);
				if (nBeg >= 0)
				{
					nEnd = rtb.Find(Constants.kCPOff) + Constants.kCPOff.Length;
					if ( nBeg < nEnd )
					{
						rtb.Select(nBeg, nEnd - nBeg);
						str = rtb.SelectedText;
						str = str.Replace(Constants.kCPOn, "");
						str = str.Replace(Constants.kCPOff, "");
						rtb.SelectedText = str;
						nEnd = nEnd - Constants.kCPOn.Length - Constants.kCPOff.Length;
						rtb.Select(nBeg, nEnd - nBeg);
						rtb.SelectionAlignment = HorizontalAlignment.Left;
						rtb.SelectionFont = GetFont();
						rtb.SelectionTabs = nTabs;
						rtb.SelectionColor = Color.Black;
					}
					else done = true;
				}
				else done = true;
			}
			while (!done);
			rtb.Select(0, 0);
			rtb.SelectionStart = nIP;	//Restore insertion point
			return rtb;
		}

		private RichTextBox FormatParaTable(RichTextBox rtb)
		{
			int nBeg = 0;
			int nEnd = 0;
			string str = "";
			bool done = false;
			int nIP = rtb.SelectionStart;	//Remember insertion point

            int[] nTabs = new int[5] { 240, 480, 720, 960, 1200 };
            do 
			{
				nBeg = rtb.Find(Constants.kTPOn);
				if (nBeg >= 0)
				{
                    // The Find method has an execution problem
                    nEnd = rtb.Find(Constants.kTPOff) + Constants.kTPOff.Length;
					if ( nBeg < nEnd )
					{
						rtb.Select(nBeg, nEnd - nBeg);
						str = rtb.SelectedText;
						str = str.Replace(Constants.kTPOn, "");
						str = str.Replace(Constants.kTPOff, "");
						rtb.SelectedText = str;
						nEnd = nEnd - Constants.kTPOn.Length - Constants.kTPOff.Length;
						rtb.Select(nBeg, nEnd - nBeg);
						rtb.SelectionAlignment = HorizontalAlignment.Left;
						rtb.SelectionFont = GetFont();
						rtb.SelectionTabs = nTabs;
						rtb.SelectionColor = Color.Black;
					}
					else done = true;
				}
				else done = true;
			}
			while (!done);
			rtb.Select(0, 0);
			rtb.SelectionStart = nIP;	//Restore insertion point
			return rtb;
		}

		private RichTextBox FormatHighlightColor(RichTextBox rtb)
		{
			int nBeg = 0;       // begin of highlighted text
			int nEnd = 0;       // end of highlighted text
            string str = "";
			bool done = false;

			do 
			{
				nBeg = rtb.Find(Constants.kHCOn);
 				if (nBeg >= 0)
				{
 					nEnd = rtb.Find(Constants.kHCOff) + Constants.kHCOff.Length;
					if ( nBeg < nEnd )
					{
						rtb.Select(nBeg, nEnd - nBeg);
						str = rtb.SelectedText;
						str = str.Replace(Constants.kHCOn, "");
						str = str.Replace(Constants.kHCOff, "");
						rtb.SelectedText = str;
						nEnd = nEnd - Constants.kHCOn.Length - Constants.kHCOff.Length;
						rtb.Select(nBeg, nEnd - nBeg);
                        rtb.SelectionBackColor = m_Settings.OptionSettings.HighlightColor;
                        rtb.SelectionColor = Color.White;
					}
					else done = true;
				}
				else done = true;
			}
			while (!done);
			rtb.Select(0, 0);
			return rtb;
		}

        private RichTextBox FormatHighlightColor(RichTextBox rtb, string strCaption)
        {
            int nBeg = 0;       // begin of highlighted text
            int nEnd = 0;       // end of highlighted text
            string str = "";
            bool done = false;
            FormProgressBar pb = new FormProgressBar(strCaption);
            pb.PB_Init(0, rtb.TextLength);

            do
            {
                nBeg = rtb.Find(Constants.kHCOn);
                pb.PB_Update(nBeg);
                if (nBeg >= 0)
                {
                    nEnd = rtb.Find(Constants.kHCOff) + Constants.kHCOff.Length;
                    if (nBeg < nEnd)
                    {
                        rtb.Select(nBeg, nEnd - nBeg);
                        str = rtb.SelectedText;
                        str = str.Replace(Constants.kHCOn, "");
                        str = str.Replace(Constants.kHCOff, "");
                        rtb.SelectedText = str;
                        nEnd = nEnd - Constants.kHCOn.Length - Constants.kHCOff.Length;
                        rtb.Select(nBeg, nEnd - nBeg);
                        str = rtb.SelectedText;         //debugging line
                        rtb.SelectionBackColor = m_Settings.OptionSettings.HighlightColor;
                        rtb.SelectionColor = Color.White;
                    }
                    else done = true;
                }
                else done = true;
            }
            while (!done);
            pb.Close();
            rtb.Select(0, 0);
            return rtb;
        }

        public void ReformatAsWordList()
		{
			RichTextBox rtb = this.Rtb;
			string strText = rtb.Text;
            int[] nTabs = new int[7] { 240, 480, 720, 960, 1200, 1440, 1680 };
            rtb.SelectionAlignment = HorizontalAlignment.Left;
			rtb.SelectionFont = GetFont();
			rtb.SelectionTabs = nTabs;
            this.Rtb = rtb;
		}

		public void ReformatAsChart()
		{
			RichTextBox rtb = this.Rtb;
			string strText = rtb.Text;
            int[] nTabs = new int[14] {144, 216, 288, 360, 432, 504, 576, 648,
										  720, 792, 864, 936, 1008, 1080};
            rtb.SelectionAlignment = HorizontalAlignment.Left;
			rtb.SelectionFont = GetFont();
			rtb.SelectionTabs = nTabs;
			this.Rtb = rtb;
		}

		public void ReformatAsTextData()
		{
			RichTextBox rtb = this.Rtb;
			string strText = rtb.Text;
			rtb.SelectionAlignment = HorizontalAlignment.Left;
			rtb.SelectionFont = GetFont();
			rtb = this.FormatHighlightColor(rtb);
            this.Rtb = rtb;
		}

		public void ClearProcessedSearchDefinitions()
		{
			RichTextBox rtb = this.Rtb;
			int nBgnSrch = 0;
			int nEndSrch = 0;
			int nBgnRslt = 0;
			int nEndRslt =  0;
			string strRslt = "";
			string strText = rtb.Rtf;
			string strTag = "";
			
			bool fDone = false;
			while ( !fDone )
			{
				strTag = Search.TagOpener + Search.TagSearch + Search.TagCloser;
				nBgnSrch = strText.IndexOf(strTag, nEndSrch);
				if (nBgnSrch >= 0)			//Next search
				{
					strTag = Search.TagOpener + Search.TagForwardSlash + Search.TagSearch
						+ Search.TagCloser;
					nEndSrch = strText.IndexOf(strTag,nBgnSrch);
					if (nBgnSrch < nEndSrch)
					{
						nEndSrch = nEndSrch + strTag.Length;
						strTag = Search.TagOpener + Search.TagResults + Search.TagCloser;
						nBgnRslt = strText.IndexOf(strTag, nBgnSrch);
						if (nBgnRslt >= 0)		//Result of next search
						{
							nBgnRslt = nBgnRslt + strTag.Length;
							strTag = Search.TagOpener + Search.TagForwardSlash 
								+ Search.TagResults + Search.TagCloser;
							nEndRslt = strText.IndexOf(strTag, nBgnRslt);
							if (nBgnRslt < nEndRslt)
							{
								strRslt = strText.Substring(nBgnRslt, nEndRslt - nBgnRslt); 
								strText = strText.Remove(nBgnRslt, nEndRslt - nBgnRslt);
								nEndSrch = nEndSrch - (nEndRslt - nBgnRslt); ;
							}
						}
					}
					else fDone = true;
				}
				else fDone = true;
			}
			rtb.Rtf = strText;
			m_Rtb = rtb;
		}

		public void HideProcessedSearchDefinitions()
		{
			RichTextBox rtb = this.Rtb;
			int nBgnSrch = 0;
			int nEndSrch = 0;
			int nBgnRslt = 0;
			int nEndRslt = 0;
			string strTag = "";
			string strSrch = "";
			string strRslt = "";
			string strText = rtb.Rtf;
			
			bool fDone = false;
			while ( !fDone )
			{
				strTag = Search.TagOpener + Search.TagSearch + Search.TagCloser;
				nBgnSrch = strText.IndexOf(strTag, nEndSrch);
				if (nBgnSrch >= 0)			//Next search
				{
					strTag = Search.TagOpener + Search.TagForwardSlash + Search.TagSearch
						+ Search.TagCloser;
					nEndSrch = strText.IndexOf(strTag, nBgnSrch);
					if (nBgnSrch < nEndSrch)
					{
						nEndSrch = nEndSrch + strTag.Length;
						strSrch = strText.Substring(nBgnSrch, nEndSrch - nBgnSrch);
						strTag = Search.TagOpener + Search.TagResults + Search.TagCloser;
						nBgnRslt = strText.IndexOf(strTag, nBgnSrch);
						if (nBgnRslt > 0)	//Results of next search
						{
							nBgnRslt = nBgnRslt + strTag.Length;
							strTag = Search.TagOpener + Search.TagForwardSlash
								+ Search.TagResults + Search.TagCloser;
							nEndRslt = strText.IndexOf(strTag, nBgnRslt);
							if (nBgnRslt < nEndRslt)
							{
								strRslt = strText.Substring(nBgnRslt, nEndRslt - nBgnRslt);
								//Get rid of extra new line at beginning of search results
								string str = "\\par" + Environment.NewLine;
								int n = strRslt.IndexOf(str, 0);
								if (n >= 0)
									strRslt = strRslt.Remove(n, str.Length);

								strText = strText.Replace(strSrch,strRslt);
								nEndSrch = nBgnSrch + strRslt.Length;
							}
						}
					}
					else fDone = true;
				}
				else fDone = true;
			}
			rtb.Rtf = strText;
			m_Rtb = rtb;
		}

		public void ShowProcessedSearchDefinitions()
		{
			RichTextBox rtb = this.Rtb;
			int nSN = 0;
			int nBgnSN = 0;
			int nEndSN = 0;
			int nLen = 0;
			Search search = null;
			string strTag = "";
			string strRslt = "";
			string strSrch = "";
			string strText = rtb.Rtf;

			bool fDone = false;
			while (!fDone)
			{
				strTag = Search.TagOpener + Search.TagSN;
				nLen = strTag.Length;
				nBgnSN = strText.IndexOf(strTag, nEndSN);
				if (nBgnSN >= 0)
				{
					int start = nBgnSN + strTag.Length;
					int end = strText.IndexOf(Search.TagCloser, nBgnSN);
					nSN = Convert.ToInt16( strText.Substring(start, end - start) );
					strTag = Search.TagOpener + Search.TagForwardSlash + Search.TagSN;
					nEndSN = strText.IndexOf(strTag,nBgnSN);
					if (nBgnSN < nEndSN)
					{
						nEndSN = nEndSN + strTag.Length;
						nEndSN = nEndSN + strText.Substring(start, end - start).Length;
						nEndSN = nEndSN + Search.TagCloser.Length;
						strRslt = strText.Substring(nBgnSN, nEndSN - nBgnSN);
						search = win.GetSearchFromSearchList(nSN);
						strSrch = ProcessSearchAsRtf(search);
						strText = strText.Replace(strRslt, strSrch);
						nEndSN = nEndSN + strSrch.Length - strRslt.Length;
					}
					else fDone = true;
				}
				else fDone = true;
			}
			rtb.Rtf = strText;
			m_Rtb = rtb;
		}

		public void RunUnprocessedSearchDefinitions()
		{
			RichTextBox rtb = this.Rtb;
			int nBgnSrch = 0;
			int nEndSrch = 0;
            string strTag = "";
			string strDefn = "";
			string strRslt = "";
			string strText = rtb.Text;
//			string strText = rtb.Rtf;
			
			bool fDone = false;
			while ( !fDone )
			{
				strTag = Search.TagOpener + Search.TagSearch + Search.TagCloser;
				nBgnSrch = strText.IndexOf(strTag, nEndSrch);
				if (nBgnSrch >= 0)			//Next search
				{
					//Process and format Search Definition
					strTag = Search.TagOpener + Search.TagForwardSlash + Search.TagSearch
						+ Search.TagCloser;
					nEndSrch = strText.IndexOf(strTag, nBgnSrch) + strTag.Length;
					if (nBgnSrch < nEndSrch)
					{
						strDefn = strText.Substring(nBgnSrch, nEndSrch - nBgnSrch);
						if ( HasEmptySearchResults(strDefn) )
						{
							strRslt = ProcessSearchDefinition(strDefn);
							strText = strText.Remove(nBgnSrch, nEndSrch - nBgnSrch);
							strText = strText.Insert(nBgnSrch, strRslt);
							nEndSrch = nBgnSrch + strRslt.Length;
						}
						else nEndSrch = nBgnSrch + strDefn.Length;
					}
					else fDone = true;
				}
				else fDone = true;
			}

			rtb.Text = strText + Environment.NewLine + Constants.Space;
//			rtb.Rtf = strText;
			rtb = this.FormatParaList(rtb);
			rtb = this.FormatParaText(rtb);
			rtb = this.FormatParaChart(rtb);
			rtb = this.FormatParaTable(rtb);
			rtb = this.FormatHighlightColor(rtb);
			this.Rtb = rtb;
		}

		public string ProcessSearchAsRtf(Search search)
		{
            if (search == null)
                return "";
			string strText = "";
			string strRtf = "";
			string str;
			strText = search.BuildSearch();

			switch (search.SearchDefinition.SearchType)
			{
				case SearchDefinition.kGeneralWL:
					strRtf = this.FormatWordList(strText);
					break;
				case SearchDefinition.kGrapheme:
					strRtf = this.FormatWordList(strText);
					break;
                case SearchDefinition.kFrequencyWL:
                    strRtf = this.FormatTable(strText);
                    break;
				case SearchDefinition.kBuildable:
					strRtf = this.FormatWordList(strText);
					break;
				case SearchDefinition.kAdvanced:
					strRtf = this.FormatWordList(strText);
					break;
                case SearchDefinition.kMinPairs:
                    strRtf = this.FormatWordList(strText);
                    break;
				case SearchDefinition.kCooccurrence:
					strRtf = this.FormatChart(strText);
					break;
				case SearchDefinition.kContext:
					strRtf = this.FormatChart(strText);
					break;
				case SearchDefinition.kSyllable:
					strRtf = this.FormatChart(strText);
					break;
				case SearchDefinition.kToneWL:
					strRtf = this.FormatWordList(strText);
					break;
                case SearchDefinition.kSyllographWL:
                    strRtf = this.FormatWordList(strText);
                    break;
                case SearchDefinition.kTonePairs:
                    strRtf = this.FormatWordList(strText);
                    break;
                case SearchDefinition.kOrderWL:
					strRtf = this.FormatTable(strText);
					break;
                case SearchDefinition.kGraphemeTD:
                    strRtf = this.FormatText(strText, true);
                    break;
                case SearchDefinition.kFrequencyTD:
                    strRtf = this.FormatTable(strText);
                    break;
				case SearchDefinition.kWord:
					strRtf = this.FormatText(strText, true);
					break;
                case SearchDefinition.kCount:
                    strRtf = this.FormatTable(strText);
                    break;
                case SearchDefinition.kSyllCount:
                    strRtf = this.FormatTable(strText);
                    break;
                case SearchDefinition.kPhrases:
					strRtf = this.FormatText(strText, true);
					break;
				case SearchDefinition.kResidue:
					strRtf = this.FormatText(strText, true);
					break;
				case SearchDefinition.kSight:
					strRtf = this.FormatText(strText, true);
					break;
                case SearchDefinition.kBuilt:
                    strRtf = this.FormatText(strText, true);
                    break;
                case SearchDefinition.kNewWord:
                    strRtf = this.FormatText(strText, true);
                    break;
				case SearchDefinition.kToneTD:
					strRtf = this.FormatText(strText, true);
					break;
                case SearchDefinition.kSyllographTD:
                    strRtf = this.FormatText(strText, true);
                    break;
                case SearchDefinition.kOrderTD:
                    strRtf = this.FormatTable(strText);
                    break;
                case SearchDefinition.kGeneralTD:
                    strRtf = this.FormatText(strText, true);
                    break;
                case SearchDefinition.kVowel:
					strRtf = this.FormatChart(strText);
					break;
				case SearchDefinition.kConsonant:
					strRtf = this.FormatChart(strText);
					break;
				case SearchDefinition.kTone:
					strRtf = this.FormatChart(strText);
					break;
                case SearchDefinition.kSyllograph:
                    strRtf = this.FormatChart(strText);
                    break;
				default:
					break;
			}
			//Get ending nullcharacter
			str = Environment.NewLine + Constants.NullChar.ToString();
			if ( strRtf.EndsWith(str) )
				strRtf = strRtf.Remove(strRtf.Length - str.Length, str.Length);
			//Get rid of extra new line on the end
			str = "\\par" + Environment.NewLine;
			int n = strRtf.LastIndexOf(str, strRtf.Length - 1);
			if (n > 0)
				strRtf = strRtf.Remove(n, str.Length);
			return strRtf;
		}

		public string ProcessSearchDefinitionAsRtf(string strDefn)
		{
			string strText = "";
			string strRtf = "";
			win.SearchCntr++;
			int sn = win.SearchCntr;

			WordList wl = win.Settings.WordList;
			TextData td = win.Settings.TextData;
            GraphemeInventory gi = win.Settings.GraphemeInventory;
 			SearchDefinition sd = new SearchDefinition();
			sd.BldSearchDefinitionFromString(strDefn);
			switch (sd.SearchType)
			{
				case SearchDefinition.kGeneralWL:
					GeneralWLSearch srchGen = new GeneralWLSearch(sn, m_Settings);
					srchGen.SetupSearch(sd);
					win.SearchList.Add(srchGen);		//Add search to List for future use
					srchGen = srchGen.ExecuteGeneralSearch(wl);
					if (win.Settings.SearchInsertionDefinitions)
						strText = srchGen.BuildSearch();
					else strText = srchGen.BuildResults();
					strRtf = this.FormatWordList(strText);
					break;
				case SearchDefinition.kGrapheme:
                    GraphemeSearchWL srchSeg = new GraphemeSearchWL(sn, m_Settings);
					srchSeg.SetupSearch(sd);
					win.SearchList.Add(srchSeg);			//Add search to List for future use
                    srchSeg = srchSeg.ExecuteGraphemeSearch(wl);
					if (win.Settings.SearchInsertionDefinitions)
						strText = srchSeg.BuildSearch();
					else strText = srchSeg.BuildResults();
					strRtf = this.FormatWordList(strText);
					break;
                case SearchDefinition.kFrequencyWL:
                    FrequencyWLSearch srchFrq = new FrequencyWLSearch(sn, m_Settings);
                    srchFrq.SetupSearch(sd);
                    win.SearchList.Add(srchFrq);
                    if (win.Settings.SearchInsertionDefinitions)
                        strText = srchFrq.BuildSearch();
                    else strText = srchFrq.BuildResults();
                    strRtf = this.FormatTable(strText);
                    break;
				case SearchDefinition.kBuildable:
                    BuildableWordSearchWL srchBld = new BuildableWordSearchWL(sn, m_Settings);
					srchBld.SetupSearch(sd);
					win.SearchList.Add(srchBld);
					srchBld = srchBld.ExecuteBuildableSearch(wl);
					if (win.Settings.SearchInsertionDefinitions)
						strText = srchBld.BuildSearch();
					else strText = srchBld.BuildResults();
					strRtf = this.FormatWordList(strText);
					break;
				case SearchDefinition.kAdvanced:
					AdvancedSearch srchAdv = new AdvancedSearch(sn, m_Settings);
					srchAdv.SetupSearch(sd);
					win.SearchList.Add(srchAdv);
					srchAdv = srchAdv.ExecuteAdvancedSearch(wl);
					if (win.Settings.SearchInsertionDefinitions)
						strText = srchAdv.BuildSearch();
					else strText = srchAdv.BuildResults();
					strRtf = this.FormatWordList(strText);
					break;
                case SearchDefinition.kMinPairs:
                    MinPairsSearch srchMin = new MinPairsSearch(sn, m_Settings);
                    srchMin.SetupSearch(sd);
                    win.SearchList.Add(srchMin);
                    srchMin = srchMin.ExecuteMinPairsSearch(wl);
                    if (win.Settings.SearchInsertionDefinitions)
                        strText = srchMin.BuildSearch();
                    else strText = srchMin.BuildResults();
                    strRtf = this.FormatWordList(strText);
                    break;
				case SearchDefinition.kCooccurrence:
					CooccurrenceChartSearch srchCoc = new CooccurrenceChartSearch(sn, m_Settings);
					srchCoc.SetupSearch(sd);
					win.SearchList.Add(srchCoc);
                    srchCoc = srchCoc.ExecuteCooccurChart(wl);
					if (win.Settings.SearchInsertionDefinitions)
						strText = srchCoc.BuildSearch();
					else strText = srchCoc.BuildResults();
					strRtf = this.FormatChart(strText);
					break;
				case SearchDefinition.kContext:
					ContextChartSearch srchCon = new ContextChartSearch(sn, m_Settings);
					srchCon.SetupSearch(sd);
					win.SearchList.Add(srchCon);
                    srchCon = srchCon.ExecuteContextChart(wl);
					if (win.Settings.SearchInsertionDefinitions)
						strText = srchCon.BuildSearch();
					else strText = srchCon.BuildResults();
					strRtf = this.FormatChart(strText);
					break;
				case SearchDefinition.kSyllable:
					SyllableChartSearch srchSyl = new SyllableChartSearch(sn, m_Settings);
					srchSyl.SetupSearch(sd);
					win.SearchList.Add(srchSyl);
                    srchSyl = srchSyl.ExecuteSyllableChart(wl);
					if (win.Settings.SearchInsertionDefinitions)
						strText = srchSyl.BuildSearch();
					else strText = srchSyl.BuildResults();
					strRtf = this.FormatChart(strText);
					break;
				case SearchDefinition.kToneWL:
					ToneWLSearch srchTn1 = new ToneWLSearch(sn, m_Settings);
					srchTn1.SetupSearch(sd);
					win.SearchList.Add(srchTn1);			//Add search to List for future use
					srchTn1 = srchTn1.ExecuteToneSearch(wl);
					if (win.Settings.SearchInsertionDefinitions)
						strText = srchTn1.BuildSearch();
					else strText = srchTn1.BuildResults();
					strRtf = this.FormatWordList(strText);
					break;
                case SearchDefinition.kTonePairs:
                    MinPairsSearch srchTMP = new MinPairsSearch(sn, m_Settings);
                    srchTMP.SetupSearch(sd);
                    win.SearchList.Add(srchTMP);
                    srchTMP = srchTMP.ExecuteMinPairsSearch(wl);
                    if (win.Settings.SearchInsertionDefinitions)
                        strText = srchTMP.BuildSearch();
                    else strText = srchTMP.BuildResults();
                    strRtf = this.FormatWordList(strText);
                    break;
                case SearchDefinition.kSyllographWL:
                    SyllographWLSearch srchSg1 = new SyllographWLSearch(sn, m_Settings);
                    srchSg1.SetupSearch(sd);
                    win.SearchList.Add(srchSg1);			//Add search to List for future use
                    srchSg1 = srchSg1.ExecuteSyllographSearch(wl);
                    if (win.Settings.SearchInsertionDefinitions)
                        strText = srchSg1.BuildSearch();
                    else strText = srchSg1.BuildResults();
                    strRtf = this.FormatWordList(strText);
                    break;
                case SearchDefinition.kOrderWL:
					TeachingOrderWLSearch srchOrd1 = new TeachingOrderWLSearch(sn, m_Settings);
					srchOrd1.SetupSearch(sd);
					win.SearchList.Add(srchOrd1);			//Add search to List for future use
					srchOrd1 = srchOrd1.ExecuteOrderSearch(wl);
					if (win.Settings.SearchInsertionDefinitions)
						strText = srchOrd1.BuildSearch();
					else strText = srchOrd1.BuildResults();
					strRtf = this.FormatTable(strText);
					break;
                case SearchDefinition.kGraphemeTD:
                    GraphemeSearchTD srchGrf = new GraphemeSearchTD(sn, m_Settings);
                    srchGrf.SetupSearch(sd);
                    win.SearchList.Add(srchGrf);			//Add search to List for future use
                    srchGrf = srchGrf.ExecuteGraphemeSearch(td);
                    if (win.Settings.SearchInsertionDefinitions)
                        strText = srchGrf.BuildSearch();
                    else strText = srchGrf.BuildResults();
                    strRtf = this.FormatText(strText, true);
                    break;
                case SearchDefinition.kFrequencyTD:
                    FrequencyTDSearch srchFrq2 = new FrequencyTDSearch(sn, m_Settings);
                    srchFrq2.SetupSearch(sd);
                    win.SearchList.Add(srchFrq2);
                    if (win.Settings.SearchInsertionDefinitions)
                        strText = srchFrq2.BuildSearch();
                    else strText = srchFrq2.BuildResults();
                    strRtf = this.FormatTable(strText);
                    break;
                case SearchDefinition.kCount:
					WordSearch srchWS = new WordSearch(sn, m_Settings);
                    srchWS.SetupSearch(sd);
                    win.SearchList.Add(srchWS);
                    srchWS.ExecuteWordSearch(td);
					if (win.Settings.SearchInsertionDefinitions)
                        strText = srchWS.BuildSearch();
                    else strText = srchWS.BuildResults();
					strRtf = this.FormatTable(strText);
					break;
                case SearchDefinition.kWord:
                    WordSearch srchWrd = new WordSearch(sn, m_Settings);
                    srchWrd.SetupSearch(sd);
                    win.SearchList.Add(srchWrd);
                    srchWrd.ExecuteWordSearch(td);
                    if (win.Settings.SearchInsertionDefinitions)
                        strText = srchWrd.BuildSearch();
                    else strText = srchWrd.BuildResults();
                    strRtf = this.FormatText(strText, true);
                    break;
                case SearchDefinition.kPhrases:
                    PhraseSearch srchPhr = new PhraseSearch(sn, m_Settings);
					srchPhr.SetupSearch(sd);
					win.SearchList.Add(srchPhr);
					srchPhr.ExecutePhraseSearch(td);
					if (win.Settings.SearchInsertionDefinitions)
						strText = srchPhr.BuildSearch();
					else strText = srchPhr.BuildResults();
					strRtf = this.FormatText(strText, true);
					break;
				case SearchDefinition.kResidue:
                    ResidueSearch srchRsd = new ResidueSearch(sn, m_Settings);
					srchRsd.SetupSearch(sd);
					win.SearchList.Add(srchRsd);
                    if (srchRsd.UseCurrentTextData)
                        srchRsd.ExecuteResidueSearch(td);
                    else
                    {
                        if (srchRsd.TextDataFile != "")
                        {
                            td = new TextData(m_Settings);
                            td.LoadFile(srchRsd.TextDataFile);
                            srchRsd.ExecuteResidueSearch(td);
                        }
                    }
					if (win.Settings.SearchInsertionDefinitions)
						strText = srchRsd.BuildSearch();
					else strText = srchRsd.BuildResults();
					strRtf = this.FormatText(strText, true);
					break;
				case SearchDefinition.kSight:
					SightSearch srchSgt = new SightSearch(sn, m_Settings);
					srchSgt.SetupSearch(sd);
					win.SearchList.Add(srchSgt);
					srchSgt.ExecuteSightSearch();
					if (win.Settings.SearchInsertionDefinitions)
						strText = srchSgt.BuildSearch();
					else strText = srchSgt.BuildResults();
					strRtf = this.FormatText(strText, true);
					break;
                case SearchDefinition.kBuilt:
                    BuildableWordSearchTD srchBwd = new BuildableWordSearchTD(sn, m_Settings);
                    srchBwd.SetupSearch(sd);
                    win.SearchList.Add(srchBwd);
                    srchBwd.ExecuteBuildableWordSearch(td);
                    if (win.Settings.SearchInsertionDefinitions)
                        strText = srchBwd.BuildSearch();
                    else strText = srchBwd.BuildResults();
                    strRtf = this.FormatText(strText, true);
                    break;
                case SearchDefinition.kNewWord:
                    NewWordSearch srchNew = new NewWordSearch(sn, m_Settings);
                    srchNew.SetupSearch(sd);
                    win.SearchList.Add(srchNew);
                    //td.ExecuteNewWordSearch(srchNew);
                    if (win.Settings.SearchInsertionDefinitions)
                        strText = srchNew.BuildSearch();
                    else strText = srchNew.BuildResults();
                    strRtf = this.FormatText(strText, true);
                    break;
                case SearchDefinition.kToneTD:
					ToneTDSearch srchTn2 = new ToneTDSearch(sn, m_Settings);
					srchTn2.SetupSearch(sd);
					win.SearchList.Add(srchTn2);			//Add search to List for future use
					srchTn2 = srchTn2.ExecuteToneSearch(td);
					if (win.Settings.SearchInsertionDefinitions)
						strText = srchTn2.BuildSearch();
					else strText = srchTn2.BuildResults();
					strRtf = this.FormatText(strText, true);
					break;
                case SearchDefinition.kSyllographTD:
                    SyllographTDSearch srchSg2 = new SyllographTDSearch(sn, m_Settings);
                    srchSg2.SetupSearch(sd);
                    win.SearchList.Add(srchSg2);			//Add search to List for future use
                    srchSg2 = srchSg2.ExecuteSyllographSearch(td);
                    if (win.Settings.SearchInsertionDefinitions)
                        strText = srchSg2.BuildSearch();
                    else strText = srchSg2.BuildResults();
                    strRtf = this.FormatWordList(strText);
                    break;
                case SearchDefinition.kOrderTD:
                    TeachingOrderTDSearch srchOrd2 = new TeachingOrderTDSearch(sn, m_Settings);
                    srchOrd2.SetupSearch(sd);
                    win.SearchList.Add(srchOrd2);			//Add search to List for future use
                    srchOrd2 = srchOrd2.ExecuteOrderSearch(td);
                    if (win.Settings.SearchInsertionDefinitions)
                        strText = srchOrd2.BuildSearch();
                    else strText = srchOrd2.BuildResults();
                    strRtf = this.FormatTable(strText);
                    break;
                case SearchDefinition.kGeneralTD:
                    GeneralTDSearch srchGen2 = new GeneralTDSearch(sn, m_Settings);
                    srchGen2.SetupSearch(sd);
                    win.SearchList.Add(srchGen2);       //Add search to list for future use
                    srchGen2.ExecuteGeneralSearch(td);
                    if (win.Settings.SearchInsertionDefinitions)
                        strText = srchGen2.BuildSearch();
                    else strText = srchGen2.BuildResults();
                    strRtf = this.FormatText(strText, true);
                    break;
                case SearchDefinition.kVowel:
					VowelChartSearch srchVwl = new VowelChartSearch(sn, m_Settings);
					srchVwl.SetupSearch(sd);
					win.SearchList.Add(srchVwl);
					srchVwl = srchVwl.ExecuteVowelChart(gi);
					if (win.Settings.SearchInsertionDefinitions)
						strText = srchVwl.BuildSearch();
					else strText = srchVwl.BuildResults();
					strRtf = this.FormatChart(strText);
					break;
				case SearchDefinition.kConsonant:
					ConsonantChartSearch srchCns = new ConsonantChartSearch(sn, m_Settings);
					srchCns.SetupSearch(sd);
					win.SearchList.Add(srchCns);		//Add search to list for future use
					srchCns.ExecuteConsonantChart(gi);
					if (win.Settings.SearchInsertionDefinitions)
						strText = srchCns.BuildSearch();
					else strText = srchCns.BuildResults();
					strRtf = this.FormatChart(strText);
					break;
				case SearchDefinition.kTone:
					ToneChartSearch srchTne = new ToneChartSearch(sn, m_Settings);
					srchTne.SetupSearch(sd);
					win.SearchList.Add(srchTne);
					srchTne.ExecuteToneChart(gi);
					if (win.Settings.SearchInsertionDefinitions)
						strText = srchTne.BuildSearch();
					else strText = srchTne.BuildResults();
					strRtf = this.FormatChart(strText);
					break;
                case SearchDefinition.kSyllograph:
                    SyllographChartSearch srchSylb = new SyllographChartSearch(sn, m_Settings);
                    srchSylb.SetupSearch(sd);
                    win.SearchList.Add(srchSylb);
                    srchSylb.ExecuteSyllographChart(gi);
                    if (win.Settings.SearchInsertionDefinitions)
                        strText = srchSylb.BuildSearch();
                    else strText = srchSylb.BuildResults();
                    strRtf = this.FormatChart(strText);
                    break;
                default:
					break;
			}

			//Get ending nullcharacter
			string str = Environment.NewLine + Constants.NullChar.ToString();
				strRtf = strRtf.Remove(strRtf.Length - str.Length, str.Length);
			//Get rid of extra new line on the end
			str = "\\par" + Environment.NewLine;
			int n = strRtf.LastIndexOf(str, strRtf.Length - 1);
			if (n > 0)
			  strRtf = strRtf.Remove(n, str.Length);
			return strRtf;
		}

		public string ProcessSearchDefinition(string strDefn)
		{
			string strText = "";
			win.SearchCntr++;
			int sn = win.SearchCntr;

			WordList wl = win.Settings.WordList;
			TextData td = win.Settings.TextData;
			GraphemeInventory gi = win.Settings.GraphemeInventory;
			SearchDefinition sd = new SearchDefinition();
			sd.BldSearchDefinitionFromString(strDefn);
			switch (sd.SearchType)
			{
				case SearchDefinition.kGeneralWL:
					GeneralWLSearch srchGen = new GeneralWLSearch(sn, m_Settings);
					srchGen.SetupSearch(sd);
					win.SearchList.Add(srchGen);		//Add search to List for future use
					srchGen = srchGen.ExecuteGeneralSearch(wl);
					if (win.Settings.SearchInsertionDefinitions)
						strText = srchGen.BuildSearch();
					else strText = srchGen.BuildResults();
					strText = Constants.kLPOn + strText + Constants.kLPOff;
					break;
				case SearchDefinition.kGrapheme:
                    GraphemeSearchWL srchSeg = new GraphemeSearchWL(sn, m_Settings);
					srchSeg.SetupSearch(sd);
					win.SearchList.Add(srchSeg);			//Add search to List for future use
                    srchSeg = srchSeg.ExecuteGraphemeSearch(wl);
					if (win.Settings.SearchInsertionDefinitions)
						strText = srchSeg.BuildSearch();
					else strText = srchSeg.BuildResults();
					strText = Constants.kLPOn + strText + Constants.kLPOff;
					break;
                case SearchDefinition.kFrequencyWL:
                    FrequencyWLSearch srchFrq = new FrequencyWLSearch(sn, m_Settings);
                    srchFrq.SetupSearch(sd);
                    win.SearchList.Add(srchFrq);
                    srchFrq = srchFrq.ExecuteFrequencySearch(wl);
                    if (win.Settings.SearchInsertionDefinitions)
                        strText = srchFrq.BuildSearch();
                    else strText = srchFrq.BuildResults();
                    strText = Constants.kTPOn + strText + Constants.kTPOff;
                    break;
				case SearchDefinition.kBuildable:
                    BuildableWordSearchWL srchBld = new BuildableWordSearchWL(sn, m_Settings);
					srchBld.SetupSearch(sd);
					win.SearchList.Add(srchBld);
					srchBld = srchBld.ExecuteBuildableSearch(wl);
					if (win.Settings.SearchInsertionDefinitions)
						strText = srchBld.BuildSearch();
					else strText = srchBld.BuildResults();
					strText = Constants.kLPOn + strText + Constants.kLPOff;
					break;
				case SearchDefinition.kAdvanced:
					AdvancedSearch srchAdv = new AdvancedSearch(sn, m_Settings);
					srchAdv.SetupSearch(sd);
					win.SearchList.Add(srchAdv);
					srchAdv = srchAdv.ExecuteAdvancedSearch(wl);
					if (win.Settings.SearchInsertionDefinitions)
						strText = srchAdv.BuildSearch();
					else strText = srchAdv.BuildResults();
					strText = Constants.kLPOn + strText + Constants.kLPOff;
					break;
                case SearchDefinition.kMinPairs:
                    MinPairsSearch srchMin = new MinPairsSearch(sn, m_Settings);
                    srchMin.SetupSearch(sd);
                    win.SearchList.Add(srchMin);
                    srchMin = srchMin.ExecuteMinPairsSearch(wl);
                    if (win.Settings.SearchInsertionDefinitions)
                        strText = srchMin.BuildSearch();
                    else strText = srchMin.BuildResults();
                    strText = Constants.kLPOn + strText + Constants.kLPOff;
                    break;
                case SearchDefinition.kCooccurrence:
					CooccurrenceChartSearch srchCoc = new CooccurrenceChartSearch(sn, m_Settings);
					srchCoc.SetupSearch(sd);
					win.SearchList.Add(srchCoc);
                    srchCoc = srchCoc.ExecuteCooccurChart(wl);
					if (win.Settings.SearchInsertionDefinitions)
						strText = srchCoc.BuildSearch();
					else strText = srchCoc.BuildResults();
					strText = Constants.kCPOn + strText + Constants.kCPOff;
					break;
				case SearchDefinition.kContext:
					ContextChartSearch srchCon = new ContextChartSearch(sn, m_Settings);
					srchCon.SetupSearch(sd);
					win.SearchList.Add(srchCon);
                    srchCon = srchCon.ExecuteContextChart(wl);
					if (win.Settings.SearchInsertionDefinitions)
						strText = srchCon.BuildSearch();
					else strText = srchCon.BuildResults();
					strText = Constants.kCPOn + strText + Constants.kCPOff;
					break;
				case SearchDefinition.kSyllable:
					SyllableChartSearch srchSyl = new SyllableChartSearch(sn, m_Settings);
					srchSyl.SetupSearch(sd);
					win.SearchList.Add(srchSyl);
                    srchSyl = srchSyl.ExecuteSyllableChart(wl);
					if (win.Settings.SearchInsertionDefinitions)
						strText = srchSyl.BuildSearch();
					else strText = srchSyl.BuildResults();
					strText = Constants.kCPOn + strText + Constants.kCPOff;
					break;
				case SearchDefinition.kToneWL:
					ToneWLSearch srchTn1 = new ToneWLSearch(sn, m_Settings);
					srchTn1.SetupSearch(sd);
					win.SearchList.Add(srchTn1);			//Add search to List for future use
					srchTn1 = srchTn1.ExecuteToneSearch(wl);
					if (win.Settings.SearchInsertionDefinitions)
						strText = srchTn1.BuildSearch();
					else strText = srchTn1.BuildResults();
					strText = Constants.kLPOn + strText + Constants.kLPOff;
					break;
                case SearchDefinition.kSyllographWL:
                    SyllographWLSearch srchSg1 = new SyllographWLSearch(sn, m_Settings);
                    srchSg1.SetupSearch(sd);
                    win.SearchList.Add(srchSg1);			//Add search to List for future use
                    srchSg1 = srchSg1.ExecuteSyllographSearch(wl);
                    if (win.Settings.SearchInsertionDefinitions)
                        strText = srchSg1.BuildSearch();
                    else strText = srchSg1.BuildResults();
                    strText = Constants.kLPOn + strText + Constants.kLPOff;
                    break;
                case SearchDefinition.kOrderWL:
					TeachingOrderWLSearch srchOrd1 = new TeachingOrderWLSearch(sn, m_Settings);
					srchOrd1.SetupSearch(sd);
					win.SearchList.Add(srchOrd1);			//Add search to List for future use
					srchOrd1 = srchOrd1.ExecuteOrderSearch(wl);
					if (win.Settings.SearchInsertionDefinitions)
						strText = srchOrd1.BuildSearch();
					else strText = srchOrd1.BuildResults();
					strText = Constants.kTPOn + strText + Constants.kTPOff;
					break;
                case SearchDefinition.kGraphemeTD:
                    GraphemeSearchTD srchGrf2 = new GraphemeSearchTD(sn, m_Settings);
                    srchGrf2.SetupSearch(sd);
                    win.SearchList.Add(srchGrf2);			//Add search to List for future use
                    srchGrf2 = srchGrf2.ExecuteGraphemeSearch(td);
                    if (win.Settings.SearchInsertionDefinitions)
                        strText = srchGrf2.BuildSearch();
                    else strText = srchGrf2.BuildResults();
                    strText = Constants.kXPOn + strText + Constants.kXPOff;
                    break;
                case SearchDefinition.kFrequencyTD:
                    FrequencyTDSearch srchFrq2 = new FrequencyTDSearch(sn, m_Settings);
                    srchFrq2.SetupSearch(sd);
                    win.SearchList.Add(srchFrq2);
                    srchFrq2 = srchFrq2.ExecuteFrequencySearch(td);
                    if (win.Settings.SearchInsertionDefinitions)
                        strText = srchFrq2.BuildSearch();
                    else strText = srchFrq2.BuildResults();
                    strText = Constants.kTPOn + strText + Constants.kTPOff;
                    break;
                case SearchDefinition.kWord:
					WordSearch srchWrd = new WordSearch(sn, m_Settings);
					srchWrd.SetupSearch(sd);
					win.SearchList.Add(srchWrd);
                    srchWrd.ExecuteWordSearch(td);
					if (win.Settings.SearchInsertionDefinitions)
						strText = srchWrd.BuildSearch();
					else strText = srchWrd.BuildResults();
					strText = Constants.kXPOn + strText + Constants.kXPOff;
					break;
                case SearchDefinition.kCount:
                    WordCountSearch srchWC = new WordCountSearch(sn, m_Settings);
                    srchWC.SetupSearch(sd);
                    win.SearchList.Add(srchWC);
                    srchWC.ExecuteWordCountSearch(td);
                    if (win.Settings.SearchInsertionDefinitions)
                        strText = srchWC.BuildSearch();
                    else strText = srchWC.BuildResults();
                    strText = Constants.kTPOn + strText + Constants.kTPOff;
                    break;
                case SearchDefinition.kSyllCount:
                    SyllableCountSearch srchSC = new SyllableCountSearch(sn, m_Settings);
                    srchSC.SetupSearch(sd);
                    win.SearchList.Add(srchSC);
                    srchSC.ExecuteSyllableCountSearch(td);
                    if (win.Settings.SearchInsertionDefinitions)
                        strText = srchSC.BuildSearch();
                    else strText = srchSC.BuildResults();
                    strText = Constants.kTPOn + strText + Constants.kTPOff;
                    break;
                case SearchDefinition.kPhrases:
                    PhraseSearch srchPhr = new PhraseSearch(sn, m_Settings);
					srchPhr.SetupSearch(sd);
					win.SearchList.Add(srchPhr);
                    srchPhr.ExecutePhraseSearch(td);
					if (win.Settings.SearchInsertionDefinitions)
						strText = srchPhr.BuildSearch();
					else strText = srchPhr.BuildResults();
					strText = Constants.kXPOn + strText + Constants.kXPOff;
					break;
				case SearchDefinition.kResidue:
                    ResidueSearch srchRsd = new ResidueSearch(sn, m_Settings);
					srchRsd.SetupSearch(sd);
					win.SearchList.Add(srchRsd);
                    if (srchRsd.UseCurrentTextData)
                        srchRsd.ExecuteResidueSearch(td);
                    else
                    {
                        if (srchRsd.TextDataFile != "")
                        {
                            td = new TextData(m_Settings);
                            td.LoadFile(srchRsd.TextDataFile);
                            srchRsd.ExecuteResidueSearch(td);
                        }
                    }
					if ( win.Settings.SearchInsertionDefinitions)
						strText = srchRsd.BuildSearch();
					else strText = srchRsd.BuildResults();
					strText = Constants.kXPOn + strText + Constants.kXPOff;
					break;
				case SearchDefinition.kSight:
					SightSearch srchSgt = new SightSearch(sn, m_Settings);
					srchSgt.SetupSearch(sd);
					win.SearchList.Add(srchSgt);
					srchSgt.ExecuteSightSearch();
					if (win.Settings.SearchInsertionDefinitions)
						strText = srchSgt.BuildSearch();
					else strText = srchSgt.BuildResults();
					strText = Constants.kXPOn + strText + Constants.kXPOff;
					break;
                case SearchDefinition.kNewWord:
                    NewWordSearch srchNew = new NewWordSearch(sn, m_Settings);
                    srchNew.SetupSearch(sd);
                    win.SearchList.Add(srchNew);
                    srchNew.ExecuteNewWordSearch();
                    if (win.Settings.SearchInsertionDefinitions)
                        strText = srchNew.BuildSearch();
                    else strText = srchNew.BuildResults();
                    strText = Constants.kXPOn + strText + Constants.kXPOff;
                    break;
                case SearchDefinition.kBuilt:
                    BuildableWordSearchTD srchBwd = new BuildableWordSearchTD(sn, m_Settings);
                    srchBwd.SetupSearch(sd);
                    win.SearchList.Add(srchBwd);
                    srchBwd.ExecuteBuildableWordSearch(td);
                    if (win.Settings.SearchInsertionDefinitions)
                        strText = srchBwd.BuildSearch();
                    else strText = srchBwd.BuildResults();
                    strText = Constants.kXPOn + strText + Constants.kXPOff;
                    break;
                case SearchDefinition.kToneTD:
					ToneTDSearch srchTn2 = new ToneTDSearch(sn, m_Settings);
					srchTn2.SetupSearch(sd);
					win.SearchList.Add(srchTn2);			//Add search to List for future use
					srchTn2 = srchTn2.ExecuteToneSearch(td);
					if (win.Settings.SearchInsertionDefinitions)
						strText = srchTn2.BuildSearch();
					else strText = srchTn2.BuildResults();
					strText = Constants.kXPOn + strText + Constants.kXPOff;
					break;
                case SearchDefinition.kSyllographTD:
                    SyllographTDSearch srchSg2 = new SyllographTDSearch(sn, m_Settings);
                    srchSg2.SetupSearch(sd);
                    win.SearchList.Add(srchSg2);			//Add search to List for future use
                    srchSg2 = srchSg2.ExecuteSyllographSearch(td);
                    if (win.Settings.SearchInsertionDefinitions)
                        strText = srchSg2.BuildSearch();
                    else strText = srchSg2.BuildResults();
                    strText = Constants.kLPOn + strText + Constants.kLPOff;
                    break;
                case SearchDefinition.kOrderTD:
                    TeachingOrderTDSearch srchOrd2 = new TeachingOrderTDSearch(sn, m_Settings);
                    srchOrd2.SetupSearch(sd);
                    win.SearchList.Add(srchOrd2);			//Add search to List for future use
                    srchOrd2 = srchOrd2.ExecuteOrderSearch(td);
                    if (win.Settings.SearchInsertionDefinitions)
                        strText = srchOrd2.BuildSearch();
                    else strText = srchOrd2.BuildResults();
                    strText = Constants.kTPOn + strText + Constants.kTPOff;
                    break;
                case SearchDefinition.kGeneralTD:
                    GeneralTDSearch srchGen2 = new GeneralTDSearch(sn, m_Settings);
                    srchGen2.SetupSearch(sd);
                    win.SearchList.Add(srchGen2);
                    srchGen2 = srchGen2.ExecuteGeneralSearch(td);
                    if (win.Settings.SearchInsertionDefinitions)
                        strText = srchGen2.BuildSearch();
                    else strText = srchGen2.BuildResults();
                    strText = Constants.kXPOn + strText + Constants.kXPOff;
                    break;
                case SearchDefinition.kVowel:
					VowelChartSearch srchVwl = new VowelChartSearch(sn, m_Settings);
					srchVwl.SetupSearch(sd);
					win.SearchList.Add(srchVwl);
					srchVwl = srchVwl.ExecuteVowelChart(gi);
					if (win.Settings.SearchInsertionDefinitions)
						strText = srchVwl.BuildSearch();
					else strText = srchVwl.BuildResults();
					strText = Constants.kCPOn + strText + Constants.kCPOff;
					break;
				case SearchDefinition.kConsonant:
					ConsonantChartSearch srchCns = new ConsonantChartSearch(sn, m_Settings);
					srchCns.SetupSearch(sd);
					win.SearchList.Add(srchCns);		//Add search to list for future use
					srchCns.ExecuteConsonantChart(gi);
					if (win.Settings.SearchInsertionDefinitions)
						strText = srchCns.BuildSearch();
					else strText = srchCns.BuildResults();
					strText = Constants.kCPOn + strText + Constants.kCPOff;
					break;
				case SearchDefinition.kTone:
					ToneChartSearch srchTne = new ToneChartSearch(sn, m_Settings);
					srchTne.SetupSearch(sd);
					win.SearchList.Add(srchTne);
					srchTne.ExecuteToneChart(gi);
					if (win.Settings.SearchInsertionDefinitions)
						strText = srchTne.BuildSearch();
					else strText = srchTne.BuildResults();
					strText = Constants.kCPOn + strText + Constants.kCPOff;
					break;
                case SearchDefinition.kSyllograph:
                    SyllographChartSearch srchSylb = new SyllographChartSearch(sn, m_Settings);
                    srchSylb.SetupSearch(sd);
                    win.SearchList.Add(srchSylb);
                    srchSylb.ExecuteSyllographChart(gi);
                    if (win.Settings.SearchInsertionDefinitions)
                        strText = srchSylb.BuildSearch();
                    else strText = srchSylb.BuildResults();
                    strText = Constants.kCPOn + strText + Constants.kCPOff;
                    break;
				default:
					break;
			}
			return strText;
		}

		public bool HasEmptySearchResults(string strDefn)
		{
			bool flag = false;
			string strTag = Search.TagOpener + Search.TagResults + Search.TagCloser
                + Search.TagOpener + Search.TagForwardSlash + Search.TagResults 
				+ Search.TagCloser;
			if (strDefn.IndexOf(strTag, 0) > 0)
				flag = true;
			return flag;
		}

		public void FindCmd()
		{
			this.Rtb.HideSelection = false;
            if (m_Settings.OptionSettings.UILanguage == OptionList.kFrench)
            {
                FormFindFrench form = new FormFindFrench(this.Rtb);
                DialogResult dr = form.ShowDialog();
                this.FindText = form.FindText;
            }
            else if (m_Settings.OptionSettings.UILanguage == OptionList.kSpanish)
            {
                FormFindSpanish form = new FormFindSpanish(this.Rtb);
                DialogResult dr = form.ShowDialog();
                this.FindText = form.FindText;
            }
            else
            {
                FormFind form = new FormFind(this.Rtb);
                DialogResult dr = form.ShowDialog();
                this.FindText = form.FindText;
            }
		}

		public void FindNextCmd()
		{
			RichTextBox rtb = this.Rtb;
			string strText = this.FindText;
            string strMsg = "";
			int ndx = 0;
		 	if (strText != "")
			{
				ndx = rtb.Find(strText, rtb.SelectionStart + rtb.SelectionLength, 
					RichTextBoxFinds.None);
                if (ndx >= 0)
                {
                    rtb.SelectionStart = ndx;
                    rtb.SelectionLength = strText.Length;
                    rtb.Show();
                }
                //else MessageBox.Show(strText + " not found");
                else
                {
                    strMsg = m_Settings.LocalizationTable.GetMessage("AppView1");
                    if (strMsg == "")
                        strMsg = "not found";
                    MessageBox.Show(strText + Constants.Space + strMsg);
                }
			}
            //else MessageBox.Show("Find text not specified");
            else
            {
                strMsg = m_Settings.LocalizationTable.GetMessage("AppView2");
                if (strMsg == "")
                    strMsg = "Find text not specified";
                MessageBox.Show(strMsg);
            }
			this.Rtb = rtb;
  		}

		public void ReplaceCmd()
		{
            this.Rtb.HideSelection = false;
            if (m_Settings.OptionSettings.UILanguage == OptionList.kFrench)
            {
                FormReplaceFrench form = new FormReplaceFrench(this.Rtb);
                DialogResult dr = form.ShowDialog();
                this.FindText = form.FindText;
            }
            else if (m_Settings.OptionSettings.UILanguage == OptionList.kSpanish)
            {
                FormReplaceSpanish form = new FormReplaceSpanish(this.Rtb);
                DialogResult dr = form.ShowDialog();
                this.FindText = form.FindText;
            }
            else
            {
                FormReplace form = new FormReplace(this.Rtb);
                DialogResult dr = form.ShowDialog();
                this.FindText = form.FindText;
            }
        }

		private void AppView_Activated(object sender, System.EventArgs e)
		{
            string strMsg = "";
			win.UpdStatusBarWnd();
            strMsg = m_Settings.LocalizationTable.GetMessage("AppView7");
            if (strMsg == "")
                strMsg = "…Ready…";
            win.UpdStatusBarInfo(strMsg);
            this.UpdateMenu();
        }

		private void AppView_Deactivate(object sender, System.EventArgs e)
		{
            win.UpdStatusBarWnd();
		}

        public void UpdateMenu()
        {
            string strText = "";
            // View Examples from Word List
            strText = m_Settings.LocalizationTable.GetMessage("AppView10");
            if (strText == "")
                strText = "…Ready…";
            this.menuExamplesWL.Text = strText;
            // View Examples from Text Data
            strText = m_Settings.LocalizationTable.GetMessage("AppView11");
            if (strText == "")
                strText = "…Ready…";
            this.menuExamplesTD.Text = strText;
        }

        private bool IsNumeric(string strText)
        {
            char[] chArray = strText.ToCharArray();
            for (int i = 0; i < strText.Length; i++)
            {
                if ( !Char.IsNumber(strText, i) )
                    return false;
            }
            return true;
        }

        private int GetSearchNumber(string Text, int Location)
        {
            int SN1 = 0;
            int SN2 = 0;
            string str;
            string strBefore = Text.Substring(0, Location);
            string strAfter = Text.Substring(Location);

            // Beginning Tag
            int nStart = strBefore.LastIndexOf(Search.TagOpener + Search.TagSN);
            int nEnd = strBefore.IndexOf(Search.TagCloser, nStart);
            str = strBefore.Substring(nStart, nEnd - nStart);
            str = str.Substring(3, str.Length - 3);
            if (IsNumeric(str))
                SN1 = Convert.ToInt32(str);

            // Ending Tag
            nStart = strAfter.IndexOf(Search.TagOpener + Search.TagForwardSlash + Search.TagSN);
            nEnd = strAfter.IndexOf(Search.TagCloser, nStart);
            str = strAfter.Substring(nStart, nEnd - nStart);
            str = str.Substring (4, str.Length - 4);
            if (IsNumeric(str))
                SN2 = Convert.ToInt32(str);

            if ( (SN1 > 0) && (SN1 == SN2) )
                return SN1;
            return 0;
        }

        private void GetSearchPosition(string Text, int Location, int SN, out int Row, out int Col)
        {
            Row = 0;
            Col = 0;
            string strBefore = Text.Substring(0, Location);
            string strAfter = Text.Substring(Location);
            int nCurr = 0;
            int nPrev = nCurr;

            // Beginning Tag
            nCurr = strBefore.LastIndexOf(Search.TagOpener + Search.TagSN);
            while ( 0 <= nCurr )
            {
                nPrev = nCurr;
                nCurr = strBefore.IndexOf(Constants.NewLine, nCurr + 1);
                Row++;
            }

            nCurr = nPrev;
            while (0 <= nCurr)
            {
                nPrev = nCurr;
                nCurr = strBefore.IndexOf(Constants.Tab, nCurr + 1);
                Col++;
            }

            // Adjust row and col due to Title and Column headers
            Search srch = win.GetSearchFromSearchList(SN);
            //Search srch = (Search)win.SearchList[SN - 1];
            if (srch != null)
            {
                string strType = srch.SearchDefinition.SearchType;
                switch (strType)
                {
                    case SearchDefinition.kCooccurrence:
                        Col = Col - 1;
                        Row = Row - 5;
                        break;
                    case SearchDefinition.kContext:
                        Col = Col - 1;
                        Row = Row - 6;
                        break;
                    case SearchDefinition.kSyllable:
                        Col = Col - 1;
                        Row = Row - 6;
                        break;
                    default:
                        break;
                }
            }
            return;
        }

        private WordList GetSearchWordList(int SN, int Row, int Col)
        {
            WordList wl = null;
            //Search srch = (Search)win.SearchList[SN - 1];
            Search srch = win.GetSearchFromSearchList(SN);
            string strType = srch.SearchDefinition.SearchType;
            switch (strType)
            {
                case SearchDefinition.kCooccurrence:
                    CooccurrenceChartSearch srchCoc = (CooccurrenceChartSearch) srch;
                    CooccurrenceChartTable tblCoc = srchCoc.Table;
                    wl = tblCoc.GetWordList(Row, Col + 1);      // add one to skip hidden key column
                    break;
                case SearchDefinition.kContext:
                    ContextChartSearch srchCon = (ContextChartSearch)srch;
                    ContextChartTable tblCon = srchCon.Table;
                    wl = tblCon.GetWordList(Row, Col);
                    break;
                case SearchDefinition.kSyllable:
                    SyllableChartSearch srchSyl = (SyllableChartSearch)srch;
                    SyllableChartTable tblSyl = srchSyl.Table;
                    wl = tblSyl.GetWordList(Row, Col);
                    break;
                default:
                    break;
            }
            return wl;
        }

        private void menuExamplesWL_Click(object sender, System.EventArgs e)
        {
            RichTextBox rtb = this.Rtb;
            string strSel = rtb.SelectedText.Trim();
            GraphemeInventory gi = m_Settings.GraphemeInventory;
            string str = "";
            string strText = "";
            string strRtf = "";
            if (strSel != "")
            {
                if (gi.IsInInventory(strSel))
                {
                    WordList wl = win.Settings.WordList;
                    GraphemeSearchWL srch = new GraphemeSearchWL(strSel, win.Settings);
                    srch = srch.ExecuteGraphemeSearch(wl);
                    //strText = "Examples for [" + strSel + "]";
                    strText = m_Settings.LocalizationTable.GetMessage("AppView12");
                    if (strText == "")
                        strText = "Examples for";
                    strText = strText + " [" + strSel + "]" + Environment.NewLine;
                    strText += srch.BuildResults();
                    strRtf = this.FormatWordList(strText);

                    AppView mdiChild = new AppView(win, "");
                    //mdiChild.Text = this.Text + "- Examples";
                    strText = m_Settings.LocalizationTable.GetMessage("AppView13");
                    if (strText == "")
                        strText = "Examples";
                    mdiChild.Text = this.Text + " - " + strText;
                    mdiChild.MdiParent = win;
                    mdiChild.Show();
                    mdiChild.Display(strRtf);
                }
                else if (this.IsNumeric(strSel))
                {
                    //Add code to determine what search was run and then determine the examples for that search
                    int nStart = rtb.SelectionStart;
                    int nEnd = nStart + strSel.Length;
                    strText = rtb.Text;
                    int nRow = 0;
                    int nCol = 0;
                    int nSN = GetSearchNumber(strText, nStart);
                    if (nSN > 0)
                    {
                        GetSearchPosition(strText, nStart, nSN, out nRow, out nCol);
                        WordList wl = GetSearchWordList(nSN, nRow, nCol);
                        if (wl != null)
                        {
                            // "Examples" / retrieved word list / ? " entries found"
                            str = m_Settings.LocalizationTable.GetMessage("AppView13");
                            if (str == "")
                                str = "Examples";
                            strText = str + Environment.NewLine;
                            strText += wl.RetrieveWordListAsString() + Environment.NewLine;
                            str = m_Settings.LocalizationTable.GetMessage("Search2");
                            if (str == "")
                                str = "entries found";
                            strText += strSel.ToString() + Constants.Space + str + Environment.NewLine;
                            strRtf = this.FormatWordList(strText);
                            
                            AppView mdiChild = new AppView(win, "");
                            //mdiChild.Text = this.Text + "- Examples";
                            strText = m_Settings.LocalizationTable.GetMessage("AppView13");
                            if (strText == "")
                                strText = "Examples";
                            mdiChild.Text = this.Text + " - " + strText;
                            mdiChild.MdiParent = win;
                            mdiChild.Show();
                            mdiChild.Display(strRtf);
                        }
                    }
                    //else MessageBox.Show("Selection needs to be within a search");
                    else
                    {
                        strText = m_Settings.LocalizationTable.GetMessage("AppView3");
                        if (strText == "")
                            strText = "Selection needs to be within a search";
                        MessageBox.Show(strText);
                    }
                }
                //else MessageBox.Show(strSel + " is not in grapheme inventory");
                else
                {
                    strText = m_Settings.LocalizationTable.GetMessage("AppView4");
                    if (strText == "")
                        strText = "is not in grapheme inventory";
                    MessageBox.Show(strSel + Constants.Space + strText);
                }
            }
            //else MessageBox.Show("Must select a grapheme or cell");
            else
            {
                strText = m_Settings.LocalizationTable.GetMessage("AppView5");
                if (strText == "")
                    strText = "Must select a grapheme or cell";
                MessageBox.Show(strText);
            }
        }

        private void menuExamplesTD_Click(object sender, System.EventArgs e)
		{
			RichTextBox rtb = this.Rtb;
			string strSel = rtb.SelectedText.Trim();
            GraphemeInventory gi = m_Settings.GraphemeInventory;
            string strText = "";
            string strRtf = "";
            if (strSel != "")
			{
                if (gi.IsInInventory(strSel))
                {
                    TextData td = win.Settings.TextData;
                    GraphemeSearchTD srch = new GraphemeSearchTD(strSel, win.Settings);
                    srch =srch.ExecuteGraphemeSearch(td);
                    //strText = "Examples for [" + strText + "]";
                    strText = m_Settings.LocalizationTable.GetMessage("AppView12");
                    if (strText == "")
                        strText = "Examples for";
                    strText = strText + " [" + strSel + "]" + Environment.NewLine;
                    strText += srch.BuildResults();
                    strRtf = this.FormatText(strText, false);

                    AppView mdiChild = new AppView(win, "");
                    //mdiChild.Text = this.Text + "-Examples";
                    strText = m_Settings.LocalizationTable.GetMessage("AppView13");
                    if (strText ==  "")
                        strText = "Examples";
                    mdiChild.Text = this.Text + "-" + strText;
                    mdiChild.MdiParent = win;
                    mdiChild.Show();
                    mdiChild.Display(strRtf);
                }
                //else MessageBox.Show(strSel + " is not in grapheme inventory");
                else
                {
                    strText = m_Settings.LocalizationTable.GetMessage("AppView4");
                    if (strText == "")
                        strText = "is not in grapheme inventory";
                    MessageBox.Show(strSel + Constants.Space + strText);
                }
            }
            //else MessageBox.Show("Must select a grapheme");
            else
            {
                strText = m_Settings.LocalizationTable.GetMessage("AppView6");
                if (strText == "")
                    strText = "Must select a grapheme";
                MessageBox.Show(strText);
            }
        }

        public ArrayList RetrieveAsArray(string strText)
        {
            ArrayList alText = new ArrayList();
            string strLine = "";
            int nBgn = 0;
            int nEnd = 0;
            int ndx = 0;

            while (nEnd >= 0)
            {
                nEnd = strText.IndexOf(Environment.NewLine, nBgn);
                if (nEnd < 0)
                    strLine = strText.Substring(nBgn);
                else strLine = strText.Substring(nBgn, nEnd - nBgn);
                alText.Add(strLine);
                ndx++;
                nBgn = nEnd + Environment.NewLine.Length;
             }
            return alText;
        }

    }
}

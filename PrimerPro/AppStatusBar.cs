using System;
using System.Windows.Forms;

namespace BLT
{
	/// <summary>
	/// Summary description for AppStatusBar
	/// </summary>
	public class XAppStatusBar : System.Windows.Forms.StatusBar
	{
		private AppWindow win;							//Application window
		private StatusBarPanel pnlWordList;
		private StatusBarPanel pnlTextData;
		private StatusBarPanel pnlWnd;
		private	StatusBarPanel pnlInfo;

		public XAppStatusBar(AppWindow pWindow)
		{
			win = pWindow;
			pnlWordList = new StatusBarPanel();
			pnlWordList.Text = "";
			pnlWordList.AutoSize = StatusBarPanelAutoSize.Contents;

			pnlTextData = new StatusBarPanel();
			pnlTextData.Text = "";
			pnlTextData.AutoSize = StatusBarPanelAutoSize.Contents;

			pnlWnd = new StatusBarPanel();
			pnlWnd.Text = "";
			pnlWnd.AutoSize = StatusBarPanelAutoSize.Contents;
			
			pnlInfo = new StatusBarPanel();
			pnlInfo.Text = "...Not Implemented Yet...";
			pnlInfo.AutoSize = StatusBarPanelAutoSize.Spring;

			this.Panels.Add(pnlWordList);
			this.Panels.Add(pnlTextData);
			this.Panels.Add(pnlWnd);
			this.Panels.Add(pnlInfo);
		}

		public void UpdWordListPanel()
		{
			string strText = "WL:<none>";
			if (win.Settings.WordList != null)
			{
				if (win.Settings.WordList.FileName != "")
				{
					strText = "WL:";
					strText += win.Settings.WordList.ShortFileName;
					strText += "->";
					strText += win.Settings.WordList.Count().ToString();
				}
			}
			pnlWordList.Text = strText;
			this.Show();
		}

		public void UpdTextDataPanel()
		{
			string strText = "TD:<none>";
			if (win.Settings.TextData != null)
			{
				if (win.Settings.TextData.FileName != "")
				{
					strText = "TD:";
					strText += win.Settings.TextData.ShortFileName;
				}
			}
			pnlTextData.Text = strText;
			this.Show();
		}

		public void UpdWndPanel(string strWnd)
		{
			pnlWnd.Text = strWnd.Trim();
			this.Show();
		}

		public void UpdInfoPanel(string strInfo)
		{
			pnlInfo.Text = strInfo.Trim();
			this.Show();
		}

	}
}

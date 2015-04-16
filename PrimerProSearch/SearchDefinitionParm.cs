using System;

namespace PrimerProSearch
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class SearchDefinitionParm
	{
		private string m_Tag = "";
		private string m_Content = "";
		
		public SearchDefinitionParm(string strTag, string strContent)
		{
			m_Tag = strTag;
			m_Content = strContent;
		}

		public SearchDefinitionParm(string strTag)
		{
			m_Tag = strTag;
			m_Content = "";
		}

		public string GetTag()
		{
			return m_Tag;
		}

		public string GetContent()
		{
			return m_Content;
		}

		public string GenSearchDefintionParm()
		{
			string str = "";
			str = Search.TagOpener + m_Tag + Search.TagCloser;
			str += m_Content;
			str += Search.TagOpener + Search.TagForwardSlash + m_Tag + Search.TagCloser;
			return str;
		}
	}
}

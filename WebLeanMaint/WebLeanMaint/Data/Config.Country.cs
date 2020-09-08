using System;
using System.Diagnostics;

namespace Data.Config
{
	/// <summary>
	/// Public Country Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  08/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_Country = {ID_Country}")]
	public partial class Country
	{
		public Country()
		{
		}

		public Country(Int32 nID_Country)
		{
			m_nID_Country = nID_Country;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Country
		{
		  get { return (m_nID_Country); }
		  set { m_nID_Country = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String Name
		{
		  get { return (m_sName); }
		  set { m_sName = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String Code
		{
		  get { return (m_sCode); }
		  set { m_sCode = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String Language
		{
		  get { return (m_sLanguage); }
		  set { m_sLanguage = value; }
		}
		#endregion

		#region Protected Properties
		protected Int32 m_nID_Country;
		protected String m_sName = String.Empty;
		protected String m_sCode = String.Empty;
		protected String m_sLanguage = String.Empty;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_Country)
		{
			m_nID_Country = nID_Country;
		}
		#endregion
	}
}

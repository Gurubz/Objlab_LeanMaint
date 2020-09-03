using System;
using System.Diagnostics;

namespace Data.dbo
{
	/// <summary>
	/// Public AspNetUserLogin Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  03/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("LoginProvider = {LoginProvider}, ProviderKey = {ProviderKey}, UserId = {UserId}")]
	public class AspNetUserLogin
	{
		public AspNetUserLogin()
		{
		}

		public AspNetUserLogin(String sLoginProvider, String sProviderKey, String sUserId)
		{
			m_sLoginProvider = sLoginProvider;
			m_sProviderKey = sProviderKey;
			m_sUserId = sUserId;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String LoginProvider
		{
		  get { return (m_sLoginProvider); }
		  set { m_sLoginProvider = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String ProviderKey
		{
		  get { return (m_sProviderKey); }
		  set { m_sProviderKey = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String UserId
		{
		  get { return (m_sUserId); }
		  set { m_sUserId = value; }
		}
		#endregion

		#region Protected Properties
		protected String m_sLoginProvider = String.Empty;
		protected String m_sProviderKey = String.Empty;
		protected String m_sUserId = String.Empty;
		#endregion

		#region Friends Methods
		internal void SetKeys(String sLoginProvider, String sProviderKey, String sUserId)
		{
			m_sLoginProvider = sLoginProvider;
			m_sProviderKey = sProviderKey;
			m_sUserId = sUserId;
		}
		#endregion
	}
}

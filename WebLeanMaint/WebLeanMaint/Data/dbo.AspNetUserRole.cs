using System;
using System.Diagnostics;

namespace Data.dbo
{
	/// <summary>
	/// Public AspNetUserRole Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  03/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("UserId = {UserId}, RoleId = {RoleId}")]
	public class AspNetUserRole
	{
		public AspNetUserRole()
		{
		}

		public AspNetUserRole(String sUserId, String sRoleId)
		{
			m_sUserId = sUserId;
			m_sRoleId = sRoleId;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String UserId
		{
		  get { return (m_sUserId); }
		  set { m_sUserId = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String RoleId
		{
		  get { return (m_sRoleId); }
		  set { m_sRoleId = value; }
		}
		#endregion

		#region Protected Properties
		protected String m_sUserId = String.Empty;
		protected String m_sRoleId = String.Empty;
		#endregion

		#region Friends Methods
		internal void SetKeys(String sUserId, String sRoleId)
		{
			m_sUserId = sUserId;
			m_sRoleId = sRoleId;
		}
		#endregion
	}
}

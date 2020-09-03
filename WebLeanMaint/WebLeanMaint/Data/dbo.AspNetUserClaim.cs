using System;
using System.Diagnostics;

namespace Data.dbo
{
	/// <summary>
	/// Public AspNetUserClaim Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  03/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("Id = {Id}")]
	public class AspNetUserClaim
	{
		public AspNetUserClaim()
		{
		}

		public AspNetUserClaim(Int32 nId)
		{
			m_nId = nId;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 Id
		{
		  get { return (m_nId); }
		  set { m_nId = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String UserId
		{
		  get { return (m_sUserId); }
		  set { m_sUserId = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String ClaimType
		{
		  get { return (m_sClaimType); }
		  set { m_sClaimType = value; m_bClaimType_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool ClaimType_HasValue
		{
		  get { return (m_bClaimType_HasValue); }
		  set { m_bClaimType_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String ClaimValue
		{
		  get { return (m_sClaimValue); }
		  set { m_sClaimValue = value; m_bClaimValue_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool ClaimValue_HasValue
		{
		  get { return (m_bClaimValue_HasValue); }
		  set { m_bClaimValue_HasValue = value; }
		}
		#endregion

		#region Protected Properties
		protected Int32 m_nId;
		protected String m_sUserId = String.Empty;
		protected String m_sClaimType = String.Empty;
		protected bool m_bClaimType_HasValue;
		protected String m_sClaimValue = String.Empty;
		protected bool m_bClaimValue_HasValue;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nId)
		{
			m_nId = nId;
		}
		#endregion
	}
}

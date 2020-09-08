using System;
using System.Diagnostics;

namespace Data.Security
{
	/// <summary>
	/// Public User Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  08/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_User = {ID_User}")]
	public partial class User
	{
		public User()
		{
		}

		public User(Int32 nID_User)
		{
			m_nID_User = nID_User;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_User
		{
		  get { return (m_nID_User); }
		  set { m_nID_User = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String Username
		{
		  get { return (m_sUsername); }
		  set { m_sUsername = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String Password
		{
		  get { return (m_sPassword); }
		  set { m_sPassword = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 Seed
		{
		  get { return (m_nSeed); }
		  set { m_nSeed = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_UserType
		{
		  get { return (m_nID_UserType); }
		  set { m_nID_UserType = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String EMail
		{
		  get { return (m_sEMail); }
		  set { m_sEMail = value; m_bEMail_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool EMail_HasValue
		{
		  get { return (m_bEMail_HasValue); }
		  set { m_bEMail_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String Mobile
		{
		  get { return (m_sMobile); }
		  set { m_sMobile = value; m_bMobile_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool Mobile_HasValue
		{
		  get { return (m_bMobile_HasValue); }
		  set { m_bMobile_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_ObjStatus
		{
		  get { return (m_nID_ObjStatus); }
		  set { m_nID_ObjStatus = value; }
		}
		#endregion

		#region Protected Properties
		protected Int32 m_nID_User;
		protected String m_sUsername = String.Empty;
		protected String m_sPassword = String.Empty;
		protected Int32 m_nSeed;
		protected Int32 m_nID_UserType;
		protected String m_sEMail = String.Empty;
		protected bool m_bEMail_HasValue;
		protected String m_sMobile = String.Empty;
		protected bool m_bMobile_HasValue;
		protected Int32 m_nID_ObjStatus;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_User)
		{
			m_nID_User = nID_User;
		}
		#endregion
	}
}

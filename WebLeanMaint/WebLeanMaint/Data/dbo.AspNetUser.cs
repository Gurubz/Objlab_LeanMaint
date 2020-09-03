using System;
using System.Diagnostics;

namespace Data.dbo
{
	/// <summary>
	/// Public AspNetUser Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  03/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("Id = {Id}")]
	public class AspNetUser
	{
		public AspNetUser()
		{
		}

		public AspNetUser(String sId)
		{
			m_sId = sId;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String Id
		{
		  get { return (m_sId); }
		  set { m_sId = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String Name
		{
		  get { return (m_sName); }
		  set { m_sName = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String ContactNumber
		{
		  get { return (m_sContactNumber); }
		  set { m_sContactNumber = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String AccountType
		{
		  get { return (m_sAccountType); }
		  set { m_sAccountType = value; m_bAccountType_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool AccountType_HasValue
		{
		  get { return (m_bAccountType_HasValue); }
		  set { m_bAccountType_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String seed
		{
		  get { return (m_sseed); }
		  set { m_sseed = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String ObjectStaus
		{
		  get { return (m_sObjectStaus); }
		  set { m_sObjectStaus = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String Email
		{
		  get { return (m_sEmail); }
		  set { m_sEmail = value; m_bEmail_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool Email_HasValue
		{
		  get { return (m_bEmail_HasValue); }
		  set { m_bEmail_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Boolean EmailConfirmed
		{
		  get { return (m_bEmailConfirmed); }
		  set { m_bEmailConfirmed = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String PasswordHash
		{
		  get { return (m_sPasswordHash); }
		  set { m_sPasswordHash = value; m_bPasswordHash_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool PasswordHash_HasValue
		{
		  get { return (m_bPasswordHash_HasValue); }
		  set { m_bPasswordHash_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String SecurityStamp
		{
		  get { return (m_sSecurityStamp); }
		  set { m_sSecurityStamp = value; m_bSecurityStamp_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool SecurityStamp_HasValue
		{
		  get { return (m_bSecurityStamp_HasValue); }
		  set { m_bSecurityStamp_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String PhoneNumber
		{
		  get { return (m_sPhoneNumber); }
		  set { m_sPhoneNumber = value; m_bPhoneNumber_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool PhoneNumber_HasValue
		{
		  get { return (m_bPhoneNumber_HasValue); }
		  set { m_bPhoneNumber_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Boolean PhoneNumberConfirmed
		{
		  get { return (m_bPhoneNumberConfirmed); }
		  set { m_bPhoneNumberConfirmed = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Boolean TwoFactorEnabled
		{
		  get { return (m_bTwoFactorEnabled); }
		  set { m_bTwoFactorEnabled = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DateTime LockoutEndDateUtc
		{
		  get { return (m_oLockoutEndDateUtc); }
		  set { m_oLockoutEndDateUtc = value; m_bLockoutEndDateUtc_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool LockoutEndDateUtc_HasValue
		{
		  get { return (m_bLockoutEndDateUtc_HasValue); }
		  set { m_bLockoutEndDateUtc_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Boolean LockoutEnabled
		{
		  get { return (m_bLockoutEnabled); }
		  set { m_bLockoutEnabled = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 AccessFailedCount
		{
		  get { return (m_nAccessFailedCount); }
		  set { m_nAccessFailedCount = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String UserName
		{
		  get { return (m_sUserName); }
		  set { m_sUserName = value; }
		}
		#endregion

		#region Protected Properties
		protected String m_sId = String.Empty;
		protected String m_sName = String.Empty;
		protected String m_sContactNumber = String.Empty;
		protected String m_sAccountType = String.Empty;
		protected bool m_bAccountType_HasValue;
		protected String m_sseed = String.Empty;
		protected String m_sObjectStaus = String.Empty;
		protected String m_sEmail = String.Empty;
		protected bool m_bEmail_HasValue;
		protected Boolean m_bEmailConfirmed;
		protected String m_sPasswordHash = String.Empty;
		protected bool m_bPasswordHash_HasValue;
		protected String m_sSecurityStamp = String.Empty;
		protected bool m_bSecurityStamp_HasValue;
		protected String m_sPhoneNumber = String.Empty;
		protected bool m_bPhoneNumber_HasValue;
		protected Boolean m_bPhoneNumberConfirmed;
		protected Boolean m_bTwoFactorEnabled;
		protected DateTime m_oLockoutEndDateUtc = DateTime.MinValue;
		protected bool m_bLockoutEndDateUtc_HasValue;
		protected Boolean m_bLockoutEnabled;
		protected Int32 m_nAccessFailedCount;
		protected String m_sUserName = String.Empty;
		#endregion

		#region Friends Methods
		internal void SetKeys(String sId)
		{
			m_sId = sId;
		}
		#endregion
	}
}

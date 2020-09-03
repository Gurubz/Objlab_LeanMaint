using System;
using System.Diagnostics;

namespace Data.dbo
{
	/// <summary>
	/// Public UserRegistrationData Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  03/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("Id = {Id}")]
	public class UserRegistrationData
	{
		public UserRegistrationData()
		{
		}

		public UserRegistrationData(Int32 nId)
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
		public String Name
		{
		  get { return (m_sName); }
		  set { m_sName = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String Email
		{
		  get { return (m_sEmail); }
		  set { m_sEmail = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String ContactNumber
		{
		  get { return (m_sContactNumber); }
		  set { m_sContactNumber = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 AccountTypes
		{
		  get { return (m_nAccountTypes); }
		  set { m_nAccountTypes = value; }
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
		#endregion

		#region Protected Properties
		protected Int32 m_nId;
		protected String m_sName = String.Empty;
		protected String m_sEmail = String.Empty;
		protected String m_sContactNumber = String.Empty;
		protected Int32 m_nAccountTypes;
		protected String m_sseed = String.Empty;
		protected String m_sObjectStaus = String.Empty;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nId)
		{
			m_nId = nId;
		}
		#endregion
	}
}

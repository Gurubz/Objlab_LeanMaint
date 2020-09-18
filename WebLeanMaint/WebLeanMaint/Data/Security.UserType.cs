using System;
using System.Diagnostics;

namespace Data.Security
{
	/// <summary>
	/// Public UserType Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  18/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_UserType = {ID_UserType}")]
	public partial class UserType
	{
		public UserType()
		{
		}

		public UserType(Int32 nID_UserType)
		{
			m_nID_UserType = nID_UserType;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_UserType
		{
		  get { return (m_nID_UserType); }
		  set { m_nID_UserType = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String Name
		{
		  get { return (m_sName); }
		  set { m_sName = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String Description
		{
		  get { return (m_sDescription); }
		  set { m_sDescription = value; }
		}
		#endregion

		#region Protected Properties
		protected Int32 m_nID_UserType;
		protected String m_sName = String.Empty;
		protected String m_sDescription = String.Empty;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_UserType)
		{
			m_nID_UserType = nID_UserType;
		}
		#endregion
	}
}

using System;
using System.Diagnostics;

namespace Data.Config
{
	/// <summary>
	/// Public OrganizationCenterType Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  03/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_OrganizationCenterType = {ID_OrganizationCenterType}")]
	public class OrganizationCenterType
	{
		public OrganizationCenterType()
		{
		}

		public OrganizationCenterType(Int32 nID_OrganizationCenterType)
		{
			m_nID_OrganizationCenterType = nID_OrganizationCenterType;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_OrganizationCenterType
		{
		  get { return (m_nID_OrganizationCenterType); }
		  set { m_nID_OrganizationCenterType = value; }
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
		protected Int32 m_nID_OrganizationCenterType;
		protected String m_sName = String.Empty;
		protected String m_sDescription = String.Empty;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_OrganizationCenterType)
		{
			m_nID_OrganizationCenterType = nID_OrganizationCenterType;
		}
		#endregion
	}
}

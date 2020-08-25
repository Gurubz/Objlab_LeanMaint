using System;
using System.Diagnostics;

namespace Data.Hierarchy
{
	/// <summary>
	/// Public OrganizationCenter Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  25/08/2020  Created
	/// </remarks>
	[DebuggerDisplay("")]
	public class OrganizationCenter
	{
		public OrganizationCenter()
		{
		}

		public OrganizationCenter(Int32 nID_OrganizationCenter, Int32 nLevel, Int32 nID_OrganizationCenterChild)
		{
			m_nID_OrganizationCenter = nID_OrganizationCenter;
			m_nLevel = nLevel;
			m_nID_OrganizationCenterChild = nID_OrganizationCenterChild;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_OrganizationCenter
		{
		  get { return (m_nID_OrganizationCenter); }
		  set { m_nID_OrganizationCenter = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 Level
		{
		  get { return (m_nLevel); }
		  set { m_nLevel = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_OrganizationCenterChild
		{
		  get { return (m_nID_OrganizationCenterChild); }
		  set { m_nID_OrganizationCenterChild = value; }
		}
		#endregion

		#region Protected Properties
		protected Int32 m_nID_OrganizationCenter;
		protected Int32 m_nLevel;
		protected Int32 m_nID_OrganizationCenterChild;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_OrganizationCenter, Int32 nLevel, Int32 nID_OrganizationCenterChild)
		{
			m_nID_OrganizationCenter = nID_OrganizationCenter;
			m_nLevel = nLevel;
			m_nID_OrganizationCenterChild = nID_OrganizationCenterChild;
		}
		#endregion
	}
}

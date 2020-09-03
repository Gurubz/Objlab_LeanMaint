using System;
using System.Diagnostics;

namespace Data.Config
{
	/// <summary>
	/// Public OrganizationCenter Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  03/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_OrganizationCenter = {ID_OrganizationCenter}")]
	public class OrganizationCenter
	{
		public OrganizationCenter()
		{
		}

		public OrganizationCenter(Int32 nID_OrganizationCenter)
		{
			m_nID_OrganizationCenter = nID_OrganizationCenter;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_OrganizationCenter
		{
		  get { return (m_nID_OrganizationCenter); }
		  set { m_nID_OrganizationCenter = value; }
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
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_OrganizationCenterType
		{
		  get { return (m_nID_OrganizationCenterType); }
		  set { m_nID_OrganizationCenterType = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_ObjStatus
		{
		  get { return (m_nID_ObjStatus); }
		  set { m_nID_ObjStatus = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Parent
		{
		  get { return (m_nID_Parent); }
		  set { m_nID_Parent = value; m_bID_Parent_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool ID_Parent_HasValue
		{
		  get { return (m_bID_Parent_HasValue); }
		  set { m_bID_Parent_HasValue = value; }
		}
		#endregion

		#region Protected Properties
		protected Int32 m_nID_OrganizationCenter;
		protected String m_sName = String.Empty;
		protected String m_sDescription = String.Empty;
		protected Int32 m_nID_OrganizationCenterType;
		protected Int32 m_nID_ObjStatus;
		protected Int32 m_nID_Parent;
		protected bool m_bID_Parent_HasValue;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_OrganizationCenter)
		{
			m_nID_OrganizationCenter = nID_OrganizationCenter;
		}
		#endregion
	}
}

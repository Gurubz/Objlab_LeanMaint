using System;
using System.Diagnostics;

namespace Data.Accountancy
{
	/// <summary>
	/// Public CostCenter Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  18/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_CostCenter = {ID_CostCenter}")]
	public partial class CostCenter
	{
		public CostCenter()
		{
		}

		public CostCenter(Int32 nID_CostCenter)
		{
			m_nID_CostCenter = nID_CostCenter;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_CostCenter
		{
		  get { return (m_nID_CostCenter); }
		  set { m_nID_CostCenter = value; }
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
		public Int32 ID_CostCenterType
		{
		  get { return (m_nID_CostCenterType); }
		  set { m_nID_CostCenterType = value; }
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
		protected Int32 m_nID_CostCenter;
		protected String m_sName = String.Empty;
		protected String m_sDescription = String.Empty;
		protected Int32 m_nID_CostCenterType;
		protected Int32 m_nID_ObjStatus;
		protected Int32 m_nID_Parent;
		protected bool m_bID_Parent_HasValue;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_CostCenter)
		{
			m_nID_CostCenter = nID_CostCenter;
		}
		#endregion
	}
}

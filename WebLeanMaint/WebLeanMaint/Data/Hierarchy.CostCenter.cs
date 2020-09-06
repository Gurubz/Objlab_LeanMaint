using System;
using System.Diagnostics;

namespace Data.Hierarchy
{
	/// <summary>
	/// Public CostCenter Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  06/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("")]
	public class CostCenter
	{
		public CostCenter()
		{
		}

		public CostCenter(Int32 nID_CostCenter, Int32 nLevel, Int32 nID_CostCenterChild)
		{
			m_nID_CostCenter = nID_CostCenter;
			m_nLevel = nLevel;
			m_nID_CostCenterChild = nID_CostCenterChild;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_CostCenter
		{
		  get { return (m_nID_CostCenter); }
		  set { m_nID_CostCenter = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 Level
		{
		  get { return (m_nLevel); }
		  set { m_nLevel = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_CostCenterChild
		{
		  get { return (m_nID_CostCenterChild); }
		  set { m_nID_CostCenterChild = value; }
		}
		#endregion

		#region Protected Properties
		protected Int32 m_nID_CostCenter;
		protected Int32 m_nLevel;
		protected Int32 m_nID_CostCenterChild;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_CostCenter, Int32 nLevel, Int32 nID_CostCenterChild)
		{
			m_nID_CostCenter = nID_CostCenter;
			m_nLevel = nLevel;
			m_nID_CostCenterChild = nID_CostCenterChild;
		}
		#endregion
	}
}

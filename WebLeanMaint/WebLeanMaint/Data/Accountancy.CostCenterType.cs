using System;
using System.Diagnostics;

namespace Data.Accountancy
{
	/// <summary>
	/// Public CostCenterType Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  08/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_CostCenterType = {ID_CostCenterType}")]
	public partial class CostCenterType
	{
		public CostCenterType()
		{
		}

		public CostCenterType(Int32 nID_CostCenterType)
		{
			m_nID_CostCenterType = nID_CostCenterType;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_CostCenterType
		{
		  get { return (m_nID_CostCenterType); }
		  set { m_nID_CostCenterType = value; }
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
		protected Int32 m_nID_CostCenterType;
		protected String m_sName = String.Empty;
		protected String m_sDescription = String.Empty;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_CostCenterType)
		{
			m_nID_CostCenterType = nID_CostCenterType;
		}
		#endregion
	}
}

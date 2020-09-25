using System;
using System.Diagnostics;

namespace Data.Hierarchy
{
	/// <summary>
	/// Public StoreCenter Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  25/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("")]
	public partial class StoreCenter
	{
		public StoreCenter()
		{
		}

		public StoreCenter(Int32 nID_StoreCenter, Int32 nLevel, Int32 nID_StoreCenterChild)
		{
			m_nID_StoreCenter = nID_StoreCenter;
			m_nLevel = nLevel;
			m_nID_StoreCenterChild = nID_StoreCenterChild;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_StoreCenter
		{
		  get { return (m_nID_StoreCenter); }
		  set { m_nID_StoreCenter = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 Level
		{
		  get { return (m_nLevel); }
		  set { m_nLevel = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_StoreCenterChild
		{
		  get { return (m_nID_StoreCenterChild); }
		  set { m_nID_StoreCenterChild = value; }
		}
		#endregion

		#region Protected Properties
		protected Int32 m_nID_StoreCenter;
		protected Int32 m_nLevel;
		protected Int32 m_nID_StoreCenterChild;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_StoreCenter, Int32 nLevel, Int32 nID_StoreCenterChild)
		{
			m_nID_StoreCenter = nID_StoreCenter;
			m_nLevel = nLevel;
			m_nID_StoreCenterChild = nID_StoreCenterChild;
		}
		#endregion
	}
}

using System;
using System.Diagnostics;

namespace Data.Planning
{
	/// <summary>
	/// Public Order Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  27/08/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_Order = {ID_Order}")]
	public class Order
	{
		public Order()
		{
		}

		public Order(Int32 nID_Order)
		{
			m_nID_Order = nID_Order;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Order
		{
		  get { return (m_nID_Order); }
		  set { m_nID_Order = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String Description
		{
		  get { return (m_sDescription); }
		  set { m_sDescription = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_OrderType
		{
		  get { return (m_nID_OrderType); }
		  set { m_nID_OrderType = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DateTime RequestedAt
		{
		  get { return (m_oRequestedAt); }
		  set { m_oRequestedAt = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DateTime PlannedFor
		{
		  get { return (m_oPlannedFor); }
		  set { m_oPlannedFor = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DateTime ToCompleteBefore
		{
		  get { return (m_oToCompleteBefore); }
		  set { m_oToCompleteBefore = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Boolean Completed
		{
		  get { return (m_bCompleted); }
		  set { m_bCompleted = value; }
		}
		#endregion

		#region Protected Properties
		protected Int32 m_nID_Order;
		protected String m_sDescription = String.Empty;
		protected Int32 m_nID_OrderType;
		protected DateTime m_oRequestedAt = DateTime.MinValue;
		protected DateTime m_oPlannedFor = DateTime.MinValue;
		protected DateTime m_oToCompleteBefore = DateTime.MinValue;
		protected Boolean m_bCompleted;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_Order)
		{
			m_nID_Order = nID_Order;
		}
		#endregion
	}
}

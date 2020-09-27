using System;
using System.Diagnostics;

namespace Data.Planning
{
	/// <summary>
	/// Public OrderOperator Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  27/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_Order = {ID_Order}, ID_Operator = {ID_Operator}")]
	public partial class OrderOperator
	{
		public OrderOperator()
		{
		}

		public OrderOperator(Int32 nID_Order, Int32 nID_Operator)
		{
			m_nID_Order = nID_Order;
			m_nID_Operator = nID_Operator;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Order
		{
		  get { return (m_nID_Order); }
		  set { m_nID_Order = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Operator
		{
		  get { return (m_nID_Operator); }
		  set { m_nID_Operator = value; }
		}
		#endregion

		#region Protected Properties
		protected Int32 m_nID_Order;
		protected Int32 m_nID_Operator;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_Order, Int32 nID_Operator)
		{
			m_nID_Order = nID_Order;
			m_nID_Operator = nID_Operator;
		}
		#endregion
	}
}

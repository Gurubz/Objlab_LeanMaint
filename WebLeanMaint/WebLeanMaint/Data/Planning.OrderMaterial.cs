using System;
using System.Diagnostics;

namespace Data.Planning
{
	/// <summary>
	/// Public OrderMaterial Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  25/08/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_Order = {ID_Order}, ID_Material = {ID_Material}")]
	public class OrderMaterial
	{
		public OrderMaterial()
		{
		}

		public OrderMaterial(Int32 nID_Order, Int32 nID_Material)
		{
			m_nID_Order = nID_Order;
			m_nID_Material = nID_Material;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Order
		{
		  get { return (m_nID_Order); }
		  set { m_nID_Order = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Material
		{
		  get { return (m_nID_Material); }
		  set { m_nID_Material = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 Quantity
		{
		  get { return (m_nQuantity); }
		  set { m_nQuantity = value; }
		}
		#endregion

		#region Protected Properties
		protected Int32 m_nID_Order;
		protected Int32 m_nID_Material;
		protected Int32 m_nQuantity;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_Order, Int32 nID_Material)
		{
			m_nID_Order = nID_Order;
			m_nID_Material = nID_Material;
		}
		#endregion
	}
}

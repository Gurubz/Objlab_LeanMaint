using System;
using System.Diagnostics;

namespace Data.Planning
{
	/// <summary>
	/// Public OrderType Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  25/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_OrderType = {ID_OrderType}")]
	public partial class OrderType
	{
		public OrderType()
		{
		}

		public OrderType(Int32 nID_OrderType)
		{
			m_nID_OrderType = nID_OrderType;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_OrderType
		{
		  get { return (m_nID_OrderType); }
		  set { m_nID_OrderType = value; }
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
		protected Int32 m_nID_OrderType;
		protected String m_sName = String.Empty;
		protected String m_sDescription = String.Empty;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_OrderType)
		{
			m_nID_OrderType = nID_OrderType;
		}
		#endregion
	}
}

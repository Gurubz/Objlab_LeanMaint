using System;
using System.Diagnostics;

namespace Data.Planning
{
	/// <summary>
	/// Public OrderAsset Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  27/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_OrderAsset = {ID_OrderAsset}")]
	public partial class OrderAsset
	{
		public OrderAsset()
		{
		}

		public OrderAsset(Int32 nID_OrderAsset)
		{
			m_nID_OrderAsset = nID_OrderAsset;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_OrderAsset
		{
		  get { return (m_nID_OrderAsset); }
		  set { m_nID_OrderAsset = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Order
		{
		  get { return (m_nID_Order); }
		  set { m_nID_Order = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Asset
		{
		  get { return (m_nID_Asset); }
		  set { m_nID_Asset = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Boolean StopRequired
		{
		  get { return (m_bStopRequired); }
		  set { m_bStopRequired = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 MinutesRequired
		{
		  get { return (m_nMinutesRequired); }
		  set { m_nMinutesRequired = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String Description
		{
		  get { return (m_sDescription); }
		  set { m_sDescription = value; }
		}
		#endregion

		#region Protected Properties
		protected Int32 m_nID_OrderAsset;
		protected Int32 m_nID_Order;
		protected Int32 m_nID_Asset;
		protected Boolean m_bStopRequired;
		protected Int32 m_nMinutesRequired;
		protected String m_sDescription = String.Empty;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_OrderAsset)
		{
			m_nID_OrderAsset = nID_OrderAsset;
		}
		#endregion
	}
}

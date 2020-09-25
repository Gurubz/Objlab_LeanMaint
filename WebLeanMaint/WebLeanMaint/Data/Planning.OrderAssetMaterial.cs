using System;
using System.Diagnostics;

namespace Data.Planning
{
	/// <summary>
	/// Public OrderAssetMaterial Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  25/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_OrderAsset = {ID_OrderAsset}, ID_Material = {ID_Material}")]
	public partial class OrderAssetMaterial
	{
		public OrderAssetMaterial()
		{
		}

		public OrderAssetMaterial(Int32 nID_OrderAsset, Int32 nID_Material)
		{
			m_nID_OrderAsset = nID_OrderAsset;
			m_nID_Material = nID_Material;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_OrderAsset
		{
		  get { return (m_nID_OrderAsset); }
		  set { m_nID_OrderAsset = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Material
		{
		  get { return (m_nID_Material); }
		  set { m_nID_Material = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Decimal Quantity
		{
		  get { return (m_nQuantity); }
		  set { m_nQuantity = value; }
		}
		#endregion

		#region Protected Properties
		protected Int32 m_nID_OrderAsset;
		protected Int32 m_nID_Material;
		protected Decimal m_nQuantity;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_OrderAsset, Int32 nID_Material)
		{
			m_nID_OrderAsset = nID_OrderAsset;
			m_nID_Material = nID_Material;
		}
		#endregion
	}
}

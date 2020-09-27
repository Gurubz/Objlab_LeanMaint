using System;
using System.Diagnostics;

namespace Data.Maintenance
{
	/// <summary>
	/// Public ExecutionAssetMaterial Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  27/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_ExecutionAsset = {ID_ExecutionAsset}, ID_Material = {ID_Material}")]
	public partial class ExecutionAssetMaterial
	{
		public ExecutionAssetMaterial()
		{
		}

		public ExecutionAssetMaterial(Int32 nID_ExecutionAsset, Int32 nID_Material)
		{
			m_nID_ExecutionAsset = nID_ExecutionAsset;
			m_nID_Material = nID_Material;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_ExecutionAsset
		{
		  get { return (m_nID_ExecutionAsset); }
		  set { m_nID_ExecutionAsset = value; }
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
		protected Int32 m_nID_ExecutionAsset;
		protected Int32 m_nID_Material;
		protected Decimal m_nQuantity;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_ExecutionAsset, Int32 nID_Material)
		{
			m_nID_ExecutionAsset = nID_ExecutionAsset;
			m_nID_Material = nID_Material;
		}
		#endregion
	}
}

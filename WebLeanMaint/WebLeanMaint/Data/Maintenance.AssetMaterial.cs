using System;
using System.Diagnostics;

namespace Data.Maintenance
{
	/// <summary>
	/// Public AssetMaterial Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  24/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_Asset = {ID_Asset}, ID_Material = {ID_Material}")]
	public partial class AssetMaterial
	{
		public AssetMaterial()
		{
		}

		public AssetMaterial(Int32 nID_Asset, Int32 nID_Material)
		{
			m_nID_Asset = nID_Asset;
			m_nID_Material = nID_Material;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Asset
		{
		  get { return (m_nID_Asset); }
		  set { m_nID_Asset = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Material
		{
		  get { return (m_nID_Material); }
		  set { m_nID_Material = value; }
		}
		#endregion

		#region Protected Properties
		protected Int32 m_nID_Asset;
		protected Int32 m_nID_Material;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_Asset, Int32 nID_Material)
		{
			m_nID_Asset = nID_Asset;
			m_nID_Material = nID_Material;
		}
		#endregion
	}
}

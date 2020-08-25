using System;
using System.Diagnostics;

namespace Data.Maintenance
{
	/// <summary>
	/// Public MaterialAsset Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  25/08/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_Material = {ID_Material}, ID_Asset = {ID_Asset}")]
	public class MaterialAsset
	{
		public MaterialAsset()
		{
		}

		public MaterialAsset(Int32 nID_Material, Int32 nID_Asset)
		{
			m_nID_Material = nID_Material;
			m_nID_Asset = nID_Asset;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Material
		{
		  get { return (m_nID_Material); }
		  set { m_nID_Material = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Asset
		{
		  get { return (m_nID_Asset); }
		  set { m_nID_Asset = value; }
		}
		#endregion

		#region Protected Properties
		protected Int32 m_nID_Material;
		protected Int32 m_nID_Asset;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_Material, Int32 nID_Asset)
		{
			m_nID_Material = nID_Material;
			m_nID_Asset = nID_Asset;
		}
		#endregion
	}
}

using System;
using System.Diagnostics;

namespace Data.Maintenance
{
	/// <summary>
	/// Public Material Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  06/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_Material = {ID_Material}")]
	public class Material
	{
		public Material()
		{
		}

		public Material(Int32 nID_Material)
		{
			m_nID_Material = nID_Material;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Material
		{
		  get { return (m_nID_Material); }
		  set { m_nID_Material = value; }
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
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_ObjStatus
		{
		  get { return (m_nID_ObjStatus); }
		  set { m_nID_ObjStatus = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String ReferenceCode
		{
		  get { return (m_sReferenceCode); }
		  set { m_sReferenceCode = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Supplier
		{
		  get { return (m_nID_Supplier); }
		  set { m_nID_Supplier = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Decimal CostPerUM
		{
		  get { return (m_nCostPerUM); }
		  set { m_nCostPerUM = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_MaterialUM
		{
		  get { return (m_nID_MaterialUM); }
		  set { m_nID_MaterialUM = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String Brand
		{
		  get { return (m_sBrand); }
		  set { m_sBrand = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String Type
		{
		  get { return (m_sType); }
		  set { m_sType = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String Barcode
		{
		  get { return (m_sBarcode); }
		  set { m_sBarcode = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_StoreCenter
		{
		  get { return (m_nID_StoreCenter); }
		  set { m_nID_StoreCenter = value; }
		}
		#endregion

		#region Protected Properties
		protected Int32 m_nID_Material;
		protected String m_sName = String.Empty;
		protected String m_sDescription = String.Empty;
		protected Int32 m_nID_ObjStatus;
		protected String m_sReferenceCode = String.Empty;
		protected Int32 m_nID_Supplier;
		protected Decimal m_nCostPerUM;
		protected Int32 m_nID_MaterialUM;
		protected String m_sBrand = String.Empty;
		protected String m_sType = String.Empty;
		protected String m_sBarcode = String.Empty;
		protected Int32 m_nID_StoreCenter;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_Material)
		{
			m_nID_Material = nID_Material;
		}
		#endregion
	}
}

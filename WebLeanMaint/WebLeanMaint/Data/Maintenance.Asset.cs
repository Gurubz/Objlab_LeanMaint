using System;
using System.Diagnostics;

namespace Data.Maintenance
{
	/// <summary>
	/// Public Asset Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  25/08/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_Asset = {ID_Asset}")]
	public class Asset
	{
		public Asset()
		{
		}

		public Asset(Int32 nID_Asset)
		{
			m_nID_Asset = nID_Asset;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Asset
		{
		  get { return (m_nID_Asset); }
		  set { m_nID_Asset = value; }
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
		public Int32 ID_AssetType
		{
		  get { return (m_nID_AssetType); }
		  set { m_nID_AssetType = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_OrganizationCenter
		{
		  get { return (m_nID_OrganizationCenter); }
		  set { m_nID_OrganizationCenter = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_CostCenter
		{
		  get { return (m_nID_CostCenter); }
		  set { m_nID_CostCenter = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_GeographicCenter
		{
		  get { return (m_nID_GeographicCenter); }
		  set { m_nID_GeographicCenter = value; m_bID_GeographicCenter_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool ID_GeographicCenter_HasValue
		{
		  get { return (m_bID_GeographicCenter_HasValue); }
		  set { m_bID_GeographicCenter_HasValue = value; }
		}
		#endregion

		#region Protected Properties
		protected Int32 m_nID_Asset;
		protected String m_sName = String.Empty;
		protected String m_sDescription = String.Empty;
		protected Int32 m_nID_AssetType;
		protected Int32 m_nID_OrganizationCenter;
		protected Int32 m_nID_CostCenter;
		protected Int32 m_nID_GeographicCenter;
		protected bool m_bID_GeographicCenter_HasValue;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_Asset)
		{
			m_nID_Asset = nID_Asset;
		}
		#endregion
	}
}

using System;
using System.Diagnostics;

namespace Data.Maintenance
{
	/// <summary>
	/// Public AssetType Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  08/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_AssetType = {ID_AssetType}")]
	public partial class AssetType
	{
		public AssetType()
		{
		}

		public AssetType(Int32 nID_AssetType)
		{
			m_nID_AssetType = nID_AssetType;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_AssetType
		{
		  get { return (m_nID_AssetType); }
		  set { m_nID_AssetType = value; }
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
		protected Int32 m_nID_AssetType;
		protected String m_sName = String.Empty;
		protected String m_sDescription = String.Empty;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_AssetType)
		{
			m_nID_AssetType = nID_AssetType;
		}
		#endregion
	}
}

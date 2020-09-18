using System;
using System.Diagnostics;

namespace Data.Maintenance
{
	/// <summary>
	/// Public SupplierType Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  18/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_SupplierType = {ID_SupplierType}")]
	public partial class SupplierType
	{
		public SupplierType()
		{
		}

		public SupplierType(Int32 nID_SupplierType)
		{
			m_nID_SupplierType = nID_SupplierType;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_SupplierType
		{
		  get { return (m_nID_SupplierType); }
		  set { m_nID_SupplierType = value; }
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
		protected Int32 m_nID_SupplierType;
		protected String m_sName = String.Empty;
		protected String m_sDescription = String.Empty;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_SupplierType)
		{
			m_nID_SupplierType = nID_SupplierType;
		}
		#endregion
	}
}

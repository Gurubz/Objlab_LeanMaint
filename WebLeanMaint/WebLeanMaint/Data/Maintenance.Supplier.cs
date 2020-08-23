using System;
using System.Diagnostics;

namespace Data.Maintenance
{
	/// <summary>
	/// Public Supplier Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  23/08/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_Supplier = {ID_Supplier}")]
	public class Supplier
	{
		public Supplier()
		{
		}

		public Supplier(Int32 nID_Supplier)
		{
			m_nID_Supplier = nID_Supplier;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Supplier
		{
		  get { return (m_nID_Supplier); }
		  set { m_nID_Supplier = value; }
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
		public Int32 ID_SupplierType
		{
		  get { return (m_nID_SupplierType); }
		  set { m_nID_SupplierType = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_ObjStatus
		{
		  get { return (m_nID_ObjStatus); }
		  set { m_nID_ObjStatus = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String Address1
		{
		  get { return (m_sAddress1); }
		  set { m_sAddress1 = value; m_bAddress1_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool Address1_HasValue
		{
		  get { return (m_bAddress1_HasValue); }
		  set { m_bAddress1_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String Address2
		{
		  get { return (m_sAddress2); }
		  set { m_sAddress2 = value; m_bAddress2_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool Address2_HasValue
		{
		  get { return (m_bAddress2_HasValue); }
		  set { m_bAddress2_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_CostCenter
		{
		  get { return (m_nID_CostCenter); }
		  set { m_nID_CostCenter = value; m_bID_CostCenter_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool ID_CostCenter_HasValue
		{
		  get { return (m_bID_CostCenter_HasValue); }
		  set { m_bID_CostCenter_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Decimal HourlyCost
		{
		  get { return (m_nHourlyCost); }
		  set { m_nHourlyCost = value; m_bHourlyCost_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool HourlyCost_HasValue
		{
		  get { return (m_bHourlyCost_HasValue); }
		  set { m_bHourlyCost_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_City
		{
		  get { return (m_nID_City); }
		  set { m_nID_City = value; m_bID_City_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool ID_City_HasValue
		{
		  get { return (m_bID_City_HasValue); }
		  set { m_bID_City_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String Zip
		{
		  get { return (m_sZip); }
		  set { m_sZip = value; m_bZip_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool Zip_HasValue
		{
		  get { return (m_bZip_HasValue); }
		  set { m_bZip_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Country
		{
		  get { return (m_nID_Country); }
		  set { m_nID_Country = value; m_bID_Country_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool ID_Country_HasValue
		{
		  get { return (m_bID_Country_HasValue); }
		  set { m_bID_Country_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DateTime ValidFrom
		{
		  get { return (m_oValidFrom); }
		  set { m_oValidFrom = value; m_bValidFrom_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool ValidFrom_HasValue
		{
		  get { return (m_bValidFrom_HasValue); }
		  set { m_bValidFrom_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_User
		{
		  get { return (m_nID_User); }
		  set { m_nID_User = value; }
		}
		#endregion

		#region Protected Properties
		protected Int32 m_nID_Supplier;
		protected String m_sName = String.Empty;
		protected String m_sDescription = String.Empty;
		protected Int32 m_nID_SupplierType;
		protected Int32 m_nID_ObjStatus;
		protected String m_sAddress1 = String.Empty;
		protected bool m_bAddress1_HasValue;
		protected String m_sAddress2 = String.Empty;
		protected bool m_bAddress2_HasValue;
		protected Int32 m_nID_CostCenter;
		protected bool m_bID_CostCenter_HasValue;
		protected Decimal m_nHourlyCost;
		protected bool m_bHourlyCost_HasValue;
		protected Int32 m_nID_City;
		protected bool m_bID_City_HasValue;
		protected String m_sZip = String.Empty;
		protected bool m_bZip_HasValue;
		protected Int32 m_nID_Country;
		protected bool m_bID_Country_HasValue;
		protected DateTime m_oValidFrom = DateTime.MinValue;
		protected bool m_bValidFrom_HasValue;
		protected Int32 m_nID_User;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_Supplier)
		{
			m_nID_Supplier = nID_Supplier;
		}
		#endregion
	}
}

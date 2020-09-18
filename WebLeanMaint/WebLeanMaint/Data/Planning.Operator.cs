using System;
using System.Diagnostics;

namespace Data.Planning
{
	/// <summary>
	/// Public Operator Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  18/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_Operator = {ID_Operator}")]
	public partial class Operator
	{
		public Operator()
		{
		}

		public Operator(Int32 nID_Operator)
		{
			m_nID_Operator = nID_Operator;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Operator
		{
		  get { return (m_nID_Operator); }
		  set { m_nID_Operator = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String Name
		{
		  get { return (m_sName); }
		  set { m_sName = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String MiddleName
		{
		  get { return (m_sMiddleName); }
		  set { m_sMiddleName = value; m_bMiddleName_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool MiddleName_HasValue
		{
		  get { return (m_bMiddleName_HasValue); }
		  set { m_bMiddleName_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String LastName
		{
		  get { return (m_sLastName); }
		  set { m_sLastName = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String Description
		{
		  get { return (m_sDescription); }
		  set { m_sDescription = value; m_bDescription_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool Description_HasValue
		{
		  get { return (m_bDescription_HasValue); }
		  set { m_bDescription_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_OperatorType
		{
		  get { return (m_nID_OperatorType); }
		  set { m_nID_OperatorType = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Calendar
		{
		  get { return (m_nID_Calendar); }
		  set { m_nID_Calendar = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Supplier
		{
		  get { return (m_nID_Supplier); }
		  set { m_nID_Supplier = value; m_bID_Supplier_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool ID_Supplier_HasValue
		{
		  get { return (m_bID_Supplier_HasValue); }
		  set { m_bID_Supplier_HasValue = value; }
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
		public Int32 ID_ObjStatus
		{
		  get { return (m_nID_ObjStatus); }
		  set { m_nID_ObjStatus = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_User
		{
		  get { return (m_nID_User); }
		  set { m_nID_User = value; }
		}
		#endregion

		#region Protected Properties
		protected Int32 m_nID_Operator;
		protected String m_sName = String.Empty;
		protected String m_sMiddleName = String.Empty;
		protected bool m_bMiddleName_HasValue;
		protected String m_sLastName = String.Empty;
		protected String m_sDescription = String.Empty;
		protected bool m_bDescription_HasValue;
		protected Int32 m_nID_OperatorType;
		protected Int32 m_nID_Calendar;
		protected Int32 m_nID_Supplier;
		protected bool m_bID_Supplier_HasValue;
		protected Int32 m_nID_CostCenter;
		protected bool m_bID_CostCenter_HasValue;
		protected Decimal m_nHourlyCost;
		protected bool m_bHourlyCost_HasValue;
		protected Int32 m_nID_ObjStatus;
		protected Int32 m_nID_User;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_Operator)
		{
			m_nID_Operator = nID_Operator;
		}
		#endregion
	}
}

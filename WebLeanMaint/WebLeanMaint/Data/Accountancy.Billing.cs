using System;
using System.Diagnostics;

namespace Data.Accountancy
{
	/// <summary>
	/// Public Billing Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  03/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_Billing = {ID_Billing}")]
	public class Billing
	{
		public Billing()
		{
		}

		public Billing(Int32 nID_Billing)
		{
			m_nID_Billing = nID_Billing;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Billing
		{
		  get { return (m_nID_Billing); }
		  set { m_nID_Billing = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Operator
		{
		  get { return (m_nID_Operator); }
		  set { m_nID_Operator = value; m_bID_Operator_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool ID_Operator_HasValue
		{
		  get { return (m_bID_Operator_HasValue); }
		  set { m_bID_Operator_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DateTime Activation
		{
		  get { return (m_oActivation); }
		  set { m_oActivation = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DateTime End
		{
		  get { return (m_oEnd); }
		  set { m_oEnd = value; m_bEnd_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool End_HasValue
		{
		  get { return (m_bEnd_HasValue); }
		  set { m_bEnd_HasValue = value; }
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
		public Int32 Year
		{
		  get { return (m_nYear); }
		  set { m_nYear = value; m_bYear_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool Year_HasValue
		{
		  get { return (m_bYear_HasValue); }
		  set { m_bYear_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 Month
		{
		  get { return (m_nMonth); }
		  set { m_nMonth = value; m_bMonth_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool Month_HasValue
		{
		  get { return (m_bMonth_HasValue); }
		  set { m_bMonth_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DateTime StartDay
		{
		  get { return (m_oStartDay); }
		  set { m_oStartDay = value; m_bStartDay_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool StartDay_HasValue
		{
		  get { return (m_bStartDay_HasValue); }
		  set { m_bStartDay_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DateTime EndDay
		{
		  get { return (m_oEndDay); }
		  set { m_oEndDay = value; m_bEndDay_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool EndDay_HasValue
		{
		  get { return (m_bEndDay_HasValue); }
		  set { m_bEndDay_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Decimal Value
		{
		  get { return (m_nValue); }
		  set { m_nValue = value; m_bValue_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool Value_HasValue
		{
		  get { return (m_bValue_HasValue); }
		  set { m_bValue_HasValue = value; }
		}
		#endregion

		#region Protected Properties
		protected Int32 m_nID_Billing;
		protected Int32 m_nID_Operator;
		protected bool m_bID_Operator_HasValue;
		protected DateTime m_oActivation = DateTime.MinValue;
		protected DateTime m_oEnd = DateTime.MinValue;
		protected bool m_bEnd_HasValue;
		protected Decimal m_nHourlyCost;
		protected bool m_bHourlyCost_HasValue;
		protected Int32 m_nYear;
		protected bool m_bYear_HasValue;
		protected Int32 m_nMonth;
		protected bool m_bMonth_HasValue;
		protected DateTime m_oStartDay = DateTime.MinValue;
		protected bool m_bStartDay_HasValue;
		protected DateTime m_oEndDay = DateTime.MinValue;
		protected bool m_bEndDay_HasValue;
		protected Decimal m_nValue;
		protected bool m_bValue_HasValue;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_Billing)
		{
			m_nID_Billing = nID_Billing;
		}
		#endregion
	}
}

using System;
using System.Diagnostics;

namespace Data.Maintenance
{
	/// <summary>
	/// Public OperatorsPermission Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  03/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_Operator = {ID_Operator}")]
	public class OperatorsPermission
	{
		public OperatorsPermission()
		{
		}

		public OperatorsPermission(Int32 nID_Operator)
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
		public Int32 LVL_User
		{
		  get { return (m_nLVL_User); }
		  set { m_nLVL_User = value; m_bLVL_User_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool LVL_User_HasValue
		{
		  get { return (m_bLVL_User_HasValue); }
		  set { m_bLVL_User_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String Auth_Code
		{
		  get { return (m_sAuth_Code); }
		  set { m_sAuth_Code = value; m_bAuth_Code_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool Auth_Code_HasValue
		{
		  get { return (m_bAuth_Code_HasValue); }
		  set { m_bAuth_Code_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DateTime Started
		{
		  get { return (m_oStarted); }
		  set { m_oStarted = value; m_bStarted_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool Started_HasValue
		{
		  get { return (m_bStarted_HasValue); }
		  set { m_bStarted_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DateTime Ended
		{
		  get { return (m_oEnded); }
		  set { m_oEnded = value; m_bEnded_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool Ended_HasValue
		{
		  get { return (m_bEnded_HasValue); }
		  set { m_bEnded_HasValue = value; }
		}
		#endregion

		#region Protected Properties
		protected Int32 m_nID_Operator;
		protected Int32 m_nLVL_User;
		protected bool m_bLVL_User_HasValue;
		protected String m_sAuth_Code = String.Empty;
		protected bool m_bAuth_Code_HasValue;
		protected DateTime m_oStarted = DateTime.MinValue;
		protected bool m_bStarted_HasValue;
		protected DateTime m_oEnded = DateTime.MinValue;
		protected bool m_bEnded_HasValue;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_Operator)
		{
			m_nID_Operator = nID_Operator;
		}
		#endregion
	}
}

using System;
using System.Diagnostics;

namespace Data.Maintenance
{
	/// <summary>
	/// Public Repair Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  23/08/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID = {ID}")]
	public class Repair
	{
		public Repair()
		{
		}

		public Repair(Int32 nID)
		{
			m_nID = nID;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID
		{
		  get { return (m_nID); }
		  set { m_nID = value; }
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
		public Int32 ID_RepairClass
		{
		  get { return (m_nID_RepairClass); }
		  set { m_nID_RepairClass = value; m_bID_RepairClass_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool ID_RepairClass_HasValue
		{
		  get { return (m_bID_RepairClass_HasValue); }
		  set { m_bID_RepairClass_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_ObjStatus
		{
		  get { return (m_nID_ObjStatus); }
		  set { m_nID_ObjStatus = value; m_bID_ObjStatus_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool ID_ObjStatus_HasValue
		{
		  get { return (m_bID_ObjStatus_HasValue); }
		  set { m_bID_ObjStatus_HasValue = value; }
		}
		#endregion

		#region Protected Properties
		protected Int32 m_nID;
		protected String m_sDescription = String.Empty;
		protected bool m_bDescription_HasValue;
		protected Int32 m_nID_RepairClass;
		protected bool m_bID_RepairClass_HasValue;
		protected Int32 m_nID_ObjStatus;
		protected bool m_bID_ObjStatus_HasValue;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID)
		{
			m_nID = nID;
		}
		#endregion
	}
}

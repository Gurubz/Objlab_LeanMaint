using System;
using System.Diagnostics;

namespace Data.Maintenance
{
	/// <summary>
	/// Public Failure Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  23/08/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID = {ID}")]
	public class Failure
	{
		public Failure()
		{
		}

		public Failure(Int32 nID)
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
		public String Name
		{
		  get { return (m_sName); }
		  set { m_sName = value; m_bName_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool Name_HasValue
		{
		  get { return (m_bName_HasValue); }
		  set { m_bName_HasValue = value; }
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
		public Int32 ID_FailureClass
		{
		  get { return (m_nID_FailureClass); }
		  set { m_nID_FailureClass = value; m_bID_FailureClass_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool ID_FailureClass_HasValue
		{
		  get { return (m_bID_FailureClass_HasValue); }
		  set { m_bID_FailureClass_HasValue = value; }
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
		protected String m_sName = String.Empty;
		protected bool m_bName_HasValue;
		protected String m_sDescription = String.Empty;
		protected bool m_bDescription_HasValue;
		protected Int32 m_nID_FailureClass;
		protected bool m_bID_FailureClass_HasValue;
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

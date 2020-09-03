using System;
using System.Diagnostics;

namespace Data.Maintenance
{
	/// <summary>
	/// Public Execution Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  03/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_Execution = {ID_Execution}")]
	public class Execution
	{
		public Execution()
		{
		}

		public Execution(Int32 nID_Execution)
		{
			m_nID_Execution = nID_Execution;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Execution
		{
		  get { return (m_nID_Execution); }
		  set { m_nID_Execution = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Order
		{
		  get { return (m_nID_Order); }
		  set { m_nID_Order = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_ExecutionType
		{
		  get { return (m_nID_ExecutionType); }
		  set { m_nID_ExecutionType = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DateTime StartedAt
		{
		  get { return (m_oStartedAt); }
		  set { m_oStartedAt = value; m_bStartedAt_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool StartedAt_HasValue
		{
		  get { return (m_bStartedAt_HasValue); }
		  set { m_bStartedAt_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DateTime EndedAt
		{
		  get { return (m_oEndedAt); }
		  set { m_oEndedAt = value; m_bEndedAt_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool EndedAt_HasValue
		{
		  get { return (m_bEndedAt_HasValue); }
		  set { m_bEndedAt_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Boolean Completed
		{
		  get { return (m_bCompleted); }
		  set { m_bCompleted = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Priority
		{
		  get { return (m_nID_Priority); }
		  set { m_nID_Priority = value; }
		}
		#endregion

		#region Protected Properties
		protected Int32 m_nID_Execution;
		protected Int32 m_nID_Order;
		protected Int32 m_nID_ExecutionType;
		protected DateTime m_oStartedAt = DateTime.MinValue;
		protected bool m_bStartedAt_HasValue;
		protected DateTime m_oEndedAt = DateTime.MinValue;
		protected bool m_bEndedAt_HasValue;
		protected Boolean m_bCompleted;
		protected Int32 m_nID_Priority;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_Execution)
		{
			m_nID_Execution = nID_Execution;
		}
		#endregion
	}
}

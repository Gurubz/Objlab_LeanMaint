using System;
using System.Diagnostics;

namespace Data.Maintenance
{
	/// <summary>
	/// Public ExecutionPriority Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  18/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_Priority = {ID_Priority}")]
	public partial class ExecutionPriority
	{
		public ExecutionPriority()
		{
		}

		public ExecutionPriority(Int32 nID_Priority)
		{
			m_nID_Priority = nID_Priority;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Priority
		{
		  get { return (m_nID_Priority); }
		  set { m_nID_Priority = value; }
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
		protected Int32 m_nID_Priority;
		protected String m_sName = String.Empty;
		protected String m_sDescription = String.Empty;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_Priority)
		{
			m_nID_Priority = nID_Priority;
		}
		#endregion
	}
}

using System;
using System.Diagnostics;

namespace Data.Maintenance
{
	/// <summary>
	/// Public ExecutionAsset Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  08/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_Execution = {ID_Execution}, ID_Asset = {ID_Asset}")]
	public partial class ExecutionAsset
	{
		public ExecutionAsset()
		{
		}

		public ExecutionAsset(Int32 nID_Execution, Int32 nID_Asset)
		{
			m_nID_Execution = nID_Execution;
			m_nID_Asset = nID_Asset;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Execution
		{
		  get { return (m_nID_Execution); }
		  set { m_nID_Execution = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Asset
		{
		  get { return (m_nID_Asset); }
		  set { m_nID_Asset = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Boolean Stopped
		{
		  get { return (m_bStopped); }
		  set { m_bStopped = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 MinutesUsed
		{
		  get { return (m_nMinutesUsed); }
		  set { m_nMinutesUsed = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String Description
		{
		  get { return (m_sDescription); }
		  set { m_sDescription = value; }
		}
		#endregion

		#region Protected Properties
		protected Int32 m_nID_Execution;
		protected Int32 m_nID_Asset;
		protected Boolean m_bStopped;
		protected Int32 m_nMinutesUsed;
		protected String m_sDescription = String.Empty;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_Execution, Int32 nID_Asset)
		{
			m_nID_Execution = nID_Execution;
			m_nID_Asset = nID_Asset;
		}
		#endregion
	}
}

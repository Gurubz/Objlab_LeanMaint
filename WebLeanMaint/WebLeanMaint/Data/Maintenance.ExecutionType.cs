using System;
using System.Diagnostics;

namespace Data.Maintenance
{
	/// <summary>
	/// Public ExecutionType Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  27/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_ExecutionType = {ID_ExecutionType}")]
	public partial class ExecutionType
	{
		public ExecutionType()
		{
		}

		public ExecutionType(Int32 nID_ExecutionType)
		{
			m_nID_ExecutionType = nID_ExecutionType;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_ExecutionType
		{
		  get { return (m_nID_ExecutionType); }
		  set { m_nID_ExecutionType = value; }
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
		protected Int32 m_nID_ExecutionType;
		protected String m_sName = String.Empty;
		protected String m_sDescription = String.Empty;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_ExecutionType)
		{
			m_nID_ExecutionType = nID_ExecutionType;
		}
		#endregion
	}
}

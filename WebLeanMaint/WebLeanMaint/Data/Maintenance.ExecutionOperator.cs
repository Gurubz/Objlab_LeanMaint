using System;
using System.Diagnostics;

namespace Data.Maintenance
{
	/// <summary>
	/// Public ExecutionOperator Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  27/08/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_Execution = {ID_Execution}, ID_Operator = {ID_Operator}")]
	public class ExecutionOperator
	{
		public ExecutionOperator()
		{
		}

		public ExecutionOperator(Int32 nID_Execution, Int32 nID_Operator)
		{
			m_nID_Execution = nID_Execution;
			m_nID_Operator = nID_Operator;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Execution
		{
		  get { return (m_nID_Execution); }
		  set { m_nID_Execution = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Operator
		{
		  get { return (m_nID_Operator); }
		  set { m_nID_Operator = value; }
		}
		#endregion

		#region Protected Properties
		protected Int32 m_nID_Execution;
		protected Int32 m_nID_Operator;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_Execution, Int32 nID_Operator)
		{
			m_nID_Execution = nID_Execution;
			m_nID_Operator = nID_Operator;
		}
		#endregion
	}
}

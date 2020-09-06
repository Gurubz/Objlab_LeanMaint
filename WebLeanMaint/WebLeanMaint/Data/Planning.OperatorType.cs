using System;
using System.Diagnostics;

namespace Data.Planning
{
	/// <summary>
	/// Public OperatorType Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  06/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_OperatorType = {ID_OperatorType}")]
	public class OperatorType
	{
		public OperatorType()
		{
		}

		public OperatorType(Int32 nID_OperatorType)
		{
			m_nID_OperatorType = nID_OperatorType;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_OperatorType
		{
		  get { return (m_nID_OperatorType); }
		  set { m_nID_OperatorType = value; }
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
		protected Int32 m_nID_OperatorType;
		protected String m_sName = String.Empty;
		protected String m_sDescription = String.Empty;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_OperatorType)
		{
			m_nID_OperatorType = nID_OperatorType;
		}
		#endregion
	}
}

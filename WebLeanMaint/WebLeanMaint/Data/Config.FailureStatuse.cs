using System;
using System.Diagnostics;

namespace Data.Config
{
	/// <summary>
	/// Public FailureStatuse Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  06/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_FailureStatus = {ID_FailureStatus}")]
	public class FailureStatuse
	{
		public FailureStatuse()
		{
		}

		public FailureStatuse(Int32 nID_FailureStatus)
		{
			m_nID_FailureStatus = nID_FailureStatus;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_FailureStatus
		{
		  get { return (m_nID_FailureStatus); }
		  set { m_nID_FailureStatus = value; }
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
		#endregion

		#region Protected Properties
		protected Int32 m_nID_FailureStatus;
		protected String m_sName = String.Empty;
		protected bool m_bName_HasValue;
		protected String m_sDescription = String.Empty;
		protected bool m_bDescription_HasValue;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_FailureStatus)
		{
			m_nID_FailureStatus = nID_FailureStatus;
		}
		#endregion
	}
}

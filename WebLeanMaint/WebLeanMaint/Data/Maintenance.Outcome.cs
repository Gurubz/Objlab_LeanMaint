using System;
using System.Diagnostics;

namespace Data.Maintenance
{
	/// <summary>
	/// Public Outcome Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  25/08/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID = {ID}")]
	public class Outcome
	{
		public Outcome()
		{
		}

		public Outcome(Int32 nID)
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
		#endregion

		#region Protected Properties
		protected Int32 m_nID;
		protected String m_sName = String.Empty;
		protected bool m_bName_HasValue;
		protected String m_sDescription = String.Empty;
		protected bool m_bDescription_HasValue;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID)
		{
			m_nID = nID;
		}
		#endregion
	}
}

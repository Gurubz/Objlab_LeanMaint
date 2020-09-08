using System;
using System.Diagnostics;

namespace Data.Planning
{
	/// <summary>
	/// Public Calendar Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  08/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_Calendar = {ID_Calendar}")]
	public partial class Calendar
	{
		public Calendar()
		{
		}

		public Calendar(Int32 nID_Calendar)
		{
			m_nID_Calendar = nID_Calendar;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Calendar
		{
		  get { return (m_nID_Calendar); }
		  set { m_nID_Calendar = value; }
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
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_ObjStatus
		{
		  get { return (m_nID_ObjStatus); }
		  set { m_nID_ObjStatus = value; }
		}
		#endregion

		#region Protected Properties
		protected Int32 m_nID_Calendar;
		protected String m_sName = String.Empty;
		protected String m_sDescription = String.Empty;
		protected Int32 m_nID_ObjStatus;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_Calendar)
		{
			m_nID_Calendar = nID_Calendar;
		}
		#endregion
	}
}

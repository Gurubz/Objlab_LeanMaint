using System;
using System.Diagnostics;

namespace Data.Planning
{
	/// <summary>
	/// Public CalendarDay Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  03/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_Calendar = {ID_Calendar}, Year = {Year}, Day = {Day}")]
	public class CalendarDay
	{
		public CalendarDay()
		{
		}

		public CalendarDay(Int32 nID_Calendar, Int32 nYear, DateTime oDay)
		{
			m_nID_Calendar = nID_Calendar;
			m_nYear = nYear;
			m_oDay = oDay;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Calendar
		{
		  get { return (m_nID_Calendar); }
		  set { m_nID_Calendar = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 Year
		{
		  get { return (m_nYear); }
		  set { m_nYear = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DateTime Day
		{
		  get { return (m_oDay); }
		  set { m_oDay = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DateTime DayStart
		{
		  get { return (m_oDayStart); }
		  set { m_oDayStart = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DateTime DayStartPause
		{
		  get { return (m_oDayStartPause); }
		  set { m_oDayStartPause = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DateTime DayEndPause
		{
		  get { return (m_oDayEndPause); }
		  set { m_oDayEndPause = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DateTime DayEnd
		{
		  get { return (m_oDayEnd); }
		  set { m_oDayEnd = value; }
		}
		#endregion

		#region Protected Properties
		protected Int32 m_nID_Calendar;
		protected Int32 m_nYear;
		protected DateTime m_oDay = DateTime.MinValue;
		protected DateTime m_oDayStart = DateTime.MinValue;
		protected DateTime m_oDayStartPause = DateTime.MinValue;
		protected DateTime m_oDayEndPause = DateTime.MinValue;
		protected DateTime m_oDayEnd = DateTime.MinValue;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_Calendar, Int32 nYear, DateTime oDay)
		{
			m_nID_Calendar = nID_Calendar;
			m_nYear = nYear;
			m_oDay = oDay;
		}
		#endregion
	}
}

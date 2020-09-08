using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Data.Planning
{
	/// <summary>
	/// Public CalendarDay Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  08/09/2020  Created
	/// </remarks>
	public class CalendarDays : EntitiesManagerBase
	{
		#region Public Properties
		public CalendarDay this[int nIndex]
		{
			get { return ((CalendarDay)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public CalendarDay GetByKeys(Int32 nID_Calendar, Int32 nYear, DateTime oDay)
		{
			foreach (CalendarDay oCalendarDay in this.m_aItems)
			{
				if (oCalendarDay.ID_Calendar == nID_Calendar && oCalendarDay.Year == nYear && oCalendarDay.Day == oDay)
				{
					return (oCalendarDay);
				}
			}

			return (null);
		}

		public CalendarDay[] ToArray()
		{
			List<CalendarDay> aRet = new List<CalendarDay>();
			foreach (CalendarDay oCalendarDay in this.m_aItems)
			{
				aRet.Add(oCalendarDay);
			}
			return (aRet.ToArray());
		}
		#endregion

		#region Database
		public virtual DataSet Load(string sWhere)
		{
			return (this.Load(sWhere, String.Empty, null));
		}

		public virtual DataSet Load(string sWhere, SqlConnection oPrivateConnection)
		{
			return (this.Load(sWhere, String.Empty, oPrivateConnection));
		}

		public virtual DataSet Load(string sWhere, string sOrderBy)
		{
			return (this.Load(sWhere, sOrderBy, null));
		}

		public virtual DataSet Load(string sWhere, string sOrderBy, SqlConnection oPrivateConnection)
		{
			CalendarDay oCalendarDay = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oCalendarDay = UTI_RowToCalendarDay(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oCalendarDay);

			}

			return (oRet);
		}

		public virtual void Delete(string sWhere)
		{
			Delete(sWhere, null);
		}

		public virtual void Delete(string sWhere, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Planning].[CalendarDays]");

			// If where provided
			if (sWhere.Length > 0)
			{
				oDelete.Append(" WHERE ");
				oDelete.Append(sWhere);
			}

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}
		#endregion
		#endregion

		#region Static Methods
		public static DataSet LoadFast(string sWhere)
		{
			return (LoadFast(sWhere, String.Empty, null));
		}

		public static DataSet LoadFast(string sWhere, SqlConnection oPrivateConnection)
		{
			return (LoadFast(sWhere, String.Empty, oPrivateConnection));
		}

		public static DataSet LoadFast(string sWhere, string sOrderBy)
		{
			return (LoadFast(sWhere, sOrderBy, null));
		}

		public static DataSet LoadFast(string sWhere, string sOrderBy, SqlConnection oPrivateConnection)
		{
			StringBuilder oSelect = null;
			DataSet oRet = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Planning].[CalendarDays]");

			// If where provided
			if (sWhere.Length > 0)
			{
				oSelect.Append(" WHERE ");
				oSelect.Append(sWhere);
			}

			// If orderby provided
			if (sOrderBy.Length > 0)
			{
				oSelect.Append(" ORDER BY ");
				oSelect.Append(sOrderBy);
			}

			// Get dataset
			oRet = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			return (oRet);
		}

		public static CalendarDay LoadOne(Int32 nID_Calendar, Int32 nYear, DateTime oDay)
		{
			return(LoadOne(nID_Calendar, nYear, oDay, null));
		}

		public static CalendarDay LoadOne(Int32 nID_Calendar, Int32 nYear, DateTime oDay, SqlConnection oPrivateConnection)
		{
			CalendarDay oCalendarDay = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Planning].[CalendarDays]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_Calendar]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Calendar));
			oSelect.Append(" AND ");
			oSelect.Append("[Year]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nYear));
			oSelect.Append(" AND ");
			oSelect.Append("[Day]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(oDay));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oCalendarDay = UTI_RowToCalendarDay(oRow);
			}

			return (oCalendarDay);
		}

		public static CalendarDay TryLoadOne(Int32 nID_Calendar, Int32 nYear, DateTime oDay)
		{
			return(TryLoadOne(nID_Calendar, nYear, oDay, null));
		}

		public static CalendarDay TryLoadOne(Int32 nID_Calendar, Int32 nYear, DateTime oDay, SqlConnection oPrivateConnection)
		{
			CalendarDay oCalendarDay = null;

			oCalendarDay = LoadOne(nID_Calendar, nYear, oDay, null);

			if (oCalendarDay == null)
			{
				return (new CalendarDay());
			}
			else
			{
				return (oCalendarDay);
			}
		}

		public static void InsertOne(CalendarDay oCalendarDay)
		{
			InsertOne(oCalendarDay, null);
		}

		public static void InsertOne(CalendarDay oCalendarDay, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Planning].[CalendarDays] ");
			oInsert.Append("([ID_Calendar], [Year], [Day], [DayStart], [DayStartPause], [DayEndPause], [DayEnd])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oCalendarDay.ID_Calendar));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oCalendarDay.Year));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oCalendarDay.Day));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oCalendarDay.DayStart));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oCalendarDay.DayStartPause));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oCalendarDay.DayEndPause));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oCalendarDay.DayEnd));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(CalendarDay oCalendarDay)
		{
			UpdateOne(oCalendarDay, null);
		}

		public static void UpdateOne(CalendarDay oCalendarDay, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Planning].[CalendarDays] SET ");

			oUpdate.Append("[DayStart]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oCalendarDay.DayStart));
			oUpdate.Append(", ");
			oUpdate.Append("[DayStartPause]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oCalendarDay.DayStartPause));
			oUpdate.Append(", ");
			oUpdate.Append("[DayEndPause]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oCalendarDay.DayEndPause));
			oUpdate.Append(", ");
			oUpdate.Append("[DayEnd]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oCalendarDay.DayEnd));

			oUpdate.Append(UTI_Where4One(oCalendarDay));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(CalendarDay oCalendarDay)
		{
			DeleteOne(oCalendarDay, null);
		}

		public static void DeleteOne(CalendarDay oCalendarDay, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Planning].[CalendarDays]");

			oDelete.Append(UTI_Where4One(oCalendarDay));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(CalendarDay oCalendarDay)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Calendar]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oCalendarDay.ID_Calendar));
			oWhere.Append(" AND ");
			oWhere.Append("[Year]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oCalendarDay.Year));
			oWhere.Append(" AND ");
			oWhere.Append("[Day]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oCalendarDay.Day));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_Calendar, Int32 nYear, DateTime oDay)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Calendar]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Calendar));
			oWhere.Append(" AND ");
			oWhere.Append("[Year]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nYear));
			oWhere.Append(" AND ");
			oWhere.Append("[Day]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oDay));

			return (oWhere.ToString());
		}

		public static CalendarDay UTI_RowToCalendarDay(DataRow oRow)
		{
			CalendarDay oCalendarDay = new CalendarDay();

			oCalendarDay.ID_Calendar = ((Int32)(oRow["ID_Calendar"]));
			oCalendarDay.Year = ((Int32)(oRow["Year"]));
			oCalendarDay.Day = ((DateTime)(oRow["Day"]));
			oCalendarDay.DayStart = ((DateTime)(oRow["DayStart"]));
			oCalendarDay.DayStartPause = ((DateTime)(oRow["DayStartPause"]));
			oCalendarDay.DayEndPause = ((DateTime)(oRow["DayEndPause"]));
			oCalendarDay.DayEnd = ((DateTime)(oRow["DayEnd"]));

			return (oCalendarDay);
		}
		#endregion
	}

}

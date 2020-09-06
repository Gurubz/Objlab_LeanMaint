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
	/// Public Calendar Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  06/09/2020  Created
	/// </remarks>
	public class Calendars : EntitiesManagerBase
	{
		#region Public Properties
		public Calendar this[int nIndex]
		{
			get { return ((Calendar)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public Calendar GetByKeys(Int32 nID_Calendar)
		{
			foreach (Calendar oCalendar in this.m_aItems)
			{
				if (oCalendar.ID_Calendar == nID_Calendar)
				{
					return (oCalendar);
				}
			}

			return (null);
		}

		public Calendar[] ToArray()
		{
			List<Calendar> aRet = new List<Calendar>();
			foreach (Calendar oCalendar in this.m_aItems)
			{
				aRet.Add(oCalendar);
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
			Calendar oCalendar = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oCalendar = UTI_RowToCalendar(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oCalendar);

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

			oDelete = new StringBuilder("DELETE FROM [Planning].[Calendars]");

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
			oSelect = new StringBuilder("SELECT * FROM [Planning].[Calendars]");

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

		public static Calendar LoadOne(Int32 nID_Calendar)
		{
			return(LoadOne(nID_Calendar, null));
		}

		public static Calendar LoadOne(Int32 nID_Calendar, SqlConnection oPrivateConnection)
		{
			Calendar oCalendar = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Planning].[Calendars]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_Calendar]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Calendar));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oCalendar = UTI_RowToCalendar(oRow);
			}

			return (oCalendar);
		}

		public static Calendar TryLoadOne(Int32 nID_Calendar)
		{
			return(TryLoadOne(nID_Calendar, null));
		}

		public static Calendar TryLoadOne(Int32 nID_Calendar, SqlConnection oPrivateConnection)
		{
			Calendar oCalendar = null;

			oCalendar = LoadOne(nID_Calendar, null);

			if (oCalendar == null)
			{
				return (new Calendar());
			}
			else
			{
				return (oCalendar);
			}
		}

		public static void InsertOne(Calendar oCalendar)
		{
			InsertOne(oCalendar, null);
		}

		public static void InsertOne(Calendar oCalendar, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Planning].[Calendars] ");
			oInsert.Append("([Name], [Description], [ID_ObjStatus])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oCalendar.Name));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oCalendar.Description));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oCalendar.ID_ObjStatus));
			oInsert.Append(")");

			Object oRet;
			oRet = EntitiesManagerBase.DAT_ExecuteScalar(oInsert.ToString(), "\nSELECT @@IDENTITY AS ID", oPrivateConnection);
			oCalendar.ID_Calendar = Convert.ToInt32(oRet);
		}

		public static void UpdateOne(Calendar oCalendar)
		{
			UpdateOne(oCalendar, null);
		}

		public static void UpdateOne(Calendar oCalendar, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Planning].[Calendars] SET ");

			oUpdate.Append("[Name]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oCalendar.Name));
			oUpdate.Append(", ");
			oUpdate.Append("[Description]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oCalendar.Description));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_ObjStatus]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oCalendar.ID_ObjStatus));

			oUpdate.Append(UTI_Where4One(oCalendar));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(Calendar oCalendar)
		{
			DeleteOne(oCalendar, null);
		}

		public static void DeleteOne(Calendar oCalendar, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Planning].[Calendars]");

			oDelete.Append(UTI_Where4One(oCalendar));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(Calendar oCalendar)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Calendar]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oCalendar.ID_Calendar));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_Calendar)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Calendar]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Calendar));

			return (oWhere.ToString());
		}

		public static Calendar UTI_RowToCalendar(DataRow oRow)
		{
			Calendar oCalendar = new Calendar();

			oCalendar.ID_Calendar = ((Int32)(oRow["ID_Calendar"]));
			oCalendar.Name = ((String)(oRow["Name"])).Trim();
			oCalendar.Description = ((String)(oRow["Description"])).Trim();
			oCalendar.ID_ObjStatus = ((Int32)(oRow["ID_ObjStatus"]));

			return (oCalendar);
		}
		#endregion
	}

}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Data.Maintenance
{
	/// <summary>
	/// Public Execution Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  24/09/2020  Created
	/// </remarks>
	public partial class Executions : EntitiesManagerBase
	{
		#region Public Properties
		public Execution this[int nIndex]
		{
			get { return ((Execution)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public Execution GetByKeys(Int32 nID_Execution)
		{
			foreach (Execution oExecution in this.m_aItems)
			{
				if (oExecution.ID_Execution == nID_Execution)
				{
					return (oExecution);
				}
			}

			return (null);
		}

		public Execution[] ToArray()
		{
			List<Execution> aRet = new List<Execution>();
			foreach (Execution oExecution in this.m_aItems)
			{
				aRet.Add(oExecution);
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
			Execution oExecution = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oExecution = UTI_RowToExecution(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oExecution);

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

			oDelete = new StringBuilder("DELETE FROM [Maintenance].[Executions]");

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
			oSelect = new StringBuilder("SELECT * FROM [Maintenance].[Executions]");

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

		public static Execution LoadOne(Int32 nID_Execution)
		{
			return(LoadOne(nID_Execution, null));
		}

		public static Execution LoadOne(Int32 nID_Execution, SqlConnection oPrivateConnection)
		{
			Execution oExecution = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Maintenance].[Executions]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_Execution]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Execution));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oExecution = UTI_RowToExecution(oRow);
			}

			return (oExecution);
		}

		public static Execution TryLoadOne(Int32 nID_Execution)
		{
			return(TryLoadOne(nID_Execution, null));
		}

		public static Execution TryLoadOne(Int32 nID_Execution, SqlConnection oPrivateConnection)
		{
			Execution oExecution = null;

			oExecution = LoadOne(nID_Execution, null);

			if (oExecution == null)
			{
				return (new Execution());
			}
			else
			{
				return (oExecution);
			}
		}

		public static void InsertOne(Execution oExecution)
		{
			InsertOne(oExecution, null);
		}

		public static void InsertOne(Execution oExecution, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Maintenance].[Executions] ");
			oInsert.Append("([ID_Order], [ID_ExecutionType], [StartedAt], [EndedAt], [Completed], [ID_Priority])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oExecution.ID_Order));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oExecution.ID_ExecutionType));
			oInsert.Append(", ");
			if (oExecution.StartedAt_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oExecution.StartedAt));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oExecution.EndedAt_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oExecution.EndedAt));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oExecution.Completed));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oExecution.ID_Priority));
			oInsert.Append(")");

			Object oRet;
			oRet = EntitiesManagerBase.DAT_ExecuteScalar(oInsert.ToString(), "\nSELECT @@IDENTITY AS ID", oPrivateConnection);
			oExecution.ID_Execution = Convert.ToInt32(oRet);
		}

		public static void UpdateOne(Execution oExecution)
		{
			UpdateOne(oExecution, null);
		}

		public static void UpdateOne(Execution oExecution, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Maintenance].[Executions] SET ");

			oUpdate.Append("[ID_Order]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oExecution.ID_Order));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_ExecutionType]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oExecution.ID_ExecutionType));
			oUpdate.Append(", ");
			oUpdate.Append("[StartedAt]=");
			if (oExecution.StartedAt_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oExecution.StartedAt));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[EndedAt]=");
			if (oExecution.EndedAt_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oExecution.EndedAt));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[Completed]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oExecution.Completed));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_Priority]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oExecution.ID_Priority));

			oUpdate.Append(UTI_Where4One(oExecution));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(Execution oExecution)
		{
			DeleteOne(oExecution, null);
		}

		public static void DeleteOne(Execution oExecution, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Maintenance].[Executions]");

			oDelete.Append(UTI_Where4One(oExecution));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(Execution oExecution)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Execution]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oExecution.ID_Execution));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_Execution)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Execution]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Execution));

			return (oWhere.ToString());
		}

		public static Execution UTI_RowToExecution(DataRow oRow)
		{
			Execution oExecution = new Execution();

			oExecution.ID_Execution = ((Int32)(oRow["ID_Execution"]));
			oExecution.ID_Order = ((Int32)(oRow["ID_Order"]));
			oExecution.ID_ExecutionType = ((Int32)(oRow["ID_ExecutionType"]));
			if (!(oRow["StartedAt"] is DBNull)) {
			  oExecution.StartedAt = ((DateTime)(oRow["StartedAt"]));
			  oExecution.StartedAt_HasValue = true;
			} else {
			  oExecution.StartedAt_HasValue = false;
			}
			if (!(oRow["EndedAt"] is DBNull)) {
			  oExecution.EndedAt = ((DateTime)(oRow["EndedAt"]));
			  oExecution.EndedAt_HasValue = true;
			} else {
			  oExecution.EndedAt_HasValue = false;
			}
			oExecution.Completed = ((Boolean)(oRow["Completed"]));
			oExecution.ID_Priority = ((Int32)(oRow["ID_Priority"]));

			return (oExecution);
		}
		#endregion
	}

}

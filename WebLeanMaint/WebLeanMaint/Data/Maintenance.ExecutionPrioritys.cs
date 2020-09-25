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
	/// Public ExecutionPriority Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  25/09/2020  Created
	/// </remarks>
	public partial class ExecutionPrioritys : EntitiesManagerBase
	{
		#region Public Properties
		public ExecutionPriority this[int nIndex]
		{
			get { return ((ExecutionPriority)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public ExecutionPriority GetByKeys(Int32 nID_Priority)
		{
			foreach (ExecutionPriority oExecutionPriority in this.m_aItems)
			{
				if (oExecutionPriority.ID_Priority == nID_Priority)
				{
					return (oExecutionPriority);
				}
			}

			return (null);
		}

		public ExecutionPriority[] ToArray()
		{
			List<ExecutionPriority> aRet = new List<ExecutionPriority>();
			foreach (ExecutionPriority oExecutionPriority in this.m_aItems)
			{
				aRet.Add(oExecutionPriority);
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
			ExecutionPriority oExecutionPriority = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oExecutionPriority = UTI_RowToExecutionPriority(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oExecutionPriority);

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

			oDelete = new StringBuilder("DELETE FROM [Maintenance].[ExecutionPriorities]");

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
		public static DataSet LoadFast(string sWhere, string sOrderBy = "", SqlConnection oPrivateConnection = null)
		{
			StringBuilder oSelect = null;
			DataSet oRet = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Maintenance].[ExecutionPriorities]");

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

		public static ExecutionPriority LoadOne(Int32 nID_Priority, SqlConnection oPrivateConnection = null)
		{
			ExecutionPriority oExecutionPriority = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Maintenance].[ExecutionPriorities]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_Priority]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Priority));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oExecutionPriority = UTI_RowToExecutionPriority(oRow);
			}

			return (oExecutionPriority);
		}

		public static ExecutionPriority TryLoadOne(Int32 nID_Priority, SqlConnection oPrivateConnection = null)
		{
			ExecutionPriority oExecutionPriority = null;

			oExecutionPriority = LoadOne(nID_Priority, null);

			if (oExecutionPriority == null)
			{
				return (new ExecutionPriority());
			}
			else
			{
				return (oExecutionPriority);
			}
		}

		public static void InsertOne(ExecutionPriority oExecutionPriority, SqlConnection oPrivateConnection = null)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Maintenance].[ExecutionPriorities] ");
			oInsert.Append("([ID_Priority], [Name], [Description])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionPriority.ID_Priority));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionPriority.Name));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionPriority.Description));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(ExecutionPriority oExecutionPriority, SqlConnection oPrivateConnection = null)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Maintenance].[ExecutionPriorities] SET ");

			oUpdate.Append("[Name]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionPriority.Name));
			oUpdate.Append(", ");
			oUpdate.Append("[Description]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionPriority.Description));

			oUpdate.Append(UTI_Where4One(oExecutionPriority));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(ExecutionPriority oExecutionPriority, SqlConnection oPrivateConnection = null)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Maintenance].[ExecutionPriorities]");

			oDelete.Append(UTI_Where4One(oExecutionPriority));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static void DeleteOne(Int32 nID_Priority, SqlConnection oPrivateConnection=null)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Maintenance].[ExecutionPriorities]");

			oDelete.Append(UTI_Where4One(nID_Priority));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(ExecutionPriority oExecutionPriority)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Priority]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionPriority.ID_Priority));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_Priority)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Priority]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Priority));

			return (oWhere.ToString());
		}

		public static ExecutionPriority UTI_RowToExecutionPriority(DataRow oRow)
		{
			ExecutionPriority oExecutionPriority = new ExecutionPriority();

			oExecutionPriority.ID_Priority = ((Int32)(oRow["ID_Priority"]));
			oExecutionPriority.Name = ((String)(oRow["Name"])).Trim();
			oExecutionPriority.Description = ((String)(oRow["Description"])).Trim();

			return (oExecutionPriority);
		}
		#endregion
	}

}

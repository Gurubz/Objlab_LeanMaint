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
	/// Public ExecutionType Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  25/08/2020  Created
	/// </remarks>
	public class ExecutionTypes : EntitiesManagerBase
	{
		#region Public Properties
		public ExecutionType this[int nIndex]
		{
			get { return ((ExecutionType)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public ExecutionType GetByKeys(Int32 nID_ExecutionType)
		{
			foreach (ExecutionType oExecutionType in this.m_aItems)
			{
				if (oExecutionType.ID_ExecutionType == nID_ExecutionType)
				{
					return (oExecutionType);
				}
			}

			return (null);
		}

		public ExecutionType[] ToArray()
		{
			List<ExecutionType> aRet = new List<ExecutionType>();
			foreach (ExecutionType oExecutionType in this.m_aItems)
			{
				aRet.Add(oExecutionType);
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
			ExecutionType oExecutionType = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oExecutionType = UTI_RowToExecutionType(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oExecutionType);

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

			oDelete = new StringBuilder("DELETE FROM [ExecutionTypes]");

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
			oSelect = new StringBuilder("SELECT * FROM [ExecutionTypes]");

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

		public static ExecutionType LoadOne(Int32 nID_ExecutionType)
		{
			return(LoadOne(nID_ExecutionType, null));
		}

		public static ExecutionType LoadOne(Int32 nID_ExecutionType, SqlConnection oPrivateConnection)
		{
			ExecutionType oExecutionType = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [ExecutionTypes]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_ExecutionType]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_ExecutionType));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oExecutionType = UTI_RowToExecutionType(oRow);
			}

			return (oExecutionType);
		}

		public static ExecutionType TryLoadOne(Int32 nID_ExecutionType)
		{
			return(TryLoadOne(nID_ExecutionType, null));
		}

		public static ExecutionType TryLoadOne(Int32 nID_ExecutionType, SqlConnection oPrivateConnection)
		{
			ExecutionType oExecutionType = null;

			oExecutionType = LoadOne(nID_ExecutionType, null);

			if (oExecutionType == null)
			{
				return (new ExecutionType());
			}
			else
			{
				return (oExecutionType);
			}
		}

		public static void InsertOne(ExecutionType oExecutionType)
		{
			InsertOne(oExecutionType, null);
		}

		public static void InsertOne(ExecutionType oExecutionType, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [ExecutionTypes] ");
			oInsert.Append("([ID_ExecutionType], [Name], [Description])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionType.ID_ExecutionType));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionType.Name));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionType.Description));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(ExecutionType oExecutionType)
		{
			UpdateOne(oExecutionType, null);
		}

		public static void UpdateOne(ExecutionType oExecutionType, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [ExecutionTypes] SET ");

			oUpdate.Append("[Name]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionType.Name));
			oUpdate.Append(", ");
			oUpdate.Append("[Description]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionType.Description));

			oUpdate.Append(UTI_Where4One(oExecutionType));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(ExecutionType oExecutionType)
		{
			DeleteOne(oExecutionType, null);
		}

		public static void DeleteOne(ExecutionType oExecutionType, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [ExecutionTypes]");

			oDelete.Append(UTI_Where4One(oExecutionType));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(ExecutionType oExecutionType)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_ExecutionType]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionType.ID_ExecutionType));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_ExecutionType)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_ExecutionType]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_ExecutionType));

			return (oWhere.ToString());
		}

		public static ExecutionType UTI_RowToExecutionType(DataRow oRow)
		{
			ExecutionType oExecutionType = new ExecutionType();

			oExecutionType.ID_ExecutionType = ((Int32)(oRow["ID_ExecutionType"]));
			oExecutionType.Name = ((String)(oRow["Name"])).Trim();
			oExecutionType.Description = ((String)(oRow["Description"])).Trim();

			return (oExecutionType);
		}
		#endregion
	}

}

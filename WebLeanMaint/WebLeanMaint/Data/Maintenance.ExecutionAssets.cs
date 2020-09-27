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
	/// Public ExecutionAsset Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  27/09/2020  Created
	/// </remarks>
	public partial class ExecutionAssets : EntitiesManagerBase
	{
		#region Public Properties
		public ExecutionAsset this[int nIndex]
		{
			get { return ((ExecutionAsset)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public ExecutionAsset GetByKeys(Int32 nID_ExecutionAsset)
		{
			foreach (ExecutionAsset oExecutionAsset in this.m_aItems)
			{
				if (oExecutionAsset.ID_ExecutionAsset == nID_ExecutionAsset)
				{
					return (oExecutionAsset);
				}
			}

			return (null);
		}

		public ExecutionAsset[] ToArray()
		{
			List<ExecutionAsset> aRet = new List<ExecutionAsset>();
			foreach (ExecutionAsset oExecutionAsset in this.m_aItems)
			{
				aRet.Add(oExecutionAsset);
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
			ExecutionAsset oExecutionAsset = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oExecutionAsset = UTI_RowToExecutionAsset(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oExecutionAsset);

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

			oDelete = new StringBuilder("DELETE FROM [Maintenance].[ExecutionAssets]");

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
			oSelect = new StringBuilder("SELECT * FROM [Maintenance].[ExecutionAssets]");

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

		public static ExecutionAsset LoadOne(Int32 nID_ExecutionAsset, SqlConnection oPrivateConnection = null)
		{
			ExecutionAsset oExecutionAsset = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Maintenance].[ExecutionAssets]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_ExecutionAsset]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_ExecutionAsset));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oExecutionAsset = UTI_RowToExecutionAsset(oRow);
			}

			return (oExecutionAsset);
		}

		public static ExecutionAsset TryLoadOne(Int32 nID_ExecutionAsset, SqlConnection oPrivateConnection = null)
		{
			ExecutionAsset oExecutionAsset = null;

			oExecutionAsset = LoadOne(nID_ExecutionAsset, null);

			if (oExecutionAsset == null)
			{
				return (new ExecutionAsset());
			}
			else
			{
				return (oExecutionAsset);
			}
		}

		public static void InsertOne(ExecutionAsset oExecutionAsset, SqlConnection oPrivateConnection = null)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Maintenance].[ExecutionAssets] ");
			oInsert.Append("([ID_Execution], [ID_Asset], [Stopped], [MinutesUsed], [Description])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionAsset.ID_Execution));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionAsset.ID_Asset));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionAsset.Stopped));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionAsset.MinutesUsed));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionAsset.Description));
			oInsert.Append(")");

			Object oRet;
			oRet = EntitiesManagerBase.DAT_ExecuteScalar(oInsert.ToString(), "\nSELECT @@IDENTITY AS ID", oPrivateConnection);
			oExecutionAsset.ID_ExecutionAsset = Convert.ToInt32(oRet);
		}

		public static void UpdateOne(ExecutionAsset oExecutionAsset, SqlConnection oPrivateConnection = null)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Maintenance].[ExecutionAssets] SET ");

			oUpdate.Append("[ID_Execution]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionAsset.ID_Execution));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_Asset]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionAsset.ID_Asset));
			oUpdate.Append(", ");
			oUpdate.Append("[Stopped]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionAsset.Stopped));
			oUpdate.Append(", ");
			oUpdate.Append("[MinutesUsed]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionAsset.MinutesUsed));
			oUpdate.Append(", ");
			oUpdate.Append("[Description]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionAsset.Description));

			oUpdate.Append(UTI_Where4One(oExecutionAsset));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(ExecutionAsset oExecutionAsset, SqlConnection oPrivateConnection = null)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Maintenance].[ExecutionAssets]");

			oDelete.Append(UTI_Where4One(oExecutionAsset));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static void DeleteOne(Int32 nID_ExecutionAsset, SqlConnection oPrivateConnection=null)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Maintenance].[ExecutionAssets]");

			oDelete.Append(UTI_Where4One(nID_ExecutionAsset));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(ExecutionAsset oExecutionAsset)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_ExecutionAsset]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionAsset.ID_ExecutionAsset));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_ExecutionAsset)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_ExecutionAsset]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_ExecutionAsset));

			return (oWhere.ToString());
		}

		public static ExecutionAsset UTI_RowToExecutionAsset(DataRow oRow)
		{
			ExecutionAsset oExecutionAsset = new ExecutionAsset();

			oExecutionAsset.ID_ExecutionAsset = ((Int32)(oRow["ID_ExecutionAsset"]));
			oExecutionAsset.ID_Execution = ((Int32)(oRow["ID_Execution"]));
			oExecutionAsset.ID_Asset = ((Int32)(oRow["ID_Asset"]));
			oExecutionAsset.Stopped = ((Boolean)(oRow["Stopped"]));
			oExecutionAsset.MinutesUsed = ((Int32)(oRow["MinutesUsed"]));
			oExecutionAsset.Description = ((String)(oRow["Description"])).Trim();

			return (oExecutionAsset);
		}
		#endregion
	}

}

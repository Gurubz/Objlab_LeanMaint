using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Data.dbo
{
	/// <summary>
	/// Public __MigrationHistory Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  03/09/2020  Created
	/// </remarks>
	public class __MigrationHistorys : EntitiesManagerBase
	{
		#region Public Properties
		public __MigrationHistory this[int nIndex]
		{
			get { return ((__MigrationHistory)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public __MigrationHistory GetByKeys(String sMigrationId, String sContextKey)
		{
			foreach (__MigrationHistory o__MigrationHistory in this.m_aItems)
			{
				if (o__MigrationHistory.MigrationId == sMigrationId && o__MigrationHistory.ContextKey == sContextKey)
				{
					return (o__MigrationHistory);
				}
			}

			return (null);
		}

		public __MigrationHistory[] ToArray()
		{
			List<__MigrationHistory> aRet = new List<__MigrationHistory>();
			foreach (__MigrationHistory o__MigrationHistory in this.m_aItems)
			{
				aRet.Add(o__MigrationHistory);
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
			__MigrationHistory o__MigrationHistory = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				o__MigrationHistory = UTI_RowTo__MigrationHistory(oRow);

				// Add entity to internal array
				this.m_aItems.Add(o__MigrationHistory);

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

			oDelete = new StringBuilder("DELETE FROM [dbo].[__MigrationHistory]");

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
			oSelect = new StringBuilder("SELECT * FROM [dbo].[__MigrationHistory]");

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

		public static __MigrationHistory LoadOne(String sMigrationId, String sContextKey)
		{
			return(LoadOne(sMigrationId, sContextKey, null));
		}

		public static __MigrationHistory LoadOne(String sMigrationId, String sContextKey, SqlConnection oPrivateConnection)
		{
			__MigrationHistory o__MigrationHistory = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [dbo].[__MigrationHistory]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[MigrationId]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(sMigrationId));
			oSelect.Append(" AND ");
			oSelect.Append("[ContextKey]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(sContextKey));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				o__MigrationHistory = UTI_RowTo__MigrationHistory(oRow);
			}

			return (o__MigrationHistory);
		}

		public static __MigrationHistory TryLoadOne(String sMigrationId, String sContextKey)
		{
			return(TryLoadOne(sMigrationId, sContextKey, null));
		}

		public static __MigrationHistory TryLoadOne(String sMigrationId, String sContextKey, SqlConnection oPrivateConnection)
		{
			__MigrationHistory o__MigrationHistory = null;

			o__MigrationHistory = LoadOne(sMigrationId, sContextKey, null);

			if (o__MigrationHistory == null)
			{
				return (new __MigrationHistory());
			}
			else
			{
				return (o__MigrationHistory);
			}
		}

		public static void InsertOne(__MigrationHistory o__MigrationHistory)
		{
			InsertOne(o__MigrationHistory, null);
		}

		public static void InsertOne(__MigrationHistory o__MigrationHistory, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [dbo].[__MigrationHistory] ");
			oInsert.Append("([MigrationId], [ContextKey], [Model], [ProductVersion])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(o__MigrationHistory.MigrationId));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(o__MigrationHistory.ContextKey));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(o__MigrationHistory.Model));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(o__MigrationHistory.ProductVersion));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(__MigrationHistory o__MigrationHistory)
		{
			UpdateOne(o__MigrationHistory, null);
		}

		public static void UpdateOne(__MigrationHistory o__MigrationHistory, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [dbo].[__MigrationHistory] SET ");

			oUpdate.Append("[Model]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(o__MigrationHistory.Model));
			oUpdate.Append(", ");
			oUpdate.Append("[ProductVersion]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(o__MigrationHistory.ProductVersion));

			oUpdate.Append(UTI_Where4One(o__MigrationHistory));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(__MigrationHistory o__MigrationHistory)
		{
			DeleteOne(o__MigrationHistory, null);
		}

		public static void DeleteOne(__MigrationHistory o__MigrationHistory, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [dbo].[__MigrationHistory]");

			oDelete.Append(UTI_Where4One(o__MigrationHistory));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(__MigrationHistory o__MigrationHistory)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[MigrationId]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(o__MigrationHistory.MigrationId));
			oWhere.Append(" AND ");
			oWhere.Append("[ContextKey]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(o__MigrationHistory.ContextKey));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(String sMigrationId, String sContextKey)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[MigrationId]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(sMigrationId));
			oWhere.Append(" AND ");
			oWhere.Append("[ContextKey]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(sContextKey));

			return (oWhere.ToString());
		}

		public static __MigrationHistory UTI_RowTo__MigrationHistory(DataRow oRow)
		{
			__MigrationHistory o__MigrationHistory = new __MigrationHistory();

			o__MigrationHistory.MigrationId = ((String)(oRow["MigrationId"])).Trim();
			o__MigrationHistory.ContextKey = ((String)(oRow["ContextKey"])).Trim();
			o__MigrationHistory.Model = ((Byte[])(oRow["Model"]));
			o__MigrationHistory.ProductVersion = ((String)(oRow["ProductVersion"])).Trim();

			return (o__MigrationHistory);
		}
		#endregion
	}

}

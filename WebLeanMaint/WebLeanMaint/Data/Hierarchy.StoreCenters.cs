using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Data.Hierarchy
{
	/// <summary>
	/// Public StoreCenter Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  06/09/2020  Created
	/// </remarks>
	public class StoreCenters : EntitiesManagerBase
	{
		#region Public Properties
		public StoreCenter this[int nIndex]
		{
			get { return ((StoreCenter)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public StoreCenter GetByKeys(Int32 nID_StoreCenter, Int32 nLevel, Int32 nID_StoreCenterChild)
		{
			foreach (StoreCenter oStoreCenter in this.m_aItems)
			{
				if (oStoreCenter.ID_StoreCenter == nID_StoreCenter && oStoreCenter.Level == nLevel && oStoreCenter.ID_StoreCenterChild == nID_StoreCenterChild)
				{
					return (oStoreCenter);
				}
			}

			return (null);
		}

		public StoreCenter[] ToArray()
		{
			List<StoreCenter> aRet = new List<StoreCenter>();
			foreach (StoreCenter oStoreCenter in this.m_aItems)
			{
				aRet.Add(oStoreCenter);
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
			StoreCenter oStoreCenter = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oStoreCenter = UTI_RowToStoreCenter(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oStoreCenter);

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

			oDelete = new StringBuilder("DELETE FROM [Hierarchy].[StoreCenters]");

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
			oSelect = new StringBuilder("SELECT * FROM [Hierarchy].[StoreCenters]");

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

		public static StoreCenter LoadOne(Int32 nID_StoreCenter, Int32 nLevel, Int32 nID_StoreCenterChild)
		{
			return(LoadOne(nID_StoreCenter, nLevel, nID_StoreCenterChild, null));
		}

		public static StoreCenter LoadOne(Int32 nID_StoreCenter, Int32 nLevel, Int32 nID_StoreCenterChild, SqlConnection oPrivateConnection)
		{
			StoreCenter oStoreCenter = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Hierarchy].[StoreCenters]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_StoreCenter]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_StoreCenter));
			oSelect.Append(" AND ");
			oSelect.Append("[Level]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nLevel));
			oSelect.Append(" AND ");
			oSelect.Append("[ID_StoreCenterChild]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_StoreCenterChild));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oStoreCenter = UTI_RowToStoreCenter(oRow);
			}

			return (oStoreCenter);
		}

		public static StoreCenter TryLoadOne(Int32 nID_StoreCenter, Int32 nLevel, Int32 nID_StoreCenterChild)
		{
			return(TryLoadOne(nID_StoreCenter, nLevel, nID_StoreCenterChild, null));
		}

		public static StoreCenter TryLoadOne(Int32 nID_StoreCenter, Int32 nLevel, Int32 nID_StoreCenterChild, SqlConnection oPrivateConnection)
		{
			StoreCenter oStoreCenter = null;

			oStoreCenter = LoadOne(nID_StoreCenter, nLevel, nID_StoreCenterChild, null);

			if (oStoreCenter == null)
			{
				return (new StoreCenter());
			}
			else
			{
				return (oStoreCenter);
			}
		}

		public static void InsertOne(StoreCenter oStoreCenter)
		{
			InsertOne(oStoreCenter, null);
		}

		public static void InsertOne(StoreCenter oStoreCenter, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Hierarchy].[StoreCenters] ");
			oInsert.Append("([ID_StoreCenter], [Level], [ID_StoreCenterChild])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oStoreCenter.ID_StoreCenter));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oStoreCenter.Level));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oStoreCenter.ID_StoreCenterChild));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(StoreCenter oStoreCenter)
		{
			UpdateOne(oStoreCenter, null);
		}

		public static void UpdateOne(StoreCenter oStoreCenter, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Hierarchy].[StoreCenters] SET ");

			oUpdate.Append("[ID_StoreCenter]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oStoreCenter.ID_StoreCenter));
			oUpdate.Append(", ");
			oUpdate.Append("[Level]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oStoreCenter.Level));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_StoreCenterChild]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oStoreCenter.ID_StoreCenterChild));

			oUpdate.Append(UTI_Where4One(oStoreCenter));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(StoreCenter oStoreCenter)
		{
			DeleteOne(oStoreCenter, null);
		}

		public static void DeleteOne(StoreCenter oStoreCenter, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Hierarchy].[StoreCenters]");

			oDelete.Append(UTI_Where4One(oStoreCenter));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(StoreCenter oStoreCenter)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_StoreCenter]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oStoreCenter.ID_StoreCenter));
			oWhere.Append(" AND ");
			oWhere.Append("[Level]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oStoreCenter.Level));
			oWhere.Append(" AND ");
			oWhere.Append("[ID_StoreCenterChild]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oStoreCenter.ID_StoreCenterChild));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_StoreCenter, Int32 nLevel, Int32 nID_StoreCenterChild)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_StoreCenter]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_StoreCenter));
			oWhere.Append(" AND ");
			oWhere.Append("[Level]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nLevel));
			oWhere.Append(" AND ");
			oWhere.Append("[ID_StoreCenterChild]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_StoreCenterChild));

			return (oWhere.ToString());
		}

		public static StoreCenter UTI_RowToStoreCenter(DataRow oRow)
		{
			StoreCenter oStoreCenter = new StoreCenter();

			oStoreCenter.ID_StoreCenter = ((Int32)(oRow["ID_StoreCenter"]));
			oStoreCenter.Level = ((Int32)(oRow["Level"]));
			oStoreCenter.ID_StoreCenterChild = ((Int32)(oRow["ID_StoreCenterChild"]));

			return (oStoreCenter);
		}
		#endregion
	}

}

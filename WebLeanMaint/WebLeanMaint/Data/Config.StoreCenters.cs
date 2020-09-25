using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Data.Config
{
	/// <summary>
	/// Public StoreCenter Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  25/09/2020  Created
	/// </remarks>
	public partial class StoreCenters : EntitiesManagerBase
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

		public StoreCenter GetByKeys(Int32 nID_StoreCenter)
		{
			foreach (StoreCenter oStoreCenter in this.m_aItems)
			{
				if (oStoreCenter.ID_StoreCenter == nID_StoreCenter)
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

			oDelete = new StringBuilder("DELETE FROM [Config].[StoreCenters]");

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
			oSelect = new StringBuilder("SELECT * FROM [Config].[StoreCenters]");

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

		public static StoreCenter LoadOne(Int32 nID_StoreCenter, SqlConnection oPrivateConnection = null)
		{
			StoreCenter oStoreCenter = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Config].[StoreCenters]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_StoreCenter]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_StoreCenter));

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

		public static StoreCenter TryLoadOne(Int32 nID_StoreCenter, SqlConnection oPrivateConnection = null)
		{
			StoreCenter oStoreCenter = null;

			oStoreCenter = LoadOne(nID_StoreCenter, null);

			if (oStoreCenter == null)
			{
				return (new StoreCenter());
			}
			else
			{
				return (oStoreCenter);
			}
		}

		public static void InsertOne(StoreCenter oStoreCenter, SqlConnection oPrivateConnection = null)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Config].[StoreCenters] ");
			oInsert.Append("([Name], [Description], [ID_StoreCenterType], [ID_ObjStatus], [ID_Parent])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oStoreCenter.Name));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oStoreCenter.Description));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oStoreCenter.ID_StoreCenterType));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oStoreCenter.ID_ObjStatus));
			oInsert.Append(", ");
			if (oStoreCenter.ID_Parent_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oStoreCenter.ID_Parent));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(")");

			Object oRet;
			oRet = EntitiesManagerBase.DAT_ExecuteScalar(oInsert.ToString(), "\nSELECT @@IDENTITY AS ID", oPrivateConnection);
			oStoreCenter.ID_StoreCenter = Convert.ToInt32(oRet);
		}

		public static void UpdateOne(StoreCenter oStoreCenter, SqlConnection oPrivateConnection = null)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Config].[StoreCenters] SET ");

			oUpdate.Append("[Name]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oStoreCenter.Name));
			oUpdate.Append(", ");
			oUpdate.Append("[Description]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oStoreCenter.Description));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_StoreCenterType]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oStoreCenter.ID_StoreCenterType));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_ObjStatus]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oStoreCenter.ID_ObjStatus));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_Parent]=");
			if (oStoreCenter.ID_Parent_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oStoreCenter.ID_Parent));
			} else {
			oUpdate.Append("NULL");
			}

			oUpdate.Append(UTI_Where4One(oStoreCenter));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(StoreCenter oStoreCenter, SqlConnection oPrivateConnection = null)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Config].[StoreCenters]");

			oDelete.Append(UTI_Where4One(oStoreCenter));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static void DeleteOne(Int32 nID_StoreCenter, SqlConnection oPrivateConnection=null)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Config].[StoreCenters]");

			oDelete.Append(UTI_Where4One(nID_StoreCenter));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(StoreCenter oStoreCenter)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_StoreCenter]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oStoreCenter.ID_StoreCenter));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_StoreCenter)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_StoreCenter]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_StoreCenter));

			return (oWhere.ToString());
		}

		public static StoreCenter UTI_RowToStoreCenter(DataRow oRow)
		{
			StoreCenter oStoreCenter = new StoreCenter();

			oStoreCenter.ID_StoreCenter = ((Int32)(oRow["ID_StoreCenter"]));
			oStoreCenter.Name = ((String)(oRow["Name"])).Trim();
			oStoreCenter.Description = ((String)(oRow["Description"])).Trim();
			oStoreCenter.ID_StoreCenterType = ((Int32)(oRow["ID_StoreCenterType"]));
			oStoreCenter.ID_ObjStatus = ((Int32)(oRow["ID_ObjStatus"]));
			if (!(oRow["ID_Parent"] is DBNull)) {
			  oStoreCenter.ID_Parent = ((Int32)(oRow["ID_Parent"]));
			  oStoreCenter.ID_Parent_HasValue = true;
			} else {
			  oStoreCenter.ID_Parent_HasValue = false;
			}

			return (oStoreCenter);
		}
		#endregion
	}

}

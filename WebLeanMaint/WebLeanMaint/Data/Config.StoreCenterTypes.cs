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
	/// Public StoreCenterType Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  08/09/2020  Created
	/// </remarks>
	public class StoreCenterTypes : EntitiesManagerBase
	{
		#region Public Properties
		public StoreCenterType this[int nIndex]
		{
			get { return ((StoreCenterType)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public StoreCenterType GetByKeys(Int32 nID_StoreCenterType)
		{
			foreach (StoreCenterType oStoreCenterType in this.m_aItems)
			{
				if (oStoreCenterType.ID_StoreCenterType == nID_StoreCenterType)
				{
					return (oStoreCenterType);
				}
			}

			return (null);
		}

		public StoreCenterType[] ToArray()
		{
			List<StoreCenterType> aRet = new List<StoreCenterType>();
			foreach (StoreCenterType oStoreCenterType in this.m_aItems)
			{
				aRet.Add(oStoreCenterType);
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
			StoreCenterType oStoreCenterType = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oStoreCenterType = UTI_RowToStoreCenterType(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oStoreCenterType);

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

			oDelete = new StringBuilder("DELETE FROM [Config].[StoreCenterTypes]");

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
			oSelect = new StringBuilder("SELECT * FROM [Config].[StoreCenterTypes]");

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

		public static StoreCenterType LoadOne(Int32 nID_StoreCenterType)
		{
			return(LoadOne(nID_StoreCenterType, null));
		}

		public static StoreCenterType LoadOne(Int32 nID_StoreCenterType, SqlConnection oPrivateConnection)
		{
			StoreCenterType oStoreCenterType = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Config].[StoreCenterTypes]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_StoreCenterType]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_StoreCenterType));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oStoreCenterType = UTI_RowToStoreCenterType(oRow);
			}

			return (oStoreCenterType);
		}

		public static StoreCenterType TryLoadOne(Int32 nID_StoreCenterType)
		{
			return(TryLoadOne(nID_StoreCenterType, null));
		}

		public static StoreCenterType TryLoadOne(Int32 nID_StoreCenterType, SqlConnection oPrivateConnection)
		{
			StoreCenterType oStoreCenterType = null;

			oStoreCenterType = LoadOne(nID_StoreCenterType, null);

			if (oStoreCenterType == null)
			{
				return (new StoreCenterType());
			}
			else
			{
				return (oStoreCenterType);
			}
		}

		public static void InsertOne(StoreCenterType oStoreCenterType)
		{
			InsertOne(oStoreCenterType, null);
		}

		public static void InsertOne(StoreCenterType oStoreCenterType, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Config].[StoreCenterTypes] ");
			oInsert.Append("([ID_StoreCenterType], [Name], [Description])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oStoreCenterType.ID_StoreCenterType));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oStoreCenterType.Name));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oStoreCenterType.Description));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(StoreCenterType oStoreCenterType)
		{
			UpdateOne(oStoreCenterType, null);
		}

		public static void UpdateOne(StoreCenterType oStoreCenterType, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Config].[StoreCenterTypes] SET ");

			oUpdate.Append("[Name]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oStoreCenterType.Name));
			oUpdate.Append(", ");
			oUpdate.Append("[Description]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oStoreCenterType.Description));

			oUpdate.Append(UTI_Where4One(oStoreCenterType));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(StoreCenterType oStoreCenterType)
		{
			DeleteOne(oStoreCenterType, null);
		}

		public static void DeleteOne(StoreCenterType oStoreCenterType, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Config].[StoreCenterTypes]");

			oDelete.Append(UTI_Where4One(oStoreCenterType));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(StoreCenterType oStoreCenterType)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_StoreCenterType]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oStoreCenterType.ID_StoreCenterType));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_StoreCenterType)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_StoreCenterType]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_StoreCenterType));

			return (oWhere.ToString());
		}

		public static StoreCenterType UTI_RowToStoreCenterType(DataRow oRow)
		{
			StoreCenterType oStoreCenterType = new StoreCenterType();

			oStoreCenterType.ID_StoreCenterType = ((Int32)(oRow["ID_StoreCenterType"]));
			oStoreCenterType.Name = ((String)(oRow["Name"])).Trim();
			oStoreCenterType.Description = ((String)(oRow["Description"])).Trim();

			return (oStoreCenterType);
		}
		#endregion
	}

}

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
	/// Public AssetType Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  27/09/2020  Created
	/// </remarks>
	public partial class AssetTypes : EntitiesManagerBase
	{
		#region Public Properties
		public AssetType this[int nIndex]
		{
			get { return ((AssetType)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public AssetType GetByKeys(Int32 nID_AssetType)
		{
			foreach (AssetType oAssetType in this.m_aItems)
			{
				if (oAssetType.ID_AssetType == nID_AssetType)
				{
					return (oAssetType);
				}
			}

			return (null);
		}

		public AssetType[] ToArray()
		{
			List<AssetType> aRet = new List<AssetType>();
			foreach (AssetType oAssetType in this.m_aItems)
			{
				aRet.Add(oAssetType);
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
			AssetType oAssetType = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oAssetType = UTI_RowToAssetType(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oAssetType);

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

			oDelete = new StringBuilder("DELETE FROM [Maintenance].[AssetTypes]");

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
			oSelect = new StringBuilder("SELECT * FROM [Maintenance].[AssetTypes]");

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

		public static AssetType LoadOne(Int32 nID_AssetType, SqlConnection oPrivateConnection = null)
		{
			AssetType oAssetType = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Maintenance].[AssetTypes]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_AssetType]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_AssetType));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oAssetType = UTI_RowToAssetType(oRow);
			}

			return (oAssetType);
		}

		public static AssetType TryLoadOne(Int32 nID_AssetType, SqlConnection oPrivateConnection = null)
		{
			AssetType oAssetType = null;

			oAssetType = LoadOne(nID_AssetType, null);

			if (oAssetType == null)
			{
				return (new AssetType());
			}
			else
			{
				return (oAssetType);
			}
		}

		public static void InsertOne(AssetType oAssetType, SqlConnection oPrivateConnection = null)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Maintenance].[AssetTypes] ");
			oInsert.Append("([ID_AssetType], [Name], [Description])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAssetType.ID_AssetType));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAssetType.Name));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAssetType.Description));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(AssetType oAssetType, SqlConnection oPrivateConnection = null)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Maintenance].[AssetTypes] SET ");

			oUpdate.Append("[Name]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAssetType.Name));
			oUpdate.Append(", ");
			oUpdate.Append("[Description]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAssetType.Description));

			oUpdate.Append(UTI_Where4One(oAssetType));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(AssetType oAssetType, SqlConnection oPrivateConnection = null)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Maintenance].[AssetTypes]");

			oDelete.Append(UTI_Where4One(oAssetType));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static void DeleteOne(Int32 nID_AssetType, SqlConnection oPrivateConnection=null)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Maintenance].[AssetTypes]");

			oDelete.Append(UTI_Where4One(nID_AssetType));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(AssetType oAssetType)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_AssetType]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oAssetType.ID_AssetType));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_AssetType)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_AssetType]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_AssetType));

			return (oWhere.ToString());
		}

		public static AssetType UTI_RowToAssetType(DataRow oRow)
		{
			AssetType oAssetType = new AssetType();

			oAssetType.ID_AssetType = ((Int32)(oRow["ID_AssetType"]));
			oAssetType.Name = ((String)(oRow["Name"])).Trim();
			oAssetType.Description = ((String)(oRow["Description"])).Trim();

			return (oAssetType);
		}
		#endregion
	}

}

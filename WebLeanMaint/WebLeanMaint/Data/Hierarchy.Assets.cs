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
	/// Public Asset Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  24/09/2020  Created
	/// </remarks>
	public partial class Assets : EntitiesManagerBase
	{
		#region Public Properties
		public Asset this[int nIndex]
		{
			get { return ((Asset)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public Asset GetByKeys(Int32 nID_Asset, Int32 nLevel, Int32 nID_AssetChild)
		{
			foreach (Asset oAsset in this.m_aItems)
			{
				if (oAsset.ID_Asset == nID_Asset && oAsset.Level == nLevel && oAsset.ID_AssetChild == nID_AssetChild)
				{
					return (oAsset);
				}
			}

			return (null);
		}

		public Asset[] ToArray()
		{
			List<Asset> aRet = new List<Asset>();
			foreach (Asset oAsset in this.m_aItems)
			{
				aRet.Add(oAsset);
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
			Asset oAsset = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oAsset = UTI_RowToAsset(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oAsset);

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

			oDelete = new StringBuilder("DELETE FROM [Hierarchy].[Assets]");

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
			oSelect = new StringBuilder("SELECT * FROM [Hierarchy].[Assets]");

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

		public static Asset LoadOne(Int32 nID_Asset, Int32 nLevel, Int32 nID_AssetChild)
		{
			return(LoadOne(nID_Asset, nLevel, nID_AssetChild, null));
		}

		public static Asset LoadOne(Int32 nID_Asset, Int32 nLevel, Int32 nID_AssetChild, SqlConnection oPrivateConnection)
		{
			Asset oAsset = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Hierarchy].[Assets]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_Asset]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Asset));
			oSelect.Append(" AND ");
			oSelect.Append("[Level]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nLevel));
			oSelect.Append(" AND ");
			oSelect.Append("[ID_AssetChild]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_AssetChild));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oAsset = UTI_RowToAsset(oRow);
			}

			return (oAsset);
		}

		public static Asset TryLoadOne(Int32 nID_Asset, Int32 nLevel, Int32 nID_AssetChild)
		{
			return(TryLoadOne(nID_Asset, nLevel, nID_AssetChild, null));
		}

		public static Asset TryLoadOne(Int32 nID_Asset, Int32 nLevel, Int32 nID_AssetChild, SqlConnection oPrivateConnection)
		{
			Asset oAsset = null;

			oAsset = LoadOne(nID_Asset, nLevel, nID_AssetChild, null);

			if (oAsset == null)
			{
				return (new Asset());
			}
			else
			{
				return (oAsset);
			}
		}

		public static void InsertOne(Asset oAsset)
		{
			InsertOne(oAsset, null);
		}

		public static void InsertOne(Asset oAsset, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Hierarchy].[Assets] ");
			oInsert.Append("([ID_Asset], [Level], [ID_AssetChild])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAsset.ID_Asset));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAsset.Level));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAsset.ID_AssetChild));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(Asset oAsset)
		{
			UpdateOne(oAsset, null);
		}

		public static void UpdateOne(Asset oAsset, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Hierarchy].[Assets] SET ");

			oUpdate.Append("[ID_Asset]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAsset.ID_Asset));
			oUpdate.Append(", ");
			oUpdate.Append("[Level]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAsset.Level));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_AssetChild]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAsset.ID_AssetChild));

			oUpdate.Append(UTI_Where4One(oAsset));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(Asset oAsset)
		{
			DeleteOne(oAsset, null);
		}

		public static void DeleteOne(Asset oAsset, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Hierarchy].[Assets]");

			oDelete.Append(UTI_Where4One(oAsset));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(Asset oAsset)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Asset]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oAsset.ID_Asset));
			oWhere.Append(" AND ");
			oWhere.Append("[Level]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oAsset.Level));
			oWhere.Append(" AND ");
			oWhere.Append("[ID_AssetChild]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oAsset.ID_AssetChild));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_Asset, Int32 nLevel, Int32 nID_AssetChild)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Asset]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Asset));
			oWhere.Append(" AND ");
			oWhere.Append("[Level]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nLevel));
			oWhere.Append(" AND ");
			oWhere.Append("[ID_AssetChild]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_AssetChild));

			return (oWhere.ToString());
		}

		public static Asset UTI_RowToAsset(DataRow oRow)
		{
			Asset oAsset = new Asset();

			oAsset.ID_Asset = ((Int32)(oRow["ID_Asset"]));
			oAsset.Level = ((Int32)(oRow["Level"]));
			oAsset.ID_AssetChild = ((Int32)(oRow["ID_AssetChild"]));

			return (oAsset);
		}
		#endregion
	}

}

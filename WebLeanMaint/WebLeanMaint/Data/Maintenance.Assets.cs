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

		public Asset GetByKeys(Int32 nID_Asset)
		{
			foreach (Asset oAsset in this.m_aItems)
			{
				if (oAsset.ID_Asset == nID_Asset)
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

			oDelete = new StringBuilder("DELETE FROM [Maintenance].[Assets]");

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
			oSelect = new StringBuilder("SELECT * FROM [Maintenance].[Assets]");

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

		public static Asset LoadOne(Int32 nID_Asset)
		{
			return(LoadOne(nID_Asset, null));
		}

		public static Asset LoadOne(Int32 nID_Asset, SqlConnection oPrivateConnection)
		{
			Asset oAsset = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Maintenance].[Assets]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_Asset]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Asset));

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

		public static Asset TryLoadOne(Int32 nID_Asset)
		{
			return(TryLoadOne(nID_Asset, null));
		}

		public static Asset TryLoadOne(Int32 nID_Asset, SqlConnection oPrivateConnection)
		{
			Asset oAsset = null;

			oAsset = LoadOne(nID_Asset, null);

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

			oInsert = new StringBuilder("INSERT INTO [Maintenance].[Assets] ");
			oInsert.Append("([Name], [Description], [ID_AssetType], [Barcode], [ID_OrganizationCenter], [ID_CostCenter], [ID_GeographicCenter], [ID_ObjStatus], [ID_Parent])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAsset.Name));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAsset.Description));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAsset.ID_AssetType));
			oInsert.Append(", ");
			if (oAsset.Barcode_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAsset.Barcode));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAsset.ID_OrganizationCenter));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAsset.ID_CostCenter));
			oInsert.Append(", ");
			if (oAsset.ID_GeographicCenter_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAsset.ID_GeographicCenter));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAsset.ID_ObjStatus));
			oInsert.Append(", ");
			if (oAsset.ID_Parent_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAsset.ID_Parent));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(")");

			Object oRet;
			oRet = EntitiesManagerBase.DAT_ExecuteScalar(oInsert.ToString(), "\nSELECT @@IDENTITY AS ID", oPrivateConnection);
			oAsset.ID_Asset = Convert.ToInt32(oRet);
		}

		public static void UpdateOne(Asset oAsset)
		{
			UpdateOne(oAsset, null);
		}

		public static void UpdateOne(Asset oAsset, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Maintenance].[Assets] SET ");

			oUpdate.Append("[Name]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAsset.Name));
			oUpdate.Append(", ");
			oUpdate.Append("[Description]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAsset.Description));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_AssetType]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAsset.ID_AssetType));
			oUpdate.Append(", ");
			oUpdate.Append("[Barcode]=");
			if (oAsset.Barcode_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAsset.Barcode));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[ID_OrganizationCenter]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAsset.ID_OrganizationCenter));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_CostCenter]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAsset.ID_CostCenter));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_GeographicCenter]=");
			if (oAsset.ID_GeographicCenter_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAsset.ID_GeographicCenter));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[ID_ObjStatus]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAsset.ID_ObjStatus));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_Parent]=");
			if (oAsset.ID_Parent_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAsset.ID_Parent));
			} else {
			oUpdate.Append("NULL");
			}

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

			oDelete = new StringBuilder("DELETE FROM [Maintenance].[Assets]");

			oDelete.Append(UTI_Where4One(oAsset));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(Asset oAsset)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Asset]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oAsset.ID_Asset));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_Asset)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Asset]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Asset));

			return (oWhere.ToString());
		}

		public static Asset UTI_RowToAsset(DataRow oRow)
		{
			Asset oAsset = new Asset();

			oAsset.ID_Asset = ((Int32)(oRow["ID_Asset"]));
			oAsset.Name = ((String)(oRow["Name"])).Trim();
			oAsset.Description = ((String)(oRow["Description"])).Trim();
			oAsset.ID_AssetType = ((Int32)(oRow["ID_AssetType"]));
			if (!(oRow["Barcode"] is DBNull)) {
			  oAsset.Barcode = ((String)(oRow["Barcode"])).Trim();
			  oAsset.Barcode_HasValue = true;
			} else {
			  oAsset.Barcode_HasValue = false;
			}
			oAsset.ID_OrganizationCenter = ((Int32)(oRow["ID_OrganizationCenter"]));
			oAsset.ID_CostCenter = ((Int32)(oRow["ID_CostCenter"]));
			if (!(oRow["ID_GeographicCenter"] is DBNull)) {
			  oAsset.ID_GeographicCenter = ((Int32)(oRow["ID_GeographicCenter"]));
			  oAsset.ID_GeographicCenter_HasValue = true;
			} else {
			  oAsset.ID_GeographicCenter_HasValue = false;
			}
			oAsset.ID_ObjStatus = ((Int32)(oRow["ID_ObjStatus"]));
			if (!(oRow["ID_Parent"] is DBNull)) {
			  oAsset.ID_Parent = ((Int32)(oRow["ID_Parent"]));
			  oAsset.ID_Parent_HasValue = true;
			} else {
			  oAsset.ID_Parent_HasValue = false;
			}

			return (oAsset);
		}
		#endregion
	}

}

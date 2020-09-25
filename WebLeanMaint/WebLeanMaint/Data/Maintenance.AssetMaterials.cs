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
	/// Public AssetMaterial Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  25/09/2020  Created
	/// </remarks>
	public partial class AssetMaterials : EntitiesManagerBase
	{
		#region Public Properties
		public AssetMaterial this[int nIndex]
		{
			get { return ((AssetMaterial)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public AssetMaterial GetByKeys(Int32 nID_Asset, Int32 nID_Material)
		{
			foreach (AssetMaterial oAssetMaterial in this.m_aItems)
			{
				if (oAssetMaterial.ID_Asset == nID_Asset && oAssetMaterial.ID_Material == nID_Material)
				{
					return (oAssetMaterial);
				}
			}

			return (null);
		}

		public AssetMaterial[] ToArray()
		{
			List<AssetMaterial> aRet = new List<AssetMaterial>();
			foreach (AssetMaterial oAssetMaterial in this.m_aItems)
			{
				aRet.Add(oAssetMaterial);
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
			AssetMaterial oAssetMaterial = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oAssetMaterial = UTI_RowToAssetMaterial(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oAssetMaterial);

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

			oDelete = new StringBuilder("DELETE FROM [Maintenance].[AssetMaterials]");

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
			oSelect = new StringBuilder("SELECT * FROM [Maintenance].[AssetMaterials]");

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

		public static AssetMaterial LoadOne(Int32 nID_Asset, Int32 nID_Material, SqlConnection oPrivateConnection = null)
		{
			AssetMaterial oAssetMaterial = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Maintenance].[AssetMaterials]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_Asset]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Asset));
			oSelect.Append(" AND ");
			oSelect.Append("[ID_Material]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Material));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oAssetMaterial = UTI_RowToAssetMaterial(oRow);
			}

			return (oAssetMaterial);
		}

		public static AssetMaterial TryLoadOne(Int32 nID_Asset, Int32 nID_Material, SqlConnection oPrivateConnection = null)
		{
			AssetMaterial oAssetMaterial = null;

			oAssetMaterial = LoadOne(nID_Asset, nID_Material, null);

			if (oAssetMaterial == null)
			{
				return (new AssetMaterial());
			}
			else
			{
				return (oAssetMaterial);
			}
		}

		public static void InsertOne(AssetMaterial oAssetMaterial, SqlConnection oPrivateConnection = null)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Maintenance].[AssetMaterials] ");
			oInsert.Append("([ID_Asset], [ID_Material])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAssetMaterial.ID_Asset));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAssetMaterial.ID_Material));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(AssetMaterial oAssetMaterial, SqlConnection oPrivateConnection = null)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Maintenance].[AssetMaterials] SET ");


			oUpdate.Append(UTI_Where4One(oAssetMaterial));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(AssetMaterial oAssetMaterial, SqlConnection oPrivateConnection = null)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Maintenance].[AssetMaterials]");

			oDelete.Append(UTI_Where4One(oAssetMaterial));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static void DeleteOne(Int32 nID_Asset, Int32 nID_Material, SqlConnection oPrivateConnection=null)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Maintenance].[AssetMaterials]");

			oDelete.Append(UTI_Where4One(nID_Asset, nID_Material));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(AssetMaterial oAssetMaterial)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Asset]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oAssetMaterial.ID_Asset));
			oWhere.Append(" AND ");
			oWhere.Append("[ID_Material]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oAssetMaterial.ID_Material));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_Asset, Int32 nID_Material)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Asset]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Asset));
			oWhere.Append(" AND ");
			oWhere.Append("[ID_Material]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Material));

			return (oWhere.ToString());
		}

		public static AssetMaterial UTI_RowToAssetMaterial(DataRow oRow)
		{
			AssetMaterial oAssetMaterial = new AssetMaterial();

			oAssetMaterial.ID_Asset = ((Int32)(oRow["ID_Asset"]));
			oAssetMaterial.ID_Material = ((Int32)(oRow["ID_Material"]));

			return (oAssetMaterial);
		}
		#endregion
	}

}

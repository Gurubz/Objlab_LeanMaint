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
	/// Public MaterialAsset Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  03/09/2020  Created
	/// </remarks>
	public class MaterialAssets : EntitiesManagerBase
	{
		#region Public Properties
		public MaterialAsset this[int nIndex]
		{
			get { return ((MaterialAsset)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public MaterialAsset GetByKeys(Int32 nID_Material, Int32 nID_Asset)
		{
			foreach (MaterialAsset oMaterialAsset in this.m_aItems)
			{
				if (oMaterialAsset.ID_Material == nID_Material && oMaterialAsset.ID_Asset == nID_Asset)
				{
					return (oMaterialAsset);
				}
			}

			return (null);
		}

		public MaterialAsset[] ToArray()
		{
			List<MaterialAsset> aRet = new List<MaterialAsset>();
			foreach (MaterialAsset oMaterialAsset in this.m_aItems)
			{
				aRet.Add(oMaterialAsset);
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
			MaterialAsset oMaterialAsset = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oMaterialAsset = UTI_RowToMaterialAsset(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oMaterialAsset);

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

			oDelete = new StringBuilder("DELETE FROM [Maintenance].[MaterialAssets]");

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
			oSelect = new StringBuilder("SELECT * FROM [Maintenance].[MaterialAssets]");

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

		public static MaterialAsset LoadOne(Int32 nID_Material, Int32 nID_Asset)
		{
			return(LoadOne(nID_Material, nID_Asset, null));
		}

		public static MaterialAsset LoadOne(Int32 nID_Material, Int32 nID_Asset, SqlConnection oPrivateConnection)
		{
			MaterialAsset oMaterialAsset = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Maintenance].[MaterialAssets]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_Material]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Material));
			oSelect.Append(" AND ");
			oSelect.Append("[ID_Asset]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Asset));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oMaterialAsset = UTI_RowToMaterialAsset(oRow);
			}

			return (oMaterialAsset);
		}

		public static MaterialAsset TryLoadOne(Int32 nID_Material, Int32 nID_Asset)
		{
			return(TryLoadOne(nID_Material, nID_Asset, null));
		}

		public static MaterialAsset TryLoadOne(Int32 nID_Material, Int32 nID_Asset, SqlConnection oPrivateConnection)
		{
			MaterialAsset oMaterialAsset = null;

			oMaterialAsset = LoadOne(nID_Material, nID_Asset, null);

			if (oMaterialAsset == null)
			{
				return (new MaterialAsset());
			}
			else
			{
				return (oMaterialAsset);
			}
		}

		public static void InsertOne(MaterialAsset oMaterialAsset)
		{
			InsertOne(oMaterialAsset, null);
		}

		public static void InsertOne(MaterialAsset oMaterialAsset, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Maintenance].[MaterialAssets] ");
			oInsert.Append("([ID_Material], [ID_Asset])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oMaterialAsset.ID_Material));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oMaterialAsset.ID_Asset));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(MaterialAsset oMaterialAsset)
		{
			UpdateOne(oMaterialAsset, null);
		}

		public static void UpdateOne(MaterialAsset oMaterialAsset, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Maintenance].[MaterialAssets] SET ");


			oUpdate.Append(UTI_Where4One(oMaterialAsset));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(MaterialAsset oMaterialAsset)
		{
			DeleteOne(oMaterialAsset, null);
		}

		public static void DeleteOne(MaterialAsset oMaterialAsset, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Maintenance].[MaterialAssets]");

			oDelete.Append(UTI_Where4One(oMaterialAsset));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(MaterialAsset oMaterialAsset)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Material]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oMaterialAsset.ID_Material));
			oWhere.Append(" AND ");
			oWhere.Append("[ID_Asset]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oMaterialAsset.ID_Asset));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_Material, Int32 nID_Asset)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Material]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Material));
			oWhere.Append(" AND ");
			oWhere.Append("[ID_Asset]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Asset));

			return (oWhere.ToString());
		}

		public static MaterialAsset UTI_RowToMaterialAsset(DataRow oRow)
		{
			MaterialAsset oMaterialAsset = new MaterialAsset();

			oMaterialAsset.ID_Material = ((Int32)(oRow["ID_Material"]));
			oMaterialAsset.ID_Asset = ((Int32)(oRow["ID_Asset"]));

			return (oMaterialAsset);
		}
		#endregion
	}

}

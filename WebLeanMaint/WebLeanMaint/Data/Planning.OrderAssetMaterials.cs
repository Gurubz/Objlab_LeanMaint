using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Data.Planning
{
	/// <summary>
	/// Public OrderAssetMaterial Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  18/09/2020  Created
	/// </remarks>
	public class OrderAssetMaterials : EntitiesManagerBase
	{
		#region Public Properties
		public OrderAssetMaterial this[int nIndex]
		{
			get { return ((OrderAssetMaterial)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public OrderAssetMaterial GetByKeys(Int32 nID_OrderAsset, Int32 nID_Material)
		{
			foreach (OrderAssetMaterial oOrderAssetMaterial in this.m_aItems)
			{
				if (oOrderAssetMaterial.ID_OrderAsset == nID_OrderAsset && oOrderAssetMaterial.ID_Material == nID_Material)
				{
					return (oOrderAssetMaterial);
				}
			}

			return (null);
		}

		public OrderAssetMaterial[] ToArray()
		{
			List<OrderAssetMaterial> aRet = new List<OrderAssetMaterial>();
			foreach (OrderAssetMaterial oOrderAssetMaterial in this.m_aItems)
			{
				aRet.Add(oOrderAssetMaterial);
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
			OrderAssetMaterial oOrderAssetMaterial = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oOrderAssetMaterial = UTI_RowToOrderAssetMaterial(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oOrderAssetMaterial);

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

			oDelete = new StringBuilder("DELETE FROM [Planning].[OrderAssetMaterials]");

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
			oSelect = new StringBuilder("SELECT * FROM [Planning].[OrderAssetMaterials]");

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

		public static OrderAssetMaterial LoadOne(Int32 nID_OrderAsset, Int32 nID_Material)
		{
			return(LoadOne(nID_OrderAsset, nID_Material, null));
		}

		public static OrderAssetMaterial LoadOne(Int32 nID_OrderAsset, Int32 nID_Material, SqlConnection oPrivateConnection)
		{
			OrderAssetMaterial oOrderAssetMaterial = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Planning].[OrderAssetMaterials]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_OrderAsset]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_OrderAsset));
			oSelect.Append(" AND ");
			oSelect.Append("[ID_Material]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Material));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oOrderAssetMaterial = UTI_RowToOrderAssetMaterial(oRow);
			}

			return (oOrderAssetMaterial);
		}

		public static OrderAssetMaterial TryLoadOne(Int32 nID_OrderAsset, Int32 nID_Material)
		{
			return(TryLoadOne(nID_OrderAsset, nID_Material, null));
		}

		public static OrderAssetMaterial TryLoadOne(Int32 nID_OrderAsset, Int32 nID_Material, SqlConnection oPrivateConnection)
		{
			OrderAssetMaterial oOrderAssetMaterial = null;

			oOrderAssetMaterial = LoadOne(nID_OrderAsset, nID_Material, null);

			if (oOrderAssetMaterial == null)
			{
				return (new OrderAssetMaterial());
			}
			else
			{
				return (oOrderAssetMaterial);
			}
		}

		public static void InsertOne(OrderAssetMaterial oOrderAssetMaterial)
		{
			InsertOne(oOrderAssetMaterial, null);
		}

		public static void InsertOne(OrderAssetMaterial oOrderAssetMaterial, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Planning].[OrderAssetMaterials] ");
			oInsert.Append("([ID_OrderAsset], [ID_Material], [Quantity])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOrderAssetMaterial.ID_OrderAsset));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOrderAssetMaterial.ID_Material));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOrderAssetMaterial.Quantity));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(OrderAssetMaterial oOrderAssetMaterial)
		{
			UpdateOne(oOrderAssetMaterial, null);
		}

		public static void UpdateOne(OrderAssetMaterial oOrderAssetMaterial, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Planning].[OrderAssetMaterials] SET ");

			oUpdate.Append("[Quantity]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOrderAssetMaterial.Quantity));

			oUpdate.Append(UTI_Where4One(oOrderAssetMaterial));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(OrderAssetMaterial oOrderAssetMaterial)
		{
			DeleteOne(oOrderAssetMaterial, null);
		}

		public static void DeleteOne(OrderAssetMaterial oOrderAssetMaterial, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Planning].[OrderAssetMaterials]");

			oDelete.Append(UTI_Where4One(oOrderAssetMaterial));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(OrderAssetMaterial oOrderAssetMaterial)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_OrderAsset]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oOrderAssetMaterial.ID_OrderAsset));
			oWhere.Append(" AND ");
			oWhere.Append("[ID_Material]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oOrderAssetMaterial.ID_Material));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_OrderAsset, Int32 nID_Material)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_OrderAsset]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_OrderAsset));
			oWhere.Append(" AND ");
			oWhere.Append("[ID_Material]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Material));

			return (oWhere.ToString());
		}

		public static OrderAssetMaterial UTI_RowToOrderAssetMaterial(DataRow oRow)
		{
			OrderAssetMaterial oOrderAssetMaterial = new OrderAssetMaterial();

			oOrderAssetMaterial.ID_OrderAsset = ((Int32)(oRow["ID_OrderAsset"]));
			oOrderAssetMaterial.ID_Material = ((Int32)(oRow["ID_Material"]));
			oOrderAssetMaterial.Quantity = ((Decimal)(oRow["Quantity"]));

			return (oOrderAssetMaterial);
		}
		#endregion
	}

}

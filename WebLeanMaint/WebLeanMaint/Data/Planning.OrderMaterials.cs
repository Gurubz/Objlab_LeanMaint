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
	/// Public OrderMaterial Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  06/09/2020  Created
	/// </remarks>
	public class OrderMaterials : EntitiesManagerBase
	{
		#region Public Properties
		public OrderMaterial this[int nIndex]
		{
			get { return ((OrderMaterial)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public OrderMaterial GetByKeys(Int32 nID_Order, Int32 nID_Material)
		{
			foreach (OrderMaterial oOrderMaterial in this.m_aItems)
			{
				if (oOrderMaterial.ID_Order == nID_Order && oOrderMaterial.ID_Material == nID_Material)
				{
					return (oOrderMaterial);
				}
			}

			return (null);
		}

		public OrderMaterial[] ToArray()
		{
			List<OrderMaterial> aRet = new List<OrderMaterial>();
			foreach (OrderMaterial oOrderMaterial in this.m_aItems)
			{
				aRet.Add(oOrderMaterial);
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
			OrderMaterial oOrderMaterial = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oOrderMaterial = UTI_RowToOrderMaterial(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oOrderMaterial);

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

			oDelete = new StringBuilder("DELETE FROM [Planning].[OrderMaterials]");

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
			oSelect = new StringBuilder("SELECT * FROM [Planning].[OrderMaterials]");

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

		public static OrderMaterial LoadOne(Int32 nID_Order, Int32 nID_Material)
		{
			return(LoadOne(nID_Order, nID_Material, null));
		}

		public static OrderMaterial LoadOne(Int32 nID_Order, Int32 nID_Material, SqlConnection oPrivateConnection)
		{
			OrderMaterial oOrderMaterial = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Planning].[OrderMaterials]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_Order]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Order));
			oSelect.Append(" AND ");
			oSelect.Append("[ID_Material]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Material));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oOrderMaterial = UTI_RowToOrderMaterial(oRow);
			}

			return (oOrderMaterial);
		}

		public static OrderMaterial TryLoadOne(Int32 nID_Order, Int32 nID_Material)
		{
			return(TryLoadOne(nID_Order, nID_Material, null));
		}

		public static OrderMaterial TryLoadOne(Int32 nID_Order, Int32 nID_Material, SqlConnection oPrivateConnection)
		{
			OrderMaterial oOrderMaterial = null;

			oOrderMaterial = LoadOne(nID_Order, nID_Material, null);

			if (oOrderMaterial == null)
			{
				return (new OrderMaterial());
			}
			else
			{
				return (oOrderMaterial);
			}
		}

		public static void InsertOne(OrderMaterial oOrderMaterial)
		{
			InsertOne(oOrderMaterial, null);
		}

		public static void InsertOne(OrderMaterial oOrderMaterial, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Planning].[OrderMaterials] ");
			oInsert.Append("([ID_Order], [ID_Material], [Quantity])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOrderMaterial.ID_Order));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOrderMaterial.ID_Material));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOrderMaterial.Quantity));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(OrderMaterial oOrderMaterial)
		{
			UpdateOne(oOrderMaterial, null);
		}

		public static void UpdateOne(OrderMaterial oOrderMaterial, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Planning].[OrderMaterials] SET ");

			oUpdate.Append("[Quantity]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOrderMaterial.Quantity));

			oUpdate.Append(UTI_Where4One(oOrderMaterial));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(OrderMaterial oOrderMaterial)
		{
			DeleteOne(oOrderMaterial, null);
		}

		public static void DeleteOne(OrderMaterial oOrderMaterial, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Planning].[OrderMaterials]");

			oDelete.Append(UTI_Where4One(oOrderMaterial));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(OrderMaterial oOrderMaterial)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Order]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oOrderMaterial.ID_Order));
			oWhere.Append(" AND ");
			oWhere.Append("[ID_Material]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oOrderMaterial.ID_Material));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_Order, Int32 nID_Material)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Order]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Order));
			oWhere.Append(" AND ");
			oWhere.Append("[ID_Material]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Material));

			return (oWhere.ToString());
		}

		public static OrderMaterial UTI_RowToOrderMaterial(DataRow oRow)
		{
			OrderMaterial oOrderMaterial = new OrderMaterial();

			oOrderMaterial.ID_Order = ((Int32)(oRow["ID_Order"]));
			oOrderMaterial.ID_Material = ((Int32)(oRow["ID_Material"]));
			oOrderMaterial.Quantity = ((Int32)(oRow["Quantity"]));

			return (oOrderMaterial);
		}
		#endregion
	}

}

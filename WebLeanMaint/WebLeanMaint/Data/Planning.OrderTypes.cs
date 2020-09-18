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
	/// Public OrderType Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  18/09/2020  Created
	/// </remarks>
	public class OrderTypes : EntitiesManagerBase
	{
		#region Public Properties
		public OrderType this[int nIndex]
		{
			get { return ((OrderType)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public OrderType GetByKeys(Int32 nID_OrderType)
		{
			foreach (OrderType oOrderType in this.m_aItems)
			{
				if (oOrderType.ID_OrderType == nID_OrderType)
				{
					return (oOrderType);
				}
			}

			return (null);
		}

		public OrderType[] ToArray()
		{
			List<OrderType> aRet = new List<OrderType>();
			foreach (OrderType oOrderType in this.m_aItems)
			{
				aRet.Add(oOrderType);
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
			OrderType oOrderType = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oOrderType = UTI_RowToOrderType(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oOrderType);

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

			oDelete = new StringBuilder("DELETE FROM [Planning].[OrderTypes]");

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
			oSelect = new StringBuilder("SELECT * FROM [Planning].[OrderTypes]");

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

		public static OrderType LoadOne(Int32 nID_OrderType)
		{
			return(LoadOne(nID_OrderType, null));
		}

		public static OrderType LoadOne(Int32 nID_OrderType, SqlConnection oPrivateConnection)
		{
			OrderType oOrderType = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Planning].[OrderTypes]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_OrderType]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_OrderType));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oOrderType = UTI_RowToOrderType(oRow);
			}

			return (oOrderType);
		}

		public static OrderType TryLoadOne(Int32 nID_OrderType)
		{
			return(TryLoadOne(nID_OrderType, null));
		}

		public static OrderType TryLoadOne(Int32 nID_OrderType, SqlConnection oPrivateConnection)
		{
			OrderType oOrderType = null;

			oOrderType = LoadOne(nID_OrderType, null);

			if (oOrderType == null)
			{
				return (new OrderType());
			}
			else
			{
				return (oOrderType);
			}
		}

		public static void InsertOne(OrderType oOrderType)
		{
			InsertOne(oOrderType, null);
		}

		public static void InsertOne(OrderType oOrderType, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Planning].[OrderTypes] ");
			oInsert.Append("([ID_OrderType], [Name], [Description])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOrderType.ID_OrderType));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOrderType.Name));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOrderType.Description));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(OrderType oOrderType)
		{
			UpdateOne(oOrderType, null);
		}

		public static void UpdateOne(OrderType oOrderType, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Planning].[OrderTypes] SET ");

			oUpdate.Append("[Name]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOrderType.Name));
			oUpdate.Append(", ");
			oUpdate.Append("[Description]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOrderType.Description));

			oUpdate.Append(UTI_Where4One(oOrderType));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(OrderType oOrderType)
		{
			DeleteOne(oOrderType, null);
		}

		public static void DeleteOne(OrderType oOrderType, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Planning].[OrderTypes]");

			oDelete.Append(UTI_Where4One(oOrderType));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(OrderType oOrderType)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_OrderType]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oOrderType.ID_OrderType));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_OrderType)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_OrderType]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_OrderType));

			return (oWhere.ToString());
		}

		public static OrderType UTI_RowToOrderType(DataRow oRow)
		{
			OrderType oOrderType = new OrderType();

			oOrderType.ID_OrderType = ((Int32)(oRow["ID_OrderType"]));
			oOrderType.Name = ((String)(oRow["Name"])).Trim();
			oOrderType.Description = ((String)(oRow["Description"])).Trim();

			return (oOrderType);
		}
		#endregion
	}

}

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
	/// Public OrderOperator Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  18/09/2020  Created
	/// </remarks>
	public class OrderOperators : EntitiesManagerBase
	{
		#region Public Properties
		public OrderOperator this[int nIndex]
		{
			get { return ((OrderOperator)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public OrderOperator GetByKeys(Int32 nID_Order, Int32 nID_Operator)
		{
			foreach (OrderOperator oOrderOperator in this.m_aItems)
			{
				if (oOrderOperator.ID_Order == nID_Order && oOrderOperator.ID_Operator == nID_Operator)
				{
					return (oOrderOperator);
				}
			}

			return (null);
		}

		public OrderOperator[] ToArray()
		{
			List<OrderOperator> aRet = new List<OrderOperator>();
			foreach (OrderOperator oOrderOperator in this.m_aItems)
			{
				aRet.Add(oOrderOperator);
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
			OrderOperator oOrderOperator = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oOrderOperator = UTI_RowToOrderOperator(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oOrderOperator);

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

			oDelete = new StringBuilder("DELETE FROM [Planning].[OrderOperators]");

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
			oSelect = new StringBuilder("SELECT * FROM [Planning].[OrderOperators]");

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

		public static OrderOperator LoadOne(Int32 nID_Order, Int32 nID_Operator)
		{
			return(LoadOne(nID_Order, nID_Operator, null));
		}

		public static OrderOperator LoadOne(Int32 nID_Order, Int32 nID_Operator, SqlConnection oPrivateConnection)
		{
			OrderOperator oOrderOperator = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Planning].[OrderOperators]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_Order]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Order));
			oSelect.Append(" AND ");
			oSelect.Append("[ID_Operator]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Operator));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oOrderOperator = UTI_RowToOrderOperator(oRow);
			}

			return (oOrderOperator);
		}

		public static OrderOperator TryLoadOne(Int32 nID_Order, Int32 nID_Operator)
		{
			return(TryLoadOne(nID_Order, nID_Operator, null));
		}

		public static OrderOperator TryLoadOne(Int32 nID_Order, Int32 nID_Operator, SqlConnection oPrivateConnection)
		{
			OrderOperator oOrderOperator = null;

			oOrderOperator = LoadOne(nID_Order, nID_Operator, null);

			if (oOrderOperator == null)
			{
				return (new OrderOperator());
			}
			else
			{
				return (oOrderOperator);
			}
		}

		public static void InsertOne(OrderOperator oOrderOperator)
		{
			InsertOne(oOrderOperator, null);
		}

		public static void InsertOne(OrderOperator oOrderOperator, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Planning].[OrderOperators] ");
			oInsert.Append("([ID_Order], [ID_Operator])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOrderOperator.ID_Order));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOrderOperator.ID_Operator));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(OrderOperator oOrderOperator)
		{
			UpdateOne(oOrderOperator, null);
		}

		public static void UpdateOne(OrderOperator oOrderOperator, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Planning].[OrderOperators] SET ");


			oUpdate.Append(UTI_Where4One(oOrderOperator));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(OrderOperator oOrderOperator)
		{
			DeleteOne(oOrderOperator, null);
		}

		public static void DeleteOne(OrderOperator oOrderOperator, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Planning].[OrderOperators]");

			oDelete.Append(UTI_Where4One(oOrderOperator));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(OrderOperator oOrderOperator)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Order]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oOrderOperator.ID_Order));
			oWhere.Append(" AND ");
			oWhere.Append("[ID_Operator]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oOrderOperator.ID_Operator));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_Order, Int32 nID_Operator)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Order]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Order));
			oWhere.Append(" AND ");
			oWhere.Append("[ID_Operator]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Operator));

			return (oWhere.ToString());
		}

		public static OrderOperator UTI_RowToOrderOperator(DataRow oRow)
		{
			OrderOperator oOrderOperator = new OrderOperator();

			oOrderOperator.ID_Order = ((Int32)(oRow["ID_Order"]));
			oOrderOperator.ID_Operator = ((Int32)(oRow["ID_Operator"]));

			return (oOrderOperator);
		}
		#endregion
	}

}

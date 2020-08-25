using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Data.Planning
{
	/// <summary>
	/// Public Order Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  25/08/2020  Created
	/// </remarks>
	public class Orders : EntitiesManagerBase
	{
		#region Public Properties
		public Order this[int nIndex]
		{
			get { return ((Order)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public Order GetByKeys(Int32 nID_Order)
		{
			foreach (Order oOrder in this.m_aItems)
			{
				if (oOrder.ID_Order == nID_Order)
				{
					return (oOrder);
				}
			}

			return (null);
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
			Order oOrder = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oOrder = UTI_RowToOrder(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oOrder);

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

			oDelete = new StringBuilder("DELETE FROM [Orders]");

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
			oSelect = new StringBuilder("SELECT * FROM [Orders]");

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

		public static Order LoadOne(Int32 nID_Order)
		{
			return(LoadOne(nID_Order, null));
		}

		public static Order LoadOne(Int32 nID_Order, SqlConnection oPrivateConnection)
		{
			Order oOrder = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Orders]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_Order]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Order));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oOrder = UTI_RowToOrder(oRow);
			}

			return (oOrder);
		}

		public static Order TryLoadOne(Int32 nID_Order)
		{
			return(TryLoadOne(nID_Order, null));
		}

		public static Order TryLoadOne(Int32 nID_Order, SqlConnection oPrivateConnection)
		{
			Order oOrder = null;

			oOrder = LoadOne(nID_Order, null);

			if (oOrder == null)
			{
				return (new Order());
			}
			else
			{
				return (oOrder);
			}
		}

		public static void InsertOne(Order oOrder)
		{
			InsertOne(oOrder, null);
		}

		public static void InsertOne(Order oOrder, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Orders] ");
			oInsert.Append("([Description], [ID_OrderType], [RequestedAt], [PlannedFor], [ToCompleteBefore], [Completed])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOrder.Description));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOrder.ID_OrderType));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOrder.RequestedAt));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOrder.PlannedFor));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOrder.ToCompleteBefore));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOrder.Completed));
			oInsert.Append(")");

			Object oRet;
			oRet = EntitiesManagerBase.DAT_ExecuteScalar(oInsert.ToString(), "\nSELECT @@IDENTITY AS ID", oPrivateConnection);
			oOrder.ID_Order = Convert.ToInt32(oRet);
		}

		public static void UpdateOne(Order oOrder)
		{
			UpdateOne(oOrder, null);
		}

		public static void UpdateOne(Order oOrder, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Orders] SET ");

			oUpdate.Append("[Description]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOrder.Description));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_OrderType]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOrder.ID_OrderType));
			oUpdate.Append(", ");
			oUpdate.Append("[RequestedAt]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOrder.RequestedAt));
			oUpdate.Append(", ");
			oUpdate.Append("[PlannedFor]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOrder.PlannedFor));
			oUpdate.Append(", ");
			oUpdate.Append("[ToCompleteBefore]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOrder.ToCompleteBefore));
			oUpdate.Append(", ");
			oUpdate.Append("[Completed]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOrder.Completed));

			oUpdate.Append(UTI_Where4One(oOrder));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(Order oOrder)
		{
			DeleteOne(oOrder, null);
		}

		public static void DeleteOne(Order oOrder, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Orders]");

			oDelete.Append(UTI_Where4One(oOrder));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(Order oOrder)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Order]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oOrder.ID_Order));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_Order)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Order]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Order));

			return (oWhere.ToString());
		}

		public static Order UTI_RowToOrder(DataRow oRow)
		{
			Order oOrder = new Order();

			oOrder.ID_Order = ((Int32)(oRow["ID_Order"]));
			oOrder.Description = ((String)(oRow["Description"])).Trim();
			oOrder.ID_OrderType = ((Int32)(oRow["ID_OrderType"]));
			oOrder.RequestedAt = ((DateTime)(oRow["RequestedAt"]));
			oOrder.PlannedFor = ((DateTime)(oRow["PlannedFor"]));
			oOrder.ToCompleteBefore = ((DateTime)(oRow["ToCompleteBefore"]));
			oOrder.Completed = ((Boolean)(oRow["Completed"]));

			return (oOrder);
		}
		#endregion
	}

}

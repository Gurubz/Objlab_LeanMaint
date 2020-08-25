using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Data.Planning
{
	/// <summary>
	/// Public OrderAsset Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  25/08/2020  Created
	/// </remarks>
	public class OrderAssets : EntitiesManagerBase
	{
		#region Public Properties
		public OrderAsset this[int nIndex]
		{
			get { return ((OrderAsset)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public OrderAsset GetByKeys(Int32 nID_Order, Int32 nID_Asset)
		{
			foreach (OrderAsset oOrderAsset in this.m_aItems)
			{
				if (oOrderAsset.ID_Order == nID_Order && oOrderAsset.ID_Asset == nID_Asset)
				{
					return (oOrderAsset);
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
			OrderAsset oOrderAsset = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oOrderAsset = UTI_RowToOrderAsset(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oOrderAsset);

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

			oDelete = new StringBuilder("DELETE FROM [OrderAssets]");

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
			oSelect = new StringBuilder("SELECT * FROM [OrderAssets]");

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

		public static OrderAsset LoadOne(Int32 nID_Order, Int32 nID_Asset)
		{
			return(LoadOne(nID_Order, nID_Asset, null));
		}

		public static OrderAsset LoadOne(Int32 nID_Order, Int32 nID_Asset, SqlConnection oPrivateConnection)
		{
			OrderAsset oOrderAsset = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [OrderAssets]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_Order]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Order));
			oSelect.Append(" AND ");
			oSelect.Append("[ID_Asset]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Asset));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oOrderAsset = UTI_RowToOrderAsset(oRow);
			}

			return (oOrderAsset);
		}

		public static OrderAsset TryLoadOne(Int32 nID_Order, Int32 nID_Asset)
		{
			return(TryLoadOne(nID_Order, nID_Asset, null));
		}

		public static OrderAsset TryLoadOne(Int32 nID_Order, Int32 nID_Asset, SqlConnection oPrivateConnection)
		{
			OrderAsset oOrderAsset = null;

			oOrderAsset = LoadOne(nID_Order, nID_Asset, null);

			if (oOrderAsset == null)
			{
				return (new OrderAsset());
			}
			else
			{
				return (oOrderAsset);
			}
		}

		public static void InsertOne(OrderAsset oOrderAsset)
		{
			InsertOne(oOrderAsset, null);
		}

		public static void InsertOne(OrderAsset oOrderAsset, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [OrderAssets] ");
			oInsert.Append("([ID_Order], [ID_Asset], [StopRequired], [MinutesRequired], [Description])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOrderAsset.ID_Order));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOrderAsset.ID_Asset));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOrderAsset.StopRequired));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOrderAsset.MinutesRequired));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOrderAsset.Description));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(OrderAsset oOrderAsset)
		{
			UpdateOne(oOrderAsset, null);
		}

		public static void UpdateOne(OrderAsset oOrderAsset, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [OrderAssets] SET ");

			oUpdate.Append("[StopRequired]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOrderAsset.StopRequired));
			oUpdate.Append(", ");
			oUpdate.Append("[MinutesRequired]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOrderAsset.MinutesRequired));
			oUpdate.Append(", ");
			oUpdate.Append("[Description]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOrderAsset.Description));

			oUpdate.Append(UTI_Where4One(oOrderAsset));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(OrderAsset oOrderAsset)
		{
			DeleteOne(oOrderAsset, null);
		}

		public static void DeleteOne(OrderAsset oOrderAsset, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [OrderAssets]");

			oDelete.Append(UTI_Where4One(oOrderAsset));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(OrderAsset oOrderAsset)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Order]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oOrderAsset.ID_Order));
			oWhere.Append(" AND ");
			oWhere.Append("[ID_Asset]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oOrderAsset.ID_Asset));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_Order, Int32 nID_Asset)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Order]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Order));
			oWhere.Append(" AND ");
			oWhere.Append("[ID_Asset]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Asset));

			return (oWhere.ToString());
		}

		public static OrderAsset UTI_RowToOrderAsset(DataRow oRow)
		{
			OrderAsset oOrderAsset = new OrderAsset();

			oOrderAsset.ID_Order = ((Int32)(oRow["ID_Order"]));
			oOrderAsset.ID_Asset = ((Int32)(oRow["ID_Asset"]));
			oOrderAsset.StopRequired = ((Boolean)(oRow["StopRequired"]));
			oOrderAsset.MinutesRequired = ((Int32)(oRow["MinutesRequired"]));
			oOrderAsset.Description = ((String)(oRow["Description"])).Trim();

			return (oOrderAsset);
		}
		#endregion
	}

}

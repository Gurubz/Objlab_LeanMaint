using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Data.Accountancy
{
	/// <summary>
	/// Public CostCenter Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  25/08/2020  Created
	/// </remarks>
	public class CostCenters : EntitiesManagerBase
	{
		#region Public Properties
		public CostCenter this[int nIndex]
		{
			get { return ((CostCenter)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public CostCenter GetByKeys(Int32 nID_CostCenter)
		{
			foreach (CostCenter oCostCenter in this.m_aItems)
			{
				if (oCostCenter.ID_CostCenter == nID_CostCenter)
				{
					return (oCostCenter);
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
			CostCenter oCostCenter = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oCostCenter = UTI_RowToCostCenter(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oCostCenter);

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

			oDelete = new StringBuilder("DELETE FROM [CostCenters]");

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
			oSelect = new StringBuilder("SELECT * FROM [CostCenters]");

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

		public static CostCenter LoadOne(Int32 nID_CostCenter)
		{
			return(LoadOne(nID_CostCenter, null));
		}

		public static CostCenter LoadOne(Int32 nID_CostCenter, SqlConnection oPrivateConnection)
		{
			CostCenter oCostCenter = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [CostCenters]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_CostCenter]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_CostCenter));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oCostCenter = UTI_RowToCostCenter(oRow);
			}

			return (oCostCenter);
		}

		public static CostCenter TryLoadOne(Int32 nID_CostCenter)
		{
			return(TryLoadOne(nID_CostCenter, null));
		}

		public static CostCenter TryLoadOne(Int32 nID_CostCenter, SqlConnection oPrivateConnection)
		{
			CostCenter oCostCenter = null;

			oCostCenter = LoadOne(nID_CostCenter, null);

			if (oCostCenter == null)
			{
				return (new CostCenter());
			}
			else
			{
				return (oCostCenter);
			}
		}

		public static void InsertOne(CostCenter oCostCenter)
		{
			InsertOne(oCostCenter, null);
		}

		public static void InsertOne(CostCenter oCostCenter, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [CostCenters] ");
			oInsert.Append("([Name], [Description], [ID_CostCenterType], [ID_ObjStatus], [ID_Parent])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oCostCenter.Name));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oCostCenter.Description));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oCostCenter.ID_CostCenterType));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oCostCenter.ID_ObjStatus));
			oInsert.Append(", ");
			if (oCostCenter.ID_Parent_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oCostCenter.ID_Parent));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(")");

			Object oRet;
			oRet = EntitiesManagerBase.DAT_ExecuteScalar(oInsert.ToString(), "\nSELECT @@IDENTITY AS ID", oPrivateConnection);
			oCostCenter.ID_CostCenter = Convert.ToInt32(oRet);
		}

		public static void UpdateOne(CostCenter oCostCenter)
		{
			UpdateOne(oCostCenter, null);
		}

		public static void UpdateOne(CostCenter oCostCenter, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [CostCenters] SET ");

			oUpdate.Append("[Name]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oCostCenter.Name));
			oUpdate.Append(", ");
			oUpdate.Append("[Description]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oCostCenter.Description));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_CostCenterType]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oCostCenter.ID_CostCenterType));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_ObjStatus]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oCostCenter.ID_ObjStatus));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_Parent]=");
			if (oCostCenter.ID_Parent_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oCostCenter.ID_Parent));
			} else {
			oUpdate.Append("NULL");
			}

			oUpdate.Append(UTI_Where4One(oCostCenter));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(CostCenter oCostCenter)
		{
			DeleteOne(oCostCenter, null);
		}

		public static void DeleteOne(CostCenter oCostCenter, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [CostCenters]");

			oDelete.Append(UTI_Where4One(oCostCenter));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(CostCenter oCostCenter)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_CostCenter]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oCostCenter.ID_CostCenter));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_CostCenter)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_CostCenter]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_CostCenter));

			return (oWhere.ToString());
		}

		public static CostCenter UTI_RowToCostCenter(DataRow oRow)
		{
			CostCenter oCostCenter = new CostCenter();

			oCostCenter.ID_CostCenter = ((Int32)(oRow["ID_CostCenter"]));
			oCostCenter.Name = ((String)(oRow["Name"])).Trim();
			oCostCenter.Description = ((String)(oRow["Description"])).Trim();
			oCostCenter.ID_CostCenterType = ((Int32)(oRow["ID_CostCenterType"]));
			oCostCenter.ID_ObjStatus = ((Int32)(oRow["ID_ObjStatus"]));
			if (!(oRow["ID_Parent"] is DBNull)) {
			  oCostCenter.ID_Parent = ((Int32)(oRow["ID_Parent"]));
			  oCostCenter.ID_Parent_HasValue = true;
			} else {
			  oCostCenter.ID_Parent_HasValue = false;
			}

			return (oCostCenter);
		}
		#endregion
	}

}

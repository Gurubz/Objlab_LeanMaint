using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Data.Maintenance
{
	/// <summary>
	/// Public Repair Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  23/08/2020  Created
	/// </remarks>
	public class Repairs : EntitiesManagerBase
	{
		#region Public Properties
		public Repair this[int nIndex]
		{
			get { return ((Repair)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public Repair GetByKeys(Int32 nID)
		{
			foreach (Repair oRepair in this.m_aItems)
			{
				if (oRepair.ID == nID)
				{
					return (oRepair);
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
			Repair oRepair = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oRepair = UTI_RowToRepair(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oRepair);

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

			oDelete = new StringBuilder("DELETE FROM [Repairs]");

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
			oSelect = new StringBuilder("SELECT * FROM [Repairs]");

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

		public static Repair LoadOne(Int32 nID)
		{
			return(LoadOne(nID, null));
		}

		public static Repair LoadOne(Int32 nID, SqlConnection oPrivateConnection)
		{
			Repair oRepair = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Repairs]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oRepair = UTI_RowToRepair(oRow);
			}

			return (oRepair);
		}

		public static Repair TryLoadOne(Int32 nID)
		{
			return(TryLoadOne(nID, null));
		}

		public static Repair TryLoadOne(Int32 nID, SqlConnection oPrivateConnection)
		{
			Repair oRepair = null;

			oRepair = LoadOne(nID, null);

			if (oRepair == null)
			{
				return (new Repair());
			}
			else
			{
				return (oRepair);
			}
		}

		public static void InsertOne(Repair oRepair)
		{
			InsertOne(oRepair, null);
		}

		public static void InsertOne(Repair oRepair, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Repairs] ");
			oInsert.Append("([Description], [ID_RepairClass], [ID_ObjStatus])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			if (oRepair.Description_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oRepair.Description));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oRepair.ID_RepairClass_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oRepair.ID_RepairClass));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oRepair.ID_ObjStatus_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oRepair.ID_ObjStatus));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(")");

			Object oRet;
			oRet = EntitiesManagerBase.DAT_ExecuteScalar(oInsert.ToString(), "\nSELECT @@IDENTITY AS ID", oPrivateConnection);
			oRepair.ID = Convert.ToInt32(oRet);
		}

		public static void UpdateOne(Repair oRepair)
		{
			UpdateOne(oRepair, null);
		}

		public static void UpdateOne(Repair oRepair, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Repairs] SET ");

			oUpdate.Append("[Description]=");
			if (oRepair.Description_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oRepair.Description));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[ID_RepairClass]=");
			if (oRepair.ID_RepairClass_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oRepair.ID_RepairClass));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[ID_ObjStatus]=");
			if (oRepair.ID_ObjStatus_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oRepair.ID_ObjStatus));
			} else {
			oUpdate.Append("NULL");
			}

			oUpdate.Append(UTI_Where4One(oRepair));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(Repair oRepair)
		{
			DeleteOne(oRepair, null);
		}

		public static void DeleteOne(Repair oRepair, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Repairs]");

			oDelete.Append(UTI_Where4One(oRepair));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(Repair oRepair)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oRepair.ID));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID));

			return (oWhere.ToString());
		}

		public static Repair UTI_RowToRepair(DataRow oRow)
		{
			Repair oRepair = new Repair();

			oRepair.ID = ((Int32)(oRow["ID"]));
			if (!(oRow["Description"] is DBNull)) {
			  oRepair.Description = ((String)(oRow["Description"])).Trim();
			  oRepair.Description_HasValue = true;
			} else {
			  oRepair.Description_HasValue = false;
			}
			if (!(oRow["ID_RepairClass"] is DBNull)) {
			  oRepair.ID_RepairClass = ((Int32)(oRow["ID_RepairClass"]));
			  oRepair.ID_RepairClass_HasValue = true;
			} else {
			  oRepair.ID_RepairClass_HasValue = false;
			}
			if (!(oRow["ID_ObjStatus"] is DBNull)) {
			  oRepair.ID_ObjStatus = ((Int32)(oRow["ID_ObjStatus"]));
			  oRepair.ID_ObjStatus_HasValue = true;
			} else {
			  oRepair.ID_ObjStatus_HasValue = false;
			}

			return (oRepair);
		}
		#endregion
	}

}

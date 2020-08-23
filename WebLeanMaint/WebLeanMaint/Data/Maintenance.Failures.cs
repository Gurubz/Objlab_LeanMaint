using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Data.Maintenance
{
	/// <summary>
	/// Public Failure Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  23/08/2020  Created
	/// </remarks>
	public class Failures : EntitiesManagerBase
	{
		#region Public Properties
		public Failure this[int nIndex]
		{
			get { return ((Failure)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public Failure GetByKeys(Int32 nID)
		{
			foreach (Failure oFailure in this.m_aItems)
			{
				if (oFailure.ID == nID)
				{
					return (oFailure);
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
			Failure oFailure = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oFailure = UTI_RowToFailure(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oFailure);

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

			oDelete = new StringBuilder("DELETE FROM [Failures]");

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
			oSelect = new StringBuilder("SELECT * FROM [Failures]");

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

		public static Failure LoadOne(Int32 nID)
		{
			return(LoadOne(nID, null));
		}

		public static Failure LoadOne(Int32 nID, SqlConnection oPrivateConnection)
		{
			Failure oFailure = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Failures]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oFailure = UTI_RowToFailure(oRow);
			}

			return (oFailure);
		}

		public static Failure TryLoadOne(Int32 nID)
		{
			return(TryLoadOne(nID, null));
		}

		public static Failure TryLoadOne(Int32 nID, SqlConnection oPrivateConnection)
		{
			Failure oFailure = null;

			oFailure = LoadOne(nID, null);

			if (oFailure == null)
			{
				return (new Failure());
			}
			else
			{
				return (oFailure);
			}
		}

		public static void InsertOne(Failure oFailure)
		{
			InsertOne(oFailure, null);
		}

		public static void InsertOne(Failure oFailure, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Failures] ");
			oInsert.Append("([Name], [Description], [ID_FailureClass], [ID_ObjStatus])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			if (oFailure.Name_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oFailure.Name));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oFailure.Description_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oFailure.Description));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oFailure.ID_FailureClass_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oFailure.ID_FailureClass));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oFailure.ID_ObjStatus_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oFailure.ID_ObjStatus));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(")");

			Object oRet;
			oRet = EntitiesManagerBase.DAT_ExecuteScalar(oInsert.ToString(), "\nSELECT @@IDENTITY AS ID", oPrivateConnection);
			oFailure.ID = Convert.ToInt32(oRet);
		}

		public static void UpdateOne(Failure oFailure)
		{
			UpdateOne(oFailure, null);
		}

		public static void UpdateOne(Failure oFailure, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Failures] SET ");

			oUpdate.Append("[Name]=");
			if (oFailure.Name_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oFailure.Name));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[Description]=");
			if (oFailure.Description_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oFailure.Description));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[ID_FailureClass]=");
			if (oFailure.ID_FailureClass_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oFailure.ID_FailureClass));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[ID_ObjStatus]=");
			if (oFailure.ID_ObjStatus_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oFailure.ID_ObjStatus));
			} else {
			oUpdate.Append("NULL");
			}

			oUpdate.Append(UTI_Where4One(oFailure));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(Failure oFailure)
		{
			DeleteOne(oFailure, null);
		}

		public static void DeleteOne(Failure oFailure, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Failures]");

			oDelete.Append(UTI_Where4One(oFailure));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(Failure oFailure)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oFailure.ID));

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

		public static Failure UTI_RowToFailure(DataRow oRow)
		{
			Failure oFailure = new Failure();

			oFailure.ID = ((Int32)(oRow["ID"]));
			if (!(oRow["Name"] is DBNull)) {
			  oFailure.Name = ((String)(oRow["Name"])).Trim();
			  oFailure.Name_HasValue = true;
			} else {
			  oFailure.Name_HasValue = false;
			}
			if (!(oRow["Description"] is DBNull)) {
			  oFailure.Description = ((String)(oRow["Description"])).Trim();
			  oFailure.Description_HasValue = true;
			} else {
			  oFailure.Description_HasValue = false;
			}
			if (!(oRow["ID_FailureClass"] is DBNull)) {
			  oFailure.ID_FailureClass = ((Int32)(oRow["ID_FailureClass"]));
			  oFailure.ID_FailureClass_HasValue = true;
			} else {
			  oFailure.ID_FailureClass_HasValue = false;
			}
			if (!(oRow["ID_ObjStatus"] is DBNull)) {
			  oFailure.ID_ObjStatus = ((Int32)(oRow["ID_ObjStatus"]));
			  oFailure.ID_ObjStatus_HasValue = true;
			} else {
			  oFailure.ID_ObjStatus_HasValue = false;
			}

			return (oFailure);
		}
		#endregion
	}

}

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
	/// Public OperatorsPermission Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  24/09/2020  Created
	/// </remarks>
	public partial class OperatorsPermissions : EntitiesManagerBase
	{
		#region Public Properties
		public OperatorsPermission this[int nIndex]
		{
			get { return ((OperatorsPermission)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public OperatorsPermission GetByKeys(Int32 nID_Operator)
		{
			foreach (OperatorsPermission oOperatorsPermission in this.m_aItems)
			{
				if (oOperatorsPermission.ID_Operator == nID_Operator)
				{
					return (oOperatorsPermission);
				}
			}

			return (null);
		}

		public OperatorsPermission[] ToArray()
		{
			List<OperatorsPermission> aRet = new List<OperatorsPermission>();
			foreach (OperatorsPermission oOperatorsPermission in this.m_aItems)
			{
				aRet.Add(oOperatorsPermission);
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
			OperatorsPermission oOperatorsPermission = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oOperatorsPermission = UTI_RowToOperatorsPermission(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oOperatorsPermission);

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

			oDelete = new StringBuilder("DELETE FROM [Maintenance].[OperatorsPermission]");

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
			oSelect = new StringBuilder("SELECT * FROM [Maintenance].[OperatorsPermission]");

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

		public static OperatorsPermission LoadOne(Int32 nID_Operator)
		{
			return(LoadOne(nID_Operator, null));
		}

		public static OperatorsPermission LoadOne(Int32 nID_Operator, SqlConnection oPrivateConnection)
		{
			OperatorsPermission oOperatorsPermission = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Maintenance].[OperatorsPermission]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_Operator]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Operator));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oOperatorsPermission = UTI_RowToOperatorsPermission(oRow);
			}

			return (oOperatorsPermission);
		}

		public static OperatorsPermission TryLoadOne(Int32 nID_Operator)
		{
			return(TryLoadOne(nID_Operator, null));
		}

		public static OperatorsPermission TryLoadOne(Int32 nID_Operator, SqlConnection oPrivateConnection)
		{
			OperatorsPermission oOperatorsPermission = null;

			oOperatorsPermission = LoadOne(nID_Operator, null);

			if (oOperatorsPermission == null)
			{
				return (new OperatorsPermission());
			}
			else
			{
				return (oOperatorsPermission);
			}
		}

		public static void InsertOne(OperatorsPermission oOperatorsPermission)
		{
			InsertOne(oOperatorsPermission, null);
		}

		public static void InsertOne(OperatorsPermission oOperatorsPermission, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Maintenance].[OperatorsPermission] ");
			oInsert.Append("([ID_Operator], [LVL_User], [Auth_Code], [Started], [Ended])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOperatorsPermission.ID_Operator));
			oInsert.Append(", ");
			if (oOperatorsPermission.LVL_User_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOperatorsPermission.LVL_User));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oOperatorsPermission.Auth_Code_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOperatorsPermission.Auth_Code));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oOperatorsPermission.Started_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOperatorsPermission.Started));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oOperatorsPermission.Ended_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOperatorsPermission.Ended));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(OperatorsPermission oOperatorsPermission)
		{
			UpdateOne(oOperatorsPermission, null);
		}

		public static void UpdateOne(OperatorsPermission oOperatorsPermission, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Maintenance].[OperatorsPermission] SET ");

			oUpdate.Append("[LVL_User]=");
			if (oOperatorsPermission.LVL_User_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOperatorsPermission.LVL_User));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[Auth_Code]=");
			if (oOperatorsPermission.Auth_Code_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOperatorsPermission.Auth_Code));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[Started]=");
			if (oOperatorsPermission.Started_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOperatorsPermission.Started));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[Ended]=");
			if (oOperatorsPermission.Ended_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOperatorsPermission.Ended));
			} else {
			oUpdate.Append("NULL");
			}

			oUpdate.Append(UTI_Where4One(oOperatorsPermission));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(OperatorsPermission oOperatorsPermission)
		{
			DeleteOne(oOperatorsPermission, null);
		}

		public static void DeleteOne(OperatorsPermission oOperatorsPermission, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Maintenance].[OperatorsPermission]");

			oDelete.Append(UTI_Where4One(oOperatorsPermission));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(OperatorsPermission oOperatorsPermission)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Operator]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oOperatorsPermission.ID_Operator));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_Operator)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Operator]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Operator));

			return (oWhere.ToString());
		}

		public static OperatorsPermission UTI_RowToOperatorsPermission(DataRow oRow)
		{
			OperatorsPermission oOperatorsPermission = new OperatorsPermission();

			oOperatorsPermission.ID_Operator = ((Int32)(oRow["ID_Operator"]));
			if (!(oRow["LVL_User"] is DBNull)) {
			  oOperatorsPermission.LVL_User = ((Int32)(oRow["LVL_User"]));
			  oOperatorsPermission.LVL_User_HasValue = true;
			} else {
			  oOperatorsPermission.LVL_User_HasValue = false;
			}
			if (!(oRow["Auth_Code"] is DBNull)) {
			  oOperatorsPermission.Auth_Code = ((String)(oRow["Auth_Code"])).Trim();
			  oOperatorsPermission.Auth_Code_HasValue = true;
			} else {
			  oOperatorsPermission.Auth_Code_HasValue = false;
			}
			if (!(oRow["Started"] is DBNull)) {
			  oOperatorsPermission.Started = ((DateTime)(oRow["Started"]));
			  oOperatorsPermission.Started_HasValue = true;
			} else {
			  oOperatorsPermission.Started_HasValue = false;
			}
			if (!(oRow["Ended"] is DBNull)) {
			  oOperatorsPermission.Ended = ((DateTime)(oRow["Ended"]));
			  oOperatorsPermission.Ended_HasValue = true;
			} else {
			  oOperatorsPermission.Ended_HasValue = false;
			}

			return (oOperatorsPermission);
		}
		#endregion
	}

}

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
	/// Public Operator Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  25/08/2020  Created
	/// </remarks>
	public class Operators : EntitiesManagerBase
	{
		#region Public Properties
		public Operator this[int nIndex]
		{
			get { return ((Operator)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public Operator GetByKeys(Int32 nID_Operator)
		{
			foreach (Operator oOperator in this.m_aItems)
			{
				if (oOperator.ID_Operator == nID_Operator)
				{
					return (oOperator);
				}
			}

			return (null);
		}

		public Operator[] ToArray()
		{
			List<Operator> aRet = new List<Operator>();
			foreach (Operator oOperator in this.m_aItems)
			{
				aRet.Add(oOperator);
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
			Operator oOperator = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oOperator = UTI_RowToOperator(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oOperator);

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

			oDelete = new StringBuilder("DELETE FROM [Operators]");

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
			oSelect = new StringBuilder("SELECT * FROM [Operators]");

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

		public static Operator LoadOne(Int32 nID_Operator)
		{
			return(LoadOne(nID_Operator, null));
		}

		public static Operator LoadOne(Int32 nID_Operator, SqlConnection oPrivateConnection)
		{
			Operator oOperator = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Operators]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_Operator]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Operator));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oOperator = UTI_RowToOperator(oRow);
			}

			return (oOperator);
		}

		public static Operator TryLoadOne(Int32 nID_Operator)
		{
			return(TryLoadOne(nID_Operator, null));
		}

		public static Operator TryLoadOne(Int32 nID_Operator, SqlConnection oPrivateConnection)
		{
			Operator oOperator = null;

			oOperator = LoadOne(nID_Operator, null);

			if (oOperator == null)
			{
				return (new Operator());
			}
			else
			{
				return (oOperator);
			}
		}

		public static void InsertOne(Operator oOperator)
		{
			InsertOne(oOperator, null);
		}

		public static void InsertOne(Operator oOperator, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Operators] ");
			oInsert.Append("([Name], [MiddleName], [LastName], [Description], [ID_OperatorType], [ID_Calendar], [ID_Supplier], [ID_CostCenter], [HourlyCost], [ID_ObjStatus], [ID_User])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOperator.Name));
			oInsert.Append(", ");
			if (oOperator.MiddleName_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOperator.MiddleName));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOperator.LastName));
			oInsert.Append(", ");
			if (oOperator.Description_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOperator.Description));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOperator.ID_OperatorType));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOperator.ID_Calendar));
			oInsert.Append(", ");
			if (oOperator.ID_Supplier_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOperator.ID_Supplier));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oOperator.ID_CostCenter_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOperator.ID_CostCenter));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oOperator.HourlyCost_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOperator.HourlyCost));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOperator.ID_ObjStatus));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOperator.ID_User));
			oInsert.Append(")");

			Object oRet;
			oRet = EntitiesManagerBase.DAT_ExecuteScalar(oInsert.ToString(), "\nSELECT @@IDENTITY AS ID", oPrivateConnection);
			oOperator.ID_Operator = Convert.ToInt32(oRet);
		}

		public static void UpdateOne(Operator oOperator)
		{
			UpdateOne(oOperator, null);
		}

		public static void UpdateOne(Operator oOperator, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Operators] SET ");

			oUpdate.Append("[Name]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOperator.Name));
			oUpdate.Append(", ");
			oUpdate.Append("[MiddleName]=");
			if (oOperator.MiddleName_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOperator.MiddleName));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[LastName]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOperator.LastName));
			oUpdate.Append(", ");
			oUpdate.Append("[Description]=");
			if (oOperator.Description_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOperator.Description));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[ID_OperatorType]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOperator.ID_OperatorType));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_Calendar]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOperator.ID_Calendar));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_Supplier]=");
			if (oOperator.ID_Supplier_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOperator.ID_Supplier));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[ID_CostCenter]=");
			if (oOperator.ID_CostCenter_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOperator.ID_CostCenter));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[HourlyCost]=");
			if (oOperator.HourlyCost_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOperator.HourlyCost));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[ID_ObjStatus]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOperator.ID_ObjStatus));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_User]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOperator.ID_User));

			oUpdate.Append(UTI_Where4One(oOperator));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(Operator oOperator)
		{
			DeleteOne(oOperator, null);
		}

		public static void DeleteOne(Operator oOperator, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Operators]");

			oDelete.Append(UTI_Where4One(oOperator));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(Operator oOperator)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Operator]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oOperator.ID_Operator));

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

		public static Operator UTI_RowToOperator(DataRow oRow)
		{
			Operator oOperator = new Operator();

			oOperator.ID_Operator = ((Int32)(oRow["ID_Operator"]));
			oOperator.Name = ((String)(oRow["Name"])).Trim();
			if (!(oRow["MiddleName"] is DBNull)) {
			  oOperator.MiddleName = ((String)(oRow["MiddleName"])).Trim();
			  oOperator.MiddleName_HasValue = true;
			} else {
			  oOperator.MiddleName_HasValue = false;
			}
			oOperator.LastName = ((String)(oRow["LastName"])).Trim();
			if (!(oRow["Description"] is DBNull)) {
			  oOperator.Description = ((String)(oRow["Description"])).Trim();
			  oOperator.Description_HasValue = true;
			} else {
			  oOperator.Description_HasValue = false;
			}
			oOperator.ID_OperatorType = ((Int32)(oRow["ID_OperatorType"]));
			oOperator.ID_Calendar = ((Int32)(oRow["ID_Calendar"]));
			if (!(oRow["ID_Supplier"] is DBNull)) {
			  oOperator.ID_Supplier = ((Int32)(oRow["ID_Supplier"]));
			  oOperator.ID_Supplier_HasValue = true;
			} else {
			  oOperator.ID_Supplier_HasValue = false;
			}
			if (!(oRow["ID_CostCenter"] is DBNull)) {
			  oOperator.ID_CostCenter = ((Int32)(oRow["ID_CostCenter"]));
			  oOperator.ID_CostCenter_HasValue = true;
			} else {
			  oOperator.ID_CostCenter_HasValue = false;
			}
			if (!(oRow["HourlyCost"] is DBNull)) {
			  oOperator.HourlyCost = ((Decimal)(oRow["HourlyCost"]));
			  oOperator.HourlyCost_HasValue = true;
			} else {
			  oOperator.HourlyCost_HasValue = false;
			}
			oOperator.ID_ObjStatus = ((Int32)(oRow["ID_ObjStatus"]));
			oOperator.ID_User = ((Int32)(oRow["ID_User"]));

			return (oOperator);
		}
		#endregion
	}

}

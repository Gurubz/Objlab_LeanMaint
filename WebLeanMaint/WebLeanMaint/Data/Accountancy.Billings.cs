using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Data.Accountancy
{
	/// <summary>
	/// Public Billing Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  25/08/2020  Created
	/// </remarks>
	public class Billings : EntitiesManagerBase
	{
		#region Public Properties
		public Billing this[int nIndex]
		{
			get { return ((Billing)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public Billing GetByKeys(Int32 nID_Billing)
		{
			foreach (Billing oBilling in this.m_aItems)
			{
				if (oBilling.ID_Billing == nID_Billing)
				{
					return (oBilling);
				}
			}

			return (null);
		}

		public Billing[] ToArray()
		{
			List<Billing> aRet = new List<Billing>();
			foreach (Billing oBilling in this.m_aItems)
			{
				aRet.Add(oBilling);
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
			Billing oBilling = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oBilling = UTI_RowToBilling(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oBilling);

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

			oDelete = new StringBuilder("DELETE FROM [Billings]");

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
			oSelect = new StringBuilder("SELECT * FROM [Billings]");

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

		public static Billing LoadOne(Int32 nID_Billing)
		{
			return(LoadOne(nID_Billing, null));
		}

		public static Billing LoadOne(Int32 nID_Billing, SqlConnection oPrivateConnection)
		{
			Billing oBilling = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Billings]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_Billing]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Billing));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oBilling = UTI_RowToBilling(oRow);
			}

			return (oBilling);
		}

		public static Billing TryLoadOne(Int32 nID_Billing)
		{
			return(TryLoadOne(nID_Billing, null));
		}

		public static Billing TryLoadOne(Int32 nID_Billing, SqlConnection oPrivateConnection)
		{
			Billing oBilling = null;

			oBilling = LoadOne(nID_Billing, null);

			if (oBilling == null)
			{
				return (new Billing());
			}
			else
			{
				return (oBilling);
			}
		}

		public static void InsertOne(Billing oBilling)
		{
			InsertOne(oBilling, null);
		}

		public static void InsertOne(Billing oBilling, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Billings] ");
			oInsert.Append("([ID_Operator], [Activation], [End], [HourlyCost], [Year], [Month], [StartDay], [EndDay], [Value])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			if (oBilling.ID_Operator_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oBilling.ID_Operator));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oBilling.Activation));
			oInsert.Append(", ");
			if (oBilling.End_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oBilling.End));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oBilling.HourlyCost_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oBilling.HourlyCost));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oBilling.Year_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oBilling.Year));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oBilling.Month_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oBilling.Month));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oBilling.StartDay_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oBilling.StartDay));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oBilling.EndDay_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oBilling.EndDay));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oBilling.Value_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oBilling.Value));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(")");

			Object oRet;
			oRet = EntitiesManagerBase.DAT_ExecuteScalar(oInsert.ToString(), "\nSELECT @@IDENTITY AS ID", oPrivateConnection);
			oBilling.ID_Billing = Convert.ToInt32(oRet);
		}

		public static void UpdateOne(Billing oBilling)
		{
			UpdateOne(oBilling, null);
		}

		public static void UpdateOne(Billing oBilling, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Billings] SET ");

			oUpdate.Append("[ID_Operator]=");
			if (oBilling.ID_Operator_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oBilling.ID_Operator));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[Activation]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oBilling.Activation));
			oUpdate.Append(", ");
			oUpdate.Append("[End]=");
			if (oBilling.End_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oBilling.End));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[HourlyCost]=");
			if (oBilling.HourlyCost_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oBilling.HourlyCost));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[Year]=");
			if (oBilling.Year_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oBilling.Year));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[Month]=");
			if (oBilling.Month_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oBilling.Month));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[StartDay]=");
			if (oBilling.StartDay_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oBilling.StartDay));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[EndDay]=");
			if (oBilling.EndDay_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oBilling.EndDay));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[Value]=");
			if (oBilling.Value_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oBilling.Value));
			} else {
			oUpdate.Append("NULL");
			}

			oUpdate.Append(UTI_Where4One(oBilling));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(Billing oBilling)
		{
			DeleteOne(oBilling, null);
		}

		public static void DeleteOne(Billing oBilling, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Billings]");

			oDelete.Append(UTI_Where4One(oBilling));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(Billing oBilling)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Billing]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oBilling.ID_Billing));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_Billing)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Billing]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Billing));

			return (oWhere.ToString());
		}

		public static Billing UTI_RowToBilling(DataRow oRow)
		{
			Billing oBilling = new Billing();

			oBilling.ID_Billing = ((Int32)(oRow["ID_Billing"]));
			if (!(oRow["ID_Operator"] is DBNull)) {
			  oBilling.ID_Operator = ((Int32)(oRow["ID_Operator"]));
			  oBilling.ID_Operator_HasValue = true;
			} else {
			  oBilling.ID_Operator_HasValue = false;
			}
			oBilling.Activation = ((DateTime)(oRow["Activation"]));
			if (!(oRow["End"] is DBNull)) {
			  oBilling.End = ((DateTime)(oRow["End"]));
			  oBilling.End_HasValue = true;
			} else {
			  oBilling.End_HasValue = false;
			}
			if (!(oRow["HourlyCost"] is DBNull)) {
			  oBilling.HourlyCost = ((Decimal)(oRow["HourlyCost"]));
			  oBilling.HourlyCost_HasValue = true;
			} else {
			  oBilling.HourlyCost_HasValue = false;
			}
			if (!(oRow["Year"] is DBNull)) {
			  oBilling.Year = ((Int32)(oRow["Year"]));
			  oBilling.Year_HasValue = true;
			} else {
			  oBilling.Year_HasValue = false;
			}
			if (!(oRow["Month"] is DBNull)) {
			  oBilling.Month = ((Int32)(oRow["Month"]));
			  oBilling.Month_HasValue = true;
			} else {
			  oBilling.Month_HasValue = false;
			}
			if (!(oRow["StartDay"] is DBNull)) {
			  oBilling.StartDay = ((DateTime)(oRow["StartDay"]));
			  oBilling.StartDay_HasValue = true;
			} else {
			  oBilling.StartDay_HasValue = false;
			}
			if (!(oRow["EndDay"] is DBNull)) {
			  oBilling.EndDay = ((DateTime)(oRow["EndDay"]));
			  oBilling.EndDay_HasValue = true;
			} else {
			  oBilling.EndDay_HasValue = false;
			}
			if (!(oRow["Value"] is DBNull)) {
			  oBilling.Value = ((Decimal)(oRow["Value"]));
			  oBilling.Value_HasValue = true;
			} else {
			  oBilling.Value_HasValue = false;
			}

			return (oBilling);
		}
		#endregion
	}

}

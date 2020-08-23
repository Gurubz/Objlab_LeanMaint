using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Data.Maintenance
{
	/// <summary>
	/// Public Supplier Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  23/08/2020  Created
	/// </remarks>
	public class Suppliers : EntitiesManagerBase
	{
		#region Public Properties
		public Supplier this[int nIndex]
		{
			get { return ((Supplier)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public Supplier GetByKeys(Int32 nID_Supplier)
		{
			foreach (Supplier oSupplier in this.m_aItems)
			{
				if (oSupplier.ID_Supplier == nID_Supplier)
				{
					return (oSupplier);
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
			Supplier oSupplier = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oSupplier = UTI_RowToSupplier(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oSupplier);

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

			oDelete = new StringBuilder("DELETE FROM [Suppliers]");

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
			oSelect = new StringBuilder("SELECT * FROM [Suppliers]");

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

		public static Supplier LoadOne(Int32 nID_Supplier)
		{
			return(LoadOne(nID_Supplier, null));
		}

		public static Supplier LoadOne(Int32 nID_Supplier, SqlConnection oPrivateConnection)
		{
			Supplier oSupplier = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Suppliers]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_Supplier]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Supplier));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oSupplier = UTI_RowToSupplier(oRow);
			}

			return (oSupplier);
		}

		public static Supplier TryLoadOne(Int32 nID_Supplier)
		{
			return(TryLoadOne(nID_Supplier, null));
		}

		public static Supplier TryLoadOne(Int32 nID_Supplier, SqlConnection oPrivateConnection)
		{
			Supplier oSupplier = null;

			oSupplier = LoadOne(nID_Supplier, null);

			if (oSupplier == null)
			{
				return (new Supplier());
			}
			else
			{
				return (oSupplier);
			}
		}

		public static void InsertOne(Supplier oSupplier)
		{
			InsertOne(oSupplier, null);
		}

		public static void InsertOne(Supplier oSupplier, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Suppliers] ");
			oInsert.Append("([Name], [Description], [ID_SupplierType], [ID_ObjStatus], [Address1], [Address2], [ID_CostCenter], [HourlyCost], [ID_City], [Zip], [ID_Country], [ValidFrom], [ID_User])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oSupplier.Name));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oSupplier.Description));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oSupplier.ID_SupplierType));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oSupplier.ID_ObjStatus));
			oInsert.Append(", ");
			if (oSupplier.Address1_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oSupplier.Address1));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oSupplier.Address2_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oSupplier.Address2));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oSupplier.ID_CostCenter_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oSupplier.ID_CostCenter));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oSupplier.HourlyCost_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oSupplier.HourlyCost));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oSupplier.ID_City_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oSupplier.ID_City));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oSupplier.Zip_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oSupplier.Zip));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oSupplier.ID_Country_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oSupplier.ID_Country));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oSupplier.ValidFrom_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oSupplier.ValidFrom));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oSupplier.ID_User));
			oInsert.Append(")");

			Object oRet;
			oRet = EntitiesManagerBase.DAT_ExecuteScalar(oInsert.ToString(), "\nSELECT @@IDENTITY AS ID", oPrivateConnection);
			oSupplier.ID_Supplier = Convert.ToInt32(oRet);
		}

		public static void UpdateOne(Supplier oSupplier)
		{
			UpdateOne(oSupplier, null);
		}

		public static void UpdateOne(Supplier oSupplier, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Suppliers] SET ");

			oUpdate.Append("[Name]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oSupplier.Name));
			oUpdate.Append(", ");
			oUpdate.Append("[Description]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oSupplier.Description));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_SupplierType]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oSupplier.ID_SupplierType));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_ObjStatus]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oSupplier.ID_ObjStatus));
			oUpdate.Append(", ");
			oUpdate.Append("[Address1]=");
			if (oSupplier.Address1_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oSupplier.Address1));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[Address2]=");
			if (oSupplier.Address2_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oSupplier.Address2));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[ID_CostCenter]=");
			if (oSupplier.ID_CostCenter_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oSupplier.ID_CostCenter));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[HourlyCost]=");
			if (oSupplier.HourlyCost_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oSupplier.HourlyCost));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[ID_City]=");
			if (oSupplier.ID_City_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oSupplier.ID_City));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[Zip]=");
			if (oSupplier.Zip_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oSupplier.Zip));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[ID_Country]=");
			if (oSupplier.ID_Country_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oSupplier.ID_Country));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[ValidFrom]=");
			if (oSupplier.ValidFrom_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oSupplier.ValidFrom));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[ID_User]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oSupplier.ID_User));

			oUpdate.Append(UTI_Where4One(oSupplier));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(Supplier oSupplier)
		{
			DeleteOne(oSupplier, null);
		}

		public static void DeleteOne(Supplier oSupplier, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Suppliers]");

			oDelete.Append(UTI_Where4One(oSupplier));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(Supplier oSupplier)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Supplier]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oSupplier.ID_Supplier));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_Supplier)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Supplier]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Supplier));

			return (oWhere.ToString());
		}

		public static Supplier UTI_RowToSupplier(DataRow oRow)
		{
			Supplier oSupplier = new Supplier();

			oSupplier.ID_Supplier = ((Int32)(oRow["ID_Supplier"]));
			oSupplier.Name = ((String)(oRow["Name"])).Trim();
			oSupplier.Description = ((String)(oRow["Description"])).Trim();
			oSupplier.ID_SupplierType = ((Int32)(oRow["ID_SupplierType"]));
			oSupplier.ID_ObjStatus = ((Int32)(oRow["ID_ObjStatus"]));
			if (!(oRow["Address1"] is DBNull)) {
			  oSupplier.Address1 = ((String)(oRow["Address1"])).Trim();
			  oSupplier.Address1_HasValue = true;
			} else {
			  oSupplier.Address1_HasValue = false;
			}
			if (!(oRow["Address2"] is DBNull)) {
			  oSupplier.Address2 = ((String)(oRow["Address2"])).Trim();
			  oSupplier.Address2_HasValue = true;
			} else {
			  oSupplier.Address2_HasValue = false;
			}
			if (!(oRow["ID_CostCenter"] is DBNull)) {
			  oSupplier.ID_CostCenter = ((Int32)(oRow["ID_CostCenter"]));
			  oSupplier.ID_CostCenter_HasValue = true;
			} else {
			  oSupplier.ID_CostCenter_HasValue = false;
			}
			if (!(oRow["HourlyCost"] is DBNull)) {
			  oSupplier.HourlyCost = ((Decimal)(oRow["HourlyCost"]));
			  oSupplier.HourlyCost_HasValue = true;
			} else {
			  oSupplier.HourlyCost_HasValue = false;
			}
			if (!(oRow["ID_City"] is DBNull)) {
			  oSupplier.ID_City = ((Int32)(oRow["ID_City"]));
			  oSupplier.ID_City_HasValue = true;
			} else {
			  oSupplier.ID_City_HasValue = false;
			}
			if (!(oRow["Zip"] is DBNull)) {
			  oSupplier.Zip = ((String)(oRow["Zip"])).Trim();
			  oSupplier.Zip_HasValue = true;
			} else {
			  oSupplier.Zip_HasValue = false;
			}
			if (!(oRow["ID_Country"] is DBNull)) {
			  oSupplier.ID_Country = ((Int32)(oRow["ID_Country"]));
			  oSupplier.ID_Country_HasValue = true;
			} else {
			  oSupplier.ID_Country_HasValue = false;
			}
			if (!(oRow["ValidFrom"] is DBNull)) {
			  oSupplier.ValidFrom = ((DateTime)(oRow["ValidFrom"]));
			  oSupplier.ValidFrom_HasValue = true;
			} else {
			  oSupplier.ValidFrom_HasValue = false;
			}
			oSupplier.ID_User = ((Int32)(oRow["ID_User"]));

			return (oSupplier);
		}
		#endregion
	}

}

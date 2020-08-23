using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Data.Maintenance
{
	/// <summary>
	/// Public Intervention Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  23/08/2020  Created
	/// </remarks>
	public class Interventions : EntitiesManagerBase
	{
		#region Public Properties
		public Intervention this[int nIndex]
		{
			get { return ((Intervention)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public Intervention GetByKeys(Int32 nID_Intervention)
		{
			foreach (Intervention oIntervention in this.m_aItems)
			{
				if (oIntervention.ID_Intervention == nID_Intervention)
				{
					return (oIntervention);
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
			Intervention oIntervention = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oIntervention = UTI_RowToIntervention(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oIntervention);

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

			oDelete = new StringBuilder("DELETE FROM [Interventions]");

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
			oSelect = new StringBuilder("SELECT * FROM [Interventions]");

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

		public static Intervention LoadOne(Int32 nID_Intervention)
		{
			return(LoadOne(nID_Intervention, null));
		}

		public static Intervention LoadOne(Int32 nID_Intervention, SqlConnection oPrivateConnection)
		{
			Intervention oIntervention = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Interventions]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_Intervention]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Intervention));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oIntervention = UTI_RowToIntervention(oRow);
			}

			return (oIntervention);
		}

		public static Intervention TryLoadOne(Int32 nID_Intervention)
		{
			return(TryLoadOne(nID_Intervention, null));
		}

		public static Intervention TryLoadOne(Int32 nID_Intervention, SqlConnection oPrivateConnection)
		{
			Intervention oIntervention = null;

			oIntervention = LoadOne(nID_Intervention, null);

			if (oIntervention == null)
			{
				return (new Intervention());
			}
			else
			{
				return (oIntervention);
			}
		}

		public static void InsertOne(Intervention oIntervention)
		{
			InsertOne(oIntervention, null);
		}

		public static void InsertOne(Intervention oIntervention, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Interventions] ");
			oInsert.Append("([Description], [ID_Operator], [ID_Plant], [RequestedAt], [Tarif_Inter], [Tipo_Risorsa], [Desc_Risorsa], [CDC_Risorsa], [Tipo_Plant], [DT_Conf_Int], [DT_Eff_Int], [DT_Ultimo_Guasto], [DT_Ultima_Riparazione], [ID_Outcome], [ID_ObjStatus], [Hours], [TotalCost], [Probability], [Gravity], [Rilevability])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			if (oIntervention.Description_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.Description));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oIntervention.ID_Operator_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.ID_Operator));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oIntervention.ID_Plant_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.ID_Plant));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oIntervention.RequestedAt_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.RequestedAt));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oIntervention.Tarif_Inter_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.Tarif_Inter));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oIntervention.Tipo_Risorsa_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.Tipo_Risorsa));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oIntervention.Desc_Risorsa_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.Desc_Risorsa));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oIntervention.CDC_Risorsa_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.CDC_Risorsa));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oIntervention.Tipo_Plant_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.Tipo_Plant));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oIntervention.DT_Conf_Int_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.DT_Conf_Int));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oIntervention.DT_Eff_Int_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.DT_Eff_Int));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oIntervention.DT_Ultimo_Guasto_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.DT_Ultimo_Guasto));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oIntervention.DT_Ultima_Riparazione_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.DT_Ultima_Riparazione));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oIntervention.ID_Outcome_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.ID_Outcome));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oIntervention.ID_ObjStatus_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.ID_ObjStatus));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oIntervention.Hours_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.Hours));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oIntervention.TotalCost_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.TotalCost));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oIntervention.Probability_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.Probability));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oIntervention.Gravity_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.Gravity));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oIntervention.Rilevability_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.Rilevability));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(")");

			Object oRet;
			oRet = EntitiesManagerBase.DAT_ExecuteScalar(oInsert.ToString(), "\nSELECT @@IDENTITY AS ID", oPrivateConnection);
			oIntervention.ID_Intervention = Convert.ToInt32(oRet);
		}

		public static void UpdateOne(Intervention oIntervention)
		{
			UpdateOne(oIntervention, null);
		}

		public static void UpdateOne(Intervention oIntervention, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Interventions] SET ");

			oUpdate.Append("[Description]=");
			if (oIntervention.Description_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.Description));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[ID_Operator]=");
			if (oIntervention.ID_Operator_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.ID_Operator));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[ID_Plant]=");
			if (oIntervention.ID_Plant_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.ID_Plant));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[RequestedAt]=");
			if (oIntervention.RequestedAt_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.RequestedAt));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[Tarif_Inter]=");
			if (oIntervention.Tarif_Inter_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.Tarif_Inter));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[Tipo_Risorsa]=");
			if (oIntervention.Tipo_Risorsa_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.Tipo_Risorsa));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[Desc_Risorsa]=");
			if (oIntervention.Desc_Risorsa_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.Desc_Risorsa));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[CDC_Risorsa]=");
			if (oIntervention.CDC_Risorsa_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.CDC_Risorsa));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[Tipo_Plant]=");
			if (oIntervention.Tipo_Plant_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.Tipo_Plant));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[DT_Conf_Int]=");
			if (oIntervention.DT_Conf_Int_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.DT_Conf_Int));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[DT_Eff_Int]=");
			if (oIntervention.DT_Eff_Int_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.DT_Eff_Int));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[DT_Ultimo_Guasto]=");
			if (oIntervention.DT_Ultimo_Guasto_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.DT_Ultimo_Guasto));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[DT_Ultima_Riparazione]=");
			if (oIntervention.DT_Ultima_Riparazione_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.DT_Ultima_Riparazione));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[ID_Outcome]=");
			if (oIntervention.ID_Outcome_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.ID_Outcome));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[ID_ObjStatus]=");
			if (oIntervention.ID_ObjStatus_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.ID_ObjStatus));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[Hours]=");
			if (oIntervention.Hours_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.Hours));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[TotalCost]=");
			if (oIntervention.TotalCost_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.TotalCost));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[Probability]=");
			if (oIntervention.Probability_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.Probability));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[Gravity]=");
			if (oIntervention.Gravity_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.Gravity));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[Rilevability]=");
			if (oIntervention.Rilevability_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.Rilevability));
			} else {
			oUpdate.Append("NULL");
			}

			oUpdate.Append(UTI_Where4One(oIntervention));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(Intervention oIntervention)
		{
			DeleteOne(oIntervention, null);
		}

		public static void DeleteOne(Intervention oIntervention, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Interventions]");

			oDelete.Append(UTI_Where4One(oIntervention));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(Intervention oIntervention)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Intervention]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oIntervention.ID_Intervention));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_Intervention)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Intervention]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Intervention));

			return (oWhere.ToString());
		}

		public static Intervention UTI_RowToIntervention(DataRow oRow)
		{
			Intervention oIntervention = new Intervention();

			oIntervention.ID_Intervention = ((Int32)(oRow["ID_Intervention"]));
			if (!(oRow["Description"] is DBNull)) {
			  oIntervention.Description = ((String)(oRow["Description"])).Trim();
			  oIntervention.Description_HasValue = true;
			} else {
			  oIntervention.Description_HasValue = false;
			}
			if (!(oRow["ID_Operator"] is DBNull)) {
			  oIntervention.ID_Operator = ((Int32)(oRow["ID_Operator"]));
			  oIntervention.ID_Operator_HasValue = true;
			} else {
			  oIntervention.ID_Operator_HasValue = false;
			}
			if (!(oRow["ID_Plant"] is DBNull)) {
			  oIntervention.ID_Plant = ((Int32)(oRow["ID_Plant"]));
			  oIntervention.ID_Plant_HasValue = true;
			} else {
			  oIntervention.ID_Plant_HasValue = false;
			}
			if (!(oRow["RequestedAt"] is DBNull)) {
			  oIntervention.RequestedAt = ((DateTime)(oRow["RequestedAt"]));
			  oIntervention.RequestedAt_HasValue = true;
			} else {
			  oIntervention.RequestedAt_HasValue = false;
			}
			if (!(oRow["Tarif_Inter"] is DBNull)) {
			  oIntervention.Tarif_Inter = ((Int32)(oRow["Tarif_Inter"]));
			  oIntervention.Tarif_Inter_HasValue = true;
			} else {
			  oIntervention.Tarif_Inter_HasValue = false;
			}
			if (!(oRow["Tipo_Risorsa"] is DBNull)) {
			  oIntervention.Tipo_Risorsa = ((String)(oRow["Tipo_Risorsa"])).Trim();
			  oIntervention.Tipo_Risorsa_HasValue = true;
			} else {
			  oIntervention.Tipo_Risorsa_HasValue = false;
			}
			if (!(oRow["Desc_Risorsa"] is DBNull)) {
			  oIntervention.Desc_Risorsa = ((String)(oRow["Desc_Risorsa"])).Trim();
			  oIntervention.Desc_Risorsa_HasValue = true;
			} else {
			  oIntervention.Desc_Risorsa_HasValue = false;
			}
			if (!(oRow["CDC_Risorsa"] is DBNull)) {
			  oIntervention.CDC_Risorsa = ((String)(oRow["CDC_Risorsa"])).Trim();
			  oIntervention.CDC_Risorsa_HasValue = true;
			} else {
			  oIntervention.CDC_Risorsa_HasValue = false;
			}
			if (!(oRow["Tipo_Plant"] is DBNull)) {
			  oIntervention.Tipo_Plant = ((String)(oRow["Tipo_Plant"])).Trim();
			  oIntervention.Tipo_Plant_HasValue = true;
			} else {
			  oIntervention.Tipo_Plant_HasValue = false;
			}
			if (!(oRow["DT_Conf_Int"] is DBNull)) {
			  oIntervention.DT_Conf_Int = ((Int32)(oRow["DT_Conf_Int"]));
			  oIntervention.DT_Conf_Int_HasValue = true;
			} else {
			  oIntervention.DT_Conf_Int_HasValue = false;
			}
			if (!(oRow["DT_Eff_Int"] is DBNull)) {
			  oIntervention.DT_Eff_Int = ((Int32)(oRow["DT_Eff_Int"]));
			  oIntervention.DT_Eff_Int_HasValue = true;
			} else {
			  oIntervention.DT_Eff_Int_HasValue = false;
			}
			if (!(oRow["DT_Ultimo_Guasto"] is DBNull)) {
			  oIntervention.DT_Ultimo_Guasto = ((Int32)(oRow["DT_Ultimo_Guasto"]));
			  oIntervention.DT_Ultimo_Guasto_HasValue = true;
			} else {
			  oIntervention.DT_Ultimo_Guasto_HasValue = false;
			}
			if (!(oRow["DT_Ultima_Riparazione"] is DBNull)) {
			  oIntervention.DT_Ultima_Riparazione = ((Int32)(oRow["DT_Ultima_Riparazione"]));
			  oIntervention.DT_Ultima_Riparazione_HasValue = true;
			} else {
			  oIntervention.DT_Ultima_Riparazione_HasValue = false;
			}
			if (!(oRow["ID_Outcome"] is DBNull)) {
			  oIntervention.ID_Outcome = ((Int32)(oRow["ID_Outcome"]));
			  oIntervention.ID_Outcome_HasValue = true;
			} else {
			  oIntervention.ID_Outcome_HasValue = false;
			}
			if (!(oRow["ID_ObjStatus"] is DBNull)) {
			  oIntervention.ID_ObjStatus = ((Int32)(oRow["ID_ObjStatus"]));
			  oIntervention.ID_ObjStatus_HasValue = true;
			} else {
			  oIntervention.ID_ObjStatus_HasValue = false;
			}
			if (!(oRow["Hours"] is DBNull)) {
			  oIntervention.Hours = ((Int32)(oRow["Hours"]));
			  oIntervention.Hours_HasValue = true;
			} else {
			  oIntervention.Hours_HasValue = false;
			}
			if (!(oRow["TotalCost"] is DBNull)) {
			  oIntervention.TotalCost = ((Int32)(oRow["TotalCost"]));
			  oIntervention.TotalCost_HasValue = true;
			} else {
			  oIntervention.TotalCost_HasValue = false;
			}
			if (!(oRow["Probability"] is DBNull)) {
			  oIntervention.Probability = ((Int32)(oRow["Probability"]));
			  oIntervention.Probability_HasValue = true;
			} else {
			  oIntervention.Probability_HasValue = false;
			}
			if (!(oRow["Gravity"] is DBNull)) {
			  oIntervention.Gravity = ((Int32)(oRow["Gravity"]));
			  oIntervention.Gravity_HasValue = true;
			} else {
			  oIntervention.Gravity_HasValue = false;
			}
			if (!(oRow["Rilevability"] is DBNull)) {
			  oIntervention.Rilevability = ((Int32)(oRow["Rilevability"]));
			  oIntervention.Rilevability_HasValue = true;
			} else {
			  oIntervention.Rilevability_HasValue = false;
			}

			return (oIntervention);
		}
		#endregion
	}

}

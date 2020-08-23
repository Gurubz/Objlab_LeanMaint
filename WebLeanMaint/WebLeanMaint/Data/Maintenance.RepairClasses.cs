using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Data.Maintenance
{
	/// <summary>
	/// Public RepairClasse Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  23/08/2020  Created
	/// </remarks>
	public class RepairClasses : EntitiesManagerBase
	{
		#region Public Properties
		public RepairClasse this[int nIndex]
		{
			get { return ((RepairClasse)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public RepairClasse GetByKeys(Int32 nID_RepairClass)
		{
			foreach (RepairClasse oRepairClasse in this.m_aItems)
			{
				if (oRepairClasse.ID_RepairClass == nID_RepairClass)
				{
					return (oRepairClasse);
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
			RepairClasse oRepairClasse = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oRepairClasse = UTI_RowToRepairClasse(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oRepairClasse);

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

			oDelete = new StringBuilder("DELETE FROM [RepairClasses]");

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
			oSelect = new StringBuilder("SELECT * FROM [RepairClasses]");

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

		public static RepairClasse LoadOne(Int32 nID_RepairClass)
		{
			return(LoadOne(nID_RepairClass, null));
		}

		public static RepairClasse LoadOne(Int32 nID_RepairClass, SqlConnection oPrivateConnection)
		{
			RepairClasse oRepairClasse = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [RepairClasses]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_RepairClass]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_RepairClass));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oRepairClasse = UTI_RowToRepairClasse(oRow);
			}

			return (oRepairClasse);
		}

		public static RepairClasse TryLoadOne(Int32 nID_RepairClass)
		{
			return(TryLoadOne(nID_RepairClass, null));
		}

		public static RepairClasse TryLoadOne(Int32 nID_RepairClass, SqlConnection oPrivateConnection)
		{
			RepairClasse oRepairClasse = null;

			oRepairClasse = LoadOne(nID_RepairClass, null);

			if (oRepairClasse == null)
			{
				return (new RepairClasse());
			}
			else
			{
				return (oRepairClasse);
			}
		}

		public static void InsertOne(RepairClasse oRepairClasse)
		{
			InsertOne(oRepairClasse, null);
		}

		public static void InsertOne(RepairClasse oRepairClasse, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [RepairClasses] ");
			oInsert.Append("([Name], [Description])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			if (oRepairClasse.Name_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oRepairClasse.Name));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oRepairClasse.Description_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oRepairClasse.Description));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(")");

			Object oRet;
			oRet = EntitiesManagerBase.DAT_ExecuteScalar(oInsert.ToString(), "\nSELECT @@IDENTITY AS ID", oPrivateConnection);
			oRepairClasse.ID_RepairClass = Convert.ToInt32(oRet);
		}

		public static void UpdateOne(RepairClasse oRepairClasse)
		{
			UpdateOne(oRepairClasse, null);
		}

		public static void UpdateOne(RepairClasse oRepairClasse, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [RepairClasses] SET ");

			oUpdate.Append("[Name]=");
			if (oRepairClasse.Name_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oRepairClasse.Name));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[Description]=");
			if (oRepairClasse.Description_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oRepairClasse.Description));
			} else {
			oUpdate.Append("NULL");
			}

			oUpdate.Append(UTI_Where4One(oRepairClasse));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(RepairClasse oRepairClasse)
		{
			DeleteOne(oRepairClasse, null);
		}

		public static void DeleteOne(RepairClasse oRepairClasse, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [RepairClasses]");

			oDelete.Append(UTI_Where4One(oRepairClasse));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(RepairClasse oRepairClasse)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_RepairClass]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oRepairClasse.ID_RepairClass));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_RepairClass)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_RepairClass]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_RepairClass));

			return (oWhere.ToString());
		}

		public static RepairClasse UTI_RowToRepairClasse(DataRow oRow)
		{
			RepairClasse oRepairClasse = new RepairClasse();

			oRepairClasse.ID_RepairClass = ((Int32)(oRow["ID_RepairClass"]));
			if (!(oRow["Name"] is DBNull)) {
			  oRepairClasse.Name = ((String)(oRow["Name"])).Trim();
			  oRepairClasse.Name_HasValue = true;
			} else {
			  oRepairClasse.Name_HasValue = false;
			}
			if (!(oRow["Description"] is DBNull)) {
			  oRepairClasse.Description = ((String)(oRow["Description"])).Trim();
			  oRepairClasse.Description_HasValue = true;
			} else {
			  oRepairClasse.Description_HasValue = false;
			}

			return (oRepairClasse);
		}
		#endregion
	}

}

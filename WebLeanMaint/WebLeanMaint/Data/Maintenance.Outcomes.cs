using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Data.Maintenance
{
	/// <summary>
	/// Public Outcome Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  25/08/2020  Created
	/// </remarks>
	public class Outcomes : EntitiesManagerBase
	{
		#region Public Properties
		public Outcome this[int nIndex]
		{
			get { return ((Outcome)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public Outcome GetByKeys(Int32 nID)
		{
			foreach (Outcome oOutcome in this.m_aItems)
			{
				if (oOutcome.ID == nID)
				{
					return (oOutcome);
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
			Outcome oOutcome = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oOutcome = UTI_RowToOutcome(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oOutcome);

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

			oDelete = new StringBuilder("DELETE FROM [Outcomes]");

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
			oSelect = new StringBuilder("SELECT * FROM [Outcomes]");

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

		public static Outcome LoadOne(Int32 nID)
		{
			return(LoadOne(nID, null));
		}

		public static Outcome LoadOne(Int32 nID, SqlConnection oPrivateConnection)
		{
			Outcome oOutcome = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Outcomes]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oOutcome = UTI_RowToOutcome(oRow);
			}

			return (oOutcome);
		}

		public static Outcome TryLoadOne(Int32 nID)
		{
			return(TryLoadOne(nID, null));
		}

		public static Outcome TryLoadOne(Int32 nID, SqlConnection oPrivateConnection)
		{
			Outcome oOutcome = null;

			oOutcome = LoadOne(nID, null);

			if (oOutcome == null)
			{
				return (new Outcome());
			}
			else
			{
				return (oOutcome);
			}
		}

		public static void InsertOne(Outcome oOutcome)
		{
			InsertOne(oOutcome, null);
		}

		public static void InsertOne(Outcome oOutcome, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Outcomes] ");
			oInsert.Append("([Name], [Description])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			if (oOutcome.Name_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOutcome.Name));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oOutcome.Description_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOutcome.Description));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(")");

			Object oRet;
			oRet = EntitiesManagerBase.DAT_ExecuteScalar(oInsert.ToString(), "\nSELECT @@IDENTITY AS ID", oPrivateConnection);
			oOutcome.ID = Convert.ToInt32(oRet);
		}

		public static void UpdateOne(Outcome oOutcome)
		{
			UpdateOne(oOutcome, null);
		}

		public static void UpdateOne(Outcome oOutcome, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Outcomes] SET ");

			oUpdate.Append("[Name]=");
			if (oOutcome.Name_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOutcome.Name));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[Description]=");
			if (oOutcome.Description_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOutcome.Description));
			} else {
			oUpdate.Append("NULL");
			}

			oUpdate.Append(UTI_Where4One(oOutcome));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(Outcome oOutcome)
		{
			DeleteOne(oOutcome, null);
		}

		public static void DeleteOne(Outcome oOutcome, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Outcomes]");

			oDelete.Append(UTI_Where4One(oOutcome));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(Outcome oOutcome)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oOutcome.ID));

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

		public static Outcome UTI_RowToOutcome(DataRow oRow)
		{
			Outcome oOutcome = new Outcome();

			oOutcome.ID = ((Int32)(oRow["ID"]));
			if (!(oRow["Name"] is DBNull)) {
			  oOutcome.Name = ((String)(oRow["Name"])).Trim();
			  oOutcome.Name_HasValue = true;
			} else {
			  oOutcome.Name_HasValue = false;
			}
			if (!(oRow["Description"] is DBNull)) {
			  oOutcome.Description = ((String)(oRow["Description"])).Trim();
			  oOutcome.Description_HasValue = true;
			} else {
			  oOutcome.Description_HasValue = false;
			}

			return (oOutcome);
		}
		#endregion
	}

}

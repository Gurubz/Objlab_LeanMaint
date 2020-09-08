using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Data.Config
{
	/// <summary>
	/// Public FailureStatuse Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  08/09/2020  Created
	/// </remarks>
	public class FailureStatuses : EntitiesManagerBase
	{
		#region Public Properties
		public FailureStatuse this[int nIndex]
		{
			get { return ((FailureStatuse)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public FailureStatuse GetByKeys(Int32 nID_FailureStatus)
		{
			foreach (FailureStatuse oFailureStatuse in this.m_aItems)
			{
				if (oFailureStatuse.ID_FailureStatus == nID_FailureStatus)
				{
					return (oFailureStatuse);
				}
			}

			return (null);
		}

		public FailureStatuse[] ToArray()
		{
			List<FailureStatuse> aRet = new List<FailureStatuse>();
			foreach (FailureStatuse oFailureStatuse in this.m_aItems)
			{
				aRet.Add(oFailureStatuse);
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
			FailureStatuse oFailureStatuse = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oFailureStatuse = UTI_RowToFailureStatuse(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oFailureStatuse);

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

			oDelete = new StringBuilder("DELETE FROM [Config].[FailureStatuses]");

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
			oSelect = new StringBuilder("SELECT * FROM [Config].[FailureStatuses]");

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

		public static FailureStatuse LoadOne(Int32 nID_FailureStatus)
		{
			return(LoadOne(nID_FailureStatus, null));
		}

		public static FailureStatuse LoadOne(Int32 nID_FailureStatus, SqlConnection oPrivateConnection)
		{
			FailureStatuse oFailureStatuse = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Config].[FailureStatuses]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_FailureStatus]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_FailureStatus));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oFailureStatuse = UTI_RowToFailureStatuse(oRow);
			}

			return (oFailureStatuse);
		}

		public static FailureStatuse TryLoadOne(Int32 nID_FailureStatus)
		{
			return(TryLoadOne(nID_FailureStatus, null));
		}

		public static FailureStatuse TryLoadOne(Int32 nID_FailureStatus, SqlConnection oPrivateConnection)
		{
			FailureStatuse oFailureStatuse = null;

			oFailureStatuse = LoadOne(nID_FailureStatus, null);

			if (oFailureStatuse == null)
			{
				return (new FailureStatuse());
			}
			else
			{
				return (oFailureStatuse);
			}
		}

		public static void InsertOne(FailureStatuse oFailureStatuse)
		{
			InsertOne(oFailureStatuse, null);
		}

		public static void InsertOne(FailureStatuse oFailureStatuse, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Config].[FailureStatuses] ");
			oInsert.Append("([Name], [Description])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			if (oFailureStatuse.Name_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oFailureStatuse.Name));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oFailureStatuse.Description_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oFailureStatuse.Description));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(")");

			Object oRet;
			oRet = EntitiesManagerBase.DAT_ExecuteScalar(oInsert.ToString(), "\nSELECT @@IDENTITY AS ID", oPrivateConnection);
			oFailureStatuse.ID_FailureStatus = Convert.ToInt32(oRet);
		}

		public static void UpdateOne(FailureStatuse oFailureStatuse)
		{
			UpdateOne(oFailureStatuse, null);
		}

		public static void UpdateOne(FailureStatuse oFailureStatuse, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Config].[FailureStatuses] SET ");

			oUpdate.Append("[Name]=");
			if (oFailureStatuse.Name_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oFailureStatuse.Name));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[Description]=");
			if (oFailureStatuse.Description_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oFailureStatuse.Description));
			} else {
			oUpdate.Append("NULL");
			}

			oUpdate.Append(UTI_Where4One(oFailureStatuse));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(FailureStatuse oFailureStatuse)
		{
			DeleteOne(oFailureStatuse, null);
		}

		public static void DeleteOne(FailureStatuse oFailureStatuse, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Config].[FailureStatuses]");

			oDelete.Append(UTI_Where4One(oFailureStatuse));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(FailureStatuse oFailureStatuse)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_FailureStatus]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oFailureStatuse.ID_FailureStatus));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_FailureStatus)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_FailureStatus]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_FailureStatus));

			return (oWhere.ToString());
		}

		public static FailureStatuse UTI_RowToFailureStatuse(DataRow oRow)
		{
			FailureStatuse oFailureStatuse = new FailureStatuse();

			oFailureStatuse.ID_FailureStatus = ((Int32)(oRow["ID_FailureStatus"]));
			if (!(oRow["Name"] is DBNull)) {
			  oFailureStatuse.Name = ((String)(oRow["Name"])).Trim();
			  oFailureStatuse.Name_HasValue = true;
			} else {
			  oFailureStatuse.Name_HasValue = false;
			}
			if (!(oRow["Description"] is DBNull)) {
			  oFailureStatuse.Description = ((String)(oRow["Description"])).Trim();
			  oFailureStatuse.Description_HasValue = true;
			} else {
			  oFailureStatuse.Description_HasValue = false;
			}

			return (oFailureStatuse);
		}
		#endregion
	}

}

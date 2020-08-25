using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Data.Config
{
	/// <summary>
	/// Public GeographicCenter Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  25/08/2020  Created
	/// </remarks>
	public class GeographicCenters : EntitiesManagerBase
	{
		#region Public Properties
		public GeographicCenter this[int nIndex]
		{
			get { return ((GeographicCenter)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public GeographicCenter GetByKeys(Int32 nID_GeographicCenter)
		{
			foreach (GeographicCenter oGeographicCenter in this.m_aItems)
			{
				if (oGeographicCenter.ID_GeographicCenter == nID_GeographicCenter)
				{
					return (oGeographicCenter);
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
			GeographicCenter oGeographicCenter = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oGeographicCenter = UTI_RowToGeographicCenter(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oGeographicCenter);

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

			oDelete = new StringBuilder("DELETE FROM [GeographicCenters]");

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
			oSelect = new StringBuilder("SELECT * FROM [GeographicCenters]");

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

		public static GeographicCenter LoadOne(Int32 nID_GeographicCenter)
		{
			return(LoadOne(nID_GeographicCenter, null));
		}

		public static GeographicCenter LoadOne(Int32 nID_GeographicCenter, SqlConnection oPrivateConnection)
		{
			GeographicCenter oGeographicCenter = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [GeographicCenters]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_GeographicCenter]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_GeographicCenter));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oGeographicCenter = UTI_RowToGeographicCenter(oRow);
			}

			return (oGeographicCenter);
		}

		public static GeographicCenter TryLoadOne(Int32 nID_GeographicCenter)
		{
			return(TryLoadOne(nID_GeographicCenter, null));
		}

		public static GeographicCenter TryLoadOne(Int32 nID_GeographicCenter, SqlConnection oPrivateConnection)
		{
			GeographicCenter oGeographicCenter = null;

			oGeographicCenter = LoadOne(nID_GeographicCenter, null);

			if (oGeographicCenter == null)
			{
				return (new GeographicCenter());
			}
			else
			{
				return (oGeographicCenter);
			}
		}

		public static void InsertOne(GeographicCenter oGeographicCenter)
		{
			InsertOne(oGeographicCenter, null);
		}

		public static void InsertOne(GeographicCenter oGeographicCenter, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [GeographicCenters] ");
			oInsert.Append("([Name], [Description], [ID_GeographicCenterType], [ID_ObjStatus], [ID_Parent])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oGeographicCenter.Name));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oGeographicCenter.Description));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oGeographicCenter.ID_GeographicCenterType));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oGeographicCenter.ID_ObjStatus));
			oInsert.Append(", ");
			if (oGeographicCenter.ID_Parent_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oGeographicCenter.ID_Parent));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(")");

			Object oRet;
			oRet = EntitiesManagerBase.DAT_ExecuteScalar(oInsert.ToString(), "\nSELECT @@IDENTITY AS ID", oPrivateConnection);
			oGeographicCenter.ID_GeographicCenter = Convert.ToInt32(oRet);
		}

		public static void UpdateOne(GeographicCenter oGeographicCenter)
		{
			UpdateOne(oGeographicCenter, null);
		}

		public static void UpdateOne(GeographicCenter oGeographicCenter, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [GeographicCenters] SET ");

			oUpdate.Append("[Name]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oGeographicCenter.Name));
			oUpdate.Append(", ");
			oUpdate.Append("[Description]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oGeographicCenter.Description));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_GeographicCenterType]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oGeographicCenter.ID_GeographicCenterType));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_ObjStatus]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oGeographicCenter.ID_ObjStatus));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_Parent]=");
			if (oGeographicCenter.ID_Parent_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oGeographicCenter.ID_Parent));
			} else {
			oUpdate.Append("NULL");
			}

			oUpdate.Append(UTI_Where4One(oGeographicCenter));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(GeographicCenter oGeographicCenter)
		{
			DeleteOne(oGeographicCenter, null);
		}

		public static void DeleteOne(GeographicCenter oGeographicCenter, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [GeographicCenters]");

			oDelete.Append(UTI_Where4One(oGeographicCenter));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(GeographicCenter oGeographicCenter)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_GeographicCenter]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oGeographicCenter.ID_GeographicCenter));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_GeographicCenter)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_GeographicCenter]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_GeographicCenter));

			return (oWhere.ToString());
		}

		public static GeographicCenter UTI_RowToGeographicCenter(DataRow oRow)
		{
			GeographicCenter oGeographicCenter = new GeographicCenter();

			oGeographicCenter.ID_GeographicCenter = ((Int32)(oRow["ID_GeographicCenter"]));
			oGeographicCenter.Name = ((String)(oRow["Name"])).Trim();
			oGeographicCenter.Description = ((String)(oRow["Description"])).Trim();
			oGeographicCenter.ID_GeographicCenterType = ((Int32)(oRow["ID_GeographicCenterType"]));
			oGeographicCenter.ID_ObjStatus = ((Int32)(oRow["ID_ObjStatus"]));
			if (!(oRow["ID_Parent"] is DBNull)) {
			  oGeographicCenter.ID_Parent = ((Int32)(oRow["ID_Parent"]));
			  oGeographicCenter.ID_Parent_HasValue = true;
			} else {
			  oGeographicCenter.ID_Parent_HasValue = false;
			}

			return (oGeographicCenter);
		}
		#endregion
	}

}

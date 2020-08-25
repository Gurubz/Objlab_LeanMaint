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
	/// Public OrganizationCenter Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  25/08/2020  Created
	/// </remarks>
	public class OrganizationCenters : EntitiesManagerBase
	{
		#region Public Properties
		public OrganizationCenter this[int nIndex]
		{
			get { return ((OrganizationCenter)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public OrganizationCenter GetByKeys(Int32 nID_OrganizationCenter)
		{
			foreach (OrganizationCenter oOrganizationCenter in this.m_aItems)
			{
				if (oOrganizationCenter.ID_OrganizationCenter == nID_OrganizationCenter)
				{
					return (oOrganizationCenter);
				}
			}

			return (null);
		}

		public OrganizationCenter[] ToArray()
		{
			List<OrganizationCenter> aRet = new List<OrganizationCenter>();
			foreach (OrganizationCenter oOrganizationCenter in this.m_aItems)
			{
				aRet.Add(oOrganizationCenter);
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
			OrganizationCenter oOrganizationCenter = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oOrganizationCenter = UTI_RowToOrganizationCenter(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oOrganizationCenter);

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

			oDelete = new StringBuilder("DELETE FROM [OrganizationCenters]");

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
			oSelect = new StringBuilder("SELECT * FROM [OrganizationCenters]");

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

		public static OrganizationCenter LoadOne(Int32 nID_OrganizationCenter)
		{
			return(LoadOne(nID_OrganizationCenter, null));
		}

		public static OrganizationCenter LoadOne(Int32 nID_OrganizationCenter, SqlConnection oPrivateConnection)
		{
			OrganizationCenter oOrganizationCenter = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [OrganizationCenters]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_OrganizationCenter]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_OrganizationCenter));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oOrganizationCenter = UTI_RowToOrganizationCenter(oRow);
			}

			return (oOrganizationCenter);
		}

		public static OrganizationCenter TryLoadOne(Int32 nID_OrganizationCenter)
		{
			return(TryLoadOne(nID_OrganizationCenter, null));
		}

		public static OrganizationCenter TryLoadOne(Int32 nID_OrganizationCenter, SqlConnection oPrivateConnection)
		{
			OrganizationCenter oOrganizationCenter = null;

			oOrganizationCenter = LoadOne(nID_OrganizationCenter, null);

			if (oOrganizationCenter == null)
			{
				return (new OrganizationCenter());
			}
			else
			{
				return (oOrganizationCenter);
			}
		}

		public static void InsertOne(OrganizationCenter oOrganizationCenter)
		{
			InsertOne(oOrganizationCenter, null);
		}

		public static void InsertOne(OrganizationCenter oOrganizationCenter, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [OrganizationCenters] ");
			oInsert.Append("([Name], [Description], [ID_OrganizationCenterType], [ID_ObjStatus], [ID_Parent])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOrganizationCenter.Name));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOrganizationCenter.Description));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOrganizationCenter.ID_OrganizationCenterType));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOrganizationCenter.ID_ObjStatus));
			oInsert.Append(", ");
			if (oOrganizationCenter.ID_Parent_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOrganizationCenter.ID_Parent));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(")");

			Object oRet;
			oRet = EntitiesManagerBase.DAT_ExecuteScalar(oInsert.ToString(), "\nSELECT @@IDENTITY AS ID", oPrivateConnection);
			oOrganizationCenter.ID_OrganizationCenter = Convert.ToInt32(oRet);
		}

		public static void UpdateOne(OrganizationCenter oOrganizationCenter)
		{
			UpdateOne(oOrganizationCenter, null);
		}

		public static void UpdateOne(OrganizationCenter oOrganizationCenter, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [OrganizationCenters] SET ");

			oUpdate.Append("[Name]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOrganizationCenter.Name));
			oUpdate.Append(", ");
			oUpdate.Append("[Description]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOrganizationCenter.Description));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_OrganizationCenterType]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOrganizationCenter.ID_OrganizationCenterType));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_ObjStatus]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOrganizationCenter.ID_ObjStatus));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_Parent]=");
			if (oOrganizationCenter.ID_Parent_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOrganizationCenter.ID_Parent));
			} else {
			oUpdate.Append("NULL");
			}

			oUpdate.Append(UTI_Where4One(oOrganizationCenter));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(OrganizationCenter oOrganizationCenter)
		{
			DeleteOne(oOrganizationCenter, null);
		}

		public static void DeleteOne(OrganizationCenter oOrganizationCenter, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [OrganizationCenters]");

			oDelete.Append(UTI_Where4One(oOrganizationCenter));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(OrganizationCenter oOrganizationCenter)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_OrganizationCenter]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oOrganizationCenter.ID_OrganizationCenter));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_OrganizationCenter)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_OrganizationCenter]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_OrganizationCenter));

			return (oWhere.ToString());
		}

		public static OrganizationCenter UTI_RowToOrganizationCenter(DataRow oRow)
		{
			OrganizationCenter oOrganizationCenter = new OrganizationCenter();

			oOrganizationCenter.ID_OrganizationCenter = ((Int32)(oRow["ID_OrganizationCenter"]));
			oOrganizationCenter.Name = ((String)(oRow["Name"])).Trim();
			oOrganizationCenter.Description = ((String)(oRow["Description"])).Trim();
			oOrganizationCenter.ID_OrganizationCenterType = ((Int32)(oRow["ID_OrganizationCenterType"]));
			oOrganizationCenter.ID_ObjStatus = ((Int32)(oRow["ID_ObjStatus"]));
			if (!(oRow["ID_Parent"] is DBNull)) {
			  oOrganizationCenter.ID_Parent = ((Int32)(oRow["ID_Parent"]));
			  oOrganizationCenter.ID_Parent_HasValue = true;
			} else {
			  oOrganizationCenter.ID_Parent_HasValue = false;
			}

			return (oOrganizationCenter);
		}
		#endregion
	}

}

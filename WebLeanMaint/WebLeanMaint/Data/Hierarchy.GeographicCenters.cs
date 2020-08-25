using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Data.Hierarchy
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

		public GeographicCenter GetByKeys(Int32 nID_GeographicCenter, Int32 nLevel, Int32 nID_GeographicCenterChild)
		{
			foreach (GeographicCenter oGeographicCenter in this.m_aItems)
			{
				if (oGeographicCenter.ID_GeographicCenter == nID_GeographicCenter && oGeographicCenter.Level == nLevel && oGeographicCenter.ID_GeographicCenterChild == nID_GeographicCenterChild)
				{
					return (oGeographicCenter);
				}
			}

			return (null);
		}

		public GeographicCenter[] ToArray()
		{
			List<GeographicCenter> aRet = new List<GeographicCenter>();
			foreach (GeographicCenter oGeographicCenter in this.m_aItems)
			{
				aRet.Add(oGeographicCenter);
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

		public static GeographicCenter LoadOne(Int32 nID_GeographicCenter, Int32 nLevel, Int32 nID_GeographicCenterChild)
		{
			return(LoadOne(nID_GeographicCenter, nLevel, nID_GeographicCenterChild, null));
		}

		public static GeographicCenter LoadOne(Int32 nID_GeographicCenter, Int32 nLevel, Int32 nID_GeographicCenterChild, SqlConnection oPrivateConnection)
		{
			GeographicCenter oGeographicCenter = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [GeographicCenters]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_GeographicCenter]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_GeographicCenter));
			oSelect.Append(" AND ");
			oSelect.Append("[Level]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nLevel));
			oSelect.Append(" AND ");
			oSelect.Append("[ID_GeographicCenterChild]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_GeographicCenterChild));

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

		public static GeographicCenter TryLoadOne(Int32 nID_GeographicCenter, Int32 nLevel, Int32 nID_GeographicCenterChild)
		{
			return(TryLoadOne(nID_GeographicCenter, nLevel, nID_GeographicCenterChild, null));
		}

		public static GeographicCenter TryLoadOne(Int32 nID_GeographicCenter, Int32 nLevel, Int32 nID_GeographicCenterChild, SqlConnection oPrivateConnection)
		{
			GeographicCenter oGeographicCenter = null;

			oGeographicCenter = LoadOne(nID_GeographicCenter, nLevel, nID_GeographicCenterChild, null);

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
			oInsert.Append("([ID_GeographicCenter], [Level], [ID_GeographicCenterChild])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oGeographicCenter.ID_GeographicCenter));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oGeographicCenter.Level));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oGeographicCenter.ID_GeographicCenterChild));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(GeographicCenter oGeographicCenter)
		{
			UpdateOne(oGeographicCenter, null);
		}

		public static void UpdateOne(GeographicCenter oGeographicCenter, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [GeographicCenters] SET ");

			oUpdate.Append("[ID_GeographicCenter]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oGeographicCenter.ID_GeographicCenter));
			oUpdate.Append(", ");
			oUpdate.Append("[Level]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oGeographicCenter.Level));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_GeographicCenterChild]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oGeographicCenter.ID_GeographicCenterChild));

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
			oWhere.Append(" AND ");
			oWhere.Append("[Level]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oGeographicCenter.Level));
			oWhere.Append(" AND ");
			oWhere.Append("[ID_GeographicCenterChild]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oGeographicCenter.ID_GeographicCenterChild));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_GeographicCenter, Int32 nLevel, Int32 nID_GeographicCenterChild)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_GeographicCenter]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_GeographicCenter));
			oWhere.Append(" AND ");
			oWhere.Append("[Level]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nLevel));
			oWhere.Append(" AND ");
			oWhere.Append("[ID_GeographicCenterChild]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_GeographicCenterChild));

			return (oWhere.ToString());
		}

		public static GeographicCenter UTI_RowToGeographicCenter(DataRow oRow)
		{
			GeographicCenter oGeographicCenter = new GeographicCenter();

			oGeographicCenter.ID_GeographicCenter = ((Int32)(oRow["ID_GeographicCenter"]));
			oGeographicCenter.Level = ((Int32)(oRow["Level"]));
			oGeographicCenter.ID_GeographicCenterChild = ((Int32)(oRow["ID_GeographicCenterChild"]));

			return (oGeographicCenter);
		}
		#endregion
	}

}

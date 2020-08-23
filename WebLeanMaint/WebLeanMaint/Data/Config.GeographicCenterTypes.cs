using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Data.Config
{
	/// <summary>
	/// Public GeographicCenterType Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  23/08/2020  Created
	/// </remarks>
	public class GeographicCenterTypes : EntitiesManagerBase
	{
		#region Public Properties
		public GeographicCenterType this[int nIndex]
		{
			get { return ((GeographicCenterType)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public GeographicCenterType GetByKeys(Int32 nID_GeographicCenterType)
		{
			foreach (GeographicCenterType oGeographicCenterType in this.m_aItems)
			{
				if (oGeographicCenterType.ID_GeographicCenterType == nID_GeographicCenterType)
				{
					return (oGeographicCenterType);
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
			GeographicCenterType oGeographicCenterType = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oGeographicCenterType = UTI_RowToGeographicCenterType(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oGeographicCenterType);

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

			oDelete = new StringBuilder("DELETE FROM [GeographicCenterTypes]");

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
			oSelect = new StringBuilder("SELECT * FROM [GeographicCenterTypes]");

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

		public static GeographicCenterType LoadOne(Int32 nID_GeographicCenterType)
		{
			return(LoadOne(nID_GeographicCenterType, null));
		}

		public static GeographicCenterType LoadOne(Int32 nID_GeographicCenterType, SqlConnection oPrivateConnection)
		{
			GeographicCenterType oGeographicCenterType = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [GeographicCenterTypes]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_GeographicCenterType]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_GeographicCenterType));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oGeographicCenterType = UTI_RowToGeographicCenterType(oRow);
			}

			return (oGeographicCenterType);
		}

		public static GeographicCenterType TryLoadOne(Int32 nID_GeographicCenterType)
		{
			return(TryLoadOne(nID_GeographicCenterType, null));
		}

		public static GeographicCenterType TryLoadOne(Int32 nID_GeographicCenterType, SqlConnection oPrivateConnection)
		{
			GeographicCenterType oGeographicCenterType = null;

			oGeographicCenterType = LoadOne(nID_GeographicCenterType, null);

			if (oGeographicCenterType == null)
			{
				return (new GeographicCenterType());
			}
			else
			{
				return (oGeographicCenterType);
			}
		}

		public static void InsertOne(GeographicCenterType oGeographicCenterType)
		{
			InsertOne(oGeographicCenterType, null);
		}

		public static void InsertOne(GeographicCenterType oGeographicCenterType, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [GeographicCenterTypes] ");
			oInsert.Append("([ID_GeographicCenterType], [Name], [Description])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oGeographicCenterType.ID_GeographicCenterType));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oGeographicCenterType.Name));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oGeographicCenterType.Description));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(GeographicCenterType oGeographicCenterType)
		{
			UpdateOne(oGeographicCenterType, null);
		}

		public static void UpdateOne(GeographicCenterType oGeographicCenterType, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [GeographicCenterTypes] SET ");

			oUpdate.Append("[Name]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oGeographicCenterType.Name));
			oUpdate.Append(", ");
			oUpdate.Append("[Description]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oGeographicCenterType.Description));

			oUpdate.Append(UTI_Where4One(oGeographicCenterType));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(GeographicCenterType oGeographicCenterType)
		{
			DeleteOne(oGeographicCenterType, null);
		}

		public static void DeleteOne(GeographicCenterType oGeographicCenterType, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [GeographicCenterTypes]");

			oDelete.Append(UTI_Where4One(oGeographicCenterType));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(GeographicCenterType oGeographicCenterType)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_GeographicCenterType]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oGeographicCenterType.ID_GeographicCenterType));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_GeographicCenterType)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_GeographicCenterType]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_GeographicCenterType));

			return (oWhere.ToString());
		}

		public static GeographicCenterType UTI_RowToGeographicCenterType(DataRow oRow)
		{
			GeographicCenterType oGeographicCenterType = new GeographicCenterType();

			oGeographicCenterType.ID_GeographicCenterType = ((Int32)(oRow["ID_GeographicCenterType"]));
			oGeographicCenterType.Name = ((String)(oRow["Name"])).Trim();
			oGeographicCenterType.Description = ((String)(oRow["Description"])).Trim();

			return (oGeographicCenterType);
		}
		#endregion
	}

}

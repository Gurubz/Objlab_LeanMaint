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
	/// Public OrganizationCenterType Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  27/08/2020  Created
	/// </remarks>
	public class OrganizationCenterTypes : EntitiesManagerBase
	{
		#region Public Properties
		public OrganizationCenterType this[int nIndex]
		{
			get { return ((OrganizationCenterType)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public OrganizationCenterType GetByKeys(Int32 nID_OrganizationCenterType)
		{
			foreach (OrganizationCenterType oOrganizationCenterType in this.m_aItems)
			{
				if (oOrganizationCenterType.ID_OrganizationCenterType == nID_OrganizationCenterType)
				{
					return (oOrganizationCenterType);
				}
			}

			return (null);
		}

		public OrganizationCenterType[] ToArray()
		{
			List<OrganizationCenterType> aRet = new List<OrganizationCenterType>();
			foreach (OrganizationCenterType oOrganizationCenterType in this.m_aItems)
			{
				aRet.Add(oOrganizationCenterType);
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
			OrganizationCenterType oOrganizationCenterType = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oOrganizationCenterType = UTI_RowToOrganizationCenterType(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oOrganizationCenterType);

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

			oDelete = new StringBuilder("DELETE FROM [OrganizationCenterTypes]");

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
			oSelect = new StringBuilder("SELECT * FROM [OrganizationCenterTypes]");

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

		public static OrganizationCenterType LoadOne(Int32 nID_OrganizationCenterType)
		{
			return(LoadOne(nID_OrganizationCenterType, null));
		}

		public static OrganizationCenterType LoadOne(Int32 nID_OrganizationCenterType, SqlConnection oPrivateConnection)
		{
			OrganizationCenterType oOrganizationCenterType = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [OrganizationCenterTypes]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_OrganizationCenterType]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_OrganizationCenterType));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oOrganizationCenterType = UTI_RowToOrganizationCenterType(oRow);
			}

			return (oOrganizationCenterType);
		}

		public static OrganizationCenterType TryLoadOne(Int32 nID_OrganizationCenterType)
		{
			return(TryLoadOne(nID_OrganizationCenterType, null));
		}

		public static OrganizationCenterType TryLoadOne(Int32 nID_OrganizationCenterType, SqlConnection oPrivateConnection)
		{
			OrganizationCenterType oOrganizationCenterType = null;

			oOrganizationCenterType = LoadOne(nID_OrganizationCenterType, null);

			if (oOrganizationCenterType == null)
			{
				return (new OrganizationCenterType());
			}
			else
			{
				return (oOrganizationCenterType);
			}
		}

		public static void InsertOne(OrganizationCenterType oOrganizationCenterType)
		{
			InsertOne(oOrganizationCenterType, null);
		}

		public static void InsertOne(OrganizationCenterType oOrganizationCenterType, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [OrganizationCenterTypes] ");
			oInsert.Append("([ID_OrganizationCenterType], [Name], [Description])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOrganizationCenterType.ID_OrganizationCenterType));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOrganizationCenterType.Name));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOrganizationCenterType.Description));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(OrganizationCenterType oOrganizationCenterType)
		{
			UpdateOne(oOrganizationCenterType, null);
		}

		public static void UpdateOne(OrganizationCenterType oOrganizationCenterType, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [OrganizationCenterTypes] SET ");

			oUpdate.Append("[Name]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOrganizationCenterType.Name));
			oUpdate.Append(", ");
			oUpdate.Append("[Description]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOrganizationCenterType.Description));

			oUpdate.Append(UTI_Where4One(oOrganizationCenterType));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(OrganizationCenterType oOrganizationCenterType)
		{
			DeleteOne(oOrganizationCenterType, null);
		}

		public static void DeleteOne(OrganizationCenterType oOrganizationCenterType, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [OrganizationCenterTypes]");

			oDelete.Append(UTI_Where4One(oOrganizationCenterType));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(OrganizationCenterType oOrganizationCenterType)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_OrganizationCenterType]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oOrganizationCenterType.ID_OrganizationCenterType));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_OrganizationCenterType)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_OrganizationCenterType]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_OrganizationCenterType));

			return (oWhere.ToString());
		}

		public static OrganizationCenterType UTI_RowToOrganizationCenterType(DataRow oRow)
		{
			OrganizationCenterType oOrganizationCenterType = new OrganizationCenterType();

			oOrganizationCenterType.ID_OrganizationCenterType = ((Int32)(oRow["ID_OrganizationCenterType"]));
			oOrganizationCenterType.Name = ((String)(oRow["Name"])).Trim();
			oOrganizationCenterType.Description = ((String)(oRow["Description"])).Trim();

			return (oOrganizationCenterType);
		}
		#endregion
	}

}

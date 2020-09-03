using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Data.Accountancy
{
	/// <summary>
	/// Public CostCenterType Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  03/09/2020  Created
	/// </remarks>
	public class CostCenterTypes : EntitiesManagerBase
	{
		#region Public Properties
		public CostCenterType this[int nIndex]
		{
			get { return ((CostCenterType)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public CostCenterType GetByKeys(Int32 nID_CostCenterType)
		{
			foreach (CostCenterType oCostCenterType in this.m_aItems)
			{
				if (oCostCenterType.ID_CostCenterType == nID_CostCenterType)
				{
					return (oCostCenterType);
				}
			}

			return (null);
		}

		public CostCenterType[] ToArray()
		{
			List<CostCenterType> aRet = new List<CostCenterType>();
			foreach (CostCenterType oCostCenterType in this.m_aItems)
			{
				aRet.Add(oCostCenterType);
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
			CostCenterType oCostCenterType = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oCostCenterType = UTI_RowToCostCenterType(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oCostCenterType);

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

			oDelete = new StringBuilder("DELETE FROM [Accountancy].[CostCenterTypes]");

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
			oSelect = new StringBuilder("SELECT * FROM [Accountancy].[CostCenterTypes]");

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

		public static CostCenterType LoadOne(Int32 nID_CostCenterType)
		{
			return(LoadOne(nID_CostCenterType, null));
		}

		public static CostCenterType LoadOne(Int32 nID_CostCenterType, SqlConnection oPrivateConnection)
		{
			CostCenterType oCostCenterType = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Accountancy].[CostCenterTypes]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_CostCenterType]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_CostCenterType));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oCostCenterType = UTI_RowToCostCenterType(oRow);
			}

			return (oCostCenterType);
		}

		public static CostCenterType TryLoadOne(Int32 nID_CostCenterType)
		{
			return(TryLoadOne(nID_CostCenterType, null));
		}

		public static CostCenterType TryLoadOne(Int32 nID_CostCenterType, SqlConnection oPrivateConnection)
		{
			CostCenterType oCostCenterType = null;

			oCostCenterType = LoadOne(nID_CostCenterType, null);

			if (oCostCenterType == null)
			{
				return (new CostCenterType());
			}
			else
			{
				return (oCostCenterType);
			}
		}

		public static void InsertOne(CostCenterType oCostCenterType)
		{
			InsertOne(oCostCenterType, null);
		}

		public static void InsertOne(CostCenterType oCostCenterType, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Accountancy].[CostCenterTypes] ");
			oInsert.Append("([ID_CostCenterType], [Name], [Description])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oCostCenterType.ID_CostCenterType));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oCostCenterType.Name));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oCostCenterType.Description));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(CostCenterType oCostCenterType)
		{
			UpdateOne(oCostCenterType, null);
		}

		public static void UpdateOne(CostCenterType oCostCenterType, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Accountancy].[CostCenterTypes] SET ");

			oUpdate.Append("[Name]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oCostCenterType.Name));
			oUpdate.Append(", ");
			oUpdate.Append("[Description]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oCostCenterType.Description));

			oUpdate.Append(UTI_Where4One(oCostCenterType));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(CostCenterType oCostCenterType)
		{
			DeleteOne(oCostCenterType, null);
		}

		public static void DeleteOne(CostCenterType oCostCenterType, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Accountancy].[CostCenterTypes]");

			oDelete.Append(UTI_Where4One(oCostCenterType));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(CostCenterType oCostCenterType)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_CostCenterType]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oCostCenterType.ID_CostCenterType));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_CostCenterType)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_CostCenterType]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_CostCenterType));

			return (oWhere.ToString());
		}

		public static CostCenterType UTI_RowToCostCenterType(DataRow oRow)
		{
			CostCenterType oCostCenterType = new CostCenterType();

			oCostCenterType.ID_CostCenterType = ((Int32)(oRow["ID_CostCenterType"]));
			oCostCenterType.Name = ((String)(oRow["Name"])).Trim();
			oCostCenterType.Description = ((String)(oRow["Description"])).Trim();

			return (oCostCenterType);
		}
		#endregion
	}

}

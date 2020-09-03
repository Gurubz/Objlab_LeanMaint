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
	/// Public CostCenter Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  03/09/2020  Created
	/// </remarks>
	public class CostCenters : EntitiesManagerBase
	{
		#region Public Properties
		public CostCenter this[int nIndex]
		{
			get { return ((CostCenter)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public CostCenter GetByKeys(Int32 nID_CostCenter, Int32 nLevel, Int32 nID_CostCenterChild)
		{
			foreach (CostCenter oCostCenter in this.m_aItems)
			{
				if (oCostCenter.ID_CostCenter == nID_CostCenter && oCostCenter.Level == nLevel && oCostCenter.ID_CostCenterChild == nID_CostCenterChild)
				{
					return (oCostCenter);
				}
			}

			return (null);
		}

		public CostCenter[] ToArray()
		{
			List<CostCenter> aRet = new List<CostCenter>();
			foreach (CostCenter oCostCenter in this.m_aItems)
			{
				aRet.Add(oCostCenter);
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
			CostCenter oCostCenter = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oCostCenter = UTI_RowToCostCenter(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oCostCenter);

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

			oDelete = new StringBuilder("DELETE FROM [Hierarchy].[CostCenters]");

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
			oSelect = new StringBuilder("SELECT * FROM [Hierarchy].[CostCenters]");

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

		public static CostCenter LoadOne(Int32 nID_CostCenter, Int32 nLevel, Int32 nID_CostCenterChild)
		{
			return(LoadOne(nID_CostCenter, nLevel, nID_CostCenterChild, null));
		}

		public static CostCenter LoadOne(Int32 nID_CostCenter, Int32 nLevel, Int32 nID_CostCenterChild, SqlConnection oPrivateConnection)
		{
			CostCenter oCostCenter = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Hierarchy].[CostCenters]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_CostCenter]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_CostCenter));
			oSelect.Append(" AND ");
			oSelect.Append("[Level]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nLevel));
			oSelect.Append(" AND ");
			oSelect.Append("[ID_CostCenterChild]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_CostCenterChild));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oCostCenter = UTI_RowToCostCenter(oRow);
			}

			return (oCostCenter);
		}

		public static CostCenter TryLoadOne(Int32 nID_CostCenter, Int32 nLevel, Int32 nID_CostCenterChild)
		{
			return(TryLoadOne(nID_CostCenter, nLevel, nID_CostCenterChild, null));
		}

		public static CostCenter TryLoadOne(Int32 nID_CostCenter, Int32 nLevel, Int32 nID_CostCenterChild, SqlConnection oPrivateConnection)
		{
			CostCenter oCostCenter = null;

			oCostCenter = LoadOne(nID_CostCenter, nLevel, nID_CostCenterChild, null);

			if (oCostCenter == null)
			{
				return (new CostCenter());
			}
			else
			{
				return (oCostCenter);
			}
		}

		public static void InsertOne(CostCenter oCostCenter)
		{
			InsertOne(oCostCenter, null);
		}

		public static void InsertOne(CostCenter oCostCenter, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Hierarchy].[CostCenters] ");
			oInsert.Append("([ID_CostCenter], [Level], [ID_CostCenterChild])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oCostCenter.ID_CostCenter));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oCostCenter.Level));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oCostCenter.ID_CostCenterChild));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(CostCenter oCostCenter)
		{
			UpdateOne(oCostCenter, null);
		}

		public static void UpdateOne(CostCenter oCostCenter, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Hierarchy].[CostCenters] SET ");

			oUpdate.Append("[ID_CostCenter]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oCostCenter.ID_CostCenter));
			oUpdate.Append(", ");
			oUpdate.Append("[Level]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oCostCenter.Level));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_CostCenterChild]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oCostCenter.ID_CostCenterChild));

			oUpdate.Append(UTI_Where4One(oCostCenter));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(CostCenter oCostCenter)
		{
			DeleteOne(oCostCenter, null);
		}

		public static void DeleteOne(CostCenter oCostCenter, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Hierarchy].[CostCenters]");

			oDelete.Append(UTI_Where4One(oCostCenter));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(CostCenter oCostCenter)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_CostCenter]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oCostCenter.ID_CostCenter));
			oWhere.Append(" AND ");
			oWhere.Append("[Level]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oCostCenter.Level));
			oWhere.Append(" AND ");
			oWhere.Append("[ID_CostCenterChild]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oCostCenter.ID_CostCenterChild));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_CostCenter, Int32 nLevel, Int32 nID_CostCenterChild)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_CostCenter]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_CostCenter));
			oWhere.Append(" AND ");
			oWhere.Append("[Level]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nLevel));
			oWhere.Append(" AND ");
			oWhere.Append("[ID_CostCenterChild]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_CostCenterChild));

			return (oWhere.ToString());
		}

		public static CostCenter UTI_RowToCostCenter(DataRow oRow)
		{
			CostCenter oCostCenter = new CostCenter();

			oCostCenter.ID_CostCenter = ((Int32)(oRow["ID_CostCenter"]));
			oCostCenter.Level = ((Int32)(oRow["Level"]));
			oCostCenter.ID_CostCenterChild = ((Int32)(oRow["ID_CostCenterChild"]));

			return (oCostCenter);
		}
		#endregion
	}

}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Data.Maintenance
{
	/// <summary>
	/// Public SupplierType Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  03/09/2020  Created
	/// </remarks>
	public class SupplierTypes : EntitiesManagerBase
	{
		#region Public Properties
		public SupplierType this[int nIndex]
		{
			get { return ((SupplierType)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public SupplierType GetByKeys(Int32 nID_SupplierType)
		{
			foreach (SupplierType oSupplierType in this.m_aItems)
			{
				if (oSupplierType.ID_SupplierType == nID_SupplierType)
				{
					return (oSupplierType);
				}
			}

			return (null);
		}

		public SupplierType[] ToArray()
		{
			List<SupplierType> aRet = new List<SupplierType>();
			foreach (SupplierType oSupplierType in this.m_aItems)
			{
				aRet.Add(oSupplierType);
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
			SupplierType oSupplierType = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oSupplierType = UTI_RowToSupplierType(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oSupplierType);

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

			oDelete = new StringBuilder("DELETE FROM [Maintenance].[SupplierTypes]");

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
			oSelect = new StringBuilder("SELECT * FROM [Maintenance].[SupplierTypes]");

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

		public static SupplierType LoadOne(Int32 nID_SupplierType)
		{
			return(LoadOne(nID_SupplierType, null));
		}

		public static SupplierType LoadOne(Int32 nID_SupplierType, SqlConnection oPrivateConnection)
		{
			SupplierType oSupplierType = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Maintenance].[SupplierTypes]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_SupplierType]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_SupplierType));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oSupplierType = UTI_RowToSupplierType(oRow);
			}

			return (oSupplierType);
		}

		public static SupplierType TryLoadOne(Int32 nID_SupplierType)
		{
			return(TryLoadOne(nID_SupplierType, null));
		}

		public static SupplierType TryLoadOne(Int32 nID_SupplierType, SqlConnection oPrivateConnection)
		{
			SupplierType oSupplierType = null;

			oSupplierType = LoadOne(nID_SupplierType, null);

			if (oSupplierType == null)
			{
				return (new SupplierType());
			}
			else
			{
				return (oSupplierType);
			}
		}

		public static void InsertOne(SupplierType oSupplierType)
		{
			InsertOne(oSupplierType, null);
		}

		public static void InsertOne(SupplierType oSupplierType, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Maintenance].[SupplierTypes] ");
			oInsert.Append("([ID_SupplierType], [Name], [Description])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oSupplierType.ID_SupplierType));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oSupplierType.Name));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oSupplierType.Description));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(SupplierType oSupplierType)
		{
			UpdateOne(oSupplierType, null);
		}

		public static void UpdateOne(SupplierType oSupplierType, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Maintenance].[SupplierTypes] SET ");

			oUpdate.Append("[Name]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oSupplierType.Name));
			oUpdate.Append(", ");
			oUpdate.Append("[Description]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oSupplierType.Description));

			oUpdate.Append(UTI_Where4One(oSupplierType));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(SupplierType oSupplierType)
		{
			DeleteOne(oSupplierType, null);
		}

		public static void DeleteOne(SupplierType oSupplierType, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Maintenance].[SupplierTypes]");

			oDelete.Append(UTI_Where4One(oSupplierType));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(SupplierType oSupplierType)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_SupplierType]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oSupplierType.ID_SupplierType));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_SupplierType)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_SupplierType]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_SupplierType));

			return (oWhere.ToString());
		}

		public static SupplierType UTI_RowToSupplierType(DataRow oRow)
		{
			SupplierType oSupplierType = new SupplierType();

			oSupplierType.ID_SupplierType = ((Int32)(oRow["ID_SupplierType"]));
			oSupplierType.Name = ((String)(oRow["Name"])).Trim();
			oSupplierType.Description = ((String)(oRow["Description"])).Trim();

			return (oSupplierType);
		}
		#endregion
	}

}

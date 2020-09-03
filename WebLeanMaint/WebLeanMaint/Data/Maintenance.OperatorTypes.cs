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
	/// Public OperatorType Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  03/09/2020  Created
	/// </remarks>
	public class OperatorTypes : EntitiesManagerBase
	{
		#region Public Properties
		public OperatorType this[int nIndex]
		{
			get { return ((OperatorType)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public OperatorType GetByKeys(Int32 nID_OperatorType)
		{
			foreach (OperatorType oOperatorType in this.m_aItems)
			{
				if (oOperatorType.ID_OperatorType == nID_OperatorType)
				{
					return (oOperatorType);
				}
			}

			return (null);
		}

		public OperatorType[] ToArray()
		{
			List<OperatorType> aRet = new List<OperatorType>();
			foreach (OperatorType oOperatorType in this.m_aItems)
			{
				aRet.Add(oOperatorType);
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
			OperatorType oOperatorType = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oOperatorType = UTI_RowToOperatorType(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oOperatorType);

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

			oDelete = new StringBuilder("DELETE FROM [Maintenance].[OperatorTypes]");

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
			oSelect = new StringBuilder("SELECT * FROM [Maintenance].[OperatorTypes]");

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

		public static OperatorType LoadOne(Int32 nID_OperatorType)
		{
			return(LoadOne(nID_OperatorType, null));
		}

		public static OperatorType LoadOne(Int32 nID_OperatorType, SqlConnection oPrivateConnection)
		{
			OperatorType oOperatorType = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Maintenance].[OperatorTypes]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_OperatorType]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_OperatorType));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oOperatorType = UTI_RowToOperatorType(oRow);
			}

			return (oOperatorType);
		}

		public static OperatorType TryLoadOne(Int32 nID_OperatorType)
		{
			return(TryLoadOne(nID_OperatorType, null));
		}

		public static OperatorType TryLoadOne(Int32 nID_OperatorType, SqlConnection oPrivateConnection)
		{
			OperatorType oOperatorType = null;

			oOperatorType = LoadOne(nID_OperatorType, null);

			if (oOperatorType == null)
			{
				return (new OperatorType());
			}
			else
			{
				return (oOperatorType);
			}
		}

		public static void InsertOne(OperatorType oOperatorType)
		{
			InsertOne(oOperatorType, null);
		}

		public static void InsertOne(OperatorType oOperatorType, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Maintenance].[OperatorTypes] ");
			oInsert.Append("([ID_OperatorType], [Name], [Description])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOperatorType.ID_OperatorType));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOperatorType.Name));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oOperatorType.Description));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(OperatorType oOperatorType)
		{
			UpdateOne(oOperatorType, null);
		}

		public static void UpdateOne(OperatorType oOperatorType, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Maintenance].[OperatorTypes] SET ");

			oUpdate.Append("[Name]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOperatorType.Name));
			oUpdate.Append(", ");
			oUpdate.Append("[Description]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oOperatorType.Description));

			oUpdate.Append(UTI_Where4One(oOperatorType));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(OperatorType oOperatorType)
		{
			DeleteOne(oOperatorType, null);
		}

		public static void DeleteOne(OperatorType oOperatorType, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Maintenance].[OperatorTypes]");

			oDelete.Append(UTI_Where4One(oOperatorType));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(OperatorType oOperatorType)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_OperatorType]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oOperatorType.ID_OperatorType));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_OperatorType)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_OperatorType]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_OperatorType));

			return (oWhere.ToString());
		}

		public static OperatorType UTI_RowToOperatorType(DataRow oRow)
		{
			OperatorType oOperatorType = new OperatorType();

			oOperatorType.ID_OperatorType = ((Int32)(oRow["ID_OperatorType"]));
			oOperatorType.Name = ((String)(oRow["Name"])).Trim();
			oOperatorType.Description = ((String)(oRow["Description"])).Trim();

			return (oOperatorType);
		}
		#endregion
	}

}

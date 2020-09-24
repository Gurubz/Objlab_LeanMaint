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
	/// Public ObjStatuse Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  24/09/2020  Created
	/// </remarks>
	public partial class ObjStatuses : EntitiesManagerBase
	{
		#region Public Properties
		public ObjStatuse this[int nIndex]
		{
			get { return ((ObjStatuse)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public ObjStatuse GetByKeys(Int32 nID_ObjStatus)
		{
			foreach (ObjStatuse oObjStatuse in this.m_aItems)
			{
				if (oObjStatuse.ID_ObjStatus == nID_ObjStatus)
				{
					return (oObjStatuse);
				}
			}

			return (null);
		}

		public ObjStatuse[] ToArray()
		{
			List<ObjStatuse> aRet = new List<ObjStatuse>();
			foreach (ObjStatuse oObjStatuse in this.m_aItems)
			{
				aRet.Add(oObjStatuse);
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
			ObjStatuse oObjStatuse = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oObjStatuse = UTI_RowToObjStatuse(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oObjStatuse);

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

			oDelete = new StringBuilder("DELETE FROM [Config].[ObjStatuses]");

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
			oSelect = new StringBuilder("SELECT * FROM [Config].[ObjStatuses]");

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

		public static ObjStatuse LoadOne(Int32 nID_ObjStatus)
		{
			return(LoadOne(nID_ObjStatus, null));
		}

		public static ObjStatuse LoadOne(Int32 nID_ObjStatus, SqlConnection oPrivateConnection)
		{
			ObjStatuse oObjStatuse = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Config].[ObjStatuses]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_ObjStatus]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_ObjStatus));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oObjStatuse = UTI_RowToObjStatuse(oRow);
			}

			return (oObjStatuse);
		}

		public static ObjStatuse TryLoadOne(Int32 nID_ObjStatus)
		{
			return(TryLoadOne(nID_ObjStatus, null));
		}

		public static ObjStatuse TryLoadOne(Int32 nID_ObjStatus, SqlConnection oPrivateConnection)
		{
			ObjStatuse oObjStatuse = null;

			oObjStatuse = LoadOne(nID_ObjStatus, null);

			if (oObjStatuse == null)
			{
				return (new ObjStatuse());
			}
			else
			{
				return (oObjStatuse);
			}
		}

		public static void InsertOne(ObjStatuse oObjStatuse)
		{
			InsertOne(oObjStatuse, null);
		}

		public static void InsertOne(ObjStatuse oObjStatuse, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Config].[ObjStatuses] ");
			oInsert.Append("([ID_ObjStatus], [Name], [Description])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oObjStatuse.ID_ObjStatus));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oObjStatuse.Name));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oObjStatuse.Description));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(ObjStatuse oObjStatuse)
		{
			UpdateOne(oObjStatuse, null);
		}

		public static void UpdateOne(ObjStatuse oObjStatuse, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Config].[ObjStatuses] SET ");

			oUpdate.Append("[Name]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oObjStatuse.Name));
			oUpdate.Append(", ");
			oUpdate.Append("[Description]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oObjStatuse.Description));

			oUpdate.Append(UTI_Where4One(oObjStatuse));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(ObjStatuse oObjStatuse)
		{
			DeleteOne(oObjStatuse, null);
		}

		public static void DeleteOne(ObjStatuse oObjStatuse, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Config].[ObjStatuses]");

			oDelete.Append(UTI_Where4One(oObjStatuse));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(ObjStatuse oObjStatuse)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_ObjStatus]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oObjStatuse.ID_ObjStatus));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_ObjStatus)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_ObjStatus]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_ObjStatus));

			return (oWhere.ToString());
		}

		public static ObjStatuse UTI_RowToObjStatuse(DataRow oRow)
		{
			ObjStatuse oObjStatuse = new ObjStatuse();

			oObjStatuse.ID_ObjStatus = ((Int32)(oRow["ID_ObjStatus"]));
			oObjStatuse.Name = ((String)(oRow["Name"])).Trim();
			oObjStatuse.Description = ((String)(oRow["Description"])).Trim();

			return (oObjStatuse);
		}
		#endregion
	}

}

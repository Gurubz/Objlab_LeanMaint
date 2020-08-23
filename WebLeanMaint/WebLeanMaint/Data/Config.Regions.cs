using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Data.Config
{
	/// <summary>
	/// Public Region Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  23/08/2020  Created
	/// </remarks>
	public class Regions : EntitiesManagerBase
	{
		#region Public Properties
		public Region this[int nIndex]
		{
			get { return ((Region)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public Region GetByKeys(Int32 nID_Region)
		{
			foreach (Region oRegion in this.m_aItems)
			{
				if (oRegion.ID_Region == nID_Region)
				{
					return (oRegion);
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
			Region oRegion = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oRegion = UTI_RowToRegion(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oRegion);

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

			oDelete = new StringBuilder("DELETE FROM [Regions]");

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
			oSelect = new StringBuilder("SELECT * FROM [Regions]");

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

		public static Region LoadOne(Int32 nID_Region)
		{
			return(LoadOne(nID_Region, null));
		}

		public static Region LoadOne(Int32 nID_Region, SqlConnection oPrivateConnection)
		{
			Region oRegion = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Regions]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_Region]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Region));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oRegion = UTI_RowToRegion(oRow);
			}

			return (oRegion);
		}

		public static Region TryLoadOne(Int32 nID_Region)
		{
			return(TryLoadOne(nID_Region, null));
		}

		public static Region TryLoadOne(Int32 nID_Region, SqlConnection oPrivateConnection)
		{
			Region oRegion = null;

			oRegion = LoadOne(nID_Region, null);

			if (oRegion == null)
			{
				return (new Region());
			}
			else
			{
				return (oRegion);
			}
		}

		public static void InsertOne(Region oRegion)
		{
			InsertOne(oRegion, null);
		}

		public static void InsertOne(Region oRegion, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Regions] ");
			oInsert.Append("([ID_Region], [Name], [ID_Country])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oRegion.ID_Region));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oRegion.Name));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oRegion.ID_Country));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(Region oRegion)
		{
			UpdateOne(oRegion, null);
		}

		public static void UpdateOne(Region oRegion, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Regions] SET ");

			oUpdate.Append("[Name]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oRegion.Name));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_Country]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oRegion.ID_Country));

			oUpdate.Append(UTI_Where4One(oRegion));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(Region oRegion)
		{
			DeleteOne(oRegion, null);
		}

		public static void DeleteOne(Region oRegion, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Regions]");

			oDelete.Append(UTI_Where4One(oRegion));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(Region oRegion)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Region]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oRegion.ID_Region));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_Region)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Region]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Region));

			return (oWhere.ToString());
		}

		public static Region UTI_RowToRegion(DataRow oRow)
		{
			Region oRegion = new Region();

			oRegion.ID_Region = ((Int32)(oRow["ID_Region"]));
			oRegion.Name = ((String)(oRow["Name"])).Trim();
			oRegion.ID_Country = ((Int32)(oRow["ID_Country"]));

			return (oRegion);
		}
		#endregion
	}

}
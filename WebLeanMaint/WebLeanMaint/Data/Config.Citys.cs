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
	/// Public City Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  06/09/2020  Created
	/// </remarks>
	public class Citys : EntitiesManagerBase
	{
		#region Public Properties
		public City this[int nIndex]
		{
			get { return ((City)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public City GetByKeys(Int32 nID_City)
		{
			foreach (City oCity in this.m_aItems)
			{
				if (oCity.ID_City == nID_City)
				{
					return (oCity);
				}
			}

			return (null);
		}

		public City[] ToArray()
		{
			List<City> aRet = new List<City>();
			foreach (City oCity in this.m_aItems)
			{
				aRet.Add(oCity);
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
			City oCity = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oCity = UTI_RowToCity(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oCity);

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

			oDelete = new StringBuilder("DELETE FROM [Config].[Cities]");

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
			oSelect = new StringBuilder("SELECT * FROM [Config].[Cities]");

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

		public static City LoadOne(Int32 nID_City)
		{
			return(LoadOne(nID_City, null));
		}

		public static City LoadOne(Int32 nID_City, SqlConnection oPrivateConnection)
		{
			City oCity = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Config].[Cities]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_City]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_City));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oCity = UTI_RowToCity(oRow);
			}

			return (oCity);
		}

		public static City TryLoadOne(Int32 nID_City)
		{
			return(TryLoadOne(nID_City, null));
		}

		public static City TryLoadOne(Int32 nID_City, SqlConnection oPrivateConnection)
		{
			City oCity = null;

			oCity = LoadOne(nID_City, null);

			if (oCity == null)
			{
				return (new City());
			}
			else
			{
				return (oCity);
			}
		}

		public static void InsertOne(City oCity)
		{
			InsertOne(oCity, null);
		}

		public static void InsertOne(City oCity, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Config].[Cities] ");
			oInsert.Append("([ID_City], [ID_Region], [Name])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oCity.ID_City));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oCity.ID_Region));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oCity.Name));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(City oCity)
		{
			UpdateOne(oCity, null);
		}

		public static void UpdateOne(City oCity, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Config].[Cities] SET ");

			oUpdate.Append("[ID_Region]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oCity.ID_Region));
			oUpdate.Append(", ");
			oUpdate.Append("[Name]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oCity.Name));

			oUpdate.Append(UTI_Where4One(oCity));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(City oCity)
		{
			DeleteOne(oCity, null);
		}

		public static void DeleteOne(City oCity, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Config].[Cities]");

			oDelete.Append(UTI_Where4One(oCity));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(City oCity)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_City]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oCity.ID_City));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_City)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_City]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_City));

			return (oWhere.ToString());
		}

		public static City UTI_RowToCity(DataRow oRow)
		{
			City oCity = new City();

			oCity.ID_City = ((Int32)(oRow["ID_City"]));
			oCity.ID_Region = ((Int32)(oRow["ID_Region"]));
			oCity.Name = ((String)(oRow["Name"])).Trim();

			return (oCity);
		}
		#endregion
	}

}

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
	/// Public Country Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  27/08/2020  Created
	/// </remarks>
	public class Countrys : EntitiesManagerBase
	{
		#region Public Properties
		public Country this[int nIndex]
		{
			get { return ((Country)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public Country GetByKeys(Int32 nID_Country)
		{
			foreach (Country oCountry in this.m_aItems)
			{
				if (oCountry.ID_Country == nID_Country)
				{
					return (oCountry);
				}
			}

			return (null);
		}

		public Country[] ToArray()
		{
			List<Country> aRet = new List<Country>();
			foreach (Country oCountry in this.m_aItems)
			{
				aRet.Add(oCountry);
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
			Country oCountry = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oCountry = UTI_RowToCountry(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oCountry);

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

			oDelete = new StringBuilder("DELETE FROM [Countries]");

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
			oSelect = new StringBuilder("SELECT * FROM [Countries]");

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

		public static Country LoadOne(Int32 nID_Country)
		{
			return(LoadOne(nID_Country, null));
		}

		public static Country LoadOne(Int32 nID_Country, SqlConnection oPrivateConnection)
		{
			Country oCountry = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Countries]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_Country]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Country));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oCountry = UTI_RowToCountry(oRow);
			}

			return (oCountry);
		}

		public static Country TryLoadOne(Int32 nID_Country)
		{
			return(TryLoadOne(nID_Country, null));
		}

		public static Country TryLoadOne(Int32 nID_Country, SqlConnection oPrivateConnection)
		{
			Country oCountry = null;

			oCountry = LoadOne(nID_Country, null);

			if (oCountry == null)
			{
				return (new Country());
			}
			else
			{
				return (oCountry);
			}
		}

		public static void InsertOne(Country oCountry)
		{
			InsertOne(oCountry, null);
		}

		public static void InsertOne(Country oCountry, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Countries] ");
			oInsert.Append("([ID_Country], [Name], [Code], [Language])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oCountry.ID_Country));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oCountry.Name));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oCountry.Code));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oCountry.Language));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(Country oCountry)
		{
			UpdateOne(oCountry, null);
		}

		public static void UpdateOne(Country oCountry, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Countries] SET ");

			oUpdate.Append("[Name]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oCountry.Name));
			oUpdate.Append(", ");
			oUpdate.Append("[Code]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oCountry.Code));
			oUpdate.Append(", ");
			oUpdate.Append("[Language]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oCountry.Language));

			oUpdate.Append(UTI_Where4One(oCountry));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(Country oCountry)
		{
			DeleteOne(oCountry, null);
		}

		public static void DeleteOne(Country oCountry, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Countries]");

			oDelete.Append(UTI_Where4One(oCountry));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(Country oCountry)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Country]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oCountry.ID_Country));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_Country)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Country]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Country));

			return (oWhere.ToString());
		}

		public static Country UTI_RowToCountry(DataRow oRow)
		{
			Country oCountry = new Country();

			oCountry.ID_Country = ((Int32)(oRow["ID_Country"]));
			oCountry.Name = ((String)(oRow["Name"])).Trim();
			oCountry.Code = ((String)(oRow["Code"])).Trim();
			oCountry.Language = ((String)(oRow["Language"])).Trim();

			return (oCountry);
		}
		#endregion
	}

}

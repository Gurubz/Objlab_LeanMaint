using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Data.dbo
{
	/// <summary>
	/// Public AspNetUserClaim Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  03/09/2020  Created
	/// </remarks>
	public class AspNetUserClaims : EntitiesManagerBase
	{
		#region Public Properties
		public AspNetUserClaim this[int nIndex]
		{
			get { return ((AspNetUserClaim)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public AspNetUserClaim GetByKeys(Int32 nId)
		{
			foreach (AspNetUserClaim oAspNetUserClaim in this.m_aItems)
			{
				if (oAspNetUserClaim.Id == nId)
				{
					return (oAspNetUserClaim);
				}
			}

			return (null);
		}

		public AspNetUserClaim[] ToArray()
		{
			List<AspNetUserClaim> aRet = new List<AspNetUserClaim>();
			foreach (AspNetUserClaim oAspNetUserClaim in this.m_aItems)
			{
				aRet.Add(oAspNetUserClaim);
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
			AspNetUserClaim oAspNetUserClaim = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oAspNetUserClaim = UTI_RowToAspNetUserClaim(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oAspNetUserClaim);

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

			oDelete = new StringBuilder("DELETE FROM [dbo].[AspNetUserClaims]");

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
			oSelect = new StringBuilder("SELECT * FROM [dbo].[AspNetUserClaims]");

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

		public static AspNetUserClaim LoadOne(Int32 nId)
		{
			return(LoadOne(nId, null));
		}

		public static AspNetUserClaim LoadOne(Int32 nId, SqlConnection oPrivateConnection)
		{
			AspNetUserClaim oAspNetUserClaim = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [dbo].[AspNetUserClaims]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[Id]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nId));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oAspNetUserClaim = UTI_RowToAspNetUserClaim(oRow);
			}

			return (oAspNetUserClaim);
		}

		public static AspNetUserClaim TryLoadOne(Int32 nId)
		{
			return(TryLoadOne(nId, null));
		}

		public static AspNetUserClaim TryLoadOne(Int32 nId, SqlConnection oPrivateConnection)
		{
			AspNetUserClaim oAspNetUserClaim = null;

			oAspNetUserClaim = LoadOne(nId, null);

			if (oAspNetUserClaim == null)
			{
				return (new AspNetUserClaim());
			}
			else
			{
				return (oAspNetUserClaim);
			}
		}

		public static void InsertOne(AspNetUserClaim oAspNetUserClaim)
		{
			InsertOne(oAspNetUserClaim, null);
		}

		public static void InsertOne(AspNetUserClaim oAspNetUserClaim, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [dbo].[AspNetUserClaims] ");
			oInsert.Append("([UserId], [ClaimType], [ClaimValue])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUserClaim.UserId));
			oInsert.Append(", ");
			if (oAspNetUserClaim.ClaimType_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUserClaim.ClaimType));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oAspNetUserClaim.ClaimValue_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUserClaim.ClaimValue));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(")");

			Object oRet;
			oRet = EntitiesManagerBase.DAT_ExecuteScalar(oInsert.ToString(), "\nSELECT @@IDENTITY AS ID", oPrivateConnection);
			oAspNetUserClaim.Id = Convert.ToInt32(oRet);
		}

		public static void UpdateOne(AspNetUserClaim oAspNetUserClaim)
		{
			UpdateOne(oAspNetUserClaim, null);
		}

		public static void UpdateOne(AspNetUserClaim oAspNetUserClaim, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [dbo].[AspNetUserClaims] SET ");

			oUpdate.Append("[UserId]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUserClaim.UserId));
			oUpdate.Append(", ");
			oUpdate.Append("[ClaimType]=");
			if (oAspNetUserClaim.ClaimType_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUserClaim.ClaimType));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[ClaimValue]=");
			if (oAspNetUserClaim.ClaimValue_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUserClaim.ClaimValue));
			} else {
			oUpdate.Append("NULL");
			}

			oUpdate.Append(UTI_Where4One(oAspNetUserClaim));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(AspNetUserClaim oAspNetUserClaim)
		{
			DeleteOne(oAspNetUserClaim, null);
		}

		public static void DeleteOne(AspNetUserClaim oAspNetUserClaim, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [dbo].[AspNetUserClaims]");

			oDelete.Append(UTI_Where4One(oAspNetUserClaim));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(AspNetUserClaim oAspNetUserClaim)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[Id]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUserClaim.Id));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nId)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[Id]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nId));

			return (oWhere.ToString());
		}

		public static AspNetUserClaim UTI_RowToAspNetUserClaim(DataRow oRow)
		{
			AspNetUserClaim oAspNetUserClaim = new AspNetUserClaim();

			oAspNetUserClaim.Id = ((Int32)(oRow["Id"]));
			oAspNetUserClaim.UserId = ((String)(oRow["UserId"])).Trim();
			if (!(oRow["ClaimType"] is DBNull)) {
			  oAspNetUserClaim.ClaimType = ((String)(oRow["ClaimType"])).Trim();
			  oAspNetUserClaim.ClaimType_HasValue = true;
			} else {
			  oAspNetUserClaim.ClaimType_HasValue = false;
			}
			if (!(oRow["ClaimValue"] is DBNull)) {
			  oAspNetUserClaim.ClaimValue = ((String)(oRow["ClaimValue"])).Trim();
			  oAspNetUserClaim.ClaimValue_HasValue = true;
			} else {
			  oAspNetUserClaim.ClaimValue_HasValue = false;
			}

			return (oAspNetUserClaim);
		}
		#endregion
	}

}

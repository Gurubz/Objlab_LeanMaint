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
	/// Public AspNetUserLogin Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  03/09/2020  Created
	/// </remarks>
	public class AspNetUserLogins : EntitiesManagerBase
	{
		#region Public Properties
		public AspNetUserLogin this[int nIndex]
		{
			get { return ((AspNetUserLogin)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public AspNetUserLogin GetByKeys(String sLoginProvider, String sProviderKey, String sUserId)
		{
			foreach (AspNetUserLogin oAspNetUserLogin in this.m_aItems)
			{
				if (oAspNetUserLogin.LoginProvider == sLoginProvider && oAspNetUserLogin.ProviderKey == sProviderKey && oAspNetUserLogin.UserId == sUserId)
				{
					return (oAspNetUserLogin);
				}
			}

			return (null);
		}

		public AspNetUserLogin[] ToArray()
		{
			List<AspNetUserLogin> aRet = new List<AspNetUserLogin>();
			foreach (AspNetUserLogin oAspNetUserLogin in this.m_aItems)
			{
				aRet.Add(oAspNetUserLogin);
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
			AspNetUserLogin oAspNetUserLogin = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oAspNetUserLogin = UTI_RowToAspNetUserLogin(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oAspNetUserLogin);

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

			oDelete = new StringBuilder("DELETE FROM [dbo].[AspNetUserLogins]");

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
			oSelect = new StringBuilder("SELECT * FROM [dbo].[AspNetUserLogins]");

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

		public static AspNetUserLogin LoadOne(String sLoginProvider, String sProviderKey, String sUserId)
		{
			return(LoadOne(sLoginProvider, sProviderKey, sUserId, null));
		}

		public static AspNetUserLogin LoadOne(String sLoginProvider, String sProviderKey, String sUserId, SqlConnection oPrivateConnection)
		{
			AspNetUserLogin oAspNetUserLogin = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [dbo].[AspNetUserLogins]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[LoginProvider]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(sLoginProvider));
			oSelect.Append(" AND ");
			oSelect.Append("[ProviderKey]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(sProviderKey));
			oSelect.Append(" AND ");
			oSelect.Append("[UserId]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(sUserId));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oAspNetUserLogin = UTI_RowToAspNetUserLogin(oRow);
			}

			return (oAspNetUserLogin);
		}

		public static AspNetUserLogin TryLoadOne(String sLoginProvider, String sProviderKey, String sUserId)
		{
			return(TryLoadOne(sLoginProvider, sProviderKey, sUserId, null));
		}

		public static AspNetUserLogin TryLoadOne(String sLoginProvider, String sProviderKey, String sUserId, SqlConnection oPrivateConnection)
		{
			AspNetUserLogin oAspNetUserLogin = null;

			oAspNetUserLogin = LoadOne(sLoginProvider, sProviderKey, sUserId, null);

			if (oAspNetUserLogin == null)
			{
				return (new AspNetUserLogin());
			}
			else
			{
				return (oAspNetUserLogin);
			}
		}

		public static void InsertOne(AspNetUserLogin oAspNetUserLogin)
		{
			InsertOne(oAspNetUserLogin, null);
		}

		public static void InsertOne(AspNetUserLogin oAspNetUserLogin, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [dbo].[AspNetUserLogins] ");
			oInsert.Append("([LoginProvider], [ProviderKey], [UserId])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUserLogin.LoginProvider));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUserLogin.ProviderKey));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUserLogin.UserId));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(AspNetUserLogin oAspNetUserLogin)
		{
			UpdateOne(oAspNetUserLogin, null);
		}

		public static void UpdateOne(AspNetUserLogin oAspNetUserLogin, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [dbo].[AspNetUserLogins] SET ");


			oUpdate.Append(UTI_Where4One(oAspNetUserLogin));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(AspNetUserLogin oAspNetUserLogin)
		{
			DeleteOne(oAspNetUserLogin, null);
		}

		public static void DeleteOne(AspNetUserLogin oAspNetUserLogin, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [dbo].[AspNetUserLogins]");

			oDelete.Append(UTI_Where4One(oAspNetUserLogin));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(AspNetUserLogin oAspNetUserLogin)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[LoginProvider]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUserLogin.LoginProvider));
			oWhere.Append(" AND ");
			oWhere.Append("[ProviderKey]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUserLogin.ProviderKey));
			oWhere.Append(" AND ");
			oWhere.Append("[UserId]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUserLogin.UserId));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(String sLoginProvider, String sProviderKey, String sUserId)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[LoginProvider]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(sLoginProvider));
			oWhere.Append(" AND ");
			oWhere.Append("[ProviderKey]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(sProviderKey));
			oWhere.Append(" AND ");
			oWhere.Append("[UserId]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(sUserId));

			return (oWhere.ToString());
		}

		public static AspNetUserLogin UTI_RowToAspNetUserLogin(DataRow oRow)
		{
			AspNetUserLogin oAspNetUserLogin = new AspNetUserLogin();

			oAspNetUserLogin.LoginProvider = ((String)(oRow["LoginProvider"])).Trim();
			oAspNetUserLogin.ProviderKey = ((String)(oRow["ProviderKey"])).Trim();
			oAspNetUserLogin.UserId = ((String)(oRow["UserId"])).Trim();

			return (oAspNetUserLogin);
		}
		#endregion
	}

}

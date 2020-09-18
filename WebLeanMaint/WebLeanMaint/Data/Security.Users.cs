using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Data.Security
{
	/// <summary>
	/// Public User Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  18/09/2020  Created
	/// </remarks>
	public class Users : EntitiesManagerBase
	{
		#region Public Properties
		public User this[int nIndex]
		{
			get { return ((User)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public User GetByKeys(Int32 nID_User)
		{
			foreach (User oUser in this.m_aItems)
			{
				if (oUser.ID_User == nID_User)
				{
					return (oUser);
				}
			}

			return (null);
		}

		public User[] ToArray()
		{
			List<User> aRet = new List<User>();
			foreach (User oUser in this.m_aItems)
			{
				aRet.Add(oUser);
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
			User oUser = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oUser = UTI_RowToUser(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oUser);

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

			oDelete = new StringBuilder("DELETE FROM [Security].[Users]");

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
			oSelect = new StringBuilder("SELECT * FROM [Security].[Users]");

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

		public static User LoadOne(Int32 nID_User)
		{
			return(LoadOne(nID_User, null));
		}

		public static User LoadOne(Int32 nID_User, SqlConnection oPrivateConnection)
		{
			User oUser = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Security].[Users]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_User]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_User));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oUser = UTI_RowToUser(oRow);
			}

			return (oUser);
		}

		public static User TryLoadOne(Int32 nID_User)
		{
			return(TryLoadOne(nID_User, null));
		}

		public static User TryLoadOne(Int32 nID_User, SqlConnection oPrivateConnection)
		{
			User oUser = null;

			oUser = LoadOne(nID_User, null);

			if (oUser == null)
			{
				return (new User());
			}
			else
			{
				return (oUser);
			}
		}

		public static void InsertOne(User oUser)
		{
			InsertOne(oUser, null);
		}

		public static void InsertOne(User oUser, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Security].[Users] ");
			oInsert.Append("([Username], [Password], [Seed], [ID_UserType], [EMail], [Mobile], [ID_ObjStatus])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oUser.Username));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oUser.Password));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oUser.Seed));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oUser.ID_UserType));
			oInsert.Append(", ");
			if (oUser.EMail_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oUser.EMail));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oUser.Mobile_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oUser.Mobile));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oUser.ID_ObjStatus));
			oInsert.Append(")");

			Object oRet;
			oRet = EntitiesManagerBase.DAT_ExecuteScalar(oInsert.ToString(), "\nSELECT @@IDENTITY AS ID", oPrivateConnection);
			oUser.ID_User = Convert.ToInt32(oRet);
		}

		public static void UpdateOne(User oUser)
		{
			UpdateOne(oUser, null);
		}

		public static void UpdateOne(User oUser, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Security].[Users] SET ");

			oUpdate.Append("[Username]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oUser.Username));
			oUpdate.Append(", ");
			oUpdate.Append("[Password]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oUser.Password));
			oUpdate.Append(", ");
			oUpdate.Append("[Seed]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oUser.Seed));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_UserType]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oUser.ID_UserType));
			oUpdate.Append(", ");
			oUpdate.Append("[EMail]=");
			if (oUser.EMail_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oUser.EMail));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[Mobile]=");
			if (oUser.Mobile_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oUser.Mobile));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[ID_ObjStatus]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oUser.ID_ObjStatus));

			oUpdate.Append(UTI_Where4One(oUser));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(User oUser)
		{
			DeleteOne(oUser, null);
		}

		public static void DeleteOne(User oUser, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Security].[Users]");

			oDelete.Append(UTI_Where4One(oUser));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(User oUser)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_User]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oUser.ID_User));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_User)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_User]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_User));

			return (oWhere.ToString());
		}

		public static User UTI_RowToUser(DataRow oRow)
		{
			User oUser = new User();

			oUser.ID_User = ((Int32)(oRow["ID_User"]));
			oUser.Username = ((String)(oRow["Username"])).Trim();
			oUser.Password = ((String)(oRow["Password"])).Trim();
			oUser.Seed = ((Int32)(oRow["Seed"]));
			oUser.ID_UserType = ((Int32)(oRow["ID_UserType"]));
			if (!(oRow["EMail"] is DBNull)) {
			  oUser.EMail = ((String)(oRow["EMail"])).Trim();
			  oUser.EMail_HasValue = true;
			} else {
			  oUser.EMail_HasValue = false;
			}
			if (!(oRow["Mobile"] is DBNull)) {
			  oUser.Mobile = ((String)(oRow["Mobile"])).Trim();
			  oUser.Mobile_HasValue = true;
			} else {
			  oUser.Mobile_HasValue = false;
			}
			oUser.ID_ObjStatus = ((Int32)(oRow["ID_ObjStatus"]));

			return (oUser);
		}
		#endregion
	}

}

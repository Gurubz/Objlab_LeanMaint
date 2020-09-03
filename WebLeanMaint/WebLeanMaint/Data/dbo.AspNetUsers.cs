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
	/// Public AspNetUser Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  03/09/2020  Created
	/// </remarks>
	public class AspNetUsers : EntitiesManagerBase
	{
		#region Public Properties
		public AspNetUser this[int nIndex]
		{
			get { return ((AspNetUser)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public AspNetUser GetByKeys(String sId)
		{
			foreach (AspNetUser oAspNetUser in this.m_aItems)
			{
				if (oAspNetUser.Id == sId)
				{
					return (oAspNetUser);
				}
			}

			return (null);
		}

		public AspNetUser[] ToArray()
		{
			List<AspNetUser> aRet = new List<AspNetUser>();
			foreach (AspNetUser oAspNetUser in this.m_aItems)
			{
				aRet.Add(oAspNetUser);
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
			AspNetUser oAspNetUser = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oAspNetUser = UTI_RowToAspNetUser(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oAspNetUser);

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

			oDelete = new StringBuilder("DELETE FROM [dbo].[AspNetUsers]");

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
			oSelect = new StringBuilder("SELECT * FROM [dbo].[AspNetUsers]");

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

		public static AspNetUser LoadOne(String sId)
		{
			return(LoadOne(sId, null));
		}

		public static AspNetUser LoadOne(String sId, SqlConnection oPrivateConnection)
		{
			AspNetUser oAspNetUser = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [dbo].[AspNetUsers]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[Id]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(sId));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oAspNetUser = UTI_RowToAspNetUser(oRow);
			}

			return (oAspNetUser);
		}

		public static AspNetUser TryLoadOne(String sId)
		{
			return(TryLoadOne(sId, null));
		}

		public static AspNetUser TryLoadOne(String sId, SqlConnection oPrivateConnection)
		{
			AspNetUser oAspNetUser = null;

			oAspNetUser = LoadOne(sId, null);

			if (oAspNetUser == null)
			{
				return (new AspNetUser());
			}
			else
			{
				return (oAspNetUser);
			}
		}

		public static void InsertOne(AspNetUser oAspNetUser)
		{
			InsertOne(oAspNetUser, null);
		}

		public static void InsertOne(AspNetUser oAspNetUser, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [dbo].[AspNetUsers] ");
			oInsert.Append("([Id], [Name], [ContactNumber], [AccountType], [seed], [ObjectStaus], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUser.Id));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUser.Name));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUser.ContactNumber));
			oInsert.Append(", ");
			if (oAspNetUser.AccountType_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUser.AccountType));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUser.seed));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUser.ObjectStaus));
			oInsert.Append(", ");
			if (oAspNetUser.Email_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUser.Email));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUser.EmailConfirmed));
			oInsert.Append(", ");
			if (oAspNetUser.PasswordHash_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUser.PasswordHash));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oAspNetUser.SecurityStamp_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUser.SecurityStamp));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			if (oAspNetUser.PhoneNumber_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUser.PhoneNumber));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUser.PhoneNumberConfirmed));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUser.TwoFactorEnabled));
			oInsert.Append(", ");
			if (oAspNetUser.LockoutEndDateUtc_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUser.LockoutEndDateUtc));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUser.LockoutEnabled));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUser.AccessFailedCount));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUser.UserName));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(AspNetUser oAspNetUser)
		{
			UpdateOne(oAspNetUser, null);
		}

		public static void UpdateOne(AspNetUser oAspNetUser, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [dbo].[AspNetUsers] SET ");

			oUpdate.Append("[Name]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUser.Name));
			oUpdate.Append(", ");
			oUpdate.Append("[ContactNumber]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUser.ContactNumber));
			oUpdate.Append(", ");
			oUpdate.Append("[AccountType]=");
			if (oAspNetUser.AccountType_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUser.AccountType));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[seed]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUser.seed));
			oUpdate.Append(", ");
			oUpdate.Append("[ObjectStaus]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUser.ObjectStaus));
			oUpdate.Append(", ");
			oUpdate.Append("[Email]=");
			if (oAspNetUser.Email_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUser.Email));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[EmailConfirmed]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUser.EmailConfirmed));
			oUpdate.Append(", ");
			oUpdate.Append("[PasswordHash]=");
			if (oAspNetUser.PasswordHash_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUser.PasswordHash));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[SecurityStamp]=");
			if (oAspNetUser.SecurityStamp_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUser.SecurityStamp));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[PhoneNumber]=");
			if (oAspNetUser.PhoneNumber_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUser.PhoneNumber));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[PhoneNumberConfirmed]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUser.PhoneNumberConfirmed));
			oUpdate.Append(", ");
			oUpdate.Append("[TwoFactorEnabled]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUser.TwoFactorEnabled));
			oUpdate.Append(", ");
			oUpdate.Append("[LockoutEndDateUtc]=");
			if (oAspNetUser.LockoutEndDateUtc_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUser.LockoutEndDateUtc));
			} else {
			oUpdate.Append("NULL");
			}
			oUpdate.Append(", ");
			oUpdate.Append("[LockoutEnabled]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUser.LockoutEnabled));
			oUpdate.Append(", ");
			oUpdate.Append("[AccessFailedCount]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUser.AccessFailedCount));
			oUpdate.Append(", ");
			oUpdate.Append("[UserName]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUser.UserName));

			oUpdate.Append(UTI_Where4One(oAspNetUser));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(AspNetUser oAspNetUser)
		{
			DeleteOne(oAspNetUser, null);
		}

		public static void DeleteOne(AspNetUser oAspNetUser, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [dbo].[AspNetUsers]");

			oDelete.Append(UTI_Where4One(oAspNetUser));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(AspNetUser oAspNetUser)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[Id]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUser.Id));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(String sId)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[Id]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(sId));

			return (oWhere.ToString());
		}

		public static AspNetUser UTI_RowToAspNetUser(DataRow oRow)
		{
			AspNetUser oAspNetUser = new AspNetUser();

			oAspNetUser.Id = ((String)(oRow["Id"])).Trim();
			oAspNetUser.Name = ((String)(oRow["Name"])).Trim();
			oAspNetUser.ContactNumber = ((String)(oRow["ContactNumber"])).Trim();
			if (!(oRow["AccountType"] is DBNull)) {
			  oAspNetUser.AccountType = ((String)(oRow["AccountType"])).Trim();
			  oAspNetUser.AccountType_HasValue = true;
			} else {
			  oAspNetUser.AccountType_HasValue = false;
			}
			oAspNetUser.seed = ((String)(oRow["seed"])).Trim();
			oAspNetUser.ObjectStaus = ((String)(oRow["ObjectStaus"])).Trim();
			if (!(oRow["Email"] is DBNull)) {
			  oAspNetUser.Email = ((String)(oRow["Email"])).Trim();
			  oAspNetUser.Email_HasValue = true;
			} else {
			  oAspNetUser.Email_HasValue = false;
			}
			oAspNetUser.EmailConfirmed = ((Boolean)(oRow["EmailConfirmed"]));
			if (!(oRow["PasswordHash"] is DBNull)) {
			  oAspNetUser.PasswordHash = ((String)(oRow["PasswordHash"])).Trim();
			  oAspNetUser.PasswordHash_HasValue = true;
			} else {
			  oAspNetUser.PasswordHash_HasValue = false;
			}
			if (!(oRow["SecurityStamp"] is DBNull)) {
			  oAspNetUser.SecurityStamp = ((String)(oRow["SecurityStamp"])).Trim();
			  oAspNetUser.SecurityStamp_HasValue = true;
			} else {
			  oAspNetUser.SecurityStamp_HasValue = false;
			}
			if (!(oRow["PhoneNumber"] is DBNull)) {
			  oAspNetUser.PhoneNumber = ((String)(oRow["PhoneNumber"])).Trim();
			  oAspNetUser.PhoneNumber_HasValue = true;
			} else {
			  oAspNetUser.PhoneNumber_HasValue = false;
			}
			oAspNetUser.PhoneNumberConfirmed = ((Boolean)(oRow["PhoneNumberConfirmed"]));
			oAspNetUser.TwoFactorEnabled = ((Boolean)(oRow["TwoFactorEnabled"]));
			if (!(oRow["LockoutEndDateUtc"] is DBNull)) {
			  oAspNetUser.LockoutEndDateUtc = ((DateTime)(oRow["LockoutEndDateUtc"]));
			  oAspNetUser.LockoutEndDateUtc_HasValue = true;
			} else {
			  oAspNetUser.LockoutEndDateUtc_HasValue = false;
			}
			oAspNetUser.LockoutEnabled = ((Boolean)(oRow["LockoutEnabled"]));
			oAspNetUser.AccessFailedCount = ((Int32)(oRow["AccessFailedCount"]));
			oAspNetUser.UserName = ((String)(oRow["UserName"])).Trim();

			return (oAspNetUser);
		}
		#endregion
	}

}

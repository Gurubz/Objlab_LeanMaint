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
	/// Public UserRegistrationData Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  03/09/2020  Created
	/// </remarks>
	public class UserRegistrationDatas : EntitiesManagerBase
	{
		#region Public Properties
		public UserRegistrationData this[int nIndex]
		{
			get { return ((UserRegistrationData)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public UserRegistrationData GetByKeys(Int32 nId)
		{
			foreach (UserRegistrationData oUserRegistrationData in this.m_aItems)
			{
				if (oUserRegistrationData.Id == nId)
				{
					return (oUserRegistrationData);
				}
			}

			return (null);
		}

		public UserRegistrationData[] ToArray()
		{
			List<UserRegistrationData> aRet = new List<UserRegistrationData>();
			foreach (UserRegistrationData oUserRegistrationData in this.m_aItems)
			{
				aRet.Add(oUserRegistrationData);
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
			UserRegistrationData oUserRegistrationData = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oUserRegistrationData = UTI_RowToUserRegistrationData(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oUserRegistrationData);

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

			oDelete = new StringBuilder("DELETE FROM [dbo].[UserRegistrationDatas]");

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
			oSelect = new StringBuilder("SELECT * FROM [dbo].[UserRegistrationDatas]");

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

		public static UserRegistrationData LoadOne(Int32 nId)
		{
			return(LoadOne(nId, null));
		}

		public static UserRegistrationData LoadOne(Int32 nId, SqlConnection oPrivateConnection)
		{
			UserRegistrationData oUserRegistrationData = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [dbo].[UserRegistrationDatas]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[Id]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nId));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oUserRegistrationData = UTI_RowToUserRegistrationData(oRow);
			}

			return (oUserRegistrationData);
		}

		public static UserRegistrationData TryLoadOne(Int32 nId)
		{
			return(TryLoadOne(nId, null));
		}

		public static UserRegistrationData TryLoadOne(Int32 nId, SqlConnection oPrivateConnection)
		{
			UserRegistrationData oUserRegistrationData = null;

			oUserRegistrationData = LoadOne(nId, null);

			if (oUserRegistrationData == null)
			{
				return (new UserRegistrationData());
			}
			else
			{
				return (oUserRegistrationData);
			}
		}

		public static void InsertOne(UserRegistrationData oUserRegistrationData)
		{
			InsertOne(oUserRegistrationData, null);
		}

		public static void InsertOne(UserRegistrationData oUserRegistrationData, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [dbo].[UserRegistrationDatas] ");
			oInsert.Append("([Name], [Email], [ContactNumber], [AccountTypes], [seed], [ObjectStaus])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oUserRegistrationData.Name));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oUserRegistrationData.Email));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oUserRegistrationData.ContactNumber));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oUserRegistrationData.AccountTypes));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oUserRegistrationData.seed));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oUserRegistrationData.ObjectStaus));
			oInsert.Append(")");

			Object oRet;
			oRet = EntitiesManagerBase.DAT_ExecuteScalar(oInsert.ToString(), "\nSELECT @@IDENTITY AS ID", oPrivateConnection);
			oUserRegistrationData.Id = Convert.ToInt32(oRet);
		}

		public static void UpdateOne(UserRegistrationData oUserRegistrationData)
		{
			UpdateOne(oUserRegistrationData, null);
		}

		public static void UpdateOne(UserRegistrationData oUserRegistrationData, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [dbo].[UserRegistrationDatas] SET ");

			oUpdate.Append("[Name]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oUserRegistrationData.Name));
			oUpdate.Append(", ");
			oUpdate.Append("[Email]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oUserRegistrationData.Email));
			oUpdate.Append(", ");
			oUpdate.Append("[ContactNumber]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oUserRegistrationData.ContactNumber));
			oUpdate.Append(", ");
			oUpdate.Append("[AccountTypes]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oUserRegistrationData.AccountTypes));
			oUpdate.Append(", ");
			oUpdate.Append("[seed]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oUserRegistrationData.seed));
			oUpdate.Append(", ");
			oUpdate.Append("[ObjectStaus]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oUserRegistrationData.ObjectStaus));

			oUpdate.Append(UTI_Where4One(oUserRegistrationData));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(UserRegistrationData oUserRegistrationData)
		{
			DeleteOne(oUserRegistrationData, null);
		}

		public static void DeleteOne(UserRegistrationData oUserRegistrationData, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [dbo].[UserRegistrationDatas]");

			oDelete.Append(UTI_Where4One(oUserRegistrationData));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(UserRegistrationData oUserRegistrationData)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[Id]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oUserRegistrationData.Id));

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

		public static UserRegistrationData UTI_RowToUserRegistrationData(DataRow oRow)
		{
			UserRegistrationData oUserRegistrationData = new UserRegistrationData();

			oUserRegistrationData.Id = ((Int32)(oRow["Id"]));
			oUserRegistrationData.Name = ((String)(oRow["Name"])).Trim();
			oUserRegistrationData.Email = ((String)(oRow["Email"])).Trim();
			oUserRegistrationData.ContactNumber = ((String)(oRow["ContactNumber"])).Trim();
			oUserRegistrationData.AccountTypes = ((Int32)(oRow["AccountTypes"]));
			oUserRegistrationData.seed = ((String)(oRow["seed"])).Trim();
			oUserRegistrationData.ObjectStaus = ((String)(oRow["ObjectStaus"])).Trim();

			return (oUserRegistrationData);
		}
		#endregion
	}

}

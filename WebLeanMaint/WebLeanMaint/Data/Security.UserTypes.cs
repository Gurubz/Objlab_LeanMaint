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
	/// Public UserType Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  27/09/2020  Created
	/// </remarks>
	public partial class UserTypes : EntitiesManagerBase
	{
		#region Public Properties
		public UserType this[int nIndex]
		{
			get { return ((UserType)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public UserType GetByKeys(Int32 nID_UserType)
		{
			foreach (UserType oUserType in this.m_aItems)
			{
				if (oUserType.ID_UserType == nID_UserType)
				{
					return (oUserType);
				}
			}

			return (null);
		}

		public UserType[] ToArray()
		{
			List<UserType> aRet = new List<UserType>();
			foreach (UserType oUserType in this.m_aItems)
			{
				aRet.Add(oUserType);
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
			UserType oUserType = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oUserType = UTI_RowToUserType(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oUserType);

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

			oDelete = new StringBuilder("DELETE FROM [Security].[UserTypes]");

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
		public static DataSet LoadFast(string sWhere, string sOrderBy = "", SqlConnection oPrivateConnection = null)
		{
			StringBuilder oSelect = null;
			DataSet oRet = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Security].[UserTypes]");

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

		public static UserType LoadOne(Int32 nID_UserType, SqlConnection oPrivateConnection = null)
		{
			UserType oUserType = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Security].[UserTypes]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_UserType]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_UserType));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oUserType = UTI_RowToUserType(oRow);
			}

			return (oUserType);
		}

		public static UserType TryLoadOne(Int32 nID_UserType, SqlConnection oPrivateConnection = null)
		{
			UserType oUserType = null;

			oUserType = LoadOne(nID_UserType, null);

			if (oUserType == null)
			{
				return (new UserType());
			}
			else
			{
				return (oUserType);
			}
		}

		public static void InsertOne(UserType oUserType, SqlConnection oPrivateConnection = null)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Security].[UserTypes] ");
			oInsert.Append("([ID_UserType], [Name], [Description])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oUserType.ID_UserType));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oUserType.Name));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oUserType.Description));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(UserType oUserType, SqlConnection oPrivateConnection = null)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Security].[UserTypes] SET ");

			oUpdate.Append("[Name]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oUserType.Name));
			oUpdate.Append(", ");
			oUpdate.Append("[Description]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oUserType.Description));

			oUpdate.Append(UTI_Where4One(oUserType));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(UserType oUserType, SqlConnection oPrivateConnection = null)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Security].[UserTypes]");

			oDelete.Append(UTI_Where4One(oUserType));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static void DeleteOne(Int32 nID_UserType, SqlConnection oPrivateConnection=null)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Security].[UserTypes]");

			oDelete.Append(UTI_Where4One(nID_UserType));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(UserType oUserType)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_UserType]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oUserType.ID_UserType));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_UserType)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_UserType]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_UserType));

			return (oWhere.ToString());
		}

		public static UserType UTI_RowToUserType(DataRow oRow)
		{
			UserType oUserType = new UserType();

			oUserType.ID_UserType = ((Int32)(oRow["ID_UserType"]));
			oUserType.Name = ((String)(oRow["Name"])).Trim();
			oUserType.Description = ((String)(oRow["Description"])).Trim();

			return (oUserType);
		}
		#endregion
	}

}

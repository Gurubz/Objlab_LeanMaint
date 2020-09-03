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
	/// Public AspNetUserRole Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  03/09/2020  Created
	/// </remarks>
	public class AspNetUserRoles : EntitiesManagerBase
	{
		#region Public Properties
		public AspNetUserRole this[int nIndex]
		{
			get { return ((AspNetUserRole)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public AspNetUserRole GetByKeys(String sUserId, String sRoleId)
		{
			foreach (AspNetUserRole oAspNetUserRole in this.m_aItems)
			{
				if (oAspNetUserRole.UserId == sUserId && oAspNetUserRole.RoleId == sRoleId)
				{
					return (oAspNetUserRole);
				}
			}

			return (null);
		}

		public AspNetUserRole[] ToArray()
		{
			List<AspNetUserRole> aRet = new List<AspNetUserRole>();
			foreach (AspNetUserRole oAspNetUserRole in this.m_aItems)
			{
				aRet.Add(oAspNetUserRole);
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
			AspNetUserRole oAspNetUserRole = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oAspNetUserRole = UTI_RowToAspNetUserRole(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oAspNetUserRole);

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

			oDelete = new StringBuilder("DELETE FROM [dbo].[AspNetUserRoles]");

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
			oSelect = new StringBuilder("SELECT * FROM [dbo].[AspNetUserRoles]");

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

		public static AspNetUserRole LoadOne(String sUserId, String sRoleId)
		{
			return(LoadOne(sUserId, sRoleId, null));
		}

		public static AspNetUserRole LoadOne(String sUserId, String sRoleId, SqlConnection oPrivateConnection)
		{
			AspNetUserRole oAspNetUserRole = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [dbo].[AspNetUserRoles]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[UserId]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(sUserId));
			oSelect.Append(" AND ");
			oSelect.Append("[RoleId]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(sRoleId));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oAspNetUserRole = UTI_RowToAspNetUserRole(oRow);
			}

			return (oAspNetUserRole);
		}

		public static AspNetUserRole TryLoadOne(String sUserId, String sRoleId)
		{
			return(TryLoadOne(sUserId, sRoleId, null));
		}

		public static AspNetUserRole TryLoadOne(String sUserId, String sRoleId, SqlConnection oPrivateConnection)
		{
			AspNetUserRole oAspNetUserRole = null;

			oAspNetUserRole = LoadOne(sUserId, sRoleId, null);

			if (oAspNetUserRole == null)
			{
				return (new AspNetUserRole());
			}
			else
			{
				return (oAspNetUserRole);
			}
		}

		public static void InsertOne(AspNetUserRole oAspNetUserRole)
		{
			InsertOne(oAspNetUserRole, null);
		}

		public static void InsertOne(AspNetUserRole oAspNetUserRole, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [dbo].[AspNetUserRoles] ");
			oInsert.Append("([UserId], [RoleId])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUserRole.UserId));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUserRole.RoleId));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(AspNetUserRole oAspNetUserRole)
		{
			UpdateOne(oAspNetUserRole, null);
		}

		public static void UpdateOne(AspNetUserRole oAspNetUserRole, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [dbo].[AspNetUserRoles] SET ");


			oUpdate.Append(UTI_Where4One(oAspNetUserRole));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(AspNetUserRole oAspNetUserRole)
		{
			DeleteOne(oAspNetUserRole, null);
		}

		public static void DeleteOne(AspNetUserRole oAspNetUserRole, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [dbo].[AspNetUserRoles]");

			oDelete.Append(UTI_Where4One(oAspNetUserRole));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(AspNetUserRole oAspNetUserRole)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[UserId]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUserRole.UserId));
			oWhere.Append(" AND ");
			oWhere.Append("[RoleId]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetUserRole.RoleId));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(String sUserId, String sRoleId)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[UserId]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(sUserId));
			oWhere.Append(" AND ");
			oWhere.Append("[RoleId]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(sRoleId));

			return (oWhere.ToString());
		}

		public static AspNetUserRole UTI_RowToAspNetUserRole(DataRow oRow)
		{
			AspNetUserRole oAspNetUserRole = new AspNetUserRole();

			oAspNetUserRole.UserId = ((String)(oRow["UserId"])).Trim();
			oAspNetUserRole.RoleId = ((String)(oRow["RoleId"])).Trim();

			return (oAspNetUserRole);
		}
		#endregion
	}

}

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
	/// Public AspNetRole Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  03/09/2020  Created
	/// </remarks>
	public class AspNetRoles : EntitiesManagerBase
	{
		#region Public Properties
		public AspNetRole this[int nIndex]
		{
			get { return ((AspNetRole)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public AspNetRole GetByKeys(String sId)
		{
			foreach (AspNetRole oAspNetRole in this.m_aItems)
			{
				if (oAspNetRole.Id == sId)
				{
					return (oAspNetRole);
				}
			}

			return (null);
		}

		public AspNetRole[] ToArray()
		{
			List<AspNetRole> aRet = new List<AspNetRole>();
			foreach (AspNetRole oAspNetRole in this.m_aItems)
			{
				aRet.Add(oAspNetRole);
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
			AspNetRole oAspNetRole = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oAspNetRole = UTI_RowToAspNetRole(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oAspNetRole);

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

			oDelete = new StringBuilder("DELETE FROM [dbo].[AspNetRoles]");

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
			oSelect = new StringBuilder("SELECT * FROM [dbo].[AspNetRoles]");

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

		public static AspNetRole LoadOne(String sId)
		{
			return(LoadOne(sId, null));
		}

		public static AspNetRole LoadOne(String sId, SqlConnection oPrivateConnection)
		{
			AspNetRole oAspNetRole = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [dbo].[AspNetRoles]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[Id]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(sId));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oAspNetRole = UTI_RowToAspNetRole(oRow);
			}

			return (oAspNetRole);
		}

		public static AspNetRole TryLoadOne(String sId)
		{
			return(TryLoadOne(sId, null));
		}

		public static AspNetRole TryLoadOne(String sId, SqlConnection oPrivateConnection)
		{
			AspNetRole oAspNetRole = null;

			oAspNetRole = LoadOne(sId, null);

			if (oAspNetRole == null)
			{
				return (new AspNetRole());
			}
			else
			{
				return (oAspNetRole);
			}
		}

		public static void InsertOne(AspNetRole oAspNetRole)
		{
			InsertOne(oAspNetRole, null);
		}

		public static void InsertOne(AspNetRole oAspNetRole, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [dbo].[AspNetRoles] ");
			oInsert.Append("([Id], [Name], [Discriminator])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetRole.Id));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetRole.Name));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetRole.Discriminator));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(AspNetRole oAspNetRole)
		{
			UpdateOne(oAspNetRole, null);
		}

		public static void UpdateOne(AspNetRole oAspNetRole, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [dbo].[AspNetRoles] SET ");

			oUpdate.Append("[Name]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetRole.Name));
			oUpdate.Append(", ");
			oUpdate.Append("[Discriminator]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetRole.Discriminator));

			oUpdate.Append(UTI_Where4One(oAspNetRole));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(AspNetRole oAspNetRole)
		{
			DeleteOne(oAspNetRole, null);
		}

		public static void DeleteOne(AspNetRole oAspNetRole, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [dbo].[AspNetRoles]");

			oDelete.Append(UTI_Where4One(oAspNetRole));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(AspNetRole oAspNetRole)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[Id]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oAspNetRole.Id));

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

		public static AspNetRole UTI_RowToAspNetRole(DataRow oRow)
		{
			AspNetRole oAspNetRole = new AspNetRole();

			oAspNetRole.Id = ((String)(oRow["Id"])).Trim();
			oAspNetRole.Name = ((String)(oRow["Name"])).Trim();
			oAspNetRole.Discriminator = ((String)(oRow["Discriminator"])).Trim();

			return (oAspNetRole);
		}
		#endregion
	}

}

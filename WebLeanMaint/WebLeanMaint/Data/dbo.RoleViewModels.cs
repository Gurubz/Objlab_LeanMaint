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
	/// Public RoleViewModel Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  03/09/2020  Created
	/// </remarks>
	public class RoleViewModels : EntitiesManagerBase
	{
		#region Public Properties
		public RoleViewModel this[int nIndex]
		{
			get { return ((RoleViewModel)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public RoleViewModel GetByKeys(String sId)
		{
			foreach (RoleViewModel oRoleViewModel in this.m_aItems)
			{
				if (oRoleViewModel.Id == sId)
				{
					return (oRoleViewModel);
				}
			}

			return (null);
		}

		public RoleViewModel[] ToArray()
		{
			List<RoleViewModel> aRet = new List<RoleViewModel>();
			foreach (RoleViewModel oRoleViewModel in this.m_aItems)
			{
				aRet.Add(oRoleViewModel);
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
			RoleViewModel oRoleViewModel = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oRoleViewModel = UTI_RowToRoleViewModel(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oRoleViewModel);

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

			oDelete = new StringBuilder("DELETE FROM [dbo].[RoleViewModels]");

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
			oSelect = new StringBuilder("SELECT * FROM [dbo].[RoleViewModels]");

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

		public static RoleViewModel LoadOne(String sId)
		{
			return(LoadOne(sId, null));
		}

		public static RoleViewModel LoadOne(String sId, SqlConnection oPrivateConnection)
		{
			RoleViewModel oRoleViewModel = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [dbo].[RoleViewModels]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[Id]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(sId));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oRoleViewModel = UTI_RowToRoleViewModel(oRow);
			}

			return (oRoleViewModel);
		}

		public static RoleViewModel TryLoadOne(String sId)
		{
			return(TryLoadOne(sId, null));
		}

		public static RoleViewModel TryLoadOne(String sId, SqlConnection oPrivateConnection)
		{
			RoleViewModel oRoleViewModel = null;

			oRoleViewModel = LoadOne(sId, null);

			if (oRoleViewModel == null)
			{
				return (new RoleViewModel());
			}
			else
			{
				return (oRoleViewModel);
			}
		}

		public static void InsertOne(RoleViewModel oRoleViewModel)
		{
			InsertOne(oRoleViewModel, null);
		}

		public static void InsertOne(RoleViewModel oRoleViewModel, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [dbo].[RoleViewModels] ");
			oInsert.Append("([Id], [Name])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oRoleViewModel.Id));
			oInsert.Append(", ");
			if (oRoleViewModel.Name_HasValue == true) {
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oRoleViewModel.Name));
			} else {;
			oInsert.Append("NULL");
			}
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(RoleViewModel oRoleViewModel)
		{
			UpdateOne(oRoleViewModel, null);
		}

		public static void UpdateOne(RoleViewModel oRoleViewModel, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [dbo].[RoleViewModels] SET ");

			oUpdate.Append("[Name]=");
			if (oRoleViewModel.Name_HasValue == true) {
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oRoleViewModel.Name));
			} else {
			oUpdate.Append("NULL");
			}

			oUpdate.Append(UTI_Where4One(oRoleViewModel));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(RoleViewModel oRoleViewModel)
		{
			DeleteOne(oRoleViewModel, null);
		}

		public static void DeleteOne(RoleViewModel oRoleViewModel, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [dbo].[RoleViewModels]");

			oDelete.Append(UTI_Where4One(oRoleViewModel));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(RoleViewModel oRoleViewModel)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[Id]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oRoleViewModel.Id));

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

		public static RoleViewModel UTI_RowToRoleViewModel(DataRow oRow)
		{
			RoleViewModel oRoleViewModel = new RoleViewModel();

			oRoleViewModel.Id = ((String)(oRow["Id"])).Trim();
			if (!(oRow["Name"] is DBNull)) {
			  oRoleViewModel.Name = ((String)(oRow["Name"])).Trim();
			  oRoleViewModel.Name_HasValue = true;
			} else {
			  oRoleViewModel.Name_HasValue = false;
			}

			return (oRoleViewModel);
		}
		#endregion
	}

}

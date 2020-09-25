using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Data.Maintenance
{
	/// <summary>
	/// Public MaterialUM Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  25/09/2020  Created
	/// </remarks>
	public partial class MaterialUMs : EntitiesManagerBase
	{
		#region Public Properties
		public MaterialUM this[int nIndex]
		{
			get { return ((MaterialUM)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public MaterialUM GetByKeys(Int32 nID_MaterialUM)
		{
			foreach (MaterialUM oMaterialUM in this.m_aItems)
			{
				if (oMaterialUM.ID_MaterialUM == nID_MaterialUM)
				{
					return (oMaterialUM);
				}
			}

			return (null);
		}

		public MaterialUM[] ToArray()
		{
			List<MaterialUM> aRet = new List<MaterialUM>();
			foreach (MaterialUM oMaterialUM in this.m_aItems)
			{
				aRet.Add(oMaterialUM);
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
			MaterialUM oMaterialUM = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oMaterialUM = UTI_RowToMaterialUM(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oMaterialUM);

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

			oDelete = new StringBuilder("DELETE FROM [Maintenance].[MaterialUMs]");

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
			oSelect = new StringBuilder("SELECT * FROM [Maintenance].[MaterialUMs]");

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

		public static MaterialUM LoadOne(Int32 nID_MaterialUM, SqlConnection oPrivateConnection = null)
		{
			MaterialUM oMaterialUM = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Maintenance].[MaterialUMs]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_MaterialUM]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_MaterialUM));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oMaterialUM = UTI_RowToMaterialUM(oRow);
			}

			return (oMaterialUM);
		}

		public static MaterialUM TryLoadOne(Int32 nID_MaterialUM, SqlConnection oPrivateConnection = null)
		{
			MaterialUM oMaterialUM = null;

			oMaterialUM = LoadOne(nID_MaterialUM, null);

			if (oMaterialUM == null)
			{
				return (new MaterialUM());
			}
			else
			{
				return (oMaterialUM);
			}
		}

		public static void InsertOne(MaterialUM oMaterialUM, SqlConnection oPrivateConnection = null)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Maintenance].[MaterialUMs] ");
			oInsert.Append("([ID_MaterialUM], [Name], [Description])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oMaterialUM.ID_MaterialUM));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oMaterialUM.Name));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oMaterialUM.Description));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(MaterialUM oMaterialUM, SqlConnection oPrivateConnection = null)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Maintenance].[MaterialUMs] SET ");

			oUpdate.Append("[Name]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oMaterialUM.Name));
			oUpdate.Append(", ");
			oUpdate.Append("[Description]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oMaterialUM.Description));

			oUpdate.Append(UTI_Where4One(oMaterialUM));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(MaterialUM oMaterialUM, SqlConnection oPrivateConnection = null)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Maintenance].[MaterialUMs]");

			oDelete.Append(UTI_Where4One(oMaterialUM));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static void DeleteOne(Int32 nID_MaterialUM, SqlConnection oPrivateConnection=null)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Maintenance].[MaterialUMs]");

			oDelete.Append(UTI_Where4One(nID_MaterialUM));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(MaterialUM oMaterialUM)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_MaterialUM]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oMaterialUM.ID_MaterialUM));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_MaterialUM)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_MaterialUM]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_MaterialUM));

			return (oWhere.ToString());
		}

		public static MaterialUM UTI_RowToMaterialUM(DataRow oRow)
		{
			MaterialUM oMaterialUM = new MaterialUM();

			oMaterialUM.ID_MaterialUM = ((Int32)(oRow["ID_MaterialUM"]));
			oMaterialUM.Name = ((String)(oRow["Name"])).Trim();
			oMaterialUM.Description = ((String)(oRow["Description"])).Trim();

			return (oMaterialUM);
		}
		#endregion
	}

}

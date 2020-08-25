using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Data.Maintenance
{
	/// <summary>
	/// Public Material Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  25/08/2020  Created
	/// </remarks>
	public class Materials : EntitiesManagerBase
	{
		#region Public Properties
		public Material this[int nIndex]
		{
			get { return ((Material)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public Material GetByKeys(Int32 nID)
		{
			foreach (Material oMaterial in this.m_aItems)
			{
				if (oMaterial.ID == nID)
				{
					return (oMaterial);
				}
			}

			return (null);
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
			Material oMaterial = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oMaterial = UTI_RowToMaterial(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oMaterial);

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

			oDelete = new StringBuilder("DELETE FROM [Materials]");

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
			oSelect = new StringBuilder("SELECT * FROM [Materials]");

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

		public static Material LoadOne(Int32 nID)
		{
			return(LoadOne(nID, null));
		}

		public static Material LoadOne(Int32 nID, SqlConnection oPrivateConnection)
		{
			Material oMaterial = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Materials]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oMaterial = UTI_RowToMaterial(oRow);
			}

			return (oMaterial);
		}

		public static Material TryLoadOne(Int32 nID)
		{
			return(TryLoadOne(nID, null));
		}

		public static Material TryLoadOne(Int32 nID, SqlConnection oPrivateConnection)
		{
			Material oMaterial = null;

			oMaterial = LoadOne(nID, null);

			if (oMaterial == null)
			{
				return (new Material());
			}
			else
			{
				return (oMaterial);
			}
		}

		public static void InsertOne(Material oMaterial)
		{
			InsertOne(oMaterial, null);
		}

		public static void InsertOne(Material oMaterial, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Materials] ");
			oInsert.Append("([Name], [Description], [ID_Plant], [Coded], [ID_Supplier], [UsedFrom], [ID_CostCenter], [Cost], [ID_ObjStatus])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oMaterial.Name));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oMaterial.Description));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oMaterial.ID_Plant));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oMaterial.Coded));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oMaterial.ID_Supplier));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oMaterial.UsedFrom));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oMaterial.ID_CostCenter));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oMaterial.Cost));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oMaterial.ID_ObjStatus));
			oInsert.Append(")");

			Object oRet;
			oRet = EntitiesManagerBase.DAT_ExecuteScalar(oInsert.ToString(), "\nSELECT @@IDENTITY AS ID", oPrivateConnection);
			oMaterial.ID = Convert.ToInt32(oRet);
		}

		public static void UpdateOne(Material oMaterial)
		{
			UpdateOne(oMaterial, null);
		}

		public static void UpdateOne(Material oMaterial, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Materials] SET ");

			oUpdate.Append("[Name]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oMaterial.Name));
			oUpdate.Append(", ");
			oUpdate.Append("[Description]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oMaterial.Description));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_Plant]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oMaterial.ID_Plant));
			oUpdate.Append(", ");
			oUpdate.Append("[Coded]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oMaterial.Coded));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_Supplier]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oMaterial.ID_Supplier));
			oUpdate.Append(", ");
			oUpdate.Append("[UsedFrom]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oMaterial.UsedFrom));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_CostCenter]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oMaterial.ID_CostCenter));
			oUpdate.Append(", ");
			oUpdate.Append("[Cost]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oMaterial.Cost));
			oUpdate.Append(", ");
			oUpdate.Append("[ID_ObjStatus]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oMaterial.ID_ObjStatus));

			oUpdate.Append(UTI_Where4One(oMaterial));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(Material oMaterial)
		{
			DeleteOne(oMaterial, null);
		}

		public static void DeleteOne(Material oMaterial, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Materials]");

			oDelete.Append(UTI_Where4One(oMaterial));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(Material oMaterial)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oMaterial.ID));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID));

			return (oWhere.ToString());
		}

		public static Material UTI_RowToMaterial(DataRow oRow)
		{
			Material oMaterial = new Material();

			oMaterial.ID = ((Int32)(oRow["ID"]));
			oMaterial.Name = ((String)(oRow["Name"])).Trim();
			oMaterial.Description = ((String)(oRow["Description"])).Trim();
			oMaterial.ID_Plant = ((Int32)(oRow["ID_Plant"]));
			oMaterial.Coded = ((Int32)(oRow["Coded"]));
			oMaterial.ID_Supplier = ((Int32)(oRow["ID_Supplier"]));
			oMaterial.UsedFrom = ((DateTime)(oRow["UsedFrom"]));
			oMaterial.ID_CostCenter = ((Int32)(oRow["ID_CostCenter"]));
			oMaterial.Cost = ((Decimal)(oRow["Cost"]));
			oMaterial.ID_ObjStatus = ((Int32)(oRow["ID_ObjStatus"]));

			return (oMaterial);
		}
		#endregion
	}

}

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
	/// Public ExecutionAssetMaterial Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  27/09/2020  Created
	/// </remarks>
	public partial class ExecutionAssetMaterials : EntitiesManagerBase
	{
		#region Public Properties
		public ExecutionAssetMaterial this[int nIndex]
		{
			get { return ((ExecutionAssetMaterial)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public ExecutionAssetMaterial GetByKeys(Int32 nID_ExecutionAsset, Int32 nID_Material)
		{
			foreach (ExecutionAssetMaterial oExecutionAssetMaterial in this.m_aItems)
			{
				if (oExecutionAssetMaterial.ID_ExecutionAsset == nID_ExecutionAsset && oExecutionAssetMaterial.ID_Material == nID_Material)
				{
					return (oExecutionAssetMaterial);
				}
			}

			return (null);
		}

		public ExecutionAssetMaterial[] ToArray()
		{
			List<ExecutionAssetMaterial> aRet = new List<ExecutionAssetMaterial>();
			foreach (ExecutionAssetMaterial oExecutionAssetMaterial in this.m_aItems)
			{
				aRet.Add(oExecutionAssetMaterial);
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
			ExecutionAssetMaterial oExecutionAssetMaterial = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oExecutionAssetMaterial = UTI_RowToExecutionAssetMaterial(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oExecutionAssetMaterial);

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

			oDelete = new StringBuilder("DELETE FROM [Maintenance].[ExecutionAssetMaterials]");

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
			oSelect = new StringBuilder("SELECT * FROM [Maintenance].[ExecutionAssetMaterials]");

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

		public static ExecutionAssetMaterial LoadOne(Int32 nID_ExecutionAsset, Int32 nID_Material, SqlConnection oPrivateConnection = null)
		{
			ExecutionAssetMaterial oExecutionAssetMaterial = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [Maintenance].[ExecutionAssetMaterials]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_ExecutionAsset]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_ExecutionAsset));
			oSelect.Append(" AND ");
			oSelect.Append("[ID_Material]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Material));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oExecutionAssetMaterial = UTI_RowToExecutionAssetMaterial(oRow);
			}

			return (oExecutionAssetMaterial);
		}

		public static ExecutionAssetMaterial TryLoadOne(Int32 nID_ExecutionAsset, Int32 nID_Material, SqlConnection oPrivateConnection = null)
		{
			ExecutionAssetMaterial oExecutionAssetMaterial = null;

			oExecutionAssetMaterial = LoadOne(nID_ExecutionAsset, nID_Material, null);

			if (oExecutionAssetMaterial == null)
			{
				return (new ExecutionAssetMaterial());
			}
			else
			{
				return (oExecutionAssetMaterial);
			}
		}

		public static void InsertOne(ExecutionAssetMaterial oExecutionAssetMaterial, SqlConnection oPrivateConnection = null)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [Maintenance].[ExecutionAssetMaterials] ");
			oInsert.Append("([ID_ExecutionAsset], [ID_Material], [Quantity])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionAssetMaterial.ID_ExecutionAsset));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionAssetMaterial.ID_Material));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionAssetMaterial.Quantity));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(ExecutionAssetMaterial oExecutionAssetMaterial, SqlConnection oPrivateConnection = null)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [Maintenance].[ExecutionAssetMaterials] SET ");

			oUpdate.Append("[Quantity]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionAssetMaterial.Quantity));

			oUpdate.Append(UTI_Where4One(oExecutionAssetMaterial));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(ExecutionAssetMaterial oExecutionAssetMaterial, SqlConnection oPrivateConnection = null)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Maintenance].[ExecutionAssetMaterials]");

			oDelete.Append(UTI_Where4One(oExecutionAssetMaterial));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static void DeleteOne(Int32 nID_ExecutionAsset, Int32 nID_Material, SqlConnection oPrivateConnection=null)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [Maintenance].[ExecutionAssetMaterials]");

			oDelete.Append(UTI_Where4One(nID_ExecutionAsset, nID_Material));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(ExecutionAssetMaterial oExecutionAssetMaterial)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_ExecutionAsset]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionAssetMaterial.ID_ExecutionAsset));
			oWhere.Append(" AND ");
			oWhere.Append("[ID_Material]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionAssetMaterial.ID_Material));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_ExecutionAsset, Int32 nID_Material)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_ExecutionAsset]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_ExecutionAsset));
			oWhere.Append(" AND ");
			oWhere.Append("[ID_Material]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Material));

			return (oWhere.ToString());
		}

		public static ExecutionAssetMaterial UTI_RowToExecutionAssetMaterial(DataRow oRow)
		{
			ExecutionAssetMaterial oExecutionAssetMaterial = new ExecutionAssetMaterial();

			oExecutionAssetMaterial.ID_ExecutionAsset = ((Int32)(oRow["ID_ExecutionAsset"]));
			oExecutionAssetMaterial.ID_Material = ((Int32)(oRow["ID_Material"]));
			oExecutionAssetMaterial.Quantity = ((Decimal)(oRow["Quantity"]));

			return (oExecutionAssetMaterial);
		}
		#endregion
	}

}

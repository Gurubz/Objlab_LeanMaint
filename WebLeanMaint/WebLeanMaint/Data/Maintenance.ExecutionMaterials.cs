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
	/// Public ExecutionMaterial Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  27/08/2020  Created
	/// </remarks>
	public class ExecutionMaterials : EntitiesManagerBase
	{
		#region Public Properties
		public ExecutionMaterial this[int nIndex]
		{
			get { return ((ExecutionMaterial)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public ExecutionMaterial GetByKeys(Int32 nID_Execution, Int32 nID_Material)
		{
			foreach (ExecutionMaterial oExecutionMaterial in this.m_aItems)
			{
				if (oExecutionMaterial.ID_Execution == nID_Execution && oExecutionMaterial.ID_Material == nID_Material)
				{
					return (oExecutionMaterial);
				}
			}

			return (null);
		}

		public ExecutionMaterial[] ToArray()
		{
			List<ExecutionMaterial> aRet = new List<ExecutionMaterial>();
			foreach (ExecutionMaterial oExecutionMaterial in this.m_aItems)
			{
				aRet.Add(oExecutionMaterial);
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
			ExecutionMaterial oExecutionMaterial = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oExecutionMaterial = UTI_RowToExecutionMaterial(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oExecutionMaterial);

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

			oDelete = new StringBuilder("DELETE FROM [ExecutionMaterials]");

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
			oSelect = new StringBuilder("SELECT * FROM [ExecutionMaterials]");

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

		public static ExecutionMaterial LoadOne(Int32 nID_Execution, Int32 nID_Material)
		{
			return(LoadOne(nID_Execution, nID_Material, null));
		}

		public static ExecutionMaterial LoadOne(Int32 nID_Execution, Int32 nID_Material, SqlConnection oPrivateConnection)
		{
			ExecutionMaterial oExecutionMaterial = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [ExecutionMaterials]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_Execution]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Execution));
			oSelect.Append(" AND ");
			oSelect.Append("[ID_Material]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Material));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oExecutionMaterial = UTI_RowToExecutionMaterial(oRow);
			}

			return (oExecutionMaterial);
		}

		public static ExecutionMaterial TryLoadOne(Int32 nID_Execution, Int32 nID_Material)
		{
			return(TryLoadOne(nID_Execution, nID_Material, null));
		}

		public static ExecutionMaterial TryLoadOne(Int32 nID_Execution, Int32 nID_Material, SqlConnection oPrivateConnection)
		{
			ExecutionMaterial oExecutionMaterial = null;

			oExecutionMaterial = LoadOne(nID_Execution, nID_Material, null);

			if (oExecutionMaterial == null)
			{
				return (new ExecutionMaterial());
			}
			else
			{
				return (oExecutionMaterial);
			}
		}

		public static void InsertOne(ExecutionMaterial oExecutionMaterial)
		{
			InsertOne(oExecutionMaterial, null);
		}

		public static void InsertOne(ExecutionMaterial oExecutionMaterial, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [ExecutionMaterials] ");
			oInsert.Append("([ID_Execution], [ID_Material], [Quantity])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionMaterial.ID_Execution));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionMaterial.ID_Material));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionMaterial.Quantity));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(ExecutionMaterial oExecutionMaterial)
		{
			UpdateOne(oExecutionMaterial, null);
		}

		public static void UpdateOne(ExecutionMaterial oExecutionMaterial, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [ExecutionMaterials] SET ");

			oUpdate.Append("[Quantity]=");
			oUpdate.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionMaterial.Quantity));

			oUpdate.Append(UTI_Where4One(oExecutionMaterial));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(ExecutionMaterial oExecutionMaterial)
		{
			DeleteOne(oExecutionMaterial, null);
		}

		public static void DeleteOne(ExecutionMaterial oExecutionMaterial, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [ExecutionMaterials]");

			oDelete.Append(UTI_Where4One(oExecutionMaterial));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(ExecutionMaterial oExecutionMaterial)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Execution]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionMaterial.ID_Execution));
			oWhere.Append(" AND ");
			oWhere.Append("[ID_Material]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionMaterial.ID_Material));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_Execution, Int32 nID_Material)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Execution]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Execution));
			oWhere.Append(" AND ");
			oWhere.Append("[ID_Material]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Material));

			return (oWhere.ToString());
		}

		public static ExecutionMaterial UTI_RowToExecutionMaterial(DataRow oRow)
		{
			ExecutionMaterial oExecutionMaterial = new ExecutionMaterial();

			oExecutionMaterial.ID_Execution = ((Int32)(oRow["ID_Execution"]));
			oExecutionMaterial.ID_Material = ((Int32)(oRow["ID_Material"]));
			oExecutionMaterial.Quantity = ((Int32)(oRow["Quantity"]));

			return (oExecutionMaterial);
		}
		#endregion
	}

}

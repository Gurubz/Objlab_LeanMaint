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
	/// Public ExecutionOperator Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  25/08/2020  Created
	/// </remarks>
	public class ExecutionOperators : EntitiesManagerBase
	{
		#region Public Properties
		public ExecutionOperator this[int nIndex]
		{
			get { return ((ExecutionOperator)this.m_aItems[nIndex]); }
			set { this.m_aItems[nIndex] = value; }
		}
		#endregion

		#region Public Methods
		#region Collection

		public ExecutionOperator GetByKeys(Int32 nID_Execution, Int32 nID_Operator)
		{
			foreach (ExecutionOperator oExecutionOperator in this.m_aItems)
			{
				if (oExecutionOperator.ID_Execution == nID_Execution && oExecutionOperator.ID_Operator == nID_Operator)
				{
					return (oExecutionOperator);
				}
			}

			return (null);
		}

		public ExecutionOperator[] ToArray()
		{
			List<ExecutionOperator> aRet = new List<ExecutionOperator>();
			foreach (ExecutionOperator oExecutionOperator in this.m_aItems)
			{
				aRet.Add(oExecutionOperator);
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
			ExecutionOperator oExecutionOperator = null;
			DataSet oRet = null;

			// Clear internal item array
			this.m_aItems.Clear();

			// Get dataset
			oRet = LoadFast(sWhere, sOrderBy, oPrivateConnection);

			// Scan rows to create entity
			foreach (DataRow oRow in oRet.Tables[0].Rows)
			{
				oExecutionOperator = UTI_RowToExecutionOperator(oRow);

				// Add entity to internal array
				this.m_aItems.Add(oExecutionOperator);

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

			oDelete = new StringBuilder("DELETE FROM [ExecutionOperators]");

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
			oSelect = new StringBuilder("SELECT * FROM [ExecutionOperators]");

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

		public static ExecutionOperator LoadOne(Int32 nID_Execution, Int32 nID_Operator)
		{
			return(LoadOne(nID_Execution, nID_Operator, null));
		}

		public static ExecutionOperator LoadOne(Int32 nID_Execution, Int32 nID_Operator, SqlConnection oPrivateConnection)
		{
			ExecutionOperator oExecutionOperator = null;
			DataSet oDs = null;
			StringBuilder oSelect = null;

			// Prepare the Sql Statement
			oSelect = new StringBuilder("SELECT * FROM [ExecutionOperators]");

			oSelect.Append(" WHERE ");
			oSelect.Append("[ID_Execution]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Execution));
			oSelect.Append(" AND ");
			oSelect.Append("[ID_Operator]=");
			oSelect.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Operator));

			oDs = EntitiesManagerBase.DAT_ExecuteDataSet(oSelect.ToString(), oPrivateConnection);

			if (oDs.Tables[0].Rows.Count == 1)
			{
				DataRow oRow = null;

				// Take the row
				oRow = oDs.Tables[0].Rows[0];

				oExecutionOperator = UTI_RowToExecutionOperator(oRow);
			}

			return (oExecutionOperator);
		}

		public static ExecutionOperator TryLoadOne(Int32 nID_Execution, Int32 nID_Operator)
		{
			return(TryLoadOne(nID_Execution, nID_Operator, null));
		}

		public static ExecutionOperator TryLoadOne(Int32 nID_Execution, Int32 nID_Operator, SqlConnection oPrivateConnection)
		{
			ExecutionOperator oExecutionOperator = null;

			oExecutionOperator = LoadOne(nID_Execution, nID_Operator, null);

			if (oExecutionOperator == null)
			{
				return (new ExecutionOperator());
			}
			else
			{
				return (oExecutionOperator);
			}
		}

		public static void InsertOne(ExecutionOperator oExecutionOperator)
		{
			InsertOne(oExecutionOperator, null);
		}

		public static void InsertOne(ExecutionOperator oExecutionOperator, SqlConnection oPrivateConnection)
		{
			StringBuilder oInsert = null;

			oInsert = new StringBuilder("INSERT INTO [ExecutionOperators] ");
			oInsert.Append("([ID_Execution], [ID_Operator])");
			oInsert.Append(" VALUES ");
			oInsert.Append("(");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionOperator.ID_Execution));
			oInsert.Append(", ");
			oInsert.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionOperator.ID_Operator));
			oInsert.Append(")");

			EntitiesManagerBase.DAT_ExecuteNonQuery(oInsert.ToString(), oPrivateConnection);
		}

		public static void UpdateOne(ExecutionOperator oExecutionOperator)
		{
			UpdateOne(oExecutionOperator, null);
		}

		public static void UpdateOne(ExecutionOperator oExecutionOperator, SqlConnection oPrivateConnection)
		{
			StringBuilder oUpdate = null;

			oUpdate = new StringBuilder("UPDATE [ExecutionOperators] SET ");


			oUpdate.Append(UTI_Where4One(oExecutionOperator));

			// Execute the update
			EntitiesManagerBase.DAT_ExecuteNonQuery(oUpdate.ToString(), oPrivateConnection);

		}

		public static void DeleteOne(ExecutionOperator oExecutionOperator)
		{
			DeleteOne(oExecutionOperator, null);
		}

		public static void DeleteOne(ExecutionOperator oExecutionOperator, SqlConnection oPrivateConnection)
		{
			StringBuilder oDelete = null;

			oDelete = new StringBuilder("DELETE FROM [ExecutionOperators]");

			oDelete.Append(UTI_Where4One(oExecutionOperator));

			EntitiesManagerBase.DAT_ExecuteNonQuery(oDelete.ToString(), oPrivateConnection);
		}

		public static string UTI_Where4One(ExecutionOperator oExecutionOperator)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Execution]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionOperator.ID_Execution));
			oWhere.Append(" AND ");
			oWhere.Append("[ID_Operator]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(oExecutionOperator.ID_Operator));

			return (oWhere.ToString());
		}

		public static string UTI_Where4One(Int32 nID_Execution, Int32 nID_Operator)
		{
			StringBuilder oWhere = new StringBuilder();

			oWhere.Append(" WHERE ");
			oWhere.Append("[ID_Execution]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Execution));
			oWhere.Append(" AND ");
			oWhere.Append("[ID_Operator]=");
			oWhere.Append(EntitiesManagerBase.UTI_ValueToSql(nID_Operator));

			return (oWhere.ToString());
		}

		public static ExecutionOperator UTI_RowToExecutionOperator(DataRow oRow)
		{
			ExecutionOperator oExecutionOperator = new ExecutionOperator();

			oExecutionOperator.ID_Execution = ((Int32)(oRow["ID_Execution"]));
			oExecutionOperator.ID_Operator = ((Int32)(oRow["ID_Operator"]));

			return (oExecutionOperator);
		}
		#endregion
	}

}

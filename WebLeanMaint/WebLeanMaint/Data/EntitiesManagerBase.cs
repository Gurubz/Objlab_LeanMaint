using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Data
{
	/// <summary>
	/// Base entities manager class
	/// </summary>
	/// <remarks>
	/// TODO: This class must be edited to manage your database interface in the
	/// way suitable for your application. Think to it as an interface to your		
	/// actual database connection.		
	/// Basically you simply need to set shared database connection		
	/// EntitiesManagerBase.SharedConnection to your current db connection.		
	/// If more connections are used you must set the optional private connection 		
	/// every time you use a Database method.		
	/// </remarks>
	public class EntitiesManagerBase : IEnumerable
	{
		public EntitiesManagerBase()
		{
			this.m_aItems = new ArrayList();
		}

		#region Protected Properties
		protected ArrayList m_aItems;
		#endregion

		#region Public Properties
		public int Count
		{
			get { return (this.m_aItems.Count); }
		}
		#endregion

		#region Protected Shared Properties
		protected static SqlConnection g_oSharedConnection;
		#endregion

		#region Public Shared Properties
		public static SqlConnection SharedConnection
		{
			get
			{
				if (EntitiesManagerBase.g_oSharedConnection == null)
				{
					EntitiesManagerBase.g_oSharedConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);

					//if (AppDomain.CurrentDomain.BaseDirectory.StartsWith("C:\\") == true)
					//{
					//  if (MCUtility.Files.Helpers.Config.HasValue("ConnLocal") == false)
					//  {
					//    throw new ArgumentNullException("ConnLocal");
					//  }

					//  g_oSharedConnection = new System.Data.OleDb.OleDbConnection(MCUtility.Files.Helpers.Config.ReadValue("ConnLocal"));
					//}
					//else
					//{
					//  if (MCUtility.Files.Helpers.Config.HasValue("Conn") == false)
					//  {
					//    throw new ArgumentNullException("Conn");
					//  }

					//  g_oSharedConnection = new System.Data.OleDb.OleDbConnection(MCUtility.Files.Helpers.Config.ReadValue("Conn"));
					//}
				}

				if (EntitiesManagerBase.g_oSharedConnection.State == ConnectionState.Closed)
				{
					EntitiesManagerBase.g_oSharedConnection.Open();
				}

				return (EntitiesManagerBase.g_oSharedConnection);
			}
			set { EntitiesManagerBase.g_oSharedConnection = value; }
		}
		#endregion

		#region Public Methods
		public IEnumerator GetEnumerator()
		{
			return (this.m_aItems.GetEnumerator());
		}
		#endregion

		#region Public Static DAT Methods
		public static DataSet DAT_ExecuteDataSet(string sSelect)
		{
			return (DAT_ExecuteDataSet(sSelect, null));
		}

		public static DataSet DAT_ExecuteDataSet(string sSelect, SqlConnection oPrivateConnection)
		{
			SqlDataAdapter oDa = null;
			DataSet oRet = new DataSet();
			SqlConnection oConnection = null;

			// If no private connection passed
			if (oPrivateConnection == null)
			{
				// Use the shared one
				oConnection = EntitiesManagerBase.SharedConnection;
			}
			// If private passed
			else
			{
				// Use that one
				oConnection = oPrivateConnection;
			}

			try
			{
				oDa = new SqlDataAdapter(sSelect, oConnection);
				oDa.Fill(oRet);
			}
			catch (SqlException oEx)
			{
				EntitiesManagerBase.UTI_Log(oEx, sSelect);
				throw;
			}
			catch (System.Exception oEx)
			{
				EntitiesManagerBase.UTI_Log(oEx);
				throw;
			}
			finally
			{
				if (oDa != null)
				{
					oDa.Dispose();
				}
			}

			return (oRet);
		}

		public static void DAT_ExecuteNonQuery(string sSelect)
		{
			DAT_ExecuteDataSet(sSelect, null);
		}

		public static void DAT_ExecuteNonQuery(string sSql, SqlConnection oPrivateConnection)
		{
			SqlCommand oCommand = null;
			SqlConnection oConnection = null;

			// If no private connection passed
			if (oPrivateConnection == null)
			{
				// Use the shared one
				oConnection = EntitiesManagerBase.SharedConnection;
			}
			// If private passed
			else
			{
				// Use that one
				oConnection = oPrivateConnection;
			}

			try
			{
				oCommand = new SqlCommand(sSql, oConnection);
				oCommand.ExecuteNonQuery();
			}
			catch (SqlException oEx)
			{
				EntitiesManagerBase.UTI_Log(oEx, sSql);
				throw;
			}
			catch (System.Exception oEx)
			{
				EntitiesManagerBase.UTI_Log(oEx);
				throw;
			}
			finally
			{
				if (oCommand != null)
				{
					oCommand.Dispose();
				}
			}
		}

		public static object DAT_ExecuteScalar(string sSql, string sSqlIdentity)
		{
			return (DAT_ExecuteScalar(sSql, sSqlIdentity, null));
		}

		public static object DAT_ExecuteScalar(string sSql, string sSqlIdentity, SqlConnection oPrivateConnection)
		{
			SqlCommand oCommand = null;
			object oRet = null;
			SqlConnection oConnection = null;

			// If no private connection passed
			if (oPrivateConnection == null)
			{
				// Use the shared one
				oConnection = EntitiesManagerBase.SharedConnection;
			}
			// If private passed
			else
			{
				// Use that one
				oConnection = oPrivateConnection;
			}

			try
			{
				// Executes the statement
				using (oCommand = new SqlCommand(sSql, oConnection))
				{
					oRet = oCommand.ExecuteScalar();
				}
				oCommand = null;

				if (String.IsNullOrEmpty(sSqlIdentity) == false)
				{
					// Executes the identity
					using (oCommand = new SqlCommand(sSqlIdentity, oConnection))
					{
						oRet = oCommand.ExecuteScalar();
					}
					oCommand = null;
				}
			}
			catch (SqlException oEx)
			{
				EntitiesManagerBase.UTI_Log(oEx, sSql);
				throw;
			}
			catch (System.Exception oEx)
			{
				EntitiesManagerBase.UTI_Log(oEx);
				throw;
			}

			return (oRet);
		}
		#endregion

		#region Public Shared UTI Methods
		public static string UTI_ValueToSql(object oValue)
		{
			StringBuilder oRet = null;

			oRet = new StringBuilder();

			if (oValue is System.DBNull)
			{
				oRet.Append("NULL");
			}
			else if (oValue is string || oValue is char)
			{
				oRet.Append("'");
				oRet.Append(oValue.ToString().Replace("'", "''"));
				oRet.Append("'");
			}
			else if (oValue is DateTime)
			{
				DateTime oDate = (DateTime)oValue;

				// Se la data e' al valore minimo di SQL Server
				if (oDate < new DateTime(1900, 1, 1))
				{
					// Forza il valore al minimo di SQL Server
					oDate = new DateTime(1900, 1, 1);
				}

				// Use default based on the db type
				oRet.Append("'" + oDate.ToString("yyyy-MM-ddTHH:mm:ss") + "'");
			}
			else if (oValue is bool)
			{
				if ((Boolean)oValue == true)
				{
					oRet.Append("1");
				}
				else
				{
					oRet.Append("0");
				}
			}
			else if (oValue is Byte[])
			{
				oRet.Append("0x");
				oRet.Append(BitConverter.ToString((byte[])oValue).Replace("-", string.Empty));
			}
			else
			{
				oRet.Append(oValue.ToString().Replace(",", "."));
			}

			return (oRet.ToString());
		}

		public static void UTI_Log(SqlException oEx, string sSqlStatement)
		{
			// TODO: Here add log logic
		}

		public static void UTI_Log(System.Exception oEx)
		{
			// TODO: Here add log logic
		}

		public static void UTI_Log(string sMessage)
		{
			// TODO: Here add log logic
		}
		#endregion
	}
}

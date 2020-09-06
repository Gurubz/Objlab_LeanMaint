using SQLite;
using System.Collections.Generic;
using System.Linq;
using System;
using AppLeanMaint.PlanningWS;

namespace AppLeanMaint.Helpers
{
	public class Database
	{
		private Database()
		{

		}

		private string DB_FILE = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "AppLeanMaint.db";

		private static Database g_oDatabase = null;
		public static Database Current
		{
			get
			{
				if (g_oDatabase == null)
				{
					g_oDatabase = new Database();
					g_oDatabase.CreateDatabase();
				}

				return (g_oDatabase);
			}
		}

		public bool CreateDatabase()
		{
			bool bRet = false;

			using (var oConnection = new SQLiteConnection(DB_FILE))
			{
				oConnection.CreateTable<PlanningWS.OrderType>();
				oConnection.CreateTable<PlanningWS.Asset>();
				bRet = true;
			}

			return (bRet);
		}

		public PlanningWS.OrderType[] GetOrderTypes()
		{
			PlanningWS.OrderType[] aRet = null;

			using (var oConnection = new SQLiteConnection(DB_FILE))
			{
				aRet = oConnection.Table<PlanningWS.OrderType>().OrderBy((x) => x.ID_OrderType).ToArray();
			}

			return (aRet);
		}

		public void SaveOrderTypes(PlanningWS.OrderType[] aOrderTypes)
		{
			using (var oConnection = new SQLiteConnection(DB_FILE))
			{
				oConnection.DeleteAll<PlanningWS.OrderType>();
				oConnection.InsertAll(aOrderTypes);
			}
		}

		public PlanningWS.Asset[] SearchAssets(string sName)
		{
			List<PlanningWS.Asset> aRet = new List<Asset>();

			using (var oConnection = new SQLiteConnection(DB_FILE))
			{
				string sSql = $"SELECT * FROM Asset WHERE Name LIKE '%{sName}%' OR Description LIKE '%{sName}%' ORDER BY Name";

				aRet.AddRange(oConnection.Query<PlanningWS.Asset>(sSql));
			}

			return (aRet.ToArray());
		}

		public void SaveAssets(Asset[] aAssets)
		{
			using (var oConnection = new SQLiteConnection(DB_FILE))
			{
				oConnection.DeleteAll<PlanningWS.Asset>();
				oConnection.InsertAll(aAssets);
			}
		}
	}
}

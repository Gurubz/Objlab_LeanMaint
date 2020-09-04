using SQLite;
using System.Collections.Generic;
using System.Linq;
using System;

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
	}
}

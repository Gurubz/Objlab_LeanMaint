using SQLite;
using System.Collections.Generic;
using System.Linq;
using System;
using AppLeanMaint.PlanningWS;
using Android.Widget;

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
				oConnection.CreateTable<PlanningWS.Material>();
				oConnection.CreateTable<PlanningWS.Operator>();
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
			List<PlanningWS.Asset> aRet = new List<PlanningWS.Asset>();

			using (var oConnection = new SQLiteConnection(DB_FILE))
			{
				string sSql = $"SELECT * FROM Asset WHERE Name LIKE '%{sName}%' OR Description LIKE '%{sName}%' ORDER BY Name";

				aRet.AddRange(oConnection.Query<PlanningWS.Asset>(sSql));
			}

			return (aRet.ToArray());
		}

		public void SaveAssets(PlanningWS.Asset[] aAssets)
		{
			using (var oConnection = new SQLiteConnection(DB_FILE))
			{
				oConnection.DeleteAll<PlanningWS.Asset>();
				oConnection.InsertAll(aAssets);
			}
		}

		public PlanningWS.Material[] SearchMaterials(string sName)
		{
			List<PlanningWS.Material> aRet = new List<PlanningWS.Material>();

			using (var oConnection = new SQLiteConnection(DB_FILE))
			{
				string sSql = $"SELECT * FROM Material WHERE Name LIKE '%{sName}%' OR Description LIKE '%{sName}%' ORDER BY Name";

				aRet.AddRange(oConnection.Query<PlanningWS.Material>(sSql));
			}

			return (aRet.ToArray());
		}

		public void SaveMaterials(PlanningWS.Material[] aMaterials)
		{
			using (var oConnection = new SQLiteConnection(DB_FILE))
			{
				oConnection.DeleteAll<PlanningWS.Material>();
				oConnection.InsertAll(aMaterials);
			}
		}

		public PlanningWS.Operator[] SearchOperators(string sName)
		{
			List<PlanningWS.Operator> aRet = new List<PlanningWS.Operator>();

			using (var oConnection = new SQLiteConnection(DB_FILE))
			{
				string sSql = $"SELECT * FROM Operator WHERE Name LIKE '%{sName}%' OR Description LIKE '%{sName}%' ORDER BY Name";

				aRet.AddRange(oConnection.Query<PlanningWS.Operator>(sSql));
			}

			return (aRet.ToArray());
		}

		public void SaveOperators(PlanningWS.Operator[] aOperators)
		{
			using (var oConnection = new SQLiteConnection(DB_FILE))
			{
				oConnection.DeleteAll<PlanningWS.Operator>();
				oConnection.InsertAll(aOperators);
			}
		}

		public Asset GetAsset(int nID_Asset)
		{
			Asset oRet = null;
			using (var oConnection = new SQLiteConnection(DB_FILE))
			{
				oRet = oConnection.Table<PlanningWS.Asset>().Where((x) => x.ID_Asset == nID_Asset).SingleOrDefault();
			}
			return (oRet);
		}

		public Operator GetOperator(int nID_Operator)
		{
			Operator oRet = null;
			using (var oConnection = new SQLiteConnection(DB_FILE))
			{
				oRet = oConnection.Table<PlanningWS.Operator>().Where((x) => x.ID_Operator == nID_Operator).SingleOrDefault();
			}
			return (oRet);
		}
	}
}

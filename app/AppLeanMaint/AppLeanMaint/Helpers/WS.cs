using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AutoMapper;

namespace AppLeanMaint.Helpers
{
	public class WS
	{
		private WS()
		{
			int nTimeout = 5000;
			m_oConfigWs = new ConfigWS.Config();
			m_oConfigWs.Timeout = nTimeout;
			m_oPlanningWs = new PlanningWS.Planning();
			m_oPlanningWs.Timeout = nTimeout;
			m_oMaintenanceWs = new MaintenanceWS.Maintenance();
			m_oMaintenanceWs.Timeout = nTimeout;
			MapperConfiguration oConfig = new MapperConfiguration(cfg =>
			{
				// cfg.CreateMap<CounterInfoResponse, Models.Counter>();
			});
			m_oMapper = oConfig.CreateMapper();
		}

		private IMapper m_oMapper = null;
		private ConfigWS.Config m_oConfigWs = null;
		private PlanningWS.Planning m_oPlanningWs = null;
		private MaintenanceWS.Maintenance m_oMaintenanceWs = null;

		private static WS g_oInstance = null;
		public static WS Instance
		{
			get
			{
				if (g_oInstance == null)
				{
					g_oInstance = new WS();
				}
				return (g_oInstance);
			}
		}

		public void UpdateLocalDataAsync()
		{
			PlanningWS.OrderType[] aOrderTypes = m_oPlanningWs.GetOrderTypes();

			Database.Current.SaveOrderTypes(aOrderTypes);
		}

		public int CreateOrder(PlanningWS.Order m_oOrder)
		{
			return (m_oPlanningWs.CreateOrder(m_oOrder));
		}

		public void UpdateLocalAssetsForOrder(int ID_Order = 0)
		{
			PlanningWS.Asset[] aAssets = m_oPlanningWs.GetAssetsForOrder(ID_Order);

			Database.Current.SaveAssets(aAssets);
		}

		public void UpdateLocalMaterialsForAsset(int ID_Asset)
		{
			PlanningWS.Material[] aMaterials = m_oPlanningWs.GetMaterialsForAsset(ID_Asset);

			Database.Current.SaveMaterials(aMaterials);
		}

		public void UpdateLocalOperatorsForOrder(int ID_Order = 0)
		{
			PlanningWS.Operator[] aOperators = m_oPlanningWs.GetOperatorsForOrder(ID_Order);

			Database.Current.SaveOperators(aOperators);
		}

		public PlanningWS.Order[] GetOrders()
		{
			PlanningWS.Order[] aRet = m_oPlanningWs.GetOrders();

			return (aRet);
		}
	}
}
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
			m_oConfigWs = new ConfigWS.Config();
			m_oPlanningWs = new PlanningWS.Planning();
			m_oMaintenanceWs = new MaintenanceWS.Maintenance();
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

		public async Task UpdateLocalDataAsync()
		{
			var aOrderTypes = await Task.Run(() => m_oPlanningWs.GetOrderTypes());
			Helpers.Database.Current.SaveOrderTypes(aOrderTypes);
		}
	}
}
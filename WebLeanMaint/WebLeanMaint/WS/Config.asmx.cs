using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebLeanMaint.WS
{
	/// <summary>
	/// Summary description for Config
	/// </summary>
	[WebService(Namespace = "http://objlab.it/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class Config : System.Web.Services.WebService
	{
		[WebMethod]
		[Description("Return organization centers tree")]
		public Models.Root<int, Data.Config.OrganizationCenter> GetOrganizationCentersTree()
		{
			Models.Root<int, Data.Config.OrganizationCenter> oRet = new Models.Root<int, Data.Config.OrganizationCenter>();

			Data.Config.OrganizationCenters aCenters = new Data.Config.OrganizationCenters();
			aCenters.Load(string.Empty);
			List<Models.Node<int, Data.Config.OrganizationCenter>> a = new List<Models.Node<int, Data.Config.OrganizationCenter>>();
			foreach (Data.Config.OrganizationCenter oCenter in aCenters)
			{
				if (oCenter.ID_Parent_HasValue == false) a.Add(new Models.Node<int, Data.Config.OrganizationCenter>(oCenter.ID_OrganizationCenter, oCenter));
				else a.Add(new Models.Node<int, Data.Config.OrganizationCenter>(oCenter.ID_OrganizationCenter, oCenter, oCenter.ID_Parent));
			}
			oRet.BuildTree(a);

			return (oRet);
		}
	}
}

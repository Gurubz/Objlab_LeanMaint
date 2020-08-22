using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebLeanMaint.WS
{
	/// <summary>
	/// Summary description for Maintenance
	/// </summary>
	[WebService(Namespace = "http://objlab.it/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class Maintenance : System.Web.Services.WebService
	{
		[WebMethod]
		[Description("Ping the status of the web service")]
		public string Ping()
		{
			return (this.Context.Request.UserHostAddress);
		}
	}
}

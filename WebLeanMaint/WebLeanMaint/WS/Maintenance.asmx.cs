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

		[WebMethod]
		[Description("Create Operator")]
		public int CreateOperator(string sUsername, string sPassword, string sName, string sLastName, string sEmail, string sMobile, Data.Maintenance.OperatorTypeEnum eType)
		{
			Data.Security.User oUser = new Data.Security.User();
			oUser.Username = sUsername;
			oUser.Password = sPassword;
			oUser.Seed = 1;
			oUser.EMail = sEmail;
			oUser.Mobile = sMobile;
			oUser.ID_UserType = (int)Data.Security.UserTypeEnum.Operator;
			oUser.ID_ObjStatus = (int)Data.Config.ObjStatuseEnum.Active;
			Data.Security.Users.InsertOne(oUser);

			Data.Maintenance.Operator oOperator = new Data.Maintenance.Operator();
			oOperator.Name = sName;
			oOperator.LastName = sLastName;
			oOperator.ID_OperatorType = (int)eType;
			oOperator.ID_ObjStatus = (int)Data.Config.ObjStatuseEnum.Active;
			oOperator.ID_User = oUser.ID_User;
			Data.Maintenance.Operators.InsertOne(oOperator);

			return (oOperator.ID_Operator);
		}

		[WebMethod]
		[Description("Create supplier")]
		public int CreateSupplier(string sUsername, string sPassword, string sName, string sDescription, string sEmail, string sMobile, Data.Maintenance.SupplierTypeEnum eType)
		{
			Data.Security.User oUser = new Data.Security.User();
			oUser.Username = sUsername;
			oUser.Password = sPassword;
			oUser.Seed = 1;
			oUser.EMail = sEmail;
			oUser.Mobile = sMobile;
			oUser.ID_UserType = (int)Data.Security.UserTypeEnum.Supplier;
			oUser.ID_ObjStatus = (int)Data.Config.ObjStatuseEnum.Active;
			Data.Security.Users.InsertOne(oUser);

			Data.Maintenance.Supplier oSupplier = new Data.Maintenance.Supplier();
			oSupplier.Name = sName;
			oSupplier.Description = sDescription;
			oSupplier.ID_SupplierType = (int)eType;
			oSupplier.ID_ObjStatus = (int)Data.Config.ObjStatuseEnum.Active;
			oSupplier.ID_User = oUser.ID_User;
			Data.Maintenance.Suppliers.InsertOne(oSupplier);

			return (oSupplier.ID_Supplier);
		}
	}
}

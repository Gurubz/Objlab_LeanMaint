using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebLeanMaint.WS
{
	/// <summary>
	/// Summary description for Planning
	/// </summary>
	[WebService(Namespace = "http://objlab.it/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class Planning : System.Web.Services.WebService
	{
		[WebMethod]
		[Description("Get order types")]
		public Data.Planning.OrderType[] GetOrderTypes()
		{
			Data.Planning.OrderTypes aTypes = new Data.Planning.OrderTypes();
			aTypes.Load(string.Empty);
			return (aTypes.ToArray());
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

			Data.Planning.Operator oOperator = new Data.Planning.Operator();
			oOperator.Name = sName;
			oOperator.LastName = sLastName;
			oOperator.ID_OperatorType = (int)eType;
			oOperator.ID_ObjStatus = (int)Data.Config.ObjStatuseEnum.Active;
			oOperator.ID_User = oUser.ID_User;
			Data.Planning.Operators.InsertOne(oOperator);

			return (oOperator.ID_Operator);
		}

		[WebMethod]
		[Description("Planning: Create order")]
		public int CreateOrder(Data.Planning.Order oOrder)
		{
			oOrder.RequestedAt = DateTime.Now;
			oOrder.Completed = false;
			Data.Planning.Orders.InsertOne(oOrder);

			return (oOrder.ID_Order);
		}

		[WebMethod]
		[Description("Planning: Get order")]
		public Data.Planning.Order GetOrder(int nID_Order)
		{
			return(Data.Planning.Orders.LoadOne(nID_Order));
		}
	}
}

using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Xml.Schema;

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
			StringBuilder oRet = new StringBuilder();

			oRet.AppendLine(this.Context.Request.UserHostAddress);
			int n = (int)EntitiesManagerBase.DAT_ExecuteScalar("SELECT 1", string.Empty);
			if (n == 1)
			{
				oRet.Append("DB Connected");
			}

			return (oRet.ToString());
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

		[WebMethod]
		[Description("Planning: Create order")]
		public int CreateOrder(Data.Planning.OrderTypeEnum eType, string sDescription, DateTime oPlannedFor, DateTime oToCompleteBefore)
		{
			Data.Planning.Order oOrder = new Data.Planning.Order();
			oOrder.ID_OrderType = (int)eType;
			oOrder.Description = sDescription;
			oOrder.RequestedAt = DateTime.Now;
			oOrder.PlannedFor = oPlannedFor;
			oOrder.ToCompleteBefore = oToCompleteBefore;
			oOrder.Completed = false;
			Data.Planning.Orders.InsertOne(oOrder);

			return (oOrder.ID_Order);
		}

		[WebMethod]
		[Description("Planning: Get operators available for order")]
		public List<Data.Planning.Operator> GetOperatorsForOrder(int ID_Order)
		{
			List<Data.Planning.Operator> aRet = new List<Data.Planning.Operator>();

			Data.Planning.Order oOrder = Data.Planning.Orders.LoadOne(ID_Order);
			if (oOrder != null)
			{
				string sPlannedFor = Data.EntitiesManagerBase.UTI_ValueToSql(oOrder.PlannedFor);
				string sToCompleteBefore = Data.EntitiesManagerBase.UTI_ValueToSql(oOrder.ToCompleteBefore);

				StringBuilder oSql = new StringBuilder();
				oSql.AppendLine("SELECT O.* FROM Planning.Operators O");
				oSql.AppendLine("INNER JOIN Planning.CalendarDays CD ON O.ID_Calendar=CD.ID_Calendar");
				oSql.AppendFormat($"WHERE (CD.DayStart<={sPlannedFor} AND {sToCompleteBefore}<=CD.DayStartPause) OR (CD.DayEndPause<={sPlannedFor} AND {sToCompleteBefore}<=CD.DayEnd)");

				DataSet oDs = Data.EntitiesManagerBase.DAT_ExecuteDataSet(oSql.ToString());
				foreach (DataRow oRow in oDs.Tables[0].Rows)
				{
					aRet.Add(Data.Planning.Operators.UTI_RowToOperator(oRow));
				}
			}

			return (aRet);
		}

		[WebMethod]
		[Description("Planning: Add operator to order")]
		public void AddOperatorToOrder(int ID_Order, int ID_Operator)
		{
			Data.Planning.OrderOperator oOperator = new Data.Planning.OrderOperator();
			oOperator.ID_Order = ID_Order;
			oOperator.ID_Operator = ID_Operator;
			Data.Planning.OrderOperators.InsertOne(oOperator);
		}

		[WebMethod]
		[Description("Planning: Get assets available for order")]
		public Data.Maintenance.Asset[] GetAssetsForOrder(int ID_Order)
		{
			return (Core.Planning.GetAssetsForOrder(ID_Order));
		}

		[WebMethod]
		[Description("Planning: Add asset to order")]
		public void AddAssetToOrder(int ID_Order, int ID_Asset)
		{
			Data.Planning.OrderAsset oAsset = new Data.Planning.OrderAsset();
			oAsset.ID_Order = ID_Order;
			oAsset.ID_Asset = ID_Asset;
			Data.Planning.OrderAssets.InsertOne(oAsset);
		}

		[WebMethod]
		[Description("Planning: Get material available for order")]
		public Data.Maintenance.Material[] GetMaterialsForOrder(int ID_Order)
		{
			return (Core.Planning.GetMaterialsForOrder(ID_Order));
		}

		[WebMethod]
		[Description("Planning: Add material to order")]
		public void AddMaterialToOrder(int ID_Order, int ID_Material, int nQuantity)
		{
			Data.Planning.OrderMaterial oMaterial = new Data.Planning.OrderMaterial();
			oMaterial.ID_Order = ID_Order;
			oMaterial.ID_Material = ID_Material;
			oMaterial.Quantity = nQuantity;
			Data.Planning.OrderMaterials.InsertOne(oMaterial);
		}

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

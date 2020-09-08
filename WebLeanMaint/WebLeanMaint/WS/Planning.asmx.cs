using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
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
		public int CreateOperator(string sUsername, string sPassword, string sName, string sLastName, string sEmail, string sMobile, Data.Planning.OperatorTypeEnum eType)
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
			if (oOrder.Assets != null)
			{
				foreach (Data.Planning.OrderAsset oOrderAsset in oOrder.Assets)
				{
					oOrderAsset.ID_Order = oOrder.ID_Order;
					Data.Planning.OrderAssets.InsertOne(oOrderAsset);
					int ID_OrderAsset = oOrderAsset.ID_OrderAsset;

					if (oOrderAsset.OrderAssetMaterials != null)
					{
						foreach (Data.Planning.OrderAssetMaterial oOrderAssetMaterial in oOrderAsset.OrderAssetMaterials)
						{
							oOrderAssetMaterial.ID_OrderAsset = ID_OrderAsset;
							Data.Planning.OrderAssetMaterials.InsertOne(oOrderAssetMaterial);
						}
					}
				}
			}
			if (oOrder.Operators != null)
			{
				foreach(Data.Planning.OrderOperator oOrderOperator in oOrder.Operators)
				{
					oOrderOperator.ID_Order = oOrder.ID_Order;
					Data.Planning.OrderOperators.InsertOne(oOrderOperator);
				}
			}

			return (oOrder.ID_Order);
		}

		[WebMethod]
		[Description("Planning: Get order")]
		public Data.Planning.Order GetOrder(int nID_Order)
		{
			return (Data.Planning.Orders.LoadOne(nID_Order));
		}

		[WebMethod]
		[Description("Planning: Get orders not completed")]
		public Data.Planning.Order[] GetOrders()
		{
			Data.Planning.Orders aOrders = new Data.Planning.Orders();
			aOrders.Load("Completed=" + EntitiesManagerBase.UTI_ValueToSql(false), "PlannedFor");
			foreach(Data.Planning.Order oOrder in aOrders)
			{
				Data.Planning.OrderAssets aOrderAssets = new Data.Planning.OrderAssets();
				aOrderAssets.Load("ID_Order=" + EntitiesManagerBase.UTI_ValueToSql(oOrder.ID_Order), string.Empty);
				oOrder.Assets = aOrderAssets.ToArray();
				foreach(Data.Planning.OrderAsset oOrderAsset in aOrderAssets)
				{
					Data.Planning.OrderAssetMaterials aMaterials = new Data.Planning.OrderAssetMaterials();
					aMaterials.Load("ID_OrderAsset=" + EntitiesManagerBase.UTI_ValueToSql(oOrderAsset.ID_OrderAsset), string.Empty);
					oOrderAsset.OrderAssetMaterials = aMaterials.ToArray();
				}
				Data.Planning.OrderOperators aOrderOperators = new Data.Planning.OrderOperators();
				aOrderOperators.Load("ID_Order=" + EntitiesManagerBase.UTI_ValueToSql(oOrder.ID_Order), string.Empty);
				oOrder.Operators = aOrderOperators.ToArray();
			}
			

			return (aOrders.ToArray());
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
			else
			{
				DataSet oDs = Data.Planning.Operators.LoadFast(string.Empty);
				foreach (DataRow oRow in oDs.Tables[0].Rows)
				{
					aRet.Add(Data.Planning.Operators.UTI_RowToOperator(oRow));
				}
			}

			return (aRet);
		}

		[WebMethod]
		[Description("Planning: Get assets available for order")]
		public Data.Maintenance.Asset[] GetAssetsForOrder(int ID_Order)
		{
			return (Core.Planning.GetAssetsForOrder(ID_Order));
		}

		[WebMethod]
		[Description("Planning: Get material available for order")]
		public Data.Maintenance.Material[] GetMaterialsForAsset(int ID_Asset)
		{
			return (Core.Planning.GetMaterialsForAsset(ID_Asset));
		}
	}
}

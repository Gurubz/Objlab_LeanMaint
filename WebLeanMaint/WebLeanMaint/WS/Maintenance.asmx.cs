﻿using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Device.Location;
using System.Linq;
using System.Security.Cryptography;
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
		[Description("Maintenance: Asset search")]
		public Data.Maintenance.Asset[] SearchAsset(string sName)
		{
			Data.Maintenance.Assets aAssets = new Data.Maintenance.Assets();
			aAssets.Load($"Name LIKE {EntitiesManagerBase.UTI_ValueToSql("%" + sName + "%")} OR Description LIKE {EntitiesManagerBase.UTI_ValueToSql("%" + sName + "%")}", "Name");
			return (aAssets.ToArray());
		}

		[WebMethod]
		[Description("Maintenance: Get available executable orders based on condition passed")]
		public Data.Planning.Order[] GetExecutableOrdersByOperator(Data.Planning.Operator oOperator)
		{
			Data.Planning.Orders aOrders = new Data.Planning.Orders();
			if (oOperator != null)
			{
				aOrders.Load("ID_Operator=" + EntitiesManagerBase.UTI_ValueToSql(oOperator.ID_Operator));
			}

			return (aOrders.ToArray());
		}

		[WebMethod]
		[Description("Maintenance: Get available executable orders based on condition passed")]
		public Data.Planning.Order[] GetExecutableOrdersByAssetID(int nID_Asset)
		{
			Data.Planning.Orders aOrders = new Data.Planning.Orders();
			Data.Planning.OrderAssets aOrderAssets = new Data.Planning.OrderAssets();
			aOrderAssets.Load("ID_Asset=" + EntitiesManagerBase.UTI_ValueToSql(nID_Asset));
			string[] aID_Orders = (from o in aOrderAssets.ToArray() select EntitiesManagerBase.UTI_ValueToSql(o.ID_Order)).Distinct().ToArray();

			aOrders.Load("ID_Order IN " + string.Join(",", aID_Orders));

			return (aOrders.ToArray());
		}

		[WebMethod]
		[Description("Maintenance: Get available executable orders based on condition passed")]
		public Data.Planning.Order[] GetExecutableOrdersByAssetBarcode(string sBarcode)
		{
			Data.Planning.Orders aOrders = new Data.Planning.Orders();
			if (string.IsNullOrEmpty(sBarcode) == false)
			{
				Data.Maintenance.Assets aAssets = new Data.Maintenance.Assets();
				aAssets.Load("Barcode=" + EntitiesManagerBase.UTI_ValueToSql(sBarcode));
				if (aAssets.Count == 1)
				{
					Data.Planning.OrderAssets aOrderAssets = new Data.Planning.OrderAssets();
					aOrderAssets.Load($"ID_Asset={EntitiesManagerBase.UTI_ValueToSql(aAssets[0].ID_Asset)}");
					string[] aID_Orders = (from o in aOrderAssets.ToArray() select EntitiesManagerBase.UTI_ValueToSql(o.ID_Order)).Distinct().ToArray();
					if (aID_Orders.Length > 0) aOrders.Load("ID_Order IN (" + string.Join(",", aID_Orders) + ")");
				}
			}

			return (aOrders.ToArray());
		}

		[WebMethod]
		[Description("Maintenance: Get available executable orders based on condition passed")]
		public Data.Planning.Order[] GetExecutableOrdersByPosition(GeoCoordinate oPosition)
		{
			Data.Planning.Orders aOrders = new Data.Planning.Orders();
			if (oPosition != null && oPosition != GeoCoordinate.Unknown)
			{
				Core.CoordinateBoundaries oBoundary = new Core.CoordinateBoundaries(oPosition, 10);
			}

			return (aOrders.ToArray());
		}

		[WebMethod]
		[Description("Maintenance: Start order execution")]
		public Data.Maintenance.Execution StartOrderExecution(int nID_Order)
		{
			return (Core.Maintenance.CreateExecutionFromOrder(nID_Order));
		}
	}
}

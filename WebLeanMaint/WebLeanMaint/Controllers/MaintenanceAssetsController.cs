using WebLeanMaint.Models;
using WebLeanMaint.QueryModel;
using WebLeanMaint.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebLeanMaint.ViewQueryModel;
using System.Text;
using Data;
using System.Data.SqlClient;
using Dapper;

namespace WebLeanMaint.Controllers
{
	[SessionTimeout]
	public class MaintenanceAssetsController : Controller
	{
		private ApplicationDbContext _context;

		public MaintenanceAssetsController()
		{
			_context = new ApplicationDbContext();
		}
		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}
		// GET: MaintenanceAssets
		public ActionResult Index()
		{
			if (Session["UserID"] == null)
			{
				return RedirectToAction("Logout", "Home");
			}
			var list = _context.Assets.ToList();
			return View(list);
		}
		public ActionResult Create(Data.Maintenance.Asset maintenance)
		{
			var list = _context.Assets.ToList();
			var GenVm = new GeneralVM
			{
				OrganizationCenters = _context.OrganizationCenters.ToList(),
				CostCenters = _context.CostCenters.ToList(),
				GeographicCenters = _context.GeographicCenters.ToList(),
				ObjStatuses = _context.ObjStatuses.ToList(),
				AssetTypes = _context.AssetTypes.ToList(),
				Assets = _context.Assets.ToList(),
				Asset = maintenance,
			};
			return View(GenVm);
		}

		[HttpPost]
		public ActionResult Save(GeneralVM vm)
		{
			if (vm.Asset.ID_Asset == 0)
			{
				Data.Maintenance.Assets.InsertOne(vm.Asset);
			}
			else
			{
				var oAsset = _context.Assets.Single(c => c.ID_Asset == vm.Asset.ID_Asset);
				oAsset.Name = vm.Asset.Name;
				oAsset.Description = vm.Asset.Description;
				oAsset.ID_OrganizationCenter = vm.Asset.ID_OrganizationCenter;
				oAsset.ID_CostCenter = vm.Asset.ID_CostCenter;
				oAsset.ID_GeographicCenter = vm.Asset.ID_GeographicCenter;
				oAsset.ID_ObjStatus = vm.Asset.ID_ObjStatus;
				oAsset.ID_Parent = vm.Asset.ID_Parent;
				oAsset.ID_Parent_HasValue = vm.Asset.ID_Parent_HasValue;
				oAsset.Barcode = vm.Asset.Barcode;
				oAsset.Barcode_HasValue = vm.Asset.Barcode_HasValue;
				Data.Maintenance.Assets.UpdateOne(oAsset);
			}
			return RedirectToAction("Index", "MaintenanceAssets");
		}
		public ActionResult Edit(int Id)
		{
			var list = _context.Assets.ToList();
			var maintenance = list.SingleOrDefault(c => c.ID_Asset == Id);
			if (maintenance == null)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			var GenVm = new GeneralVM
			{
				OrganizationCenters = _context.OrganizationCenters.ToList(),
				CostCenters = _context.CostCenters.ToList(),
				GeographicCenters = _context.GeographicCenters.ToList(),
				ObjStatuses = _context.ObjStatuses.ToList(),
				AssetTypes = _context.AssetTypes.ToList(),
				Assets = _context.Assets.ToList(),
				Asset = maintenance,
			};
			return View("Create", GenVm);
		}
		public ActionResult Delete(int Id)
		{
			EntitiesManagerBase.SharedConnection.Execute("Delete From Maintenance.Assets where ID_Asset = " + Id + "");
			return RedirectToAction("Index");
		}
	}
}
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
		public ActionResult Create(Data.Maintenance.Asset oAsset)
		{
			var GenVm = new GeneralVM
			{
				OrganizationCenters = _context.OrganizationCenters.ToList(),
				CostCenters = _context.CostCenters.ToList(),
				GeographicCenters = _context.GeographicCenters.ToList(),
				ObjStatuses = _context.ObjStatuses.ToList(),
				AssetTypes = _context.AssetTypes.ToList(),
				Assets = _context.Assets.ToList(),
				Asset = oAsset,
			};
			// Defaults
			GenVm.Asset.ID_ObjStatus = (int)Data.Config.ObjStatuseEnum.Active;
			return View(GenVm);
		}

		[HttpPost]
		public ActionResult Save(GeneralVM vm)
		{
			// Null management
			vm.Asset.ID_GeographicCenter_HasValue = (vm.Asset.ID_GeographicCenter != 0);
			vm.Asset.ID_Parent_HasValue = (vm.Asset.ID_Parent != 0);

			if (vm.Asset.ID_Asset == 0)
			{
				Data.Maintenance.Assets.InsertOne(vm.Asset);
			}
			else
			{
				Data.Maintenance.Assets.UpdateOne(vm.Asset);
			}
			return RedirectToAction("Index", "MaintenanceAssets");
		}
		public ActionResult Edit(int Id)
		{
			var list = _context.Assets.ToList();
			var oAsset = list.SingleOrDefault(c => c.ID_Asset == Id);
			if (oAsset == null)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			var GenVm = new GeneralVM
			{
				OrganizationCenters = _context.OrganizationCenters.ToList(),
				CostCenters = _context.CostCenters.ToList(),
				GeographicCenters = _context.GeographicCenters.ToList(),
				ObjStatuses = _context.ObjStatuses.ToList(),
				AssetTypes = _context.AssetTypes.ToList(),
				Assets = _context.Assets.ToList(),
				Asset = oAsset,
			};
			return View("Create", GenVm);
		}
		public ActionResult Delete(int Id)
		{
			Data.Maintenance.Assets.DeleteOne(Id);
			return RedirectToAction("Index");
		}
	}
}
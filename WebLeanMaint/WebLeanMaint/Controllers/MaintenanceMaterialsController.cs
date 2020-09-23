using WebLeanMaint.Models;
using WebLeanMaint.QueryModel;
using WebLeanMaint.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
namespace WebLeanMaint.Controllers
{
	[SessionTimeout]
	public class MaintenanceMaterialsController : Controller
	{
		private ApplicationDbContext _context;

		public MaintenanceMaterialsController()
		{
			_context = new ApplicationDbContext();
		}
		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}
		// GET: MaintenanceMaterials
		public ActionResult Index()
		{
			if (Session["UserID"] == null)
			{
				return RedirectToAction("Logout", "Home");
			}
			var list = _context.Database.SqlQuery<MaintenanceMaterialsquery>("SELECT *,(Select name From [Config].[ObjStatuses] where ID_ObjStatus=Maintenance.Materials.ID_ObjStatus) as subname,(Select name From Maintenance.Suppliers where ID_Supplier=Maintenance.Materials.ID_Supplier) as supname,(Select name From Maintenance.MaterialUMs where ID_MaterialUM=Maintenance.Materials.ID_MaterialUM) as unitname,(Select name From [Config].[StoreCenters] where ID_StoreCenter=Maintenance.Materials.ID_StoreCenter) as storename   FROM Maintenance.Materials ").ToList();
			//,(Select name From [Config].[ObjStatuses] where ID_ObjStatus=MaintenanceMaterials.ID_ObjStatus) as subname
			return View(list);
		}
		public ActionResult Create(MaintenanceMaterials maintenanceMaterials)
		{
			var main_supp = _context.tbl_MaintenanceSuppliers.ToList();
			var main_suppum = _context.tbl_MaintenanceMaterialUMs.ToList();
			var main_stores = _context.Database.SqlQuery<General_query>("Select * from [Config].[StoreCenters]").ToList();
			var GenVm = new GeneralVM
			{
				main_suppum = main_suppum,
				main_stores = main_stores,
				ObjStatuses = _context.ObjStatuses.ToList(),
				main_supp = main_supp,
				maintenanceMaterials = maintenanceMaterials,
			};
			return View(GenVm);
		}
		[HttpPost]
		public ActionResult Save(GeneralVM vm)
		{
			if (vm.maintenanceMaterials.ID_Material == 0)
			{
				_context.tbl_MaintenanceMaterials.Add(vm.maintenanceMaterials);
			}
			else
			{
				var tbl_MaintenanceAssetsdb = _context.tbl_MaintenanceMaterials.Single(c => c.ID_Material == vm.maintenanceMaterials.ID_Material);
				tbl_MaintenanceAssetsdb.Name = vm.maintenanceMaterials.Name;
				tbl_MaintenanceAssetsdb.Description = vm.maintenanceMaterials.Description;
				tbl_MaintenanceAssetsdb.ID_ObjStatus = vm.maintenanceMaterials.ID_ObjStatus;
				tbl_MaintenanceAssetsdb.ReferenceCode = vm.maintenanceMaterials.ReferenceCode;
				tbl_MaintenanceAssetsdb.ID_Supplier = vm.maintenanceMaterials.ID_Supplier;
				tbl_MaintenanceAssetsdb.CostPerUM = vm.maintenanceMaterials.CostPerUM;
				tbl_MaintenanceAssetsdb.Brand = vm.maintenanceMaterials.Brand;
				tbl_MaintenanceAssetsdb.ID_MaterialUM = vm.maintenanceMaterials.ID_MaterialUM;
				tbl_MaintenanceAssetsdb.ID_StoreCenter = vm.maintenanceMaterials.ID_StoreCenter;
				tbl_MaintenanceAssetsdb.Type = vm.maintenanceMaterials.Type;
				tbl_MaintenanceAssetsdb.Barcode = vm.maintenanceMaterials.Barcode;
			}
			_context.SaveChanges();
			return RedirectToAction("Index", "MaintenanceMaterials");
		}
		public ActionResult Edit(int Id)
		{
			var maintenanceMaterials = _context.tbl_MaintenanceMaterials.SingleOrDefault(c => c.ID_Material == Id);
			if (maintenanceMaterials == null)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			var main_supp = _context.tbl_MaintenanceSuppliers.ToList();
			var main_suppum = _context.tbl_MaintenanceMaterialUMs.ToList();
			var main_stores = _context.Database.SqlQuery<General_query>("Select * from [Config].[StoreCenters]").ToList();
			var GenVm = new GeneralVM
			{
				main_suppum = main_suppum,
				main_stores = main_stores,
				ObjStatuses = _context.ObjStatuses.ToList(),
				main_supp = main_supp,
				maintenanceMaterials = maintenanceMaterials,

			};
			return View("Create", GenVm);
		}
		public ActionResult Delete(int Id)
		{
			_context.Database.ExecuteSqlCommand("Delete From Maintenance.Materials where ID_Material = " + Id + "");
			return RedirectToAction("Index");
		}
	}
}
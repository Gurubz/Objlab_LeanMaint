using WebLeanMaint.Models;
using WebLeanMaint.QueryModel;
using WebLeanMaint.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
using Dapper;

namespace WebLeanMaint.Controllers
{
	[SessionTimeout]
	public class MaintenanceSuppliersController : Controller
	{
		private ApplicationDbContext _context;

		public MaintenanceSuppliersController()
		{
			_context = new ApplicationDbContext();
		}
		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}
		// GET: MaintenanceSuppliers
		public ActionResult Index()
		{
			if (Session["UserID"] == null)
			{
				return RedirectToAction("Logout", "Home");
			}
			var list = _context.Suppliers.ToList();
			return View(list);
		}
		public ActionResult Create(Data.Maintenance.Supplier oSupplier)
		{
			var GenVm = new GeneralVM
			{
				CostCenters = _context.CostCenters.ToList(),
				SupplierTypes = _context.SupplierTypes.ToList(),
				Cities = _context.Cities.ToList(),
				Countries = _context.Countries.ToList(),
				ObjStatuses = _context.ObjStatuses.ToList(),
				Users = _context.Users.ToList(),
				Suppliers = _context.Suppliers.ToList(),
				Supplier = oSupplier,
			};
			// Defaults
			GenVm.Supplier.ID_ObjStatus = (int)Data.Config.ObjStatuseEnum.Active;
			GenVm.Supplier.ID_Country = 100; // Italy
			GenVm.Supplier.ValidFrom = DateTime.Now.Date;
			return View(GenVm);
		}
		[HttpPost]
		public ActionResult Save(GeneralVM vm)
		{
			// Null management
			vm.Supplier.Address2_HasValue = !string.IsNullOrEmpty(vm.Supplier.Address2);
			vm.Supplier.ID_User_HasValue = (vm.Supplier.ID_User != 0);

			if (vm.Supplier.ID_Supplier == 0)
			{
				Data.Maintenance.Suppliers.InsertOne(vm.Supplier);
			}
			else
			{
				Data.Maintenance.Suppliers.UpdateOne(vm.Supplier);
			}
			return RedirectToAction("Index", "MaintenanceSuppliers");
		}
		public ActionResult Edit(int Id)
		{
			var list = _context.Suppliers.ToList();
			var oSupplier = list.SingleOrDefault(c => c.ID_Supplier == Id);
			if (oSupplier == null)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			var GenVm = new GeneralVM
			{
				CostCenters = _context.CostCenters.ToList(),
				SupplierTypes = _context.SupplierTypes.ToList(),
				Cities = _context.Cities.ToList(),
				Countries = _context.Countries.ToList(),
				ObjStatuses = _context.ObjStatuses.ToList(),
				Users = _context.Users.ToList(),
				Supplier = oSupplier,
			};
			return View("Create", GenVm);
		}
		public ActionResult Delete(int Id)
		{
			Data.Maintenance.Suppliers.DeleteOne(Id);
			return RedirectToAction("Index");
		}
	}
}
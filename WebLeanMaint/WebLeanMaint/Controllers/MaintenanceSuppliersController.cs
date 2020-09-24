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
			return View(GenVm);
		}
		[HttpPost]
		public ActionResult Save(GeneralVM vm)
		{
			if (vm.Supplier.ID_Supplier == 0)
			{
				Data.Maintenance.Suppliers.InsertOne(vm.Supplier);
			}
			else
			{
				var oSupplier = _context.Suppliers.Single(c => c.ID_Supplier == vm.Supplier.ID_Supplier);
				oSupplier.Name = vm.Supplier.Name;
				oSupplier.Description = vm.Supplier.Description;
				oSupplier.ID_SupplierType = vm.Supplier.ID_SupplierType;
				oSupplier.ID_ObjStatus = vm.Supplier.ID_ObjStatus;
				oSupplier.Address1 = vm.Supplier.Address1;
				oSupplier.ID_CostCenter = vm.Supplier.ID_CostCenter;
				oSupplier.Address2 = vm.Supplier.Address2;
				oSupplier.HourlyCost = vm.Supplier.HourlyCost;
				oSupplier.ID_City = vm.Supplier.ID_City;
				oSupplier.Zip = vm.Supplier.Zip;
				oSupplier.ID_Country = vm.Supplier.ID_Country;
				oSupplier.ValidFrom = vm.Supplier.ValidFrom;
				oSupplier.ID_User = vm.Supplier.ID_User;
				Data.Maintenance.Suppliers.UpdateOne(oSupplier);
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
			EntitiesManagerBase.SharedConnection.Execute("Delete From Maintenance.Suppliers where ID_Supplier = " + Id + "");
			return RedirectToAction("Index");
		}
	}
}
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
		public ActionResult Index()
		{
			if (Session["UserID"] == null)
			{
				return RedirectToAction("Logout", "Home");
			}
			var list = _context.Materials.ToList();
			return View(list);
		}
		public ActionResult Create(Data.Maintenance.Material oMaterial)
		{
			var GenVm = new GeneralVM
			{
				Materials = _context.Materials.ToList(),
				Material = oMaterial,
			};
			return View(GenVm);
		}
		[HttpPost]
		public ActionResult Save(GeneralVM vm)
		{
			if (vm.Material.ID_Material == 0)
			{
				Data.Maintenance.Materials.InsertOne(vm.Material);
			}
			else
			{
				var oMaterial = _context.Materials.Single(c => c.ID_Material == vm.Material.ID_Material);
				oMaterial.Name = vm.Material.Name;
				oMaterial.Description = vm.Material.Description;
				oMaterial.ID_ObjStatus = vm.Material.ID_ObjStatus;
				oMaterial.ReferenceCode = vm.Material.ReferenceCode;
				oMaterial.ID_Supplier = vm.Material.ID_Supplier;
				oMaterial.CostPerUM = vm.Material.CostPerUM;
				oMaterial.Brand = vm.Material.Brand;
				oMaterial.ID_MaterialUM = vm.Material.ID_MaterialUM;
				oMaterial.ID_StoreCenter = vm.Material.ID_StoreCenter;
				oMaterial.Type = vm.Material.Type;
				oMaterial.Barcode = vm.Material.Barcode;
				Data.Maintenance.Materials.UpdateOne(oMaterial);
			}
			return RedirectToAction("Index", "MaintenanceMaterials");
		}
		public ActionResult Edit(int Id)
		{
			var list = _context.Materials.ToList();
			var oMaterial = list.SingleOrDefault(c => c.ID_Material == Id);
			if (oMaterial == null)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			var GenVm = new GeneralVM
			{
				MaterialUMs = _context.MaterialUMs.ToList(),
				Suppliers = _context.Suppliers.ToList(),
				StoreCenters = _context.StoreCenters.ToList(),
				ObjStatuses = _context.ObjStatuses.ToList(),
				Materials = _context.Materials.ToList(),
				Material = oMaterial,
			};
			return View("Create", GenVm);
		}
		public ActionResult Delete(int Id)
		{
			EntitiesManagerBase.SharedConnection.Execute("Delete From Maintenance.Materials where ID_Material = " + Id + "");
			return RedirectToAction("Index");
		}
	}
}
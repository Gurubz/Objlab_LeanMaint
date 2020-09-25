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
				MaterialUMs = _context.MaterialUMs.ToList(),
				Suppliers = _context.Suppliers.ToList(),
				StoreCenters = _context.StoreCenters.ToList(),
				ObjStatuses = _context.ObjStatuses.ToList(),
				Materials = _context.Materials.ToList(),
				Material = oMaterial,
			};
			// Defaults
			GenVm.Material.ID_ObjStatus = (int)Data.Config.ObjStatuseEnum.Active;
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
				Data.Maintenance.Materials.UpdateOne(vm.Material);
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
			Data.Maintenance.Materials.DeleteOne(Id);
			return RedirectToAction("Index");
		}
	}
}
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
	public class PlanningOperatorsController : Controller
	{
		private ApplicationDbContext _context;

		public PlanningOperatorsController()
		{
			_context = new ApplicationDbContext();
		}
		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}
		// GET: PlanningOperators
		public ActionResult Index()
		{
			if (Session["UserID"] == null)
			{
				return RedirectToAction("Logout", "Home");
			}
			var list = _context.Database.SqlQuery<PlanningOperatorsquery>("SELECT *,(Select name From [Config].[ObjStatuses] where ID_ObjStatus=Planning.Operators.ID_ObjStatus) as subname,(Select name From Maintenance.Suppliers where ID_Supplier=Planning.Operators.ID_Supplier) as supp,(Select name From [Accountancy].[CostCenters] where ID_CostCenter=Planning.Operators.ID_CostCenter) as costname,(Select name From Planning.OperatorTypes where ID_OperatorType=Planning.Operators.ID_OperatorType) as ptype,(Select name From [Planning].[Calendars] where ID_Calendar=Planning.Operators.ID_Calendar) as cal,(Select name From [Security].[Users] where ID_User=Planning.Operators.ID_User) as username   FROM Planning.Operators").ToList();
			return View(list);
		}
		public ActionResult Create(PlanningOperators planningOperators)
		{
			var main_supp = _context.tbl_MaintenanceSuppliers.ToList();
			var opp_types = _context.tbl_PlanningOperatorTypes.ToList();
			var cal = _context.Database.SqlQuery<General_query>("Select * from [Planning].[Calendars]").ToList();
			var user = _context.Database.SqlQuery<General_query>("Select * from [Security].[Users]").ToList();
			var GenVm = new GeneralVM
			{
				cal = cal,
				main_supp = main_supp,
				opp_types = opp_types,
				CostCenters = _context.CostCenters.ToList(),
				user = user,
				ObjStatuses = _context.ObjStatuses.ToList(),
				planningOperators = planningOperators,

			};
			return View(GenVm);
		}
		[HttpPost]
		public ActionResult Save(GeneralVM vm)
		{
			if (vm.planningOperators.ID_Operator == 0)
			{
				_context.tbl_PlanningOperators.Add(vm.planningOperators);
			}
			else
			{
				var tbl_PlanningOperatorsdb = _context.tbl_PlanningOperators.Single(c => c.ID_Operator == vm.planningOperators.ID_Operator);
				tbl_PlanningOperatorsdb.Name = vm.planningOperators.Name;
				tbl_PlanningOperatorsdb.MiddleName = vm.planningOperators.MiddleName;
				tbl_PlanningOperatorsdb.LastName = vm.planningOperators.LastName;
				tbl_PlanningOperatorsdb.Description = vm.planningOperators.Description;
				tbl_PlanningOperatorsdb.ID_OperatorType = vm.planningOperators.ID_OperatorType;
				tbl_PlanningOperatorsdb.ID_Calendar = vm.planningOperators.ID_Calendar;
				tbl_PlanningOperatorsdb.ID_Supplier = vm.planningOperators.ID_Supplier;
				tbl_PlanningOperatorsdb.ID_CostCenter = vm.planningOperators.ID_CostCenter;
				tbl_PlanningOperatorsdb.HourlyCost = vm.planningOperators.HourlyCost;
				tbl_PlanningOperatorsdb.ID_ObjStatus = vm.planningOperators.ID_ObjStatus;
				tbl_PlanningOperatorsdb.ID_User = vm.planningOperators.ID_User;
			}
			_context.SaveChanges();
			return RedirectToAction("Index", "PlanningOperators");
		}
		public ActionResult Edit(int Id)
		{
			var planningOperators = _context.tbl_PlanningOperators.SingleOrDefault(c => c.ID_Operator == Id);
			if (planningOperators == null)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			var main_supp = _context.tbl_MaintenanceSuppliers.ToList();
			var opp_types = _context.tbl_PlanningOperatorTypes.ToList();
			var cal = _context.Database.SqlQuery<General_query>("Select * from [Planning].[Calendars]").ToList();
			var user = _context.Database.SqlQuery<General_query>("Select * from [Security].[Users]").ToList();
			var GenVm = new GeneralVM
			{
				cal = cal,
				main_supp = main_supp,
				opp_types = opp_types,
				CostCenters = _context.CostCenters.ToList(),
				user = user,
				ObjStatuses = _context.ObjStatuses.ToList(),
				planningOperators = planningOperators,

			};
			return View("Create", GenVm);
		}
		public ActionResult Delete(int Id)
		{
			_context.Database.ExecuteSqlCommand("Delete From Planning.Operators where ID_Operator = " + Id + "");
			return RedirectToAction("Index");
		}
	}
}
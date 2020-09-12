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
            var list = _context.Database.SqlQuery<MaintenanceAssetsQuery>("SELECT *,(Select name From Maintenance.AssetTypes where ID_AssetType=[Maintenance].[Assets].ID_Asset) as AssetType,(Select name From [Config].[OrganizationCenters] where ID_OrganizationCenter=[Maintenance].[Assets].ID_OrganizationCenter) as OrgName,(Select name From [Accountancy].[CostCenters] where ID_CostCenter=[Maintenance].[Assets].ID_CostCenter) as costname,(Select name From [Config].[GeographicCenters] where ID_GeographicCenter=[Maintenance].[Assets].ID_GeographicCenter) as geoname,(Select name From [Config].[ObjStatuses] where ID_ObjStatus=[Maintenance].[Assets].ID_ObjStatus) as subname   FROM [Maintenance].[Assets] ").ToList();
            return View(list);
        }
        public ActionResult Create(MaintenanceAssets maintenance)
        {
            var main_types = _context.Database.SqlQuery<General_query>("Select * from Maintenance.AssetTypes").ToList();
            var main_orga = _context.Database.SqlQuery<General_query>("Select * from [Config].[OrganizationCenters]").ToList();
            var main_cost = _context.Database.SqlQuery<General_query>("Select * from [Accountancy].[CostCenters]").ToList();
            var main_geo = _context.Database.SqlQuery<General_query>("Select * from [Config].[GeographicCenters]").ToList();
            var main_subj = _context.Database.SqlQuery<General_query>("Select * from [Config].[ObjStatuses]").ToList();
            var list = _context.tbl_MaintenanceAssets.ToList();
            var GenVm = new GeneralVM
            {
                main_orga = main_orga,
                main_cost = main_cost,
                main_geo = main_geo,
                main_subj = main_subj,
                main_types = main_types,
                list = list,
                maintenance = maintenance,
                
            };
            return View(GenVm);
        }

        [HttpPost]
        public ActionResult Save(GeneralVM vm)
        {
            if (vm.maintenance.ID_Asset == 0)
            {
                _context.tbl_MaintenanceAssets.Add(vm.maintenance);
            }
            else
            {
                var tbl_MaintenanceAssetsdb = _context.tbl_MaintenanceAssets.Single(c => c.ID_Asset == vm.maintenance.ID_Asset);
                tbl_MaintenanceAssetsdb.Name = vm.maintenance.Name;
                tbl_MaintenanceAssetsdb.Description = vm.maintenance.Description;
                tbl_MaintenanceAssetsdb.ID_OrganizationCenter = vm.maintenance.ID_OrganizationCenter;
                tbl_MaintenanceAssetsdb.ID_CostCenter = vm.maintenance.ID_CostCenter;
                tbl_MaintenanceAssetsdb.ID_GeographicCenter = vm.maintenance.ID_GeographicCenter;
                tbl_MaintenanceAssetsdb.ID_ObjStatus = vm.maintenance.ID_ObjStatus;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "MaintenanceAssets");
        }
        public ActionResult Edit(int Id)
        {
            var maintenance = _context.tbl_MaintenanceAssets.SingleOrDefault(c => c.ID_Asset == Id);
            if (maintenance == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var main_types = _context.Database.SqlQuery<General_query>("Select * from Maintenance.AssetTypes").ToList();
            var main_orga = _context.Database.SqlQuery<General_query>("Select * from [Config].[OrganizationCenters]").ToList();
            var main_cost = _context.Database.SqlQuery<General_query>("Select * from [Accountancy].[CostCenters]").ToList();
            var main_geo = _context.Database.SqlQuery<General_query>("Select * from [Config].[GeographicCenters]").ToList();
            var main_subj = _context.Database.SqlQuery<General_query>("Select * from [Config].[ObjStatuses]").ToList();
            var list = _context.tbl_MaintenanceAssets.ToList();
            var GenVm = new GeneralVM
            {
                main_orga = main_orga,
                main_cost = main_cost,
                main_geo = main_geo,
                main_subj = main_subj,
                main_types = main_types,
                list = list,
                maintenance = maintenance,

            };
            return View("Create", GenVm);
        }
        public ActionResult Delete(int Id)
        {
            _context.Database.ExecuteSqlCommand("Delete From Maintenance.Assets where ID_Asset = " + Id + "");
            return RedirectToAction("Index");
        }
    }
}
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
            var list = _context.Database.SqlQuery<MaintenanceSuppliersquery>("SELECT *,(Select name From [Config].[ObjStatuses] where ID_ObjStatus=Maintenance.Suppliers.ID_ObjStatus) as subname,(Select name From Maintenance.SupplierTypes where ID_SupplierType=Maintenance.Suppliers.ID_SupplierType) as suptype,(Select name From [Accountancy].[CostCenters] where ID_CostCenter=Maintenance.Suppliers.ID_CostCenter) as costname,(Select name From [Config].[Cities] where ID_City=Maintenance.Suppliers.ID_City) as city,(Select name From [Config].[Countries] where ID_Country=Maintenance.Suppliers.ID_Country) as city,(Select name From [Security].[Users] where ID_User=Maintenance.Suppliers.ID_User) as username   FROM Maintenance.Suppliers").ToList();
            return View(list);
        }
        public ActionResult Create(MaintenanceSuppliers maintenanceSuppliers)
        {
            var supp_type = _context.tbl_MaintenanceSupplierTypes.ToList();
            var city = _context.Database.SqlQuery<General_query>("SELECT T.* FROM Config.Countries C INNER JOIN Config.Regions R ON C.ID_Country = R.ID_Country INNER JOIN Config.Cities T ON R.ID_Region = T.ID_Region WHERE C.ID_Country = 100").ToList();
            var country = _context.Database.SqlQuery<General_query>("Select * from [Config].[Countries]").ToList();
            var user = _context.Database.SqlQuery<General_query>("Select * from [Security].[Users]").ToList();
            var GenVm = new GeneralVM
            {
                CostCenters= _context.CostCenters.ToList(),
                supp_type = supp_type,
                city = city,
                country = country,
                ObjStatuses= _context.ObjStatuses.ToList(),
                user = user,
                maintenanceSuppliers = maintenanceSuppliers,

            };
            return View(GenVm);
        }
        [HttpPost]
        public ActionResult Save(GeneralVM vm)
        {
            if (vm.maintenanceSuppliers.ID_Supplier == 0)
            {
                _context.tbl_MaintenanceSuppliers.Add(vm.maintenanceSuppliers);
            }
            else
            {
                var tbl_MaintenanceSuppliersdb = _context.tbl_MaintenanceSuppliers.Single(c => c.ID_Supplier == vm.maintenanceSuppliers.ID_Supplier);
                tbl_MaintenanceSuppliersdb.Name = vm.maintenanceSuppliers.Name;
                tbl_MaintenanceSuppliersdb.Description = vm.maintenanceSuppliers.Description;
                tbl_MaintenanceSuppliersdb.ID_SupplierType = vm.maintenanceSuppliers.ID_SupplierType;
                tbl_MaintenanceSuppliersdb.ID_ObjStatus = vm.maintenanceSuppliers.ID_ObjStatus;
                tbl_MaintenanceSuppliersdb.Address1 = vm.maintenanceSuppliers.Address1;
                tbl_MaintenanceSuppliersdb.ID_CostCenter = vm.maintenanceSuppliers.ID_CostCenter;
                tbl_MaintenanceSuppliersdb.Address2 = vm.maintenanceSuppliers.Address2;
                tbl_MaintenanceSuppliersdb.HourlyCost = vm.maintenanceSuppliers.HourlyCost;
                tbl_MaintenanceSuppliersdb.ID_City = vm.maintenanceSuppliers.ID_City;
                tbl_MaintenanceSuppliersdb.Zip = vm.maintenanceSuppliers.Zip;
                tbl_MaintenanceSuppliersdb.ID_Country = vm.maintenanceSuppliers.ID_Country;
                tbl_MaintenanceSuppliersdb.ValidFrom = vm.maintenanceSuppliers.ValidFrom;
                tbl_MaintenanceSuppliersdb.ID_User = vm.maintenanceSuppliers.ID_User;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "MaintenanceSuppliers");
        }
        public ActionResult Edit(int Id)
        {
            var maintenanceSuppliers = _context.tbl_MaintenanceSuppliers.SingleOrDefault(c => c.ID_Supplier == Id);
            if (maintenanceSuppliers == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var supp_type = _context.tbl_MaintenanceSupplierTypes.ToList();
            var city = _context.Database.SqlQuery<General_query>("Select * from [Config].[Cities]").ToList();
            var country = _context.Database.SqlQuery<General_query>("Select * from [Config].[Countries]").ToList();
            var user = _context.Database.SqlQuery<General_query>("Select * from [Security].[Users]").ToList();
            var GenVm = new GeneralVM
            {
                CostCenters= _context.CostCenters.ToList(),
                supp_type = supp_type,
                city = city,
                country = country,
                ObjStatuses= _context.ObjStatuses.ToList(),
                user = user,
                maintenanceSuppliers = maintenanceSuppliers,

            };
            return View("Create", GenVm);
        }
        public ActionResult Delete(int Id)
        {
            _context.Database.ExecuteSqlCommand("Delete From Maintenance.Suppliers where ID_Supplier = " + Id + "");
            return RedirectToAction("Index");
        }
    }
}
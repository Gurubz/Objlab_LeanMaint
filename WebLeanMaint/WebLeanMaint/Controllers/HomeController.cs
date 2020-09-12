using WebLeanMaint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLeanMaint.ViewQueryModel;
using WebLeanMaint.ViewModels;

namespace WebLeanMaint.Controllers
{
    public class SessionTimeoutAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            if (HttpContext.Current.Session["UserID"] == null)
            {
                filterContext.Result = new RedirectResult("~/Home/Login");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }

    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Logout()
        {
            Session["UserID"] = null;
            return RedirectToAction("Login", "Home");
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult TreeView()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Logout", "Home");
            }
            var complete = _context.Database.SqlQuery<OrganizationCenters>("Select * From Config.OrganizationCenters ").ToList();
            var parent_list = _context.Database.SqlQuery<OrganizationCenters>("Select * From Config.OrganizationCenters where ID_Parent IS NULL ").ToList();
            var child_list = _context.Database.SqlQuery<OrganizationCenters>("Select * From Config.OrganizationCenters where ID_Parent IS NOT NULL ").ToList();
            var types_list = _context.Database.SqlQuery<OrganizationCenterTypes>("Select * From Config.OrganizationCenterTypes order by ID_OrganizationCenterType DESC ").ToList();
            var Treeviewmodel = new Treeviewmodel
            {
                complete = complete,
                parent_list = parent_list,
                child_list = child_list,
                types_list = types_list,
            };
            return View(Treeviewmodel);
        }
        [HttpPost]
        public ActionResult AddData(string name, string des, int option, string submit, int types)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Logout", "Home");
            }
            string id = Request["id"];
            //int idd = _context.Database.SqlQuery<int>("select ISNULL(Max(ID_OrganizationCenter),0)+1 from Config.OrganizationCenters").FirstOrDefault();
            if (submit == "Add")
            {
                if (option == 2)
                {
                    _context.Database.ExecuteSqlCommand("insert into Config.OrganizationCenters (Name,Description,ID_OrganizationCenterType,ID_ObjStatus,ID_Parent) values('" + name + "','" + des + "'," + types + ",'0'," + id + ")");
                }
                else
                {
                    _context.Database.ExecuteSqlCommand("insert into Config.OrganizationCenters (Name,Description,ID_OrganizationCenterType,ID_ObjStatus,ID_Parent) values('" + name + "','" + des + "'," + types + ",'0','0')");
                }
            }
            else if (submit == "Edit")
            {
                _context.Database.ExecuteSqlCommand("UPDATE  Config.OrganizationCenters set Name='" + name + "', Description = '" + des + "' where ID_OrganizationCenter =" + id + "");

            }
            else if (submit == "Delete")
            {
                _context.Database.ExecuteSqlCommand("DELETE FROM Config.OrganizationCenters where ID_OrganizationCenter =" + id + "");

            }
            return RedirectToAction("TreeView");
        }
        [HttpGet]
        public ActionResult GetData(int message)
        {
            var lst = _context.Database.SqlQuery<JoinQuery>("SELECT Config.OrganizationCenters.ID_OrganizationCenter, Config.OrganizationCenters.Name, Config.OrganizationCenters.Description, Config.OrganizationCenters.ID_Parent, Config.OrganizationCenterTypes.Name AS ID_ObjStatus, Config.OrganizationCenters.ID_OrganizationCenterType FROM Config.OrganizationCenters INNER JOIN Config.OrganizationCenterTypes ON Config.OrganizationCenters.ID_OrganizationCenterType = Config.OrganizationCenterTypes.ID_OrganizationCenterType where Config.OrganizationCenters.ID_OrganizationCenter=" + message + " ").ToList();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, ActionName("Login")]
        //[ValidateAntiForgeryToken]
        public ActionResult Save(string username, string password)
        {
            var status = _context.Database.SqlQuery<Models.Users>("Select * From Security.Users where Username='" + username + "' and Password='" + password + "' ").ToList();
            Session["UserID"] = "1";
            if (status.Count() == 0)
            {
                ViewBag.Fail = "Invalid Login Details";
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Dashboard");
            }
        }
    }
}
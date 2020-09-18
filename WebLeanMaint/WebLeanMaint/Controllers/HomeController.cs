using WebLeanMaint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLeanMaint.ViewQueryModel;
using WebLeanMaint.ViewModels;
using Data;
using System.EnterpriseServices;

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
			var Treeviewmodel = new TreeView
			{
				complete = complete,
				parent_list = parent_list,
				child_list = child_list,
				types_list = types_list,
			};
			return View(Treeviewmodel);
		}
		public ActionResult OrganizationCentersTree()
		{
			if (Session["UserID"] == null)
			{
				return RedirectToAction("Logout", "Home");
			}
			Data.Config.OrganizationCenters aCenters = new Data.Config.OrganizationCenters();
			aCenters.Load(string.Empty);
			var complete = aCenters.ToArray();
			aCenters.Load("ID_Parent IS NULL");
			var parent_list = aCenters.ToArray();
			aCenters.Load("ID_Parent IS NOT NULL");
			var child_list = aCenters.ToArray();
			Data.Config.OrganizationCenterTypes aTypes = new Data.Config.OrganizationCenterTypes();
			aTypes.Load(string.Empty, "ID_OrganizationCenterType ASC");
			var types_list = aTypes.ToArray();
			var oViewModel = new OrganizationCentersTree
			{
				complete = complete,
				parent_list = parent_list,
				child_list = child_list,
				types_list = types_list,
			};
			return View(oViewModel);
		}
		public ActionResult CostCentersTree()
		{
			if (Session["UserID"] == null)
			{
				return RedirectToAction("Logout", "Home");
			}
			Data.Accountancy.CostCenters aCenters = new Data.Accountancy.CostCenters();
			aCenters.Load(string.Empty);
			var complete = aCenters.ToArray();
			aCenters.Load("ID_Parent IS NULL");
			var parent_list = aCenters.ToArray();
			aCenters.Load("ID_Parent IS NOT NULL");
			var child_list = aCenters.ToArray();
			Data.Accountancy.CostCenterTypes aTypes = new Data.Accountancy.CostCenterTypes();
			aTypes.Load(string.Empty, "ID_CostCenterType ASC");
			var types_list = aTypes.ToArray();
			var oViewModel = new CostCentersTree
			{
				complete = complete,
				parent_list = parent_list,
				child_list = child_list,
				types_list = types_list,
			};
			return View(oViewModel);
		}

		public ActionResult GeographicCentersTree()
		{
			if (Session["UserID"] == null)
			{
				return RedirectToAction("Logout", "Home");
			}
			Data.Config.GeographicCenters aCenters = new Data.Config.GeographicCenters();
			aCenters.Load(string.Empty);
			var complete = aCenters.ToArray();
			aCenters.Load("ID_Parent IS NULL");
			var parent_list = aCenters.ToArray();
			aCenters.Load("ID_Parent IS NOT NULL");
			var child_list = aCenters.ToArray();
			Data.Config.GeographicCenterTypes aTypes = new Data.Config.GeographicCenterTypes();
			aTypes.Load(string.Empty, "ID_GeographicCenterType ASC");
			var types_list = aTypes.ToArray();
			var oViewModel = new GeographicCentersTree
			{
				complete = complete,
				parent_list = parent_list,
				child_list = child_list,
				types_list = types_list,
			};
			return View(oViewModel);
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
			var lst = _context.Database.SqlQuery<OrganizationCenterJoinQuery>("SELECT Config.OrganizationCenters.ID_OrganizationCenter, Config.OrganizationCenters.Name, Config.OrganizationCenters.Description, Config.OrganizationCenters.ID_Parent, Config.OrganizationCenterTypes.Name AS ID_ObjStatus, Config.OrganizationCenters.ID_OrganizationCenterType FROM Config.OrganizationCenters INNER JOIN Config.OrganizationCenterTypes ON Config.OrganizationCenters.ID_OrganizationCenterType = Config.OrganizationCenterTypes.ID_OrganizationCenterType where Config.OrganizationCenters.ID_OrganizationCenter=" + message + " ").ToList();
			return Json(lst, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public ActionResult AddOrganizationCenterData(string name, string des, int option, string submit, int types)
		{
			if (Session["UserID"] == null)
			{
				return RedirectToAction("Logout", "Home");
			}
			//int idd = _context.Database.SqlQuery<int>("select ISNULL(Max(ID_OrganizationCenter),0)+1 from Config.OrganizationCenters").FirstOrDefault();
			if (submit == "Add")
			{
				Data.Config.OrganizationCenter oCenter = new Data.Config.OrganizationCenter();
				oCenter.Name = name;
				oCenter.Description = des;
				oCenter.ID_ObjStatus = (int)Data.Config.ObjStatuseEnum.Active;
				oCenter.ID_OrganizationCenterType = types;
				if (option == 2)
				{
					oCenter.ID_Parent = int.Parse(Request["id"]);
					//_context.Database.ExecuteSqlCommand("insert into Config.OrganizationCenters (Name,Description,ID_OrganizationCenterType,ID_ObjStatus,ID_Parent) values('" + name + "','" + des + "'," + types + ",'0'," + id + ")");
				}
				else
				{
					oCenter.ID_Parent_HasValue = false;
					//_context.Database.ExecuteSqlCommand("insert into Config.OrganizationCenters (Name,Description,ID_OrganizationCenterType,ID_ObjStatus,ID_Parent) values('" + name + "','" + des + "'," + types + ",'0','0')");
				}
				Data.Config.OrganizationCenters.InsertOne(oCenter);
			}
			else if (submit == "Edit")
			{
				int nID = int.Parse(Request["id"]);
				Data.Config.OrganizationCenter oCenter = Data.Config.OrganizationCenters.LoadOne(nID);
				oCenter.Name = name;
				oCenter.Description = des;
				oCenter.ID_OrganizationCenterType = types;
				Data.Config.OrganizationCenters.UpdateOne(oCenter);
				//_context.Database.ExecuteSqlCommand("UPDATE  Config.OrganizationCenters set Name='" + name + "', Description = '" + des + "' where ID_OrganizationCenter =" + id + "");
			}
			else if (submit == "Delete")
			{
				int nID = int.Parse(Request["id"]);
				Data.Config.OrganizationCenter oCenter = Data.Config.OrganizationCenters.LoadOne(nID);
				Data.Config.OrganizationCenters.DeleteOne(oCenter);
				//_context.Database.ExecuteSqlCommand("DELETE FROM Config.OrganizationCenters where ID_OrganizationCenter =" + id + "");
			}
			return RedirectToAction("OrganizationCentersTree");
		}
		[HttpGet]
		public ActionResult GetOrganizationCenterData(int nID)
		{
			var lst = _context.Database.SqlQuery<OrganizationCenterJoinQuery>("SELECT Config.OrganizationCenters.ID_OrganizationCenter, Config.OrganizationCenters.Name, Config.OrganizationCenters.Description, Config.OrganizationCenters.ID_Parent, Config.OrganizationCenterTypes.Name AS ID_ObjStatus, Config.OrganizationCenters.ID_OrganizationCenterType FROM Config.OrganizationCenters INNER JOIN Config.OrganizationCenterTypes ON Config.OrganizationCenters.ID_OrganizationCenterType = Config.OrganizationCenterTypes.ID_OrganizationCenterType where Config.OrganizationCenters.ID_OrganizationCenter=" + nID + " ").ToList();
			return Json(lst, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public ActionResult AddCostCenterData(string name, string des, int option, string submit, int types)
		{
			if (Session["UserID"] == null)
			{
				return RedirectToAction("Logout", "Home");
			}
			//int idd = _context.Database.SqlQuery<int>("select ISNULL(Max(ID_CostCenter),0)+1 from Accountancy.CostCenters").FirstOrDefault();
			if (submit == "Add")
			{
				Data.Accountancy.CostCenter oCenter = new Data.Accountancy.CostCenter();
				oCenter.Name = name;
				oCenter.Description = des;
				oCenter.ID_ObjStatus = (int)Data.Config.ObjStatuseEnum.Active;
				oCenter.ID_CostCenterType = types;
				if (option == 2)
				{
					oCenter.ID_Parent = int.Parse(Request["id"]);
					//_context.Database.ExecuteSqlCommand("insert into Accountancy.CostCenters (Name,Description,ID_CostCenterType,ID_ObjStatus,ID_Parent) values('" + name + "','" + des + "'," + types + ",'0'," + id + ")");
				}
				else
				{
					oCenter.ID_Parent_HasValue = false;
					//_context.Database.ExecuteSqlCommand("insert into Accountancy.CostCenters (Name,Description,ID_CostCenterType,ID_ObjStatus,ID_Parent) values('" + name + "','" + des + "'," + types + ",'0','0')");
				}
				Data.Accountancy.CostCenters.InsertOne(oCenter);
			}
			else if (submit == "Edit")
			{
				int nID = int.Parse(Request["id"]);
				Data.Accountancy.CostCenter oCenter = Data.Accountancy.CostCenters.LoadOne(nID);
				oCenter.Name = name;
				oCenter.Description = des;
				oCenter.ID_CostCenterType = types;
				Data.Accountancy.CostCenters.UpdateOne(oCenter);
				//_context.Database.ExecuteSqlCommand("UPDATE  Accountancy.CostCenters set Name='" + name + "', Description = '" + des + "' where ID_CostCenter =" + id + "");
			}
			else if (submit == "Delete")
			{
				int nID = int.Parse(Request["id"]);
				Data.Accountancy.CostCenter oCenter = Data.Accountancy.CostCenters.LoadOne(nID);
				Data.Accountancy.CostCenters.DeleteOne(oCenter);
				//_context.Database.ExecuteSqlCommand("DELETE FROM Accountancy.CostCenters where ID_CostCenter =" + id + "");
			}
			return RedirectToAction("CostCentersTree");
		}
		[HttpGet]
		public ActionResult GetCostCenterData(int nID)
		{
			var lst = _context.Database.SqlQuery<CostCenterJoinQuery>("SELECT Accountancy.CostCenters.ID_CostCenter, Accountancy.CostCenters.Name, Accountancy.CostCenters.Description, Accountancy.CostCenters.ID_Parent, Accountancy.CostCenterTypes.Name AS ID_ObjStatus, Accountancy.CostCenters.ID_CostCenterType FROM Accountancy.CostCenters INNER JOIN Accountancy.CostCenterTypes ON Accountancy.CostCenters.ID_CostCenterType = Accountancy.CostCenterTypes.ID_CostCenterType where Accountancy.CostCenters.ID_CostCenter=" + nID + " ").ToList();
			return Json(lst, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public ActionResult AddGeographicCenterData(int option, string name, string des, string lat, string lon, string submit, int types)
		{
			if (Session["UserID"] == null)
			{
				return RedirectToAction("Logout", "Home");
			}
			//int idd = _context.Database.SqlQuery<int>("select ISNULL(Max(ID_GeographicCenter),0)+1 from Config.GeographicCenters").FirstOrDefault();
			if (submit == "Add")
			{
				Data.Config.GeographicCenter oCenter = new Data.Config.GeographicCenter();
				oCenter.Name = name;
				oCenter.Description = des;
				if (string.IsNullOrEmpty(lat) == false && string.IsNullOrEmpty(lon) == false)
				{
					oCenter.Latitude = double.Parse(lat);
					oCenter.Longitude = double.Parse(lon);
				}
				oCenter.ID_ObjStatus = (int)Data.Config.ObjStatuseEnum.Active;
				oCenter.ID_GeographicCenterType = types;
				if (option == 2)
				{
					oCenter.ID_Parent = int.Parse(Request["id"]);
					//_context.Database.ExecuteSqlCommand("insert into Config.GeographicCenters (Name,Description,ID_GeographicCenterType,ID_ObjStatus,ID_Parent) values('" + name + "','" + des + "'," + types + ",'0'," + id + ")");
				}
				else
				{
					oCenter.ID_Parent_HasValue = false;
					//_context.Database.ExecuteSqlCommand("insert into Config.GeographicCenters (Name,Description,ID_GeographicCenterType,ID_ObjStatus,ID_Parent) values('" + name + "','" + des + "'," + types + ",'0','0')");
				}
				Data.Config.GeographicCenters.InsertOne(oCenter);
			}
			else if (submit == "Edit")
			{
				int nID = int.Parse(Request["id"]);
				Data.Config.GeographicCenter oCenter = Data.Config.GeographicCenters.LoadOne(nID);
				oCenter.Name = name;
				oCenter.Description = des;
				if (string.IsNullOrEmpty(lat) == false && string.IsNullOrEmpty(lon) == false)
				{
					oCenter.Latitude = double.Parse(lat);
					oCenter.Longitude = double.Parse(lon);
				}
				oCenter.ID_GeographicCenterType = types;
				Data.Config.GeographicCenters.UpdateOne(oCenter);
				//_context.Database.ExecuteSqlCommand("UPDATE  Config.GeographicCenters set Name='" + name + "', Description = '" + des + "' where ID_GeographicCenter =" + id + "");
			}
			else if (submit == "Delete")
			{
				int nID = int.Parse(Request["id"]);
				Data.Config.GeographicCenter oCenter = Data.Config.GeographicCenters.LoadOne(nID);
				Data.Config.GeographicCenters.DeleteOne(oCenter);
				//_context.Database.ExecuteSqlCommand("DELETE FROM Config.GeographicCenters where ID_GeographicCenter =" + id + "");
			}
			return RedirectToAction("GeographicCentersTree");
		}
		[HttpGet]
		public ActionResult GetGeographicCenterData(int nID)
		{
			// var lst = _context.Database.SqlQuery<GeographicCenterJoinQuery>("SELECT Config.GeographicCenters.ID_GeographicCenter, Config.GeographicCenters.Name, Config.GeographicCenters.Description, Config.GeographicCenters.ID_Parent, Config.GeographicCenterTypes.Name AS ID_ObjStatus, Config.GeographicCenters.ID_GeographicCenterType FROM Config.GeographicCenters INNER JOIN Config.GeographicCenterTypes ON Config.GeographicCenters.ID_GeographicCenterType = Config.GeographicCenterTypes.ID_GeographicCenterType where Config.GeographicCenters.ID_GeographicCenter=" + nID + " ").ToList();
			var lst = _context.Database.SqlQuery<GeographicCenterJoinQuery>(
				"SELECT GC.*, GCT.Name AS TypeName " +
				"FROM Config.GeographicCenters GC " +
				"INNER JOIN Config.GeographicCenterTypes GCT ON GC.ID_GeographicCenterType = GCT.ID_GeographicCenterType " +
				"WHERE GC.ID_GeographicCenter = " + EntitiesManagerBase.UTI_ValueToSql(nID)).ToList();
			return Json(lst, JsonRequestBehavior.AllowGet);
		}

		[HttpPost, ActionName("Login")]
		//[ValidateAntiForgeryToken]
		public ActionResult Save(string username, string password)
		{
			Data.Security.Users aUsers = new Data.Security.Users();
			aUsers.Load($"Username={EntitiesManagerBase.UTI_ValueToSql(username)} AND Password={EntitiesManagerBase.UTI_ValueToSql(password)}");
			if (aUsers.Count == 0)
			{
				ViewBag.Fail = "Invalid Login Details";
				return View();
			}
			else
			{
				Session["UserID"] = aUsers[0].ID_User;
				return RedirectToAction("Index", "Dashboard");
			}
		}
	}
}
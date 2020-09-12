using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebLeanMaint.Controllers
{
    [SessionTimeout]
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Logout","Home");
            }
                return View();
        }
    }
}
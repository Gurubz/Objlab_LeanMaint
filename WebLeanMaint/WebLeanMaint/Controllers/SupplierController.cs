using WebLeanMaint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebLeanMaint.Controllers
{
	[SessionTimeout]
	public class SupplierController : Controller
	{
		private ApplicationDbContext _context;

		public SupplierController()
		{
			_context = new ApplicationDbContext();
		}
		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}
		// GET: Supplier
		public ActionResult Index()
		{
			if (Session["UserID"] == null)
			{
				return RedirectToAction("Logout", "Home");
			}
			return View();
		}
	}
}
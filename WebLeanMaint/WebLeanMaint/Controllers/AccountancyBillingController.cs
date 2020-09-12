using WebLeanMaint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebLeanMaint.Controllers
{
    [SessionTimeout]
    public class AccountancyBillingController : Controller
    {
        private ApplicationDbContext _context;

        public AccountancyBillingController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: AccountancyBilling
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Logout", "Home");
            }
            //var list = _context.Database.SqlQuery<AccountancyBilling>("SELECT * From AccountancyBillings").ToList();
            var list = _context.tbl_AccountancyBilling.ToList();
            return View(list);
        }
        public ActionResult Create()
        {

             return View();
        }
        [HttpPost]
        public ActionResult Save(AccountancyBilling AccountancyBilling)
        {
            if (AccountancyBilling.ID_Billing == 0)
            {
             _context.tbl_AccountancyBilling.Add(AccountancyBilling);
            }
            else
            {
            var accountancyBillingdb = _context.tbl_AccountancyBilling.Single(c => c.ID_Billing == AccountancyBilling.ID_Billing);
                accountancyBillingdb.ID_Operator = AccountancyBilling.ID_Operator;
                accountancyBillingdb.Activation = AccountancyBilling.Activation;
                accountancyBillingdb.End = AccountancyBilling.End;
                accountancyBillingdb.HourlyCost = AccountancyBilling.HourlyCost;
                accountancyBillingdb.Year = AccountancyBilling.Year;
                accountancyBillingdb.Month = AccountancyBilling.Month;
                accountancyBillingdb.StartDay = AccountancyBilling.StartDay;
                accountancyBillingdb.EndDay = AccountancyBilling.EndDay;
                accountancyBillingdb.Value = AccountancyBilling.Value;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "AccountancyBilling");
        }
        public ActionResult Edit(int Id)
        {
            var bank = _context.tbl_AccountancyBilling.SingleOrDefault(c => c.ID_Billing == Id);
            if (bank == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return View("Create", bank);
        }
        public ActionResult Delete(int Id)
        {
            _context.Database.ExecuteSqlCommand("Delete From AccountancyBillings where ID_Billing = " + Id + "");
            return RedirectToAction("Index");
        }
    }
}
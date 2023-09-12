using ATMEntryPoint.Models;
using ModelsAndData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelsAndData.Controllers {
    public class TransactionController : Controller {

        private  ApplicationDbContext db = new ApplicationDbContext();

        // GET: Transaction/Deposit
        public ActionResult Deposit() {
            return View();
        }
        [HttpPost]
        public ActionResult Deposit(Transaction transaction) {
            if (ModelState.IsValid) {
                //db.Entry(transaction.CheckingAccount).State = System.Data.Entity.EntityState.Unchanged;

                var userId = db.Users.Where(u => u.Email == User.Identity.Name).FirstOrDefault().Id;
                var checkingAccount = db.CheckingAccounts.Where(c => c.ApplicationUserId == userId).FirstOrDefault();
                transaction.CheckingAccountId = checkingAccount.Id;
                db.Transactions.Add(transaction);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
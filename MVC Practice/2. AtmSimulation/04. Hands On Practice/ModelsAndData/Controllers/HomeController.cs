using ATMEntryPoint.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATMEntryPoint.Controllers {

    //[Authorize]
    public class HomeController : Controller {
        private ApplicationDbContext db = new ApplicationDbContext();
        //[Authorize]
        public ActionResult Index() {
            //var usrId = User.Identity.GetUserId();
            //var checkingAccountId = db.CheckingAccounts.Where(x => x.ApplicationUserId == usrId).First().Id;
            //ViewBag.CheckingAccountId = checkingAccountId;
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // Serial ActionMethod
        public ActionResult Serial(string letterCase) {

            var serial = "ASPNET-ATM-SERIAL1";
            if (letterCase == "lower") {
                return Content(serial.ToLower());
            }
            return Content(serial);

        }

    }
}
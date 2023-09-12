using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATMEntryPoint.Controllers
{
    public class HomeController : Controller
    {
        // Get /home/index
        public ActionResult Index()
        {
            //throw new StackOverflowException();// filters example
            return View();
            //return PartialView(); // it removes the view from _layout file 
        }

        // Get /home/about
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View(); // so it doesn't go looking for some other view
        }

        public ActionResult Contact()
        {
            ViewBag.TheMessage = "Having Trouble ? Send us A Message";
            return View();
        }

        // method with post Action Selector
        [HttpPost]
        public ActionResult Contact(string msg) {
            // TODO :  sed message to HQ
            ViewBag.TheMessage = "Thanks, we Got your messsage";
            return View();
        }


        // ActionMethod SHIT
        //public ActionResult Shit() {

        //    return View("About"); //View();//  this bitch gives error cause Shit.cshtml doesn't exist
        //}

        // Shit Method for Post and Route with RequestQery
        public ActionResult Shit(string shitCase) {

            var shit = "ASPNET-ATM-SHIT1";
            if (shitCase == "lower") {
                return Content(shit.ToLower());
            }
            //return Content(shit);
            return Json(new { name = "shit", value = shit }, JsonRequestBehavior.AllowGet);
        }

        // Serial ActionMethod
        public ActionResult Serial(string letterCase) {

            var serial = "ASPNET-ATM-SERIAL1";
            if (letterCase =="lower") {
                return Content(serial.ToLower());
            }
            return Content(serial);
        }
    }
}
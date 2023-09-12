using ExploreCalifornia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExploreCalifornia.Controllers
{
    public class TouraController : Controller
    {
        private MyDbContext db = new MyDbContext();
        // GET: Tour
        public ActionResult Index()
        {
            return View();
        }

        // GET: Tour/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tour/Create  // this will be used to add a tour to the user
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tour/Create
        [HttpPost]
        public ActionResult Create(Tour tour)
        {
            try
            {
                // TODO: Add insert logic here  will be used to add things to tour to database
                db.Tours.Add(tour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tour/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tour/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tour/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tour/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

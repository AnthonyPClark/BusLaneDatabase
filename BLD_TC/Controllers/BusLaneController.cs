using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLD_TC.Models;
using BLD_TC.Entitities;

namespace BLD_TC.Controllers
{
    public class BusLaneController : Controller
    {
        private BusLaneDbContext db = new BusLaneDbContext();

        //
        // GET: /BusLane/

        public ActionResult Index()
        {
            return View(db.buslanes.ToList());
        }


        [HttpPost]
        public ActionResult Index(string searchString)
        {
            var buslanes = from b in db.buslanes
                         select b;

            if (!String.IsNullOrEmpty(searchString))
            {
                buslanes = buslanes.Where(s => s.Description.Contains(searchString));
            }

            return View(buslanes); 
        }

        //
        // GET: /BusLane/Details/5

        public ActionResult Details(int id = 0)
        {
            BusLane buslane = db.buslanes.Find(id);
            if (buslane == null)
            {
                return HttpNotFound();
            }
            return View(buslane);
        }

        //
        // GET: /BusLane/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /BusLane/Create

        [HttpPost]
        public ActionResult Create(BusLaneEditModel buslaneeditmodel)
        {
            if (!ModelState.IsValid)
            {
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        System.Console.Write(error.ToString());
                    }
                }
            }
            if (ModelState.IsValid)
            {
                BusLane buslane = new BusLane
                {
                    implementationDate = buslaneeditmodel.implementationDate,
                    startTime = buslaneeditmodel.startTime,
                    endTime = buslaneeditmodel.endTime,
                    vehicles = new List<Vehicle>(),
                    length = buslaneeditmodel.length,
                    Description = buslaneeditmodel.Description,
                    removed = false,
                    removedBy = null
                };
                db.buslanes.Add(buslane);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(buslaneeditmodel);
        }

        //
        // GET: /BusLane/Edit/5

        public ActionResult Edit(int id = 0)
        {
            BusLane buslane = db.buslanes.Find(id);
            if (buslane == null)
            {
                return HttpNotFound();
            }
            return View(buslane);
        }

        //
        // POST: /BusLane/Edit/5

        [HttpPost]
        public ActionResult Edit(BusLaneEditModel buslaneeditmodel)
        {
            if (!ModelState.IsValid)
            {
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        System.Console.Write(error.ToString());
                    }
                }
            }
            if (ModelState.IsValid)
            {
                BusLane buslane = new BusLane
                {
                    implementationDate = buslaneeditmodel.implementationDate,
                    startTime = buslaneeditmodel.startTime,
                    endTime = buslaneeditmodel.endTime,
                    vehicles = new List<Vehicle>(),
                    length = buslaneeditmodel.length,
                    Description = buslaneeditmodel.Description,
                    removed = false,
                    removedBy = null
                };
                db.Entry(buslane).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(buslaneeditmodel);
        }

        //
        // GET: /BusLane/Delete/5

        public ActionResult Delete(int id = 0)
        {
            BusLaneEditModel buslaneeditmodel = db.BusLaneEditModels.Find(id);
            if (buslaneeditmodel == null)
            {
                return HttpNotFound();
            }
            return View(buslaneeditmodel);
        }

        //
        // POST: /BusLane/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            BusLane buslane = db.buslanes.Find(id);
            //db.buslanes.Remove(buslane);
            buslane.removed = true;
            buslane.removedBy = "Tony Clark";
            db.Entry(buslane).State = EntityState.Modified;    
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
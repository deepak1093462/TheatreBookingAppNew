using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheatreBookingAppNew.Models;

namespace TheatreBookingAppNew.Controllers
{
    public class TheatreController : Controller
    {
        private TheatreBookingDBEntities db = new TheatreBookingDBEntities();

        // GET: Theatre
        public ActionResult Index()
        {
            return View(db.TheatreTables.ToList());
        }

        // GET: Theatre/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheatreTable theatreTable = db.TheatreTables.Find(id);
            if (theatreTable == null)
            {
                return HttpNotFound();
            }
            return View(theatreTable);
        }

        // GET: Theatre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Theatre/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TheatreId,TheatreName,EntryPerUser")] TheatreTable theatreTable)
        {
            if (ModelState.IsValid)
            {
                db.TheatreTables.Add(theatreTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(theatreTable);
        }

        // GET: Theatre/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheatreTable theatreTable = db.TheatreTables.Find(id);
            if (theatreTable == null)
            {
                return HttpNotFound();
            }
            return View(theatreTable);
        }

        // POST: Theatre/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TheatreId,TheatreName,EntryPerUser")] TheatreTable theatreTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(theatreTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(theatreTable);
        }

        // GET: Theatre/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheatreTable theatreTable = db.TheatreTables.Find(id);
            if (theatreTable == null)
            {
                return HttpNotFound();
            }
            return View(theatreTable);
        }

        // POST: Theatre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TheatreTable theatreTable = db.TheatreTables.Find(id);
            db.TheatreTables.Remove(theatreTable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

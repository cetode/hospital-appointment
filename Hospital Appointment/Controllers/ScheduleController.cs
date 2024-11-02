using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hospital_Appointment.Models;

namespace Hospital_Appointment.Controllers
{
    public class ScheduleController : Controller
    {
        private APPIONTMENTDBEntities db = new APPIONTMENTDBEntities();

        // GET: /Schedule/
        public ActionResult Index()
        {
            var tblschedules = db.tblSchedules.Include(t => t.tblAdmin);
            return View(tblschedules.ToList());
        }

        // GET: /Schedule/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSchedule tblschedule = db.tblSchedules.Find(id);
            if (tblschedule == null)
            {
                return HttpNotFound();
            }
            return View(tblschedule);
        }

        // GET: /Schedule/Create
        public ActionResult Create()
        {
            ViewBag.AdminID = new SelectList(db.tblAdmins, "AdminID", "Name");
            return View();
        }

        // POST: /Schedule/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ScheduleID,Date,AvailableTime,AdminID")] tblSchedule tblschedule)
        {
            if (ModelState.IsValid)
            {
                db.tblSchedules.Add(tblschedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdminID = new SelectList(db.tblAdmins, "AdminID", "Name", tblschedule.AdminID);
            return View(tblschedule);
        }

        // GET: /Schedule/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSchedule tblschedule = db.tblSchedules.Find(id);
            if (tblschedule == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdminID = new SelectList(db.tblAdmins, "AdminID", "Name", tblschedule.AdminID);
            return View(tblschedule);
        }

        // POST: /Schedule/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ScheduleID,Date,AvailableTime,AdminID")] tblSchedule tblschedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblschedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdminID = new SelectList(db.tblAdmins, "AdminID", "Name", tblschedule.AdminID);
            return View(tblschedule);
        }

        // GET: /Schedule/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSchedule tblschedule = db.tblSchedules.Find(id);
            if (tblschedule == null)
            {
                return HttpNotFound();
            }
            return View(tblschedule);
        }

        // POST: /Schedule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblSchedule tblschedule = db.tblSchedules.Find(id);
            db.tblSchedules.Remove(tblschedule);
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

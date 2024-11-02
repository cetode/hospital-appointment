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
    public class AppointmentController : Controller
    {
        private APPIONTMENTDBEntities db = new APPIONTMENTDBEntities();

        // GET: /Appointment/
        public ActionResult Index()
        {
            var tblappointments = db.tblAppointments.Include(t => t.tblPayment);
            return View(tblappointments.ToList());
        }

        // GET: /Appointment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAppointment tblappointment = db.tblAppointments.Find(id);
            if (tblappointment == null)
            {
                return HttpNotFound();
            }
            return View(tblappointment);
        }

        // GET: /Appointment/Create
        public ActionResult Create()
        {
            ViewBag.PaymentID = new SelectList(db.tblPayments, "PaymentID", "Amount");
            return View();
        }

        // POST: /Appointment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="AppointmentID,Date,Time,Duration,Pending,Confirmed,Cancelled,PaymentID")] tblAppointment tblappointment)
        {
            if (ModelState.IsValid)
            {
                db.tblAppointments.Add(tblappointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PaymentID = new SelectList(db.tblPayments, "PaymentID", "Amount", tblappointment.PaymentID);
            return View(tblappointment);
        }

        // GET: /Appointment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAppointment tblappointment = db.tblAppointments.Find(id);
            if (tblappointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.PaymentID = new SelectList(db.tblPayments, "PaymentID", "Amount", tblappointment.PaymentID);
            return View(tblappointment);
        }

        // POST: /Appointment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="AppointmentID,Date,Time,Duration,Pending,Confirmed,Cancelled,PaymentID")] tblAppointment tblappointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblappointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PaymentID = new SelectList(db.tblPayments, "PaymentID", "Amount", tblappointment.PaymentID);
            return View(tblappointment);
        }

        // GET: /Appointment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAppointment tblappointment = db.tblAppointments.Find(id);
            if (tblappointment == null)
            {
                return HttpNotFound();
            }
            return View(tblappointment);
        }

        // POST: /Appointment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblAppointment tblappointment = db.tblAppointments.Find(id);
            db.tblAppointments.Remove(tblappointment);
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

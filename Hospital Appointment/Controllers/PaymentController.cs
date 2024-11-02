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
    public class PaymentController : Controller
    {
        private APPIONTMENTDBEntities db = new APPIONTMENTDBEntities();

        // GET: /Payment/
        public ActionResult Index()
        {
            var tblpayments = db.tblPayments.Include(t => t.tblUser);
            return View(tblpayments.ToList());
        }

        // GET: /Payment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPayment tblpayment = db.tblPayments.Find(id);
            if (tblpayment == null)
            {
                return HttpNotFound();
            }
            return View(tblpayment);
        }

        // GET: /Payment/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.tblUsers, "UserID", "Name");
            return View();
        }

        // POST: /Payment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PaymentID,Amount,PaymentMethod,UserID")] tblPayment tblpayment)
        {
            if (ModelState.IsValid)
            {
                db.tblPayments.Add(tblpayment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.tblUsers, "UserID", "Name", tblpayment.UserID);
            return View(tblpayment);
        }

        // GET: /Payment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPayment tblpayment = db.tblPayments.Find(id);
            if (tblpayment == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.tblUsers, "UserID", "Name", tblpayment.UserID);
            return View(tblpayment);
        }

        // POST: /Payment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PaymentID,Amount,PaymentMethod,UserID")] tblPayment tblpayment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblpayment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.tblUsers, "UserID", "Name", tblpayment.UserID);
            return View(tblpayment);
        }

        // GET: /Payment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPayment tblpayment = db.tblPayments.Find(id);
            if (tblpayment == null)
            {
                return HttpNotFound();
            }
            return View(tblpayment);
        }

        // POST: /Payment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPayment tblpayment = db.tblPayments.Find(id);
            db.tblPayments.Remove(tblpayment);
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

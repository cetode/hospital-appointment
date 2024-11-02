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
    public class UserController : Controller
    {
        private APPIONTMENTDBEntities db = new APPIONTMENTDBEntities();

        // GET: /User/
        public ActionResult Index()
        {
            return View(db.tblUsers.ToList());
        }

        // GET: /User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUser tbluser = db.tblUsers.Find(id);
            if (tbluser == null)
            {
                return HttpNotFound();
            }
            return View(tbluser);
        }

        // GET: /User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="UserID,Name,PhoneNumber,Address,MedicalHistory")] tblUser tbluser)
        {
            if (ModelState.IsValid)
            {
                db.tblUsers.Add(tbluser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbluser);
        }

        // GET: /User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUser tbluser = db.tblUsers.Find(id);
            if (tbluser == null)
            {
                return HttpNotFound();
            }
            return View(tbluser);
        }

        // POST: /User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="UserID,Name,PhoneNumber,Address,MedicalHistory")] tblUser tbluser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbluser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbluser);
        }

        // GET: /User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUser tbluser = db.tblUsers.Find(id);
            if (tbluser == null)
            {
                return HttpNotFound();
            }
            return View(tbluser);
        }

        // POST: /User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblUser tbluser = db.tblUsers.Find(id);
            db.tblUsers.Remove(tbluser);
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

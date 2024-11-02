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
    public class AdminController : Controller
    {
        private APPIONTMENTDBEntities db = new APPIONTMENTDBEntities();

        // GET: /Admin/
        public ActionResult Index()
        {
            var tbladmins = db.tblAdmins.Include(t => t.tblRole);
            return View(tbladmins.ToList());
        }

        // GET: /Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAdmin tbladmin = db.tblAdmins.Find(id);
            if (tbladmin == null)
            {
                return HttpNotFound();
            }
            return View(tbladmin);
        }

        // GET: /Admin/Create
        public ActionResult Create()
        {
            ViewBag.RoleID = new SelectList(db.tblRoles, "RoleID", "Name");
            return View();
        }

        // POST: /Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="AdminID,Name,PhoneNumber,Email,Address,RoleID")] tblAdmin tbladmin)
        {
            if (ModelState.IsValid)
            {
                db.tblAdmins.Add(tbladmin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleID = new SelectList(db.tblRoles, "RoleID", "Name", tbladmin.RoleID);
            return View(tbladmin);
        }

        // GET: /Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAdmin tbladmin = db.tblAdmins.Find(id);
            if (tbladmin == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleID = new SelectList(db.tblRoles, "RoleID", "Name", tbladmin.RoleID);
            return View(tbladmin);
        }

        // POST: /Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="AdminID,Name,PhoneNumber,Email,Address,RoleID")] tblAdmin tbladmin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbladmin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleID = new SelectList(db.tblRoles, "RoleID", "Name", tbladmin.RoleID);
            return View(tbladmin);
        }

        // GET: /Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAdmin tbladmin = db.tblAdmins.Find(id);
            if (tbladmin == null)
            {
                return HttpNotFound();
            }
            return View(tbladmin);
        }

        // POST: /Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblAdmin tbladmin = db.tblAdmins.Find(id);
            db.tblAdmins.Remove(tbladmin);
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

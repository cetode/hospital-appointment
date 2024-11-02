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
    public class RoleController : Controller
    {
        private APPIONTMENTDBEntities db = new APPIONTMENTDBEntities();

        // GET: /Role/
        public ActionResult Index()
        {
            return View(db.tblRoles.ToList());
        }

        // GET: /Role/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRole tblrole = db.tblRoles.Find(id);
            if (tblrole == null)
            {
                return HttpNotFound();
            }
            return View(tblrole);
        }

        // GET: /Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Role/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="RoleID,Name,CanCreate,CanRead,CanUpdate,CanDelete,Receptionist,Doctor")] tblRole tblrole)
        {
            if (ModelState.IsValid)
            {
                db.tblRoles.Add(tblrole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblrole);
        }

        // GET: /Role/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRole tblrole = db.tblRoles.Find(id);
            if (tblrole == null)
            {
                return HttpNotFound();
            }
            return View(tblrole);
        }

        // POST: /Role/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="RoleID,Name,CanCreate,CanRead,CanUpdate,CanDelete,Receptionist,Doctor")] tblRole tblrole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblrole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblrole);
        }

        // GET: /Role/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRole tblrole = db.tblRoles.Find(id);
            if (tblrole == null)
            {
                return HttpNotFound();
            }
            return View(tblrole);
        }

        // POST: /Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblRole tblrole = db.tblRoles.Find(id);
            db.tblRoles.Remove(tblrole);
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

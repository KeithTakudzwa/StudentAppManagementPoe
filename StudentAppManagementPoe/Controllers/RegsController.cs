using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentAppManagementPoe.Models;

namespace StudentAppManagementPoe.Controllers
{
    public class RegsController : Controller
    {
        private StudentInfoEntities db = new StudentInfoEntities();

        // GET: Regs
        public ActionResult Index()
        {
            var regs = db.Regs.Include(r => r.Module).Include(r => r.SelfStudy);
            return View(regs.ToList());
        }

        // GET: Regs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reg reg = db.Regs.Find(id);
            if (reg == null)
            {
                return HttpNotFound();
            }
            return View(reg);
        }

        // GET: Regs/Create
        public ActionResult Create()
        {
            ViewBag.Student_id = new SelectList(db.Modules, "Course_Code", "Monday");
            ViewBag.Student_id = new SelectList(db.SelfStudies, "Module_Code", "Module_Name");
            return View();
        }

        // POST: Regs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Student_id,First_Name,Last_name,Course_Code,Module_Code")] Reg reg)
        {
            if (ModelState.IsValid)
            {
                db.Regs.Add(reg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Student_id = new SelectList(db.Modules, "Course_Code", "Monday", reg.Student_id);
            ViewBag.Student_id = new SelectList(db.SelfStudies, "Module_Code", "Module_Name", reg.Student_id);
            return View(reg);
        }

        // GET: Regs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reg reg = db.Regs.Find(id);
            if (reg == null)
            {
                return HttpNotFound();
            }
            ViewBag.Student_id = new SelectList(db.Modules, "Course_Code", "Monday", reg.Student_id);
            ViewBag.Student_id = new SelectList(db.SelfStudies, "Module_Code", "Module_Name", reg.Student_id);
            return View(reg);
        }

        // POST: Regs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Student_id,First_Name,Last_name,Course_Code,Module_Code")] Reg reg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Student_id = new SelectList(db.Modules, "Course_Code", "Monday", reg.Student_id);
            ViewBag.Student_id = new SelectList(db.SelfStudies, "Module_Code", "Module_Name", reg.Student_id);
            return View(reg);
        }

        // GET: Regs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reg reg = db.Regs.Find(id);
            if (reg == null)
            {
                return HttpNotFound();
            }
            return View(reg);
        }

        // POST: Regs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Reg reg = db.Regs.Find(id);
            db.Regs.Remove(reg);
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

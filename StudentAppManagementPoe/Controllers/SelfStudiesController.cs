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
    public class SelfStudiesController : Controller
    {
        private StudentInfoEntities db = new StudentInfoEntities();

        // GET: SelfStudies
        public ActionResult Index()
        {
            var selfStudies = db.SelfStudies.Include(s => s.Reg);
            return View(selfStudies.ToList());
        }

        // GET: SelfStudies/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SelfStudy selfStudy = db.SelfStudies.Find(id);
            if (selfStudy == null)
            {
                return HttpNotFound();
            }
            return View(selfStudy);
        }

        // GET: SelfStudies/Create
        public ActionResult Create()
        {
            ViewBag.Module_Code = new SelectList(db.Regs, "Student_id", "First_Name");
            ViewBag.test = "Not Submitted";

            return View();
        }

        // POST: SelfStudies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Module_Code,Module_Name,Module_Credit,Class_Hours_Per_Week,StartDate")] SelfStudy selfStudy)
        {
            if (ModelState.IsValid)
            {
                //db.SelfStudies.Add(selfStudy);
                //db.SaveChanges();
                RecordingHours recordingHours = new RecordingHours();
                recordingHours.recordingHours(selfStudy.Module_Code, selfStudy.Module_Name, selfStudy.Module_Credit, selfStudy.Class_Hours_Per_Week, selfStudy.StartDate);
                ViewBag.test = "Submitted";
            }

            ViewBag.Module_Code = new SelectList(db.Regs, "Student_id", selfStudy.Module_Code);
            return View(selfStudy);
        }

        // GET: SelfStudies/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SelfStudy selfStudy = db.SelfStudies.Find(id);
            if (selfStudy == null)
            {
                return HttpNotFound();
            }
            ViewBag.Module_Code = new SelectList(db.Regs, "Student_id", "First_Name", selfStudy.Module_Code);
            return View(selfStudy);
        }

        // POST: SelfStudies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Module_Code,Module_Name,Module_Credit,Class_Hours_Per_Week,StartDate")] SelfStudy selfStudy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(selfStudy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Module_Code = new SelectList(db.Regs, "Student_id", selfStudy.Module_Code);
            return View(selfStudy);
        }

        // GET: SelfStudies/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SelfStudy selfStudy = db.SelfStudies.Find(id);
            if (selfStudy == null)
            {
                return HttpNotFound();
            }
            return View(selfStudy);
        }

        // POST: SelfStudies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SelfStudy selfStudy = db.SelfStudies.Find(id);
            db.SelfStudies.Remove(selfStudy);
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
        public ActionResult ViewDetails()
        {
            return View();
        }
        public ActionResult Display()
        {
            
            return View();
        }
    }

}

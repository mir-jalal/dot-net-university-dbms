using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityWebDBMS.Models;

namespace UniversityWebDBMS.Controllers
{
    public class AcademicInfoesController : Controller
    {
        private UniModel db = new UniModel();

        // GET: AcademicInfoes
        public ActionResult Index()
        {
            var academicInfos = db.AcademicInfos.Include(a => a.Student);
            return View(academicInfos.ToList());
        }

        // GET: AcademicInfoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicInfo academicInfo = db.AcademicInfos.Find(id);
            if (academicInfo == null)
            {
                return HttpNotFound();
            }
            return View(academicInfo);
        }

        // GET: AcademicInfoes/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(db.Students, "id", "name");
            return View();
        }

        // POST: AcademicInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,entrance,status,advisor,dis_topic,exam_score,state_funded,presidential_scholarship,registration_date")] AcademicInfo academicInfo)
        {
            if (ModelState.IsValid)
            {
                db.AcademicInfos.Add(academicInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id = new SelectList(db.Students, "id", "name", academicInfo.id);
            return View(academicInfo);
        }

        // GET: AcademicInfoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicInfo academicInfo = db.AcademicInfos.Find(id);
            if (academicInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = new SelectList(db.Students, "id", "name", academicInfo.id);
            return View(academicInfo);
        }

        // POST: AcademicInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,entrance,status,advisor,dis_topic,exam_score,state_funded,presidential_scholarship,registration_date")] AcademicInfo academicInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(academicInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id = new SelectList(db.Students, "id", "name", academicInfo.id);
            return View(academicInfo);
        }

        // GET: AcademicInfoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicInfo academicInfo = db.AcademicInfos.Find(id);
            if (academicInfo == null)
            {
                return HttpNotFound();
            }
            return View(academicInfo);
        }

        // POST: AcademicInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AcademicInfo academicInfo = db.AcademicInfos.Find(id);
            db.AcademicInfos.Remove(academicInfo);
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

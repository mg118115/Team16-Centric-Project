using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Team_16_Centric_Project.DAL;
using Team_16_Centric_Project.Models;

namespace Team_16_Centric_Project.Controllers
{
    public class ValuesRecognitionsController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: ValuesRecognitions
        public ActionResult Index()
        {
            return View(db.ValuesRecognitions.ToList());
        }

        // GET: ValuesRecognitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValuesRecognition valuesRecognition = db.ValuesRecognitions.Find(id);
            if (valuesRecognition == null)
            {
                return HttpNotFound();
            }
            return View(valuesRecognition);
        }

        // GET: ValuesRecognitions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ValuesRecognitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "valuesRecognitionID,description")] ValuesRecognition valuesRecognition)
        {
            if (ModelState.IsValid)
            {
                db.ValuesRecognitions.Add(valuesRecognition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(valuesRecognition);
        }

        // GET: ValuesRecognitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValuesRecognition valuesRecognition = db.ValuesRecognitions.Find(id);
            if (valuesRecognition == null)
            {
                return HttpNotFound();
            }
            return View(valuesRecognition);
        }

        // POST: ValuesRecognitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "valuesRecognitionID,description")] ValuesRecognition valuesRecognition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valuesRecognition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(valuesRecognition);
        }

        // GET: ValuesRecognitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValuesRecognition valuesRecognition = db.ValuesRecognitions.Find(id);
            if (valuesRecognition == null)
            {
                return HttpNotFound();
            }
            return View(valuesRecognition);
        }

        // POST: ValuesRecognitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ValuesRecognition valuesRecognition = db.ValuesRecognitions.Find(id);
            db.ValuesRecognitions.Remove(valuesRecognition);
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

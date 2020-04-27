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
    public class EmployeeRecognitionsController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: EmployeeRecognitions
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View(db.EmployeeRecognitions.ToList());
            }
            else
            { return View("NotAuthenticated"); }
        }

        // GET: EmployeeRecognitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeRecognition employeeRecognition = db.EmployeeRecognitions.Find(id);
            if (employeeRecognition == null)
            {
                return HttpNotFound();
            }
            return View(employeeRecognition);
        }

        // GET: EmployeeRecognitions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeRecognitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "employeeRecognitionID,firstName,email,phone")] EmployeeRecognition employeeRecognition)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeRecognitions.Add(employeeRecognition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeRecognition);
        }

        // GET: EmployeeRecognitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeRecognition employeeRecognition = db.EmployeeRecognitions.Find(id);
            if (employeeRecognition == null)
            {
                return HttpNotFound();
            }
            return View(employeeRecognition);
        }

        // POST: EmployeeRecognitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "employeeRecognitionID,firstName,email,phone")] EmployeeRecognition employeeRecognition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeRecognition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeRecognition);
        }

        // GET: EmployeeRecognitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeRecognition employeeRecognition = db.EmployeeRecognitions.Find(id);
            if (employeeRecognition == null)
            {
                return HttpNotFound();
            }
            return View(employeeRecognition);
        }

        // POST: EmployeeRecognitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeRecognition employeeRecognition = db.EmployeeRecognitions.Find(id);
            db.EmployeeRecognitions.Remove(employeeRecognition);
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

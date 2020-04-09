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
    public class RecognitionDetailsController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: RecognitionDetails
        public ActionResult Index()
        {
            var recognitionDetails = db.RecognitionDetails.Include(r => r.EmployeeRecognition).Include(r => r.Recognition);
            return View(recognitionDetails.ToList());
        }

        // GET: RecognitionDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecognitionDetail recognitionDetail = db.RecognitionDetails.Find(id);
            if (recognitionDetail == null)
            {
                return HttpNotFound();
            }
            return View(recognitionDetail);
        }

        // GET: RecognitionDetails/Create
        public ActionResult Create()
        {
            ViewBag.employeeRecognitionID = new SelectList(db.EmployeeRecognitions, "employeeRecognitionID", "firstName");
            ViewBag.recognitionID = new SelectList(db.Recognitions, "recognitionID", "description");
            return View();
        }

        // POST: RecognitionDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecognitionDetailID,qtyOrdered,price,recognitionID,employeeRecognitionID")] RecognitionDetail recognitionDetail)
        {
            if (ModelState.IsValid)
            {
                db.RecognitionDetails.Add(recognitionDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.employeeRecognitionID = new SelectList(db.EmployeeRecognitions, "employeeRecognitionID", "firstName", recognitionDetail.employeeRecognitionID);
            ViewBag.recognitionID = new SelectList(db.Recognitions, "recognitionID", "description", recognitionDetail.recognitionID);
            return View(recognitionDetail);
        }

        // GET: RecognitionDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecognitionDetail recognitionDetail = db.RecognitionDetails.Find(id);
            if (recognitionDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.employeeRecognitionID = new SelectList(db.EmployeeRecognitions, "employeeRecognitionID", "firstName", recognitionDetail.employeeRecognitionID);
            ViewBag.recognitionID = new SelectList(db.Recognitions, "recognitionID", "description", recognitionDetail.recognitionID);
            return View(recognitionDetail);
        }

        // POST: RecognitionDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecognitionDetailID,qtyOrdered,price,recognitionID,employeeRecognitionID")] RecognitionDetail recognitionDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recognitionDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.employeeRecognitionID = new SelectList(db.EmployeeRecognitions, "employeeRecognitionID", "firstName", recognitionDetail.employeeRecognitionID);
            ViewBag.recognitionID = new SelectList(db.Recognitions, "recognitionID", "description", recognitionDetail.recognitionID);
            return View(recognitionDetail);
        }

        // GET: RecognitionDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecognitionDetail recognitionDetail = db.RecognitionDetails.Find(id);
            if (recognitionDetail == null)
            {
                return HttpNotFound();
            }
            return View(recognitionDetail);
        }

        // POST: RecognitionDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecognitionDetail recognitionDetail = db.RecognitionDetails.Find(id);
            db.RecognitionDetails.Remove(recognitionDetail);
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

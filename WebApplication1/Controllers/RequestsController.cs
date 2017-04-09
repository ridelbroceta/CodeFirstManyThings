using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using App.Data.Context;
using App.Data.Entities;

namespace WebApplication1.Controllers
{
    public class RequestsController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Requests
        public ActionResult Index()
        {
            var requests = db.Requests.Where(p => p.RequestId > 1)
                .Include(r => r.ReceiveDocType)
                .Include(r => r.RequestDocType)
                .Include(r => r.Status).Include(r => r.State.Country)
                .Include(r => r.Division.Department)
                .Include(r => r.Department)
                ;
            var myList = requests.ToList();
            return View(myList);
        }

        // GET: Requests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // GET: Requests/Create
        public ActionResult Create()
        {
            ViewBag.ReceiveDocTypeId = new SelectList(db.DocTypes, "DocTypeId", "DocTypeDesc");
            ViewBag.RequestDocTypeId = new SelectList(db.DocTypes, "DocTypeId", "DocTypeDesc");
            ViewBag.StatusId = new SelectList(db.RequestStatus, "StatusId", "StatusDesc");
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RequestId,RequestDesc,StatusId,StateId,RequestDocTypeId,ReceiveDocTypeId")] Request request)
        {
            if (ModelState.IsValid)
            {
                db.Requests.Add(request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReceiveDocTypeId = new SelectList(db.DocTypes, "DocTypeId", "DocTypeDesc", request.ReceiveDocTypeId);
            ViewBag.RequestDocTypeId = new SelectList(db.DocTypes, "DocTypeId", "DocTypeDesc", request.RequestDocTypeId);
            ViewBag.StatusId = new SelectList(db.RequestStatus, "StatusId", "StatusDesc", request.StatusId);
            return View(request);
        }

        // GET: Requests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReceiveDocTypeId = new SelectList(db.DocTypes, "DocTypeId", "DocTypeDesc", request.ReceiveDocTypeId);
            ViewBag.RequestDocTypeId = new SelectList(db.DocTypes, "DocTypeId", "DocTypeDesc", request.RequestDocTypeId);
            ViewBag.StatusId = new SelectList(db.RequestStatus, "StatusId", "StatusDesc", request.StatusId);
            return View(request);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RequestId,RequestDesc,StatusId,StateId,RequestDocTypeId,ReceiveDocTypeId")] Request request)
        {
            if (ModelState.IsValid)
            {
                db.Entry(request).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReceiveDocTypeId = new SelectList(db.DocTypes, "DocTypeId", "DocTypeDesc", request.ReceiveDocTypeId);
            ViewBag.RequestDocTypeId = new SelectList(db.DocTypes, "DocTypeId", "DocTypeDesc", request.RequestDocTypeId);
            ViewBag.StatusId = new SelectList(db.RequestStatus, "StatusId", "StatusDesc", request.StatusId);
            return View(request);
        }

        // GET: Requests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Request request = db.Requests.Find(id);
            db.Requests.Remove(request);
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

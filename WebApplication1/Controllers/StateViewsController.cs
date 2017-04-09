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
    public class StateViewsController : Controller
    {
        private MyContext db = new MyContext();

        // GET: StateViews
        public ActionResult Index()
        {
            return View(db.States.ToList());
        }

        // GET: StateViews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StateView stateView = db.States.Find(id);
            if (stateView == null)
            {
                return HttpNotFound();
            }
            return View(stateView);
        }

        // GET: StateViews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StateViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StateId,Name,Abbreviation,CountryId")] StateView stateView)
        {
            if (ModelState.IsValid)
            {
                db.States.Add(stateView);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stateView);
        }

        // GET: StateViews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StateView stateView = db.States.Find(id);
            if (stateView == null)
            {
                return HttpNotFound();
            }
            return View(stateView);
        }

        // POST: StateViews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StateId,Name,Abbreviation,CountryId")] StateView stateView)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stateView).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stateView);
        }

        // GET: StateViews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StateView stateView = db.States.Find(id);
            if (stateView == null)
            {
                return HttpNotFound();
            }
            return View(stateView);
        }

        // POST: StateViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StateView stateView = db.States.Find(id);
            db.States.Remove(stateView);
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

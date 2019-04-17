using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryProject.Models;

namespace InventoryProject.Controllers
{
    public class Tr_DetailsController : Controller
    {
        private Tr_DBEntities db = new Tr_DBEntities();

        // GET: /Tr_Details/
        public ActionResult Index()
        {
            var tr_details = db.Tr_Details.Include(t => t.Tr_Masters);
            return View(tr_details.ToList());
        }

        // GET: /Tr_Details/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tr_Details tr_details = db.Tr_Details.Find(id);
            if (tr_details == null)
            {
                return HttpNotFound();
            }
            return View(tr_details);
        }

        // GET: /Tr_Details/Create
        public ActionResult Create()
        {
            ViewBag.Tr_MasterID = new SelectList(db.Tr_Masters, "Tr_MasterID", "MemoNo");
            return View();
        }

        // POST: /Tr_Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Tr_DetailID,Tr_MasterID,BookGroupID,BookID,Qty,Rate,Commission")] Tr_Details tr_details)
        {
            if (ModelState.IsValid)
            {
                //tr_details.Tr_DetailID = Guid.NewGuid();
                db.Tr_Details.Add(tr_details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Tr_MasterID = new SelectList(db.Tr_Masters, "Tr_MasterID", "MemoNo", tr_details.Tr_MasterID);
            return View(tr_details);
        }

        // GET: /Tr_Details/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tr_Details tr_details = db.Tr_Details.Find(id);
            if (tr_details == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tr_MasterID = new SelectList(db.Tr_Masters, "Tr_MasterID", "MemoNo", tr_details.Tr_MasterID);
            return View(tr_details);
        }

        // POST: /Tr_Details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Tr_DetailID,Tr_MasterID,BookGroupID,BookID,Qty,Rate,Commission")] Tr_Details tr_details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tr_details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Tr_MasterID = new SelectList(db.Tr_Masters, "Tr_MasterID", "MemoNo", tr_details.Tr_MasterID);
            return View(tr_details);
        }

        // GET: /Tr_Details/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tr_Details tr_details = db.Tr_Details.Find(id);
            if (tr_details == null)
            {
                return HttpNotFound();
            }
            return View(tr_details);
        }

        // POST: /Tr_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Tr_Details tr_details = db.Tr_Details.Find(id);
            db.Tr_Details.Remove(tr_details);
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

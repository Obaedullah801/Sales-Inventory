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
    public class BookGroupController : Controller
    {
        private Tr_DBEntities db = new Tr_DBEntities();

        // GET: BookGroups
        public ActionResult Index()
        {
            List<BookGroup> bookGrouptList = db.BookGroups.ToList();
            ViewBag.bookGrouptList = new SelectList(bookGrouptList, "BookGroupID", "MainBookName");
            return View(bookGrouptList);

           // return View(db.BookGroups.ToList());
        }

        // GET: BookGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookGroup bookGroup = db.BookGroups.Find(id);
            if (bookGroup == null)
            {
                return HttpNotFound();
            }
            return View(bookGroup);
        }

        // GET: BookGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookGroupID,MainBookName,Class")] BookGroup bookGroup)
        {
            if (ModelState.IsValid)
            {
                db.BookGroups.Add(bookGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookGroup);
        }

        // GET: BookGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookGroup bookGroup = db.BookGroups.Find(id);
            if (bookGroup == null)
            {
                return HttpNotFound();
            }
            return View(bookGroup);
        }

        // POST: BookGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookGroupID,MainBookName,Class")] BookGroup bookGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookGroup);
        }

        // GET: BookGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookGroup bookGroup = db.BookGroups.Find(id);
            if (bookGroup == null)
            {
                return HttpNotFound();
            }
            return View(bookGroup);
        }

        // POST: BookGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookGroup bookGroup = db.BookGroups.Find(id);
            db.BookGroups.Remove(bookGroup);
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

        public JsonResult GetBookGroupList()
        {
            var dataList = db.BookGroups.ToList();
            var jsonData = dataList.Select(c => new { c.BookGroupID, c.MainBookName });
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetBookList(int bookgroupId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Book> BookList = db.Books.Where(x => x.BookGroupID == bookgroupId).ToList();
            return Json(BookList, JsonRequestBehavior.AllowGet);
        }

    }
}

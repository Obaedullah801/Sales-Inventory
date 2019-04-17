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
    public class Tr_DetailsController22 : Controller
    {
        public Tr_DBEntities db = new Tr_DBEntities();

        // GET: Tr_Details
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Index()
        {
            var tr_Details = db.Tr_Details.Include(t=>t.Tr_MasterID);
            return View(tr_Details.ToList());
        }

        // GET: Tr_Details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tr_Details tr_Details = db.Tr_Details.Find(id);
            if (tr_Details == null)
            {
                return HttpNotFound();
            }
            return View(tr_Details);
        }




        // GET: Tr_Details/Create
        public ActionResult Create()
        {
            ViewBag.BookGroupID = new SelectList(db.BookGroups, "BookGroupID", "MainBookName");
            ViewBag.BookID = new SelectList(db.Books, "BookID", "BookName");
            ViewBag.Tr_MasterID = new SelectList(db.Tr_Masters, "Tr_MasterID", "MemoNo");
            return View();
        }

         // POST: Tr_Details/Create
         //To protect from overposting attacks, please enable the specific properties you want to bind to, for 
         // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Tr_DetailID,Tr_MasterID,BookGroupID,BookID,Qty,Rate,Commission")] Tr_Details tr_Details)
        {
            if (ModelState.IsValid)
            {
                db.Tr_Details.Add(tr_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookGroupID = new SelectList(db.BookGroups, "BookGroupID", "MainBookName", tr_Details.BookGroupID);
            ViewBag.BookID = new SelectList(db.Books, "BookID", "BookName", tr_Details.BookID);
            ViewBag.Tr_MasterID = new SelectList(db.Tr_Masters, "Tr_MasterID", "MemoNo", tr_Details.Tr_MasterID);
            return View(tr_Details);
        }

         //GET: Tr_Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tr_Details tr_Details = db.Tr_Details.Find(id);
            if (tr_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookGroupID = new SelectList(db.BookGroups, "BookGroupID", "MainBookName", tr_Details.BookGroupID);
            ViewBag.BookID = new SelectList(db.Books, "BookID", "BookName", tr_Details.BookID);
            ViewBag.Tr_MasterID = new SelectList(db.Tr_Masters, "Tr_MasterID", "MemoNo", tr_Details.Tr_MasterID);
            return View(tr_Details);
        }
        




         //POST: Tr_Details/Edit/5
         //To protect from overposting attacks, please enable the specific properties you want to bind to, for 
         //more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Tr_DetailID,Tr_MasterID,BookGroupID,BookID,Qty,Rate,Commission")] Tr_Details tr_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tr_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookGroupID = new SelectList(db.BookGroups, "BookGroupID", "MainBookName", tr_Details.BookGroupID);
            ViewBag.BookID = new SelectList(db.Books, "BookID", "BookName", tr_Details.BookID);
            ViewBag.Tr_MasterID = new SelectList(db.Tr_Masters, "Tr_MasterID", "MemoNo", tr_Details.Tr_MasterID);
            return View(tr_Details);
        }
        

         //GET: Tr_Details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tr_Details tr_Details = db.Tr_Details.Find(id);
            if (tr_Details == null)
            {
                return HttpNotFound();
            }
            return View(tr_Details);
        }



        // POST: Tr_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tr_Details tr_Details = db.Tr_Details.Find(id);
            db.Tr_Details.Remove(tr_Details);
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


















//public ActionResult ViewAll()
//        {
//            return View(GetAllTr_Details());
//        }

//        IEnumerable<Tr_Details> GetAllTr_Details()
//        {
//            using (Tr_DBEntities db = new Tr_DBEntities())
//            {
                
//                return db.Tr_Details.Include(t => t.BookGroup).Include(t => t.Book).Include(t => t.Tr_Masters).ToList();
//               // return db.Tr_Details.ToList<Tr_Details>();
//            }
//        }


       
       
//        public ActionResult GetTr_Detail()
//        {
//            using (Tr_DBEntities db = new Tr_DBEntities())
//            {
//                var tr_details = db.Tr_Details.OrderBy(c=> c.Qty).ToList();
//                return Json(new{data = tr_details}, JsonRequestBehavior.AllowGet);
//            }
//        }

//        //// GET: Tr_Details/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Tr_Details tr_Details = db.Tr_Details.Find(id);
//            if (tr_Details == null)
//            {
//                return HttpNotFound();
//            }
//            return View(tr_Details);
//        }

//        public ActionResult AddOrEdit(int id = 0)
//        {
//            Tr_Details emp = new Tr_Details();
//            if (id != 0)
//            {
//                using (Tr_DBEntities db = new Tr_DBEntities())
//                {
//                    emp = db.Tr_Details.Where(x => x.Tr_DetailID == id).FirstOrDefault<Tr_Details>();
//                }
//            }

//            return View(emp);
//        }
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult AddOrEdit(Tr_Details tr_D)
//        {
//            using (Tr_DBEntities db = new Tr_DBEntities())
//            {

//                if (tr_D.Tr_DetailID == 0)
//                {
//                    db.Tr_Details.Add(tr_D);
//                    db.SaveChanges();
//                }
//                else
//                {
//                    db.Entry(tr_D).State = EntityState.Modified;
//                    db.SaveChanges();
//                }

//            }
//            return Json(new { success = true, message = "Successfully" },JsonRequestBehavior.AllowGet);
//        }
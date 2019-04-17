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
    public class DistrictsController : Controller
    {
        private Tr_DBEntities db = new Tr_DBEntities();

        // GET: Districts
        public ActionResult Index()
        {
            List<District> districtList = db.Districts.ToList();
            ViewBag.districtList = new SelectList(districtList, "DistrictID", "DistrictName");
            return View(districtList);

            //var districts = db.Districts.Include(d => d.Division);
            //return View(districts.ToList());
        }

        // GET: Districts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District district = db.Districts.Find(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            return View(district);
        }

        // GET: Districts/Create
        public ActionResult Create()
        {
            ViewBag.DivisionID = new SelectList(db.Divisions, "DivisionID", "DivisionName");
            return View();
        }

        // POST: Districts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DistrictID,DistrictName,DivisionID")] District district)
        {
            if (ModelState.IsValid)
            {
                db.Districts.Add(district);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DivisionID = new SelectList(db.Divisions, "DivisionID", "DivisionName", district.DivisionID);
            return View(district);
        }

        // GET: Districts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District district = db.Districts.Find(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            ViewBag.DivisionID = new SelectList(db.Divisions, "DivisionID", "DivisionName", district.DivisionID);
            return View(district);
        }

        // POST: Districts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DistrictID,DistrictName,DivisionID")] District district)
        {
            if (ModelState.IsValid)
            {
                db.Entry(district).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DivisionID = new SelectList(db.Divisions, "DivisionID", "DivisionName", district.DivisionID);
            return View(district);
        }

        // GET: Districts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District district = db.Districts.Find(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            return View(district);
        }

        // POST: Districts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            District district = db.Districts.Find(id);
            db.Districts.Remove(district);
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
        public JsonResult getDistrict()
        {
            var district = db.Districts.ToList();
            var jsonData = district.Select(c => new { c.DistrictID, c.DistrictName });
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetClientList(int districtId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Client> ClientList = db.Clients.Where(x => x.DistrictID == districtId).ToList();
            return Json(ClientList, JsonRequestBehavior.AllowGet);
        }
    }
}

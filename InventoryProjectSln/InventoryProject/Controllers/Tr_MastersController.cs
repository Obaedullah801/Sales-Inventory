using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryProject.Models;
using InventoryProject.Controllers.SelectOption;
using System.Text.RegularExpressions;


namespace InventoryProject.Controllers
{
    public class Tr_MastersController : Controller
    {
        
         Tr_DBEntities db = new Tr_DBEntities();

        public ActionResult OrderAndCustomer()
        {
            
            List<Tr_Masters> customerList = db.Tr_Masters.ToList();
            ViewBag.customerList = new SelectList(customerList, "Tr_MasterID", "invoiceNo");
            return View(customerList);
        }

        // dropdown
        public ActionResult IndexDivision()
        {
            ViewBag.DivisionList = new SelectList(GetDivisionList(), "DivisionID", "DivisionName");
            return View();
        }
        public List<Division> GetDivisionList()
        {
            
            List<Division> divisions = db.Divisions.ToList();
            return divisions;
        }
        public List<District> GetDistrictist()
        {

            List<District> districts = db.Districts.ToList();
            return districts;
        }
        //.................


        //public ActionResult BookList()
        //{
        //    BookCreateVM book = new BookCreateVM();
        //    book.selectListOrganization = _select.SelectBook();
        //    return View(book);
        //}


        public ActionResult SaveOrder(int? invoiceNo, string memoNo, string salesType, int districtId, int clientID, int? packdebit, DateTime date, int? less, int commission2, decimal netAmount, Tr_Details[] Tr_Detail, Book[] book, BookGroup[] bookGroup, District[] district, Client[] client)
        {
            string result = "Error! Order Is Not Complete ";
            if (invoiceNo != null || memoNo != null || Tr_Detail != null || book != null || packdebit != null|| bookGroup !=null || district !=null || client !=null)
            {


                Tr_Masters model = new Tr_Masters();
                model.InvoiceNo = invoiceNo;
                model.Less = less;
                model.DistrictID = districtId;
                model.ClientID = clientID;
                model.PackDebit = packdebit;
                model.Type = salesType;
                model.Commission = commission2;
                model.Tr_Date = date;
                MoneyReceipt moneyReceipt = new MoneyReceipt();
                moneyReceipt.PartyCode = clientID;
                moneyReceipt.EntryDate = date;
                moneyReceipt.Amount = netAmount;
                db.MoneyReceipts.Add(moneyReceipt);
                db.Tr_Masters.Add(model);
                foreach (var item in Tr_Detail)
                {
                    
                    Tr_Details o = new Tr_Details();
                    o.BookID = item.BookID;
                    o.BookGroupID = item.BookGroupID;
                    o.Qty = item.Qty;
                    o.Rate = item.Rate;
                    o.Commission = item.Commission;
                    o.Amount = item.Amount;
                    db.Tr_Details.Add(o);
                    
                }

                db.SaveChanges();
                result = "Success Order Is Complete ";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
            
        }
       


        //public JsonResult getmethod()
        //{
        //    var db = new Tr_DBEntities();
        //    return Json(db.Books.Select(c => new { BookID = c.BookID, BookName = c.BookName }), JsonRequestBehavior.AllowGet);
        //}

        // GET: Tr_Masters
        public ActionResult Index()
        {
            var tr_Masters = db.Tr_Masters;
            return View(tr_Masters.ToList());
        }

        // GET: Tr_Masters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tr_Masters tr_Masters = db.Tr_Masters.Find(id);
            if (tr_Masters == null)
            {
                return HttpNotFound();
            }
            return View(tr_Masters);
        }

        // GET: Tr_Masters/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientName");
            ViewBag.DistrictID = new SelectList(db.Districts, "DistrictID", "DistrictName");
            return View();
        }

        // POST: Tr_Masters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Tr_MasterID,Tr_Date,MemoNo,DistrictID,ClientID,PackDebit,Less,Type,ReturnLessMemoNo,InvoiceNo,BindID,OrderID,Commission")] Tr_Masters tr_Masters)
        {
            if (ModelState.IsValid)
            {
                db.Tr_Masters.Add(tr_Masters);
                db.SaveChanges();
                return RedirectToAction("Nes.cshtml");
            }

            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientName", tr_Masters.ClientID);
            ViewBag.DistrictID = new SelectList(db.Districts, "DistrictID", "DistrictName", tr_Masters.DistrictID);
            return View(tr_Masters);
        }
       
        // GET: Tr_Masters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tr_Masters tr_Masters = db.Tr_Masters.Find(id);
            if (tr_Masters == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientName", tr_Masters.ClientID);
            ViewBag.DistrictID = new SelectList(db.Districts, "DistrictID", "DistrictName", tr_Masters.DistrictID);
            return View(tr_Masters);
        }

        // POST: Tr_Masters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Tr_MasterID,Tr_Date,MemoNo,DistrictID,ClientID,PackDebit,Less,Type,ReturnLessMemoNo,InvoiceNo,BindID,OrderID,Commission")] Tr_Masters tr_Masters)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tr_Masters).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientName", tr_Masters.ClientID);
            ViewBag.DistrictID = new SelectList(db.Districts, "DistrictID", "DistrictName", tr_Masters.DistrictID);
            return View(tr_Masters);
        }

        // GET: Tr_Masters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tr_Masters tr_Masters = db.Tr_Masters.Find(id);
            if (tr_Masters == null)
            {
                return HttpNotFound();
            }
            return View(tr_Masters);
        }

        // POST: Tr_Masters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tr_Masters tr_Masters = db.Tr_Masters.Find(id);
            db.Tr_Masters.Remove(tr_Masters);
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

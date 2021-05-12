using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLNHANSU.Models;

namespace QLNHANSU.Controllers
{
    public class KHENTHUONG_KYLUATController : Controller
    {
        private QLNSDbContext db = new QLNSDbContext();

        // GET: KHENTHUONG_KYLUAT
        public ActionResult Index()
        {
            var kHENTHUONG_KYLUATs = db.KHENTHUONG_KYLUATs.Include(k => k.NHANVIENs);
            return View(kHENTHUONG_KYLUATs.ToList());
        }

        // GET: KHENTHUONG_KYLUAT/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHENTHUONG_KYLUAT kHENTHUONG_KYLUAT = db.KHENTHUONG_KYLUATs.Find(id);
            if (kHENTHUONG_KYLUAT == null)
            {
                return HttpNotFound();
            }
            return View(kHENTHUONG_KYLUAT);
        }

        // GET: KHENTHUONG_KYLUAT/Create
        public ActionResult Create()
        {
            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "TenNV");
            return View();
        }

        // POST: KHENTHUONG_KYLUAT/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoQD,TenNV,MaNV,LyDo,HinhThuc,SoTien")] KHENTHUONG_KYLUAT kHENTHUONG_KYLUAT)
        {
            if (ModelState.IsValid)
            {
                db.KHENTHUONG_KYLUATs.Add(kHENTHUONG_KYLUAT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "TenNV", kHENTHUONG_KYLUAT.MaNV);
            return View(kHENTHUONG_KYLUAT);
        }

        // GET: KHENTHUONG_KYLUAT/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHENTHUONG_KYLUAT kHENTHUONG_KYLUAT = db.KHENTHUONG_KYLUATs.Find(id);
            if (kHENTHUONG_KYLUAT == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "TenNV", kHENTHUONG_KYLUAT.MaNV);
            return View(kHENTHUONG_KYLUAT);
        }

        // POST: KHENTHUONG_KYLUAT/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SoQD,TenNV,MaNV,LyDo,HinhThuc,SoTien")] KHENTHUONG_KYLUAT kHENTHUONG_KYLUAT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kHENTHUONG_KYLUAT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "TenNV", kHENTHUONG_KYLUAT.MaNV);
            return View(kHENTHUONG_KYLUAT);
        }

        // GET: KHENTHUONG_KYLUAT/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHENTHUONG_KYLUAT kHENTHUONG_KYLUAT = db.KHENTHUONG_KYLUATs.Find(id);
            if (kHENTHUONG_KYLUAT == null)
            {
                return HttpNotFound();
            }
            return View(kHENTHUONG_KYLUAT);
        }

        // POST: KHENTHUONG_KYLUAT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KHENTHUONG_KYLUAT kHENTHUONG_KYLUAT = db.KHENTHUONG_KYLUATs.Find(id);
            db.KHENTHUONG_KYLUATs.Remove(kHENTHUONG_KYLUAT);
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

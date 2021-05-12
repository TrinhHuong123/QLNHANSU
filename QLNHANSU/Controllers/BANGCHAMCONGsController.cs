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
    public class BANGCHAMCONGsController : Controller
    {
        private QLNSDbContext db = new QLNSDbContext();

        // GET: BANGCHAMCONGs
        public ActionResult Index()
        {
            var bANGCHAMCONGs = db.BANGCHAMCONGs.Include(b => b.NHANVIENs);
            return View(bANGCHAMCONGs.ToList());
        }

        // GET: BANGCHAMCONGs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANGCHAMCONG bANGCHAMCONG = db.BANGCHAMCONGs.Find(id);
            if (bANGCHAMCONG == null)
            {
                return HttpNotFound();
            }
            return View(bANGCHAMCONG);
        }

        // GET: BANGCHAMCONGs/Create
        public ActionResult Create()
        {
            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "TenNV");
            return View();
        }

        // POST: BANGCHAMCONGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCC,MaNV,TenNV,SoNgayNghi,SoNgayDiLam,TongNgayCong")] BANGCHAMCONG bANGCHAMCONG)
        {
            if (ModelState.IsValid)
            {
                db.BANGCHAMCONGs.Add(bANGCHAMCONG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "TenNV", bANGCHAMCONG.MaNV);
            return View(bANGCHAMCONG);
        }

        // GET: BANGCHAMCONGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANGCHAMCONG bANGCHAMCONG = db.BANGCHAMCONGs.Find(id);
            if (bANGCHAMCONG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "TenNV", bANGCHAMCONG.MaNV);
            return View(bANGCHAMCONG);
        }

        // POST: BANGCHAMCONGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCC,MaNV,TenNV,SoNgayNghi,SoNgayDiLam,TongNgayCong")] BANGCHAMCONG bANGCHAMCONG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bANGCHAMCONG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "TenNV", bANGCHAMCONG.MaNV);
            return View(bANGCHAMCONG);
        }

        // GET: BANGCHAMCONGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANGCHAMCONG bANGCHAMCONG = db.BANGCHAMCONGs.Find(id);
            if (bANGCHAMCONG == null)
            {
                return HttpNotFound();
            }
            return View(bANGCHAMCONG);
        }

        // POST: BANGCHAMCONGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BANGCHAMCONG bANGCHAMCONG = db.BANGCHAMCONGs.Find(id);
            db.BANGCHAMCONGs.Remove(bANGCHAMCONG);
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

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
    public class BANGLUONGsController : Controller
    {
        private QLNSDbContext db = new QLNSDbContext();

        // GET: BANGLUONGs
        public ActionResult Index()
        {
            var bANGLUONGs = db.BANGLUONGs.Include(b => b.NHANVIENs);
            return View(bANGLUONGs.ToList());
        }

        // GET: BANGLUONGs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANGLUONG bANGLUONG = db.BANGLUONGs.Find(id);
            if (bANGLUONG == null)
            {
                return HttpNotFound();
            }
            return View(bANGLUONG);
        }

        // GET: BANGLUONGs/Create
        public ActionResult Create()
        {
            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "TenNV");
            return View();
        }

        // POST: BANGLUONGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLuong,MaNV,HeSoLuong,BacLuong,TongNgayCong")] BANGLUONG bANGLUONG)
        {
            if (ModelState.IsValid)
            {
                db.BANGLUONGs.Add(bANGLUONG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "TenNV", bANGLUONG.MaNV);
            return View(bANGLUONG);
        }

        // GET: BANGLUONGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANGLUONG bANGLUONG = db.BANGLUONGs.Find(id);
            if (bANGLUONG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "TenNV", bANGLUONG.MaNV);
            return View(bANGLUONG);
        }

        // POST: BANGLUONGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLuong,MaNV,HeSoLuong,BacLuong,TongNgayCong")] BANGLUONG bANGLUONG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bANGLUONG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "TenNV", bANGLUONG.MaNV);
            return View(bANGLUONG);
        }

        // GET: BANGLUONGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANGLUONG bANGLUONG = db.BANGLUONGs.Find(id);
            if (bANGLUONG == null)
            {
                return HttpNotFound();
            }
            return View(bANGLUONG);
        }

        // POST: BANGLUONGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BANGLUONG bANGLUONG = db.BANGLUONGs.Find(id);
            db.BANGLUONGs.Remove(bANGLUONG);
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

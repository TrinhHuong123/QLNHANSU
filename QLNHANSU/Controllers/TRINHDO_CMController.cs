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
    public class TRINHDO_CMController : Controller
    {
        private QLNSDbContext db = new QLNSDbContext();

        // GET: TRINHDO_CM
        public ActionResult Index()
        {
            var tRINHDO_CMs = db.TRINHDO_CMs.Include(t => t.NHANVIENs);
            return View(tRINHDO_CMs.ToList());
        }

        // GET: TRINHDO_CM/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRINHDO_CM tRINHDO_CM = db.TRINHDO_CMs.Find(id);
            if (tRINHDO_CM == null)
            {
                return HttpNotFound();
            }
            return View(tRINHDO_CM);
        }

        // GET: TRINHDO_CM/Create
        public ActionResult Create()
        {
            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "TenNV");
            return View();
        }

        // POST: TRINHDO_CM/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "STT,TenNV,MaNV,TDCM,TDNN")] TRINHDO_CM tRINHDO_CM)
        {
            if (ModelState.IsValid)
            {
                db.TRINHDO_CMs.Add(tRINHDO_CM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "TenNV", tRINHDO_CM.MaNV);
            return View(tRINHDO_CM);
        }

        // GET: TRINHDO_CM/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRINHDO_CM tRINHDO_CM = db.TRINHDO_CMs.Find(id);
            if (tRINHDO_CM == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "TenNV", tRINHDO_CM.MaNV);
            return View(tRINHDO_CM);
        }

        // POST: TRINHDO_CM/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "STT,TenNV,MaNV,TDCM,TDNN")] TRINHDO_CM tRINHDO_CM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tRINHDO_CM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "TenNV", tRINHDO_CM.MaNV);
            return View(tRINHDO_CM);
        }

        // GET: TRINHDO_CM/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRINHDO_CM tRINHDO_CM = db.TRINHDO_CMs.Find(id);
            if (tRINHDO_CM == null)
            {
                return HttpNotFound();
            }
            return View(tRINHDO_CM);
        }

        // POST: TRINHDO_CM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TRINHDO_CM tRINHDO_CM = db.TRINHDO_CMs.Find(id);
            db.TRINHDO_CMs.Remove(tRINHDO_CM);
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

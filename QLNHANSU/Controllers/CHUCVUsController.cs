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
    public class CHUCVUsController : Controller
    {
        private QLNSDbContext db = new QLNSDbContext();

        // GET: CHUCVUs
        public ActionResult Index()
        {
            var cHUCVUs = db.CHUCVUs.Include(c => c.PHONGBANs);
            return View(cHUCVUs.ToList());
        }

        // GET: CHUCVUs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUCVU cHUCVU = db.CHUCVUs.Find(id);
            if (cHUCVU == null)
            {
                return HttpNotFound();
            }
            return View(cHUCVU);
        }

        // GET: CHUCVUs/Create
        public ActionResult Create()
        {
            ViewBag.MaPB = new SelectList(db.PHONGBANs, "MaPB", "TenPB");
            return View();
        }

        // POST: CHUCVUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCV,TenCV,MaPB")] CHUCVU cHUCVU)
        {
            if (ModelState.IsValid)
            {
                db.CHUCVUs.Add(cHUCVU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaPB = new SelectList(db.PHONGBANs, "MaPB", "TenPB", cHUCVU.MaPB);
            return View(cHUCVU);
        }

        // GET: CHUCVUs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUCVU cHUCVU = db.CHUCVUs.Find(id);
            if (cHUCVU == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPB = new SelectList(db.PHONGBANs, "MaPB", "TenPB", cHUCVU.MaPB);
            return View(cHUCVU);
        }

        // POST: CHUCVUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCV,TenCV,MaPB")] CHUCVU cHUCVU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHUCVU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPB = new SelectList(db.PHONGBANs, "MaPB", "TenPB", cHUCVU.MaPB);
            return View(cHUCVU);
        }

        // GET: CHUCVUs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUCVU cHUCVU = db.CHUCVUs.Find(id);
            if (cHUCVU == null)
            {
                return HttpNotFound();
            }
            return View(cHUCVU);
        }

        // POST: CHUCVUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CHUCVU cHUCVU = db.CHUCVUs.Find(id);
            db.CHUCVUs.Remove(cHUCVU);
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

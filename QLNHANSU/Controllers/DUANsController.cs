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
    public class DUANsController : Controller
    {
        private QLNSDbContext db = new QLNSDbContext();

        // GET: DUANs
        public ActionResult Index()
        {
            return View(db.DUANs.ToList());
        }

        // GET: DUANs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DUAN dUAN = db.DUANs.Find(id);
            if (dUAN == null)
            {
                return HttpNotFound();
            }
            return View(dUAN);
        }

        // GET: DUANs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DUANs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDuAn,TenDuAn,MaNhanVien,Ngaybatdau,Ngaygiahan,Ngayketthuc,SoLuong,DonGia,ChietKhau")] DUAN dUAN)
        {
            if (ModelState.IsValid)
            {
                db.DUANs.Add(dUAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dUAN);
        }

        // GET: DUANs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DUAN dUAN = db.DUANs.Find(id);
            if (dUAN == null)
            {
                return HttpNotFound();
            }
            return View(dUAN);
        }

        // POST: DUANs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDuAn,TenDuAn,MaNhanVien,Ngaybatdau,Ngaygiahan,Ngayketthuc,SoLuong,DonGia,ChietKhau")] DUAN dUAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dUAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dUAN);
        }

        // GET: DUANs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DUAN dUAN = db.DUANs.Find(id);
            if (dUAN == null)
            {
                return HttpNotFound();
            }
            return View(dUAN);
        }

        // POST: DUANs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DUAN dUAN = db.DUANs.Find(id);
            db.DUANs.Remove(dUAN);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebASP.Models;

namespace WebASP.Controllers
{
    public class TrangThaiDonHangsController : Controller
    {
        private DataContexts db = new DataContexts();

        // GET: TrangThaiDonHangs
        public ActionResult Index()
        {
            return View(db.TrangThaiDonHang.ToList());
        }

        // GET: TrangThaiDonHangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrangThaiDonHang trangThaiDonHang = db.TrangThaiDonHang.Find(id);
            if (trangThaiDonHang == null)
            {
                return HttpNotFound();
            }
            return View(trangThaiDonHang);
        }

        // GET: TrangThaiDonHangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrangThaiDonHangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTT,TenTT,MoTaTT")] TrangThaiDonHang trangThaiDonHang)
        {
            if (ModelState.IsValid)
            {
                db.TrangThaiDonHang.Add(trangThaiDonHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trangThaiDonHang);
        }

        // GET: TrangThaiDonHangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrangThaiDonHang trangThaiDonHang = db.TrangThaiDonHang.Find(id);
            if (trangThaiDonHang == null)
            {
                return HttpNotFound();
            }
            return View(trangThaiDonHang);
        }

        // POST: TrangThaiDonHangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTT,TenTT,MoTaTT")] TrangThaiDonHang trangThaiDonHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trangThaiDonHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trangThaiDonHang);
        }

        // GET: TrangThaiDonHangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrangThaiDonHang trangThaiDonHang = db.TrangThaiDonHang.Find(id);
            if (trangThaiDonHang == null)
            {
                return HttpNotFound();
            }
            return View(trangThaiDonHang);
        }

        // POST: TrangThaiDonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TrangThaiDonHang trangThaiDonHang = db.TrangThaiDonHang.Find(id);
            db.TrangThaiDonHang.Remove(trangThaiDonHang);
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

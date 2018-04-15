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
    public class LoaiNVsController : Controller
    {
        private DataContexts db = new DataContexts();

        // GET: LoaiNVs
        public ActionResult Index()
        {
            return View(db.LoaiNV.ToList());
        }

        // GET: LoaiNVs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiNV loaiNV = db.LoaiNV.Find(id);
            if (loaiNV == null)
            {
                return HttpNotFound();
            }
            return View(loaiNV);
        }

        // GET: LoaiNVs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiNVs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoaiNV,TenLoaiNV,MoTaLoaiNV,QuyenSD")] LoaiNV loaiNV)
        {
            if (ModelState.IsValid)
            {
                db.LoaiNV.Add(loaiNV);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiNV);
        }

        // GET: LoaiNVs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiNV loaiNV = db.LoaiNV.Find(id);
            if (loaiNV == null)
            {
                return HttpNotFound();
            }
            return View(loaiNV);
        }

        // POST: LoaiNVs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoaiNV,TenLoaiNV,MoTaLoaiNV,QuyenSD")] LoaiNV loaiNV)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiNV).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiNV);
        }

        // GET: LoaiNVs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiNV loaiNV = db.LoaiNV.Find(id);
            if (loaiNV == null)
            {
                return HttpNotFound();
            }
            return View(loaiNV);
        }

        // POST: LoaiNVs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LoaiNV loaiNV = db.LoaiNV.Find(id);
            db.LoaiNV.Remove(loaiNV);
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

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
    public class NhomSanPhamsController : Controller
    {
        private DataContexts db = new DataContexts();

        // GET: NhomSanPhams
        public ActionResult Index()
        {
            return View(db.NhomSanPham.ToList());
        }

        // GET: NhomSanPhams/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhomSanPham nhomSanPham = db.NhomSanPham.Find(id);
            if (nhomSanPham == null)
            {
                return HttpNotFound();
            }
            return View(nhomSanPham);
        }

        // GET: NhomSanPhams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhomSanPhams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNhomSP,TenNhomSP,MoTaNhomSP")] NhomSanPham nhomSanPham)
        {
            if (ModelState.IsValid)
            {
                db.NhomSanPham.Add(nhomSanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhomSanPham);
        }

        // GET: NhomSanPhams/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhomSanPham nhomSanPham = db.NhomSanPham.Find(id);
            if (nhomSanPham == null)
            {
                return HttpNotFound();
            }
            return View(nhomSanPham);
        }

        // POST: NhomSanPhams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNhomSP,TenNhomSP,MoTaNhomSP")] NhomSanPham nhomSanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhomSanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhomSanPham);
        }

        // GET: NhomSanPhams/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhomSanPham nhomSanPham = db.NhomSanPham.Find(id);
            if (nhomSanPham == null)
            {
                return HttpNotFound();
            }
            return View(nhomSanPham);
        }

        // POST: NhomSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhomSanPham nhomSanPham = db.NhomSanPham.Find(id);
            db.NhomSanPham.Remove(nhomSanPham);
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

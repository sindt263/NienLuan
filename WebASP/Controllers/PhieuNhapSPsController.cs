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
    public class PhieuNhapSPsController : Controller
    {
        private DataContexts db = new DataContexts();

        // GET: PhieuNhapSPs
        public ActionResult Index()
        {
            var phieuNhapSP = db.PhieuNhapSP.Include(p => p.NhaCungCap).Include(p => p.NhanVien);
            return View(phieuNhapSP.ToList());
        }

        // GET: PhieuNhapSPs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuNhapSP phieuNhapSP = db.PhieuNhapSP.Find(id);
            if (phieuNhapSP == null)
            {
                return HttpNotFound();
            }
            return View(phieuNhapSP);
        }

        // GET: PhieuNhapSPs/Create
        public ActionResult Create()
        {
            ViewBag.MaNCC = new SelectList(db.NhaCungCap, "MaNCC", "TenNCC");
            ViewBag.MaNV = new SelectList(db.NhanVien, "MaNV", "MaLoaiNV");
            return View();
        }

        // POST: PhieuNhapSPs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPN,MaNCC,MaNV,NgayNhap,GhiChuPN,SLNhap")] PhieuNhapSP phieuNhapSP)
        {
            if (ModelState.IsValid)
            {
                if (Common.MaNV != "")
                {

                }
                else
                {
                    Common.Alert = "Đăng nhập trước khi chỉnh sữa !";
                    return RedirectToAction("Index", "Logins");
                }
                phieuNhapSP.MaNV = Common.MaNV;
                db.PhieuNhapSP.Add(phieuNhapSP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNCC = new SelectList(db.NhaCungCap, "MaNCC", "TenNCC", phieuNhapSP.MaNCC);
            ViewBag.MaNV = new SelectList(db.NhanVien, "MaNV", "MaLoaiNV", phieuNhapSP.MaNV);
            return View(phieuNhapSP);
        }

        // GET: PhieuNhapSPs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuNhapSP phieuNhapSP = db.PhieuNhapSP.Find(id);
            if (phieuNhapSP == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNCC = new SelectList(db.NhaCungCap, "MaNCC", "TenNCC", phieuNhapSP.MaNCC);
            ViewBag.MaNV = new SelectList(db.NhanVien, "MaNV", "MaLoaiNV", phieuNhapSP.MaNV);
            return View(phieuNhapSP);
        }

        // POST: PhieuNhapSPs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPN,MaNCC,MaNV,NgayNhap,GhiChuPN,SLNhap")] PhieuNhapSP phieuNhapSP)
        {
            if (ModelState.IsValid)
            {
                if (Common.MaNV != "")
                {

                }
                else
                {
                    Common.Alert = "Đăng nhập trước khi chỉnh sữa !";
                    return RedirectToAction("Index", "Logins");
                }
                db.Entry(phieuNhapSP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNCC = new SelectList(db.NhaCungCap, "MaNCC", "TenNCC", phieuNhapSP.MaNCC);
            ViewBag.MaNV = new SelectList(db.NhanVien, "MaNV", "MaLoaiNV", phieuNhapSP.MaNV);
            return View(phieuNhapSP);
        }

        // GET: PhieuNhapSPs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuNhapSP phieuNhapSP = db.PhieuNhapSP.Find(id);
            if (phieuNhapSP == null)
            {
                return HttpNotFound();
            }
            return View(phieuNhapSP);
        }

        // POST: PhieuNhapSPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PhieuNhapSP phieuNhapSP = db.PhieuNhapSP.Find(id);
            db.PhieuNhapSP.Remove(phieuNhapSP);
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

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
    public class ChiTietNhapsController : Controller
    {
        private DataContexts db = new DataContexts();

        // GET: ChiTietNhaps
        public ActionResult Index()
        {
            var chiTietNhap = db.ChiTietNhap.Include(c => c.PhieuNhapSP).Include(c => c.SanPham);
            return View(chiTietNhap.ToList());
        }

        // GET: ChiTietNhaps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietNhap chiTietNhap = db.ChiTietNhap.Find(id);
            if (chiTietNhap == null)
            {
                return HttpNotFound();
            }
            return View(chiTietNhap);
        }

        // GET: ChiTietNhaps/Create
        public ActionResult Create()
        {
            ViewBag.MaPN = new SelectList(db.PhieuNhapSP, "MaPN", "MaNCC");
            ViewBag.SerialNumber = new SelectList(db.SanPham, "SerialNumber", "SerialNumber");
            return View();
        }

        // POST: ChiTietNhaps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCTNhap,MaPN,SerialNumber,GiaNhap")] ChiTietNhap chiTietNhap)
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
                db.ChiTietNhap.Add(chiTietNhap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaPN = new SelectList(db.PhieuNhapSP, "MaPN", "MaNCC", chiTietNhap.MaPN);
            ViewBag.SerialNumber = new SelectList(db.SanPham, "SerialNumber", "SerialNumber", chiTietNhap.SerialNumber);
            return View(chiTietNhap);
        }

        // GET: ChiTietNhaps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietNhap chiTietNhap = db.ChiTietNhap.Find(id);
            if (chiTietNhap == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPN = new SelectList(db.PhieuNhapSP, "MaPN", "MaNCC", chiTietNhap.MaPN);
            ViewBag.SerialNumber = new SelectList(db.SanPham, "SerialNumber", "SerialNumber", chiTietNhap.SerialNumber);
            return View(chiTietNhap);
        }

        // POST: ChiTietNhaps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCTNhap,MaPN,SerialNumber,GiaNhap")] ChiTietNhap chiTietNhap)
        {
            if (Common.MaNV != "")
            {
                if (ModelState.IsValid)
                {
                    db.Entry(chiTietNhap).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                Common.Alert = "Đăng nhập trước khi chỉnh sữa !";
                return RedirectToAction("Index", "Logins");
            }

            ViewBag.MaPN = new SelectList(db.PhieuNhapSP, "MaPN", "MaNCC", chiTietNhap.MaPN);
            ViewBag.SerialNumber = new SelectList(db.SanPham, "SerialNumber", "SerialNumber", chiTietNhap.SerialNumber);
            return View(chiTietNhap);
        }

        // GET: ChiTietNhaps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietNhap chiTietNhap = db.ChiTietNhap.Find(id);
            if (chiTietNhap == null)
            {
                return HttpNotFound();
            }
            return View(chiTietNhap);
        }

        // POST: ChiTietNhaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietNhap chiTietNhap = db.ChiTietNhap.Find(id);
            db.ChiTietNhap.Remove(chiTietNhap);
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

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
    public class ChiTietKHsController : Controller
    {
        private DataContexts db = new DataContexts();

        // GET: ChiTietKHs
        public ActionResult Index()
        {
            var chiTietKH = db.ChiTietKH.Include(c => c.KhachHang);
            return View(chiTietKH.ToList());
        }

        // GET: ChiTietKHs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietKH chiTietKH = db.ChiTietKH.Find(id);
            if (chiTietKH == null)
            {
                return HttpNotFound();
            }
            return View(chiTietKH);
        }

        // GET: ChiTietKHs/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KhachHang, "MaKH", "TenKH");
            return View();
        }

        // POST: ChiTietKHs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKHCT,MaKH,SoHangDaMua,TongTien,DiaChiThuongDung")] ChiTietKH chiTietKH)
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
                db.ChiTietKH.Add(chiTietKH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KhachHang, "MaKH", "TenKH", chiTietKH.MaKH);
            return View(chiTietKH);
        }

        // GET: ChiTietKHs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietKH chiTietKH = db.ChiTietKH.Find(id);
            if (chiTietKH == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KhachHang, "MaKH", "TenKH", chiTietKH.MaKH);
            return View(chiTietKH);
        }

        // POST: ChiTietKHs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKHCT,MaKH,SoHangDaMua,TongTien,DiaChiThuongDung")] ChiTietKH chiTietKH)
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
                db.Entry(chiTietKH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KhachHang, "MaKH", "TenKH", chiTietKH.MaKH);
            return View(chiTietKH);
        }

        // GET: ChiTietKHs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietKH chiTietKH = db.ChiTietKH.Find(id);
            if (chiTietKH == null)
            {
                return HttpNotFound();
            }
            return View(chiTietKH);
        }

        // POST: ChiTietKHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ChiTietKH chiTietKH = db.ChiTietKH.Find(id);
            db.ChiTietKH.Remove(chiTietKH);
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

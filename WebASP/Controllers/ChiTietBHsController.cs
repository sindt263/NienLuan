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
    public class ChiTietBHsController : Controller
    {
        private DataContexts db = new DataContexts();

        // GET: ChiTietBHs
        public ActionResult Index()
        {

            var chiTietBH = db.ChiTietBH.Include(c => c.BaoHanh).Include(c => c.NhanVien).Include(c => c.SanPham);
            return View(chiTietBH.ToList());
        }

        // GET: ChiTietBHs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietBH chiTietBH = db.ChiTietBH.Find(id);
            if (chiTietBH == null)
            {
                return HttpNotFound();
            }
            return View(chiTietBH);
        }

        // GET: ChiTietBHs/Create
        public ActionResult Create()
        {
            ViewBag.MaBH = new SelectList(db.BaoHanh, "MaBH", "HinhThucBH");
            ViewBag.MaNV = new SelectList(db.NhanVien, "MaNV", "TenNV");
            ViewBag.SerialNumber = new SelectList(db.SanPham, "SerialNumber", "SerialNumber");
            return View();
        }

        // POST: ChiTietBHs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCTBH,SerialNumber,MaNV,MaBH,TrangThai,NgayBH,GhiChuBH,NgayTra")] ChiTietBH chiTietBH)
        {
            var count = from sl in db.ChiTietBH select sl;
            int a = KTTonTai(count.Count());
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
                chiTietBH.MaCTBH = a;
                db.ChiTietBH.Add(chiTietBH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaBH = new SelectList(db.BaoHanh, "MaBH", "HinhThucBH", chiTietBH.MaBH);
            ViewBag.MaNV = new SelectList(db.NhanVien, "MaNV", "TenNV");
            ViewBag.SerialNumber = new SelectList(db.SanPham, "SerialNumber", "SerialNumber", chiTietBH.SerialNumber);
            return View(chiTietBH);
        }

        public int KTTonTai(int temp)
        {
            var KTTontai = from TT in db.ChiTietBH where TT.MaCTBH == temp select TT;
            if (KTTontai.Count() == 0) {
                return temp;
            }
            else
            {
               return KTTonTai(temp +1);
            }
        }
        // GET: ChiTietBHs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietBH chiTietBH = db.ChiTietBH.Find(id);
            if (chiTietBH == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaBH = new SelectList(db.BaoHanh, "MaBH", "HinhThucBH", chiTietBH.MaBH);
            ViewBag.MaNV = new SelectList(db.NhanVien, "MaNV", "TenNV");
            ViewBag.SerialNumber = new SelectList(db.SanPham, "SerialNumber", "SerialNumber", chiTietBH.SerialNumber);
            return View(chiTietBH);
        }

        // POST: ChiTietBHs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCTBH,SerialNumber,MaNV,MaBH,TrangThai,NgayBH,GhiChuBH,NgayTra")] ChiTietBH chiTietBH)
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
                db.Entry(chiTietBH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaBH = new SelectList(db.BaoHanh, "MaBH", "HinhThucBH", chiTietBH.MaBH);
            ViewBag.MaNV = new SelectList(db.NhanVien, "MaNV", "TenNV");
            ViewBag.SerialNumber = new SelectList(db.SanPham, "SerialNumber", "SerialNumber", chiTietBH.SerialNumber);
            return View(chiTietBH);
        }

        // GET: ChiTietBHs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietBH chiTietBH = db.ChiTietBH.Find(id);
            if (chiTietBH == null)
            {
                return HttpNotFound();
            }
            return View(chiTietBH);
        }

        // POST: ChiTietBHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietBH chiTietBH = db.ChiTietBH.Find(id);
            db.ChiTietBH.Remove(chiTietBH);
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

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
    public class DonHangsController : AlertController
    {
        private DataContexts db = new DataContexts();

        // GET: DonHangs
        public ActionResult Index()
        {
            var donHang = db.DonHang.Include(d => d.HinhThucThanhToan).Include(d => d.NhanVien).Include(d => d.TrangThaiDonHang);
            return View(donHang.ToList());
        }

        // GET: DonHangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHang.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        public ActionResult DetailsKH(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHang.Find(id);
            var listKH = from p in db.DonHang where p.MaKH == id select p;
            if (listKH == null)
            {
                return HttpNotFound();
            }
            return View(listKH.ToList());
        }

        // GET: DonHangs/Create
        public ActionResult Create()
        {
            ViewBag.MaHTTT = new SelectList(db.HinhThucThanhToan, "MaHTTT", "TenHTTT");
            ViewBag.MaNV = new SelectList(db.NhanVien, "MaNV", "TenNV");
            ViewBag.MaTT = new SelectList(db.TrangThaiDonHang, "MaTT", "TenTT");
            ViewBag.MaKH = new SelectList(db.KhachHang, "MaKH", "MaKH");
            return View();
        }

        // POST: DonHangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDonHang,MaHTTT,MaTT,MaNV,NgayMua,GhiChuDonHang,SoLuongCT,TongTienDH")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                if (Common.MaNV != "")
                {
                    donHang.MaNV = Common.MaNV;
                }
                else
                {
                    Common.Alert = "Đăng nhập trước khi chỉnh sữa !";
                    return RedirectToAction("Index", "Logins");
                }
                db.DonHang.Add(donHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHTTT = new SelectList(db.HinhThucThanhToan, "MaHTTT", "TenHTTT", donHang.MaHTTT);
            ViewBag.MaNV = new SelectList(db.NhanVien, "MaNV", "MaLoaiNV", donHang.MaNV);
            ViewBag.MaTT = new SelectList(db.TrangThaiDonHang, "MaTT", "TenTT", donHang.MaTT);
            ViewBag.MaKH = new SelectList(db.KhachHang, "MaKH", "MaKH",donHang.MaKH);
            return View(donHang);
        }


        public ActionResult CreateKH(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham nONGSAN = db.SanPham.Find(id);
            if (nONGSAN == null)
            {
                return HttpNotFound();
            }
            Common.Soserial = id;
            ViewBag.MaHTTT = new SelectList(db.HinhThucThanhToan, "MaHTTT", "TenHTTT");
            ViewBag.MaNV = new SelectList(db.NhanVien, "MaNV", "TenNV");
            ViewBag.MaTT = new SelectList(db.TrangThaiDonHang, "MaTT", "TenTT");
            ViewBag.MaKH = new SelectList(db.KhachHang, "MaKH", "MaKH");
            return View();
        }

        // POST: DonHangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateKH([Bind(Include = "MaDonHang,MaHTTT,MaTT,NgayMua,GhiChuDonHang,TongTienDH")] DonHang donHang)
        {
            var countKH = from p in db.DonHang where p.MaKH == Common.MaKH select p;
            int i = countKH.Count();
            if(Common.MaKH != "") { 
            if (ModelState.IsValid)
            {
                donHang.MaDonHang = Common.MaKH + i;
                   
                donHang.MaKH = Common.MaKH;
                donHang.MaTT = "TT0";
                donHang.NgayMua = DateTime.Now;
                Common.MaDH = donHang.MaDonHang;
                db.DonHang.Add(donHang);
                db.SaveChanges();
                return RedirectToAction("CreateKH","ChiTietDonHangs");
            }
            }
            else
            {
                SetAlert("Vui Lòng đăng nhập trước khi mua hàng", "error");
                Common.Alert = "Hãy đăng nhập trước khi mua hàng";
                return RedirectToAction("LoginKH", "Logins");
            }
            ViewBag.MaHTTT = new SelectList(db.HinhThucThanhToan, "MaHTTT", "TenHTTT", donHang.MaHTTT);
            ViewBag.MaNV = new SelectList(db.NhanVien, "MaNV", "MaLoaiNV", donHang.MaNV);
            ViewBag.MaTT = new SelectList(db.TrangThaiDonHang, "MaTT", "TenTT", donHang.MaTT);
            ViewBag.MaKH = new SelectList(db.KhachHang, "MaKH", "MaKH", donHang.MaKH);
            return View(donHang);
        }

        // GET: DonHangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHang.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHTTT = new SelectList(db.HinhThucThanhToan, "MaHTTT", "TenHTTT", donHang.MaHTTT);
            ViewBag.MaNV = new SelectList(db.NhanVien, "MaNV", "TenNV", donHang.MaNV);
            ViewBag.MaTT = new SelectList(db.TrangThaiDonHang, "MaTT", "TenTT", donHang.MaTT);
            ViewBag.MaKH = new SelectList(db.KhachHang, "MaKH", "MaKH", donHang.MaKH);
            return View(donHang);
        }

        // POST: DonHangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDonHang,MaHTTT,MaTT,MaKH,MaNV,NgayMua,GhiChuDonHang,SoLuongCT,TongTienDH")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                if (Common.MaNV != "")
                {
                    donHang.MaNV = Common.MaNV;
                }
                else
                {
                    Common.Alert = "Đăng nhập trước khi chỉnh sữa !";
                    return RedirectToAction("Login", "Logins");
                }
                db.Entry(donHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHTTT = new SelectList(db.HinhThucThanhToan, "MaHTTT", "TenHTTT", donHang.MaHTTT);
            ViewBag.MaNV = new SelectList(db.NhanVien, "MaNV", "TenNV", donHang.MaNV);
            ViewBag.MaTT = new SelectList(db.TrangThaiDonHang, "MaTT", "TenTT", donHang.MaTT);
            ViewBag.MaKH = new SelectList(db.KhachHang, "MaKH", "MaKH", donHang.MaKH);
            return View(donHang);
        }
        
        // GET: DonHangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHang.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        // POST: DonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DonHang donHang = db.DonHang.Find(id);

            db.DonHang.Remove(donHang);
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

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
    public class SanPhamsController : AlertController
    {
        private DataContexts db = new DataContexts();

        // GET: SanPhams
        public ActionResult Index()
        {
            var sanPham = db.SanPham.Include(s => s.GiaSP).Include(s => s.KhuyenMai).Include(s => s.LoaiSP).Include(s => s.NhaSanXuat).Include(s => s.NhomSanPham);
            //var sanPham = from giasp in db.GiaSP
            //              join sp in db.SanPham on giasp.MaGiaSP equals sp.MaGiaSP
            //              join km in db.KhachHang on sp.MaKM equals km.MaKH
            //              join sx in db.NhaSanXuat on sp.MaNSX equals sx.MaNSX
            //              join nsp in db.NhomSanPham on sp.MaNhomSP equals nsp.MaNhomSP
            //              where sp.SLTonKho == 1
            //              select sp;

            return View(sanPham.ToList());
        }

        public string FindHASP(string id)
        {
            string chuoi = "";
            var hinhAnhSP = from p in db.HinhAnhSP where p.SerialNumber == id select p;
            foreach (HinhAnhSP ha in hinhAnhSP)
            {

                chuoi += ha.LinkHASP;
                return chuoi;

            }
            return "";
        }
        // GET: SanPhams/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: SanPhams/Create
        public ActionResult Create()
        {
            ViewBag.MaGiaSP = new SelectList(db.GiaSP, "MaGiaSP", "MaGiaSP");
            ViewBag.MaKM = new SelectList(db.KhuyenMai, "MaKM", "TenKM");
            ViewBag.MaLoaiSP = new SelectList(db.LoaiSP, "MaLoaiSP", "TenLoaiSP");
            ViewBag.MaNSX = new SelectList(db.NhaSanXuat, "MaNSX", "TenNSX");
            ViewBag.MaNhomSP = new SelectList(db.NhomSanPham, "MaNhomSP", "TenNhomSP");
            return View();
        }

        // POST: SanPhams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SerialNumber,MaLoaiSP,MaNSX,MaGiaSP,MaKM,MaNhomSP,TenSP,SLTonKho,MoTaNgan,MoTaChiTiet,TGBaoHanh")] SanPham sanPham)
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
                sanPham.SLTonKho = 1;
                db.SanPham.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaGiaSP = new SelectList(db.GiaSP, "MaGiaSP", "MaGiaSP", sanPham.MaGiaSP);
            ViewBag.MaKM = new SelectList(db.KhuyenMai, "MaKM", "TenKM", sanPham.MaKM);
            ViewBag.MaLoaiSP = new SelectList(db.LoaiSP, "MaLoaiSP", "TenLoaiSP", sanPham.MaLoaiSP);
            ViewBag.MaNSX = new SelectList(db.NhaSanXuat, "MaNSX", "TenNSX", sanPham.MaNSX);
            ViewBag.MaNhomSP = new SelectList(db.NhomSanPham, "MaNhomSP", "TenNhomSP", sanPham.MaNhomSP);
            return View(sanPham);
        }

        // GET: SanPhams/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaGiaSP = new SelectList(db.GiaSP, "MaGiaSP", "MaGiaSP", sanPham.MaGiaSP);
            ViewBag.MaKM = new SelectList(db.KhuyenMai, "MaKM", "TenKM", sanPham.MaKM);
            ViewBag.MaLoaiSP = new SelectList(db.LoaiSP, "MaLoaiSP", "TenLoaiSP", sanPham.MaLoaiSP);
            ViewBag.MaNSX = new SelectList(db.NhaSanXuat, "MaNSX", "TenNSX", sanPham.MaNSX);
            ViewBag.MaNhomSP = new SelectList(db.NhomSanPham, "MaNhomSP", "TenNhomSP", sanPham.MaNhomSP);
            return View(sanPham);
        }

        // POST: SanPhams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SerialNumber,MaLoaiSP,MaNSX,MaGiaSP,MaKM,MaNhomSP,TenSP,SLTonKho,MoTaNgan,MoTaChiTiet,TGBaoHanh")] SanPham sanPham)
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
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaGiaSP = new SelectList(db.GiaSP, "MaGiaSP", "MaGiaSP", sanPham.MaGiaSP);
            ViewBag.MaKM = new SelectList(db.KhuyenMai, "MaKM", "TenKM", sanPham.MaKM);
            ViewBag.MaLoaiSP = new SelectList(db.LoaiSP, "MaLoaiSP", "TenLoaiSP", sanPham.MaLoaiSP);
            ViewBag.MaNSX = new SelectList(db.NhaSanXuat, "MaNSX", "TenNSX", sanPham.MaNSX);
            ViewBag.MaNhomSP = new SelectList(db.NhomSanPham, "MaNhomSP", "TenNhomSP", sanPham.MaNhomSP);
            return View(sanPham);
        }

        // GET: SanPhams/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPham.Find(id);
            db.SanPham.Remove(sanPham);
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


        public ActionResult IndexKH()
        {
          
                var select = from p in db.SanPham join giasp in db.GiaSP on p.MaGiaSP equals giasp.MaGiaSP select p;
                return View(select.ToList());
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IndexKH(string ID)
        {
           
                var select = from p in db.SanPham join giasp in db.GiaSP on p.MaGiaSP equals giasp.MaGiaSP select p;
                Common.Soserial = ID;
                Common.Alert = "";
                return View(select.ToList());
           
        }
    }
}

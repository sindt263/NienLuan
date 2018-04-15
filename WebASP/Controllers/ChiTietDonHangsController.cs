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
    public class ChiTietDonHangsController : Controller
    {
        private DataContexts db = new DataContexts();

        // GET: ChiTietDonHangs
        public ActionResult Index()
        {
            var chiTietDonHang = db.ChiTietDonHang.Include(c => c.SanPham);
            return View(chiTietDonHang.ToList());
        }

        // GET: ChiTietDonHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDonHang chiTietDonHang = db.ChiTietDonHang.Find(id);
            if (chiTietDonHang == null)
            {
                return HttpNotFound();
            }
            return View(chiTietDonHang);
        }


        public ActionResult DetailsKH(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //ChiTietDonHang chiTietDonHang = db.ChiTietDonHang.Find(id);
            var listKH = from p in db.ChiTietDonHang where p.MaDonHang == id select p;
            if (listKH == null)
            {
                return HttpNotFound();
            }
            return View(listKH.ToList());
        }
        // GET: ChiTietDonHangs/Create
        public ActionResult Create()
        {
            ViewBag.SerialNumber = new SelectList(db.SanPham, "SerialNumber", "SerialNumber");
            ViewBag.MaDonHang = new SelectList(db.DonHang, "MaDonHang", "MaDonHang");
            return View();
        }

        public int KTTonTai(int temp)
        {
            var KTTontai = from TT in db.ChiTietDonHang where TT.MaCTDH == temp select TT;
            if (KTTontai.Count() == 0)
            {
                return temp;
            }
            else
            {
                return KTTonTai(temp + 1);
            }
        }

        // POST: ChiTietDonHangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCTDH,MaDonHang,SerialNumber,DonGiaCT,DiaChiGiaoHang")] ChiTietDonHang chiTietDonHang)
        {
            int? gia;
            string serial = Request["SerialNumber"];
            var giasp = from p in db.SanPham join q in db.GiaSP on p.MaGiaSP equals q.MaGiaSP where p.SerialNumber == serial select p.GiaSP.GiaSPHienTai;
            foreach (var i in giasp)
            {
                chiTietDonHang.DonGiaCT = Convert.ToInt32(i);
            }
            var count = from sl in db.ChiTietDonHang select sl;
            int a = KTTonTai(count.Count());
            if (ModelState.IsValid)
            {
                chiTietDonHang.MaCTDH = a;
                db.ChiTietDonHang.Add(chiTietDonHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SerialNumber = new SelectList(db.SanPham, "SerialNumber", "MaLoaiSP", chiTietDonHang.SerialNumber);
            ViewBag.MaDonHang = new SelectList(db.DonHang, "MaDonHang", "MaDonHang", chiTietDonHang.MaDonHang);
            return View(chiTietDonHang);
        }


        public ActionResult CreateKH()
        {
            ViewBag.error = "Mã ĐH " + Common.MaDH;
            ViewBag.error1 = "Số serial " + Common.Soserial;
            ViewBag.error2 = "Mẫ KH " + Common.MaKH;
            ViewBag.SerialNumber = new SelectList(db.SanPham, "SerialNumber", "SerialNumber");
            ViewBag.MaDonHang = new SelectList(db.DonHang, "MaDonHang", "MaDonHang");
            return View();
        }



        // POST: ChiTietDonHangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateKH([Bind(Include = "MaCTDH,MaDonHang,SerialNumber,DonGiaCT,DiaChiGiaoHang")] ChiTietDonHang chiTietDonHang)
        {
            var giasp = from p in db.SanPham join q in db.GiaSP on p.MaGiaSP equals q.MaGiaSP where p.SerialNumber == Common.Soserial select p.GiaSP.GiaSPHienTai;

            var count = from sl in db.ChiTietDonHang select sl;
            int a = KTTonTai(count.Count());
            if (Common.MaKH != "")
            {
                if (ModelState.IsValid)
                {
                    foreach (var i in giasp)
                    {
                        chiTietDonHang.DonGiaCT = Convert.ToInt32(i);
                    }
                    chiTietDonHang.MaCTDH = a;
                    chiTietDonHang.MaDonHang = Common.MaDH;
                    chiTietDonHang.SerialNumber = Common.Soserial;
                    db.ChiTietDonHang.Add(chiTietDonHang);
                    db.SaveChanges();
                    Common.Alert = "Đã mua hàng thành công, bạn có thể tiếp tục mua!";
                    return RedirectToAction("IndexKH","SanPhams");
                }
                else
                {
                    ViewBag.error = "Bị lổi gì đó và chưa thêm được";
                }
            }

            else
            {
                return RedirectToAction("LoginKH", "Logins");
            }
            ViewBag.SerialNumber = new SelectList(db.SanPham, "SerialNumber", "MaLoaiSP", chiTietDonHang.SerialNumber);
            ViewBag.MaDonHang = new SelectList(db.DonHang, "MaDonHang", "MaDonHang", chiTietDonHang.MaDonHang);
            return View(chiTietDonHang);
        }
        // GET: ChiTietDonHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDonHang chiTietDonHang = db.ChiTietDonHang.Find(id);
            if (chiTietDonHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.SerialNumber = new SelectList(db.SanPham, "SerialNumber", "MaLoaiSP", chiTietDonHang.SerialNumber);
            ViewBag.MaDonHang = new SelectList(db.DonHang, "MaDonHang", "MaDonHang", chiTietDonHang.MaDonHang);
            return View(chiTietDonHang);
        }

        // POST: ChiTietDonHangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCTDH,MaDonHang,SerialNumber,DonGiaCT,DiaChiGiaoHang")] ChiTietDonHang chiTietDonHang)
        {
            int? gia;
            string serial = Request["SerialNumber"];
            var giasp = from p in db.SanPham join q in db.GiaSP on p.MaGiaSP equals q.MaGiaSP where p.SerialNumber == serial select p.GiaSP.GiaSPHienTai;
            foreach (var i in giasp)
            {
                chiTietDonHang.DonGiaCT = Convert.ToInt32(i);
            }
            if (ModelState.IsValid)
            {
                db.Entry(chiTietDonHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SerialNumber = new SelectList(db.SanPham, "SerialNumber", "MaLoaiSP", chiTietDonHang.SerialNumber);
            ViewBag.MaDonHang = new SelectList(db.DonHang, "MaDonHang", "MaDonHang", chiTietDonHang.MaDonHang);
            return View(chiTietDonHang);
        }

        // GET: ChiTietDonHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDonHang chiTietDonHang = db.ChiTietDonHang.Find(id);
            if (chiTietDonHang == null)
            {
                return HttpNotFound();
            }
            return View(chiTietDonHang);
        }

        // POST: ChiTietDonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietDonHang chiTietDonHang = db.ChiTietDonHang.Find(id);
            db.ChiTietDonHang.Remove(chiTietDonHang);
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

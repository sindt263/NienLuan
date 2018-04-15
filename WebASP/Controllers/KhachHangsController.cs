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
    public class KhachHangsController : Controller
    {
        private DataContexts db = new DataContexts();

        // GET: KhachHangs
        public ActionResult Index()
        {
            return View(db.KhachHang.ToList());
        }

        [HttpGet]
        public ActionResult IndexKH()
        {
            var KH = from p in db.KhachHang where p.MaKH == Common.MaKH select p;
            return View(KH.ToList());
        }

        [HttpPost]
        public ActionResult IndexKH(KhachHang kh)
        {
            if (Common.Alert != "") Common.Alert = "";
            var KH = from p in db.KhachHang where p.MaKH == Common.MaKH select p;
            
            return View(KH.ToList());
        }
        // GET: KhachHangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHang.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // GET: KhachHangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KhachHangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKH,TenKH,TaiKhoanKH,MatKhauKH,DiaChiKH,SDTKH,EmailKH,GioiTinhKH")] KhachHang khachHang)
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
                db.KhachHang.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khachHang);
        }


        public ActionResult CreateKH()
        {
            return View();
        }

        // POST: KhachHangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateKH([Bind(Include = "MaKH,TenKH,TaiKhoanKH,MatKhauKH,DiaChiKH,SDTKH,EmailKH,GioiTinhKH")] KhachHang khachHang)
        {
            var slkh = from p in db.KhachHang select p;
            int sl = slkh.Count() +1;
            if (ModelState.IsValid)
            {
                khachHang.MaKH = sl.ToString();
                db.KhachHang.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction("IndexKH");
            }

            return View(khachHang);
        }

        // GET: KhachHangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHang.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: KhachHangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKH,TenKH,TaiKhoanKH,MatKhauKH,DiaChiKH,SDTKH,EmailKH,GioiTinhKH")] KhachHang khachHang)
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
                db.Entry(khachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khachHang);
        }

        [HttpGet]
        // GET: KhachHangs/Edit/5
        public ActionResult EditKH(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHang.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: KhachHangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditKH([Bind(Include = "MaKH,TenKH,TaiKhoanKH,MatKhauKH,DiaChiKH,SDTKH,EmailKH,GioiTinhKH")] KhachHang khachHang)
        {
            if (Common.Alert != "") Common.Alert = "";
            if (ModelState.IsValid)
            {
                if (Common.MaKH != "")
                {

                }
                else
                {
                    Common.Alert = "Đăng nhập trước khi chỉnh sữa !";
                    return RedirectToAction("LoginKH", "Logins");
                }
                db.Entry(khachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexKH");
            }
            return View(khachHang);
        }

        [HttpGet]
        // GET: KhachHangs/Edit/5
        public ActionResult EditKHPass(string id)
        {
            if (Common.MaKH != "")
            {

            }
            else
            {
                Common.Alert = "Đăng nhập trước khi chỉnh sữa !";
                return RedirectToAction("LoginKH", "Logins");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHang.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditKHPass([Bind(Include = "MaKH,TenKH,TaiKhoanKH,MatKhauKH,DiaChiKH,SDTKH,EmailKH,GioiTinhKH")] KhachHang khachHang)
        {
            if (Common.Alert != "") Common.Alert = "";
            string MK1 = Request["MatKhauKH"];
            string mk2 = Request["XNMatKhauKH"];
            if (MK1 == mk2)
            {
                if (ModelState.IsValid)
            {
               
                db.Entry(khachHang).State = EntityState.Modified;
                db.SaveChanges();
                    Common.Alert = "Đã cập nhật mật khẩu";
                return RedirectToAction("IndexKH");
            }
            }
            else
            {
                Common.Alert = "Mật khẩu không khớp";
            }
            return View(khachHang);
        }
        // GET: KhachHangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHang.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: KhachHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KhachHang khachHang = db.KhachHang.Find(id);
            db.KhachHang.Remove(khachHang);
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

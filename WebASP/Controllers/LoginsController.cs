using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebASP.Models;

namespace WebASP.Controllers
{
    public class LoginsController : Controller
    {
        // GET: Logins
        [HttpGet]
        public ActionResult Index()
        {
            Common.MaNV = "";
            return View();
        }
        DataContexts db = new DataContexts();

        public ActionResult Login()
        {
            Common.MaNV = "";
            return View();
        }

        [HttpPost]
        public ActionResult Login(NhanVien nv)
        {
            string a = "";
            var select = from p in db.NhanVien where p.TaiKhoan == nv.TaiKhoan && p.MatKhau == nv.MatKhau select p;
            foreach (var i in select)
            {
                if (i.TaiKhoan == nv.TaiKhoan && i.MatKhau == nv.MatKhau)
                {
                    Common.MaNV = i.MaNV;
                    return RedirectToAction("Index", "Home");
                }
                else ViewBag.error = "Tài khoản hoặc mật khẩu sai";
                a += i.TaiKhoan;
            }
            ViewBag.view = a;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(NhanVien nv)
        {
            string a = "";
            var select = from p in db.NhanVien where p.TaiKhoan == nv.TaiKhoan && p.MatKhau == nv.MatKhau select p;
            foreach (var i in select)
            {
                Common.MaNV = i.MaNV;
                if (i.TaiKhoan == nv.TaiKhoan && i.MatKhau == nv.MatKhau)
                {
                    return RedirectToAction("Index", "Home");
                }
                else ViewBag.error = "Tài khoản hoặc mật khẩu sai";
                a += i.TaiKhoan;
            }
            ViewBag.view = a;
            return View();
        }

     
        [HttpGet]
        public ActionResult LoginKH()
        {
            Common.MaKH = "";
            var select = from p in db.KhachHang where p.TaiKhoanKH == "123" && p.MatKhauKH == "123" select p;
            foreach(var i in select)
            {
                ViewBag.v = i.TaiKhoanKH;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginKH(KhachHang kh)
        {
            if (Common.Alert != "") Common.Alert = "";
            
            string a = "";
            var select = from p in db.KhachHang where p.TaiKhoanKH == kh.TaiKhoanKH && p.MatKhauKH == kh.MatKhauKH select p;
            
                if (select.Count() >= 1)
                {
                foreach (var i in select)
                {
                    Common.MaKH = i.MaKH;
                }
                return RedirectToAction("IndexKH","Home");

                }
            
                else ViewBag.error = "Tài khoản hoặc mật khẩu sai";

            ViewBag.view = a;
            return View();
        }
      

       
    }
}
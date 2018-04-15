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
    public class HinhAnhSPsController : Controller
    {
        private DataContexts db = new DataContexts();

        // GET: HinhAnhSPs
        public ActionResult Index()
        {
            var hinhAnhSP = db.HinhAnhSP.Include(h => h.SanPham);
            return View(hinhAnhSP.ToList());
        }

        // GET: HinhAnhSPs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HinhAnhSP hinhAnhSP = db.HinhAnhSP.Find(id);
            if (hinhAnhSP == null)
            {
                return HttpNotFound();
            }
            return View(hinhAnhSP);
        }

        // GET: HinhAnhSPs/Create
        public ActionResult Create()
        {
            ViewBag.SerialNumber = new SelectList(db.SanPham, "SerialNumber", "SerialNumber");
            return View();
        }

        // POST: HinhAnhSPs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHASP,SerialNumber,LinkHASP")] HinhAnhSP hinhAnhSP)
        {
            var Image = Request.Files["Image"];
            var path = Server.MapPath("~/Images/" + Image.FileName);
            Image.SaveAs(path);
            var sl = from p in db.HinhAnhSP select p;
            int a = sl.Count() +1;
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
                hinhAnhSP.MaHASP = a.ToString();
                hinhAnhSP.LinkHASP = "/Images/" + Image.FileName;
                db.HinhAnhSP.Add(hinhAnhSP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SerialNumber = new SelectList(db.SanPham, "SerialNumber", "SerialNumber", hinhAnhSP.SerialNumber);
            return View(hinhAnhSP);
        }

        // GET: HinhAnhSPs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HinhAnhSP hinhAnhSP = db.HinhAnhSP.Find(id);
            if (hinhAnhSP == null)
            {
                return HttpNotFound();
            }
            ViewBag.SerialNumber = new SelectList(db.SanPham, "SerialNumber", "SerialNumber", hinhAnhSP.SerialNumber);
            return View(hinhAnhSP);
        }

        // POST: HinhAnhSPs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHASP,SerialNumber,LinkHASP")] HinhAnhSP hinhAnhSP)
        {
            var Image = Request.Files["Image"];
            var path = Server.MapPath("~/Images/" + Image.FileName);
            Image.SaveAs(path);
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
                hinhAnhSP.LinkHASP = "/Images/" + Image.FileName;
                db.Entry(hinhAnhSP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SerialNumber = new SelectList(db.SanPham, "SerialNumber", "SerialNumber", hinhAnhSP.SerialNumber);
            return View(hinhAnhSP);
        }

        // GET: HinhAnhSPs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HinhAnhSP hinhAnhSP = db.HinhAnhSP.Find(id);
            if (hinhAnhSP == null)
            {
                return HttpNotFound();
            }
            return View(hinhAnhSP);
        }

        // POST: HinhAnhSPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HinhAnhSP hinhAnhSP = db.HinhAnhSP.Find(id);
            db.HinhAnhSP.Remove(hinhAnhSP);
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

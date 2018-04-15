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
    public class GiaSPsController : Controller
    {
        private DataContexts db = new DataContexts();

        // GET: GiaSPs
        public ActionResult Index()
        {
            return View(db.GiaSP.ToList());
        }

        // GET: GiaSPs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaSP giaSP = db.GiaSP.Find(id);
            if (giaSP == null)
            {
                return HttpNotFound();
            }
            return View(giaSP);
        }

        // GET: GiaSPs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GiaSPs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaGiaSP,GiaSauUpdate,GiaSPHienTai,NgayCapNhat,NgayApDung")] GiaSP giaSP)
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
                db.GiaSP.Add(giaSP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(giaSP);
        }

        // GET: GiaSPs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaSP giaSP = db.GiaSP.Find(id);
            if (giaSP == null)
            {
                return HttpNotFound();
            }
            return View(giaSP);
        }

        // POST: GiaSPs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaGiaSP,GiaSauUpdate,GiaSPHienTai,NgayCapNhat,NgayApDung")] GiaSP giaSP)
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
                db.Entry(giaSP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(giaSP);
        }

        // GET: GiaSPs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaSP giaSP = db.GiaSP.Find(id);
            if (giaSP == null)
            {
                return HttpNotFound();
            }
            return View(giaSP);
        }

        // POST: GiaSPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GiaSP giaSP = db.GiaSP.Find(id);
            db.GiaSP.Remove(giaSP);
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

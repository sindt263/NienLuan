using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebASP.Models;

namespace WebASP.Controllers
{
    public class HinhThucThanhToansController : Controller
    {
        private DataContexts db = new DataContexts();

        // GET: HinhThucThanhToans
        public async Task<ActionResult> Index()
        {
            return View(await db.HinhThucThanhToan.ToListAsync());
        }

        // GET: HinhThucThanhToans/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HinhThucThanhToan hinhThucThanhToan = await db.HinhThucThanhToan.FindAsync(id);
            if (hinhThucThanhToan == null)
            {
                return HttpNotFound();
            }
            return View(hinhThucThanhToan);
        }

        // GET: HinhThucThanhToans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HinhThucThanhToans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaHTTT,TenHTTT,MoToHTTT")] HinhThucThanhToan hinhThucThanhToan)
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
                db.HinhThucThanhToan.Add(hinhThucThanhToan);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(hinhThucThanhToan);
        }

        // GET: HinhThucThanhToans/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HinhThucThanhToan hinhThucThanhToan = await db.HinhThucThanhToan.FindAsync(id);
            if (hinhThucThanhToan == null)
            {
                return HttpNotFound();
            }
            return View(hinhThucThanhToan);
        }

        // POST: HinhThucThanhToans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaHTTT,TenHTTT,MoToHTTT")] HinhThucThanhToan hinhThucThanhToan)
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
                db.Entry(hinhThucThanhToan).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(hinhThucThanhToan);
        }

        // GET: HinhThucThanhToans/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HinhThucThanhToan hinhThucThanhToan = await db.HinhThucThanhToan.FindAsync(id);
            if (hinhThucThanhToan == null)
            {
                return HttpNotFound();
            }
            return View(hinhThucThanhToan);
        }

        // POST: HinhThucThanhToans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            HinhThucThanhToan hinhThucThanhToan = await db.HinhThucThanhToan.FindAsync(id);
            db.HinhThucThanhToan.Remove(hinhThucThanhToan);
            await db.SaveChangesAsync();
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

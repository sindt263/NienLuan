using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebASP.Models;
namespace WebASP.Controllers
{
    public class BaoHanhsController : Controller
    {
        private DataContexts db = new DataContexts();

        // GET: BaoHanhs
        public ActionResult Index()
        {
            return View(db.BaoHanh.ToList());
        }

        // GET: BaoHanhs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaoHanh baoHanh = db.BaoHanh.Find(id);
            if (baoHanh == null)
            {
                return HttpNotFound();
            }
            return View(baoHanh);
        }

        // GET: BaoHanhs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BaoHanhs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaBH,HinhThucBH,MoTaBH")] BaoHanh baoHanh)
        {
            var sl = from p in db.BaoHanh select p;
            int i = sl.Count() +1;
            if (ModelState.IsValid)
            {
                if (Common.MaNV != "")
                {
                    baoHanh.MaBH = "BH" + i.ToString();
                }
                else
                {
                    Common.Alert = "Đăng nhập trước khi chỉnh sữa !";
                    return RedirectToAction("Index", "Logins");
                }
                
                db.BaoHanh.Add(baoHanh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(baoHanh);
        }

        // GET: BaoHanhs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaoHanh baoHanh = db.BaoHanh.Find(id);
            if (baoHanh == null)
            {
                return HttpNotFound();
            }
            return View(baoHanh);
        }

        // POST: BaoHanhs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaBH,HinhThucBH,MoTaBH")] BaoHanh baoHanh)
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

                db.Entry(baoHanh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(baoHanh);
        }

        // GET: BaoHanhs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaoHanh baoHanh = db.BaoHanh.Find(id);
            if (baoHanh == null)
            {
                return HttpNotFound();
            }
            return View(baoHanh);
        }

        // POST: BaoHanhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BaoHanh baoHanh = db.BaoHanh.Find(id);
            db.BaoHanh.Remove(baoHanh);
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

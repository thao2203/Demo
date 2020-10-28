using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BAIVIETsController : Controller
    {
        private Model1 db = new Model1();

        // GET: BAIVIETs
        public ActionResult Index()
        {
            return View(db.BAIVIETs.ToList());
        }
        public JsonResult getTenDMC(string maDMC)
        {
            SqlConnection conStr = new SqlConnection(@"Data Source=DESKTOP-PDPTD6M\MSSQLSERVER01;Initial Catalog=PROJECT3_BlogAmThuc;Integrated Security=True");
            SqlDataAdapter TenDMC = new SqlDataAdapter("SELECT TENDMC FROM DANHMUCCON WHERE MADMC='"+maDMC+"'", conStr);
            DataTable dt = new DataTable();
            TenDMC.Fill(dt);
            List<DANHMUCCON> li = new List<DANHMUCCON>();
            foreach (DataRow dr in dt.Rows)
            {
                DANHMUCCON sp = new DANHMUCCON();
                sp.tenDMC = dt.Rows[0].ToString();
                li.Add(sp);
            }

            return Json(li, JsonRequestBehavior.AllowGet);

        }
        public JsonResult get()
        {
             return Json(db.BAIVIETs.ToList(),JsonRequestBehavior.AllowGet);
        }
        // GET: BAIVIETs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAIVIET bAIVIET = db.BAIVIETs.Find(id);
            if (bAIVIET == null)
            {
                return HttpNotFound();
            }
            return View(bAIVIET);
        }

        // GET: BAIVIETs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BAIVIETs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maBV,taiKhoanUs,maBL,maDMC,tieuDe,noiDung,hinhAnh,thoiGianDang,trangThai")] BAIVIET bAIVIET)
        {
            if (ModelState.IsValid)
            {
                db.BAIVIETs.Add(bAIVIET);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bAIVIET);
        }

        // GET: BAIVIETs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAIVIET bAIVIET = db.BAIVIETs.Find(id);
            if (bAIVIET == null)
            {
                return HttpNotFound();
            }
            return View(bAIVIET);
        }

        // POST: BAIVIETs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maBV,taiKhoanUs,maBL,maDMC,tieuDe,noiDung,hinhAnh,thoiGianDang,trangThai")] BAIVIET bAIVIET)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bAIVIET).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bAIVIET);
        }

        // GET: BAIVIETs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAIVIET bAIVIET = db.BAIVIETs.Find(id);
            if (bAIVIET == null)
            {
                return HttpNotFound();
            }
            return View(bAIVIET);
        }

        // POST: BAIVIETs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BAIVIET bAIVIET = db.BAIVIETs.Find(id);
            db.BAIVIETs.Remove(bAIVIET);
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

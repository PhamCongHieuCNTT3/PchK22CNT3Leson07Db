using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PchKiemTraGK.Models;

namespace PchKiemTraGK.Controllers
{
    public class pchSinhViensController : Controller
    {
        private PchK22CNT3Lesson07DbEntities db = new PchK22CNT3Lesson07DbEntities();

        // GET: pchSinhViens
        public ActionResult PchIndex()
        {
            var pchSinhViens = db.pchSinhViens.Include(p => p.pchKhoa);
            return View(pchSinhViens.ToList());
        }

        // GET: pchSinhViens/Details/5
        public ActionResult PchDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pchSinhVien pchSinhVien = db.pchSinhViens.Find(id);
            if (pchSinhVien == null)
            {
                return HttpNotFound();
            }
            return View(pchSinhVien);
        }

        // GET: pchSinhViens/Create
        public ActionResult PchCreate()
        {
            ViewBag.PchMaKH = new SelectList(db.pchKhoas, "PchMaKH", "PchTenKH");
            return View();
        }

        // POST: pchSinhViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PchCreate([Bind(Include = "PchMaSV,PchHoSV,PchTenSV,PchNgaySinh,PchPhai,PchPhone,PchEmail,PchMaKH")] pchSinhVien pchSinhVien)
        {
            if (ModelState.IsValid)
            {
                db.pchSinhViens.Add(pchSinhVien);
                db.SaveChanges();
                return RedirectToAction("PchIndex");
            }

            ViewBag.PchMaKH = new SelectList(db.pchKhoas, "PchMaKH", "PchTenKH", pchSinhVien.PchMaKH);
            return View(pchSinhVien);
        }

        // GET: pchSinhViens/Edit/5
        public ActionResult PchEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pchSinhVien pchSinhVien = db.pchSinhViens.Find(id);
            if (pchSinhVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.PchMaKH = new SelectList(db.pchKhoas, "PchMaKH", "PchTenKH", pchSinhVien.PchMaKH);
            return View(pchSinhVien);
        }

        // POST: pchSinhViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PchEdit([Bind(Include = "PchMaSV,PchHoSV,PchTenSV,PchNgaySinh,PchPhai,PchPhone,PchEmail,PchMaKH")] pchSinhVien pchSinhVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pchSinhVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PchIndex");
            }
            ViewBag.PchMaKH = new SelectList(db.pchKhoas, "PchMaKH", "PchTenKH", pchSinhVien.PchMaKH);
            return View(pchSinhVien);
        }

        // GET: pchSinhViens/Delete/5
        public ActionResult PchDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pchSinhVien pchSinhVien = db.pchSinhViens.Find(id);
            if (pchSinhVien == null)
            {
                return HttpNotFound();
            }
            return View(pchSinhVien);
        }

        // POST: pchSinhViens/Delete/5
        [HttpPost, ActionName("PchDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            pchSinhVien pchSinhVien = db.pchSinhViens.Find(id);
            db.pchSinhViens.Remove(pchSinhVien);
            db.SaveChanges();
            return RedirectToAction("PchIndex");
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

using BTL_TTCN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BTL_TTCN.Areas.Admin.Controllers
{
    public class DanhMucController : Controller
    {
        TTCN db = new TTCN();
        // GET: Admin/DanhMuc
        public ActionResult Index()
        {
            var items = db.DanhMucs;
            return View(items);
        }
        public ActionResult Add()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(DanhMuc model)
        {
          

            if (ModelState.IsValid)
            {
                if (db.DanhMucs.Any(d => d.MaDanhMuc == model.MaDanhMuc))
                {

                    ViewBag.error = "Mã danh mục đã tôn tại";
                }
                else
                {
                    model.NgayTao = DateTime.Now;
                    db.DanhMucs.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }

            return View(model);
        }
        public ActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var item = db.DanhMucs.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DanhMuc model)
        {
            if (ModelState.IsValid)
            {

                db.DanhMucs.Attach(model);
                model.NgayTao = DateTime.Now;
                db.Entry(model).Property(x => x.TenDanhMuc).IsModified = true;
                db.Entry(model).Property(x => x.MoTa).IsModified = true;
                db.Entry(model).Property(x => x.NgayTao).IsModified = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(string MaDanhMuc)
        {
            var item = db.DanhMucs.Find(MaDanhMuc);
            if (item != null)
            {
                db.DanhMucs.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });

        }
    }
}
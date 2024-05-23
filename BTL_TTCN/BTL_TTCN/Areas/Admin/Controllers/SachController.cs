using BTL_TTCN.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_TTCN.Areas.Admin.Controllers
{
    public class SachController : Controller
    {
        TTCN db = new TTCN();

        // GET: Admin/Sach
        public ActionResult Index(int? page)
        {
            IEnumerable<Sach> items = db.Saches.OrderByDescending(x => x.MaSach);
            var pageSize = 10;
            if (page == null)
            {
                page=1;
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }
        public ActionResult Add()
        {
            ViewBag.MaTheLoai = new SelectList(db.TheLoais.ToList(), "MaTheLoai", "TenTheLoai");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Sach model)
        {
            if (ModelState.IsValid)
            {  
                db.Saches.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaTheLoai = new SelectList(db.TheLoais.ToList(), "MaTheLoai", "TenTheLoai");
            return View(model);
        }
        public ActionResult Edit(string id)
        {
           
            var item = db.Saches.Find(id);
            ViewBag.MaTheLoai = new SelectList(db.TheLoais, "MaTheLoai", "TenTheLoai", item.MaTheLoai);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Sach model)
        {
            if (ModelState.IsValid)
            {


            
                db.Saches.Attach(model);
                db.Entry(model).State=System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaTheLoai = new SelectList(db.TheLoais, "MaTheLoai", "TenTheLoai", model.MaTheLoai);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            var item = db.Saches.Find(id);
            if (item != null)
            {
                db.Saches.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });

        }
    }
}
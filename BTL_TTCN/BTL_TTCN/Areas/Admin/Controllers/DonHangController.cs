using BTL_TTCN.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_TTCN.Areas.Admin.Controllers
{
    public class DonHangController : Controller
    {
        TTCN db = new TTCN();

        // GET: Admin/DonHang
        public ActionResult Index(int? page)
        {
            IEnumerable<DonHang> items = db.DonHangs.OrderByDescending(x => x.MaDonHang);
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
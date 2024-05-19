using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTL_TTCN.Models;

namespace BTL_TTCN.Controllers
{
    public class SachesController : Controller
    {
        private TTCN db = new TTCN();

        public ActionResult Index(string SearchString)
        {
            var sach = db.Saches.Include(t => t.TheLoai);
            if (!String.IsNullOrEmpty(SearchString))
            {
                sach = sach.Where(p => p.TenSach == SearchString);
            }
            return View(sach.ToList());
        }

        public PartialViewResult CategoryMenu()
        {
            var li = db.TheLoais.ToList();
            return PartialView(li);
        }

        [Route("SachTheoTheLoai/{MaTheLoai}")]
        public ActionResult HienThiTheoTheLoai(string MaTheLoai)
        {
            var list = db.Saches.Where(p => p.MaTheLoai == MaTheLoai).ToList();
            return View(list);
        }

        // GET: Saches/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // GET: Saches/Create
        public ActionResult Create()
        {
            ViewBag.MaTheLoai = new SelectList(db.TheLoais, "MaTheLoai", "TenTheLoai");
            return View();
        }

        // POST: Saches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSach,TenSach,AnhMinhHoa,GiaBan,SoLuong,DanhGia,MaTheLoai")] Sach sach)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    sach.AnhMinhHoa = "";
                    var f = Request.Files["AnhFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        Console.WriteLine(FileName);
                        string UploadPath = Server.MapPath("~/Content/Sach/" + FileName);
                        f.SaveAs(UploadPath);
                        sach.AnhMinhHoa = FileName;
                    }

                    db.Saches.Add(sach);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu" + ex.Message;
                ViewBag.MaTheLoai = new SelectList(db.TheLoais, "MaTheLoai", "TenTheLoai", sach.MaTheLoai);
                return View(sach);
            }

        }

        // GET: Saches/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaTheLoai = new SelectList(db.TheLoais, "MaTheLoai", "TenTheLoai", sach.MaTheLoai);
            return View(sach);
        }

        // POST: Saches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSach,TenSach,AnhMinhHoa,GiaBan,SoLuong,DanhGia,MaTheLoai")] Sach sach)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var f = Request.Files["AnhFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        Console.WriteLine(FileName);
                        string UploadPath = Server.MapPath("~/Content/Images/" + FileName);
                        f.SaveAs(UploadPath);
                        sach.AnhMinhHoa = FileName;
                    }
                    db.Entry(sach).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu" + e;
                ViewBag.MaTheLoai = new SelectList(db.TheLoais, "MaTheLoai", "TenTheLoai", sach.MaTheLoai);
                return View(sach);
            }
        }

        // GET: Saches/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // POST: Saches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Sach sach = db.Saches.Find(id);
            try
            {
                db.Saches.Remove(sach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Không xóa được bản ghi này" + ex;
                return View("Delete", sach);
            }
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

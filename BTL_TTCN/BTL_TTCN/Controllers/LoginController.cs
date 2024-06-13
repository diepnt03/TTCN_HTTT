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
    public class LoginController : Controller
    {
        private TTCN db = new TTCN();
        


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        public ActionResult Login(string email, string matKhau)
        {
            var user = db.TaiKhoans.Where(u => u.Email == email && u.MatKhau== matKhau).FirstOrDefault();
            if (email == "admin" && matKhau == "1")
            {
                return RedirectToAction("Index", "DanhMuc", new { area = "Admin" });
            }
            
            else if (user == null)
            {
                ViewBag.errMsg = "Sai tên đăng nhập hoặc mật khẩu";
                return View("Login");
            }
            else
            {
                Session["email"] = user.TenNguoiNhan;
                
                return RedirectToAction("Index", "Saches");//chạy tới action Index
            }
        }
        public ActionResult Logout()
        {
            Session["email"] = null;
            return RedirectToAction("Index", "Saches");
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        //// GET: Login
        //public ActionResult Index()
        //{
        //    return View(db.TaiKhoans.ToList());
        //}

        //// GET: Login/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
        //    if (taiKhoan == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(taiKhoan);
        //}

        //// GET: Login/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Login/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "MaTaiKhoan,TenNguoiNhan,Email,MatKhau,SDT,DiaChi")] TaiKhoan taiKhoan)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.TaiKhoans.Add(taiKhoan);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(taiKhoan);
        //}

        //// GET: Login/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
        //    if (taiKhoan == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(taiKhoan);
        //}

        //// POST: Login/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "MaTaiKhoan,TenNguoiNhan,Email,MatKhau,SDT,DiaChi")] TaiKhoan taiKhoan)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(taiKhoan).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(taiKhoan);
        //}

        //// GET: Login/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
        //    if (taiKhoan == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(taiKhoan);
        //}

        //// POST: Login/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
        //    db.TaiKhoans.Remove(taiKhoan);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}

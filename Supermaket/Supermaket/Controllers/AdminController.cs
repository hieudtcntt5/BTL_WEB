using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Supermaket.DB;
using Supermaket.Models;

namespace Supermaket.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        BTL_WEBEntities db = new BTL_WEBEntities();
        public ActionResult Index()
        {
            List<HANGHOA> list = db.HANGHOAs.Where(m => m.MANHOMHANG == "Cake Candy").ToList();

            return View(list);
        }
        public PartialViewResult HienThiNhomHang()
        {
            return PartialView(db.NHOMHANGs.ToList());
        }
        public ActionResult ChiTietNhomHang(string ma)
        {
            List<HANGHOA> hh = db.HANGHOAs.Where(m => m.MANHOMHANG == ma).ToList();
            if(hh.Count == 0)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(hh);
        }
        [HttpGet]
        private void ConnectData()
        {
            ViewBag.MANHOMHANG = new SelectList(db.NHOMHANGs.OrderBy(m => m.TENNHOMHANG), "MANHOMHANG", "TENNHOMHANG");
            ViewBag.MANSX = new SelectList(db.NHASANXUATs.OrderBy(m => m.TENNSX), "MANSX", "TENNSX");
        }
        public ActionResult ThemMoiHangHoa()
        {
            ConnectData();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemMoiHangHoa(HANGHOA hh)
        {
            if(ModelState.IsValid)
            {
                ViewBag.tt = "Them thanh cong"; 
                db.HANGHOAs.Add(hh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            ConnectData();
            HANGHOA hh = db.HANGHOAs.SingleOrDefault(m => m.MAHANG == id);
            if (hh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(hh);
        }

        [HttpPost]
       public ActionResult Edit(string id,HANGHOA hangHoa)
        {
            HANGHOA hh = db.HANGHOAs.SingleOrDefault(m => m.MAHANG == id);
            if(hh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else
            {
                db.Entry(hangHoa).State = System.Data.Entity.EntityState.Modified;
            }
            return View(hh);
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            HANGHOA hh = db.HANGHOAs.SingleOrDefault(m => m.MAHANG == id);
            if (hh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(hh);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            HANGHOA hh = db.HANGHOAs.SingleOrDefault(m => m.MAHANG == id);
            if (hh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(hh);
        }
        [HttpPost]
        public ActionResult Delete(HANGHOA obj)
        {
            HANGHOA hh = db.HANGHOAs.SingleOrDefault(m => m.MAHANG == obj.MAHANG);
            db.HANGHOAs.Remove(hh);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
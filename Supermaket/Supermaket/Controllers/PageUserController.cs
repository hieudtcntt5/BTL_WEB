using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Supermaket.DB;
using PagedList;

namespace Supermaket.Controllers
{
    public class PageUserController : Controller
    {
        // GET: PageUser
        BTL_WEBEntities db = new BTL_WEBEntities();
        public ActionResult Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pagesize = 8;
            List<HANGHOA> list = db.HANGHOAs.Where(m => m.MANHOMHANG == "Cake Candy").ToList();
            ViewBag.tt = "Cake Candy";
            return View(list.ToPagedList(pageNumber,pagesize));
        }
        public PartialViewResult HienThiNhomHang()
        {
            return PartialView(db.NHOMHANGs.ToList());
        }

        public ActionResult ChiTietNhomHang(int? page,string ma)
        {
            int pageNumber = page ?? 1;
            int pagesize = 8;
            List<HANGHOA> hh = db.HANGHOAs.Where(m => m.MANHOMHANG == ma).ToList();

            ViewBag.tt = ma;
            if (hh.Count == 0)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(hh.ToPagedList(pageNumber,pagesize));
        }

        public ActionResult ChiTietSanPham(string ma)
        {
            HANGHOA sp = db.HANGHOAs.SingleOrDefault(m => m.MAHANG == ma);
            if(sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sp);
        }
    }
}
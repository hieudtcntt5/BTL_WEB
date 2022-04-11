using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Supermaket.DB;
using PagedList;

namespace Supermaket.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        BTL_WEBEntities db = new BTL_WEBEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TimKiemSanPham(FormCollection f , int? page)
        {
            String keySearch = f["search_pageuser"].ToString();
            int pageNumber = page ?? 1;
            int pagesize = 8;
            List<HANGHOA> list = db.HANGHOAs.Where(m => m.TENHANG.Contains(keySearch)).ToList();
            if(list.Count == 0)
            {
                ViewBag.tt = "Khong co san pham can tim kiem";
                return null;
            }
            ViewBag.tt = "San pham can tim";
            return View(list.ToPagedList(pageNumber,pagesize));

        }


    }
}
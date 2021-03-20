using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopthucung.Areas.admin.code;
using Shopthucung.Areas.admin.Models;
using Shopthucung.Models;

namespace Shopthucung.Areas.admin.Controllers
{
    public class hoadonController : Controller
    {
        
        // GET: admin/hoadon
        public ActionResult Index(int? Page)
        {
            if (SessionHelper.GetSession() != null)
            {
                sqlAdmin spModel = new sqlAdmin();
                int? page = 1;
                if (Page != null)
                    page = Page;
                int pagesize = 6;
                ViewBag.hd = spModel.getHoaDon((int)page, pagesize);
                return View(spModel.countPageHD((int)page, pagesize));
            }
            else
            {
                return RedirectToAction("index", "login");
            }
            
        }
        public ActionResult xoaHD(int MaHD)
        {
            sqlAdmin conn = new sqlAdmin();
            conn.deleteHD(MaHD);
            return RedirectToAction("Index");
        }
        public ActionResult chitiethoadon(int MaHD)
        {
            if (SessionHelper.GetSession() != null)
            {
                sqlAdmin spModel = new sqlAdmin();
                ViewBag.hoadon = spModel.getHoaDon(MaHD);
                return View(spModel.getChitiet(MaHD));
            }
            else
            {
                return RedirectToAction("index", "login");
            }
           
        }
        public ActionResult xoaCTHD(int MaHD,string MaSP)
        {
            sqlAdmin conn = new sqlAdmin();
            conn.deleteCTHD(MaHD, MaSP);
            return RedirectToAction("chitiethoadon",new {MaHD=MaHD });
        }
        [HttpPost]
        public JsonResult changeStatusHD(int MaHD)
        {
            try
            {
                shopDBmodel conn = new shopDBmodel();
                var hd = conn.hoadons.Find(MaHD);
                if (hd.status == 1)
                {
                    hd.status = 0;
                }
                else
                {
                    hd.status = 1;
                }
                conn.SaveChanges();
                return Json(new
                {
                    status = true
                });

            }
            catch
            {
                return Json(new
                {
                    status = false
                }) ;
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopthucung.Areas.admin.code;
using Shopthucung.Models;

namespace Shopthucung.Areas.admin.Controllers
{
    public class danhmucController : Controller
    {
        // GET: admin/danhmuc
 
        
    
        public ActionResult Index()
        {
            if (SessionHelper.GetSession() != null)
            {
                sqlDB spModel = new sqlDB();

                if (HttpContext.Request.Params.Get("loai") == null)
                {
                    ViewBag.loai = 1;
                    return View(spModel.getPhanLoai(1));
                }
                else
                {
                    ViewBag.loai = HttpContext.Request.Params.Get("loai");
                    return View(spModel.getPhanLoai(int.Parse(HttpContext.Request.Params.Get("loai"))));
                }
            }
            else
            {
                return RedirectToAction("index", "login");
            }
            
            
        }
        public ActionResult insertDM(int Loai,string insertNPL)
        {
            try
            {
                shopDBmodel conn = new shopDBmodel();
                PhanLoaiSP pl = new PhanLoaiSP();
                pl.MaLoaiSP = Loai;
                pl.TenPhanLoai = insertNPL;
                conn.PhanLoaiSPs.Add(pl);
                conn.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index",new {error =1 });
            }
        }
        public ActionResult updateDM(int editMaPL, int Loai, string ten)
        {
            try
            {
                shopDBmodel conn = new shopDBmodel();
                var pl = conn.PhanLoaiSPs.Find(editMaPL);
                pl.MaLoaiSP = Loai;
                pl.TenPhanLoai = ten;
                conn.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index", new { error = 1 });
            }
        }
        public ActionResult deleteDM(int MaPL)
        {
            try
            {
                shopDBmodel conn = new shopDBmodel();
                PhanLoaiSP pl = new PhanLoaiSP();
                pl = conn.PhanLoaiSPs.Find(MaPL);
                conn.PhanLoaiSPs.Remove(pl);
                conn.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index", new { error = 1 });
            }
        }
    }
}
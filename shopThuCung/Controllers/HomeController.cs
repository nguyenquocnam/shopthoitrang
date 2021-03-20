using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopthucung.Models;
using Shopthucung.Models.code;

namespace Shopthucung.Controllers
{
   
    public class HomeController : Controller
    {
        public menuDF listMenu = null;
        public sqlDB spModel =null;
        
        public HomeController()
        {
            spModel = new sqlDB();
            listMenu = new menuDF();
            listMenu.list.Add(spModel.getPhanLoai(1));
            listMenu.list.Add(spModel.getPhanLoai(2));
            listMenu.list.Add(spModel.getPhanLoai(3));
            
        }

        public PartialViewResult headerCartView()
        {
            var ss = Session["CartSession"];
            int dem = 0;
            if (ss != null)
            {
                foreach (var item in ((List<cartItem>)ss))
                {
                    dem += item.Quantity;
                }
            }
            
            return PartialView(dem);
        }
        public PartialViewResult MenuMBPartialView()
        {
            return PartialView();
        }
        public PartialViewResult MenuPartialView()
        {
            return PartialView();
        }
        public ActionResult Index()
        {
            ViewBag.listMenu = listMenu;
            ViewBag.spHot = spModel.getSP1(1);
            ViewBag.menuDog = spModel.getPhanLoai(1);
            ViewBag.menuCat= spModel.getPhanLoai(2);
            ViewBag.menuPK= spModel.getPhanLoai(3);
            ViewBag.spDFDog = spModel.getSP(ViewBag.menuDog[0].MaPL);
            ViewBag.spDFCat = spModel.getSP(ViewBag.menuCat[0].MaPL);
            ViewBag.spDFPk = spModel.getSP(ViewBag.menuPK[0].MaPL);
            
            return View();
        }
        public ActionResult search(string tenSP)
        {
            ViewBag.keyword = tenSP;
            ViewBag.listMenu = listMenu;
            int page = 1;
            if (HttpContext.Request.Params.Get("page") != null)
                page = int.Parse(HttpContext.Request.Params.Get("page"));
            int pageSize = 12;
         
            ViewBag.sp = spModel.searchSP(tenSP, page, pageSize);
            return View(spModel.countS(tenSP, page, pageSize));
        }
        public ActionResult chitiet(int MaPL, string MaSp)
        {
            ViewBag.listMenu = listMenu;
            ViewBag.menuDog = spModel.getPhanLoai(1);
            ViewBag.menuCat = spModel.getPhanLoai(2);
            ViewBag.menuPK = spModel.getPhanLoai(3);
            ViewBag.detailSP = spModel.getSPChiTiet(MaSp);
            ViewBag.likeSP = spModel.getSPLike(MaPL, MaSp);
            ViewBag.loaiSP = spModel.getLoaiSP();
            ViewBag.fullLoai = spModel.getPhanLoai();
            return View();
        }
        
        public ActionResult listsp(int MaLoaiSP, int? MaPL)
        {
            
            ViewBag.loaiSP = spModel.getLoaiSP();
            ViewBag.listMenu = listMenu;
            int page = 1;
            if (HttpContext.Request.Params.Get("page") != null)
                page = int.Parse(HttpContext.Request.Params.Get("page"));
            int pageSize = 12;
            if (MaPL == null)
            {
                ViewBag.kiemTra = 1;
                ViewBag.sp = spModel.getListSP(MaLoaiSP,page,pageSize);
                return View(spModel.countSPForMaLoai(MaLoaiSP,page,pageSize));
            }
            else
            {
                ViewBag.kiemTra = 2;

                ViewBag.sp = spModel.getListSP(MaLoaiSP,(int)MaPL,page,pageSize);
                return View(spModel.countSPForMaPL((int)MaPL, page, pageSize));
            }
        }

        public ActionResult listTinTuc()
        {
            ViewBag.listMenu = listMenu;
            int page = 1;
            if (HttpContext.Request.Params.Get("page") != null)
                page = int.Parse(HttpContext.Request.Params.Get("page"));
            int pageSize = 7;
            ViewBag.listTinTuc = spModel.getTinTuc(page, pageSize);
            return View(spModel.countPageTinTuc(page,pageSize));
        }
        public ActionResult chiTietTinTuc(string MaBaiViet)
        {
            ViewBag.listMenu = listMenu;
            ViewBag.tinTuc = spModel.getTinTuc(MaBaiViet);
            return View();
        }
        [HttpPost]
        public JsonResult productIndexChange(int MaPL)
        {
            var getSP = spModel.getSP(MaPL);
            if (getSP.Count > 0)
            {
                return Json(new
                {
                    count =getSP.Count,
                    listSP = getSP
                });
            }
            return Json(new
            {
                count = 0
            }) ;
        }
    }
}
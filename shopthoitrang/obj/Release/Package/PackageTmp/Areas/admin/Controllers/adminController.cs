using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Shopthucung.Areas.admin.code;
using Shopthucung.Areas.admin.Models;
using Shopthucung.Models;

namespace Shopthucung.Areas.admin.Controllers
{

    public class adminController : Controller
    {
        // GET: admin/admin
        [HttpGet]
        public ActionResult Index()
        {
            if (SessionHelper.GetSession() != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("index", "login");
            }


        }
        public ActionResult SanPham(int? Page)
        {

            if (SessionHelper.GetSession() != null)
            {
                int pageSize = 6;
                int? page = 1;
                if (Page != null)
                    page = Page;
                sqlAdmin conn = new sqlAdmin();
                ViewBag.sp = conn.getSp((int)page, pageSize);
                ViewBag.pl = conn.getPhanLoai("3");
                return View(conn.countPageSP((int)page, pageSize));
            }
            else
            {
                return RedirectToAction("index", "login");
            }
        }
        public ActionResult MenuSanPham()
        {
            if (SessionHelper.GetSession() != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("index", "login");
            }
        }
        public ActionResult TinTuc(int? Page)
        {
            if (SessionHelper.GetSession() != null)
            {
                int pageSize = 6;
                int? page = 1;
                if (Page != null)
                    page = Page;
                sqlAdmin conn = new sqlAdmin();
                ViewBag.tintuc = conn.getTinTuc((int)page, pageSize);
                return View(conn.countPageTT((int)page, pageSize));
            }
            else
            {
                return RedirectToAction("index", "login");
            }
        }
        public ActionResult deleteTT(String MaTinTuc)
        {
            new sqlAdmin().deleteTinTuc(MaTinTuc);
            return RedirectToAction("TinTuc");
        }
        public ActionResult editTT(string MaTinTuc)
        {

            if (SessionHelper.GetSession() != null)
            {
                ViewBag.tt = new sqlAdmin().findTT(MaTinTuc);
                return View();
            }
            else
            {
                return RedirectToAction("index", "login");
            }
        }
        public ActionResult insertTT()
        {

            if (SessionHelper.GetSession() != null)
            {
                
                return View();
            }
            else
            {
                return RedirectToAction("index", "login");
            }
        }
        public JsonResult saveInfoTT(string sp)
        {
            try
            {
                sqlAdmin conn = new sqlAdmin();
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                var info = serializer.Deserialize<List<string>>(sp);
                TinTuc tt = new TinTuc();
                tt.MaBaiViet = info[0];
                tt.TieuDe = info[1];
                tt.motangan = info[2];
                tt.anhmota = info[3];
                tt.mota = replaceC(info[4]);
                DateTime i = DateTime.Now;
                tt.ngaydang = DateTime.Now;

                bool kt = conn.insertTT(tt);
                if (kt == false)
                {
                    return Json(new
                    {
                        status = false
                    });
                }
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
                });
            }
        }
        public JsonResult editInfoTT(string sp)
        {
            try
            {
                sqlAdmin conn = new sqlAdmin();
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                var info = serializer.Deserialize<List<string>>(sp);
                TinTuc tt = new TinTuc();
                tt.MaBaiViet = info[0];
                tt.TieuDe = info[1];
                tt.motangan = info[2];
                tt.anhmota = info[3];
                tt.mota = replaceC(info[4]);
                tt.ngaydang = conn.findTT(info[0]).ngaydang;
                bool kt = conn.updateTT(tt);
                if (kt == false)
                {
                    return Json(new
                    {
                        status = false
                    });
                }
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
                });
            }
        }
        public ActionResult editSP(string MaSp) {
            
            if (SessionHelper.GetSession() != null)
            {
                ViewBag.sp = new sqlAdmin().getSPChiTiet(MaSp);
                return View(new sqlAdmin().getPhanLoai());
            }
            else
            {
                return RedirectToAction("index", "login");
            }
        }
        public ActionResult deleteSP(String MaSp)
        {
            new sqlAdmin().deleteSp(MaSp);

            return RedirectToAction("SanPham");
        }
        [HttpGet]
        public ActionResult insertSP()
        {
            if (SessionHelper.GetSession() != null)
            {
                ViewBag.a = HttpContext.Request.Params.Get("vacxin");
                return View(new sqlAdmin().getPhanLoai());
            }
            else
            {
                return RedirectToAction("index", "login");
            }
        }
        [HttpPost]
        public ActionResult insertSP(SanPham sp)
        {
            //new sqlAdmin().insertSP(sp);
            
            

            if (SessionHelper.GetSession() != null)
            {
                if (getHttpSP() != null)
                {
                    ViewBag.a = HttpContext.Request.Params.Get("vacxin");
                    new sqlAdmin().insertSP(getHttpSP());
                    return RedirectToAction("SanPham", "admin");
                }
                else
                {
                    return RedirectToAction("SanPham", "admin");
                }
            }
            else
            {
                return RedirectToAction("index", "login");
            }
        }
        public JsonResult changeHot(string MaSp) {
            try
            {
                sqlAdmin conn = new sqlAdmin();
                SanPham sp = conn.findSP(MaSp);
                if (sp.hot == 1)
                    sp.hot = 0;
                else
                {
                    sp.hot = 1;
                }
                bool kt = conn.updateSP(sp);
                if(kt==false)
                    return Json(new { status = false });
                return Json(new { status = true });
            }
            catch
            {
                return Json(new { status = false });
            }
            
        }
        public JsonResult editInfoDP(string sp)
        {
            try
            {
                sqlAdmin conn = new sqlAdmin();
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                var info = serializer.Deserialize<List<string>>(sp);
                SanPham sp1 = new SanPham();
                sp1.MaSp = info[0];
                sp1.tenSP = info[1];
                sp1.MaPL = info[2];
                sp1.mausac = info[3];
                sp1.gioitinh = info[4];
                sp1.tuoi = info[5];
                sp1.tinhtrang = info[6];
                sp1.timvacxin = int.Parse(info[7]);
                sp1.taygiun = int.Parse(info[8]);
                sp1.xuatxu = info[9];
                sp1.mota = replaceC(info[10]);
                sp1.ngaythem = DateTime.Parse(info[11]);
                sp1.hot = conn.findSP(info[0]).hot;
                bool kt = conn.updateSP(sp1);
                if (kt == false)
                {
                    return Json(new
                    {
                        status = false
                    });
                }
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
                });
            }
        }
        public JsonResult editImageSP(string MaSp, string image, string imageDetail)
        {
            try
            {
                sqlAdmin conn = new sqlAdmin();
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                var listImages = serializer.Deserialize<List<string>>(image);
                var listImgDt = serializer.Deserialize<List<string>>(imageDetail);
                conn.deleteImgSp(MaSp);
                foreach (var item in listImages)
                {
                    var kt = conn.insertImg(MaSp, item, 0);
                    if (kt == false)
                    {
                        return Json(new
                        {
                            id = 0,
                            status = false
                        });
                    }

                }
                foreach (var item in listImgDt)
                {
                    var kt = conn.insertImg(MaSp, item, 1);
                    if (kt == false)
                    {
                        return Json(new
                        {
                            id = 1,
                            status = false
                        });
                    }
                }

                return Json(new
                {

                    status = true
                });
            }
            catch
            {
                return Json(new
                {
                    id = 2,
                    status = false
                });
            }

        }
        public JsonResult saveInfoSP(string sp) {
            try
            {
                sqlAdmin conn = new sqlAdmin();
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                var info = serializer.Deserialize<List<string>>(sp);
                SanPham sp1 = new SanPham();
                sp1.MaSp = info[0];
                sp1.tenSP = info[1];
                sp1.MaPL = info[2];
                sp1.mausac = info[3];
                sp1.gioitinh = info[4];
                sp1.tuoi = info[5];
                sp1.tinhtrang = info[6];
                sp1.timvacxin = int.Parse(info[7]);
                sp1.taygiun = int.Parse(info[8]);
                sp1.xuatxu = info[9];
                sp1.mota = replaceC(info[10]);
                DateTime i = DateTime.Now;
                sp1.ngaythem = DateTime.Now;
                sp1.hot = 0;
                bool kt = conn.insertSP(sp1);
                if (kt == false) {
                    return Json(new
                    {
                        status = false
                    });
                }
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
                });
            }
        }
        public JsonResult saveImageSP(string MaSp ,string image,string imageDetail) 
        {
            try
            {
                sqlAdmin conn = new sqlAdmin();
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                var listImages = serializer.Deserialize<List<string>>(image);
                var listImgDt = serializer.Deserialize<List<string>>(imageDetail);
                
                foreach(var item in listImages)
                {
                    var kt = conn.insertImg(MaSp,item,0);
                    if (kt == false)
                    {
                        return Json(new
                        {
                            id = 0,
                            status = false
                        }) ;
                    }

                }
                foreach (var item in listImgDt)
                {
                    var kt = conn.insertImg(MaSp, item, 1);
                    if (kt == false)
                    {
                        return Json(new
                        {
                            id = 1,
                            status = false
                        });
                    }
                }

                return Json(new
                {
                    
                    status = true
                });
            }
            catch
            {
                return Json(new
                {
                    id = 2,
                    status = false
                }) ;
            }
            
        }
        public SanPham getHttpSP()
        {
            
            if (HttpContext.Request.Form.Get("MaSp") != null) {
                SanPham sp = new SanPham();
                sp.MaSp = HttpContext.Request.Form.Get("MaSp");
                sp.tenSP = HttpContext.Request.Form.Get("tenSP");
                sp.MaPL = HttpContext.Request.Form.Get("loai");
                sp.mausac = HttpContext.Request.Form.Get("mausac");
                if(Request.Form.Get("gioitinh")!=null)
                    sp.gioitinh = (int.Parse(HttpContext.Request.Form.Get("gioitinh")) == 1) ? "Đực" : "Cái";
                sp.tuoi = HttpContext.Request.Form.Get("tuoi");
                if (HttpContext.Request.Form.Get("tinhtrang") == "false")
                {
                    sp.tinhtrang = "Không có sẵn";
                }
                else
                {
                    sp.tinhtrang = "Có hàng";
                }
                if (HttpContext.Request.Form.Get("vacxin") == "false" && HttpContext.Request.Form.Get("vacxin")!=null)
                {
                    sp.timvacxin =0;
                }
                else
                {
                    sp.timvacxin=1;
                }
                if (HttpContext.Request.Form.Get("taygiun") == "false" && HttpContext.Request.Form.Get("taygiun") != null)
                {
                    sp.taygiun = 0;
                }
                else
                {
                    sp.taygiun = 1;
                }
                sp.xuatxu = HttpContext.Request.Form.Get("xuatxu");
                sp.mota = HttpContext.Request.Form.Get("mota");
                sp.hot = 0;
                return sp;
            }

            return null;
        }
        public string replaceC(string text)
        {
            var s = text.Replace("&amp;", "&");
            s = s.Replace("&lt;", "<");
            s = s.Replace("&gt;", ">");
            s = s.Replace("&quot;", "\"");
            s = s.Replace("&#039;", "\'");
            return s;
        }
        public static string decodeC(string text)
        {
            var s = text.Replace( "&", "&amp;");
            s = s.Replace( "<", "&lt;");
            s = s.Replace( ">", "&gt;");
            s = s.Replace( "\"", "&quot;");
            s = s.Replace( "\'", "&#039;");
            return s;
        }

    }
    
}
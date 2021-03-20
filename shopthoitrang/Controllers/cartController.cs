using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Shopthucung.Areas.admin.Models;
using Shopthucung.Models;
using Shopthucung.Models.code;

namespace Shopthucung.Controllers
{
    public class cartController : Controller
    {
        private string CartSs = "CartSession";
        public menuDF listMenu = null;
        public sqlDB spModel = null;

        public cartController()
        {
            spModel = new sqlDB();
            listMenu = new menuDF();
            listMenu.list.Add(spModel.getPhanLoai(1));
            listMenu.list.Add(spModel.getPhanLoai(2));
            listMenu.list.Add(spModel.getPhanLoai(3));

        }
        public PartialViewResult MenuMBPartialView()
        {
            return PartialView();
        }
        public PartialViewResult MenuPartialView()
        {
            return PartialView();
        }
        // GET: cart
        public ActionResult Index()
        {
            ViewBag.listMenu = listMenu;
            var cart = Session[CartSs];
            var list = new List<cartItem>();
            if (cart != null)
            {
                list = (List<cartItem>)cart;
                 
            }
            ViewBag.cart = list;
            return View();
        }

        public JsonResult cartUpdate(string cartModel)
        {
            var cart = new JavaScriptSerializer().Deserialize<List<cartItem>>(cartModel);
            var ssCart = (List<cartItem>)Session[CartSs];
            foreach(var item in ssCart)
            {
                var jsonItem = cart.SingleOrDefault(x => x.product.MaSp == item.product.MaSp);
                if(cart != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            return Json(new
            {
                status = true
            }) ;
        }
        public JsonResult deleteAll()
        {
            Session[CartSs] = null;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult delete(string MaSp)
        {
            var cart = (List<cartItem>)Session[CartSs];
            cart.RemoveAll(c => c.product.MaSp == MaSp);
            if (cart.Count > 0)
            {
                Session[CartSs] = cart;
            }
            else
            {
                Session[CartSs] = null;
            }
            

            return Json(new
            {
                status = true
            });
        }
        public ActionResult AddCart(string productID,int quantity)
        {
            var cart = Session[CartSs];
            if(cart != null)
            {
                var list = (List<cartItem>)cart;
                if(list.Exists(x=>x.product.MaSp== productID))
                foreach(var item in list)
                {
                    if(item.product.MaSp.Equals(productID))
                    {
                        item.Quantity += quantity;
                    }
                    }
                else
                {
                    var item = new cartItem();
                    item.product = new sqlDB().getSPCart(productID) ;
                    item.Quantity = quantity;
                    
                    list.Add(item);
                   
                }
            }
            else
            {
                var item = new cartItem();
                item.product = new sqlDB().getSPCart(productID);
                item.Quantity = quantity;
                var list = new List<cartItem>();
                list.Add(item);
                Session[CartSs] = list;
            }
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult payment()
        {
            ViewBag.listMenu = listMenu;
            var cart = Session[CartSs];
            var list = new List<cartItem>();
            if (cart != null)
            {
                list = (List<cartItem>)cart;

            }
            ViewBag.cart = list;
            return View();
        }
        [HttpPost]
        public ActionResult payment(String shipName,String phone,String address,String email)
        {
            try
            {
                var cart = Session[CartSs];
                var list = new List<cartItem>();
                if (cart != null)
                {
                    list = (List<cartItem>)cart;
                    var conn = new sqlDB();
                    var hoadon = new hoadon();
                    hoadon.createDate = DateTime.Now;
                    hoadon.shipName = shipName;
                    hoadon.shipAddress = address;
                    hoadon.shipMobie = phone;
                    hoadon.shipEmail = email;
                    hoadon.status = 0;
                    var id = conn.insertHoaDon(hoadon);

                    foreach (var item in list)
                    {
                        chitiethoadon ctHoaDon = new chitiethoadon();
                        ctHoaDon.OrderID = id;
                        ctHoaDon.ProductID = item.product.MaSp;
                        ctHoaDon.Quantity = item.Quantity;
                        ctHoaDon.Price = item.product.price;
                        conn.insertChiTiet(ctHoaDon);
                    }
                    Session[CartSs] = null;
                    return RedirectToAction("HoanThanh");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Error");
            }

        }
        public ActionResult HoanThanh()
        {
            ViewBag.listMenu = listMenu;
            return View();
        }
        public ActionResult Error()
        {
            ViewBag.listMenu = listMenu;
            return View();
        }
    }
    
}
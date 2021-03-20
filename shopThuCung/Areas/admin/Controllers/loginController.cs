using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopthucung.Areas.admin.code;
using Shopthucung.Areas.admin.Models;

namespace Shopthucung.Areas.admin.Controllers
{
    public class loginController : Controller
    {
        // GET: admin/login
        [HttpGet]
        public ActionResult Index()
        {
            if (SessionHelper.GetSession() != null)
            {
                return RedirectToAction("Index", "admin");

            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            var result = new AccountModel().Login(model.UserName, model.Password);
            
            if(result && ModelState.IsValid)
            {
                SessionHelper.SetSession(new UserSession() { UserName = model.UserName});

                return RedirectToAction("Index", "admin");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập không đúng");
            }
            return View(model);
        }
        public ActionResult logout()
        {
            SessionHelper.RemoveSession();
            return RedirectToAction("Index", "login");
        }
    }
}
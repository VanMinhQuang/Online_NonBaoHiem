using Model;
using Online_NonBaoHiem.Areas.Admin.Code;
using Online_NonBaoHiem.Areas.Admin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_NonBaoHiem.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            var result = new AccountModel().Login(model.UserName, model.PassWord);
            if(result && ModelState.IsValid)
            {
                SessionHelper.SetSession(new UserSession() { UserName = model.UserName });
                Session["DisplayName"] = model.UserName;
                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng!");
            }
            return View(model);
        }

        public RedirectToRouteResult Logout()
        {
            Session["loginSession"] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}
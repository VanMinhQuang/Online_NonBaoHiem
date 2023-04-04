using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_NonBaoHiem.Models;

namespace Online_NonBaoHiem.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        NonData myData = new NonData();
        // GET: Admin/Account
        public ActionResult Index()
        {
            string s = (string)Session["DisplayName"];
            if (Session["loginSession"] != null)
            {
                if(s == "vanminhquang")
                {
                    var all_account = from ss in myData.AdminAccounts select ss;
                    return View(all_account);
                }
                else
                {
                    return RedirectToAction("Index","Home");
                }

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }

        public ActionResult Detail(int id)
        {
            var d_account = myData.AdminAccounts.Where(s => s.IdAdmin == id).First();
            return View(d_account);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create (AdminAccount ac,FormCollection collection)
        {
            var c_ten = collection["AccountName"];
            var c_displayten = collection["DisplayName"];
            var c_pass = collection["Password"];
            var c_diachi = collection["Address"];
            var c_sdt = collection["PhoneNumber"];
            if (string.IsNullOrEmpty(c_ten))
            {
                ViewBag["Error"] = "Don't Empty";
            }
            else
            {
                ac.UserName = c_ten.ToString();
                ac.DISPLAYNAME = c_displayten.ToString();
                ac.Pass = c_pass.ToString();
                ac.DIACHI = c_diachi.ToString();
                ac.SDT = c_sdt.ToString();
                myData.AdminAccounts.Add(ac);
                myData.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }
        public ActionResult Edit(int id)
        {
            var e_admin = myData.AdminAccounts.First(m => m.IdAdmin == id);
            return View(e_admin);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var e_admin = myData.AdminAccounts.First(m => m.IdAdmin == id);
            var e_ten = collection["UserName"];
            var e_tenHienThi =collection["DISPLAYNAME"];
            var e_Pass = collection["Pass"];
            var e_Sdt = collection["SDT"];
            var e_DiaChi = collection["DIACHI"];
            e_admin.IdAdmin = id;
            if (string.IsNullOrEmpty(e_ten))
            {
                ViewData["Error"] = "Don't Empty";
            }
            else
            {
                e_admin.UserName = e_ten;
                e_admin.DISPLAYNAME = e_tenHienThi;
                e_admin.Pass = e_Pass;
                e_admin.SDT = e_Sdt;
                e_admin.DIACHI = e_DiaChi;
                UpdateModel(e_admin);
                myData.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }
        public ActionResult Delete(int id)
        {
            var de_admin = myData.AdminAccounts.First(m => m.IdAdmin == id);
            return View(de_admin);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var de_admin = myData.AdminAccounts.Where(m => m.IdAdmin == id).First();
            myData.AdminAccounts.Remove(de_admin);
            myData.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
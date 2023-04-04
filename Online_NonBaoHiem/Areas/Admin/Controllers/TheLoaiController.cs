using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_NonBaoHiem.Models;

namespace Online_NonBaoHiem.Areas.Admin.Controllers
{
    public class TheLoaiController : Controller
    {
        NonData myData = new NonData();
        // GET: Admin/TheLoai
        public ActionResult Index()
        {
            if (Session["loginSession"] != null)
            {
                var all_theloai = from ss in myData.Categories select ss;
                return View(all_theloai);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, Category s)
        {
            var c_tentheloai = collection["CategoryName"];
            if (string.IsNullOrEmpty(c_tentheloai))
            {
                ViewBag["Error"] = "Do not Empty";
            }
            else
            {
                s.CategoryName = c_tentheloai;
                myData.Categories.Add(s);
                myData.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.View();
        }
        public ActionResult Edit(int id)
        {
            var e_theloai = myData.Categories.Where(t => t.IdCategory == id);
            return View(e_theloai);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection collection, int id)
        {
            var theloai = myData.Categories.First(m => m.IdCategory == id);
            var ten = collection["CategoryName"];
            if (string.IsNullOrEmpty(ten))
            {
                ViewData["Error"] = "Don't empty";
            }
            else
            {
                theloai.CategoryName = ten;
                UpdateModel(theloai);
                myData.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }
        public ActionResult Delete(int id)
        {
            var de_theloai = myData.Categories.First(m => m.IdCategory == id);
            return View(de_theloai);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var de_theloai = myData.Categories.Where(m => m.IdCategory == id).First();
            myData.Categories.Remove(de_theloai);
            myData.SaveChanges();
            return RedirectToAction("Index");
        }
    }
        
}
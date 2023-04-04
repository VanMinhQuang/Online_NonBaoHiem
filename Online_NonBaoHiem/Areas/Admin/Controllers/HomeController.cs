using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_NonBaoHiem.Models;

namespace Online_NonBaoHiem.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        NonData myData = new NonData();
        // GET: Sach
        public ActionResult Index()
        {
            if (Session["loginSession"] != null)
            {
                var all_non = from ss in myData.Helmets select ss;
                return View(all_non);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }

        public ActionResult Detail(int id)
        {
            var d_non = myData.Helmets.Where(m => m.IdHelmet == id).First();
            return View(d_non);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, Helmet s)
        {
            var c_tennon = collection["HelmetName"];
            var c_gia = Convert.ToDouble(collection["Price"]);
            var c_soluongton = Convert.ToInt32(collection["Quanity"]);
            var c_thumbnail = collection["Thumbnail"];
            var c_updatetime = Convert.ToDateTime(collection["UpdateTime"]);
            var c_description = collection["Description"] ;
            if (string.IsNullOrEmpty(c_tennon))
            {
                ViewData["Error"] = "Don't Empty";
            }
            else
            {
                s.HelmetName = c_tennon.ToString();
                s.Quanity = c_soluongton;
                s.Price = c_gia;
                s.Thumbnail = c_thumbnail.ToString();
                s.UpdateTime = c_updatetime;
                s.Description = c_description.ToString();
                myData.Helmets.Add(s);
                myData.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }

        public ActionResult Edit(int id)
        {
            var e_sach = myData.Helmets.First(m => m.IdHelmet == id);
            return View(e_sach);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var e_non = myData.Helmets.First(m => m.IdHelmet == id);
            var e_tennon = collection["HelmetName"];
            var e_gia = Convert.ToDouble(collection["Price"]);
            var e_soluongton = Convert.ToInt32(collection["Quanity"]);
            var e_thumbnail = collection["Thumbnail"];
            var e_updatetime = Convert.ToDateTime(collection["UpdateTime"]);
            var e_description = collection["Description"];
            e_non.IdHelmet = id;
            if (string.IsNullOrEmpty(e_tennon))
            {
                ViewData["Error"] = "Don't Empty";
            }
            else
            {
                e_non.HelmetName = e_tennon;
                e_non.Price = e_gia;
                e_non.Quanity = e_soluongton;
                e_non.Thumbnail = e_thumbnail;
                e_non.UpdateTime = e_updatetime;
                e_non.Description = e_description;
                UpdateModel(e_non);
                myData.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }

        public ActionResult Delete(int id)
        {
            var de_non = myData.Helmets.First(m => m.IdHelmet == id);
            return View(de_non);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
                var de_non = myData.Helmets.Where(m => m.IdHelmet == id).First();
                myData.Helmets.Remove(de_non);
                myData.SaveChanges();
                return RedirectToAction("Index");
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
            return "/Content/images/" + file.FileName;
        }
    }
}
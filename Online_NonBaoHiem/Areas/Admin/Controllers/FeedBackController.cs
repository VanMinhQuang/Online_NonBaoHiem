using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_NonBaoHiem.Models;

namespace Online_NonBaoHiem.Areas.Admin.Controllers
{
    public class FeedBackController : Controller
    {
        // GET: Admin/FeedBack
        NonData myData = new NonData();
        // GET: Admin/Bill
        public ActionResult Index()
        {
            if (Session["loginSession"] != null)
            {
                var all_feedback = from ss in myData.Feedbacks select ss;
                return View(all_feedback);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Detail(int id)
        {
            var d_feedback = myData.Feedbacks.Where(m => m.IdFeedback == id).First();
            return View(d_feedback);
        }

        public ActionResult Delete(int id)
        {
            var de_feedback = myData.Feedbacks.First(m => m.IdFeedback == id);
            return View(de_feedback);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var de_feedback = myData.Feedbacks.Where(m => m.IdFeedback == id).First();
            myData.Feedbacks.Remove(de_feedback);
            myData.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
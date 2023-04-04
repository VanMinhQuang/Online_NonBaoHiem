using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_NonBaoHiem.Models;

namespace Online_NonBaoHiem.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Admin/Customer
        NonData myData = new NonData();
        public ActionResult Index()
        {
            if (Session["loginSession"] != null)
            {
                if((string)Session["DisplayName"] == "vanminhquang")
                {
                    var all_cus = from ss in myData.CustomerAccounts select ss;
                    return View(all_cus);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Detail(int id)
        {
            var d_cus = myData.CustomerAccounts.Where(m => m.IdCustomer == id).First();
            return View(d_cus);
        }

        public ActionResult Delete(int id)
        {
            var de_cus = myData.CustomerAccounts.First(m => m.IdCustomer == id);
            return View(de_cus);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var de_feedback = myData.CustomerAccounts.Where(m => m.IdCustomer == id).First();
            myData.CustomerAccounts.Remove(de_feedback);
            myData.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_NonBaoHiem.Models;

namespace Online_NonBaoHiem.Controllers
{
    public class TrangChuController : Controller
    {
        NonData non = new NonData();
        // GET: TrangChu
        public ActionResult Index()
        {
            var all_non = from s in non.Helmets select s;
            return View(all_non);
        }

        public ActionResult Non34()
        {
            var all_nondep = from s in non.Helmets.Where(m => m.IdCategory == 1) select s;
            return View(all_nondep);
        }
        public ActionResult NonPhuot()
        {
            var all_nonphuot = from s in non.Helmets.Where(m => m.IdCategory == 2) select s;
            return View(all_nonphuot);
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_NonBaoHiem.Models;

namespace Online_NonBaoHiem.Areas.Admin.Controllers
{
    public class BillController : Controller
    {
        NonData myData = new NonData();
        // GET: Admin/Bill
        public ActionResult Index()
        {
            if (Session["loginSession"] != null)
            {
                var all_bill = from ss in myData.Bills select ss;
                return View(all_bill);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Detail(int id)
        {
            var d_bill = myData.Bills.Where(m => m.IdBill == id).First();
            return View(d_bill);
        }

        public ActionResult Edit(int id)
        {
            var e_sach = myData.Bills.First(m => m.IdBill == id);
            return View(e_sach);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var e_bill = myData.Bills.First(m => m.IdBill == id);
            var e_thanhtoan = Convert.ToBoolean(collection["ThanhToan"]);
            var e_giaohang = Convert.ToBoolean(collection["GiaoHang"]);
            var e_ngaydat = Convert.ToDateTime(collection["NgayDat"]);
            var e_ngaygiao = Convert.ToDateTime(collection["NgayGiao"]);
            e_bill.IdBill = id;
            if(string.IsNullOrEmpty(Convert.ToString(e_ngaydat)))
                {
                ViewBag["Error"] = "Empty";
                }
            else
            {
                e_bill.ThanhToan = e_thanhtoan;
                e_bill.GiaoHang = e_giaohang;
                e_bill.NgayDat = e_ngaydat;
                e_bill.NgayGiao = e_ngaygiao;
                UpdateModel(e_bill);
                myData.SaveChanges();
                return RedirectToAction("Index");
            }

            
            return this.Edit(id);
        }

        public ActionResult Delete(int id)
        {
            var de_non = myData.Bills.First(m => m.IdBill == id);
            return View(de_non);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var de_non = myData.Bills.Where(m => m.IdBill == id).First();
            myData.Bills.Remove(de_non);
            myData.SaveChanges();
            return RedirectToAction("Index");
        }
    }
} 
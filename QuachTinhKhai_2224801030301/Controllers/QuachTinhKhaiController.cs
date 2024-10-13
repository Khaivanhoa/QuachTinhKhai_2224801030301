using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuachTinhKhai_2224801030301.Models;

namespace QuachTinhKhai_2224801030301.Controllers
{
    public class QuachTinhKhaiController : Controller
    {
           SachOnlineEntities db = new SachOnlineEntities();
        // GET: QuachTinhKhai
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PartialNav()
        {
            return PartialView("_PartialNav");
        }
        public ActionResult PartialSlider()
        {
            return PartialView("_PartialSlider");
        }
        public ActionResult PartialChuDe()
        {
            return PartialView("_PartialChuDe");
        }
        public ActionResult PartialNhaXuatBan()
        {
            return PartialView("_PartialNhaXuatBan");
        }
        public ActionResult PartialSachBanNhieu()
        {
            return PartialView("_PartialSachBanNhieu");
        }
        public ActionResult PartialFooter()
        {
            return PartialView("_PartialFooter");
        }
        public ActionResult ChuDe()
        {
            var cd = from c in db.CHUDEs select c;
            return PartialView(cd);
        }

        public ActionResult ChiTietSach(int id)
        {
            //var book = (from s int data.SACHes where 
            //    s.MaSach == id select s).Single();
            var s = db.SACHes.Where(n => n.MaSach == id).SingleOrDefault();
            return View("ChiTietSach", s);
        }
    }
}
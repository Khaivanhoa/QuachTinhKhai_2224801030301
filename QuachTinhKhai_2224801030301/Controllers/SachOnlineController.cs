using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuachTinhKhai_2224801030301.Controllers
{
    public class SachOnlineController : Controller
    {
        // GET: SachOnline
        public ActionResult Index()
        {
            return View();
        }

        public ActiontResult BoolDetail(int id)
        {
            var book = (from s in Data.SACHes where
                s.MaSach == id select s).Single();
            var s = Data.SACHes.Where(nameof <= nameof.Ma)
                  
        }
    }
}
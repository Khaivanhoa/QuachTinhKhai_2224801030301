using QuachTinhKhai_2224801030301.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuachTinhKhai_2224801030301.Areas.Admin.Controllers
{
    public class NhaXuatBanController : Controller
    {
        SachOnlineEntities db = new SachOnlineEntities();
        // GET: Admin/NhaXuatBan
        public ActionResult IndexNXB()
        {
            return View(db.NHAXUATBANs.ToList());
        }
        public ActionResult ChiTietNXB()
        {
            int maNXB = int.Parse(Request["id"]);
            var kq = db.NHAXUATBANs.Where(n => n.MaNXB == maNXB).SingleOrDefault();//trả về 1 hoặc không gì cả
            return View(kq);
        }
        [HttpGet]
        public ActionResult SuaNhaXuatBan(int id)
        {
            /* int maNXB = int.Parse(Request["id"]);*/
            var kq = db.NHAXUATBANs.Where(n => n.MaNXB == id).SingleOrDefault();//do truyền id để lấy ra
            return View(kq);
        }
        [HttpPost]
        //kết quả nhận về sao khi nhấn nút
        public ActionResult SuaNhaXuatBan(FormCollection f)
        {
            int maNXB = int.Parse(f["MaNXB"]);

            NHAXUATBAN kq = db.NHAXUATBANs.Where(n => n.MaNXB == maNXB).SingleOrDefault();//Khai báo NHAXUATBAN để truy xuất luôn
            kq.TenNXB = f["TenNXB"];
            kq.DiaChi = f["DiaChi"];
            kq.DienThoai = f["DienThoai"];
            db.SaveChanges();
            return RedirectToAction("IndexNXB", "NhaXuatBan");

        }
        [HttpGet]
        public ActionResult ThemNhaXuatBan()
        {
            return View();
        }
        [HttpPost]
        //kết quả nhận về sao khi nhấn nút
        public ActionResult ThemNhaXuatBan(FormCollection f)
        {
            //tạo mới 1 đối tượng gán thông tin add vô và lưu
            NHAXUATBAN nxb = new NHAXUATBAN();
            //gán các thuộc tính cho nxb
            db.NHAXUATBANs.Add(nxb);
            nxb.TenNXB = f["TenNXB"];
            nxb.DiaChi = f["DiaChi"];
            nxb.DienThoai = f["DienThoai"];

            db.SaveChanges();
            return View();


        }
        /* tạo dạn model, model có gì thì nxb có đó
         public ActionResult ThemNhaXuatBan(NHAXUATBAN nxb)
        {
            //gán các thuộc tính cho nxb
            db.NHAXUATBANs.Add(nxb);
            db.SaveChanges();
            return View();

        }
         */

    }
}
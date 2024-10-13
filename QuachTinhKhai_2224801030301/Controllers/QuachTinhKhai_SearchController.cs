using QuachTinhKhai_2224801030301.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuachTinhKhai_2224801030301.Controllers
{
    public class QuachTinhKhai_SearchController : Controller
    {
        // GET: QuachTinhKhai_Search
        public class SearchController : Controller
        { 
             
            // Phương thức xử lý yêu cầu tìm kiếm
            public ActionResult Search(string strSearch)
            {
                // Lưu trữ giá trị tìm kiếm vào ViewBag để hiển thị trong view
                ViewBag.Search = strSearch;

                // Kiểm tra xem chuỗi tìm kiếm có rỗng hay không
                if (!string.IsNullOrEmpty(strSearch))
                {
                    // Thực hiện truy vấn LINQ để tìm kiếm sách trong cơ sở dữ liệu
                    var kq = from item in db.SACHes
                                 // Tìm các sách có tiêu đề hoặc tác giả chứa chuỗi tìm kiếm
                             where item.Title.Contains(strSearch) || item.Author.Contains(strSearch)
                             select item;

                    // Trả về view với kết quả tìm kiếm
                    return View(kq.ToList());
                }

                // Nếu không có kết quả, trả về view với danh sách sách rỗng
                return View(new List<SACH>());
            }
        }
    }
}
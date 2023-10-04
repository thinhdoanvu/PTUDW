using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyClass.Model;

namespace _63CNTTX.Controllers
{
    public class SiteController : Controller
    {
        // GET: Site
        public ActionResult Index()
        {
            MyDBContext db = new MyDBContext();//tạo mới mẫu tin
            int somau = db.Products.Count();//ví dụ hiển thị số mẫu tin của Products ra M.hình
            ViewBag.somau = somau;//truyền dưới dạng ViewBag

            return View();
        }
    }
}
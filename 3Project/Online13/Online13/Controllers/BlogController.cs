using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online13.DAL;
using Online13.Models;
namespace Online13.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        EduContext db = new EduContext();
        public ActionResult Index()
        {
            Blog blog = new Blog();
            ViewBag.ViewCount = blog.ViewCount;
            ViewBag.Quest = true;
            return View();
        }
        public ActionResult BlogDetails()
        {

            return View();
        }
    }
}
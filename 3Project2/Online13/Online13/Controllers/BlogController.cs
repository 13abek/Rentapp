using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online13.DAL;
using Online13.Models;
using Online13.ViewModels;


namespace Online13.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        EduContext db = new EduContext();
        public ActionResult Index()
        {
            ViewBag.Quest = true;
            VmBlogs model =new VmBlogs();
            model.Blogs = db.Blogs.Include("BlogCategory").ToList();
          
            return View(model);
        }
        public ActionResult BlogDetails(int id)
        {
            VmBlogSingle model = new VmBlogSingle();
            model.blog = db.Blogs.Include("BlogCategory").FirstOrDefault(b => b.Id == id);
            model.blogCategories= db.BlogCategories.ToList();
            return View(model);
        }
    }
}
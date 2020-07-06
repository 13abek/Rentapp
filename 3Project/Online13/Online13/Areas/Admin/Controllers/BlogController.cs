using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Online13.DAL;
using Online13.Models;
using System.Data.Entity;
using Online13.ViewModels;

namespace Online13.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        // GET: Admin/Blog
        EduContext db = new EduContext();
        /* Blog CRUD */
        public ActionResult Index()
        {
            List<Blog> blogs = db.Blogs.Include("BlogCategory").ToList();
            return View(blogs);
        }
        public ActionResult Create()
        {
            ViewBag.Categories = db.BlogCategories.ToList();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                Blog Blog = new Blog();
                if (blog.ImageFile==null)
                {
                    ModelState.AddModelError("", "Image is Required");
                    ViewBag.Categories = db.BlogCategories.ToList();
                    return View(blog);
                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + blog.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    blog.ImageFile.SaveAs(imagePath);
                    Blog.Image = imageName;

                }
                Blog.Title = blog.Title;
                Blog.AddedDate = DateTime.Now;
                Blog.ByAuthor = blog.ByAuthor;
                Blog.Content = blog.Content;
                Blog.BlogCategoryId = blog.BlogCategoryId;
                Blog.ViewCount = blog.ViewCount;
                db.Blogs.Add(Blog);
                db.SaveChanges();
                return RedirectToAction("Index","Blog");
            }
            ViewBag.Categories = db.BlogCategories.ToList();
            return View(blog);
        }
        public ActionResult Update(int id)
        {
            Blog blog = db.Blogs.Find(id);
            if (blog==null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories = db.BlogCategories.ToList();
            return View(blog);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Blog blog)
        {
            if (ModelState.IsValid)
            {
                Blog Blog = db.Blogs.Find(blog.Id);

                if (blog.ImageFile!=null)
                {

                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + blog.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), Blog.Image);

                    blog.ImageFile.SaveAs(imagePath);
                    System.IO.File.Delete(oldImagePath);

                    Blog.Image = imageName;
                }
                Blog.Title = blog.Title;
                Blog.ByAuthor = blog.ByAuthor;
                Blog.BlogCategoryId = blog.BlogCategoryId;
                Blog.Content = blog.Content;

                db.Entry(Blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Blog");

            }

            ViewBag.Categories = db.BlogCategories.ToList();
            return View(blog);
        }
        public ActionResult Delete(int id)
        {
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            db.Blogs.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index", "Blog");
        }

        /* Blog Categoies CRUD */
        public ActionResult CategoryIndex()
        {
            List<BlogCategory> categories = db.BlogCategories.ToList();
            return View(categories);
        }
        public ActionResult CategoryCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryCreate(BlogCategory blogCategory)
        {
            if (ModelState.IsValid)
            {
                db.BlogCategories.Add(blogCategory);
                db.SaveChanges();
                return RedirectToAction("CategoryIndex","Blog");
            }
            return View(blogCategory);
        }
        public ActionResult CategoryUpdate(int id)
        {
            BlogCategory blogCategory = db.BlogCategories.Find(id);
            if (blogCategory == null)
            {
                return HttpNotFound();
            }
            return View(blogCategory);
        }
        [HttpPost]
        public ActionResult CategoryUpdate(BlogCategory blogCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CategoryIndex", "Blog");
            }
            return View(blogCategory);
        }
        public ActionResult CategoryDelete(int id)
        {
            BlogCategory blogCategory = db.BlogCategories.Find(id);
            if (blogCategory==null)
            {
                return HttpNotFound();
            }
            db.BlogCategories.Remove(blogCategory);
            db.SaveChanges();

            return RedirectToAction("CategoryIndex", "Blog");
        }

    }
}

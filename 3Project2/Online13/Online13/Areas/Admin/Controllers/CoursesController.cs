using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online13.DAL;
using Online13.Models;
using System.IO;
using System.Data.Entity;
using Online13.Areas.Admin.Filters;

namespace Online13.Areas.Admin.Controllers
{
    [Logout]
    public class CoursesController : Controller
    {
        // GET: Admin/Courses
        /* Course  CRUD */
        EduContext db = new EduContext();
        public ActionResult Index()
        {
            List<Course> courses = db.Courses.Include("CourseCategory").ToList();
            return View(courses);

        }
        public ActionResult Create()
        {
            ViewBag.Categories = db.CourseCategories.ToList();
            return View();

        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                Course Course = new Course();

                if (course.ImageFile==null)
                {
                    ModelState.AddModelError("", "Image is Required");
                    ViewBag.Categories = db.CourseCategories.ToList();
                    return View(course);

                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + course.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);
                    course.ImageFile.SaveAs(imagePath);
                    Course.Image = imageName;
                }
                Course.Name = course.Name;
                Course.InputContent = course.InputContent;
                Course.Content = course.Content;
                Course.Starts = course.Starts;
                Course.Duration = course.Duration;
                Course.ClassDuration = course.ClassDuration;
                Course.SkillLevel = course.SkillLevel;
                Course.Language = course.Language;
                Course.StudentCount = course.StudentCount;
                Course.Assesments = course.Assesments;
                Course.Price = course.Price;
                Course.CourseCategoryId = course.CourseCategoryId;

                db.Courses.Add(Course);
                db.SaveChanges();
                return RedirectToAction("Index","Courses");

            }
            ViewBag.Categories = db.CourseCategories.ToList();

            return View(course);

        }

        public ActionResult Update(int id)
        {
            Course course = db.Courses.Find(id);
            if (course==null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories = db.CourseCategories.ToList();
            return View(course);

        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Course course)
        {
            if (ModelState.IsValid)
            {
                Course Course = db.Courses.Find(course.Id);

                if (course.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + course.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), Course.Image);

                    course.ImageFile.SaveAs(imagePath);
                    System.IO.File.Delete(oldImagePath);

                    Course.Image = imageName;

                }
                Course.Name = course.Name;
                Course.InputContent = course.InputContent;
                Course.Content = course.Content;
                Course.Starts = course.Starts;
                Course.Duration = course.Duration;
                Course.ClassDuration = course.ClassDuration;
                Course.SkillLevel = course.SkillLevel;
                Course.Language = course.Language;
                Course.StudentCount = course.StudentCount;
                Course.Assesments = course.Assesments;
                Course.Price = course.Price;
                Course.CourseCategoryId = course.CourseCategoryId;

                db.Entry(Course).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index","Courses");
            }

            ViewBag.Categories = db.CourseCategories.ToList();
            return View(course);

        }

        public ActionResult Delete(int id)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }

            db.Courses.Remove(course);
            db.SaveChanges();

            return RedirectToAction("Index","Courses");
        }




        /* Course Categoies CRUD */

        public ActionResult CategoryIndex()
        {
            List<CourseCategory> categories = db.CourseCategories.ToList();

            return View(categories);
        }
        public ActionResult CategoryCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryCreate(CourseCategory category)
        {
            if (ModelState.IsValid)
            {
                db.CourseCategories.Add(category);
                db.SaveChanges();
                return RedirectToAction("CategoryIndex", "Courses");
            }
            return View(category);
        }

        public ActionResult CategoryUpdate(int id)
        {
            CourseCategory Category = db.CourseCategories.Find(id);
            if (Category == null)
            {
                return HttpNotFound();
            }
            return View(Category);
        }
        [HttpPost]
        public ActionResult CategoryUpdate(CourseCategory Category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CategoryIndex", "Blog");
            }
            return View(Category);
        }
        public ActionResult CategoryDelete(int id)
        {
            CourseCategory Category = db.CourseCategories.Find(id);
            if (Category == null)
            {
                return HttpNotFound();
            }
            db.CourseCategories.Remove(Category);
            db.SaveChanges();

            return RedirectToAction("CategoryIndex", "Blog");
        }

     
    }
}
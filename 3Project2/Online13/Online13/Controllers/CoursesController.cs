using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online13.ViewModels;
using Online13.DAL;
using Online13.Models;



namespace Online13.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses
        EduContext db = new EduContext();
        public ActionResult Index()
        {
            VmCourses models = new VmCourses();
            models.Courses = db.Courses.Include("CourseCategory").ToList();

            ViewBag.Quest = true;
            return View(models);
        }
        public ActionResult CoursesDetails(int id)
        {
            VmCoursesDetails models = new VmCoursesDetails();
            models.Course = db.Courses.Include("CourseCategory").FirstOrDefault(crs=>crs.Id==id);
            models.courseCategories = db.CourseCategories.ToList();
            models.poster = db.Posters.FirstOrDefault(p => p.Id ==id );
            
            
            return View(models);
        }
    }
}
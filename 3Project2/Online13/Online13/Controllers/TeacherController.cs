using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online13.Models;
using Online13.DAL;
using Online13.ViewModels;


namespace Online13.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        EduContext db = new EduContext();
        public ActionResult Index()
        {
            VmTeachers model = new VmTeachers();
            model.Teachers = db.Teachers.Include("Position").Include("SocialTeachers").ToList();

            ViewBag.Quest = true;
            return View(model);
        }
        public ActionResult TeacherDetails(int id)
        {
            VmTeacherSingle model = new VmTeacherSingle();
            model.Teacher = db.Teachers.Include("Position").Include("SocialTeachers").FirstOrDefault(m=>m.Id==id);
            model.TeacherContactData = db.TeacherContactDatas.FirstOrDefault();
            return View(model);
        }
    }
}
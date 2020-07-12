using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online13.DAL;
using Online13.Models;
using Online13.ViewModels;

namespace Online13.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        EduContext db = new EduContext();
        public ActionResult Index()
        {
            VmAbout model = new VmAbout();
            model.About = db.Abouts.FirstOrDefault();
            model.setting = db.Settings.FirstOrDefault();
            model.Notices = db.Notices.ToList();
            model.aboutSliders = db.AboutSliders.ToList();
            model.Teachers = db.Teachers.OrderBy(t=>t.Id).Take(4).Include("Position").Include("SocialTeachers").ToList();
           
            return View(model);
        }
    }
}
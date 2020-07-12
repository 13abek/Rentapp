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
    public class SocialTeacherController : Controller
    {
        // GET: Admin/SocialTeacher
        EduContext db = new EduContext();
        public ActionResult Index()
        {
            List<SocialTeacher> socials = db.SocialTeachers.Include("Teacher").ToList();

            return View(socials);
        }
        public ActionResult Create()
        {
            ViewBag.Teachers = db.Teachers.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(SocialTeacher social)
        {
            if (ModelState.IsValid)
            {
                SocialTeacher Social = new SocialTeacher();
            
                Social.TeacherId = social.TeacherId;
                Social.Name = social.Name;
                Social.Icon = social.Icon;
                Social.Link = social.Link;

                db.SocialTeachers.Add(Social);
                db.SaveChanges();
                return RedirectToAction("Index", "SocialTeacher");

            }
            ViewBag.Teachers = db.Teachers.ToList();
            return View(social);
        }
        public ActionResult Update(int id)
        {
            SocialTeacher social = db.SocialTeachers.Find(id);
            if (social==null)
            {
                return HttpNotFound();
            }

            ViewBag.Teachers = db.Teachers.ToList();
            return View(social);
        }
        [HttpPost]
        public ActionResult Update( SocialTeacher social)
        {
            if (ModelState.IsValid)
            {
                db.Entry(social).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Team = db.SocialTeachers.ToList();
            return View(social);
        }

        public ActionResult Delete(int id)
        {
            SocialTeacher social = db.SocialTeachers.Find(id);
            if (social == null)
            {
                return HttpNotFound();
            }

            db.SocialTeachers.Remove(social);
            db.SaveChanges();

            return RedirectToAction("Index", "SocialTeacher");
        }

    }
}
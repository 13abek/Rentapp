using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Online13.DAL;
using Online13.Models;
using System.Data.Entity;
using Online13.Areas.Admin.Filters;

namespace Online13.Areas.Admin.Controllers
{

    [Logout]
    public class ApplicationController : Controller
    {
        // GET: Admin/Application
        EduContext db = new EduContext();
        public ActionResult Index()
        {
            List<Application> applications = db.Applications.ToList();
            return View(applications);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create( Application application)
        {
            if (ModelState.IsValid)
            {
                Application Application = new Application();
                Application.Name = application.Name;
                Application.Email = application.Email;
                Application.Phone = application.Phone;
                Application.Subject = application.Subject;
                Application.Message = application.Message;
                Application.CreatedDate = DateTime.Now;

                db.Applications.Add(Application);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            

            return View(application);
        }
        public ActionResult Update(int id)
        {
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();

            }
            return View(application);
        }
        [HttpPost]
        public ActionResult Update(Application application)
        {
            if (ModelState.IsValid)
            {
                Application Application = db.Applications.Find(application.Id);

                Application.Name = application.Name;
                Application.Email = application.Email;
                Application.Phone = application.Phone;
                Application.Subject = application.Subject;
                Application.Message = application.Message;
                Application.CreatedDate = DateTime.Now;

                db.Entry(Application).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");

            }
            return View(application);
        }
        public ActionResult Delete(int id)
        {
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();

            }
            db.Applications.Remove(application);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
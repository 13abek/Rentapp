using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online13.DAL;
using Online13.Models;
using System.IO;
using System.Data.Entity;
using System.Web.Helpers;
using Online13.Areas.Admin.Filters;

namespace Online13.Areas.Admin.Controllers
{
    [Logout]
    public class pageAdminController : Controller
    {
        // GET: Admin/pageAdmin
        EduContext db = new EduContext();
        public ActionResult Index()
        {
            List<pageAdmin> admins = db.pageAdmins.ToList();
            return View(admins);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create( pageAdmin admin)
        {
            if (ModelState.IsValid)
            {
                pageAdmin Admin = new pageAdmin();
                Admin.FullName = admin.FullName;
                Admin.AdminName = admin.AdminName;
                Admin.Password = Crypto.HashPassword(admin.Password);

                db.pageAdmins.Add(Admin);
                db.SaveChanges();

               return RedirectToAction("Index","pageAdmin");
            }
            return View(admin);
        }
        public ActionResult Update(int id)
        {
            pageAdmin admin = db.pageAdmins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }

            return View(admin);
        }
        [HttpPost]
        public ActionResult Update(pageAdmin admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admin);
        }
        public ActionResult Delete(int id)
        {
            pageAdmin admin = db.pageAdmins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            db.pageAdmins.Remove(admin);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
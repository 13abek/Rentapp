using Online13.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online13.DAL;
using Online13.Models;
using System.Web.Helpers;
using Online13.Areas.Admin.Filters;

namespace Online13.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        EduContext db = new EduContext();
        [Logout]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        { 
            return View();
        }
        [HttpPost]
        public ActionResult Login(VmLogin login)
        {
            if (ModelState.IsValid)
            {
                pageAdmin admin = db.pageAdmins.FirstOrDefault(a => a.AdminName == login.Username);

                if (admin!=null)
                {
                    if (Crypto.VerifyHashedPassword(admin.Password,login.Password)==true)
                    {
                        Session["Loginner"] = admin;
                        Session["LoginnerId"] = admin.Id;

                        return RedirectToAction("Index");
                    }
                }
            }
            return View(login);
        }
        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Login");
        }
    }
}
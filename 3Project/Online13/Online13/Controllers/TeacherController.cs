using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online13.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            ViewBag.Quest = true;
            return View();
        }
        public ActionResult TeacherDetails()
        {
            return View();
        }
    }
}
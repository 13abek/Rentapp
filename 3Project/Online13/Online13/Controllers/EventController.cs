using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online13.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index()
        {
            ViewBag.Quest = true;
            return View();
        }
        public ActionResult EventDetails()
        {
            return View();
        }
    }
}
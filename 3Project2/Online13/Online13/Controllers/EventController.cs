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
    public class EventController : Controller
    {
        // GET: Event
        EduContext db = new EduContext();
        public ActionResult Index()
        {
            ViewBag.Quest = true;
            VmEvent model = new VmEvent();
            model.events = db.Events.Include("EventCategory").ToList();
            return View(model);

        }
        public ActionResult EventDetails(int id)
        {
            VmEventSingle model = new VmEventSingle();

            model.Event = db.Events.Include("EventCategory").Include("EventRelSpeakers").FirstOrDefault(e=>e.Id==id);
            model.eventRelSpeakers = db.eventRelSpeakers.ToList();
            model.positions = db.Positions.ToList();
            return View(model);
        }
    }
}
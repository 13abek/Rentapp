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
    public class EventRelSpeakerController : Controller
    {
        // GET: Admin/EventRelSpeaker
        EduContext db = new EduContext();
        public ActionResult Index()
        {
            List<EventRelSpeakers> eventRel = db.eventRelSpeakers.ToList();
            return View(eventRel);
        }
        public ActionResult Create()
        {
            ViewBag.Events = db.Events.ToList();
            ViewBag.Speakers = db.Speakers.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create( EventRelSpeakers eventRelSpeaker)
        {
            EventRelSpeakers EventRelSpeakers = new EventRelSpeakers();
            if (ModelState.IsValid)
            {

                EventRelSpeakers.SpeakerId = eventRelSpeaker.SpeakerId;
                EventRelSpeakers.EventId = eventRelSpeaker.EventId;

            }
            return View();
        }
        public ActionResult Update(int id)
        {
            EventRelSpeakers eventRelSpeaker = db.eventRelSpeakers.Find(id);
            if (eventRelSpeaker==null)
            {
                return HttpNotFound();
            }
            ViewBag.Events = db.Events.ToList();
            ViewBag.Speakers = db.Speakers.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Update(EventRelSpeakers eventRelSpeaker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventRelSpeaker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "EventRelSpeaker");
            }
            ViewBag.Events = db.Events.ToList();
            ViewBag.Speakers = db.Speakers.ToList();
            return View(eventRelSpeaker);
        }
        public ActionResult Delete(int id)
        {
            EventRelSpeakers eventRelSpeaker = db.eventRelSpeakers.Find(id);
            if (eventRelSpeaker == null)
            {
                return HttpNotFound();
            }
            db.eventRelSpeakers.Remove(eventRelSpeaker);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
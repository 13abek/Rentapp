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
    public class EventController : Controller
    {
        // GET: Admin/Event
        EduContext db = new EduContext();
        /* Event CRUD */
        public ActionResult Index()
        {
            List<Event> events = db.Events.Include("EventCategory").ToList();

            return View(events);
        }
        public ActionResult Create()
        {
            ViewBag.Categories = db.eventCategories.ToList();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Event @event)
        {
            if (ModelState.IsValid)
            {
                Event @Event = new Event();
                if (@event.ImageFile == null)
                {
                    ModelState.AddModelError("", "Image is Required");
                    ViewBag.Categories = db.eventCategories.ToList();
                    return View(@event);
                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + @event.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    @event.ImageFile.SaveAs(imagePath);
                    @Event.Image = imageName;

                }
                @Event.Title = @event.Title;
                @Event.StarsTime = @event.StarsTime;
                @Event.EndTime = @event.EndTime;
                @Event.Venue = @event.Venue;
                @Event.Content = @event.Content;
                @Event.AddedDate = DateTime.Now;
                @Event.EventCategoryId = @event.EventCategoryId;
                db.Events.Add(@Event);
                db.SaveChanges();
                return RedirectToAction("Index", "Event");
            }
            ViewBag.Categories = db.eventCategories.ToList();
            return View(@event);
        }
        public ActionResult Update(int id)
        {
            Event @event = db.Events.Find(id);
            if (@event==null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories = db.eventCategories.ToList();
            return View(@event);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Event @event)
        {
            if (ModelState.IsValid)
            {

                Event @Event = db.Events.Find(@event.Id);

                if (@event.ImageFile != null)
                {

                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + @event.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), @Event.Image);

                    @event.ImageFile.SaveAs(imagePath);
                    System.IO.File.Delete(oldImagePath);

                    @Event.Image = imageName;
                }
                @Event.Title = @event.Title;
                @Event.StarsTime = @event.StarsTime;
                @Event.EndTime = @event.EndTime;
                @Event.Venue = @event.Venue;
                @Event.Content = @event.Content;
                @Event.AddedDate = DateTime.Now;
                @Event.EventCategoryId = @event.EventCategoryId;

                db.Entry(@Event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Blog");

            }


            ViewBag.Categories = db.eventCategories.ToList();
            return View();
        }


        public ActionResult Delete(int id)
        {
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            db.Events.Remove(@event);
            db.SaveChanges();
            return RedirectToAction("Index", "Event");
        }

        /* Event Categoies CRUD */
        public ActionResult CategoryIndex()
        {
            List<EventCategory> categories = db.eventCategories.ToList();
            return View(categories);
        }
        public ActionResult CategoryCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryCreate(EventCategory category)
        {
            if (ModelState.IsValid)
            {
                db.eventCategories.Add(category);
                db.SaveChanges();
                return RedirectToAction("CategoryIndex", "Event");
            }
            return View(category);
        }
        public ActionResult CategoryUpdate(int id)
        {
            EventCategory category = db.eventCategories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        [HttpPost]
        public ActionResult CategoryUpdate(EventCategory category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CategoryIndex", "Event");
            }
            return View(category);
        }
        public ActionResult CategoryDelete(int id)
        {
            EventCategory category = db.eventCategories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            db.eventCategories.Remove(category);
            db.SaveChanges();

            return RedirectToAction("CategoryIndex", "Event");
        }

    }
}
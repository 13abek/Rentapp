using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online13.DAL;
using Online13.Models;
using System.Data.Entity;
using System.IO;

namespace Online13.Areas.Admin.Controllers
{
    public class SpeakerController : Controller
    {
        // GET: Admin/Speaker
        EduContext db = new EduContext();
        public ActionResult Index()
        {
            List<Speaker> speakers = db.Speakers.Include("Position").ToList();

            return View(speakers);
        }
        public ActionResult Create()
        {
            ViewBag.Position = db.Positions.ToList();

            return View();
        }
        [HttpPost]
        public ActionResult Create(Speaker speaker)
        {
            if (ModelState.IsValid)
            {
                Speaker Speaker = new Speaker();

                if (speaker.ImageFile==null)
                {
                    ModelState.AddModelError("","Image is required");

                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + speaker.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    speaker.ImageFile.SaveAs(imagePath);
                    Speaker.Image = imageName;
                    
                }
                Speaker.FullName = speaker.FullName;
                Speaker.PositionId = speaker.PositionId;

                db.Speakers.Add(Speaker);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.Position = db.Positions.ToList();

            return View(speaker);
        }

        public ActionResult Update(int id)
        {
            Speaker speaker = db.Speakers.Find(id);
            if (speaker==null)
            {
                return HttpNotFound();

            }
            ViewBag.Position = db.Positions.ToList();

            return View(speaker);
        }
        [HttpPost]
        public ActionResult Update(Speaker speaker)
        {
            if (ModelState.IsValid)
            {
                Speaker Speaker = db.Speakers.Find(speaker.Id);
                if (speaker.ImageFile!=null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + speaker.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), speaker.Image);

                    speaker.ImageFile.SaveAs(imagePath);
                    System.IO.File.Delete(oldImagePath);


                    Speaker.Image = imageName;
                }
                Speaker.FullName = speaker.FullName;
                Speaker.PositionId = speaker.PositionId;

                db.Entry(Speaker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            ViewBag.Position = db.Positions.ToList();

            return View(speaker);
        }
        public ActionResult Delete(int id)
        {
            Speaker speaker = db.Speakers.Find(id);
            if (speaker==null)
            {
                return HttpNotFound();
            }
            db.Speakers.Remove(speaker);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
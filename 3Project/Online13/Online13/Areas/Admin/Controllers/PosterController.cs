using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online13.DAL;
using Online13.Models;
using System.IO;
using System.Data.Entity;

namespace Online13.Areas.Admin.Controllers
{
    public class PosterController : Controller
    {
        // GET: Admin/Poster
        EduContext db = new EduContext();
        public ActionResult Index()
        {
            List<Poster> posters = db.Posters.ToList();
            return View(posters);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Poster poster)
        {
            if (ModelState.IsValid)
            {
                Poster Poster = new Poster();

                if (poster.ImageFile == null)
                {
                    ModelState.AddModelError("", "Image is Required");
                    return View(poster);

                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + poster.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);
                    poster.ImageFile.SaveAs(imagePath);
                    Poster.Image = imageName;
                }
                Poster.Page = poster.Page;
                Poster.Title = poster.Title;

                db.Posters.Add(Poster);
                db.SaveChanges();

                return RedirectToAction("Index");

            }
            return View(poster);
        }

        public ActionResult Update(int id)
        {
            Poster poster = db.Posters.Find(id);
            if (poster == null)
            {
                return HttpNotFound();
            }
            return View(poster);
        }
        [HttpPost]
        public ActionResult Update(Poster poster)
        {
            if (ModelState.IsValid)
            {
                Poster Poster = db.Posters.Find(poster.Id);

                if (poster.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + poster.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), Poster.Image);

                    poster.ImageFile.SaveAs(imagePath);
                    System.IO.File.Delete(oldImagePath);

                    Poster.Image = imageName;

                }
                Poster.Title = poster.Title;
                Poster.Page = poster.Page;

                db.Entry(Poster).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index","Poster");
            }
            return View(poster);
        }

        public ActionResult Delete(int id)
        {
            Poster poster = db.Posters.Find(id);
            if (poster == null)
            {
                return HttpNotFound();
            }

            db.Posters.Remove(poster);
            db.SaveChanges();

            return RedirectToAction("Index", "Poster");
        }


    }
}
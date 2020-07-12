using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online13.DAL;
using Online13.Models;
using System.IO;
using System.Data.Entity;
using Online13.Areas.Admin.Filters;

namespace Online13.Areas.Admin.Controllers
{
    [Logout]
    public class IntroImageController : Controller
    {
        // GET: Admin/IntroImage
        EduContext db = new EduContext();
        public ActionResult Index()
        {
            List<IntroImage> intros = db.IntroImages.ToList();
            return View(intros);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(IntroImage intro)
        {
            if (ModelState.IsValid)
            {
                IntroImage  Intro = new IntroImage();

                if (intro.ImageFile == null)
                {
                    ModelState.AddModelError("", "Image is Required");
                    return View(intro);

                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + intro.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);
                    intro.ImageFile.SaveAs(imagePath);
                    Intro.Image = imageName;
                }
                Intro.Page = intro.Page;
                Intro.Title = intro.Title;

                db.IntroImages.Add(Intro);
                db.SaveChanges();

                return RedirectToAction("Index");

            }
            return View(intro);
        }

        public ActionResult Update(int id)
        {
            IntroImage intro = db.IntroImages.Find(id);
            if (intro == null)
            {
                return HttpNotFound();
            }
            return View(intro);
        }
        [HttpPost]
        public ActionResult Update(IntroImage intro)
        {
            if (ModelState.IsValid)
            {
                IntroImage Intro = db.IntroImages.Find(intro.Id);

                if (intro.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + intro.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), Intro.Image);

                    intro.ImageFile.SaveAs(imagePath);
                    System.IO.File.Delete(oldImagePath);

                    Intro.Image = imageName;

                }
                Intro.Title = intro.Title;
                Intro.Page = intro.Page;

                db.Entry(Intro).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(intro);
        }

        public ActionResult Delete(int id)
        {
            IntroImage intro = db.IntroImages.Find(id);

            if (intro == null)
            {
                return HttpNotFound();
            }

            db.IntroImages.Remove(intro);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
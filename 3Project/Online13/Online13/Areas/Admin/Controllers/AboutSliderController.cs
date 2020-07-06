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
    public class AboutSliderController : Controller
    {
        // GET: Admin/AboutSlider
        EduContext db = new EduContext();
        public ActionResult Index()
        {
            List<AboutSlider> aboutSliders = db.AboutSliders.ToList();
            return View(aboutSliders);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(AboutSlider slider)
        {
            if (ModelState.IsValid)
            {
                string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + slider.ImageFile.FileName;
                string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                slider.ImageFile.SaveAs(imagePath);
                slider.Image = imageName;

                db.AboutSliders.Add(slider);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(slider);
        }
        public ActionResult Update(int id)
        {
            AboutSlider slider = db.AboutSliders.Find(id);
            if (slider==null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }
        [HttpPost]
        public ActionResult Update(AboutSlider slider)
        {
            if (ModelState.IsValid)
            {
                AboutSlider Slider = db.AboutSliders.Find(slider.Id);

                if (slider.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + slider.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldImage = Path.Combine(Server.MapPath("~/Uploads/"), Slider.Image);
                    System.IO.File.Delete(oldImage);
                    slider.ImageFile.SaveAs(imagePath);
                    Slider.Image = imageName;

                }
                Slider.FullName = slider.FullName;
                Slider.Content = slider.Content;
                Slider.Position = slider.Position;
                db.Entry(Slider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slider);

        }

        public ActionResult Delete(int id)
        {
            AboutSlider slider = db.AboutSliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            db.AboutSliders.Remove(slider);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
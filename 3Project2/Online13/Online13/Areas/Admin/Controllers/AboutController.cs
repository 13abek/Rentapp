using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online13.Models;
using Online13.DAL;
using Online13.ViewModels;
using System.IO;
using System.Data.Entity;
using Online13.Areas.Admin.Filters;

namespace Online13.Areas.Admin.Controllers
{
    [Logout]
    public class AboutController : Controller
    {
        // GET: Admin/About
        EduContext db = new EduContext();
        public ActionResult Index()
        {
            List<About> abouts = db.Abouts.ToList();
            return View(abouts);
        }

        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create( About about)
        {
            if (ModelState.IsValid)
            {

                string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.ImageFile.FileName;
                string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                string VidebgimageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.VideBGImageFile.FileName;
                string VideBGImagePath = Path.Combine(Server.MapPath("~/Uploads/"), VidebgimageName);

                about.ImageFile.SaveAs(imagePath);
                about.VideBGImageFile.SaveAs(VideBGImagePath);
                about.Image = imageName;
                about.VideBgImage = VidebgimageName;

                db.Abouts.Add(about);
                db.SaveChanges();
              return  RedirectToAction("Index");
            }
            return View(about);
        }
        public ActionResult Update(int id)
        {
            About about = db.Abouts.Find(id);
            if (about==null)
            {
                return HttpNotFound();
            }

            return View(about);
        }
        [HttpPost]
        public ActionResult Update(About about)
        {
            About About = db.Abouts.Find(about.Id);
            if (ModelState.IsValid)
            {
                if (about.ImageFile!=null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/,"), About.Image);
                    System.IO.File.Delete(oldImagePath);
                    about.ImageFile.SaveAs(imagePath);
                    About.Image = imageName;
                }
                if (about.VideBGImageFile!=null)
                {
                    string videoImageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.VideBGImageFile.FileName;
                    string videoImagePath = Path.Combine(Server.MapPath("~/Uploads/"), videoImageName);

                    string oldVideoImagePath = Path.Combine(Server.MapPath("~/Uploads/"), about.VideBgImage);

                    System.IO.File.Delete(oldVideoImagePath);
                    about.VideBGImageFile.SaveAs(videoImagePath);
                    About.VideBgImage = videoImageName;
                }
                About.NoticeTitle = about.NoticeTitle;
                About.Content = about.Content;
                About.VideoLink = about.VideoLink;
                About.VideoTitle = about.VideoTitle;

                db.Entry(About).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(about);
        }
        public ActionResult Delete(int id)
        {
            About about = db.Abouts.Find(id);
            if (about==null)
            {
                return HttpNotFound();
            }
            db.Abouts.Remove(about);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }   
}
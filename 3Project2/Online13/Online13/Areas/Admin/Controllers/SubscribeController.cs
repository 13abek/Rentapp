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
    public class SubscribeController : Controller
    {
        // GET: Admin/Subscribe
        EduContext db = new EduContext();
        public ActionResult Index()
        {
            List<Subscribe> subscribes = db.Subscribes.ToList();
            return View(subscribes);
        }
        //public ActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Create(Subscribe subscribe)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Subscribe Subscribe = new Subscribe();
        //        Subscribe.Email = subscribe.Email;
        //        Subscribe.CreatedDate = DateTime.Now;

        //        db.Subscribes.Add(Subscribe);
        //        db.SaveChanges();

        //        return RedirectToAction("Index", "Subscribe");
        //    }
        //    return View(subscribe);
        //}
        //public ActionResult Update(int id)
        //{
        //    Subscribe subscribe = db.Subscribes.Find(id);
        //    if (subscribe == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(subscribe);
        //}
        //[HttpPost]
        //public ActionResult Update(Subscribe subscribe)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(subscribe).State = EntityState.Modified;

        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(subscribe);
        //}
        public ActionResult Delete(int id)
        {
            Subscribe subscribe = db.Subscribes.Find(id);
            if (subscribe == null)
            {
                return HttpNotFound();
            }
            db.Subscribes.Remove(subscribe);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
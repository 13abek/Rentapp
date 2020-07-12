using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online13.Models;
using Online13.DAL;
using System.IO;
using System.Data.Entity;
using Online13.Areas.Admin.Filters;

namespace Online13.Areas.Admin.Controllers
{
    [Logout]
    public class NoticeController : Controller
    {
        // GET: Admin/Notice
        EduContext db = new EduContext();
        public ActionResult Index()
        {
            List<Notice> notices = db.Notices.ToList();

            return View(notices);
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create( Notice notice)
        {
            if (ModelState.IsValid)
            {
                Notice Notice = new Notice();
                Notice.Content = notice.Content;
                Notice.CreatedDate = DateTime.Now;
                db.Notices.Add(Notice);
                db.SaveChanges();

                return RedirectToAction("Index");

            }
            return View(notice);
        }
        public ActionResult Update(int id)
        {
            Notice notice = db.Notices.Find(id);

            if (notice==null)
            {
                return HttpNotFound();
            }
            return View(notice);
        }
        [HttpPost]
        public ActionResult Update(Notice notice)
        {
            if (ModelState.IsValid)
            {
                Notice Notice = db.Notices.Find(notice.Id);

                Notice.Content = notice.Content;

                db.Entry(Notice).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(notice);
        }

        public ActionResult Delete(int id)
        {
                Notice notice = db.Notices.Find(id);
                if (notice==null)
                {
                    return HttpNotFound();

                }

                db.Notices.Remove(notice);
                db.SaveChanges();

              return  RedirectToAction("Index");
        }


    }
}
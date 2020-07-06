using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Online13.DAL;
using Online13.Models;
using System.Data.Entity;

namespace Online13.Areas.Admin.Controllers
{
    public class TeachersController : Controller
    {
        // GET: Admin/Teachers
        EduContext db = new EduContext();
        public ActionResult Index()
        {
            List<Teacher> teachers = db.Teachers.Include("Position").ToList();
            return View(teachers);
        }
        public ActionResult Create()
        {
            ViewBag.Position = db.Positions.ToList();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                Teacher Teacher = new Teacher();

                if (teacher.ImageFile==null)
                {
                    ModelState.AddModelError("", "Image is requried");
                    ViewBag.Position = db.Positions.ToList();
                    return View(teacher);

                }
                else
                {
                    string imageName = DateTime.Now.ToString("~/Uploads/") + teacher.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    teacher.ImageFile.SaveAs(imagePath);
                    Teacher.Image = imageName;
                }
                Teacher.FullName = teacher.FullName;
                Teacher.Content = teacher.Content;
                Teacher.language = teacher.language;
                Teacher.TeamLeader = teacher.TeamLeader;
                Teacher.Development = teacher.Development;
                Teacher.Design = teacher.Design;
                Teacher.Innoation = teacher.Innoation;
                Teacher.Communication = teacher.Communication;
                Teacher.mail = teacher.mail;
                Teacher.Phone = teacher.Phone;
                Teacher.skpe = teacher.skpe;
                Teacher.PositionId = teacher.PositionId;

                db.Teachers.Add(Teacher);
                db.SaveChanges();
                return RedirectToAction("Index","Teachers");

            }
            ViewBag.Position = db.Positions.ToList();

            return View(teacher);
        }

        public ActionResult Details(int id)
        {
            Teacher teacher = db.Teachers.Find(id);

            if (id == null)
            {
                Session["Nullid"] = true;
                return RedirectToAction("Index");
            }

            return View(teacher);
        }

        public ActionResult Update(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            if (teacher==null)
            {
                return HttpNotFound();
            }
            ViewBag.Position = db.Positions.ToList();
            return View(teacher);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                Teacher Teacher = db.Teachers.Find(teacher.Id);

                if (teacher!=null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + teacher.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), Teacher.Image);

                    teacher.ImageFile.SaveAs(imagePath);
                    System.IO.File.Delete(oldImagePath);

                    Teacher.Image = imageName;

                }
                Teacher.FullName = teacher.FullName;
                Teacher.Content = teacher.Content;
                Teacher.language = teacher.language;
                Teacher.TeamLeader = teacher.TeamLeader;
                Teacher.Design = teacher.Design;
                Teacher.Innoation = teacher.Innoation;
                Teacher.Communication = teacher.Communication;
                Teacher.mail = teacher.mail;
                Teacher.Phone = teacher.Phone;
                Teacher.skpe = teacher.skpe;
                Teacher.PositionId = teacher.PositionId;

                db.Entry(Teacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Teachers");

            }
            ViewBag.Position = db.Positions.ToList();

            return View(teacher);
        }

        public ActionResult Delete(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            if (teacher==null)
            {
                return HttpNotFound();
            }
            db.Teachers.Remove(teacher);
            db.SaveChanges();
            return RedirectToAction("Index", "Teachers");
        }
      
    }
}
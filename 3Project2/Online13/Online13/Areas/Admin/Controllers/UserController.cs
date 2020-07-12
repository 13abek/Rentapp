using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc;
using Online13.DAL;
using Online13.Models;
using System.IO;
using System.Data.Entity;
using System.Web.Helpers;
using Online13.Areas.Admin.Filters;

namespace Online13.Areas.Admin.Controllers
{
    [Logout]
    public class UserController : Controller
    {
        // GET: Admin/User
        EduContext db = new EduContext();
        public ActionResult Index()
        {
            List<User> users = db.Users.ToList();
            return View(users);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                User User = new User();

                if (user.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + user.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    user.ImageFile.SaveAs(imagePath);
                    User.Image = imageName;
                }
                else
                {
                    ModelState.AddModelError("ImageFile", "Image is required");
                    return View(user);
                }

                if (user.Password != null)
                {
                    User.Password = Crypto.HashPassword(user.Password);
                }
                else
                {
                    ModelState.AddModelError("", "Password is required!");
                    return View(user);
                }

                User.Email = user.Email;
                User.FullName = user.FullName;
                User.UserName = user.UserName;
                User.Email = user.Email;
                User.Phone = user.Phone;
                User.CreatedDate = DateTime.Now;

                db.Users.Add(User);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(user);
        }

        public ActionResult Update(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        [HttpPost]
        public ActionResult Update(User user)
        {
            if (ModelState.IsValid)
            {
                User User = db.Users.Find(user.Id);

                if (user.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + user.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), User.Image);
                    System.IO.File.Delete(oldImagePath);

                    user.ImageFile.SaveAs(imagePath);
                    User.Image = imageName;
                }


                User.Email = user.Email;
                User.FullName = user.FullName;
                User.UserName = user.UserName;
                User.Email = user.Email;
                User.Phone = user.Phone; 

                db.Entry(User).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        public ActionResult Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
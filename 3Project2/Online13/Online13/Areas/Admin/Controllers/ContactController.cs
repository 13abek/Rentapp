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
    public class ContactController : Controller
    {
        // GET: Admin/Contact
        EduContext db = new EduContext();
        public ActionResult Index()
        {
            List<Contact> contacts = db.Contacts.ToList();
            return View(contacts);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create( Contact contact)
        {
            if (ModelState.IsValid)
            {
                Contact Contact = new Contact();
                if (contact.ImageFile==null)
                {
                    ModelState.AddModelError("", "Image is Required");
                    return View(contact);

                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + contact.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    contact.ImageFile.SaveAs(imagePath);
                    Contact.Image = imageName;

                }

                Contact.UpperTitle = contact.UpperTitle;
                Contact.FirstTitle = contact.FirstTitle;
                Contact.SecondTitle = contact.SecondTitle;
                db.Contacts.Add(Contact);
                db.SaveChanges();

                return RedirectToAction("Index","Contact");

            }
            return View(contact);
        }
        public ActionResult Update(int id)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact==null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }
        [HttpPost]
        public ActionResult Update(Contact contact)
        {
            if (ModelState.IsValid)
            {
                Contact Contact = db.Contacts.Find(contact.Id);
                if (contact.ImageFile!=null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + contact.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), Contact.Image);

                    contact.ImageFile.SaveAs(imagePath);
                    System.IO.File.Delete(oldImagePath);

                    Contact.Image = imageName;
                }
                Contact.UpperTitle = contact.UpperTitle;
                Contact.FirstTitle = contact.FirstTitle;
                Contact.SecondTitle = contact.SecondTitle;

                db.Entry(Contact).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(contact);
        }
    }
}
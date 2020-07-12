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
    public class SettingsController : Controller
    {
        //// GET: Admin/Settings
        EduContext db = new EduContext();
        public ActionResult Index()
        {
            List<Setting> settings = db.Settings.ToList();
            return View(settings);
        }
        public ActionResult Create()
        {
            

            return View();
        }
        [HttpPost]
        public ActionResult Create(Setting setting)
        {
            if (ModelState.IsValid)
            {
                Setting Setting = new Setting();
                string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + setting.BgImageFile.FileName;
                string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                string logoName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + setting.LogoFile.FileName;
                string logoPath = Path.Combine(Server.MapPath("~/Uploads/"), logoName);



                setting.BgImageFile.SaveAs(imagePath);
                setting.LogoFile.SaveAs(logoPath);

                setting.BgImage = imageName;
                setting.Logo = logoName;

                db.Settings.Add(setting);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(setting);

        }

        public ActionResult Update(int id)
        {
            Setting setting = db.Settings.Find(id);
            if (setting == null)
            {
                return HttpNotFound();
            }

            return View(setting);
        }
        [HttpPost]
        public ActionResult Update(Setting setting)
        {
            if (ModelState.IsValid)
            {
                Setting Setting = db.Settings.Find(setting.Id);


                if (setting.BgImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + setting.BgImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string OldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), Setting.BgImage);
                    System.IO.File.Delete(OldImagePath);

                    setting.BgImageFile.SaveAs(imagePath);
                    Setting.BgImage = imageName;
                }

                if (setting.LogoFile != null)
                {
                    string logoName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + setting.LogoFile.FileName;
                    string logoPath = Path.Combine(Server.MapPath("~/Uploads/"), logoName);

                    string OldLogoPath = Path.Combine(Server.MapPath("~/Uploads/"), Setting.Logo);

                    System.IO.File.Delete(OldLogoPath);

                    setting.LogoFile.SaveAs(logoPath);
                    Setting.Logo = logoName;
                }

                Setting.AddressStreet = setting.AddressStreet;
                Setting.FirstPhone = setting.FirstPhone;
                Setting.SecondPhone = setting.SecondPhone;
                Setting.FirstEmail = setting.FirstEmail;
                Setting.SecondEmail = setting.SecondEmail;
                Setting.FooterContent = setting.FooterContent;
                Setting.CopyRight = setting.CopyRight;
                db.Entry(Setting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
                return View();
        }

        public ActionResult Delete(int id)
        {
            Setting setting = db.Settings.Find(id);
            if (setting == null)
            {
                return HttpNotFound();
            }
            db.Settings.Remove(setting);
            db.SaveChanges();


            return RedirectToAction("Index");
        }

        //SocialCompany Crud

        public ActionResult SocialCompanyIndex()
        {
            List<SocialCompany> socialCompanies = db.SocialCompanies.ToList();

            return View(socialCompanies);
        }
        public ActionResult SocialCompanyCreate()
        {
            ViewBag.Settings = db.Settings.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult SocialCompanyCreate(SocialCompany social)
        {
            if (ModelState.IsValid)
            {
                SocialCompany Social = new SocialCompany();

                Social.Name = social.Name;
                Social.Icon = social.Icon;
                Social.Link = social.Link;
                Social.SettingId = social.SettingId;
                db.SocialCompanies.Add(Social);
                db.SaveChanges();

                return RedirectToAction("SocialCompanyIndex", "Settings");
            }

            ViewBag.Settings = db.Settings.ToList();
            return View(social);
        }

        public ActionResult SocialCompanyUpdate(int id)
        {
            SocialCompany social = db.SocialCompanies.Find(id);
            if (social == null)
            {
                return HttpNotFound();
            }
            ViewBag.Settings = db.Settings.ToList();
            return View(social);
        }
        [HttpPost]
        public ActionResult SocialCompanyUpdate(SocialCompany social)
        {
            if (ModelState.IsValid)
            {
                SocialCompany Social = db.SocialCompanies.Find(social.Id);

                Social.Name = social.Name;
                Social.Icon = social.Icon;
                Social.Link = social.Link;
                Social.SettingId = social.SettingId;

                db.Entry(Social).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SocialCompanyIndex", "Settings");
            }
            ViewBag.Settings = db.Settings.ToList();
            return View(social);
        }

        public ActionResult SocialCompanyDelete(int id)
        {
            SocialCompany social = db.SocialCompanies.Find(id);
            if (social == null)
            {
                return HttpNotFound();
            }
            db.SocialCompanies.Remove(social);
            db.SaveChanges();
            return RedirectToAction("SocialCompanyIndex", "Settings");

        }

    }
}
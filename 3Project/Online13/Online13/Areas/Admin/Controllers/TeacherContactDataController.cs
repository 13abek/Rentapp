using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online13.DAL;
using Online13.Models;



namespace Online13.Areas.Admin.Controllers
{
    public class TeacherContactDataController : Controller
    {
        // GET: Admin/TeacherContactData
        EduContext db = new EduContext();
        public ActionResult Index()
        {
            List<TeacherContactData> teacherContactDatas = db.TeacherContactDatas.ToList();

            return View(teacherContactDatas);
        }
        //public ActionResult Create()
        //{

        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Create(TeacherContactData tcd)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        TeacherContactData TCD = new TeacherContactData();
        //        TCD.UpperTitle = tcd.UpperTitle;
        //        TCD.FirstTitle = tcd.FirstTitle;
        //        TCD.SecondTitle = tcd.SecondTitle;
        //        TCD.ThirdTitle = tcd.ThirdTitle;

        //        db.TeacherContactDatas.Add(TCD);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(tcd);
        //}

        public ActionResult Update(int id)
        {
            TeacherContactData tcd = db.TeacherContactDatas.Find(id);
            if (tcd==null)
            {
                return HttpNotFound();

            }

            return View(tcd);
        }
        [HttpPost]
        public ActionResult Update( TeacherContactData tcd)
        {
            if (ModelState.IsValid)
            {
                TeacherContactData TCD = db.TeacherContactDatas.Find(tcd.Id);
                TCD.UpperTitle = tcd.UpperTitle;
                TCD.FirstTitle = tcd.FirstTitle;
                TCD.SecondTitle = tcd.SecondTitle;
                TCD.ThirdTitle = tcd.ThirdTitle;

                db.Entry(TCD).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");

            }
            return View(tcd);
        }


        public ActionResult Delete(int id)
        {
            TeacherContactData tcd = db.TeacherContactDatas.Find(id);
            if (tcd == null)
            {
                return HttpNotFound();
            }
            db.TeacherContactDatas.Remove(tcd);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
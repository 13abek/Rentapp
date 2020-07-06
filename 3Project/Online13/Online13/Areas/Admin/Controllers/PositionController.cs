using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online13.DAL;
using Online13.Models;
using System.Data.Entity;

namespace Online13.Areas.Admin.Controllers
{
    public class PositionController : Controller
    {
        // GET: Admin/Position
        EduContext db = new EduContext();
        public ActionResult Index()
        {
            List<Position> positions = db.Positions.ToList();

            return View(positions);
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Position position)
        {
            if (ModelState.IsValid)
            {
                Position Position = new Position();
                Position.Name = position.Name;

                db.Positions.Add(Position);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(position);
        }
        public ActionResult Update(int id)
        {
            Position position = db.Positions.Find(id);
            if (position == null)
            {
                return HttpNotFound();

            }

            return View(position);
        }
        [HttpPost]
        public ActionResult Update(Position position )
        {
            if (ModelState.IsValid)
            {
                Position Position = db.Positions.Find(position.Id);
                Position.Name = position.Name;

                db.Entry(Position).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");

            }
            return View(position);
        }


        public ActionResult Delete(int id)
        {
            Position position = db.Positions.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            db.Positions.Remove(position);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
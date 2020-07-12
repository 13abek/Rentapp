using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online13.Models;
using Online13.DAL;
using Online13.ViewModels;

namespace Online13.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        EduContext db = new EduContext();
        public ActionResult Index()
        {
            VmContact model = new VmContact();
            model.Contacts = db.Contacts.ToList();
            return View(model);
        }
    }
}
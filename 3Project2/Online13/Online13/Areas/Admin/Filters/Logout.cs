using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online13.Areas.Admin.Filters
{
    public class Logout : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["Loginner"] == null)
            {
                filterContext.Result = new RedirectResult("~/Admin/Home");
                return;
            }
            base.OnActionExecuting(filterContext);
        }


    }
}
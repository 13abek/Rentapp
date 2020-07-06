using System.Web.Mvc;

namespace Online13.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Register", action = "Login", id = UrlParameter.Optional },
                 new[] { "Online13.Areas.Admin.Controllers" }
            );
        }
    }
}
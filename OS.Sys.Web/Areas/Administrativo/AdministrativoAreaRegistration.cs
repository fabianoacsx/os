using System.Web.Mvc;

namespace OS.Sys.Web.Areas.Administrativo
{
    public class AdministrativoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administrativo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Administrativo_default",
                "Administrativo/{controller}/{action}/{id}",
                new { controller = "Ordens", action = "Index", id = UrlParameter.Optional },
                new[] { "OS.Sys.Web.Areas.Administrativo.Controllers" }
            );
        }
    }
}
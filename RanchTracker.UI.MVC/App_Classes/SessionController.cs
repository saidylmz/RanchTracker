using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RanchTracker.UI.MVC.App_Classes
{
    public class SessionController:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (!HttpContext.Current.Response.IsRequestBeingRedirected)
                    filterContext.HttpContext.Response.Redirect("/Login/Index");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAS.Controllers;
using DAS.Models.DB;

namespace DAS.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUser = (Usuario)HttpContext.Current.Session["User"];

            if(oUser == null)
            {
                if(filterContext.Controller is HomeController == false && filterContext.Controller is AccessController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
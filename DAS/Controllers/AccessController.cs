using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAS.Models.DB;
using DAS.Models.AccessViewModel;

namespace DAS.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Entry(AccessViewModel model)
        {
            try
            {
                using (var db = new UDBEntities())
                {
                    var lsit = from d in db.Usuario
                               where d.mailUser == model.Mail && d.passwordUser == model.Password
                               select d;

                    if (lsit.Count() > 0)
                    {
                        Usuario oUser = lsit.First();
                        Session["User"] = oUser;
                        return Redirect(Url.Content("~/User/"));
                    } else
                    {
                        return Redirect(Url.Content("~/Access/Index"));
                    }
                }
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error" + ex.Message);
            }
        }
    }
}
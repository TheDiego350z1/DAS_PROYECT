using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAS.Models.DB;
using DAS.Models.UserViewModel;
using DAS.Models.UserTableViewModel;

namespace DAS.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            using(var db = new UDBEntities())
            {
                Usuario oUsuario = new Usuario();

                oUsuario.idUser = 1;
                oUsuario.nameUser = model.Name;
                oUsuario.mailUser = model.Mail;
                oUsuario.passwordUser = model.PassWord;

                db.Usuario.Add(oUsuario);

                db.SaveChanges();

            }
            return Redirect(Url.Content("~/User/"));

        }
        public ActionResult ShowUser()
        {
            List<UserTableViewModel> lst = null;
            using (var db = new UDBEntities())
            {
                lst = (from d in db.Usuario
                       select new UserTableViewModel
                       {
                           Id = d.idUser,
                           Name = d.nameUser,
                           Mail = d.mailUser
                       }).ToList();

            }
            return View(lst);
        }
        public ActionResult Edit(int Id)
        {
            EditUserViewModel model = new EditUserViewModel();

            using (var db = new UDBEntities())
            {
                var oUsuario = db.Usuario.Find(Id);

                model.Name = oUsuario.nameUser;
                model.Mail = oUsuario.mailUser;
                model.Id = oUsuario.idUser;
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EditUserViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new UDBEntities())
            {
                var oUsuario = db.Usuario.Find(model.Id);
                oUsuario.nameUser = model.Name;
                oUsuario.mailUser = model.Mail;

                if(model.Password != null && model.Password.Trim() != "")
                {
                    oUsuario.passwordUser = model.Password;
                }
                db.Entry(oUsuario).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/User/ShowUser"));
        }
        [HttpPost]
        public ActionResult Delete (int Id)
        {
            using(var db = new UDBEntities())
            {
                var oUsuario = db.Usuario.Find(Id);
                db.Usuario.Remove(oUsuario);
                db.SaveChanges();
            }

            return Content("1");
        }
    }
}
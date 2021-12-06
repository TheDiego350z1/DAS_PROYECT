using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAS.Models.TipoViewModel;
using DAS.Models.DB;

namespace DAS.Controllers
{
    public class TipoController : Controller
    {
        // GET: Tipo
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TipoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new UDBEntities())
            {
                Tipo oTipo = new Tipo();
                oTipo.idTipo = 1;
                oTipo.nameTipo = model.Name;

                db.Tipo.Add(oTipo);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ShowTipo()
        {
            List<TableTipoViewModel> listTipo = null;
            using (var db = new UDBEntities())
            {
                listTipo = (from d in db.Tipo
                            select new TableTipoViewModel
                            {
                                Id = d.idTipo,
                                Name = d.nameTipo
                            }).ToList();
            }
            return View(listTipo);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            EditTipoViewModel model = new EditTipoViewModel();
            using (var db = new UDBEntities())
            {
                var oTipo = db.Tipo.Find(Id);

                model.Name = oTipo.nameTipo;
                model.Id = oTipo.idTipo;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EditTipoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new UDBEntities())
            {
                var oTipo = db.Tipo.Find(model.Id);
                oTipo.nameTipo = model.Name;

                db.Entry(oTipo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Tipo/ShowTipo"));
        }
    }
}
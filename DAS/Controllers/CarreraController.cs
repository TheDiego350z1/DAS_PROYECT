using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAS.Models.DB;
using DAS.Models.CarreraViewModel;
using PagedList;

namespace DAS.Controllers
{
    public class CarreraController : Controller
    {
        // GET: Carrera
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            List<SelectListItem> listTipo = new List<SelectListItem>();
            using (var db = new UDBEntities())
            {
                listTipo = (from d in db.Tipo
                            select new SelectListItem
                            {
                                Value = d.idTipo.ToString(),
                                Text = d.nameTipo
                            }).ToList();
            }
            ViewBag.TipoList = listTipo;
            return View();
        }
        [HttpPost]
        public ActionResult Create(CarreraViewModel model, string TipoList)
        {
            var RutaSitio = Server.MapPath("~/");
            var NameFile = System.IO.Path.Combine(RutaSitio + "/Upluad/" + model.File.FileName);
            var FileName = System.IO.Path.Combine("/Upluad/" + model.File.FileName);

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.File.SaveAs(NameFile);

            using (var db = new UDBEntities())
            {
                Carrera oCarrera = new Carrera();
                oCarrera.idCarrera = 1;
                oCarrera.nameCarrera = model.Name;
                oCarrera.objetivoCarrera = model.Objetivo;
                oCarrera.perfilEgresoCarrera = model.Perfil;
                oCarrera.areaDesempenoCarrera = model.Area;
                oCarrera.pensumCarrera = FileName.ToString();
                oCarrera.tipoCarrera = int.Parse(TipoList);
                db.Carrera.Add(oCarrera);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ShowCarreras()
        {
            List<ListCarreraViewModel> lstCarrera = new List<ListCarreraViewModel>();

            using (var db = new UDBEntities())
            {
                lstCarrera = (from d in db.Carrera
                              select new ListCarreraViewModel
                              {
                                  Id = d.idCarrera,
                                  Name = d.nameCarrera,
                                  Objetivo = d.objetivoCarrera
                              }).ToList();
            }

            return View(lstCarrera);
        }

        public ActionResult Show(int Id)
        {
            ShowCarreraViewModel model = new ShowCarreraViewModel();

            using (var db = new UDBEntities())
            {
                var oCarrera = db.Carrera.Find(Id);

                model.Name = oCarrera.nameCarrera;
                model.Area = oCarrera.areaDesempenoCarrera;
                model.Perfil = oCarrera.perfilEgresoCarrera;
                model.Objetivo = oCarrera.objetivoCarrera;
                model.Pensum = oCarrera.pensumCarrera;

            }
            return View(model);
        }
    }
}
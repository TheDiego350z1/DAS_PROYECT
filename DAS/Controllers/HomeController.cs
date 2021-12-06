using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAS.Models.DB;
using DAS.Models.ConsultaViewModel;
using DAS.Models.CarreraViewModel;

namespace DAS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Consulta()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Consulta(CosultaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new UDBEntities())
            {
                Consulta oConsulta = new Consulta();

                oConsulta.idConsulta = 1;
                oConsulta.Nombre = model.Nombre;
                oConsulta.tipoConsulta = model.Tipo;
                oConsulta.correoConsulta = model.Correo;
                oConsulta.contenidoConsulta = model.Contendio;

                db.Consulta.Add(oConsulta);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Home"));
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
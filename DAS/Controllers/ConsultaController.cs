using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAS.Models.ConsultaViewModel;
using DAS.Models.DB;

namespace DAS.Controllers
{
    public class ConsultaController : Controller
    {
        // GET: Consulta
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CrearCosulta()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CrearCosulta(CosultaViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            using(var db = new UDBEntities())
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
        public ActionResult ShowConsultas()
        {
            List<ViewConsultaViewModel> lstConsulta = new List<ViewConsultaViewModel>();
            using (var db = new UDBEntities())
            {
                lstConsulta = (from d in db.Consulta
                               select new ViewConsultaViewModel
                               {
                                   Id = d.idConsulta,
                                   Tipo = d.tipoConsulta,
                                   Correo = d.correoConsulta,
                                   Contenido = d.contenidoConsulta,
                                   Nombre = d.Nombre
                               }).ToList();

            }

            return View(lstConsulta);
        }
    }
}
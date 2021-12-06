using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAS.Models.CarreraViewModel
{
    public class CarreraViewModel
    {
        [Required]
        [Display(Name="Nombre de Carrera")]
        public string Name { get; set; }
        [Required]
        [Display(Name="Objetivo de carrera")]
        public string Objetivo { get; set; }
        [Required]
        [Display(Name ="Perfil de carrera")]
        public string Perfil { get; set; }
        [Required]
        [Display(Name ="Area de carrera")]
        public string Area { get; set; }
        [Display(Name="Penum de carrera")]
        public string Pensum { get; set; }
        [Required]
        [Display(Name="Tipo de carrera")]
        public int Tipo { get; set; }
        public HttpPostedFileBase File { get; set; }
    }

    public class ListCarreraViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Objetivo { get; set; }
    }
    public class ShowCarreraViewModel
    {
        public string Name { get; set; }
        public string Objetivo { get; set; }
        public string Perfil { get; set; }
        public string Area { get; set; }
        public string Pensum { get; set; }
    }
}
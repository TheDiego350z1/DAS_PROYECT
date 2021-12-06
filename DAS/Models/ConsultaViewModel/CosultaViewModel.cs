using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAS.Models.ConsultaViewModel
{
    public class CosultaViewModel
    {
        [Required]
        [Display(Name = "Tipo de consulta")]
        public string Tipo { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Correo de Usuario")]
        public string Correo { get; set; }
        [Required]
        [Display(Name = "Contenido de Consulta")]
        public string Contendio { get; set; }
        [Required]
        [Display(Name ="Nombre")]
        public string Nombre { get; set; }

    }
    public class ViewConsultaViewModel
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Correo { get; set; }
        public string Contenido { get; set; }
        public string Nombre { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAS.Models.TipoViewModel
{
    public class TipoViewModel
    {
        [Required]
        [Display(Name="Nombre")]
        public string Name { get; set; }
    }
    public class TableTipoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class EditTipoViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Nombre")]
        public string Name { get; set; }
    }

}
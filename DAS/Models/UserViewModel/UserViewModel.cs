using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAS.Models.UserViewModel
{
    public class UserViewModel
    { 
        [Required]
        [Display(Name = "Nombre de Usuario")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Correo de Usuario")]
        public string Mail { get; set; }
        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
        [Required]
        [Display(Name = "Confirmar Contraseña")]
        [DataType(DataType.Password)]
        [Compare("PassWord", ErrorMessage = "Las contraseñas no son iguales")]
        public string ConfirmPassWord { get; set; }
    }

    public class EditUserViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Nombre de Usuario")]
        public string Name { get; set; }
        [EmailAddress]
        [Display(Name = "Correo de Usuario")]
        public string Mail { get; set; }
        [Display(Name = "Contraseña Usuario")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirmar Contraseña")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contraseñas no son iguales")]
        public string ConfirmPassWord { get; set; }
    }
}
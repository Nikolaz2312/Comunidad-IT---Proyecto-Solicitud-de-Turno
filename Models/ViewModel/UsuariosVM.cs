using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TurnoProyecto.Models.ViewModel
{
    public class UsuariosVM
    {
         [Required(ErrorMessage ="Escriba su Email")]
         public string email {get;set;}
           [Required(ErrorMessage ="Escriba su Contraseña")]
         public string password {get;set;}
    }
}
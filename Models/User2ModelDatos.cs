using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TurnoProyecto.Models
{
    public class User2ModelDatos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userid { get; set; }
        [Required(ErrorMessage ="Escriba su Correo.")]
        [EmailAddress(ErrorMessage ="Escriba un correo valido.")]
        public string email{ get; set; }
        [Required(ErrorMessage ="Escriba su Contraseña.")]
        public string password { get; set; }
        [Required(ErrorMessage ="Escriba su Nombre.")]
        [MinLength(4,ErrorMessage ="Escriba al menos 5 caracteres.")]
        [MaxLength(50, ErrorMessage ="Escriba un maximo de 50 caracteres.")]
        public string nombre { get; set;}
        [Required(ErrorMessage ="Escriba su Apellido.")]
        [MinLength(4,ErrorMessage ="Escriba al menos 5 caracteres.")]
        [MaxLength(50, ErrorMessage ="Escriba un maximo de 50 caracteres.")]
        public string apellido{get;set;}
      
         [Required(ErrorMessage ="Escriba su DNI.")]
        [RegularExpression("^[0-9]{8}", ErrorMessage = "Escriba un DNI valido.")]
        public string dni{get;set;}
        [Required(ErrorMessage ="Ingrese una Fecha de Nacimiento.")]
        public DateTime fechadenacimiento{get;set;}
        
        public string role {get;set;}
       
        public ICollection<AsignarTurno> asignarTurnos {get;set;}
    }
}
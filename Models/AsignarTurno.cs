using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TurnoProyecto.Models
{
    public class AsignarTurno
    {
         [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        
       public int userid{get;set;}
       [ForeignKey("userid")]
       
        public User2ModelDatos UserModelDatos{get;set;}
           
        public int turnoid{get;set;}
        [ForeignKey("turnoid")]
       
       public TurnoModelDatos TurnoModelDatos {get;set;}
    }
}
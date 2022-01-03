using System;
using System.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TurnoProyecto.Models
{
    public class NumeroDeTurnoModelDatos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Nturnoid { get; set; }
        [Required]
        public int Disponible{get;set;}
       
        public int Ocupados {get;set;}
        public int turnoid{get;set;}
        [ForeignKey("turnoid")]
        public TurnoModelDatos turnoModelDatos {get;set;}
        
    }
}
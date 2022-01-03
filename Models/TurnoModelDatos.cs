using System.Data.SqlTypes;
using System;
using System.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TurnoProyecto.Models
{
    public class TurnoModelDatos
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int turnoid{get;set;}
        [Required]
           [DataType(DataType.Date)]
        public DateTime aturno{get;set;}
        [Required]
           [DataType(DataType.Date)]
        public DateTime fturno{get;set;}
        
        public int estado {get;set;}
        
        public int userid{get;set;}
        [ForeignKey("userid")]
        public virtual UserModelDatos UserModelDatos {get;set;}
        public  NumeroDeTurnoModelDatos NumeroDeTurnoModelDatos{get;set;}
    }
}
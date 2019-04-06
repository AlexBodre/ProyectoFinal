using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Models
{
    public class Nomina
    {
        
        public int Id { get; set; }
        [Required]
        public int AÑO { get; set; }
        [Required]
        public int Mes { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString ="{0:#.##RD$}", ApplyFormatInEditMode = false)]
        public double Montototal { get; set; }

    }

   
}
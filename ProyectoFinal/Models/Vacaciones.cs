using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Models
{
    public class Vacaciones
    { 
        public int ID { get; set; }


        public virtual Empleados Empleado { get; set; }
        [Display(Name = "empleado")]
        [ForeignKey("Empleado")]
        [Required]
        public int IdEmpleado { get; set; }
        [Required]
        public int CorrespondientealAÑO { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Desde { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Hasta { get; set; }

        [Required]
        public string Comentarios { get; set; }

    }
}
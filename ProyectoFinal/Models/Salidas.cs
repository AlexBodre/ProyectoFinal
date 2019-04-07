using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Models
{
    public class Salidas
    {
        public int Id { get; set; }

        public virtual Empleados Empleado { get; set; }
        [Display(Name = "empleado")]
        [ForeignKey("Empleado")]
        [Required]
        public int IdEmpleado { get; set; }


        public virtual TipoSalida tipoSalida { get; set; }
        [Display(Name = "Tipo de Salida")]
        [ForeignKey("tipoSalida")]
        [Required]
        public int IdTipoSalidas { get; set; }

        public string Motivo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaSalida { get; set; }
    }
}
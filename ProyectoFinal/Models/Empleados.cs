using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Models
{
    public class Empleados
    {

        public int Id { get; set; }
        [Required]
        public int CodigoEmpleado { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Telefono { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaIngreso { get; set; }

        [Required]
        public Double Salario { get; set; }
        [Required]
        public string Estatus { get; set; }


        public virtual Departamentos departamento { get; set; }
        [Display(Name = "departamento")]
        [ForeignKey("departamento")]
        [Required]
        public int IdDepartamento { get; set; }
        

        
        public virtual Cargos cargo { get; set; }
        [Display(Name = "Cargo")]
        [ForeignKey("cargo")]
        [Required]
        public int IdCargo { get; set; }


    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public DateTime FechaIngreso { get; set; }
        [Required]
        public Double Salario { get; set; }
        [Required]
        public string Estatus { get; set; }

        [Display(Name ="Departamento")]
        public int IdDepartamento { get; set; }
        public Departamentos departamento { get; set; }

        [Display(Name = "Cargo")]
        public int IdCargo { get; set; }
        public Cargos cargo { get; set; }



    }
}
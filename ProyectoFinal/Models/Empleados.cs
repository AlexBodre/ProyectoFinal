using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Models
{
    public class Empleados
    {

        public int Id { get; set; }
        public int CodigoEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Departamento { get; set; }
        public string Cargo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public Double Salario { get; set; }
        public string Estatus { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProyectoFinal.Models
{
    public class AppContext: DbContext
    {
        public AppContext()
            :base("Empleados")
        {
            
        }
        public DbSet<Empleados> Empleados { get; set; } 
        public DbSet<Departamentos> Departamentos { get; set; }
        public DbSet<Cargos> Cargos { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace aereoliniafinal.Models
{
    public class MyDbContext : DbContext
    {

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Ciudades> Ciudades { get; set; }
        public DbSet<TipoEmpleado> TipoEmpleado { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<TipoSexo> TipoSexo { get; set; }
        public DbSet<Aviones> Aviones { get; set; }
        public DbSet<Vuelos> Vuelos { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
    }
}

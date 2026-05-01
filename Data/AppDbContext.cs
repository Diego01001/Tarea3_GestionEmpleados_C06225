using Microsoft.EntityFrameworkCore;
using Tarea3_GestionEmpleados_C06225.Models;

namespace Tarea3_GestionEmpleados_C06225.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Empleado> Empleados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // empleados inciales: 10
            modelBuilder.Entity<Empleado>().HasData(
                new Empleado { Id = 1, Nombre = "Juan", Apellidos = "Pérez", Departamento = "TI", Salario = 850000, FechaIngreso = new DateTime(2022, 1, 15), Activo = true },
                new Empleado { Id = 2, Nombre = "María", Apellidos = "Rodríguez", Departamento = "RRHH", Salario = 600000, FechaIngreso = new DateTime(2021, 5, 20), Activo = true },
                new Empleado { Id = 3, Nombre = "Carlos", Apellidos = "Sánchez", Departamento = "TI", Salario = 950000, FechaIngreso = new DateTime(2023, 3, 10), Activo = true },
                new Empleado { Id = 4, Nombre = "Ana", Apellidos = "López", Departamento = "Contabilidad", Salario = 550000, FechaIngreso = new DateTime(2020, 11, 5), Activo = true },
                new Empleado { Id = 5, Nombre = "Luis", Apellidos = "García", Departamento = "TI", Salario = 1200000, FechaIngreso = new DateTime(2022, 8, 12), Activo = true },
                new Empleado { Id = 6, Nombre = "Elena", Apellidos = "Martínez", Departamento = "Ventas", Salario = 450000, FechaIngreso = new DateTime(2023, 1, 30), Activo = true },
                new Empleado { Id = 7, Nombre = "Pedro", Apellidos = "Gómez", Departamento = "Marketing", Salario = 700000, FechaIngreso = new DateTime(2021, 9, 15), Activo = true },
                new Empleado { Id = 8, Nombre = "Sofía", Apellidos = "Vargas", Departamento = "RRHH", Salario = 620000, FechaIngreso = new DateTime(2022, 4, 18), Activo = true },
                new Empleado { Id = 9, Nombre = "Diego", Apellidos = "Castro", Departamento = "TI", Salario = 1500000, FechaIngreso = new DateTime(2020, 6, 25), Activo = true },
                new Empleado { Id = 10, Nombre = "Lucía", Apellidos = "Mora", Departamento = "Ventas", Salario = 480000, FechaIngreso = new DateTime(2023, 5, 5), Activo = true }
            );
        }
    }
}

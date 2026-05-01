using System;
using System.ComponentModel.DataAnnotations;

namespace Tarea3_GestionEmpleados_C06225.Models
{
    public class Empleado
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(80, ErrorMessage = "El nombre no puede superar los 80 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Los apellidos son obligatorios.")]
        [StringLength(100, ErrorMessage = "Los apellidos no pueden superar los 100 caracteres.")]
        public string Apellidos { get; set; } = string.Empty;

        [Required(ErrorMessage = "El departamento es obligatorio.")]
        public string Departamento { get; set; } = string.Empty;

        [Required(ErrorMessage = "El salario es obligatorio.")]
        [Range(typeof(decimal), "400000", "10000000", ErrorMessage = "El salario debe estar entre 400,000 y 10,000,000.")]
        public decimal Salario { get; set; }

        public DateTime FechaIngreso { get; set; } = DateTime.Now;

        public bool Activo { get; set; } = true;

        public string NombreCompleto
        {
            get
            {
                return $"{Nombre} {Apellidos}";
            }
        }
    }
}
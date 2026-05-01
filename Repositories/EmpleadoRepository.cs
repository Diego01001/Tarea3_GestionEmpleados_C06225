using Tarea3_GestionEmpleados_C06225.Data;
using Tarea3_GestionEmpleados_C06225.Models;

namespace Tarea3_GestionEmpleados_C06225.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly AppDbContext _context;

        public EmpleadoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Empleado> ObtenerTodos()
        {
            return _context.Empleados.OrderBy(e => e.Id).ToList();
        }

        public Empleado? ObtenerPorId(int id)
        {
            return _context.Empleados.Find(id);
        }

        public IEnumerable<Empleado> BuscarPorNombreODepartamento(string termino)
        {
            if (string.IsNullOrWhiteSpace(termino))
                return ObtenerTodos();

            return _context.Empleados
                .Where(e => e.Nombre.ToLower().Contains(termino.ToLower()) ||
                            e.Apellidos.ToLower().Contains(termino.ToLower()) ||
                            e.Departamento.ToLower().Contains(termino.ToLower()))
                .OrderBy(e => e.Id)
                .ToList();
        }

        public IEnumerable<Empleado> ObtenerPaginado(int pagina, int tamano, string? busqueda)
        {
            IQueryable<Empleado> query = _context.Empleados;

            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                string t = busqueda.ToLower();
                query = query.Where(e => e.Nombre.ToLower().Contains(t) ||
                                         e.Apellidos.ToLower().Contains(t) ||
                                         e.Departamento.ToLower().Contains(t));
            }

            return query
                .OrderBy(e => e.Id)
                .Skip((pagina - 1) * tamano)
                .Take(tamano)
                .ToList();
        }

        public int ContarTotal(string? busqueda)
        {
            IQueryable<Empleado> query = _context.Empleados;

            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                string t = busqueda.ToLower();
                query = query.Where(e => e.Nombre.ToLower().Contains(t) ||
                                         e.Apellidos.ToLower().Contains(t) ||
                                         e.Departamento.ToLower().Contains(t));
            }

            return query.Count();
        }

        public void Agregar(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            _context.SaveChanges();
        }

        public void Actualizar(Empleado empleado)
        {
            var existente = _context.Empleados.Find(empleado.Id);
            if (existente != null)
            {
                existente.Nombre = empleado.Nombre;
                existente.Apellidos = empleado.Apellidos;
                existente.Departamento = empleado.Departamento;
                existente.Salario = empleado.Salario;
                existente.FechaIngreso = empleado.FechaIngreso;
                existente.Activo = empleado.Activo;

                _context.Empleados.Update(existente);
                _context.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            var empleado = _context.Empleados.Find(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
                _context.SaveChanges();
            }
        }
    }
}

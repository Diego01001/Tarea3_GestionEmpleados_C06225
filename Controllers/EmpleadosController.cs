using Microsoft.AspNetCore.Mvc;
using Tarea3_GestionEmpleados_C06225.Models;
using Tarea3_GestionEmpleados_C06225.Repositories;

namespace Tarea3_GestionEmpleados_C06225.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly IEmpleadoRepository _repository;
        private const int pageSize = 5;

        public EmpleadosController(IEmpleadoRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index(string? busqueda, int pagina = 1)
        {
            var totalRegistros = _repository.ContarTotal(busqueda);
            var totalPaginas = (int)Math.Ceiling(totalRegistros / (double)pageSize);
            
            // Ensure page is within range
            if (pagina < 1) pagina = 1;
            if (totalPaginas > 0 && pagina > totalPaginas) pagina = totalPaginas;

            var empleados = _repository.ObtenerPaginado(pagina, pageSize, busqueda);

            ViewBag.Busqueda = busqueda;
            ViewBag.PaginaActual = pagina;
            ViewBag.TotalPaginas = totalPaginas;
            ViewBag.TotalRegistros = totalRegistros;

            return View(empleados);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _repository.Agregar(empleado);
                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }

        public IActionResult Edit(int id)
        {
            var empleado = _repository.ObtenerPorId(id);
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _repository.Actualizar(empleado);
                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ToggleActivo(int id)
        {
            var empleado = _repository.ObtenerPorId(id);
            if (empleado == null)
            {
                return NotFound();
            }

            empleado.Activo = !empleado.Activo;
            _repository.Actualizar(empleado);

            return RedirectToAction(nameof(Index));
        }
    }
}

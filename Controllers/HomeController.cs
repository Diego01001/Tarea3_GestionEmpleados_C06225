using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tarea3_GestionEmpleados_C06225.Models;

namespace Tarea3_GestionEmpleados_C06225.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

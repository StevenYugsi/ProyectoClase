using Microsoft.AspNetCore.Mvc;

namespace ProyectoClase.Controllers
{
    public class VentasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

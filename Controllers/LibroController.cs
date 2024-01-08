using Microsoft.AspNetCore.Mvc;

namespace ProyectoClase.Controllers
{
    public class LibroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

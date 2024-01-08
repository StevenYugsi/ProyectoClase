using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using ProyectoClase.Models;
using ProyectoClase.Models.Entidades;

namespace ProyectoClase.Controllers
{   
    public class AutoresController : Controller
    {
        private readonly LibreriaContext _context;

        public AutoresController(LibreriaContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> ListadoAutores()
        {
            return View(await _context.Autores.ToListAsync());
        }
        public IActionResult Crear()
        {
            return View();
        }
        public async Task<IActionResult> Crear(Autor autor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autor);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Autor Creado Exitosamente";
                return RedirectToAction("ListaAutores");
            }
            else
            {
                ModelState.AddModelError(String.Empty, "Ha ocurrido un error");
            }
            return View();
        }
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null || _context.Autores == null)
            {
                return NotFound();
            }
            var autor = await _context.Autores.FirstOrDefaultAsync(n => n.IdAutor == id);
            if (autor == null)
            {
                return NotFound();
            }
            return View (autor);

        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, Autor autor)
        {
            if (id != autor.IdAutor)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autor);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Autor Actualizado Correctamente!!! ";
                    return RedirectToAction("ListadoAutores");


                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(ex.Message, "Ocurrio un error al Actualizar");

                }
            }
            return View(autor);
        }
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.Autores == null)
            {
                return NotFound();
            }
            var autor = await _context.Autores
                .FirstOrDefaultAsync(n => n.IdAutor == id);

            if (autor == null)
            {
                return NotFound();
            }
            try
            {
                _context.Autores.Remove(autor);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Autor eliminado exitosamente";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocurrio un error, no se puede eliminar");

            }
            return RedirectToAction(nameof(ListadoAutores));

        }


    }
}

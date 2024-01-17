using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using ProyectoClase.Models;
using ProyectoClase.Models.Entidades;

namespace ProyectoClase.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly LibreriaContext _context;

        public CategoriaController(LibreriaContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> ListadoCategoria()
        {
            return View(await _context.Categorias.ToListAsync());
        }
        public IActionResult Crear()
        {
            return View();
        }
        public async Task<IActionResult> Crear(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoria);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Categoria Creada Correctamente";
                return RedirectToAction("ListadoCategorias");
            }
            else
            {
                ModelState.AddModelError(String.Empty, "Ha ocurrido un error");
            }
            return View();
        }
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null || _context.Categorias == null)
            {
                return NotFound();
            }
            var categoria = await _context.Categorias.FirstOrDefaultAsync(n => n.IdCategoria == id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(int id, Categoria categoria)
        {
            if (id != categoria.IdCategoria)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoria);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Categoria Actualizada Correctamente!!!";
                    return RedirectToAction("ListadoAutores");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(ex.Message, "Ocurrio un error al Actualizar");
                }
            }
            return View(categoria);
        }
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.Categorias == null)
            {
                return NotFound();
            }
            var categoria = await _context.Categorias
                .FirstOrDefaultAsync(n => n.IdCategoria == id);
            if (categoria == null)
            {
                return NotFound();
            }
            try
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Categoria eliminada Exitosamente";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocurrio un error, no se puede eliminar");

            }
            return RedirectToAction(nameof(ListadoCategoria));
        }
        
    }
}

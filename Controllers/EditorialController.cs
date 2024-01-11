using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoClase.Models;
using ProyectoClase.Models.Entidades;

namespace ProyectoClase.Controllers
{
    public class EditorialController : Controller
    {
        private readonly LibreriaContext _context;

        public EditorialController(LibreriaContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> ListadoEditoriales()
        {
            try
            {
                return View(await _context.editoriales.ToListAsync());
            }
            catch (Exception ex)
            {

                return View(ex);
            }

        }
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Crear(Editorial editorial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(editorial);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Editorial Creado Exitosamente";
                return RedirectToAction("ListadoEditoriales");
            }
            else
            {
                ModelState.AddModelError(String.Empty, "Ha ocurrido un error");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null || _context.editoriales == null)
            {
                return NotFound();
            }

            var editorial = await _context.editoriales.FindAsync(id);
            if (editorial == null)
            {
                return NotFound();
            }
            return View(editorial);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, Editorial editorial)
        {
            if (id != editorial.IdEditorial)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(editorial);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Editorial actualizado " +
                        "exitosamente!!!";
                    return RedirectToAction("ListadoEditoriales");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(ex.Message, "Ocurrio un error " +
                        "al actualizar");
                }
            }
            return View(editorial);
        }
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.editoriales == null)
            {
                return NotFound();
            }
            var editorial = await _context.editoriales
                .FirstOrDefaultAsync(n => n.IdEditorial == id);

            if (editorial == null)
            {
                return NotFound();
            }
            try
            {
                _context.editoriales.Remove(editorial);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Editorial eliminado exitosamente";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocurrio un error, no se puede eliminar");

            }
            return RedirectToAction(nameof(ListadoEditoriales));

        }


    }
}

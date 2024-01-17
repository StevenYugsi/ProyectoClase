using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using ProyectoClase.Models;
using ProyectoClase.Models.Entidades;
using ProyectoClase.Services;

namespace ProyectoClase.Controllers
{
    public class LibrosController : Controller
    {
        private readonly IServicioUsuario _servicioUsuario;
        private readonly IServicioImagen _servicioImagen;
        private readonly IServicioLista _servicioLista;
        private readonly LibreriaContext _context;

        public LibrosController(IServicioUsuario servicioUsuario, IServicioImagen servicioImagen, IServicioLista servicioLista, LibreriaContext context)
        {
            _servicioUsuario = servicioUsuario;
            _servicioImagen = servicioImagen;
            _servicioLista = servicioLista;
            _context = context;
        }
        public async Task<IActionResult> Lista()
        {
            return View(await _context.libros
                .Include(l => l.categoria)
                .Include(l => l.autor)
                .ToListAsync()
                );
        }
        public async Task<IActionResult> Crear()
        {
            Libro libro = await GetLibro();
            return View(libro);
        }

        private async Task<Libro> GetLibro()
        {
            return new Libro()
            {
                Categorias = await _servicioLista.GetListaCategorias(),
                Autores = await _servicioLista.GetListaAutores(),
                Editoriales = await _servicioLista.GetListaEditoriales()
            };
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Libro libro, IFormFile Imagen)
        {
            if (ModelState.IsValid)
            {
                Stream image = Imagen.OpenReadStream();
                string urlImagen = await _servicioImagen.SubirImagen(image, Imagen.Name);
                libro.URLLibro = urlImagen;

                _context.Add(libro);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Libro creado exitosamente ";
                return RedirectToAction("Lista");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Ha ocurrido un error");
            }
            libro.Categorias = await _servicioLista.GetListaCategorias();
            libro.Autores = await _servicioLista.GetListaAutores();
            libro.Editoriales = await _servicioLista.GetListaEditoriales();
            return View(libro);
        }
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var libro = await _context.libros.FindAsync(id);

            if (libro == null)
            {
                return NotFound();
            }
            libro.Categorias = await _servicioLista.GetListaCategorias();
            libro.Autores = await _servicioLista.GetListaAutores();
            return View(libro);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(Libro libro, IFormFile Imagen)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var libroexiste = await _context.libros.FindAsync(libro.IdLibro);
                    if (libroexiste == null)
                    {
                        return NotFound();
                    }
                    if (Imagen != null)
                    {
                        Stream image = Imagen.OpenReadStream();
                        string urlImagen = await _servicioImagen.SubirImagen(image, Imagen.Name);
                        libroexiste.URLLibro = urlImagen;
                    }
                    libroexiste.Titulo = libro.Titulo;
                    libroexiste.autor = await _context.Autores.FindAsync(libro.idAutor);
                    libroexiste.categoria = await _context.Categorias.FindAsync(libro.idCategoria);
                    libroexiste.Precio = libro.Precio;

                    _context.Update(libroexiste);
                    await _context.SaveChangesAsync();
                    TempData["AlertMesage"] = "Libro actualizado exitosamente";
                    return RedirectToAction("Lista");
                }
                catch (Exception ex)
                {
                    TempData["AlertMessage"] = ex;
                    return RedirectToAction("Lista");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Ha ocurrido un error");
            }
            return View();
        }

    }
}

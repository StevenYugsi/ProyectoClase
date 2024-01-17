using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoClase.Models;

namespace ProyectoClase.Services
{
    public class ServicioLista : IServicioLista
    {
        private readonly LibreriaContext _context;

        public ServicioLista(LibreriaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SelectListItem>> GetListaAutores()
        {
            List<SelectListItem> list = await _context.Autores.Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = $"{x.IdAutor}"
            })
                .OrderBy(x => x.Text)
                .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un autor...]",
                Value = "0"
            });
            return list;

        }

        public async Task<IEnumerable<SelectListItem>> GetListaCategorias()
        {
            List<SelectListItem> list = await _context.Categorias.Select(x => new SelectListItem
            {
                Text = x.categoria,
                Value = $"{x.IdCategoria}"
            })
                 .OrderBy(x => x.Text)
                 .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione una Categoria...]",
                Value = "0"
            });
            return list;
        }
        public async Task<IEnumerable<SelectListItem>> GetListaEditoriales()
        {
            List<SelectListItem> list = await _context.editoriales.Select(x => new SelectListItem
            {
                Text = x.NombreEditorial,
                Value = $"{x.IdEditorial}"
            })
                .OrderBy(x => x.Text)
                .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un Editorial...]",
                Value = "0"
            });
            return list;

        }

        public async Task<IEnumerable<SelectListItem>> GetListaeditoriales()
        {
            List<SelectListItem> list = await _context.editoriales.Select(x => new SelectListItem
            {
                Text = x.NombreEditorial,
                Value = $"{x.IdEditorial}"
            })
                .OrderBy(x => x.Text)
                .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un Editorial...]",
                Value = "0"
            });
            return list;
        }
    }
}

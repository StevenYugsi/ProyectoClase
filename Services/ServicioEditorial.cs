using Microsoft.EntityFrameworkCore;
using ProyectoClase.Models;
using ProyectoClase.Models.Entidades;

namespace ProyectoClase.Services
{
    public class ServicioEditorial : IServicioEditorial
    {
        private readonly LibreriaContext _context;

        public ServicioEditorial(LibreriaContext context)
        {
            _context = context;
        }
        public async Task<Editorial> GetEditorial(string NombreEdictorial)
        {
            Editorial editorial = await _context.editoriales.Where(u => u.NombreEdictorial == NombreEdictorial).FirstOrDefaultAsync();
            return editorial;
        }

        public async Task<Editorial> GetEditoriales(string editoriales)
        {
            return await _context.editoriales.FirstOrDefaultAsync(u => u.NombreEdictorial == editoriales);
        }

        public async Task<Editorial> SaveEditorial(Editorial editorial)
        {
            _context.editoriales.Add(editorial);
            await _context.SaveChangesAsync();
            return editorial;
        }
    }
}

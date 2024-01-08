using Microsoft.EntityFrameworkCore;
using ProyectoClase.Models;
using ProyectoClase.Models.Entidades;

namespace ProyectoClase.Services
{
    public class ServicioAutores : IServicioAutores
    {
        private readonly LibreriaContext _context;

        public ServicioAutores(LibreriaContext context)
        {
            _context = context;
        }

        public async Task<Autor> GetAutor(string Nombre, string Apellido)
        {
            Autor Autor = await _context.Autores.Where(u => u.Nombre == Nombre && u.Apellido == Apellido).FirstOrDefaultAsync();
            return Autor;
        }  
        public async Task<Autor> GetAutor(string nombreAutor)
        {
            return await _context.Autores.FirstOrDefaultAsync(u => u.Nombre == nombreAutor);
        }
        public async Task<Autor> SaveAutor(Autor Nombre)
        {
            _context.Autores.Add(Nombre);
            await _context.SaveChangesAsync();
            return Nombre;
        }
    }
}

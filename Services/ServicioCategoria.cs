using Microsoft.EntityFrameworkCore;
using ProyectoClase.Models;
using ProyectoClase.Models.Entidades;


namespace ProyectoClase.Services
{
    public class ServicioCategoria : IServicioCategoria
    {
        private readonly LibreriaContext _context;

        public ServicioCategoria(LibreriaContext context)
        {
            _context = context;
        }
        public async Task<Categoria> GetCategoria(string categoria, string descripcion)
        {
            Categoria Categoria = await _context.Categorias.Where(u => u.categoria == categoria && u.Descripcion == descripcion).FirstOrDefaultAsync();
            return Categoria; 
        }

        public async Task<Categoria> GetCategoria(string nombrecategoria)
        {
            return await _context.Categorias.FirstOrDefaultAsync(u => u.categoria == nombrecategoria);
        }

        public async Task<Categoria> SaveCategoria(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }
    }
}

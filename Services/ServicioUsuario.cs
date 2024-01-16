using Microsoft.EntityFrameworkCore;
using ProyectoClase.Models;
using ProyectoClase.Models.Entidades;

namespace ProyectoClase.Services
{
    public class ServicioUsuario : IServicioUsuario
    {
        private readonly LibreriaContext _context;

        public ServicioUsuario(LibreriaContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GetUsuario(string correo, string contraseña)
        {
            Usuario usuario = await _context.usuarios.Where(u => u.Correo == correo && u.Contraseña == contraseña).FirstOrDefaultAsync();
            return usuario;
        }

        public async Task<Usuario> GetUsuario(string nombreUsuario)
        {
            return await _context.usuarios.FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario);
        }

        public async Task<Usuario> SaveUsuario(Usuario usuario)
        {
            _context.usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
    }
}

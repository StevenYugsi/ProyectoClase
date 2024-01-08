using ProyectoClase.Models.Entidades;

namespace ProyectoClase.Services
{
    public interface IServicioUsuario
    {
        Task<Usuario> GetUsuario(string correo, string contraseña);
        Task<Usuario> SaveUsuario(Usuario usuario);
        Task<Usuario> GetUsuario(string nombreUsuario);

    }
}

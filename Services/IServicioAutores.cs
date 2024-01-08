using ProyectoClase.Models.Entidades;

namespace ProyectoClase.Services
{
    public interface IServicioAutores
    {
        Task<Autor> GetAutor(string Nombre, string Apellido);
        Task<Autor> SaveAutor(Autor Nombre);
        Task<Autor> GetAutor(string nombreAutor);
    }
}

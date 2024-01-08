using ProyectoClase.Models.Entidades;

namespace ProyectoClase.Services
{
    public interface IServicioCategoria
    {
        Task<Categoria> GetCategoria(string categoria, string descripcion);
        Task<Categoria> SaveCategoria(Categoria categoria);
        Task<Categoria> GetCategoria(string nombrecategoria);
    }
}

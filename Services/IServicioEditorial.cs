using ProyectoClase.Models.Entidades;

namespace ProyectoClase.Services
{
    public interface IServicioEditorial
    {
        Task<Editorial> GetEditorial(string NombreEdictorial);
        Task<Editorial> SaveEditorial(Editorial editorial);
        Task<Editorial> GetEditoriales(string editoriales);
    }
}

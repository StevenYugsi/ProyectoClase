using Microsoft.EntityFrameworkCore;
using ProyectoClase.Models.Entidades;

namespace ProyectoClase.Models
{
    public class LibreriaContext : DbContext
    {
        public LibreriaContext() { 
        }
        public LibreriaContext(DbContextOptions<LibreriaContext> options) : base(options)
        {

        }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<DetalleVentas> detalleVentas { get; set; }
        public DbSet<Editorial> editoriales { get; set; }
        public DbSet<Libro> libros { get; set; }   
        public DbSet<Roles> roles { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Ventas> ventas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
